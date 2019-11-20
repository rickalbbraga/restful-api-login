using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Contracts.Interfaces.Services;
using Domain.Contracts.Requests;
using Domain.Contracts.Response;
using Domain.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Restful.Login.API.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRegisterService _userRegisterService;

        public UsersController(IUserRegisterService UserRegisterService)
        {
            _userRegisterService = UserRegisterService;
        }

        /// <summary>
        /// Create an user.
        /// </summary>
        /// <returns>A newly created user</returns>
        /// <response code="201">created with success</response>
        /// <response code="400">If bad request</response>
        /// <response code="500">If internal error server</response>            
        [HttpPost]
        [Route("/users")]
        [ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(List<ErrorsResponse>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post([FromBody]UserRequest userRequest)
        {
            try
            {
                var response = await _userRegisterService.Add(userRequest);
                var notifications = _userRegisterService as Notifiable;

                if (response == null && !notifications.IsValid)
                    return BadRequest(notifications.Error);

                return Created(string.Empty, response);    
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        /// <summary>
        /// Get all users.
        /// </summary>
        /// <response code="200">List of users</response>
        /// <response code="500">If internal error server</response>            
        [HttpGet]
        [Route("/users")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get()
        {
            try
            {
                var response = await Task.FromResult(_userRegisterService.GetAll());
                return Ok(response);    
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        /// <summary>
        /// Delete user.
        /// </summary>
        /// <response code="204">No Content</response>
        /// <response code="500">If internal error server</response>            
        [HttpDelete]
        [Route("/users/{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await Task.Run(() => _userRegisterService.Delete(id));
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        /// <summary>
        /// Delete user.
        /// </summary>
        /// <response code="204">No Content</response>
        /// <response code="500">If internal error server</response>            
        [HttpPut]
        [Route("/users/{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put([FromBody]UserUpdateRequest userUpdateRequest, Guid id)
        {
            try
            {
                await Task.Run(() => _userRegisterService.Update(userUpdateRequest, id));
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }
    }
}
