﻿using Domain.Contracts.Response;
using Domain.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restful.Login.Domain.Contracts.Interfaces.Services;
using Restful.Login.Domain.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful.Login.API.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    public class StudentGroupController : ControllerBase
    {
        private readonly IStudentGroupService _studentGroupService;

        public StudentGroupController(IStudentGroupService studentGroupService)
        {
            _studentGroupService = studentGroupService;
        }

        /// <summary>
        /// Create an student group.
        /// </summary>
        /// <returns>A newly created student group</returns>
        /// <response code="201">created with success</response>
        /// <response code="400">If bad request</response>
        /// <response code="500">If internal error server</response>            
        [HttpPost]
        [Route("/studentgroups")]
        [ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(List<ErrorsResponse>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post([FromBody]StudentGroupRequest studentRequest)
        {
            try
            {
                var response = await _studentGroupService.Add(studentRequest);
                var notifications = _studentGroupService as Notifiable;

                if (response == null && notifications.Error.Any())
                    return BadRequest(notifications.Error);

                return Created(string.Empty, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }
    }
}