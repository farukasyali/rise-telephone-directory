using Microsoft.AspNetCore.Mvc;
using Moq;
using PhoneBook.Web.Controllers;
using PhoneBook.Web.Services.Abstract;
using Xunit;

namespace PhoneBook.Web.Test
{
    public class PersonControllerTest
    {
        private readonly Mock<IPersonService> _mockRepo;

        private readonly PersonController _controller;

        public PersonControllerTest()
        {
            _mockRepo = new Mock<IPersonService>();
            _controller = new PersonController(_mockRepo.Object);
        }

        [Fact]
        public void Index_ActionExecute_ReturnView()
        {
            var result = _controller.Index();

            Assert.IsType<ViewResult>(result);
        }
    }
}
