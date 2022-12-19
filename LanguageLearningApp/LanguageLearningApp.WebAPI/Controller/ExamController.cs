using LanguageLearningApp.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LanguageLearningApp.WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private IExamService _examService;

        public ExamController(IExamService examService)

        {
            _examService = examService; 
        }

        [HttpGet("createexam")]
        public IActionResult CreateExam(int studentId)
        {
            var result =_examService.CreateExam(studentId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("prepareexam")]
        public IActionResult PrepareExam(int studentId)
        {
            var result = _examService.PrepareExamQuestions(studentId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
