using Domain.Contracts.Response;
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
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        /// <summary>
        /// Create an registration.
        /// </summary>
        /// <returns>A newly created registration</returns>
        /// <response code="201">created with success</response>
        /// <response code="400">If bad request</response>
        /// <response code="500">If internal error server</response>            
        [HttpPost]
        [Route("/registration")]
        [ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(List<ErrorsResponse>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post([FromBody]RegistrationRequest registrationRequest)
        {
            try
            {
                var response = await _registrationService.Add(registrationRequest);
                var notifications = _registrationService as Notifiable;

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