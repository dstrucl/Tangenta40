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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using LanguageControl;
using DBTypes;
using FiscalVerificationOfInvoices_SLO;
using System.IO;

namespace Tangenta
{
    public partial class usrc_PrinterSettings : UserControl
    {
        private Printer Printer = null;
        private string PaperName;

        public usrc_PrinterSettings()
        {
            InitializeComponent();
            this.Printer = Program.usrc_Printer1.Printer;
            lbl_PrinterName.Text = lngRPM.s_Printer.s;
            this.lbl_PrinterName_Value.Text = Printer.printer_settings.PrinterName;
            lbl_PaperName.Text = lngRPM.s_PaperName.s + ":";
            this.lbl_PaperName_Value.Text = Printer.page_settings.PaperSize.PaperName;
            PaperName = Printer.page_settings.PaperSize.PaperName;
            chk_PrintAll.Text = lngRPM.s_chk_PrintAll.s;
            this.chk_PrintAll.CheckedChanged -= new System.EventHandler(this.chk_PrintAll_CheckedChanged);
            chk_PrintAll.Checked = Properties.Settings.Default.PrintAtOnce;
            this.Printer.PrintInBuffer = chk_PrintAll.Checked;
            this.chk_PrintAll.CheckedChanged += new System.EventHandler(this.chk_PrintAll_CheckedChanged);

        }


        private void btn_SelectPrinter_Click(object sender, EventArgs e)
        {
            if (this.Printer.Select(null))
            {
                Printer.PrinterName = Printer.printer_settings.PrinterName;
                PaperName = Printer.page_settings.PaperSize.PaperName;
                this.lbl_PrinterName_Value.Text = Printer.printer_settings.PrinterName;
                this.lbl_PaperName_Value.Text = Printer.page_settings.PaperSize.PaperName;
            }
        }

        private void btn_PageSetup_Click(object sender, EventArgs e)
        {
            Printer.SelectPageSettings();
        }

        private void chk_PrintAll_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PrintAtOnce = chk_PrintAll.Checked;
            Printer.PrintInBuffer = chk_PrintAll.Checked;
            Properties.Settings.Default.Save();
        }


    }
}
