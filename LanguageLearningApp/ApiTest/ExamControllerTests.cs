using AutoFixture;
using LanguageLearningApp.Core.Entities;
using LanguageLearningApp.Core.Interfaces.Services;
using LanguageLearningApp.Core.Utilities.Results;
using LanguageLearningApp.WebAPI.Controller;
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
    public class ExamControllerTests
    {
        private readonly Mock<IExamService> _examServiceMock;

        private Fixture _fixture;

        public ExamControllerTests()
        {
            _examServiceMock = new Mock<IExamService>();
            _fixture = new Fixture();
        }

        [TestMethod]
        public async Task CreateExam()
        {
            var studentList = _fixture.CreateMany<Student>(5).ToList();
            var student = studentList.First();
            _examServiceMock.Setup(e => e.CreateExam(student.Id)).Returns(new SuccessResult());
            var examController = new ExamController(_examServiceMock.Object);
            _examServiceMock.Setup(ex => ex.PrepareExamQuestions(student.Id)).Returns(new SuccessResult());
            var result = await examController.CreateExam(student.Id);
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }

    }
}