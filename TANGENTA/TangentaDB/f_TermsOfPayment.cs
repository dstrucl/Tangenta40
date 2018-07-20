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
        public static bool Get(string Description, ref ID TermsOfPayment_ID)
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

        internal static bool SetDefault(ID xTermsOfPayment_ID)
        {
            if (ID.Validate(myOrg.Atom_ElectronicDevice_ID))
            {
                string sql = "select ID,TermsOfPayment_ID from TermsOfPayment_Default where Atom_ElectronicDevice_ID = " + myOrg.Atom_ElectronicDevice_ID.ToString();
                DataTable dt = new DataTable();
                string Err = null;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        sql = "update TermsOfPayment_Default set TermsOfPayment_ID = " + xTermsOfPayment_ID.ToString();
                        object ores = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref ores, ref Err))
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
                        sql = "insert into TermsOfPayment_Default (TermsOfPayment_ID,Atom_ElectronicDevice_ID)values("+ xTermsOfPayment_ID.ToString() + ","+ myOrg.Atom_ElectronicDevice_ID.ToString()+")";
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

        internal static bool GetDefault(ref ID xIDdefault, ref string_v description_v)
        {
            if (ID.Validate(myOrg.Atom_ElectronicDevice_ID))
            {
                string sql = "select ID,TermsOfPayment_ID from TermsOfPayment_Default where Atom_ElectronicDevice_ID = " + myOrg.Atom_ElectronicDevice_ID.ToString();
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
                        string sElectronicDeviceName = null;
                        if (myOrg.m_myOrg_Office!=null)
                        {
                            sElectronicDeviceName = myOrg.m_myOrg_Office.Atom_ElectronicDevice_ComputerName + "/" + myOrg.m_myOrg_Office.Atom_ElectronicDevice_ComputerUserName;
                        }
                        if (sElectronicDeviceName != null)
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:GetDefault:Deafult TermsOfPayment_ID for Electronic device = "+ sElectronicDeviceName +" was not not found!");
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:GetDefault:Deafult TermsOfPayment_ID for Electronic device = null was not not found!");
                        }
                        return false;
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
                LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:GetDefault:myOrg.Atom_ElectronicDevice_ID is not valid");
                return false;
            }
        }
    }
}
