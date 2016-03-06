#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBConnectionControl40;
using DBTypes;
using CodeTables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB
{
    public class PostAddress_v
    {
        public string_v StreetName_v = null;
        public string_v HouseNumber_v = null;
        public string_v ZIP_v = null;
        public string_v City_v = null;
        public string_v Country_v = null;
        public string_v Country_ISO_3166_a2_v = null;
        public string_v Country_ISO_3166_a3_v = null;
        public short_v Country_ISO_3166_num_v = null;
        public string_v State_v = null;

        public long ID = -1;

        public string StreetName { get { return StreetName_v.vs; } }
        public string HouseNumber { get { return HouseNumber_v.vs; } }
        public string ZIP { get { return ZIP_v.vs; } }
        public string City { get { return City_v.vs; } }
        public string Country{ get { return Country_v.vs; } }
        public string Country_ISO_3166_a2 { get { return Country_ISO_3166_a2_v.vs; } }
        public string Country_ISO_3166_a3 { get { return Country_ISO_3166_a3_v.vs; } }
        public short Country_ISO_3166_num { get { return Country_ISO_3166_num_v.v; } }

        public string State
        {
            get
            {
                return State_v.vs;
            }
        }


        public PostAddress_v Clone()
        {
            PostAddress_v pa = new PostAddress_v();
            pa.StreetName_v = string_v.Copy(this.StreetName_v);
            pa.HouseNumber_v = string_v.Copy(this.HouseNumber_v);
            pa.ZIP_v = string_v.Copy(this.ZIP_v);
            pa.City_v = string_v.Copy(this.City_v);
            pa.Country_v = string_v.Copy(this.Country_v);
            pa.State_v = string_v.Copy(this.State_v);
            pa.Country_ISO_3166_a2_v = string_v.Copy(this.Country_ISO_3166_a2_v);
            pa.Country_ISO_3166_a3_v = string_v.Copy(this.Country_ISO_3166_a3_v);
            pa.Country_ISO_3166_num_v = short_v.Copy(this.Country_ISO_3166_num_v);

            return pa;
        }

        public static PostAddress_v Copy(PostAddress_v xpa)
        {
            if (xpa != null)
            {
                return xpa.Clone();
            }
            else
            {
                return null;
            }
        }

        public bool Get_Address_Tabel_ID(SQLTable Address_Tabel, ref ID_v iD_v)
        {
            string Err = null;
            string sql_select = "select ID from " + Address_Tabel.TableName + " where ";
            string sql_conditions = null;
            string sql_insert = "insert into " + Address_Tabel.TableName + "(";
            string sql_insert_columns = null;
            string sql_values = null;
            foreach (Column col in Address_Tabel.Column)
            {
                if (!col.IsIdentity)
                {
                    if (col.fKey != null)
                    {
                        if (col.fKey.fTable != null)
                        {
                            foreach (Column c in col.fKey.fTable.Column)
                            {
                                if (!c.IsIdentity)
                                {
                                    if (c.fKey == null)
                                    {
                                        if (c.Name.Equals("StreetName"))
                                        {
                                            if (!GetAddressElementID(col.fKey.fTable.TableName, c.Name, StreetName, ref col.fKey.reference_ID))
                                            {
                                                return false;
                                            }
                                        }
                                        else if (c.Name.Equals("HouseNumber"))
                                        {
                                            if (!GetAddressElementID(col.fKey.fTable.TableName, c.Name, HouseNumber, ref col.fKey.reference_ID))
                                            {
                                                return false;
                                            }
                                        }
                                        else if (c.Name.Equals("ZIP"))
                                        {
                                            if (!GetAddressElementID(col.fKey.fTable.TableName, c.Name, ZIP, ref col.fKey.reference_ID))
                                            {
                                                return false;
                                            }
                                        }
                                        else if (c.Name.Equals("City"))
                                        {
                                            if (!GetAddressElementID(col.fKey.fTable.TableName, c.Name, City, ref col.fKey.reference_ID))
                                            {
                                                return false;
                                            }
                                        }
                                        else if (c.Name.Equals("Country"))
                                        {
                                            string tbl_name = col.fKey.fTable.TableName;
                                            if (!GetAddressElementID(tbl_name, new string[] { "Country", "Country_ISO_3166_a2", "Country_ISO_3166_a3", "Country_ISO_3166_num" },
                                                                                                new object[] { Country, Country_ISO_3166_a2, Country_ISO_3166_a3, Country_ISO_3166_num },
                                                                                                ref col.fKey.reference_ID))
                                            {
                                                return false;
                                            }
                                        }
                                        else if (c.Name.Equals("State"))
                                        {
                                            if (State_v != null)
                                            {
                                                if (!GetAddressElementID(col.fKey.fTable.TableName, c.Name, State, ref col.fKey.reference_ID))
                                                {
                                                    return false;
                                                }
                                            }
                                            else
                                            {
                                                col.fKey.reference_ID = null;
                                            }
                                        }
                                    }
                                }
                            }
                            string sql_condition = null;
                            if (col.fKey.reference_ID != null)
                            {
                                sql_condition = col.Name + " = " + col.fKey.reference_ID.v.ToString();
                            }
                            else
                            {
                                sql_condition = col.Name + " is null ";
                            }

                            if (sql_conditions == null)
                            {
                                sql_conditions = sql_condition;
                            }
                            else
                            {
                                sql_conditions += " and " + sql_condition;
                            }

                            if (sql_insert_columns == null)
                            {
                                sql_insert_columns = col.Name;
                            }
                            else
                            {
                                sql_insert_columns += "," + col.Name;
                            }

                            if (col.fKey.reference_ID != null)
                            {
                                if (sql_values == null)
                                {
                                    sql_values = col.fKey.reference_ID.v.ToString();
                                }
                                else
                                {
                                    sql_values += "," + col.fKey.reference_ID.v.ToString();
                                }
                            }
                            else
                            {
                                if (sql_values == null)
                                {
                                    sql_values = "null";
                                }
                                else
                                {
                                    sql_values += ",null";
                                }
                            }
                        }
                    }
                }
            }
            sql_select += sql_conditions;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_select, null, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (iD_v == null)
                    {
                        iD_v = new ID_v();
                    }
                    iD_v.v = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    // insert
                    sql_insert += sql_insert_columns + ") Values (" + sql_values + ")";
                    long id = -1;
                    object oret = new object();
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_insert, null, ref id, ref oret, ref Err, Address_Tabel.TableName))
                    {
                        if (iD_v == null)
                        {
                            iD_v = new ID_v();
                        }
                        iD_v.v = id;
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:PostAddress:Get_Address_Tabel_ID:" + sql_insert + "\r\n" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:PostAddress:Get_Address_Tabel_ID:" + sql_select + "\r\n" + Err);
                return false;
            }
        }

        private bool GetAddressElementID(string AddressElement_TableName, string[] AddressElement_ColumnNames, object[] oValues, ref ID_v iD_v)
        {
            string Err = null;
            DataTable dt = new DataTable();
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string sql = null;
            string sql_Condtition = null;
            string sql_insert_Columns = null;
            string sql_insert_Values = null;

            if (AddressElement_ColumnNames.Length != oValues.Length)
            {
                LogFile.Error.Show("ERROR:Adress:GetAddressElementID:(AddressElement_ColumnNames.Length != oValues.Length)!");
                return false;
            }
            int i;
            string sql_pref = "select ID from " + AddressElement_TableName + " where ";
            for (i = 0; i < AddressElement_ColumnNames.Length; i++)
            {
                string sparname = "@par_" + AddressElement_TableName + "_" + AddressElement_ColumnNames[i];
                object oValue = oValues[i];
                if (oValue != null)
                {
                    SQL_Parameter par = null;
                    if (oValue is string)
                    {
                        par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Nvarchar, false, ((string)oValue));
                        lpar.Add(par);
                    }
                    else if (oValue is short)
                    {
                        par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Smallint, false, ((short)oValue));
                        lpar.Add(par);

                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:Address:GetAddressElementID:Err=type=" + oValue.GetType().ToString() + " not implemented!");
                        return false;
                    }

                    if (sql_Condtition == null)
                    {
                        sql_Condtition = " (" + AddressElement_ColumnNames[i] + " = " + sparname + ") ";
                    }
                    else
                    {
                        sql_Condtition += " and (" + AddressElement_ColumnNames[i] + " = " + sparname + ")";
                    }

                    if (sql_insert_Columns == null)
                    {
                        sql_insert_Columns = AddressElement_ColumnNames[i];
                        sql_insert_Values = sparname;
                    }
                    else
                    {
                        sql_insert_Columns += "," + AddressElement_ColumnNames[i];
                        sql_insert_Values += "," + sparname;
                    }
                }
                else
                {
                    iD_v = null;
                    return true;
                }
            }

            if (sql_Condtition != null)
            {
                if (sql_Condtition.Length > 0)
                {
                    sql = sql_pref + sql_Condtition;
                    if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            if (iD_v == null)
                            {
                                iD_v = new ID_v();
                            }
                            iD_v.v = (long)dt.Rows[0]["ID"];
                            return true;
                        }
                        else
                        {
                            // insert
                            sql = "insert into " + AddressElement_TableName + "(" + sql_insert_Columns + ") values (" + sql_insert_Values + ")";
                            long id = -1;
                            object oret = new object();
                            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref id, ref oret, ref Err, AddressElement_TableName))
                            {
                                if (iD_v == null)
                                {
                                    iD_v = new ID_v();
                                }
                                iD_v.v = id;
                                return true;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:PostAddress:GetAddressElementID:sql=" + sql + "\r\n" + Err);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:PostAddress:GetAddressElementID:" + sql + "\r\n" + Err);
                        return false;
                    }
                }
            }
            LogFile.Error.Show("ERROR:PostAddress:GetAddressElementID:sql_Condtition not defined!");
            return false;
        }

        private bool GetAddressElementID(string AddressElement_TableName, string AddressElement_ColumnName, object oValue, ref ID_v iD_v)
        {
            string Err = null;
            DataTable dt = new DataTable();
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string sql = null;
            string sparname = "@par_" + AddressElement_TableName + "_" + AddressElement_ColumnName;
            if (oValue != null)
            {
                SQL_Parameter par = null;
                if (oValue is string)
                {
                    par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Nvarchar, false, ((string)oValue));
                }
                else if (oValue is short)
                {
                    par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Smallint, false, ((short)oValue));
                }
                else
                {
                    LogFile.Error.Show("ERROR:Address:GetAddressElementID:Err=type=" + oValue.GetType().ToString() + " not implemented!");
                }

                lpar.Add(par);
                sql = "select ID from " + AddressElement_TableName + " where " + AddressElement_ColumnName + " = " + sparname;
            }
            else
            {
                iD_v = null;
                return true;
            }

            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (iD_v == null)
                    {
                        iD_v = new ID_v();
                    }
                    iD_v.v = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    // insert
                    sql = "insert into " + AddressElement_TableName + "(" + AddressElement_ColumnName + ") values (" + sparname + ")";
                    long id = -1;
                    object oret = new object();
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref id, ref oret, ref Err, AddressElement_TableName))
                    {
                        if (iD_v == null)
                        {
                            iD_v = new ID_v();
                        }
                        iD_v.v = id;
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:PostAddress:GetAddressElementID:sql=" + sql + "\r\n" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:PostAddress:GetAddressElementID:" + sql + "\r\n" + Err);
                return false;
            }
        }

    }
}
