﻿
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HUDCMS;

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

        public SomethingReadyNotifier DialogClosingNotifier = null;

        public delegate void delegate_ChildDialogClosing(Form ChildDialog);

        private delegate_ChildDialogClosing delegateChildDialogClosing = null;

        public bool DialogShown { get { return m_DialogShown; }
                                  set { m_DialogShown = value; }
                                }

        public Navigation(delegate_ChildDialogClosing xdelegate_ChildDialogClosing)
        {
            delegateChildDialogClosing = xdelegate_ChildDialogClosing;
            if (delegateChildDialogClosing==null)
            {
                bDoModal = true;
            }
        }

        public Navigation()
        {
            delegateChildDialogClosing = null;
            DialogClosingNotifier = new SomethingReadyNotifier(SynchronizationContext.Current);
        }

        public void ShowForm(Form new_Form, string sHelpToShow)
        {
            eExitResult = NavigationButtons.Navigation.eEvent.NOTHING;
            
            
            
            bDoModal = false;

            if (ChildDialog != null)
            {
                LastStartupDialog_TYPE = ChildDialog.GetType().ToString();
                if (!ChildDialog.IsDisposed)
                {
                    if (ChildDialog.IsAccessible)
                    {
                        ChildDialog.FormClosing -= ChildDialog_FormClosing; //delete previous event handler!
                        ChildDialog.Close();
                        ChildDialog.DialogResult = DialogResult.Abort;
                    }
                }
                ChildDialog.Dispose();
                ChildDialog = null;
            }

            ChildDialog = new_Form;
            ChildDialog.StartPosition = FormStartPosition.CenterScreen;
            ChildDialog.Visible = true;
            ChildDialog.Owner = this.OwnerForm;
            ChildDialog.FormClosing -= ChildDialog_FormClosing; //delete previous event handler!
            ChildDialog.FormClosing += ChildDialog_FormClosing;
            if (sHelpToShow!=null)
            {
                ShowHelp(ChildDialog,sHelpToShow);
            }
            ChildDialog.Show();
            m_DialogShown = true;
        }

        public void ShowDialog()
        {
            eExitResult = NavigationButtons.Navigation.eEvent.NOTHING;
            LastStartupDialog_TYPE = ChildDialog.GetType().ToString();
            bDoModal = true;
            ChildDialog.FormClosing -= ChildDialog_FormClosing; //delete previous event handler!
            ChildDialog.FormClosing += ChildDialog_FormClosing;
            ChildDialog.ShowDialog();
            m_DialogShown = true;
        }

        private void ChildDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            usrc_NavigationButtons unavb = Get_usrc_NavigationButtons(sender);
            if (unavb != null)
            {
                if (unavb.m_eButtons == eButtons.PrevNextExit)
                {
                    if (unavb.m_nav.eExitResult == eEvent.NOTHING)
                    {
                        bool bCancelExit = false;
                        unavb.ExitClicked(ref bCancelExit);
                        if (bCancelExit)
                        {
                            e.Cancel = true;
                        }
                        return;
                    }
                }
            }
            if (delegateChildDialogClosing != null)
            {
                delegateChildDialogClosing(ChildDialog);
            }
            else
            {
                if (DialogClosingNotifier != null)
                {
                    DialogClosingNotifier.NotifySomethingReady();
                }
            }
        }

        private usrc_NavigationButtons Get_usrc_NavigationButtons(object sender)
        {
            if (sender is Form)
            {
                IEnumerable<usrc_NavigationButtons> unavbuttons = ((Form)sender).Controls.OfType<usrc_NavigationButtons>();
                if (unavbuttons != null)
                {
                    if (unavbuttons.Count() > 0)
                    {
                        return unavbuttons.ElementAt(0);
                    }
                }
            }
            return null;
        }


        public void ShowDialog(Form parent)
        {
            eExitResult = NavigationButtons.Navigation.eEvent.NOTHING;
            LastStartupDialog_TYPE = ChildDialog.GetType().ToString();
            ChildDialog.ShowDialog(parent);
            m_DialogShown = true;
        }


        public void ShowHelp(Form pForm,string sNameSpaceDotType)
        {
            if (sNameSpaceDotType != null)
            {
                show_help(pForm, sNameSpaceDotType);
            }
        }

        public string ShowHelpResolver(string FormTypeAsString)
        {
            if (FormTypeAsString != null)
            {
                string[]s = FormTypeAsString.Split(new char[] { '.' });
                if (s.Length==2)
                {
                    return s[0] + '/' + s[1];
                }
                else
                {
                    MessageBox.Show("Error:ShowHelpResolver can not find namespace and object type!");
                }
            }
            return null;
        }

        private void show_help(Form pForm,string sNameSpaceAndType)
        {
            web_Help.Show(pForm,sNameSpaceAndType);
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

        public void SetPreviousButtonVisible(bool v)
        {
            btn1_Visible = v;
        }
    }
}
