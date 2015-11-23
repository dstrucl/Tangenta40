using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
//using Ambq.Tools;
using DBConnectionControl40;
using LanguageControl;
using System.Drawing;
using StaticLib;
using DBTypes;

namespace SQLTableControl
{


    public partial class SQLTable
    {
        public const string VIEW_TableName2ColumnName_SEPARATOR = "_$$";

        public const string VIEW_TableName_SEPARATOR = "_$_";

        public string sql_CreateTable = null;
        public string sql_CreateView = null;

        bool m_SelectionButtonVisible = true;

        public bool SelectionButtonVisible
        {
            get
            {
                if (myGroupBox != null)
                {
                    m_SelectionButtonVisible = myGroupBox.SelectionButtonVisible;
                    return m_SelectionButtonVisible;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                m_SelectionButtonVisible = value;
                if (myGroupBox != null)
                {
                    myGroupBox.SelectionButtonVisible = m_SelectionButtonVisible;
                }
            }
        }

        public class Table_View
        {
            public class ColumnNames
            {
                public string Name = null;
                public ltext Name_in_language = null;
            }
            
            public bool defined = false;
            public string View_Name = null;
            public List<ColumnNames> View_ColumnNames_List = new List<ColumnNames>();
            public List<Table_View> View_List = new List<Table_View>();

            internal bool SetView_DataGridViewImageColumns_Headers(DataGridViewColumn dgvcol)
            {
                    if (SetHeaderText(dgvcol))
                    {
                        return true;
                    }
                    else
                    {
                        foreach (Table_View tbv in View_List)
                        {
                            if (tbv.SetView_DataGridViewImageColumns_Headers(dgvcol))
                            {
                                return true;
                            }
                        }
                        return false;
                    }
            }

            private bool SetHeaderText(DataGridViewColumn dgvcol)
            {
                foreach (ColumnNames cname in View_ColumnNames_List)
                {
                    if (cname.Name.Equals(dgvcol.Name))
                    {
                        dgvcol.HeaderText = cname.Name_in_language.s;
                        return true;
                    }
                }
                return false;
            }
        }

        public Table_View m_Table_View = null;

        const string const_DataBaseViewSuffix = "_VIEW";
 

        public delegate bool delegate_GetInputControlRandomData(usrc_InputControl inpControl, Column column,bool bMen);
        public delegate bool delegate_CheckRandomParamSettings(SQLTable tbl, bool bCheck);

        internal long tag_ID = -1;
        
        public ID_v current_row_ID = null;


        public int NoOfColumns = 0;

        public Object objTable = null;

        public string ViewName
        {
            get
            {
                if (m_Table_View != null)
                {
                    return m_Table_View.View_Name;
                }
                else
                {
                    return null;
                }
            }
        }

        public string TableName = "";

        public string TableName_Abbreviation = null;

        public string TableName_for_join_in_VIEW
        {
            get {
                    if (TableName_Abbreviation != null)
                    {
                        return TableName_Abbreviation;
                    }
                    else
                    {
                        return TableName;
                    }
                }
        }

        public ltext lngTableName;

        public Column.Flags flags;

        public List<Column> Column = new List<Column>();

        public List<ForeignKey> m_Fkey = new List<ForeignKey>();

        public List<EditControl> edtCtrlList = new List<EditControl>();

        public List<usrc_InputControl> inpCtrlList = new List<usrc_InputControl>();
        public List<DefineView_InputControl> DefineView_inpCtrlList = new List<DefineView_InputControl>();

        public usrc_myGroupBox myGroupBox = null;
        public DefineView_GroupBox DefineView_GroupBox = null;
        public Button btn;
        

        public SQLTable pParentTable;

        public MyTabControl TabControl = null;

        public string sThisVar = "";

        private List<Color> ColorList = new List<Color>();

        private List<Color> DefineView_ColorList = new List<Color>();

        private void InitColors()
        {
            //ColorList.Add(Color.FromArgb(169, 172, 211));
            //ColorList.Add(Color.FromArgb(211, 168, 194));
            //ColorList.Add(Color.FromArgb(211, 209, 168));
            //ColorList.Add(Color.FromArgb(168, 211, 186));
            //ColorList.Add(Color.FromArgb(169, 172, 211));
            //ColorList.Add(Color.FromArgb(211, 168, 194));
            //ColorList.Add(Color.FromArgb(211, 209, 168));
            //ColorList.Add(Color.FromArgb(168, 211, 186));
            //ColorList.Add(Color.FromArgb(169, 172, 211));
            //ColorList.Add(Color.FromArgb(211, 168, 194));



            //DefineView_ColorList.Add(Color.FromArgb(175, 128, 105));
            //DefineView_ColorList.Add(Color.FromArgb(198, 204, 167));
            //DefineView_ColorList.Add(Color.FromArgb(128, 116, 105));
            //DefineView_ColorList.Add(Color.FromArgb(204, 186, 167));
            //DefineView_ColorList.Add(Color.FromArgb(127, 127, 127));
            //DefineView_ColorList.Add(Color.FromArgb(124, 128, 105));
            //DefineView_ColorList.Add(Color.FromArgb(198, 204, 167));
            //DefineView_ColorList.Add(Color.FromArgb(128, 116, 105));
            //DefineView_ColorList.Add(Color.FromArgb(204, 186, 167));
            //DefineView_ColorList.Add(Color.FromArgb(127, 127, 127));

            ColorList.Add(Color.FromArgb(186, 199, 204));
            ColorList.Add(Color.FromArgb(204, 186, 199));
            ColorList.Add(Color.FromArgb(199, 204, 186));
            ColorList.Add(Color.FromArgb(186, 199, 204));
            ColorList.Add(Color.FromArgb(204, 186, 199));
            ColorList.Add(Color.FromArgb(199, 204, 186));
            ColorList.Add(Color.FromArgb(186, 199, 204));
            ColorList.Add(Color.FromArgb(204, 186, 199));
            ColorList.Add(Color.FromArgb(199, 204, 186));
            ColorList.Add(Color.FromArgb(186, 199, 204));



            DefineView_ColorList.Add(Color.FromArgb(186, 199, 204));
            DefineView_ColorList.Add(Color.FromArgb(204, 186, 199));
            DefineView_ColorList.Add(Color.FromArgb(199, 204, 186));
            DefineView_ColorList.Add(Color.FromArgb(186, 199, 204));
            DefineView_ColorList.Add(Color.FromArgb(204, 186, 199));
            DefineView_ColorList.Add(Color.FromArgb(199, 204, 186));
            DefineView_ColorList.Add(Color.FromArgb(186, 199, 204));
            DefineView_ColorList.Add(Color.FromArgb(204, 186, 199));
            DefineView_ColorList.Add(Color.FromArgb(199, 204, 186));
            DefineView_ColorList.Add(Color.FromArgb(186, 199, 204));


        }
        
        public SQLTable(SQLTable srcTbl)
        {
            InitColors();
            NoOfColumns = srcTbl.NoOfColumns;
            objTable = srcTbl.objTable;
            if (m_Table_View == null)
            {
                m_Table_View = new Table_View();
            }
            m_Table_View.View_Name = srcTbl.ViewName;
            TableName = srcTbl.TableName;
            TableName_Abbreviation = srcTbl.TableName_Abbreviation;
            lngTableName = srcTbl.lngTableName;
            flags = srcTbl.flags;
            foreach (Column col in srcTbl.Column)
            {
                Column nCol = new Column(col);
                nCol.ownerTable = this;
                Column.Add(nCol);
            }

            foreach (Column col in Column)
            {
                if (col.fKey != null)
                {
                    m_Fkey.Add(col.fKey);// Set the same reference
                }
            }
            //foreach (ForeignKey fk in srcTbl.m_Fkey)
            //{
            //    ForeignKey fknew = new ForeignKey(fk);
            //    m_Fkey.Add(fknew);
            //}
        }

        public SQLTable(SQLTable srcTbl,SQLTable DBm_owner_Tabel,List<SQLTable> lTable)  // This constructor is used for DBm_Image and DBm_Document
        {
            InitColors();
            NoOfColumns = srcTbl.NoOfColumns;
            objTable = srcTbl.objTable;
            m_Table_View = null;
            //ViewName = null;
            pParentTable = DBm_owner_Tabel;
            TableName = DBm_owner_Tabel.TableName + "_" + srcTbl.TableName;
            TableName_Abbreviation = DBm_owner_Tabel.TableName_Abbreviation + "_" + srcTbl.TableName_Abbreviation;
            lngTableName = new ltext(DBm_owner_Tabel.lngTableName.GetText(0) + ":" + srcTbl.lngTableName.GetText(0), DBm_owner_Tabel.lngTableName.GetText(1) + ":" + srcTbl.lngTableName.GetText(1));
            flags = srcTbl.flags;
            foreach (Column col in srcTbl.Column)
            {
                Column nCol = new Column(col, DBm_owner_Tabel, lTable);
                nCol.ownerTable = this;
                Column.Add(nCol);
            }

            foreach (Column col in Column)
            {
                if (col.fKey != null)
                {
                    m_Fkey.Add(col.fKey);// Set the same reference
                }
            }
            //foreach (ForeignKey fk in srcTbl.m_Fkey)
            //{
            //    ForeignKey fknew = new ForeignKey(fk);
            //    m_Fkey.Add(fknew);
            //}
        }
 

        public SQLTable(Object obj,string xTableName_Abbreviation, Column.Flags xflag, ltext lTableName)
        {
            InitColors();
            objTable = obj;
            flags = xflag;
            TableName = Func.GetNameFromObjectType(obj);
            TableName_Abbreviation = xTableName_Abbreviation;
            TableNames.Add(TableName, TableName_Abbreviation);
            lngTableName = lTableName;
            Column.Clear();
        }


        public void AddColumn(Object obj, Column.nullTYPE nulltype, Column.Flags xFlags, Column.eStyle styl,ltext lngLabels)
        {
            Column col = new Column(this, obj, nulltype, xFlags, styl, lngLabels);
            Column.Add(col);
            NoOfColumns++;
        }


        public bool IsForeignKey(string sfkey, out  ForeignKey outfKey)
        {
            foreach (ForeignKey fKey in m_Fkey)
            {
                if (fKey.ID_ForeignKey.Equals(sfkey))
                {
                    outfKey = fKey;
                    return true;
                }
            }
            outfKey = null;
            return false;
        }

        public bool IsColumnName(string s, out int ColumnIndex)
        {
            int i;
            int iCount;

            i = 0;
            iCount = this.Column.Count();

            for (i = 0; i<iCount;i++)
            {
                if (Column[i].Name.Equals(s))
                {
                    ColumnIndex = i;
                    return true;
                }
            }
            ColumnIndex = -1;
            return false;
        }

        public string s_GetColumnList()
        {
            int i;
            int iCount;
            iCount = Column.Count();
            string s= "\r\n";
            for (i = 0; i < iCount; i++)
            {
                if (i==0)
                {
                    s = s + Column[i].Name;
                }
                else
                {
                    s = s + ",\r\n" + Column[i].Name;
                }
            }
            return s;
        }

        public string s_GetForeignKeyList()
        {
            int i;
            int iCount;
            iCount = this.m_Fkey.Count();
            string s = "\r\n";
            for (i = 0; i < iCount; i++)
            {
                if (i == 0)
                {
                    s = s + m_Fkey[i].ID_ForeignKey;
                }
                else
                {
                    s = s + ",\r\n" + m_Fkey[i].ID_ForeignKey; 
                }
            }
            return s;
        }

        public bool SetColumnValue(string pcell,
                                   string Value,
                                   ref SourceText sTxt)
        {
            int iColumnIndex;
            char[] trimChars = new char[]{'*'};
            if (pcell.Length>=1)
            {
                if (pcell[0]=='*')
                {
                    // it is foreign key ID of this table;
                    string sForeignKey = pcell.TrimStart(trimChars);
                    int i = sForeignKey.IndexOf('>');
                    i++;
                    string pnextcell = sForeignKey.Substring(i);
                    sForeignKey = sForeignKey.Substring(0, i-1);
                    if (sForeignKey.Length>0)
                    {
                        sForeignKey = sForeignKey+ "_ID";
                        ForeignKey fKey;
                        if (IsForeignKey(sForeignKey, out fKey))
                        {
                            if (IsColumnName(sForeignKey, out iColumnIndex))
                            {
                                //Column[iColumnIndex].SetType = SQLTableControl.Column.ValueSetTYPE.SET_MUST;
                                if (Column[iColumnIndex].fKey.fTable.SetColumnValue(pnextcell, Value, ref sTxt))
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
                                sTxt.ShowParseError(lngRPM.s_CanNotFindColumnName.s + ":" + sForeignKey + "!", lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;

                            }
                            
                        }
                        else 
                        {
                            sTxt.ShowParseError(lngRPM.s_CanNotFindForeignKey.s + ":" + sForeignKey + " " + lngRPM.s_In_Table.s + ":" + this.TableName + " !\r\n" + lngRPM.s_ForeignKeysAre.s + ":" + s_GetForeignKeyList(), 
                                                lngRPM.s_Error.s, 
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else 
                    {
                       sTxt.ShowParseError(lngRPM.s_NoColumnName .s +  "!", lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                       return false;
                    }
                }
                else
                {
                    // check if it is columnName of this table;
                    if (IsColumnName(pcell, out iColumnIndex))
                    {
                        //Column[iColumnIndex].SetType = SQLTableControl.Column.ValueSetTYPE.SET_MUST;

                        if (Column[iColumnIndex].SetObjValue(Value, sTxt))
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
                        sTxt.ShowParseError(lngRPM.s_No_Table_or_Column_Name_in_Line.s + ":" + sTxt.iLine.ToString() + "!  " + lngRPM.s_Table.s + "\"" + this.TableName + "\" " + lngRPM.s_Columns_Are.s+":" + s_GetColumnList(), lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            else
            {
                sTxt.ShowParseError(lngRPM.s_No_Table_or_Column_Name_in_Line.s + ":" + sTxt.iLine.ToString() + "!", lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool SetColumnValue(string pcell,
                                   string Value)
        {
            int iColumnIndex;
            char[] trimChars = new char[] { '*' };
            if (pcell.Length >= 1)
            {
                if (pcell[0] == '*')
                {
                    // it is foreign key ID of this table;
                    string sForeignKey = pcell.TrimStart(trimChars);
                    int i = sForeignKey.IndexOf('>');
                    i++;
                    string pnextcell = sForeignKey.Substring(i);
                    sForeignKey = sForeignKey.Substring(0, i - 1);
                    if (sForeignKey.Length > 0)
                    {
                        sForeignKey = sForeignKey + "_ID";
                        ForeignKey fKey;
                        if (IsForeignKey(sForeignKey, out fKey))
                        {
                            if (IsColumnName(sForeignKey, out iColumnIndex))
                            {
                                //Column[iColumnIndex].SetType = SQLTableControl.Column.ValueSetTYPE.SET_MUST;
                                if (Column[iColumnIndex].fKey.fTable.SetColumnValue(pnextcell, Value))
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
                                //sTxt.ShowParseError(lngRPM.s_CanNotFindColumnName.s + ":" + sForeignKey + "!", lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                MessageBox.Show(lngRPM.s_CanNotFindColumnName.s + ":" + sForeignKey + "!", lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;

                            }

                        }
                        else
                        {
                            //sTxt.ShowParseError(lngRPM.s_CanNotFindForeignKey.s + ":" + sForeignKey + " " + lngRPM.s_In_Table.s + ":" + this.TableName + " !\r\n" + lngRPM.s_ForeignKeysAre.s + ":" + s_GetForeignKeyList(),
                                                //lngRPM.s_Error.s,
                            //MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MessageBox.Show(lngRPM.s_CanNotFindForeignKey.s + ":" + sForeignKey + " " + lngRPM.s_In_Table.s + ":" + this.TableName + " !\r\n" + lngRPM.s_ForeignKeysAre.s + ":" + s_GetForeignKeyList(),
                                                lngRPM.s_Error.s,
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        //sTxt.ShowParseError(lngRPM.s_NoColumnName.s + "!", lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MessageBox.Show(lngRPM.s_NoColumnName.s + "!", lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    // check if it is columnName of this table;
                    if (IsColumnName(pcell, out iColumnIndex))
                    {
                        //Column[iColumnIndex].SetType = SQLTableControl.Column.ValueSetTYPE.SET_MUST;
                        if (Column[iColumnIndex].SetObjValue(Value))
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
                        //sTxt.ShowParseError(lngRPM.s_No_Table_or_Column_Name_in_Line.s + ":" + sTxt.iLine.ToString() + "!  " + lngRPM.s_Table.s + "\"" + this.TableName + "\" " + lngRPM.s_Columns_Are.s + ":" + s_GetColumnList(), lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MessageBox.Show(lngRPM.s_No_Table_or_Column_Name_in_Line.s +  "!  " + lngRPM.s_Table.s + "\"" + this.TableName + "\" " + lngRPM.s_Columns_Are.s + ":" + s_GetColumnList(), lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            else
            {
                //sTxt.ShowParseError(lngRPM.s_No_Table_or_Column_Name_in_Line.s + ":" + sTxt.iLine.ToString() + "!", lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(lngRPM.s_No_Table_or_Column_Name_in_Line.s + "!", lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public string MSSQLcmd_CreateTable(DBTableControl dbTables, List<string> UniqueConstraintNameList, ref string sql_DBm, SQLTable DBm_owner_Table)
        {
            string SQL = "\nCREATE TABLE [dbo].[" + TableName + "]\n" + Globals.LeftMargin + "(\n";
            m_Fkey.Clear();
            int iLine = 0;
            foreach (Column col in this.Column)
            {
                if (iLine == 0)
                {
                    SQL = SQL + col.GetColumnDefinitionLine(dbTables, ref m_Fkey, UniqueConstraintNameList, ref sql_DBm, DBm_owner_Table);
                }
                else
                {
                    SQL = SQL + ",\n" + col.GetColumnDefinitionLine(dbTables, ref m_Fkey, UniqueConstraintNameList, ref sql_DBm, DBm_owner_Table);
                }
                iLine++;
            }
            // Add ForeignKeys if Any
            SQL = SQL + ",\n\n" + Globals.LeftMargin + "CONSTRAINT [PK_" + TableName + "] PRIMARY KEY CLUSTERED\n" + Globals.LeftMargin + "(\n" + Globals.LeftMargin + " [" + Column[0].Name + "] ASC\n" +
            Globals.LeftMargin + ")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]";

            SQL = SQL + "\n\n" + Globals.LeftMargin + ") ON [PRIMARY]\n";

            foreach (Column col in this.Column)
            {
                if ((col.flags & SQLTableControl.Column.Flags.UNIQUE)!=0)
                {
                    if (!col.IsIdentity)
                    {
                        string sUniqueConstraintName = UniqueNames.GetName(UniqueConstraintNameList, "uniquec_" + col.Name);
                        SQL = SQL + "\nALTER TABLE [dbo].[" + TableName + "]\n" + "ADD CONSTRAINT " + sUniqueConstraintName + " UNIQUE(" + col.Name + ");\n";
                        UniqueConstraintNameList.Add(sUniqueConstraintName);
                    }
                }
            }

            return SQL;
        }

        public string MySQLcmd_CreateTable(DBTableControl dbTables, List<string> UniqueConstraintNameList, ref string sql_DBm, SQLTable DBm_owner_Table)
        {
            string SQL = "\nCREATE TABLE `" + TableName + "`\n" + Globals.LeftMargin + "(\n";
            m_Fkey.Clear();
            int iLine = 0;
            foreach (Column col in this.Column)
            {
                if (iLine == 0)
                {
                    SQL = SQL + col.GetColumnMySQLDefinitionLine(dbTables, ref m_Fkey,UniqueConstraintNameList, ref sql_DBm, DBm_owner_Table);
                }
                else
                {
                    SQL = SQL + ",\n" + col.GetColumnMySQLDefinitionLine(dbTables, ref m_Fkey, UniqueConstraintNameList, ref sql_DBm, DBm_owner_Table);
                }
                iLine++;
            }
            //// Add ForeignKeys if Any
            SQL = SQL + ",\n\n" + Globals.LeftMargin + "PRIMARY KEY \n" + Globals.LeftMargin + "(\n" + Globals.LeftMargin + " `" + Column[0].Name + "`" +
            Globals.LeftMargin + ")";

            foreach (ForeignKey fk in m_Fkey)
            {
                SQL = SQL + ",\n\n" + Globals.LeftMargin + "KEY `" + fk.ID_ForeignKey + "` (`" + fk.ID_ForeignKey + "`)";
            }


            SQL = SQL + "\n\n" + Globals.LeftMargin + ") ENGINE=InnoDB DEFAULT CHARSET=utf8 PACK_KEYS=0;\n";

            foreach (Column col in this.Column)
            {
                if ((col.flags & SQLTableControl.Column.Flags.FILTER)!=0)
                {
                    if (!col.IsIdentity)
                    {
                        string sBasicTypeLength = "";
                        int il = DBTypes.DBtypesFunc.GetBasicTypeLengthMySQL(col.obj);
                        if (il > 0)
                        {
                            sBasicTypeLength = "(" + il.ToString() + ")";
                        }

                        string sUniqueConstraintName = UniqueNames.GetName(UniqueConstraintNameList, "uniquec_" + col.Name);
                        SQL = SQL + "\nALTER TABLE `" + TableName + "`\n" + "ADD CONSTRAINT " + sUniqueConstraintName + " UNIQUE(" + col.Name + sBasicTypeLength +");\n";
                        UniqueConstraintNameList.Add(sUniqueConstraintName);
                    }
                }
            }

            return SQL;
        }

        private string GetMySqlVarcharLengthString(string s)
        {
            int isB = s.IndexOf('(');
            int isE = s.IndexOf(')');
            if (isB > 0)
            {
                if (isE>isB)
                {
                    return s.Substring(isB, isE - isB + 1);
                }
            }
            return ("(20)");
        }


        public string SQLitecmd_CreateTable(DBTableControl dbTables, List<string> UniqueConstraintNameList, ref string sql_DBm, SQLTable DBm_owner_Table)
        {
            string SQL = "\nCREATE TABLE " + TableName + "\n" + Globals.LeftMargin + "(\n";
            m_Fkey.Clear();
            int iLine = 0;
            foreach (Column col in this.Column)
            {
                if (iLine == 0)
                {
                    SQL = SQL + col.GetColumnSQLiteDefinitionLine(dbTables, ref m_Fkey,UniqueConstraintNameList, ref sql_DBm,  DBm_owner_Table);
                }
                else
                {
                    SQL = SQL + ",\n" + col.GetColumnSQLiteDefinitionLine(dbTables, ref m_Fkey, UniqueConstraintNameList, ref sql_DBm, DBm_owner_Table);
                }
                iLine++;
            }
            ////// Add ForeignKeys if Any
            //SQL = SQL + ",\n\n" + Globals.LeftMargin + "PRIMARY KEY \n" + Globals.LeftMargin + "(\n" + Globals.LeftMargin + " `" + Column[0].Name + "`" +
            //Globals.LeftMargin + ")";

            SQL = SQL + "\n\n" + Globals.LeftMargin + ");";

            //foreach (Column col in this.Column)
            //{
            //    if (col.utyp == SQLTableControl.UNIQUE)
            //    {
            //        if (!col.IsIdentity)
            //        {
            //            string sUniqueConstraintName = UniqueNames.GetName(UniqueConstraintNameList, "uniquec_" + col.Name);
            //            SQL = SQL + "\nALTER TABLE `" + TableName + "`\n" + "ADD CONSTRAINT " + sUniqueConstraintName + " UNIQUE(" + col.Name + ");\n";
            //            UniqueConstraintNameList.Add(sUniqueConstraintName);
            //        }
            //    }
            //}
            return SQL;
        }

        public string SQLcmd_CreateTable(DBTableControl dbTables, List<string> UniqueConstraintNameList, ref string sql_DBm, SQLTable DBm_owner_Table)
        {
            //this.Column.Clear();
            //this.ColorList.Clear();
            //this.DefineView_ColorList.Clear();
            //this.DefineView_inpCtrlList.Clear();
            //this.m_Fkey.Clear();

            switch (dbTables.m_con.DBType)
            {
                case DBConnection.eDBType.MYSQL:
                return MySQLcmd_CreateTable(dbTables, UniqueConstraintNameList, ref sql_DBm, DBm_owner_Table);

                case DBConnection.eDBType.MSSQL:
                return MSSQLcmd_CreateTable(dbTables, UniqueConstraintNameList, ref sql_DBm, DBm_owner_Table);

                case DBConnection.eDBType.SQLITE:
                return SQLitecmd_CreateTable(dbTables, UniqueConstraintNameList, ref sql_DBm, DBm_owner_Table);

                default:
                MessageBox.Show("Error dbTables.m_con.DBType in function:public string SQLcmd_CreateTable(SQLTableControl dbTables, List<string> UniqueConstraintNameList)");
                return "ERROR";
            }

        }


        public string SQLcmdMSSQL_AlterTableAddConstraintForeign()
        {
            string SQL = "";

            foreach (ForeignKey fk in m_Fkey)
            {
                SQL = SQL + Globals.tab(Globals.TAB) + "\nALTER TABLE [dbo].[" + this.TableName + "]\n"
                           + Globals.tab(Globals.TAB * 2) + "ADD\n";
                string str = Globals.tab(Globals.TAB * 3) + " CONSTRAINT [FK_" + fk.ID_ForeignKey + "_in_" + TableName + "] FOREIGN KEY([" + fk.ID_ForeignKey + "]) REFERENCES [dbo].[" + fk.ReferenceTable + "] ([" + fk.ReferenceTable_Column + "]);\n";
                SQL = SQL + str;
            }
             return SQL;
        }

        public string SQLcmdMySQL_AlterTableAddConstraintForeign()
        {
            string SQL = "";

            foreach (ForeignKey fk in m_Fkey)
            {
                SQL = SQL + Globals.tab(Globals.TAB) + "\nALTER TABLE `" + this.TableName + "`\n"
                           + Globals.tab(Globals.TAB * 2) + "ADD\n";
                string str = Globals.tab(Globals.TAB * 3) + " CONSTRAINT `FK_" + fk.ID_ForeignKey + "_in_" + TableName + "` FOREIGN KEY(`" + fk.ID_ForeignKey + "`) REFERENCES `" + fk.ReferenceTable + "` (`" + fk.ReferenceTable_Column + "`);\n";
                SQL = SQL + str;
            }
            return SQL;
        }


        public string SQLcmd_AlterTableDropConstraintForeign()
        {
            string SQL = "";

            foreach (ForeignKey fk in m_Fkey)
            {
                SQL = SQL + Globals.tab(Globals.TAB) + "\nALTER TABLE [dbo].[" + this.TableName + "]\n"
                           + Globals.tab(Globals.TAB * 2) + "DROP\n";
                string str = Globals.tab(Globals.TAB * 3) + " CONSTRAINT [FK_" + fk.ID_ForeignKey + "_in_" + TableName + "];";// FOREIGN KEY([" + fk.ID_ForeignKey + "]) REFERENCES [dbo].[" + fk.ReferenceTable + "] ([" + fk.ReferenceTable_Column + "]);\n";
                SQL = SQL + str;
            }
            return SQL;
        }

        public string MySQLcmd_AlterTableDropConstraintForeign()
        {
            string SQL = "";

            foreach (ForeignKey fk in m_Fkey)
            {
                SQL = SQL + Globals.tab(Globals.TAB) + "\nALTER TABLE " + this.TableName + "\n"
                           + Globals.tab(Globals.TAB * 2) + "DROP\n";
                string str = Globals.tab(Globals.TAB * 3) + " CONSTRAINT FK_" + fk.ID_ForeignKey + "_in_" + TableName + ";";// FOREIGN KEY([" + fk.ID_ForeignKey + "]) REFERENCES [dbo].[" + fk.ReferenceTable + "] ([" + fk.ReferenceTable_Column + "]);\n";
                SQL = SQL + str;
            }
            return SQL;
        }

        public string SQLitecmd_AlterTableDropConstraintForeign()
        {
            string SQL = "";

            foreach (ForeignKey fk in m_Fkey)
            {
                SQL = SQL + Globals.tab(Globals.TAB) + "\nALTER TABLE " + this.TableName + "\n"
                           + Globals.tab(Globals.TAB * 2) + "DROP\n";
                string str = Globals.tab(Globals.TAB * 3) + " CONSTRAINT FK_" + fk.ID_ForeignKey + "_in_" + TableName + ";";// FOREIGN KEY([" + fk.ID_ForeignKey + "]) REFERENCES [dbo].[" + fk.ReferenceTable + "] ([" + fk.ReferenceTable_Column + "]);\n";
                SQL = SQL + str;
            }
            return SQL;
        }

        public string SQLcmd_DropTable()
        {
           return @"
                DROP TABLE [dbo].[" + this.TableName + @"];
            ";
        }

        public string MySQLcmd_DropTable()
        {
            return @"
                DROP TABLE " + this.TableName + ";\n";
        }

        public string SQLitecmd_DropTable()
        {
            return @"
                DROP TABLE " + this.TableName + ";\n";
        }

        private string SetString(string s)
        {
            return "'" + s + "'";
        }


        private bool InsertIntoSQLITE(DBConnection xcon, List<Col_class> lColVar,ref List<SQL_Parameter> lsqlPar, ref Int64 ID_returned,ref  string csError)
        {
            // simply insert
            string sqlinsert = "";
            int i;
            
            string sInsertTo = "\nINSERT INTO " + TableName + "\n(\n";

            i = 0;
            foreach (Col_class cvar in lColVar)
            {
                if (i == 0)
                {
                    sInsertTo = sInsertTo + cvar.sColName;
                    i++;
                }
                else
                {
                    sInsertTo = sInsertTo + ",\n" + cvar.sColName;
                }
            }
            sInsertTo = sInsertTo + "\n)\n VALUES\n(\n";
            i = 0;
            foreach (Col_class cvar in lColVar)
            {
                if (i == 0)
                {
                    sInsertTo = sInsertTo + cvar.sValue;
                    i++;
                }
                else
                {
                    sInsertTo = sInsertTo + ",\n" + cvar.sValue;
                }
            }
            sqlinsert  = "";
            sqlinsert += sInsertTo;
            sqlinsert += "\n);";
            Int64 newID = 0;
            object ObjRet = null;

            if (xcon.ExecuteNonQuerySQLReturnID(sqlinsert, lsqlPar, ref newID, ref ObjRet, ref csError, TableName))
            {
                if (newID >= 0)
                {
                    ID_returned = newID;
                    return true;
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
        public bool SQLcmd_InsertInto_SQLITE(DBConnection xcon,string PrevVar, ref string sVarID, /*ref List<SQL_Parameter> lsqlPar,*/ List<SQLTable> lTable,ref bool bSomethingDefined, ref Int64 ID_returned, ref string csError)
        {
            int i = 0;

            string sqlSelect = "SELECT ID FROM " + TableName;

            int iCol = 0;
            int iCount = Column.Count();

            List<Col_class> lColVar = new List<Col_class>();
            List<SQL_Parameter> lsqlPar = new List<SQL_Parameter>();

            List<string> lCol = new List<string>();
            List<string> lVar = new List<string>();
            for (iCol = 0; iCol < iCount; iCol++)
            {
                Column col = Column[iCol];
                if (!col.IsIdentity)
                {
                    //if (col.SetType == SQLTableControl.Column.ValueSetTYPE.SET_MUST)
                    //{

                    Col_class ColVar = null;;

                    if (col.fKey != null)
                    {
                        Int64 IDfKey = 0;
                        string sVarfKeyID = "";
                        bool bSomethingDefinedInChildTable = false;
                        if (col.fKey.fTable.SQLcmd_InsertInto_SQLITE(xcon, sThisVar, ref sVarfKeyID, /*ref lsqlPar,*/ lTable,ref bSomethingDefinedInChildTable, ref IDfKey, ref csError))
                        {
                            if (bSomethingDefinedInChildTable)
                            {
                                DBTypes.DBtypesFunc.ID_Is_Defined(col.obj);
                                ColVar = new Col_class(col.Name, IDfKey.ToString(), col.flags);
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (col.Name.Equals("ImageData"))
                        {
                            i = 1;
                        }

                        if (DBTypes.DBtypesFunc.IsValueDefined(col.obj))
                        {
                            ColVar = new Col_class(col.Name, DBTypes.DBtypesFunc.DbValueForSql(ref col.obj, col.BasicType(), this.sThisVar, ref lsqlPar, col.Name), col.flags);
                        }

                    }

                    if (ColVar!=null)
                    {
                        lColVar.Add(ColVar);
                    }
                    //}
                }
            }


            if (lColVar.Count == 0)
            {
                bSomethingDefined = false;
                return true;
            }
            else
            {
                bSomethingDefined = true;
            }

            if ((flags & SQLTableControl.Column.Flags.FILTER)!=0)
            {
                string sWhere = "";
                i = 0;
                foreach (Col_class cvar in lColVar)
                {
                    if ((cvar.m_Flags & SQLTableControl.Column.Flags.FILTER)!=0)
                    {
                        if (i == 0)
                        {
                            sWhere += "\n WHERE \n";
                            sWhere = sWhere + cvar.sColName + " = " + cvar.sValue;
                            i++;
                        }
                        else
                        {
                            sWhere = sWhere + "\n  AND " + cvar.sColName + " = " + cvar.sValue;
                        }
                    }
                }

                StringBuilder sqlinsert = new StringBuilder(sqlSelect);
                sqlinsert.Append(sWhere + "\n");
                int newID = -1;
                Object ObjRet = null;
                if (xcon.ExecuteQuerySQL(sqlinsert, lsqlPar, ref newID, ref ObjRet, ref csError,TableName))
                {
                    if ((ObjRet!=null)&&(newID >= 0))
                    {
                        ID_returned = newID;
                        return true;
                    }
                    else
                    {
                        return InsertIntoSQLITE(xcon, lColVar, ref  lsqlPar, ref ID_returned, ref  csError);
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return InsertIntoSQLITE(xcon, lColVar, ref  lsqlPar, ref ID_returned, ref  csError);
            }
        }

//************************** MSSQL

        public void SQLcmd_Insert_MSSQL(ref StringBuilder sqlinsert, string PrevVar, ref string sVarID, ref List<SQL_Parameter> lsqlPar, List<SQLTable> lTable,int iNestingLevel)
        {
            int i = 0;
            iNestingLevel++;
            sThisVar = PrevVar + "_" + GetStringIndex(TableName, lTable);

            //if (this.TableName.Equals("evl_Picture"))
            //{
            //    i=0;
            //}

            string sqlHead =  "\n\nDECLARE @" + sThisVar + " bigint \n";
            string sqlSelect =  "SELECT @" +sThisVar + " = ID FROM " + TableName;

            int iCol = 0;
            int iCount = Column.Count();
            List<Col_class> lColVar = new List<Col_class>();
            List<string> lCol = new List<string>();
            List<string> lVar = new List<string>();
            for (iCol = 0; iCol < iCount; iCol++)
            {
                Column col = Column[iCol];
                if (!col.IsIdentity)
                {
                    //if (col.SetType == SQLTableControl.Column.ValueSetTYPE.SET_MUST)
                    //{

                        Col_class ColVar;

                        if (col.fKey != null)
                        {

                            string sVarfKeyID = "";

                            col.fKey.fTable.SQLcmd_Insert_MSSQL(ref sqlinsert, sThisVar, ref sVarfKeyID, ref lsqlPar, lTable, iNestingLevel);

                            ColVar = new Col_class(col.Name, "@" + sVarfKeyID, col.flags);

                        }
                        else
                        {
                           
                            ColVar = new Col_class(col.Name, DBTypes.DBtypesFunc.DbValueForSql(ref col.obj, col.BasicType(), this.sThisVar, ref lsqlPar, col.Name), col.flags);

                        }
                        lColVar.Add(ColVar);
                    //}
                }
            }

            sqlinsert.Append(sqlHead);

            string sWhere_Condition_Error_Report = "";

            if ((flags & SQLTableControl.Column.Flags.FILTER)!=0)
            {
                string sWhere = "";
                i = 0;
                foreach (Col_class cvar in lColVar)
                {
                    if ((cvar.m_Flags & SQLTableControl.Column.Flags.FILTER)!=0)
                    {
                        string sPossibleErrorValue = "";
                        if (i == 0)
                        {
                            sWhere += "\n WHERE \n";
                            sWhere = sWhere + cvar.sColName + " = " + cvar.sValue;
                            if (iNestingLevel == 1)
                            {
                                if (cvar.sValue[0]=='@')
                                {
                                    sPossibleErrorValue = DBtypesFunc.GetValueToString(cvar.sValue, lsqlPar);
                                }
                                else
                                {
                                    sPossibleErrorValue = cvar.sValue;
                                }
                                sWhere_Condition_Error_Report = sWhere_Condition_Error_Report + cvar.sColName + " = " + sPossibleErrorValue;
                            }
                            i++;
                        }
                        else
                        {
                            sWhere = sWhere + "\n  AND " + cvar.sColName + " = " + cvar.sValue;
                            if (iNestingLevel == 1)
                            {
                                if (cvar.sValue[0] == '@')
                                {
                                    sPossibleErrorValue = DBtypesFunc.GetValueToString(cvar.sValue, lsqlPar);
                                }
                                else
                                {
                                    sPossibleErrorValue = cvar.sValue;
                                }
                                sWhere_Condition_Error_Report = sWhere_Condition_Error_Report + cvar.sColName + " = " + sPossibleErrorValue;
                            }
                        }
                    }
                }
                sqlinsert.Append(sqlSelect);
                sqlinsert.Append(sWhere+"\n");
                string sIF = "\nIF @" + sThisVar + " IS NULL\nBEGIN";
                sqlinsert.Append(sIF);
            }

            string sInsertTo = "\nINSERT INTO " + TableName + "\n(\n";

            i = 0;
            foreach (Col_class cvar in lColVar)
            {
                if (i == 0)
                {
                    sInsertTo = sInsertTo + cvar.sColName;
                    i++;
                }
                else
                {
                    sInsertTo = sInsertTo + ",\n" + cvar.sColName;
                }
            }
            sInsertTo = sInsertTo + "\n)\n VALUES\n(\n";
            i = 0;
            foreach (Col_class cvar in lColVar)
            {
                if (i == 0)
                {
                    sInsertTo = sInsertTo + cvar.sValue;
                    i++;
                }
                else
                {
                    sInsertTo = sInsertTo + ",\n" + cvar.sValue;
                }
            }
            sInsertTo = sInsertTo + "\n) SET @" + sThisVar + "= SCOPE_IDENTITY() \n";

            if ((flags & SQLTableControl.Column.Flags.FILTER)!=0)
            {
                sInsertTo = sInsertTo + "END\n";
                if (iNestingLevel == 1)
                {
                    sInsertTo = sInsertTo + "ELSE\n";
                    sInsertTo = sInsertTo + "BEGIN\n";
                    sInsertTo = sInsertTo + @" DECLARE @ErrorVariable NVARCHAR(1000);
                                                SET @ErrorVariable = N'" + lngRPM.s_Error_Insert_Unique.s + sWhere_Condition_Error_Report + lngRPM.s_Error_Insert_Unique_the_same_allready_exists_at_id.s+ @"';
                                                RAISERROR (@ErrorVariable, -- Message text.
                                                11, -- Severity,
                                                 1, -- State
                                                N'" + TableName + @"',
                                                "+ "@" +sThisVar + ")";
                    sInsertTo = sInsertTo + "\nEND\n";
                }
            }
            
            sqlinsert.Append(sInsertTo);
            sVarID = sThisVar;
        }

//************************** MYSQL **************************
        public void SQLcmd_Insert_MYSQL(ref StringBuilder sqlinsert, string PrevVar, ref string sVarID, ref List<SQL_Parameter> lsqlPar, List<SQLTable> lTable)
        {
            int i = 0;

            sThisVar = PrevVar + "_" + GetStringIndex(TableName, lTable);

            //if (this.TableName.Equals("evl_Picture"))
            //{
            //    i=0;
            //}

            string sqlHead = "\n\nDECLARE @" + sThisVar + " bigint; \n";
            string sqlSelect = "SELECT @" + sThisVar + " = ID FROM " + TableName;

            int iCol = 0;
            int iCount = Column.Count();
            List<Col_class> lColVar = new List<Col_class>();
            List<string> lCol = new List<string>();
            List<string> lVar = new List<string>();
            for (iCol = 0; iCol < iCount; iCol++)
            {
                Column col = Column[iCol];
                if (!col.IsIdentity)
                {
                    //if (col.SetType == SQLTableControl.Column.ValueSetTYPE.SET_MUST)
                    //{

                    Col_class ColVar;

                    if (col.fKey != null)
                    {

                        string sVarfKeyID = "";

                        col.fKey.fTable.SQLcmd_Insert_MYSQL(ref sqlinsert, sThisVar, ref sVarfKeyID, ref lsqlPar, lTable);

                        ColVar = new Col_class(col.Name, "@" + sVarfKeyID, col.flags);

                    }
                    else
                    {
                        if (col.Name.Equals("ImageData"))
                        {

                            i = 1;

                        }

                        ColVar = new Col_class(col.Name, DBTypes.DBtypesFunc.DbValueForSql(ref col.obj, col.BasicType(), this.sThisVar, ref lsqlPar, col.Name), col.flags);

                    }
                    lColVar.Add(ColVar);
                    //}
                }
            }

            sqlinsert.Append(sqlHead);

            if ((flags & SQLTableControl.Column.Flags.FILTER) != 0)
            {
                string sWhere = "";
                i = 0;
                foreach (Col_class cvar in lColVar)
                {
                    if ((cvar.m_Flags & SQLTableControl.Column.Flags.FILTER) != 0)
                    {
                        if (i == 0)
                        {
                            sWhere += "\n WHERE \n";
                            sWhere = sWhere + cvar.sColName + " = " + cvar.sValue;
                            i++;
                        }
                        else
                        {
                            sWhere = sWhere + "\n  AND " + cvar.sColName + " = " + cvar.sValue;
                        }
                    }
                }
                sqlinsert.Append(sqlSelect);
                sqlinsert.Append(sWhere + "\n");
                string sIF = "\nIF @" + sThisVar + " IS NULL\nBEGIN";
                sqlinsert.Append(sIF);
            }

            string sInsertTo = "\nINSERT INTO " + TableName + "\n(\n";

            i = 0;
            foreach (Col_class cvar in lColVar)
            {
                if (i == 0)
                {
                    sInsertTo = sInsertTo + cvar.sColName;
                    i++;
                }
                else
                {
                    sInsertTo = sInsertTo + ",\n" + cvar.sColName;
                }
            }
            sInsertTo = sInsertTo + "\n)\n VALUES\n(\n";
            i = 0;
            foreach (Col_class cvar in lColVar)
            {
                if (i == 0)
                {
                    sInsertTo = sInsertTo + cvar.sValue;
                    i++;
                }
                else
                {
                    sInsertTo = sInsertTo + ",\n" + cvar.sValue;
                }
            }
            sInsertTo = sInsertTo + "\n) SET @" + sThisVar + "= SCOPE_IDENTITY();\n";

            if ((flags & SQLTableControl.Column.Flags.FILTER) != 0)
            {
                sInsertTo = sInsertTo + "END\n";
            }
            sqlinsert.Append(sInsertTo);
            sVarID = sThisVar;
        }

        internal string GetStringIndex(string TableName, List<SQLTable> lTable)
        {
            int iCount = lTable.Count;
            int i;
            for (i = 0; i < iCount; i++)
            {
                if (lTable[i].TableName.Equals(TableName))
                {
                    return i.ToString();
                }
            }
            MessageBox.Show("ERROR GetStringIndex(string TableName, List<SQL_Table> lTable)");
            return "ERROR";
        }




        public void CreateTableTree(List<SQLTable> lTable)
        {
            SQLTable sqlTbl;
            SQLTable rfTable;
            foreach (Column col in Column)
            {
                if (col.fKey != null)
                {
                    if (Globals.FindTable(out rfTable, col.fKey.refInListOfTables.TableName, lTable))
                    {
                        sqlTbl = new SQLTable(rfTable);
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

        public void SetColumnValues(Object xTable)
        {
            //this.objTable = xTable;

            Type this_class = xTable.GetType();
            FieldInfo[] this_class_fields = this_class.GetFields();

            foreach (Column col in Column)
            {
                if (col.fKey != null)
                {
                    int i;
                    int iCount = this_class_fields.Count();
                    for (i = 0; i < iCount; i++)
                    {
                        //string field_name = this_class_fields[i].GetValue(xTable).GetType().ToString();
                        //if (col.fKey.refTable.TableName.Equals(field_name))
                        if (col.fKey.fTable.objTable.GetType() == this_class_fields[i].GetValue(xTable).GetType())
                        {
                            object yTable = this_class_fields[i].GetValue(xTable);
                            col.fKey.fTable.SetColumnValues(yTable);
                        }
                    }
                }
                SetReference(col, xTable);
            }
        }

        private void SetReference(SQLTableControl.Column col, Object xTable)
        {
            Type this_class = xTable.GetType();
            FieldInfo[] this_class_fields = this_class.GetFields();
            int i;
            int iCount = this_class_fields.Count();
            for (i = 0; i < iCount; i++)
            {
                string field_name = this_class_fields[i].Name;
                if (col.Name.Equals(field_name))
                {
                    //Type basetype = this_class_fields[i].GetType().BaseType;
                    //Object obj = basetype.GetVa
                    col.obj = this_class_fields[i].GetValue(xTable);
                }
            }
        }

        private void SetReference(SQLTableControl.Column col)
        {
            Type this_class = this.objTable.GetType();
            FieldInfo[] this_class_fields = this_class.GetFields();
            int i;
            int iCount = this_class_fields.Count();
            for (i = 0; i < iCount; i++)
            {
                string field_name = this_class_fields[i].Name;
                if (col.Name.Equals(field_name))
                {
                    //Type basetype = this_class_fields[i].GetType().BaseType;
                    //Object obj = basetype.GetVa
                    col.obj = this_class_fields[i].GetValue(this.objTable);
                }
            }
        }
 

        public void CreateImportExportTemplate(string sParentKeys, ref StringBuilder sExportImportTamplate)
        {
            int iCol = 0;
            int iCount = Column.Count();
            for (iCol = 0; iCol < iCount; iCol++)
            {
                Column col = Column[iCol];
                if (!col.IsIdentity)
                {
                    if (col.fKey != null)
                    {
                        string sKey;

                        sKey = sParentKeys + "*" + col.fKey.refInListOfTables.TableName + ">";

                        col.fKey.fTable.CreateImportExportTemplate(sKey, ref sExportImportTamplate);


                    }
                    else
                    {
                        string sImportExportLine;
                        if (col.IsNumber())
                        {
                           sImportExportLine = sParentKeys + col.Name + ",\n";
                        }
                        else
                        {
                           sImportExportLine = sParentKeys + col.Name + ",\"\"\n";
                        }
                        sExportImportTamplate.Append(sImportExportLine);
                    }
                }
            }
        }

        public void CreateEditControls(MyTabControl xTabControl,TabPage xTabPage)
        {
            int iCol = 0;
            int iCount = Column.Count();
            for (iCol = 0; iCol < iCount; iCol++)
            {
                Column col = Column[iCol];
                if (!col.IsIdentity)
                {
                    if (col.fKey != null)
                    {
                        //if (col.fKey.fTable.Column.Count > 2)
                        //{
                            col.fKey.TabPage = new TabPage(col.fKey.fTable.lngTableName.s);
                            col.fKey.TabPage.BorderStyle = BorderStyle.Fixed3D;
                            xTabControl.TabPages.Add(col.fKey.TabPage);
                            col.fKey.fTable.TabControl = new MyTabControl(col.fKey.TabPage, this.edtCtrlList);
                            col.fKey.fTable.CreateEditControls(col.fKey.fTable.TabControl, col.fKey.TabPage);
                        //}
                        //else
                        //{
                        //    // insert EditControl

                        //}
                    }
                    else
                    {
                        EditControl edtCtrl = new EditControl(xTabPage, col, this.edtCtrlList);

                    }
                }
            }
        }

        public void RepositionEditControls(MyTabControl xTabControl, TabPage xTabPage)
        {
            int iCol = 0;
            int iCount = Column.Count();
            for (iCol = 0; iCol < iCount; iCol++)
            {
                Column col = Column[iCol];
                if (!col.IsIdentity)
                {
                    if (col.fKey != null)
                    {
                        //if (col.fKey.fTable.Column.Count > 2)
                        //{
                        int xCount = this.edtCtrlList.Count;
                        if (xCount > 0)
                        {
                            int iLastIndex = xCount - 1;
                            col.fKey.fTable.TabControl.Top = this.edtCtrlList[iLastIndex].y + this.edtCtrlList[iLastIndex].height;
                        }
                        col.fKey.fTable.RepositionEditControls(col.fKey.fTable.TabControl, col.fKey.TabPage);
                        //}
                        //else
                        //{
                        //    // insert EditControl

                        //}
                    }
                    else
                    {
                    }
                }
            }
        }



        public bool GetRandomData(usrc_myGroupBox pmyGroupBox, ref bool bGenderMan, SQLTable.delegate_GetInputControlRandomData ControlRandomData, bool bMen)
        {

               foreach (MyControl ctrl in pmyGroupBox.controls)
               {

                   if (ctrl.Control.GetType() == typeof(usrc_myGroupBox))
                   {
                       usrc_myGroupBox pGrpBox = (usrc_myGroupBox)ctrl.Control;

                       GetRandomData(pGrpBox, ref bGenderMan, ControlRandomData, bGenderMan);
                   }
                   else if (ctrl.Control.GetType() == typeof(usrc_InputControl))
                   {

                       usrc_InputControl pInputControl = (usrc_InputControl)ctrl.Control;

                       pInputControl.GetRandomData(this,ControlRandomData,bMen);

                   }
                   else
                   {
                       MessageBox.Show("Program Error in RepositionInputControls(MyGroupBox pmyGroupBox)");
                       return false;
                   }
               }
               return true;
        }

        public List<string>  GetInputControlsData()
        {
            List<string> Line = new List<string>();
            Line.Add("<" + this.TableName + ">");
            if (this.inpCtrlList.Count > 0)
            {
                foreach (usrc_InputControl inpctrl in inpCtrlList)
                {
                   inpctrl.GetStringDataDataLine(ref Line);
                }
                Line.Add("</" + this.TableName + ">");
            }
            else
            {
                MessageBox.Show(lngRPM.s_ErrorNoData.s);
            }
            return Line;
        }

        public bool SQLcmd_InsertInto(DBConnection xcon, List<SQLTable> lTable, ref string csError, StringBuilder m_strSQLUseDatabase, ref Int64 ID)
        {
            List<SQL_Parameter> lsqlPar = new List<SQL_Parameter>();
            if (xcon.DBType == DBConnection.eDBType.SQLITE)
            {
                string PrevVar = this.TableName;
                string sVarID = "";
                ID = -1;
                bool bSomethingDefined = false;
                if (SQLcmd_InsertInto_SQLITE(xcon, PrevVar, ref sVarID,/* ref  lsqlPar,*/ lTable,ref bSomethingDefined, ref ID, ref csError))
                {
                    if (ID != -1)
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
                    return false;
                }
            }
            else if (xcon.DBType == DBConnection.eDBType.MSSQL)
            {
                StringBuilder sqlinsert = new StringBuilder("");
                string PrevVar = this.TableName;
                string sVarID = "";
                SQLcmd_Insert_MSSQL(ref sqlinsert, PrevVar, ref sVarID, ref  lsqlPar, lTable,0);
                Object oResult = -1;
                SQL_Parameter par_ReturnID = new SQL_Parameter("@ReturnID"+sVarID, SQL_Parameter.eSQL_Parameter.Bigint,true,oResult);
                lsqlPar.Add(par_ReturnID);
                sqlinsert.Append("\r\n set  " + par_ReturnID.Name + " = @" + sVarID);
                if (xcon.ExecuteNonQuerySQL(sqlinsert.ToString(), lsqlPar,ref oResult, ref csError))
                {
                    int iCount = lsqlPar.Count();
                    if (xcon.DBType == DBConnection.eDBType.MSSQL)
                    {
                      ID = Convert.ToInt64(lsqlPar[iCount - 1].MS_SqlSqlParameter.Value);
                    }
                    lsqlPar.Clear();
                    sqlinsert.Remove(0, sqlinsert.Length);
                    sqlinsert.Append(m_strSQLUseDatabase.ToString());
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (xcon.DBType == DBConnection.eDBType.MYSQL)
            {
                StringBuilder sqlinsert = new StringBuilder("");
                string PrevVar = this.TableName;
                string sVarID = "";
                SQLcmd_Insert_MYSQL(ref sqlinsert, PrevVar, ref sVarID, ref  lsqlPar, lTable);
                Object oResult = -1;
                SQL_Parameter par_ReturnID = new SQL_Parameter("@ReturnID" + sVarID, SQL_Parameter.eSQL_Parameter.Bigint, true, oResult);
                lsqlPar.Add(par_ReturnID);
                sqlinsert.Append("\r\n set  " + par_ReturnID.Name + " = @" + sVarID);
                DBConnectionControl40.DynSettings.bPreviewSQLBeforeExecution = true;
                if (xcon.ExecuteNonQuerySQL(sqlinsert.ToString(), lsqlPar, ref oResult, ref csError))
                {
                    int iCount = lsqlPar.Count();
                    if (xcon.DBType == DBConnection.eDBType.MSSQL)
                    {
                        ID = Convert.ToInt64(lsqlPar[iCount - 1].MS_SqlSqlParameter.Value);
                    }
                    lsqlPar.Clear();
                    sqlinsert.Remove(0, sqlinsert.Length);
                    sqlinsert.Append(m_strSQLUseDatabase.ToString());
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:SQLcmd_InsertInto :xcon.DBType = " + xcon.DBType.ToString());
                return false;
            }
        }

        public Column FindColumn(Type type)
        {
            foreach (Column col in Column)
            {
                if (col.obj.GetType() == type)
                {
                    return col;
                }
            }
            return null;
        }


    }

    public class MySize
    {
        public int cx;
        public int cy;
    }
}

