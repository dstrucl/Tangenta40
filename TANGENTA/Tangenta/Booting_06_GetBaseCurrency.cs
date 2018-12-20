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
                    //frm.m_usrc_Main.m_usrc_DocumentEditor.usrc_Currency1.Init(GlobalData.BaseCurrency);
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
            Startup_06_Show_Form_Select_DefaultCurrency(xnav);
            return true;
        }

        private void Startup_06_Show_Form_Select_DefaultCurrency(NavigationButtons.Navigation xnav)
        {
            if (GlobalData.BaseCurrency == null)
            {
                GlobalData.BaseCurrency = new xCurrency();
            }
            ID DefaultCurrency_ID = myOrg.Default_Currency_ID;
            xnav.ShowForm(new Form_Select_DefaultCurrency(DefaultCurrency_ID, ref GlobalData.BaseCurrency, xnav), typeof(Form_Select_DefaultCurrency).ToString());
        }

        internal bool Startup_06_set_DefaultCurrency(Form_Select_DefaultCurrency sel_basecurrency_dlg, ref string Err)
        {
            Transaction transaction_Startup_06_set_DefaultCurrency = new Transaction("Startup_06_set_DefaultCurrency");
            if (GlobalData.InsertIntoBaseCurrency(sel_basecurrency_dlg.Currency_ID, ref Err, transaction_Startup_06_set_DefaultCurrency))
            {
                if (transaction_Startup_06_set_DefaultCurrency.Commit())
                {
                    //usrc_Currency1.Init(GlobalData.BaseCurrency);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                transaction_Startup_06_set_DefaultCurrency.Rollback();
                Err = "ERROR:usrc_Invoice:Select_BaseCurrency:InsertIntoBaseCurrency:Err=" + Err;
                return false;
            }
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
                        if (Startup_06_set_DefaultCurrency((Form_Select_DefaultCurrency)form, ref Err))
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
