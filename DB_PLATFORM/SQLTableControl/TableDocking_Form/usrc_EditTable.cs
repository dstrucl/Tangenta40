using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using DBTypes;

namespace SQLTableControl.TableDocking_Form
{
    public partial class usrc_EditTable : UserControl
    {
        public long Identity = -1;

        public delegate void delegate_dgvx_DataError(object sender, DataGridViewDataErrorEventArgs e);


        public delegate bool delegate_RowReferenceFromTable_Check_NoChangeToOther(SQLTable pSQL_Table, List<usrc_RowReferencedFromTable> usrc_RowReferencedFromTable_List, SQLTableControl.ID_v id_v, ref bool bCancelDialog, ref ltext Instruction);

        public delegate void delegate_before_New(SQLTable m_tbl, ref bool bCancel);
        public delegate void delegate_after_New(SQLTable m_tbl, bool bRes);

        public delegate void delegate_SelectedIndexChanged(SQLTable m_tbl,long ID, int index);

        public delegate void delegate_before_InsertInDataBase(SQLTable m_tbl, ref bool bCancel);
        public delegate void delegate_after_InsertInDataBase(SQLTable m_tbl,long ID, bool bRes);

        public delegate void delegate_before_UpdateDataBase(SQLTable m_tbl, ref bool bCancel);
        public delegate void delegate_after_UpdateDataBase(SQLTable m_tbl,long ID, bool bRes);

        public delegate void delegate_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e);

        public delegate void delegate_FillTable(SQLTable m_tbl);

        public event delegate_dgvx_DataError dgvx_DataError = null;

        public event usrc_EditRow.delegate_after_FillDataInputControl after_FillDataInputControl = null; 

        public event delegate_FillTable FillTable = null;
        public delegate void delegate_SetInputControlProperties(Column col, object obj);
        public event delegate_SetInputControlProperties SetInputControlProperties = null;

        public event delegate_before_New before_New = null;
        public event delegate_after_New after_New = null;

        public event delegate_before_InsertInDataBase before_InsertInDataBase = null;
        public event delegate_after_InsertInDataBase after_InsertInDataBase = null;

        public event delegate_before_UpdateDataBase before_UpdateDataBase = null;
        public event delegate_after_UpdateDataBase after_UpdateDataBase = null;

        public event delegate_SelectedIndexChanged SelectedIndexChanged = null;

        public event delegate_CellFormatting CellFormatting = null;

        public event delegate_RowReferenceFromTable_Check_NoChangeToOther RowReferenceFromTable_Check_NoChangeToOther = null;



        public string WhereConditon = null;
        public string SelectedColumns = null;
        private bool bEditUndefined = false;

        string OrderByColumnName = null;
        public DataTable dt_Data = new DataTable();
        SQLTableControl.DBTableControl dbTables = null;
        SQLTable tbl = null;
        bool bInitData = false;

        private bool m_WorkingSemaphore = false;

        public bool Changed
        {
            get { return usrc_EditRow.Changed; }
        }

        public usrc_EditTable()
        {
            InitializeComponent();
        }

        public bool SelectionButtonVisible
        {
            get { return usrc_EditRow.SelectionButtonVisible; }
            set { usrc_EditRow.SelectionButtonVisible = value; }
        }


        public bool WorkingSemaphore
        {
            get { return m_WorkingSemaphore; }
        }

        public bool GetRandomData
        {
            get { return this.usrc_EditRow.GetRandomData; }
            set { this.usrc_EditRow.GetRandomData = value; }
        }

        public bool AllowUserToAddNew
        {
            get { return this.usrc_EditRow.AllowUserToAddNew; }
            set { this.usrc_EditRow.AllowUserToAddNew = value; }
        }

        public bool AllowUserToChange
        {
            get { return this.usrc_EditRow.AllowUserToChange; }
            set { this.usrc_EditRow.AllowUserToChange = value; }
        }

        public string Title
        {
            get
            {
                return this.usrc_EditRow.Title;
            }
            set
            {
                usrc_EditRow.Title = value;
            }
        }

        public void Text(ltext xltext)
        {
            usrc_EditRow.Text(xltext);
        }

        public Color Title_Color
        {
            get
            {
                return usrc_EditRow.ForeColor;
            }
            set
            {
                usrc_EditRow.ForeColor = value;
            }
        }

        public Font Title_Font
        {
            get
            {
                return usrc_EditRow.Font;
            }
            set
            {
                usrc_EditRow.Font = value;
            }
        }


