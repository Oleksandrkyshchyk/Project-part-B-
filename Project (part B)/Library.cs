using System;
using System.Collections.Generic;
using System.Linq;

namespace Project__part_B_
{
    public class Library
    {
        // Поля / Властивості
        public string OwnerName { get; set; }
        public List<LibraryItem> PurchasedGames { get; set; } = new List<LibraryItem>();
        public Account UserAccount { get; private set; }

        // Конструктор
        public Library(string ownerName)
        {
            this.OwnerName = ownerName;
            this.PurchasedGames = new List<LibraryItem>();
            this.UserAccount = new Account();
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

        public List<LibraryItem> FindGamesByGenre(Genre genre)
        {
            // Динамічне визначення типу
            return PurchasedGames
                .Where(item => item is Game g && g.GameGenre == genre)
                .Cast<LibraryItem>()
                .ToList();
        }

        // Метод для сортування за назвою
        public void SortItemsByTitle()
        {
            PurchasedGames = PurchasedGames.OrderBy(item => item.Title).ToList();
        }

        // Метод для сортування за ціною
        public void SortItemsByPrice()
        {
            PurchasedGames.Sort();
        }
    }
}