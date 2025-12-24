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
            var account = new Account("test@mail.com", "Player", "1234");
            var library = new Library(account);

            var game = new Game
            {
                Title = "Witcher 3",
                GameGenre = Genre.RPG,
                Price = 30
            };

            // Act
            library.AddGame(game);

            // Assert
            Assert.AreEqual(1, library.PurchasedGames.Count);
        }


        [TestMethod]
        public void LibraryConstructor_ShouldInitializeAccount()
        {
            var account = new Account("user@mail.com", "Player1", "1234");

            var library = new Library(account);

            Assert.IsNotNull(library.UserAccount);
        }


        [TestMethod]
        public void GetTotalGamesCount_ShouldReturnCorrectNumber()
        {
            var account = new Account("vault@mail.com", "Vault", "1234");
            var library = new Library(account);

            int count = library.GetTotalGamesCount();

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void Library_InitialState_GamesList_IsNotNull()
        {
            var account = new Account("steam@mail.com", "Steam", "1234");
            var library = new Library(account);

            Assert.IsNotNull(library.PurchasedGames);
        }

        [TestMethod]
        public void Library_LaunchGame_NonExistent_DoesNotThrow()
        {
            var account = new Account("epic@mail.com", "Epic", "1234");
            var library = new Library(account);

            library.LaunchGame("UnknownGame");
        }

        [TestMethod]
        public void AddGame_ShouldAddGameToLibrary()
        {
            // Arrange
            var library = CreateLibrary();
            var game = new Game { Title = "Skyrim" };

            // Act
            library.AddGame(game);

            // Assert
            Assert.AreEqual(1, library.PurchasedGames.Count);
            Assert.IsInstanceOfType(library.PurchasedGames.First(), typeof(Game));
        }

        [TestMethod]
        public void AddAddon_ShouldAddAddonToLibrary()
        {
            // Arrange
            var library = CreateLibrary();
            var game = new Game { Title = "Witcher 3" };
            var addon = new Addon { Title = "Blood and Wine", ParentGame = game };

            // Act
            library.AddAddon(addon);

            // Assert
            Assert.AreEqual(1, library.PurchasedGames.Count);
            Assert.IsInstanceOfType(library.PurchasedGames.First(), typeof(Addon));
        }

        [TestMethod]
        public void AddNullGame_ShouldNotChangeLibrary()
        {
            // Arrange
            var library = CreateLibrary();
            int before = library.PurchasedGames.Count;

            // Act
            library.AddGame(null!);

            // Assert
            Assert.AreEqual(before, library.PurchasedGames.Count);
        }

        // ---------- INSTALL / LAUNCH ----------

        [TestMethod]
        public void LaunchGame_InstalledGame_ShouldNotThrow()
        {
            // Arrange
            var library = CreateLibrary();
            var game = new Game { Title = "Doom" };
            library.AddGame(game);
            game.Install();

            // Act
            library.LaunchGame("Doom");

            // Assert
            Assert.IsTrue(game.IsInstalled);
        }

        [TestMethod]
        public void LaunchGame_NotInstalledGame_ShouldNotThrow()
        {
            // Arrange
            var library = CreateLibrary();
            var game = new Game { Title = "Doom" };
            library.AddGame(game);

            // Act
            library.LaunchGame("Doom");

            // Assert
            Assert.IsFalse(game.IsInstalled);
        }

        [TestMethod]
        public void LaunchGame_AddonTitle_ShouldNotInstallAddon()
        {
            // Arrange
            var library = CreateLibrary();
            var game = new Game { Title = "Cyberpunk" };
            var addon = new Addon { Title = "Phantom Liberty", ParentGame = game };

            library.AddGame(game);
            library.AddAddon(addon);

            // Act
            library.LaunchGame("Phantom Liberty");

            // Assert
            Assert.IsFalse(addon.IsInstalled);
        }

        // ---------- SORTING ----------

        [TestMethod]
        public void SortItemsByTitle_ShouldSortAlphabetically()
        {
            // Arrange
            var library = CreateLibrary();
            library.AddGame(new Game { Title = "Zelda" });
            library.AddGame(new Game { Title = "Assassin" });
            library.AddGame(new Game { Title = "Dark Souls" });

            // Act
            library.SortItemsByTitle();

            // Assert
            Assert.AreEqual("Assassin", library.PurchasedGames.First().Title);
        }

        [TestMethod]
        public void SortItemsByPrice_ShouldSortAscending()
        {
            // Arrange
            var library = CreateLibrary();
            library.AddGame(new Game { Title = "A", Price = 60 });
            library.AddGame(new Game { Title = "B", Price = 20 });

            // Act
            library.SortItemsByPrice();

            // Assert
            Assert.AreEqual(20, library.PurchasedGames.First().Price);
        }

        [TestMethod]
        public void SortEmptyLibrary_ShouldNotThrow()
        {
            // Arrange
            var library = CreateLibrary();

            // Act
            library.SortItemsByTitle();
            library.SortItemsByPrice();

            // Assert
            Assert.AreEqual(0, library.PurchasedGames.Count);
        }

        // ---------- FIND / FILTER ----------

        [TestMethod]
        public void FindGamesByGenre_ShouldReturnMatchingGames()
        {
            // Arrange
            var library = CreateLibrary();
            library.AddGame(new Game { Title = "Skyrim", GameGenre = Genre.RPG });
            library.AddGame(new Game { Title = "Doom", GameGenre = Genre.Action });

            // Act
            var result = library.FindGamesByGenre(Genre.RPG);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Skyrim", result.First().Title);
        }

        [TestMethod]
        public void FindGamesByGenre_NoMatches_ShouldReturnEmptyList()
        {
            // Arrange
            var library = CreateLibrary();
            library.AddGame(new Game { Title = "Doom", GameGenre = Genre.Action });

            // Act
            var result = library.FindGamesByGenre(Genre.RPG);

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        // ---------- COUNTS / OWNER ----------

        [TestMethod]
        public void GetTotalGamesCount_ShouldReturnCorrectValue()
        {
            // Arrange
            var library = CreateLibrary();
            library.AddGame(new Game());
            library.AddGame(new Game());

            // Act
            int count = library.GetTotalGamesCount();

            // Assert
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void OwnerName_ShouldReturnUsernameIfExists()
        {
            // Arrange
            var account = new Account("mail@test.com", "Player", "1234");
            var library = new Library(account);

            // Act
            string owner = library.OwnerName;

            // Assert
            Assert.AreEqual("Player", owner);
        }

        [TestMethod]
        public void OwnerName_ShouldFallbackToEmailIfUsernameNull()
        {
            // Arrange
            var account = new Account("mail@test.com", null!, "1234");
            var library = new Library(account);

            // Act
            string owner = library.OwnerName;

            // Assert
            Assert.AreEqual("mail@test.com", owner);
        }

        // ---------- INTEGRATION ----------

        [TestMethod]
        public void Library_ShouldContainGameAndAddonTogether()
        {
            // Arrange
            var library = CreateLibrary();
            var game = new Game { Title = "Witcher 3" };
            var addon = new Addon { Title = "Blood and Wine", ParentGame = game };

            // Act
            library.AddGame(game);
            library.AddAddon(addon);

            // Assert
            Assert.AreEqual(2, library.PurchasedGames.Count);
            Assert.IsTrue(library.PurchasedGames.Any(i => i is Game));
            Assert.IsTrue(library.PurchasedGames.Any(i => i is Addon));
        }

        // ---------- HELPERS ----------

        private Library CreateLibrary()
        {
            return new Library(
                new Account("test@mail.com", "TestUser", "1234")
            );
        }
    }
}