using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project__part_B_;
using System;

namespace Project_part_B_Tests
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void Constructor_ShouldInitializeEmail()
        {
            // Arrange
            string email = "user@test.com";
            string username = "User";
            string password = "1234";

            // Act
            var account = new Account(email, username, password);

            // Assert
            Assert.AreEqual(email, account.Email);
        }

        [TestMethod]
        public void Constructor_ShouldInitializeCreatedAt()
        {
            // Arrange
            var before = DateTime.Now;

            // Act
            var account = new Account("mail@test.com", "User", "1234");

            // Assert
            Assert.IsTrue(account.CreatedAt >= before && account.CreatedAt <= DateTime.Now);
        }

        [TestMethod]
        public void ChangePassword_ValidPassword_ShouldNotThrow()
        {
            // Arrange
            var account = new Account("mail@test.com", "User", "old123");
            string oldPassword = "old123";
            string newPassword = "new123";

            // Act
            account.ChangePassword(oldPassword, newPassword);

            // Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ChangePassword_EmptyPassword_ShouldThrowArgumentException()
        {
            // Arrange
            var account = new Account("mail@test.com", "User", "1234");
            string oldPassword = "1234";
            string newPassword = "";

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                account.ChangePassword(oldPassword, newPassword));
        }

        [TestMethod]
        public void ChangeUsername_ValidUsername_ShouldChange()
        {
            // Arrange
            var account = new Account("mail@test.com", "OldName", "1234");
            string newUsername = "NewName";

            // Act
            account.ChangeUsername(newUsername);

            // Assert
            Assert.AreEqual(newUsername, account.Username);
        }

        [TestMethod]
        public void ChangeUsername_EmptyUsername_ShouldThrowArgumentException()
        {
            // Arrange
            var account = new Account("mail@test.com", "User", "1234");
            string newUsername = "";

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                account.ChangeUsername(newUsername));
        }

        [TestMethod]
        public void ChangePassword_NullPassword_ShouldThrowArgumentException()
        {
            // Arrange
            var account = new Account("mail@test.com", "User", "1234");

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                account.ChangePassword("1234", null!));
        }

        [TestMethod]
        public void ChangePassword_WrongOldPassword_ShouldThrowArgumentException()
        {
            // Arrange
            var account = new Account("mail@test.com", "User", "correct123");

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                account.ChangePassword("wrong123", "new123"));
        }

        [TestMethod]
        public void ChangeUsername_NullUsername_ShouldThrowArgumentException()
        {
            // Arrange
            var account = new Account("mail@test.com", "User", "1234");

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                account.ChangeUsername(null!));
        }

        [TestMethod]
        public void ChangeUsername_CalledMultipleTimes_ShouldUpdateValue()
        {
            // Arrange
            var account = new Account("mail@test.com", "User", "1234");

            // Act
            account.ChangeUsername("User1");
            account.ChangeUsername("User2");

            // Assert
            Assert.AreEqual("User2", account.Username);
        }

        [TestMethod]
        public void Email_ShouldRemainUnchanged_AfterOperations()
        {
            // Arrange
            var account = new Account("mail@test.com", "User", "1234");

            // Act
            account.ChangeUsername("NewUser");
            account.ChangePassword("1234", "new123");

            // Assert
            Assert.AreEqual("mail@test.com", account.Email);
        }

        [TestMethod]
        public void CreatedAt_ShouldNotChange_AfterOperations()
        {
            // Arrange
            var account = new Account("mail@test.com", "User", "1234");
            var createdAt = account.CreatedAt;

            // Act
            account.ChangeUsername("AnotherUser");
            account.ChangePassword("1234", "new123");

            // Assert
            Assert.AreEqual(createdAt, account.CreatedAt);
        }
    }
}
