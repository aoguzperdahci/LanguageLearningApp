using LanguageLearningApp.Core.Constants;
using LanguageLearningApp.Core.Entities;
using LanguageLearningApp.Core.Interfaces.Repository;
using LanguageLearningApp.Core.Interfaces.Services;
using LanguageLearningApp.Core.Utilities.Results;

namespace LanguageLearningApp.Service
{
    public class LessonManager : ILessonService
    {
        private readonly ILessonRepository _lessonService;
        private readonly IStudentRepository _studentService;


        public LessonManager(ILessonRepository lessonService,IStudentRepository studentService)
        {
            _lessonService = lessonService;
            _studentService = studentService;
        }

        public IDataResult<LessonShortInfo> GetCurrentLessonDetails(int studentId)
        {
            if (_studentService.Get(i => i.Id == studentId) == null)
            {
                return new ErrorDataResult<LessonShortInfo>(Messages.StudentMissing);

            }
            return new SuccesDataResult<LessonShortInfo>(_lessonService.GetCurrentLessonDetails(studentId));
        }

        public IDataResult<Lesson> GetSingleLesson(int lessonid)
        {
            var lesson = _lessonService.Get(l => l.Id == lessonid);
            if (lesson is null)
            {
                return new ErrorDataResult<Lesson>(Messages.LessonIsMissing);

            }
            return new SuccesDataResult<Lesson>(lesson);
        }

        public IDataResult<List<LessonShortInfo>> LessonDetails()
        {
            return new SuccesDataResult<List<LessonShortInfo>>(_lessonService.GetDetails());
        }
    }
}
