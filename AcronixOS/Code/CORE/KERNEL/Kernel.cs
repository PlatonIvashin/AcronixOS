using System;
using System.Drawing;
using Sys = Cosmos.System;
using AcronixOS.Code.CORE.terminal;
using AcronixOS.Code.CORE.System32.HARDWARE.FAT;

namespace Graphics
{
    public class Kernel : Sys.Kernel
    {

        protected override void BeforeRun()
        {
            Console.Clear();
            PMFAT.Initialize(); // Инициализация дисковогго пространства
            CommandManager.Initialize(); // Инициализания Терминала
            Console.WriteLine("AcronixOS v1.5 early build");
        }

        protected override void Run()
        {
            CommandManager.GetInput(); // Получение строки терминала
        }
    }
}