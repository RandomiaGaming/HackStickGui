using System;
using System.Diagnostics;

namespace HackStick
{
    public static class Helper
    {
        public static bool MatchesCaseless(string a, string b)
        {
            return a.ToLower() == b.ToLower();
        }
        public static void PressAnyKeyToExit()
        {
            Console.WriteLine("Press any key to exit...");
            Stopwatch stopwatch = Stopwatch.StartNew();
            while (true)
            {
                Console.ReadKey(true);
                if (stopwatch.ElapsedTicks > 10000000)
                {
                    break;
                }
            }
            Environment.Exit(0);
        }
        public static string RunCommand(string commandExe, string arguments)
        {
            Process process = new Process();
            process.StartInfo.FileName = commandExe;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return output;
        }
    }
}