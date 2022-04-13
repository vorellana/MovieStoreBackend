using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStoreBackend.DTO;
using MovieStoreBackend.Entities;
using MovieStoreBackend.Services.Infrastructure.Services;

namespace MovieStoreBackend.WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        protected readonly ISaleService saleService;

        public SalesController(ISaleService saleService) { 
            this.saleService = saleService;
        }

        // GET: api/Sales
        [HttpGet]
        public async Task<ActionResult> GetAllSales()
        {
            Response oResponse = new Response();
            try
            {
                oResponse.Data = await saleService.GetAllSales();
            }
            catch (Exception ex)
            {
                oResponse.Success = false;
                oResponse.Message = ex.Message;
            }
            return Ok(oResponse);
        }

        // POST: api/Sales
        [HttpPost]
        public async Task<ActionResult> CreateMovie(SaleDTO sale)
        {
            Response oResponse = new Response();
            try
            {
                oResponse.Data = await saleService.InsertSale(sale);
            }
            catch (Exception ex)
            {
                oResponse.Success = false;
                oResponse.Message = ex.Message;
            }
            return Ok(oResponse);
        }

    }

}
