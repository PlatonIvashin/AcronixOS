using Cosmos.System.Network.IPv4;
using AcronixOS.Code.CORE.System32.langs;
using System;
using Cosmos.System.Network.IPv4.UDP.DNS;

namespace AcronixOS.Code.CORE.terminal.Commands
{
    public class Host : Command
    {
        public Host()
        {
            this.Name = "HOST";
            this.Help = "Converting a URL to an IPv4 Address";
        }

        public override void Execute(string line, string[] args)
        {
            if (args.Length == 2)
            {
                Console.WriteLine(en_US.Host_Get_IP, args[1]);
                try
                {
                    if (Cosmos.HAL.NetworkDevice.Devices.Count < 1)
                    {
                        throw new Exception(en_US.Network_Card_not_detected);
                    }
                    using (var xClient = new DnsClient())
                    {
                        xClient.Connect(new Address(8, 8, 8, 8));

                        xClient.SendAsk(args[1]);

                        Address destination = xClient.Receive(); //can set a timeout value
                        Console.WriteLine(en_US.Host_Output_IP, args[1], destination.ToString());
                    }
                }
                catch (Exception EX)
                {
                    Console.WriteLine("ERROR: " + EX.Message);
                }
            }
                else
                {
                    Console.WriteLine(en_US.Invalid_Arguments);
                    return;
                }
            }
        }
    
}
