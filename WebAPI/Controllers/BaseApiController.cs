using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected IMediator mediator;

        // protected IMediator Mediator => mediator ?? HttpContext.RequestServices.GetService<IMediator>();
        public BaseApiController(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
