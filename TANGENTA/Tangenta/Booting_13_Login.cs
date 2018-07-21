﻿using DBConnectionControl40;
using NavigationButtons;
using Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TangentaDB;
using TangentaPrint;
using static Startup.startup_step;

namespace Tangenta
{
    public class Booting_13_Login
    {
        private startup_step.eStep eStep = eStep.Check_13_Login;

        private Form_Document frm = null;
        private startup m_startup = null;


        public Booting_13_Login(Form_Document xfmain, startup x_sturtup)
        {
            frm = xfmain;
            m_startup = x_sturtup;

        }


        internal startup_step CreateStep()
        {
            return new startup_step(lng.s_Startup_Login.s, m_startup, Program.nav, Startup_13_Login,null, eStep);
        }

        public Startup_check_proc_Result Startup_13_Login(startup_step xstartup_step,
                                                   object oData,
                                                   ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                   ref string Err)
        {
            if (Program.Login_MultipleUsers)
            {
                if (frm.m_usrc_Main.ShowMultipleUserLoginControl(m_startup, null, m_startup.nav, ref Err))
                {
                    return Startup_check_proc_Result.CHECK_OK;
                }
                else
                {
                    return Startup_check_proc_Result.CHECK_ERROR;
                }
            }
            else
            {
                if (frm.m_usrc_Main.GetWorkPeriod(m_startup, null, m_startup.nav, ref Err))
                {
                    return Startup_check_proc_Result.CHECK_OK;
                }
                else
                {
                    return Startup_check_proc_Result.CHECK_ERROR;
                }
            }
        }

        private bool Startup_12_Show_Form_Printer_Edit(startup_step xstartup_step,
                                                            NavigationButtons.Navigation xnav,
                                                            ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            startup_OnFormResult_proc = Startup_12_onformresult_Form_Printer;
            return true;
        }

        private Startup_onformresult_proc_Result Startup_12_onformresult_Form_Printer(startup_step myStartup_step,
                                                                                    Form form,
                                                                                    NavigationButtons.Navigation.eEvent eExitResult,
                                                                                    ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                                                    ref string Err)
        {
            switch (eExitResult)
            {
                case Navigation.eEvent.NEXT:
                    if (form is Form_DefinePrinters)
                    {
                       return Startup_onformresult_proc_Result.NEXT;
                    }
                    else
                    {
                            return Startup_onformresult_proc_Result.ERROR;
                    }

                case Navigation.eEvent.PREV:
                    return Startup_onformresult_proc_Result.PREV;

                case Navigation.eEvent.EXIT:
                    return Startup_onformresult_proc_Result.EXIT;

                case NavigationButtons.Navigation.eEvent.NOTHING:
                    // happens when check procedure is OK
                    return Startup_onformresult_proc_Result.NO_FORM_BUT_CHECK_OK;

                default:
                    LogFile.Error.Show("ERROR:Tangenta:FormDocument:Startup_06_onformresult_Form_Select_DefaultCurrency:eExitResult not implemented for xnav.eExitResult = " + eExitResult.ToString());
                    return Startup_onformresult_proc_Result.ERROR;
            }
        }
    }
}
