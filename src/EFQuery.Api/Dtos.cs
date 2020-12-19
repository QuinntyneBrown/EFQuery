using System;

namespace EFQuery.Api
{
    public record CustomerDto(Guid CustomerId, string Firstname, string Lastname);
}
