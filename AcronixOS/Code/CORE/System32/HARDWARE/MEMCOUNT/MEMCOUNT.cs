using System;
using Cosmos.Core;

namespace AcronixOS.Code.CORE.System32.HARDWARE.MEMCOUNT
{
    public static class MEMCOUNT
    {
        public static void Initialize()
        {
            if (CPU.GetAmountOfRAM() + 2 < 64) // Проверка необходимого кол-ва ОЗУ
            {
                Console.WriteLine("[ERROR] OUT OF MEMORY!\nYour system does not have enough RAM to run AcronixOS!\nAt least 64 Mb of RAM is required, but you only have " + (Cosmos.Core.CPU.GetAmountOfRAM() + 2) + " Mb.");
                Console.ReadKey(true);
                Cosmos.System.Power.Shutdown();
            }
        }
    }
}
