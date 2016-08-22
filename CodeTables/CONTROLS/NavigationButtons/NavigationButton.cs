using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavigationButtons
{
    public class Navigation
    {
        //public enum eStartupStepDialogs
        //{
        //    NONE,
        //    Form_SelectLanguage,
        //    CommandLineHelp_Form,
        //    Form_GetDBType,
        //    ConnectionDialog,
        //    SQLiteConnectionDialog,
        //    Form_CheckInsertSampleData,
        //    Form_Select_Country_ISO_3166,
        //    Form_EditSampleData,
        //    Form_Select_DefaultCurrency
        //}
        public System.Windows.Forms.WebBrowser web_Help = null;

        public enum eButtons { PrevNextExit, OkCancel };

        public enum eEvent {NOTHING, PREV, NEXT, EXIT, OK, CANCEL };

        public string LastStartupDialog_TYPE = "";
        public bool bDoModal = false;
        public Form parentForm = null;
        public Form ChildDialog = null;

        public eButtons m_eButtons = eButtons.OkCancel;
        public eEvent eExitResult = eEvent.NOTHING;

        public Image btn1_Image = null;
        public string btn1_Text = null;
        public string btn1_ToolTip_Text = null;
        public bool btn1_Visible = true;

        public Image btn2_Image = null;
        public string btn2_Text = null;
        public string btn2_ToolTip_Text = null;
        public bool btn2_Visible = true;

        public Image btn3_Image = null;
        public string btn3_Text = null;
        public string btn3_ToolTip_Text = null;
        public bool btn3_Visible = true;

        public void ShowDialog()
        {
            eExitResult = NavigationButtons.Navigation.eEvent.NOTHING;
            LastStartupDialog_TYPE = ChildDialog.GetType().ToString();
            if (!bDoModal)
            {
                ChildDialog.StartPosition = FormStartPosition.CenterScreen;
                ChildDialog.TopMost = true;
                ChildDialog.Visible = true;
                ChildDialog.Show();
                while (eExitResult == NavigationButtons.Navigation.eEvent.NOTHING)
                {
                    Application.DoEvents();
                }
                if (ChildDialog.IsAccessible)
                {
                    ChildDialog.Close();
                }
            }
            else
            {
                ChildDialog.ShowDialog();
            }
        }

        public void ShowHelp(string FormTypeAsString)
        {
            if (FormTypeAsString.Equals("DBSync.Form_GetDBType"))
            {
                show_help("")
            }
        }
     }
 }
