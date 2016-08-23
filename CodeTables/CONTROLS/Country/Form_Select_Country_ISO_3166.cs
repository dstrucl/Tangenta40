#region LICENSE 
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

namespace Country_ISO_3166
{
    public partial class Form_Select_Country_ISO_3166 : Form
    {
        private NavigationButtons.Navigation nav = null;
        private DataTable dt_ISO_3166;
        public string Country= null;
        public string Country_ISO_3166_a2 = null;
        public string Country_ISO_3166_a3 = null;
        public short Country_ISO_3166_num = -1;
        public string DefaultCountry = null;

        public Form_Select_Country_ISO_3166(DataTable dt_ISO_3166, string xDefaultCountry, string xTitle, NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;
            DefaultCountry = xDefaultCountry;
            this.dt_ISO_3166 = dt_ISO_3166;
            dgvx_ISO_3166.DataSource = this.dt_ISO_3166;
            dgvx_ISO_3166.Columns["Country"].HeaderText = lngRPM.s_Country.s;
            dgvx_ISO_3166.Columns["a2"].HeaderText = lngRPM.ss_Abbreviation.s + " a2";
            dgvx_ISO_3166.Columns["a3"].HeaderText = lngRPM.ss_Abbreviation.s + " a3";
            dgvx_ISO_3166.Columns["num"].HeaderText = lngRPM.s_Number.s;
            if (xTitle != null)
            {
                this.Text = xTitle;
            }
            else
            {
                this.Text = lngRPM.s_Form_Select_Country_ISO_3166_Title.s;
            }
            usrc_NavigationButtons1.Init(nav);
        }

        private void do_Cancel()
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void Form_Select_Country_ISO_3166_Load(object sender, EventArgs e)
        {
            if (DefaultCountry != null)
            {
                DataRow[] drs = dt_ISO_3166.Select("Country = '" + DefaultCountry + "'");
                if (drs.Count() > 0)
                {
                    int iRowIndex = dt_ISO_3166.Rows.IndexOf(drs[0]);
                    dgvx_ISO_3166.CurrentCell = dgvx_ISO_3166.Rows[iRowIndex].Cells[0];
                    txt_SelectCountry.Text = (string) dgvx_ISO_3166.Rows[iRowIndex].Cells[0].Value;
                }
            }
            txt_SelectCountry.Focus();

            this.dgvx_ISO_3166.SelectionChanged += new System.EventHandler(this.dgvx_ISO_3166_SelectionChanged);
        }

        private void txt_SelectCountry_TextChanged(object sender, EventArgs e)
        {
            this.dgvx_ISO_3166.SelectionChanged -= new System.EventHandler(this.dgvx_ISO_3166_SelectionChanged);
            string s = txt_SelectCountry.Text + "*";
            DataRow[] drs = dt_ISO_3166.Select("Country LIKE '" + s+"'");
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
                DataRowView drv = (DataRowView)dgvx_ISO_3166.Rows[iRow].DataBoundItem;
                DataRow dr = drv.Row;
                iRow = this.dt_ISO_3166.Rows.IndexOf(dr);
                this.txt_SelectCountry.TextChanged -= txt_SelectCountry_TextChanged;
                this.txt_SelectCountry.Text = (string)this.dt_ISO_3166.Rows[iRow]["Country"];
                this.txt_SelectCountry.TextChanged += txt_SelectCountry_TextChanged;
            }
        }

        private void do_OK()
        {
            DataGridViewSelectedRowCollection dgvc = this.dgvx_ISO_3166.SelectedRows;
            if (dgvc.Count > 0)
            {
                DataGridViewRow dgvr = dgvc[0];
                int iRow = dgvx_ISO_3166.Rows.IndexOf(dgvr);
                DataRowView drv = (DataRowView)dgvx_ISO_3166.Rows[iRow].DataBoundItem;
                DataRow dr = drv.Row;
                iRow = this.dt_ISO_3166.Rows.IndexOf(dr);
                this.txt_SelectCountry.TextChanged -= txt_SelectCountry_TextChanged;
                this.txt_SelectCountry.Text = (string)this.dt_ISO_3166.Rows[iRow]["Country"];
                this.txt_SelectCountry.TextChanged += txt_SelectCountry_TextChanged;
                this.Country= (string)this.dt_ISO_3166.Rows[iRow]["Country"];
                this.Country_ISO_3166_a2 = (string)this.dt_ISO_3166.Rows[iRow]["a2"];
                this.Country_ISO_3166_a3 = (string)this.dt_ISO_3166.Rows[iRow]["a3"];
                this.Country_ISO_3166_num = (short)this.dt_ISO_3166.Rows[iRow]["num"];
                this.Close();
                DialogResult = DialogResult.OK;
            }
        }

        private void usrc_NavigationButtons1_ButtonPressed(NavigationButtons.Navigation.eEvent evt)
        {
            nav.eExitResult = evt;
            switch (nav.m_eButtons)
            {
                case NavigationButtons.Navigation.eButtons.PrevNextExit:
                    switch (evt)
                    {
                        case NavigationButtons.Navigation.eEvent.NEXT:
                            do_OK();
                            break;
                        case NavigationButtons.Navigation.eEvent.PREV:
                            do_Cancel();
                            break;
                        case NavigationButtons.Navigation.eEvent.EXIT:
                            do_Cancel();
                            break;
                    }
                    break;
                case NavigationButtons.Navigation.eButtons.OkCancel:
                    switch (evt)
                    {
                        case NavigationButtons.Navigation.eEvent.OK:
                            do_OK();
                            break;
                        case NavigationButtons.Navigation.eEvent.CANCEL:
                            do_Cancel();
                            break;
                    }
                    break;

            }
        }

        private void dgvx_ISO_3166_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
