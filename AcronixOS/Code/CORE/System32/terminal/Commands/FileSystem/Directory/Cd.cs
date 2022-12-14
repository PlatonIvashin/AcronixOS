using System;
using AcronixOS.Code.CORE.System32.HARDWARE.FAT;
using AcronixOS.Code.CORE.System32.Configurations;
using System.Collections.Generic;
using System.Text;

namespace AcronixOS.Code.CORE.terminal.Commands
{
    public class Cd : Command
    {
        public Cd()
        {
            this.Name = "CD";
            this.Help = "Set the active directory";
        }

        public override void Execute(string line, string[] args)
        {
            if (args.Length == 1) { registry32.CurrentDirectory = @"0:\"; }
            else
            {
                if (line.Length > 3)
                {
                    string path = line.Substring(3, line.Length - 3).ToLower();
                    if (path.EndsWith('\\')) { path = path.Remove(path.Length - 1, 1); }
                    path += "\\";

                    if (PMFAT.FolderExists(path))
                    {
                        if (path.StartsWith(registry32.CurrentDirectory)) { registry32.CurrentDirectory = path; }
                        else if (path.StartsWith(@"0:\")) { registry32.CurrentDirectory = path; }
                        else if (!path.StartsWith(registry32.CurrentDirectory) && !path.StartsWith(@"0:\"))
                        {
                            if (PMFAT.FolderExists(registry32.CurrentDirectory + path)) { registry32.CurrentDirectory = registry32.CurrentDirectory + path; }
                            else { Console.WriteLine(registry32.noLocDir, Console.ForegroundColor = ConsoleColor.Red); }
                        }
                    }
                    else { Console.WriteLine(registry32.noLocDir, Console.ForegroundColor = ConsoleColor.Red); }
                }
                else { Console.WriteLine(registry32.InvalidArg, Console.ForegroundColor = ConsoleColor.Red); }
            }
        }
    }
}