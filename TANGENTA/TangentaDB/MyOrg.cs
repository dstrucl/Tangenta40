#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeTables;
using TangentaTableClass;
using DBConnectionControl40;
using System.Data;
using System.Drawing;
using DBTypes;
using Country_ISO_3166;
using System.Windows.Forms;

namespace TangentaDB
{
    public static class myOrg
    {

        public static ID ID = null;
        public static string_v Name_v = null;
        public static PostAddress_v Address_v = new PostAddress_v();
        public static string_v Tax_ID_v = null;
        public static string_v Registration_ID_v = null;
        public static bool_v TayPayer_v = null;
        public static string_v Comment1_v = null;
        public static string_v OrganisationTYPE_v = null;
        public static string_v PhoneNumber_v = null;
        public static string_v FaxNumber_v = null;
        public static string_v Email_v = null;
        public static string_v HomePage_v = null;
        public static string_v BankName_v = null;
        public static string_v TRR_v = null;
        public static Image Logo = null;
        public static string_v Logo_Hash_v = null;
        public static byte_array_v Logo_Image_Data_v = null;
        public static string_v Logo_Description_v = null;

        public static myOrg_Office m_myOrg_Office = null;


        public static ID Office_ID
        {
            get
            {
                if (m_myOrg_Office!=null)
                {
                    return m_myOrg_Office.ID;
                }
                else
                {
                    return null;
                }
            }
        }


        public static ID ElectronicDevice_ID
        {
            get
            {
                if (m_myOrg_Office != null)
                {
                    return m_myOrg_Office.ElectronicDevice_ID;
                }
                else
                {
                    return null;
                }
            }
        }


        public static List<myOrg_Office> myOrg_Office_list = new List<myOrg_Office>();

      

        public static ID Default_Currency_ID = null;
        public static tnr[] Default_TaxRates = null;

