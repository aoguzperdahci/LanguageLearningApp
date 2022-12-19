using LanguageLearningApp.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LanguageLearningApp.WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamQuestionController : ControllerBase
    {
        private IExamQuestionService _examQuestionService;

        public ExamQuestionController(IExamQuestionService examQuestionService)

        {
            _examQuestionService = examQuestionService;
        }

        [HttpGet("getnextquestion")]
        public IActionResult NextQuestion(int studentId)
        {
           var result = _examQuestionService.GetNextQuestion(studentId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet]
        public IActionResult GetStudentAnswer([FromQuery]int studentId,[FromQuery] string answer)
        {
            var result = _examQuestionService.GetAnswer(studentId, answer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();    
        }

        [HttpGet("calculatepoints")]
        public IActionResult CalculatePoints(int studentId)
        {
            var result = _examQuestionService.CalculateExamResult(studentId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getexamresult")]
        public IActionResult GetExamResult(int studentId)
        {
            var result =_examQuestionService.GetExamResult(studentId);
            return Ok(result);
        }
    }
}
