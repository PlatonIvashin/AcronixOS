using System;
using Cosmos.Core;
using AcronixOS.Code.CORE.System32.Configurations;

namespace AcronixOS.Code.CORE.terminal.Commands
{
    public class Sysinfo : Command
    {
        public Sysinfo()
        {
            this.Name = "SYSINFO";
            this.Help = "Displays system information";
        }

        public override void Execute(string line, string[] args)
        {
            try
            {
                var ip = Cosmos.System.Network.Config.NetworkConfig.CurrentConfig.Value.IPAddress;
                var mac = Cosmos.System.Network.Config.NetworkConfig.CurrentConfig.Key.MACAddress;

                Console.WriteLine($"OS AcronixOS {registry32.OS_Version}");
                Console.WriteLine($"Procesor: {CPU.GetCPUBrandString().ToString()}");
                Console.WriteLine($"Random access memory (RAM): {Cosmos.Core.CPU.GetAmountOfRAM() + 2} Mb");

                if (Cosmos.HAL.NetworkDevice.Devices.Count < 1)
                {
                    Console.WriteLine("IPv4 address: [No usable network devices!]");
                    Console.WriteLine("MAC address: [No usable network devices!]");
                }
                else
                {
                    Console.WriteLine("IPv4 address: " + ip);
                    Console.WriteLine("MAC address: " + mac);
                }
                
                Console.Write("#", Console.BackgroundColor = ConsoleColor.Red);
                Console.Write("#", Console.BackgroundColor = ConsoleColor.DarkRed);
                Console.Write("#", Console.BackgroundColor = ConsoleColor.Yellow);
                Console.Write("#", Console.BackgroundColor = ConsoleColor.DarkYellow);
                Console.Write("#", Console.BackgroundColor = ConsoleColor.Green);
                Console.Write("#", Console.BackgroundColor = ConsoleColor.DarkGreen);
                Console.Write("#", Console.BackgroundColor = ConsoleColor.Cyan);
                Console.Write("#", Console.BackgroundColor = ConsoleColor.DarkCyan);
                Console.Write("#", Console.BackgroundColor = ConsoleColor.Blue);
                Console.Write("#", Console.BackgroundColor = ConsoleColor.DarkBlue);
                Console.Write("#", Console.BackgroundColor = ConsoleColor.Magenta);
                Console.Write("#", Console.BackgroundColor = ConsoleColor.DarkMagenta);
                Console.Write("#", Console.BackgroundColor = ConsoleColor.Black);
                Console.Write("#", Console.BackgroundColor = ConsoleColor.White);
                Console.WriteLine("#\n", Console.BackgroundColor = ConsoleColor.Gray);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        
    }
}
