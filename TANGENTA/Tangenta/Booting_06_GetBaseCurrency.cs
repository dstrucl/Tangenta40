using DBConnectionControl40;
using NavigationButtons;
using Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TangentaDB;
using static Startup.startup_step;

namespace Tangenta
{
    public class Booting_06_GetBaseCurrency
    {
        private startup_step.eStep eStep = eStep.Check_06_GetBaseCurrency;

        private Form_Document frm = null;
        private startup m_startup = null;


        public Booting_06_GetBaseCurrency(Form_Document xfmain, startup x_sturtup)
        {
            frm = xfmain;
            m_startup = x_sturtup;

        }


        internal startup_step CreateStep()
        {
            return new startup_step(lng.s_Startup_GetBaseCurrency.s, m_startup, Program.nav, Startup_06_GetBaseCurrency, null,eStep);
        }

        public Startup_check_proc_Result Startup_06_GetBaseCurrency(startup_step xstartup_step,
                                                   object oData,
                                                   ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                   ref string Err)
        {
            string BaseCurrency_Text = null;
            if (GlobalData.Get_BaseCurrency(ref BaseCurrency_Text, ref Err))
            {
                if (BaseCurrency_Text != null)
                {
                    frm.m_usrc_Main.m_usrc_DocumentEditor.usrc_Currency1.Init(GlobalData.BaseCurrency);
                    return Startup_check_proc_Result.CHECK_OK;
                }
                else
                {
                    startup_ShowForm_proc = Startup_06_Show_Form_Select_DefaultCurrency;
                    return Startup_check_proc_Result.WAIT_USER_INTERACTION;
                }
            }
            return Startup_check_proc_Result.CHECK_ERROR;
        }

        private bool Startup_06_Show_Form_Select_DefaultCurrency(startup_step xstartup_step,
                                                            NavigationButtons.Navigation xnav,
                                                            ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            startup_OnFormResult_proc = Startup_06_onformresult_Form_Select_DefaultCurrency;
            frm.m_usrc_Main.m_usrc_DocumentEditor.Startup_06_Show_Form_Select_DefaultCurrency(xnav);
            return true;
        }

        private Startup_onformresult_proc_Result Startup_06_onformresult_Form_Select_DefaultCurrency(startup_step myStartup_step,
                                                                                    Form form,
                                                                                    NavigationButtons.Navigation.eEvent eExitResult,
                                                                                    ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                                                    ref string Err)
        {
            switch (eExitResult)
            {
                case Navigation.eEvent.NEXT:
                    if (form is Form_Select_DefaultCurrency)
                    {
                        if (frm.m_usrc_Main.m_usrc_DocumentEditor.Startup_06_set_DefaultCurrency((Form_Select_DefaultCurrency)form, ref Err))
                        {
                            return Startup_onformresult_proc_Result.NEXT;
                        }
                        else
                        {
                            return Startup_onformresult_proc_Result.ERROR;
                        }
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
