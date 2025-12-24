using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project__part_B_;

namespace Project__part_B_Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void Title_SetInGame_ShouldBeStored()
        {
            // Arrange
            var game = new Game();
            string title = "Elden Ring";

            // Act
            game.Title = title;

            // Assert
            Assert.AreEqual(title, game.Title);
        }

        [TestMethod]
        public void Game_ShouldImplementILibraryItem()
        {
            // Arrange
            var game = new Game();

            // Act
            var result = game is ILibraryItem;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Creator_AssignedToGame_ShouldBeAccessible()
        {
            // Arrange
            var developer = new Developer { Name = "FromSoftware" };
            var game = new Game();

            // Act
            game.Creator = developer;

            // Assert
            Assert.AreEqual("FromSoftware", game.Creator.Name);
        }

        [TestMethod]
        public void Install_ShouldSetIsInstalledToTrue()
        {
            // Arrange
            var game = new Game { Title = "Dark Souls" };

            // Act
            game.Install();

            // Assert
            Assert.IsTrue(game.IsInstalled);
        }

        [TestMethod]
        public void Uninstall_ShouldSetIsInstalledToFalse()
        {
            // Arrange
            var game = new Game { Title = "Dark Souls" };
            game.Install();

            // Act
            game.Uninstall();

            // Assert
            Assert.IsFalse(game.IsInstalled);
        }

        [TestMethod]
        public void Clone_ShouldCreateNewGameWithSameData()
        {
            // Arrange
            var game = new Game
            {
                Title = "Original",
                Price = 60,
                SizeGb = 40,
                GameGenre = Genre.RPG
            };

            // Act
            var clone = (Game)game.Clone();

            // Assert
            Assert.AreNotSame(game, clone);
            Assert.AreEqual(game.Title, clone.Title);
            Assert.AreEqual(game.Price, clone.Price);
            Assert.AreEqual(game.GameGenre, clone.GameGenre);
            Assert.IsFalse(clone.IsInstalled);
        }

        [TestMethod]
        public void CompareTo_GameWithHigherPrice_ShouldReturnNegative()
        {
            // Arrange
            var cheapGame = new Game { Price = 20 };
            var expensiveGame = new Game { Price = 60 };

            // Act
            int result = cheapGame.CompareTo(expensiveGame);

            // Assert
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void GameGenre_Set_ShouldBeStored()
        {
            // Arrange
            var game = new Game();
            var genre = Genre.Action;

            // Act
            game.GameGenre = genre;

            // Assert
            Assert.AreEqual(genre, game.GameGenre);
        }

        [TestMethod]
        public void Install_CalledTwice_ShouldRemainInstalled()
        {
            // Arrange
            var game = new Game { Title = "Skyrim" };

            // Act
            game.Install();
            game.Install();

            // Assert
            Assert.IsTrue(game.IsInstalled);
        }

        [TestMethod]
        public void Uninstall_WithoutInstall_ShouldRemainNotInstalled()
        {
            // Arrange
            var game = new Game { Title = "Skyrim" };

            // Act
            game.Uninstall();

            // Assert
            Assert.IsFalse(game.IsInstalled);
        }

        [TestMethod]
        public void Clone_FromInstalledGame_ShouldNotBeInstalled()
        {
            // Arrange
            var game = new Game { Title = "Skyrim" };
            game.Install();

            // Act
            var clone = (Game)game.Clone();

            // Assert
            Assert.IsFalse(clone.IsInstalled);
        }

        [TestMethod]
        public void Clone_ShouldCopyCreatorReference()
        {
            // Arrange
            var developer = new Developer { Name = "Bethesda" };
            var game = new Game
            {
                Title = "Skyrim",
                Creator = developer
            };

            // Act
            var clone = (Game)game.Clone();

            // Assert
            Assert.AreEqual(developer, clone.Creator);
        }

        [TestMethod]
        public void CompareTo_SamePrice_ShouldReturnZero()
        {
            // Arrange
            var game1 = new Game { Price = 50 };
            var game2 = new Game { Price = 50 };

            // Act
            int result = game1.CompareTo(game2);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CompareTo_Null_ShouldReturnPositive()
        {
            // Arrange
            var game = new Game { Price = 50 };

            // Act
            int result = game.CompareTo(null);

            // Assert
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void GameGenre_ShouldRemainAfterInstallAndUninstall()
        {
            // Arrange
            var game = new Game
            {
                Title = "Doom",
                GameGenre = Genre.Action
            };

            // Act
            game.Install();
            game.Uninstall();

            // Assert
            Assert.AreEqual(Genre.Action, game.GameGenre);
        }
    }
}
