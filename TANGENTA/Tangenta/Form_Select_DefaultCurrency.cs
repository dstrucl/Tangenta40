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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LogFile;
using SQLTableControl;
using BlagajnaTableClass;
using LanguageControl;

namespace Tangenta
{
    public partial class Form_Select_DefaultCurrency : Form
    {
        public long Currency_ID = -1;
        public InvoiceDB.xCurrency m_xCurrency = null;


        DataTable dtCurrency = new DataTable();
        public Form_Select_DefaultCurrency(ref InvoiceDB.xCurrency xxCurrency)
        {
            InitializeComponent();
            m_xCurrency = xxCurrency;
            this.Text = lngRPM.s_SelectDefaultCurrency.s;
            lbl_SelectedCurrency.Text = lngRPM.s_SelectedCurrency.s;
        }


        private void Select_DefaultCurrency_Form_Load(object sender, EventArgs e)
        {
            string Err = null;
            if (!Init(ref Err))
            {
                LogFile.Error.Show(Err);
                this.Close();
                DialogResult = DialogResult.Abort;
            }
        }

        private bool Init(ref string Err)
        {
            string sql = "select * from Currency";
            if (DBSync.DBSync.ReadDataTable(ref dtCurrency, sql, ref Err))
            {
                if (dtCurrency.Rows.Count > 0)
                {
                    dgvx_Currency.DataSource = dtCurrency;
                    SQLTable tbl = new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(myCompany_Person)));
                    tbl.Set_DataGridViewImageColumns_Headers(dgvx_Currency);
                    return true;
                }
                else
                {
                    Err = "ERROR:Select_DefaultCurrency_Form:Select_DefaultCurrency_Form_Load: Currency Table is empty!";
                    return false;
                }
            }
            else
            {
                Err = "ERROR:Select_DefaultCurrency_Form:Select_DefaultCurrency_Form_Load:Err=" + Err;
                return false;
            }

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgr = dgvx_Currency.SelectedRows;
            if (dgr.Count > 0)
            {
                int index = dgvx_Currency.SelectedRows[0].Index;
                Currency_ID = (long)dtCurrency.Rows[index]["ID"];
                m_xCurrency.ID = Currency_ID;
                m_xCurrency.Name = (string)dtCurrency.Rows[index]["Name"];
                m_xCurrency.Abbreviation = (string)dtCurrency.Rows[index]["Abbreviation"];
                m_xCurrency.Symbol = (string)dtCurrency.Rows[index]["Symbol"];
                m_xCurrency.CurrencyCode = (int)dtCurrency.Rows[index]["CurrencyCode"];
                m_xCurrency.DecimalPlaces = (int)dtCurrency.Rows[index]["DecimalPlaces"];
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvx_Currency_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgr = dgvx_Currency.SelectedRows;
            if (dgr.Count > 0)
            {
                int index = dgvx_Currency.SelectedRows[0].Index;
                txt_SelectedCurrency.Text = (string)dtCurrency.Rows[index]["Name"] + " (" + (string)dtCurrency.Rows[index]["Abbreviation"] + ")," + (string)dtCurrency.Rows[index]["Symbol"]; ;
            }
        }
    }
}
