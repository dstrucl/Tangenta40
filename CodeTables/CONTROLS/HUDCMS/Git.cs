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
        public enum eCheckIfFileInRepository {FileIsInRepository, FileIsNotInRepository,ERROR};

        public static eCheckIfFileInRepository CheckIfFileInRepository(string filename, ref string stdout_str, ref string stderr_str)
        {
            string GitExeFile = Properties.Settings.Default.GitExeFile;
            if (GitExeFile.Length > 0)
            {
                if (File.Exists(GitExeFile))
                {
                    stdout_str = "";
                    stderr_str = "";
                    if (GitCommand(GitExeFile, " ls-files ", filename, ref stdout_str, ref stderr_str))
                    {
                        string fileNameWithExtension = Path.GetFileName(filename);
                        if (stdout_str.Contains(fileNameWithExtension))
                        {
                            return eCheckIfFileInRepository.FileIsInRepository;
                        }
                        else
                        {
                            return eCheckIfFileInRepository.FileIsNotInRepository;
                        }
                    }
                    else
                    {
                        return eCheckIfFileInRepository.ERROR ;
                    }
                }
                else
                {
                    stderr_str = "Git exe file:\"" + GitExeFile + "\" does not exist";
                    stdout_str = "";
                    return eCheckIfFileInRepository.ERROR;
                }
            }
            else
            {
                stderr_str = "Git exe file is not defined!";
                stdout_str = "";
                return eCheckIfFileInRepository.ERROR;
            }
        }
        public static bool Add(string filename,ref string stdout_str, ref string stderr_str)
        {
            string GitExeFile = Properties.Settings.Default.GitExeFile;
            if (GitExeFile.Length > 0)
            {
                if (File.Exists(GitExeFile))
                {
                    return GitCommand(GitExeFile, " add ", filename, ref stdout_str, ref stderr_str);
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

        private static bool GitCommand(string gitexefile,string gitcommand,string filename, ref string stdout_str, ref string stderr_str)
        {
            try
            {
                ProcessStartInfo gitInfo = new ProcessStartInfo();
                gitInfo.CreateNoWindow = true;
                gitInfo.RedirectStandardError = true;
                gitInfo.RedirectStandardOutput = true;
                gitInfo.FileName = gitexefile;
                gitInfo.UseShellExecute = false;

                Process gitProcess = new Process();
                gitInfo.Arguments = gitcommand + "\"" + filename + "\""; // such as "fetch orign"
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
            catch (Exception ex)
            {
                stderr_str = ex.Message;
                return false;
            }


        }
    }
}
