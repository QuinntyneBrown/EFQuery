using EFQuery.Api.Data;
using EFQuery.Api.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace EFQuery.Core.Seeding
{
    public static class SeedData
    {
        public static void Seed(EFQueryDbContext context, IConfiguration configuration)
        {
            var olivia = context.Customers.SingleOrDefault(x => x.Email == "oliviabrown@gmail.com");

            if (olivia == null)
            {
                olivia = new Customer()
                {
                    Firstname = "Olivia",
                    Lastname = "Brown",
                    Email = "oliviabrown@gmail.com"
                };

                context.Customers.Add(olivia);

                context.SaveChanges();
            }

            var quinntyne = context.Customers.SingleOrDefault(x => x.Email == "quinntynebrown@gmail.com");

            if (quinntyne == null)
            {
                quinntyne = new Customer()
                {
                    Firstname = "Quinntyne",
                    Lastname = "Brown",
                    Email = "quinntynebrown@gmail.com"
                };

                context.Customers.Add(quinntyne);

                context.SaveChanges();
            }

            var vanessa = context.Customers.SingleOrDefault(x => x.Email == "vanessabrown@gmail.com");

            if (vanessa == null)
            {
                vanessa = new Customer()
                {
                    Firstname = "Vanessa",
                    Lastname = "Brown",
                    Email = "vanessabrown@gmail.com"
                };

                context.Customers.Add(vanessa);

                context.SaveChanges();
            }


            if (!context.Orders.Where(x => x.CustomerId == quinntyne.CustomerId).Any())
            {
                context.Orders.Add(new Order
                {
                    CustomerId = quinntyne.CustomerId,
                    CreatedDate = DateTime.UtcNow
                });

                context.Orders.Add(new Order
                {
                    CustomerId = quinntyne.CustomerId,
                    CreatedDate = DateTime.UtcNow.AddDays(-1)
                });

                context.Orders.Add(new Order
                {
                    CustomerId = quinntyne.CustomerId,
                    CreatedDate = DateTime.UtcNow.AddDays(-2)
                });

                context.SaveChanges();
            }


            if (!context.Orders.Where(x => x.CustomerId == vanessa.CustomerId).Any())
            {
                context.Orders.Add(new Order
                {
                    CustomerId = vanessa.CustomerId,
                    CreatedDate = DateTime.UtcNow.AddDays(-1)
                });

                context.Orders.Add(new Order
                {
                    CustomerId = vanessa.CustomerId,
                    CreatedDate = DateTime.UtcNow.AddDays(-2)
                });

                context.SaveChanges();
            }

        }
    }
}
