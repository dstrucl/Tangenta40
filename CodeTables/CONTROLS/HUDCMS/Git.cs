using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUDCMS
{
    public static class Git
    {
        public static bool Add(string filename,ref string stdout_str, ref string stderr_str)
        {
            string GitExeFile = Properties.Settings.Default.GitExeFile;
            if (GitExeFile.Length > 0)
            {
                if (File.Exists(GitExeFile))
                {
                    ProcessStartInfo gitInfo = new ProcessStartInfo();
                    gitInfo.CreateNoWindow = true;
                    gitInfo.RedirectStandardError = true;
                    gitInfo.RedirectStandardOutput = true;
                    gitInfo.FileName = GitExeFile;
                    gitInfo.UseShellExecute = false;

                    Process gitProcess = new Process();
                    gitInfo.Arguments = " add \""+filename+"\""; // such as "fetch orign"
                    string path = Path.GetDirectoryName(filename);
                    gitInfo.WorkingDirectory = path;

                    gitProcess.StartInfo = gitInfo;
                    gitProcess.Start();

                    stderr_str = gitProcess.StandardError.ReadToEnd();  // pick up STDERR
                    stdout_str = gitProcess.StandardOutput.ReadToEnd(); // pick up STDOUT

                    gitProcess.WaitForExit();
                    gitProcess.Close();
                    return true;
                }
                else
                {
                    stderr_str = "Git exe file:\"" + GitExeFile + "\" does not exist";
                    stdout_str = "";
                    return false;
                }
            }
            else
            {
                stderr_str = "Git exe file is not defined!";
                stdout_str = "";
                return false;
            }
        }
    }
}
