using System;
using AcronixOS.Code.CORE.System32.Configurations;
using AcronixOS.Code.CORE.System32.HARDWARE.FAT;
using AcronixOS.Code.CORE.System32.langs;
using AcronixOS.Code.CORE.System32.HARDWARE.CLI;

namespace AcronixOS.Code.CORE.terminal.Commands
{
    public class Dir : Command
    {
        public Dir()
        {
            this.Name = "DIR";
            this.Help = "List contents of specified directory";
        }

        public override void Execute(string line, string[] args)
        {
            // Показ контента в действующей директории
            if (args.Length == 1)
            {
                ListContents(registry32.CurrentDirectory);
            }
            // Показ контента в указанной директории
            else if (line.Length > 4)
            {
                string path = line.Substring(4, line.Length - 4).ToLower();
                if (path.EndsWith('\\')) { path = path.Remove(path.Length - 1, 1); }
                path += "\\";

                if (PMFAT.FolderExists(path))
                {
                    if (path.StartsWith(registry32.CurrentDirectory)) { ListContents(path); }
                    else if (path.StartsWith(@"0:\")) { ListContents(path); }
                    else if (!path.StartsWith(registry32.CurrentDirectory) && !path.StartsWith(@"0:\"))
                    {
                        if (PMFAT.FolderExists(registry32.CurrentDirectory + path)) ListContents(registry32.CurrentDirectory + path);
                        else { Console.WriteLine(en_US.Not_Locate_Directory + path, Console.ForegroundColor = ConsoleColor.Red); }
                    }
                    else { Console.WriteLine(en_US.Not_Locate_Directory + path, Console.ForegroundColor = ConsoleColor.Red); }
                }
                else { Console.WriteLine(en_US.Not_Locate_Directory + path, Console.ForegroundColor = ConsoleColor.Red); }
            }
            else { Console.WriteLine(en_US.Invalid_Arguments, Console.ForegroundColor = ConsoleColor.Red); }
        }

        private void ListContents(string path)
        {
            try
            {
                string[] folders = PMFAT.GetFolders(path);
                string[] files = PMFAT.GetFiles(path);

                Console.WriteLine(en_US.Directory_Content + " " + path);

                // draw folders
                for (ushort i = 0; i < folders.Length; i++)
                {
                    Console.WriteLine(folders[i], Console.ForegroundColor = ConsoleColor.White);
                }

                // draw files
                for (ushort i = 0; i < files.Length; i++)
                {
                    Cosmos.System.FileSystem.Listing.DirectoryEntry attr = PMFAT.Get_File_Info(path + files[i]);
                    if (attr != null)
                    {
                        Console.Write(files[i]);
                        CLI.SetCursorPos(30, CLI.CursorY);
                        Console.WriteLine(attr.mSize.ToString() + " BYTES", Console.ForegroundColor = ConsoleColor.Gray);
                    }
                    else { Console.WriteLine("Error retrieiving file info", Console.ForegroundColor = ConsoleColor.Red); }
                }

                Console.WriteLine("");
                Console.Write("Total folders: " + folders.Length.ToString());
                Console.Write("        Total files: " + files.Length.ToString());
                Console.WriteLine("        Available free space: " + PMFAT.Driver.GetAvailableFreeSpace(@"0:\"));
            }
            catch (Exception ex) { }
        }
    }
}
