using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Core.Entities
{
    [PrimaryKey(nameof(ExamId), nameof(QuestionNumber))]
    public class ExamQuestions:IEntity
    {
        public int ExamId { get; set; }
        public int QuestionNumber { get; set; }
        public Question Question { get; set; }
        public string? StudentAnswer { get; set; }
    }
}
