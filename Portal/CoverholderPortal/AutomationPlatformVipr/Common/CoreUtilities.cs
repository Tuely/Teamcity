using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AutomationPlatformVipr.Common
{
   public class CoreUtilities
    {
        public static void ExecuteCommand(string command)
        {
            int exitCode;
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            // *** Redirect the output ***
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);
            process.WaitForExit();

            // *** Read the streams ***
            // Warning: This approach can lead to deadlocks, see Edit #2
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            exitCode = process.ExitCode;

            //Log.Info("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
            //Log.Error("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
            //Log.Info("ExitCode: " + exitCode + "ExecuteCommand");
            process.Close();
        }
    }
}
