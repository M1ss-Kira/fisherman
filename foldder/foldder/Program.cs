using System;
using System.IO;
using System.Linq;

class FileExplorer
{
    private static string _currentDirectory;

    static void Main(string[] args)
    {
        _currentDirectory = Directory.GetCurrentDirectory();
        ShowMainMenu();
    }

    static void ShowMainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== КОНСОЛЬНЫЙ ПРОВОДНИК ===");
            Console.WriteLine("1. Работа с файловой системой");
            Console.WriteLine("2. Управление дисками");
            Console.WriteLine("3. Выход");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ShowFileSystemMenu();
                    break;
                case "2":
                    ShowDrivesMenu();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    ShowError("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    static void ShowFileSystemMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Текущая директория: {_currentDirectory}");
            Console.WriteLine("====================================");
            Console.WriteLine("1. Просмотр содержимого");
            Console.WriteLine("2. Перейти в подкаталог");
            Console.WriteLine("3. Вернуться в родительский каталог");
            Console.WriteLine("4. Открыть файл");
            Console.WriteLine("5. Создать каталог");
            Console.WriteLine("6. Создать файл");
            Console.WriteLine("7. Удалить файл/каталог");
            Console.WriteLine("8. Назад в главное меню");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ShowDirectoryContents();
                    break;
                case "2":
                    EnterSubdirectory();
                    break;
                case "3":
                    GoToParentDirectory();
                    break;
                case "4":
                    OpenFile();
                    break;
                case "5":
                    CreateDirectory();
                    break;
                case "6":
                    CreateFile();
                    break;
                case "7":
                    DeleteItem();
                    break;
                case "8":
                    return;
                default:
                    ShowError("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    static void ShowDrivesMenu()
    {
        Console.Clear();
        Console.WriteLine("=== ДОСТУПНЫЕ ДИСКИ ===");
        DriveInfo[] drives = DriveInfo.GetDrives();

        for (int i = 0; i < drives.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {drives[i].Name} ({drives[i].DriveType})");
        }

        Console.WriteLine($"{drives.Length + 1}. Назад в главное меню");
        Console.Write("Выберите диск: ");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            if (choice >= 1 && choice <= drives.Length)
            {
                _currentDirectory = drives[choice - 1].RootDirectory.FullName;
                ShowDriveOperationsMenu(drives[choice - 1]);
            }
            else if (choice == drives.Length + 1)
            {
                return;
            }
            else
            {
                ShowError("Неверный выбор.");
            }
        }
        else
        {
            ShowError("Неверный ввод.");
        }
    }

    static void ShowDriveOperationsMenu(DriveInfo drive)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Диск: {drive.Name}");
            Console.WriteLine($"Тип: {drive.DriveType}"); Console.WriteLine($"Файловая система: {drive.DriveFormat}");
            Console.WriteLine($"Общий размер: {drive.TotalSize / (1024 * 1024 * 1024)} GB");
            Console.WriteLine($"Свободно: {drive.TotalFreeSpace / (1024 * 1024 * 1024)} GB");
            Console.WriteLine("====================================");
            Console.WriteLine("1. Просмотр содержимого");
            Console.WriteLine("2. Создать каталог");
            Console.WriteLine("3. Создать файл");
            Console.WriteLine("4. Удалить файл/каталог");
            Console.WriteLine("5. Назад к списку дисков");
            Console.WriteLine("6. Назад в главное меню");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ShowDirectoryContents();
                    break;
                case "2":
                    CreateDirectory();
                    break;
                case "3":
                    CreateFile();
                    break;
                case "4":
                    DeleteItem();
                    break;
                case "5":
                    ShowDrivesMenu();
                    return;
                case "6":
                    return;
                default:
                    ShowError("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    static void ShowDirectoryContents()
    {
        Console.Clear();
        Console.WriteLine($"Содержимое: {_currentDirectory}");
        Console.WriteLine("====================================");

        try
        {
            var directories = Directory.GetDirectories(_currentDirectory);
            Console.WriteLine("\n[КАТАЛОГИ]");
            foreach (var dir in directories)
            {
                var info = new DirectoryInfo(dir);
                Console.WriteLine($"  {info.Name,-40} {info.CreationTime}");
            }

            var files = Directory.GetFiles(_currentDirectory);
            Console.WriteLine("\n[ФАЙЛЫ]");
            foreach (var file in files)
            {
                var info = new FileInfo(file);
                Console.WriteLine($"  {info.Name,-40} {info.Length / 1024} KB");
            }
        }
        catch (UnauthorizedAccessException)
        {
            ShowError("Нет доступа к этой директории.");
        }
        catch (DirectoryNotFoundException)
        {
            ShowError("Директория не найдена.");
        }

        WaitForUserInput();
    }

    static void EnterSubdirectory()
    {
        Console.Write("Введите имя подкаталога: ");
        string subdirectory = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(subdirectory))
        {
            ShowError("Имя каталога не может быть пустым.");
            return;
        }

        string newPath = Path.Combine(_currentDirectory, subdirectory);
        if (Directory.Exists(newPath))
        {
            _currentDirectory = newPath;
        }
        else
        {
            ShowError($"Каталог '{subdirectory}' не существует.");
        }
    }

