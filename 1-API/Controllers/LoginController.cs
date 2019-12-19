using Domain.Contracts.Response;
using Domain.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restful.Login.Domain.Contracts.Interfaces.Services;
using Restful.Login.Domain.Contracts.Requests;
using Restful.Login.Domain.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful.Login.API.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        /// <summary>
        /// Authenticate on the system.
        /// </summary>
        /// <returns>JWT created</returns>
        /// <response code="201">JWT created with success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Error Server</response>            
        [HttpPost]
        [Route("/authenticate")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(List<ErrorsResponse>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post([FromBody]LoginRequest loginRequest)
        {
            try
            {
                var response = await _loginService.Authentication(loginRequest);
                var notifications = _loginService as Notifiable;

                if (response == null && notifications.Error.Any())
                    return BadRequest(notifications.Error);

                return Created(string.Empty, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        /// <summary>
        /// Logout from system.
        /// </summary>
        /// <response code="204">Logout with success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Error Server</response>            
        [HttpDelete]
        [Route("/authenticate")]
        [Authorize(Policy = "Bearer", Roles = "Administrator,Owner")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(List<ErrorsResponse>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete([FromBody]LoginRequest loginRequest)
        {
            try
            {
                //var response = await _loginService.Authentication(loginRequest);
                //var notifications = _loginService as Notifiable;

                //if (response == null && notifications.Error.Any())
                //    return BadRequest(notifications.Error);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }
    }
}