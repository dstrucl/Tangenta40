#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogFile
{
    public class CanNotWriteLogClass
    {
        private DateTime time;
        private string type;
        private string stext;
        private string log_exception_error;
        public CanNotWriteLogClass(DateTime xtime, string typ , string msg, string exerr)
        {
            time = xtime;
            type = typ;
            stext = msg;
            log_exception_error = exerr;
        }
        public string slog
        {
            get { return time.ToString() + "|" + type + "|" + stext + "|" + log_exception_error; }
        }
    }
}
