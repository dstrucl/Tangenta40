using DBConnectionControl40;
using NavigationButtons;
using Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TangentaDB;
using static Startup.startup_step;

namespace Tangenta
{
    public partial class Form_Document
    {
        

        private startup_step CStartup_05_Check_myOrganisation_Data()
        {
            return new startup_step(lng.s_Startup_Check_myOrganisation_Data.s, m_startup, Program.nav, Startup_05_Check_myOrganisation_Data, Startup_05_ShowmyOrganisation_DataForm, Startup_05_onformresult_ShowmyOrganisation_Data, startup_step.eStep.Check_05_myOrganisation_Data);
        }

        public Startup_check_proc_Result Startup_05_Check_myOrganisation_Data(startup myStartup, object o, NavigationButtons.Navigation xnav, ref string Err)
        {
            usrc_Invoice.eGetOrganisationDataResult eres = this.m_usrc_Main.Startup_05_Check_myOrganisation_Data();
            switch (eres)
            {
                case usrc_Invoice.eGetOrganisationDataResult.OK:
                    return Startup_check_proc_Result.CHECK_OK;
                case usrc_Invoice.eGetOrganisationDataResult.NO_ORGANISATION_NAME:
                    return Startup_check_proc_Result.WAIT_USER_INTERACTION_0;

                case usrc_Invoice.eGetOrganisationDataResult.NO_COUNTRY:
                case usrc_Invoice.eGetOrganisationDataResult.NO_ZIP:
                case usrc_Invoice.eGetOrganisationDataResult.NO_CITY:
                case usrc_Invoice.eGetOrganisationDataResult.NO_STREET_NAME:
                case usrc_Invoice.eGetOrganisationDataResult.NO_HOUSE_NUMBER:
                case usrc_Invoice.eGetOrganisationDataResult.NO_TAX_ID:
                    return Startup_check_proc_Result.WAIT_USER_INTERACTION_3;

                case usrc_Invoice.eGetOrganisationDataResult.NO_OFFICE:
                    return Startup_check_proc_Result.WAIT_USER_INTERACTION_4;

                case usrc_Invoice.eGetOrganisationDataResult.NO_REAL_ESTATE:
                    return Startup_check_proc_Result.WAIT_USER_INTERACTION_5;

                default:
                    return Startup_check_proc_Result.CHECK_ERROR;

            }
        }

        private bool Startup_05_ShowmyOrganisation_DataForm(object oData, Navigation xnav, startup_step.Startup_check_proc_Result echeck_proc_Result, ref string Err)
        {
            bool bCanceled = false;
            switch (echeck_proc_Result)
            {
                case Startup_check_proc_Result.WAIT_USER_INTERACTION_0:
                    m_startup.sbd.Startup_05_Form_Select_Country_ISO_3166_ShowForm(ref bCanceled, xnav, Properties.Resources.Tangenta_Icon);
                    break;

                case Startup_check_proc_Result.WAIT_USER_INTERACTION_1:
                    m_usrc_Main.Startup_05_Show_Form_CheckInsertSampleData(m_startup, xnav);
                    break;

                case Startup_check_proc_Result.WAIT_USER_INTERACTION_2:
                    m_startup.sbd.Startup_05_MyOrgSampleShowForm(ref bCanceled, xnav, Properties.Resources.Tangenta_Icon);
                    break;

                case Startup_check_proc_Result.WAIT_USER_INTERACTION_3:
                    m_usrc_Main.m_usrc_InvoiceMan.m_usrc_Invoice.Startup_05_ShowForm_EditMyOrganisation_Data(false, xnav);
                    break;

                case Startup_check_proc_Result.WAIT_USER_INTERACTION_4:
                    m_usrc_Main.m_usrc_InvoiceMan.m_usrc_Invoice.Startup_05_Show_Form_myOrg_Office_Data(xnav);
                    break;

                case Startup_check_proc_Result.WAIT_USER_INTERACTION_5:
                    m_usrc_Main.m_usrc_InvoiceMan.m_usrc_Invoice.Startup_05_Show_Form_myOrg_Office_Data_FVI_SLO_RealEstateBP(xnav);
                    break;

            }
            return true;
        }

        private Startup_onformresult_proc_Result Startup_05_onformresult_ShowmyOrganisation_Data(startup myStartup, object oData, Navigation xnav, ref string Err)
        {
            switch (xnav.eExitResult)
            {
                case Navigation.eEvent.NEXT:
                        return Startup_onformresult_proc_Result.NEXT;

                case Navigation.eEvent.PREV:
                    return Startup_onformresult_proc_Result.PREV;

                case Navigation.eEvent.EXIT:
                    return Startup_onformresult_proc_Result.EXIT;

                case NavigationButtons.Navigation.eEvent.NOTHING:
                    // happens when check procedure is OK
                    return Startup_onformresult_proc_Result.NO_FORM_BUT_CHECK_OK;

                default:
                    LogFile.Error.Show("ERROR:Tangenta:FormDocument:onformresult_ShowDataBaseTypeSelectionForm:xnav.eExitResult not implemented for xnav.eExitResult = " + xnav.eExitResult.ToString());
                    return Startup_onformresult_proc_Result.ERROR;
            }
        }
    }
}
