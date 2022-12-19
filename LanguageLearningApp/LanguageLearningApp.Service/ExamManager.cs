using LanguageLearningApp.Core.Constants;
using LanguageLearningApp.Core.Entities;
using LanguageLearningApp.Core.Interfaces.Repository;
using LanguageLearningApp.Core.Interfaces.Services;
using LanguageLearningApp.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Service
{
    public class ExamManager : IExamService
    {
        private readonly ILessonRepository _lessonService;
        private readonly IStudentRepository _studentService;
        private readonly IQuestionRepository _questionService;
        private readonly IExamRepository _examService;
        private readonly IExamQuestionsRepository _examQuestionsRepository;
        const int totalNumberOfQuestion = 10;


        public ExamManager(IStudentRepository studentService, ILessonRepository lessonReadRepository, IQuestionRepository questionService, IExamRepository examService, IExamQuestionsRepository examQuestionsRepository)

        {
            _examQuestionsRepository = examQuestionsRepository;
            _studentService = studentService;
            _lessonService = lessonReadRepository;
            _questionService = questionService;
            _examService = examService;
        }

        public IResult CreateExam(int studentId)
        {
            if (_studentService.isStudent(studentId))
            {
                var currentStudent = _studentService.Get(s => s.Id == studentId);
                _examService.CreateExam(currentStudent, currentStudent.Lesson);
                return new SuccessResult(Messages.ExamCreated);

            }
            return new ErrorResult(Messages.StudentMissing + Messages.ExamIsNotCreated);
        }

        public IResult PrepareExamQuestions(int studentId)
        {
            if (_studentService.isStudent(studentId))
            {
                var toCreated = _examService.GetTheLastExam(studentId);
                var studentLevelQuestions = _questionService.GetAll(q => q.Lesson.Id == toCreated.Lesson.Id);
                Random random = new Random();
                for (int i = 0; i < totalNumberOfQuestion; i++)
                {
                    int rInt = random.Next(0, studentLevelQuestions.Count);
                    _examQuestionsRepository.SaveExamQuestion(toCreated.Id, i++, studentLevelQuestions[rInt]);

                }
                return new SuccessResult(Messages.ExamQuestionCreated);

            }
            return new ErrorResult(Messages.StudentMissing+Messages.ExamQuestionsIsNotCreated);
           
        }
    }
}
