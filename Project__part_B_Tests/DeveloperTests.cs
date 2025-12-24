using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project__part_B_;

namespace Project__part_B_Tests
{
    [TestClass]
    public class DeveloperTests
    {
        [TestMethod]
        public void Name_Set_ShouldBeStored()
        {
            // Arrange
            var developer = new Developer();
            string name = "CD Projekt Red";

            // Act
            developer.Name = name;

            // Assert
            Assert.AreEqual(name, developer.Name);
        }

        [TestMethod]
        public void FoundationYear_Set_ShouldBeStored()
        {
            // Arrange
            var developer = new Developer();
            int year = 1994;

            // Act
            developer.FoundationYear = year;

            // Assert
            Assert.AreEqual(year, developer.FoundationYear);
        }

        [TestMethod]
        public void Developer_Constructor_ShouldCreateInstance()
        {
            // Arrange & Act
            var developer = new Developer();

            // Assert
            Assert.IsNotNull(developer);
        }

        [TestMethod]
        public void Developer_Name_ShouldNotBeNull()
        {
            // Arrange
            var developer = new Developer();

            // Act
            developer.Name = "Valve";

            // Assert
            Assert.IsNotNull(developer.Name);
        }

        [TestMethod]
        public void Name_CanBeChangedMultipleTimes()
        {
            // Arrange
            var developer = new Developer();

            // Act
            developer.Name = "Valve";
            developer.Name = "Rockstar";

            // Assert
            Assert.AreEqual("Rockstar", developer.Name);
        }

        [TestMethod]
        public void FoundationYear_CanBeUpdated()
        {
            // Arrange
            var developer = new Developer();

            // Act
            developer.FoundationYear = 1998;
            developer.FoundationYear = 2001;

            // Assert
            Assert.AreEqual(2001, developer.FoundationYear);
        }

        [TestMethod]
        public void Developer_Properties_ShouldBeIndependentBetweenInstances()
        {
            // Arrange
            var dev1 = new Developer { Name = "CD Projekt" };
            var dev2 = new Developer { Name = "Ubisoft" };

            // Act
            dev1.Name = "CDPR";

            // Assert
            Assert.AreEqual("CDPR", dev1.Name);
            Assert.AreEqual("Ubisoft", dev2.Name);
        }

        [TestMethod]
        public void Name_CanBeSetToNull()
        {
            // Arrange
            var developer = new Developer { Name = "Valve" };

            // Act
            developer.Name = null!;

            // Assert
            Assert.IsNull(developer.Name);
        }
    }
}
