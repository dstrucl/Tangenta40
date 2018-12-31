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
using DBTypes;
using DBConnectionControl40;
using System.Windows.Forms;
using LanguageControl;
using System.Drawing;
using System.IO;
using System.IO.Compression;

namespace CodeTables
{

    public static class Globals
    {
        public const int BUFFER_SIZE = 64 * 1024;
        public delegate void delegate_SetControls(SQLTable tbl);

        public enum eDBType
        {
            DB_UNKNOWN,
            DB_Int32,
            DB_Int64,
            DB_Money,
            DB_decimal,
            DB_float,
            DB_Percent,
            DB_smallInt,
            DB_bit,
            DB_DateTime,
            DB_varbinary_max,
            DB_varchar_264,
            DB_varchar_250,
            DB_varchar_64,
            DB_varchar_50,
            DB_varchar_45,
            DB_varchar_32,
            DB_varchar_25,
            DB_varchar_10,
            DB_varchar_5,
            DB_varchar_2000,
            DB_varchar_max,
            DB_Document,
            DB_Image
        }


        private static bool m_Show_ID = false;

        public static bool ShowID
        {
            get {
                return m_Show_ID;
                }
            set {
                    m_Show_ID = value;
                }
        }

        public static Object MainWindow = null;
        public static int TAB = 4;
        public static string sVar = "Var";
        public static string LeftMargin = "  ";
        public static string m_IdentityIndexTYPE = "int";
        public static string tab(int num)
        {
            string s = new string(' ', num);
            return s;

        }

        internal static void ShowID_In_DataGrid(DataGridView dataGridView)
        {
            foreach (DataGridViewColumn dgvc in dataGridView.Columns)
            {
                if (dgvc.Name.Equals("ID")|| dgvc.Name.Contains("_$$ID"))
                {
                    dgvc.Visible = ShowID;
                }
            }
        }

        public static byte[] Compress(byte[] inputData)
        {
            if (inputData == null)
                throw new ArgumentNullException("inputData must be non-null");

            using (var compressIntoMs = new MemoryStream())
            {
                using (var gzs = new BufferedStream(new GZipStream(compressIntoMs,
                 CompressionMode.Compress), BUFFER_SIZE))
                {
                    gzs.Write(inputData, 0, inputData.Length);
                }
                return compressIntoMs.ToArray();
            }
        }

        public static byte[] Decompress(byte[] inputData)
        {
            if (inputData == null)
                throw new ArgumentNullException("inputData must be non-null");

            using (var compressedMs = new MemoryStream(inputData))
            {
                using (var decompressedMs = new MemoryStream())
                {
                    using (var gzs = new BufferedStream(new GZipStream(compressedMs,
                     CompressionMode.Decompress), BUFFER_SIZE))
                    {
                        gzs.CopyTo(decompressedMs);
                    }
                    return decompressedMs.ToArray();
                }
            }
        }


        public static Image Image_SelectRow
        {
            get { return Properties.Resources.SelectRow; }
        }


        public static object GetNewObject(Type t)
        {
            try
            {
                return t.GetConstructor(new Type[] { }).Invoke(new object[] { });
            }
            catch
            {
                return null;
            }
        }


        public static string RemoveComas(string s)
        {
            char[] trchr = {' '};
            string s1 = s.TrimStart(trchr);
            
            if (s1.Length > 0)
            {
                if (s1[0] == '"')
                {
                    if (s1.Length > 2)
                    {
                        trchr[0] = '"';
                        s1 = s1.TrimStart(trchr);
                        trchr[0] = ' ';
                        s1 = s1.TrimEnd(trchr);
                        trchr[0] = '"';
                        s1 = s1.TrimEnd(trchr);
                        return s1;
                    }
                }
            }
            return s;
        }

        public static bool FindTable(out SQLTable outTable, string xTableName,List<SQLTable> lTable)
        {
            foreach (SQLTable tbl in lTable)
            {
                if (tbl.TableName.Equals(xTableName))
                {
                    outTable = tbl;
                    return true;
                }
            }
            outTable = null;
            return false;
        }

