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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TangentaCore
{
    public partial class Form_XML_FilesPreview : Form
    {
        private Form_XML_output m_form_XML_output;
        private DataTable dt_Invoice = new DataTable();
        private DataTable dt_Item = new DataTable();

        public Form_XML_FilesPreview()
        {
            InitializeComponent();
        }

        public Form_XML_FilesPreview(Form_XML_output form_XML_output)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.m_form_XML_output = form_XML_output;
            try
            {
                lbl_file_GLAVA.Text = form_XML_output.cmbR_FilePath.Text + form_XML_output.filename_XML_IZPIS_RACUNI_GLAVE_TXT;
                lbl_file_POSTAVKE.Text =form_XML_output.cmbR_FilePath.Text + form_XML_output.filename_XML_IZPIS_RACUNI_POSTAVKE_TXT;
                txt_GLAVA.Text = File.ReadAllText(lbl_file_GLAVA.Text);
                txt_POSTAVKE.Text = File.ReadAllText(lbl_file_POSTAVKE.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, lng.s_Error.s + ":" + ex.Message);
            }
        }

        private void Form_XML_FilesPreview_Load(object sender, EventArgs e)
        {
            try
            { 
                dt_Invoice.ReadXml(lbl_file_GLAVA.Text);
                dgvx_Invoice.DataSource = dt_Invoice;
                dt_Item.ReadXml(lbl_file_POSTAVKE.Text);
                dgvx_Items.DataSource = dt_Item;
                CheckInvoices(dt_Invoice, dt_Item);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, lng.s_Error.s + ":" + ex.Message);
            }
        }

        private void CheckInvoices(DataTable dt_Invoice, DataTable dt_Item)
        {
            string sError = "";
            foreach (DataRow dr_Invoice in dt_Invoice.Rows)
            {
                string InvoiceNumber = (string)dr_Invoice[m_form_XML_output.Invoices.c_Stevilka_Racuna];
                decimal dGrossSum = (decimal)dr_Invoice[m_form_XML_output.Invoices.c_Znesek_Racuna_skupaj_z_DDV];
                CheckItems(InvoiceNumber, dGrossSum, ref sError);
            }
            if (sError.Length>0)
            {
                LogFile.Error.Show(sError);
            }
        }

        private void CheckItems(string InvoiceNumber, decimal dGrossSum, ref string sError)
        {
            DataRow[] dr_Items = dt_Item.Select(m_form_XML_output.Invoices.c_Stevilka_Racuna + " = '"+InvoiceNumber+"'");
            if (dr_Items.Count()>0)
            {
                decimal gross_sum = 0;
                foreach (DataRow dr_Item in dr_Items)
                {
                    decimal d_price_per_unit = (decimal) dr_Item[m_form_XML_output.Items.cp_Cena_blaga_oziroma_storitve_na_enoto_mere_skupaj_z_DDV];
                    decimal d_price = d_price_per_unit * (decimal)dr_Item[m_form_XML_output.Items.cp_Kolicina_blaga_oziroma_storitve];
                    gross_sum += d_price;
                }
                if (dGrossSum!=gross_sum)
                {
                    sError += "ERROR:Invoice:" + InvoiceNumber + " " + dGrossSum.ToString() + " <> " + gross_sum.ToString()+"\r\n";
                }
            }
            else
            {
                sError += "ERROR:Invoice" + InvoiceNumber + " has no items ! \r\n";
            }
        }
    }
}
