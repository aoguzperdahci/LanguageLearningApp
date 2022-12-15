using LanguageLearningApp.Core.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Core.Entities
{
    public class Question:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public QuestionDifficulty Difficulty { get; set; }
        public string CorrectAnswer { get; set; }
        public Lesson Lesson { get; set; }
    }
}
