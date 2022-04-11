using Microsoft.EntityFrameworkCore;
using MovieStoreBackend.Entities;
using MovieStoreBackend.Services.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreBackend.DataAccess.EFCore.Repositories
{
    public class StudentRepository : IStudentRepository
    {

        private string ConnectionString;

        private readonly MovieStoreDataContext _dbContext;

        // me quede aquí para la conexión por stringConnection (según youtube) o context (según Nebular)


        //aquiii usamoe el contextt
        public StudentRepository(MovieStoreDataContext context) // esta linea está bien... ver como se usa en el proyecto de EJ
        {
            _dbContext = context;
        }

        //public StudentRepository(string connectionString)
        //{
        //    ConnectionString = connectionString;
        //}

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            students = await _dbContext.Student.ToListAsync();
            return students;
            // throw new NotImplementedException();
        }
    }
}
