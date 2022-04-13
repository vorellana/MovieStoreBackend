using MovieStoreBackend.Entities;
using MovieStoreBackend.Services.Infrastructure.Repositories;
using MovieStoreBackend.Services.Infrastructure.Services;

namespace MovieStoreBackend.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return customerRepository.GetAllCustomers();
        }
    }
}
