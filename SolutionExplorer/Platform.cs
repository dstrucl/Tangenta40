﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionExplorer
{
    public class Platform
    {
        string m_Name = null;
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public Platform(string name)
        {
            Name = name;
        }
    }
}
