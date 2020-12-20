using EFQuery.Api.Data;
using EFQuery.Api.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EFQuery.Api.Queries
{
    public class GetCustomers
    {
        public class Request : IRequest<Response> {  }

        public class Response
        {
            public List<CustomerDto> Customers { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IEFQueryDbContext _context;

            public Handler(IEFQueryDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {

                var customers = (from customer in _context.Customers
                            join order in _context.Orders on customer.CustomerId equals order.CustomerId into gj
                            from subOrder in gj.DefaultIfEmpty()
                            select new Tuple<Customer,Order>(customer, subOrder)).Aggregate(new List<CustomerDto>(), Reduce); ;

                List<CustomerDto> Reduce(List<CustomerDto> customers, Tuple<Customer,Order> data)
                {
                    var customer = customers.SingleOrDefault(x => x.CustomerId == data.Item1.CustomerId);

                    if (customer == null)
                    {
                        customer = new CustomerDto(data.Item1.CustomerId, data.Item1.FirstName, data.Item1.LastName, new List<OrderDto>());

                        customers.Add(customer);
                    }

                    if (data.Item2 != null)
                    {
                        customer.Orders.Add(new OrderDto(data.Item2.OrderId, data.Item2.CustomerId, data.Item2.Total, data.Item2.CreatedDate));
                    }

                    return customers;
                }

                return new Response
                {
                    Customers = customers
                };
            }
        }
    }

    public static class CustomerExtensions
    {
        public static CustomerDto ToDto(this Customer customer)
        {
            return new CustomerDto(customer.CustomerId, customer.FirstName, customer.LastName, new List<OrderDto>());
        }
    }
}
