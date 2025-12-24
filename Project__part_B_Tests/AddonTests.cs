using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project__part_B_;

namespace Project__part_B_Tests
{
    [TestClass]
    public class AddonTests
    {
        [TestMethod]
        public void Addon_ShouldInheritFromLibraryItem()
        {
            // Arrange
            var addon = new Addon();

            // Act
            bool result = addon is LibraryItem;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Addon_ShouldImplementILibraryItem()
        {
            // Arrange
            var addon = new Addon();

            // Act
            bool result = addon is ILibraryItem;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ParentGame_Assigned_ShouldBeAccessible()
        {
            // Arrange
            var game = new Game { Title = "The Witcher 3" };
            var addon = new Addon();

            // Act
            addon.ParentGame = game;

            // Assert
            Assert.AreEqual(game, addon.ParentGame);
            Assert.AreEqual("The Witcher 3", addon.ParentGame.Title);
        }

        [TestMethod]
        public void Install_ShouldSetIsInstalledToTrue()
        {
            // Arrange
            var game = new Game { Title = "Cyberpunk 2077" };
            var addon = new Addon
            {
                Title = "Phantom Liberty",
                ParentGame = game
            };

            // Act
            addon.Install();

            // Assert
            Assert.IsTrue(addon.IsInstalled);
        }

        [TestMethod]
        public void Uninstall_ShouldSetIsInstalledToFalse()
        {
            // Arrange
            var game = new Game { Title = "Cyberpunk 2077" };
            var addon = new Addon
            {
                Title = "Phantom Liberty",
                ParentGame = game
            };
            addon.Install();

            // Act
            addon.Uninstall();

            // Assert
            Assert.IsFalse(addon.IsInstalled);
        }

        [TestMethod]
        public void Clone_ShouldCreateNewAddonWithSameData()
        {
            // Arrange
            var game = new Game { Title = "The Witcher 3" };
            var addon = new Addon
            {
                Title = "Blood and Wine",
                Price = 15,
                SizeGb = 10,
                ParentGame = game
            };

            // Act
            var clone = (Addon)addon.Clone();

            // Assert
            Assert.AreNotSame(addon, clone);
            Assert.AreEqual(addon.Title, clone.Title);
            Assert.AreEqual(addon.Price, clone.Price);
            Assert.AreEqual(addon.SizeGb, clone.SizeGb);
            Assert.AreEqual(addon.ParentGame, clone.ParentGame);
            Assert.IsFalse(clone.IsInstalled);
        }

        [TestMethod]
        public void CompareTo_AddonWithHigherPrice_ShouldReturnNegative()
        {
            // Arrange
            var cheapAddon = new Addon { Price = 5 };
            var expensiveAddon = new Addon { Price = 20 };

            // Act
            int result = cheapAddon.CompareTo(expensiveAddon);

            // Assert
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void Addon_ShouldBeUsableViaLibraryItemReference()
        {
            // Arrange
            var game = new Game { Title = "Elden Ring" };
            LibraryItem item = new Addon
            {
                Title = "Shadow of the Erdtree",
                ParentGame = game
            };

            // Act
            item.Install();

            // Assert
            Assert.IsTrue(item.IsInstalled);
        }

        [TestMethod]
        public void Install_CalledTwice_ShouldRemainInstalled()
        {
            // Arrange
            var game = new Game { Title = "Elden Ring" };
            var addon = new Addon
            {
                Title = "Shadow of the Erdtree",
                ParentGame = game
            };

            // Act
            addon.Install();
            addon.Install();

            // Assert
            Assert.IsTrue(addon.IsInstalled);
        }

        [TestMethod]
        public void Uninstall_WithoutInstall_ShouldRemainNotInstalled()
        {
            // Arrange
            var game = new Game { Title = "Elden Ring" };
            var addon = new Addon
            {
                Title = "Shadow of the Erdtree",
                ParentGame = game
            };

            // Act
            addon.Uninstall();

            // Assert
            Assert.IsFalse(addon.IsInstalled);
        }

        [TestMethod]
        public void Clone_FromInstalledAddon_ShouldNotBeInstalled()
        {
            // Arrange
            var game = new Game { Title = "The Witcher 3" };
            var addon = new Addon
            {
                Title = "Blood and Wine",
                ParentGame = game
            };
            addon.Install();

            // Act
            var clone = (Addon)addon.Clone();

            // Assert
            Assert.IsFalse(clone.IsInstalled);
        }

        [TestMethod]
        public void Clone_ShouldKeepSameParentGameReference()
        {
            // Arrange
            var game = new Game { Title = "Cyberpunk 2077" };
            var addon = new Addon
            {
                Title = "Phantom Liberty",
                ParentGame = game
            };

            // Act
            var clone = (Addon)addon.Clone();

            // Assert
            Assert.AreEqual(game, clone.ParentGame);
        }

        [TestMethod]
        public void CompareTo_SamePrice_ShouldReturnZero()
        {
            // Arrange
            var game = new Game { Title = "Skyrim" };
            var addon1 = new Addon { Price = 20, ParentGame = game };
            var addon2 = new Addon { Price = 20, ParentGame = game };

            // Act
            int result = addon1.CompareTo(addon2);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Install_WithoutParentGame_ShouldThrowException()
        {
            // Arrange
            var addon = new Addon { Title = "Broken Addon" };

            // Act & Assert
            Assert.ThrowsException<System.NullReferenceException>(() =>
                addon.Install());
        }
    }
}
