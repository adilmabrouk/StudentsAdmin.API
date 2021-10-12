using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsAdmin.API.Models;
using StudentsAdmin.API.Repository;
using System;
using System.Threading.Tasks;

namespace StudentsAdmin.API.Controllers
{
    public class StudentsController : ControllerBase
    {
        protected readonly IStudentRepository _studentRepository;
        protected readonly IMapper _mapper;

        public StudentsController(IStudentRepository studentRepository , IMapper mapper)
        {
            _studentRepository = studentRepository;  
            _mapper = mapper;   
        }


        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok( await _studentRepository.GetAllStudentsAsync());
        }

        [HttpGet]
        [Route("api/[controller]/{studentId:guid}"), ActionName("GetStudentByIdAsync")]
        public async Task<IActionResult> GetStudentByIdAsync([FromRoute] Guid studentId)
        {
             var student = await _studentRepository.GetStudentByIdAsync(studentId);

             if (student == null)
            {
                return NotFound();  
            }

            return Ok(student);
        }
        [HttpPut]
        [Route("api/[controller]/{studentId:guid}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid studentId , [FromBody] UpdateStudentRequest request)
        {
            if (await _studentRepository.Exists(studentId))
            {
                var updatedStudent = await _studentRepository.UpdateStudent(studentId, _mapper.Map<Student>(request));

                if (updatedStudent != null)
                {
                    return Ok(_mapper.Map<Student>(updatedStudent));
                }
            }

            return NotFound();

        }

        [HttpDelete]
        [Route("api/[controller]/{studentId:guid}")]
        public async Task<IActionResult> DeleteStudentAsync([FromRoute] Guid studentId)
        {
            if(await _studentRepository.Exists(studentId))
            {
                var student = await _studentRepository.DeleteStudentAsync(studentId);
                return Ok(student);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("api/[controller]/Add")]
        public async Task<IActionResult> AddStudentAsync([FromBody] AddStudentRequest request)
        {
           var student = await _studentRepository.AddStudentAsync(_mapper.Map<Student>(request));
           return CreatedAtAction(nameof(GetStudentByIdAsync),new {studentId = student.Id}, _mapper.Map<Student>(student));
        }

    }
}
