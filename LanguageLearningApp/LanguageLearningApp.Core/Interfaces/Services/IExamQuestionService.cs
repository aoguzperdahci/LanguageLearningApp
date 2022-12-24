using LanguageLearningApp.Core.Entities;
using LanguageLearningApp.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Core.Interfaces.Services
{
    public interface IExamQuestionService
    {
        public int GetNextQuestionId(int studentId);
        public IDataResult<TestQuestion> GetTestQuestion(int questionId);
        public IDataResult<GapFillingQuestion> GetGapFillingQuestion(int questionId);
        public IResult GetAnswer(int examId,string answer);
        public List<ExamQuestionResult> GetExamResult(int studentId);
    }
}
