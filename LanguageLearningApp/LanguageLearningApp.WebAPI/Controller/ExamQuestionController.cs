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
        public async Task<IActionResult> NextQuestion(int studentId)
        {
            var questionId = _examQuestionService.GetNextQuestionId(studentId);
            var testQuestion = _examQuestionService.GetTestQuestion(questionId);
            if (testQuestion.Success)
            {
                testQuestion.Data.CorrectAnswer = "";
                return Ok(testQuestion);
            }
            else
            {
                var gapFillingQuestion = _examQuestionService.GetGapFillingQuestion(questionId);
                if (gapFillingQuestion.Success)
                {
                    gapFillingQuestion.Data.CorrectAnswer = "";
                    return Ok(gapFillingQuestion);
                }
            }

            return BadRequest();
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
            var result = _examQuestionService.GetExamResult(studentId);
            return Ok(result);
        }
    }
}