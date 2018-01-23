using DBConnectionControl40;
using NavigationButtons;
using Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TangentaDB;
using TangentaSampleDB;
using static Startup.startup_step;

namespace Tangenta
{
    public class Booting_11_GetShopC_Items
    {
        private startup_step.eStep eStep = eStep.Check_11_GetShopC_Items;

        private Form_Document frm = null;
        private startup m_startup = null;


        public Booting_11_GetShopC_Items(Form_Document xfmain, startup x_sturtup)
        {
            frm = xfmain;
            m_startup = x_sturtup;

        }


        internal startup_step CreateStep()
        {
            return new startup_step(lng.s_Startup_GetShopC_Items.s, m_startup, Program.nav, Startup_11_GetShopC_Items,null, eStep);
        }

        public Startup_check_proc_Result Startup_11_GetShopC_Items(startup_step xstartup_step,
                                                   object oData,
                                                   ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                   ref string Err)
        {
            long ShopC_Items_Count = fs.GetTableRowsCount("Item");
            if (ShopC_Items_Count > 0)
            {
                return Startup_check_proc_Result.CHECK_OK;
            }
            else
            {
                if (Program.Shops_in_use.Contains("C"))
                {
                    startup_ShowForm_proc = Startup_11_Show_Form_ShopC_Items_Edit;
                    return Startup_check_proc_Result.WAIT_USER_INTERACTION;
                }
                else
                {
                    return Startup_check_proc_Result.CHECK_OK;
                }
            }
        }

        private bool Startup_11_Show_Form_ShopC_Items_Edit(startup_step xstartup_step,
                                                            NavigationButtons.Navigation xnav,
                                                            ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            startup_OnFormResult_proc = Startup_11_onformresult_Form_ShopC_Items_Edit;
            xnav.ShowForm(new Form_Items_Samples(xnav, lng.s_Shop_C.s), "TangentaSampleDB.Form_Items_Samples");
            return true;
        }

        private Startup_onformresult_proc_Result Startup_11_onformresult_Form_ShopC_Items_Edit(startup_step myStartup_step,
                                                                                    Form form,
                                                                                    NavigationButtons.Navigation.eEvent eExitResult,
                                                                                    ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                                                    ref string Err)
        {
            switch (eExitResult)
            {
                case Navigation.eEvent.NEXT:
                    if (form is Form_Items_Samples)
                    {
                        if (m_startup.sbd.Startup_11_Write_ShopC_Items((Form_Items_Samples)form))
                        {
                            return Startup_onformresult_proc_Result.DO_CHECK_PROC_AGAIN;
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
