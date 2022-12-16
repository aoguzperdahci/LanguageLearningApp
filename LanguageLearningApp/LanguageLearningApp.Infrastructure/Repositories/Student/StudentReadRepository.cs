using LanguageLearningApp.Core.Entities;
using LanguageLearningApp.Core.Interfaces.Repository;
using LanguageLearningApp.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Infrastructure.Repositories
{
    public class StudentReadRepository : ReadRepository<Student>, IStudentReadRepository
   {
        public StudentReadRepository(LanguageLearningContext context) : base(context)
        {
        }
        public void UpdateStudentOrder(Student student)
        {
            using (var context = new LanguageLearningContext())
            {
                var updatedEntity = context.Entry(student);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
