using EFQuery.Api.Models;
using System;
using System.Collections.Generic;

namespace EFQuery.Api
{
    public record CustomerDto(Guid CustomerId, string Firstname, string Lastname, List<OrderDto> Orders);

    public record OrderDto(Guid OrderId, Guid CustomerId, decimal Total, DateTime CreatedDate);

    public static class ModelExtensions
    {
        public static CustomerDto ToDto(this Customer customer)
            => new(customer.CustomerId, customer.Firstname, customer.Lastname, new List<OrderDto>());

        public static OrderDto ToDto(this Order order)
            => new(order.OrderId, order.CustomerId, order.Total, order.CreatedDate);
    }
}
