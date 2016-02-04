using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB
{
    public class myOrg_Office
    {
        public long_v ID_v = null;
        public string_v Name_v = null;
        public PostAddress_v Address_v = new PostAddress_v();

        public bool Get(long_v Office_ID_v)
        {
            string Err = null;
            ID_v = null;
            Name_v = null;
            Address_v.StreetName_v = null;
            Address_v.HouseNumber_v = null;
            Address_v.ZIP_v = null;
            Address_v.City_v = null;
            Address_v.State_v = null;
            Address_v.State_ISO_3166_a2_v = null;
            Address_v.State_ISO_3166_a3_v = null;
            Address_v.State_ISO_3166_num_v = null;
            if (Office_ID_v != null)
            {
                string sql = @"SELECT 
                              Office_Data.ID,
                              Office_Data_$_office.ID AS Office_Data_$_office_$$ID,
                              Office_Data_$_office.Name AS Office_Data_$_office_$$Name,
                              Office_Data_$_cadrorg.ID AS Office_Data_$_cadrorg_$$ID,
                              Office_Data_$_cadrorg_$_cstrnorg.StreetName AS Office_Data_$_cadrorg_$_cstrnorg_$$StreetName,
                              Office_Data_$_cadrorg_$_chounorg.HouseNumber AS Office_Data_$_cadrorg_$_chounorg_$$HouseNumber,
                              Office_Data_$_cadrorg_$_ccitorg.City AS Office_Data_$_cadrorg_$_ccitorg_$$City,
                              Office_Data_$_cadrorg_$_cziporg.ZIP AS Office_Data_$_cadrorg_$_cziporg_$$ZIP,
                              Office_Data_$_cadrorg_$_cstorg.State AS Office_Data_$_cadrorg_$_cstorg_$$State,
                              Office_Data_$_cadrorg_$_cstorg.State_ISO_3166_a2 AS Office_Data_$_cadrorg_$_cstorg_$$State_ISO_3166_a2,
                              Office_Data_$_cadrorg_$_cstorg.State_ISO_3166_a3 AS Office_Data_$_cadrorg_$_cstorg_$$State_ISO_3166_a3,
                              Office_Data_$_cadrorg_$_cstorg.State_ISO_3166_num AS Office_Data_$_cadrorg_$_cstorg_$$State_ISO_3166_num,
                              Office_Data_$_cadrorg_$_ccouorg.Country AS Office_Data_$_cadrorg_$_ccouorg_$$Country,
                              Office_Data.Description AS Office_Data_$$Description
                              FROM Office_Data
                              INNER JOIN Office Office_Data_$_office ON Office_Data.Office_ID = Office_Data_$_office.ID
                                LEFT JOIN cAddress_Org Office_Data_$_cadrorg ON Office_Data.cAddress_Org_ID = Office_Data_$_cadrorg.ID
                                LEFT JOIN cStreetName_Org Office_Data_$_cadrorg_$_cstrnorg ON Office_Data_$_cadrorg.cStreetName_Org_ID = Office_Data_$_cadrorg_$_cstrnorg.ID
                                LEFT JOIN cHouseNumber_Org Office_Data_$_cadrorg_$_chounorg ON Office_Data_$_cadrorg.cHouseNumber_Org_ID = Office_Data_$_cadrorg_$_chounorg.ID
                                LEFT JOIN cCity_Org Office_Data_$_cadrorg_$_ccitorg ON Office_Data_$_cadrorg.cCity_Org_ID = Office_Data_$_cadrorg_$_ccitorg.ID
                                LEFT JOIN cZIP_Org Office_Data_$_cadrorg_$_cziporg ON Office_Data_$_cadrorg.cZIP_Org_ID = Office_Data_$_cadrorg_$_cziporg.ID
                                LEFT JOIN cState_Org Office_Data_$_cadrorg_$_cstorg ON Office_Data_$_cadrorg.cState_Org_ID = Office_Data_$_cadrorg_$_cstorg.ID
                                LEFT JOIN cCountry_Org Office_Data_$_cadrorg_$_ccouorg ON Office_Data_$_cadrorg.cCountry_Org_ID = Office_Data_$_cadrorg_$_ccouorg.ID
                              where Office_Data_$_office_$$ID = " + Office_ID_v.v.ToString();

                DataTable dt = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        ID_v = tf.set_long(dt.Rows[0]["Office_Data_$_office_$$ID"]);
                        Name_v = tf.set_string(dt.Rows[0]["Office_Data_$_office_$$Name"]);
                        Address_v.StreetName_v = tf.set_string(dt.Rows[0]["Office_Data_$_office_$$Name"]);
                        Address_v.HouseNumber_v = tf.set_string(dt.Rows[0]["Office_Data_$_cadrorg_$_chounorg_$$HouseNumber"]);
                        Address_v.ZIP_v = tf.set_string(dt.Rows[0]["Office_Data_$_cadrorg_$_cziporg_$$ZIP"]);
                        Address_v.City_v = tf.set_string(dt.Rows[0]["Office_Data_$_cadrorg_$_ccitorg_$$City"]);
                        Address_v.State_v = tf.set_string(dt.Rows[0]["Office_Data_$_cadrorg_$_cstorg_$$State"]);
                        Address_v.State_ISO_3166_a2_v = tf.set_string(dt.Rows[0]["Office_Data_$_cadrorg_$_cstorg_$$State_ISO_3166_a2"]);
                        Address_v.State_ISO_3166_a3_v = tf.set_string(dt.Rows[0]["Office_Data_$_cadrorg_$_cstorg_$$State_ISO_3166_a3"]);
                        Address_v.State_ISO_3166_num_v = tf.set_short(dt.Rows[0]["Office_Data_$_cadrorg_$_cstorg_$$State_ISO_3166_num"]);
                    }
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:myOrg_Office:Get:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:myOrg_Office:Get:(Office_ID_v == null)");
                return false;
            }
        }
    }
}
