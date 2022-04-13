using MovieStoreBackend.DTO;
using MovieStoreBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreBackend.Services.Infrastructure.Services
{
    public interface ISaleService
    {
        Task<IEnumerable<Sale>> GetAllSales();

        Task<bool> InsertSale(SaleDTO sale);
    }
}
