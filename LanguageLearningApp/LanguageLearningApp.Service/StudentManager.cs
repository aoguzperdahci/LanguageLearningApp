using LanguageLearningApp.Core.Entities;
using LanguageLearningApp.Core.Interfaces.Repository;
using LanguageLearningApp.Core.Interfaces.Services;
using LanguageLearningApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Service
{
    public class StudentManager : IStudentService
    {
        IStudentReadRepository _studentReadRepository;
        int currentStudentId = 0;
        public StudentManager(IStudentReadRepository studentService)
        {
            _studentReadRepository = studentService;
        }

        public Lesson currentLesson()
        {
            return (_studentReadRepository.Get(s => s.Id == currentStudentId).Lesson);
        }

        public void getStudentId(int StudentId)
        {
            currentStudentId = StudentId;
        }

        public bool isStudent()
        {
    
            var currentStudent = _studentReadRepository.Get(s => s.Id == currentStudentId);
            if(currentStudent == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
