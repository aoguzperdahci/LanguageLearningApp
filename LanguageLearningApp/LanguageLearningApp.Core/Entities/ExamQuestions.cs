using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Core.Entities
{
    [PrimaryKey(nameof(Exam), nameof(QuestionNumber))]
    public class ExamQuestions
    {
        public Exam Exam { get; set; }
        public int QuestionNumber { get; set; }
        public Question Question { get; set; }
        public string StudentAnswer { get; set; }
    }
}
