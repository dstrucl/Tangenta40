using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Evaluation;

namespace SolutionExplorer
{
    public class ProjectReference
    {
        private bool m_Scanned = false;
        public bool Scanned
        {
            get { return m_Scanned; }
            set { m_Scanned = value; }
        }

        public Microsoft.Build.Evaluation.Project Project;

        public string Name
        {
            get { return Project.FullPath; }
        }

        public ProjectReference(Microsoft.Build.Evaluation.Project xprj)
        {
            this.Project = xprj;
            Scanned = false;
        }
    }
}