        public bool Init(SQLTableControl.DBTableControl xdbTables, SQLTable xtbl, string xSelectedColumns, string xOrderByColumnName, bool xbEditUndefined, string xWhereConditon,long_v ID_v,bool bReadOnly)
        {
            bEditUndefined = xbEditUndefined;
            SelectedColumns = xSelectedColumns;
            WhereConditon = xWhereConditon;
            OrderByColumnName = xOrderByColumnName;
            dbTables = xdbTables;
            if (tbl != null)
            {
                if (!tbl.TableName.Equals(xtbl.TableName))
                {
                    tbl.DeleteInputControls();
                    tbl = xtbl;
                }
            }
            else
            {
                tbl = xtbl;
            }

            long id = -1;
            if (ID_v!=null)
            {
                id = ID_v.v;
            }
            if (InitDataTable(id))
            {
                usrc_EditRow.Init(dbTables, tbl, null, bReadOnly);
                if (dt_Data.Rows.Count > 0)
                {
                    Identity = (long)dt_Data.Rows[0]["ID"];
                    if (ID_v != null)
                    {
                        string expression = "ID = " + ID_v.v.ToString();
                        DataRow[] drs = dt_Data.Select(expression);
                        if (drs.Count()>0)
                        { 
                            Identity = ID_v.v;
                        }
                    }
                    usrc_EditRow.ShowTableRow(Identity);
                }
                else
                {
                    Identity = -1;
                }
                this.dgvx_Table.SelectionChanged += new System.EventHandler(this.dgvx_Table_SelectionChanged);
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool InitDataTable(long ID)
        {
            bInitData = true;
            dt_Data.Clear();
            string sql = null;
            string selection = "";
            if (SelectedColumns == null)
            {
                selection = "*";
            }
            else
            {
                selection = SelectedColumns;
            }

            string sOrderBy = "";
            if (OrderByColumnName!=null)
            {
                sOrderBy = " order by " + OrderByColumnName;
            }
            if (WhereConditon == null)
            {
                if (tbl.ViewName != null)
                {
                    sql = "select " + selection + " from " + tbl.ViewName + sOrderBy;
                }
                else
                {
                    sql = "select " + selection + " from " + tbl.TableName + sOrderBy;
                }
            }
            else
            {
                if (tbl.ViewName != null)
                {
                    sql = "select " + selection + " from " + tbl.ViewName + " " + WhereConditon + sOrderBy;
                }
                else
                {
                    sql = "select " + selection + " from " + tbl.TableName + "  " + WhereConditon + sOrderBy;
                }
            }

            string Err = null;
            dt_Data.Clear();
            if (dbTables.m_con.ReadDataTable(ref dt_Data, sql, ref Err))
            {
                dgvx_Table.DataSource = dt_Data;
                if (tbl.ViewName != null)
                {
                    tbl.SetVIEW_DataGridViewImageColumns_Headers((DataGridView)dgvx_Table, dbTables);
                }
                else
                {
                    tbl.Set_DataGridViewImageColumns_Headers((DataGridView)dgvx_Table);
                }

                for (int i = 0; i < dgvx_Table.Columns.Count; i++)
                    if (dgvx_Table.Columns[i] is DataGridViewImageColumn)
                    {
                        ((DataGridViewImageColumn)dgvx_Table.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                    }
                if (ID >= 0)
                {
                    DataRow[] drows = dt_Data.Select("ID = " + ID.ToString());
                    if (drows.Count() > 0)
                    {
                        foreach (DataRow dr in drows)
                        {
                            int i = dt_Data.Rows.IndexOf(dr);
                            dgvx_Table.Rows[i].Selected = true;
                            dgvx_Table.CurrentCell = dgvx_Table[0, i];
                        }
                    }
                }
                else
                {
                    if (dt_Data.Rows.Count > 0)
                    {
                        dgvx_Table.Rows[0].Selected = true;
                    }
                }
                bInitData = false;

                DataGridViewSelectedCellCollection dgvCellCollection = this.dgvx_Table.SelectedCells;
                if (dgvCellCollection.Count >= 1)
                {
                    //lbl_test_sender_type.Text = "Count:" + dgvCellCollection.Count.ToString() + " CellType=" + dgvCellCollection[0].GetType().ToString() + " ValueType" + dgvCellCollection[0].Value.GetType().ToString() + " Value=" + dgvCellCollection[0].Value.ToString() + " Column Name = " + dgvCellCollection[0].OwningColumn.Name;
                    if (dgvCellCollection[0].OwningRow.Cells["ID"].Value.GetType() == typeof(long))
                    {
                        long Identity = (long)dgvCellCollection[0].OwningRow.Cells["ID"].Value;
                        if (!m_WorkingSemaphore)
                        {
                            if (SelectedIndexChanged != null)
                            {
                                int index = dgvCellCollection[0].RowIndex;
                                SelectedIndexChanged(tbl, Identity, index);
                            }
                        }
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show(Err);
                return false;
            }

        }

        internal void EditSelectedRow()
        {
            DataGridViewSelectedCellCollection dgvCellCollection = this.dgvx_Table.SelectedCells;
            if (dgvCellCollection.Count >= 1)
            {
                //lbl_test_sender_type.Text = "Count:" + dgvCellCollection.Count.ToString() + " CellType=" + dgvCellCollection[0].GetType().ToString() + " ValueType" + dgvCellCollection[0].Value.GetType().ToString() + " Value=" + dgvCellCollection[0].Value.ToString() + " Column Name = " + dgvCellCollection[0].OwningColumn.Name;
                if (dgvCellCollection[0].OwningRow.Cells["ID"].Value.GetType() == typeof(long))
                {
                    Identity = (long)dgvCellCollection[0].OwningRow.Cells["ID"].Value;
                    usrc_EditRow.ShowTableRow(Identity);
                    if (!m_WorkingSemaphore)
                    {
                        if (SelectedIndexChanged != null)
                        {
                            int index = dgvCellCollection[0].RowIndex;
                            SelectedIndexChanged(tbl, Identity, index);
                        }
                    }
                }
            }
            else
            {
                //lbl_test_sender_type.Text = "Num Selected cels = 0";
            }

        }

        private void dgvx_Table_SelectionChanged(object sender, EventArgs e)
        {
            if (!bInitData)
            {
                EditSelectedRow();
            }
        }

        private void usrc_EditRow_Update(bool res,long ID, string Err)
        {
            if (res)
            {
                InitDataTable(ID);
            }
            else
            {
                if (Err!=null)
                { 
                    LogFile.Error.Show(Err);
                }
            }

        }

        private void usrc_EditRow_before_InsertInDataBase(SQLTable x_tbl, ref bool bCancel)
        {
            m_WorkingSemaphore = true;
            if (before_InsertInDataBase != null)
            {
                before_InsertInDataBase(x_tbl, ref bCancel);
            }
        }

        private void usrc_EditRow_before_UpdateDataBase(SQLTable x_tbl, ref bool bCancel)
        {
            if (before_UpdateDataBase != null)
            {
                before_UpdateDataBase(x_tbl, ref bCancel);
            }
        }

        private void usrc_EditRow_after_InsertInDataBase(SQLTable x_tbl,long id, bool bRes)
        {
            Identity = id;
            if (after_InsertInDataBase != null)
            {
                after_InsertInDataBase(x_tbl,id, bRes);
            }
            m_WorkingSemaphore = false;
        }

        private void usrc_EditRow_after_UpdateDataBase(SQLTable x_tbl,long id, bool bRes)
        {
            Identity = id;
            if (after_UpdateDataBase != null)
            {
                after_UpdateDataBase(x_tbl,id, bRes);
            }
        }

        private void usrc_EditRow_after_New(SQLTable m_tbl, bool bRes)
        {
            if (after_New != null)
            {
                after_New(m_tbl, bRes);
            }
        }

        private void usrc_EditRow_before_New(SQLTable m_tbl, ref bool bCancel)
        {
            if (before_New != null)
            {
                before_New(m_tbl, ref bCancel);
            }
        }

        public void Save()
        {
            this.usrc_EditRow.Save();
        }

        private void dgvx_Table_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (CellFormatting!=null)
            {
                CellFormatting(sender, e);
            }
        }

        public void Clear()
        {
            dt_Data.Clear();
            this.usrc_EditRow.Clear();
        }

        private bool usrc_EditRow_RowReferenceFromTable_Check_NoChangeToOther(SQLTable pSQL_Table, List<usrc_RowReferencedFromTable> usrc_RowReferencedFromTable_List, ID_v id_v, ref bool bCancelDialog, ref ltext Instruction)
        {
            if (this.RowReferenceFromTable_Check_NoChangeToOther!=null)
            {
                return RowReferenceFromTable_Check_NoChangeToOther(pSQL_Table, usrc_RowReferencedFromTable_List, id_v, ref bCancelDialog, ref Instruction);
            }
            else
            {
                bCancelDialog = false;
                return false;
            }
        }


        public int RowsCount {
            get
            {
                return dt_Data.Rows.Count;
            }
        }

        public void FillInitialData()
        {
            usrc_EditRow.FillInitialData();
        }


        private void usrc_EditRow_FillTable(SQLTable m_tbl)
        {
            if (this.FillTable!=null)
            {
                this.FillTable(m_tbl);
            }
        }


        public void CallBackSetInputControlProperties(object obj)
        {
            usrc_EditRow.CallBackSetInputControlProperties(obj);
        }


        private void usrc_EditRow_SetInputControlProperties(Column col, object obj)
        {
            if (SetInputControlProperties !=null)
            {
                SetInputControlProperties(col, obj);
            }
        }

        private void usrc_EditRow_after_FillDataInputControl(SQLTable m_tbl, long ID)
        {
            if (after_FillDataInputControl!=null)
            {
                after_FillDataInputControl(m_tbl, ID);
            }
        }

        private void dgvx_Table_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (dgvx_DataError!=null)
            {
                dgvx_DataError(sender, e);
            }
        }
    }
}
