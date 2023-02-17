using System;

namespace AcronixOS.Code.CORE.System32.HARDWARE.CLI
{
    public class CLI
    {
        public static ushort Width { get { return 80; } } // получение ширины
        public static ushort Height { get { return 25; } } // получение высоты
        public static int CursorX { get { return Console.CursorLeft; } set { Console.CursorLeft = value; } } // курсор по X
        public static int CursorY { get { return Console.CursorTop; } set { Console.CursorTop = value; } } // курсор по Y
        public static void SetCursorPos(int x, int y) // Установить курсор в позицию X;Y
        {
            int cx = x, cy = y;
            if (x < 0) { cx = 0; }
            if (y < 0) { cy = 0; }
            if (x >= Width) { cx = Width - 1; }
            if (y >= Height) { cy = Height - 1; }
            CursorX = cx; CursorY = cy;
        }
        public static void DrawLineH(int x, int y, int w, char c, ConsoleColor fg, ConsoleColor bg) // Отрисовка линий
        {
            char drawChar = c;
            if (c < 32 || c >= 127) { drawChar = ' '; }
            for (ushort i = 0; i < w; i++) { DrawChar(x + i, y, drawChar, fg, bg); }
        }
        public static bool DrawChar(int x, int y, char c, ConsoleColor fg, ConsoleColor bg) // Отрисовка символа
        {
            if (x >= 0 && x < CLI.Width && y >= 0 && y < CLI.Height)
            {
                int oldX = CLI.CursorX, oldY = CLI.CursorY;
                CLI.SetCursorPos(x, y);
                Console.Write(c.ToString(), fg, bg);
                CLI.SetCursorPos(oldX, oldY);
                return true;
            }
            else { return false; }
        }
        public static void DrawString(int x, int y, string txt, ConsoleColor fg, ConsoleColor bg) // Отрисовка Строки
        {
            for (ushort i = 0; i < txt.Length; i++) { DrawChar(x + i, y, txt[i], fg, bg); }
        }
        public static void FillRect(int x, int y, int w, int h, char c, ConsoleColor fg, ConsoleColor bg)
        {
            char drawChar = c;
            if (c < 32 || c >= 127) { drawChar = ' '; }

            for (ushort i = 0; i < w * h; i++)
            {
                int xx = x + (i % w);
                int yy = y + (i / w);
                if (xx * yy < CLI.Width * CLI.Height) { DrawChar(xx, yy, drawChar, fg, bg); }
            }
        }

    }
}