    static void GoToParentDirectory()
    {
        var parent = Directory.GetParent(_currentDirectory);
        if (parent != null)
        {
            _currentDirectory = parent.FullName;
        }
        else
        {
            ShowError("Вы уже в корневой директории.");
        }
    }

    static void OpenFile()
    {
        Console.Write("Введите имя файла: ");
        string fileName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(fileName))
        {
            ShowError("Имя файла не может быть пустым.");
            return;
        }

        string filePath = Path.Combine(_currentDirectory, fileName);
        if (File.Exists(filePath))
        {
            try
            {
                Console.Clear();
                Console.WriteLine($"Содержимое файла: {filePath}");
                Console.WriteLine("===================================="); string content = File.ReadAllText(filePath);
                Console.WriteLine(content);
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка при чтении файла: {ex.Message}");
            }
        }
        else
        {
            ShowError($"Файл '{fileName}' не существует.");
        }

        WaitForUserInput();
    }

    static void CreateDirectory()
    {
        Console.Write("Введите имя каталога: ");
        string dirName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(dirName))
        {
            ShowError("Имя каталога не может быть пустым.");
            return;
        }

        string newDirPath = Path.Combine(_currentDirectory, dirName);
        try
        {
            Directory.CreateDirectory(newDirPath);
            Console.WriteLine($"Каталог '{dirName}' создан.");
        }
        catch (Exception ex)
        {
            ShowError($"Ошибка: {ex.Message}");
        }

        WaitForUserInput();
    }

    static void CreateFile()
    {
        Console.Write("Введите имя файла: ");
        string fileName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(fileName))
        {
            ShowError("Имя файла не может быть пустым.");
            return;
        }

        string filePath = Path.Combine(_currentDirectory, fileName);
        if (File.Exists(filePath))
        {
            ShowError("Файл уже существует.");
            return;
        }

        Console.WriteLine("Введите содержимое (пустая строка - завершить):");
        var contentLines = new System.Collections.Generic.List<string>();
        while (true)
        {
            string line = Console.ReadLine();
            if (string.IsNullOrEmpty(line))
                break;
            contentLines.Add(line);
        }

        try
        {
            File.WriteAllLines(filePath, contentLines);
            Console.WriteLine($"Файл '{fileName}' создан.");
        }
        catch (Exception ex)
        {
            ShowError($"Ошибка: {ex.Message}");
        }

        WaitForUserInput();
    }

    static void DeleteItem()
    {
        Console.Write("Введите имя файла/каталога: ");
        string itemName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(itemName))
        {
            ShowError("Имя не может быть пустым.");
            return;
        }

        string itemPath = Path.Combine(_currentDirectory, itemName);
        if (File.Exists(itemPath))
        {
            Console.Write($"Удалить файл '{itemName}'? (y/n): ");
            if (Console.ReadLine()?.ToLower() == "y")
            {
                try
                {
                    File.Delete(itemPath);
                    Console.WriteLine("Файл удален.");
                }
                catch (Exception ex)
                {
                    ShowError($"Ошибка: {ex.Message}");
                }
            }
        }
        else if (Directory.Exists(itemPath))
        {
            Console.Write($"Удалить каталог '{itemName}'? (y/n): ");
            if (Console.ReadLine()?.ToLower() == "y")
            {
                try
                {
                    Directory.Delete(itemPath, true);
                    Console.WriteLine("Каталог удален.");
                }
                catch (Exception ex)
                {
                    ShowError($"Ошибка: {ex.Message}");
                }
            }
        }
        else
        {
            ShowError("Объект не найден.");
        }

        WaitForUserInput();
    }

    private static void ShowError(string message)
    {
        Console.WriteLine($"Ошибка: {message}");
        WaitForUserInput();
    }

    private static void WaitForUserInput()
    {
        Console.WriteLine("\nНажмите любую клавишу...");
        Console.ReadKey();
    }
}