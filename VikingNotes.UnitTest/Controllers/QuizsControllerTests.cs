using System.Web.Http.Results;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VikingNotes.Controllers.API;
using VikingNotes.Models;
using VikingNotes.Repositories;
using VikingNotes.UnitTest.Extentions;

namespace VikingNotes.UnitTest.Controllers
{
    [TestClass]
    public class QuizsControllerTests
    {
        private QuizsController controller;
        private Mock<IQuizRepository> mockRepository;
        private string userId;

        // creating constructor
        public QuizsControllerTests()
        {
            var mockRepository = new Mock<IQuizRepository>();
            var mockUoW = new Mock<IUnitOfWork>();   // creating a controller

            mockUoW.Setup(u => u.Quizzes).Returns(mockRepository.Object); // when accessing Quiz property of UnitOfWork, return mock repository 

            var controller = new QuizsController(mockUoW.Object); // mock object is the actual implementaiton of IUnitOfWork
            controller.MockCurrentUser("1", "UserName");
        }

        [TestMethod]
        public void Cancel_NoQuizWithGivenIdExists_ShouldReturnNotFound()
        {
            var result = controller.Cancel(1);

            result.Should().BeOfType<NotFoundResult>(); //  fluent assertion
        }

        [TestMethod]
        public void Cancel_ValidRequest_ShouldReturnOk()
        {
            var quiz = new Quiz { AuthorId = userId };

            mockRepository.Setup(r => r.GetQuiz(1)).Returns(quiz);

            var result = controller.Cancel(1);

            result.Should().BeOfType<OkResult>();
        }
    }
}
