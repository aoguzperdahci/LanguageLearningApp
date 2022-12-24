using LanguageLearningApp.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Core.Entities
{
    public class ExamQuestionResult
    {
        public bool Correct { get; set; }
        public QuestionDifficulty Difficulty { get; set; }
    }
}
