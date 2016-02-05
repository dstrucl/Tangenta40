#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using DBTypes;
using System.Windows.Forms;
using LanguageControl;
using DBConnectionControl40;
using StaticLib;
using LogFile;

namespace SQLTableControl
{
    

    public class Column
    {
        public enum Flags : int
        {
            DUPLICATE = 0x00,
            FILTER = 0x01,
            UNIQUE = 0x08,
            FILTER_AND_UNIQUE = FILTER | UNIQUE
        }

        public enum eStyle
        {
                           none,
                           TextBox,
                           TextBox_ReadOnly,
                           Label,             // read only
                           RichTextBox,
                           NumericUpDown,
                           PictureBox,
                           RadioButtons,
                           CheckBox,
                           DateTimePicker, // Now - default
                           FileSelection,
                           DateTimePicker_MinDate,
                           DateTimePicker_Now,
                           DateTimePicker_ReadOnly,
                           DateTimeNow,
                           DateTimeOfDocument,
                           Document,
                           DataBox,
                           DocumentSource,
                           CheckBox_default_true,
                           ReadOnly_CheckBox_default_true,
                           ReadOnlyTable
        };

        public bool IsIdentity = false;
        public enum ValueSetTYPE { SET_NOTHING, SET_MUST, SET_DEFINED };
        public enum nullTYPE { NULL, NOT_NULL };


        public Object obj = null;
        public nullTYPE nulltype;
        public Flags flags;
        public eStyle Style;

        public SQLTable ownerTable;

        //        public Object Value = null;
        //public ValueSetTYPE SetType = ValueSetTYPE.SET_NOTHING;
        public ForeignKey fKey = null;

        public string Name;

        public ltext Name_in_language = null;

        public usrc_InputControl InputControl = null;

        public DefineView_InputControl DefineView_InputControl = null;

        public Object SetObject(Object obj)
        {
            Type ytyp = obj.GetType();
            return Globals.GetNewObject(ytyp);
        }

        public Column(Column c)
        {
            obj = SetObject(c.obj);
            nulltype = c.nulltype;
            Style = c.Style;
            flags = c.flags;
            IsIdentity = c.IsIdentity;
            ownerTable = c.ownerTable;
            Name = c.Name;
            //            Value = c.Value;

            //SetType = c.SetType;
            if (c.fKey != null)
            {
                fKey = new ForeignKey(c.fKey);
            }

            Name_in_language = c.Name_in_language;
            //Name_in_language = new ltext();

            //int iCount = c.Name_in_language.sText.Length;
            //for (int i = 0; i < iCount; i++)
            //{
            //    Name_in_language.sText(i) = c.Name_in_language.sText(i);
            //}

        }

        public Column(Column c,SQLTable DBm_owner_Table,List<SQLTable> lTable) //this constructor is used only for DBm_Image and DBm_Document table trees
        {
            obj = SetObject(c.obj);
            nulltype = c.nulltype;
            Style = c.Style;
            flags = c.flags;
            IsIdentity = c.IsIdentity;
            ownerTable = c.ownerTable;
            Name = c.Name;
            //            Value = c.Value;

            //SetType = c.SetType;
            if (c.fKey != null)
            {
                fKey = new ForeignKey(c.fKey, DBm_owner_Table, lTable);
            }
            Name_in_language = c.Name_in_language;
            //Name_in_language = new ltext();
            //int iCount = c.Name_in_language.sText.Length;

            //for (int i = 0; i < iCount;i++)
            //{
            //    Name_in_language.sText(i) = c.Name_in_language.sText(i);
            //}

        }

        public Column(SQLTable owner,Object xObj, nullTYPE xType, Flags xflags, eStyle styl, ltext Name_in_lang)
        {
            Style = styl;
            fKey = null;
            obj = xObj;
            nulltype = xType;
            flags = xflags;
           // int i = 0;
            int iCount = Name_in_lang.sText_Length;
            this.ownerTable = owner;

            Name = StaticLib.Func.GetNameFromObjectType(obj);
            if (obj.GetType() == typeof(ID))
            {
                IsIdentity = true;
            }

            Name_in_language = Name_in_lang; 
            //Name_in_language = new ltext();

            //for (i = 0; i < iCount; i++)
            //{
            //    Name_in_language.sText(i)=Name_in_lang.sText(i);
            //}
        }


