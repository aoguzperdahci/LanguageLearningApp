using LanguageLearningApp.Core.Entities;
using LanguageLearningApp.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Core.Interfaces.Repository
{
    public interface IExamQuestionsRepository : IRepository<ExamQuestions>
    {
        public void SaveExamQuestion(int ExamId, int QuestionNumber ,Question question);
        public Question NextQuestion(int examQuestionId);
        public void SaveAnswer(int examQuestionId, string answer);
    }
}
