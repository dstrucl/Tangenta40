﻿#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using LanguageControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace State_ISO_3166
{
    public partial class Form_Select_State_ISO_3166 : Form
    {
        private DataTable dt_ISO_3166;
        public string State = null;
        public string State_ISO_3166_a2 = null;
        public string State_ISO_3166_a3 = null;
        public short State_ISO_3166_num = -1;

        public Form_Select_State_ISO_3166(DataTable dt_ISO_3166)
        {
            InitializeComponent();
            this.dt_ISO_3166 = dt_ISO_3166;
            dgvx_ISO_3166.DataSource = this.dt_ISO_3166;
            dgvx_ISO_3166.Columns["State"].HeaderText = lngRPM.s_State.s;
            dgvx_ISO_3166.Columns["a2"].HeaderText = lngRPM.ss_Abbreviation.s + " a2";
            dgvx_ISO_3166.Columns["a3"].HeaderText = lngRPM.ss_Abbreviation.s + " a3";
            dgvx_ISO_3166.Columns["num"].HeaderText = lngRPM.s_Number.s;
            this.Text = lngRPM.s_Form_Select_State_ISO_3166_Title.s;
            lngRPM.s_OK.Text(btn_OK);
            lngRPM.s_Cancel.Text(btn_Cancel);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void Form_Select_State_ISO_3166_Load(object sender, EventArgs e)
        {
            txt_SelectState.Focus();
            this.dgvx_ISO_3166.SelectionChanged += new System.EventHandler(this.dgvx_ISO_3166_SelectionChanged);
        }

        private void txt_SelectState_TextChanged(object sender, EventArgs e)
        {
            this.dgvx_ISO_3166.SelectionChanged -= new System.EventHandler(this.dgvx_ISO_3166_SelectionChanged);
            string s = txt_SelectState.Text + "*";
            DataRow[] drs = dt_ISO_3166.Select("State LIKE '" + s+"'");
            if (drs.Count()>0)
            {
                int iRowIndex = dt_ISO_3166.Rows.IndexOf(drs[0]);
                dgvx_ISO_3166.CurrentCell = dgvx_ISO_3166.Rows[iRowIndex].Cells[0];
            }
            this.dgvx_ISO_3166.SelectionChanged += new System.EventHandler(this.dgvx_ISO_3166_SelectionChanged);
        }

        private void dgvx_ISO_3166_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgvc = this.dgvx_ISO_3166.SelectedRows;
            if (dgvc.Count>0)
            {
                DataGridViewRow dgvr = dgvc[0];
                int iRow = dgvx_ISO_3166.Rows.IndexOf(dgvr);
                this.txt_SelectState.TextChanged -= txt_SelectState_TextChanged;
                this.txt_SelectState.Text = (string)this.dt_ISO_3166.Rows[iRow]["State"];
                this.txt_SelectState.TextChanged += txt_SelectState_TextChanged;
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgvc = this.dgvx_ISO_3166.SelectedRows;
            if (dgvc.Count > 0)
            {
                DataGridViewRow dgvr = dgvc[0];
                int iRow = dgvx_ISO_3166.Rows.IndexOf(dgvr);
                this.txt_SelectState.TextChanged -= txt_SelectState_TextChanged;
                this.txt_SelectState.Text = (string)this.dt_ISO_3166.Rows[iRow]["State"];
                this.txt_SelectState.TextChanged += txt_SelectState_TextChanged;
                this.State = (string)this.dt_ISO_3166.Rows[iRow]["State"];
                this.State_ISO_3166_a2 = (string)this.dt_ISO_3166.Rows[iRow]["a2"];
                this.State_ISO_3166_a3 = (string)this.dt_ISO_3166.Rows[iRow]["a3"];
                this.State_ISO_3166_num = (short)this.dt_ISO_3166.Rows[iRow]["num"];
                this.Close();
                DialogResult = DialogResult.OK;
            }
        }
    }
}
