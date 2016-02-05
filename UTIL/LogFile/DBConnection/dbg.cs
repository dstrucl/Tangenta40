#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;

using System.Text;
using System.Diagnostics;

namespace LogFile
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

