using LanguageLearningApp.Core.Entities;
using LanguageLearningApp.Core.Interfaces.Repository;
using LanguageLearningApp.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Service
{
    public class LessonManager : ILessonService
    {
        private readonly ILessonReadRepository _lessonService;

        public LessonManager(ILessonReadRepository lessonService)
        {
            _lessonService = lessonService;
        }

        public List<Lesson> allLessons()
        {
            return _lessonService.GetAll();
        }
    }
}
