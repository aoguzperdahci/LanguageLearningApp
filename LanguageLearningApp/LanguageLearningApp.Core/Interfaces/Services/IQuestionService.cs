using LanguageLearningApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Core.Interfaces.Services
{
    public interface IQuestionService
    {
        void CalculatePoints(int answer);
        public bool isStudent();
        public int SendExamResult();
        public void UpdateStudentOrder();
        void CheckAnswer(string answer);
        void Prepare(int StudentId);
        Question SendQuestion();

        
    }
}
