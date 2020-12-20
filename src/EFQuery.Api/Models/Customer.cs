using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EFQuery.Api.Models
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Firstname), nameof(Lastname), IsUnique = true)]
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
    }
}
