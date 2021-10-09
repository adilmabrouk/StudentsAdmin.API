using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsAdmin.API.Repository;
using System.Threading.Tasks;

namespace StudentsAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        protected readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;   
        }


        [HttpGet]   
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok( await _studentRepository.GetAllStudentsAsync());
        }
    }
}
