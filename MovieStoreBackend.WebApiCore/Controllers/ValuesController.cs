using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieStoreBackend.DataAccess.EFCore;
using MovieStoreBackend.DTO;
using MovieStoreBackend.Entities;
using MovieStoreBackend.Utils;

namespace MovieStoreBackend.WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly MovieStoreDataContext _context;

        public ValuesController(MovieStoreDataContext context) {
            this._context = context;

        }

        // GET: api/Values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Response>>> GetStudent()
        {
            // return await _context.Student.ToListAsync();
            Response oResponse = new Response();
            try
            {
                string diskStatus = "Rentada";
                string docType = "Factura";

                string sqlQuery =String.Format( "SELECT CAST( ROW_NUMBER() OVER(ORDER BY T. DiskCode) AS INT) Id, GETDATE() CreatedAt, * FROM (" +
                    "SELECT D.Code DiskCode, D.Status DiskStatus, DT.Name DiskType, M.Name MovieName, M.RentalPrice, M.PurchasePrice, MC.Name CategoryName," +
                    "ISNULL(T1.DocType, '') DocType, ISNULL(T1.CustomerName, '') CustomerName, ISNULL(T1.CustomerCode, '') CustomerCode FROM dbo.Disk D " +
                    "INNER JOIN dbo.DiskType DT ON DT.Id = D.DiskTypeId INNER JOIN dbo.Movie M ON M.Id = D.MovieId " +
                    "INNER JOIN dbo.MovieCategory MC ON MC.Id = M.MovieCategoryId LEFT JOIN (SELECT SD1.DiskId, S.Type DocType, " +
                    "C.Name + ' ' + C.LastNames CustomerName, C.Code CustomerCode FROM dbo.SaleDetail SD1 " +
                    "INNER JOIN (SELECT SD.DiskId, MAX(SD.CreatedAt) MaxCreatedAt FROM dbo.SaleDetail SD GROUP BY DiskId " +
                    ") MSD ON MSD.MaxCreatedAt = SD1.CreatedAt AND MSD.DiskId = SD1.DiskId INNER JOIN dbo.Sale S ON S.Id = SD1.SaleId " +
                    "INNER JOIN dbo.Customer C ON C.Id = S.CustomerId) T1 ON (T1.DiskId = D.Id AND D.Status <> 'Disponible') ) T " +
                    "WHERE T.DiskStatus LIKE '{0}' AND T.DocType LIKE '{1}'", diskStatus, docType);


                // var res = await _context.MovieCategory.ToListAsync();
                // var res = await _context.MovieCategory.FromSqlRaw("select * from dbo.Customer").ToListAsync();
                // var res = await _context.MovieCategory.FromSqlRaw(sqlQuery).ToListAsync();
                // var res = await _context.MovieCategory.AsNoTracking().FromS //.FromSqlRaw(sqlQuery).ToListAsync();

                var con = new ConnectionDB();

                var res = await con.RawSqlQuery(sqlQuery, _context, f => new MoviesByCustomerDTO
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

                // var res = await ConnectionDB.RawSqlQuery(sqlQuery, _context, null);


                // oResponse.Data = await _context.MovieCategory.ToListAsync();

                oResponse.Data = res;

                // oResponse.Data = await _context.Student.FromSqlRaw("").ToList;
                // var students = await _context.Student.FromSqlRaw("").ToListAsync();
                // var list = await _context.MovieCategory.FromSqlRaw("").ToListAsync();
            }
            catch (Exception ex)
            {
                oResponse.Success = false;
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);

        }


        //public async List<object> RunQuery2<T>(string query, DbContext db) where T : class
        //{
        //    var rv = await db.Set<T>().FromSqlRaw(query)
        //               .Select(e => (object)e)
        //               .ToListAsync();
        //    return rv;
        //}

    }
}