        public string AddForeignKey(ref List<ForeignKey> m_Fkey, SQLTable fTbl, ref ForeignKey fk)
        {
            string columnName = this.Name; //Func.GetNameFromObjectType(obj);
            fk.ID_ForeignKey = columnName;
            Name = columnName;
            fk.ReferenceTable = fTbl.TableName;
            fk.ReferenceTable_Column = "ID";
            fk.refInListOfTables = fTbl;
            m_Fkey.Add(fk);
            return "[" + fk.ID_ForeignKey + "] ";
        }

        public string AddForeignKeyMySQL(ref List<ForeignKey> m_Fkey, SQLTable fTbl, ref ForeignKey fk)
        {
            string columnName = this.Name; //Func.GetNameFromObjectType(obj);
            fk.ID_ForeignKey = columnName;
            Name = columnName;
            fk.ReferenceTable = columnName;
            fk.ReferenceTable_Column = "ID";
            fk.refInListOfTables = fTbl;
            m_Fkey.Add(fk);
            return "`" + fk.ID_ForeignKey + "`";
        }

        public string AddForeignKeySQLite(ref List<ForeignKey> m_Fkey, SQLTable fTbl, ref ForeignKey fk)
        {
            string columnName = this.Name; //Func.GetNameFromObjectType(obj);
            fk.ID_ForeignKey = columnName;
            Name = columnName;
            fk.ReferenceTable = columnName;
            fk.ReferenceTable_Column = "ID";
            fk.refInListOfTables = fTbl;
            m_Fkey.Add(fk);
            return " " + fk.ID_ForeignKey + " ";
        }


        public string GetColumnDefinitionLine(DBTableControl dbTables, ref List<ForeignKey> m_Fkey,  List<string> UniqueConstraintNameList, ref string sql_DBm, SQLTable DBm_owner_Table)
        {
            SQLTable refTable = null;
            SQLTable new_ref_Table = null;
            if (obj != null)
            {
                string columnName = StaticLib.Func.GetNameFromObjectType(obj);
                this.Name = columnName;
                string sBasicType = null;
                // complex types
                string strNull;
                if (nulltype == nullTYPE.NOT_NULL)
                {
                    strNull = " NOT NULL";
                }
                else
                {
                    strNull = " NULL";
                }

                if (obj.GetType() == typeof(ID))
                {
                    ID ID = (ID)obj;
                    return Globals.LeftMargin + "[" + columnName + "] " + DBtypesFunc.GetBasicType(obj) + " IDENTITY(1,1)" + strNull;
                }
                else if (dbTables.IsMyTable(out refTable,obj.GetType()))
                {

                    if (DBtypesFunc.Is_DBm_Type(refTable.objTable))
                    {
                        if (DBm_owner_Table == null)
                        {
                            DBm_owner_Table = this.ownerTable;
                        }
                        new_ref_Table = new SQLTable(refTable, DBm_owner_Table, dbTables.items);
                        dbTables.items.Add(new_ref_Table);

                        string new_sql_DBm = new_ref_Table.MSSQLcmd_CreateTable(dbTables, UniqueConstraintNameList, ref sql_DBm, DBm_owner_Table);
                        sql_DBm += new_sql_DBm;

                        refTable = new_ref_Table;
                        this.Name = refTable.TableName;
                        int iCount = this.Name_in_language.sText_Length;
                        for (int i = 0; i < iCount; i++)
                        {
                            this.Name_in_language.sText(i, refTable.lngTableName.sText(i) + ":" + this.Name_in_language.sText(i));
                        }
                    }
                    this.Name = this.Name + "_ID";
                    string str;
                    ForeignKey fk = new ForeignKey();
                    object obj_reftable_id = refTable.FindIdentityObject();
                    string sIdentityType;
                    if (obj_reftable_id != null)
                    {
                        sIdentityType = " " + DBtypesFunc.GetBasicType(obj_reftable_id)+ " ";
                    }
                    else
                    {
                        sIdentityType = " [" + Globals.m_IdentityIndexTYPE + "]";
                    }

                    str = Globals.LeftMargin + AddForeignKey(ref m_Fkey, refTable, ref fk) + sIdentityType + strNull;
                    fKey = fk;
                    return str;
                }
                else
                {
                     sBasicType = DBTypes.DBtypesFunc.GetBasicType(obj);
                }
                return Globals.LeftMargin + "[" + columnName + "] " + sBasicType + strNull;
            }
            else
            {
                return "!!!Object Is Null!!!";
            }
        }

