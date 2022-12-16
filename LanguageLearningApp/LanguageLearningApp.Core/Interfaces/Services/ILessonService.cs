using LanguageLearningApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Core.Interfaces.Services
{
    public interface ILessonService
    {
        List<Lesson> allLessons();
    }
}
