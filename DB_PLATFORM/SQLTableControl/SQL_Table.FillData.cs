using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBConnectionControl40;
using System.Data;
using DBTypes;

namespace SQLTableControl
{
    partial class SQLTable
    {
        public int iFillTableData = 0;
        public bool Fill_SQLTable(DBConnection x_SQL_connection, Int64 ID, ref string csError)
        {
            // 1 Read row data
            String sSQL_ReadRow = "";
            switch (x_SQL_connection.DBType)
            {
                case DBConnection.eDBType.MYSQL:
                    sSQL_ReadRow = "USE " + x_SQL_connection.DataBase + ";\n"
                                          + "SELECT ";
                    break;
                case DBConnection.eDBType.MSSQL:
                    sSQL_ReadRow = "USE " + x_SQL_connection.DataBase + "\n"
                                          + "SELECT ";
                    break;

                case DBConnection.eDBType.SQLITE:
                    sSQL_ReadRow = "SELECT ";
                    break;
            }
            int i = 0;
            foreach (Column col in Column)
            {
                if (!col.IsIdentity)
                {
                    if (DBtypesFunc.IsValueDefined(col.obj))
                    {
                        if (i == 0)
                        {
                            sSQL_ReadRow += col.Name;
                        }
                        else
                        {
                            sSQL_ReadRow += "," + col.Name;
                        }
                        i++;
                    }
                    else if (col.fKey != null)
                    {
                        if (i == 0)
                        {
                            sSQL_ReadRow += col.Name;
                        }
                        else
                        {
                            sSQL_ReadRow += "," + col.Name;
                        }
                        i++;
                    }
                }
                else
                {
                    sSQL_ReadRow += col.Name;
                    i++;
                }
            }
            sSQL_ReadRow += " FROM " + TableName + " WHERE  ID = " + ID.ToString();

            DataTable dt = new DataTable(this.TableName);
            dt.TableName = this.TableName;

            if (x_SQL_connection.ReadDataTable(ref dt, sSQL_ReadRow, ref  csError))
            {
                // Now we have data in dt
                foreach (Column col in this.Column)
                {
                    if (!col.IsIdentity)
                    {
                        if (col.fKey != null)
                        {
                            if (dt.Rows.Count > 0)
                            {

                                if ((dt.Rows[0][col.Name].GetType() == typeof(int)) || (dt.Rows[0][col.Name].GetType() == typeof(Int64)))
                                {
                                    Int64 Identity = Convert.ToInt64(dt.Rows[0][col.Name]);
                                    if (col.fKey.fTable.Fill_SQLTable(x_SQL_connection, Identity, ref csError))
                                    {

                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (DBtypesFunc.IsValueDefined(col.obj))
                            {
                                DBTypes.DBtypesFunc.SetValue(ref col.obj, dt.Rows[0][col.Name], ref csError);
                            }
                        }
                    }
                    else
                    {
                        DBTypes.DBtypesFunc.SetValue(ref col.obj, dt.Rows[0][col.Name], ref csError);
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool FillDataInputControl(DBConnection x_SQL_connection, long ID, bool bSetInitialValues,ref string csError)
        {
            // 1 Read row data
            iFillTableData++;
            this.current_row_ID = new ID_v();
            this.current_row_ID.v = ID;
            String sSQL_ReadRow="";
            switch (x_SQL_connection.DBType)
            {
                case DBConnection.eDBType.MYSQL:
                sSQL_ReadRow = "USE " + x_SQL_connection.DataBase + ";\n"
                                      + "SELECT ";
                break;
                case DBConnection.eDBType.MSSQL:
                sSQL_ReadRow = "USE " + x_SQL_connection.DataBase + "\n"
                                      + "SELECT ";
                break;
                case DBConnection.eDBType.SQLITE:
                sSQL_ReadRow =  " SELECT ";
                break;
            }
            int i=0;
            foreach (Column col in Column)
            {
                if (!col.IsIdentity)
                {
                    if (i == 0)
                    {
                        sSQL_ReadRow += col.Name;
                    }
                    else
                    {
                        sSQL_ReadRow += "," + col.Name;
                    }
                    i++;
                }
            }
            sSQL_ReadRow += " FROM " + TableName + " WHERE  ID = " + ID.ToString();

            DataTable dt = new DataTable(this.TableName);
            dt.TableName = this.TableName;

            if (x_SQL_connection.ReadDataTable(ref dt, sSQL_ReadRow, ref  csError))
            {
                // Now we have data in dt
                foreach (Column col in this.Column)
                {
                    if (col.IsIdentity)
                    {
                       ID my_ID = (ID) col.obj;
                       my_ID.val = ID;
                    }
                    else
                    {
                        if (col.fKey != null)
                        {
                            if (dt.Rows.Count > 0)
                            {

                                if (dt.Rows[0][col.Name].GetType() == typeof(long))
                                {
                                    long Identity = (long)dt.Rows[0][col.Name];
                                    col.fKey.reference_ID = new ID_v();
                                    col.fKey.reference_ID.v = Identity;
                                    if (col.fKey.fTable.FillDataInputControl(x_SQL_connection, Identity,bSetInitialValues, ref csError))
                                    {
                                        if (col.fKey.fTable.myGroupBox != null)
                                        {
                                            col.fKey.fTable.myGroupBox.Changed_up = false;
                                        }
                                    }
                                    else
                                    {
                                        iFillTableData--;
                                        return false;
                                    }
                                }
                                else if (dt.Rows[0][col.Name].GetType() == typeof(System.DBNull))
                                {
                                    col.fKey.reference_ID = null;
                                    col.fKey.fTable.Hide_And_Init_Reference_ID();
                                    if (col.fKey.fTable.myGroupBox != null)
                                    {
                                        col.fKey.fTable.myGroupBox.Changed_up = false;
                                    }
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:SQLTable:FillDataInputControl:Unknown Data Column type !");
                                    iFillTableData--;
                                    return false;
                                }
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            if (col.InputControl != null)
                            {
                                object dVal = dt.Rows[0][col.Name];
                                col.SetValue(dVal);
                                if (bSetInitialValues)
                                {
                                    col.InputControl.Init_SetValue(dVal);
                                }
                                else
                                {
                                    col.InputControl.SetValue(dVal);
                                }
                                col.InputControl.Changed = false;
                            }
                        }
                    }
                }
                Show_And_Init_Reference_ID();
                iFillTableData--;
                return true;
            }
            else
            {
                iFillTableData--;
                return false;
            }
        }
    }
}
