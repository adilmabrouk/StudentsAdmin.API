using Microsoft.EntityFrameworkCore;
using StudentsAdmin.API.Models;
using System;
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

        public async Task<Student> GetStudentByIdAsync(Guid studentId)
        {
            return await _studentAdminDbContext.Students.Include(nameof(Gender)).Include(nameof(Address))
                         .Where(x => x.Id == studentId).FirstOrDefaultAsync();  
        }

        public async Task<List<Gender>> GetGenders()
        {
           return await _studentAdminDbContext.Genders.ToListAsync();
        }

        public async Task<bool> Exists(Guid studentId)
        {
            return await _studentAdminDbContext.Students.AnyAsync(x => x.Id == studentId);
        }

        public async Task<Student> UpdateStudent(Guid studentId, Student request)
        {
            var existingStudent = await GetStudentByIdAsync(studentId);
            if (existingStudent != null)
            {
                existingStudent.FirstName = request.FirstName; 
                existingStudent.LastName = request.LastName;
                existingStudent.DateOfBirth = request.DateOfBirth;
                existingStudent.Email = request.Email;  
                existingStudent.Mobile = request.Mobile;
                existingStudent.GenderId = request.GenderId;    
                existingStudent.Address.PhysicalAddress = request.Address.PhysicalAddress;  
                existingStudent.Address.PostalAddress = request.Address.PostalAddress;

                await _studentAdminDbContext.SaveChangesAsync();
                return existingStudent; 
            }

            return  null;
        }

        public async Task<Student> DeleteStudentAsync(Guid studentId)
        {
            var student = await GetStudentByIdAsync(studentId);
            if (student != null)
            {
                 _studentAdminDbContext.Remove(student);
                await _studentAdminDbContext.SaveChangesAsync();  
                return student;
            }
            return null;

        }
    }
}
