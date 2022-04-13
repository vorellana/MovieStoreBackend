#nullable disable
using Microsoft.EntityFrameworkCore;
using MovieStoreBackend.DTO;
using MovieStoreBackend.Entities;
using MovieStoreBackend.Services.Infrastructure.Repositories;

namespace MovieStoreBackend.DataAccess.EFCore.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly MovieStoreDataContext _dbContext;

        public SaleRepository(MovieStoreDataContext context) {
            _dbContext = context;
        }

        public async Task<IEnumerable<Sale>> GetAllSales()
        {
            List<Sale> sales = new List<Sale>();
            sales = await _dbContext.Sale.ToListAsync();
            return sales;
        }

        public async Task<bool> InsertSale(SaleDTO saleDto)
        {
            Sale sale = new Sale();
            sale.TotalAmount = saleDto.TotalAmount;
            sale.Type= saleDto.Type;
            sale.CustomerId = saleDto.CustomerId;
            sale.IssuedAt = DateTime.Now;
            _dbContext.Sale.Add(sale);
            var response = await _dbContext.SaveChangesAsync();

            foreach (var item in saleDto.SaleDetailDtoList) {
                var disk = await _dbContext.Disk.Where(d => d.MovieId == item.MovieId).Where(d => d.Status == "Disponible").FirstOrDefaultAsync();
                SaleDetail detail = new SaleDetail();
                detail.DiskId = disk.Id;
                detail.SaleId = sale.Id;
                detail.Type = item.Type;
                detail.Amount = item.Amount;
                _dbContext.SaleDetail.Add(detail);
                disk.Status = (item.Type == "compra" ? "Comprada" : "Rentada");
                response = await _dbContext.SaveChangesAsync();
            }
            return true;
        }
    }
}
