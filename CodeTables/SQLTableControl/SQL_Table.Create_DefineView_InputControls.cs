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
using System.Reflection;
using DBTypes;
using System.Drawing;
using System.IO;
using UniqueControlNames;

namespace CodeTables
{
    partial class SQLTable
    {

        public delegate void delegate_FillTable(SQLTable tbl);
        public delegate void delegate_mySetInputControlProperties(Column col, object obj);

        // function creates DefineView_InputControls but does not bind them with xml data !
        public void Create_DefineView_InputControls(SQLTable pPrevTable, string sParentKeys, ref List<DefineView_InputControl> inpCtrlList, Object pParentWindow, Form pForm,ref int iCtrl)
        {
            int iCol = 0;
            int iCount = Column.Count();
            this.pParentTable = pPrevTable;

            for (iCol = 0; iCol < iCount; iCol++)
            {
                Column col = Column[iCol];
                if (!col.IsIdentity)
                {
                    if (col.fKey != null)
                    {
                        string sKey;
                        
                        sKey = sParentKeys + "*" + col.fKey.refInListOfTables.TableName + ">";
                        col.fKey.fTable.Create_DefineView_InputControls(this, sKey, ref inpCtrlList, this.DefineView_GroupBox, pForm, ref iCtrl);
                    }
                    else
                    {
                        string sImportExportLine;
                        
                        DefineView_InputControl inpCtrl;
                        sImportExportLine = sParentKeys + col.Name;
                        inpCtrl = new DefineView_InputControl(col, inpCtrlList, sImportExportLine, true, ref iCtrl);
                        col.DefineView_InputControl = inpCtrl;
                        inpCtrlList.Add(inpCtrl);
                    }
                }
            }
        }

        

        internal DefineView_InputControl GetDefineView_InputControl(string FullName)
        {
            foreach (DefineView_InputControl dvinpctrl in this.DefineView_inpCtrlList)
            {
                if (dvinpctrl.FullName.Equals(FullName))
                {
                    return dvinpctrl;
                }
            }
            return null;
        }

        internal bool GetTableView(DBConnection sQL_Connection, ViewXml m_ViewXml, ref DataTable dt, ref string csError)
        {
            bool bRet = true;
            String SqlCmd = m_ViewXml.SQLView;

            dt.TableName = TableName;

            if (sQL_Connection.ReadDataTable(ref dt, SqlCmd, ref  csError))
            {
                bRet= true;
            }
            else
            {
                bRet = false;
            }
            return bRet;


        }

        public void AddMutualExclusionCheck(object p, object p_2)
        {
            //throw new NotImplementedException();
        }

        internal string GetFirstViewName()
        {
            return lng.s_View.s + lngTableName.s + "1";
        }

        internal void ClearFilterDataOf_DefineView_InputControl()
        {
            foreach (DefineView_InputControl dvinpctrl in DefineView_inpCtrlList)
            {
                dvinpctrl.bUseSqlFilter = false;
                dvinpctrl.SQLFilter = "";
                if (dvinpctrl.m_txtSQLFilter != null)
                {
                    dvinpctrl.m_txtSQLFilter.Text = "";
                }
                if (dvinpctrl.m_chkUseFiler != null)
                {
                    dvinpctrl.m_chkUseFiler.Checked = false;
                }
            }
        }

        public bool SetAsFirstColumn(string ColumnName)
        {
            int iCount = Column.Count;
            int i = 0;
            for(i=0;i<iCount;i++)
            {
                if (Column[i].Name.Equals(ColumnName))
                {
                    var item = Column[i];
                    Column.RemoveAt(i);
                    Column.Insert(0, item);
                    return true;
                }
            }
            return false;
        }

        public bool SetAsLastColumn(string ColumnName)
        {
            int iCount = Column.Count;
            int i = 0;
            for (i = 0; i < iCount; i++)
            {
                if (Column[i].Name.Equals(ColumnName))
                {
                    var item = Column[i];
                    Column.RemoveAt(i);
                    Column.Add(item);
                    return true;
                }
            }
            return false;
        }

