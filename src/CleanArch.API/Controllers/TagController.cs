using CleanArch.Application.Commands.Tag.CreateTag;
using CleanArch.Application.Commands.Tag.DeleteTag;
using CleanArch.Application.Queries.Tag.GetAllTag;
using CleanArch.Application.Queries.Tag.GetTag;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        public readonly IMediator mediator;

        public TagController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get All Tags
        /// </summary>
        /// <param name="request">Empty request</param>
        /// <returns>Tag list that contains name and description</returns>
        [HttpGet("/")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllTagQueryRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        /// <summary>
        /// Get specified Tag
        /// </summary>
        /// <param name="request">Any Guid</param>
        /// <returns>Tag that contains name and description</returns>
        [HttpGet("/:Id")]
        public async Task<IActionResult> Get([FromQuery] GetTagQueryRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        /// <summary>
        /// Create a Tag
        /// </summary>
        /// <param name="request">Tag Model</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTagCommandRequest request)
        {
            return (Ok(await mediator.Send(request)));
        }

        /// <summary>
        /// Delete the tag
        /// </summary>
        /// <param name="request">Any Guid</param>
        /// <returns></returns>
        [HttpDelete("/:Id")]
        public async Task<IActionResult> Delete([FromQuery] DeleteTagCommandRequest request)
        {
            await mediator.Send(request);
            return NoContent();
        }
    }
}
