using System;

namespace AcronixOS.Code.CORE.terminal
{
    public abstract class Command
    {
        public string Name;
        public string Help;
        public string Usage;

        public abstract void Execute(string line, string[] args);
    }
}

