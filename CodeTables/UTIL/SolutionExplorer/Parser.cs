using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Build.Construction;
using Microsoft.Build.Evaluation;

namespace SolutionExplorer
{
    public static class Parser
    {
        public static string dcln_select = "Select";
        public static string dcln_ProjectPath = "ProjectPath";
        public static string dcln_AssemblyName = "AssemblyName";
        public static string dcln_NETVersion = "NETVersion";
        public static string dcln_GUID = "GUID";
        public static string dcln_Project = "Project";
        public static string dcln_ExternalDll_relative_path = "Relative Path";
        public static string dcln_ExternalDll_absolute_path = "Absolute Path";
        public static string dcln_ExternalDll_ref_assembly = "Referencing assembly";


        public static string SolutionFile = "";

        public static string ConfigurationName = "";

        public static string Platform = "";

        public static PlatformList Platforms = new PlatformList();

        public static ConfigurationList Configurations = new ConfigurationList();

        public static DataTable dtSelectExecutablesInSolution = null;

        public static DataTable dtLibraries = null;

        public static DataTable dtExternalDll = null;


        public static ProjectReferencesList proj_ref_list = new ProjectReferencesList();

        public static ExternalDllReferenceList extdll_ref_list = new ExternalDllReferenceList();

        public static void Init(ref string SolutionFilePath, ref string SolutionFileName)
        {
            SolutionFile = Properties.Settings.Default.SolutionFile;

            ConfigurationName = Properties.Settings.Default.ConfigurationName;

            Platform = Properties.Settings.Default.Platform;

            SolutionFileName = System.IO.Path.GetFileName(Parser.SolutionFile);

            int iofname = Parser.SolutionFile.IndexOf(SolutionFileName);

            if (iofname > 0)
            {
                SolutionFilePath = Parser.SolutionFile.Substring(0, iofname);
            }
            else
            {
                SolutionFilePath  = "";
            }
        }


        public static Project FindProjectInCollection(string refprojfullpath)
        {
            foreach (Microsoft.Build.Evaluation.Project prj in Microsoft.Build.Evaluation.ProjectCollection.GlobalProjectCollection.LoadedProjects)
            {
                prj.SetProperty("Configuration", ConfigurationName);
                prj.SetProperty("Platform", Platform);
                prj.ReevaluateIfNecessary();
                string prj_full_path = prj.FullPath;
                if (refprojfullpath.Equals(prj.FullPath))
                {
                    return prj;
                }
            }
            return null;
        }

        internal static void SetConfiguration(int iSelectedIndex)
        {
            ConfigurationName = Configurations.SetSelected(iSelectedIndex);
            Properties.Settings.Default.ConfigurationName = ConfigurationName;
            Properties.Settings.Default.Save();

        }

        internal static void SetPlatform(int iSelectedIndex)
        {
            Platform = Platforms.SetSelected(iSelectedIndex);
            Properties.Settings.Default.Platform = Platform;
            Properties.Settings.Default.Save();
        }

        public static string Spaces(int iTabLevel)
        {
            string s = "";
            if (iTabLevel > 0)
            {
                int i = 0;
                while (i < iTabLevel)
                {
                    s = s + "  ";
                    i++;
                }
            }
            return s;
        }


        public static void GetProjectDependencies(int iTabLevel, Microsoft.Build.Evaluation.Project prj)
        {
            string stab = Spaces(iTabLevel);
            int iIndex = proj_ref_list.Find(prj);
            if (iIndex >= 0)
            {
                return;
            }
            else
            {
                proj_ref_list.Add(prj);
            }

            var ProjectReference_Items = prj.GetItems("ProjectReference");

            foreach (Microsoft.Build.Evaluation.ProjectItem pitm in ProjectReference_Items)
            {
                Microsoft.Build.Evaluation.Project pr = pitm.Project;
                string EvaluatedInclude = pitm.EvaluatedInclude;
                string ReferenceProjectCombined = System.IO.Path.Combine(pr.DirectoryPath, EvaluatedInclude);
                string refprojfullpath = Path.GetFullPath(ReferenceProjectCombined);
                Microsoft.Build.Evaluation.Project ref_pr = Parser.FindProjectInCollection(refprojfullpath);

                if (ref_pr != null)
                {
                    GetProjectDependencies( iTabLevel + 1, ref_pr);
                }
                else
                {
                    MessageBox.Show("Project " + refprojfullpath + " not found in Microsoft.Build.Evaluation.ProjectCollection.GlobalProjectCollection.LoadedProjects!");
                }
            }
        }

