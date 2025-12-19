using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project__part_B_;

namespace Project__part_B_Tests
{
    [TestClass]
    public class LibraryTests
    {
        [TestMethod]
        public void AddGame_ShouldIncreasePurchasedGamesCount()
        {
            // Arrange
            var library = new Library("MySteam");
            var game = new Game { Title = "Witcher 3" };

            // Act
            library.AddGame(game);

            // Assert
            Assert.AreEqual(1, library.PurchasedGames.Count);
        }

        [TestMethod]
        public void LibraryConstructor_ShouldInitializeAccount()
        {
            // Arrange & Act
            var library = new Library("Player1");

            // Assert
            Assert.IsNotNull(library.UserAccount);
        }

        [TestMethod]
        public void GetTotalGamesCount_ShouldReturnCorrectNumber()
        {
            // Arrange
            var library = new Library("Vault");

            // Act
            int count = library.GetTotalGamesCount();

            // Assert
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void Library_InitialState_GamesList_IsNotNull()
        {
            var library = new Library("Steam");
            Assert.IsNotNull(library.PurchasedGames, "Games list must be initialized");
        }

        [TestMethod]
        public void Library_LaunchGame_NonExistent_ThrowsException()
        {
            var library = new Library("Epic");
            // Перевірка методу на неіснуючу гру
            Assert.ThrowsException<NotImplementedException>(() => library.LaunchGame("UnknownGame"));
        }
    }
}