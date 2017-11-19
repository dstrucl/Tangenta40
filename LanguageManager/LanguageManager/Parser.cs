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

namespace LanguageManager
{
    public static class Parser
    {
        public delegate void delegate_find_reference_progress(string comment, ltext_project_reference lvar, string Result);
        public static string dcln_select = "Select";
        public static string dcln_ProjectPath = "ProjectPath";
        public static string dcln_ProjectObject = "ProjectObject";
        public static string dcln_AssemblyName = "AssemblyName";
        public static string dcln_NETVersion = "NETVersion";
        public static string dcln_GUID = "GUID";
        public static string dcln_Project = "Project";
        public static string dcln_ExternalDll_relative_path = "Relative Path";

     
        public static string dcln_ExternalDll_absolute_path = "Absolute Path";
        public static string dcln_ExternalDll_ref_assembly = "Referencing assembly";

        public static string dcln_SourceFile = "SourceFile";
        public static string dcln_SourceFileBaseDirectory = "SourceFileBaseDirectory";
        public static string dcln_SourceFileName = "SourceFileName";
        public static string dcln_SourceFileProject = "Project";

        public static string dcln_class_Name = "class_Name";
        public static string dcln_ltext_Name = "ltext_Name";
        public static string dcln_ltext_Initialisation = "Initialisation";

        public static DataColumn dcol_dtDictionary_SourceFile = null;
        public static DataColumn dcol_class_Name = null;
        public static DataColumn dcol_ltext_Name = null;
        public static DataColumn dcol_ltext_Initialisation = null;

        public static DataColumn dcol_ProjectPath = null;
        public static DataColumn dcol_ProjectObject = null;
        public static DataColumn dcol_AssemblyName = null;
        public static DataColumn dcol_NET_Version = null;

      

        public static DataColumn dcol_GUID = null;
        public static DataColumn dcol_Project = null;

        public static DataColumn dcol_SourceFile = null;
        public static DataColumn dcol_SourceFileBaseDirectory = null;
        public static DataColumn dcol_SourceFileName = null;
        public static DataColumn dcol_SourceFileProject = null;

        public static string SolutionFile = "";

        public static string ConfigurationName = "";

        public static string Platform = "";

        public static PlatformList Platforms = new PlatformList();

        public static ConfigurationList Configurations = new ConfigurationList();

        public static DataTable dtSelectExecutablesInSolution = null;

        public static DataTable dtLibraries = null;

        public static DataTable dtSourceFiles = null;

        public static DataTable dtDictionary = null;

