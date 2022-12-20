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
        const int easyNumberOfQuestion = 4;
        const int mediumNumberOfQuestion = 3;
        const int hardNumberOfQuestion = 3;


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
                var exam = _examService.GetTheLastExam(studentId);
                var lessonQuestions = _questionService.GetAll(q => q.Lesson.Id == exam.Lesson.Id);
                var easyQuestions = lessonQuestions.FindAll(q => q.Difficulty == QuestionDifficulty.Easy);
                var mediumQuestions = lessonQuestions.FindAll(q => q.Difficulty == QuestionDifficulty.Medium);
                var hardQuestions = lessonQuestions.FindAll(q => q.Difficulty == QuestionDifficulty.Hard);
                
                Random random = new Random();
                for (int i = 1; i <= easyNumberOfQuestion; i++)
                {
                    int index = random.Next(0, easyQuestions.Count);
                    var question = lessonQuestions.ElementAt(index);
                    lessonQuestions.Remove(question);
                    _examQuestionsRepository.SaveExamQuestion(exam.Id, i, question);
                }

                for (int i = 1; i <= mediumNumberOfQuestion; i++)
                {
                    int index = random.Next(0, mediumQuestions.Count);
                    var question = lessonQuestions.ElementAt(index);
                    lessonQuestions.Remove(question);
                    _examQuestionsRepository.SaveExamQuestion(exam.Id, i, question);
                }

                for (int i = 1; i <= hardNumberOfQuestion; i++)
                {
                    int index = random.Next(0, hardQuestions.Count);
                    var question = lessonQuestions.ElementAt(index);
                    lessonQuestions.Remove(question);
                    _examQuestionsRepository.SaveExamQuestion(exam.Id, i, question);
                }
                return new SuccessResult(Messages.ExamQuestionCreated);

            }
            return new ErrorResult(Messages.StudentMissing+Messages.ExamQuestionsIsNotCreated);
           
        }
    }
}
