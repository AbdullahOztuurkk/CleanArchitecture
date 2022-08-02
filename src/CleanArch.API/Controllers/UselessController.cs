using CleanArch.Application.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArch.API.Controllers
{
    [ApiController]
    [Route("api/useless")]
    public class UselessController : ControllerBase
    {
        public readonly IMediator mediator;
        public UselessController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("sample")]
        public async Task<IActionResult> Post([FromBody]UselessQueryRequest query)
        {
            return Ok(await mediator.Send(query));
        }

       
    }
}
