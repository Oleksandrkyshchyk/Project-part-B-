using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project__part_B_;

namespace Project__part_B_Tests
{
    [TestClass]
    public class DeveloperTests
    {
        [TestMethod]
        public void Name_SetAndGet_ShouldWork()
        {
            var dev = new Developer { Name = "CD Projekt Red" };
            Assert.AreEqual("CD Projekt Red", dev.Name);
        }

        [TestMethod]
        public void FoundationYear_SetAndGet_ShouldWork()
        {
            var dev = new Developer { FoundationYear = 1994 };
            Assert.AreEqual(1994, dev.FoundationYear);
        }

        [TestMethod]
        public void Developer_Constructor_ShouldCreateInstance()
        {
            var dev = new Developer();
            Assert.IsNotNull(dev);
        }

        [TestMethod]
        public void Developer_FoundationYear_ShouldNotBeInFuture()
        {
            var dev = new Developer { FoundationYear = 2050 };
            // У майбутньому тут буде логіка валідації
            Assert.IsTrue(dev.FoundationYear <= DateTime.Now.Year, "Year cannot be in the future");
        }

        [TestMethod]
        public void Developer_FoundationYear_ShouldNotBeTooOld()
        {
            var dev = new Developer { FoundationYear = 1800 };
            Assert.IsTrue(dev.FoundationYear >= 1950, "Video game companies didn't exist in 1800");
        }

        [TestMethod]
        public void Developer_Name_Length_ShouldBeWithinReason()
        {
            var dev = new Developer { Name = "A" };
            Assert.IsTrue(dev.Name.Length >= 1, "Company name cannot be empty");
        }
    }
}