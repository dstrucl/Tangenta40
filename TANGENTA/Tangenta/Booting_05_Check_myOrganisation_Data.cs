using CodeTables;
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
using TangentaTableClass;
using static Startup.startup_step;

namespace Tangenta
{
    public class Booting_05_Check_myOrganisation_Data
    {
        private Form_Document frm = null;
        private startup m_startup = null;
        public PostAddress_v myorg_PostAddress_v = null;

      
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


        /// <summary>
        /// Startup_05_Check_myOrganisation_Data
        /// </summary>
        /// <param name="xstartup_step"></param>
        /// <param name="oData"></param>
        /// <param name="startup_ShowForm_proc"></param>
        /// <param name="Err"></param>
        /// <returns></returns>
        public Startup_check_proc_Result Startup_05_Check_myOrganisation_Data(startup_step xstartup_step,
                                                   object oData,
                                                   ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                   ref string Err)
        {
     
            myOrg.eGetOrganisationDataResult eres = this.Startup_05_Check_myOrganisation_Data();
            switch (eres)
            {
                case myOrg.eGetOrganisationDataResult.OK:

                    if (GlobalData.Get_ElectronicDevice_depended_definitions())
                    {
                        if (TangentaDB.myOrg.Address_v.Country_ISO_3166_num == Country_ISO_3166.ISO_3166_Table.SLOVENIA_COUNTRY_NUM)
                        {

                            if (FVICheckDefined())
                            {
                                return Startup_check_proc_Result.CHECK_OK;
                            }
                            else
                            {
                                startup_ShowForm_proc = Startup_05_Show_Form_FVI_check;
                                return Startup_check_proc_Result.WAIT_USER_INTERACTION;
                            }
                        }
                        else
                        {
                            return Startup_check_proc_Result.CHECK_OK;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:Tangenta:Booting_05_Check_myorganisation_Data:Startup_05_Check_myOrganisation_Data:GlobalData.Get_ElectronicDevice_depended_definitions():failed!");
                        return Startup_check_proc_Result.CHECK_ERROR;
                    }
                    

                case myOrg.eGetOrganisationDataResult.NO_ORGANISATION_NAME:
                    startup_ShowForm_proc = Startup_05_Show_Form_Select_Country_ISO_3166;
                    return Startup_check_proc_Result.WAIT_USER_INTERACTION;

                case myOrg.eGetOrganisationDataResult.NO_COUNTRY:
                case myOrg.eGetOrganisationDataResult.NO_ZIP:
                case myOrg.eGetOrganisationDataResult.NO_CITY:
                case myOrg.eGetOrganisationDataResult.NO_STREET_NAME:
                case myOrg.eGetOrganisationDataResult.NO_HOUSE_NUMBER:
                case myOrg.eGetOrganisationDataResult.NO_TAX_ID:
                    startup_ShowForm_proc = Startup_05_Show_Form_CheckInsertSampleData;
                    return Startup_check_proc_Result.WAIT_USER_INTERACTION;

                case myOrg.eGetOrganisationDataResult.NO_OFFICE:
                    startup_ShowForm_proc = Startup_05_Show_Form_myOrg_Office_Data;
                    return Startup_check_proc_Result.WAIT_USER_INTERACTION;

                case myOrg.eGetOrganisationDataResult.NO_MY_ORG_OFFICE_PERSON:
                    if (myOrg.m_myOrg_Office!=null)
                    {
                        startup_ShowForm_proc = Startup_05_Show_Form_myOrg_Person_Edit;
                        return Startup_check_proc_Result.WAIT_USER_INTERACTION;
                    }
                   else
                    {
                        startup_ShowForm_proc = Startup_05_Show_Form_myOrg_Office_Data;
                        return Startup_check_proc_Result.WAIT_USER_INTERACTION;
                    }

                case myOrg.eGetOrganisationDataResult.NO_MYORGANISATION_PERSON_SingleUser_FOR_THIS_ELECTRONIC_DEVICE_ID:
                    startup_ShowForm_proc = Startup_05_Show_Form_Select_Person_SINGLE_USER;
                    return Startup_check_proc_Result.WAIT_USER_INTERACTION;

                case myOrg.eGetOrganisationDataResult.NO_MY_ORG_OFFICE_PERSON_SINGLE_USER:
                        startup_ShowForm_proc = Startup_05_Show_Form_Select_Person_SINGLE_USER;
                        return Startup_check_proc_Result.WAIT_USER_INTERACTION;

                case myOrg.eGetOrganisationDataResult.NO_REAL_ESTATE:
                    if (TangentaDB.myOrg.Address_v.Country_ISO_3166_num == Country_ISO_3166.ISO_3166_Table.SLOVENIA_COUNTRY_NUM)
                    {
                        if (!FVICheckDefined())
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

                case myOrg.eGetOrganisationDataResult.NO_ELECTRONIC_DEVICE_NAME:
                    startup_ShowForm_proc = Startup_05_Show_Form_SetElectronicDeviceName;
                    return Startup_check_proc_Result.WAIT_USER_INTERACTION;

                default:
                    return Startup_check_proc_Result.CHECK_ERROR;

            }
        }

        /// <summary>
        /// Startup_05_Show_Form_FVI_check
        /// </summary>
        /// <param name="xstartup_step"></param>
        /// <param name="xnav"></param>
        /// <param name="startup_OnFormResult_proc"></param>
        /// <returns></returns>
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
            bool bCountryDefined = false;
            if (myorg_PostAddress_v!=null)
            {
                bCountryDefined=myorg_PostAddress_v.CountryDefined;
            }
            switch (eExitResult)
            {
                case Navigation.eEvent.NEXT:
                    // Result of Form_FVI_Check is stored in Program.bFVI_SLO and stored to Properties.Settings.Default.bFVI_SLO as string which can be ="1" or "0"
                    myOrg.eGetOrganisationDataResult eres = this.Startup_05_Check_myOrganisation_Data();
                    switch (eres)
                    {
                        case myOrg.eGetOrganisationDataResult.OK:
                            return Startup_onformresult_proc_Result.NEXT;


                        case myOrg.eGetOrganisationDataResult.NO_ORGANISATION_NAME:
                            if (!bCountryDefined)
                            {
                                startup_ShowForm_proc = Startup_05_Show_Form_Select_Country_ISO_3166;
                                return Startup_onformresult_proc_Result.WAIT_USER_INTERACTION;
                            }
                            else
                            {
                                startup_ShowForm_proc = Startup_05_Show_Form_CheckInsertSampleData;
                                return Startup_onformresult_proc_Result.WAIT_USER_INTERACTION;
                            }

                        case myOrg.eGetOrganisationDataResult.NO_COUNTRY:
                        case myOrg.eGetOrganisationDataResult.NO_ZIP:
                        case myOrg.eGetOrganisationDataResult.NO_CITY:
                        case myOrg.eGetOrganisationDataResult.NO_STREET_NAME:
                        case myOrg.eGetOrganisationDataResult.NO_HOUSE_NUMBER:
                        case myOrg.eGetOrganisationDataResult.NO_TAX_ID:
                            startup_ShowForm_proc = Startup_05_Show_Form_CheckInsertSampleData;
                            return Startup_onformresult_proc_Result.WAIT_USER_INTERACTION;

                        case myOrg.eGetOrganisationDataResult.NO_OFFICE:
                            startup_ShowForm_proc = Startup_05_Show_Form_myOrg_Office_Data;
                            return Startup_onformresult_proc_Result.WAIT_USER_INTERACTION;

                        case myOrg.eGetOrganisationDataResult.NO_MY_ORG_OFFICE_PERSON:
                            if (myOrg.m_myOrg_Office!= null)
                            {
                                startup_ShowForm_proc = Startup_05_Show_Form_myOrg_Person_Edit;
                                return Startup_onformresult_proc_Result.WAIT_USER_INTERACTION;
                            }
                            else
                            {
                                startup_ShowForm_proc = Startup_05_Show_Form_myOrg_Office_Data;
                                return Startup_onformresult_proc_Result.WAIT_USER_INTERACTION;
                            }
                         

                        case myOrg.eGetOrganisationDataResult.NO_REAL_ESTATE:
                            if (TangentaDB.myOrg.Address_v.Country_ISO_3166_num == Country_ISO_3166.ISO_3166_Table.SLOVENIA_COUNTRY_NUM)
                            {
                                if (!FVICheckDefined())
                                {
                                    startup_ShowForm_proc = Startup_05_Show_Form_FVI_check;
                                    return Startup_onformresult_proc_Result.WAIT_USER_INTERACTION;
                                }
                                else
                                {
                                    if (Program.b_FVI_SLO)
                                    {
                                        startup_ShowForm_proc = Startup_05_Show_Form_myOrg_Office_Data_FVI_SLO_RealEstateBP;
                                        return Startup_onformresult_proc_Result.WAIT_USER_INTERACTION;
                                    }
                                    else
                                    {
                                        return Startup_onformresult_proc_Result.NEXT;
                                    }
                                }
                            }
                            else
                            {
                                return Startup_onformresult_proc_Result.NEXT; 
                            }

                        default:
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
                    LogFile.Error.Show("ERROR:Tangenta:FormDocument:Startup_05_onformresult_Form_FVI_check:xnav.eExitResult not implemented for eExitResult = " + eExitResult.ToString());
                    return Startup_onformresult_proc_Result.ERROR;
            }
        }


        private bool FVICheckDefined()
        {
            string Err = null;
            bool bReadOnly = false;
            string sFiscalVerificationOfInvoices = null;
            switch (fs.GetDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.FiscalVerificationOfInvoices.Name, ref sFiscalVerificationOfInvoices, ref bReadOnly, ref Err))
            {
                case fs.enum_GetDBSettings.DBSettings_OK:
                    Program.b_FVI_SLO = sFiscalVerificationOfInvoices.Equals("1");
                    return true;

                case fs.enum_GetDBSettings.No_TextValue:
                case fs.enum_GetDBSettings.No_Data_Rows:
                case fs.enum_GetDBSettings.Error_Load_DBSettings:
                    return false;
            }
            return false;
        }

        /// <summary>
        /// Startup_05_Show_Form_Select_Country_ISO_3166
        /// </summary>
        /// <param name="xstartup_step"></param>
        /// <param name="xnav"></param>
        /// <param name="startup_OnFormResult_proc"></param>
        /// <returns></returns>
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
                        myorg_PostAddress_v = TangentaDB.myOrg.Address_v.Clone();

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

        /// <summary>
        /// Startup_05_Show_Form_CheckInsertSampleData
        /// </summary>
        /// <param name="xstartup_step"></param>
        /// <param name="xnav"></param>
        /// <param name="startup_OnFormResult_proc"></param>
        /// <returns></returns>
        private bool Startup_05_Show_Form_CheckInsertSampleData(startup_step xstartup_step,
                                                            NavigationButtons.Navigation xnav,
                                                            ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            startup_OnFormResult_proc = Startup_05_onformresult_Form_CheckInsertSampleData;
            return Startup_05_Show_Form_CheckInsertSampleData(m_startup, xnav);
        }

        private bool Startup_05_Show_Form_CheckInsertSampleData(startup myStartup, NavigationButtons.Navigation xnav)
        {
            xnav.ShowForm(new Form_CheckInsertSampleData(myStartup, xnav), typeof(Form_CheckInsertSampleData).ToString());
            return true;
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

        /// <summary>
        /// Startup_05_Show_Form_EditMyOrgSampleData
        /// </summary>
        /// <param name="xstartup_step"></param>
        /// <param name="xnav"></param>
        /// <param name="startup_OnFormResult_proc"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Startup_05_Show_Form_EditMyOrganisation_Data
        /// </summary>
        /// <param name="xstartup_step"></param>
        /// <param name="xnav"></param>
        /// <param name="startup_OnFormResult_proc"></param>
        /// <returns></returns>
        private bool Startup_05_Show_Form_EditMyOrganisation_Data(startup_step xstartup_step,
                                                            NavigationButtons.Navigation xnav,
                                                            ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            startup_OnFormResult_proc = Startup_05_onformresult_Form_EditMyOrganisation_Data;
            Startup_05_ShowForm_EditMyOrganisation_Data(false, xnav,myorg_PostAddress_v);
            return true;
        }

        internal bool Startup_05_Show_Form_myOrg_Office_Data_FVI_SLO_RealEstateBP(NavigationButtons.Navigation xnav)
        {
            xnav.ShowForm(new Form_myOrg_Office_Data_FVI_SLO_RealEstateBP(myOrg.myOrg_Office_list[0].Office_Data_ID, xnav), typeof(Form_myOrg_Office_Data_FVI_SLO_RealEstateBP).ToString());
            return true;
        }

        internal bool Startup_05_ShowForm_Form_myOrg_Person_Edit(ID x_Office_ID, bool bAllowNew, NavigationButtons.Navigation xnav)
        {
            xnav.ShowForm(new Form_myOrg_Person_Edit(x_Office_ID, null, xnav), typeof(Form_myOrg_Person_Edit).ToString());
            return true;
        }


        internal bool Startup_05_ShowForm_Form_Select_Person_SINGLE_USER(ID x_Office_ID, bool bAllowNew, NavigationButtons.Navigation xnav)
        {
            xnav.ShowForm(new Form_Select_Person_SINGLE_USER(x_Office_ID, xnav), typeof(Form_Select_Person_SINGLE_USER).ToString());
            return true;
        }

        internal bool Startup_05_ShowForm_EditMyOrganisation_Data(bool bAllowNew, NavigationButtons.Navigation xnav, PostAddress_v myorg_PostAddress_v)
        {
            xnav.ShowForm(new Form_myOrg_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables, new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(myOrganisation))), bAllowNew, xnav, myorg_PostAddress_v), typeof(Form_myOrg_Edit).ToString());
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

