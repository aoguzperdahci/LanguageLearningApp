using LanguageLearningApp.Core.DTOs;
using LanguageLearningApp.Core.Entities;
using LanguageLearningApp.Core.Interfaces.Repository;
using LanguageLearningApp.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Infrastructure.Repositories
{
    public class LessonRepository : ReadRepository<Lesson,LanguageLearningContext>, ILessonRepository
    {
        public List<LessonDetailDto> GetDetails()
        {
            using (LanguageLearningContext context = new LanguageLearningContext())
            {
                var result = from lesson in context.Lessons
                             select new LessonDetailDto
                             {
                                 Id = lesson.Id,
                                 Name = lesson.Name

                             };
                return result.ToList();
            }
            
        }
        public LessonDetailDto GetCurrentLessonDetails(int studentId)
        {
            using (LanguageLearningContext context = new LanguageLearningContext())
            {
                var currentStudentLesson = context.Students.FirstOrDefault(x => x.Id == studentId).Lesson;
                var currentLessonDto = new LessonDetailDto { Id = currentStudentLesson.Id, Name = currentStudentLesson.Name };
                return currentLessonDto;
            }

        }
    }
}
