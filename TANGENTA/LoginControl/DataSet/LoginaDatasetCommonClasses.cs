
using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LoginaDatasetCommonClasses
{
public static class Func
    {
        public static string CleanName(string name)
        {
            //Compliant with item 2.4.2 of the C# specification

            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"[^\p{Ll}\p{Lu}\p{Lt}\p{Lo}\p{Nd}\p{Nl}\p{Mn}\p{Mc}\p{Cf}\p{Pc}\p{Lm}]");

            string ret = regex.Replace(name, "");

            //The identifier must start with a character or a "_"

            if (!char.IsLetter(ret, 0) || !Microsoft.CSharp.CSharpCodeProvider.CreateProvider("C#").IsValidIdentifier(ret))
                ret = string.Concat("_", ret);
            return ret;
        }
    }

public class Col_Type
    {
        public bool bPRIMARY_KEY = false;
        public bool bFOREIGN_KEY = false;
        public bool bUNIQUE = false;
        public bool bNULL = true;
        public string m_Type = null;
    }
public class bEnabled
{
    private bool m_enabled = false;

    public bool enabled
    {
        get { return m_enabled; }
        set { m_enabled = value; }
    }
}
public class Where : bEnabled
{
    private string m_expression = null;
    public List<DBConnectionControl40.SQL_Parameter> m_expression_parameters = null;
    public string expression
    {
        get { return m_expression; }
        set { m_expression = value; }
    }
    public void AddParameter(DBConnectionControl40.SQL_Parameter par)
    {
        if (m_expression_parameters == null)
        {
            m_expression_parameters = new List<DBConnectionControl40.SQL_Parameter>();
        }
        m_expression_parameters.Add(par);
    }

    internal void Add_lPar(List<DBConnectionControl40.SQL_Parameter> lPar)
    {
        if (m_expression_parameters != null)
        {
            foreach (DBConnectionControl40.SQL_Parameter par in m_expression_parameters)
            {
                lPar.Add(par);
            }
        }
    }

    internal void Clear()
    {
        enabled = false;
        m_expression = null;
        if (m_expression_parameters != null)
        {
            m_expression_parameters.Clear();
            m_expression_parameters = null;
        }
    }
}

public class Select : bEnabled
{
    private string m_expression = null;
    private string m_alternate_column_name = null;

    public string expression
    {
        get { return m_expression; }
        set { m_expression = value; }
    }

    public string alternate_column_name
    {
        get { return m_alternate_column_name; }
        set { m_alternate_column_name = value; }
    }

