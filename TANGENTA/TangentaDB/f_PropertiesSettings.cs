using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_PropertiesSettings
    {
        public static bool GetTable(ID ElectronicDevice_ID, ID ProgramModule_ID, ID myOrganisation_Person_ID, ref DataTable dt)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string scond_ElectronicDevice_ID = " ElectronicDevice_ID is null ";
            if (ID.Validate(ElectronicDevice_ID))
            {
                string spar_ElectronicDevice_ID = "@par_ElectronicDevice_ID";
                SQL_Parameter par_ElectronicDevice_ID = new SQL_Parameter(spar_ElectronicDevice_ID, false, ElectronicDevice_ID);
                lpar.Add(par_ElectronicDevice_ID);
                scond_ElectronicDevice_ID = " ElectronicDevice_ID = " + spar_ElectronicDevice_ID + " ";
            }

            string scond_ProgramModule_ID = " ProgramModule_ID is null ";
            if (ID.Validate(ProgramModule_ID))
            {
                string spar_ProgramModule_ID = "@par_ProgramModule_ID";
                SQL_Parameter par_ProgramModule_ID = new SQL_Parameter(spar_ProgramModule_ID, false, ProgramModule_ID);
                lpar.Add(par_ProgramModule_ID);
                scond_ProgramModule_ID = " ProgramModule_ID = " + spar_ProgramModule_ID + " ";
            }

            string scond_myOrgPer_ID = " myOrganisation_Person_ID is null ";
            if (ID.Validate(myOrganisation_Person_ID))
            {
                string spar_myOrgPer_ID = "@par_myOrgPer_ID_ID";
                SQL_Parameter par_myOrgPer_ID = new SQL_Parameter(spar_myOrgPer_ID, false, myOrganisation_Person_ID);
                lpar.Add(par_myOrgPer_ID);
                scond_myOrgPer_ID = "  myOrganisation_Person_ID = " + spar_myOrgPer_ID + " ";
            }
            if (dt == null)
            {
                dt = new DataTable();
            }
            else
            {
                dt.Clear();
                dt.Columns.Clear();
            }
            string sql = @"select  ps.ID,ps.Name,ps.SValue,st.Typ from PropertiesSettings ps
		                    inner join SettingsType st on ps.SettingsType_ID = st.ID
		                    where TestEnvironment = 0 and " + scond_ElectronicDevice_ID
                            + " and " + scond_ProgramModule_ID
                            + "and  " + scond_myOrgPer_ID + " ";
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_PropertiesSettings:GetTable:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Save(ID ElectronicDevice_ID, ID ProgramModule_ID, ID myOrganisation_Person_ID, string name, ID SettingsType_ID, string SValue, ref ID PropertiesSettings_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string scond_ElectronicDevice_ID = " ElectronicDevice_ID is null ";
            string sval_ElectronicDevice_ID = " null ";
            if (ID.Validate(ElectronicDevice_ID))
            {
                string spar_ElectronicDevice_ID = "@par_ElectronicDevice_ID";
                SQL_Parameter par_ElectronicDevice_ID = new SQL_Parameter(spar_ElectronicDevice_ID, false, ElectronicDevice_ID);
                lpar.Add(par_ElectronicDevice_ID);
                scond_ElectronicDevice_ID = " ElectronicDevice_ID = " + spar_ElectronicDevice_ID + " ";
                sval_ElectronicDevice_ID = spar_ElectronicDevice_ID;
            }

            string scond_ProgramModule_ID = " ProgramModule_ID is null ";
            string sval_ProgramModule_ID = " null ";
            if (ID.Validate(ProgramModule_ID))
            {
                string spar_ProgramModule_ID = "@par_ProgramModule_ID";
                SQL_Parameter par_ProgramModule_ID = new SQL_Parameter(spar_ProgramModule_ID, false, ProgramModule_ID);
                lpar.Add(par_ProgramModule_ID);
                scond_ProgramModule_ID = " ProgramModule_ID = " + spar_ProgramModule_ID + " ";
                sval_ProgramModule_ID = spar_ProgramModule_ID;
            }

            string scond_myOrgPer_ID = " myOrganisation_Person_ID is null ";
            string sval_myOrgPer_ID = " null ";
            if (ID.Validate(myOrganisation_Person_ID))
            {
                string spar_myOrgPer_ID = "@par_myOrgPer_ID_ID";
                SQL_Parameter par_myOrgPer_ID = new SQL_Parameter(spar_myOrgPer_ID, false, myOrganisation_Person_ID);
                lpar.Add(par_myOrgPer_ID);
                scond_myOrgPer_ID = "  myOrganisation_Person_ID = " + spar_myOrgPer_ID + " ";
                sval_myOrgPer_ID = spar_myOrgPer_ID;
            }

            string spar_Name = "@par_Name";
            SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, name);
            lpar.Add(par_Name);
            string scond_Name = "  Name = " + spar_Name + " ";

            string sql = @"select  ps.ID from PropertiesSettings ps
		                    inner join SettingsType st on ps.SettingsType_ID = st.ID
		                    where TestEnvironment = 0 and " + scond_ElectronicDevice_ID
                + " and " + scond_ProgramModule_ID
                + " and  " + scond_myOrgPer_ID
                + " and  " + scond_Name + " ";

            string spar_SettingsType_ID = "@par_SettingsType_ID";
            SQL_Parameter par_SettingsType_ID = new SQL_Parameter(spar_SettingsType_ID, false, SettingsType_ID);
            lpar.Add(par_SettingsType_ID);

            string spar_SettingsValue = "@par_SettingsValue";
            SQL_Parameter par_SettingsValue = new SQL_Parameter(spar_SettingsValue,SQL_Parameter.eSQL_Parameter.Nvarchar, false, SValue);
            lpar.Add(par_SettingsValue);

            string Err = null;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    PropertiesSettings_ID = tf.set_ID(dt.Rows[0]["ID"]);
                    if (ID.Validate(PropertiesSettings_ID))
                    {


                        sql = @"update PropertiesSettings set SettingsType_ID = " + spar_SettingsType_ID
                                                              + ",SValue = " + spar_SettingsValue +
                            " where TestEnvironment = 0 and " + scond_ElectronicDevice_ID
                            + " and " + scond_ProgramModule_ID
                            + " and  " + scond_myOrgPer_ID
                            + " and  " + scond_Name + " ";
                        if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, lpar,  ref Err))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:f_PropertiesSettings:GetTable:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:f_PropertiesSettings:GetTable:PropertiesSettings_ID is not valid");
                        return false;
                    }
                }
                else
                {
                    sql = @"insert into PropertiesSettings (ElectronicDevice_ID,
                                                      ProgramModule_ID,
                                                      myOrganisation_Person_ID,
                                                      Name, 
                                                      SettingsType_ID,
                                                      SValue,
                                                      TestEnvironment,
                                                      Description)
                                                      values
                                                      (" + sval_ElectronicDevice_ID + ","
                                                        + sval_ProgramModule_ID + ","
                                                        + sval_myOrgPer_ID + ","
                                                        + spar_Name + ","
                                                        + spar_SettingsType_ID + ","
                                                        + spar_SettingsValue + ",0,null)";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref PropertiesSettings_ID, ref Err, "PropertiesSettings"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:f_PropertiesSettings:GetTable:PropertiesSettings_ID is not valid");
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_PropertiesSettings:GetTable:PropertiesSettings_ID is not valid");
                return false;
            }
        }

        public static bool Update(ID propertiesSettings_ID, string SValue)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_SettingsValue = "@par_SettingsValue";
            SQL_Parameter par_SettingsValue = new SQL_Parameter(spar_SettingsValue, SQL_Parameter.eSQL_Parameter.Nvarchar,false, SValue);
            lpar.Add(par_SettingsValue);

            string spar_propertiesSettings_ID = "@par_propertiesSettings_ID";
            SQL_Parameter par_propertiesSettings_ID = new SQL_Parameter(spar_propertiesSettings_ID, false, propertiesSettings_ID);
            lpar.Add(par_propertiesSettings_ID);

            string sql = @"update PropertiesSettings set SValue = " + spar_SettingsValue
                           + " where ID = " + spar_propertiesSettings_ID;
            string Err = null;
            if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, lpar, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_PropertiesSettings:Update:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
