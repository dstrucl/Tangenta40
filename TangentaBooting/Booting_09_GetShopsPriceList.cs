using DBConnectionControl40;
using DocumentManager;
using NavigationButtons;
using PriseLists;
using Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TangentaDB;
using static Startup.startup_step;

namespace TangentaBooting
{
    public class Booting_09_GetShopsPriceLists
    {
        private startup_step.eStep eStep = eStep.Check_09_ShopsPriceLists;

        private Form frm = null;
        private Startup.Startup m_startup = null;


        public Booting_09_GetShopsPriceLists(Form xfmain, Startup.Startup x_sturtup)
        {
            frm = xfmain;
            m_startup = x_sturtup;

        }


        internal startup_step CreateStep()
        {
            return new startup_step(lng.s_SetShopsPricelists.s, m_startup, Booting.nav, Startup_09_GetShopsPriceLists,null, eStep);
        }

        public Startup_check_proc_Result Startup_09_GetShopsPriceLists(startup_step xstartup_step,
                                                   object oData,
                                                   ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                   ref string Err)
        {

            if (DocumentMan.eShopsInUse.Contains("B")|| DocumentMan.eShopsInUse.Contains("C"))
            {
                long PriceListRowsCount = fs.GetTableRowsCount("PriceList");
                if (PriceListRowsCount > 0)
                {
                    return Startup_check_proc_Result.CHECK_OK;
                }
                else
                {
                    startup_ShowForm_proc = Startup_09_Show_Form_ShopsPriceLists_Edit;
                    return Startup_check_proc_Result.WAIT_USER_INTERACTION;
                }
            }
            else
            {
                //Only ShopA in use
                return Startup_check_proc_Result.CHECK_OK;
            }
        }

        private bool Startup_09_Show_Form_ShopsPriceLists_Edit(startup_step xstartup_step,
                                                            NavigationButtons.Navigation xnav,
                                                            ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            startup_OnFormResult_proc = Startup_09_onformresult_Form_ShopsPriceLists_Edit;
            xnav.ShowForm(new Form_PriceList_Edit(false, usrc_PriceList_Edit.eShopType.ShopB, xnav), typeof(Form_PriceList_Edit).ToString());
            return true;
        }

        private Startup_onformresult_proc_Result Startup_09_onformresult_Form_ShopsPriceLists_Edit(startup_step myStartup_step,
                                                                                    Form form,
                                                                                    NavigationButtons.Navigation.eEvent eExitResult,
                                                                                    ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                                                    ref string Err)
        {
            switch (eExitResult)
            {
                case Navigation.eEvent.NEXT:
                    if (form is Form_PriceList_Edit)
                    {
                       return Startup_onformresult_proc_Result.DO_CHECK_PROC_AGAIN;
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
