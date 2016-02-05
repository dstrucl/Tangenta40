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

namespace SQLTableControl
{
    public partial class usrc_RowReferencedFromTable : UserControl
    {
        SQLTable m_tbl = null;
        DataTable m_dt = null;
        SQLTable m_tbl_referenced = null;
        long m_tbl_referenced_ID = -1;

        public usrc_RowReferencedFromTable()
        {
            InitializeComponent();
            this.lbl_TableName.Text = lngRPM.s_Table.s;
            this.lbl_ReferencedTableRow.Text = lngRPM.s_ReferencedTableRow.s;
        }

        public void Init(SQLTable x_tbl, SQLTable x_tbl_referenced, long x_tbl_referenced_ID, DataTable x_dt)
        {
            m_tbl = x_tbl;
            this.txt_TableName.Text = m_tbl.lngTableName.s;
            m_dt = x_dt;
            m_tbl_referenced = x_tbl_referenced;
            m_tbl_referenced_ID = x_tbl_referenced_ID;
            this.txt_ReferencedTableRow.Text = m_tbl_referenced.lngTableName.s + " ID = " + m_tbl_referenced_ID.ToString();
            dgvx_References.DataSource = m_dt;
            m_tbl.Set_DataGridViewImageColumns_Headers(dgvx_References);

        }
    }
}