        public string GetColumnMySQLDefinitionLine(DBTableControl dbTables, ref List<ForeignKey> m_Fkey, List<string> UniqueConstraintNameList, ref string sql_DBm, SQLTable DBm_owner_Table)
        {
            SQLTable refTable = null;
            SQLTable new_ref_Table = null;
            if (obj != null)
            {
                string columnName = StaticLib.Func.GetNameFromObjectType(obj);
                this.Name = columnName;
                string sBasicType = null;
                // complex types
                string strNull;
                if (nulltype == nullTYPE.NOT_NULL)
                {
                    strNull = " NOT NULL";
                }
                else
                {
                    strNull = " NULL";
                }

                if (obj.GetType() == typeof(ID))
                {
                    ID ID = (ID)obj;
                    return Globals.LeftMargin + "`" + columnName + "` " + DBtypesFunc.GetBasicTypeMySQL(obj) +" unsigned NOT NULL AUTO_INCREMENT";
                }
                else if (dbTables.IsMyTable(out refTable, obj.GetType()))
                {
                    if (DBtypesFunc.Is_DBm_Type(refTable.objTable))
                    {
                        if (DBm_owner_Table == null)
                        {
                            DBm_owner_Table = this.ownerTable;
                        }
                        new_ref_Table = new SQLTable(refTable, DBm_owner_Table, dbTables.items);
                        dbTables.items.Add(new_ref_Table);

                        string new_sql_DBm = new_ref_Table.MySQLcmd_CreateTable(dbTables, UniqueConstraintNameList, ref sql_DBm, DBm_owner_Table);
                        sql_DBm += new_sql_DBm;

                        refTable = new_ref_Table;
                        this.Name = refTable.TableName;
                        int iCount = this.Name_in_language.sText_Length;
                        for (int i = 0; i < iCount; i++)
                        {
                            this.Name_in_language.sText(i,refTable.lngTableName.sText(i) + "_" + this.Name_in_language.sText(i));
                        }
                    }
                     this.Name =  this.Name  + "_ID";
                    string str;
                    ForeignKey fk = new ForeignKey();
                    object obj_reftable_id = refTable.FindIdentityObject();
                    string sIdentityType;
                    if (obj_reftable_id != null)
                    {
                        sIdentityType = " " + DBtypesFunc.GetBasicTypeMySQL(obj_reftable_id) + " ";
                    }
                    else
                    {
                        sIdentityType = " [" + Globals.m_IdentityIndexTYPE + "]";
                    }

                    str = Globals.LeftMargin + AddForeignKeyMySQL(ref m_Fkey, refTable, ref fk) + " " + sIdentityType + " unsigned " + strNull;
                    fKey = fk;
                    return str;
                }
                else
                {
                    sBasicType = DBTypes.DBtypesFunc.GetBasicTypeMySQL(obj);
                }
                return Globals.LeftMargin + "`" + columnName + "` " + sBasicType + strNull;
            }
            else
            {
                return "!!!Object Is Null!!!";
            }
        }

