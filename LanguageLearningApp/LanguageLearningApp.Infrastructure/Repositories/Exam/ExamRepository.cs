using LanguageLearningApp.Core.Entities;
using LanguageLearningApp.Core.Interfaces.Repository;
using LanguageLearningApp.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                
                return (context.Exams.Include(l=>l.Lesson).Include(s=>s.Student).OrderBy(e => e.Id).LastOrDefault(s=>s.Student.Id==studentId));
            } 
        }

        public void SaveExamResult(int examId, int examResult)
        {
            using (var context = new LanguageLearningContext())
            {
                var exam = context.Exams.Where(e => e.Id == examId).Single();
                exam.ExamResult = examResult;
                context.SaveChanges();
            }
        }
        public List<Exam> GetAll(Expression<Func<Exam, bool>> filter = null)
        {
            using (var context = new LanguageLearningContext())
            {
                return filter == null
                 ? context.Set<Exam>().Include(s=>s.Student).Include(l=>l.Lesson).ToList() : context.Set<Exam>().Include(s => s.Student).Include(l => l.Lesson).Where(filter).ToList();
            }
        }

    }
}
