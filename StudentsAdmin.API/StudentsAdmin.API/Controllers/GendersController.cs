using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsAdmin.API.Models;
using StudentsAdmin.API.Repository;
using System.Threading.Tasks;

namespace StudentsAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;

        public GendersController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        [HttpGet]   
        public async Task<IActionResult> GetGenders()
        {
            return  Ok(await this.studentRepository.GetGenders());
        }
    }
}
