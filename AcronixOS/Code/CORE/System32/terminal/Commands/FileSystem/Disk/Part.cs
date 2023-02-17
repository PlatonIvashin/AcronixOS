using System;
using AcronixOS.Code.CORE.System32.langs;

namespace AcronixOS.Code.CORE.terminal.Commands
{
    public class Part : Command
    {
        public Part()
        {
            this.Name = "PART";
            this.Help = "Interaction with the disk and its partitions";
        }

        public override void Execute(string line, string[] args)
        {
            switch (args[1])
            {
                case "format":
                    try
                    {
                        if (args.Length == 3)
                        {
                            int index = 0;
                            bool DriveExists = false;
                            foreach (var disk in Cosmos.System.FileSystem.VFS.VFSManager.GetDisks())
                            {
                                foreach (var partition in disk.Partitions)
                                {
                                    if (partition.RootPath == args[2])
                                    {
                                        DriveExists = true;
                                        Console.WriteLine(en_US.Partitions_Format, index, args[2]);
                                        disk.FormatPartition(0, "FAT32", true);
                                        break;
                                    }
                                }
                            }

                            if (!DriveExists)
                            {
                                Console.WriteLine(en_US.Partitions_Exists, args[2]);
                            }
                        }
                        else
                        {
                            Console.WriteLine(en_US.Missing_Arguments);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        break;
                    }
                    break;

                case "create":
                    try
                    {
                        if (args.Length == 4)
                        {
                            foreach (var disk in Cosmos.System.FileSystem.VFS.VFSManager.GetDisks())
                            {
                                foreach (var partition in disk.Partitions)
                                {
                                    if (partition.RootPath == args[2])
                                    {
                                        Console.WriteLine(en_US.Partitions_Create, args[2], args[3]);
                                        disk.CreatePartition(System.Convert.ToInt32(args[3]));
                                        disk.FormatPartition(disk.Partitions.Count - 1, "FAT32", true);
                                        disk.MountPartition(disk.Partitions.Count - 1);
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine(en_US.Missing_Arguments);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        break;
                    }
                    break;

                case "list":
                    try
                    {
                        if (args.Length == 3)
                        {
                            foreach (var disk in Cosmos.System.FileSystem.VFS.VFSManager.GetDisks())
                            {
                                foreach (var partition in disk.Partitions)
                                {
                                    if (partition.RootPath == args[2])
                                    {
                                        Console.WriteLine("Root Path: " + partition.RootPath);
                                        Console.WriteLine("Has FS: " + partition.HasFileSystem);
                                        Console.WriteLine("Label: " + partition.MountedFS.Label);
                                    }
                                }
                                Console.WriteLine();
                            }
                        }

                        else
                        {
                            Console.WriteLine(en_US.Missing_Arguments);
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        break;
                    }
                    break;

                default:
                    Console.WriteLine("Unkown argument: " + args[1], Console.ForegroundColor = ConsoleColor.Red);
                    break;
            }
        }
    }
}