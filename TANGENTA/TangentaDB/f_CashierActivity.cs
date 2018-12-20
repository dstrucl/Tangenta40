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
    public static class f_CashierActivity
    {
        public static bool Open(string xAtom_ElectronicDevice_Name,
                                string xAtom_Office_ShortName, 
                                ID xAtom_WorkPeriod_ID,
                                ref ID xCashierActivityOpened_ID,
                                ref int xCashierActivityNumber, 
                                ref DateTime loginTime,
                                ref ID xCashierActivity_ID, 
                                ref bool bAllreadyOpened,
                                Transaction transaction)
        {
            string Err = null;
            string sql = null;
            bAllreadyOpened = false;
            xCashierActivityOpened_ID = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            ID existing_CashierActivityOpened_ID = null;
            ID existingOpened_CashierActivity_ID = null;
            int existingOpened_CashierActivityNumber = -1;
            if (GetOpened(xAtom_ElectronicDevice_Name,
                          xAtom_Office_ShortName,
                          ref existing_CashierActivityOpened_ID,
                          ref existingOpened_CashierActivity_ID,
                          ref existingOpened_CashierActivityNumber,
                          ref loginTime))
            {
                if (ID.Validate(existingOpened_CashierActivity_ID))
                {
                    xCashierActivityOpened_ID = existing_CashierActivityOpened_ID;
                    xCashierActivity_ID = existingOpened_CashierActivity_ID;
                    xCashierActivityNumber =existingOpened_CashierActivityNumber;
                    bAllreadyOpened = true;
                    return true;
                }
            }
            else
            {
                return false;
            }

            int last_cashierActivityNumber = -1;
            int cashierActivityNumber = -1;
            if (GetLastNumber(xAtom_ElectronicDevice_Name, xAtom_Office_ShortName, ref last_cashierActivityNumber))
            {
                cashierActivityNumber = last_cashierActivityNumber +1;
            }
            else
            {
                return false;
            }

            if (!f_CashierActivityOpened.Get(xAtom_WorkPeriod_ID, ref xCashierActivityOpened_ID, ref loginTime, transaction))
            {
                return false;
            }

            if (!ID.Validate(xCashierActivityOpened_ID))
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_CashierActivity:Open:xCashierActivityOpened_ID is not valid");
                return false;
            }

            string spar_CashierActivityNumber = "@par_CashierActivityNumber";
            SQL_Parameter par_CashierActivityNumber = new SQL_Parameter(spar_CashierActivityNumber,SQL_Parameter.eSQL_Parameter.Int, false, cashierActivityNumber);
            lpar.Add(par_CashierActivityNumber);

            string scond_CashierActivityOpened_ID = null;
            string sval_CashierActivityOpened_ID = "null";

            string spar_CashierActivityOpened_ID = "@par_CashierActivityOpened_ID";
            SQL_Parameter par_CashierActivityOpened_ID = new SQL_Parameter(spar_CashierActivityOpened_ID, false, xCashierActivityOpened_ID);
            lpar.Add(par_CashierActivityOpened_ID);
            scond_CashierActivityOpened_ID = "CashierActivityOpened_ID = " + spar_CashierActivityOpened_ID;
            sval_CashierActivityOpened_ID = spar_CashierActivityOpened_ID;


            sql = @"insert into CashierActivity (CashierActivityNumber,CashierActivityOpened_ID,CashierActivityClosed_ID) values (" + spar_CashierActivityNumber+"," + sval_CashierActivityOpened_ID+",null)";

            if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref xCashierActivity_ID, ref Err, "CashierActivity"))
            {
                xCashierActivityNumber = cashierActivityNumber;
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_CashierActivity:Open:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool GetTable(ref DataTable dt, ref List<CashierActivity> CashierActivity_List)
        {
            string Err = null;
            string sql = @"select
                     ca.CashierActivityNumber as CashierActivityNumber,
		             awpf.LoginTime as LoginTime,
		             awpl.LogoutTime as LogoutTime,
		             aof.Name As Atom_Office_Name,
		             aof.ShortName As Atom_Office_ShortName,
		             aedf.Name As Atom_ElectronicDevice_Name,
		             acfnf.FirstName As Person_LoggedIn_FirstName,
		             aclnf.LastName As Person_LoggedIn_LastName,
	                 apf.Tax_ID as Person_LoggedIn_TaxID,
		             acfnl.FirstName As Person_LoggedOut_FirstName,
		             aclnl.LastName As Person_LoggedOut_LastName,
	                 apl.Tax_ID as Person_LoggedOut_TaxID,
		             ca.ID as CashierActivity_ID,
                     ca.CashierActivityOpened_ID as CashierActivityOpened_ID,
                     awpf.ID as Login_Atom_WorkPeriod_ID,
                     ca.CashierActivityClosed_ID as CashierActivityClosed_ID,
                     awpl.ID as Logout_Atom_WorkPeriod_ID
              from CashierActivity ca
              inner  join CashierActivityOpened cao on ca.CashierActivityOpened_ID = cao.ID
              inner  join Atom_WorkPeriod awpf on cao.Atom_WorkPeriod_ID = awpf.ID
              inner  join Atom_ElectronicDevice aedf on awpf.Atom_ElectronicDevice_ID = aedf.ID
              inner  join Atom_Office aof on aedf.Atom_Office_ID = aof.ID
              inner  join Atom_myOrganisation_Person amopf on awpf.Atom_myOrganisation_Person_ID = amopf.ID
              inner  join Atom_Person apf on amopf.Atom_Person_ID = apf.ID
              inner  join Atom_cFirstName acfnf on apf.Atom_cFirstName_ID = acfnf.ID
              inner  join Atom_cLastName aclnf on apf.Atom_cLastName_ID = aclnf.ID
              inner  join CashierActivityClosed cac on ca.CashierActivityClosed_ID = cac.ID
              inner  join Atom_WorkPeriod awpl on cac.Atom_WorkPeriod_ID = awpl.ID
              inner  join Atom_myOrganisation_Person amopl on awpl.Atom_myOrganisation_Person_ID = amopl.ID
              inner  join Atom_Person apl on amopl.Atom_Person_ID = apl.ID
              inner  join Atom_cFirstName acfnl on apl.Atom_cFirstName_ID = acfnl.ID
              inner  join Atom_cLastName aclnl on apl.Atom_cLastName_ID = aclnl.ID
              order by awpl.LogoutTime desc
            ";
            if (dt== null)
            {
                dt = new DataTable();
            }
            else
            {
                dt.Clear();
                dt.Columns.Clear();
            }
            if (DBSync.DBSync.ReadDataTable(ref dt,sql,ref Err))
            {

                if (CashierActivity_List==null)
                {
                    CashierActivity_List = new List<CashierActivity>();
                }
                else
                {
                    CashierActivity_List.Clear();
                }

                int iCount = dt.Rows.Count;
                for (int i =0;i<iCount;i++)
                {
                    DataRow dr = dt.Rows[i];
                    CashierActivity ca = Get(dr);
                    if (ca != null)
                    {
                        CashierActivity_List.Add(ca);
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_CashierActivity:GetTable:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private static CashierActivity Get(DataRow dr)
        {
            int_v xCashierActivityNUmber_v = tf.set_int(dr["CashierActivityNumber"]);
            if (xCashierActivityNUmber_v==null)
            {
                LogFile.Error.Show("ERROR:f_CashierActivity:Get(DataRow dr): (xCashierActivityNUmber_v==null)");
                return null;

            }

            ID xCashierActivity_ID = tf.set_ID(dr["CashierActivity_ID"]);
            if (!ID.Validate(xCashierActivity_ID))
            {
                LogFile.Error.Show("ERROR:f_CashierActivity:Get(DataRow dr): xCashierActivity_ID is not valid");
                return null;

            }


            ID xCashierActivityOpened_ID = tf.set_ID(dr["CashierActivityOpened_ID"]);
            if (!ID.Validate(xCashierActivityOpened_ID))
            {
                LogFile.Error.Show("ERROR:f_CashierActivity:Get(DataRow dr): xCashierActivityOpened_ID is not valid");
                return null;

            }

            ID xCashierActivityClosed_ID = tf.set_ID(dr["CashierActivityClosed_ID"]);
            if (!ID.Validate(xCashierActivityClosed_ID))
            {
                LogFile.Error.Show("ERROR:f_CashierActivity:Get(DataRow dr): xCashierActivityClosed_ID is not valid");
                return null;

            }

            ID xLogin_Atom_WorkPeriod_ID = tf.set_ID(dr["Login_Atom_WorkPeriod_ID"]);
            if (!ID.Validate(xLogin_Atom_WorkPeriod_ID))
            {
                LogFile.Error.Show("ERROR:f_CashierActivity:Get(DataRow dr): Login_Atom_WorkPeriod_ID is not valid");
                return null;

            }

            DateTime_v xFirstTime_v = tf.set_DateTime(dr["LoginTime"]);
            if (xFirstTime_v==null)
            {
                LogFile.Error.Show("ERROR:f_CashierActivity:Get(DataRow dr): xFirstTime_v == null");
                return null;

            }

            ID xLogout_Atom_WorkPeriod_ID = tf.set_ID(dr["Logout_Atom_WorkPeriod_ID"]);
            if (!ID.Validate(xLogout_Atom_WorkPeriod_ID))
            {
                LogFile.Error.Show("ERROR:f_CashierActivity:Get(DataRow dr): Logout_Atom_WorkPeriod_ID is not valid");
                return null;

            }

            DateTime_v xLastTime_v = tf.set_DateTime(dr["LogoutTime"]);
            if (xLastTime_v == null)
            {
                LogFile.Error.Show("ERROR:f_CashierActivity:Get(DataRow dr): xLastTime_v == null");
                return null;

            }

            string_v xAtom_ElectronicDevice_Name_v = tf.set_string(dr["Atom_ElectronicDevice_Name"]);
            if (xAtom_ElectronicDevice_Name_v == null)
            {
                LogFile.Error.Show("ERROR:f_CashierActivity:Get(DataRow dr): Atom_ElectronicDevice_Name_v == null");
                return null;

            }

            string_v xAtom_Office_ShortName_v = tf.set_string(dr["Atom_Office_ShortName"]);
            if (xAtom_Office_ShortName_v == null)
            {
                LogFile.Error.Show("ERROR:f_CashierActivity:Get(DataRow dr): xAtom_Office_ShortName_v == null");
                return null;

            }

            

            CashierActivity ca = new CashierActivity(xCashierActivityNUmber_v.v,
                                                     xLogin_Atom_WorkPeriod_ID,
                                                     xFirstTime_v.v,
                                                     xLogout_Atom_WorkPeriod_ID,
                                                     xLastTime_v.v
                                                     );
            ca.Atom_Office_ShortName = xAtom_Office_ShortName_v.v;
            ca.Atom_ElectronicDevice_Name = xAtom_ElectronicDevice_Name_v.v;
            ca.CashierActivityOpened_ID = xCashierActivityOpened_ID;
            ca.CashierActivityClosed_ID = xCashierActivityClosed_ID;
            if (ID.Validate(ca.CashierActivityClosed_ID))
            {
                ca.CashierState = CashierActivity.eCashierState.CLOSED;
            }
            else
            {
                ca.CashierState = CashierActivity.eCashierState.OPENED;
            }

            ca.ID = xCashierActivity_ID;
            ca.GetDocInvoices();
            return ca;
        }

        public static bool GetOpened(string xAtom_ElectronicDevice_Name,
                                     string xAtom_Office_ShortName,
                                     ref ID xCashierActivityOpened_ID,
                                     ref ID xCashierActivity_ID, 
                                     ref int xCashierActivityNumber,
                                     ref DateTime firstTime)
        {
            xCashierActivityNumber = -1;
            xCashierActivity_ID = null;
            string Err = null;
            string sql = null;

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string scond_Atom_ShortName = null;
            string sval_Atom_ShortName = "null";
            if (xAtom_Office_ShortName!=null)
            {
                string spar_Atom_ShortName = "@par_ShortName";
                SQL_Parameter par_Atom_ShortName = new SQL_Parameter(spar_Atom_ShortName, SQL_Parameter.eSQL_Parameter.Nvarchar,false, xAtom_Office_ShortName);
                lpar.Add(par_Atom_ShortName);
                scond_Atom_ShortName = "ao.ShortName = " + spar_Atom_ShortName;
                sval_Atom_ShortName = spar_Atom_ShortName;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_CashierActivity:Get:GetOpened:Atom_Office_ID is not valid");
                return false;
            }


            string spar_Atom_ElectronicDevice_Name = "@par_Atom_ElectronicDevice_Name";
            SQL_Parameter par_Atom_ElectronicDevice_Name = new SQL_Parameter(spar_Atom_ElectronicDevice_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, xAtom_ElectronicDevice_Name);
            lpar.Add(par_Atom_ElectronicDevice_Name);
            string scond_Atom_ElectronicDevice_Name = "aed.Name = " + spar_Atom_ElectronicDevice_Name;

            DataTable dt = new DataTable();
            dt.Columns.Clear();
            dt.Clear();
            sql = @"select ca.ID as ID,
                           ca.CashierActivityOpened_ID as CashierActivityOpened_ID,
                           ca.CashierActivityNumber as CashierActivityNumber,
                           awp.LoginTime
                    from CashierActivity ca
                    inner join CashierActivityOpened cao on  ca.CashierActivityOpened_ID = cao.ID
                    inner join Atom_WorkPeriod awp on  cao.Atom_WorkPeriod_ID = awp.ID
                    inner join Atom_ElectronicDevice aed on  awp.Atom_ElectronicDevice_ID = aed.ID
                    INNER JOIN Atom_Office ao ON aed.Atom_Office_ID = ao.ID
                    where " + scond_Atom_ShortName + " and " + scond_Atom_ElectronicDevice_Name + " and ca.CashierActivityClosed_ID is null";
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    xCashierActivityOpened_ID = tf.set_ID(dt.Rows[0]["CashierActivityOpened_ID"]);
                    int_v xCashierActivityNumber_v = tf.set_int(dt.Rows[0]["CashierActivityNumber"]);
                    if (xCashierActivityNumber_v!=null)
                    {
                        xCashierActivityNumber = xCashierActivityNumber_v.v;
                        xCashierActivity_ID = tf.set_ID(dt.Rows[0]["ID"]);
                        DateTime_v firstTime_v = tf.set_DateTime(dt.Rows[0]["LoginTime"]);
                        if (firstTime_v!=null)
                        {
                            firstTime = firstTime_v.v;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:f_CashierActivity:Get:GetOpened:(xCashierActivityNumber_v==null)");
                        return false;
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_CashierActivity:GetOpened:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Close(ID xCashierActivity_ID,ID xAtom_WorkPeriod_ID, Transaction transaction)
        {
            bool bIsOpened = false;
            if (IsOpened(xCashierActivity_ID, ref bIsOpened))
            {
                if (!bIsOpened)
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_CashierActivity:Open:xCashierActivity_ID = " + xCashierActivity_ID + " is allready closed");
                    return false;
                }
            }
            else
            {
                return false;
            }
            ID xCashierActivityClosed_ID = null;
            if (!f_CashierActivityClosed.Get(xAtom_WorkPeriod_ID, ref xCashierActivityClosed_ID, transaction))
            {
                return false;
            }
            if (!ID.Validate(xCashierActivityClosed_ID))
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_CashierActivity:Close:xCashierActivityClosed_ID is not valid");
                return false;
            }

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_CashierActivityClosed_ID = "@par_CashierActivityClosed_ID";
            SQL_Parameter par_CashierActivityClosed_ID = new SQL_Parameter(spar_CashierActivityClosed_ID, false, xCashierActivityClosed_ID);
            lpar.Add(par_CashierActivityClosed_ID);

            string spar_CashierActivity_ID = "@par_CashierActivity_ID";
            SQL_Parameter par_CashierActivity_ID = new SQL_Parameter(spar_CashierActivity_ID, false, xCashierActivity_ID);
            lpar.Add(par_CashierActivity_ID);

            string sql = "update CashierActivity set CashierActivityClosed_ID = " + spar_CashierActivityClosed_ID + " where ID = " + spar_CashierActivity_ID;
            string Err = null;
            if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql,lpar, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_CashierActivity:Close:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool IsOpened(ID xCashierActivity_ID, ref bool bIsOpened)
        {

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_CashierActivity_ID = "@par_CashierActivity_ID";
            SQL_Parameter par_CashierActivity_ID = new SQL_Parameter(spar_CashierActivity_ID, false, xCashierActivity_ID);
            lpar.Add(par_CashierActivity_ID);

            DataTable dt = new DataTable();
            dt.Columns.Clear();
            dt.Clear();
            string Err = null;
            string sql = @"select CashierActivityClosed_ID
                    from CashierActivity
                    where ID = " + spar_CashierActivity_ID;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    ID xCashierActivityClosed_ID = tf.set_ID(dt.Rows[0]["CashierActivityClosed_ID"]);
                    if (ID.Validate(xCashierActivityClosed_ID))
                    {
                        bIsOpened = false;
                    }
                    else
                    {
                        bIsOpened = true;
                    }
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_CashierActivity:IsOpened:xCashierActivity_ID = " + xCashierActivity_ID + " is not found!");
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_CashierActivity:IsOpened:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool GetLastNumber(string xAtom_ElectronicDevice_Name, string xAtom_Office_ShortName, ref int xCashierActivityNumber)
        {
            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string scond_Atom_ShortName = null;
            string sval_Atom_ShortName = "null";
            if (xAtom_Office_ShortName!=null)
            {
                string spar_Atom_ShortName = "@par_Atom_ShortName";
                SQL_Parameter par_Atom_ShortName = new SQL_Parameter(spar_Atom_ShortName,SQL_Parameter.eSQL_Parameter.Nvarchar, false, xAtom_Office_ShortName);
                lpar.Add(par_Atom_ShortName);
                scond_Atom_ShortName = "ao.ShortName = " + spar_Atom_ShortName;
                sval_Atom_ShortName = spar_Atom_ShortName;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_CashierActivity:Get:GetOpened:Atom_ShortName is not valid");
                return false;
            }

            string spar_Atom_ElectronicDevice_Name = "@par_Atom_ElectronicDevice_Name";
            SQL_Parameter par_Atom_ElectronicDevice_Name = new SQL_Parameter(spar_Atom_ElectronicDevice_Name,SQL_Parameter.eSQL_Parameter.Nvarchar, false, xAtom_ElectronicDevice_Name);
            lpar.Add(par_Atom_ElectronicDevice_Name);
            string scond_Atom_ElectronicDevice_Name = "aed.Name = " + spar_Atom_ElectronicDevice_Name;

            string sql = @"select ca.CashierActivityNumber 
                        from CashierActivity ca
                        inner join CashierActivityOpened cao on  ca.CashierActivityOpened_ID = cao.ID
                        inner join Atom_WorkPeriod awp on  cao.Atom_WorkPeriod_ID = awp.ID
                        inner join Atom_ElectronicDevice aed on  awp.Atom_ElectronicDevice_ID = aed.ID
                        INNER JOIN Atom_Office ao ON aed.Atom_Office_ID = ao.ID
                          where " + scond_Atom_ShortName + @" and "+ scond_Atom_ElectronicDevice_Name + @" 
                          order by CashierActivityNumber desc limit 1";
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql,lpar,ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    int_v xCashierActivityNumber_v = tf.set_int(dt.Rows[0]["CashierActivityNumber"]);
                    if (xCashierActivityNumber_v!=null)
                    {
                        xCashierActivityNumber = xCashierActivityNumber_v.v;
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_CashierActivity:GetLastNumber:(xCashierActivityNumber_v==null)");
                        return false;
                    }
                }
                xCashierActivityNumber = 0;
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_CashierActivity:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

    }
}
