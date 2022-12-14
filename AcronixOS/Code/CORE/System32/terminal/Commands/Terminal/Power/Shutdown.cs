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
            Cosmos.System.Power.Shutdown();
        }
    }
}