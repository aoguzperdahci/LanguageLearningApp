using LanguageLearningApp.Core.Entities;
using LanguageLearningApp.Core.Interfaces.Repository;
using LanguageLearningApp.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Infrastructure.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class  
    {
        LanguageLearningContext _context;

        public ReadRepository(LanguageLearningContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public T Get(Expression<Func<T, bool>> filter)
        {
            return Table.SingleOrDefault(filter);
            

        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return filter == null
                 ? Table.ToList() : Table.Where(filter).ToList();
        }
    }
}
