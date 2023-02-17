using System;
using AcronixOS.Code.CORE.System32.HARDWARE.Network;
using AcronixOS.Code.CORE.System32.langs;

namespace AcronixOS.Code.CORE.terminal.Commands
{
    public class Shutdown : Command
    {
        public Shutdown()
        {
            this.Name = "SHUTDOWN";
            this.Help = "Command to shut down the computer";
        }

        public override void Execute(string line, string[] args)
        {
            DHCP.shutdown();
            if (args.Length == 1)
            {
                Cosmos.System.Power.Shutdown();
            }
            else
            {
                if(args[1] == "r")
                {
                    Cosmos.System.Power.Reboot();
                }
                else
                {
                    Console.WriteLine(en_US.Missing_Arguments);
                }
            }
        }
    }
}