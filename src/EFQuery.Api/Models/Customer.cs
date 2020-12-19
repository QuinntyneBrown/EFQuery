using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EFQuery.Api.Models
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(FirstName), nameof(LastName), IsUnique = true)]
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