        public static ltext_project_reference_List lText_project_reference_List = new ltext_project_reference_List();


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
                SolutionFilePath = "";
            }
        }

        internal static string SelectedExecutableSolutionPath()
        {
            return System.IO.Path.GetDirectoryName(Parser.SolutionFile); ;
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
                    GetProjectDependencies(iTabLevel + 1, ref_pr);
                }
                else
                {
                    MessageBox.Show("Project " + refprojfullpath + " not found in Microsoft.Build.Evaluation.ProjectCollection.GlobalProjectCollection.LoadedProjects!");
                }
            }
        }

        internal static List<Project> FindLanguageControledProjects()
        {
            List<Project> lprojects_with_lng_cs_file = new List<Project>();
            if (dtLibraries != null)
            {
                foreach (DataRow dr in dtLibraries.Rows)
                {
                    Project proj = (Project)dr[dcol_Project];
                    Parser.ParseProjectSourceFiles(proj);
                    int iSourceFilesCount_in_a_Project = dtSourceFiles.Rows.Count;
                    int isf = 1;
                    bool bFound = false;
                    foreach (DataRow drSourceFile in dtSourceFiles.Rows)
                    {

                        string xsource_file = (string)drSourceFile[dcln_SourceFile];
                        if (xsource_file.IndexOf("lng.cs") > 0)
                        {
                            bFound = true;
                            break;
                        }
                        isf++;
                    }
                    if (bFound)
                    {
                        lprojects_with_lng_cs_file.Add(proj);
                    }
                }
                if (lprojects_with_lng_cs_file.Count == 0)
                {
                    MessageBox.Show("LanguageControl not found!");
                }
                return lprojects_with_lng_cs_file;
            }
            else
            {
                MessageBox.Show("There are no libraries!");
            }
            return null;

        }

        public static bool GetSelectedProjectDependencies(ref string TextOutput, ref string Err)
        {
            TextOutput = "";

            if (dtLibraries == null)
            {
                dtLibraries = new DataTable();
                dcol_ProjectPath = new DataColumn(dcln_ProjectPath, typeof(string));
                dcol_AssemblyName = new DataColumn(dcln_AssemblyName, typeof(string));
                dcol_NET_Version = new DataColumn(dcln_NETVersion, typeof(string));
                dcol_GUID = new DataColumn(dcln_GUID, typeof(string));
                dcol_Project = new DataColumn(dcln_Project, typeof(object));

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

                    Parser.GetProjectDependencies(0, (Microsoft.Build.Evaluation.Project)dr[dcln_Project]);

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

                if (outputPath == null)
                {
                    Err = "Output path not found for Configuration=\"" + ConfigurationName + "\" Platform = " + Platform + "\r\n"
                          + "Hint: May be you don't have such configuration defined in project:" + proj.FullPath + ".\r\n Try to change Configuration and Platform.";
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

        internal static string GetAllReferences(delegate_find_reference_progress Show_Progress)
        {
            string sResult = "";
            string Error = null;
            if (dtDictionary != null)
            {
                if (dtLibraries != null)
                {


                    //lvar_Progress(iRowInDictionary.ToString()+" Start:", lvar,"");

                    int iCountLibraries = dtLibraries.Rows.Count;
                    int iRowInLibraries = 0;
                    int iLib = 1;
                    if (iCountLibraries > 0)
                    {
                        for (iRowInLibraries = iCountLibraries-1; iRowInLibraries >=0; iRowInLibraries--)
                        {
                            DataRow drLib = dtLibraries.Rows[iRowInLibraries];
                            string project_file = (string)drLib[dcln_ProjectPath];
                            Microsoft.Build.Evaluation.Project proj = (Microsoft.Build.Evaluation.Project)drLib[Parser.dcol_Project];
                            if (dtSourceFiles != null)
                            {
                                dtSourceFiles.Clear();
                            }

                            ltext_project_reference lt_proj = lText_project_reference_List.GetProject(project_file);
                            ParseProjectSourceFiles(proj);
                            //lvar_Progress("  Start:"+ project_file+":", lvar);
                            int iSourceFilesCount_in_a_Project = dtSourceFiles.Rows.Count;
                            int isf = 1;
                            foreach (DataRow drSourceFile in dtSourceFiles.Rows)
                            {

                                string xsource_file = (string)drSourceFile[dcln_SourceFile];
                                if (Ignore(xsource_file, new string[] { "lngConn.cs", "lngRPM.cs", "lngRPMS.cs", "lngTName.cs", "lngToken.cs" }))
                                {
                                    continue;
                                }
                                else
                                {
                                    GetVariableReference(project_file, xsource_file, lt_proj, ref Error);
                                }
                                Show_Progress("Searched: Library:" + iLib.ToString() + " of " + iCountLibraries.ToString() + " : " + project_file + " SOURCE FILES: " + isf.ToString() + " of " + iSourceFilesCount_in_a_Project.ToString() + "\r\n", lt_proj, " : " + xsource_file);
                                isf++;
                            }

                            iLib++;
                        }
                    }
                    string sProject = null;
                    int iProject = 0;
                    int iProjectsCount = 0;

                    int iReferences = 0;
                    iProjectsCount = lText_project_reference_List.project_reference_list.Count();

                    for (iProject = 0; iProject < iProjectsCount; iProject++)
                    {
                        ltext_project_reference projref = lText_project_reference_List.project_reference_list[iProject];
                        int iproj = iProject + 1;
                        if (sProject == null)
                        {
                            sProject = iproj.ToString() + "   PROJECT:\r\n    " + projref.Project_name;
                        }
                        else
                        {
                            sProject = "\r\n" + iproj.ToString() + "   PROJECT:\r\n    " + projref.Project_name;
                        }

                        
                        string sSourceFile = null;

                        foreach (ltext_source_file_reference sf in projref.source_file_reference_list)
                        {
                            if (sSourceFile == null)
                            {
                                sSourceFile = "\r\n    SOURCE FILES:\r\n           " + sf.Source_file;
                            }
                            else
                            {
                                sSourceFile += "\r\n           " + sf.Source_file;
                            }

                            string slvr = "";
                            foreach (ltext_var_reference lvr in sf.var_ltext_reference_List)
                            {
                                if (slvr.Length == 0)
                                {
                                    slvr = "\r\n    ltext variables:\r\n           " + lvr.Class_and_Var;
                                }
                                else
                                {
                                    slvr += "\r\n                    " + lvr.Class_and_Var;
                                }
                                string spositions = null;
                                iReferences += lvr.Positions.Count;
                                foreach (int ixpos in lvr.Positions)
                                {
                                    if (spositions == null)
                                    {
                                        spositions = " -> "+ ixpos.ToString();
                                    }
                                    else
                                    {
                                        spositions += " , " + ixpos.ToString();
                                    }
                                }
                                slvr += spositions;
                            }
                            sSourceFile += slvr;
                        }
                        sProject += sSourceFile;
                        sResult += sProject;
                    }
                               

                }
                else
                {
                    sResult = "Can not get references because dtLibraries is not created! ";
                }
            }
            else
            {
                sResult = "Can not get references because dtDictionary is not created! ";
            }
            return sResult;
        }

        private static void GetVariableReference(string project_file, string xsource_file, ltext_project_reference lt_proj, ref string Error)
        {
            try
            {
                string sSourceText = File.ReadAllText(xsource_file);
                ltext_source_file_reference lt_sfr = lt_proj.GetSourceFile(xsource_file);
                int iCountInDictionary = dtDictionary.Rows.Count;
                int iRowInDictionary = 0;
                for (iRowInDictionary = 0; iRowInDictionary < iCountInDictionary; iRowInDictionary++)
                {
                    DataRow drDic = dtDictionary.Rows[iRowInDictionary];
                    string sClassName = (string)drDic[dcln_class_Name];
                    string sVarName = (string)drDic[dcln_ltext_Name];
                    string sConstructor_Call = (string)drDic[dcln_ltext_Initialisation];
                    int iCurrentPos = 0;
                    int iWordPos = 0;
                    while (GetWholeWordPos(sClassName+"."+ sVarName, ref iCurrentPos, ref iWordPos, ref sSourceText))
                    {
                        ltext_var_reference lvar = lt_sfr.Get_ltext_var_reference(sClassName, sVarName, sConstructor_Call);
                        lvar.Positions.Add(iWordPos);
                    }
                }
               

            }
            catch (Exception ex)
            {
                string msg = "Can not read file:" + xsource_file + "\r\nException=" + ex.Message +"\r\n";
                if (Error == null)
                {
                    Error = msg;
                }
                else
                {
                    if (!Error.Contains(msg))
                    {
                        Error += msg;
                    }
                    
                }  
           }
        }

        private static bool GetWholeWordPos(string class_and_Var,ref int iCurrentPos, ref int iWordPos, ref string sSourceText)
        {
            int index = sSourceText.IndexOf(class_and_Var, iCurrentPos);
            if (index >=0)
            {
                // check if whole word
                int nextpos = index + class_and_Var.Length;
                if (nextpos < sSourceText.Length)
                {
                    // check next character
                    char ch = sSourceText[nextpos];
                    if (Char.IsLetterOrDigit(ch)||(ch=='_'))
                    {
                        return false;
                    }
                    else
                    {
                        iCurrentPos = index + class_and_Var.Length;
                        iWordPos = index;
                        return true;
                    }
                }
                else
                {
                    return false;
                }

            }
            return false;
        }

        private static bool Ignore(string svar, string[] sa)
        {
            foreach (string s in sa)
            {
                if (s.Equals(svar))
                {
                    return true;
                }
            }
            return false;
        }
        internal static void ParseProjectLanguageControlSourceFiles()
        { 
            foreach (DataRow dr in dtSourceFiles.Rows)
            {
                string source_file = (string)dr[dcol_SourceFile];
                ParseProjectLanguageControlSource(source_file);
            }
        }

        private static void ParseProjectLanguageControlSource(string source_file)
        {
            string[] SourceLines = null;
            if (source_file != null)
            {
                if (source_file.ToLower().IndexOf("lng.cs") >= 0)
                {
                    try
                    {
                        SourceLines = File.ReadAllLines(source_file);
                        Parser.RemoveComments(ref SourceLines);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Can not read " + source_file + "\r\nExecption=" + ex.Message);
                        return;
                    }
                    if (SourceLines != null)
                    {
                        int inext_token_line = 0;
                        int inext_token_start_col = 0;
                        string next_token = null;

                        GetLanguageClassMembersAs_dtDictionary(source_file, ref SourceLines, ref inext_token_line, ref inext_token_start_col, ref next_token);

                    }
                    return;
                }
                MessageBox.Show("ERROR:ParseProjectLanguageControlSource(string source_file):Not a valid Source file name :" + source_file + "\r\nLanguage definition source file must be lng.cs");
                return;
              }
            MessageBox.Show("ERROR:ParseProjectLanguageControlSource(string source_file):Not a valid Source file name is null!");
            return;

        }

        private static void RemoveComments(ref string[] sourceLines)
        {
            string line_comment = "//";
            string block_comment_start = "/*";
            string block_comment_end = "*/";
            int i = 0;
            int icount = sourceLines.Length;
            bool bblock_comment = false;
            while (i< icount)
            {
                if (!bblock_comment)
                {
                    int icol_line_comment = sourceLines[i].IndexOf(line_comment);
                    int icol_block_comment_start = sourceLines[i].IndexOf(block_comment_start);
                    if (((icol_block_comment_start >= 0) && ((icol_block_comment_start < icol_line_comment)&&(icol_line_comment>=0)))
                        || ((icol_block_comment_start >= 0)&&(icol_line_comment < 0))
                        )
                    {
                        //remove block comment
                        sourceLines[i] = sourceLines[i].Substring(0, icol_block_comment_start);
                        bblock_comment = true;

                    }
                    else if (icol_line_comment >= 0)
                    {
                        //remove line comment
                        sourceLines[i] = sourceLines[i].Substring(0, icol_line_comment);
                    }
                }
                else
                {
                    int icol_block_comment_end = sourceLines[i].IndexOf(block_comment_end);
                    if (icol_block_comment_end>=0)
                    {
                        sourceLines[i] = sourceLines[i].Substring(icol_block_comment_end + block_comment_end.Length);
                        bblock_comment = false;
                    }
                    else
                    {
                        sourceLines[i] = "";
                    }
                }
                i++;
            }
        }

        private static bool GetLanguageClassMembersAs_dtDictionary(string source_file,ref string[] sourceLines, ref int inext_token_line, ref int inext_token_start_col, ref string next_token)
        {
            string[] tokens = new string[] { "lng" };
            bool bFound = false;
            foreach (string token in tokens)
            {
                int xinext_token_line = 0;
                int xinext_token_start_col = 0;
                string[] tk_identifiers = new string[] { "public", "static", "class", token };
                int itk = 0;
                if (find_next_token(tk_identifiers,itk,ref sourceLines, ref xinext_token_line, ref xinext_token_start_col, ref next_token))
                {
                    
                    inext_token_line = xinext_token_line;
                    inext_token_start_col = xinext_token_start_col;
                    while (xinext_token_line < sourceLines.Count() - 1)
                    {
                        tk_identifiers = new string[] { "public", "static", "ltext" };
                        string var_name_of_ltext = null;
                        if (find_next_token(tk_identifiers, itk, ref sourceLines, ref xinext_token_line, ref xinext_token_start_col, ref var_name_of_ltext))
                        {

                            tk_identifiers = new string[] { "=", "new" };
                            if (find_next_token(tk_identifiers, itk, ref sourceLines, ref xinext_token_line, ref xinext_token_start_col, ref next_token))
                            {
                                string constructor_call = null;
                                if (Get_ltext_constructor_call(sourceLines, ref xinext_token_line, ref xinext_token_start_col, ref constructor_call))
                                {
                                    bFound = true;
                                    if (dtDictionary==null)
                                    {
                                        dtDictionary = new DataTable();
                                        dcol_dtDictionary_SourceFile = new DataColumn(dcln_SourceFile,typeof(string));
                                        dcol_class_Name = new DataColumn(dcln_class_Name,typeof(string));
                                        dcol_ltext_Name = new DataColumn(dcln_ltext_Name, typeof(string));
                                        dcol_ltext_Initialisation = new DataColumn(dcln_ltext_Initialisation, typeof(string));
                                        dtDictionary.Columns.Add(dcol_dtDictionary_SourceFile);
                                        dtDictionary.Columns.Add(dcol_class_Name);
                                        dtDictionary.Columns.Add(dcol_ltext_Name);
                                        dtDictionary.Columns.Add(dcol_ltext_Initialisation);
                                    }
                                    DataRow dr = dtDictionary.NewRow();
                                    dr[dcln_SourceFile] = source_file;
                                    dr[dcln_class_Name] = token;
                                    dr[dcln_ltext_Name] = var_name_of_ltext;
                                    dr[dcln_ltext_Initialisation] = constructor_call;
                                    dtDictionary.Rows.Add(dr);
                                    continue;
                                }
                            }
                        }
                    }
                }
            }
            return bFound;
        }

        private static bool Get_ltext_constructor_call(string[] sourceLines, ref int xinext_token_line, ref int xinext_token_start_col, ref string constructor_call)
        {
            char[] delimiters = new char[] { ')', ';' };
            int yinext_token_line = xinext_token_line;
            int yinext_token_start_col = xinext_token_start_col;
            int itk = 0;
            if (GetDelimiters(delimiters, itk, ref sourceLines, ref yinext_token_line,ref yinext_token_start_col))
            {
                int iline = xinext_token_line;
                int icol = xinext_token_start_col;
                string cons_call = sourceLines[iline].Substring(icol);
                while (iline <= yinext_token_line)
                {

                    
                    if (iline < yinext_token_line)
                    {
                        iline++;
                        
                        if (iline == yinext_token_line)
                        {
                            cons_call += "\r\n" + sourceLines[iline].Substring(0, yinext_token_start_col+1);
                        }
                        else
                        {
                            cons_call += "\r\n" + sourceLines[iline];
                        }
                    }
                    else
                    {
                        
                        break;
                    }

                }
                constructor_call = cons_call;
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool GetDelimiters(char[] delimiters,int itk, ref string[] sourceLines, ref int yinext_token_line, ref int yinext_token_start_col)
        {
            if (itk< delimiters.Length)
            {
                int idelimiter = sourceLines[yinext_token_line].IndexOf(delimiters[itk], yinext_token_start_col);
                if (idelimiter >= 0)
                {
                    itk++;
                    if (itk == delimiters.Length)
                    {
                        yinext_token_start_col = idelimiter;
                        return true;
                    }
                    else
                    {
                        if (GetDelimiters(delimiters, itk, ref sourceLines, ref yinext_token_line, ref yinext_token_start_col))
                        {
                            return true;
                        }
                        else
                        {
                            if (yinext_token_line < sourceLines.Length - 1)
                            {
                                yinext_token_line++;
                                yinext_token_start_col = 0;
                                return GetDelimiters(delimiters, itk, ref sourceLines, ref yinext_token_line, ref yinext_token_start_col);
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }

                }
                else
                {
                    if (yinext_token_line < sourceLines.Length - 1)
                    {
                        yinext_token_line++;
                        yinext_token_start_col = 0;
                        return GetDelimiters(delimiters, itk, ref sourceLines, ref yinext_token_line, ref yinext_token_start_col);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return true;
            }
        }


        private static bool find_next_token(string[] tk_identifiers, int itk, ref string[] sourceLines, ref int inext_token_line, ref int inext_token_start_col, ref string next_token)
        {


            string sline = sourceLines[inext_token_line];
            string tk = tk_identifiers[itk];
            int index = sline.IndexOf(tk, inext_token_start_col);
            if (index >= 0)
            {
                if (index + tk.Length < sline.Length)
                {
                    if (!IsDelimiter(sline[index + tk.Length]))
                    {
                        index = -1;
                    }
                }
            }
            if (index >= 0)
            {
                inext_token_start_col = index + tk.Length;
                while (itk < tk_identifiers.Count() - 1)
                {
                    itk++;
                    if (find_next_token(tk_identifiers, itk, ref sourceLines, ref inext_token_line, ref inext_token_start_col, ref next_token))
                    {
                        return true;
                    }
                    else
                    {
                        inext_token_line++;
                        while (inext_token_line < sourceLines.Count() - 1)
                        {
                            inext_token_start_col = 0;
                            if (find_next_token(tk_identifiers, itk, ref sourceLines, ref inext_token_line, ref inext_token_start_col, ref next_token))
                            {
                                return true;
                            }
                            else
                            {
                                inext_token_line++;
                                continue;
                            }
                        }
                        return false;
                    }

                }
                // all tokens found here
                // now get next token whatever it is;
                return GetNextToken(ref sourceLines, ref inext_token_line, ref inext_token_start_col, ref next_token);
            }
            else
            {
                // search in next line
                inext_token_line++;
                while (inext_token_line < sourceLines.Count() - 1)
                {
                    inext_token_start_col = 0;
                    if (find_next_token(tk_identifiers, itk, ref sourceLines, ref inext_token_line, ref inext_token_start_col, ref next_token))
                    {
                        return true;
                    }
                    else
                    {
                        inext_token_line++;
                        continue;
                    }                   
                }
                return false;
            }
        }

        private static bool IsDelimiter(char c)
        {
            return ((c == ' ') || (c == '{') || (c == '\r') || (c == '\n') || (c == '\t'));
        }


        // get next token what ever it is
        private static bool GetNextToken(ref string[] sourceLines, ref int inext_token_line, ref int inext_token_start_col, ref string next_token)
        {

           while (inext_token_line< sourceLines.Count()-1)
            {
                int i = inext_token_start_col;
                while (i< sourceLines[inext_token_line].Length)
                {
                    char ch = sourceLines[inext_token_line][i];
                    if (ch == ' '|| ch == '\t' || ch == '\r' || ch == '\n')
                    {
                        i++;
                    }
                    else
                    {
                        // here new token starts
                        inext_token_start_col = i;
                        next_token = GetToken(ref sourceLines, inext_token_line, inext_token_start_col);
                        return true;
                    }
                }
                inext_token_line++;
                inext_token_start_col = 0;
            }
            return false;
        }

        private static string GetToken(ref string[] sourceLines, int inext_token_line, int inext_token_start_col)
        {
            string token = "";
            int i = inext_token_start_col;
            while (i < sourceLines[inext_token_line].Length)
            {
                char ch = sourceLines[inext_token_line][i];
                if (ch == ' ' || ch == '\t' || ch == '\r' || ch == '\n')
                {
                    return token;
                }
                else
                {
                    token += ch;
                    i++;
                }
            }
            return token;
        }

        internal static void ParseProjectSourceFiles(Project proj)
        {
            foreach (ProjectItem pitm in proj.AllEvaluatedItems)
            {
                string sitem_type = pitm.ItemType;
                if (sitem_type.Equals("Compile"))
                {
                    if (dtSourceFiles == null)
                    {
                        dtSourceFiles = new DataTable();
                        dcol_SourceFileName = new DataColumn(dcln_SourceFileName, typeof(string));
                        dcol_SourceFileBaseDirectory = new DataColumn(dcln_SourceFileBaseDirectory, typeof(string));
                        dcol_SourceFile = new DataColumn(dcln_SourceFile, typeof(string));
                        dcol_SourceFileProject = new DataColumn(dcln_SourceFileProject, typeof(string));
                        dtSourceFiles.Columns.Add(dcol_SourceFileProject);
                        dtSourceFiles.Columns.Add(dcol_SourceFileName);
                        dtSourceFiles.Columns.Add(dcln_SourceFileBaseDirectory);
                        dtSourceFiles.Columns.Add(dcol_SourceFile);

                    }
                    string source_file = proj.DirectoryPath + "\\" + pitm.EvaluatedInclude;
                    DataRow dr = dtSourceFiles.NewRow();
                    dr[dcln_SourceFileProject] = Path.GetFileName(proj.FullPath);
                    dr[dcln_SourceFileName] = pitm.EvaluatedInclude;
                    dr[dcln_SourceFileBaseDirectory] = Path.GetDirectoryName(proj.FullPath);
                    dr[dcln_SourceFile] = source_file;
                    dtSourceFiles.Rows.Add(dr);
                }
            }
            
        }
        internal static void ParseProjectListSourceFiles(List<Project> projlist)
        {
            foreach (Project proj in projlist)
            {
                foreach (ProjectItem pitm in proj.AllEvaluatedItems)
                {
                    string sitem_type = pitm.ItemType;
                    if (sitem_type.Equals("Compile"))
                    {
                        string file_name = pitm.EvaluatedInclude;
                        if (file_name.ToLower().IndexOf("lng.cs")>=0)
                        {
                            if (dtSourceFiles == null)
                            {
                                dtSourceFiles = new DataTable();
                                dcol_SourceFileName = new DataColumn(dcln_SourceFileName, typeof(string));
                                dcol_SourceFileBaseDirectory = new DataColumn(dcln_SourceFileBaseDirectory, typeof(string));
                                dcol_SourceFile = new DataColumn(dcln_SourceFile, typeof(string));
                                dcol_SourceFileProject = new DataColumn(dcln_SourceFileProject, typeof(string));
                                dtSourceFiles.Columns.Add(dcol_SourceFileProject);
                                dtSourceFiles.Columns.Add(dcol_SourceFileName);
                                dtSourceFiles.Columns.Add(dcln_SourceFileBaseDirectory);
                                dtSourceFiles.Columns.Add(dcol_SourceFile);

                            }
                            string source_file = proj.DirectoryPath + "\\" + pitm.EvaluatedInclude;
                            DataRow dr = dtSourceFiles.NewRow();
                            dr[dcln_SourceFileProject] = Path.GetFileName(proj.FullPath);
                            dr[dcln_SourceFileName] = pitm.EvaluatedInclude;
                            dr[dcln_SourceFileBaseDirectory] = Path.GetDirectoryName(proj.FullPath);
                            dr[dcln_SourceFile] = source_file;
                            dtSourceFiles.Rows.Add(dr);
                        }
                    }
                }
            }
        }

      

        internal static string ProjectsSeclected()
        {
            string selected_projects = "";
            foreach (DataRow dr in dtSelectExecutablesInSolution.Rows)
            {
                if ((bool)dr[dcln_select] == true)
                {
                    if (dr[dcln_ProjectPath] is string)
                    {
                        if (selected_projects.Length == 0)
                        {
                            selected_projects = (string)dr[dcln_ProjectPath];
                        }
                        else
                        {
                            selected_projects += ";" + (string)dr[dcln_ProjectPath];
                        }
                    }
                }
            }
            return selected_projects;
        }


    internal static void SelectProjects(string[] selectedProjects)
        {
            if (selectedProjects != null)
            {
                foreach (string sProject in selectedProjects)
                {
                    if (sProject != null)
                    {
                        if (sProject.Length > 0)
                        {
                            foreach (DataRow dr in dtSelectExecutablesInSolution.Rows)
                            {
                                dr[dcln_select] = false;
                                if (dr[dcln_ProjectPath] is string)
                                {
                                    if (sProject.Equals((string)dr[dcln_ProjectPath]))
                                    {
                                        dr[dcln_select] = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
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

        internal static void Write_lng_files()
        {
            foreach (ltext_project_reference lt_proj in lText_project_reference_List.project_reference_list)
            {

                if (lt_proj.LanguageTextCount > 0)
                {
                    string s_AssemblyName = Path.GetFileNameWithoutExtension(lt_proj.Project_name);
                    string slngfile_path = Path.GetDirectoryName(lt_proj.Project_name);
                    string slngfile = slngfile_path + "\\lng.cs";
                    string slngs = null;
                    try
                    {
                        List<Ordered_ltext_position> lordered_List = new List<Ordered_ltext_position>();
                        foreach (ltext_source_file_reference lsf in lt_proj.source_file_reference_list)
                        {
                            if (lsf.var_ltext_reference_List.Count > 0)
                            {
                                if (slngs == null)
                                {
                                    slngs = Properties.Resources.lng_Header;
                                    slngs = slngs.Replace("/*LanguageControl*/", s_AssemblyName);
                                }

                                lordered_List.Clear();
                                foreach (ltext_var_reference lvr in lsf.var_ltext_reference_List)
                                {
                                    slngs += lvr.Static_ltext_Definition() + "   // referenced in " + lsf.Source_file + "\r\n";
                                    lvr.AddPositions(lordered_List);
                                }

                                ReplaceInSourceFile(lsf.Source_file, lordered_List);
                            }
                        }
                        slngs += "\r\n  }\r\n}\r\n";
                        File.WriteAllText(slngfile, slngs);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Can not write " + slngfile_path + "\r\nExcpetion=" + ex.Message);
                    }
                }
            }
        }
            

        internal static void ReplaceInSourceFile(string source_file, List<Ordered_ltext_position> lordered_List)
        {
            try
            {
                string src = File.ReadAllText(source_file);
              

                int iCount = lordered_List.Count;
                if (iCount > 0)
                {
                    for (int i = iCount - 1; i >= 0; i--)
                    {
                        Ordered_ltext_position op = lordered_List[i];
                        int iPos = op.iPos;
                        int iLenClassAndVar = op.Class_and_Var.Length;
                        src = src.Substring(0, iPos) + "lng." + op.Var_name + src.Substring(iPos + iLenClassAndVar);
                    }
                }
                File.WriteAllText(source_file, src);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not read or write " + source_file + "\r\nException ex =" + ex.Message);
            }
        }
    }
}
