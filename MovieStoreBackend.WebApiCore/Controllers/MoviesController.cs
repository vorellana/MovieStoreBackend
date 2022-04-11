#nullable disable
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStoreBackend.DTO;
using MovieStoreBackend.Entities;
using MovieStoreBackend.Services.Infrastructure.Services;

namespace MovieStoreBackend.WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        protected readonly IMovieService movieService;

        public MoviesController(IMovieService movieService) { 
            this.movieService = movieService;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetStudent()
        {
            Response oResponse = new Response();
            try
            {
                oResponse.Data = await movieService.GetAllMovies();
            }
            catch (Exception ex)
            {
                oResponse.Success = false;
                oResponse.Message = ex.Message;
            }
            return Ok(oResponse);
        }

        // GET: api/Movies/byCustomers?diskStatus=&docType=
        [HttpGet]
        [Route("byCustomers")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesByCustomers(string? diskStatus, string? docType)
        {
            Response oResponse = new Response();
            try
            {
                oResponse.Data = await movieService.GetListOfMoviesByCustomer(diskStatus, docType);
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
