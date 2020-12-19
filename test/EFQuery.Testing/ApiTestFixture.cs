using EFQuery.Api;
using EFQuery.Api.Data;
using EFQuery.Core.Seeding;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace EFQuery.Testing
{
    public class ApiTestFixture : WebApplicationFactory<Startup>
    {
        public EFQueryDbContext Context { get; private set; }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {

            builder.ConfigureServices(services =>
            {
                var serviceProvider = services.BuildServiceProvider();

                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    
                    Context = scopedServices.GetRequiredService<EFQueryDbContext>();

                    Context.Database.EnsureCreated();

                    SeedData.Seed(Context, ConfigurationFactory.Create());
                }
            });
        }

    }
}
