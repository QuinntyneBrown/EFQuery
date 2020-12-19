using System;
using System.ComponentModel.DataAnnotations;

namespace EFQuery.Api.Models
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow.Date;
    }

}
