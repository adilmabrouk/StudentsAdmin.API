using Microsoft.EntityFrameworkCore;
using StudentsAdmin.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsAdmin.API.Repository
{
    public class StudentRepository : IStudentRepository
    {
        protected readonly StudentAdminDbContext _studentAdminDbContext;
        public StudentRepository(StudentAdminDbContext studentAdminDbContext )
        {
            _studentAdminDbContext = studentAdminDbContext; 
                
        }
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _studentAdminDbContext.Students.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        }
    }
}
