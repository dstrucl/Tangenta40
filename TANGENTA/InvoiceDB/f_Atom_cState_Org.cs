using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBTypes;

namespace InvoiceDB
{
    public static class f_Atom_cState_Org
    {
        public static bool Get(long cState_Org_ID, ref long Atom_cState_Org_ID)
        {
            string Err = null;
            string sql = @"select State, State_ISO_3166_a2,State_ISO_3166_a3,State_ISO_3166_num from cState_Org where ID = " + cState_Org_ID.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {

                    object o_State = dt.Rows[0]["State"];
                    if (o_State is string)
                    {
                        string State = (string)o_State;
                        List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                        string spar_State = "@par_State";
                        SQL_Parameter par_State = new SQL_Parameter(spar_State, SQL_Parameter.eSQL_Parameter.Nvarchar, false, State);
                        lpar.Add(par_State);

                        string State_ISO_3166_a2 = (string)dt.Rows[0]["State_ISO_3166_a2"];
                        string spar_State_ISO_3166_a2 = "@par_State_ISO_3166_a2";
                        SQL_Parameter par_State_ISO_3166_a2 = new SQL_Parameter(spar_State_ISO_3166_a2, SQL_Parameter.eSQL_Parameter.Nvarchar, false, State_ISO_3166_a2);
                        lpar.Add(par_State_ISO_3166_a2);

                        string State_ISO_3166_a3 = (string)dt.Rows[0]["State_ISO_3166_a3"];
                        string spar_State_ISO_3166_a3 = "@par_State_ISO_3166_a3";
                        SQL_Parameter par_State_ISO_3166_a3 = new SQL_Parameter(spar_State_ISO_3166_a3, SQL_Parameter.eSQL_Parameter.Nvarchar, false, State_ISO_3166_a3);
                        lpar.Add(par_State_ISO_3166_a3);

                        short State_ISO_3166_num = Convert.ToInt16(dt.Rows[0]["State_ISO_3166_num"]);
                        string spar_State_ISO_3166_num = "@par_State_ISO_3166_num";
                        SQL_Parameter par_State_ISO_3166_num = new SQL_Parameter(spar_State_ISO_3166_num, SQL_Parameter.eSQL_Parameter.Smallint, false, State_ISO_3166_num);
                        lpar.Add(par_State_ISO_3166_num);


                        
                        dt.Columns.Clear();
                        dt.Clear();
                        sql = @"select ID from Atom_cState_Org where State = "+ spar_State+ " and  State_ISO_3166_a2 = "+ spar_State_ISO_3166_a2 + " and State_ISO_3166_a3 = " + spar_State_ISO_3166_a3 + " and State_ISO_3166_num = " + spar_State_ISO_3166_num;
                        if (DBSync.DBSync.ReadDataTable(ref dt, sql,lpar, ref Err))
                        {
                            if (dt.Rows.Count > 0)
                            {
                                Atom_cState_Org_ID = (long)dt.Rows[0]["ID"];
                                return true;
                            }
                            else
                            {
                                sql = @"insert into Atom_cState_Org (State,State_ISO_3166_a2,State_ISO_3166_a3,State_ISO_3166_num) values (" + spar_State + ","+ spar_State_ISO_3166_a2+","+ spar_State_ISO_3166_a3 +","+ spar_State_ISO_3166_num + ")";
                                object objretx = null;
                                if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_cState_Org_ID, ref objretx, ref Err, "Atom_cState_Org"))
                                {
                                    return true;
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:f_Atom_cState_Org:Get:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_Atom_cState_Org:Get:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_cState_Org:Get:1:No State for cState_Org_ID =" + cState_Org_ID.ToString());
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_cState_Org:Get:2:No State for cState_Org_ID =" + cState_Org_ID.ToString());
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_cState_Org:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        internal static bool Get(string_v state_v, string_v state_ISO_3166_a2_v, string_v state_ISO_3166_a3_v, short_v state_ISO_3166_num_v, ref long_v atom_cState_Org_ID_v)
        {
            if ((state_v != null)&& (state_ISO_3166_a2_v != null)&&(state_ISO_3166_a3_v!=null) && (state_ISO_3166_num_v!=null))
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string spar_state_v = "@par_state_v";
                SQL_Parameter par_state_v = new SQL_Parameter(spar_state_v, SQL_Parameter.eSQL_Parameter.Nvarchar, false, state_v.v);
                lpar.Add(par_state_v);
                string spar_state_ISO_3166_a2_v = "@par_state_ISO_3166_a2_v";
                SQL_Parameter par_state_ISO_3166_a2_v = new SQL_Parameter(spar_state_ISO_3166_a2_v, SQL_Parameter.eSQL_Parameter.Nvarchar, false, state_ISO_3166_a2_v.v);
                lpar.Add(par_state_ISO_3166_a2_v);
                string spar_state_ISO_3166_a3_v = "@par_state_ISO_3166_a3_v";
                SQL_Parameter par_state_ISO_3166_a3_v = new SQL_Parameter(spar_state_ISO_3166_a3_v, SQL_Parameter.eSQL_Parameter.Nvarchar, false, state_ISO_3166_a3_v.v);
                lpar.Add(par_state_ISO_3166_a3_v);

                string spar_state_ISO_3166_num_v = "@par_state_ISO_3166_num_v";
                SQL_Parameter par_state_ISO_3166_num_v = new SQL_Parameter(spar_state_ISO_3166_num_v, SQL_Parameter.eSQL_Parameter.Smallint, false, state_ISO_3166_num_v.v);
                lpar.Add(par_state_ISO_3166_num_v);


                string sql = @"select ID from Atom_cState_Org where State = "+ spar_state_v 
                                                                            + " and State_ISO_3166_a2 = " + spar_state_ISO_3166_a2_v 
                                                                            + " and State_ISO_3166_a3 =" + spar_state_ISO_3166_a3_v
                                                                            + " and State_ISO_3166_num =" + spar_state_ISO_3166_num_v;
                DataTable dt = new DataTable();
                string Err = null;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (atom_cState_Org_ID_v == null)
                        {
                            atom_cState_Org_ID_v = new long_v();
                        }
                        atom_cState_Org_ID_v.v = (long)dt.Rows[0]["ID"];
                        return true;
                    }
                    else
                    {
                        sql = @"insert into Atom_cState_Org (State,State_ISO_3166_a2,State_ISO_3166_a3,State_ISO_3166_num) values ("+ spar_state_v + ","
                                                                                                                                    + spar_state_ISO_3166_a2_v + ","
                                                                                                                                    + spar_state_ISO_3166_a3_v + ","
                                                                                                                                    + spar_state_ISO_3166_num_v +")";
                        long Atom_cState_Org_ID = -1;
                        object oret = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_cState_Org_ID, ref oret, ref Err, "Atom_cState_Org"))
                        {
                            if (atom_cState_Org_ID_v == null)
                            {
                                atom_cState_Org_ID_v = new long_v();
                            }
                            atom_cState_Org_ID_v.v = Atom_cState_Org_ID;
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:InvoiceDB:f_Atom_cState_Org:Get(string_v state_v, string_v state_ISO_3166_a2_v, string_v state_ISO_3166_a3_v, short_v state_ISO_3166_num_v, ref long_v atom_cState_Org_ID_v)\r\nsql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:InvoiceDB:f_Atom_cState_Org:Get(string_v state_v, string_v state_ISO_3166_a2_v, string_v state_ISO_3166_a3_v, short_v state_ISO_3166_num_v, ref long_v atom_cState_Org_ID_v)\r\nsql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:InvoiceDB:f_Atom_cState_Org:Get(string_v state_v, string_v state_ISO_3166_a2_v, string_v state_ISO_3166_a3_v, short_v state_ISO_3166_num_v, ref long_v atom_cState_Org_ID_v)\r\n state_v may not be null!");
                return false;
            }
        }
    }
}
