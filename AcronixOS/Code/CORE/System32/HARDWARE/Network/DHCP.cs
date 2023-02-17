using System;
using AcronixOS.Code.CORE.System32.langs;
using Cosmos.System.Network.IPv4.UDP.DHCP;


namespace AcronixOS.Code.CORE.System32.HARDWARE.Network
{
    public static class DHCP
    {
        static DHCPClient xClient;
        public static void Initialize()
        {
            try
            {
                try
                {
                    if (Cosmos.HAL.NetworkDevice.Devices.Count < 1)
                    {
                        throw new Exception(en_US.Network_Card_not_detected);
                    }

                    Console.WriteLine("[INFO] Creating new DHCP client...");
                    xClient = new DHCPClient();
                    Console.WriteLine("[INFO] Sending DHCP discover packet...");
                    xClient.SendDiscoverPacket();
                    Console.WriteLine("[INFO] Retrieving local IP address...");
                    Console.WriteLine("[INFO] Closing DHCP client...");
                    xClient.Close();
                    Console.WriteLine("[INFO] Network connection established via DHCP.");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[ERROR] DHCP Discover failed.\n" + ex.Message);
                }
            }
            catch (Exception EX)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] " + EX.Message);
            }
        }
        public static void shutdown()
        {
            try
            {
                Console.WriteLine("[INFO] Closing network connections...");
                xClient.Close();

                Console.WriteLine("[INFO] Disposing DHCP client...");
                xClient.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERROR] " + ex.Message);
            }
        }
    }
}