        public static bool CountryDefined
        {
            get
            {
                if (Address_v != null)
                {
                    if (Address_v.Country_v != null)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

       

        public static bool Get()
        {
            string Err = null;

            DataTable dt_myOrganisation = new DataTable();
            myOrg.ID = null;
            myOrg.Name_v = null;
            myOrg.Tax_ID_v = null;
            myOrg.Registration_ID_v = null;
            myOrg.OrganisationTYPE_v = null;
            myOrg.PhoneNumber_v = null;
            myOrg.FaxNumber_v = null;
            myOrg.HomePage_v = null;
            myOrg.Email_v = null;
            myOrg.Logo_Image_Data_v = null;
            myOrg.Logo_Hash_v = null;
            myOrg.Address_v.StreetName_v = null;
            myOrg.Address_v.HouseNumber_v = null;
            myOrg.Address_v.ZIP_v = null;
            myOrg.Address_v.City_v = null;
            myOrg.Address_v.Country_v = null;
            myOrg.Address_v.Country_ISO_3166_a2_v = null;
            myOrg.Address_v.Country_ISO_3166_a3_v = null;
            myOrg.Address_v.Country_ISO_3166_num_v = null;
            myOrg.Address_v.State_v = null;

            string sql = null;
                sql = @"Select 
                            ID,
                            myOrganisation_$_orgd_$$ID,
                            myOrganisation_$_orgd_$_org_$$ID,
                            myOrganisation_$_orgd_$_org_$$Name,
                            myOrganisation_$_orgd_$_org_$$Tax_ID,
                            myOrganisation_$_orgd_$_org_$$Registration_ID,
                            myOrganisation_$_orgd_$_org_$$TaxPayer,
                            myOrganisation_$_orgd_$_org_$_cmt1_$$Comment,
                            myOrganisation_$_orgd_$_orgt_$$OrganisationTYPE,
                            myOrganisation_$_orgd_$_cadrorg_$_cstrnorg_$$StreetName,
                            myOrganisation_$_orgd_$_cadrorg_$_chounorg_$$HouseNumber,
                            myOrganisation_$_orgd_$_cadrorg_$_ccitorg_$$City,
                            myOrganisation_$_orgd_$_cadrorg_$_cziporg_$$ZIP,
                            myOrganisation_$_orgd_$_cadrorg_$_ccouorg_$$Country,
                            myOrganisation_$_orgd_$_cadrorg_$_ccouorg_$$Country_ISO_3166_a2,
                            myOrganisation_$_orgd_$_cadrorg_$_ccouorg_$$Country_ISO_3166_a3,
                            myOrganisation_$_orgd_$_cadrorg_$_ccouorg_$$Country_ISO_3166_num,
                            myOrganisation_$_orgd_$_cadrorg_$_cstorg_$$State,
                            myOrganisation_$_orgd_$_cphnnorg_$$PhoneNumber,
                            myOrganisation_$_orgd_$_cfaxnorg_$$FaxNumber,
                            myOrganisation_$_orgd_$_cemailorg_$$Email,
                            myOrganisation_$_orgd_$_chomepgorg_$$HomePage,
                            myOrganisation_$_orgd_$_logo_$$Image_Hash,
                            myOrganisation_$_orgd_$_logo_$$Image_Data,
                            myOrganisation_$_orgd_$_logo_$$Description
                            from myOrganisation_VIEW";

            dt_myOrganisation.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dt_myOrganisation, sql, ref Err))
            {
                if (dt_myOrganisation.Rows.Count > 0)
                {
                    myOrg.ID = tf.set_ID(dt_myOrganisation.Rows[0]["ID"]);
                    myOrg.Name_v = tf.set_string(dt_myOrganisation.Rows[0]["myOrganisation_$_orgd_$_org_$$Name"]);
                    myOrg.Tax_ID_v = tf.set_string(dt_myOrganisation.Rows[0]["myOrganisation_$_orgd_$_org_$$Tax_ID"]);
                    myOrg.Registration_ID_v = tf.set_string(dt_myOrganisation.Rows[0]["myOrganisation_$_orgd_$_org_$$Registration_ID"]);
                    myOrg.TayPayer_v = tf.set_bool(dt_myOrganisation.Rows[0]["myOrganisation_$_orgd_$_org_$$TaxPayer"]);
                    myOrg.Comment1_v = tf.set_string(dt_myOrganisation.Rows[0]["myOrganisation_$_orgd_$_org_$_cmt1_$$Comment"]);
                    myOrg.OrganisationTYPE_v = tf.set_string(dt_myOrganisation.Rows[0]["myOrganisation_$_orgd_$_orgt_$$OrganisationTYPE"]);
                    myOrg.PhoneNumber_v = tf.set_string(dt_myOrganisation.Rows[0]["myOrganisation_$_orgd_$_cphnnorg_$$PhoneNumber"]);
                    myOrg.FaxNumber_v = tf.set_string(dt_myOrganisation.Rows[0]["myOrganisation_$_orgd_$_cfaxnorg_$$FaxNumber"]);
                    myOrg.HomePage_v = tf.set_string(dt_myOrganisation.Rows[0]["myOrganisation_$_orgd_$_chomepgorg_$$HomePage"]);
                    myOrg.Email_v = tf.set_string(dt_myOrganisation.Rows[0]["myOrganisation_$_orgd_$_cemailorg_$$Email"]);
                    myOrg.Logo_Image_Data_v = tf.set_byte_array(dt_myOrganisation.Rows[0]["myOrganisation_$_orgd_$_logo_$$Image_Data"]);
                    myOrg.Logo_Hash_v = tf.set_string(dt_myOrganisation.Rows[0]["myOrganisation_$_orgd_$_logo_$$Image_Hash"]);
                    if (myOrg.Logo_Image_Data_v != null)
                    {
                        ImageConverter ic = new ImageConverter();
                        myOrg.Logo = (Image)ic.ConvertFrom(myOrg.Logo_Image_Data_v.v);
                    }
                    myOrg.Address_v.StreetName_v = tf.set_dstring(dt_myOrganisation.Rows[0]["myOrganisation_$_orgd_$_cadrorg_$_cstrnorg_$$StreetName"]);
                    myOrg.Address_v.HouseNumber_v = tf.set_dstring(dt_myOrganisation.Rows[0]["myOrganisation_$_orgd_$_cadrorg_$_chounorg_$$HouseNumber"]);
                    myOrg.Address_v.ZIP_v = tf.set_dstring(dt_myOrganisation.Rows[0]["myOrganisation_$_orgd_$_cadrorg_$_cziporg_$$ZIP"]);
                    myOrg.Address_v.City_v = tf.set_dstring(dt_myOrganisation.Rows[0]["myOrganisation_$_orgd_$_cadrorg_$_ccitorg_$$City"]);
                    myOrg.Address_v.Country_v = tf.set_dstring(dt_myOrganisation.Rows[0]["myOrganisation_$_orgd_$_cadrorg_$_ccouorg_$$Country"]);
                    myOrg.Address_v.Country_ISO_3166_a2_v = tf.set_dstring(dt_myOrganisation.Rows[0]["myOrganisation_$_orgd_$_cadrorg_$_ccouorg_$$Country_ISO_3166_a2"]);
                    myOrg.Address_v.Country_ISO_3166_a3_v = tf.set_dstring(dt_myOrganisation.Rows[0]["myOrganisation_$_orgd_$_cadrorg_$_ccouorg_$$Country_ISO_3166_a3"]);
                    myOrg.Address_v.Country_ISO_3166_num_v = tf.set_dshort(fs.MyConvertToShort(dt_myOrganisation.Rows[0]["myOrganisation_$_orgd_$_cadrorg_$_ccouorg_$$Country_ISO_3166_num"]));
                    myOrg.Address_v.State_v = tf.set_dstring(dt_myOrganisation.Rows[0]["myOrganisation_$_orgd_$_cadrorg_$_cstorg_$$State"]);
                    if (myOrg.ID != null)
                    {
                        myOrg_Office_List.Get(myOrg.ID, ref myOrg.myOrg_Office_list);
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:MyOrg:Get:sql=" + sql+"\r\nErr="+Err);
                return false;
            }
        }

        public static myOrg_Office Find_Office(ID m_Office_ID)
        {
            foreach (myOrg_Office moff in myOrg.myOrg_Office_list)
            {
                if (ID.Validate(moff.ID))
                {
                    if (ID.Validate(m_Office_ID))
                    {
                        if (moff.ID.Equals(m_Office_ID))
                        {
                            return moff;
                        }
                    }
                }
            }
            return null;
        }

        public static bool SetOffice(ID identity)
        {
            myOrg_Office xmyOrg_Office = Find_Office(identity);
            if (xmyOrg_Office!=null)
            {
                myOrg.m_myOrg_Office = xmyOrg_Office;
                return true;
            }
            myOrg.m_myOrg_Office = null;
            return false;
        }

        public static bool Find_ElectronicDevice()
        {
            string xComputerName = f_Atom_ComputerName.Get();
            string xComputerUserName = f_Atom_ComputerUsername.Get();
            foreach (myOrg_Office moff in myOrg_Office_list)
            {
                moff.m_myOrg_Office_ElectronicDevice = null;
                foreach (myOrg_Office_ElectronicDevice moffed in moff.myOrg_Office_ElectronicDevice_List)
                {
                    if (moffed.ComputerName != null)
                    {
                        if (moffed.ComputerName.Equals(xComputerName))
                        {
                            if (moffed.ComputerUserName != null)
                            {
                                if (xComputerUserName != null)
                                {
                                    if (moffed.ComputerUserName.Equals(xComputerUserName))
                                    {
                                        myOrg.m_myOrg_Office = moff;
                                        moff.m_myOrg_Office_ElectronicDevice = moffed;
                                        return true;
                                    }
                                }
                            }
                            else if (xComputerUserName == null)
                            {
                                myOrg.m_myOrg_Office = moff;
                                moff.m_myOrg_Office_ElectronicDevice = moffed;
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public static myOrg_Office.eGet_m_myOrg_Person_SingleUser_Result Get_m_myOrg_Office_m_myOrg_Person_SingleUser()
        {
            if (m_myOrg_Office!=null)
            {
                if (m_myOrg_Office.m_myOrg_Person!=null)
                {
                    return myOrg_Office.eGet_m_myOrg_Person_SingleUser_Result.OK;
                }
                else
                {
                    Transaction transaction_Get_m_myOrg_Person_SingleUser = new Transaction("Get_m_myOrg_Person_SingleUser");
                    myOrg_Office.eGet_m_myOrg_Person_SingleUser_Result res = m_myOrg_Office.Get_m_myOrg_Person_SingleUser(transaction_Get_m_myOrg_Person_SingleUser);
                    if (res == myOrg_Office.eGet_m_myOrg_Person_SingleUser_Result.ERROR)
                    {
                        transaction_Get_m_myOrg_Person_SingleUser.Rollback();
                    }
                    else
                    {
                        transaction_Get_m_myOrg_Person_SingleUser.Commit();
                    }
                    return res;

                }
            }
            else
            {
                return myOrg_Office.eGet_m_myOrg_Person_SingleUser_Result.myOrg_Office_NOT_DEFINED;
            }
        }

        // DataBase is empty No Organisation Data First select Shops In use !
        public enum eGetOrganisationDataResult
        {
            NO_ORGANISATION_NAME,
            NO_TAX_ID,
            NO_STREET_NAME,
            NO_HOUSE_NUMBER,
            NO_ZIP,
            NO_CITY,
            NO_COUNTRY,
            NO_OFFICE,
            NO_REAL_ESTATE,
            NO_ELECTRONIC_DEVICE_NAME,
            NO_MY_ORG_OFFICE_PERSON,
            NO_MY_ORG_OFFICE_PERSON_SINGLE_USER,
            ELECTRONIC_DEVICE_NOT_DEFINED_FOR_THIS_COMPUTER,
            NO_MYORGANISATION_PERSON_SingleUser_FOR_THIS_ELECTRONIC_DEVICE_ID,
            OK,
            ERROR
        }

        public static eGetOrganisationDataResult GetOrganisationData(bool Program_bFirstTimeInstallation,
                                                                bool Program_OperationMode_MultiUser,
                                                                bool Program_b_FVI_SLO,
                                                                ref bool Program_m_CountryHasFVI)
        {
            if (myOrg.Get())
            {

                if (myOrg.Name_v == null)
                {
                    //x_usrc_Main.Get_shops_in_use(false);
                    if (!Program_bFirstTimeInstallation)
                    {
                        MessageBox.Show(lng.s_No_OrganisationData.s);
                    }
                    return eGetOrganisationDataResult.NO_ORGANISATION_NAME;


                }
                if (myOrg.Tax_ID_v == null)
                {
                    if (!Program_bFirstTimeInstallation)
                    {
                        MessageBox.Show(lng.s_No_MyOrganisation_Tax_ID.s);
                    }
                    return eGetOrganisationDataResult.NO_TAX_ID;

                }

                if (myOrg.Address_v.StreetName_v == null)
                {
                    if (!Program_bFirstTimeInstallation)
                    {
                        MessageBox.Show(lng.s_No_MyOrganisation_StreetName.s);
                    }
                    return eGetOrganisationDataResult.NO_STREET_NAME;
                }

                if (myOrg.Address_v.HouseNumber_v == null)
                {
                    if (!Program_bFirstTimeInstallation)
                    {
                        MessageBox.Show(lng.s_No_MyOrganisation_HouseNumber.s);
                    }
                    return eGetOrganisationDataResult.NO_HOUSE_NUMBER;
                }

                if (myOrg.Address_v.ZIP_v == null)
                {
                    if (!Program_bFirstTimeInstallation)
                    {
                        MessageBox.Show(lng.s_No_MyOrganisation_ZIP.s);
                    }
                    return eGetOrganisationDataResult.NO_ZIP;
                }
                if (myOrg.Address_v.City_v == null)
                {
                    if (!Program_bFirstTimeInstallation)
                    {
                        MessageBox.Show(lng.s_No_MyOrganisation_City.s);
                    }
                    return eGetOrganisationDataResult.NO_CITY;
                }

                if (myOrg.Address_v.Country_v == null)
                {
                    if (!Program_bFirstTimeInstallation)
                    {
                        MessageBox.Show(lng.s_No_MyOrganisation_Country.s);
                    }
                    return eGetOrganisationDataResult.NO_COUNTRY;
                }

                Transaction transaction_MyOrg_GetOrganisationData = new Transaction("MyOrg_GetOrganisationData");

                if (!f_Currency.Get(myOrg.Address_v.Country_ISO_3166_num, ref myOrg.Default_Currency_ID, transaction_MyOrg_GetOrganisationData))
                {
                    transaction_MyOrg_GetOrganisationData.Rollback();
                    return eGetOrganisationDataResult.ERROR;
                }

                if (f_Taxation.Get(myOrg.Address_v.Country_ISO_3166_num, ref myOrg.Default_TaxRates, transaction_MyOrg_GetOrganisationData))
                {
                    transaction_MyOrg_GetOrganisationData.Commit();
                }
                else
                {
                    transaction_MyOrg_GetOrganisationData.Rollback();
                    return eGetOrganisationDataResult.ERROR;
                }

                if (myOrg.myOrg_Office_list.Count > 0)
                {
                    if (myOrg.Find_ElectronicDevice())
                    {
                        if (!Program_OperationMode_MultiUser)
                        {
                            switch (myOrg.Get_m_myOrg_Office_m_myOrg_Person_SingleUser())
                            {
                                case myOrg_Office.eGet_m_myOrg_Person_SingleUser_Result.OK:
                                    break;
                                case myOrg_Office.eGet_m_myOrg_Person_SingleUser_Result.ELECTRONIC_DEVICE_NOT_DEFINED_FOR_THIS_COMPUTER:
                                    return eGetOrganisationDataResult.NO_ELECTRONIC_DEVICE_NAME; ;
                                case myOrg_Office.eGet_m_myOrg_Person_SingleUser_Result.myOrg_Office_NOT_DEFINED:
                                    return eGetOrganisationDataResult.NO_OFFICE;
                                case myOrg_Office.eGet_m_myOrg_Person_SingleUser_Result.NO_MYORGANISATION_PERSON_SingleUser_FOR_THIS_ELECTRONIC_DEVICE_ID:
                                    return eGetOrganisationDataResult.NO_MYORGANISATION_PERSON_SingleUser_FOR_THIS_ELECTRONIC_DEVICE_ID;
                                case myOrg_Office.eGet_m_myOrg_Person_SingleUser_Result.NO_myOrganisation_Person_ID_IN_myOrg_Person_list:
                                    return eGetOrganisationDataResult.NO_MY_ORG_OFFICE_PERSON;
                                case myOrg_Office.eGet_m_myOrg_Person_SingleUser_Result.ERROR:
                                    return eGetOrganisationDataResult.ERROR;
                            }
                        }
                    }
                    if (myOrg.m_myOrg_Office == null)
                    {
                        if (!Program_bFirstTimeInstallation)
                        {
                            MessageBox.Show(lng.s_No_Office_Data.s);
                        }
                        return eGetOrganisationDataResult.NO_OFFICE;
                    }
                    else
                    {
                        myOrg.SetOffice(myOrg.m_myOrg_Office.ID);
                        if (myOrg.m_myOrg_Office.myOrg_Person_list.Count == 0)
                        {
                            MessageBox.Show(lng.s_No_MyOrganisation_Person.s);

                            return eGetOrganisationDataResult.NO_MY_ORG_OFFICE_PERSON;
                        }


                        if (myOrg.Address_v.Country_ISO_3166_a3.Equals(Country_ISO_3166.ISO_3166_Table.m_Slovenia.State_A3))
                        {
                            Program_m_CountryHasFVI = true;
                        }
                        else
                        {
                            Program_m_CountryHasFVI = false;
                        }

                        if (Program_b_FVI_SLO)
                        {

                            if (myOrg.m_myOrg_Office != null)
                            {
                                if (myOrg.m_myOrg_Office.myOrg_Office_FVI_SLO_RealEstate.BuildingNumber_v == null)
                                {
                                    myOrg.SetOffice(myOrg.m_myOrg_Office.ID);
                                    if (myOrg.m_myOrg_Office.myOrg_Office_FVI_SLO_RealEstate.BuildingNumber_v == null)
                                    {
                                        if (!Program_bFirstTimeInstallation)
                                        {
                                            MessageBox.Show(lng.s_No_Office_Data_FVI_SLO_RealEstateBP.s);
                                        }
                                        return eGetOrganisationDataResult.NO_REAL_ESTATE;
                                    }
                                }
                            }
                        }

                        if (myOrg.ElectronicDevice_ID == null)
                        {
                            return eGetOrganisationDataResult.NO_ELECTRONIC_DEVICE_NAME;
                        }

                        if (!Program_OperationMode_MultiUser)
                        {
                            if (myOrg.m_myOrg_Office.m_myOrg_Person == null)
                            {
                                return eGetOrganisationDataResult.NO_MY_ORG_OFFICE_PERSON_SINGLE_USER;
                            }
                        }
                    }
                }
                else
                {
                    if (!Program_bFirstTimeInstallation)
                    {
                        MessageBox.Show(lng.s_No_Office.s);
                    }
                    return eGetOrganisationDataResult.NO_OFFICE;
                }



                string sPhoneNumber = "";
                string sEmail = "";
                string sHomePage = "";
                string sRegistration_ID = "";
                if (myOrg.PhoneNumber_v != null)
                {
                    sPhoneNumber = myOrg.PhoneNumber_v.vs;
                }
                if (myOrg.Email_v != null)
                {
                    sEmail = myOrg.Email_v.vs;
                }
                if (myOrg.HomePage_v != null)
                {
                    sHomePage = myOrg.HomePage_v.vs;
                }
                if (myOrg.Registration_ID_v != null)
                {
                    sRegistration_ID = myOrg.Registration_ID_v.vs;
                }

                string sAddress = myOrg.Address_v.StreetName_v.v + " " + myOrg.Address_v.HouseNumber_v.v + " , " + myOrg.Address_v.ZIP_v.v + " " + myOrg.Address_v.City_v.v + " , " + myOrg.Address_v.Country;

                //this.txt_MyOrganisation.Text = myOrg.Name_v.vs + "," + sAddress
                //    + "\r\n" + lng.s_Tax_ID.s + ":" + myOrg.Tax_ID_v.vs
                //    + "\r\n" + lng.s_Registration_ID.s + ":" + sRegistration_ID
                //    + "\r\n" + lng.s_PhoneNumber.s + ":" + sPhoneNumber
                //    + "\r\n" + lng.s_Email.s + ":" + sEmail
                //    + "\r\n" + lng.s_HomePage.s + ":" + sHomePage;
                //Fill_MyOrganisation_Person();

                return eGetOrganisationDataResult.OK;
            }
            else
            {
                return eGetOrganisationDataResult.ERROR;
            }
        }


    }
}
