// See https://aka.ms/new-console-template for more information

using System;
using System.IO;
using System.Reflection;
namespace DriveManager
{
    class Program
    {
        static void Main(string[] args)
        {
            DelCatalogs();

        }
        static void Getdriveinfo()
        {
            // получим системные диски
            DriveInfo[] drives = DriveInfo.GetDrives();

            // Пробежимся по дискам и выведем их свойства
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Объем: {drive.TotalSize}");
                    Console.WriteLine($"Свободно: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Метка: {drive.VolumeLabel}");
                }
            }
        }
        static void MoveDir()
        {
            string dirName = @"C:\Users\electronic\Downloads\NewFolder";
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dirName);
            string newPath = @"C:\Users\electronic\Downloads\TelegramDesktop";

            if (dirInfo.Exists && !Directory.Exists(newPath))
                dirInfo.MoveTo(newPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void CreateDir()
        {
            string dirName = @"C:\Users\electronic\Downloads";
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dirName);
                if (dirInfo.Exists)
                {
                    Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
                }
                if (!dirInfo.Exists)
                    dirInfo.Create();

                dirInfo.CreateSubdirectory("NewFolder");
                if (dirInfo.Exists)
                {
                    Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }
        static void DelCatalogs()//Удаление каталога и  файлов
        {
            string dirName = @"C:\Users\electronic\Тest delite";// Прописываем путь к корневой директории MacOS (для Windows скорее всего тут будет "C:\\")
            if (Directory.Exists(dirName)) // Проверим, что директория существует
            {
                
                string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории корневого каталога
                
                foreach (string d in dirs) // Выведем их все

                {
                    try
                    {
                        DirectoryInfo dirInfo = new DirectoryInfo(d);
                        dirInfo.Delete(true); // Удаление со всем содержимым
                        Console.WriteLine("Каталоги удалены");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                   
                    
                }
                
               string[] files = Directory.GetFiles(dirName);// Получим все файлы корневого каталога

                foreach (string s in files)
                {
                    try
                    {
                        FileInfo fileInfo = new FileInfo(s);
                        fileInfo.Delete(); // Удаление со всем содержимым
                        Console.WriteLine("файлы удалены");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }// Выведем их все
               
            }
        }
        static void DelCat()
        {
            string foldername = "NewFolder";
            string dirName = @"C:\Users\electronic\Downloads\";
           
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dirName+foldername);
                dirInfo.Delete(true); // Удаление со всем содержимым
                Console.WriteLine("Каталог удален");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
            static void GetCatalogs()//получение каталога и колличества файлов
        {
            string dirName = @"C:\Users\electronic\Downloads";
            int dircount=0,filecount=0;// Прописываем путь к корневой директории MacOS (для Windows скорее всего тут будет "C:\\")
            if (Directory.Exists(dirName)) // Проверим, что директория существует
            {
                Console.WriteLine("Папки:");
                string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории корневого каталога
                try
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(dirName);
                    if (dirInfo.Exists)
                    {
                        Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                foreach (string d in dirs) // Выведем их все

                {

                    Console.WriteLine(d);
                    dircount++;
                }
                Console.WriteLine("кол-во папок {0}",dircount);

                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);// Получим все файлы корневого каталога

                foreach (string s in files)
                {
                    Console.WriteLine(s);
                    filecount++;
                }// Выведем их все
                Console.WriteLine(filecount);
            }
        }
        static void BinReader () // чтение бинарных данных из файла
        {
            // сохраняем путь к файлу (допустим, вы его скачали на рабочий стол)
            string filePath = @"C:\Users\electronic\Downloads\BinaryFile.bin";

            // при запуске проверим, что файл существует
            if (File.Exists(filePath))
            {
                // строковая переменная, в которую будем считывать данные
                string stringValue;

                // считываем, после использования высвобождаем задействованный ресурс BinaryReader
                using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    stringValue = reader.ReadString();
                }

                // Вывод
                Console.WriteLine("Из файла считано:");
                Console.WriteLine(stringValue);
            }
        }
    }
     public class FileWriter // создание и обновление  файла при запуске программы
    {
        public static void write()
        {
            string tempFile = Path.GetTempFileName(); // используем генерацию имени файла.
            var fileInfo = new FileInfo(tempFile); // Создаем объект класса FileInfo.

            //Создаем файл и записываем в него.
            using (StreamWriter sw = fileInfo.CreateText())
            {
                sw.WriteLine("Игорь");
                sw.WriteLine("Андрей");
                sw.WriteLine("Сергей");
                sw.WriteLine(DateTime.Now);
            }

            //Открываем файл и читаем из него.
            using (StreamReader sr = fileInfo.OpenText())
            {
                string str = "";
                while ((str = sr.ReadLine()) != null)
                {
                    Console.WriteLine(str);
                }
            }

            try
            {
                string tempFile2 = Path.GetTempFileName();
                var fileInfo2 = new FileInfo(tempFile2);

                // Убедимся, что файл назначения точно отсутствует
                fileInfo2.Delete();

                // Копируем информацию
                fileInfo.CopyTo(tempFile2);
                Console.WriteLine($"{tempFile} скопирован в файл {tempFile2}.");
                //Удаляем ранее созданный файл.
                fileInfo.Delete();
                Console.WriteLine($"{tempFile} удален.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e}");
            }
        }
    }
    public class Drive
    {
        public Drive(string name, long totalSpace, long freeSpace)
        {
            Name = name;
            TotalSpace = totalSpace;
            FreeSpace = freeSpace;
        }

        public string Name { get; }
        public long TotalSpace { get; }
        public long FreeSpace { get; }
    }
    public class Folder
    {
        public List<string> Files { get; set; } = new List<string>();

        Dictionary<string, Folder> Folders = new Dictionary<string, Folder>();

        public void CreateFolder(string name)
        {
            Folders.Add(name, new Folder());
        }
    }
}
