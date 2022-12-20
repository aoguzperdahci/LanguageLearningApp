using LanguageLearningApp.Core.Entities;
using LanguageLearningApp.Core.Interfaces.Repository;
using LanguageLearningApp.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Infrastructure.Repositories
{
    public class ExamRepository : ReadRepository<Exam,LanguageLearningContext>, IExamRepository
    {

        public void CreateExam(Student student, Lesson lesson)
        {
            var exam = new Exam
            {
                Student = student,
                Lesson = lesson,
                ExamResult = 0
            };

            using (var context = new LanguageLearningContext())
            {
                var toBeAddedEntity = context.Entry(exam);
                toBeAddedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public Exam GetTheLastExam(int studentId)
        {
            using(var context = new LanguageLearningContext())
            {
                
                return (context.Exams.OrderBy(e => e.Id).LastOrDefault(s=>s.Student.Id==studentId));
            } 
        }
    }
}
