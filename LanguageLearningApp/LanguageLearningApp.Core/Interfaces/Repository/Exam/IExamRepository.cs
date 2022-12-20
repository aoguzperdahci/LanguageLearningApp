using LanguageLearningApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Core.Interfaces.Repository
{
    public interface IExamRepository:IRepository<Exam>
    {
        public void CreateExam(Student student, Lesson lesson);
        public Exam GetTheLastExam(int studentId);
        public void SaveExamResult(int examId, int examResult);


    }
}