        public static eDBType Get_eDBType(Object obj)
        {
            Type basetype = obj.GetType().BaseType;
            if (basetype == typeof(DB_Int32))
            {
                return eDBType.DB_Int32;
            }
            else if (basetype == typeof(DB_Int64))
            {
                return eDBType.DB_Int64;
            }
            else if (basetype == typeof(DB_Money))
            {
                return eDBType.DB_Money;
            }
            else if (basetype == typeof(DB_decimal))
            {
                return eDBType.DB_decimal;
            }
            else if (basetype == typeof(DB_float))
            {
                return eDBType.DB_float;
            }
            else if (basetype == typeof(DB_Percent))
            {
                return eDBType.DB_Percent;
            }
            else if (basetype == typeof(DB_smallInt))
            {
                return eDBType.DB_smallInt;
            }
            else if (basetype == typeof(DB_bit))
            {
                return eDBType.DB_bit;
            }
            else if (basetype == typeof(DB_DateTime))
            {
                return eDBType.DB_DateTime;
            }
            else if (basetype == typeof(DB_varbinary_max))
            {
                return eDBType.DB_varbinary_max;
            }
            else if (basetype == typeof(DB_varchar_264))
            {
                return eDBType.DB_varchar_264;
            }
            else if (basetype == typeof(DB_varchar_250))
            {
                return eDBType.DB_varchar_250;
            }
            else if (basetype == typeof(DB_varchar_64))
            {
                return eDBType.DB_varchar_64;
            }
            else if (basetype == typeof(DB_varchar_50))
            {
                return eDBType.DB_varchar_50;
            }
            else if (basetype == typeof(DB_varchar_45))
            {
                return eDBType.DB_varchar_45;
            }
            else if (basetype == typeof(DB_varchar_32))
            {
                return eDBType.DB_varchar_32;
            }
            else if (basetype == typeof(DB_varchar_25))
            {
                return eDBType.DB_varchar_25;
            }
            else if (basetype == typeof(DB_varchar_10))
            {
                return eDBType.DB_varchar_10;
            }
            else if (basetype == typeof(DB_varchar_5))
            {
                return eDBType.DB_varchar_5;
            }
            else if (basetype == typeof(DB_varchar_2000))
            {
                return eDBType.DB_varchar_2000;
            }
            else if (basetype == typeof(DB_varchar_max))
            {
                return eDBType.DB_varchar_max;
            }
            else if (basetype == typeof(DB_Document))
            {
                return eDBType.DB_Document;
            }
            else if (basetype == typeof(DB_Image))
            {
                return eDBType.DB_Image;
            }
            else
            {
                return eDBType.DB_UNKNOWN;
            }
        }

