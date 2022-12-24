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
        private Mock<IExamQuestionsRepository> _examQuestionsRepository;
        private Mock<IExamRepository> _examRepository;


        private Fixture _fixture;

        public ExamQuestionTests()
        {
            _fixture = new Fixture();

            _examQuestionService = new Mock<IExamQuestionService>();
            _examQuestionsRepository = new Mock<IExamQuestionsRepository>();
            _examRepository = new Mock<IExamRepository>();
        }
        [TestMethod]
        public async Task NextQuestion()
        {

            var exams = _fixture.CreateMany<Exam>(2).ToList();
            var examId = exams.Last().Id;
            var examQuestions = _fixture.CreateMany<ExamQuestions>(2).ToList();
            examQuestions.First().ExamId = exams.First().Id;
            examQuestions.Last().ExamId = exams.Last().Id;

            var studentId = exams.Last().Student.Id;
            var expectedExam = exams.Last();
            var expectedExamQuestion = examQuestions.Last().Question;
            _examRepository.Setup(e => e.GetTheLastExam(studentId)).Returns(expectedExam);
            _examQuestionsRepository.Setup(e => e.NextQuestion(examId)).Returns((expectedExamQuestion));
            _examQuestionService.Setup(e => e.GetNextQuestion(studentId)).Returns(new SuccesDataResult<Question>(expectedExamQuestion));

            var controller = new ExamQuestionController(_examQuestionService.Object);
            var result = await controller.NextQuestion(studentId);
            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);

        }

    }
}