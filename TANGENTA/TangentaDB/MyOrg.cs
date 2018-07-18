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


        public static ID Atom_ElectronicDevice_ID
        {
            get
            {
                if (m_myOrg_Office != null)
                {
                    return m_myOrg_Office.Atom_ElectronicDevice_ID;
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
                if (ID.Validate(moff.Office_Data_ID))
                {
                    if (ID.Validate(m_Office_ID))
                    {
                        if (moff.Office_Data_ID.Equals(m_Office_ID))
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

        public static bool Find_Atom_ElectronicDevice()
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

        public static bool Get_m_myOrg_Office_m_myOrg_Person_SingleUser()
        {
            if (m_myOrg_Office!=null)
            {
                if (m_myOrg_Office.m_myOrg_Person!=null)
                {
                    return true;
                }
                else
                {
                    return m_myOrg_Office.Get_m_myOrg_Person_SingleUser();
                }
            }
            else
            {
                return false;
            }
        }
    }
}
