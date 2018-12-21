#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
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
using NavigationButtons;
using DBConnectionControl40;

namespace CodeTables.TableDocking_Form
{
    public partial class usrc_EditTable : UserControl
    {
        public ID Identity = null;

        public delegate void delegate_dgvx_DataError(object sender, DataGridViewDataErrorEventArgs e);


        public delegate bool delegate_RowReferenceFromTable_Check_NoChangeToOther(SQLTable pSQL_Table, List<usrc_RowReferencedFromTable> usrc_RowReferencedFromTable_List, ID id, ref bool bCancelDialog, ref ltext Instruction);

        public delegate void delegate_before_New(SQLTable m_tbl, ref bool bCancel);
        public delegate void delegate_after_New(SQLTable m_tbl, bool bRes);

        public delegate void delegate_SelectedIndexChanged(SQLTable m_tbl,ID ID, int index);

        public delegate void delegate_before_InsertInDataBase(SQLTable m_tbl, ref bool bCancel);
        public delegate void delegate_after_InsertInDataBase(SQLTable m_tbl,ID ID, bool bRes);

        public delegate void delegate_before_UpdateDataBase(SQLTable m_tbl, ref bool bCancel);
        public delegate void delegate_after_UpdateDataBase(SQLTable m_tbl,ID ID, bool bRes);

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

        public bool IdentitySelect(ID m_myOrganisation_Person_ID)
        {
            return InitDataTable(m_myOrganisation_Person_ID);
        }

        string OrderByColumnName = null;
        public DataTable dt_Data = new DataTable();
        CodeTables.DBTableControl dbTables = null;
        public SQLTable tbl = null;
        bool bInitData = false;

        private bool m_WorkingSemaphore = false;
        private Navigation nav;

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

        public new void Text(ltext xltext)
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