        /// <summary>
        /// Startup_05_Show_Form_myOrg_Office_Data
        /// </summary>
        /// <param name="xstartup_step"></param>
        /// <param name="xnav"></param>
        /// <param name="startup_OnFormResult_proc"></param>
        /// <returns></returns>
        private bool Startup_05_Show_Form_myOrg_Office_Data(startup_step xstartup_step,
                                                            NavigationButtons.Navigation xnav,
                                                            ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            startup_OnFormResult_proc = Startup_05_onformresult_Form_myOrg_Office_Data;
           return Startup_05_Show_Form_myOrg_Office_Data(xnav);
        }

        private bool Startup_05_Show_Form_myOrg_Office_Data(NavigationButtons.Navigation xnav)
        {
            if (myOrg.myOrg_Office_list.Count > 0)
            {
                xnav.ShowForm(new Form_myOrg_Office_Data(myOrg.Office_ID, xnav), typeof(Form_myOrg_Office_Data).ToString());
            }
            else
            {
                xnav.ShowForm(new Form_myOrg_Office_Data(null, xnav), typeof(Form_myOrg_Office_Data).ToString());
            }
            return true;
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

        /// <summary>
        /// Startup_05_Show_Form_myOrg_Person_Edit
        /// </summary>
        /// <param name="xstartup_step"></param>
        /// <param name="xnav"></param>
        /// <param name="startup_OnFormResult_proc"></param>
        /// <returns></returns>
        public bool Startup_05_Show_Form_myOrg_Person_Edit(startup_step xstartup_step,
                                                            NavigationButtons.Navigation xnav,
                                                            ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            startup_OnFormResult_proc = Startup_05_onformresult_Form_myOrg_Person_Edit;
            Startup_05_ShowForm_Form_myOrg_Person_Edit(myOrg.m_myOrg_Office.ID,true, xnav);
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



        /// <summary>
        /// Startup_05_Show_Form_Select_Person_SINGLE_USER
        /// </summary>
        /// <param name="xstartup_step"></param>
        /// <param name="xnav"></param>
        /// <param name="startup_OnFormResult_proc"></param>
        /// <returns></returns>
        public bool Startup_05_Show_Form_Select_Person_SINGLE_USER(startup_step xstartup_step,
                                                            NavigationButtons.Navigation xnav,
                                                            ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            startup_OnFormResult_proc = Startup_05_onformresult_Form_Select_Person_SINGLE_USER;
            Startup_05_ShowForm_Form_Select_Person_SINGLE_USER(myOrg.m_myOrg_Office.ID, true, xnav);
            return true;
        }

        private Startup_onformresult_proc_Result Startup_05_onformresult_Form_Select_Person_SINGLE_USER(startup_step myStartup_step,
                                                                               Form form,
                                                                               NavigationButtons.Navigation.eEvent eExitResult,
                                                                               ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                                               ref string Err)
        {
            switch (eExitResult)
            {
                case Navigation.eEvent.NEXT:
                    if (form is Form_Select_Person_SINGLE_USER)
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

        /// <summary>
        /// Startup_05_Show_Form_myOrg_Office_Data_FVI_SLO_RealEstateBP
        /// </summary>
        /// <param name="xstartup_step"></param>
        /// <param name="xnav"></param>
        /// <param name="startup_OnFormResult_proc"></param>
        /// <returns></returns>
        private bool Startup_05_Show_Form_myOrg_Office_Data_FVI_SLO_RealEstateBP(startup_step xstartup_step,
                                                            NavigationButtons.Navigation xnav,
                                                            ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            startup_OnFormResult_proc = Startup_05_onformresult_Form_myOrg_Office_Data_FVI_SLO_RealEstateBP;
           return Startup_05_Show_Form_myOrg_Office_Data_FVI_SLO_RealEstateBP(xnav);
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
                        //startup_ShowForm_proc = Startup_05_Show_FiscalVerificationOfInvoices_SLO_Form_Settings;
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

        /// <summary>
        /// Startup_05_Show_Form_SetElectronicDeviceName
        /// </summary>
        /// <param name="xstartup_step"></param>
        /// <param name="xnav"></param>
        /// <param name="startup_OnFormResult_proc"></param>
        /// <returns></returns>
        private bool Startup_05_Show_Form_SetElectronicDeviceName(startup_step xstartup_step,
                                                            NavigationButtons.Navigation xnav,
                                                            ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            startup_OnFormResult_proc = Startup_05_onformresult_Form_SetElectronicDeviceName;
            return Startup_05_Show_Form_SetElectronicDeviceName(xnav);
        }

        private bool Startup_05_Show_Form_SetElectronicDeviceName(NavigationButtons.Navigation xnav)
        {
            xnav.ShowForm(new Form_SetElectronicDeviceName(xnav), typeof(Form_myOrg_Office_Data_FVI_SLO_RealEstateBP).ToString());
            return true;
        }

        private Startup_onformresult_proc_Result Startup_05_onformresult_Form_SetElectronicDeviceName(startup_step myStartup_step,
                                                                               Form form,
                                                                               NavigationButtons.Navigation.eEvent eExitResult,
                                                                               ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                                               ref string Err)
        {
            switch (eExitResult)
            {
                case Navigation.eEvent.NEXT:
                    if (form is Form_SetElectronicDeviceName)
                    {
                        if (Program.b_FVI_SLO)
                        {
                            startup_ShowForm_proc = Startup_05_Show_FiscalVerificationOfInvoices_SLO_Form_Settings;
                            return Startup_onformresult_proc_Result.WAIT_USER_INTERACTION;
                        }
                        else
                        {
                            return Startup_onformresult_proc_Result.DO_CHECK_PROC_AGAIN;
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

        /// <summary>
        /// Startup_05_Show_FiscalVerificationOfInvoices_SLO_Form_Settings
        /// </summary>
        /// <param name="xstartup_step"></param>
        /// <param name="xnav"></param>
        /// <param name="startup_OnFormResult_proc"></param>
        /// <returns></returns>
        private bool Startup_05_Show_FiscalVerificationOfInvoices_SLO_Form_Settings(startup_step xstartup_step,
                                                    NavigationButtons.Navigation xnav,
                                                    ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            bool Reset2FactorySettings_FiscalVerification_DLL = Program.Reset2FactorySettings.FiscalVerification_DLL;
            startup_OnFormResult_proc = Startup_05_onformresult_FiscalVerificationOfInvoices_SLO_Form_Settings;
            xnav.ShowForm(new FiscalVerificationOfInvoices_SLO.Form_Settings(frm.fvI_SLO1, xnav, ref Reset2FactorySettings_FiscalVerification_DLL), typeof(FiscalVerificationOfInvoices_SLO.Form_Settings).ToString());
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

        internal myOrg.eGetOrganisationDataResult Startup_05_Check_myOrganisation_Data()
        {
            myOrg.eGetOrganisationDataResult eres = myOrg.GetOrganisationData(Program.bFirstTimeInstallation,
                                                                              Program.OperationMode.MultiUser,
                                                                              Program.b_FVI_SLO,
                                                                              ref Program.m_CountryHasFVI
                                                                              );
            return eres;

        }

    }
}