        public static bool GetSelectedProjectDependencies(ref string TextOutput,ref string Err)
        {
            TextOutput = "";

            if (dtLibraries == null)
            {
                dtLibraries = new DataTable();
                DataColumn dcol_ProjectPath = new DataColumn(dcln_ProjectPath, typeof(string));
                DataColumn dcol_AssemblyName = new DataColumn(dcln_AssemblyName, typeof(string));
                DataColumn dcol_NET_Version = new DataColumn(dcln_NETVersion, typeof(string));
                DataColumn dcol_GUID = new DataColumn(dcln_GUID, typeof(string));
                DataColumn dcol_Project = new DataColumn(dcln_Project, typeof(object));
                dtLibraries.Columns.Add(dcol_AssemblyName);
                dtLibraries.Columns.Add(dcol_NET_Version);
                dtLibraries.Columns.Add(dcol_ProjectPath);
                dtLibraries.Columns.Add(dcol_GUID);
                dtLibraries.Columns.Add(dcol_Project);
            }


            if (dtExternalDll == null)
            {
                dtExternalDll = new DataTable();
                DataColumn dcol_ExternalDll_relative_path = new DataColumn(dcln_ExternalDll_relative_path, typeof(string));
                DataColumn dcol_ExternalDll_absolute_path = new DataColumn(dcln_ExternalDll_absolute_path, typeof(string));
                DataColumn dcol_ExternalDll_ref_assembly = new DataColumn(dcln_ExternalDll_ref_assembly, typeof(string));
                dtExternalDll.Columns.Add(dcol_ExternalDll_absolute_path);
                dtExternalDll.Columns.Add(dcol_ExternalDll_ref_assembly);
                dtExternalDll.Columns.Add(dcol_ExternalDll_relative_path);
            }


            dtLibraries.Rows.Clear();
            dtExternalDll.Rows.Clear();
            proj_ref_list.Items.Clear();

            extdll_ref_list.Items.Clear();





            foreach (DataRow dr in dtSelectExecutablesInSolution.Rows)

            {

                if ((bool)dr[dcln_select] == true)

                {

                    Parser.GetProjectDependencies( 0, (Microsoft.Build.Evaluation.Project)dr[dcln_Project]);

                }

            }



            int iCount = proj_ref_list.Items.Count;



            for (int i = 0; i < iCount; i++)

            {

                DataRow dr = dtLibraries.NewRow();

                Microsoft.Build.Evaluation.Project proj = proj_ref_list.Items[i].Project;



                proj.SetProperty("Configuration", ConfigurationName);

                proj.SetProperty("Platform", Platform);

                proj.ReevaluateIfNecessary();



                var AssemblyName = proj.GetPropertyValue("AssemblyName");



                ICollection<ProjectItem> pitms = proj.Items;

                foreach (ProjectItem pitm in pitms)

                {

                    if (pitm.DirectMetadata != null)

                    {

                        foreach (ProjectMetadata pmd in pitm.DirectMetadata)

                        {



                            if ((pmd.ItemType != null) && (pmd.Name != null))

                            {

                                if (pmd.ItemType.ToLower().Equals("reference") && pmd.Name.ToLower().Equals("hintpath"))

                                {



                                    if (pmd.EvaluatedValue != null)

                                    {

                                        string s = pmd.EvaluatedValue;

                                        TextOutput += "pmd.ItemType = " + pmd.ItemType + ";  pmd.Name = " + pmd.Name + "; pitm.EvaluatedInclude = " + s + "\r\n";

                                        string rel_path = pmd.EvaluatedValue;



                                        string xabs_path = Path.Combine(proj.DirectoryPath, rel_path);

                                        string abs_path = Path.GetFullPath(xabs_path); ;



                                        int iIndex = extdll_ref_list.Find(abs_path);
                                        if (iIndex < 0)
                                        {
                                            extdll_ref_list.Add(rel_path, abs_path, AssemblyName);
                                        }
                                        else
                                        {
                                            extdll_ref_list.Items[iIndex].Add(AssemblyName);
                                        }

                                    }

                                }

                            }

                        }

                    }

                }



                var outputPath = GetOutputPath(proj);

                if (outputPath==null)
                {
                    Err = "Output path not found for Configuration=\"" + ConfigurationName + "\" Platform = " + Platform +"\r\n"
                          + "Hint: May be you don't have such configuration defined in project:"+ proj.FullPath + ".\r\n Try to change Configuration and Platform." ;
                    return false;
                }

                var fullpath = Path.Combine(proj.DirectoryPath, outputPath);



                var projfullpath = Path.GetFullPath(fullpath);



                var OutputType = proj.GetPropertyValue("OutputType");



                var TargetFrameworkVersion = proj.GetPropertyValue("TargetFrameworkVersion");



                var projGUID = proj.GetPropertyValue("ProjectGuid");



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



                dr[dcln_ProjectPath] = proj.FullPath;

                dr[dcln_AssemblyName] = sBinPathAndFullName;

                dr[dcln_NETVersion] = TargetFrameworkVersion;

                dr[dcln_GUID] = projGUID;

                dr[dcln_Project] = proj;

                dtLibraries.Rows.Add(dr);

                TextOutput += sBinPathAndFullName + "\r\n";



            }


            dtExternalDll.Rows.Clear();

            iCount = extdll_ref_list.Items.Count;

            for (int i = 0; i < iCount; i++)
            {

                if (!proj_ref_list.FindFile(extdll_ref_list.Items[i].m_AbsolutePath, ConfigurationName, Platform))
                {

                    DataRow dr = dtExternalDll.NewRow();

                    dr[dcln_ExternalDll_absolute_path] = extdll_ref_list.Items[i].m_AbsolutePath;

                    dr[dcln_ExternalDll_ref_assembly] = extdll_ref_list.Items[i].ReferencingAssembly;

                    dr[dcln_ExternalDll_relative_path] = extdll_ref_list.Items[i].m_RelativePath;

                    dtExternalDll.Rows.Add(dr);

                }
            }
            return true;
        }

