using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieStoreBackend.DataAccess.EFCore;
using MovieStoreBackend.DTO;
using MovieStoreBackend.Services.Infrastructure.Services;

namespace MovieStoreBackend.WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        protected readonly IStudentService studentService;

        // private readonly MovieStoreDataContext _context;

        // public StudentsController(MovieStoreDataContext context)
        public StudentsController(IStudentService studentService)
        {
            // _context = context;
            this.studentService = studentService;
        }


        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Response>>> GetStudent()
        {
            // return await _context.Student.ToListAsync();
            Response oResponse = new Response();
            try
            {
                // oResponse.Data = await _context.Student.ToListAsync();
                oResponse.Data = await studentService.GetAllStudents();
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