    public bool IsExpression
    {
        get
        {
            if (m_expression == null)
            {
                return false;
            }
            else
            {
                if (m_expression.Length > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }

    internal void Clear()
    {
        enabled = false;
        m_expression = null;
    }
}

public class ValSet
{
    public string col_name = null;
    public Col_Type col_type = new Col_Type();
    public Select Select = new Select();
    public Where Where = new Where();
    public bool bChanged = false;
    public object obj = null;

    internal void Clear()
    {
        bChanged = false;
        Select.Clear();
        Where.Clear();
    }
}
public class Command
    {
        public enum Type {UPDATE,INSERT,DELETE};
        public Type type;
        public string sql;
        public int Index;

        public Command(Type xtype, string xsql, int indx)
        {
            type = xtype;
            sql = xsql;
            Index = indx;
        }
    }
public class XTable
{
    private bool bRead = false;
    public enum CompareResult { o1_EQ_o2, o1_GT_o2, o1_LT_o2, not_comapared };
    private string m_sql_UpdateAll = "";
    private List<Command> Commands = new List<Command>();
    public bool bModified = false;
    private List<DBConnectionControl40.SQL_Parameter> m_UpdateAllPar = new List<DBConnectionControl40.SQL_Parameter>();
    public delegate void delegate_UpdateObjects(DataRow dr);
    protected delegate_UpdateObjects myUpdateObjects = null;
    protected string tablename;
    public DBConnectionControl40.DBConnection m_con;
    public List<ValSet> Columns = new List<ValSet>();

    public int Cursor
    {
        get { return m_bs_dt.Position; }
        set { m_bs_dt.Position = value; }
    }

    public DataTable dt = new DataTable();
    public BindingSource m_bs_dt = new BindingSource();
    private string m_order = "";

    public string order
    {
        get { return m_order; }
        set
        {
            if (value == null)
            {
                m_order = "";
            }
            else
            {
                m_order = value;
            };
        }
    }

    private void Row_Deleting(object sender, DataRowChangeEventArgs e)
    {
        switch (e.Action)
        {
            case DataRowAction.Delete:
                switch (e.Row.RowState)
                {
                    case DataRowState.Unchanged:
                        if (!bRead)
                        {
                            int indx = dt.Rows.IndexOf(e.Row);
                            string s_id = e.Row["id"].ToString();
                            string sqlDelete = "\r\n DELETE FROM [" + this.tablename + @"]
                                WHERE id = " + s_id;
                            Command cmd = new Command(Command.Type.DELETE, sqlDelete, indx);
                            Commands.Add(cmd);
                            bModified = true;
                        }
                        break;
                }
                break;
        }
    }

    private void Row_Changed(object sender, DataRowChangeEventArgs e)
    {
        switch (e.Action)
        {
            case DataRowAction.Add:
                switch (e.Row.RowState)
                {
                    case DataRowState.Added:
                        if (!bRead)
                        {
                            int indx = dt.Rows.IndexOf(e.Row);
                            Command cmd = new Command(Command.Type.INSERT, null, indx);
                            Commands.Add(cmd);
                            bModified = true;
                        }
                        break;
                }
                break;

            case DataRowAction.Change:
                switch (e.Row.RowState)
                {
                    case DataRowState.Modified:
                        // get changes of a row
                        string sql_update = "";
                        int i;
                        int iCount = Columns.Count;
                        bool bFirstTime = false;
                        CompareResult comp_res = CompareResult.not_comapared;


                        for (i = 0; i < iCount; i++)
                        {
                            if (Compare(Columns[i].obj, e.Row.ItemArray[i], ref comp_res))
                            {
                                if (comp_res != CompareResult.o1_EQ_o2)
                                {
                                    bModified = true;
                                    if (!bFirstTime)
                                    {
                                        bFirstTime = true;
                                        sql_update += @"

UPDATE [" + tablename + @"]
SET 
[" + Columns[i].col_name + "] = " + AddParam(Columns[i], e.Row.ItemArray[i]);
                                    }
                                    else
                                    {
                                        sql_update += @"
,[" + Columns[i].col_name + "] = " + AddParam(Columns[i], e.Row.ItemArray[i]);
                                    }
                                }
                            }
                        }
                        if (sql_update.Length > 0)
                        {
                            sql_update += @"
WHERE id = " + GetIDValue(Columns);
                            int indx = dt.Rows.IndexOf(e.Row);
                            Command cmd = new Command(Command.Type.UPDATE, sql_update, indx);
                            int iCommandsCount =Commands.Count;
                            if (iCommandsCount > 0)
                            {
                                if ((Commands[iCommandsCount - 1].type == Command.Type.UPDATE) && (Commands[iCommandsCount - 1].Index == indx))
                                {
                                    Commands[iCommandsCount - 1] = cmd; // if previous command was updating the same row then overwrite previous row with newest update!
                                }
                                else
                                {
                                    Commands.Add(cmd);
                                }
                            }
                            else
                            {
                                Commands.Add(cmd);
                            }
                        }
                        break;
                }
                break;
        }
    }

    private bool Compare(object obj1, object obj2, ref CompareResult Result)
    {
        if ((obj1 == null) && (obj2.GetType() == typeof(DBNull)))
        {
            Result = CompareResult.o1_EQ_o2;
            return true;
        }
        if ((obj1 == null) && (obj2.GetType() != typeof(DBNull)))
        {
            Result = CompareResult.o1_LT_o2;
            return true;
        }
        
        if ((obj1 != null) && (obj2.GetType() == typeof(DBNull)))
        {
            Result = CompareResult.o1_LT_o2;
            return true;
        }

        if (obj1.GetType() == obj2.GetType())
        {
            if (obj1.GetType() == typeof(int))
            {
                int v1 = (int)obj1;
                int v2 = (int)obj2;
                if (v1 == v2)
                {
                    Result = CompareResult.o1_EQ_o2;
                    return true;
                }
                else if (v1 > v2)
                {
                    Result = CompareResult.o1_GT_o2;
                    return true;
                }
                else
                {
                    Result = CompareResult.o1_LT_o2;
                    return true;
                }
            }
            else if (obj1.GetType() == typeof(string))
            {
                string v1 = (string)obj1;
                string v2 = (string)obj2;
                int iRes = string.Compare(v1, v2);
                if (iRes == 0)
                {
                    Result = CompareResult.o1_EQ_o2;
                    return true;
                }
                else if (iRes > 0)
                {
                    Result = CompareResult.o1_GT_o2;
                    return true;
                }
                else
                {
                    Result = CompareResult.o1_LT_o2;
                    return true;
                }

            }
            else if (obj1.GetType() == typeof(bool))
            {
                bool v1 = (bool)obj1;
                bool v2 = (bool)obj2;
                if (v1 == v2)
                {
                    Result = CompareResult.o1_EQ_o2;
                    return true;
                }
                else
                {
                    Result = CompareResult.o1_LT_o2;
                    return true;
                }

            }
            else if (obj1.GetType() == typeof(byte[]))
            {
                byte[] v1 = (byte[])obj1;
                byte[] v2 = (byte[])obj2;
                if (v1.Length == v2.Length)
                {
                    int i;
                    int iCount = v1.Length;
                    for (i = 0; i < iCount; i++)
                    {
                        if (v1[i] != v2[i])
                        {
                            Result = CompareResult.o1_LT_o2;
                            return true;
                        }
                    }
                    Result = CompareResult.o1_EQ_o2;
                    return true;
                }
                else
                {
                    Result = CompareResult.o1_LT_o2;
                    return true;
                }

            }
            else if (obj1.GetType() == typeof(byte))
            {
                byte v1 = (byte)obj1;
                byte v2 = (byte)obj2;
                if (v1 == v2)
                {
                    Result = CompareResult.o1_EQ_o2;
                    return true;
                }
                else if (v1 > v2)
                {
                    Result = CompareResult.o1_GT_o2;
                    return true;
                }
                else
                {
                    Result = CompareResult.o1_LT_o2;
                    return true;
                }

            }
            else if (obj1.GetType() == typeof(DateTime))
            {
                DateTime v1 = (DateTime)obj1;
                DateTime v2 = (DateTime)obj2;
                int iRes = v1.CompareTo(v2);
                if (iRes == 0)
                {
                    Result = CompareResult.o1_EQ_o2;
                    return true;
                }
                else if (iRes > 0)
                {
                    Result = CompareResult.o1_GT_o2;
                    return true;
                }
                else
                {
                    Result = CompareResult.o1_LT_o2;
                    return true;
                }

            }
            else if (obj1.GetType() == typeof(double))
            {
                double v1 = (double)obj1;
                double v2 = (double)obj2;
                if (v1 == v2)
                {
                    Result = CompareResult.o1_EQ_o2;
                    return true;
                }
                else if (v1 > v2)
                {
                    Result = CompareResult.o1_GT_o2;
                    return true;
                }
                else
                {
                    Result = CompareResult.o1_LT_o2;
                    return true;
                }
            }
            else if (obj1.GetType() == typeof(float))
            {
                float v1 = (float)obj1;
                float v2 = (float)obj2;
                if (v1 == v2)
                {
                    Result = CompareResult.o1_EQ_o2;
                    return true;
                }
                else if (v1 > v2)
                {
                    Result = CompareResult.o1_GT_o2;
                    return true;
                }
                else
                {
                    Result = CompareResult.o1_LT_o2;
                    return true;
                }
            }
            else if (obj1.GetType() == typeof(long))
            {
                long v1 = (long)obj1;
                long v2 = (long)obj2;
                if (v1 == v2)
                {
                    Result = CompareResult.o1_EQ_o2;
                    return true;
                }
                else if (v1 > v2)
                {
                    Result = CompareResult.o1_GT_o2;
                    return true;
                }
                else
                {
                    Result = CompareResult.o1_LT_o2;
                    return true;
                }
            }
            else if (obj1.GetType() == typeof(char))
            {
                char v1 = (char)obj1;
                char v2 = (char)obj2;
                int iRes = v1.CompareTo(v2);
                if (iRes == 0)
                {
                    Result = CompareResult.o1_EQ_o2;
                    return true;
                }
                else if (iRes > v2)
                {
                    Result = CompareResult.o1_GT_o2;
                    return true;
                }
                else
                {
                    Result = CompareResult.o1_LT_o2;
                    return true;
                }
            }
            else if (obj1.GetType() == typeof(char[]))
            {
                char[] v1 = (char[])obj1;
                char[] v2 = (char[])obj2;
                string s1 = new string(v1);
                string s2 = new string(v2);
                int iRes = string.Compare(s1, s2);
                if (iRes == 0)
                {
                    Result = CompareResult.o1_EQ_o2;
                    return true;
                }
                else if (iRes > 0)
                {
                    Result = CompareResult.o1_GT_o2;
                    return true;
                }
                else
                {
                    Result = CompareResult.o1_LT_o2;
                    return true;
                }
            }
            else if (obj1.GetType() == typeof(short))
            {
                short v1 = (short)obj1;
                short v2 = (short)obj2;
                if (v1 == v2)
                {
                    Result = CompareResult.o1_EQ_o2;
                    return true;
                }
                else if (v1 > v2)
                {
                    Result = CompareResult.o1_GT_o2;
                    return true;
                }
                else
                {
                    Result = CompareResult.o1_LT_o2;
                    return true;
                }
            }
            else if (obj1.GetType() == typeof(uint))
            {
                uint v1 = (uint)obj1;
                uint v2 = (uint)obj2;
                if (v1 == v2)
                {
                    Result = CompareResult.o1_EQ_o2;
                    return true;
                }
                else if (v1 > v2)
                {
                    Result = CompareResult.o1_GT_o2;
                    return true;
                }
                else
                {
                    Result = CompareResult.o1_LT_o2;
                    return true;
                }
            }
            else if (obj1.GetType() == typeof(ushort))
            {
                ushort v1 = (ushort)obj1;
                ushort v2 = (ushort)obj2;
                if (v1 == v2)
                {
                    Result = CompareResult.o1_EQ_o2;
                    return true;
                }
                else if (v1 > v2)
                {
                    Result = CompareResult.o1_GT_o2;
                    return true;
                }
                else
                {
                    Result = CompareResult.o1_LT_o2;
                    return true;
                }
            }
            else if (obj1.GetType() == typeof(ulong))
            {
                ulong v1 = (ulong)obj1;
                ulong v2 = (ulong)obj2;
                if (v1 == v2)
                {
                    Result = CompareResult.o1_EQ_o2;
                    return true;
                }
                else if (v1 > v2)
                {
                    Result = CompareResult.o1_GT_o2;
                    return true;
                }
                else
                {
                    Result = CompareResult.o1_LT_o2;
                    return true;
                }
            }
            else if (obj1.GetType() == typeof(byte))
            {
                byte v1 = (byte)obj1;
                byte v2 = (byte)obj2;
                if (v1 == v2)
                {
                    Result = CompareResult.o1_EQ_o2;
                    return true;
                }
                else if (v1 > v2)
                {
                    Result = CompareResult.o1_GT_o2;
                    return true;
                }
                else
                {
                    Result = CompareResult.o1_LT_o2;
                    return true;
                }
            }
            else
            {

                LogFile.Error.Show("Error Not implemented type to compare obj1.GetType()==" + obj1.GetType().ToString());
                return false; //Objects are not of same Type!
            }
        }
        else
        {
            LogFile.Error.Show("Error you can not compare objects of two different types!  obj1.GetType()==" + obj1.GetType().ToString() + ", obj1.GetType()==" + obj1.GetType().ToString());
            return false; //Objects are not of same Type!
        }
    }

    private string GetIDValue(List<ValSet> Columns)
    {
        foreach (ValSet vs in Columns)
        {
            if (vs.col_name.ToLower().Equals("id"))
            {
                return vs.obj.ToString();
            }
        }
        LogFile.Error.Show("Error column id not found in table:" + tablename);
        return "-1";
    }

    private string AddParam(ValSet valSet, object obj_new)
    {
        string sParName = "@par" + m_UpdateAllPar.Count.ToString() + "_" + Func.CleanName(valSet.col_name);
            DBConnectionControl40.SQL_Parameter.eSQL_Parameter epar = DBConnectionControl40.SQL_Parameter.Get_eSQL_Parameter(valSet.col_type.m_Type);
        m_UpdateAllPar.Add(new DBConnectionControl40.SQL_Parameter(sParName, DBConnectionControl40.SQL_Parameter.Get_eSQL_Parameter(valSet.col_type.m_Type),  false, obj_new));
        return sParName;
    }

    private void m_bs_dt_CurrentChanged(object obj, EventArgs e)
    {
        DataRowView drv = (DataRowView)((BindingSource)obj).Current;
        if (drv != null)
        {
            myUpdateObjects(drv.Row);
        }
    }

    public XTable()
    {
        bModified = false;
        m_bs_dt.DataSource = dt;
        m_bs_dt.AllowNew = true;
        m_bs_dt.CurrentChanged += new EventHandler(m_bs_dt_CurrentChanged);
        dt.RowChanged += new DataRowChangeEventHandler(Row_Changed);
        dt.RowDeleting += new DataRowChangeEventHandler(Row_Deleting);

    }


    protected void clear()
    {
        dt.Clear();
        if (m_bs_dt != null)
        {
            if (m_bs_dt.DataSource != null)
            {
                if (m_bs_dt.DataSource.GetType() == typeof(DataTable))
                {
                    ((DataTable)m_bs_dt.DataSource).Clear();
                }
            }
        }
        foreach (ValSet vs in Columns)
        {
            vs.Clear();
        }
    }

    protected int RowsCount()
    {
        if (dt != null)
        {
            return dt.Rows.Count;
        }
        else
        {
            return -1;
        }
    }

    public void Add(ValSet vs)
    {
        Columns.Add(vs);
    }


    private string CreateInsert(Command cmd, ref string csError)
    {
        string sqlInsert = "\r\n INSERT INTO [" + this.tablename + @"]
            (";
        int i;
        int iCount = Columns.Count;
        bool bFirst = false;
        for (i = 0; i < iCount; i++)
        {
            if (Columns[i].col_type.bPRIMARY_KEY)
            {
                continue;
            }
            if (!bFirst)
            {
                bFirst = true;
                sqlInsert += "\r\n[" + Columns[i].col_name + "]";
            }
            else
            {
                sqlInsert += "\r\n,[" + Columns[i].col_name + "]";
            }
        }
        sqlInsert += @"
            )
            VALUES
            (
            ";
        bFirst = false;
        for (i = 0; i < iCount; i++)
        {
            if (Columns[i].col_type.bPRIMARY_KEY)
            {
                continue;
            }
            if (!Columns[i].col_type.bNULL)
            {
                //nulls not allowed
                object obj = dt.Rows[cmd.Index][Columns[i].col_name];
                if (obj.GetType() == typeof(System.DBNull))
                {
                    if (csError == null)
                    {
                        csError = "";
                    }
                    string sError = "%Table%:'" + this.tablename + "' %Column%:'" + Columns[i].col_name + "' %MayNotBeNull%\r\n";
                    csError += sError;
                    return null;
                }
            }
            if (!bFirst)
            {
                bFirst = true;
                sqlInsert += "\r\n" + AddParam(Columns[i], dt.Rows[cmd.Index][Columns[i].col_name]);
            }
            else
            {
                sqlInsert += "\r\n," + AddParam(Columns[i], dt.Rows[cmd.Index][Columns[i].col_name]);
            }
        }
        sqlInsert += @"
            );";
        return sqlInsert;
    }

    public bool update(ref string csError)
    {
        this.m_sql_UpdateAll = "";
        foreach (Command cmd in Commands)
        {
            switch (cmd.type)
            {
                case Command.Type.UPDATE:
                    this.m_sql_UpdateAll += "\r\n" + cmd.sql;
                    break;
                case Command.Type.INSERT:
                    // create Insert
                    string sqlINS = CreateInsert(cmd, ref csError);
                    if (sqlINS != null)
                    {
                        m_sql_UpdateAll += sqlINS;
                    }
                    else
                    {
                        return false;
                    }
                    break;

                case Command.Type.DELETE:
                    // create Insert
                    m_sql_UpdateAll += "\r\n" + cmd.sql;
                    break;
            }
        }
        object oResult = null;
        bool bRes = m_con.ExecuteNonQuerySQL(m_sql_UpdateAll, m_UpdateAllPar,ref oResult, ref csError);
        if (bRes)
        {
            bModified = false;
            m_sql_UpdateAll = "";
            Commands.Clear();
            m_UpdateAllPar.Clear();
        }
        return bRes;
    }


    public bool read(ref string csError)
    {
        bRead = true;
        dt.Clear();
        List<DBConnectionControl40.SQL_Parameter> lPar = new List<DBConnectionControl40.SQL_Parameter>();
        string sql_select = "SELECT ";
        int i;
        int iColumns = Columns.Count;
        bool bFirstFound = false;
        for (i = 0; i < iColumns; i++)
        {
            ValSet vscol = Columns[i];
            if (vscol.Select.enabled)
            {
                if (vscol.Select.IsExpression)
                {
                    if (!bFirstFound)
                    {
                        sql_select += vscol.Select.expression + " as " + vscol.Select.alternate_column_name;
                        bFirstFound = true;
                    }
                    else
                    {
                        sql_select += "," + vscol.Select.expression + " as " + vscol.Select.alternate_column_name;
                    }
                }
                else
                {
                    if (!bFirstFound)
                    {
                        sql_select += "[" + vscol.col_name + "]";
                        bFirstFound = true;
                    }
                    else
                    {
                        sql_select += ",[" + vscol.col_name + "]";
                    }
                }
            }
        }

        sql_select += @"
 FROM [" + tablename + "]";

        // WHERE part
        bFirstFound = false;
        for (i = 0; i < iColumns; i++)
        {
            ValSet colvs = Columns[i];
            if (colvs.Where.enabled) //CHANGE!!
            {
                if (colvs.Where.expression == null)
                {
                    if (!bFirstFound)
                    {
                        sql_select += " WHERE ([" + colvs.col_name + "] = @par_" + GetParamName(colvs.col_name) + ")";
                        lPar.Add(new DBConnectionControl40.SQL_Parameter("@par_" + GetParamName(colvs.col_name), DBConnectionControl40.SQL_Parameter.Get_eSQL_Parameter(colvs.col_type.m_Type), false, colvs.obj));
                        bFirstFound = true;
                    }
                    else
                    {
                        sql_select += " AND ([" + colvs.col_name + "] = @par_" + GetParamName(colvs.col_name) + ")";
                        lPar.Add(new DBConnectionControl40.SQL_Parameter("@par_" + GetParamName(colvs.col_name), DBConnectionControl40.SQL_Parameter.Get_eSQL_Parameter(colvs.col_type.m_Type), false, colvs.obj));
                    }
                }
                else
                {
                    if (!bFirstFound)
                    {
                        sql_select += " WHERE ([" + colvs.col_name + "] " + colvs.Where.expression + ")";
                        colvs.Where.Add_lPar(lPar);
                        bFirstFound = true;
                    }
                    else
                    {
                        sql_select += " AND ([" + Columns[i].col_name + "] " + colvs.Where.expression + ")";
                        colvs.Where.Add_lPar(lPar);
                    }

                }
            }
        }
        if (order.Length > 0)
        {
            sql_select += order;
        }
        if (m_bs_dt != null)
        {
            if (m_bs_dt.DataSource != null)
            {
                if (m_bs_dt.DataSource.GetType() == typeof(DataTable))
                {
                    ((DataTable)m_bs_dt.DataSource).Clear();
                }
            }
        }
        bool bRes = m_con.ReadDataTable(ref dt, sql_select, lPar, ref csError);
        if (bRes)
        {
        }
        bRead = false;
        return bRes;
    }

    private string GetParamName(string sName)
    {
        return Func.CleanName(sName);
    }
}
// End class XTable
// Start Class XView
public class XView
{
    private bool m_bRead = false;

    private bool bRead
        {
            get { return m_bRead; }
            set { m_bRead = value; }
        }


        public enum CompareResult { o1_EQ_o2, o1_GT_o2, o1_LT_o2, not_comapared };
    private string m_sql_UpdateAll = null;
    private string sql_UpdateAll
        {
            get { return m_sql_UpdateAll; }
            set { m_sql_UpdateAll = value; }
        }
    private List<Command> Commands = new List<Command>();

    protected string tablename;
    public DBConnectionControl40.DBConnection m_con;
    public List<ValSet> Columns = new List<ValSet>();

    public int Cursor
    {
        get { return m_bs_dt.Position; }
        set { m_bs_dt.Position = value; }
    }

    public DataTable dt = new DataTable();
    public BindingSource m_bs_dt = new BindingSource();

    public delegate void delegate_UpdateObjects(DataRow dr);
    protected delegate_UpdateObjects myUpdateObjects = null;

    private string m_order = "";

    public string order
    {
        get { return m_order; }
        set
        {
            if (value == null)
            {
                m_order = "";
            }
            else
            {
                m_order = value;
            };
        }
    }



    private void m_bs_dt_CurrentChanged(object obj, EventArgs e)
    {
        DataRowView drv = (DataRowView)((BindingSource)obj).Current;
        if (drv != null)
        {
            myUpdateObjects(drv.Row);
        }
    }

    public XView()
    {
        m_bs_dt.DataSource = dt;
        m_bs_dt.AllowNew = true;
        m_bs_dt.CurrentChanged += new EventHandler(m_bs_dt_CurrentChanged);
    }


    protected void clear()
    {
        dt.Clear();
        if (m_bs_dt != null)
        {
            if (m_bs_dt.DataSource != null)
            {
                if (m_bs_dt.DataSource.GetType() == typeof(DataTable))
                {
                    ((DataTable)m_bs_dt.DataSource).Clear();
                }
            }
        }
        foreach (ValSet vs in Columns)
        {
            vs.Clear();
        }
    }

    protected int RowsCount()
    {
        if (dt != null)
        {
            return dt.Rows.Count;
        }
        else
        {
            return -1;
        }
    }

    public void Add(ValSet vs)
    {
        Columns.Add(vs);
    }


    public bool read(ref string csError)
    {
        bRead = true;
        dt.Clear();
        List<DBConnectionControl40.SQL_Parameter> lPar = new List<DBConnectionControl40.SQL_Parameter>();
        string sql_select = "SELECT ";
        int i;
        int iColumns = Columns.Count;
        bool bFirstFound = false;
        for (i = 0; i < iColumns; i++)
        {
            ValSet vscol = Columns[i];
            if (vscol.Select.enabled)
            {
                if (vscol.Select.IsExpression)
                {
                    if (!bFirstFound)
                    {
                        sql_select += vscol.Select.expression + " as " + vscol.Select.alternate_column_name;
                        bFirstFound = true;
                    }
                    else
                    {
                        sql_select += "," + vscol.Select.expression + " as " + vscol.Select.alternate_column_name;
                    }
                }
                else
                {
                    if (!bFirstFound)
                    {
                        sql_select += "[" + vscol.col_name + "]";
                        bFirstFound = true;
                    }
                    else
                    {
                        sql_select += ",[" + vscol.col_name + "]";
                    }
                }
            }
        }

        sql_select += @"
 FROM [" + tablename + "]";

        // WHERE part
        bFirstFound = false;
        for (i = 0; i < iColumns; i++)
        {
            ValSet colvs = Columns[i];
            if (colvs.Where.enabled) //CHANGE!!
            {
                if (colvs.Where.expression == null)
                {
                    if (!bFirstFound)
                    {
                        sql_select += " WHERE ([" + Columns[i].col_name + "] = @par_" + Func.CleanName(Columns[i].col_name) + ")";
                        lPar.Add(new DBConnectionControl40.SQL_Parameter("@par_" + Func.CleanName(Columns[i].col_name), DBConnectionControl40.SQL_Parameter.Get_eSQL_Parameter(Columns[i].col_type.m_Type), false, Columns[i].obj));
                        bFirstFound = true;
                    }
                    else
                    {
                        sql_select += " AND ([" + Columns[i].col_name + "] = @par_" + Func.CleanName(Columns[i].col_name) + ")";
                        lPar.Add(new DBConnectionControl40.SQL_Parameter("@par_" + Func.CleanName(Columns[i].col_name), DBConnectionControl40.SQL_Parameter.Get_eSQL_Parameter(Columns[i].col_type.m_Type), false, Columns[i].obj));
                    }
                }
                else
                {
                    if (!bFirstFound)
                    {
                        sql_select += " WHERE ([" + colvs.col_name + "] " + colvs.Where.expression + ")";
                        colvs.Where.Add_lPar(lPar);
                        bFirstFound = true;
                    }
                    else
                    {
                        sql_select += " AND ([" + Columns[i].col_name + "] " + colvs.Where.expression + ")";
                        colvs.Where.Add_lPar(lPar);
                    }
                }
            }
        }

        if (order.Length > 0)
        {
            sql_select += order;
        }

        if (m_bs_dt != null)
        {
            if (m_bs_dt.DataSource != null)
            {
                if (m_bs_dt.DataSource.GetType() == typeof(DataTable))
                {
                    ((DataTable)m_bs_dt.DataSource).Clear();
                }
            }
        }
        bool bRes = m_con.ReadDataTable(ref dt, sql_select, lPar, ref csError);
        if (bRes)
        {
        }
        bRead = false;
        return bRes;
    }
}
//END class XView
// Start Class XTableFunction
public class XTableFunction
{
    private bool m_bRead = false;
    private bool bRead
        {
            get { return m_bRead; }
            set { m_bRead = value; }
        }

    public enum CompareResult { o1_EQ_o2, o1_GT_o2, o1_LT_o2, not_comapared };

    private List<Command> Commands = new List<Command>();

    protected string tablefunctionname;
    public DBConnectionControl40.DBConnection m_con;
    public List<ValSet> Columns = new List<ValSet>();

    public List<DBConnectionControl40.SQL_Parameter> FuncParams = new List<DBConnectionControl40.SQL_Parameter>();

    public int Cursor
    {
        get { return m_bs_dt.Position; }
        set { m_bs_dt.Position = value; }
    }
    public DataTable dt = new DataTable();
    public BindingSource m_bs_dt = new BindingSource();

    public delegate void delegate_UpdateObjects(DataRow dr);
    protected delegate_UpdateObjects myUpdateObjects = null;

    private string m_order = "";

    public string order
    {
        get { return m_order; }
        set
        {
            if (value == null)
            {
                m_order = "";
            }
            else
            {
                m_order = value;
            };
        }
    }



    private void m_bs_dt_CurrentChanged(object obj, EventArgs e)
    {
        DataRowView drv = (DataRowView)((BindingSource)obj).Current;
        if (drv != null)
        {
            myUpdateObjects(drv.Row);
        }
    }

    public XTableFunction()
    {
        m_bs_dt.DataSource = dt;
        m_bs_dt.AllowNew = true;
        m_bs_dt.CurrentChanged += new EventHandler(m_bs_dt_CurrentChanged);
    }


    protected void clear()
    {
        dt.Clear();
        if (m_bs_dt != null)
        {
            if (m_bs_dt.DataSource != null)
            {
                if (m_bs_dt.DataSource.GetType() == typeof(DataTable))
                {
                    ((DataTable)m_bs_dt.DataSource).Clear();
                }
            }
        }
        foreach (ValSet vs in Columns)
        {
            vs.Clear();
        }
    }

    protected int RowsCount()
    {
        if (dt != null)
        {
            return dt.Rows.Count;
        }
        else
        {
            return -1;
        }
    }

    public void Add(ValSet vs)
    {
        Columns.Add(vs);
    }


    public bool read(ref string csError)
    {
        bRead = true;
        dt.Clear();
        List<DBConnectionControl40.SQL_Parameter> lPar = new List<DBConnectionControl40.SQL_Parameter>();
        string sql_select = "SELECT ";
        int i;
        int iColumns = Columns.Count;
        bool bFirstFound = false;
        for (i = 0; i < iColumns; i++)
        {
            ValSet vscol = Columns[i];
            if (vscol.Select.enabled)
            {
                if (vscol.Select.IsExpression)
                {
                    if (!bFirstFound)
                    {
                        sql_select += vscol.Select.expression + " as " + vscol.Select.alternate_column_name;
                        bFirstFound = true;
                    }
                    else
                    {
                        sql_select += "," + vscol.Select.expression + " as " + vscol.Select.alternate_column_name;
                    }
                }
                else
                {
                    if (!bFirstFound)
                    {
                        sql_select += "[" + vscol.col_name + "]";
                        bFirstFound = true;
                    }
                    else
                    {
                        sql_select += ",[" + vscol.col_name + "]";
                    }
                }
            }
        }

        sql_select += @"
            FROM dbo." + tablefunctionname + "(";

        // Parameters part
        string sql_args = "";
        foreach (DBConnectionControl40.SQL_Parameter par in FuncParams)
        {
            lPar.Add(par);
            if (sql_args.Length == 0)
            {
                sql_args += par.Name;
            }
            else
            {
                sql_args += "," + par.Name;
            }
        }

        sql_select += sql_args + ")";

        bFirstFound = false;
        for (i = 0; i < iColumns; i++)
        {
            ValSet colvs = Columns[i];
            if (colvs.Where.enabled) //CHANGE!!
            {
                if (colvs.Where.expression == null)
                {
                    if (!bFirstFound)
                    {
                        sql_select += " WHERE ([" + Columns[i].col_name + "] = @par_" + Func.CleanName(Columns[i].col_name) + ")";
                        lPar.Add(new DBConnectionControl40.SQL_Parameter("@par_" + Func.CleanName(Columns[i].col_name), DBConnectionControl40.SQL_Parameter.Get_eSQL_Parameter(Columns[i].col_type.m_Type), false, Columns[i].obj));
                        bFirstFound = true;
                    }
                    else
                    {
                        sql_select += " AND ([" + Columns[i].col_name + "] = @par_" + Func.CleanName(Columns[i].col_name) + ")";
                        lPar.Add(new DBConnectionControl40.SQL_Parameter("@par_" + Func.CleanName(Columns[i].col_name), DBConnectionControl40.SQL_Parameter.Get_eSQL_Parameter(Columns[i].col_type.m_Type), false, Columns[i].obj));
                    }
                }
                else
                {
                    if (!bFirstFound)
                    {
                        sql_select += " WHERE ([" + colvs.col_name + "] " + colvs.Where.expression + ")";
                        colvs.Where.Add_lPar(lPar);
                        bFirstFound = true;
                    }
                    else
                    {
                        sql_select += " AND ([" + Columns[i].col_name + "] " + colvs.Where.expression + ")";
                        colvs.Where.Add_lPar(lPar);
                    }
                }
            }
        }

        if (order.Length > 0)
        {
            sql_select += order;
        }

        if (m_bs_dt != null)
        {
            if (m_bs_dt.DataSource != null)
            {
                if (m_bs_dt.DataSource.GetType() == typeof(DataTable))
                {
                    ((DataTable)m_bs_dt.DataSource).Clear();
                }
            }
        }
        bool bRes = m_con.ReadDataTable(ref dt, sql_select, lPar, ref csError);
        if (bRes)
        {
        }
        this.bRead = false;
        return bRes;
    }
}
// End Class XTableFunction// Start Class XFunction
// Start Class XFunction
public class XFunction
{
    protected string scalarfunctionname;
    public DBConnectionControl40.DBConnection m_con;

    public List<DBConnectionControl40.SQL_Parameter> FuncParams = new List<DBConnectionControl40.SQL_Parameter>();



    public XFunction()
    {
    }


    public object exec(string sFunctionName, ref string csError)
    {
        List<DBConnectionControl40.SQL_Parameter> lPar = new List<DBConnectionControl40.SQL_Parameter>();
        string sql_args = "";
        string Result_par = null;
        foreach (DBConnectionControl40.SQL_Parameter par in FuncParams)
        {
            lPar.Add(par);
            if (!par.IsOutputParameter)
            {
                if (sql_args.Length == 0)
                {
                    sql_args += par.Name;
                }
                else
                {
                    sql_args += "," + par.Name;
                }
            }
            else
            {
                Result_par = par.Name;
            }
        }


        string sql_select = "SET " + Result_par + " = ";
        sql_select += @" dbo." + sFunctionName + "(";

        // Parameters part

        sql_select += sql_args + ")";


        object Result = new object();
        bool bRes = m_con.ExecuteNonQuerySQL(sql_select,
                                             lPar,
                                             ref Result,
                                             ref csError);
        if (bRes)
        {
            return Result;
        }
        else
        {
            return null;
        }
    }
}
// End Class XFunction
// Start Class XProcedure
public class XProcedure
{
    public const string string_const_par_return = "Ret_code_CopyRight_Logina_AuthorDamjanStrucl";
    protected string scalarfunctionname;
    public DBConnectionControl40.DBConnection m_con;

    public List<DBConnectionControl40.SQL_Parameter> ProcParams = new List<DBConnectionControl40.SQL_Parameter>();



    public XProcedure()
    {
    }

    public object ProcParamValue(string name)
    {
        int iPar;
        int iParCount = ProcParams.Count;
        for (iPar = 1; iPar < iParCount; iPar++)
        {
            DBConnectionControl40.SQL_Parameter par = ProcParams[iPar];
            if (par.Name.Equals(name))
            {
                if (par.MS_SqlSqlParameter != null)
                {
                    return par.MS_SqlSqlParameter.Value;
                }
            }
        }
        return null;
    }


    public object exec(string sProcedureName, string[] sArgs, ref string csError)
    {
        List<DBConnectionControl40.SQL_Parameter> lPar = new List<DBConnectionControl40.SQL_Parameter>();
        string sql_args = "";
        int iArg = 0;
        int iPar;
        int iParCount = ProcParams.Count;
        lPar.Add(ProcParams[0]); // add param Ret_code_CopyRight_Logina_AuthorDamjanStrucl !
        for (iPar = 1; iPar < iParCount; iPar++)
        {
            DBConnectionControl40.SQL_Parameter par = ProcParams[iPar];
            string sOutput = "";
            if (par.IsOutputParameter)
            {
                sOutput = " OUTPUT ";
            }

            lPar.Add(par);
            if (sql_args.Length == 0)
            {
                sql_args += sArgs[iArg] + " = " + par.Name + sOutput;
            }
            else
            {
                sql_args += "," + sArgs[iArg] + " = " + par.Name + sOutput;
            }
            iArg++;
        }

        string sql_select = "EXECUTE @Ret_code_CopyRight_Logina_AuthorDamjanStrucl = ";
        sql_select += @" dbo." + sProcedureName + " ";

        // Parameters part

        sql_select += sql_args;


        Object Result = null;
        bool bRes = m_con.ExecuteNonQuerySQL(sql_select,
                                             lPar,
                                             ref Result,
                                             ref csError);
        if (bRes)
        {
            return Result;
        }
        else
        {
            return null;
        }
    }
}
// End Class XProcedure

}