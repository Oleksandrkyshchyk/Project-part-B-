using System;
using System.Collections.Generic;
using System.Linq;

namespace Project__part_B_
{
    public class Library
    {
        // Поля / Властивості
        public string OwnerName => UserAccount.Username ?? UserAccount.Email;
        public List<LibraryItem> PurchasedGames { get; set; } = new List<LibraryItem>();
        public Account UserAccount { get; private set; }


        // Конструктор

        public Library(Account account)
        {
            UserAccount = account ?? throw new ArgumentNullException(nameof(account));
            PurchasedGames = new List<LibraryItem>();
        }


        // Методи

        // Додавання елемента (Поліморфізм: приймає і Game, і Addon)
        public void AddGame(LibraryItem item)
        {
            if (item != null)
            {
                PurchasedGames.Add(item);
            }
        }

        public void LaunchGame(string title)
        {
            // Пошук елемента за назвою
            var item = PurchasedGames.FirstOrDefault(i => i.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (item is Game game)
            {
                Console.WriteLine($"Запуск гри: {game.Title}...");
            }
            else if (item is Addon)
            {
                Console.WriteLine("Це аддон. Запустіть основну гру.");
            }
            else
            {
                Console.WriteLine("Гру не знайдено.");
            }
        }

        public int GetTotalGamesCount()
        {
            // Повертає кількість усіх елементів у списку
            return PurchasedGames.Count;
        }

        public List<Game> FindGamesByGenre(Genre genre)
        {
            return PurchasedGames
                .OfType<Game>()
                .Where(g => g.GameGenre == genre)
                .ToList();
        }

        // Метод для сортування за назвою
        public void SortItemsByTitle()
        {
            PurchasedGames.Sort((a, b) =>
                string.Compare(a.Title, b.Title, StringComparison.OrdinalIgnoreCase));
        }

        // Метод для сортування за ціною
        public void SortItemsByPrice()
        {
            PurchasedGames.Sort();
        }

        public void AddAddon(Addon addon)
        {
            PurchasedGames.Add(addon);
        }

    }
}