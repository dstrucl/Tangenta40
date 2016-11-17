using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Build.Construction;

namespace SolutionExport
{
    public partial class Form1 : Form
    {
        string solution_file = "";
        string ConfigurationName = "";
        string Platform = "";

        public Form1()
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
            string SolutionFile = usrc_SelectFile1.PathWithFileName;
        }

        public bool ParseSolutionFile(string SolutionFile, string xConfigurationName,string Platform)
        {
            txt_Projects.Text = "";
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
                if (iConf>=0)
                {
                    cmb_Configuration.SelectedIndex = iConf;
                }

                foreach (Microsoft.Build.Construction.SolutionConfigurationInSolution sol in sol_configs)
                {
                    if (sol.ConfigurationName.Equals(xConfigurationName))
                    {
                        txt_Projects.Text += sol.ConfigurationName + "  Platform:" + sol.PlatformName + ";\r\n";
                    }
                }

                return true;

            }
            return false;
        }



        private void AddConfiguration(string configurationName)
        {
            if (cmb_Configuration_Items_Find(configurationName)<0)
            {
                cmb_Configuration.Items.Add(configurationName);
            }
        }

        private int cmb_Configuration_Items_Find(string configurationName)
        {
            int iCount = cmb_Configuration.Items.Count;
            int i = 0;
            for (i=0;i<iCount;i++)
            {
                string sitm = (string)cmb_Configuration.Items[i];
                if (sitm.Equals(configurationName))
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
            ParseSolutionFile(solution_file, this.ConfigurationName,this.Platform);
            this.cmb_Configuration.SelectedIndexChanged += new System.EventHandler(this.cmb_Configuration_SelectedIndexChanged);
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
                ParseSolutionFile(solution_file, this.ConfigurationName, this.Platform);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            usrc_SelectFile1.FireEvent_ExistingFileChanged();
        }
    }
}
