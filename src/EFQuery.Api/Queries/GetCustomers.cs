using EFQuery.Api.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EFQuery.Api.Queries
{
    public class GetCustomers
    {
        public record Request : IRequest<Response>;

        public record Response(List<CustomerDto> Customers);

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IEFQueryDbContext _context;

            public Handler(IEFQueryDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {

                _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

                var customers = await (from customer in _context.Customers

                                 let orders = _context.Orders.Where(x => x.CustomerId == customer.CustomerId).Select(x => x.ToDto()).ToList()

                                 select new CustomerDto(customer.CustomerId, customer.Firstname, customer.Lastname, orders)).ToListAsync();

                return new Response(customers);
            }
        }
    }
}
