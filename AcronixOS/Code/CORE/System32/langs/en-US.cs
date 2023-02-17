using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcronixOS.Code.CORE.System32.langs
{
    class en_US
    {
        // TERMINAL
        public static String Command_Not_Found = "Command not found. Enter help for list of commands";
        public static String Help_Nect_Page = "Press \"Y\" to see the following list of commands";
        public static String Invalid_Arguments = "Invalid argument!";
        public static String Missing_Arguments = "Missing arguments!";

        // FileSystem
        public static String Attempting_Delete = "Attempting to delete";
        public static String Get_File_Info = "Error occured when trying to retrieve file info";
        public static String Not_Locate_File = "Could not locate file";
        public static String Not_Locate_Directory = "Could not locate directory";
        public static String MKDir_successfully = "Successfully created directory";
        public static String RMDir_successfully = "Successfully deleted directory";
        public static String CFile_successfully = "Successfully created file";
        public static String DFile_successfully = "Successfully deleted file";
        public static String Directory_Content = "Showing contents of directory";

        public static String Volume_info = "Volume information for {0}";
        public static String Disk_label = "Label: {0}";
        public static String Disk_total_size = "Total size: {0} MB";
        public static String Disk_free_space = "Available free space: {0} MB";
        public static String Disk_used_space = "Used space: {0} MB";
        public static String Disk_filesystem = "File system: {0}";

        public static String Partitions_Format = "Formatting partition {0} of disk {1}...";
        public static String Partitions_Create = "Creating new partition on disk {0} with size {1}...";
        public static String Partitions_Exists = "The drive \"{0}\" doesn't exist!";

        // Network 

        public static String Network_Card_not_detected = "There are no usable network devices installed in the system!";

        public static String Host_Get_IP = "Getting ip address of {0}...";
        public static String Host_Output_IP = "{0}'s ip address is: {1}";

        public static String Ping_IPv4_addresses = "Pinging \" {0} \"...";
        public static String Ping_Response_Time = "Response recieved in {0} millisecond(s)";
        public static String Ping_Failed = "Ping failed";
        public static String Ping_Successful = "Success rate: {0} percent. ({1}/ 4)";

    }
}
