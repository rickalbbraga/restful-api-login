using Domain.Contracts.Response;
using Domain.Validations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Restful.Login.Domain.Contracts.Interfaces.Services;
using Restful.Login.Domain.Contracts.Requests;
using Restful.Login.Domain.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Restful.Login.API.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly ILogger<LoginController> _logger;

        public LoginController(
            ILoginService loginService,
            ILogger<LoginController> logger)
        {
            _loginService = loginService;
            _logger = logger;
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
                _logger.LogInformation("Here is authenticate on application");

                var response = await _loginService.Authentication(loginRequest);
                var notifications = _loginService as Notifiable;

                if (response == null && notifications.Error.Any())
                    return BadRequest(notifications.Error);

                return Created(string.Empty, response);
            }
            catch (Exception ex)
            {
                var error = new { Error = ex.ToString(), Namespace = "Restful.Login.API", Date = DateTime.UtcNow };
                _logger.LogError(error.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Error Server.");
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
        public async Task<ActionResult> Delete()
        {
            try
            {
                var bearer = await HttpContext.GetTokenAsync("access_token");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }
    }
}