using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain.Contracts.Interfaces.Services;
using Domain.Contracts.Requests;
using Domain.Contracts.Response;
using Domain.Validations;
using Microsoft.AspNetCore.Mvc;

namespace Restful.Login.API.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    [Route("/users")]
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
        [Route("")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(List<ErrorsResponse>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorsResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> Post([FromBody]UserRequest userRequest)
        {
            var response = await _userRegisterService.Add(userRequest);
            var notifications = _userRegisterService as Notifiable;

            if (response == null && notifications.Error.Any())
                return BadRequest(notifications.Error);

            return Created(string.Empty, string.Empty);
        }
    }
}