        public static string GetOutputPath(Project proj)
        {
            string sOutputPath = null;

            proj.SetProperty("Configuration", ConfigurationName);
            proj.SetProperty("Platform", Platform);
            proj.ReevaluateIfNecessary();

            ICollection<ProjectProperty> proj_prop = proj.AllEvaluatedProperties;

            foreach (ProjectProperty pp in proj_prop)
            {
                string sName = pp.Name;
                if (sName.Equals("OutputPath"))
                {
                    sOutputPath = pp.EvaluatedValue;
                    return sOutputPath;
                }
            }


            string last_configuration = "";
            string last_platform = "";
            foreach (Microsoft.Build.Construction.ProjectPropertyGroupElement pge in  proj.Xml.PropertyGroups)
            {
                foreach (Microsoft.Build.Construction.ProjectElement pe in pge.Children)
                {
                    Microsoft.Build.Construction.ProjectPropertyElement ppe = (Microsoft.Build.Construction.ProjectPropertyElement)pe;
                    if (ppe.Name.ToLower().Equals("configuration"))
                    {
                        last_configuration = ppe.Value;
                    }
                    else if (ppe.Name.ToLower().Equals("platform"))
                    {
                        last_platform = ppe.Value;
                    }
                    else if (ppe.Name.ToLower().Equals("outputpath"))
                    {
                        if (last_configuration.Equals(ConfigurationName) && last_platform.Equals(Platform))
                        {
                            return ppe.Value;
                        }
                            //if (ppe.NextSibling != null)
                            //{
                            //    Microsoft.Build.Construction.ProjectPropertyElement ppe_platform = (Microsoft.Build.Construction.ProjectPropertyElement)ppe.NextSibling;
                            //    if (ppe_platform.Name.ToLower().Equals("platform"))
                            //    {
                            //        if (ppe_platform.Value.Equals(Platform))
                            //        {
                            //            if (ppe_platform.NextSibling != null)
                            //            {
                            //                int iMaxSiblings = 200;
                            //                string s = CheckNextSibling(ppe_platform.NextSibling, iMaxSiblings);
                            //                if (s != null)
                            //                {
                            //                    sOutputPath = s;
                            //                    return sOutputPath;
                            //                }
                            //            }
                            //        }
                            //    }
                            //}
                    }
                }
            }
            return null;
            
        }

