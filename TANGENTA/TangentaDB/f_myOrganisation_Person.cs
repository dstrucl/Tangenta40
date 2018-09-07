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
        public static bool Get(string_v Job_v,
                               bool_v Active_v,
                               string_v Description_v,
                               ID Person_ID,
                               ID Office_ID,
                               ref ID myOrganisation_Person_ID)
        {
            string Err = null;
            DataTable dt = new DataTable();
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

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
            fs.AddPar(spar_Person_ID, ref lpar, Person_ID, ref Person_ID_cond, ref Person_ID_value);

            string Office_ID_cond = null;
            string Office_ID_value = null;
            string spar_Office_ID = "Office_ID";
            fs.AddPar(spar_Office_ID, ref lpar, Office_ID, ref Office_ID_cond, ref Office_ID_value);

            string sql = "select ID from myOrganisation_Person where " + Job_cond + " and "
                                                                       + Active_cond + " and "
                                                                       + Description_cond + " and "
                                                                       + Person_ID_cond + " and "
                                                                       + Office_ID_cond;

 
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (myOrganisation_Person_ID == null)
                    {
                        myOrganisation_Person_ID = new ID();
                    }
                    myOrganisation_Person_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @"insert into myOrganisation_Person ( Job,
                                                                Active,
                                                                Description,
                                                                Person_ID,
                                                                Office_ID
                                                                ) values
                                                                ("
                                                            + Job_value + @",
                                                        " + Active_value + @",
                                                        " + Description_value + @",
                                                        " + Person_ID_value + @",
                                                        " + Office_ID_value + @")";
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref myOrganisation_Person_ID, ref Err, "myOrganisation_Person"))
                    {
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

        public static bool DeleteAll()
        {
            return fs.DeleteAll("myOrganisation_Person");
        }

        public static ID myOrganisation_Person_SingleUser_ID()
        {
            string sql = null;
            sql = @"select mopsu.myOrganisation_Person_ID as myOrganisation_Person_ID
                    from myOrganisation_Person_SingleUser mopsu 
	                inner join myOrganisation_Person mop on mopsu.myOrganisation_Person_ID = mop.ID
	                where mopsu.ElectronicDevice_ID = " + myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice.ID.ToString();

            DataTable dt = new DataTable();
            string err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref err))
            {
                if (dt.Rows.Count>0)
                {
                    return new ID(dt.Rows[0]["myOrganisation_Person_ID"]);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_myOrganisation_Person:First_ID:sql=" + sql + "\r\nErr="+err);
                return null;
            }
        }
    }
}
