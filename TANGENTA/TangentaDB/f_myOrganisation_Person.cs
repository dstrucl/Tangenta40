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
    public static class f_myOrganisation_Person
    {
        public static bool Get(string_v UserName_v,
                               string_v Password_v,
                               string_v Job_v,
                               bool_v Active_v,
                               string_v Description_v,
                               long_v Person_ID_v,
                               long_v Office_ID_v,
                               ref long_v myOrganisation_Person_v)
        {
            string Err = null;
            DataTable dt = new DataTable();
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string UserName_cond = null;
            string UserName_value = null;
            string spar_UserName = "UserName";
            fs.AddPar(spar_UserName, ref lpar, UserName_v, ref UserName_cond, ref UserName_value);

            string Password_cond = null;
            string Password_value = null;
            string spar_Password = "Password";
            fs.AddPar(spar_Password, ref lpar, Password_v, ref Password_cond, ref Password_value);

            string Job_cond = null;
            string Job_value = null;
            string spar_Job = "Job";
            fs.AddPar(spar_Job, ref lpar, Job_v, ref Job_cond, ref Job_value);

            string Active_cond = null;
            string Active_value = null;
            string spar_Active = "Active";
            fs.AddPar(spar_Active, ref lpar, Active_v, ref Active_cond, ref Active_value);

            string Description_cond = null;
            string Description_value = null;
            string spar_Description = "Description";
            fs.AddPar(spar_Description, ref lpar, Description_v, ref Description_cond, ref Description_value);

            string Person_ID_cond = null;
            string Person_ID_value = null;
            string spar_Person_ID = "Person_ID";
            fs.AddPar(spar_Person_ID, ref lpar, Person_ID_v, ref Person_ID_cond, ref Person_ID_value);

            string Office_ID_cond = null;
            string Office_ID_value = null;
            string spar_Office_ID = "Office_ID";
            fs.AddPar(spar_Office_ID, ref lpar, Office_ID_v, ref Office_ID_cond, ref Office_ID_value);

            string sql = "select ID from myOrganisation_Person where " + UserName_cond + " and "
                                                                       + Password_cond + " and "
                                                                       + Job_cond + " and "
                                                                       + Active_cond + " and "
                                                                       + Description_cond + " and "
                                                                       + Person_ID_cond + " and "
                                                                       + Office_ID_cond;

 
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (myOrganisation_Person_v == null)
                    {
                        myOrganisation_Person_v = new long_v();
                    }
                    myOrganisation_Person_v.v = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = "select ID from myOrganisation_Person where " + UserName_cond ;
                    if (DBSync.DBSync.ReadDataTable(ref dt, sql,lpar, ref Err))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            if (myOrganisation_Person_v == null)
                            {
                                myOrganisation_Person_v = new long_v();
                            }
                            myOrganisation_Person_v.v = (long)dt.Rows[0]["ID"];
                            sql = "update myOrganisation_Person set Password = " + Password_value + @",
                                                                set Job = " + Job_value + @",
                                                                set Active = " + Active_value + @",
                                                                set Description = " + Description_value + @",
                                                                set Person_ID = " + Person_ID_value + @",
                                                                set Office_ID = " + Office_ID_value + @"
                                                                where  ID = " + myOrganisation_Person_v.v.ToString();
                            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, lpar, ref Err))
                            {
                                return true;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:f_myOrganisation:Get: sql = " + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                        else
                        {
                            sql = @"insert into myOrganisation_Person ( UserName,
                                                                        Password,
                                                                        Job,
                                                                        Active,
                                                                        Description,
                                                                        Person_ID,
                                                                        Office_ID
                                                                        ) values
                                                                       ("
                                                                 + UserName_value + @",
                                                                " + Password_value + @",
                                                                " + Job_value + @",
                                                                " + Active_value + @",
                                                                " + Description_value + @",
                                                                " + Person_ID_value + @",
                                                                " + Office_ID_value + @")";
                            long myOrganisation_Person_ID = -1;
                            object oret = null;
                            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref myOrganisation_Person_ID, ref oret, ref Err, "myOrganisation_Person"))
                            {
                                if (myOrganisation_Person_v == null)
                                {
                                    myOrganisation_Person_v = new long_v();
                                }
                                myOrganisation_Person_v.v = myOrganisation_Person_ID;
                                return true;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:f_myOrganisation_Person:Get: sql = " + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_myOrganisation_Person:Get: sql = " + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_myOrganisation_Person:Get: sql = " + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool DeleteAll()
        {
            return fs.DeleteAll("myOrganisation_Person");
        }
    }
}
