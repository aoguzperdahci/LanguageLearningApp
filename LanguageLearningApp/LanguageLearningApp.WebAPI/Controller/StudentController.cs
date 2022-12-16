using LanguageLearningApp.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LanguageLearningApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
       
        private IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;   
                
        }
        [HttpGet]
        public void CurrentStudentId(int id)
        {
            _studentService.getStudentId(id);
            
        }

        [HttpGet]
        public IActionResult CurrentLesson()
        {
            if (_studentService.isStudent())
            {
                return Ok(_studentService.currentLesson());
            }
            return BadRequest();
            
        }
    }
}
