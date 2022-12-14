using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcronixOS.Code.CORE.System32.Configurations
{
    class registry32
    {
        // SuperUser
        public static Boolean su = false;

        // registry32
        public static string CurrentDirectory = @"0:\";

        // FileSystem
        public static string noLocDir = "Could not locate directory!";
        // MKDir
        public static string MKDir_successfully = "Successfully created directory";
        // RMDir
        public static string RMDir_successfully = "Successfully deleted directory";
        // Create File
        public static string CFile_successfully = "Successfully created file";
        // Delete File
        public static string DFile_successfully = "Successfully deleted file";

        // Terminal
        public static string InvalidArg = "Invalid argument! Path expected";
    }
}
