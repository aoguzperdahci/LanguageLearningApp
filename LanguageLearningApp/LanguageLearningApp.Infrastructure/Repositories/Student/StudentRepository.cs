using LanguageLearningApp.Core.Entities;
using LanguageLearningApp.Core.Interfaces.Repository;
using LanguageLearningApp.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Infrastructure.Repositories
{
    public class StudentRepository : ReadRepository<Student,LanguageLearningContext>, IStudentRepository
   {

        public bool isStudent(int studentId)
        {
            using (var context = new LanguageLearningContext())
            {
                var student = context.Students.SingleOrDefault(s => s.Id == studentId);
                if (student == null)
                {
                    return false;
                }
                return true;
            }
        }

        public void UpdateStudentLesson(int studentId)
        {
            using (var context = new LanguageLearningContext())
            {
                var student = context.Students.SingleOrDefault(s => s.Id == studentId);
                var maxLessonOrder = context.Lessons.OrderBy(l => l.Order).Last().Order;

                if (maxLessonOrder > student.Lesson.Order)
                {
                    var nextLesson = context.Lessons.SingleOrDefault(l => l.Order == student.Lesson.Order + 1);
                    student.Lesson = nextLesson;
                    context.SaveChanges();
                }
            }
        }
    }
}
