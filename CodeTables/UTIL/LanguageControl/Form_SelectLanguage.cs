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
        NavigationButtons.Navigation nav = null;

        public Form_SelectLanguage(Icon xProgram_Icon, string xProgram_name, int Language_ID, NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            Program_Icon = xProgram_Icon;
            Program_name = xProgram_name;
            nav = xnav;
            usrc_NavigationButtons1.Init(nav);
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

        private void DoOK()
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

        private void DoCancel()
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void cmb_Language_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void usrc_NavigationButtons1_ButtonPressed(NavigationButtons.Navigation.eEvent evt)
        {
            switch (nav.m_eButtons)
            {
                case NavigationButtons.Navigation.eButtons.OkCancel:
                    switch (evt)
                    {
                        case NavigationButtons.Navigation.eEvent.OK:
                            DoOK();
                            break;
                        case NavigationButtons.Navigation.eEvent.CANCEL:
                            DoCancel();
                            break;
                    }
                    break;

                case NavigationButtons.Navigation.eButtons.PrevNextExit:
                    switch (evt)
                    {
                        case NavigationButtons.Navigation.eEvent.NEXT:
                            DoOK();
                            break;
                        case NavigationButtons.Navigation.eEvent.EXIT:
                            DoCancel();
                            break;
                    }
                    break;

            }
        }
    }
}
