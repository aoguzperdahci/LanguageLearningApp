using LanguageLearningApp.Core.Entities;
using LanguageLearningApp.Core.Interfaces.Repository;
using LanguageLearningApp.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace LanguageLearningApp.Infrastructure.Repositories
{
    public class ExamQuestionRepository : ReadRepository<ExamQuestions,LanguageLearningContext>, IExamQuestionsRepository
    {
   
        public void SaveExamQuestion(int ExamId, int QuestionNumber, Question question)
        {
            var examQuestion = new ExamQuestions
            {
                ExamId = ExamId,
                QuestionNumber = QuestionNumber,
                Question = question,
                StudentAnswer = ""
            };
            using (var context = new LanguageLearningContext())
            {
                var toBeAddedEntity = context.Entry(examQuestion);
                toBeAddedEntity.State = EntityState.Added;
                context.SaveChanges();
            }

        }

        public Question NextQuestion(int examQuestionId)
        {
            using(var context = new LanguageLearningContext())
            {
                return (context.ExamQuestions.Where(x => x.ExamId == examQuestionId).Where(s => s.StudentAnswer.Equals("")).First().Question);
   
            }

        }

        public void SaveAnswer(int examQuestionId, string answer)
        {
            
            using(var context = new LanguageLearningContext())
            {
                
                var examQuestion = new ExamQuestions()
                {
                    ExamId = examQuestionId,
                    QuestionNumber = context.ExamQuestions.Where(x => x.ExamId == examQuestionId).Where(y => y.StudentAnswer.Equals("")).First().QuestionNumber,
                    StudentAnswer= answer
                };

                context.ExamQuestions.Attach(examQuestion);
                context.Entry(examQuestion).Property(x => x.StudentAnswer).IsModified = true;
                context.SaveChanges();
            }
        }

        public void SaveExamResult(int examId)
        {
            using(var context = new LanguageLearningContext())
            {
                var correctAnswers = context.ExamQuestions.Where(x => x.ExamId == examId).Where(q => q.Question.CorrectAnswer.ToLower().Equals(q.StudentAnswer.ToLower()));
                var examResult = correctAnswers.Count()*10;

                var exam= new Exam()
                {
                    Id = examId,
                    ExamResult = examResult
                };
                context.Exams.Attach(exam);
                context.Entry(exam).Property(x => x.ExamResult).IsModified = true;
                context.SaveChanges();
            }
            
        }

       
    }
}
