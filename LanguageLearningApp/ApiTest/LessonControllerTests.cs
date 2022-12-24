using AutoFixture;
using LanguageLearningApp.Core.Constants;
using LanguageLearningApp.Core.Entities;
using LanguageLearningApp.Core.Interfaces.Repository;
using LanguageLearningApp.Core.Interfaces.Services;
using LanguageLearningApp.Core.Utilities.Results;
using LanguageLearningApp.Infrastructure.Repositories;
using LanguageLearningApp.Service;
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
    public class LessonControllerTests
    {

        private readonly Mock<ILessonService> _lessonServiceMock;

        private Fixture _fixture;


        public LessonControllerTests()
        {
            _fixture = new Fixture();

            _lessonServiceMock = new Mock<ILessonService>();
        }

        [TestMethod]
        public async Task GetSingleLesson()
        {
            var lessonList = _fixture.CreateMany<Lesson>(5).ToList();
            var lessonId = lessonList.First().Id;
            var expected = lessonList.First();
            _lessonServiceMock.Setup(x => x.GetSingleLesson(lessonId)).Returns(new SuccesDataResult<Lesson>(expected));
            var _lessonController = new LessonController(_lessonServiceMock.Object);
            var result = await _lessonController.GetSingleLesson(lessonId);
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }


        [TestMethod]
        public async Task GetCurrentLesson()
        {
            var studentList = _fixture.CreateMany<Student>(5).ToList();
            var currentLesson = studentList.First().Lesson;
            var toExpect = new LessonShortInfo { Id = studentList.First().Id, Name = studentList.First().Name };
            _lessonServiceMock.Setup(s => s.GetCurrentLessonDetails(studentList.First().Id)).Returns(new SuccesDataResult<LessonShortInfo>(toExpect));
            var _lessonController = new LessonController(_lessonServiceMock.Object);
            var result = await _lessonController.GetCurrentLesson(studentList.First().Id);
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task LessonDetail()
        {
            var lessonList = _fixture.CreateMany<LessonShortInfo>().ToList();
            _lessonServiceMock.Setup(l => l.LessonDetails()).Returns(new SuccesDataResult<List<LessonShortInfo>>(lessonList));
            var lessonController = new LessonController(_lessonServiceMock.Object);
            var result = await lessonController.LessonDetail();
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }

    }
}
