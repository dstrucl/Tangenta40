﻿using DBConnectionControl40;
using NavigationButtons;
using Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TangentaCore;
using TangentaDB;
using TangentaPrint;
using TangentaProperties;
using static Startup.startup_step;

namespace TangentaBooting
{
    public class Booting_13_Login
    {
        private startup_step.eStep eStep = eStep.Check_13_Login;

        private Form frm = null;
        private Startup.Startup m_startup = null;


        public Booting_13_Login(Form xfmain, Startup.Startup x_sturtup)
        {
            frm = xfmain;
            m_startup = x_sturtup;

        }


        internal startup_step CreateStep()
        {
            return new startup_step(lng.s_Startup_Login.s, m_startup, Booting.nav, Startup_13_Login,null, eStep);
        }

        public Startup_check_proc_Result Startup_13_Login(startup_step xstartup_step,
                                                   object oData,
                                                   ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                   ref string Err)
        {
            if (TSettings.Login_MultipleUsers)
            {
                if (Login_MultipleUsers_ShowControlAtStartup(m_startup, null, m_startup.nav, ref Err))
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
                Transaction transaction_Startup_13_Login = DBSync.DBSync.NewTransaction("Startup_13_Login");
                if (DocumentMan.GetWorkPeriod(DocumentMan.Form_Document,m_startup, null, m_startup.nav, transaction_Startup_13_Login, ref Err))
                {
                    if (transaction_Startup_13_Login.Commit())
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
                    transaction_Startup_13_Login.Rollback();
                    return Startup_check_proc_Result.CHECK_ERROR;
                }
            }
        }

        public bool Login_MultipleUsers_ShowControlAtStartup(Startup.Startup myStartup, object oData, NavigationButtons.Navigation xnav, ref string Err)
        {
            bool bCancel = false;
            TSettings.LoginControl1.Init(frm,LoginControl.LoginCtrl.eDataTableCreationMode.AWP,
                                            DBSync.DBSync.Con,
                                            null,
                                            LanguageControl.DynSettings.LanguageID,
                                            false,
                                            ref bCancel
                                            );
            if (TSettings.LoginControl1.Login_MultipleUsers_ShowControlAtStartup(xnav, TSettings.ShowAdministratorsInMultiuserLogin))
            {
                //myStartup.eNextStep++;
                if (TSettings.Login_MultipleUsers)
                {
                    return true;
                }
                else
                {
                    if (myOrg.m_myOrg_Office.m_myOrg_Person == null)
                    {
                        LogFile.Error.Show("ERROR:Tangenta:usrc_DocumentMan:GetWorkPeriod:myOrg.m_myOrg_Office.m_myOrg_Person==null");
                        return false;
                    }
                }
                return true;
            }
            else
            {
                //myStartup.eNextStep = Startup.startup_step.eStep.Cancel;
                return false;
            }
        }
     }
}