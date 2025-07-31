// Runs when you boot from a HackStick.
using System;
using System.Diagnostics;
using System.IO;

namespace HackStick
{
    public static class Program
    {
        public static void Main()
        {
            string exePath = Process.GetCurrentProcess().MainModule.FileName;
            string exeName = Path.GetFileName(exePath);
            exeName = "Utilman.exe";

            if (Helper.MatchesCaseless(exeName, "HackStick.exe"))
            {
                Phase1.Program.Main();
            }
            else if (Helper.MatchesCaseless(exeName, "Setup.exe"))
            {
                Phase2.Program.Main();
            }
            else if (Helper.MatchesCaseless(exeName, "Utilman.exe"))
            {
                Phase3.Program.Main();
            }
            else
            {
                Console.WriteLine(exePath);
                Console.WriteLine("Please rename executable back to original name.");
                Console.WriteLine("HackStick uses executable name to determine intent.");
                Helper.PressAnyKeyToExit();
            }
        }
    }
}