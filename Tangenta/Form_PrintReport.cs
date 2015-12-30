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

namespace Tangenta
{
    public partial class Form_PrintReport : Form
    {
        private usrc_InvoiceTable m_usrc_InvoiceTable = null;

        public Form_PrintReport(usrc_InvoiceTable xusrc_InvoiceTable)
        {
            InitializeComponent();
            m_usrc_InvoiceTable = xusrc_InvoiceTable;
            this.lbl_From_To.Text = xusrc_InvoiceTable.lbl_From_To.Text;
            this.Text = "";
            btn_DURS_output.Text = lngRPM.s_DURS_output.s;
            this.btn_XML_export.Text = lngRPM.s_XML_export.s;
            this.btn_VOD_xml_OPAL_export.Text = lngRPM.s_VODxml_OPAL_export.s;
        }

        private void Form_PrintReport_Load(object sender, EventArgs e)
        {
            this.m_usrc_Print.Init(null);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            this.m_usrc_Print.PrintReport(m_usrc_InvoiceTable);
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void btn_DURS_output_Click(object sender, EventArgs e)
        {
            DURS_output();
        }

        private void DURS_output()
        {
            Form_DURS_output DURS_output_dlg = new Form_DURS_output(m_usrc_InvoiceTable);
            DURS_output_dlg.ShowDialog();
        }

        private void btn_XML_export_Click(object sender, EventArgs e)
        {
            Form_XML_output XML_output_dlg = new Form_XML_output(m_usrc_InvoiceTable);
            XML_output_dlg.ShowDialog();
        }

        private void btn_VOD_xml_OPAL_export_Click(object sender, EventArgs e)
        {
            Form_VODxml_OPAL_output XML_output_dlg = new Form_VODxml_OPAL_output(m_usrc_InvoiceTable);
            XML_output_dlg.ShowDialog();

        }
    }
}
