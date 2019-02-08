﻿using CodeTables;
using DBConnectionControl40;
using NavigationButtons;
using ShopC_Forms;
//using ShopC;
using Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TangentaDB;
using TangentaProperties;
using TangentaSampleDB;
using static Startup.startup_step;

namespace TangentaBooting
{
    public class Booting_11_GetShopC_Items
    {
        private startup_step.eStep eStep = eStep.Check_11_GetShopC_Items;

        private Form frm = null;
        private Startup.Startup m_startup = null;


        public Booting_11_GetShopC_Items(Form xfmain, Startup.Startup x_sturtup)
        {
            frm = xfmain;
            m_startup = x_sturtup;

        }


        internal startup_step CreateStep()
        {
            return new startup_step(lng.s_Startup_GetShopC_Items.s, m_startup, Booting.nav, Startup_11_GetShopC_Items,null, eStep);
        }

        public Startup_check_proc_Result Startup_11_GetShopC_Items(startup_step xstartup_step,
                                                   object oData,
                                                   ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                   ref string Err)
        {
            if (PropertiesUser.ShopsInUse_Get(null).Contains("C"))
            {
                long ShopC_Items_Count = fs.GetTableRowsCount("Item");
                if (ShopC_Items_Count > 0)
                {
                    return Startup_check_proc_Result.CHECK_OK;
                }
                else
                {
                    if (PropertiesUser.ShopsInUse_Get(null).Contains("C"))
                    {
                        startup_ShowForm_proc = Startup_11_Show_Form_Items_Samples;
                        return Startup_check_proc_Result.WAIT_USER_INTERACTION;
                    }
                    else
                    {
                        return Startup_check_proc_Result.CHECK_OK;
                    }
                }
            }
            else
            {
                return Startup_check_proc_Result.CHECK_OK;
            }
        }

        private bool Startup_11_Show_Form_Items_Samples(startup_step xstartup_step,
                                                            NavigationButtons.Navigation xnav,
                                                            ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            startup_OnFormResult_proc = Startup_11_onformresult_Form_Items_Samples;
            xnav.ShowForm(new Form_Items_Samples(xnav, lng.s_Shop_C.s), typeof(Form_Items_Samples).ToString());
            return true;
        }

        private Startup_onformresult_proc_Result Startup_11_onformresult_Form_Items_Samples(startup_step myStartup_step,
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
                        Form_Items_Samples frm_Items_Samples = (Form_Items_Samples)form;
                        if (frm_Items_Samples.bAutoGenerateDemoSampleItems)
                        {
                            Transaction transaction_Startup_11_Write_ShopC_Items = DBSync.DBSync.NewTransaction("Startup_11_Write_ShopC_Items");
                            if (m_startup.sbd.Startup_11_Write_ShopC_Items((Form_Items_Samples)form, transaction_Startup_11_Write_ShopC_Items))
                            {
                                if (transaction_Startup_11_Write_ShopC_Items.Commit())
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
                                transaction_Startup_11_Write_ShopC_Items.Rollback();
                                return Startup_onformresult_proc_Result.ERROR;
                            }
                        }
                        else
                        {
                            startup_ShowForm_proc = Startup_10_Show_Form_ShopC_Item_Edit;
                            return Startup_onformresult_proc_Result.WAIT_USER_INTERACTION;
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
                    LogFile.Error.Show("ERROR:Tangenta:FormDocument:Startup_11_onformresult_Form_Items_Samples:eExitResult not implemented for xnav.eExitResult = " + eExitResult.ToString());
                    return Startup_onformresult_proc_Result.ERROR;
            }
        }

        private bool Startup_10_Show_Form_ShopC_Item_Edit(startup_step xstartup_step,
                                                          NavigationButtons.Navigation xnav,
                                                          ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            startup_OnFormResult_proc = Startup_10_onformresult_Form_ShopC_Item_Edit;
            SQLTable tbl_Item = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.Item)));
            xnav.ShowForm(new Form_ShopC_Item_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                            tbl_Item,
                                                            "Item_$$Code desc", xnav), typeof(Form_ShopC_Item_Edit).ToString());
            return true;
        }

        private Startup_onformresult_proc_Result Startup_10_onformresult_Form_ShopC_Item_Edit(startup_step myStartup_step,
                                                                                    Form form,
                                                                                    NavigationButtons.Navigation.eEvent eExitResult,
                                                                                    ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                                                    ref string Err)
        {
            switch (eExitResult)
            {
                case Navigation.eEvent.NEXT:
                    if (form is Form_ShopC_Item_Edit)
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
                    LogFile.Error.Show("ERROR:Tangenta:FormDocument:Form_ShopC_Item_Edit:eExitResult not implemented for xnav.eExitResult = " + eExitResult.ToString());
                    return Startup_onformresult_proc_Result.ERROR;
            }
        }
    }
}