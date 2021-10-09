using Microsoft.EntityFrameworkCore;

namespace StudentsAdmin.API.Models
{
    public class StudentAdminDbContext : DbContext  
    {
        public StudentAdminDbContext(DbContextOptions<StudentAdminDbContext> options) : base(options)    
        {
                
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<Address> Addresses { get; set; }
    }
}
