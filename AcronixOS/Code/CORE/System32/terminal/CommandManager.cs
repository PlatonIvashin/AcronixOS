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
            Console.WriteLine("[INFO] Command prompt loaded");
            AddCommands();
        }
        private static void AddCommands()
        {
            // Utils
            Commands.Add(new Commands.Clear());
            Commands.Add(new Commands.Echo());
            Commands.Add(new Commands.Beep());
            Commands.Add(new Commands.Help());
            Commands.Add(new Commands.Sysinfo());

            // FSys
            Commands.Add(new Commands.File());
            Commands.Add(new Commands.diskpart());
            Commands.Add(new Commands.Part());
            Commands.Add(new Commands.MKDir());
            Commands.Add(new Commands.RMDir());
            Commands.Add(new Commands.Cd());
            Commands.Add(new Commands.Dir());

            // Network
            Commands.Add(new Commands.Ping());
            Commands.Add(new Commands.Host());

            // Power
            Commands.Add(new Commands.Shutdown());
        }
        public static void GetInput()
        {
                if (registry32.CurrentDirectory == @"0:\")
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("user", Console.ForegroundColor = ConsoleColor.Green);
                    Console.Write(" $ ", Console.ForegroundColor = ConsoleColor.Yellow);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("user", Console.ForegroundColor = ConsoleColor.Green); Console.Write("@", Console.ForegroundColor = ConsoleColor.Yellow);
                    Console.Write(registry32.CurrentDirectory.Substring(3, registry32.CurrentDirectory.Length - 3), Console.ForegroundColor = ConsoleColor.White);
                    Console.Write(" $ ", Console.ForegroundColor = ConsoleColor.Yellow);
                    Console.ForegroundColor = ConsoleColor.White;
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
                for (ushort i = 0; i < Commands.Count; i++)
                {
                    if (args[0].ToUpper() == Commands[i].Name)
                    {
                        Commands[i].Execute(line, args);
                        error = false;
                        break;
                    }
                }

                if (error) { Console.WriteLine(en_US.Command_Not_Found); Console.Beep(250, 130); ; }
            }
            GetInput();
        }
        public static Command GetCommand(string cmd)
        {
            for (ushort i = 0; i < Commands.Count; i++)
            {
                if (Commands[i].Name == cmd.ToUpper()) { return Commands[i]; }
            }
            return null;
        }
    }
}