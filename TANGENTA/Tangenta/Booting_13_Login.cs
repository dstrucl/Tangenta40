using DBConnectionControl40;
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
                if (frm.DocumentMan.GetWorkPeriod(m_startup, null, m_startup.nav, ref Err))
                {
                    return Startup_check_proc_Result.CHECK_OK;
                }
                else
                {
                    return Startup_check_proc_Result.CHECK_ERROR;
                }
            }
        }

        public bool Login_MultipleUsers_ShowControlAtStartup(startup myStartup, object oData, NavigationButtons.Navigation xnav, ref string Err)
        {
            bool bCancel = false;
            frm.loginControl1.Init(frm,LoginControl.LoginCtrl.eDataTableCreationMode.AWP,
                                            DBSync.DBSync.DB_for_Tangenta.m_DBTables.m_con,
                                            frm.EndProgram,
                                            null,
                                            LanguageControl.DynSettings.LanguageID,
                                            ref bCancel
                                            );
            if (frm.loginControl1.Login_MultipleUsers_ShowControlAtStartup(xnav,  frm.Activate_usrc_DocumentMan))
            {
                //myStartup.eNextStep++;
                if (Program.Login_MultipleUsers)
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
