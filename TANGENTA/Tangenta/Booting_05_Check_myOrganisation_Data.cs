using Country_ISO_3166;
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
    public class Booting_05_Check_myOrganisation_Data
    {
        private startup_step.eStep eStep = eStep.Check_05_myOrganisation_Data;

        private Form_Document frm = null;
        private startup m_startup = null;

        private long myOffice_ID = -1;

        public Booting_05_Check_myOrganisation_Data(Form_Document xfmain, startup x_sturtup)
        {
            frm = xfmain;
            m_startup = x_sturtup;

        }


        internal startup_step CreateStep()
        {
            return new startup_step(lng.s_Startup_Check_myOrganisation_Data.s, m_startup, Program.nav,
                                    Startup_05_Check_myOrganisation_Data,
                                    null,
                                    startup_step.eStep.Check_05_myOrganisation_Data);
        }

        public Startup_check_proc_Result Startup_05_Check_myOrganisation_Data(startup_step xstartup_step,
                                                   object oData,
                                                   ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                   ref string Err)
        {
            if (Properties.Settings.Default.bFVI_SLO.Equals("1"))
            {
                Program.b_FVI_SLO = true;
            }
            else if (Properties.Settings.Default.bFVI_SLO.Equals("0"))
            {
                Program.b_FVI_SLO = false;
            }

            usrc_DocumentEditor.eGetOrganisationDataResult eres = frm.m_usrc_Main.Startup_05_Check_myOrganisation_Data();
            switch (eres)
            {
                case usrc_DocumentEditor.eGetOrganisationDataResult.OK:
                    return Startup_check_proc_Result.CHECK_OK;
                case usrc_DocumentEditor.eGetOrganisationDataResult.NO_ORGANISATION_NAME:
                    startup_ShowForm_proc = Startup_05_Show_Form_Select_Country_ISO_3166;
                    return Startup_check_proc_Result.WAIT_USER_INTERACTION;

                case usrc_DocumentEditor.eGetOrganisationDataResult.NO_COUNTRY:
                case usrc_DocumentEditor.eGetOrganisationDataResult.NO_ZIP:
                case usrc_DocumentEditor.eGetOrganisationDataResult.NO_CITY:
                case usrc_DocumentEditor.eGetOrganisationDataResult.NO_STREET_NAME:
                case usrc_DocumentEditor.eGetOrganisationDataResult.NO_HOUSE_NUMBER:
                case usrc_DocumentEditor.eGetOrganisationDataResult.NO_TAX_ID:
                    startup_ShowForm_proc = Startup_05_Show_Form_CheckInsertSampleData;
                    return Startup_check_proc_Result.WAIT_USER_INTERACTION;

                case usrc_DocumentEditor.eGetOrganisationDataResult.NO_OFFICE:
                    startup_ShowForm_proc = Startup_05_Show_Form_myOrg_Office_Data;
                    return Startup_check_proc_Result.WAIT_USER_INTERACTION;

                case usrc_DocumentEditor.eGetOrganisationDataResult.NO_MY_ORG_PERSON:
                    if (myOrg.myOrg_Office_list!=null)
                    {
                        if (myOrg.myOrg_Office_list.Count>0)
                        {
                            if (myOrg.myOrg_Office_list[0].ID_v != null)
                            {
                                myOffice_ID = myOrg.myOrg_Office_list[0].ID_v.v;
                            }
                        }
                    }
                    startup_ShowForm_proc = Startup_05_Show_Form_myOrg_Person_Edit;
                    return Startup_check_proc_Result.WAIT_USER_INTERACTION;

                case usrc_DocumentEditor.eGetOrganisationDataResult.NO_REAL_ESTATE:
                    if (TangentaDB.myOrg.Address_v.Country_ISO_3166_num == Country_ISO_3166.ISO_3166_Table.SLOVENIA_COUNTRY_NUM)
                    {
                        if (Properties.Settings.Default.bFVI_SLO.Length == 0)
                        {
                            startup_ShowForm_proc = Startup_05_Show_Form_FVI_check;
                            return Startup_check_proc_Result.WAIT_USER_INTERACTION;
                        }
                        else
                        {
                            if (Program.b_FVI_SLO)
                            {
                                startup_ShowForm_proc = Startup_05_Show_Form_myOrg_Office_Data_FVI_SLO_RealEstateBP;
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

                default:
                    return Startup_check_proc_Result.CHECK_ERROR;

            }
        }


        private bool Startup_05_Show_Form_Select_Country_ISO_3166(startup_step xstartup_step,
                                                            NavigationButtons.Navigation xnav,
                                                            ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            bool bCanceled = false;

            startup_OnFormResult_proc = Startup_05_onformresult_Form_Select_Country_ISO_3166;
            return m_startup.sbd.Startup_05_Form_Select_Country_ISO_3166_ShowForm(ref bCanceled, xnav, Properties.Resources.Tangenta_Icon);
        }

        private Startup_onformresult_proc_Result Startup_05_onformresult_Form_Select_Country_ISO_3166(startup_step myStartup_step,
                                                                                    Form form,
                                                                                    NavigationButtons.Navigation.eEvent eExitResult,
                                                                                    ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                                                    ref string Err)
        {
            switch (eExitResult)
            {
                case Navigation.eEvent.NEXT:
                    if (form is Form_Select_Country_ISO_3166)
                    {
                        Form_Select_Country_ISO_3166 frm_Select_Country_ISO_3166 = (Form_Select_Country_ISO_3166)form;
                        if (TangentaDB.myOrg.Address_v == null)
                        {
                            TangentaDB.myOrg.Address_v = new TangentaDB.PostAddress_v();
                        }
                        if (TangentaDB.myOrg.Address_v.Country_v == null)
                        {
                            TangentaDB.myOrg.Address_v.Country_v = new DBTypes.dstring_v(frm_Select_Country_ISO_3166.Country);
                            TangentaDB.myOrg.Address_v.Country_ISO_3166_a2_v = new DBTypes.dstring_v(frm_Select_Country_ISO_3166.Country_ISO_3166_a2);
                            TangentaDB.myOrg.Address_v.Country_ISO_3166_a3_v = new DBTypes.dstring_v(frm_Select_Country_ISO_3166.Country_ISO_3166_a3);
                            TangentaDB.myOrg.Address_v.Country_ISO_3166_num_v = new DBTypes.dshort_v(frm_Select_Country_ISO_3166.Country_ISO_3166_num);
                        }

                        m_startup.sbd.myOrgSample.SetCountry(frm_Select_Country_ISO_3166);

                        if (TangentaDB.myOrg.Address_v.Country_ISO_3166_num_v.v == ISO_3166_Table.SLOVENIA_COUNTRY_NUM)
                        {
                            startup_ShowForm_proc = Startup_05_Show_Form_FVI_check;
                            return Startup_onformresult_proc_Result.WAIT_USER_INTERACTION;
                        }
                        else
                        {
                            startup_ShowForm_proc = Startup_05_Show_Form_CheckInsertSampleData;
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
                    LogFile.Error.Show("ERROR:Tangenta:FormDocument:Startup_05_onformresult_Form_Select_Country_ISO_3166:eExitResult not implemented for xnav.eExitResult = " + eExitResult.ToString());
                    return Startup_onformresult_proc_Result.ERROR;
            }
        }

        private bool Startup_05_Show_Form_FVI_check(startup_step xstartup_step,
                                                           NavigationButtons.Navigation xnav,
                                                           ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            startup_OnFormResult_proc = Startup_05_onformresult_Form_FVI_check;
            xnav.ShowForm(new Form_FVI_check(xnav), typeof(Form_FVI_check).ToString());
            return true;
        }

        private Startup_onformresult_proc_Result Startup_05_onformresult_Form_FVI_check(startup_step myStartup_step,
                                                                                   Form form,
                                                                                   NavigationButtons.Navigation.eEvent eExitResult,
                                                                                   ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                                                   ref string Err)
        {
            switch (eExitResult)
            {
                case Navigation.eEvent.NEXT:
                    // Result of Form_FVI_Check is stored in Program.bFVI_SLO and stored to Properties.Settings.Default.bFVI_SLO as string which can be ="1" or "0"
                    startup_ShowForm_proc = Startup_05_Show_Form_CheckInsertSampleData;
                    return Startup_onformresult_proc_Result.WAIT_USER_INTERACTION;


                case Navigation.eEvent.PREV:
                    return Startup_onformresult_proc_Result.PREV;

                case Navigation.eEvent.EXIT:
                    return Startup_onformresult_proc_Result.EXIT;

                case NavigationButtons.Navigation.eEvent.NOTHING:
                    // happens when check procedure is OK
                    return Startup_onformresult_proc_Result.NO_FORM_BUT_CHECK_OK;

                default:
                    LogFile.Error.Show("ERROR:Tangenta:FormDocument:Startup_05_onformresult_Form_FVI_check:xnav.eExitResult not implemented for eExitResult = " + eExitResult.ToString());
                    return Startup_onformresult_proc_Result.ERROR;
            }
        }


        private bool Startup_05_Show_Form_CheckInsertSampleData(startup_step xstartup_step,
                                                            NavigationButtons.Navigation xnav,
                                                            ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            startup_OnFormResult_proc = Startup_05_onformresult_Form_CheckInsertSampleData;
            return frm.m_usrc_Main.Startup_05_Show_Form_CheckInsertSampleData(m_startup, xnav);
        }


        private Startup_onformresult_proc_Result Startup_05_onformresult_Form_CheckInsertSampleData(startup_step myStartup_step,
                                                                                   Form form,
                                                                                   NavigationButtons.Navigation.eEvent eExitResult,
                                                                                   ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                                                   ref string Err)
        {
            switch (eExitResult)
            {
                case Navigation.eEvent.NEXT:
                    if (form is Form_CheckInsertSampleData)
                    {
                        Form_CheckInsertSampleData frm_CheckInsertSampleData = (Form_CheckInsertSampleData)form;
                        if (frm_CheckInsertSampleData.WritePredefinedDefaultDataInDataBase)
                        {
                            startup_ShowForm_proc = Startup_05_Show_Form_EditMyOrgSampleData;
                            return Startup_onformresult_proc_Result.WAIT_USER_INTERACTION;
                        }
                        else
                        {
                            startup_ShowForm_proc = Startup_05_Show_Form_EditMyOrganisation_Data;
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
                    LogFile.Error.Show("ERROR:Tangenta:FormDocument:Startup_05_onformresult_Form_CheckInsertSampleData:xnav.eExitResult not implemented for eExitResult = " + eExitResult.ToString());
                    return Startup_onformresult_proc_Result.ERROR;
            }
        }

        private bool Startup_05_Show_Form_EditMyOrgSampleData(startup_step xstartup_step,
                                                            NavigationButtons.Navigation xnav,
                                                            ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            bool xbCanceled = false;
            startup_OnFormResult_proc = Startup_05_onformresult_Form_EditMyOrgSampleData;
            m_startup.sbd.Startup_05_Show_Form_EditMyOrgSampleData(ref xbCanceled, xnav, Properties.Resources.Tangenta_Icon);
            return true;
        }


        private Startup_onformresult_proc_Result Startup_05_onformresult_Form_EditMyOrgSampleData(startup_step myStartup_step,
                                                                                  Form form,
                                                                                  NavigationButtons.Navigation.eEvent eExitResult,
                                                                                  ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                                                  ref string Err)
        {
            switch (eExitResult)
            {
                case Navigation.eEvent.NEXT:
                    if (form is Form_EditMyOrgSampleData)
                    {
                        m_startup.sbd.WriteMyOrg();
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
                    LogFile.Error.Show("ERROR:Tangenta:FormDocument:Startup_05_onformresult_Form_CheckInsertSampleData:xnav.eExitResult not implemented for eExitResult = " + eExitResult.ToString());
                    return Startup_onformresult_proc_Result.ERROR;
            }
        }

        private bool Startup_05_Show_Form_EditMyOrganisation_Data(startup_step xstartup_step,
                                                            NavigationButtons.Navigation xnav,
                                                            ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            startup_OnFormResult_proc = Startup_05_onformresult_Form_EditMyOrganisation_Data;
            frm.m_usrc_Main.m_usrc_DocumentEditor.Startup_05_ShowForm_EditMyOrganisation_Data(false, xnav);
            return true;
        }

        private Startup_onformresult_proc_Result Startup_05_onformresult_Form_EditMyOrganisation_Data(startup_step myStartup_step,
                                                                                 Form form,
                                                                                 NavigationButtons.Navigation.eEvent eExitResult,
                                                                                 ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                                                 ref string Err)
        {
            switch (eExitResult)
            {
                case Navigation.eEvent.NEXT:
                    if (form is Form_myOrg_Edit)
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
                    LogFile.Error.Show("ERROR:Tangenta:FormDocument:Startup_05_onformresult_Form_CheckInsertSampleData:xnav.eExitResult not implemented for eExitResult = " + eExitResult.ToString());
                    return Startup_onformresult_proc_Result.ERROR;
            }
        }

        private bool Startup_05_Show_Form_myOrg_Office_Data(startup_step xstartup_step,
                                                            NavigationButtons.Navigation xnav,
                                                            ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            startup_OnFormResult_proc = Startup_05_onformresult_Form_myOrg_Office_Data;
           return frm.m_usrc_Main.m_usrc_DocumentEditor.Startup_05_Show_Form_myOrg_Office_Data(xnav);
        }

        private Startup_onformresult_proc_Result Startup_05_onformresult_Form_myOrg_Office_Data(startup_step myStartup_step,
                                                                                 Form form,
                                                                                 NavigationButtons.Navigation.eEvent eExitResult,
                                                                                 ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                                                 ref string Err)
        {
            switch (eExitResult)
            {
                case Navigation.eEvent.NEXT:
                    if (form is Form_myOrg_Office_Data)
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
                    LogFile.Error.Show("ERROR:Tangenta:FormDocument:Startup_05_onformresult_Form_CheckInsertSampleData:eExitResult not implemented for eExitResult = " + eExitResult.ToString());
                    return Startup_onformresult_proc_Result.ERROR;
            }
        }

        public bool Startup_05_Show_Form_myOrg_Person_Edit(startup_step xstartup_step,
                                                            NavigationButtons.Navigation xnav,
                                                            ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            startup_OnFormResult_proc = Startup_05_onformresult_Form_myOrg_Person_Edit;
            frm.m_usrc_Main.m_usrc_DocumentEditor.Startup_05_ShowForm_Form_myOrg_Person_Edit(myOffice_ID,true, xnav);
            return true;
        }

        private Startup_onformresult_proc_Result Startup_05_onformresult_Form_myOrg_Person_Edit(startup_step myStartup_step,
                                                                               Form form,
                                                                               NavigationButtons.Navigation.eEvent eExitResult,
                                                                               ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                                               ref string Err)
        {
            switch (eExitResult)
            {
                case Navigation.eEvent.NEXT:
                    if (form is Form_myOrg_Person_Edit)
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
                    LogFile.Error.Show("ERROR:Tangenta:FormDocument:Startup_05_onformresult_Form_myOrg_Person_Edit:eExitResult not implemented for eExitResult = " + eExitResult.ToString());
                    return Startup_onformresult_proc_Result.ERROR;
            }
        }

        private bool Startup_05_Show_Form_myOrg_Office_Data_FVI_SLO_RealEstateBP(startup_step xstartup_step,
                                                            NavigationButtons.Navigation xnav,
                                                            ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            startup_OnFormResult_proc = Startup_05_onformresult_Form_myOrg_Office_Data_FVI_SLO_RealEstateBP;
           return frm.m_usrc_Main.m_usrc_DocumentEditor.Startup_05_Show_Form_myOrg_Office_Data_FVI_SLO_RealEstateBP(xnav);
        }

        private Startup_onformresult_proc_Result Startup_05_onformresult_Form_myOrg_Office_Data_FVI_SLO_RealEstateBP(startup_step myStartup_step,
                                                                               Form form,
                                                                               NavigationButtons.Navigation.eEvent eExitResult,
                                                                               ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                                               ref string Err)
        {
            switch (eExitResult)
            {
                case Navigation.eEvent.NEXT:
                    if (form is Form_myOrg_Office_Data_FVI_SLO_RealEstateBP)
                    {
                        startup_ShowForm_proc = Startup_05_Show_FiscalVerificationOfInvoices_SLO_Form_Settings;
                        return Startup_onformresult_proc_Result.WAIT_USER_INTERACTION;
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
                    LogFile.Error.Show("ERROR:Tangenta:FormDocument:Startup_05_onformresult_Form_CheckInsertSampleData:xnav.eExitResult not implemented for eExitResult = " + eExitResult.ToString());
                    return Startup_onformresult_proc_Result.ERROR;
            }
        }

        private bool Startup_05_Show_FiscalVerificationOfInvoices_SLO_Form_Settings(startup_step xstartup_step,
                                                    NavigationButtons.Navigation xnav,
                                                    ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            bool Reset2FactorySettings_FiscalVerification_DLL = Program.Reset2FactorySettings.FiscalVerification_DLL;
            startup_OnFormResult_proc = Startup_05_onformresult_FiscalVerificationOfInvoices_SLO_Form_Settings;
            xnav.ShowForm(new FiscalVerificationOfInvoices_SLO.Form_Settings(frm.m_usrc_Main.usrc_FVI_SLO1, xnav, ref Reset2FactorySettings_FiscalVerification_DLL), typeof(FiscalVerificationOfInvoices_SLO.Form_Settings).ToString());
            return true;
        }

        private Startup_onformresult_proc_Result Startup_05_onformresult_FiscalVerificationOfInvoices_SLO_Form_Settings(startup_step myStartup_step,
                                                                               Form form,
                                                                               NavigationButtons.Navigation.eEvent eExitResult,
                                                                               ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                                               ref string Err)
        {
            switch (eExitResult)
            {
                case Navigation.eEvent.NEXT:
                    if (form is FiscalVerificationOfInvoices_SLO.Form_Settings)
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
                    LogFile.Error.Show("ERROR:Tangenta:FormDocument:Startup_05_onformresult_Form_CheckInsertSampleData:xnav.eExitResult not implemented for eExitResult = " + eExitResult.ToString());
                    return Startup_onformresult_proc_Result.ERROR;
            }
        }
    }
}