        public string GetColumnSQLiteDefinitionLine(DBTableControl dbTables, ref List<ForeignKey> m_Fkey, List<string> UniqueConstraintNameList, ref string sql_DBm, SQLTable DBm_owner_Table)
        {
            SQLTable refTable = null;
            SQLTable new_ref_Table = null;
            if (obj != null)
            {
                string columnName = StaticLib.Func.GetNameFromObjectType(obj);
                this.Name = columnName;
                string sBasicType = null;
                // complex types
                string strNull;
                if (nulltype == nullTYPE.NOT_NULL)
                {
                    strNull = " NOT NULL";
                }
                else
                {
                    strNull = " NULL";
                }

                string strUNIQUE;
                if ((this.flags & Flags.UNIQUE)!=0)
                {
                    strUNIQUE = " UNIQUE ";
                }
                else
                {
                    strUNIQUE = "";
                }


                if (obj.GetType() == typeof(ID))
                {
                    ID ID = (ID)obj;
                    return Globals.LeftMargin + "'" + columnName + "' INTEGER PRIMARY KEY AUTOINCREMENT";
                }
                else if (dbTables.IsMyTable(out refTable, obj.GetType()))
                {

                    if (DBtypesFunc.Is_DBm_Type(refTable.objTable))
                    {
                        if (DBm_owner_Table == null)
                        {
                            DBm_owner_Table = this.ownerTable;
                        }
                        new_ref_Table = new SQLTable(refTable, DBm_owner_Table, dbTables.items);
                        dbTables.items.Add(new_ref_Table);

                        string new_sql_DBm = new_ref_Table.SQLitecmd_CreateTable(dbTables, UniqueConstraintNameList, ref sql_DBm, DBm_owner_Table);
                        sql_DBm += new_sql_DBm;

                        refTable = new_ref_Table;
                        this.Name = refTable.TableName;
                        int iCount = this.Name_in_language.sText_Length;
                        for (int i = 0; i < iCount; i++)
                        {
                            this.Name_in_language.sText(i,refTable.lngTableName.sText(i) + ":" + this.Name_in_language.sText(i));
                        }
                    }
                    this.Name = this.Name + "_ID";
                    string str;
                    ForeignKey fk = new ForeignKey();
                    str = Globals.LeftMargin + AddForeignKeySQLite(ref m_Fkey, refTable, ref fk) + " INTEGER " + strNull + " REFERENCES " + refTable.TableName + "(ID)" + strUNIQUE;
                    fKey = fk;
                    return str;
                }
                else
                {
                    sBasicType = DBTypes.DBtypesFunc.GetBasicTypeSQLite(obj) + strUNIQUE;
                }

                return Globals.LeftMargin + "'" + columnName + "' " + sBasicType + strNull + strUNIQUE;
            }
            else
            {
                return "!!!Object Is Null!!!";
            }
        }
        public Type BasicType()
        {
            //MemberInfo[] myMemberInfo;
            Type objType = obj.GetType();
            Type baseType = objType.BaseType;
            DBtypes DBtypes = new DBtypes();
            Type myDBTypes = DBtypes.GetType();

            if (baseType != null)
            {
                string csError = "";
                Type bRetType = DBtypesFunc.BasicType(baseType, myDBTypes, ref csError);
                if (bRetType != null)
                {
                    return bRetType;
                }
                else
                {
                    Error.Show(csError, "Program Error!");
                    return null;
                }
            }
            else
            {
                return null;
            }
        }


