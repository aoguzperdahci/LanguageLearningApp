using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Core.Entities
{
    public class Lesson:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public int Order { get; set; }
        public string LessonContent { get; set; }
        public MultimediaContent MultimediaContent { get; set; }

    }
}
