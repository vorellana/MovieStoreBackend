using Microsoft.EntityFrameworkCore;
using MovieStoreBackend.Entities;
using MovieStoreBackend.Services.Infrastructure.Repositories;

namespace MovieStoreBackend.DataAccess.EFCore.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly MovieStoreDataContext _dbContext;
        public CustomerRepository(MovieStoreDataContext context) { 
            _dbContext = context;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            customers = await _dbContext.Customer.ToListAsync();
            return customers;
        }
    }
}
