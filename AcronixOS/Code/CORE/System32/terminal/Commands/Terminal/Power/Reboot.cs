namespace AcronixOS.Code.CORE.terminal.Commands
{
    public class Reboot : Command
    {
        public Reboot()
        {
            this.Name = "REBOOT";
            this.Help = "Command to restart the computer";
        }

        public override void Execute(string line, string[] args)
        {
            Cosmos.System.Power.Reboot();
        }
    }
}
