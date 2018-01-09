﻿using System;
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
        public enum Startup_check_proc_Result {CHECK_NONE,CHECK_OK,WAIT_USER_INTERACTION, CHECK_ERROR};
        public enum Startup_onformresult_proc_Result {EXIT,NEXT,PREV,ERROR };

        public enum eResult { NEXT, BACK, EXIT, ERROR};

        public enum eStep : int {
                                  Do_TangentaAbout,
                                  Do_TangentaLicence,
                                  Check_DataBase,
                                  Read_DBSettings_Version,
                                  CheckDBVersion,
                                  GetOrganisationData,
                                  GetBaseCurrency,
                                  GetTaxation,
                                  Get_ProgramSettings,
                                  SetShopsPricelists,
                                  GetSimpleItemData,
                                  GetItemData,
                                  GetPrinter,
                                  GetWorkPeriod,
                                  End,
                                  Cancel,
                                  NoStep
                                };

        public Startup_check_proc_Result ResultOf_check_procedure = Startup_check_proc_Result.CHECK_NONE;

        public delegate Startup_check_proc_Result delegate_startup_check_proc(startup myStartup,
                                                   object oData, 
                                                   NavigationButtons.Navigation xnav,
                                                   ref string Err);

        public delegate bool delegate_startup_ShowForm_proc(startup myStartup,
                                                   object oData,
                                                   NavigationButtons.Navigation xnav,
                                                   ref string Err);

        public delegate Startup_onformresult_proc_Result delegate_startup_OnFormResult_proc(startup myStartup,
                                                                                            object oData,
                                                                                            NavigationButtons.Navigation xnav,
                                                                                            ref string Err);


        public string s_Title = null;

        public usrc_startup_step m_usrc_startup_step = null;

        public startup myStartup = null;

        public NavigationButtons.Navigation nav = null;

        private delegate_startup_check_proc check_procedure;
        private delegate_startup_ShowForm_proc showform_procedure;
        private delegate_startup_OnFormResult_proc onformresult_procedure;

        public eStep Step = eStep.NoStep;


        //public delegate_startup_check_proc Check_procedure { get => check_procedure; set => check_procedure = value; }

        public startup_step(string xs_Title,
                            startup xmyStartup,
                            NavigationButtons.Navigation xnav,
                            delegate_startup_check_proc xcheck_proc,
                            delegate_startup_ShowForm_proc xshowform_procedure,
                            delegate_startup_OnFormResult_proc xonformresult_procedure,
                            eStep xStep)
        {
            s_Title = xs_Title;
            ResultOf_check_procedure = Startup_check_proc_Result.CHECK_NONE;

            myStartup = xmyStartup;
            nav = xnav;
            check_procedure = xcheck_proc;
            showform_procedure = xshowform_procedure;
            onformresult_procedure = xonformresult_procedure;
            Step = xStep;
        }

        internal void SetOK()
        {
            m_usrc_startup_step.check1.State = Check.check.eState.TRUE;
        }

        internal void SetNotDone()
        {
            m_usrc_startup_step.check1.State = Check.check.eState.UNDEFINED;
        }


        public Startup_check_proc_Result Execute_check_procedure(object oData, ref string Err)
        {
            ResultOf_check_procedure = check_procedure(myStartup, oData, nav, ref Err);
            switch (ResultOf_check_procedure)
            {
                case Startup_check_proc_Result.CHECK_OK:
                    SetOK();
                    break;
            }
            return ResultOf_check_procedure;
        }

        public bool Execute_showform_procedure(object oData, ref string Err)
        {
            bool bRes = showform_procedure(myStartup, oData, nav, ref Err);
            return bRes;
        }

        public Startup_onformresult_proc_Result Execute_onformresult_procedure(object oData, ref string Err)
        {
            Startup_onformresult_proc_Result eRes = onformresult_procedure(myStartup, oData, nav, ref Err);
            return eRes;
        }
    }
}
