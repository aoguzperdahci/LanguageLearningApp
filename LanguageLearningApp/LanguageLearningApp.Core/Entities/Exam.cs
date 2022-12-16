using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Core.Entities
{
    public class Exam: IEntity
    {
        [Key]
        public int Id { get; set; }
        public Student Student { get; set; }
        public Lesson Lesson { get; set; }
    }
}
