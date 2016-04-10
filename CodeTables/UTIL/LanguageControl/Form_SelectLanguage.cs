using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LanguageControl
{
    public partial class Form_SelectLanguage : Form
    {
        Icon Program_Icon = null;
        string Program_name = null;
        public Form_SelectLanguage(Icon xProgram_Icon, string xProgram_name, int Language_ID)
        {
            InitializeComponent();
            Program_Icon = xProgram_Icon;
            Program_name = xProgram_name;
            if (Program_name != null)
            {
                lbl_ProgramName.Text = Program_name;
            }
            if (Program_Icon != null)
            {
                this.pic_Program_Icon.Image = Program_Icon.ToBitmap();
            }
            foreach (string slang in DynSettings.s_language.sTextArr)
            {
                if (slang!=null)
                {
                    cmb_Language.Items.Add(slang);
                }
            }
            if (Language_ID >= 0)
            {
                if (Language_ID < cmb_Language.Items.Count)
                {
                    cmb_Language.SelectedIndex = Language_ID;
                }
                else
                {
                    SelectLanguageOnCultureInfo();
                }
            }
            else
            {
                SelectLanguageOnCultureInfo();
            }
        }

        private void SelectLanguageOnCultureInfo()
        {
            CultureInfo ci = CultureInfo.CurrentUICulture;
            if (ci != null)
            {
                if (ci.Name.Contains("sl-"))
                {
                    cmb_Language.SelectedIndex = 1;
                }
                else
                {
                    cmb_Language.SelectedIndex = 0;
                }
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DynSettings.LanguageID = cmb_Language.SelectedIndex;
            this.Close();
            DialogResult = DialogResult.OK;
        }
    }
}
