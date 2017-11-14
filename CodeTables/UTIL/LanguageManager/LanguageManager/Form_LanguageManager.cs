using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DataGridView_2xls;

namespace LanguageManager
{
    public partial class Form_LanguageManager : Form
    {
        string[] SelectedProjects = null;

        public Form_LanguageManager()
        {
            InitializeComponent();
            string SolutionFileName = null;
            string SolutionPath = null;

            Parser.Init(ref SolutionPath, ref SolutionFileName);

            usrc_SelectFile1.FileName = SolutionFileName;
            usrc_SelectFile1.Path = SolutionPath;
        }

        public void ParseSelectedProjects()
        {
            dgvx_Libraries.DataSource = null;
            string sout = null;
            string Err = null;
            if (Parser.GetSelectedProjectDependencies(ref sout, ref Err))
            {
                txt_Projects.Text = sout;
                dgvx_Libraries.DataSource = Parser.dtLibraries;
                //dgvx_ExternalDLLReferences.DataSource = Parser.dtExternalDll;
            }
            else
            {
                MessageBox.Show(this, "ERROR:" + Err);
            }
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
            Parser.SolutionFile = SolutionFileName;

            this.cmb_Configuration.SelectedIndexChanged -= new System.EventHandler(this.cmb_Configuration_SelectedIndexChanged);

            this.cmb_Platform.SelectedIndexChanged -= new System.EventHandler(this.cmb_Platform_SelectedIndexChanged);

            string sTextOut = txt_Projects.Text;

            cmb_Configuration.DataSource = null;
            cmb_Platform.DataSource = null;
            dgvx_SelectedExecutablesInSolution.DataSource = null;

            Parser.ParseSolutionFile(ref sTextOut);
            dgvx_SelectedExecutablesInSolution.DataSource = Parser.dtSelectExecutablesInSolution;

            foreach (DataGridViewColumn dgvc in dgvx_SelectedExecutablesInSolution.Columns)
            {
                dgvc.ReadOnly = true;
            }

            dgvx_SelectedExecutablesInSolution.Columns[Parser.dcln_select].ReadOnly = false;


            cmb_Configuration.DataSource = Parser.Configurations.Items;
            cmb_Configuration.DisplayMember = "Name";

            cmb_Platform.DataSource = Parser.Platforms.Items;
            cmb_Platform.DisplayMember = "Name";

            this.cmb_Configuration.SelectedIndex = Parser.Configurations.SelectedIndex;
            this.cmb_Platform.SelectedIndex = Parser.Platforms.SelectedIndex;


            this.cmb_Configuration.SelectedIndexChanged += new System.EventHandler(this.cmb_Configuration_SelectedIndexChanged);

            this.cmb_Platform.SelectedIndexChanged += new System.EventHandler(this.cmb_Platform_SelectedIndexChanged);

        }



        private void cmb_Configuration_SelectedIndexChanged(object sender, EventArgs e)

        {
            int iSelectedIndex = cmb_Configuration.SelectedIndex;
            if (iSelectedIndex >= 0)
            {
                Parser.SetConfiguration(iSelectedIndex);

                cmb_Configuration.SelectedIndex = iSelectedIndex;

                this.cmb_Configuration.SelectedIndexChanged -= new System.EventHandler(this.cmb_Configuration_SelectedIndexChanged);

                this.cmb_Platform.SelectedIndexChanged -= new System.EventHandler(this.cmb_Platform_SelectedIndexChanged);

                string sTextOut = "";
                Parser.ParseSolutionFile(ref sTextOut);
                txt_Projects.Text += sTextOut;


                this.cmb_Configuration.SelectedIndexChanged += new System.EventHandler(this.cmb_Configuration_SelectedIndexChanged);

                this.cmb_Platform.SelectedIndexChanged += new System.EventHandler(this.cmb_Platform_SelectedIndexChanged);

            }
        }


        private void cmb_Platform_SelectedIndexChanged(object sender, EventArgs e)
        {

            int iSelectedIndex = cmb_Platform.SelectedIndex;

            if (iSelectedIndex >= 0)

            {

                Parser.SetPlatform(iSelectedIndex);

                cmb_Platform.SelectedIndex = iSelectedIndex;

                this.cmb_Configuration.SelectedIndexChanged -= new System.EventHandler(this.cmb_Configuration_SelectedIndexChanged);

                this.cmb_Platform.SelectedIndexChanged -= new System.EventHandler(this.cmb_Platform_SelectedIndexChanged);

                string sTextOut = "";
                Parser.ParseSolutionFile(ref sTextOut);
                txt_Projects.Text += sTextOut;

                this.cmb_Configuration.SelectedIndexChanged += new System.EventHandler(this.cmb_Configuration_SelectedIndexChanged);

                this.cmb_Platform.SelectedIndexChanged += new System.EventHandler(this.cmb_Platform_SelectedIndexChanged);
            }
        }

