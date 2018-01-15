using LanguageControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThreadProcessor;
using TangentaDB;
using TangentaSampleDB;
using NavigationButtons;

namespace Startup
{
   

    public class startup
        {
        public enum EvaulateStep_RESULT {EXIT,NEXT,PREV,START_GO_PREV, FINISHED_GO_NEXT };

        public SampleDB sbd;
        public NavigationButtons.Navigation nav = null;

        public startup_step.eStep eStep = startup_step.eStep.NoStep;

        public bool bNewDatabaseCreated = false;
        public bool bInsertSampleData = false;
        public bool bUpgradeDone = false;
        public string AdminPassword = null;

        public Form m_parent_form = null;
        public usrc_Startup m_usrc_Startup = null;
        private startup_step[] m_Step = null;

        public startup_step[] Steps
        {
            get {   return m_Step; }

            set {   m_Step = value;
                    if(m_usrc_Startup!=null)
                    {
                        eStep = startup_step.eStep.Check_00_TangentaAbout;
                        m_usrc_Startup.Init();
                    }
                }
        }
        public Image m_ImageCancel = null;
        private bool m_bCancel = false;
        public Icon m_FormIconQuestion = null;
        public fs.enum_GetDBSettings eGetDBSettings_Result = fs.enum_GetDBSettings.No_TextValue;
        public string CurrentDataBaseVersionTextValue = null;
        private bool bFirstTimeInstallation = false;

        public bool bCanceled
        {
            get { return m_bCancel; }
            set { m_bCancel = value; }
        }

        public bool Exit { get { return ((((int)eStep) < 0) || m_usrc_Startup.Exit); } }


        public startup(Form parent_form, NavigationButtons.Navigation xnav, Icon xFormIconQuestion,bool xbFirstTimeInstallation)
        {
            sbd = new SampleDB();
            m_parent_form = parent_form;
            nav = xnav;
            bFirstTimeInstallation = xbFirstTimeInstallation;
            m_usrc_Startup = new usrc_Startup(this);
            nav.web_Help = m_usrc_Startup.usrc_web_Help1;
            m_FormIconQuestion = xFormIconQuestion;
        }


        public bool Startup_01_Do_showform_TangentaLicence(object o, NavigationButtons.Navigation xnav, startup_step.Startup_check_proc_Result echeck_proc_Result, ref string Err)
        {
            // return  true for step over
            Err = null;
            xnav.ShowForm(new Form_LicenseAgreement(xnav), "Tangenta.Tangenta-LicenseAgreement");
            return true; //
        }


        public bool Startup_00_Do_showform_TangentaAbout( object o, NavigationButtons.Navigation xnav, startup_step.Startup_check_proc_Result echeck_proc_Result,  ref string Err)
        {
            xnav.ShowForm(new Form_Navigate(xnav), "Tangenta.Tangenta_about");
            return true;
        }

        public void CurrentStepExecutionSetUndefined()
        {
            m_Step[(int)eStep].SetUndefined();
        }

        public void StartExecution()
        {

             m_Step[0].StartExecution();
        }

        public bool StartCurrentStepExecution()
        {
            m_Step[(int)eStep].StartExecution();
            return true;
        }

        public bool StartNextStepExecution()
        {
            if (((int)eStep) < m_Step.Length-1)
            {
                m_Step[(int)eStep].Remove_DialogClosingNotifier_SomethingReady();
                eStep++;
                m_Step[(int)eStep].StartExecution();
                return true;
            }
            else
            {
                // all steps done
                return false;
            }
        }

        public bool StartPrevStepExecution()
        {
            if (((int)eStep) > 0)
            {
                m_Step[(int)eStep].Remove_DialogClosingNotifier_SomethingReady();
                eStep--;
                m_Step[(int)eStep].StartExecution();
                return true;
            }
            else
            {
                m_Step[(int)eStep].Remove_DialogClosingNotifier_SomethingReady();
                // all steps in PREV direction done
                return false;
            }
        }

        internal bool StartCurrentStepExecution_checkprocedure()
        {
            switch (m_Step[(int)eStep].m_usrc_startup_step.DoStartup_check_proc_Result())
            {
                case startup_step.Startup_check_proc_Result.CHECK_OK:
                    return true;
                default:
                    return false;
            }
        }

        public void RemoveControl()
        {
            m_parent_form.Controls.Remove(m_usrc_Startup);
            m_usrc_Startup.Dispose();
            m_usrc_Startup = null;
        }

        public EvaulateStep_RESULT EvaulateStep(Navigation nav)
        {
            if (nav.eExitResult== Navigation.eEvent.NEXT)
            {
                eStep++;
                if (((int)eStep) < m_Step.Length)
                {
                    //ExecuteSingleStep();
                    return EvaulateStep_RESULT.NEXT;
                }
                else
                {
                    return EvaulateStep_RESULT.FINISHED_GO_NEXT;
                }
            }
            else if (nav.eExitResult == Navigation.eEvent.PREV)
            {
                eStep--;
                if (((int)eStep) >= 0)
                {
                    //ExecuteSingleStep();
                    return EvaulateStep_RESULT.PREV;
                }
                else
                {
                    return EvaulateStep_RESULT.START_GO_PREV;
                }
            }
            else if (nav.eExitResult == Navigation.eEvent.EXIT)
            {
                return EvaulateStep_RESULT.EXIT;
            }
            else
            {
                return EvaulateStep_RESULT.EXIT;
            }
        }

        public void StartCurrentStepExecution_ShowForm(startup_step.Startup_check_proc_Result wAIT_USER_INTERACTION)
        {
            m_Step[(int)eStep].StartExecution_ShowForm(wAIT_USER_INTERACTION);
        }
    }
}
