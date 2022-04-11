using MovieStoreBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreBackend.Services.Infrastructure.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudents();

        //Task<Student> GetStudentDetails(int id);

        //Task<bool> InserStudent(Student student);

        //Task<bool> UpdateStudent(Student student);

        //Task<bool> DeleteStudent(int id);

    }
}
