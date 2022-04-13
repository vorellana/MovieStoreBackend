using MovieStoreBackend.Entities;

namespace MovieStoreBackend.Services.Infrastructure.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
    }
}
