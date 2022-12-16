using LanguageLearningApp.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LanguageLearningApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)

        {
           _questionService = questionService;
        }

        [HttpGet]
        public IActionResult NextQuestion()
        {
            return Ok(_questionService.SendQuestion());
        }
        [HttpGet]
        public IActionResult PrepareExam(int StudentId)
        {
            if (_questionService.isStudent())
            {
                _questionService.Prepare(StudentId);
                return Ok();
            }
            return BadRequest();
            
            
        }
        [HttpGet]
        public IActionResult SaveAnswer(string answer)
        {
            _questionService.CheckAnswer(answer);
            return Ok();

        }

        [HttpGet]
        public IActionResult CalculateExamResult()
        {
            return Ok(_questionService.SendExamResult());
        }
    }
}