        public bool Init(CodeTables.DBTableControl xdbTables,
                        SQLTable xtbl,
                        string xSelectedColumns,
                        string xOrderByColumnName,
                        bool xbEditUndefined,
                        string xWhereConditon,
                        ID IDa,bool bReadOnly,
                        NavigationButtons.Navigation xnav)
        {
            nav = xnav;
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

            ID id = null;
            if (IDa!=null)
            {
                id = IDa;
            }
            if (InitDataTable(id))
            {
                usrc_EditRow.Init(dbTables, tbl, null, bReadOnly,nav);
                if (dt_Data.Rows.Count > 0)
                {
                    if (Identity == null)
                    {
                        Identity = new ID();
                    }
                    Identity.Set(dt_Data.Rows[0]["ID"]);
                    if (IDa != null)
                    {
                        string expression = "ID = " + IDa.V.ToString();
                        DataRow[] drs = dt_Data.Select(expression);
                        if (drs.Count()>0)
                        { 
                            Identity = IDa;
                        }
                    }
                    usrc_EditRow.ShowTableRow(Identity);
                }
                else
                {
                    Identity = null;
                }
                this.dgvx_Table.SelectionChanged += new System.EventHandler(this.dgvx_Table_SelectionChanged);

                DataGridViewSelectedCellCollection dgvCellCollection = this.dgvx_Table.SelectedCells;
                if (dgvCellCollection.Count >= 1)
                {
                    //lbl_test_sender_type.Text = "Count:" + dgvCellCollection.Count.ToString() + " CellType=" + dgvCellCollection[0].GetType().ToString() + " ValueType" + dgvCellCollection[0].Value.GetType().ToString() + " Value=" + dgvCellCollection[0].Value.ToString() + " Column Name = " + dgvCellCollection[0].OwningColumn.Name;
                    if (dgvCellCollection[0].OwningRow.Cells["ID"].Value.GetType() == typeof(long))
                    {
                        ID Identity = new ID(dgvCellCollection[0].OwningRow.Cells["ID"].Value);
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
                return false;
            }
        }

        public void KeyPressed(Keys k)
        {
            usrc_EditRow.KeyPressed(k);
        }

        public object GetColumnObject(string ColumnName)
        {
            if (tbl!=null)
            {
                DataRow[] drs = dt_Data.Select("ID=" + this.Identity.ToString());
                if (drs!= null)
                {
                    if (drs.Length>0)
                    {
                        foreach (DataColumn dcol in dt_Data.Columns)
                        {
                            if (dcol.ColumnName.Equals(ColumnName))
                            {
                                return drs[0][ColumnName];
                            }
                        }

                    }
                }

                return null;
            }
            else
            {
                return null;
            }
        }

        private bool InitDataTable(ID ID)
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
                if (ID.Validate(ID))
                {
                    DataRow[] drows = dt_Data.Select("ID = " + ID.ToString());
                    if (drows.Count() > 0)
                    {
                        int iColIndexOfID = dgvx_Table.Rows[0].Cells["ID"].ColumnIndex;

                        foreach (DataRow dr in drows)
                        {

                            int rowIndex = -1;

                            foreach (DataGridViewRow row in dgvx_Table.Rows)
                            {
                                ID idcell = new ID(row.Cells[iColIndexOfID].Value);
                                if (idcell.Equals(ID))
                                {
                                    rowIndex = row.Index;
                                    dgvx_Table.Rows[rowIndex].Selected = true;
                                    dgvx_Table.CurrentCell = dgvx_Table[0, rowIndex];
                                    break;
                                }
                            }
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

                return true;
            }
            else
            {
                LogFile.Error.Show(Err);
                return false;
            }

        }

        private bool GetSelected_ID(ref ID selected_ID, ref int rowIndex)
        {
            DataGridViewSelectedCellCollection dgvCellCollection = this.dgvx_Table.SelectedCells;
            if (dgvCellCollection.Count >= 1)
            {
                //lbl_test_sender_type.Text = "Count:" + dgvCellCollection.Count.ToString() + " CellType=" + dgvCellCollection[0].GetType().ToString() + " ValueType" + dgvCellCollection[0].Value.GetType().ToString() + " Value=" + dgvCellCollection[0].Value.ToString() + " Column Name = " + dgvCellCollection[0].OwningColumn.Name;
                ID id1 = new ID(dgvCellCollection[0].OwningRow.Cells["ID"].Value);
                if (ID.Validate(id1))
                {
                    rowIndex = dgvCellCollection[0].RowIndex;
                    selected_ID = id1;
                    return true;
                }
                
            }
            else
            {
                //lbl_test_sender_type.Text = "Num Selected cels = 0";
            }
            return false;
        }

        internal void EditSelectedRow()
        {
            ID selected_ID = null;
            int index = -1;
            if (GetSelected_ID(ref selected_ID,ref index))
            {
                if (SelectionChange_Allowed(Identity, selected_ID))
                {
                    Identity = selected_ID;
                    usrc_EditRow.ShowTableRow(Identity);
                    if (!m_WorkingSemaphore)
                    {
                        if (SelectedIndexChanged != null)
                        {
                            SelectedIndexChanged(tbl, Identity, index);
                        }
                    }
                }
            }
        }

        private bool SelectionChange_Allowed(ID identity, ID selected_ID)
        {
            if (ID.Validate(identity))
            {
                if (ID.Validate(selected_ID))
                {
                    if (!identity.Equals(selected_ID))
                    {
                        if (this.usrc_EditRow.InsertingNewRow)
                        {
                            if (XMessage.Box.Show(this, lng.s_DoYouWantToCancelWritingDataAndDisplayAnotherSelectedRow, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private void dgvx_Table_SelectionChanged(object sender, EventArgs e)
        {
            if (!bInitData)
            {
                EditSelectedRow();
            }
        }

        private void usrc_EditRow_Update(bool res,ID ID, string Err)
        {
            if (res)
            {
                InitDataTable(ID);

                ID selected_ID = null;
                int index = -1;
                if (GetSelected_ID(ref selected_ID, ref index))
                {
                    ID Identity = selected_ID;
                    if (!m_WorkingSemaphore)
                    {
                        if (SelectedIndexChanged != null)
                        {
                            SelectedIndexChanged(tbl, Identity, index);
                        }
                    }
                }
            }
            else
            {
                if (Err != null)
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

        private void usrc_EditRow_after_InsertInDataBase(SQLTable x_tbl,ID id, bool bRes)
        {
            Identity = id;
            if (after_InsertInDataBase != null)
            {
                after_InsertInDataBase(x_tbl,id, bRes);
            }
            m_WorkingSemaphore = false;
        }

        private void usrc_EditRow_after_UpdateDataBase(SQLTable x_tbl,ID id, bool bRes)
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

        public bool Save(Transaction transaction)
        {
            return this.usrc_EditRow.Save(transaction);
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

        private bool usrc_EditRow_RowReferenceFromTable_Check_NoChangeToOther(SQLTable pSQL_Table, List<usrc_RowReferencedFromTable> usrc_RowReferencedFromTable_List, DBConnectionControl40.ID id, ref bool bCancelDialog, ref ltext Instruction)
        {
            if (this.RowReferenceFromTable_Check_NoChangeToOther!=null)
            {
                return RowReferenceFromTable_Check_NoChangeToOther(pSQL_Table, usrc_RowReferencedFromTable_List, id, ref bCancelDialog, ref Instruction);
            }
            else
            {
                if (this.tbl!=null)
                {
                    if (usrc_RowReferencedFromTable_List.Count==1)
                    {
                        usrc_RowReferencedFromTable ut = usrc_RowReferencedFromTable_List[0];
                        if (ut.m_tbl!=null)
                        {
                            if (ut.m_tbl.TableName.Equals(this.tbl.TableName))
                            {
                                bCancelDialog = true;
                                return false;
                            }
                        }
                    }
                }
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


        public void FillInitialDataAndSetInputControls(object obj)
        {
            usrc_EditRow.FillInitialData();
            usrc_EditRow.CallBackSetInputControlProperties(obj);
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

        private void usrc_EditRow_after_FillDataInputControl(SQLTable m_tbl, ID ID)
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

        private void dgvx_Table_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
