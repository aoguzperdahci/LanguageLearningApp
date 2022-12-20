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

        [HttpGet("getall")]
        public IActionResult LessonDetail()
        {
            return Ok(_lessonService.LessonDetails());    
        }

        [HttpGet("getsinglelesson")]
        public IActionResult GetSingleLesson(int lessonid)
        {
            return Ok(_lessonService.GetSingleLesson(lessonid));
        }

        [HttpGet("getcurrentlesson")]
        public IActionResult GetCurrentLesson(int studentId)
        {
            return Ok(_lessonService.GetCurrentLessonDetails(studentId));   

        }
    }
}
