// FILE: src/Endpoints/v1/UsersTest.cs
using NUnit.Framework;
using Moq;
using MythApi.Users.Interfaces;
using MythApi.Users.Models;
using MythApi.Endpoints.v1;
using System.Threading.Tasks;
using MythApi.Common.Database.Models;
using System.Text.Encodings.Web;

namespace MythApi.Tests.Endpoints.v1
{
    [TestFixture]
    public class UsersTest
    {
        private Mock<IUserRepository> _userRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
        }

        [Test]
        public async Task AddOrUpdateUserInformation_CallsRepositoryMethod()
        {
            // Arrange
            var userInput = new UserInput { Name = "Test User", Bio = "test@example.com" };
            var user = new User { Id = 1, Name = "Test User", Bio = "test@example.com" };
            _userRepositoryMock.Setup(repo => repo.AddOrUpdateUserInformation(userInput)).ReturnsAsync(user);

            // Act
            var result = await MythApi.Endpoints.v1.Users.AddOrUpdateUserInformation(userInput, _userRepositoryMock.Object);

            // Assert
            Assert.AreEqual(user, result);
            _userRepositoryMock.Verify(repo => repo.AddOrUpdateUserInformation(userInput), Times.Once);
        }

        [Test]
        public async Task AddOrUpdateUserInformation_EncodesInputToPreventXSS()
        {
            // Arrange
            var userInput = new UserInput { Name = "<script>alert('xss')</script>", Bio = "test@example.com" };
            var encodedName = HtmlEncoder.Default.Encode(userInput.Name);
            var user = new User { Id = 1, Name = encodedName, Bio = "test@example.com" };
            _userRepositoryMock.Setup(repo => repo.AddOrUpdateUserInformation(It.Is<UserInput>(u => u.Name == encodedName))).ReturnsAsync(user);

            // Act
            var result = await MythApi.Endpoints.v1.Users.AddOrUpdateUserInformation(userInput, _userRepositoryMock.Object);

            // Assert
            _userRepositoryMock.Verify(repo => repo.AddOrUpdateUserInformation(It.Is<UserInput>(u => u.Name == encodedName)), Times.Once);
            Assert.AreEqual(encodedName, result.Name);
        }
    }
}