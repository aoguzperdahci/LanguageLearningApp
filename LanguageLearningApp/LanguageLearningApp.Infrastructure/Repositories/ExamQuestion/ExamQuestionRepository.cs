using LanguageLearningApp.Core.Entities;
using LanguageLearningApp.Core.Interfaces.Repository;
using LanguageLearningApp.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace LanguageLearningApp.Infrastructure.Repositories
{
    public class ExamQuestionRepository<T> : ReadRepository<ExamQuestions,LanguageLearningContext>, IExamQuestionsRepository<T>
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

        public T NextQuestion(int examQuestionId)
        {
            using(var context = new LanguageLearningContext())
            {
                var questionId = context.ExamQuestions.Where(x => x.ExamId == examQuestionId).OrderBy(q => q.QuestionNumber).Where(s => s.StudentAnswer.Equals("")).First().Question.Id;
                if(context.TestQuestions.Where(x=>x.Id == questionId) !=null)
                {
                    var nextQuestion = context.TestQuestions.Where(x => x.Id == questionId);
                    return (T)nextQuestion;

                }
                return (T)context.GapFillingQuestions.Where(x => x.Id == questionId);
               
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
