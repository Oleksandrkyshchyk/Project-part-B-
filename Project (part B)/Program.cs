using Project__part_B_;
using System;
using System.Linq;

class Program
{
    static Library library = new Library(
    new Account("user@mail.com", "DefaultUser", "password")
);

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Title = "Game Library Management System";
        MainMenu();
    }

    // MAIN MENU 

    static void MainMenu()
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("   GAME LIBRARY MANAGEMENT SYSTEM");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Керування бібліотекою");
            Console.WriteLine("2. Перегляд і пошук");
            Console.WriteLine("3. Сортування");
            Console.WriteLine("4. Акаунт");
            Console.WriteLine("0. Вихід");
            Console.WriteLine("---------------------------------");

            int choice = ReadIntInRange("Оберіть дію", 0, 4);

            switch (choice)
            {
                case 1: LibraryMenu(); break;
                case 2: ViewMenu(); break;
                case 3: SortMenu(); break;
                case 4: AccountMenu(); break;
                case 0: Console.WriteLine("Завершення програми...");
                    exit = true; break;
            }
        }
    }

    // LIBRARY MENU   

    static void LibraryMenu()
    {
        bool back = false;

        while (!back)
        {
            Console.Clear();
            Console.WriteLine("-------- КЕРУВАННЯ БІБЛІОТЕКОЮ --------");
            Console.WriteLine("1. Додати гру");
            Console.WriteLine("2. Додати аддон");
            Console.WriteLine("3. Встановити елемент");
            Console.WriteLine("4. Видалити елемент");
            Console.WriteLine("5. Запустити гру");
            Console.WriteLine("6. Клонувати елемент");
            Console.WriteLine("0. Назад");
            Console.WriteLine("---------------------------------------");

            int choice = ReadIntInRange("Оберіть дію", 0, 6);

            switch (choice)
            {
                case 1: AddGame(); break;
                case 2: AddAddon(); break;
                case 3: InstallItem(); break;
                case 4: UninstallItem(); break;
                case 5: LaunchGame(); break;
                case 6: CloneItem(); break;
                case 0: back = true; break;
            }
        }
    }

    // VIEW MENU 

    static void ViewMenu()
    {
        bool back = false;

        while (!back)
        {
            Console.Clear();
            Console.WriteLine("-------- ПЕРЕГЛЯД ТА ПОШУК --------");
            Console.WriteLine("1. Показати всі елементи");
            Console.WriteLine("2. Показати тільки ігри");
            Console.WriteLine("3. Показати тільки аддони");
            Console.WriteLine("4. Знайти ігри за жанром");
            Console.WriteLine("0. Назад");
            Console.WriteLine("-----------------------------------");

            int choice = ReadIntInRange("Оберіть дію", 0, 4);

            switch (choice)
            {
                case 1: ShowAllItems(); break;
                case 2: ShowOnlyGames(); break;
                case 3: ShowOnlyAddons(); break;
                case 4: FindGamesByGenre(); break;
                case 0: back = true; break;
            }
        }
    }

    // SORT MENU 

    static void SortMenu()
    {
        bool back = false;

        while (!back)
        {
            Console.Clear();
            Console.WriteLine("-------- СОРТУВАННЯ --------");
            Console.WriteLine("1. За назвою (A–Z)");
            Console.WriteLine("2. За ціною (зростання)");
            Console.WriteLine("0. Назад");
            Console.WriteLine("----------------------------");

            int choice = ReadIntInRange("Оберіть дію", 0, 2);

            if (choice == 0)
            {
                back = true;
                continue;
            }

            if (!library.PurchasedGames.Any())
            {
                ShowInfo("Бібліотека порожня");
                Pause();
                continue;
            }

            switch (choice)
            {
                case 1:
                    library.SortItemsByTitle();
                    ShowSuccess("Бібліотеку відсортовано за назвою");
                    Pause();
                    break;

                case 2:
                    library.SortItemsByPrice();
                    ShowSuccess("Бібліотеку відсортовано за ціною");
                    Pause();
                    break;
            }
        }
    }


    // ACCOUNT MENU

    static void AccountMenu()
    {
        bool back = false;

        while (!back)
        {
            Console.Clear();
            Console.WriteLine("-------- АККАУНТ --------");
            Console.WriteLine("1. Показати інформацію");
            Console.WriteLine("2. Змінити пароль");
            Console.WriteLine("3. Змінити імʼя користувача");
            Console.WriteLine("0. Назад");
            Console.WriteLine("-------------------------");

            int choice = ReadIntInRange("Оберіть дію", 0, 3);

            switch (choice)
            {
                case 1:
                    ShowAccountInfo();
                    break;

                case 2:
                    ChangePassword();
                    break;
                case 3:
                    ChangeUsername();
                    break;

                case 0:
                    back = true;
                    break;
            }
        }
    }

    // PLACEHOLDERS FOR LOGIC 

    static void AddGame() {

        Console.Clear();

        Console.WriteLine("-------- ДОДАВАННЯ ГРИ --------");

        // 1. Назва гри
        string title = ReadNonEmptyString("Введіть назву гри");

        // Перевірка на дублікати
        if (library.PurchasedGames.Any(i =>
            i.Title.Equals(title, StringComparison.OrdinalIgnoreCase)))
        {
            ShowError("Гра з такою назвою вже існує в бібліотеці");
            Pause();
            return;
        }

        // 2. Ціна
        double price = ReadPositiveDouble("Введіть ціну гри");

        // 3. Розмір
        double size = ReadPositiveDouble("Введіть розмір гри (GB)");

        // 4. Жанр
        Genre genre = ReadGenre();

        // 5. Розробник
        string developerName = ReadNonEmptyString("Введіть назву студії-розробника");

        // 6. Рік заснування
        int currentYear = DateTime.Now.Year;
        int foundationYear = ReadIntInRange(
            "Введіть рік заснування студії",
            1950,
            currentYear
        );

        // 7. Створення об'єктів
        Developer developer = new Developer
        {
            Name = developerName,
            FoundationYear = foundationYear
        };

        Game game = new Game
        {
            Title = title,
            Price = price,
            SizeGb = size,
            GameGenre = genre,
            Creator = developer,
            IsInstalled = false
        };

        // 8. Додавання в бібліотеку
        library.AddGame(game);

        ShowSuccess($"Гру \"{title}\" успішно додано до бібліотеки");
        Pause();
    }
    static void AddAddon()
    {
        Console.Clear();
        Console.WriteLine("-------- ДОДАВАННЯ АДДОНУ --------");

        var games = library.PurchasedGames.OfType<Game>().ToList();

        if (!games.Any())
        {
            ShowError("У бібліотеці немає жодної гри. Спочатку додайте гру.");
            Pause();
            return;
        }

        Console.WriteLine("Оберіть гру, для якої додається аддон:");
        for (int i = 0; i < games.Count; i++)
            Console.WriteLine($"{i + 1}. {games[i].Title}");

        int gameChoice = ReadIntInRange("Ваш вибір", 1, games.Count);
        Game parentGame = games[gameChoice - 1];

        string addonTitle = ReadNonEmptyString("Введіть назву аддону");

        if (library.PurchasedGames.Any(i =>
            i.Title.Equals(addonTitle, StringComparison.OrdinalIgnoreCase)))
        {
            ShowError("Елемент з такою назвою вже існує в бібліотеці");
            Pause();
            return;
        }

        double price = ReadPositiveDouble("Введіть ціну аддону");
        double size = ReadPositiveDouble("Введіть розмір аддону (GB)");

        Addon addon = new Addon
        {
            Title = addonTitle,
            Price = price,
            SizeGb = size,
            ParentGame = parentGame,
            IsInstalled = false
        };

        library.AddAddon(addon);

        ShowSuccess(
            $"Аддон \"{addon.Title}\" успішно додано до гри \"{parentGame.Title}\""
        );
        Pause();
    }

    static void InstallItem()
    {
        Console.Clear();
        Console.WriteLine("-------- ВСТАНОВЛЕННЯ ЕЛЕМЕНТА --------");

        if (!library.PurchasedGames.Any())
        {
            ShowError("Бібліотека порожня");
            Pause();
            return;
        }

        for (int i = 0; i < library.PurchasedGames.Count; i++)
        {
            var item = library.PurchasedGames[i];
            string status = item.IsInstalled ? "Встановлено" : "Не встановлено";
            Console.WriteLine($"{i + 1}. {item.Title} [{status}]");
        }

        int choice = ReadIntInRange("Оберіть елемент", 1, library.PurchasedGames.Count);
        LibraryItem selectedItem = library.PurchasedGames[choice - 1];

        if (selectedItem.IsInstalled)
        {
            ShowInfo("Елемент вже встановлений");
            Pause();
            return;
        }

        if (selectedItem is Addon addon)
        {
            if (!addon.ParentGame.IsInstalled)
            {
                ShowError(
                    $"Неможливо встановити аддон, оскільки гра \"{addon.ParentGame.Title}\" не встановлена"
                );
                Pause();
                return;
            }
        }

        selectedItem.Install();
        ShowSuccess($"Елемент \"{selectedItem.Title}\" успішно встановлено");
        Pause();
    }

    static void UninstallItem()
    {
        Console.Clear();
        Console.WriteLine("-------- ВИДАЛЕННЯ ЕЛЕМЕНТА --------");

        if (!library.PurchasedGames.Any())
        {
            ShowError("Бібліотека порожня");
            Pause();
            return;
        }

        for (int i = 0; i < library.PurchasedGames.Count; i++)
        {
            var item = library.PurchasedGames[i];
            string status = item.IsInstalled ? "Встановлено" : "Не встановлено";
            Console.WriteLine($"{i + 1}. {item.Title} [{status}]");
        }

        int choice = ReadIntInRange("Оберіть елемент", 1, library.PurchasedGames.Count);
        LibraryItem selectedItem = library.PurchasedGames[choice - 1];

        if (!selectedItem.IsInstalled)
        {
            ShowInfo("Елемент не встановлений");
            Pause();
            return;
        }

        if (selectedItem is Game game)
        {
            var relatedAddons = library.PurchasedGames
                .OfType<Addon>()
                .Where(a => a.ParentGame == game && a.IsInstalled)
                .ToList();

            foreach (var addon in relatedAddons)
            {
                addon.Uninstall();
                ShowInfo($"Аддон \"{addon.Title}\" видалено разом з грою");
            }

            game.Uninstall();
            ShowSuccess($"Гру \"{game.Title}\" та всі її аддони видалено");
            Pause();
            return;
        }

        selectedItem.Uninstall();
        ShowSuccess($"Аддон \"{selectedItem.Title}\" видалено");
        Pause();
    }

    static void LaunchGame()
    {
        Console.Clear();
        Console.WriteLine("-------- ЗАПУСК ГРИ --------");

        var games = library.PurchasedGames.OfType<Game>().ToList();

        if (!games.Any())
        {
            ShowError("У бібліотеці немає жодної гри");
            Pause();
            return;
        }

        for (int i = 0; i < games.Count; i++)
        {
            string status = games[i].IsInstalled ? "Встановлено" : "Не встановлено";
            Console.WriteLine($"{i + 1}. {games[i].Title} [{status}]");
        }

        int choice = ReadIntInRange("Оберіть гру", 1, games.Count);
        Game selectedGame = games[choice - 1];

        if (!selectedGame.IsInstalled)
        {
            ShowError("Гра не встановлена. Спочатку встановіть її.");
            Pause();
            return;
        }

        Console.Clear();
        ShowSuccess($"Запуск гри \"{selectedGame.Title}\"...");
        Console.WriteLine("🎮 Гра запущена. Гарної гри!");
        Pause();
    }

    static void CloneItem()
    {
        Console.Clear();
        Console.WriteLine("-------- КЛОНУВАННЯ ЕЛЕМЕНТА --------");

        if (!library.PurchasedGames.Any())
        {
            ShowError("Бібліотека порожня");
            Pause();
            return;
        }

        for (int i = 0; i < library.PurchasedGames.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {library.PurchasedGames[i].Title}");
        }

        int choice = ReadIntInRange("Оберіть елемент", 1, library.PurchasedGames.Count);
        LibraryItem original = library.PurchasedGames[choice - 1];

        LibraryItem clone = (LibraryItem)original.Clone();

        Console.Write("Введіть уточнення для назви (наприклад: Deluxe Edition), або Enter щоб пропустити: ");
        string? userTitle = Console.ReadLine();

        string baseTitle = clone.Title;
        string newTitle = string.IsNullOrWhiteSpace(userTitle)
            ? $"{baseTitle} (Copy)"
            : $"{baseTitle} – {userTitle.Trim()}";

        int counter = 1;
        string uniqueTitle = newTitle;

        while (library.PurchasedGames.Any(i =>
            i.Title.Equals(uniqueTitle, StringComparison.OrdinalIgnoreCase)))
        {
            uniqueTitle = $"{newTitle} ({counter++})";
        }

        clone.Title = uniqueTitle;
        clone.IsInstalled = false;

        library.PurchasedGames.Add(clone);

        ShowSuccess($"Елемент \"{clone.Title}\" успішно клоновано");
        Pause();
    }





    static void ShowAllItems()
    {
        Console.Clear();
        Console.WriteLine("-------- УСІ ЕЛЕМЕНТИ --------");

        if (!library.PurchasedGames.Any())
        {
            ShowInfo("Бібліотека порожня");
            Pause();
            return;
        }

        foreach (var item in library.PurchasedGames)
        {
            item.DisplayInfo();
        }

        Pause();
    }

    static void ShowOnlyGames()
    {
        Console.Clear();
        Console.WriteLine("-------- УСІ ІГРИ --------");

        var games = library.PurchasedGames.OfType<Game>().ToList();

        if (!games.Any())
        {
            ShowInfo("У бібліотеці немає ігор");
            Pause();
            return;
        }

        foreach (var game in games)
        {
            game.DisplayInfo();
        }

        Pause();
    }

    static void ShowOnlyAddons()
    {
        Console.Clear();
        Console.WriteLine("-------- УСІ АДДОНИ --------");

        var addons = library.PurchasedGames.OfType<Addon>().ToList();

        if (!addons.Any())
        {
            ShowInfo("У бібліотеці немає аддонів");
            Pause();
            return;
        }

        foreach (var addon in addons)
        {
            addon.DisplayInfo();
        }

        Pause();
    }

    static void FindGamesByGenre()
    {
        Console.Clear();
        Console.WriteLine("-------- ПОШУК ІГОР ЗА ЖАНРОМ --------");

        // Отримуємо всі доступні жанри
        var genres = Enum.GetValues(typeof(Genre)).Cast<Genre>().ToList();

        // Виводимо жанри
        for (int i = 0; i < genres.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {genres[i]}");
        }

        // Вибір жанру
        int choice = ReadIntInRange("Оберіть жанр", 1, genres.Count);
        Genre selectedGenre = genres[choice - 1];

        Console.Clear();
        Console.WriteLine($"-------- ІГРИ ЖАНРУ: {selectedGenre} --------");

        // Пошук ігор за жанром
        var games = library.PurchasedGames
            .OfType<Game>()
            .Where(g => g.GameGenre == selectedGenre)
            .ToList();

        if (!games.Any())
        {
            ShowInfo("Ігор з таким жанром не знайдено");
            Pause();
            return;
        }

        // Вивід результатів
        foreach (var game in games)
        {
            game.DisplayInfo();
        }

        Pause();
    }




    static void ShowAccountInfo()
    {
        Console.Clear();
        Console.WriteLine("-------- ІНФОРМАЦІЯ ПРО АКАУНТ --------");

        Console.WriteLine($"Email: {library.UserAccount.Email}");
        Console.WriteLine($"Імʼя користувача: {library.UserAccount.Username}");
        Console.WriteLine($"Дата створення: {library.UserAccount.CreatedAt}");

        Pause();
    }
    static void ChangePassword()
    {
        Console.Clear();
        Console.WriteLine("-------- ЗМІНА ПАРОЛЯ --------");

        Console.Write("Введіть поточний пароль: ");
        string oldPassword = Console.ReadLine() ?? "";

        Console.Write("Введіть новий пароль: ");
        string newPassword = Console.ReadLine() ?? "";

        try
        {
            library.UserAccount.ChangePassword(oldPassword, newPassword);
            ShowSuccess("Пароль успішно змінено");
        }
        catch (ArgumentException ex)
        {
            ShowError(ex.Message);
        }

        Pause();
    }



    // HELPER METHODS

    static void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"❌ Помилка: {message}");
        Console.ResetColor();
    }

    static void ShowSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"✅ {message}");
        Console.ResetColor();
    }

    static void ShowInfo(string message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"ℹ️ {message}");
        Console.ResetColor();
    }

    static void Pause()
    {
        Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
        Console.ReadKey();
    }

    static int ReadIntInRange(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write($"{prompt} ({min}-{max}): ");
            if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
                return value;

            ShowError("Некоректний вибір");
        }
    }

    static string ReadNonEmptyString(string prompt)
    {
        while (true)
        {
            Console.Write($"{prompt}: ");
            string? input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                return input.Trim();

            ShowError("Значення не може бути порожнім");
        }
    }

    static double ReadPositiveDouble(string prompt)
    {
        while (true)
        {
            Console.Write($"{prompt}: ");
            string? input = Console.ReadLine();

            if (double.TryParse(input, out double value) && value >= 0)
                return value;

            ShowError("Введіть коректне додатне число");
        }
    }

    static Genre ReadGenre()
    {
        Console.WriteLine("Оберіть жанр:");

        var genres = Enum.GetValues(typeof(Genre));
        for (int i = 0; i < genres.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {genres.GetValue(i)}");
        }

        int choice = ReadIntInRange("Ваш вибір", 1, genres.Length);
        return (Genre)genres.GetValue(choice - 1)!;
    }

    static void ChangeUsername()
    {
        Console.Clear();
        Console.WriteLine("=== ЗМІНА ІМЕНІ КОРИСТУВАЧА ===");

        string newUsername = ReadNonEmptyString("Введіть нове імʼя користувача");

        try
        {
            library.UserAccount.ChangeUsername(newUsername);
            ShowSuccess("Імʼя користувача успішно змінено");
        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
        }

        Pause();
    }
}

