using Domain.Contracts.Interfaces.Services;
using Domain.Contracts.Requests;
using Domain.Contracts.Response;
using Domain.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restful.Login.API.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserRegisterService _userRegisterService;

        public RegisterController(IUserRegisterService UserRegisterService)
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
        [Route("/registers")]
        [AllowAnonymous]
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
        [Route("/registers")]
        [Authorize(Policy = "Bearer", Roles = "Administrator")]
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
        [Authorize(Policy = "Bearer", Roles = "Administrator,Owner")]
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
        [Authorize(Policy = "Bearer", Roles = "Administrator,Owner")]
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