        private static string CheckNextSibling(ProjectElement nextSibling, int iMaxSiblings)
        {
            if (iMaxSiblings > 0)
            {
                Microsoft.Build.Construction.ProjectPropertyElement ppe_sibling = (Microsoft.Build.Construction.ProjectPropertyElement)nextSibling;
                if (ppe_sibling.Name.ToLower().Equals("outputpath"))
                {
                    return ppe_sibling.Value;
                }
                else
                {
                    if (ppe_sibling.NextSibling!=null)
                    {
                        return CheckNextSibling(ppe_sibling.NextSibling, iMaxSiblings - 1);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else
            {
                return null;
            }
        }

        public static bool ParseSolutionFile(ref string TextOutput)
        {

            TextOutput = "";

            if (dtSelectExecutablesInSolution == null)
            {
                dtSelectExecutablesInSolution = new DataTable();
                DataColumn dcol_select = new DataColumn(dcln_select, typeof(bool));
                DataColumn dcol_ProjectPath = new DataColumn(dcln_ProjectPath, typeof(string));
                DataColumn dcol_AssemblyName = new DataColumn(dcln_AssemblyName, typeof(string));
                DataColumn dcol_NET_Version = new DataColumn(dcln_NETVersion, typeof(string));
                DataColumn dcol_GUID = new DataColumn(dcln_GUID, typeof(string));
                DataColumn dcol_Project = new DataColumn(dcln_Project, typeof(object));
                dtSelectExecutablesInSolution.Columns.Add(dcol_select);
                dtSelectExecutablesInSolution.Columns.Add(dcol_AssemblyName);
                dtSelectExecutablesInSolution.Columns.Add(dcol_NET_Version);
                dtSelectExecutablesInSolution.Columns.Add(dcol_ProjectPath);
                dtSelectExecutablesInSolution.Columns.Add(dcol_GUID);
                dtSelectExecutablesInSolution.Columns.Add(dcol_Project);
            }
            else
            {
                dtSelectExecutablesInSolution.Rows.Clear();
            }

            if (SolutionFile.Length > 0)
            {
                Properties.Settings.Default.SolutionFile = SolutionFile;
                Properties.Settings.Default.Save();

                Microsoft.Build.Construction.SolutionFile _solutionFile = Microsoft.Build.Construction.SolutionFile.Parse(SolutionFile);

                var sol_configs = _solutionFile.SolutionConfigurations;

                Configurations.Clear();

                foreach (Microsoft.Build.Construction.SolutionConfigurationInSolution sol in sol_configs)
                {
                    Configurations.Add(sol.ConfigurationName);
                }


                int iConf = Configurations.Find(ConfigurationName);

                if (iConf >= 0)
                {

                    Configurations.SelectedIndex = iConf;

                    foreach (Microsoft.Build.Construction.SolutionConfigurationInSolution sol in sol_configs)
                    {

                        if (sol.ConfigurationName.Equals(ConfigurationName))

                        {

                            Platforms.Add(sol.PlatformName);

                        }

                    }

                    int iPlatf = Platforms.Find(Platform);

                    if (iPlatf >= 0)

                    {

                        Platforms.SelectedIndex = iPlatf;

                    }

                }
                else
                {

                    Platforms.Clear();

                    foreach (Microsoft.Build.Construction.SolutionConfigurationInSolution sol in sol_configs)

                    {

                        Platforms.Add(sol.PlatformName);

                    }



                    int iPlatf = Platforms.Find(Platform);

                    if (iPlatf >= 0)

                    {

                        Platforms.SelectedIndex = iPlatf;

                    }

                }

                foreach (Microsoft.Build.Construction.ProjectInSolution proj in _solutionFile.ProjectsInOrder)
                {

                    if (proj.ProjectType == SolutionProjectType.KnownToBeMSBuildFormat)

                    {

                        Microsoft.Build.Evaluation.Project project = null;

                        project = FindProjectInCollection(proj.AbsolutePath);
                        if (project == null)
                        {
                            project = new Microsoft.Build.Evaluation.Project(proj.AbsolutePath);
                        }


                        project.SetProperty("Configuration", ConfigurationName);

                        project.SetProperty("Platform", Platform);

                        project.ReevaluateIfNecessary();



                        var outputPath = project.GetPropertyValue("OutputPath");



                        var fullpath = Path.Combine(project.DirectoryPath, outputPath);

                        var projfullpath = Path.GetFullPath(fullpath);



                        var OutputType = project.GetPropertyValue("OutputType");



                        var AssemblyName = project.GetPropertyValue("AssemblyName");



                        var TargetFrameworkVersion = project.GetPropertyValue("TargetFrameworkVersion");



                        var projGUID = project.GetPropertyValue("ProjectGuid");

                        string sext = null;



                        if (OutputType.ToLower().Equals("winexe"))

                        {

                            sext = "exe";

                        }

                        else if (OutputType.ToLower().Equals("library"))

                        {

                            sext = "dll";

                        }



                        if (sext != null)

                        {

                            if (sext.Equals("exe"))

                            {

                                string sBinPathAndFullName = projfullpath + AssemblyName + "." + sext;

                                DataRow dr = dtSelectExecutablesInSolution.NewRow();

                                dr[dcln_select] = false;

                                dr[dcln_ProjectPath] = proj.AbsolutePath;

                                dr[dcln_AssemblyName] = sBinPathAndFullName;

                                dr[dcln_NETVersion] = TargetFrameworkVersion;

                                dr[dcln_GUID] = projGUID;

                                dr[dcln_Project] = project;

                                dtSelectExecutablesInSolution.Rows.Add(dr);

                                TextOutput += OutputType + " :: " + sBinPathAndFullName + "\r\n";

                            }

                        }

                        else

                        {

                            MessageBox.Show("ERROR:OutputType :" + OutputType + " not supported !");

                        }

                    }

                }

                return true;



            }

            return false;

        }

    }
}
