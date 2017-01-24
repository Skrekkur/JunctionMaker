using System.IO;
using System.Runtime.InteropServices;

namespace JunctionMaker
{

    public class WinAPIWrapper
    {
        /// <summary>
         /// The GetDriveType function determines whether a disk drive is a removable, fixed, CD-ROM, RAM disk, or network drive
         /// </summary>
         /// <param name="lpRootPathName">A pointer to a null-terminated string that specifies the root directory and returns information about the disk.A trailing backslash is required. If this parameter is NULL, the function uses the root of the current directory.</param>
         [DllImport("kernel32.dll")]
         public static extern DriveType GetDriveType([MarshalAs(UnmanagedType.LPStr)] string lpRootPathName);
    }
}
