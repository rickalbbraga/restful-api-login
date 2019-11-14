using Domain.Contracts.Response;
using Domain.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restful.Login.Domain.Contracts.Interfaces.Services;
using Restful.Login.Domain.Contracts.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful.Login.API.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        /// <summary>
        /// Create an grade.
        /// </summary>
        /// <returns>A newly created grade</returns>
        /// <response code="201">created with success</response>
        /// <response code="400">If bad request</response>
        /// <response code="500">If internal error server</response>            
        [HttpPost]
        [Route("/grades")]
        [ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(List<ErrorsResponse>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post([FromBody]GradeRequest gradeRequest)
        {
            try
            {
                var response = await _gradeService.Add(gradeRequest);
                var notifications = _gradeService as Notifiable;

                if (response == null && notifications.Error.Any())
                    return BadRequest(notifications.Error);

                return Created(string.Empty, response);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }
    }
}