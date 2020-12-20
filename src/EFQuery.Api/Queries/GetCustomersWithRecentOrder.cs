using EFQuery.Api.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EFQuery.Api.Queries
{
    public class GetCustomersWithRecentOrder
    {
        public class Request : IRequest<Response> { }

        public class Response
        {
            public List<CustomerDto> Customers { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IEFQueryDbContext _context;

            public Handler(IEFQueryDbContext context)
            {
                _context = context;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {

                var threshold = DateTime.UtcNow.AddDays(-10).Date;

                var query = (from order in _context.Orders
                            where order.CreatedDate >= threshold
                            join customer in _context.Customers on order.CustomerId equals customer.CustomerId
                            select customer).Distinct();

                return new Response()
                {
                    Customers = query.Select(x => x.ToDto()).ToList()
                };
            }
        }
    }
}
