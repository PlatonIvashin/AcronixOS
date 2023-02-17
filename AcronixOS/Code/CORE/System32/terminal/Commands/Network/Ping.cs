using Cosmos.System.Network.IPv4;
using AcronixOS.Code.CORE.System32.langs;
using System;

namespace AcronixOS.Code.CORE.terminal.Commands
{
    public class Ping : Command
    {
        public Ping()
        {
            this.Name = "PING";
            this.Help = "Connection test";
        }

        public override void Execute(string line, string[] args)
        {
            if (args.Length == 2)
            {
                String IP = line.Substring(5, line.Length - 5);
                float successful = 0;
                if (Cosmos.HAL.NetworkDevice.Devices.Count > 0)
                {
                    try
                    {
                        Console.WriteLine(en_US.Ping_IPv4_addresses, IP);
                        EndPoint endPoint = new EndPoint(Address.Zero, 0); ;
                        using (var xClient = new ICMPClient())
                        {
                            xClient.Connect(Address.Parse(IP));

                            for (int i = 0; i < 4; i++)
                            {
                                xClient.SendEcho();

                                int time = xClient.Receive(ref endPoint);
                                if (time >= 0)
                                {
                                    Console.WriteLine(en_US.Ping_Response_Time, time);
                                    successful++;
                                }
                                else
                                {
                                    Console.WriteLine(en_US.Ping_Failed);
                                }
                            }
                        }
                        Console.WriteLine(en_US.Ping_Successful, successful / 4 * 100, successful);
                    }
                    catch
                    {

                    }
                }
                else
                {
                    Console.WriteLine(en_US.Network_Card_not_detected);
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
