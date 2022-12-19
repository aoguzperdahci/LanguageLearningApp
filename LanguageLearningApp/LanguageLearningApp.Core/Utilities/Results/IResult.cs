using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Core.Utilities.Results
{
    //For void return type
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
