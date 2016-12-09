using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TangentaPrint
{
    public partial class Form_SelectPrinter_from_predefined_printer_list : Form
    {
        public Printer selected_printer = null;
        private List<Printer> m_printer_list = null;
        public Form_SelectPrinter_from_predefined_printer_list(List<Printer> printer_list)
        {
            InitializeComponent();
            m_printer_list = printer_list;
            this.cmb_PrinterList.DataSource = m_printer_list;
            this.cmb_PrinterList.DisplayMember = "PrinterName";
            this.cmb_PrinterList.ValueMember = "ThisPrinter";
            this.cmb_PrinterList.SelectedIndex = 0;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            selected_printer = (Printer) cmb_PrinterList.SelectedValue;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
