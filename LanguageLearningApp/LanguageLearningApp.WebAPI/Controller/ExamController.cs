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

        [HttpGet("prepareexam")]
        public IActionResult PrepareExam(int studentId)
        {
            _examService.CreateExam(studentId);
            _examService.PrepareExamQuestions(studentId);   
            return Ok();
        }
    }
}
