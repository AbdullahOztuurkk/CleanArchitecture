using CleanArch.Application.Commands.Note.CreateNote;
using CleanArch.Application.Commands.Note.DeleteNote;
using CleanArch.Application.Queries.Note.GetAllNote;
using CleanArch.Application.Queries.Note.GetNote;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        [HttpGet("/")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllNoteQueryRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpGet("/:Id")]
        public async Task<IActionResult> Get([FromQuery] GetNoteQueryRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNoteCommandRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpDelete("/:Id")]
        public async Task<IActionResult> Delete([FromQuery] DeleteNoteCommandRequest request)
        {
            await mediator.Send(request);
            return NoContent();
        }
    }
}
