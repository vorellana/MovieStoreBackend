using MovieStoreBackend.DTO;
using MovieStoreBackend.Entities;

namespace MovieStoreBackend.Services.Infrastructure.Repositories
{
    public interface ISaleRepository
    {
        Task<IEnumerable<Sale>> GetAllSales();

        Task<bool> InsertSale(SaleDTO sale);
    }
}
