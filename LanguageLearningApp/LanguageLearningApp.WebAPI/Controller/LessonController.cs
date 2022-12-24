using LanguageLearningApp.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LanguageLearningApp.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private ILessonService _lessonService;

        public LessonController(ILessonService lessonService)

        {
            _lessonService = lessonService;
        }

        [HttpGet("getAllLessons")]
        public async Task<IActionResult> LessonDetail()
        {
            var result = _lessonService.LessonDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getSingleLesson")]
        public async Task<IActionResult> GetSingleLesson(int lessonid)
        {
            var result = _lessonService.GetSingleLesson(lessonid);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getCurrentLesson")]
        public async Task<IActionResult> GetCurrentLesson(int studentId)
        {
            var result = _lessonService.GetCurrentLessonDetails(studentId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
