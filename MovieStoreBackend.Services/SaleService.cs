using MovieStoreBackend.DTO;
using MovieStoreBackend.Entities;
using MovieStoreBackend.Services.Infrastructure.Repositories;
using MovieStoreBackend.Services.Infrastructure.Services;

namespace MovieStoreBackend.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository saleRepository;

        public SaleService(ISaleRepository saleRepository) { 
            this.saleRepository = saleRepository;
        }

        public async Task<IEnumerable<Sale>> GetAllSales()
        {
            return await saleRepository.GetAllSales();
        }

        public async Task<bool> InsertSale(SaleDTO sale)
        {
            return await saleRepository.InsertSale(sale);
        }
    }
}