        public bool IsNumber()
        {
            //MemberInfo[] myMemberInfo;
            Type objType = obj.GetType();
            Type baseType = objType.BaseType;
            DBtypes DBtypes = new DBtypes();
            Type myDBTypes = DBtypes.GetType();

            if (baseType != null)
            {
                string csError = null;
                if (DBtypesFunc.IsNumber(baseType, myDBTypes, ref csError))
                {
                    if (csError != null)
                    {
                        Error.Show(csError, "Program Error!");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    if (csError != null)
                    {
                        Error.Show(csError, "Program Error!");
                    }
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool SetObjValue(string Value)
        {
            string sAction = "";
            //string Value = Globals.RemoveComas(Val);
            Type type = this.BasicType();
            string csError = null;
            if (DBTypes.DBtypesFunc.SetObjValue(ref this.obj, type, ref sAction, Value, ref csError))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SetObjValue(string Value, SourceText sTxt)
        {
            string sAction = "";
            //string Value = Globals.RemoveComas(Val);
            //string Value = Val;
            Type type = this.BasicType();
            string csError = null;
            if (DBTypes.DBtypesFunc.SetObjValue(ref this.obj, type, ref sAction, Value, ref csError))
            {
                return true;
            }
            else
            {
                sTxt.ShowParseError(csError, lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //public bool SetObjValue(string Value, SourceText sTxt)
        //{
        //    string sAction = "";
        //    //string Value = Globals.RemoveComas(Val);
        //    //string Value = Val;
        //    Type type = this.BasicType();
        //    try
        //    {
        //        if (type == typeof(DB_Int32))
        //        {
        //            sAction = "DB_Int32";

        //            DB_Int32 xDBInt = (DB_Int32)obj;
        //            xDBInt.val = Convert.ToInt32(Value);
        //            return true;
        //        }
        //        else if (type == typeof(DB_smallInt))
        //        {
        //            sAction = "DB_smallInt";
        //            DB_smallInt xDB_smallInt = (DB_smallInt)obj;
        //            xDB_smallInt.val = Convert.ToInt16(Value);
        //            return true;
        //        }
        //        else if (type == typeof(DB_bit))
        //        {
        //            sAction = "DB_bit";
        //            if (Value.Length == 1)
        //            {
        //                if (Value[0] == 'M')
        //                {
        //                    Value = "true";
        //                }
        //                else if (Value[0] == 'Ž')
        //                {
        //                    Value = "false";
        //                }
        //                else if (Value[0] == 'F')
        //                {
        //                    Value = "false";
        //                }
        //                else if (Value[0] == '1')
        //                {
        //                    Value = "true";
        //                }
        //                else if (Value[0] == '0')
        //                {
        //                    Value = "false";
        //                }
        //            }
        //            DB_bit xDB_bit = (DB_bit)obj;
        //            xDB_bit.val = Convert.ToBoolean(Value);
        //            return true;
        //        }
        //        else if (type == typeof(DB_DateTime))
        //        {
        //            sAction = "DB_DateTime";
        //            DB_DateTime xDB_DateTime = (DB_DateTime)obj;
        //            //if (Value.Length == 0)
        //            //{
        //            //    this.SetType = ValueSetTYPE.SET_NOTHING;
        //            //    return true;
        //            //}

        //            xDB_DateTime.val = Convert.ToDateTime(Value);
        //            return true;
        //        }
        //        else if (type == typeof(DB_varbinary_max))
        //        {
        //            sAction = "DB_varbinary_max";
        //            DB_varbinary_max xDB_varbinary_max = (DB_varbinary_max)obj;
        //            if (Func.ImageStore.IsName(Value))
        //            {
        //                if (Func.ImageStore!=null)
        //                {
        //                    xDB_varbinary_max.val = Func.imageToByteArray(Func.ImageStore.Get(Value));
        //                    return true;
        //                }
        //                else 
        //                {
        //                    MessageBox.Show("ERROR Func.ImageStore==null");
        //                    return false;
        //                }
        //            }
        //            else
        //            {
        //                if (File.Exists(Value))
        //                {
        //                    xDB_varbinary_max.val = File.ReadAllBytes(Value);
        //                    return true;
        //                }
        //                else
        //                {
        //                    xDB_varbinary_max.val = null;
        //                    sTxt.ShowParseError(lngRPM.s_File.s + ":\"" + Value + "\"" + lngRPM.s_File_does_not_exist.s, lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    return false;
        //                }
        //            }
        //        }
        //        else if (type == typeof(DB_varchar_250))
        //        {
        //            sAction = "DB_varchar_250";
        //            DB_varchar_250 xDB_varchar_250 = (DB_varchar_250)obj;
        //            xDB_varchar_250.val = Value;
        //            return true;
        //        }
        //        else if (type == typeof(DB_varchar_50))
        //        {
        //            sAction = "DB_varchar_50";
        //            DB_varchar_50 xDB_varchar_50 = (DB_varchar_50)obj;
        //            xDB_varchar_50.val = Value;
        //            return true;
        //        }
        //        else if (type == typeof(DB_varchar_45))
        //        {
        //            sAction = "DB_varchar_45";
        //            DB_varchar_45 xDB_varchar_45 = (DB_varchar_45)obj;
        //            xDB_varchar_45.val = Value;
        //            return true;
        //        }
        //        else if (type == typeof(DB_varchar_32))
        //        {
        //            sAction = "DB_varchar_32";
        //            DB_varchar_32 xDB_varchar_32 = (DB_varchar_32)obj;
        //            xDB_varchar_32.val = Value;
        //            return true;
        //        }
        //        else if (type == typeof(DB_varchar_25))
        //        {
        //            sAction = "DB_varchar_25";
        //            DB_varchar_25 xDB_varchar_25 = (DB_varchar_25)obj;
        //            xDB_varchar_25.val = Value;
        //            return true;
        //        }
        //        else if (type == typeof(DB_varchar_10))
        //        {
        //            sAction = "DB_varchar_10";
        //            DB_varchar_10 xDB_varchar_10 = (DB_varchar_10)obj;
        //            xDB_varchar_10.val = Value;
        //            return true;
        //        }
        //        else if (type == typeof(DB_varchar_5))
        //        {
        //            sAction = "DB_varchar_5";
        //            DB_varchar_5 xDB_varchar_5 = (DB_varchar_5)obj;
        //            xDB_varchar_5.val = Value;
        //            return true;
        //        }
        //        else if (type == typeof(DB_varchar_2000))
        //        {
        //            sAction = "DB_varchar_2000";
        //            DB_varchar_2000 xDB_varchar_2000 = (DB_varchar_2000)obj;
        //            xDB_varchar_2000.val = Value;
        //            return true;
        //        }
        //        else if (type == typeof(DB_varchar_max))
        //        {

        //            sAction = "DB_varchar_max";
        //            DB_varchar_max xDB_varchar_max = (DB_varchar_max)obj;
        //            xDB_varchar_max.val = Value;
        //            return true;
        //        }
        //        else
        //        {
        //            sTxt.ShowParseError(lngRPM.s_UnsuportedType.s + " " + obj.GetType().ToString() + " : " + Value, lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        sTxt.ShowParseError(lngRPM.s_Illegal_format_for.s + " " + sAction + ": " + Value + "\r\n " + ex.Message, lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //}
        //public bool SetObjValue(string Value)
        //{
        //    string sAction = "";
        //    //string Value = Globals.RemoveComas(Val);
        //    Type type = this.BasicType();
        //    try
        //    {
        //        if (type == typeof(DB_Int32))
        //        {
        //            sAction = "DB_Int32";

        //            DB_Int32 xDBInt = (DB_Int32)obj;
        //            xDBInt.val = Convert.ToInt32(Value);
        //            return true;
        //        }
        //        else if (type == typeof(DB_smallInt))
        //        {
        //            sAction = "DB_smallInt";
        //            DB_smallInt xDB_smallInt = (DB_smallInt)obj;
        //            xDB_smallInt.val = Convert.ToInt16(Value);
        //            return true;
        //        }
        //        else if (type == typeof(DB_bit))
        //        {
        //            sAction = "DB_bit";
        //            if (Value.Length == 1)
        //            {
        //                if (Value[0] == 'M')
        //                {
        //                    Value = "true";
        //                }
        //                else if (Value[0] == 'Ž')
        //                {
        //                    Value = "false";
        //                }
        //                else if (Value[0] == 'F')
        //                {
        //                    Value = "false";
        //                }
        //                else if (Value[0] == '1')
        //                {
        //                    Value = "true";
        //                }
        //                else if (Value[0] == '0')
        //                {
        //                    Value = "false";
        //                }
        //            }
        //            DB_bit xDB_bit = (DB_bit)obj;
        //            xDB_bit.val = Convert.ToBoolean(Value);
        //            return true;
        //        }
        //        else if (type == typeof(DB_DateTime))
        //        {
        //            sAction = "DB_DateTime";
        //            DB_DateTime xDB_DateTime = (DB_DateTime)obj;
        //            //if (Value.Length == 0)
        //            //{
        //            //    this.SetType = ValueSetTYPE.SET_NOTHING;
        //            //    return true;
        //            //}

        //            xDB_DateTime.val = Convert.ToDateTime(Value);
        //            return true;
        //        }
        //        else if (type == typeof(DB_varbinary_max))
        //        {
        //            sAction = "DB_varbinary_max";
        //            DB_varbinary_max xDB_varbinary_max = (DB_varbinary_max)obj;
        //            if (Func.ImageStore.IsName(Value))
        //            {
        //                if (Func.ImageStore != null)
        //                {
        //                    xDB_varbinary_max.val = Func.imageToByteArray(Func.ImageStore.Get(Value));
        //                    return true;
        //                }

        //                MessageBox.Show(lngRPM.s_ErrorNoImage.s);
        //                return false;
        //            }
        //            else
        //            {
        //                if (File.Exists(Value))
        //                {
        //                    xDB_varbinary_max.val = File.ReadAllBytes(Value);
        //                    return true;
        //                }
        //                else
        //                {
        //                    xDB_varbinary_max.val = null;
        //                    //sTxt.ShowParseError(lngRPM.s_File.s + ":\"" + Value + "\"" + lngRPM.s_File_does_not_exist.s, lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    MessageBox.Show(lngRPM.s_File.s + ":\"" + Value + "\"" + lngRPM.s_File_does_not_exist.s, lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    return false;
        //                }
        //            }
        //        }
        //        else if (type == typeof(DB_varchar_250))
        //        {
        //            sAction = "DB_varchar_250";
        //            DB_varchar_250 xDB_varchar_250 = (DB_varchar_250)obj;
        //            xDB_varchar_250.val = Value;
        //            return true;
        //        }
        //        else if (type == typeof(DB_varchar_50))
        //        {
        //            sAction = "DB_varchar_50";
        //            DB_varchar_50 xDB_varchar_50 = (DB_varchar_50)obj;
        //            xDB_varchar_50.val = Value;
        //            return true;
        //        }
        //        else if (type == typeof(DB_varchar_45))
        //        {
        //            sAction = "DB_varchar_45";
        //            DB_varchar_45 xDB_varchar_45 = (DB_varchar_45)obj;
        //            xDB_varchar_45.val = Value;
        //            return true;
        //        }
        //        else if (type == typeof(DB_varchar_32))
        //        {
        //            sAction = "DB_varchar_32";
        //            DB_varchar_32 xDB_varchar_32 = (DB_varchar_32)obj;
        //            xDB_varchar_32.val = Value;
        //            return true;
        //        }
        //        else if (type == typeof(DB_varchar_25))
        //        {
        //            sAction = "DB_varchar_25";
        //            DB_varchar_25 xDB_varchar_25 = (DB_varchar_25)obj;
        //            xDB_varchar_25.val = Value;
        //            return true;
        //        }
        //        else if (type == typeof(DB_varchar_10))
        //        {
        //            sAction = "DB_varchar_10";
        //            DB_varchar_10 xDB_varchar_10 = (DB_varchar_10)obj;
        //            xDB_varchar_10.val = Value;
        //            return true;
        //        }
        //        else if (type == typeof(DB_varchar_5))
        //        {
        //            sAction = "DB_varchar_5";
        //            DB_varchar_5 xDB_varchar_5 = (DB_varchar_5)obj;
        //            xDB_varchar_5.val = Value;
        //            return true;
        //        }

        //        else if (type == typeof(DB_varchar_2000))
        //        {
        //            sAction = "DB_varchar_2000";
        //            DB_varchar_2000 xDB_varchar_2000 = (DB_varchar_2000)obj;
        //            xDB_varchar_2000.val = Value;
        //            return true;
        //        }
        //        else if (type == typeof(DB_varchar_max))
        //        {

        //            sAction = "DB_varchar_max";
        //            DB_varchar_max xDB_varchar_max = (DB_varchar_max)obj;
        //            xDB_varchar_max.val = Value;
        //            return true;
        //        }
        //        else
        //        {
        //            //sTxt.ShowParseError(lngRPM.s_UnsuportedType.s + " " + obj.GetType().ToString() + " : " + Value, lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            MessageBox.Show(lngRPM.s_UnsuportedType.s + " " + obj.GetType().ToString() + " : " + Value, lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //sTxt.ShowParseError(lngRPM.s_Illegal_format_for.s + " " + sAction + ": " + Value + "\r\n " + ex.Message, lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        MessageBox.Show(lngRPM.s_Illegal_format_for.s + " " + sAction + ": " + Value + "\r\n " + ex.Message, lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //}


        private string SetParString(string sValue, List<SQL_Parameter> lsqlPar, string sPar)
        {
            SQL_Parameter sqlPar = new SQL_Parameter();
            sqlPar.dbType = System.Data.SqlDbType.NVarChar;
            sqlPar.Name = sPar;
            sqlPar.size = -1;
            sqlPar.Value = sValue;
            lsqlPar.Add(sqlPar);
            return sPar;
        }

        public bool ValueExistInTable(DBConnection my_SQLConnection)
        {

            SQL_Parameter sqlpar = new SQL_Parameter();
            List<SQL_Parameter> lsqlPar = new List<SQL_Parameter>();
            StringBuilder sbl = new StringBuilder("\nSELECT " + this.Name + " FROM " + this.ownerTable.TableName + " WHERE " + this.Name + " = " + DBTypes.DBtypesFunc.DbValueForSql(ref this.obj,this.BasicType(), this.ownerTable.sThisVar, ref lsqlPar, this.Name));
            string cs_Error = "";
            int Index=0;
            Object ObjRet = null;
            if (my_SQLConnection.ExecuteQuerySQL(sbl, lsqlPar, ref Index, ref ObjRet, ref cs_Error, this.ownerTable.TableName))
            {
                if (ObjRet != null)
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

        internal string UniqueName(List<SQLTable> lTable)
        {
            string sName = "";
            SQLTable pTable = this.ownerTable;
            while (pTable != null)
            {
                sName = pTable.GetStringIndex(pTable.TableName, lTable) + "_" + sName;
                pTable = pTable.pParentTable;
            }
            //            sName = "@Var_" + sName;
            return sName;
        }


        internal void SetValue(object value)
        {
          string Err = null;
          if (!DBTypes.DBtypesFunc.SetValue(ref obj, value, ref Err))
          {
              LogFile.Error.Show("ERROR:Column:SetValue:Err=" + Err);
          }
        }

        internal bool get_SQL_Parameter(ref SQL_Parameter par, ref string Insert_Into_Paramater, DBTableControl dbTables,int iSQLFormatedTabsWithLineBreaks)
        {
            string parname = "@par_" + Name;
            if (IsNull())
            {
                Insert_Into_Paramater = "null";
                par = null;
                return true;
            }
            else
            {
                if (fKey != null)
                {
                    long_v id_v = null;
                    if (fKey.fTable.Insert_SQL_Get_ID(ref id_v, dbTables, iSQLFormatedTabsWithLineBreaks))
                    {
                        par = new SQL_Parameter(parname,SQL_Parameter.eSQL_Parameter.Bigint, false, id_v.v);
                        Insert_Into_Paramater = parname;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (this.InputControl != null)
                    {
                        object objret = null;
                        SQL_Parameter.eSQL_Parameter eSQL_Parameter_TYPE = SQL_Parameter.eSQL_Parameter.Int;

                        if (this.InputControl.SetColumnObject(ref objret, ref eSQL_Parameter_TYPE))
                        {
                            if (objret != null)
                            {
                                par = new SQL_Parameter(parname, eSQL_Parameter_TYPE, false, objret);
                                Insert_Into_Paramater = parname;
                            }
                            else
                            {
                                Insert_Into_Paramater = "null";
                                par = null;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:get_SQLite_Parameter:this.InputControl == null");
                        return false;
                    }
                }
            }
            return true;
        }



        public bool IsNull()
        {
            if (this.nulltype == nullTYPE.NOT_NULL)
            {
                return false;
            }
            else
            {
                if (this.fKey != null)
                {
                    if (this.fKey.fTable != null)
                    {
                        if (this.fKey.fTable.myGroupBox != null)
                        {
                            return fKey.fTable.myGroupBox.usrc_lbl.Null_Selected;
                        }
                    }
                    LogFile.Error.Show("ERROR:Column:IsNull: this.fKey.fTable.myGroupBox not defined!");
                }
                else
                {
                    if (this.InputControl != null)
                    {
                        return this.InputControl.usrc_lbl.Null_Selected;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:Column:IsNull: this.InputControl not defined!");
                    }
                }
                return false;
            }
        }
    }
}
