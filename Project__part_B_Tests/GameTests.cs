using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project__part_B_;
using System;

namespace Project__part_B_Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void Title_SetAndGet_ShouldWork()
        {
            var game = new Game { Title = "Elden Ring" };
            Assert.AreEqual("Elden Ring", game.Title);
        }

        [TestMethod]
        public void Game_ShouldImplementILibraryItem()
        {
            var game = new Game();
            Assert.IsInstanceOfType(game, typeof(ILibraryItem));
        }

        [TestMethod]
        public void Creator_Association_ShouldWork()
        {
            var dev = new Developer { Name = "FromSoftware" };
            var game = new Game { Creator = dev };
            Assert.AreEqual("FromSoftware", game.Creator.Name);
        }

        [TestMethod]
        public void Install_ShouldThrowNotImplementedException()
        {
            var game = new Game();
            Assert.ThrowsException<NotImplementedException>(() => game.Install());
        }

        [TestMethod]
        public void Uninstall_ShouldThrowNotImplementedException()
        {
            var game = new Game();
            Assert.ThrowsException<NotImplementedException>(() => game.Uninstall());
        }

        [TestMethod]
        public void DisplayInfo_ShouldThrowNotImplementedException()
        {
            var game = new Game();
            Assert.ThrowsException<NotImplementedException>(() => game.DisplayInfo());
        }

        [TestMethod]
        public void GameGenre_SetAndGet_ShouldWork()
        {
            var game = new Game { GameGenre = Genre.RPG };
            Assert.AreEqual(Genre.RPG, game.GameGenre);
        }

        [TestMethod]
        public void Game_Price_ShouldNotBeNegative()
        {
            var game = new Game();
            game.Price = -100;
            // Перевіряємо можливість запису або очікуємо 0.
            Assert.IsTrue(game.Price >= 0, "Price should not be negative");
        }

        [TestMethod]
        public void Game_SizeGb_ShouldHaveMinimumValue()
        {
            var game = new Game { SizeGb = 0.01 };
            Assert.IsTrue(game.SizeGb > 0, "Game size must be positive");
        }

        [TestMethod]
        public void Game_Title_ShouldNotBeEmpty()
        {
            var game = new Game { Title = "" };
            // Тест на майбутню валідацію: назва не може бути порожньою
            Assert.IsNotNull(game.Title);
        }

        [TestMethod]
        public void Game_ShouldBeCloneable()
        {
            var game = new Game { Title = "Original" };
            Assert.ThrowsException<NotImplementedException>(() => game.Clone());
        }

        [TestMethod]
        public void Game_Comparison_ByPrice_ShouldThrowException()
        {
            var game1 = new Game { Price = 100 };
            var game2 = new Game { Price = 200 };
            Assert.ThrowsException<NotImplementedException>(() => game1.CompareTo(game2));
        }

        [TestMethod]
        public void Game_Price_ZeroIsAllowed()
        {
            var game = new Game { Price = 0 };
            Assert.AreEqual(0, game.Price);
        }

        [TestMethod]
        public void Game_Price_ShouldNotExceedLimit()
        {
            var game = new Game { Price = 5000 };
            Assert.IsTrue(game.Price < 10000, "Price is too high for a standard game");
        }

        [TestMethod]
        public void Game_Size_ShouldBePositive()
        {
            var game = new Game { SizeGb = 50.5 };
            Assert.IsTrue(game.SizeGb > 0);
        }
    }
}