        public bool SetColumnStyle(string ColumnName, CodeTables.Column.eStyle style)
        {
            foreach(Column col in Column)
            {
                if (col.Name.Equals(ColumnName))
                {
                    col.Style = style;
                    return true;
                }
            }
            return false;
        }

        private Column IdentityColumn()
        {
            foreach (Column col in Column)
            {
                if (col.IsIdentity)
                {
                    return col;
                }
            }
            return null;
        }

        private string IdentityName()
        {
            foreach (Column col in Column)
            {
                if (col.IsIdentity)
                {
                    return col.Name;
                }
            }
            return "";
        }

        internal void ClearInputControls()
        {
            if (myGroupBox != null)
            {
                myGroupBox.Dispose();
                myGroupBox = null;
            }
        }

        internal bool IsMyChildTable(out SQLTable OutTbl, Type type)
        {

            foreach (Column col in Column)
            {
                if (col.fKey!=null)
                {
                    if (col.fKey.fTable != null)
                    {
                        if (type == col.fKey.fTable.objTable.GetType())
                        {
                            OutTbl = col.fKey.fTable;
                            return true;
                        }
                    }
                }
            }
            OutTbl = null;
            return false;
        }

        internal object FindIdentityObject()
        {
            foreach (Column col in Column)
            {
                if (col.IsIdentity)
                {
                    return col.obj;
                }
            }
            return null;
        }

        public void Define_TREE(List<SQLTable> lTable)
        {
            SQLTable sqlTbl;
            SQLTable rfTable;
            if (TableName.Equals("evl_Picture_Person"))
            {
                MessageBox.Show("STOP");
            }

            foreach (Column col in Column)
            {
                if (col.fKey != null)
                {
                    if (
                        (col.fKey.fTable.objTable.GetType() == typeof(DBm_Image)) ||
                        (col.fKey.fTable.objTable.GetType() == typeof(DBm_SImage)) ||
                        (col.fKey.fTable.objTable.GetType() == typeof(DBm_Document))
                        )
                    {
                        // create new DBm_Image class
                        if (Globals.FindTable(out rfTable, col.fKey.refInListOfTables.TableName, lTable))
                        {
                            sqlTbl = new SQLTable(rfTable, this, lTable);
                            lTable.Add(sqlTbl);
                            col.fKey.fTable = sqlTbl;
                            foreach (ForeignKey fk in m_Fkey)
                            {
                                if (fk.refInListOfTables.TableName.Equals(col.fKey.refInListOfTables.TableName))
                                {
                                    fk.fTable = sqlTbl;
                                }
                            }
                        }
                    }
                }
            }
        }

        internal usrc_InputControl GetInputControl(Type type)
        {
            foreach (Column col in Column)
            {
                if (col.fKey != null)
                {
                    usrc_InputControl inpCtrl = col.fKey.fTable.GetInputControl(type);
                    if (inpCtrl != null)
                    {
                        return inpCtrl;
                    }
                }
                else if (col.obj.GetType() == type)
                {
                    return col.InputControl;
                }
            }
            return null;
        }

        internal void ClearInputControls_bManualyChanged()
        {
            foreach (usrc_InputControl inpctrl in inpCtrlList)
            {
                inpctrl.bManualyChanged = false;
            }
        }



