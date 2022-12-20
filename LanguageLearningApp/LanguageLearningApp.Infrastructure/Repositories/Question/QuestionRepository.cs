using LanguageLearningApp.Core.Entities;
using LanguageLearningApp.Core.Interfaces.Repository;
using LanguageLearningApp.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LanguageLearningApp.Infrastructure.Repositories
{
    public class QuestionRepository : ReadRepository<Question,LanguageLearningContext>, IQuestionRepository
    {
    }
}
