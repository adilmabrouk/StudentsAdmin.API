using StudentsAdmin.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsAdmin.API.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudentsAsync();
    }
}
