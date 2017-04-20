using LanguageControl;
using Startup;
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
        DataTable m_dt = null;
        NavigationButtons.Navigation m_nav = null;
        public bool bChanged = false;

        public Form_DefinePrinters(ref DataTable xdt,NavigationButtons.Navigation xnav, usrc_TangentaPrint xusrc_TangentaPrint)
        {
            InitializeComponent();
            m_dt = xdt;
            m_nav = xnav;
            bChanged = false;
            this.usrc_NavigationButtons1.Init(xnav);
            this.m_usrc_TangentaPrint = xusrc_TangentaPrint;
            lngRPM.s_Form_DefinePrinters.Text(this);
            if (m_dt.Rows.Count > 0)
            {
                for (int i = 0; i < m_dt.Rows.Count; i++)
                {
                    Printer printer = new Printer(i);
                    printer.m_usrc_Printer = new usrc_Printer();
                    printer.m_usrc_Printer.Left = 0;
                    printer.m_usrc_Printer.Init(i, this, printer.GetPrinter());
                    this.panel1.Controls.Add(printer.m_usrc_Printer);
                }
                ArrangePrinterControls();
            }
            SetNavigationButtonsInRelationToPreviouseDialog();
        }

        private void SetNavigationButtonsInRelationToPreviouseDialog()
        {
            if (m_nav!=null)
            {
                if (m_nav.oStartup is startup)
                {
                    if (m_nav.StartupStep_index>0)
                    {
                        if (m_nav.m_eButtons == NavigationButtons.Navigation.eButtons.PrevNextExit)
                        {
                            int iPrev_StartupStep_Index = m_nav.StartupStep_index - 1;
                            if (!(((startup)m_nav.oStartup).Step[iPrev_StartupStep_Index].DialogShown))
                            {
                                    this.usrc_NavigationButtons1.HidePreviousButton();
                            }
                        }
                    }
                }
            }
        }

        private void ArrangePrinterControls()
        {
            int y = 0;
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is usrc_Printer)
                {
                    ((usrc_Printer)ctrl).Top = y;
                    y += ((usrc_Printer)ctrl).Height + 5;
                }
            }
        }
        private void btn_AddPrinter_Click(object sender, EventArgs e)
        {
            int idx = PrintersList.dt.Rows.Count;
            Printer prn = new Printer(idx);
            if (prn.Select(this))
            {
                if (PrintersList.Contains(prn.PrinterName))
                {
                    XMessage.Box.ShowTopMost(this, lngRPM.s_PrinterIsAllreadyOnTheList, lngRPM.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    bChanged = true;
                    usrc_Printer usrc_prn = new usrc_Printer();
                    usrc_prn.Init(PrintersList.Add(prn),this,prn.GetPrinter());
                    this.panel1.Controls.Add(usrc_prn);
                    ArrangePrinterControls();
                }
            }
        }

        internal void Remove(int x_index)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is usrc_Printer)
                {
                    if (((usrc_Printer)ctrl).m_index == x_index)
                    {
                        panel1.Controls.Remove(ctrl);
                        PrintersList.dt.Rows.RemoveAt(x_index);
                        PrintersList.dtPrinterObject.Rows.RemoveAt(x_index);
                        bChanged = true;
                        PrintersList.Save();
                        break;
                    }
                }
            }
            ArrangePrinterControls();
        }

        private void SaveIfChanged()
        {
            bool xbChanged = false;
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is usrc_Printer)
                {
                    if (((usrc_Printer)ctrl).bChanged)
                    {
                        xbChanged = true;
                        PrintersList.Fill(((usrc_Printer)ctrl).m_index,
                                          ((usrc_Printer)ctrl).bInvoicePrinting,
                                          ((usrc_Printer)ctrl).bInvoicePrinting_PaymentCash,
                                          ((usrc_Printer)ctrl).bInvoicePrinting_PaymentCard,
                                          ((usrc_Printer)ctrl).bInvoicePrinting_PaymentBankAccount,
                                          ((usrc_Printer)ctrl).bPrinting_ProformaInvoices,
                                          ((usrc_Printer)ctrl).bPrinting_Reports
                                          );
                        break;
                    }
                }
            }
            if (xbChanged || bChanged)
            {
                if (XMessage.Box.ShowTopMost(this, lngRPM.sPrinterListDataChanged_Save, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    PrintersList.Save();
                }
            }
        }

        private void usrc_NavigationButtons1_ButtonPressed(NavigationButtons.Navigation.eEvent evt)
        {
            switch (evt)
            {
                case NavigationButtons.Navigation.eEvent.NEXT:
                    m_nav.eExitResult = NavigationButtons.Navigation.eEvent.NEXT;
                    this.Close();
                    DialogResult = DialogResult.OK;
                    SaveIfChanged();
                    break;
                case NavigationButtons.Navigation.eEvent.OK:
                    m_nav.eExitResult = NavigationButtons.Navigation.eEvent.OK;
                    this.Close();
                    DialogResult = DialogResult.OK;
                    SaveIfChanged();
                    break;
                case NavigationButtons.Navigation.eEvent.CANCEL:
                    m_nav.eExitResult = NavigationButtons.Navigation.eEvent.CANCEL;
                    this.Close();
                    DialogResult = DialogResult.Cancel;
                    break;
                case NavigationButtons.Navigation.eEvent.EXIT:
                    m_nav.eExitResult = NavigationButtons.Navigation.eEvent.EXIT;
                    this.Close();
                    DialogResult = DialogResult.Abort;
                    break;

                case NavigationButtons.Navigation.eEvent.PREV:
                    m_nav.eExitResult = NavigationButtons.Navigation.eEvent.PREV;
                    this.Close();
                    DialogResult = DialogResult.Cancel;
                    break;
            }
        }
    }
}
