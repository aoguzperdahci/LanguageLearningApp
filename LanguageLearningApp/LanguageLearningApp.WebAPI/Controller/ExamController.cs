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

        [HttpPost("createExam")]
        public async Task<IActionResult> CreateExam(int studentId)
        {
            var resultCreated =_examService.CreateExam(studentId);
            if (resultCreated.Success)
            {
                var resultPrepared = _examService.PrepareExamQuestions(studentId);

                if (resultPrepared.Success)
                {
                    return Ok(resultPrepared);
                }
                return BadRequest(resultPrepared);

            }
            return BadRequest(resultCreated);
        }
    }
}
