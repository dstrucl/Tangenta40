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


namespace SolutionExplorer
{
    public partial class Form_SolutionExplorer : Form
    {
        internal Form_NSIS_Setup Form_NSIS = null;
        internal Form_INNO_Setup Form_INNO = null;
        string[] SelectedProjects = null;

        public Form_SolutionExplorer()
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
            dgvx_ExternalDLLReferences.DataSource = null;
            dgvx_Libraries.DataSource = null;
            string sout = null;
            string Err = null;
            if (Parser.GetSelectedProjectDependencies(ref sout, ref Err))
            {
                txt_Projects.Text = sout;
                dgvx_Libraries.DataSource = Parser.dtLibraries;
                dgvx_ExternalDLLReferences.DataSource = Parser.dtExternalDll;
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

        private void btn_NSIS_Click(object sender, EventArgs e)
        {
            if (Form_NSIS == null)
            {
                Form_NSIS = new Form_NSIS_Setup(this);
                Form_NSIS.Show();
            }
            else
            {
                Form_NSIS.Show();
            }
        }

        private void btn_INNO_Installer_Click(object sender, EventArgs e)
        {
            if(Form_INNO == null)
            {
                Form_INNO = new Form_INNO_Setup(this);
                Form_INNO.Show();
            }
            else
            {
                Form_INNO.Show();
            }

        }

        private void Form_SolutionExplorer_Load(object sender, EventArgs e)
        {
            usrc_SelectFile1.FireEvent_ExistingFileChanged();
            SelectedProjects = Properties.Settings.Default.SelectedProjects.Split(';');
            if (SelectedProjects != null)
            {
                bool bEmpty = true;
                foreach (string s in SelectedProjects)
                {
                    if (s!=null)
                    {
                        if (s.Length>0)
                        {
                            bEmpty = false;
                        }
                    }
                }
                if (!bEmpty)
                {
                    Parser.SelectProjects(SelectedProjects);
                    ParseSelectedProjects();
                }
            }
        }

        private void dgvx_SelectedExecutablesInSolution_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

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
    }
}
