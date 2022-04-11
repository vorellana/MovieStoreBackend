using MovieStoreBackend.DataAccess.EFCore;
using MovieStoreBackend.DataAccess.EFCore.Repositories;
using MovieStoreBackend.Entities;
using MovieStoreBackend.Services.Infrastructure.Repositories;
using MovieStoreBackend.Services.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreBackend.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;

        //public StudentService(MovieStoreDataContext context) { 
        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
            // _studentRepository = new StudentRepository(context);
        }

        public Task<IEnumerable<Student>> GetAllStudents()
        {
            // throw new NotImplementedException();
            return studentRepository.GetAllStudents();
        }

        // método save: determina si es insert o update
    }
}
