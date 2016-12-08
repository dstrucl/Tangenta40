using LanguageControl;
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
    public partial class Form_DefinePrinters : Form
    {
        private usrc_TangentaPrint m_usrc_TangentaPrint;

        public Form_DefinePrinters(usrc_TangentaPrint xusrc_TangentaPrint)
        {
            InitializeComponent();
            this.m_usrc_TangentaPrint = xusrc_TangentaPrint;
            lngRPM.s_Form_DefinePrinters.Text(this);
            int xPos = 5;
            for (int i =0;i<m_usrc_TangentaPrint.Printers.Length;i++)
            {
                Printer printer = m_usrc_TangentaPrint.Printers[i];
                printer.m_usrc_Printer = new usrc_Printer();
                printer.m_usrc_Printer.Left = xPos;
                this.Controls.Add(printer.m_usrc_Printer);
                xPos = xPos + printer.m_usrc_Printer.Width+5;
                printer.m_usrc_Printer.Init(printer);
            }
        }
    }
}
