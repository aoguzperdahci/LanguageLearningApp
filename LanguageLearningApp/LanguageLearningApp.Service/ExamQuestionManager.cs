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
    public class ExamQuestionManager:IExamQuestionService
    {
        private IExamQuestionsRepository _examQuestionsRepository;
        private IExamRepository _examRepository; 
        private ILessonRepository _lessonRepository;
        private IStudentRepository _studentRepository;
        private int PASSING_SCORE = 70; 
        public ExamQuestionManager(IExamQuestionsRepository examQuestionsRepository, IExamRepository examRepository, ILessonRepository lessonRepository, IStudentRepository studentRepository)
        {
            _examQuestionsRepository = examQuestionsRepository;
            _examRepository = examRepository;
            _lessonRepository = lessonRepository;
            _studentRepository = studentRepository;
        }

        public int GetNextQuestionId(int studentId)
        {
            if (_studentRepository.isStudent(studentId))
            {
                var examId = _examRepository.GetTheLastExam(studentId).Id;
                return _examQuestionsRepository.NextQuestionId(examId);
            }
            return -1;
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

            var examResult = correctAnswerCount*10;
            _examRepository.SaveExamResult(examId, examResult);

            if (examResult >= PASSING_SCORE)
            {
                _studentRepository.UpdateStudentLesson(studentId);
            }
            return results;
        }

        public IDataResult<TestQuestion> GetTestQuestion(int questionId)
        {
            var question = _examQuestionsRepository.GetTestQuestion(questionId);

            if (question != null)
            {
                return new SuccesDataResult<TestQuestion>(question, Messages.QuestionServed);
            }
            else
            {
                return new ErrorDataResult<TestQuestion>(Messages.StudentMissing);
            }
        }

        public IDataResult<GapFillingQuestion> GetGapFillingQuestion(int questionId)
        {
            var question = _examQuestionsRepository.GetGapFillingQuestion(questionId);

            if (question != null)
            {
                return new SuccesDataResult<GapFillingQuestion>(question, Messages.QuestionServed);
            }
            else
            {
                return new ErrorDataResult<GapFillingQuestion>(Messages.StudentMissing);
            }
        }
    }
}
