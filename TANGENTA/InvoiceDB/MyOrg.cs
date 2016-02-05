using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLTableControl;
using BlagajnaTableClass;
using DBConnectionControl40;
using System.Data;
using System.Drawing;
using DBTypes;


namespace InvoiceDB
{
    public static class myOrg
    {

        public static long_v ID_v = null;
        public static string_v Name_v = null;
        public static PostAddress_v Address_v = new PostAddress_v();
        public static string_v Tax_ID_v = null;
        public static string_v Registration_ID_v = null;
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

        public static List<myOrg_Person> myOrg_Person_list = new List<myOrg_Person>();
        public static myOrg_Person myOrg_Person_LoggedIn = null;



        public static bool Get(long myCompany_id)
        {

            DataTable dt_myCompany = new DataTable();
            myOrg.ID_v = null;
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
            myOrg.Address_v.State_v = null;
            myOrg.Address_v.State_ISO_3166_a2_v = null;
            myOrg.Address_v.State_ISO_3166_a3_v = null;
            myOrg.Address_v.State_ISO_3166_num_v = null;
            myOrg.Address_v.Country_v = null;

            string sql = null;
            if (myCompany_id >= 0)
            {
                sql = @"Select 
                            ID,
                            myCompany_$_orgd_$$ID,
                            myCompany_$_orgd_$_org_$$ID,
                            myCompany_$_orgd_$_org_$$Name,
                            myCompany_$_orgd_$_org_$$Tax_ID,
                            myCompany_$_orgd_$_org_$$Registration_ID,
                            myCompany_$_orgd_$_orgt_$$OrganisationTYPE,
                            myCompany_$_orgd_$_cadrorg_$_cstrnorg_$$StreetName,
                            myCompany_$_orgd_$_cadrorg_$_chounorg_$$HouseNumber,
                            myCompany_$_orgd_$_cadrorg_$_ccitorg_$$City,
                            myCompany_$_orgd_$_cadrorg_$_cziporg_$$ZIP,
                            myCompany_$_orgd_$_cadrorg_$_cstorg_$$State,
                            myCompany_$_orgd_$_cadrorg_$_cstorg_$$State_ISO_3166_a2,
                            myCompany_$_orgd_$_cadrorg_$_cstorg_$$State_ISO_3166_a3,
                            myCompany_$_orgd_$_cadrorg_$_cstorg_$$State_ISO_3166_num,
                            myCompany_$_orgd_$_cadrorg_$_ccouorg_$$Country,
                            myCompany_$_orgd_$_cphnnorg_$$PhoneNumber,
                            myCompany_$_orgd_$_cfaxnorg_$$FaxNumber,
                            myCompany_$_orgd_$_cemailorg_$$Email,
                            myCompany_$_orgd_$_chomepgorg_$$HomePage,
                            myCompany_$_orgd_$_logo_$$Image_Hash,
                            myCompany_$_orgd_$_logo_$$Image_Data,
                            myCompany_$_orgd_$_logo_$$Description
                            from myCompany_VIEW where ID = " + myCompany_id.ToString();
            }
            else
            {
                sql = @"Select 
                            ID,
                            myCompany_$_orgd_$$ID,
                            myCompany_$_orgd_$_org_$$ID,
                            myCompany_$_orgd_$_org_$$Name,
                            myCompany_$_orgd_$_org_$$Tax_ID,
                            myCompany_$_orgd_$_org_$$Registration_ID,
                            myCompany_$_orgd_$_orgt_$$OrganisationTYPE,
                            myCompany_$_orgd_$_cadrorg_$_cstrnorg_$$StreetName,
                            myCompany_$_orgd_$_cadrorg_$_chounorg_$$HouseNumber,
                            myCompany_$_orgd_$_cadrorg_$_ccitorg_$$City,
                            myCompany_$_orgd_$_cadrorg_$_cziporg_$$ZIP,
                            myCompany_$_orgd_$_cadrorg_$_cstorg_$$State,
                            myCompany_$_orgd_$_cadrorg_$_cstorg_$$State_ISO_3166_a2,
                            myCompany_$_orgd_$_cadrorg_$_cstorg_$$State_ISO_3166_a3,
                            myCompany_$_orgd_$_cadrorg_$_cstorg_$$State_ISO_3166_num,
                            myCompany_$_orgd_$_cadrorg_$_ccouorg_$$Country,
                            myCompany_$_orgd_$_cphnnorg_$$PhoneNumber,
                            myCompany_$_orgd_$_cfaxnorg_$$FaxNumber,
                            myCompany_$_orgd_$_cemailorg_$$Email,
                            myCompany_$_orgd_$_chomepgorg_$$HomePage,
                            myCompany_$_orgd_$_logo_$$Image_Hash,
                            myCompany_$_orgd_$_logo_$$Image_Data,
                            myCompany_$_orgd_$_logo_$$Description
                            from myCompany_VIEW";

            }
            string Err = null;
            dt_myCompany.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dt_myCompany, sql, ref Err))
            {
                if (dt_myCompany.Rows.Count > 0)
                {
                    myOrg.ID_v = tf.set_long(dt_myCompany.Rows[0]["ID"]);
                    myOrg.Name_v = tf.set_string(dt_myCompany.Rows[0]["myCompany_$_orgd_$_org_$$Name"]);
                    myOrg.Tax_ID_v = tf.set_string(dt_myCompany.Rows[0]["myCompany_$_orgd_$_org_$$Tax_ID"]);
                    myOrg.Registration_ID_v = tf.set_string(dt_myCompany.Rows[0]["myCompany_$_orgd_$_org_$$Registration_ID"]);
                    myOrg.OrganisationTYPE_v = tf.set_string(dt_myCompany.Rows[0]["myCompany_$_orgd_$_orgt_$$OrganisationTYPE"]);
                    myOrg.PhoneNumber_v = tf.set_string(dt_myCompany.Rows[0]["myCompany_$_orgd_$_cphnnorg_$$PhoneNumber"]);
                    myOrg.FaxNumber_v = tf.set_string(dt_myCompany.Rows[0]["myCompany_$_orgd_$_cfaxnorg_$$FaxNumber"]);
                    myOrg.HomePage_v = tf.set_string(dt_myCompany.Rows[0]["myCompany_$_orgd_$_chomepgorg_$$HomePage"]);
                    myOrg.Email_v = tf.set_string(dt_myCompany.Rows[0]["myCompany_$_orgd_$_cemailorg_$$Email"]);
                    myOrg.Logo_Image_Data_v = tf.set_byte_array(dt_myCompany.Rows[0]["myCompany_$_orgd_$_logo_$$Image_Data"]);
                    myOrg.Logo_Hash_v = tf.set_string(dt_myCompany.Rows[0]["myCompany_$_orgd_$_logo_$$Image_Hash"]);
                    if (myOrg.Logo_Image_Data_v != null)
                    {
                        ImageConverter ic = new ImageConverter();
                        myOrg.Logo = (Image)ic.ConvertFrom(myOrg.Logo_Image_Data_v.v);
                    }
                    myOrg.Address_v.StreetName_v = tf.set_string(dt_myCompany.Rows[0]["myCompany_$_orgd_$_cadrorg_$_cstrnorg_$$StreetName"]);
                    myOrg.Address_v.HouseNumber_v = tf.set_string(dt_myCompany.Rows[0]["myCompany_$_orgd_$_cadrorg_$_chounorg_$$HouseNumber"]);
                    myOrg.Address_v.ZIP_v = tf.set_string(dt_myCompany.Rows[0]["myCompany_$_orgd_$_cadrorg_$_cziporg_$$ZIP"]);
                    myOrg.Address_v.City_v = tf.set_string(dt_myCompany.Rows[0]["myCompany_$_orgd_$_cadrorg_$_ccitorg_$$City"]);
                    myOrg.Address_v.State_v = tf.set_string(dt_myCompany.Rows[0]["myCompany_$_orgd_$_cadrorg_$_cstorg_$$State"]);
                    myOrg.Address_v.State_ISO_3166_a2_v = tf.set_string(dt_myCompany.Rows[0]["myCompany_$_orgd_$_cadrorg_$_cstorg_$$State_ISO_3166_a2"]);
                    myOrg.Address_v.State_ISO_3166_a3_v = tf.set_string(dt_myCompany.Rows[0]["myCompany_$_orgd_$_cadrorg_$_cstorg_$$State_ISO_3166_a3"]);
                    myOrg.Address_v.State_ISO_3166_num_v = tf.set_short(fs.MyConvertToShort(dt_myCompany.Rows[0]["myCompany_$_orgd_$_cadrorg_$_cstorg_$$State_ISO_3166_num"]));
                    myOrg.Address_v.Country_v = tf.set_string(dt_myCompany.Rows[0]["myCompany_$_orgd_$_cadrorg_$_ccouorg_$$Country"]);
                    if (myOrg.ID_v != null)
                    {
                        myOrg_Person_List.Get(myOrg.ID_v.v, ref myOrg.myOrg_Person_list);
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
    }
}
