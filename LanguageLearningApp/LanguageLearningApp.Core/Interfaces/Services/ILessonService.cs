using LanguageLearningApp.Core.Entities;
using LanguageLearningApp.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Core.Interfaces.Services
{
    public interface ILessonService
    {
        IDataResult<List<LessonShortInfo>>LessonDetails();
        IDataResult<Lesson> GetSingleLesson(int studentId);
        IDataResult<LessonShortInfo> GetCurrentLessonDetails(int studentId);
    }
}
