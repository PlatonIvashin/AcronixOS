using System;
using AcronixOS.Code.CORE.System32.Configurations;

namespace AcronixOS.Code.CORE.terminal.Commands
{
    public class Superuser : Command
    {
        public Superuser()
        {
            this.Name = "SU";
            this.Help = "command for issuing/revoking superuser rights";
        }

        public override void Execute(string line, string[] args)
        {
            if (registry32.su == false){
                registry32.su = true;
                Console.WriteLine("[SU] You have been granted superuser rights", Console.ForegroundColor = ConsoleColor.Green);
            }
            else
            {
                registry32.su = false;
                Console.WriteLine("[SU] You have been revoked superuser rights", Console.ForegroundColor = ConsoleColor.Red);
            }
        }
    }
}
