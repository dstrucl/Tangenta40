using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBConnectionControl40;
using System.Data;
using System.Windows.Forms;
using LanguageControl;
using LogFile;
using DBTypes;

namespace SQLTableControl
{
    partial class SQLTable
    {
        public bool SQLcmd_DeleteRows(DBTableControl dbTables, ref string csError)
        {
            MessageBox.Show("ERROR : Not implemented yet public bool SQLcmd_DeleteRows(DBTableControl dbTables, ref string csError)");
            //string sqlUpdate;
            //List<SQL_Parameter> sqlParamList = new List<SQL_Parameter>();
            //if (dbTables.m_con.DBType == DBConnection.eDBType.SQLITE)
            //{
            //    foreach (Column col in this.Column)
            //    {
            //        if (!col.IsIdentity)
            //        {
            //            if (col.fKey != null)
            //            {
            //                if (col.fKey.fTable != null)
            //                {
            //                    if (!col.fKey.fTable.SQLcmd_DeleteRows(dbTables, ref csError))
            //                    {
            //                        return false;
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                if (DBtypesFunc.IsValueDefined(col.obj))
            //                {
            //                    long lID = -1;
            //                    if (col.ownerTable.GetID(dbTables.m_con, col.ownerTable.TableName + "_ID", ref lID, ref csError))
            //                    {

            //                        Column id_column = col.ownerTable.IdentityColumn();

            //                        string sUniqueN = col.UniqueName(dbTables.items);
            //                        //string sVar = "@Var_" + sUniqueN + col.Name;
            //                        string sPar = DBtypesFunc.DbValueForSql(ref col.obj, col.obj.GetType().BaseType, sUniqueN, ref sqlParamList, col.Name);
            //                        //string sPar = inpctrl.m_col.DbValueForSql(sUniqueN, ref sqlParamList);
            //                        string sParID = DBtypesFunc.DbValueForSql(ref id_column.obj, id_column.obj.GetType().BaseType, sUniqueN, ref sqlParamList, id_column.Name);
            //                        if ((col.flags & SQLTableControl.Column.Flags.FILTER) != 0)
            //                        {

            //                            if (col.ownerTable.pParentTable == null)
            //                            {
            //                                sqlUpdate = "\nSELECT ID FROM " + col.ownerTable.TableName +
            //                                            "\nWHERE " + col.Name + " =  " + sPar + ";";
            //                                DataTable dt = new DataTable();
            //                                if (dbTables.m_con.ReadDataTable(ref dt, sqlUpdate, sqlParamList, ref csError, " Select Uniqueue values in SQLcmd_Update"))
            //                                {
            //                                    if (dt.Rows.Count == 0)
            //                                    {
            //                                        StringBuilder sbsqlUpdate = new StringBuilder("\nUPDATE " + col.ownerTable.TableName +
            //                                            "\nSET " + col.Name + " = " + sPar +
            //                                            "\nWHERE " + id_column.Name + " = " + sParID + ";");
            //                                        int newID = -1;
            //                                        object objRet = new object();
            //                                        if (dbTables.m_con.ExecuteQuerySQL(sbsqlUpdate, sqlParamList, ref newID, ref objRet, ref csError, " Select Uniqueue values in SQLcmd_Update", this.TableName))
            //                                        {
            //                                            return true;
            //                                        }
            //                                        else
            //                                        {
            //                                            return false;
            //                                        }
            //                                    }
            //                                    else if (dt.Rows.Count == 1)
            //                                    {
            //                                        //  Update parent table;
            //                                        long newID = Convert.ToInt64(dt.Rows[0][0]);
            //                                        string sUpdate = "\nUPDATE " + col.ownerTable.pParentTable.TableName +
            //                                                            "\nSET " + col.ownerTable + "_ID = " + newID.ToString() +
            //                                                            "\nWHERE ID = " + col.ownerTable.pParentTable.tag_ID.ToString() + ";";

            //                                        if (dbTables.m_con.ExecuteNonQuerySQL(sUpdate, sqlParamList, ref csError, " Select Uniqueue values in SQLcmd_Update"))
            //                                        {
            //                                        }
            //                                        else
            //                                        {
            //                                            return false;
            //                                        }
            //                                    }
            //                                    else
            //                                    {
            //                                        csError = "Error to menu same values in Unique table : " + sqlUpdate;
            //                                        return false;
            //                                    }
            //                                }
            //                                else
            //                                {
            //                                    return false;
            //                                }
            //                            }
            //                            else
            //                            {
            //                                // parent table exist
            //                                string sParentfKeyColumnName = col.ownerTable.pParentTable.GetfKeyColumnName(col.ownerTable);
            //                                sqlUpdate = "\nSELECT ID FROM " + col.ownerTable.TableName +
            //                                            "\nWHERE " + col.Name + " =  " + sPar + ";";
            //                                DataTable dt = new DataTable();
            //                                if (dbTables.m_con.ReadDataTable(ref dt, sqlUpdate, sqlParamList, ref csError, " Select Uniqueue values in SQLcmd_Update"))
            //                                {
            //                                    if (dt.Rows.Count == 0)
            //                                    {
            //                                        StringBuilder sbsqlUpdate = new StringBuilder("\nINSERT INTO " + col.ownerTable.TableName +
            //                                                "\n(" +
            //                                                "\n  " + col.Name +
            //                                                "\n)" +
            //                                                "\nVALUES" +
            //                                                "\n(" +
            //                                                "\n  " + sPar +
            //                                                "\n);");
            //                                        int newID = -1;
            //                                        object objRet = new object();
            //                                        if (dbTables.m_con.ExecuteQuerySQL(sbsqlUpdate, sqlParamList, ref newID, ref objRet, ref csError, " Select Uniqueue values in SQLcmd_Update", TableName))
            //                                        {
            //                                            string sVar = newID.ToString();
            //                                            string sParID_Parent = newID.ToString();
            //                                            string sUpdate = "\nUPDATE " + col.ownerTable.pParentTable.TableName +
            //                                                                "\nSET " + sParentfKeyColumnName + " = " + sVar +
            //                                                                "\nWHERE ID = " + sParID_Parent + ";";

            //                                            if (dbTables.m_con.ExecuteNonQuerySQL(sUpdate, sqlParamList, ref csError, " Select Uniqueue values in SQLcmd_Update"))
            //                                            {
            //                                            }
            //                                            else
            //                                            {
            //                                                return false;
            //                                            }
            //                                        }
            //                                        else
            //                                        {
            //                                            return false;
            //                                        }
            //                                    }
            //                                    else
            //                                    {
            //                                        // value allready exist in unique table
            //                                        if (dt.Rows.Count == 1)
            //                                        {
            //                                            long lnewID = Convert.ToInt64(dt.Rows[0][0]);
            //                                            string sUpdate = "\nUPDATE " + col.ownerTable.pParentTable.TableName +
            //                                                                "\nSET " + col.ownerTable.TableName + "_ID" + " = " + lnewID.ToString() +
            //                                                                "\nWHERE ID = " + col.ownerTable.tag_ID.ToString() + ";";

            //                                            if (dbTables.m_con.ExecuteNonQuerySQL(sUpdate, sqlParamList, ref csError, " Select Uniqueue values in SQLcmd_Update"))
            //                                            {
            //                                            }
            //                                            else
            //                                            {
            //                                                return false;
            //                                            }
            //                                        }
            //                                        else
            //                                        {
            //                                            csError = "Error to menu same values in Unique table : " + sqlUpdate;
            //                                            return false;
            //                                        }
            //                                    }
            //                                }
            //                                else
            //                                {
            //                                    // Value allready exist
            //                                    return true;
            //                                }
            //                            }

            //                        } // (col.utyp == SQLTableControl.UNIQUE)
            //                        else
            //                        { // column NOT UNIQUE
            //                            string sUpdate = "\nUPDATE " + col.ownerTable.TableName +
            //                                                "\nSET " + col.Name + " = " + sPar +
            //                                                "\nWHERE " + id_column.Name + " = " + sParID + ";";

            //                            if (dbTables.m_con.ExecuteNonQuerySQL(sUpdate, sqlParamList, ref csError, " Select Uniqueue values in SQLcmd_Update"))
            //                            {
            //                            }
            //                            else
            //                            {
            //                                return false;
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        return false;
            //                    }
            //                } //if (DBtypesFunc.IsValueDefined(col.obj))
            //            }
            //        } //if (!col.IsIdentity)
            //    } //foreach (Column col in this.Column)
            //}
            //else
            //{
            //    // MSSQL or MYSQL
            //    foreach (Column col in this.Column)
            //    {
            //        if (!col.IsIdentity)
            //        {
            //            if (col.fKey != null)
            //            {
            //                if (col.fKey.fTable != null)
            //                {
            //                    if (!col.fKey.fTable.SQLcmd_Update(dbTables, ref csError))
            //                    {
            //                        return false;
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                if (DBtypesFunc.IsValueDefined(col.obj))
            //                {
            //                    Column id_column = col.ownerTable.IdentityColumn();
            //                    string sUniqueN = col.UniqueName(dbTables.items);
            //                    string sVar = "@Var_" + sUniqueN + col.Name;
            //                    string sPar = DBtypesFunc.DbValueForSql(ref col.obj, col.GetType(), sUniqueN, ref sqlParamList, col.Name);
            //                    //string sPar = inpctrl.m_col.DbValueForSql(sUniqueN, ref sqlParamList);
            //                    string sParID = DBtypesFunc.DbValueForSql(ref id_column.obj, id_column.GetType(), sUniqueN, ref sqlParamList, id_column.Name);
            //                    if ((col.flags & SQLTableControl.Column.Flags.FILTER) != 0)
            //                    {

            //                        string sParentfKeyColumnName = col.ownerTable.pParentTable.GetfKeyColumnName(col.ownerTable);
            //                        if (col.ownerTable.pParentTable == null)
            //                        {
            //                            sqlUpdate = "\nDECLARE " + sVar + " int" +
            //                                        "\nSELECT " + sVar + " = ID FROM " + col.ownerTable.TableName +
            //                                        "\nWHERE " + col.Name + " =  " + sPar +
            //                                        "\nIF " + sVar + "  IS NULL" +
            //                                        "\n BEGIN" +
            //                                            "\nUPDATE " + col.ownerTable.TableName +
            //                                            "\nSET " + col.Name + " = " + sPar +
            //                                            "\nWHERE " + id_column.Name + " = " + sParID +
            //                                        "\n END";
            //                        }
            //                        else
            //                        {

            //                            Column id_column_Parent = col.ownerTable.pParentTable.IdentityColumn();
            //                            string sUniqueN_id_column_Parent = id_column_Parent.UniqueName(dbTables.items);

            //                            string sParID_Parent = DBtypesFunc.DbValueForSql(ref id_column_Parent.obj, id_column_Parent.GetType(), sUniqueN, ref sqlParamList, id_column_Parent.Name);
            //                            //string sParID_Parent = id_column_Parent.DbValueForSql(sUniqueN_id_column_Parent, ref sqlParamList);

            //                            string sVarCount = sVar + "_Count";

            //                            sqlUpdate = "\nDECLARE " + sVar + " int" +
            //                                        "\nSELECT " + sVar + " = ID FROM " + col.ownerTable.TableName +
            //                                        "\nWHERE " + col.Name + " =  " + sPar +
            //                                        "\nIF " + sVar + "  IS NULL" +
            //                                        "\n BEGIN" +
            //                                             "\n DECLARE " + sVarCount + " int" +
            //                                             "\n SELECT " + sVarCount + " = COUNT(ID) " +
            //                                             "\n FROM " + col.ownerTable.pParentTable.TableName +
            //                                             "\n WHERE " + sParentfKeyColumnName + " = " + sParID +
            //                                             "\n IF " + sVarCount + " > 1" + // Also others are using this Columns
            //                                                 "\n BEGIN" +
            //                                                    "\nINSERT INTO " + col.ownerTable.TableName +
            //                                                    "\n(" +
            //                                                    "\n  " + col.Name +
            //                                                    "\n)" +
            //                                                    "\nVALUES" +
            //                                                    "\n(" +
            //                                                    "\n  " + sPar +
            //                                                    "\n) SET " + sVar + " = @@IDENTITY" +
            //                                                    "\nUPDATE " + col.ownerTable.pParentTable.TableName +
            //                                                    "\nSET " + sParentfKeyColumnName + " = " + sVar +
            //                                                    "\nWHERE ID = " + sParID_Parent +
            //                                                "\n END" +
            //                                            "\n ELSE" + // Only one ore none is using this 
            //                                                "\n BEGIN" +
            //                                                    "\nUPDATE " + col.ownerTable.TableName +
            //                                                    "\nSET " + col.Name + " = " + sPar +
            //                                                    "\nWHERE " + id_column.Name + " = " + sParID +
            //                                                "\n END" +
            //                                        "\n END" +
            //                                        "\nELSE" +
            //                                        "\n BEGIN" +   // Insert new value in parent table !!
            //                                            "\nUPDATE " + col.ownerTable.pParentTable.TableName +
            //                                            "\nSET " + sParentfKeyColumnName + " = " + sVar +
            //                                            "\nWHERE ID = " + sParID_Parent +
            //                                        "\n END";
            //                        }

            //                        string csErrorMsg = "";
            //                        if (dbTables.m_con.ExecuteNonQuerySQL(sqlUpdate, sqlParamList, ref csErrorMsg, "Update inputcontrol"))
            //                        {
            //                            return true;
            //                        }
            //                        else
            //                        {
            //                            Error.Show(csErrorMsg);
            //                            return false;
            //                        }

            //                    }
            //                    else
            //                    {
            //                        if (id_column != null)
            //                        {
            //                            sqlUpdate = "\r\nUPDATE " + col.ownerTable.TableName +
            //                                        "\r\nSET " + col.Name + " = " + sPar +
            //                                        "\r\nWHERE " + id_column.Name + " = " + sParID;
            //                        }
            //                        else
            //                        {
            //                            Error.Show(lngRPM.s_Error_Table_DoesNotHavePrimary_ID.s);
            //                            return false;
            //                        }

            //                        if (dbTables.m_con.ExecuteNonQuerySQL(sqlUpdate, sqlParamList, ref csError, "Update inputcontrol"))
            //                        {
            //                            return true;
            //                        }
            //                        else
            //                        {
            //                            return false;
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            return true;
        }
    }
}
