using EFQuery.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;

namespace EFQuery.Api.Data
{
    public interface IEFQueryDbContext
    {
        DbSet<Customer> Customers { get; }
        DbSet<Order> Orders { get; }

        ChangeTracker ChangeTracker { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
