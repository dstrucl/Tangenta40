#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
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

namespace CodeTables
{
    partial class SQLTable
    {
        public bool SQLcmd_Update(DBTableControl dbTables,ref string csError, Transaction transaction)
        {
            string sqlUpdate;
            List<SQL_Parameter> sqlParamList = new List<SQL_Parameter>();
            if (dbTables.m_con.DBType == DBConnection.eDBType.SQLITE)
            {
                foreach (Column col in this.Column)
                {
                    if (!col.IsIdentity)
                    {
                        if (col.fKey != null)
                        {
                            if (col.fKey.fTable != null)
                            {
                                if (!col.fKey.fTable.SQLcmd_Update(dbTables, ref csError, transaction))
                                {
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            if (DBtypesFunc.IsValueDefined(col.obj))
                            {
                                ID lID = null;
                                if (col.ownerTable.GetID(dbTables.m_con, col.ownerTable.TableName + "_ID", ref lID, ref csError))
                                {

                                    Column id_column = col.ownerTable.IdentityColumn();
                                    id_column.obj = lID;
                                    string sUniqueN = col.UniqueName(dbTables.items);
                                    //string sVar = "@Var_" + sUniqueN + col.Name;
                                    string sPar = DBtypesFunc.DbValueForSql(ref col.obj, col.obj.GetType().BaseType, sUniqueN, ref sqlParamList, col.Name);
                                    //string sPar = inpctrl.m_col.DbValueForSql(sUniqueN, ref sqlParamList);
                                    string sParID = DBtypesFunc.DbValueForSql(ref id_column.obj, id_column.obj.GetType().BaseType, sUniqueN, ref sqlParamList, id_column.Name);
                                    if ((col.flags & CodeTables.Column.Flags.UNIQUE) != 0)
                                    {

                                        if (col.ownerTable.pParentTable == null)
                                        {
                                            sqlUpdate = "\nSELECT ID FROM " + col.ownerTable.TableName +
                                                        "\nWHERE " + col.Name + " =  " + sPar + ";";
                                            DataTable dt = new DataTable();
                                            if (dbTables.m_con.ReadDataTable(ref dt, sqlUpdate, sqlParamList, ref csError))
                                            {
                                                if (dt.Rows.Count == 0)
                                                {
                                                    StringBuilder sbsqlUpdate = new StringBuilder("\nUPDATE " + col.ownerTable.TableName +
                                                        "\nSET " + col.Name + " = " + sPar +
                                                        "\nWHERE " + id_column.Name + " = " + sParID + ";");
                                                    ID newID = null;
                                                    if (transaction.ExecuteScalaraReturnID(dbTables.m_con,sbsqlUpdate, sqlParamList, ref newID,  ref csError, this.TableName))
                                                    {
                                                        return true;
                                                    }
                                                    else
                                                    {
                                                        return false;
                                                    }
                                                }
                                                else if (dt.Rows.Count == 1)
                                                {
                                                    //  Update parent table;
                                                    if (col.ownerTable.pParentTable != null)
                                                    {
                                                        ID newID = new ID(dt.Rows[0][0]);
                                                        string sUpdate = "\nUPDATE " + col.ownerTable.pParentTable.TableName +
                                                                            "\nSET " + col.ownerTable + "_ID = " + newID.ToString() +
                                                                            "\nWHERE ID = " + col.ownerTable.pParentTable.tag_ID.ToString() + ";";
                                                        if (transaction.ExecuteNonQuerySQL(dbTables.m_con,sUpdate, sqlParamList,  ref csError))
                                                        {
                                                        }
                                                        else
                                                        {
                                                            return false;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    csError = "Error to menu same values in Unique table : " + sqlUpdate;
                                                    return false;
                                                }
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            // parent table exist
                                            string sParentfKeyColumnName = col.ownerTable.pParentTable.GetfKeyColumnName(col.ownerTable);
                                            sqlUpdate = "\nSELECT ID FROM " + col.ownerTable.TableName +
                                                        "\nWHERE " + col.Name + " =  " + sPar + ";";
                                            DataTable dt = new DataTable();
                                            if (dbTables.m_con.ReadDataTable(ref dt, sqlUpdate, sqlParamList, ref csError))
                                            {
                                                if (dt.Rows.Count == 0)
                                                {
                                                    StringBuilder sbsqlUpdate = new StringBuilder("\nINSERT INTO " + col.ownerTable.TableName +
                                                            "\n(" +
                                                            "\n  " + col.Name +
                                                            "\n)" +
                                                            "\nVALUES" +
                                                            "\n(" +
                                                            "\n  " + sPar +
                                                            "\n);");
                                                    ID newID = null;
                                                    if (transaction.ExecuteScalaraReturnID(dbTables.m_con,sbsqlUpdate, sqlParamList, ref newID, ref csError, TableName))
                                                    {
                                                        string sVar = newID.ToString();
                                                        string sParID_Parent = newID.ToString();
                                                        string sUpdate = "\nUPDATE " + col.ownerTable.pParentTable.TableName +
                                                                            "\nSET " + sParentfKeyColumnName + " = " + sVar +
                                                                            "\nWHERE ID = " + sParID_Parent + ";";
                                                        if (transaction.ExecuteNonQuerySQL(dbTables.m_con,sUpdate, sqlParamList, ref csError))
                                                        {
                                                        }
                                                        else
                                                        {
                                                            return false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        return false;
                                                    }
                                                }
                                                else
                                                {
                                                    // value allready exist in unique table
                                                    if (dt.Rows.Count == 1)
                                                    {
                                                        long lnewID = Convert.ToInt64(dt.Rows[0][0]);
                                                        string sUpdate = "\nUPDATE " + col.ownerTable.pParentTable.TableName +
                                                                            "\nSET " + col.ownerTable.TableName + "_ID" + " = " + lnewID.ToString() +
                                                                            "\nWHERE ID = " + col.ownerTable.pParentTable.tag_ID.ToString() + ";";

                                                        if (transaction.ExecuteNonQuerySQL(dbTables.m_con,sUpdate, sqlParamList, ref csError))
                                                        {
                                                        }
                                                        else
                                                        {
                                                            return false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        csError = "Error to menu same values in Unique table : " + sqlUpdate;
                                                        return false;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                // Value allready exist
                                                return true;
                                            }
                                        }

                                    } // (col.utyp == CodeTables.UNIQUE)
                                    else
                                    { // column NOT UNIQUE
                                        string sUpdate = "\nUPDATE " + col.ownerTable.TableName +
                                                            "\nSET " + col.Name + " = " + sPar +
                                                            "\nWHERE " + id_column.Name + " = " + sParID + ";";
                                        if (transaction.ExecuteNonQuerySQL(dbTables.m_con,sUpdate, sqlParamList,ref csError))
                                        {
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                }
                                else
                                {
                                    return false;
                                }
                            } //if (DBtypesFunc.IsValueDefined(col.obj))
                        }
                    } //if (!col.IsIdentity)
                } //foreach (Column col in this.Column)
            } 
            else
            {
                // MSSQL or MYSQL
                foreach (Column col in this.Column)
                {
                    if (!col.IsIdentity)
                    {
                        if (col.fKey != null)
                        {
                            if (col.fKey.fTable != null)
                            {
                                if (!col.fKey.fTable.SQLcmd_Update(dbTables, ref csError, transaction))
                                {
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            if (DBtypesFunc.IsValueDefined(col.obj))
                            {
                                Column id_column = col.ownerTable.IdentityColumn();
                                string sUniqueN = col.UniqueName(dbTables.items);
                                string sVar = "@Var_" + sUniqueN + col.Name;
                                string sPar = DBtypesFunc.DbValueForSql(ref col.obj, col.BasicType(), sUniqueN, ref sqlParamList, col.Name);
                                //string sPar = inpctrl.m_col.DbValueForSql(sUniqueN, ref sqlParamList);
                                string sParID = DBtypesFunc.DbValueForSql(ref id_column.obj, id_column.BasicType(), sUniqueN, ref sqlParamList, id_column.Name);
                                if ((col.flags & CodeTables.Column.Flags.UNIQUE)!=0)
                                {

                                    string sParentfKeyColumnName = col.ownerTable.pParentTable.GetfKeyColumnName(col.ownerTable);
                                    if (col.ownerTable.pParentTable == null)
                                    {
                                        sqlUpdate = "\nDECLARE " + sVar + " int" +
                                                    "\nSELECT " + sVar + " = ID FROM " + col.ownerTable.TableName +
                                                    "\nWHERE " + col.Name + " =  " + sPar +
                                                    "\nIF " + sVar + "  IS NULL" +
                                                    "\n BEGIN" +
                                                        "\nUPDATE " + col.ownerTable.TableName +
                                                        "\nSET " + col.Name + " = " + sPar +
                                                        "\nWHERE " + id_column.Name + " = " + sParID +
                                                    "\n END";
                                    }
                                    else
                                    {

                                        Column id_column_Parent = col.ownerTable.pParentTable.IdentityColumn();
                                        string sUniqueN_id_column_Parent = id_column_Parent.UniqueName(dbTables.items);

                                        string sParID_Parent = DBtypesFunc.DbValueForSql(ref id_column_Parent.obj, id_column_Parent.BasicType(), sUniqueN, ref sqlParamList, id_column_Parent.Name);
                                        //string sParID_Parent = id_column_Parent.DbValueForSql(sUniqueN_id_column_Parent, ref sqlParamList);

                                        string sVarCount = sVar + "_Count";

                                        sqlUpdate = "\nDECLARE " + sVar + " int" +
                                                    "\nSELECT " + sVar + " = ID FROM " + col.ownerTable.TableName +
                                                    "\nWHERE " + col.Name + " =  " + sPar +
                                                    "\nIF " + sVar + "  IS NULL" +
                                                    "\n BEGIN" +
                                                         "\n DECLARE " + sVarCount + " int" +
                                                         "\n SELECT " + sVarCount + " = COUNT(ID) " +
                                                         "\n FROM " + col.ownerTable.pParentTable.TableName +
                                                         "\n WHERE " + sParentfKeyColumnName + " = " + sParID +
                                                         "\n IF " + sVarCount + " > 1" + // Also others are using this Columns
                                                             "\n BEGIN" +
                                                                "\nINSERT INTO " + col.ownerTable.TableName +
                                                                "\n(" +
                                                                "\n  " + col.Name +
                                                                "\n)" +
                                                                "\nVALUES" +
                                                                "\n(" +
                                                                "\n  " + sPar +
                                                                "\n) SET " + sVar + " = SCOPE_IDENTITY()" +
                                                                "\nUPDATE " + col.ownerTable.pParentTable.TableName +
                                                                "\nSET " + sParentfKeyColumnName + " = " + sVar +
                                                                "\nWHERE ID = " + sParID_Parent +
                                                            "\n END" +
                                                        "\n ELSE" + // Only one ore none is using this 
                                                            "\n BEGIN" +
                                                                "\nUPDATE " + col.ownerTable.TableName +
                                                                "\nSET " + col.Name + " = " + sPar +
                                                                "\nWHERE " + id_column.Name + " = " + sParID +
                                                            "\n END" +
                                                    "\n END" +
                                                    "\nELSE" +
                                                    "\n BEGIN" +   // Insert new value in parent table !!
                                                        "\nUPDATE " + col.ownerTable.pParentTable.TableName +
                                                        "\nSET " + sParentfKeyColumnName + " = " + sVar +
                                                        "\nWHERE ID = " + sParID_Parent +
                                                    "\n END";
                                    }

                                    string csErrorMsg = "";
                                    if (transaction.ExecuteNonQuerySQL(dbTables.m_con,sqlUpdate, sqlParamList,ref csErrorMsg))
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        Error.Show(csErrorMsg);
                                        return false;
                                    }

                                }
                                else
                                {
                                    if (id_column != null)
                                    {
                                        sqlUpdate = "\r\nUPDATE " + col.ownerTable.TableName +
                                                    "\r\nSET " + col.Name + " = " + sPar +
                                                    "\r\nWHERE " + id_column.Name + " = " + sParID;
                                    }
                                    else
                                    {
                                        Error.Show(lng.s_Error_Table_DoesNotHavePrimary_ID.s);
                                        return false;
                                    }
                                    if (transaction.ExecuteNonQuerySQL(dbTables.m_con,sqlUpdate, sqlParamList, ref csError))
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }

        internal bool GetID(DBConnection xcon,string ColumnName_ID, ref ID id, ref string csError)
        {
            while (this.pParentTable != null)
            {
                if (this.pParentTable.GetID(xcon,this.TableName + "_ID", ref id, ref csError))
                {
                    string sql = "SELECT " + this.TableName + "_ID" + " FROM " + this.pParentTable.TableName + " WHERE ID = " + id.ToString() + ";";
                    DataTable dt = new DataTable();
                    if (xcon.ReadDataTable(ref dt,sql,ref csError))
                    {
                        if (dt.Rows.Count == 1)
                        {
                            if (id == null)
                            {
                                id = new ID();
                            }
                            if (!id.Set(dt.Rows[0][0]))
                            {
                                return false;
                            }
                        }
                        else
                        {
                            csError = "Error:Result has to many rows (dt.rows.Count=" + dt.Rows.Count.ToString()+") for:" + sql + " !";
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            Column id_column = this.IdentityColumn();
            if (id_column != null)
            {
                ID top_ID = (ID)id_column.obj;
                id = top_ID;
                this.tag_ID = id;
                return true;
            }
            else
            {
                csError = "ID column not found in table:" + this.TableName + " !";
                return false;
            }
        }

        internal bool UpdateInputControls(DBTableControl dbTables,ref ID ID, ref string csError, Transaction transaction)
        {
            //string sqlUpdate ="";
            //bool bRes = true;
           

            //if (dbTables.m_con.DBType == DBConnection.eDBType.SQLITE)
            //{
                if (UpdateInputControls_SQL(dbTables, null, ref ID, ref csError, transaction))
                {
                    return true;
                }
                else
                {
                    return false;
                }

//            }
            //else
            //{
            //    List<SQL_Parameter> sqlParamList = new List<SQL_Parameter>();
            //    foreach (usrc_InputControl inpctrl in inpCtrlList)
            //    {

            //        if (inpctrl.bManualyChanged)
            //        {
            //            inpctrl.UpdateValue();
            //            Column id_column = inpctrl.m_col.ownerTable.IdentityColumn();
            //            string sUniqueN = inpctrl.m_col.UniqueName(dbTables.items);
            //            string sVar = "@Var_" + sUniqueN + inpctrl.m_col.Name;
            //            string sPar = DBtypesFunc.DbValueForSql(ref inpctrl.m_col.obj, inpctrl.m_col.BasicType(), sUniqueN, ref sqlParamList, inpctrl.m_col.Name);
            //            //string sPar = inpctrl.m_col.DbValueForSql(sUniqueN, ref sqlParamList);
            //            string sParID = DBtypesFunc.DbValueForSql(ref id_column.obj, id_column.BasicType(), sUniqueN, ref sqlParamList, id_column.Name);
            //            //string sParID = id_column.DbValueForSql(sUniqueN, ref sqlParamList);

            //            if ((inpctrl.m_col.flags & CodeTables.Column.Flags.FILTER)!=0)
            //            {

            //                if (inpctrl.m_col.ownerTable.pParentTable == null)
            //                {
            //                    sqlUpdate = "\nDECLARE " + sVar + " int" +
            //                                "\nSELECT " + sVar + " = ID FROM " + inpctrl.m_col.ownerTable.TableName +
            //                                "\nWHERE " + inpctrl.m_col.Name + " =  " + sPar +
            //                                "\nIF " + sVar + "  IS NULL" +
            //                                "\n BEGIN" +
            //                                    "\nUPDATE " + inpctrl.m_col.ownerTable.TableName +
            //                                    "\nSET " + inpctrl.m_col.Name + " = " + sPar +
            //                                    "\nWHERE " + id_column.Name + " = " + sParID +
            //                                "\n END";
            //                }
            //                else
            //                {

            //                    string sParentfKeyColumnName = inpctrl.m_col.ownerTable.pParentTable.GetfKeyColumnName(inpctrl.m_col.ownerTable);
            //                    Column id_column_Parent = inpctrl.m_col.ownerTable.pParentTable.IdentityColumn();
            //                    string sUniqueN_id_column_Parent = id_column_Parent.UniqueName(dbTables.items);

            //                    string sParID_Parent = DBtypesFunc.DbValueForSql(ref id_column_Parent.obj, id_column_Parent.BasicType(), sUniqueN, ref sqlParamList, id_column_Parent.Name);
            //                    //string sParID_Parent = id_column_Parent.DbValueForSql(sUniqueN_id_column_Parent, ref sqlParamList);

            //                    string sVarCount = sVar + "_Count";

            //                    sqlUpdate = "\nDECLARE " + sVar + " int" +
            //                                "\nSELECT " + sVar + " = ID FROM " + inpctrl.m_col.ownerTable.TableName +
            //                                "\nWHERE " + inpctrl.m_col.Name + " =  " + sPar +
            //                                "\nIF " + sVar + "  IS NULL" +
            //                                "\n BEGIN" +
            //                                     "\n DECLARE " + sVarCount + " int" +
            //                                     "\n SELECT " + sVarCount + " = COUNT(ID) " +
            //                                     "\n FROM " + inpctrl.m_col.ownerTable.pParentTable.TableName +
            //                                     "\n WHERE " + sParentfKeyColumnName + " = " + sParID +
            //                                     "\n IF " + sVarCount + " > 1" + // Also others are using this Columns
            //                                         "\n BEGIN" +
            //                                            "\nINSERT INTO " + inpctrl.m_col.ownerTable.TableName +
            //                                            "\n(" +
            //                                            "\n  " + inpctrl.m_col.Name +
            //                                            "\n)" +
            //                                            "\nVALUES" +
            //                                            "\n(" +
            //                                            "\n  " + sPar +
            //                                            "\n) SELECT " + sVar + " = IDENT_CURRENT('"+inpctrl.m_col.ownerTable.TableName+"')" +
            //                                            "\nUPDATE " + inpctrl.m_col.ownerTable.pParentTable.TableName +
            //                                            "\nSET " + sParentfKeyColumnName + " = " + sVar +
            //                                            "\nWHERE ID = " + sParID_Parent +
            //                                        "\n END" +
            //                                    "\n ELSE" + // Only one ore none is using this 
            //                                        "\n BEGIN" +
            //                                            "\nUPDATE " + inpctrl.m_col.ownerTable.TableName +
            //                                            "\nSET " + inpctrl.m_col.Name + " = " + sPar +
            //                                            "\nWHERE " + id_column.Name + " = " + sParID +
            //                                        "\n END" +
            //                                "\nEND" +
            //                                "\nELSE" +
            //                                "\n BEGIN" +   // Insert new value in parent table !!
            //                                    "\nUPDATE " + inpctrl.m_col.ownerTable.pParentTable.TableName +
            //                                    "\nSET " + sParentfKeyColumnName + " = " + sVar +
            //                                    "\nWHERE ID = " + sParID_Parent +
            //                                "\n END";
            //                }

            //                string csErrorMsg = "";
            //                object oResult = null;
            //                if (transaction.ExecuteNonQuerySQL(dbTables.m_con,sqlUpdate, sqlParamList, ref oResult, ref csErrorMsg))
            //                {
            //                    inpctrl.bManualyChanged = false;
            //                }
            //                else
            //                {
            //                    Error.Show(csErrorMsg);
            //                    bRes = false;
            //                }

            //            }
            //            else
            //            {
            //                if (id_column != null)
            //                {
            //                    sqlUpdate = "\r\nUPDATE " + inpctrl.m_col.ownerTable.TableName +
            //                                "\r\nSET " + inpctrl.m_col.Name + " = " + sPar +
            //                                "\r\nWHERE " + id_column.Name + " = " + sParID;
            //                }
            //                else
            //                {
            //                    Error.Show(lng.s_Error_Table_DoesNotHavePrimary_ID.s);
            //                    bRes = false;
            //                }

            //                string csErrorMsg = "";
            //                object oResult = null;
            //                if (transaction.ExecuteNonQuerySQL(dbTables.m_con,sqlUpdate, sqlParamList,ref oResult, ref csErrorMsg))
            //                {
            //                    inpctrl.bManualyChanged = false;
            //                }
            //                else
            //                {
            //                    Error.Show(csErrorMsg);
            //                    bRes = false;
            //                }
            //            }
            //        }
            //    }
            //}
  //          return bRes;
        }

        private bool RowReferenceFromTable_Check_NoChangeToOther_Ex(List<usrc_RowReferencedFromTable> usrc_RowReferencedFromTable_List, ID id)
        {
            ltext Instruction = null;
            if (this.myGroupBox!=null)
            {
                bool bCancelDialog = false;
                bool bRes = this.myGroupBox.SetEvent_RowReferenceFromTable_Check_NoChangeToOther(this, usrc_RowReferencedFromTable_List, id, ref bCancelDialog, ref Instruction);
                if (bCancelDialog)
                {
                    return bRes;
                }
            }
            usrc_RowReferencedFromTable_List_Dialog RowReferencedFromTable_List_Dialog = new usrc_RowReferencedFromTable_List_Dialog(usrc_RowReferencedFromTable_List, this, id, Instruction);
            DialogResult dlgRes = RowReferencedFromTable_List_Dialog.ShowDialog();
            if (dlgRes == DialogResult.No)
            {
                return true;
            }
            return false;
        }


        private bool UpdateInputControls_SQL(DBTableControl dbTables,
                                             SQLTable pParentTable,
                                             ref ID ID,
                                             ref string Err,
                                             Transaction transaction)
        {
            List<SQL_Parameter> sqlParamList = new List<SQL_Parameter>();
            if (pParentTable == null)
            {
                if (this.myGroupBox != null)
                {
                    ID id1 = this.myGroupBox.ID;
                    if (id1 != null)
                    {
                        List<usrc_RowReferencedFromTable> usrc_RowReferencedFromTable_List = null;
                        int total_count = 0;
                        if (Get_RowReferencedFromTable_List(dbTables,id1,ref usrc_RowReferencedFromTable_List,ref total_count, ref Err))
                        {
                            if (total_count > 1)
                            {
                                if (RowReferenceFromTable_Check_NoChangeToOther_Ex(usrc_RowReferencedFromTable_List, id1))
                                {
                                    ID = id1;
                                    return true;
                                }
                            }
                            // Update agreed
                            string sqlite_update ="";
                            string sqlite_set = "";
                            foreach (Column col in this.Column)
                            {
                                if (!col.IsIdentity)
                                {
                                    if (col.fKey != null)
                                    {
                                        if (col.fKey.fTable.myGroupBox.Changed_up)
                                        {
                                            if (col.fKey.IsNull)
                                            {
                                                sqlite_set = col.Name + " = null";
                                            }
                                            else
                                            {
                                                ID id = null;
                                                if (col.fKey.fTable.UpdateInputControls_SQL(dbTables, this, ref id, ref Err, transaction))
                                                {
                                                    sqlite_set = col.Name + " = " + id.ToString();
                                                }
                                                else
                                                {
                                                    return false;
                                                }
                                            }
                                            if (sqlite_update.Length == 0)
                                            {
                                                sqlite_update += " update " + this.TableName + " set \r\n" + sqlite_set;
                                            }
                                            else
                                            {
                                                sqlite_update += "," + sqlite_set + "\r\n";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (col.InputControl.Changed)
                                        {
                                            if (col.IsNull())
                                            {
                                                sqlite_set = col.Name + " = null";
                                            }
                                            else
                                            {
                                                object objret = null;
                                                SQL_Parameter.eSQL_Parameter eSQL_Parameter_TYPE = SQL_Parameter.eSQL_Parameter.Int;
                                                string parname = "";
                                                if (col.InputControl.SetColumnObject(ref objret, ref eSQL_Parameter_TYPE))
                                                {
                                                    if (objret != null)
                                                    {
                                                        parname = "@par_" + this.TableName + "_" + col.Name;
                                                        SQL_Parameter par = new SQL_Parameter(parname, eSQL_Parameter_TYPE, false, objret);
                                                        sqlParamList.Add(par);
                                                    }
                                                    else
                                                    {
                                                        LogFile.Error.Show("ERROR:UpdateInputControls_SQLite:pParentTable != null:objret == null !");
                                                        return false;
                                                    }
                                                }
                                                else
                                                {
                                                    LogFile.Error.Show("ERROR:UpdateInputControls_SQLite:pParentTable != null:col.InputControl.SetColumnObject failed!");
                                                    return false;
                                                }

                                                sqlite_set = col.Name + " = " + parname;

                                                if (!sql_check_if_not_unique_parameter(dbTables, col, sqlParamList, sqlite_set,objret, ref Err))
                                                {
                                                    return false;
                                                }

                                            }
                                            if (sqlite_update.Length == 0)
                                            {
                                                sqlite_update += " update " + this.TableName + " set \r\n" + sqlite_set;
                                            }
                                            else
                                            {
                                                sqlite_update += "," + sqlite_set + "\r\n";
                                            }

                                        }
                                    }

                                }
                            }
                            if (sqlite_update.Length > 0)
                            {
                                sqlite_update += " where ID = " + id1.ToString();
                                if (transaction.ExecuteNonQuerySQL(dbTables.m_con,sqlite_update,sqlParamList,ref Err))
                                {
                                    ID = id1;
                                    return true;
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:UpdateInputControls_SQLite:sql="+sqlite_update+"\r\nErr="+Err);
                                    return false;
                                }
                            }
                            else
                            {
                                return true;
                                //Err = "ERROR:UpdateInputControls_SQLite:(sqlite_update.Length == 0!";
                                //LogFile.Error.Show(Err);
                                //return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        Err = "ERROR:UpdateInputControls_SQLite:myGroupBox.ID_v for Table:\"" + this.TableName + "\" is null!";
                        LogFile.Error.Show(Err);
                        return false;
                    }


                }
                else
                {
                    Err = "ERROR:UpdateInputControls_SQLite:myGroupBox for table:\"" + this.TableName + "\" is null!";
                    LogFile.Error.Show(Err);
                    return false;
                }
            }
            else
            {
                if (this.myGroupBox != null)
                {
                    ID id1 = this.myGroupBox.ID;
                    if (id1 != null)
                    {
                        List<usrc_RowReferencedFromTable> usrc_RowReferencedFromTable_List = null;
                        int total_count = 0;
                        if (Get_RowReferencedFromTable_List(dbTables, id1, ref usrc_RowReferencedFromTable_List, ref total_count, ref Err))
                        {
                            if (total_count > 1)
                            {
                                if (RowReferenceFromTable_Check_NoChangeToOther_Ex(usrc_RowReferencedFromTable_List, id1))
                                {
                                    ID id2 = null;
                                    if (Insert_SQL_Get_Select_ID(ref id2, dbTables, -1, transaction))
                                    {
                                        if (id2 != null)
                                        {
                                            ID = id2;
                                            return true;
                                        }
                                        else
                                        {
                                            if (Insert_SQL(ref ID, dbTables, -1, transaction))
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                Err = "ERROR:UpdateInputControls_SQLite:Insert_SQLite(ref ID, dbTables, -1) for table :\"" + this.TableName + "\" is null!";
                                                return false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Err = "ERROR:UpdateInputControls_SQLite:Insert_SQLite_Get_Select_ID(ref id_v2, dbTables, -1) for table :\"" + this.TableName + "\" is null!";
                                        return false;
                                    }
                                }
                            }
                            // Update agreed
                            string sqlite_update = "";
                            string sqlite_set = "";
                            foreach (Column col in this.Column)
                            {
                                if (!col.IsIdentity)
                                {
                                    if (col.fKey != null)
                                    {
                                        if (col.fKey.fTable.myGroupBox.Changed_up)
                                        {
                                            if (col.fKey.IsNull)
                                            {
                                                sqlite_set = col.Name + " = null";
                                            }
                                            else
                                            {
                                                ID id = null;
                                                if (col.fKey.fTable.UpdateInputControls_SQL(dbTables, this, ref id, ref Err, transaction))
                                                {
                                                    sqlite_set = col.Name + " = " + id.ToString();
                                                }
                                                else
                                                {
                                                    return false;
                                                }
                                            }
                                            if (sqlite_update.Length == 0)
                                            {
                                                sqlite_update += " update " + this.TableName + " set \r\n" + sqlite_set;
                                            }
                                            else
                                            {
                                                sqlite_update += "," + sqlite_set + "\r\n";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (col.InputControl.Changed)
                                        {
                                            if (col.IsNull())
                                            {
                                                sqlite_set = col.Name + " = null";
                                            }
                                            else
                                            {
                                                object objret = null;
                                                SQL_Parameter.eSQL_Parameter eSQL_Parameter_TYPE = SQL_Parameter.eSQL_Parameter.Int;
                                                string parname = "";
                                                if (col.InputControl.SetColumnObject(ref objret, ref eSQL_Parameter_TYPE))
                                                {
                                                    if (objret != null)
                                                    {
                                                        parname = "@par_" + this.TableName + "_" + col.Name;
                                                        SQL_Parameter par = new SQL_Parameter(parname, eSQL_Parameter_TYPE, false, objret);
                                                        sqlParamList.Add(par);
                                                    }
                                                    else
                                                    {
                                                        LogFile.Error.Show("ERROR:UpdateInputControls_SQLite:pParentTable != null:objret == null !");
                                                        return false;
                                                    }
                                                }
                                                else
                                                {
                                                    LogFile.Error.Show("ERROR:UpdateInputControls_SQLite:pParentTable != null:col.InputControl.SetColumnObject failed!");
                                                    return false;
                                                }

                                                sqlite_set = col.Name + " = " + parname;

                                                if (!sql_check_if_not_unique_parameter(dbTables, col,sqlParamList, sqlite_set,objret, ref Err))
                                                {
                                                    return false;
                                                }

                                            }
                                            if (sqlite_update.Length == 0)
                                            {
                                                sqlite_update += " update " + this.TableName + " set \r\n" + sqlite_set;
                                            }
                                            else
                                            {
                                                sqlite_update += "," + sqlite_set + "\r\n";
                                            }

                                        }
                                    }

                                }
                            }
                            if (sqlite_update.Length > 0)
                            {
                                sqlite_update += " where ID = " + id1.ToString();
                                if (transaction.ExecuteNonQuerySQL(dbTables.m_con,sqlite_update, sqlParamList, ref Err))
                                {
                                    ID = id1;
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                // nothing to update
                                ID = id1;
                                return true; 
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        ID id2 = null;
                        if (Insert_SQL_Get_ID(ref id2, dbTables, -1, transaction))
                        {
                            ID = id2;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    Err = "ERROR:UpdateInputControls_SQLite:pParentTable != null:myGroupBox for table:\"" + this.TableName + "\" is null!";
                    return false;
                }
            }
        }

        private bool sql_check_if_not_unique_parameter(DBTableControl dbTables, CodeTables.Column col, List<SQL_Parameter> sqlParamList, string sqlite_set, object value, ref string Err)
        {
            if ((col.flags & CodeTables.Column.Flags.UNIQUE) != 0)
            {
                // check if not unique parameter
                DataTable dt = new DataTable();
                string sql_check = "select ID," + col.Name + " from " + this.TableName + " where " + sqlite_set;
                if (dbTables.m_con.ReadDataTable(ref dt, sql_check, sqlParamList, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        bool bHandled = false;
                        if (this.myGroupBox != null)
                        {
                            this.myGroupBox.Unique_parameter_exist_Dialog_EventTrigger(this, col, dt, value,ref bHandled);
                        }
                        if (!bHandled)
                        {
                            //string sText=null;
                            string sValue = GetString(value);
                            if (sValue!=null)
                            {
                                MessageBox.Show(lng.s_Data_in_Column.s + ":" + col.Name_in_language.s + " (" + col.Name + ") " + lng.s_In_Table.s + " " + this.lngTableName.s + " (" + this.TableName + ") " + lng.s_MustBeUnique.s + ".\r\n" + lng.s_Value.s + ":" + sValue + " " + lng.s_AllreadyExistForTable.s + " " +this.lngTableName.s + " (" + this.TableName + ") ");
                            }
                            else
                            {
                                MessageBox.Show(lng.s_Data_in_Column.s + ":" + col.Name_in_language.s + " (" + col.Name + ") " + " " + lng.s_In_Table.s +" " + this.lngTableName.s + " (" + this.TableName + ") " + lng.s_MustBeUnique.s);
                            }
                        }
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:SQLTable.Update.cs:sql_check_if_not_unique_parameter:sql=" + sql_check + "\r\nErr=" + Err);
                    return false;
                }
            }
            return true;
        }

        private string GetString(object value)
        {
            string s = null;
            try
            {
                s = Convert.ToString(value);
            }
            catch 
            {

            }
            return s;
        }


        //private bool Get_RowReferencedFromTable_List(DBTableControl dbTables,long id,ref List<usrc_RowReferencedFromTable> usrc_RowReferencedFromTable_List,ref int total_count, ref string Err)
        //{
        //    total_count = 0;
        //    foreach (SQLTable x_tbl in dbTables.items)
        //    {
        //        SQLTable tbl = new SQLTable(x_tbl);
        //        tbl.CreateTableTree(dbTables.items);
        //        if (tbl.Column != null)
        //        {
        //            foreach (Column col in tbl.Column)
        //            {
        //                if (col.fKey != null)
        //                {
        //                    if (col.fKey.fTable != null)
        //                    {
        //                        if (col.fKey.fTable.TableName.Equals(this.TableName))
        //                        {
        //                            DataTable dt = new DataTable();
        //                            string sql_select = "select * from " + tbl.TableName + " where " + col.Name + " = " + id.ToString();
        //                            if (dbTables.m_con.ReadDataTable(ref dt, sql_select, ref Err))
        //                            {
        //                                if (dt.Rows.Count > 0)
        //                                {
        //                                    total_count += dt.Rows.Count;
        //                                    usrc_RowReferencedFromTable x_usrc_RowReferencedFromTable = new usrc_RowReferencedFromTable();
        //                                    x_usrc_RowReferencedFromTable.Init(tbl, col.fKey.fTable, id, dt);
        //                                    if (usrc_RowReferencedFromTable_List == null)
        //                                    {
        //                                        usrc_RowReferencedFromTable_List = new List<usrc_RowReferencedFromTable>();
        //                                    }
        //                                    usrc_RowReferencedFromTable_List.Add(x_usrc_RowReferencedFromTable);
        //                                }
        //                            }
        //                            else
        //                            {
        //                                LogFile.Error.Show("ERROR:SQLTable.Update.cs:SQLTable:Get_RowReferencedFromTable_List:sql_select=" + sql_select + "\r\nErr=" + Err);
        //                                return false;
        //                            }

        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            LogFile.Error.Show("ERROR:SQLTable.Update.cs:SQLTable:Get_RowReferencedFromTable_List:Table " + tbl.TableName + " has no columns defined !");
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        private bool Get_RowReferencedFromTable_List(DBTableControl dbTables,ID id, ref List<usrc_RowReferencedFromTable> usrc_RowReferencedFromTable_List, ref int total_count, ref string Err)
        {
            ReferencesToTable reftt = dbTables.GetReferencesToTable(this);
            if (reftt != null)
            {
                if (reftt.Count > 0)
                {
                    foreach (ReferenceFromTable rtf in  reftt.Items)
                    {
                        total_count = 0;
                        DataTable dt = new DataTable();
                        string sql_select = "select * from " + rtf.TableName + " where " + rtf.ColumnName + " = " + id.ToString();
                        if (dbTables.m_con.ReadDataTable(ref dt, sql_select, ref Err))
                        {
                            if (dt.Rows.Count > 0)
                            {
                                total_count += dt.Rows.Count;
                                usrc_RowReferencedFromTable x_usrc_RowReferencedFromTable = new usrc_RowReferencedFromTable();
                                x_usrc_RowReferencedFromTable.Init(rtf.Table, this, id, dt);
                                if (usrc_RowReferencedFromTable_List == null)
                                {
                                    usrc_RowReferencedFromTable_List = new List<usrc_RowReferencedFromTable>();
                                }
                                usrc_RowReferencedFromTable_List.Add(x_usrc_RowReferencedFromTable);
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:SQLTable.Update.cs:SQLTable:Get_RowReferencedFromTable_List:sql_select=" + sql_select + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:SQLTable.Update.cs:SQLTable:Get_RowReferencedFromTable_List:ReferencesToTable==null!");
                return false;
            }

            return true;
        }


        private string GetfKeyColumnName(SQLTable fTable)
        {
            foreach (Column col in Column)
            {
                if (col.fKey != null)
                {
                    if (col.fKey.fTable != null)
                    {
                        if (col.fKey.fTable.TableName.Equals(fTable.TableName))
                        {
                            return col.Name;
                        }
                    }
                    else if (col.fKey.refInListOfTables != null)
                    {
                        if (col.fKey.refInListOfTables.TableName.Equals(fTable.TableName))
                        {
                            return col.Name;
                        }
                    }
                    else
                    {
                        Error.Show("ERROR: No fTable of refTable in col.fKey != null!)");
                        return null;
                    }
                }
            }
            return null;
        }
    }
}

