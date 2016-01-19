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
    public partial class Form_PrinterSettings : Form
    {
        usrc_Printer m_usrc_Printer = null;
        public Form_PrinterSettings(usrc_Printer xusrc_Printer)
        {
            InitializeComponent();
            m_usrc_Printer = xusrc_Printer;
        }

        private void Form_PrinterSettings_Load(object sender, EventArgs e)
        {
            this.Top = m_usrc_Printer.Top + m_usrc_Printer.Height;
            this.Left = m_usrc_Printer.Right - this.Width;
        }
    }
}
