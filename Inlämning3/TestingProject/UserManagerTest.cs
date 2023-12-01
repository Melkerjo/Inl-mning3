using Inlämning3.Interfaces;
using Inlämning3;
using Moq;
using NUnit.Framework;

namespace UserManagerTests
{
    [TestFixture]
    public class UserManagerTests
    {
        private User user;
        private Mock<IDatabase> mockDatabase;
        private UserManager userManager;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            user = new User(1, "Melker", "password", "melker@example.com");
            mockDatabase = new Mock<IDatabase>();
            userManager = new UserManager(mockDatabase.Object);

            // Configure the AddUser method to save the user
            mockDatabase.Setup(db => db.AddUser(user)).Callback((User u) => user = u);

            // Configure the GetUser method to return the saved user
            mockDatabase.Setup(db => db.GetUser(user.UserId)).Returns(user);
        }

        [Test]
        public void AddUser_ValidUser_CallsAddUserInDatabase()
        {
            // Act
            userManager.AddUser(user);

            // Assert
            mockDatabase.Verify(db => db.AddUser(user), Times.Once, "AddUser should be called once");
        }

        [Test]
        public void GetUser_GetsUserFromDatabase()
        {
            // Act
            var result = userManager.GetUser(user.UserId);

            // Assert
            Assert.IsNotNull(result); // Check if user exists
            Assert.AreEqual(user.UserId, result.UserId); // Compare UserId
            Assert.AreEqual(user.UserName, result.UserName); // Compare UserName
            Assert.AreEqual(user.Password, result.Password); // Compare Password
            Assert.AreEqual(user.Email, result.Email); // Compare Email
        }

        [Test]
        public void RemoveUser_ValidUserId_CallsRemoveUserInDatabase()
        {
            // Act
            userManager.RemoveUser(user.UserId);

            // Assert
            mockDatabase.Verify(db => db.RemoveUser(user.UserId), Times.Once, "RemoveUser should be called once");
        }

        [Test]
        public void GetUser_WhenUserNotFound_ThrowsUserNotFoundException()
        {
            // Arrange
            int nonExistentUserId = 999;

            // Act and Assert
            var ex = Assert.Throws<ArgumentException>(() => userManager.GetUser(nonExistentUserId));
            Assert.AreEqual($"User with ID {nonExistentUserId} not found", ex.Message);

        }


        [Test]
        public void RemoveUser_WhenUserNotFound_ThrowsUserNotFoundException()
        {
            // Arrange
            int nonExistentUserId = 999;

            // Act and Assert
            var ex = Assert.Throws<ArgumentException>(() => userManager.RemoveUser(nonExistentUserId));
            Assert.AreEqual($"User with ID {nonExistentUserId} not found", ex.Message);
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up after each test
            user = null;
            userManager = null;
            mockDatabase.Reset();
        }
    }
}
