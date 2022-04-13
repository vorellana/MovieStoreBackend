using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStoreBackend.DTO;
using MovieStoreBackend.Services.Infrastructure.Services;

namespace MovieStoreBackend.WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        protected readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult> GetAllCustomers()
        {
            Response oResponse = new Response();
            try
            {
                oResponse.Data = await customerService.GetAllCustomers();
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
