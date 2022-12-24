using LanguageLearningApp.Core.Entities;
using LanguageLearningApp.Core.Interfaces.Repository;
using LanguageLearningApp.Core.Utilities.Results;
using LanguageLearningApp.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
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
                var student = context.Students.Include(l=>l.Lesson).SingleOrDefault(s => s.Id == studentId);
                var maxLessonOrder = context.Lessons.OrderBy(l => l.Order).Last().Order;

                if (maxLessonOrder > student.Lesson.Order)
                {
                    var nextLesson = context.Lessons.SingleOrDefault(l => l.Order == student.Lesson.Order + 1);
                    student.Lesson = nextLesson;
                    context.SaveChanges();
                }
            }
        }

        public Student Get(Expression<Func<Student, bool>> filter)
        {
            using (var context = new LanguageLearningContext())
            {

                return context.Students.Include(l=>l.Lesson).SingleOrDefault(filter);

            }

        }


    }
}
