using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThreadProcessor;

namespace Startup
{
    public class startup_step
    {
        public enum Startup_check_proc_Result {CHECK_NONE,
                                               CHECK_OK,
                                               WAIT_USER_INTERACTION,
                                               CHECK_ERROR
            
        };

        public enum Startup_onformresult_proc_Result {EXIT,
                                                      NEXT,
                                                      PREV,
                                                      DO_CHECK_PROC_AGAIN,
                                                      WAIT_USER_INTERACTION,
                                                    NO_FORM_BUT_CHECK_OK,
                                                    ERROR,
                                                    NO_RESULT
        };

        public enum eResult { NEXT, BACK, EXIT, ERROR};

        public enum eStep : int {
                                Check_00_TangentaAbout,
                                Check_01_TangentaLicence,
                                Check_02_DataBaseType,
                                Check_03_DBConnection,
                                Check_04_DBSettings,
                                Check_05_myOrganisation_Data,
                                Check_06_InsertSampleData,
                                Check_07_GetOrganisationData,
                                GetBaseCurrency,
                                GetTaxation,
                                Get_ProgramSettings,
                                SetShopsPricelists,
                                GetSimpleItemData,
                                GetItemData,
                                GetPrinter,
                                GetWorkPeriod,
                                NoStep //NoStep must be at the end !
                                };

       

        internal void SetCurretStepShowFormProcedure()
        {
            throw new NotImplementedException();
        }

        public Startup_check_proc_Result eResult_Of_check_procedure = Startup_check_proc_Result.CHECK_NONE;
        public Startup_onformresult_proc_Result eonformresult_proc_Result = Startup_onformresult_proc_Result.NO_RESULT;

        public delegate Startup_check_proc_Result delegate_startup_check_proc(startup_step xstartup_step,
                                                   object oData, 
                                                   ref string Err);

        public delegate bool delegate_startup_ShowForm_proc(startup_step xstartup_step,
                                                            NavigationButtons.Navigation xnav,
                                                            ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc);

        public delegate Startup_onformresult_proc_Result delegate_startup_OnFormResult_proc(startup_step myStartup_step,
                                                                                            Form form,
                                                                                            NavigationButtons.Navigation.eEvent eExitResult,
                                                                                            ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                                                            ref string Err);


        public string s_Title = null;

        public usrc_startup_step m_usrc_startup_step = null;

        public startup myStartup = null;

        public NavigationButtons.Navigation nav = null;

        internal delegate_startup_check_proc check_procedure;
        public delegate_startup_ShowForm_proc showform_procedure;
        public delegate_startup_OnFormResult_proc onformresult_procedure;

        public eStep Step = eStep.NoStep;


        //public delegate_startup_check_proc Check_procedure { get => check_procedure; set => check_procedure = value; }

        public startup_step(string xs_Title,
                            startup xmyStartup,
                            NavigationButtons.Navigation xnav,
                            delegate_startup_check_proc xcheck_proc,
                            eStep xStep)
        {
            s_Title = xs_Title;
            eResult_Of_check_procedure = Startup_check_proc_Result.CHECK_NONE;

            myStartup = xmyStartup;
            nav = xnav;
            check_procedure = xcheck_proc;
            showform_procedure = null;
            onformresult_procedure =null;
            Step = xStep;
        }

        internal bool ShowFormProcedure(delegate_startup_ShowForm_proc Do_showform)
        {
            if (Do_showform != null)
            {
                showform_procedure = Do_showform;
            }
            if (showform_procedure!=null)
            {
                bool bRes = showform_procedure(this,nav,ref onformresult_procedure);
                return bRes;
            }
            return false;
        }
        internal void Remove_DialogClosingNotifier_SomethingReady()
        {
            m_usrc_startup_step.Remove_DialogClosingNotifier_SomethingReady();
        }

        internal startup_step.Startup_check_proc_Result StartExecution()
        {
            eResult_Of_check_procedure = m_usrc_startup_step.DoStartup_check_proc_Result();
            return eResult_Of_check_procedure;
        }

        internal void SetOK()
        {
            m_usrc_startup_step.check1.State = Check.check.eState.TRUE;
        }

        public void SetUndefined()
        {
            m_usrc_startup_step.check1.State = Check.check.eState.UNDEFINED;
        }

        public void SetWait()
        {
            m_usrc_startup_step.check1.State = Check.check.eState.WAIT;
        }

        public Startup_check_proc_Result Execute_check_procedure(object oData, ref string Err)
        {
            eResult_Of_check_procedure = check_procedure(this, oData,  ref Err);
            switch (eResult_Of_check_procedure)
            {
                case Startup_check_proc_Result.CHECK_OK:
                    SetOK();
                    break;
            }
            return eResult_Of_check_procedure;
        }


        internal void StartExecution_ShowForm(Startup_check_proc_Result wAIT_USER_INTERACTION)
        {
            SetWait();
            bool bRes = showform_procedure(this, nav, ref onformresult_procedure);
        }

        public Startup_onformresult_proc_Result Execute_onformresult_procedure(object oData, ref string Err)
        {
            eonformresult_proc_Result = onformresult_procedure(this,nav.ChildDialog, nav.eExitResult,ref showform_procedure, ref Err);
            return eonformresult_proc_Result;
        }

        public Startup_onformresult_proc_Result DoOnFormClosing()
        {
            string Err = null;
            Startup_onformresult_proc_Result eRes = onformresult_procedure(this,nav.ChildDialog, nav.eExitResult, ref showform_procedure, ref Err);
            return eRes;
        }
    }
}
