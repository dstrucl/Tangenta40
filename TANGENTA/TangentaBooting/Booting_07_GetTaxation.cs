using CodeTables;
using DBConnectionControl40;
using NavigationButtons;
using Startup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TangentaCore;
using TangentaDB;
using TangentaTableClass;
using static Startup.startup_step;

namespace TangentaBooting
{
    public class Booting_07_GetTaxation
    {
        private startup_step.eStep eStep = eStep.Check_07_GetTaxation;
        public DBTablesAndColumnNamesOfDocInvoice DBtcn = null;

        private Form frm = null;
        private Startup.Startup m_startup = null;


        public Booting_07_GetTaxation(Form xfmain, Startup.Startup x_sturtup)
        {
            frm = xfmain;
            m_startup = x_sturtup;

        }


        internal startup_step CreateStep()
        {
            return new startup_step(lng.s_Startup_GetTaxation.s, m_startup, Booting.nav, Startup_07_GetTaxation,null, eStep);
        }

        public Startup_check_proc_Result Startup_07_GetTaxation(startup_step xstartup_step,
                                                   object oData,
                                                   ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                   ref string Err)
        {
            if (Startup_07_GetTaxation(ref Err))
            {
                return Startup_check_proc_Result.CHECK_OK;
            }
            else
            {
                startup_ShowForm_proc = Startup_07_Show_Form_Taxation_Edit;
                return Startup_check_proc_Result.WAIT_USER_INTERACTION;
            }
        }

        private bool Startup_07_GetTaxation(ref string Err)
        {
            Err = null;
            if (DBtcn == null)
            {
                DBtcn = new DBTablesAndColumnNamesOfDocInvoice();
            }

            ShopABC xShopABC = new ShopABC(DBtcn);

            return (xShopABC.m_xTaxationList != null);

        }

        private bool Startup_07_Show_Form_Taxation_Edit(startup_step xstartup_step,
                                                            NavigationButtons.Navigation xnav,
                                                            ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            startup_OnFormResult_proc = Startup_07_onformresult_Form_Taxation_Edit;
            Startup_07_Show_Form_Taxation_Edit(xnav);
            return true;
        }

        internal void Startup_07_Show_Form_Taxation_Edit(NavigationButtons.Navigation xnav)
        {
            SQLTable tbl_Taxation = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Taxation)));
            xnav.ShowForm(new Form_Taxation_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables, tbl_Taxation, "ID asc", xnav), typeof(Form_Taxation_Edit).ToString());
        }


        private Startup_onformresult_proc_Result Startup_07_onformresult_Form_Taxation_Edit(startup_step myStartup_step,
                                                                                    Form form,
                                                                                    NavigationButtons.Navigation.eEvent eExitResult,
                                                                                    ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                                                    ref string Err)
        {
            switch (eExitResult)
            {
                case Navigation.eEvent.NEXT:
                    if (form is Form_Taxation_Edit)
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
