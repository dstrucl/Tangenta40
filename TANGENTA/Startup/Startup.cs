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

        public startup_step.eStep eNextStep = startup_step.eStep.NoStep;
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
                        eStep = startup_step.eStep.Do_TangentaAbout;
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

        //public bool Execute(bool bFirstTimeInstallation, ref string Err)
        //{
        //    if (bFirstTimeInstallation)
        //    {

        //    Do_TangentaAbout_again:
        //        Do_TangentaAbout(nav);
        //        if (nav.eExitResult == NavigationButtons.Navigation.eEvent.NEXT)
        //        {

        //            Do_TangentaLicence(nav);
        //            if (nav.eExitResult == NavigationButtons.Navigation.eEvent.PREV)
        //            {
        //                goto Do_TangentaAbout_again;
        //            }
        //            else if (nav.eExitResult == NavigationButtons.Navigation.eEvent.EXIT)
        //            {
        //                eNextStep = startup_step.eStep.Cancel;
        //                return false;
        //            }
        //        }
        //        else if (nav.eExitResult == NavigationButtons.Navigation.eEvent.PREV)
        //        {
        //            eNextStep = startup_step.eStep.Cancel;
        //            return false;
        //        }
        //        else if (nav.eExitResult == NavigationButtons.Navigation.eEvent.EXIT)
        //        {
        //            eNextStep = startup_step.eStep.Cancel;
        //            return false;
        //        }
        //    }
        //    return false;
        //    //return ExecuteSteps(ref Err);
        //}

        public bool Do_TangentaLicence(startup myStartup, object o, NavigationButtons.Navigation xnav, ref string Err)
        {
            // return  true for step over
            if (bFirstTimeInstallation)
            {
                nav.ShowHelp("Tangenta.Tangenta-LicenseAgreement");
                nav.ChildDialog = new Form_LicenseAgreement(nav);
                nav.ShowDialog();
                return false; //
            }
            else
            {
                return true; 
            }
        }

        public bool Do_TangentaAbout(startup myStartup, object o, NavigationButtons.Navigation xnav, ref string Err)
        {
            // return  true for step over
            if (bFirstTimeInstallation)
            {
                nav.ShowHelp("Tangenta.Tangenta_about");
                nav.ChildDialog = new Form_Navigate(xnav);
                nav.ShowDialog();
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool StartExecuteSteps(ref string Err)
        {
            eStep = startup_step.eStep.Check_DataBase;
            eNextStep = eStep;
            return true;
        }

        public bool ExecuteSingleStep()
        {
            if ((eStep != startup_step.eStep.Cancel) && (eStep != startup_step.eStep.End))
            {
                object odata = null;
                string Err = null;

                bool bIgnoredSoGoToNextStep = false;
                for(;;)
                {
                    bIgnoredSoGoToNextStep = m_Step[(int)eStep].Execute(this, odata, nav, ref Err);
                    if (bIgnoredSoGoToNextStep)
                    {
                        eStep++;
                    }
                    else
                    {
                        return false;
                    }
                }
                //while (bNextStep);

                //return bRet;
                //if (bRet)
                //{
                //    int iStep = -1;
                //    int iNextStep = -1;
                //    switch (nav.eExitResult)
                //    {
                //        case NavigationButtons.Navigation.eEvent.EXIT:
                //            return false;

                //        case NavigationButtons.Navigation.eEvent.NEXT:
                //            if ((eStep != startup_step.eStep.Cancel) && (eStep != startup_step.eStep.End))
                //            {
                //                iStep = (int)eStep + 1;
                //                iNextStep = (int)eNextStep;
                //                while (iStep < iNextStep)
                //                {
                //                    m_Step[iStep].SetOK();
                //                    iStep++;
                //                }
                //            }
                //            break;
                //        case NavigationButtons.Navigation.eEvent.PREV:
                //            iStep = (int)eStep;
                //            iNextStep = (int)eNextStep;
                //            while (iStep > iNextStep)
                //            {
                //                m_Step[iStep].SetNotDone();
                //                iStep--;
                //            }
                //            break;
                //    }

                //}
                //eStep = eNextStep;
                //if (!bRet)
                //{
                //    return false;
                //}
                //else
                //{
                //    return true;
                //}
            }
            else
            {
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
                    ExecuteSingleStep();
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
                    ExecuteSingleStep();
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
    }
}
