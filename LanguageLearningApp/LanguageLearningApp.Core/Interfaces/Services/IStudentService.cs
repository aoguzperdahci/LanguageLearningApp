using LanguageLearningApp.Core.Entities;
using LanguageLearningApp.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Core.Interfaces.Services
{
    public interface IStudentService
    {
        IDataResult<Lesson> currentLesson();
        
    }
}
