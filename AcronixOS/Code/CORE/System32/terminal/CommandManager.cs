using System;
using System.Collections.Generic;
using AcronixOS.Code.CORE.System32.Configurations;
using AcronixOS.Code.CORE.System32.langs;

namespace AcronixOS.Code.CORE.terminal
{
    public static class CommandManager
    {
        public static List<Command> Commands = new List<Command>();
        public static void Initialize()
        {
            AddCommands();
        }
        private static void AddCommands()
        {
            // Utils
            Commands.Add(new Commands.Clear());
            Commands.Add(new Commands.Echo());
            Commands.Add(new Commands.Help());
            Commands.Add(new Commands.Superuser());

            // FSys
            Commands.Add(new Commands.File());
            Commands.Add(new Commands.Dir());
            Commands.Add(new Commands.Cd());
            Commands.Add(new Commands.MKDir());
            Commands.Add(new Commands.RMDir());

            // Power
            Commands.Add(new Commands.Shutdown());
            Commands.Add(new Commands.Reboot());
        }
        public static void GetInput()
        {

            if (registry32.su == false)
            {
                if (registry32.CurrentDirectory == @"0:\")
                {
                    Console.Write("user", Console.ForegroundColor = ConsoleColor.Green);
                    Console.Write(" $ ", Console.ForegroundColor = ConsoleColor.Yellow);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write("user", Console.ForegroundColor = ConsoleColor.Green); Console.Write("@", Console.ForegroundColor = ConsoleColor.Black);
                    Console.Write(registry32.CurrentDirectory.Substring(3, registry32.CurrentDirectory.Length - 3), Console.ForegroundColor = ConsoleColor.Black);
                    Console.Write(" $ ", Console.ForegroundColor = ConsoleColor.Yellow);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                if (registry32.CurrentDirectory == @"0:\")
                {
                    Console.Write("root", Console.ForegroundColor = ConsoleColor.Green);
                    Console.Write(" $ ", Console.ForegroundColor = ConsoleColor.Yellow);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write("root", Console.ForegroundColor = ConsoleColor.Green); Console.Write("@", Console.ForegroundColor = ConsoleColor.Black);
                    Console.Write(registry32.CurrentDirectory.Substring(3, registry32.CurrentDirectory.Length - 3), Console.ForegroundColor = ConsoleColor.Black);
                    Console.Write(" $ ", Console.ForegroundColor = ConsoleColor.Yellow);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            string input = Console.ReadLine();
            ParseCommand(input);
        }
        private static void ParseCommand(string line)
        {
            if (line.Length > 0)
            {
                string[] args = line.Split(' ');
                bool error = true;
                for (int i = 0; i < Commands.Count; i++)
                {
                    if (args[0].ToUpper() == Commands[i].Name)
                    {
                        Commands[i].Execute(line, args);
                        error = false;
                        break;
                    }
                }

                if (error) { Console.WriteLine(en_US.NotFound); Console.Beep(250, 130); ; }
            }

            GetInput();
        }
        public static Command GetCommand(string cmd)
        {
            for (int i = 0; i < Commands.Count; i++)
            {
                if (Commands[i].Name == cmd.ToUpper()) { return Commands[i]; }
            }
            return null;
        }
    }
}