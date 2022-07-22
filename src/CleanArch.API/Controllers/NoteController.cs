using CleanArch.Application.Features.Commands.CreateEvent;
using CleanArch.Application.Features.Commands.DeleteEvent;
using CleanArch.Application.Features.Queries.GetAllEvent;
using CleanArch.Application.Features.Queries.GetEvent;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArch.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        public readonly IMediator mediator;
        public NoteController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get All Notes
        /// </summary>
        /// <returns>Note list that contains Title, content and is favorited</returns>
        [HttpGet("/")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllNoteQueryRequest()));
        }

        /// <summary>
        /// Get Note
        /// </summary>
        /// <param name="request">Any Guid</param>
        /// <returns>Note that contains title, content and is favorited</returns>
        [HttpGet("/:Id")]
        public async Task<IActionResult> Get([FromQuery] GetNoteQueryRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        /// <summary>
        /// Create a Note
        /// </summary>
        /// <param name="request">Note Model</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNoteCommandRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        /// <summary>
        /// Delete the Note
        /// </summary>
        /// <param name="request">Any Guid</param>
        /// <returns></returns>
        [HttpDelete("/:Id")]
        public async Task<IActionResult> Delete([FromQuery] DeleteNoteCommandRequest request)
        {
            await mediator.Send(request);
            return NoContent();
        }
    }
}
