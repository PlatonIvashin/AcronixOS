using System;
using AcronixOS.Code.CORE.System32.langs;

namespace AcronixOS.Code.CORE.terminal.Commands
{
    public class Beep : Command
    {
        public Beep()
        {
            this.Name = "BEEP";
            this.Help = "Plays the sound at the specified frequency";
        }

        public override void Execute(string line, string[] args)
        {
            if (line.Length == 1 && line.Length > 2)
            {
                Console.WriteLine(en_US.Invalid_Arguments);
                return;
            }
            try
            {
                Cosmos.System.PCSpeaker.Beep(Convert.ToUInt32(args[1]), 250);
            }
            catch (Exception EX)
            {
                Console.WriteLine("ERROR: " + EX.Message);
            }
        }
    }
}
