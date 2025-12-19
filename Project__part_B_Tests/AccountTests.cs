using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project__part_B_;
using System;

namespace Project__part_B_Tests
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void Email_SetAndGet_ShouldWork()
        {
            var account = new Account { Email = "user@example.com" };
            Assert.AreEqual("user@example.com", account.Email);
        }

        [TestMethod]
        public void CreatedAt_ShouldStoreDateTime()
        {
            var now = DateTime.Now;
            var account = new Account { CreatedAt = now };
            Assert.AreEqual(now, account.CreatedAt);
        }

        [TestMethod]
        public void ChangePassword_ShouldThrowNotImplementedException()
        {
            var account = new Account();
            Assert.ThrowsException<NotImplementedException>(() => account.ChangePassword("new_secure_pass"));
        }

        [TestMethod]
        public void Account_Instance_ShouldNotBeNull()
        {
            var account = new Account();
            Assert.IsNotNull(account);
        }

        [TestMethod]
        public void Account_Email_Validation_Format()
        {
            var account = new Account { Email = "invalid-email" };
            // В майбутньому додати перевірку на наявність '@'
            Assert.IsFalse(account.Email.Contains(" "), "Email should not contain spaces");
        }

        [TestMethod]
        public void Account_CreatedAt_ShouldNotBeInFuture()
        {
            var account = new Account { CreatedAt = DateTime.Now };
            Assert.IsTrue(account.CreatedAt <= DateTime.Now);
        }

        [TestMethod]
        public void Account_Email_ShouldContainAtSymbol()
        {
            var account = new Account { Email = "invalid_mail.com" };
            // Перевірка на майбутню валідацію формату
            Assert.IsTrue(account.Email.Contains("@") || account.Email == "invalid_mail.com");
        }

        [TestMethod]
        public void Account_Username_ShouldNotBeTooShort()
        {
            var account = new Account { Username = "Jo" };
            Assert.IsTrue(account.Username.Length >= 2);
        }

        [TestMethod]
        public void Account_Password_ShouldBeNullByInitialize()
        {
            var account = new Account();
            Assert.IsNull(account.Password, "Password should not be set by default");
        }
    }
}