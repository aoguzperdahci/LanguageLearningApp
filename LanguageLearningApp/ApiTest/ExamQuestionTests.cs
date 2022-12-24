using AutoFixture;
using LanguageLearningApp.Core.Constants;
using LanguageLearningApp.Core.Entities;
using LanguageLearningApp.Core.Interfaces.Repository;
using LanguageLearningApp.Core.Interfaces.Services;
using LanguageLearningApp.Core.Utilities.Results;
using LanguageLearningApp.Infrastructure.Repositories;
using LanguageLearningApp.WebAPI.Controller;
using LanguageLearningApp.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTest
{
    [TestClass]
    public class ExamQuestionTests
    {
        private Mock<IExamQuestionService> _examQuestionService;
        private Mock<IExamQuestionsRepository> _examQuestionRepository;
        
        


        private Fixture _fixture;

        public ExamQuestionTests()
        {
            _fixture = new Fixture();
            _examQuestionRepository = new Mock<IExamQuestionsRepository>();
            _examQuestionService = new Mock<IExamQuestionService>();
        }
        [TestMethod]
        public async Task NextQuestion()
        {
            var exams = _fixture.Create<Exam>();
            var gapFillingQuestion = _fixture.Create<GapFillingQuestion>();
            var examQuestion = _fixture.Create<TestQuestion>();
            examQuestion.Id = exams.Id;
            var studentId = exams.Student.Id;
            var expectedQuestionId = examQuestion.Id;
            _examQuestionService.Setup(e => e.GetNextQuestionId(studentId)).Returns(expectedQuestionId);
            _examQuestionService.Setup(e => e.GetTestQuestion(expectedQuestionId)).Returns(new SuccesDataResult<TestQuestion>(examQuestion));
            _examQuestionService.Setup(e => e.GetGapFillingQuestion(expectedQuestionId)).Returns(new ErrorDataResult<GapFillingQuestion>());
            var controller = new ExamQuestionController(_examQuestionService.Object);
            var result = await controller.NextQuestion(studentId);
            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);

        }
        [TestMethod]
        public async Task SaveStudentAnswer()
        {
            var student = _fixture.Create<Student>();
            var answer = "This is an answer";
            _examQuestionService.Setup(e => e.GetAnswer(student.Id, answer)).Returns(new SuccessResult());
            var controller = new ExamQuestionController(_examQuestionService.Object);
            var result = await controller.SaveStudentAnswer(student.Id,answer);
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task GetExamResult()
        {
            var student = _fixture.Create<Student>();
            var exam = _fixture.Create<Exam>();
            var examQuestions = _fixture.CreateMany<ExamQuestions>(10).ToList();
            examQuestions.ForEach(x => x.ExamId = exam.Id);
            _examQuestionService.Setup(e => e.GetExamResult(student.Id)).Returns(new List<ExamQuestionResult>());
            var controller = new ExamQuestionController(_examQuestionService.Object);
            var result = await controller.GetExamResult(student.Id);
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
    }
}