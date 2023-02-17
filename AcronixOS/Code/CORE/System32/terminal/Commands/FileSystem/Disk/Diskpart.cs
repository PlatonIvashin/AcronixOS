using System;
using AcronixOS.Code.CORE.System32.Configurations;
using AcronixOS.Code.CORE.System32.langs;

namespace AcronixOS.Code.CORE.terminal.Commands
{
    public class diskpart : Command
    {
        public diskpart()
        {
            this.Name = "DISKPART";
            this.Help = "Displays disk information";
        }

        public override void Execute(string line, string[] args)
        {
            long totalSize = Cosmos.System.FileSystem.VFS.VFSManager.GetTotalSize(registry32.CurrentDirectory) / 1024 / 1024;
            long freeSpace = Cosmos.System.FileSystem.VFS.VFSManager.GetAvailableFreeSpace(registry32.CurrentDirectory) / 1024 / 1024;
            long usedSpace = totalSize - freeSpace;

            Console.WriteLine(en_US.Volume_info, registry32.CurrentDirectory);

            Console.WriteLine(en_US.Disk_label, Cosmos.System.FileSystem.VFS.VFSManager.GetFileSystemLabel(registry32.CurrentDirectory));

            Console.WriteLine(en_US.Disk_total_size, totalSize);

            Console.WriteLine(en_US.Disk_free_space, freeSpace);

            Console.WriteLine(en_US.Disk_used_space, usedSpace);

            Console.WriteLine(en_US.Disk_filesystem, Cosmos.System.FileSystem.VFS.VFSManager.GetFileSystemType(registry32.CurrentDirectory));
        }
    }
}