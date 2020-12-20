using EFQuery.Api.Queries;
using EFQuery.Testing;
using Newtonsoft.Json;
using System.Linq;
using Xunit;
using static EFQuery.FunctionalTests.CustomersControllerTests.Endpoints;

namespace EFQuery.FunctionalTests
{
    public class CustomersControllerTests : IClassFixture<ApiTestFixture>
    {
        private readonly ApiTestFixture _fixture;
        public CustomersControllerTests(ApiTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async System.Threading.Tasks.Task Should_GetCustomers()
        {
            var expectedCustomerCount = 3;

            var expectedOrderCount = 3;

            var httpResponseMessage = await _fixture.CreateClient().GetAsync(Get.Customers);

            httpResponseMessage.EnsureSuccessStatusCode();

            var response = JsonConvert.DeserializeObject<GetCustomersWithRecentOrder.Response>(await httpResponseMessage.Content.ReadAsStringAsync());

            Assert.Equal(expectedCustomerCount, response.Customers.Count);

            var quinntyne = response.Customers.Single(x => x.Firstname == "Quinntyne");

            Assert.Equal(expectedOrderCount, quinntyne.Orders.Count);
        }


        [Fact]
        public async System.Threading.Tasks.Task Should_GetCustomersWithRecentOrder()
        {
            var httpResponseMessage = await _fixture.CreateClient().GetAsync(Get.ActiveCustomers);

            httpResponseMessage.EnsureSuccessStatusCode();

            var response = JsonConvert.DeserializeObject<GetCustomersWithRecentOrder.Response>(await httpResponseMessage.Content.ReadAsStringAsync());

            Assert.Single(response.Customers);
        }


        internal static class Endpoints
        {
            public static class Get
            {
                public static string Customers = "api/customers";
                public static string ActiveCustomers = "api/customers/active";
            }
        }
    }
}
