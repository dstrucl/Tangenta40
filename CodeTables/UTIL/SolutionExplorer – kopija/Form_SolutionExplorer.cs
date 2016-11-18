using System;

using System.Collections.Generic;

using System.ComponentModel;

using System.Data;

using System.Drawing;

using System.Linq;

using System.Text;

using System.Windows.Forms;

using Microsoft.Build.Construction;

using System.IO;

using Microsoft.Build.Evaluation;


namespace SolutionExplorer
{
    public partial class Form_SolutionExplorer : Form
    {

            string dcln_select = "Select";

            string dcln_ProjectPath = "ProjectPath";

            string dcln_AssemblyName = "AssemblyName";

            string dcln_NETVersion = "NETVersion";

            string dcln_GUID = "GUID";

            string dcln_Project = "Project";

            string dcln_ExternalDll_relative_path = "Relative Path";

            string dcln_ExternalDll_absolute_path = "Absolute Path";

            string dcln_ExternalDll_ref_assembly = "Referencing assembly";





            string solution_file = "";

            string ConfigurationName = "";

            string Platform = "";

            DataTable dtSelectExecutablesInSolution = null;

            DataTable dtLibraries = null;

            DataTable dtExternalDll = null;

            ProjectReferencesList proj_ref_list = new ProjectReferencesList();

            ExternalDllReferenceList extdll_ref_list = new ExternalDllReferenceList();



            public Form_SolutionExplorer()

            {

                InitializeComponent();

                solution_file = Properties.Settings.Default.SolutionFile;

                ConfigurationName = Properties.Settings.Default.ConfigurationName;

                Platform = Properties.Settings.Default.Platform;

                usrc_SelectFile1.FileName = System.IO.Path.GetFileName(solution_file);

                int iofname = solution_file.IndexOf(usrc_SelectFile1.FileName);

                if (iofname > 0)

                {

                    usrc_SelectFile1.Path = solution_file.Substring(0, iofname);

                }

                else

                {

                    usrc_SelectFile1.Path = "";

                }

            }



            private void btn_Parse_Click(object sender, EventArgs e)

            {

                GetSelectedProjectDependencies();

            }



            private void GetSelectedProjectDependencies()

            {

                txt_Projects.Text = "";

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

                        GetProjectDependencies(this.ConfigurationName, 0, (Microsoft.Build.Evaluation.Project)dr[dcln_Project]);

                    }

                }



                int iCount = proj_ref_list.Items.Count;



                dgvx_Libraries.DataSource = null;

                for (int i = 0; i < iCount; i++)

                {

                    DataRow dr = dtLibraries.NewRow();

                    Microsoft.Build.Evaluation.Project proj = proj_ref_list.Items[i].Project;



                    proj.SetProperty("Configuration", this.ConfigurationName);

                    proj.SetProperty("Platform", this.Platform);

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

                                            txt_Projects.Text += "pmd.ItemType = " + pmd.ItemType + ";  pmd.Name = " + pmd.Name + "; pitm.EvaluatedInclude = " + s + "\r\n";

                                            string rel_path = pmd.EvaluatedValue;



                                            string xabs_path = Path.Combine(proj.DirectoryPath, rel_path);

                                            string abs_path = Path.GetFullPath(xabs_path); ;



                                            int iIndex = extdll_ref_list.Find(abs_path);

                                            if (iIndex < 0)

                                            {

                                                extdll_ref_list.Add(rel_path, abs_path, AssemblyName);

                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }



                    var outputPath = GetOutputPath(proj, this.ConfigurationName, this.Platform);



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

                    txt_Projects.Text += sBinPathAndFullName + "\r\n";



                }

                dgvx_Libraries.DataSource = dtLibraries;

                dtExternalDll.Rows.Clear();

                dgvx_ExternalDLLReferences.DataSource = null;

                iCount = extdll_ref_list.Items.Count;

                for (int i = 0; i < iCount; i++)

                {

                    if (!proj_ref_list.FindFile(extdll_ref_list.Items[i].m_AbsolutePath, this.ConfigurationName, this.Platform))

                    {

                        DataRow dr = dtExternalDll.NewRow();

                        dr[dcln_ExternalDll_absolute_path] = extdll_ref_list.Items[i].m_AbsolutePath;

                        dr[dcln_ExternalDll_ref_assembly] = extdll_ref_list.Items[i].m_ReferencingAssembly;

                        dr[dcln_ExternalDll_relative_path] = extdll_ref_list.Items[i].m_RelativePath;

                        dtExternalDll.Rows.Add(dr);

                    }

                }

