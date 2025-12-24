using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project__part_B_;
using System.Linq;

namespace Project__part_B_Tests
{
    [TestClass]
    public class LibraryLogicTests
    {
        [TestMethod]
        public void Library_ShouldHandleMultipleTypesOfContent()
        {
            // Arrange
            var account = new Account("user@mail.com", "User", "1234");
            var library = new Library(account);

            var game = new Game { Title = "The Witcher 3", Price = 30 };
            var addon = new Addon
            {
                Title = "Blood and Wine",
                Price = 15,
                ParentGame = game
            };

            // Act
            library.AddGame(game);
            library.AddAddon(addon);

            // Assert
            Assert.AreEqual(2, library.PurchasedGames.Count);
            Assert.IsTrue(library.PurchasedGames.Any(i => i is Game));
            Assert.IsTrue(library.PurchasedGames.Any(i => i is Addon));
        }

        [TestMethod]
        public void Library_SortItemsByTitle_ShouldSortAlphabetically()
        {
            // Arrange
            var account = new Account("user@mail.com", "User", "1234");
            var library = new Library(account);

            library.AddGame(new Game { Title = "Zelda" });
            library.AddGame(new Game { Title = "Assassin's Creed" });

            // Act
            library.SortItemsByTitle();

            // Assert
            Assert.AreEqual("Assassin's Creed", library.PurchasedGames.First().Title);
        }

        [TestMethod]
        public void Library_FindGamesByGenre_ShouldReturnCorrectGames()
        {
            // Arrange
            var account = new Account("user@mail.com", "User", "1234");
            var library = new Library(account);

            var rpgGame = new Game { Title = "Skyrim", GameGenre = Genre.RPG };
            var actionGame = new Game { Title = "Doom", GameGenre = Genre.Action };

            library.AddGame(rpgGame);
            library.AddGame(actionGame);

            // Act
            var result = library.FindGamesByGenre(Genre.RPG);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Skyrim", result.First().Title);
        }

        [TestMethod]
        public void Library_OwnerName_ShouldBeTakenFromAccount()
        {
            // Arrange
            var account = new Account("mail@test.com", "Player1", "1234");

            // Act
            var library = new Library(account);

            // Assert
            Assert.AreEqual("Player1", library.OwnerName);
        }

        [TestMethod]
        public void Library_AddNullGame_ShouldNotIncreaseCollection()
        {
            // Arrange
            var account = new Account("mail@test.com", "User", "1234");
            var library = new Library(account);

            int beforeCount = library.PurchasedGames.Count;

            // Act
            library.AddGame(null!);

            // Assert
            Assert.AreEqual(beforeCount, library.PurchasedGames.Count);
        }

        [TestMethod]
        public void Library_ShouldAllowMultipleAddonsForSingleGame()
        {
            // Arrange
            var library = CreateLibrary();
            var game = new Game { Title = "Witcher 3" };

            var addon1 = new Addon { Title = "Blood and Wine", ParentGame = game };
            var addon2 = new Addon { Title = "Hearts of Stone", ParentGame = game };

            // Act
            library.AddGame(game);
            library.AddAddon(addon1);
            library.AddAddon(addon2);

            // Assert
            Assert.AreEqual(3, library.PurchasedGames.Count);
            Assert.AreEqual(2, library.PurchasedGames.Count(i => i is Addon));
        }

        [TestMethod]
        public void FindGamesByGenre_ShouldIgnoreAddons()
        {
            // Arrange
            var library = CreateLibrary();
            var game = new Game { Title = "Skyrim", GameGenre = Genre.RPG };
            var addon = new Addon { Title = "DLC", ParentGame = game };

            library.AddGame(game);
            library.AddAddon(addon);

            // Act
            var result = library.FindGamesByGenre(Genre.RPG);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.IsInstanceOfType(result.First(), typeof(Game));
        }

        [TestMethod]
        public void SortItemsByTitle_ShouldSortGamesAndAddonsTogether()
        {
            // Arrange
            var library = CreateLibrary();
            library.AddGame(new Game { Title = "Zelda" });
            library.AddAddon(new Addon
            {
                Title = "Blood and Wine",
                ParentGame = new Game { Title = "Witcher 3" }
            });

            // Act
            library.SortItemsByTitle();

            // Assert
            Assert.AreEqual("Blood and Wine", library.PurchasedGames.First().Title);
        }

        [TestMethod]
        public void LaunchGame_GameNotInLibrary_ShouldNotThrow()
        {
            // Arrange
            var library = CreateLibrary();

            // Act
            library.LaunchGame("NonExistentGame");

            // Assert
            Assert.AreEqual(0, library.PurchasedGames.Count);
        }

        // ---------- Helper ----------
        private Library CreateLibrary()
        {
            return new Library(
                new Account("logic@test.com", "LogicUser", "1234")
            );
        }
    }
}
