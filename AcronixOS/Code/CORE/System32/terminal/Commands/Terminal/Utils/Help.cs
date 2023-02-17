using System;
using AcronixOS.Code.CORE.System32.HARDWARE.CLI;

namespace AcronixOS.Code.CORE.terminal.Commands {
    public class Help : Command
    {
        public Help()
        {
            this.Name = "HELP";
            this.Help = "Prints a list of commands";
        }

        public override void Execute(string line, string[] args)
        {
            // Показ меню
            if (args.Length == 1)
            {
                // Отрисовка
                SetupScreen();
                DrawMessage();

                CLI.DrawString(2, CLI.Height - 2, "Press any key to exit...", Console.ForegroundColor = ConsoleColor.Black, Console.BackgroundColor = ConsoleColor.White);

                // Выход
                CLI.SetCursorPos(CLI.Width - 13, 0);
                Console.ReadKey(true);
                Console.ForegroundColor = ConsoleColor.Black; Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                CLI.SetCursorPos(0, 0);
            }
        }

        private void SetupScreen()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            CLI.FillRect(2, 2, CLI.Width - 4, CLI.Height - 3, ' ', Console.ForegroundColor = ConsoleColor.Black, Console.BackgroundColor = ConsoleColor.White);
            CLI.DrawLineH(2, 2, CLI.Width - 4, ' ', Console.ForegroundColor = ConsoleColor.Black, Console.BackgroundColor = ConsoleColor.White);
            CLI.DrawString(2, 2, " CMD                   DESCRIPTION", Console.ForegroundColor = ConsoleColor.Black, Console.BackgroundColor = ConsoleColor.White);
            CLI.DrawLineH(0, 3, CLI.Width, ' ', Console.ForegroundColor = ConsoleColor.Black, Console.BackgroundColor = ConsoleColor.Blue);
            CLI.SetCursorPos(2, 2);
        }

        private void DrawMessage()
        {
            int dx = 3, dy = 4;
            for (int i = 0; i < CommandManager.Commands.Count; i++)
            {
                CLI.DrawString(dx, dy, "---------------------", Console.ForegroundColor = ConsoleColor.Black, Console.BackgroundColor = ConsoleColor.White);
                CLI.DrawString(dx, dy, CommandManager.Commands[i].Name + " ", Console.ForegroundColor = ConsoleColor.Black, Console.BackgroundColor = ConsoleColor.White);
                CLI.DrawString(dx + 22, dy, CommandManager.Commands[i].Help, Console.ForegroundColor = ConsoleColor.Black, Console.BackgroundColor = ConsoleColor.White);
                dy += 1;
                if (dy >= 23)
                {
                    // Следущее сообщение
                    CLI.DrawString(2, CLI.Height - 2, "Press any key to goto next page", Console.ForegroundColor = ConsoleColor.Black, Console.BackgroundColor = ConsoleColor.White);
                    CLI.SetCursorPos(CLI.Width - 13, 0);

                    // Следущая страница
                    Console.ReadKey(true);
                    SetupScreen();
                    dy = 4;
                }
            }
        }
    }
}
