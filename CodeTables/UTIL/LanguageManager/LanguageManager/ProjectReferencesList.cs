using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageManager
{
    public class ProjectReferencesList
    {
        public List<ProjectReference> Items = new List<ProjectReference>();

        public int Find(Microsoft.Build.Evaluation.Project prj)
        {
            int iCount = Items.Count;
            int i = 0;
            string sGUID = prj.GetPropertyValue("ProjectGuid");
            for (i=0;i<iCount;i++)
            {
                string GuidOfItem = Items[i].Project.GetPropertyValue("ProjectGuid");
                if (sGUID.Equals(GuidOfItem))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Add(Microsoft.Build.Evaluation.Project prj)
        {
            int iIndex = Find(prj);
            if (iIndex<0)
            {
                ProjectReference pref = new ProjectReference(prj);
                Items.Add(pref);
            }
        }

        internal bool FindFile(string m_AbsolutePath, string xConfigurationName,string xPlatform)
        {
            string FileName = System.IO.Path.GetFileName(m_AbsolutePath);
            foreach (ProjectReference prj in Items)
            {
                var AssemblyName = prj.Project.GetPropertyValue("AssemblyName");

                var outputPath = Parser.GetOutputPath(prj.Project);

                var fullpath = System.IO.Path.Combine(prj.Project.DirectoryPath, outputPath);

                var projfullpath = System.IO.Path.GetFullPath(fullpath);

                var OutputType = prj.Project.GetPropertyValue("OutputType");

                var TargetFrameworkVersion = prj.Project.GetPropertyValue("TargetFrameworkVersion");

                var projGUID = prj.Project.GetPropertyValue("ProjectGuid");

                string sext = null;

                if (OutputType.ToLower().Equals("winexe"))
                {
                    sext = "exe";
                }
                else if (OutputType.ToLower().Equals("library"))
                {
                    sext = "dll";
                }

                string sBinPathAndFullName = "";
                if (sext != null)
                {
                    sBinPathAndFullName = projfullpath + AssemblyName + "." + sext;
                }

                string sfilename = System.IO.Path.GetFileName(sBinPathAndFullName);
                if (FileName.ToLower().Equals(sfilename.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
