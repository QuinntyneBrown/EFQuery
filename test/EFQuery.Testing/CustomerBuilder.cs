using EFQuery.Api.Models;

namespace EFQuery.Testing
{
    public class CustomerBuilder
    {
        private Customer _customer;

        public static Customer WithDefaults()
        {
            return new Customer();
        }

        public CustomerBuilder()
        {
            _customer = WithDefaults();
        }

        public Customer Build()
        {
            return _customer;
        }
    }
}