        public string DBm_Image_Insert(string jpgFile, string Image_Name, string Image_Author, string Image_Capture_Location,List<SQL_Parameter> lsqlPar,List<DBm_col_name_and_param> lPar_DBm_col_name_and_param, ref string Par_DBm_ID, ref string csError)
        {
            if (this.objTable.GetType() == typeof(DBm_Image))
            {
                if (this.pParentTable != null)
                {

                    string sql_DBm_Image_Insert = "";

                    string RootTableName = this.pParentTable.TableName;

                    Image img = new Bitmap(jpgFile);


                    string hash = DBtypesFunc.GetHash_SHA1(DBtypesFunc.imageToByteArray(img));

                    string Image_FileName = Path.GetFileNameWithoutExtension(jpgFile);
                    string Image_Ext = Path.GetExtension(jpgFile);
                    string Image_Folder = Path.GetDirectoryName(jpgFile);
                    string ComputerName = SystemInformation.ComputerName;
                    string ComputerUserName = SystemInformation.UserDomainName + "\\" + SystemInformation.UserName;
                    // Create new FileInfo object and get the Length.
                    FileInfo f = new FileInfo(jpgFile);
                    DateTime CaptureTime = File.GetCreationTime(jpgFile);
                    long Image_Size = f.Length;
                    int img_width = img.PhysicalDimension.ToSize().Width;
                    int img_height = img.PhysicalDimension.ToSize().Height;


                    foreach (Column col in Column)
                    {
                        if (col.IsIdentity)
                        {

                        }
                        else 
                        {
                            if (col.fKey != null)
                            {
                                Type type = col.obj.GetType();
                                if (type == typeof(DBm_Image_Name))
                                {
                                    sql_DBm_Image_Insert += DBtypesFunc.DBm_sql_Insert_fkey_column(RootTableName, type, typeof(Image_Name),Image_Name, lsqlPar,  System.Data.SqlDbType.BigInt,false,-1, lPar_DBm_col_name_and_param );
                                }
                                else if (col.obj.GetType() == typeof(DBm_Image_Author))
                                {
                                    sql_DBm_Image_Insert += DBtypesFunc.DBm_sql_Insert_fkey_column(RootTableName, type, typeof(Image_Author),Image_Author, lsqlPar,  System.Data.SqlDbType.NVarChar, false, -1,lPar_DBm_col_name_and_param);
                                }
                                else if (col.obj.GetType() == typeof(DBm_Image_CaptureLocation))
                                {
                                    sql_DBm_Image_Insert += DBtypesFunc.DBm_sql_Insert_fkey_column(RootTableName, type, typeof(Image_CaptureLocation),Image_Capture_Location, lsqlPar, System.Data.SqlDbType.NVarChar, false, -1,lPar_DBm_col_name_and_param);
                                }
                                else if (col.obj.GetType() == typeof(DBm_Image_FileName))
                                {
                                    sql_DBm_Image_Insert += DBtypesFunc.DBm_sql_Insert_fkey_column(RootTableName, type, typeof(Image_FileName),Image_FileName, lsqlPar, System.Data.SqlDbType.NVarChar, false, -1,lPar_DBm_col_name_and_param);
                                }
                                else if (col.obj.GetType() == typeof(DBm_Image_Ext))
                                {
                                    sql_DBm_Image_Insert += DBtypesFunc.DBm_sql_Insert_fkey_column(RootTableName, type, typeof(Image_Ext),Image_Ext, lsqlPar, System.Data.SqlDbType.NVarChar, false, -1,lPar_DBm_col_name_and_param);
                                }
                                else if (col.obj.GetType() == typeof(DBm_Image_Folder))
                                {
                                    sql_DBm_Image_Insert += DBtypesFunc.DBm_sql_Insert_fkey_column(RootTableName, type, typeof(Image_Folder),Image_Folder, lsqlPar, System.Data.SqlDbType.NVarChar, false, -1,lPar_DBm_col_name_and_param);
                                }
                                else if (col.obj.GetType() == typeof(DBm_Image_Computer))
                                {
                                    sql_DBm_Image_Insert += DBtypesFunc.DBm_sql_Insert_fkey_column(RootTableName, type, typeof(Image_Computer),ComputerName, lsqlPar, System.Data.SqlDbType.NVarChar, false, -1,lPar_DBm_col_name_and_param);
                                }
                                else if (col.obj.GetType() == typeof(DBm_Image_ComputerUserName))
                                {
                                    sql_DBm_Image_Insert += DBtypesFunc.DBm_sql_Insert_fkey_column(RootTableName, type, typeof(Image_ComputerUserName),ComputerUserName, lsqlPar, System.Data.SqlDbType.NVarChar, false, -1,lPar_DBm_col_name_and_param);
                                }
                            }
                            else
                            {
                                if (col.obj.GetType() == typeof(Image_DateCreated))
                                {
                                    DBtypesFunc.Add_DBm_col_name_and_param(RootTableName, typeof(Image_DateCreated),CaptureTime,System.Data.SqlDbType.DateTime,-1, lsqlPar,lPar_DBm_col_name_and_param);
                                }
                                else if (col.obj.GetType() == typeof(Image_Size))
                                {
                                    DBtypesFunc.Add_DBm_col_name_and_param(RootTableName, typeof(Image_Size),Image_Size,System.Data.SqlDbType.BigInt,-1,lsqlPar,lPar_DBm_col_name_and_param);
                                }
                                else if (col.obj.GetType() == typeof(Image_Width))
                                {
                                    DBtypesFunc.Add_DBm_col_name_and_param(RootTableName, typeof(Image_Width),img_width,System.Data.SqlDbType.BigInt,-1,lsqlPar,lPar_DBm_col_name_and_param);
                                }
                                else if (col.obj.GetType() == typeof(Image_Height))
                                {
                                    DBtypesFunc.Add_DBm_col_name_and_param(RootTableName, typeof(Image_Height),img_height,System.Data.SqlDbType.BigInt,-1,lsqlPar,lPar_DBm_col_name_and_param);
                                }
                                else if (col.obj.GetType() == typeof(Image_Hash))
                                {
                                    DBtypesFunc.Add_DBm_col_name_and_param(RootTableName, typeof(Image_Hash),hash,System.Data.SqlDbType.NVarChar,-1,lsqlPar,lPar_DBm_col_name_and_param);
                                }
                                else if (col.obj.GetType() == typeof(Image_Data))
                                {
                                      byte[] bin = DBTypes.DBtypesFunc.imageToByteArray(img);
                                    DBtypesFunc.Add_DBm_col_name_and_param(RootTableName, typeof(Image_Data),bin,System.Data.SqlDbType.VarBinary,bin.Count(),lsqlPar,lPar_DBm_col_name_and_param);
                                }
                            }
                        }
                    }

                    Par_DBm_ID = "@Par_"+this.TableName+"_ID";

                    SQL_Parameter SQL_Par = new SQL_Parameter();
                    SQL_Par.dbType = SqlDbType.BigInt;
                    SQL_Par.IsOutputParameter = true;
                    SQL_Par.Name = Par_DBm_ID;
                    SQL_Par.size = -1;
                    SQL_Par.Value = -1;
                    lsqlPar.Add(SQL_Par);


                    //sql_DBm_Image_Insert += "declare "+Par_DBm_ID+ " bigint \r\n";


                    sql_DBm_Image_Insert += "select " + Par_DBm_ID + " = ID from " + this.TableName + " where  Image_Hash = '" + hash + "' \r\n";
                    
                    sql_DBm_Image_Insert += "if ( " + Par_DBm_ID + " is null) \r\n";
                    sql_DBm_Image_Insert += "begin\r\n";
                    sql_DBm_Image_Insert += "  insert into " + this.TableName +@"
                                               (";
                    string comma="";
                    foreach (DBm_col_name_and_param Par_DBm in lPar_DBm_col_name_and_param)
                    {
                        sql_DBm_Image_Insert += "\r\n"+comma+Par_DBm.col_name;
                        comma=",";
                    }
                    sql_DBm_Image_Insert += @"  
                                                )
                                                VALUES
                                                (";
                    comma="";
                    foreach (DBm_col_name_and_param Par_DBm in lPar_DBm_col_name_and_param)
                    {
                        sql_DBm_Image_Insert += "\r\n"+comma+Par_DBm.Par_col_name;
                        comma=",";
                    }
                    sql_DBm_Image_Insert += @" )\r\n";
                    sql_DBm_Image_Insert += @" SET " +Par_DBm_ID+" = SCOPE_IDENTITY() \r\n";

                    sql_DBm_Image_Insert += "end\r\n";

                    return sql_DBm_Image_Insert;

                }
                else
                {
                    csError = "Error:DBm_Image table '" + this.TableName + "' has no parent table in function DBm_Image_Insert(..";
                    return null;
                }
            }
            else
            {
                string sql_DBm_Image_Insert_all = "";
                foreach (Column col in Column)
                {
                    if (col.fKey != null)
                    {
                        if (col.fKey.fTable.objTable.GetType() == typeof(DBm_Image))
                        {
                            string sIns = col.fKey.fTable.DBm_Image_Insert(jpgFile, Image_Name, Image_Author, Image_Capture_Location,lsqlPar,lPar_DBm_col_name_and_param, ref Par_DBm_ID,ref csError);
                            if (sIns==null)
                            {
                                return null;
                            }
                            sql_DBm_Image_Insert_all += sIns;
                        }
                    }
                }
                return sql_DBm_Image_Insert_all;
            }
        }

        public string DBm_SImage_Insert(string jpgFile, List<SQL_Parameter> lsqlPar, List<DBm_col_name_and_param> lPar_DBm_col_name_and_param, ref string Par_DBm_ID, ref string csError)
        {
            if (this.objTable.GetType() == typeof(DBm_SImage))
            {
                if (this.pParentTable != null)
                {

                    string sql_DBm_SImage_Insert = "";

                    string RootTableName = this.pParentTable.TableName;

                    Image img = new Bitmap(jpgFile);


                    string hash = DBtypesFunc.GetHash_SHA1(DBtypesFunc.imageToByteArray(img));


                    foreach (Column col in Column)
                    {
                        if (col.IsIdentity)
                        {

                        }
                        else
                        {
                            if (col.fKey != null)
                            {
                            }
                            else
                            {
                                if (col.obj.GetType() == typeof(Image_Hash))
                                {
                                    DBtypesFunc.Add_DBm_col_name_and_param(RootTableName, typeof(Image_Hash), hash, System.Data.SqlDbType.NVarChar, -1, lsqlPar, lPar_DBm_col_name_and_param);
                                }
                                else if (col.obj.GetType() == typeof(Image_Data))
                                {
                                    byte[] bin = DBTypes.DBtypesFunc.imageToByteArray(img);
                                    DBtypesFunc.Add_DBm_col_name_and_param(RootTableName, typeof(Image_Data), bin, System.Data.SqlDbType.VarBinary, bin.Count(), lsqlPar, lPar_DBm_col_name_and_param);
                                }
                            }
                        }
                    }

                    Par_DBm_ID = "@Par_" + this.TableName + "_ID";

                    SQL_Parameter SQL_Par = new SQL_Parameter();
                    SQL_Par.dbType = SqlDbType.BigInt;
                    SQL_Par.IsOutputParameter = true;
                    SQL_Par.Name = Par_DBm_ID;
                    SQL_Par.size = -1;
                    SQL_Par.Value = -1;
                    lsqlPar.Add(SQL_Par);


                    //sql_DBm_Image_Insert += "declare "+Par_DBm_ID+ " bigint \r\n";


                    sql_DBm_SImage_Insert += "select " + Par_DBm_ID + " = ID from " + this.TableName + " where  Image_Hash = '" + hash + "' \r\n";

                    sql_DBm_SImage_Insert += "if ( " + Par_DBm_ID + " is null) \r\n";
                    sql_DBm_SImage_Insert += "begin\r\n";
                    sql_DBm_SImage_Insert += "  insert into " + this.TableName + @"
                                               (";
                    string comma = "";
                    foreach (DBm_col_name_and_param Par_DBm in lPar_DBm_col_name_and_param)
                    {
                        sql_DBm_SImage_Insert += "\r\n" + comma + Par_DBm.col_name;
                        comma = ",";
                    }
                    sql_DBm_SImage_Insert += @"  
                                                )
                                                VALUES
                                                (";
                    comma = "";
                    foreach (DBm_col_name_and_param Par_DBm in lPar_DBm_col_name_and_param)
                    {
                        sql_DBm_SImage_Insert += "\r\n" + comma + Par_DBm.Par_col_name;
                        comma = ",";
                    }
                    sql_DBm_SImage_Insert += @" )\r\n";
                    sql_DBm_SImage_Insert += @" SET " + Par_DBm_ID + " = SCOPE_IDENTITY() \r\n";

                    sql_DBm_SImage_Insert += "end\r\n";

                    return sql_DBm_SImage_Insert;

                }
                else
                {
                    csError = "Error:DBm_Image table '" + this.TableName + "' has no parent table in function DBm_Image_Insert(..";
                    return null;
                }
            }
            else
            {
                string sql_DBm_SImage_Insert_all = "";
                foreach (Column col in Column)
                {
                    if (col.fKey != null)
                    {
                        if (col.fKey.fTable.objTable.GetType() == typeof(DBm_SImage))
                        {
                            string sIns = col.fKey.fTable.DBm_SImage_Insert(jpgFile, lsqlPar, lPar_DBm_col_name_and_param, ref Par_DBm_ID, ref csError);
                            if (sIns == null)
                            {
                                return null;
                            }
                            sql_DBm_SImage_Insert_all += sIns;
                        }
                    }
                }
                return sql_DBm_SImage_Insert_all;
            }
        }

        public void Set_DataGridViewImageColumns_Headers(DataGridView dgvx_Item)
        {
            foreach (DataGridViewColumn col in dgvx_Item.Columns)
            {
               Column c = this.FindColumn(col.Name);
               if (c != null)
               {
                   col.HeaderText = c.Name_in_language.s;
               }
            }
        }

        public void SetVIEW_DataGridViewImageColumns_Headers(DataGridView dgvx_Item, CodeTables.DBTableControl xdbTables)
        {
            foreach (DataGridViewColumn col in dgvx_Item.Columns)
            {
                Column c = this.FindColumn(col.Name);
                if (c != null)
                {
                    col.HeaderText = c.Name_in_language.s;
                }
                else
                {
                    string sSeparator = VIEW_TableName2ColumnName_SEPARATOR;
                    int iSeparator_Length = sSeparator.Length;
                    int iTableNameEnd = col.Name.IndexOf(sSeparator);
                    if (iTableNameEnd > 0)
                    {
                        string sTableName = col.Name.Substring(0, iTableNameEnd);
                        string sColName = col.Name.Substring(iTableNameEnd + iSeparator_Length, col.Name.Length - iTableNameEnd - iSeparator_Length);
                        iSeparator_Length = VIEW_TableName_SEPARATOR.Length;
                        iTableNameEnd = sTableName.LastIndexOf(VIEW_TableName_SEPARATOR);
                        SQLTable tbl = null;
                        if (iTableNameEnd > 0)
                        {
                            sTableName = sTableName.Substring(iTableNameEnd + iSeparator_Length, sTableName.Length - iTableNameEnd - iSeparator_Length);
                            tbl = xdbTables.GetTable_from_TableName_Abbreviation(sTableName);
                        }
                        else
                        {
                            tbl = xdbTables.GetTable(sTableName);
                        }
                        if (tbl != null)
                        {
                            Column cc = tbl.FindColumn(sColName);
                            if (cc != null)
                            {
                                col.HeaderText = cc.Name_in_language.s;
                            }
                        }
                    }
                }
            }
        }

        private Column FindColumn(string column_name)
        {
            return Column.Find(col => col.Name == column_name);
            //foreach (Column col in Column)
            //{
            //    if (col.Name.Equals(column_name))
            //    {
            //        return col;
            //    }
            //}
            //return null;

        }


        public void SetView_DataGridViewImageColumns_Headers(DataGridView dataGridView)
        {
            if (this.m_Table_View != null)
            {
                foreach (DataGridViewColumn dgvcol in dataGridView.Columns)
                {
                    this.m_Table_View.SetView_DataGridViewImageColumns_Headers(dgvcol);
                }
            }
        }

        internal void Check_Null_Values(ref string mymsg)
        {
            foreach (Column col in Column)
            {
                if (col.nulltype == CodeTables.Column.nullTYPE.NOT_NULL)
                {
                    if (col.InputControl != null)
                    {
                        if (col.InputControl.IsNotDefined())
                        {
                            col.InputControl.MarkAsUndefined();
                            string s = col.Name_in_language.s + lng.s_CanNotBeNull.s;
                            if (mymsg == null)
                            {
                                mymsg = s;
                            }
                            else
                            {
                                mymsg += "\r\n" + s;
                            }
                        }
                    }
                    else
                    {
                        if (col.fKey != null)
                        {
                            if (col.fKey.fTable != null)
                            {
                                if (col.fKey.fTable.myGroupBox != null)
                                {
                                    DBTypes.long_v id_v = null;
                                    if (!col.fKey.fTable.myGroupBox.Get_ID(ref id_v))
                                    {
                                        col.fKey.fTable.myGroupBox.MarkAsUndefined_Index();
                                        //string s = col.Name_in_language[LanguageControl.DynSettings.LanguageID] + lng.s_CanNotBeNull.s;
                                        //if (mymsg == null)
                                        //{
                                        //    mymsg = s;
                                        //}
                                        //else
                                        //{
                                        //    mymsg += "\r\n" + s;
                                        //}
                                        col.fKey.fTable.Check_Null_Values(ref mymsg);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    //col.nulltype ==  CodeTables.Column.nullTYPE.NULL
                    if (col.InputControl != null)
                    {
                        if (!col.InputControl.usrc_lbl.Null_Selected)
                        {
                            if (col.InputControl.IsNotDefined())
                            {
                                col.InputControl.MarkAsUndefined();
                                string s = col.Name_in_language.s + lng.s_CanNotBeNull.s;
                                if (mymsg == null)
                                {
                                    mymsg = s;
                                }
                                else
                                {
                                    mymsg += "\r\n" + s;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (col.fKey != null)
                        {
                            if (col.fKey.fTable != null)
                            {
                                if (col.fKey.fTable.myGroupBox != null)
                                {
                                    if (!col.fKey.fTable.myGroupBox.usrc_lbl.Null_Selected)
                                    {
                                       col.fKey.fTable.Check_Null_Values(ref mymsg);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        internal void Show_And_Init_Reference_ID(UniqueControlName xuctrln)
        {
            if (this.myGroupBox != null)
            {
                  this.myGroupBox.Show_And_Init_Reference_ID(xuctrln);
            }
        }

        internal void Hide_And_Init_Reference_ID(UniqueControlName xuctrln)
        {
            if (this.myGroupBox != null)
            {
                // undefine input controls!
                foreach(Column col in Column)
                {
                    if (col.InputControl != null)
                    {
                        col.InputControl.Defined = false;
                        col.InputControl.InitToDefault();
                    }
                }
                this.myGroupBox.Hide_And_Init_Reference_ID(xuctrln);
            }
        }

        internal bool Image_Hash_Changed()
        {
            foreach (Column col in Column)
            {
                if (col.Name.Equals("Image_Hash"))
                {
                    return col.InputControl.Changed;
                }
            }
            LogFile.Error.Show("ERROR:Image_Hash_Changed:Column Image_Hash not found");
            return false;
        }

        internal bool xDocument_Hash_Changed()
        {
            foreach (Column col in Column)
            {
                if (col.Name.Equals("xDocument_Hash"))
                {
                    return col.InputControl.Changed;
                }
            }
            LogFile.Error.Show("ERROR:xDocument_Hash_Changed:Column xDocument_Hash not found");
            return false;
        }

        public void FillTable(SQLTable.delegate_FillTable myFill)
        {
            foreach (Column col in Column)
            {
                if (col.fKey!=null)
                {
                    if (col.fKey.fTable!=null)
                    {
                        col.fKey.fTable.FillTable(myFill);
                    }
                }
            }
            myFill(this);
        }

        public void SetInputControlProperties(SQLTable.delegate_mySetInputControlProperties mySetInputControlProperties, object obj)
        {
            foreach (Column col in Column)
            {
                if (col.fKey != null)
                {
                    if (col.fKey.fTable != null)
                    {
                        col.fKey.fTable.SetInputControlProperties(mySetInputControlProperties, obj);
                    }
                }
                else
                {
                    mySetInputControlProperties(col, obj);
                }
            }
        }
    }
}

