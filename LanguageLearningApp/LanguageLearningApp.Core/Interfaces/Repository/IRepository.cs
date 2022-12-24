using LanguageLearningApp.Core.Entities;
using System.Linq.Expressions;

namespace LanguageLearningApp.Core.Interfaces.Repository
{
    public interface IRepository<T> where T : class,IEntity, new()  
    {
        List<T>GetAll(Expression<Func<T, bool>> filter = null);
         T Get(Expression<Func<T, bool>> filter);


    }
}
