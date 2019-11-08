using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Domain.Contracts.Requests;
using Domain.Contracts.Response;
using Microsoft.AspNetCore.Mvc;

namespace Restful.Login.API.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    [Route("/users")]
    public class UsersController : ControllerBase
    {

        public UsersController()
        {
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
        public async Task<ActionResult> Post([FromBody]UserRequest user)
        {
            return Created(string.Empty, string.Empty);
        }
    }
}
