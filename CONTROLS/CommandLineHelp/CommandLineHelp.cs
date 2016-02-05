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

namespace CommandLineHelp
{
    public class CommandLineHelp
    {
        public string Command;
        public string description;
        public CommandLineHelp(string cmd, string help)
        {
            Command = cmd;
            description = help;
        }
    }
}
