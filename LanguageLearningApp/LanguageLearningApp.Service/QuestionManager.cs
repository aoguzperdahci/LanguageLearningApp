using LanguageLearningApp.Core.Entities;
using LanguageLearningApp.Core.Interfaces.Repository;
using LanguageLearningApp.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Service
{
    public class QuestionManager : IQuestionService
    {
        IStudentReadRepository _studentReadRepository;
        IQuestionReadRepository _questionReadRepository;
        ILessonReadRepository _lessonReadRepository;

        List<Question> currentExamQuestionList;
        int NumberOfQuestion = 10;
        int holdIndex = 0;
        int ExamResult = 0;
        int CurrentStudentId = 0;
        //IExamRepository

        public QuestionManager(IStudentReadRepository studentReadRepository, IQuestionReadRepository questionReadRepository , ILessonReadRepository lessonReadRepository)

        {
            _studentReadRepository = studentReadRepository;
            _questionReadRepository = questionReadRepository;
            _lessonReadRepository = lessonReadRepository;
     

        }

        public void UpdateStudentOrder()
        {
            if(ExamResult >= 70)
            {
                var maxOrder = _lessonReadRepository.GetAll().Count-1;
                var currentStudent= _studentReadRepository.Get(s => s.Id == CurrentStudentId);
                var currentStudentOrder = currentStudent.Lesson.Order;
                if (maxOrder > currentStudentOrder)
                {
                    currentStudent.Lesson.Order++;
                    _studentReadRepository.UpdateStudentOrder(currentStudent);
                    
                }
            }
        }
        
        public int SendExamResult()
        {
            UpdateStudentOrder();
            return ExamResult;
        }
        public void CalculatePoints(int answerResult)
        {
            if (answerResult == 0)
            {
                ExamResult += 10;
            }
        }
        public bool isStudent()
        {

            var currentStudent = _studentReadRepository.Get(s => s.Id == CurrentStudentId);
            if (currentStudent == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void CheckAnswer(string answer)
        {
            var x = currentExamQuestionList[holdIndex++].CorrectAnswer.CompareTo(answer);
            CalculatePoints(x);
        }

        public void Prepare(int StudentId)
        {
            currentExamQuestionList = new List<Question>();
            CurrentStudentId = StudentId;

            var lessonId= _studentReadRepository.Get(s => s.Id == StudentId).Lesson.Id;
            var allQuestions = _questionReadRepository.GetAll(q=>q.Lesson.Id==lessonId);
            var lengthOfQuestions = allQuestions.Count;
            Random rand = new Random();

            for (int i = 0; i < NumberOfQuestion; i++)
            {
                int rInt = rand.Next(0, lengthOfQuestions);
                currentExamQuestionList.Add(allQuestions[rInt]);
            }
        }

        public Question SendQuestion()
        {
            try
            {
                return currentExamQuestionList[holdIndex];
            }
            catch (Exception )
            {

                throw ;
            }
              
        }
     
    }
}
