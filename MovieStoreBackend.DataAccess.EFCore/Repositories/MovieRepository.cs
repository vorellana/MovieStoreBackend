using Microsoft.EntityFrameworkCore;
using MovieStoreBackend.DTO;
using MovieStoreBackend.Entities;
using MovieStoreBackend.Services.Infrastructure.Repositories;
using MovieStoreBackend.DataAccess.EFCore.Utils;

namespace MovieStoreBackend.DataAccess.EFCore.Repositories
{
    public class MovieRepository: IMovieRepository
    {
        private readonly MovieStoreDataContext _dbContext;

        public MovieRepository(MovieStoreDataContext context) {
            _dbContext = context;
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            List<Movie> movies = new List<Movie>();
            movies = await _dbContext.Movie.ToListAsync();
            return movies;
        }

        public async Task<IEnumerable<MoviesByCustomerDTO>> GetListOfMoviesByCustomer(string diskStatus, string docType)
        {
            diskStatus = (string.IsNullOrEmpty(diskStatus) ? "%" : diskStatus);
            docType = (string.IsNullOrEmpty(docType) ? "%" : docType);

            string sqlQuery = String.Format("SELECT CAST( ROW_NUMBER() OVER(ORDER BY T. DiskCode) AS INT) Id, GETDATE() CreatedAt, * FROM (" +
                "SELECT D.Code DiskCode, D.Status DiskStatus, DT.Name DiskType, M.Name MovieName, M.RentalPrice, M.PurchasePrice, MC.Name CategoryName," +
                "ISNULL(T1.DocType, '') DocType, ISNULL(T1.CustomerName, '') CustomerName, ISNULL(T1.CustomerCode, '') CustomerCode FROM dbo.Disk D " +
                "INNER JOIN dbo.DiskType DT ON DT.Id = D.DiskTypeId INNER JOIN dbo.Movie M ON M.Id = D.MovieId " +
                "INNER JOIN dbo.MovieCategory MC ON MC.Id = M.MovieCategoryId LEFT JOIN (SELECT SD1.DiskId, S.Type DocType, " +
                "C.Name + ' ' + C.LastNames CustomerName, C.Code CustomerCode FROM dbo.SaleDetail SD1 " +
                "INNER JOIN (SELECT SD.DiskId, MAX(SD.CreatedAt) MaxCreatedAt FROM dbo.SaleDetail SD GROUP BY DiskId " +
                ") MSD ON MSD.MaxCreatedAt = SD1.CreatedAt AND MSD.DiskId = SD1.DiskId INNER JOIN dbo.Sale S ON S.Id = SD1.SaleId " +
                "INNER JOIN dbo.Customer C ON C.Id = S.CustomerId) T1 ON (T1.DiskId = D.Id AND D.Status <> 'Disponible') ) T " +
                "WHERE T.DiskStatus LIKE '{0}' AND T.DocType LIKE '{1}'", diskStatus, docType);

            var con = new ConnectionDB();

            var MoviesByCustomers = await con.RawSqlQuery(sqlQuery, _dbContext, f => new MoviesByCustomerDTO
            {
                Id = (int)f["Id"],
                DiskCode = (string)f["DiskCode"],
                DiskStatus = (string)f["DiskStatus"],
                DiskType = (string)f["DiskType"],
                MovieName = (string)f["MovieName"],
                RentalPrice = (decimal)f["RentalPrice"],
                PurchasePrice = (decimal)f["PurchasePrice"],
                CategoryName = (string)f["CategoryName"],
                DocType = (string)f["DocType"],
                CustomerName = (string)f["CustomerName"],
                CustomerCode = (string)f["CustomerCode"],
            });

            return MoviesByCustomers;
        }
    }
}
