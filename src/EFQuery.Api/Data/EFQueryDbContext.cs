using EFQuery.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;

namespace EFQuery.Api.Data
{
    public class EFQueryDbContext : DbContext, IEFQueryDbContext
    {
        public EFQueryDbContext(DbContextOptions options)
            : base(options) { }

        public static readonly ILoggerFactory ConsoleLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public DbSet<Customer> Customers { get; private set; }
        public DbSet<Order> Orders { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
