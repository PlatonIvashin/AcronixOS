using System;
using System.IO;
using System.Collections.Generic;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem;
using AcronixOS.Code.CORE.System32.langs;

namespace AcronixOS.Code.CORE.System32.HARDWARE.FAT
{
    public static class PMFAT
    {
        public static CosmosVFS Driver;
        public static string ConfigFile = @"0:\";

        public static void Initialize()
        {
            try
            {
                Driver = new CosmosVFS();
                Sys.FileSystem.VFS.VFSManager.RegisterVFS(Driver); // Регистрируем Файловую систему (ФАТ32)
                Console.WriteLine("[INFO] Virtual filesystem initialized");
                foreach (var disk in Cosmos.System.FileSystem.VFS.VFSManager.GetDisks())
                {
                    Console.WriteLine("[INFO] Mounting all partitions on disk " + Cosmos.System.FileSystem.VFS.VFSManager.GetDisks().IndexOf(disk) + "...");
                    disk.Mount();
                    Console.WriteLine();
                }
            }
            catch (Exception ex) 
            {
                Console.Write("[FSys] ", Console.ForegroundColor = ConsoleColor.Red); // блок с ошибкой
                Console.Write(ex.Message, Console.ForegroundColor = ConsoleColor.Black);
            }
        }
        public static string CreateFile(string file) 
        {
            Sys.FileSystem.VFS.VFSManager.CreateFile(file); // Создание файла
            return file;
        }
        public static string[] GetFiles(string path)
        {
            string[] files = Directory.GetFiles(path); // Получение файлов
            return files;
        }

        public static string[] GetFolders(string path)
        {
            string[] folders = Directory.GetDirectories(path); // Получении папок
            return folders;
        }

        public static List<Sys.FileSystem.Listing.DirectoryEntry> GetVolumes()
        {
            return Driver.GetVolumes();
        }

        public static bool FileExists(string file) { return File.Exists(file); } // Проверка на существование файла
        public static bool FolderExists(string path) { return Directory.Exists(path); } // Проверка на существование папки

        public static string[] ReadLines(string path) // Считывание строки
        {
            string[] data;
            data = File.ReadAllLines(path);
            return data;
        }
        public static string ReadText(string path) // Считывание текста
        {
            string data;
            data = File.ReadAllText(path);
            return data;
        }
        public static byte[] ReadBytes(string path) // Считывание байтов
        {
            byte[] data;
            data = File.ReadAllBytes(path);
            return data;
        }
        public static void WriteAllText(string path, string text) // Запись всего текста
        {
            File.WriteAllText(path, text);
        }
        public static void WriteAllLines(string path, string[] lines) // Запись всех строк
        {
            File.WriteAllLines(path, lines);
        }
        public static void WriteAllBytes(string path, byte[] data) // Запись всех байтов
        {
            File.WriteAllBytes(path, data);
        }
        public static void WriteAllBytes(string path, List<byte> data) // Запись всех байтов (лист)
        {
            byte[] input = new byte[data.Count];
            for (int i = 0; i < input.Length; i++) { input[i] = data[i]; }
            WriteAllBytes(path, input);
        }

        public static bool CreateFolder(string name) // Создание папки
        {
            bool value = false;
            if (FolderExists(name)) { value = false; }
            else { Directory.CreateDirectory(name); value = true; }
            return value;
        }
        public static bool RenameFolder(string input, string newName) // Переименование папки
        {
            bool value = false;
            if (Directory.Exists(input))
            { Directory.Move(input, newName); value = true; }
            else { value = false; }
            return value;
        }

        public static bool RenameFile(string input, string newName) // Переименование файла
        {
            bool value = false;
            if (FileExists(input))
            { File.Move(input, newName); value = true; }
            else { value = false; }
            return value;
        }

        public static bool DeleteFolder(string path) // Удаление Папки
        {
            if (FolderExists(path))
            {
                try
                {
                    Console.WriteLine(en_US.Attempting_Delete + " " + path);
                    Directory.Delete(path, true);
                    if (!FolderExists(path)) { return true; }
                    else { return false; }
                }
                catch (Exception ex)
                {
                    Console.Write("[FSys] ", Console.ForegroundColor = ConsoleColor.Red); Console.WriteLine(ex.Message, Console.ForegroundColor = ConsoleColor.Black);
                    return false;
                }
            }
            else { return false; }
        }

        public static bool DeleteFile(string file) // Удаление файла
        {
            if (FileExists(file)) { File.Delete(file); return true; }
            else { return false; }
        }

        public static Cosmos.System.FileSystem.Listing.DirectoryEntry Get_File_Info(string file)
        {
            if (FileExists(file))
            {
                try
                {
                    Cosmos.System.FileSystem.Listing.DirectoryEntry attr = Driver.GetFile(file);
                    return attr;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(en_US.Get_File_Info);
                    Console.Write("[FSys] ", Console.ForegroundColor = ConsoleColor.Red); Console.WriteLine(ex.Message, Console.ForegroundColor = ConsoleColor.Black);
                    return null;
                }
            }
            else
            {
                Console.WriteLine(en_US.Not_Locate_File + " " + file);
                return null;
            }
        }

        public static bool CopyFile(string src, string dest) // Копирование файлов
        {
            try
            {
                byte[] sourceData = ReadBytes(src);
                WriteAllBytes(dest, sourceData);
                return true;
            }
            catch (Exception ex) {
                Console.Write("[FSys] ", Console.ForegroundColor = ConsoleColor.Red); Console.WriteLine(ex.Message, Console.ForegroundColor = ConsoleColor.Black);
                return false;
            }
        }

        public static double BytesToMB(long bytes) // Конвертирование Байтов в Мб
        {
            return (bytes / 1024f) / 1024f;
        }

        public static double BytesToKB(long bytes)
        {
            return bytes / 1024;
        }
    }
}