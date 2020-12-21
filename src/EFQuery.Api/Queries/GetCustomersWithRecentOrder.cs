using EFQuery.Api.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static System.DateTime;

namespace EFQuery.Api.Queries
{
    public class GetCustomersWithRecentOrder
    {
        public record Request : IRequest<Response>;

        public record Response(List<CustomerDto> Customers);

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IEFQueryDbContext _context;

            public Handler(IEFQueryDbContext context)
            {
                _context = context;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

                var threshold = UtcNow.AddDays(-1).Date;

                var query = from customer in _context.Customers
                                                       
                            where _context.Orders.Where(order => order.CreatedDate >= threshold && order.CustomerId == customer.CustomerId).Any()

                            select customer;

                return new(await query.Select(x => x.ToDto()).ToListAsync(cancellationToken));
            }
        }
    }
}
