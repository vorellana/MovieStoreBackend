using MovieStoreBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreBackend.Services.Infrastructure.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudents();
    }
}
