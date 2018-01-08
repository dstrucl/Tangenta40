using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using usrc_Help;

namespace NavigationButtons
{
    public class Navigation
    {
        public Auto_NEXT m_Auto_NEXT = null;

        public usrc_web_Help web_Help = null;

        public enum eButtons { PrevNextExit, OkCancel };

        public enum eEvent { NOTHING, PREV, NEXT, EXIT, OK, CANCEL };

        public string HelpURL = "https://dstrucl.github.io/Tangenta-Help/";

        public LicenseAgreementAcceptedTime LicenseAgreementAccaptedTime = null;

        public string LastStartupDialog_TYPE = "";
        public bool bDoModal = false;
        public Form parentForm = null;
        public Form OwnerForm = null;
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

        public string ExitProgramQuestionInLanguage = null;

        private bool m_DialogShown = false;

        public bool Auto_NEXT { get { return (m_Auto_NEXT != null) && (m_eButtons == eButtons.PrevNextExit); } }

        public object oStartup = null;
        public int StartupStep_index;


        public delegate void delegate_ChildDialogClosed(Form ChildDialog);

        private delegate_ChildDialogClosed delegateChildDialogClosed = null;

        public bool DialogShown { get { return m_DialogShown; }
                                  set { m_DialogShown = value; }
                                }

        public Navigation(delegate_ChildDialogClosed xdelegate_ChildDialogClosed)
        {
            delegateChildDialogClosed = xdelegate_ChildDialogClosed;
            if (delegateChildDialogClosed==null)
            {
                bDoModal = true;
            }
        }
        public void ShowDialog()
        {
            eExitResult = NavigationButtons.Navigation.eEvent.NOTHING;
            LastStartupDialog_TYPE = ChildDialog.GetType().ToString();
            if (!bDoModal)
            {
                ChildDialog.StartPosition = FormStartPosition.CenterScreen;
                ChildDialog.Visible = true;
                ChildDialog.Owner = this.OwnerForm;
                ChildDialog.FormClosed -= ChildDialog_FormClosed; //delete previous event handler!
                ChildDialog.FormClosed += ChildDialog_FormClosed;
                ChildDialog.Show();
            }
            else
            {
                ChildDialog.ShowDialog();
            }
            m_DialogShown = true;
        }

        private void ChildDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (delegateChildDialogClosed != null)
            {
                delegateChildDialogClosed(ChildDialog);
            }
        }

        public void ShowDialog(Form parent)
        {
            eExitResult = NavigationButtons.Navigation.eEvent.NOTHING;
            LastStartupDialog_TYPE = ChildDialog.GetType().ToString();
            if (!bDoModal)
            {
                ChildDialog.StartPosition = FormStartPosition.CenterScreen;
                ChildDialog.Visible = true;
                ChildDialog.Owner = parent;
                ChildDialog.FormClosed -= ChildDialog_FormClosed; //delete previous event handler!
                ChildDialog.FormClosed += ChildDialog_FormClosed;
                ChildDialog.Show();
                //while (eExitResult == NavigationButtons.Navigation.eEvent.NOTHING)
                //{
                //    Application.DoEvents();
                //}
                //if (ChildDialog.IsAccessible)
                //{
                //    ChildDialog.Close();
                //}
            }
            else
            {
                ChildDialog.ShowDialog(parent);
            }
            m_DialogShown = true;
        }


        public void ShowHelp(string FormTypeAsString)
        {
            string sUrl = ShowHelpResolver(FormTypeAsString);
            if (sUrl != null)
            {
                show_help(sUrl, "");
            }
        }

        public string ShowHelpResolver(string FormTypeAsString)
        {
            if (FormTypeAsString != null)
            {
                int idot = FormTypeAsString.IndexOf(".");
                if (idot >= 0)
                {
                    string stoken = FormTypeAsString.Substring(idot + 1);
                    return HelpURL + lngRPM_strings.LanguagePrefix + "_" + stoken + ".html";
                }
            }
            return null;
        }

        private void show_help(string sURL, string s_Local_Html)
        {
            web_Help.Show(sURL, s_Local_Html);
        }

        public class LicenseAgreementAcceptedTime
        {
            private DateTime m_time = DateTime.MinValue;
            public DateTime time
            {
                get { return m_time; }
            }

            public LicenseAgreementAcceptedTime(DateTime t)
            {
                m_time = t;
            }
        }
    }
}
