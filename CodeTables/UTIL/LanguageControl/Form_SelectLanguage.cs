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
        List<Language> LanguageList = new List<Language> ();
        Image Image_Cancel = null;
        public Form_SelectLanguage(Icon xProgram_Icon, string xProgram_name, int Language_ID, Image xImage_Cancel)
        {
            InitializeComponent();
            Program_Icon = xProgram_Icon;
            Program_name = xProgram_name;
            Image_Cancel = xImage_Cancel;
            if (Program_Icon!= null)
            {
                this.Icon = Program_Icon;
            }
            
            if (Program_name != null)
            {
                lbl_ProgramName.Text = Program_name;
            }
            if (Program_Icon != null)
            {
                this.pic_Program_Icon.Image = Program_Icon.ToBitmap();
            }
            if (Image_Cancel !=null)
            {
                btn_Cancel.Text = "";
                btn_Cancel.Image = Image_Cancel;
                btn_Cancel.ImageAlign = ContentAlignment.MiddleCenter;
            }
            int iCount = DynSettings.s_language.sTextArr.Length;
            int i = 0;
            for ( i = 0;i<iCount;i++)
            {
                string slang = DynSettings.s_language.sTextArr[i];
                if (slang != null)
                {
                    //int iItem = cmb_Language.Items.Add(slang);
                    LanguageList.Add(new Language(slang, i));
                }
            }

            cmb_Language.DataSource = LanguageList;
            cmb_Language.DisplayMember = "Name";
            cmb_Language.ValueMember = "Index";

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
            int i = cmb_Language.SelectedIndex;
            if (i >= 0)
            {
                DynSettings.LanguageID = ((Language)cmb_Language.Items[i]).Index;
            }
            else
            {
                DynSettings.LanguageID = 0;
            }
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }
    }
}
