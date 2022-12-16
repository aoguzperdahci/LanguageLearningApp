using LanguageLearningApp.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LanguageLearningApp.WebAPI.Controllers
{
    public class LessonController : Controller
    {
        private ILessonService _lessonService;

        public LessonController(ILessonService lessonService)

        {
            _lessonService = lessonService;
        }

        [HttpGet]
        public IActionResult GetAllLessons()
        {
            return Ok(_lessonService.allLessons());    
        }
    }
}
