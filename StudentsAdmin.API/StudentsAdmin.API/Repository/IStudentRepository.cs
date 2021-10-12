using StudentsAdmin.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsAdmin.API.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudentsAsync();

        Task<Student> GetStudentByIdAsync(Guid studentId); 
        
        Task<List<Gender>> GetGenders();

        Task<bool> Exists(Guid studentId);

        Task<Student> UpdateStudent(Guid studentId, Student request);

        Task<Student> DeleteStudentAsync(Guid studentId);  
        
    }
}