                dgvx_ExternalDLLReferences.DataSource = dtExternalDll;

            }



            public static string GetOutputPath(Project proj, string xConfigurationName, string xPlatform)

            {

                string sOutputPath = null;

                proj.SetProperty("Configuration", xConfigurationName);

                proj.SetProperty("Platform", xPlatform);

                proj.ReevaluateIfNecessary();

                ICollection<ProjectProperty> proj_prop = proj.AllEvaluatedProperties;

                foreach (ProjectProperty pp in proj_prop)

                {

                    string sName = pp.Name;

                    if (sName.Equals("OutputPath"))

                    {

                        sOutputPath = pp.EvaluatedValue;

                        break;

                    }

                }



                return sOutputPath;

            }



            public string Spaces(int iTabLevel)

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

            private void GetProjectDependencies(string xConfiguration, int iTabLevel, Microsoft.Build.Evaluation.Project prj)

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

                    Microsoft.Build.Evaluation.Project ref_pr = FindProjectInCollection(xConfiguration, refprojfullpath);

                    if (ref_pr != null)

                    {

                        GetProjectDependencies(xConfiguration, iTabLevel + 1, ref_pr);

                    }

                    else

                    {

                        MessageBox.Show("Project " + refprojfullpath + " not found in Microsoft.Build.Evaluation.ProjectCollection.GlobalProjectCollection.LoadedProjects!");

                    }

                }

            }



            private Project FindProjectInCollection(string xConfigurationName, string refprojfullpath)

            {

                foreach (Microsoft.Build.Evaluation.Project prj in Microsoft.Build.Evaluation.ProjectCollection.GlobalProjectCollection.LoadedProjects)

                {

                    prj.SetProperty("Configuration", xConfigurationName);

                    prj.SetProperty("Platform", this.Platform);

                    prj.ReevaluateIfNecessary();

                    string prj_full_path = prj.FullPath;

                    if (refprojfullpath.Equals(prj.FullPath))

                    {

                        return prj;

                    }

                }

                return null;

            }



            public bool ParseSolutionFile(string SolutionFile, string xConfigurationName, string xPlatform)

            {

                txt_Projects.Text = "";

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



                    cmb_Configuration.Items.Clear();

                    foreach (Microsoft.Build.Construction.SolutionConfigurationInSolution sol in sol_configs)

                    {

                        AddConfiguration(sol.ConfigurationName);

                    }



                    int iConf = cmb_Configuration_Items_Find(xConfigurationName);

                    if (iConf >= 0)

                    {

                        cmb_Configuration.SelectedIndex = iConf;

                        cmb_Platform.Items.Clear();

                        foreach (Microsoft.Build.Construction.SolutionConfigurationInSolution sol in sol_configs)

                        {

                            if (sol.ConfigurationName.Equals(xConfigurationName))

                            {

                                AddPlatform(sol.PlatformName);

                            }

                        }



                        int iPlatf = cmb_Platform_Items_Find(xPlatform);

                        if (iPlatf >= 0)

                        {

                            cmb_Platform.SelectedIndex = iPlatf;

                        }

                    }

                    else

                    {

                        cmb_Platform.Items.Clear();

                        foreach (Microsoft.Build.Construction.SolutionConfigurationInSolution sol in sol_configs)

                        {

                            AddPlatform(sol.PlatformName);

                        }



                        int iPlatf = cmb_Platform_Items_Find(xPlatform);

                        if (iPlatf >= 0)

                        {

                            cmb_Platform.SelectedIndex = iPlatf;

                        }

                    }



                    dgvx_SelectedExecutablesInSolution.DataSource = null;

                    foreach (Microsoft.Build.Construction.ProjectInSolution proj in _solutionFile.ProjectsInOrder)

                    {

                        if (proj.ProjectType == SolutionProjectType.KnownToBeMSBuildFormat)

                        {





                            Microsoft.Build.Evaluation.Project project = new Microsoft.Build.Evaluation.Project(proj.AbsolutePath);



                            project.SetProperty("Configuration", this.ConfigurationName);

                            project.SetProperty("Platform", this.Platform);

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

                                    txt_Projects.Text += OutputType + " :: " + sBinPathAndFullName + "\r\n";

                                }

                            }

                            else

                            {

                                MessageBox.Show("ERROR:OutputType :" + OutputType + " not supported !");

                            }

                        }

                    }

                    dgvx_SelectedExecutablesInSolution.DataSource = dtSelectExecutablesInSolution;

                    foreach (DataGridViewColumn dgvc in dgvx_SelectedExecutablesInSolution.Columns)

                    {

                        dgvc.ReadOnly = true;

                    }

                    dgvx_SelectedExecutablesInSolution.Columns[dcln_select].ReadOnly = false;

                    return true;



                }

                return false;

            }







            private void AddConfiguration(string configurationName)

            {

                if (cmb_Configuration_Items_Find(configurationName) < 0)

                {

                    cmb_Configuration.Items.Add(configurationName);

                }

            }



            private int cmb_Configuration_Items_Find(string configurationName)

            {

                int iCount = cmb_Configuration.Items.Count;

                int i = 0;

                for (i = 0; i < iCount; i++)

                {

                    string sitm = (string)cmb_Configuration.Items[i];

                    if (sitm.Equals(configurationName))

                    {

                        return i;

                    }

                }

                return -1;

            }



            private void AddPlatform(string platform)

            {

                if (cmb_Platform_Items_Find(platform) < 0)

                {

                    cmb_Platform.Items.Add(platform);

                }

            }



            private int cmb_Platform_Items_Find(string platform)

            {

                int iCount = cmb_Platform.Items.Count;

                int i = 0;

                for (i = 0; i < iCount; i++)

                {

                    string sitm = (string)cmb_Platform.Items[i];

                    if (sitm.Equals(platform))

                    {

                        return i;

                    }

                }

                return -1;

            }





            private void usrc_SelectFile1_ExistingFileChanged(string SolutionFileName)

            {

                this.solution_file = SolutionFileName;

                this.cmb_Configuration.SelectedIndexChanged -= new System.EventHandler(this.cmb_Configuration_SelectedIndexChanged);

                this.cmb_Platform.SelectedIndexChanged -= new System.EventHandler(this.cmb_Platform_SelectedIndexChanged);

                ParseSolutionFile(solution_file, this.ConfigurationName, this.Platform);

                this.cmb_Configuration.SelectedIndexChanged += new System.EventHandler(this.cmb_Configuration_SelectedIndexChanged);

                this.cmb_Platform.SelectedIndexChanged += new System.EventHandler(this.cmb_Platform_SelectedIndexChanged);

            }



            private void cmb_Configuration_SelectedIndexChanged(object sender, EventArgs e)

            {

                int iSelectedIndex = cmb_Configuration.SelectedIndex;

                if (iSelectedIndex >= 0)

                {

                    this.ConfigurationName = (string)cmb_Configuration.Items[iSelectedIndex];

                    Properties.Settings.Default.ConfigurationName = this.ConfigurationName;

                    Properties.Settings.Default.Save();

                    cmb_Configuration.SelectedIndex = iSelectedIndex;

                    this.cmb_Configuration.SelectedIndexChanged -= new System.EventHandler(this.cmb_Configuration_SelectedIndexChanged);

                    this.cmb_Platform.SelectedIndexChanged -= new System.EventHandler(this.cmb_Platform_SelectedIndexChanged);

                    ParseSolutionFile(solution_file, this.ConfigurationName, this.Platform);

                    this.cmb_Configuration.SelectedIndexChanged += new System.EventHandler(this.cmb_Configuration_SelectedIndexChanged);

                    this.cmb_Platform.SelectedIndexChanged += new System.EventHandler(this.cmb_Platform_SelectedIndexChanged);



                }

            }



            private void Form1_Load(object sender, EventArgs e)

            {

                usrc_SelectFile1.FireEvent_ExistingFileChanged();

            }



            private void cmb_Platform_SelectedIndexChanged(object sender, EventArgs e)

            {

                int iSelectedIndex = cmb_Platform.SelectedIndex;

                if (iSelectedIndex >= 0)

                {

                    this.Platform = (string)cmb_Platform.Items[iSelectedIndex];

                    Properties.Settings.Default.Platform = this.Platform;

                    Properties.Settings.Default.Save();

                    cmb_Platform.SelectedIndex = iSelectedIndex;

                    this.cmb_Configuration.SelectedIndexChanged -= new System.EventHandler(this.cmb_Configuration_SelectedIndexChanged);

                    this.cmb_Platform.SelectedIndexChanged -= new System.EventHandler(this.cmb_Platform_SelectedIndexChanged);

                    ParseSolutionFile(solution_file, this.ConfigurationName, this.Platform);

                    this.cmb_Configuration.SelectedIndexChanged += new System.EventHandler(this.cmb_Configuration_SelectedIndexChanged);

                    this.cmb_Platform.SelectedIndexChanged += new System.EventHandler(this.cmb_Platform_SelectedIndexChanged);
                }
            }
        }
    }
