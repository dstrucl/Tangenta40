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
    public partial class Form_INNO_Setup : Form
    {
        Form_SolutionExplorer m_Form_SolutionExplorer = null;
        INNOScriptTemplateParser INNO_parser = new INNOScriptTemplateParser();

        public Form_INNO_Setup(Form_SolutionExplorer xForm_SolutionExplorer)
        {
            InitializeComponent();
            m_Form_SolutionExplorer = xForm_SolutionExplorer;
            usrc_SelectFile_INNO_Script_Template.Path = Properties.Settings.Default.INNO_Script_Path_of_Template;
            usrc_SelectFile_INNO_Script_Template.FileName = Properties.Settings.Default.INNO_Script_FileName_of_Template;
            usrc_SelectFile_INNO_Script_File.Path = Properties.Settings.Default.INNO_Script_Path;
            usrc_SelectFile_INNO_Script_File.FileName = Properties.Settings.Default.INNO_Script_FileName;
            if (System.IO.File.Exists(usrc_SelectFile_INNO_Script_Template.PathWithFileName))
            {
                txt_INNO_Script_File_Template.LoadFile(usrc_SelectFile_INNO_Script_Template.PathWithFileName, true, true);
            }
            if (System.IO.File.Exists(usrc_SelectFile_INNO_Script_File.PathWithFileName))
            {
                txt_INNO_Script_File.LoadFile(usrc_SelectFile_INNO_Script_File.PathWithFileName, true, true);
            }
        }


        private void Form_INNO_Setup_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_Form_SolutionExplorer.Form_INNO = null;
        }

        private void usrc_SelectFile_INNO_Script_Template_ExistingFileChanged(string xFileName)
        {
            Properties.Settings.Default.INNO_Script_Path_of_Template = usrc_SelectFile_INNO_Script_Template.Path;
            Properties.Settings.Default.INNO_Script_FileName_of_Template = usrc_SelectFile_INNO_Script_Template.FileName;
            Properties.Settings.Default.Save();
            txt_INNO_Script_File_Template.LoadFile(xFileName, true, true);
        }

        private void usrc_SelectFile_INNO_Script_File_ExistingFileChanged(string xFileName)
        {
            Properties.Settings.Default.INNO_Script_Path = usrc_SelectFile_INNO_Script_File.Path;
            Properties.Settings.Default.INNO_Script_FileName_of_Template = usrc_SelectFile_INNO_Script_Template.FileName;
            Properties.Settings.Default.Save();
            txt_INNO_Script_File.LoadFile(xFileName, true, true);
        }

        private void btn_Build_INNO_Script_Click(object sender, EventArgs e)
        {
            string Err = null;
            txt_INNO_Script_File_Template.SaveFile(usrc_SelectFile_INNO_Script_Template.PathWithFileName);
            INNO_parser.DocumentText = txt_INNO_Script_File_Template.Text;
            string sFilesToInstallBlock = INNO_parser.FilesToInstallBlock(ref Err);
            string sFilesToUninstallBlock = "";// INNO_parser.FilesToUninstallBlock(ref Err);
            if (sFilesToInstallBlock != null)
            {
                string sNewScript = INNO_parser.ReplaceDocumentText(INNO_parser.Token_FilesToInstall, INNO_parser.DocumentText, sFilesToInstallBlock, ref Err);
//                sNewScript = INNO_parser.ReplaceDocumentText(INNO_parser.Token_FilesToUninstall, sNewScript, sFilesToUninstallBlock, ref Err);
                if (sNewScript==null)
                {
                    txt_INNO_Script_File.Text = null;
                    MessageBox.Show("ERROR:Script Not created:\r\n" + Err);
                }
                else
                {
                    txt_INNO_Script_File.Text = sNewScript;
                }
            }
            else
            {
                MessageBox.Show("ERROR:" + Err);
            }
        }
    }
}
