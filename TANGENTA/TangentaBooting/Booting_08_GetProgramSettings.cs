using DBConnectionControl40;
using LanguageControl;
using LayoutManager;
using NavigationButtons;
using Startup;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TangentaCore;
using TangentaDB;
using TangentaProperties;
using static Startup.startup_step;

namespace TangentaBooting
{
    public class Booting_08_GetProgramSettings
    {
        private startup_step.eStep eStep = eStep.Check_08_GetProgramSettings;

        private Form frm = null;
        private Startup.Startup m_startup = null;


        public Booting_08_GetProgramSettings(Form xfmain, Startup.Startup x_sturtup)
        {
            frm = xfmain;
            m_startup = x_sturtup;

        }


        internal startup_step CreateStep()
        {
            return new startup_step(lng.s_Startup_Get_ProgramSettings.s, m_startup, Booting.nav, Startup_08_GetProgramSettings,null, eStep);
        }

        public Startup_check_proc_Result Startup_08_GetProgramSettings(startup_step xstartup_step,
                                                   object oData,
                                                   ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                   ref string Err)
        {
            if (Startup_08_CheckPogramSettings(true))
            {
                return Startup_check_proc_Result.CHECK_OK;
            }
            else
            {
                startup_ShowForm_proc = Startup_08_Show_Form_ProgramSettings_Edit;
                return Startup_check_proc_Result.WAIT_USER_INTERACTION;
            }
        }

        private bool Startup_08_Show_Form_ProgramSettings_Edit(startup_step xstartup_step,
                                                            NavigationButtons.Navigation xnav,
                                                            ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            startup_OnFormResult_proc = Startup_08_onformresult_Form_ProgramSettings;
            Startup_08_Show_Form_ProgramSettings(xnav);
            return true;
        }

        private bool Startup_08_CheckPogramSettings(bool bResetShopsInUse)
        {
            if (!Set_ScreenLayoutDesign())
            {
                return false;
            }
            string spropertiesUser = PropertiesUser.ShopsInUse_Get(null);
            if ((Startup.Startup.bFirstTimeInstallation && Reset2FactorySettings.TangentaProperties) || spropertiesUser.Length == 0)
            {
                return false;
            }
            else
            {
                if (spropertiesUser.Length > 0)
                {
                    return true;
                }
            }
            return false;
        }

        private struct fdata
        {
            public string filename;
            public string data;
            public fdata(string xfilename, string xdata)
            {
                filename = xfilename;
                data = xdata;
            }
        }
        private bool Set_ScreenLayoutDesign()
        {
            string screen_layout_folder = Form_Layout.GetScreenLayoutFolder(frm);
            fdata[] filesAndData = new fdata[]{new fdata("s1920x1080_Form_Document.xml",TangentaResources.Properties.Resources.s1920x1080_Form_Document ),
                                               new fdata("s1680x1050_Form_Document.xml",TangentaResources.Properties.Resources.s1680x1050_Form_Document )
                                               };

            foreach (fdata fd in filesAndData)
            {
                string sfile = screen_layout_folder + fd.filename;
                if (File.Exists(sfile))
                {
                    if (Reset2FactorySettings.LayoutSettings)
                    {

                        List<object> lobj = new List<object>();
                        lobj.Add(lng.s_OverwriteExistingScreenControlLayoutForScreenResolution);
                        lobj.Add(fd.filename + " ?");
                        ltext ltMsg = new ltext(lobj);
                        if (XMessage.Box.Show(frm, ltMsg,"?",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
                        {
                            try
                            {
                                File.WriteAllText(sfile, fd.data);
                            }
                            catch (Exception ex)
                            {
                                LogFile.Error.Show("ERROR:TangentaBooting:Booting_08_GetProgramSettings:Set_ScreenLayoutDesign:Can not over-write file:\"" + sfile + "\", Exception=" + ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    try
                    {
                        File.WriteAllText(sfile, fd.data);
                    }
                    catch (Exception ex)
                    {
                        LogFile.Error.Show("ERROR:TangentaBooting:Booting_08_GetProgramSettings:Set_ScreenLayoutDesign:Can not over-write file:\"" + sfile + "\", Exception=" + ex.Message);
                    }
                }
            }
            return true;
        }

        private bool Startup_08_Show_Form_ProgramSettings(NavigationButtons.Navigation xnav)
        {
            xnav.ShowForm(new Form_ProgramSettings(frm,xnav), typeof(Form_ProgramSettings).ToString());
            return true;
        }



        private Startup_onformresult_proc_Result Startup_08_onformresult_Form_ProgramSettings(startup_step myStartup_step,
                                                                                    Form form,
                                                                                    NavigationButtons.Navigation.eEvent eExitResult,
                                                                                    ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                                                    ref string Err)
        {
            switch (eExitResult)
            {
                case Navigation.eEvent.NEXT:
                    if (form is Form_ProgramSettings)
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
                    LogFile.Error.Show("ERROR:Tangenta:FormDocument:Startup_06_onformresult_Form_Select_DefaultCurrency:eExitResult not implemented for xnav.eExitResult = " + eExitResult.ToString());
                    return Startup_onformresult_proc_Result.ERROR;
            }
        }
    }
}
