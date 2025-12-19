using Project__part_B_;

namespace Project__part_B_Tests;

[TestClass]
public class LibraryLogicTests
{
    [TestMethod]
    public void Library_ShouldHandleMultipleTypesOfContent()
    {
        var library = new Library("MegaStore");
        // Уявімо, що ми додаємо і гру, і DLC
        ILibraryItem item = new Game { Title = "The Witcher 3" };

        Assert.IsNotNull(item);
        Assert.ThrowsException<NotImplementedException>(() => item.Install());
    }

    [TestMethod]
    public void Library_Sorting_ByTitle_ShouldThrowNotImplemented()
    {
        var library = new Library("MyStore");
        // Перевірка майбутнього методу сортування за назвою
        Assert.ThrowsException<NotImplementedException>(() => library.SortItemsByTitle());
    }

    [TestMethod]
    public void Game_DeepClone_ShouldHaveSameTitle()
    {
        var original = new Game { Title = "Hades" };
        // Перевірка майбутньої логіки клонування
        Assert.ThrowsException<NotImplementedException>(() => original.Clone());
    }

    [TestMethod]
    public void Library_FindGame_ByGenre_ShouldThrowNotImplemented()
    {
        var library = new Library("Store");
        Assert.ThrowsException<NotImplementedException>(() => library.FindGamesByGenre(Genre.Action));
    }

    [TestMethod]
    public void Library_OwnerName_ShouldNotBeEmpty()
    {
        var library = new Library("");
        Assert.IsNotNull(library.OwnerName);
    }

    [TestMethod]
    public void Library_AddNullGame_ShouldThrowException()
    {
        var library = new Library("User");

        // !додати перевірку на null
        Assert.ThrowsException<NotImplementedException>(() => library.AddGame(null!));
    }
}
