using Project__part_B_;
using System;
using System.Linq;

class Program
{
    static Library library = new Library("Default User");

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
            Console.WriteLine("-------------------------------------");

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
            Console.WriteLine("----------------------------------");

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
            Console.WriteLine("1. За назвою");
            Console.WriteLine("2. За ціною");
            Console.WriteLine("0. Назад");
            Console.WriteLine("----------------------------");

            int choice = ReadIntInRange("Оберіть дію", 0, 2);

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

                case 0:
                    back = true;
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
            Console.WriteLine("0. Назад");
            Console.WriteLine("------------------------");

            int choice = ReadIntInRange("Оберіть дію", 0, 2);

            switch (choice)
            {
                case 1:
                    ShowAccountInfo();
                    break;

                case 2:
                    ChangePassword();
                    break;

                case 0:
                    back = true;
                    break;
            }
        }
    }

    // ======================================================
    // ============ PLACEHOLDERS FOR LOGIC ==================
    // ======================================================

    static void AddGame() { ShowInfo("Додавання гри (реалізуємо далі)"); Pause(); }
    static void AddAddon() { ShowInfo("Додавання аддону (реалізуємо далі)"); Pause(); }
    static void InstallItem() { ShowInfo("Встановлення (реалізуємо далі)"); Pause(); }
    static void UninstallItem() { ShowInfo("Видалення (реалізуємо далі)"); Pause(); }
    static void LaunchGame() { ShowInfo("Запуск гри (реалізуємо далі)"); Pause(); }
    static void CloneItem() { ShowInfo("Клонування (реалізуємо далі)"); Pause(); }

    static void ShowAllItems() { ShowInfo("Перегляд усіх елементів"); Pause(); }
    static void ShowOnlyGames() { ShowInfo("Перегляд ігор"); Pause(); }
    static void ShowOnlyAddons() { ShowInfo("Перегляд аддонів"); Pause(); }
    static void FindGamesByGenre() { ShowInfo("Пошук за жанром"); Pause(); }

    static void ShowAccountInfo() { ShowInfo("Інформація про акаунт"); Pause(); }
    static void ChangePassword() { ShowInfo("Зміна пароля"); Pause(); }

    // ======================================================
    // ================= HELPER METHODS =====================
    // ======================================================

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
}
