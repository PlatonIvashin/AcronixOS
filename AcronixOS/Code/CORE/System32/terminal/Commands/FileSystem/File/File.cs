using System;
using AcronixOS.Code.CORE.System32.Configurations;
using AcronixOS.Code.CORE.System32.HARDWARE.FAT;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcronixOS.Code.CORE.terminal.Commands
{
    public class File : Command
    {
        public File()
        {
            this.Name = "FILE";
            this.Help = "File Interaction";
        }

        public override void Execute(string line, string[] args)
        {
            switch (args[1])
            {
                case "c":
                    try
                    {
                        string path = "";
                        if (line.Length > 6)
                        {
                            path = line.Substring(7, line.Length - 7);
                            if (path.EndsWith('\\')) { path = path.Remove(path.Length - 1, 1); }
                            if (path.StartsWith(registry32.CurrentDirectory)) { PMFAT.CreateFile(path); Console.WriteLine(registry32.CFile_successfully + " " + path, Console.ForegroundColor = ConsoleColor.Green); }
                            else if (path.StartsWith(@"0:\")) { PMFAT.CreateFile(path); Console.WriteLine(registry32.CFile_successfully + " " + path, Console.ForegroundColor = ConsoleColor.Green); }
                            else if (!path.StartsWith(registry32.CurrentDirectory) && !path.StartsWith(@"0:\"))
                            {
                                PMFAT.CreateFile(registry32.CurrentDirectory + path);

                                Console.WriteLine(registry32.CFile_successfully + " " + registry32.CurrentDirectory + path, Console.ForegroundColor = ConsoleColor.Green);
                            }
                            else { Console.WriteLine(registry32.noLocDir + path, Console.ForegroundColor = ConsoleColor.Red); ; }
                        }
                        else { Console.WriteLine(registry32.InvalidArg, Console.ForegroundColor = ConsoleColor.Red); }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        break;
                    }
                    break;

                case "rm":
                    try { 
                    string path = "";
                    if (line.Length > 6)
                    {
                        path = line.Substring(8, line.Length - 8);
                        if (path.EndsWith('\\')) { path = path.Remove(path.Length - 1, 1); }
                        if (path.StartsWith(registry32.CurrentDirectory)) { PMFAT.DeleteFile(path); Console.WriteLine(registry32.DFile_successfully + " " + path, Console.ForegroundColor = ConsoleColor.Green); }
                        else if (path.StartsWith(@"0:\")) { PMFAT.DeleteFile(path); Console.WriteLine(registry32.DFile_successfully + " " + path, Console.ForegroundColor = ConsoleColor.Green); }
                        else if (!path.StartsWith(registry32.CurrentDirectory) && !path.StartsWith(@"0:\"))
                        {
                            PMFAT.DeleteFile(registry32.CurrentDirectory + path);

                            Console.WriteLine(registry32.DFile_successfully + " " + registry32.CurrentDirectory + path, Console.ForegroundColor = ConsoleColor.Green);
                        }
                        else { Console.WriteLine(registry32.noLocDir + path, Console.ForegroundColor = ConsoleColor.Red); ; }
                    }
                    else { Console.WriteLine(registry32.InvalidArg, Console.ForegroundColor = ConsoleColor.Red); } }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        break;
                    }
                    break;
                default:
                    Console.WriteLine("Unkown argument: " + args[1], Console.ForegroundColor = ConsoleColor.Red);
                    break;
            }
        }
    }
}
