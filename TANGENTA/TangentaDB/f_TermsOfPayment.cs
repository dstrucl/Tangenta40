using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_TermsOfPayment
    {
        public static bool Get(string Description, ref ID TermsOfPayment_ID, Transaction transaction)
        {
            if (Description != null)
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string Err = null;
                DataTable dt = new DataTable();

                string scond_Description = " Description is null ";
                string sval_Description = " null ";

                if (Description != null)
                {
                    string spar_Description = "@par_Description";
                    SQL_Parameter par_Description = new SQL_Parameter(spar_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Description);
                    lpar.Add(par_Description);
                    scond_Description = " Description = " + spar_Description;
                    sval_Description = " " + spar_Description + " ";
                }

                string sql = " select ID from TermsOfPayment where " + scond_Description;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (TermsOfPayment_ID == null)
                        {
                            TermsOfPayment_ID = new ID();
                        }
                        TermsOfPayment_ID.Set(dt.Rows[0]["ID"]);
                        return true;
                    }
                    else
                    {
                        if (!transaction.Get(DBSync.DBSync.Con))
                        {
                            return false;
                        }
                        sql = @" insert into  TermsOfPayment (Description) values
                                                      (" + sval_Description + ")";
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref TermsOfPayment_ID, ref Err, "TermsOfPayment"))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_TermsOfPayment:Get:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_TermsOfPayment:Get:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                TermsOfPayment_ID = null;
                return true;
            }
        }

        internal static bool SetDefault(ID xTermsOfPayment_ID, Transaction transaction)
        {
            if (ID.Validate(myOrg.ElectronicDevice_ID))
            {
                if (myOrg.m_myOrg_Office != null)
                {
                    if (ID.Validate(myOrg.m_myOrg_Office.ID))
                    {
                        ID xAtom_Office_ID = null;
                        if (f_Atom_Office.Get(myOrg.m_myOrg_Office.ID,ref xAtom_Office_ID, transaction))
                        {
                            ID xAtom_ElectronicDevice_ID = null;
                            if (myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice!=null)
                            { 

                                if (myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice.ElectronicDevice_Name!=null)
                                { 
                                    if (f_Atom_ElectronicDevice.Get(xAtom_Office_ID, myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice.ElectronicDevice_Name, myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice.ElectronicDevice_Description, ref xAtom_ElectronicDevice_ID,transaction))
                                    {
                                        if (ID.Validate(xAtom_ElectronicDevice_ID))
                                        {
                                            string sql = "select ID,TermsOfPayment_ID from TermsOfPayment_Default where Atom_ElectronicDevice_ID = " + xAtom_ElectronicDevice_ID.ToString();
                                            DataTable dt = new DataTable();
                                            string Err = null;
                                            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                                            {
                                                if (dt.Rows.Count > 0)
                                                {
                                                    if (!transaction.Get(DBSync.DBSync.Con))
                                                    {
                                                        return false;
                                                    }
                                                    sql = "update TermsOfPayment_Default set TermsOfPayment_ID = " + xTermsOfPayment_ID.ToString();
                                                    if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref Err))
                                                    {
                                                        return true;
                                                    }
                                                    else
                                                    {
                                                        LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:SetDefault:sql=" + sql + "\r\nErr=" + Err);
                                                        return false;
                                                    }
                                                }
                                                else
                                                {
                                                    if (!transaction.Get(DBSync.DBSync.Con))
                                                    {
                                                        return false;
                                                    }
                                                    sql = "insert into TermsOfPayment_Default (TermsOfPayment_ID,Atom_ElectronicDevice_ID)values(" + xTermsOfPayment_ID.ToString() + "," + xAtom_ElectronicDevice_ID.ToString() + ")";
                                                    ID xTermsOfPayment_Default_ID = null;
                                                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, null, ref xTermsOfPayment_Default_ID, ref Err, "TermsOfPayment_Default"))
                                                    {
                                                        return true;
                                                    }
                                                    else
                                                    {
                                                        LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:SetDefault:sql=" + sql + "\r\nErr=" + Err);
                                                        return false;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:SetDefault:sql=" + sql + "\r\nErr=" + Err);
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:SetDefault:xAtom_ElectronicDevice_ID is not valid!");
                                            return false;
                                        }

                                    }
                                    else
                                    {
                                        LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:SetDefault:f_Atom_ElectronicDevice.Get(..) failed!");
                                        return false;
                                    }
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:SetDefault:myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice.ElectronicDevice_Name==null");
                                    return false;
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:SetDefault:myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice==null");
                                return false;
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:SetDefault:f_Atom_Office.Get(..) failed!");
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:SetDefault:myOrg.m_myOrg_Office.ID is not valid");
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:SetDefault:myOrg.m_myOrg_Office == null");
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:SetDefault:myOrg.Atom_ElectronicDevice_ID is not valid");
                return false;
            }
        }

        public static bool Get(ID TermsOfPayment_ID, ref string_v xDescription_v)
        {
            DataTable dt = new DataTable();
            string Err = null;
            string sql = " select Description from TermsOfPayment where ID = " + TermsOfPayment_ID.ToString();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    xDescription_v = tf.set_string(dt.Rows[0]["Description"]);
                }
                else
                {
                    xDescription_v = null;
                }
                return true;
            }
            else
            {
                xDescription_v = null;
                LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        internal static bool GetDefault(ref ID xIDdefault, ref string_v description_v, Transaction transaction)
        {
            if (ID.Validate(myOrg.ElectronicDevice_ID))
            {
                string sql = "select ID,TermsOfPayment_ID from TermsOfPayment_Default where Atom_ElectronicDevice_ID = " + myOrg.ElectronicDevice_ID.ToString();
                DataTable dt = new DataTable();
                string Err = null;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        xIDdefault = tf.set_ID(dt.Rows[0]["TermsOfPayment_ID"]);
                        if (ID.Validate(xIDdefault))
                        {
                            sql = "select Description from TermsOfPayment where ID = " + xIDdefault.ToString();
                            dt.Clear();
                            dt.Columns.Clear();
                            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                            {
                                if (dt.Rows.Count > 0)
                                {

                                    description_v = tf.set_string(dt.Rows[0]["Description"]);
                                    if (description_v == null)
                                    {
                                        LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:GetDefault:description_v is null in table  TermsOfPayment!");
                                        return false;
                                    }
                                    return true;
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:GetDefault:sql=" + sql + "\r\n Default TermsOfpayment not found!");
                                    return false;
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:GetDefault:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:GetDefault:Deafult TermsOfPayment_ID is not valid!");
                            return false;
                        }
                    }
                    else
                    {
                        if (myOrg.m_myOrg_Office != null)
                        {
                            if (myOrg.m_myOrg_Office.Name_v != null)
                            {
                                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                                string spar_aof_name = "@par_aof_name";
                                SQL_Parameter par_aof_name = new SQL_Parameter(spar_aof_name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, myOrg.m_myOrg_Office.Name_v.v);
                                lpar.Add(par_aof_name);
                                dt.Clear();
                                dt.Columns.Clear();
                                sql = @"select tofpd.TermsOfPayment_ID as TermsOfPayment_ID,
                                               topf.Description as Description
                                     from TermsOfPayment_Default as tofpd 
                                     inner join TermsOfPayment as topf on tofpd.TermsOfPayment_ID = topf.ID
                                     inner join Atom_ElectronicDevice as aed on aed.ID=tofpd.Atom_ElectronicDevice_ID
                                     inner join Atom_Office as aof on aed.Atom_Office_ID = aof.ID 
									 where aof.Name = " + spar_aof_name;
                                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                                {
                                    if (dt.Rows.Count > 0)
                                    {
                                        xIDdefault = tf.set_ID(dt.Rows[0]["TermsOfPayment_ID"]);
                                        if (ID.Validate(xIDdefault))
                                        {
                                            SetDefault(xIDdefault, transaction);
                                            description_v = tf.set_string(dt.Rows[0]["Description"]);
                                            if (description_v == null)
                                            {
                                                LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:GetDefault:description_v is null in table  TermsOfPayment!");
                                                return false;
                                            }
                                            return true;
                                        }
                                        else
                                        {
                                            LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:GetDefault:Deafult TermsOfPayment_ID for office " + myOrg.m_myOrg_Office.Name_v.v + " is not found!");
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        int iTry = 0;
                  DoSelectAgain:
                                        sql = @"select tofpd.TermsOfPayment_ID as TermsOfPayment_ID,
                                                 topf.Description as Description
                                                 from TermsOfPayment_Default as tofpd
                                                 inner join TermsOfPayment as topf on tofpd.TermsOfPayment_ID = topf.ID
                                                ";
                                        dt.Clear();
                                        dt.Columns.Clear();
                                        if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                                        {
                                            if (dt.Rows.Count > 0)
                                            {
                                                xIDdefault = tf.set_ID(dt.Rows[0]["TermsOfPayment_ID"]);
                                                if (ID.Validate(xIDdefault))
                                                {
                                                    SetDefault(xIDdefault,transaction);
                                                    description_v = tf.set_string(dt.Rows[0]["Description"]);
                                                    if (description_v==null)
                                                    {
                                                        LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:GetDefault:description_v is null in table  TermsOfPayment!");
                                                        return false;
                                                    }
                                                    return true;
                                                }
                                                else
                                                {
                                                    LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:GetDefault:Deafult TermsOfPayment_ID not found in table TermsOfPayment_Default ");
                                                    return false;
                                                }
                                            }
                                            else
                                            {
                                                // If your database is moved to some ElectronicDevice next lines of codes will write TermsOfPayment_Default table
                                                if (iTry == 0)
                                                {
                                                    switch (DBSync.DBSync.m_DBType)
                                                    {
                                                        case DBConnection.eDBType.SQLITE:
                                                            sql = @"select ID From TermsOfPayment limit 1";
                                                            break;

                                                        case DBConnection.eDBType.MSSQL:
                                                            sql = @"select TOP 1 ID From TermsOfPayment";
                                                            break;
                                                        default:
                                                            LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:GetDefault:DBSync.DBSync.m_DBType not implemeneted for DBSync.DBSync.m_DBType = " + DBSync.DBSync.m_DBType.ToString());
                                                            break;
                                                    }
                                                    dt.Clear();
                                                    dt.Columns.Clear();
                                                    if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                                                    {
                                                        if (dt.Rows.Count > 0)
                                                        {
                                                            xIDdefault = tf.set_ID(dt.Rows[0]["ID"]);
                                                            if (ID.Validate(xIDdefault))
                                                            {
                                                                if (SetDefault(xIDdefault,transaction))
                                                                {
                                                                    iTry++;
                                                                    goto DoSelectAgain;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:GetDefault: Table TermsOfPayment_Default is empty!");
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:GetDefault:sql=" + sql + "\r\nErr=" + Err);
                                            return false;
                                        }
                                    }
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:GetDefault:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:GetDefault:myOrg.m_myOrg_Office.Name_v  is null");
                                return false;
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:GetDefault:myOrg.m_myOrg_Office  is null");
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:GetDefault:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:GetDefault:myOrg.Atom_ElectronicDevice_ID is not valid");
                return false;
            }
        }

        public static bool GetDefault(ref ID xID,ref string xDescription, Transaction transaction)
        {
            string_v description_v = null;
            ID xIDdefault = null;
            if (f_TermsOfPayment.GetDefault(ref xIDdefault, ref description_v,transaction))
            {
                if (description_v != null)
                {
                    xID = xIDdefault;
                    xDescription = description_v.v;
                    return true;
                }
            }
            return false;
        }
    }
}
