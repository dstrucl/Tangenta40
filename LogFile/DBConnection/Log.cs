using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Reflection;

namespace LogFile
{
        public static class Log
        {
            public static int LogLevel = 0;

            static string strAppDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
            static string LogFileName = strAppDir + "\\Log.txt";
            public static void Write(int Level, string s)
            {
                if (Level > LogLevel)
                {
                    TextWriter twr = new StreamWriter(LogFileName, true);
                    DateTime dt = DateTime.Now;
                    string DateTimeString = dt.Day.ToString("D2") + "." + dt.Month.ToString("D2") + "." + dt.Year.ToString("D4") + ", " + dt.Hour.ToString("D2") + ":" + dt.Minute.ToString("D2") + ":" + dt.Second.ToString("D2") + " + " + dt.Millisecond.ToString("D3") + "ms";
                    twr.WriteLine(DateTimeString + "|" + s);
                    twr.Close();
                }
            }
        }

}