        public static bool SQLcmd_InsertLines(List<string> Line, DBTableControl dbTables, StringBuilder m_strSQLUseDatabase, ref string ErrorMsg, Transaction transaction)
        {
            List<SQL_Parameter> lsqlPar = new List<SQL_Parameter>();

            SQLTable sqlTbl = null;
            SQLTable refsqlTbl = null;
            int iTableNameStart;
            int iTableNameEnd;
            StringBuilder sbSQLInsert = new StringBuilder(m_strSQLUseDatabase.ToString());
            string sPrevVar = "";

            char[] trimChars = new char[] { ' ', '\t' };

            int index;
            int iCount = Line.Count();
            index = 0;
            while (index < iCount)
            {
                string sLine = Line[index];
                if (sqlTbl != null)
                {
                    iTableNameStart = sLine.IndexOf('<');
                    if (iTableNameStart != -1)
                    {
                        iTableNameStart++;
                        if (sLine[iTableNameStart].Equals('/'))
                        {
                            iTableNameStart++;
                            iTableNameEnd = sLine.IndexOf('>');
                            string sTblName = sLine.Substring(iTableNameStart, iTableNameEnd - iTableNameStart);
                            if (sqlTbl.TableName.Equals(sTblName))
                            {
                                string sVarID = Globals.sVar + "_" + sqlTbl.TableName;
                                sPrevVar = Globals.sVar;
                                if (dbTables.Con.DBType == DBConnection.eDBType.SQLITE)
                                {
                                    string PrevVar = sqlTbl.TableName;
                                    sVarID = "";
                                    ID ID = null;
                                    string csError = null;
                                    bool bSomethingDefined = false;
                                    if (sqlTbl.SQLcmd_InsertInto_SQLITE(dbTables.Con, PrevVar, ref sVarID, /*ref  lsqlPar,*/ dbTables.items,ref bSomethingDefined, ref ID, ref csError, transaction))
                                    {
                                        if (ID.Validate(ID))
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        LogFile.Error.Show("Error:" + csError);
                                    }
                                }
                                else
                                {
                                    sqlTbl.SQLcmd_Insert_MSSQL(ref sbSQLInsert, sPrevVar, ref sVarID, ref lsqlPar, dbTables.items,0);
                                    if (transaction.ExecuteNonQuerySQL(dbTables.Con,sbSQLInsert.ToString(), lsqlPar, ref ErrorMsg))
                                    {
                                        lsqlPar.Clear();
                                        sbSQLInsert.Remove(0, sbSQLInsert.Length);
                                        sbSQLInsert.Append(m_strSQLUseDatabase.ToString());
                                        sqlTbl = null;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show(lng.s_Illegal_end_table_XML_command_expected.s + ": </" + sqlTbl.TableName + ">\n", lng.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //Source_Txt.CloseText();
                            }
                        }
                        else
                        {
                            MessageBox.Show(lng.s_Illegal_end_table_XML_command_expected.s + ": </" + sqlTbl.TableName + ">\n", lng.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //                                Source_Txt.CloseText();
                        }
                    }
                    else
                    {
                        string[] column = sLine.Split(',');
                        int iTokenCount = column.Count();
                        string s1;
                        string s2 = "";
                        if (iTokenCount >= 2)
                        {
                            s1 = column[0];
                            int i;
                            for (i = 1; i < iTokenCount; i++)
                            {
                                s2 += column[i];
                            }
                            string Value = "";
                            index = GetValue(index, Line, s2, ref Value);
                            if (sqlTbl.SetColumnValue(s1, Value))
                            {
                                index++;
                                continue;
                            }
                            else
                            {
                                //Source_Txt.CloseText();
                                return false;
                            }
                        }
                        else
                        {
                            //Source_Txt.ShowParseError(lng.s_File.s + ":" + FileName + "\n" + lng.s_Comma_is_missing_to_separate_cells_column_name_from_cell_value_in_line.s + ":" + Source_Txt.iLine.ToString(), lng.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MessageBox.Show(lng.s_File.s + lng.s_Comma_is_missing_to_separate_cells_column_name_from_cell_value_in_line.s, lng.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //Source_Txt.CloseText();
                            return false;
                        }
                    }
                }
                else
                {
                    iTableNameStart = sLine.IndexOf('<');
                    iTableNameEnd = sLine.IndexOf('>');
                    if ((iTableNameStart != -1) && (iTableNameEnd != -1) && (iTableNameEnd > iTableNameStart))
                    {
                        string sTableName = sLine.Substring(iTableNameStart + 1, iTableNameEnd - iTableNameStart - 1);
                        sTableName = sTableName.TrimStart(trimChars);
                        sTableName = sTableName.TrimEnd(trimChars);
                        if (Globals.FindTable(out refsqlTbl, sTableName, dbTables.items))
                        {
                            sqlTbl = new SQLTable(refsqlTbl);
                            sqlTbl.CreateTableTree(dbTables.items);
                            index++;
                            continue;
                        }
                        else
                        {
                            //Source_Txt.ShowParseError(lng.s_TableNameIsExpectedToBeBeforeDataLines.s, lng.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(lng.s_TableNameIsExpectedToBeBeforeDataLines.s, lng.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }

                    }
                    else
                    {
                        //Source_Txt.ShowParseError(lng.s_TableNameIsExpectedToBeBeforeDataLines.s, lng.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        MessageBox.Show(lng.s_TableNameIsExpectedToBeBeforeDataLines.s, lng.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }

                index++;
            }
            //Source_Txt.CloseText();
            //  Structures are filled now create SQL statements
            return true;
        }

        private static int GetValue(int index, List<string> Line, string s2, ref string Value)
        {
            string[] token = s2.Split('=');
            char[] SkipSpaces = { ' ', '\t' };
            if (token.Count() >= 2)
            {
                string sCommand = token[0];
                sCommand.TrimStart(SkipSpaces);
                sCommand.TrimEnd(SkipSpaces);
                if (sCommand.Equals(ASet.KEYWORD_LINES))
                {
                    string sNumOfLines = token[1];
                    sNumOfLines.TrimStart(SkipSpaces);
                    sNumOfLines.TrimEnd(SkipSpaces);
                    int NumOfLines = Convert.ToInt32(sNumOfLines);
                    int i;
                    for (i = 0; i < NumOfLines; i++)
                    {
                        index++;
                        Value += Line[index];
                    }
                    return index;
                }
                else
                {
                    Value = s2;
                    return index;
                }
            }
            else
            {
                Value = s2;
                return index;
            }
        }

        public static bool InsertInDataBase_WithImportText(Globals.delegate_SetControls SetControls, SQLTable m_tbl,DBTableControl dbTables, StringBuilder sDataBaseUsed, bool bRefresh_m_DataTable_Form, Transaction transaction)
        {
            bool bRet = false;
            List<string> Lines = m_tbl.GetInputControlsData();
            if (Lines != null)
            {
                if (Lines.Count > 0)
                {
                    string ErrorMsg = "";
                    if (SQLcmd_InsertLines(Lines, dbTables, sDataBaseUsed, ref ErrorMsg,transaction))
                    {
                        bRet = true;
                        //System.Data.OleDb.OleDbDataAdapter adp=new System.Data.OleDb.OleDbDataAdapter();
                        if (bRefresh_m_DataTable_Form)
                        {
                            if (SetControls != null)
                            {
                                SetControls(m_tbl);
                            }
                        }
                    }
                    else
                    {
                        if (!DBConnectionControl40.DynSettings.bPreviewSQLBeforeExecution)
                        {
                            MessageBox.Show(ErrorMsg);
                        }
                    }
                }
            }
            return bRet;
        }

        public static bool ControlInfo(object ctrl,ref string title,ref string about, ref string description)
        {
            if (ctrl != null)
            {
                if (ctrl is usrc_myGroupBox)
                {
                    usrc_myGroupBox umygroupbox = (usrc_myGroupBox)ctrl;
                    if (umygroupbox.pSQL_Table!=null)
                    {
                        title = umygroupbox.grpBox.Text;
                        description += lng.s_NameOfTableInDatabaseIs.s+"\""+ umygroupbox.pSQL_Table.TableName +"\".";
                        return true;
                    }
                }
                else if (ctrl is usrc_InputControl)
                {
                    usrc_InputControl uinpctrl = (usrc_InputControl)ctrl;
                    Column xcol = uinpctrl.m_col;
                    if (xcol != null)
                    {
                        title = xcol.Name_in_language.s;
                        string xdescription = "";
                        if ((xcol.flags & Column.Flags.UNIQUE)!=0)
                        {
                            xdescription += lng.s_WriteUniqueValue.s;
                        }
                        switch (xcol.nulltype)
                        {
                            case Column.nullTYPE.NULL:
                              if (xdescription!=null)
                              {
                                    xdescription +="\r\n"+ lng.s_ThisInformationIsOptional.s;
                              }
                              else
                                {
                                    xdescription += "\r\n" + lng.s_ThisInformationIsCompulsory.s;
                                }
                                break;
                        }
                        int len = xcol.GetMaxColumnStringLength();
                        if (len>0)
                        {
                            xdescription += "\r\n" + lng.s_MaxInformationColumnTextLengthIs.s+" "+len.ToString()+ " "+lng.s_Characters.s+".";
                        }

                        string scolumnname = null;
                        if (xcol.ownerTable!=null)
                        {
                            if (xcol.ownerTable.TableName != null)
                            {
                                scolumnname = "\r\n" + lng.s_NameOfColumnInDataBaseTable.s + "\"" + xcol.ownerTable.TableName + "\":\"" + xcol.Name + "\".";
                            }
                        }
                        if (scolumnname == null)
                        {
                            scolumnname = "\r\n" + lng.s_NameOfColumnInDataBaseTable.s +":\"" + xcol.Name + "\".";
                        }
                        xdescription += scolumnname;
                        description = xdescription;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
