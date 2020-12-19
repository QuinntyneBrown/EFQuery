using EFQuery.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EFQuery.Api.Data
{
    public interface IEFQueryDbContext
    {
        DbSet<Customer> Customers { get; }
        DbSet<Order> Orders { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
