using LanguageLearningApp.Core.Constants;
using LanguageLearningApp.Core.DTOs;
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

        public IDataResult<LessonDetailDto> GetCurrentLessonDetails(int studentId)
        {
            return new SuccesDataResult<LessonDetailDto>(_lessonService.GetCurrentLessonDetails(studentId));
        }

        public IDataResult<Lesson> GetSingleLesson(int studentId)
        {
            return new SuccesDataResult<Lesson>(_studentService.Get(s=>s.Id==studentId).Lesson);
        }

        public IDataResult<List<LessonDetailDto>> LessonDetails()
        {
            return new SuccesDataResult<List<LessonDetailDto>>(_lessonService.GetDetails());
        }
    }
}
