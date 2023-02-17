using System;
using AcronixOS.Code.CORE.System32.langs;
using AcronixOS.Code.CORE.System32.Configurations;
using AcronixOS.Code.CORE.System32.HARDWARE.FAT;

namespace AcronixOS.Code.CORE.terminal.Commands
{
    public class RMDir : Command
    {
        public RMDir()
        {
            this.Name = "RMDIR";
            this.Help = "Deletes a directory";
        }

        public override void Execute(string line, string[] args)
        {
            string path = "";
            if (line.Length > 6)
            {
                path = line.Substring(6, line.Length - 6);
                if (path.EndsWith('\\')) { path = path.Remove(path.Length - 1, 1); }
                path += "\\";
                if (path.StartsWith(registry32.CurrentDirectory)) { PMFAT.DeleteFolder(path); Console.WriteLine(en_US.RMDir_successfully + " " + path, Console.ForegroundColor = ConsoleColor.Green); }
                else if (path.StartsWith(@"0:\")) { PMFAT.DeleteFolder(path); Console.WriteLine(en_US.RMDir_successfully + " " + path, Console.ForegroundColor = ConsoleColor.Green); }
                else if (!path.StartsWith(registry32.CurrentDirectory) && !path.StartsWith(@"0:\"))
                {
                    PMFAT.CreateFolder(registry32.CurrentDirectory + path);
                    Console.WriteLine(en_US.RMDir_successfully + " " + registry32.CurrentDirectory + path, Console.ForegroundColor = ConsoleColor.Green);
                }
                else { Console.WriteLine(en_US.Not_Locate_Directory, Console.ForegroundColor = ConsoleColor.Red); ; }
            }
            else { Console.WriteLine(en_US.Invalid_Arguments, Console.ForegroundColor = ConsoleColor.Red); }
        }
    }
}
