﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanguageManager
{
    public partial class Form_ViewGetingReferencesProgress : Form
    {
        string sselected_executable_path = null;
        string sFile = null;
        public Form_ViewGetingReferencesProgress()
        {
            InitializeComponent();
        }

        private void ShowProgress(string comment,ltext_var_reference lvar,string Result)
        {
            string s = comment + lvar.Class_and_Var + " : " + Result;

            this.txt_output.Text = s + "\r\n\r\n" + this.txt_output.Text;
            this.txt_output.Refresh();
            Application.DoEvents();
            SaveLoginaReferences(sFile);           
        }

        private void Form_ViewGetingReferencesProgress_Shown(object sender, EventArgs e)
        {
            sselected_executable_path = Parser.SelectedExecutableSolutionPath();
            sFile = sselected_executable_path + "\\LanguageReferences.txt";
            Parser.GetAllReferences(ShowProgress);
            if (SaveLoginaReferences(sFile))
            {
                MessageBox.Show(this, "Language references are saved to " + sFile+ " OK.");
            }
           
        }

        private bool SaveLoginaReferences(string xFile)
        {
            try
            {
                File.WriteAllText(xFile, this.txt_output.Text);
                return true;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Can not save " + sFile + "\r\n Exception =" + ex.Message);
                return false;
            }
        }
    }
}
