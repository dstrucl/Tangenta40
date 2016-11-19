﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolutionExplorer
{
    public partial class Form_NSIS_Setup : Form
    {
        Form_SolutionExplorer m_Form_SolutionExplorer = null;
        public Form_NSIS_Setup(Form_SolutionExplorer xForm_SolutionExplorer)
        {
            InitializeComponent();
            m_Form_SolutionExplorer = xForm_SolutionExplorer;
            usrc_SelectFile_NSIS_Script_Template.Path = Properties.Settings.Default.NSIS_Script_Path_of_Template;
            usrc_SelectFile_NSIS_Script_Template.FileName = Properties.Settings.Default.NSIS_Script_FileName_of_Template;
            usrc_SelectFile_NSIS_Script_File.Path = Properties.Settings.Default.NSIS_Script_Path;
            usrc_SelectFile_NSIS_Script_File.FileName = Properties.Settings.Default.NSIS_Script_FileName;
            if (System.IO.File.Exists(usrc_SelectFile_NSIS_Script_Template.PathWithFileName))
            {
                txt_NSIS_Script_File_Template.LoadFile(usrc_SelectFile_NSIS_Script_Template.PathWithFileName, true, true);
            }
            if (System.IO.File.Exists(usrc_SelectFile_NSIS_Script_File.PathWithFileName))
            {
                txt_NSIS_Script_File.LoadFile(usrc_SelectFile_NSIS_Script_File.PathWithFileName, true, true);
            }
        }

        private void lbl_NSIS_Script_Template_Click(object sender, EventArgs e)
        {

        }

        private void Form_NSIS_Setup_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_Form_SolutionExplorer.Form_NSIS = null;
        }

        private void usrc_SelectFile_NSIS_Script_Template_ExistingFileChanged(string xFileName)
        {
            Properties.Settings.Default.NSIS_Script_Path_of_Template = usrc_SelectFile_NSIS_Script_Template.Path;
            Properties.Settings.Default.NSIS_Script_FileName_of_Template = usrc_SelectFile_NSIS_Script_Template.FileName;
            Properties.Settings.Default.Save();
            txt_NSIS_Script_File_Template.LoadFile(xFileName, true, true);
        }

        private void usrc_SelectFile_NSIS_Script_File_ExistingFileChanged(string xFileName)
        {
            Properties.Settings.Default.NSIS_Script_Path = usrc_SelectFile_NSIS_Script_File.Path;
            Properties.Settings.Default.NSIS_Script_FileName_of_Template = usrc_SelectFile_NSIS_Script_Template.FileName;
            Properties.Settings.Default.Save();
            txt_NSIS_Script_File.LoadFile(xFileName, true, true);
        }
    }
}