        private void lbl_ConfigurationName_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer3_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form_LanguageManager_Load(object sender, EventArgs e)
        {
            usrc_SelectFile1.FireEvent_ExistingFileChanged();
            SelectedProjects = Properties.Settings.Default.SelectedProjects.Split(';');
            if (SelectedProjects != null)
            {
                bool bEmpty = true;
                foreach (string s in SelectedProjects)
                {
                    if (s != null)
                    {
                        if (s.Length > 0)
                        {
                            bEmpty = false;
                        }
                    }
                }
                if (!bEmpty)
                {
                    Parser.SelectProjects(SelectedProjects);
                    ParseSelectedProjects();
                    AllSourceFiles();
                    CreateLanguageDictionary();
                }
            }
        }

        private void CreateLanguageDictionary()
        {
            Microsoft.Build.Evaluation.Project LanguageControlProject = Parser.FindLanguageControlProject();
            if (LanguageControlProject != null)
            {
                if (Parser.dtSourceFiles != null)
                {
                    Parser.dtSourceFiles.Clear();
                }
                dgvx_SourceFiles.DataSource = null;
                Parser.ParseProjectSourceFiles(LanguageControlProject);
                dgvx_SourceFiles.DataSource = Parser.dtSourceFiles;
                if (Parser.dtDictionary != null)
                {
                    Parser.dtDictionary.Clear();
                }
                dgvx_ltext.DataSource = null;
                Parser.ParseProjectLanguageControlSourceFiles();
                dgvx_ltext.DataSource = Parser.dtDictionary;
            }

        }

  

        private void dgvx_SelectedExecutablesInSolution_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvx_SelectedExecutablesInSolution.Columns[Parser.dcln_select].Index)
            {
                Properties.Settings.Default.SelectedProjects = Parser.ProjectsSeclected();
                Properties.Settings.Default.Save();
                ParseSelectedProjects();
            }
        }

        private void dgvx_SelectedExecutablesInSolution_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dgvx_SelectedExecutablesInSolution.Columns[Parser.dcln_select].Index)
            {
                dgvx_SelectedExecutablesInSolution.EndEdit();
            }
        }

        private void dgvx_Libraries_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Microsoft.Build.Evaluation.Project proj = (Microsoft.Build.Evaluation.Project)Parser.dtLibraries.Rows[e.RowIndex][Parser.dcol_Project];
                if (Parser.dtSourceFiles != null)
                {
                    Parser.dtSourceFiles.Clear();
                }
                dgvx_SourceFiles.DataSource = null;
                Parser.ParseProjectSourceFiles(proj);
                dgvx_SourceFiles.DataSource = Parser.dtSourceFiles;
                lbl_SourceFiles.Text = "Source files for:" + proj.FullPath;
            }

        }

        private void AllSourceFiles()
        {
            if (Parser.dtSourceFiles != null)
            {
                Parser.dtSourceFiles.Clear();
            }
            dgvx_SourceFiles.DataSource = null;
            foreach (DataRow dr in Parser.dtLibraries.Rows)
            {
                Microsoft.Build.Evaluation.Project proj = (Microsoft.Build.Evaluation.Project)dr[Parser.dcol_Project];
                Parser.ParseProjectSourceFiles(proj);
            }
            dgvx_SourceFiles.DataSource = Parser.dtSourceFiles;
            lbl_SourceFiles.Text = "Source files for all solution";

            // disable cell selection
            foreach (DataGridViewCell cell in this.dgvx_SourceFiles.SelectedCells)
                cell.Selected = false;
            // disable row selection
            foreach (DataGridViewRow row in this.dgvx_SourceFiles.SelectedRows)
                row.Selected = false;
            // disable column selection
            foreach (DataGridViewColumn col in this.dgvx_SourceFiles.SelectedColumns)
                col.Selected = false;

        }

        private void btn_AllSourceFiles_Click(object sender, EventArgs e)
        {
            AllSourceFiles();
        }

        private void dgvx_ltext_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
