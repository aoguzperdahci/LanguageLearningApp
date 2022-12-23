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

        [HttpGet("getNextQuestion")]
        public async Task<IActionResult>NextQuestion(int studentId)
        {
           var result = _examQuestionService.GetNextQuestion(studentId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPost("saveStudentAnswer")]
        public IActionResult SaveStudentAnswer(int studentId, string answer)
        {
            var result = _examQuestionService.GetAnswer(studentId, answer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();    
        }

        [HttpGet("getExamResult")]
        public IActionResult GetExamResult(int studentId)
        {
            var result =_examQuestionService.GetExamResult(studentId);
            return Ok(result);
        }
    }
}
