using LanguageLearningApp.Core.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Core.Entities
{
    public class MultimediaContent:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Link { get; set; }
        public MultimediaType Type { get; set; }

    }
}
