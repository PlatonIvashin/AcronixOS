using System;
using AcronixOS.Code.CORE.System32.Configurations;
using AcronixOS.Code.CORE.System32.HARDWARE.FAT;
using AcronixOS.Code.CORE.System32.HARDWARE.CLI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            {
                ListContents(registry32.CurrentDirectory);
            }
        }

        private void ListContents(string path)
        {
            try
            {
                string[] folders = PMFAT.GetFolders(path);
                string[] files = PMFAT.GetFiles(path);

                Console.WriteLine("Showing contents of directory \"" + path + "\"");

                // draw folders
                for (int i = 0; i < folders.Length; i++)
                {
                    Console.WriteLine(folders[i], Console.ForegroundColor = ConsoleColor.White);
                    CLI.SetCursorPos(30, CLI.CursorY);
                    Console.WriteLine(" FOLDER", Console.ForegroundColor = ConsoleColor.Gray);
                }

                // draw files
                for (int i = 0; i < files.Length; i++)
                {
                    Cosmos.System.FileSystem.Listing.DirectoryEntry attr = PMFAT.GetFileInfo(path + files[i]);
                    if (attr != null)
                    {
                        Console.Write(files[i]);
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
