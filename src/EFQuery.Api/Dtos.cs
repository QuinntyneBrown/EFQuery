using EFQuery.Api.Models;
using System;
using System.Collections.Generic;

namespace EFQuery.Api
{
    public record CustomerDto(Guid CustomerId, string Firstname, string Lastname, List<OrderDto> Orders);

    public record OrderDto(Guid OrderId, Guid CustomerId, decimal Total, DateTime CreatedDate);

    public static class CustomerExtensions
    {
        public static CustomerDto ToDto(this Customer customer)
        {
            return new CustomerDto(customer.CustomerId, customer.FirstName, customer.LastName, new List<OrderDto>());
        }
    }

    public static class OrderExtensions
    {
        public static OrderDto ToDto(this Order order)
        {
            return new OrderDto(order.OrderId, order.CustomerId, order.Total, order.CreatedDate);
        }
    }
}
