using LanguageLearningApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Core.DTOs
{
    public class LessonDetailDto:IDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
