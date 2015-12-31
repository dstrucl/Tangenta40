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
