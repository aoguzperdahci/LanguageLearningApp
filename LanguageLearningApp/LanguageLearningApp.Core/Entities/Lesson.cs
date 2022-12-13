using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Core.Entities
{
    public class Lesson:IEntity
    {
        [Key]
        public string Name { get; set; }
        public string Level { get; set; }
        public string LessonContent { get; set; }

    }
}
