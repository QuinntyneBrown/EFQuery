using System;
using System.Collections.Generic;

namespace EFQuery.Api
{
    public record CustomerDto(Guid CustomerId, string Firstname, string Lastname, List<OrderDto> Orders);

    public record OrderDto(Guid OrderId, Guid CustomerId, decimal Total, DateTime CreatedDate);
}
