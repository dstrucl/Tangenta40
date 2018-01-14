using Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static Startup.startup_step;

namespace Tangenta
{
    public partial class Form_Document
    {
        private startup_step CStartup_01_TangentaLicence()
        {
            return new startup_step(lng.s_Licence_checked.s, m_startup, Program.nav, Check_TangentaLicenceShown, m_startup.Do_showform_TangentaLicence, onformresult_TangentaLicence, startup_step.eStep.Check_01_TangentaLicence);
        }

        private Startup_check_proc_Result Check_TangentaLicenceShown(startup myStartup,
                                                   object oData,
                                                   NavigationButtons.Navigation xnav,
                                                   ref string Err)
        {
            if (Properties.Settings.Default.Startup_TangentaLicence_Showed)
            {
                return Startup_check_proc_Result.CHECK_OK;
            }
            else
            {
                return Startup_check_proc_Result.WAIT_USER_INTERACTION_0;
            }
        }

        private Startup_onformresult_proc_Result onformresult_TangentaLicence(startup myStartup,
                                                                                       object oData,
                                                                                       NavigationButtons.Navigation xnav,
                                                                                       ref string Err)
        {
            switch (xnav.eExitResult)
            {
                case NavigationButtons.Navigation.eEvent.NEXT:
                    Properties.Settings.Default.Startup_TangentaLicence_Showed = true;
                    Properties.Settings.Default.Save();
                    return Startup_onformresult_proc_Result.NEXT;

                case NavigationButtons.Navigation.eEvent.PREV:
                    return Startup_onformresult_proc_Result.PREV;

                case NavigationButtons.Navigation.eEvent.EXIT:
                    this.Close();
                    this.DialogResult = DialogResult.Cancel;
                    return Startup_onformresult_proc_Result.EXIT;

                case NavigationButtons.Navigation.eEvent.NOTHING:
                    // happens when check procedure is OK
                    return Startup_onformresult_proc_Result.NO_FORM_BUT_CHECK_OK;

                default:
                    LogFile.Error.Show("ERROR:Tangenta:Form_Document:onformresult_TangentaLicence  xnav.eExitResult = " + xnav.eExitResult.ToString() + " not implemented");
                    return Startup_onformresult_proc_Result.ERROR;
            }
        }
    }
}
