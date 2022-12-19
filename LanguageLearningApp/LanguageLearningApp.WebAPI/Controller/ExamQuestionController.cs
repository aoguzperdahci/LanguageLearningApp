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
            _examQuestionService.GetNextQuestion(studentId);
            return Ok();
        }
        
        [HttpGet]
        public IActionResult GetStudentAnswer([FromQuery]int studentId,[FromQuery] string answer)
        {
            _examQuestionService.GetAnswer(studentId, answer);
            return Ok();    
        }

        [HttpGet("calculatepoints")]
        public IActionResult CalculatePoints(int studentId)
        {
            _examQuestionService.CalculateExamResult(studentId);
            return Ok();
        }

        [HttpGet("getexamresult")]
        public IActionResult GetExamResult(int studentId)
        {
            _examQuestionService.GetExamResult(studentId);
            return Ok();
        }
    }
}
