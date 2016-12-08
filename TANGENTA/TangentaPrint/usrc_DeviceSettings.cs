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
//using FiscalVerificationOfInvoices_SLO;
using System.IO;

namespace TangentaPrint
{
    public partial class usrc_DeviceSettings : UserControl
    {
        private Printer m_Printer = null;
        private string PaperName;

        public usrc_DeviceSettings()
        {
            InitializeComponent();
        }

        public void Init(Printer xPrinter)
        {
            m_Printer = xPrinter;
            lbl_PrinterName.Text = lngRPM.s_Printer.s;
            this.lbl_PrinterName_Value.Text = m_Printer.printer_settings.PrinterName;
            lbl_PaperName.Text = lngRPM.s_PaperName.s + ":";
            if (m_Printer.page_settings != null)
            {
                this.lbl_PaperName_Value.Text = m_Printer.page_settings.PaperSize.PaperName;
                PaperName = m_Printer.page_settings.PaperSize.PaperName;
            }
            else
            {
                this.lbl_PaperName_Value.Text = "??";
                PaperName = "??";
            }

            chk_PrintAll.Text = lngRPM.s_chk_PrintAll.s;
            this.chk_PrintAll.CheckedChanged -= new System.EventHandler(this.chk_PrintAll_CheckedChanged);
            chk_PrintAll.Checked = Properties.Settings.Default.Printer1_PrintAtOnce;
            m_Printer.PrintInBuffer = chk_PrintAll.Checked;
            this.chk_PrintAll.CheckedChanged += new System.EventHandler(this.chk_PrintAll_CheckedChanged);
        }
        


        private void btn_SelectPrinter_Click(object sender, EventArgs e)
        {
            if (m_Printer.Select(null))
            {
                m_Printer.PrinterName = m_Printer.printer_settings.PrinterName;
                if (m_Printer.page_settings != null)
                {
                    PaperName = m_Printer.page_settings.PaperSize.PaperName;
                    this.lbl_PaperName_Value.Text = m_Printer.page_settings.PaperSize.PaperName;
                }
                else
                {
                    PaperName = "??";
                    this.lbl_PaperName_Value.Text = "??";
                }


                this.lbl_PrinterName_Value.Text = m_Printer.printer_settings.PrinterName;
            }
        }

        private void btn_PageSetup_Click(object sender, EventArgs e)
        {
            m_Printer.SelectPageSettings();
        }

        private void chk_PrintAll_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Printer1_PrintAtOnce = chk_PrintAll.Checked;
            m_Printer.PrintInBuffer = chk_PrintAll.Checked;
            Properties.Settings.Default.Save();
        }


    }
}
