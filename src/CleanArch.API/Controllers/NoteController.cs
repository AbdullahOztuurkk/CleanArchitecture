using CleanArch.Application.Features.Commands.CreateEvent;
using CleanArch.Application.Features.Commands.DeleteEvent;
using CleanArch.Application.Features.Queries.GetAllEvent;
using CleanArch.Application.Features.Queries.GetEvent;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArch.API.Controllers
{
    [ApiController]
    [Route("api/notes")]
    public class NoteController : ControllerBase
    {
        private readonly IMediator mediator;
        public NoteController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get All Notes
        /// </summary>
        /// <returns>Note list that contains Title, content and is favorited</returns>
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllNoteQueryRequest()));
        }

        /// <summary>
        /// Get Note
        /// </summary>
        /// <param name="request">Any Guid</param>
        /// <returns>Note that contains title, content and is favorited</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(":Id")]
        public async Task<IActionResult> Get([FromQuery] GetNoteQueryRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        /// <summary>
        /// Create a Note
        /// </summary>
        /// <param name="request">Note Model</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNoteCommandRequest request)
        {
            var result = await mediator.Send(request);
            if (result.IsSucceed == false)
                return BadRequest(result.Message);
            return Ok(result);
        }

        /// <summary>
        /// Delete the Note
        /// </summary>
        /// <param name="request">Any Guid</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete(":Id")]
        public async Task<IActionResult> Delete([FromQuery] DeleteNoteCommandRequest request)
        {
            var result = await mediator.Send(request);
            if (result.IsSucceed == false)
                return NoContent();
            return Ok(result);
        }
    }
}
