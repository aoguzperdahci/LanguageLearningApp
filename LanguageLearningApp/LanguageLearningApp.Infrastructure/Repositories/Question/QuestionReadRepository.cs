using LanguageLearningApp.Core.Entities;
using LanguageLearningApp.Core.Interfaces.Repository;
using LanguageLearningApp.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LanguageLearningApp.Infrastructure.Repositories
{
    public class QuestionReadRepository : ReadRepository<Question>, IQuestionReadRepository
    {
        public QuestionReadRepository(LanguageLearningContext context) : base(context)
        {
        }

       
    }
}
