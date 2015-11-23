using System;
using System.Collections.Generic;

using System.Text;
using System.Diagnostics;

namespace DBConnectionControl40
{
    public static class dbg
    {
        public static bool bON = false;
        public static void Print(string s)
        {
            if (bON)
            {
                DateTime dt = DateTime.Now;
                string DateTimeString = dt.Day.ToString("D2") +"."+ dt.Month.ToString("D2") + "." + dt.Year.ToString("D4") + ", " + dt.Hour.ToString("D2")+":"+dt.Minute.ToString("D2")+":"+dt.Second.ToString("D2")+" + "+ dt.Millisecond.ToString("D3")+"ms"; 
                Debug.Print("\r\n" + DateTimeString+"|"+s);
            }
        }
    }
}

