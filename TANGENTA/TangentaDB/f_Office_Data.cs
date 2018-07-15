using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_Office_Data
    {
        public static bool Get(
                                   ID cAddress_Org_ID,
                                   ID Office_ID,
                                   string Description,
                                   ref ID Office_Data_ID)
        {

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string scond_Description = null;
            string sval_Description = null;
            if (Description != null)
            {
                string spar_Description = "@par_Description";
                SQL_Parameter par_Office_ShortName = new SQL_Parameter(spar_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Description);
                lpar.Add(par_Office_ShortName);
                scond_Description = "Description = " + spar_Description;
                sval_Description = spar_Description;
            }
            else
            {
                scond_Description = "Description is null";
                sval_Description = "null";
            }

            string sql = @"select ID from Office_Data
                                        where ( cAddress_Org_ID = " + cAddress_Org_ID.ToString() + ") and ( Office_ID = " + Office_ID.ToString() + ") and ("+ scond_Description + ")";
            string Err = null;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Office_Data_ID==null)
                    {
                        Office_Data_ID = new ID();
                    }
                    Office_Data_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @"insert into Office_Data (cAddress_Org_ID,
                                                            Office_ID,
                                                            Description) values ("
                                                            + cAddress_Org_ID.ToString() + ","
                                                            + Office_ID.ToString() + ","
                                                            + sval_Description +
                                                            ")";
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Office_Data_ID, ref Err, "Office_Data"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Office_Data:Get:" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Office_Data:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Get(ID Office_ID, ref DataTable dtOfficeData_of_Office_ID)
        {
            if (ID.Validate(Office_ID))
            {
                string sql = @"select 
                            ID
                            from Office_Data od
                            where od.Office_ID = " + Office_ID.ToString();
                string Err = null;
                if (DBSync.DBSync.ReadDataTable(ref dtOfficeData_of_Office_ID, sql, null, ref Err))
                {
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_Office_Data:Get:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                string sql = @"SELECT Office_Data.ID,
                                 Office_Data_$_office.Name AS Office_Data_$_office_$$Name,
                                 Office_Data_$_office.ShortName AS Office_Data_$_office_$$ShortName,
                                 Office_Data.Description AS Office_Data_$$Description,
                                 Office_Data_$_cadrorg_$_cstrnorg.StreetName AS Office_Data_$_cadrorg_$_cstrnorg_$$StreetName,
                                 Office_Data_$_cadrorg_$_chounorg.HouseNumber AS Office_Data_$_cadrorg_$_chounorg_$$HouseNumber,
                                 Office_Data_$_cadrorg_$_ccitorg.City AS Office_Data_$_cadrorg_$_ccitorg_$$City,
                                 Office_Data_$_cadrorg_$_cziporg.ZIP AS Office_Data_$_cadrorg_$_cziporg_$$ZIP,
                                 Office_Data_$_cadrorg_$_ccouorg.Country AS Office_Data_$_cadrorg_$_ccouorg_$$Country,
                                 Office_Data_$_cadrorg_$_ccouorg.Country_ISO_3166_a2 AS Office_Data_$_cadrorg_$_ccouorg_$$Country_ISO_3166_a2,
                                 Office_Data_$_cadrorg_$_ccouorg.Country_ISO_3166_a3 AS Office_Data_$_cadrorg_$_ccouorg_$$Country_ISO_3166_a3,
                                 Office_Data_$_cadrorg_$_ccouorg.Country_ISO_3166_num AS Office_Data_$_cadrorg_$_ccouorg_$$Country_ISO_3166_num,
                                 Office_Data_$_cadrorg_$_cstorg.State AS Office_Data_$_cadrorg_$_cstorg_$$State,
                                 Office_Data_$_office.ID AS Office_Data_$_office_$$ID,
								 Office_Data_$_office.myOrganisation_ID AS Office_Data_$_office_$$myOrganisation_ID
                                 FROM Office_Data 
                                 INNER JOIN Office Office_Data_$_office ON Office_Data.Office_ID = Office_Data_$_office.ID 
                                 INNER JOIN cAddress_Org Office_Data_$_cadrorg ON Office_Data.cAddress_Org_ID = Office_Data_$_cadrorg.ID 
                                 INNER JOIN cStreetName_Org Office_Data_$_cadrorg_$_cstrnorg ON Office_Data_$_cadrorg.cStreetName_Org_ID = Office_Data_$_cadrorg_$_cstrnorg.ID 
                                 INNER JOIN cHouseNumber_Org Office_Data_$_cadrorg_$_chounorg ON Office_Data_$_cadrorg.cHouseNumber_Org_ID = Office_Data_$_cadrorg_$_chounorg.ID 
                                 INNER JOIN cCity_Org Office_Data_$_cadrorg_$_ccitorg ON Office_Data_$_cadrorg.cCity_Org_ID = Office_Data_$_cadrorg_$_ccitorg.ID 
                                 INNER JOIN cZIP_Org Office_Data_$_cadrorg_$_cziporg ON Office_Data_$_cadrorg.cZIP_Org_ID = Office_Data_$_cadrorg_$_cziporg.ID 
                                 INNER JOIN cCountry_Org Office_Data_$_cadrorg_$_ccouorg ON Office_Data_$_cadrorg.cCountry_Org_ID = Office_Data_$_cadrorg_$_ccouorg.ID 
                                 LEFT JOIN cState_Org Office_Data_$_cadrorg_$_cstorg ON Office_Data_$_cadrorg.cState_Org_ID = Office_Data_$_cadrorg_$_cstorg.ID where Office_Data_$_office.myOrganisation_ID = " + myOrg.ID.ToString();

                string Err = null;
                if (DBSync.DBSync.ReadDataTable(ref dtOfficeData_of_Office_ID, sql, null, ref Err))
                {
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_Office_Data:Get:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
        }

        public static bool DeleteAll()
        {
            return fs.DeleteAll("Office_Data");
        }
    }
}
