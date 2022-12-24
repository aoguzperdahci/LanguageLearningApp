using LanguageLearningApp.Core.Entities;
using LanguageLearningApp.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Core.Interfaces.Repository
{
    public interface IExamQuestionsRepository : IRepository<ExamQuestions>
    {
        public void SaveExamQuestion(int ExamId, int QuestionNumber ,Question question);
        public int NextQuestionId(int examQuestionId);
        public TestQuestion GetTestQuestion(int questionId);
        public GapFillingQuestion GetGapFillingQuestion(int questionId);
        public void SaveAnswer(int examQuestionId, string answer);
        public List<ExamQuestions> GetAll(Expression<Func<ExamQuestions, bool>> filter = null);
    }
}
