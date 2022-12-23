using LanguageLearningApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Core.Interfaces.Repository
{
    public interface IExamQuestionsRepository<T> : IRepository<ExamQuestions>
    {
        public void SaveExamQuestion(int ExamId, int QuestionNumber ,Question question);
        public T NextQuestion(int examQuestionId);
        public void SaveAnswer(int examQuestionId, string answer);

    }
}
