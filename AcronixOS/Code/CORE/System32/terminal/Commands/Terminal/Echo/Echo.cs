using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcronixOS.Code.CORE.terminal.Commands
{
    public class Echo : Command
    {
        public Echo()
        {
            this.Name = "ECHO";
            this.Help = "Prints a line of input";
        }

        public override void Execute(string line, string[] args)
        {
            Console.WriteLine(line.Substring(5, line.Length - 5));
        }
    }
}