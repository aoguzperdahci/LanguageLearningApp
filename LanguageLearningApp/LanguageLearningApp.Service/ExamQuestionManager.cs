using LanguageLearningApp.Core.Constants;
using LanguageLearningApp.Core.Entities;
using LanguageLearningApp.Core.Interfaces.Repository;
using LanguageLearningApp.Core.Interfaces.Services;
using LanguageLearningApp.Core.Utilities.Results;
using LanguageLearningApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Service
{
    public class ExamQuestionManager<T>:IExamQuestionService<T>
    {
        private IExamQuestionsRepository<T> _examQuestionsRepository;
        private IExamRepository _examRepository; 
        private ILessonRepository _lessonRepository;
        private IStudentRepository _studentRepository;
        private int PASSING_SCORE = 70; 
        public ExamQuestionManager(IExamQuestionsRepository<T> examQuestionsRepository, IExamRepository examRepository, ILessonRepository lessonRepository, IStudentRepository studentRepository)
        {
            _examQuestionsRepository = examQuestionsRepository;
            _examRepository = examRepository;
            _lessonRepository = lessonRepository;
            _studentRepository = studentRepository;
        }

        public IDataResult<T> GetNextQuestion(int studentId)
        {

            if (_studentRepository.isStudent(studentId))
            {
                var examId = _examRepository.GetTheLastExam(studentId).Id;
                return new SuccesDataResult<T>(_examQuestionsRepository.NextQuestion(examId), Messages.QuestionServed);
            }
            return new ErrorDataResult<T>(Messages.StudentMissing);
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

        public List<ExamQuestionResult> GetExamResult(int studentId)
        {
            var examId = _examRepository.GetTheLastExam(studentId).Id;
            var examQuestions = _examQuestionsRepository.GetAll(e => e.ExamId == examId);
            List<ExamQuestionResult> results = new List<ExamQuestionResult>();
            int correctAnswerCount = 0;

            foreach(var question in examQuestions)
            {
                var correct = question.Question.CorrectAnswer.ToLower() == question.StudentAnswer.ToLower();

                if (correct)
                {
                    correctAnswerCount++;
                }

                results.Add(new ExamQuestionResult { Correct = correct, Difficulty = question.Question.Difficulty});
            }

            var examResult = correctAnswerCount / examQuestions.Count() * 100;
            _examRepository.SaveExamResult(examId, examResult);

            if (examResult >= PASSING_SCORE)
            {
                _studentRepository.UpdateStudentLesson(studentId);
            }

            return results;
        }
    }
}
