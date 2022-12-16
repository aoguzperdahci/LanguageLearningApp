using LanguageLearningApp.Core.Entities;
using LanguageLearningApp.Core.Interfaces.Repository;
using LanguageLearningApp.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Infrastructure.Repositories
{
    public class LessonReadRepository : ReadRepository<Lesson>, ILessonReadRepository
    {
        public LessonReadRepository(LanguageLearningContext context) : base(context)
        {
        }
    }
}
