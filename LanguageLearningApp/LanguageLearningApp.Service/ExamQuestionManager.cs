using LanguageLearningApp.Core.Constants;
using LanguageLearningApp.Core.Entities;
using LanguageLearningApp.Core.Interfaces.Repository;
using LanguageLearningApp.Core.Interfaces.Services;
using LanguageLearningApp.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Service
{
    public class ExamQuestionManager:IExamQuestionService
    {
        private IExamQuestionsRepository _examQuestionsRepository;
        private IExamRepository _examRepository; 
        private ILessonRepository _lessonRepository;
        private IStudentRepository _studentRepository;
        public ExamQuestionManager(IExamQuestionsRepository examQuestionsRepository, IExamRepository examRepository, ILessonRepository lessonRepository, IStudentRepository studentRepository)
        {
            _examQuestionsRepository = examQuestionsRepository;
            _examRepository = examRepository;
            _lessonRepository = lessonRepository;
            _studentRepository = studentRepository;
        }

        public IDataResult<Question> GetNextQuestion(int studentId)
        {

            var examId = _examRepository.GetTheLastExam(studentId).Id;
            return new DataResult<Question>(_examQuestionsRepository.NextQuestion(examId),true, Messages.QuestionServed);

        }

        public IResult GetAnswer(int studentId, string answer)
        {
            if(_studentRepository.isStudent(studentId))
            {
                var examId = _examRepository.GetTheLastExam(studentId).Id;
                _examQuestionsRepository.SaveAnswer(examId, answer);
                return new SuccessResult(Messages.AnswerSaved);
            }
            return new ErrorResult(Messages.StudentMissing + Messages.AnswerIsNotSaved);
        }
            

        public IResult CalculateExamResult(int studentId)
        {
            if (_studentRepository.isStudent(studentId))
            {
                var examId = _examRepository.GetTheLastExam(studentId).Id;
                _examQuestionsRepository.SaveExamResult(examId);
                return new SuccessResult(Messages.ExamResultCalculated);
            }
            return new ErrorResult(Messages.StudentMissing + Messages.ExamIsNotCalculated);
        }

        public int GetExamResult(int studentId)
        {
            var examId = _examRepository.GetTheLastExam(studentId).Id;
            var examResult = _examRepository.Get(x => x.Id == examId).ExamResult;
            if (examResult >= 70)
            {
                var maxOrder = _lessonRepository.GetAll().Count - 1;
                var studentOrder =_studentRepository.Get(s => s.Id == studentId).Lesson.Order;
                if (maxOrder> studentOrder)
                {
                    _studentRepository.UpdateStudentOrder(_studentRepository.Get(s => s.Id == studentId));
                }
            }
            return examResult;

        }
    }
}
