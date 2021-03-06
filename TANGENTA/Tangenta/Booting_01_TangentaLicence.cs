﻿using Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static Startup.startup_step;

namespace Tangenta
{
    public  class Booting_01_TangentaLicence
    {

        private Form_Document frm = null;
        private startup m_startup = null;


        public Booting_01_TangentaLicence(Form_Document xfmain, startup x_sturtup)
        {
            frm = xfmain;
            m_startup = x_sturtup;

        }

        internal startup_step CreateStep()
        {
            return new startup_step(lng.s_Licence_checked.s, m_startup, Program.nav,
                                    Startup_01_Check_TangentaLicenceShown,
                                    Startup_01_Undo,
                                    startup_step.eStep.Check_01_TangentaLicence);
        }

        private Startup_check_proc_Result Startup_01_Check_TangentaLicenceShown(startup_step xstartup_step,
                                                   object oData,
                                                   ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                   ref string Err)
        {
            
            if (Properties.Settings.Default.Startup_TangentaLicence_Showed)
            {
                return Startup_check_proc_Result.CHECK_OK;
            }
            else
            {
                startup_ShowForm_proc = Startup_01_Do_showform_TangentaLicence;
                return Startup_check_proc_Result.WAIT_USER_INTERACTION;
            }
        }

        internal Startup_eUndoProcedureResult Startup_01_Undo(startup_step xstartup_step,
                                         ref string Err)
        {
            return Startup_eUndoProcedureResult.NO_UNDO;
        }


        private bool Startup_01_Do_showform_TangentaLicence(startup_step xstartup_step,
                                                            NavigationButtons.Navigation xnav,
                                                            ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            startup_OnFormResult_proc = Startup_01_onformresult_TangentaLicence;
            return m_startup.Startup_01_Do_showform_TangentaLicence(xnav);
        }

        private Startup_onformresult_proc_Result Startup_01_onformresult_TangentaLicence(startup_step myStartup_step,
                                                                                            Form form,
                                                                                            NavigationButtons.Navigation.eEvent eExitResult,
                                                                                            ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                                                            ref string Err)
        {
            switch (eExitResult)
            {
                case NavigationButtons.Navigation.eEvent.NEXT:
                    Properties.Settings.Default.Startup_TangentaLicence_Showed = true;
                    Properties.Settings.Default.Save();
                    return Startup_onformresult_proc_Result.NEXT;

                case NavigationButtons.Navigation.eEvent.PREV:
                    return Startup_onformresult_proc_Result.PREV;

                case NavigationButtons.Navigation.eEvent.EXIT:
                    frm.Close();
                    frm.DialogResult = DialogResult.Cancel;
                    return Startup_onformresult_proc_Result.EXIT;

                case NavigationButtons.Navigation.eEvent.NOTHING:
                    // happens when check procedure is OK
                    return Startup_onformresult_proc_Result.NO_FORM_BUT_CHECK_OK;

                default:
                    LogFile.Error.Show("ERROR:Tangenta:Form_Document:onformresult_TangentaLicence  xnav.eExitResult = " + eExitResult.ToString() + " not implemented");
                    return Startup_onformresult_proc_Result.ERROR;
            }
        }
    }
}
