using EFQuery.Api.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace EFQuery.Api.Controllers
{
    [ApiController]
    [Route("api/customers")]
    [Produces("application/json")]
    public class CustomersController
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator) => _mediator = mediator;

        [HttpGet(Name = "GetCustomersRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCustomers.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCustomers.Response>> Get()
            => await _mediator.Send(new GetCustomers.Request());

        [HttpGet("active",Name = "GetCustomersWithRecentOrderRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCustomersWithRecentOrder.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCustomersWithRecentOrder.Response>> GetActive()
            => await _mediator.Send(new GetCustomersWithRecentOrder.Request());
    }
}
