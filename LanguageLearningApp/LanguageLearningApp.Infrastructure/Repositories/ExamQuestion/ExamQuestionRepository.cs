using LanguageLearningApp.Core.Entities;
using LanguageLearningApp.Core.Interfaces.Repository;
using LanguageLearningApp.Core.Utilities.Results;
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
                return context.ExamQuestions.Where(x => x.ExamId == examQuestionId).OrderBy(q => q.QuestionNumber).Where(s => s.StudentAnswer.Equals("")).First().Question;
               
            }

        }

        public void SaveAnswer(int examQuestionId, string answer)
        {
            
            using(var context = new LanguageLearningContext())
            {
                var examQuestion = context.ExamQuestions.Where(x => x.ExamId == examQuestionId).OrderBy(q => q.QuestionNumber).Where(y => y.StudentAnswer.Equals("")).First();
                examQuestion.StudentAnswer = answer;
                context.SaveChanges();
            }
        }

    }
}
