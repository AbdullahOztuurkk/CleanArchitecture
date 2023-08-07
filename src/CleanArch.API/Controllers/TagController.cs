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
    [Route("api/tags/")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly IMediator mediator;

        public TagController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get All Tags
        /// </summary>
        /// <returns>Tag list that contains name and description</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllTagQueryRequest()));
        }

        /// <summary>
        /// Get specified Tag
        /// </summary>
        /// <param name="request">Any Guid</param>
        /// <returns>Tag that contains name and description</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(":Id")]
        public async Task<IActionResult> Get([FromQuery] GetTagQueryRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        /// <summary>
        /// Create a Tag
        /// </summary>
        /// <param name="request">Tag Model</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTagCommandRequest request)
        {
            var result = await mediator.Send(request);
            if (result.IsSucceed == false)
                return BadRequest(result.Message);
            return Ok(result);
        }

        /// <summary>
        /// Delete the tag
        /// </summary>
        /// <param name="request">Any Guid</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete(":Id")]
        public async Task<IActionResult> Delete([FromQuery] DeleteTagCommandRequest request)
        {
            var result = await mediator.Send(request);
            if (result.IsSucceed == false)
                return NoContent();
            return Ok(result);
        }
    }
}
