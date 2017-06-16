using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using TangentaDB;
using System.Drawing.Printing;
using CodeTables;
using TangentaTableClass;

namespace TangentaPrint
{
    public partial class usrc_SelectPrintTemplate : UserControl
    {

        public delegate void delagate_SettingsChanged();
        public event delagate_SettingsChanged SettingsChanged = null;
        public byte[] Doc = null;
        public bool bCompressedDocumentTemplate = false;

        public Printer SelectedPrinter = null;

        public f_doc.StandardPages PageType
        {
            get
            {
                if (rdb_A4.Checked)
                {
                    return f_doc.StandardPages.A4;
                }
                else if (rdb_58.Checked)
                {
                    return f_doc.StandardPages.ROLL_58;
                }
                else if (rdb_80.Checked)
                {
                    return f_doc.StandardPages.ROLL_80;
                }
                else
                {
                    return f_doc.StandardPages.A4;
                }
            }
        }


        public f_doc.PageOreintation PageOrientation
        {
            get {
                    if (rdb_Landscape.Checked)
                    {
                        return f_doc.PageOreintation.LANDSCAPE;
                    }
                    else
                    {
                         return f_doc.PageOreintation.PORTRAIT;
                    }
            }
        }

        public int SelectedLangugage
        {
            get { return 1; }
        }


        public string TemplateName
        {
            get { return cmb_SelectPrintTemplate.Text; }
            set { cmb_SelectPrintTemplate.Text = value; }
        }

        public usrc_SelectPrintTemplate()
        {
            InitializeComponent();
            lngRPM.s_Printer.Text(lbl_printer);
            lngRPM.s_SelectPrinter.Text(btn_SelectPrinter);

            lngRPM.s_Language.Text(lbl_Language);
            lngRPM.s_PaperSize.Text(grp_PaperSize);
            lngRPM.s_Template.Text(lbl_Template, ":");
            lngRPM.s_A4.Text(rdb_A4);
            lngRPM.s_Roll_80.Text(rdb_80);
            lngRPM.s_Roll_58.Text(rdb_58);
            lngRPM.s_PaperOrientation.Text(grp_Orientation);
            lngRPM.s_PaperOrientation_Portrait.Text(rdb_Portrait);
            lngRPM.s_PaperOrientation_Landscape.Text(rdb_Landscape);
            lngRPM.s_Description.Text(lbl_Description);
            cmb_Language.DataSource = LanguageControl.DynSettings.s_language.sTextArr;
            cmb_Language.SelectedIndex = LanguageControl.DynSettings.LanguageID;
        }


        internal bool Init(InvoiceData m_InvoiceData)
        {
            if (m_InvoiceData.IsDocInvoice)
            {
                MakeInvoicePrinterSelection(m_InvoiceData);
            }
            else if (m_InvoiceData.IsDocProformaInvoice)
            {
                rdb_A4.Checked = true;
                grp_Orientation.Enabled = true;
                rdb_Portrait.Checked = true;
            }
            else
            {
                LogFile.Error.Show("ERROR:Form_SelectTemplate:Form_SelectTemplate:Unknown document type!");
                return false;
            }
            this.rdb_Landscape.CheckedChanged += Rdb_Landscape_CheckedChanged;
            this.rdb_Portrait.CheckedChanged += Rdb_Portrait_CheckedChanged;
            this.rdb_A4.CheckedChanged += Rdb_A4_CheckedChanged; ;
            this.rdb_80.CheckedChanged += Rdb_80_CheckedChanged;
            this.rdb_58.CheckedChanged += Rdb_58_CheckedChanged;
            return true;
        }

        private void Rdb_Portrait_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_Portrait.Checked)
            {
                if (SettingsChanged != null)
                {
                    SettingsChanged();
                }
            }
        }

        private void Rdb_58_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdb_58.Checked)
            {
                if (SettingsChanged != null)
                {
                    SettingsChanged();
                }
            }
        }

        private void Rdb_80_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdb_80.Checked)
            {
                if (SettingsChanged != null)
                {
                    SettingsChanged();
                }
            }
        }

        private void Rdb_A4_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdb_A4.Checked)
            {
                if (SettingsChanged != null)
                {
                    SettingsChanged();
                }
            }
        }

        private void Rdb_Landscape_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_Landscape.Checked)
            {
                if (SettingsChanged != null)
                {
                    SettingsChanged();
                }
            }
        }

        private void MakeInvoicePrinterSelection(InvoiceData m_InvoiceData)
        {

            this.cmb_SelectPrinter.Items.Clear();
            string selection = PrintersList.dcol_InvoicePrinting.ColumnName + " = true";

            switch (m_InvoiceData.AddOnDI.m_MethodOfPayment.eType)
            {
                case GlobalData.ePaymentType.CASH:
                    selection += " and " + PrintersList.dcol_InvoicePrinting_PaymentCash.ColumnName + " = true";
                    break;
                case GlobalData.ePaymentType.CASH_OR_PAYMENT_CARD:
                    selection += " and ((" + PrintersList.dcol_InvoicePrinting_PaymentCash.ColumnName + " = true ) or (" + PrintersList.dcol_InvoicePrinting_PaymentCard.ColumnName + " = true ))";
                    break;
                case GlobalData.ePaymentType.PAYMENT_CARD:
                    selection += " and (" + PrintersList.dcol_InvoicePrinting_PaymentCard.ColumnName + " = true )";
                    break;

                default:
                    rdb_A4.Checked = true;
                    grp_Orientation.Enabled = true;
                    rdb_Portrait.Checked = true;
                    break;

            }
            DataRow[] drs = PrintersList.dt.Select(selection);
            if (drs.Count() > 0)
            {
                foreach (DataRow dr in drs)
                {
                    this.cmb_SelectPrinter.Items.Add((string)dr[PrintersList.dcol_PrinterName]);
                }
                this.cmb_SelectPrinter.SelectedIndex = 0;
            }
            else
            {
                SelectPrinter();
            }

        }

        public bool SelectPrinter()
        {
            Printer  prn = null;
            prn = new Printer(0);
            if (prn.Select((Form)this.Parent))
            {
                SelectedPrinter = null;
                SelectedPrinter = prn;
                this.cmb_SelectPrinter.Text = prn.PrinterName;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btn_SelectPrinter_Click(object sender, EventArgs e)
        {
            SelectPrinter();
        }

        private void cmb_SelectPrinter_TextChanged(object sender, EventArgs e)
        {
            string PrinterName = cmb_SelectPrinter.Text;
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                if (SelectedPrinter != null)
                {
                    if (SelectedPrinter.Equals(printer))
                    {
                        GetSettings(SelectedPrinter);
                        return;
                    }
                }
                if (printer.Equals(PrinterName))
                {
                    if (SelectedPrinter != null)
                    {
                        if (SelectedPrinter.PrinterName.Equals(PrinterName))
                        {
                            GetSettings(SelectedPrinter);
                            return;
                        }
                        else
                        {
                            if (GetSelectedPrinterFromPrinterList(PrinterName, ref SelectedPrinter))
                            {
                                GetSettings(SelectedPrinter);
                                return;
                            }
                            else
                            {
                                SelectedPrinter = null;
                                SelectedPrinter = new Printer(0);
                                SelectedPrinter.PrinterName = PrinterName;
                                GetSettings(SelectedPrinter);
                            }
                        }
                    }
                    else
                    {
                        if (GetSelectedPrinterFromPrinterList(PrinterName,ref SelectedPrinter))
                        {
                            GetSettings(SelectedPrinter);
                            return;
                        }
                        else
                        {
                            SelectedPrinter = new Printer(0);
                            SelectedPrinter.PrinterName = PrinterName;
                            GetSettings(SelectedPrinter);
                        }
                        return;
                    }
                }
            }
        }

        private bool GetSelectedPrinterFromPrinterList(string printerName, ref Printer selectedPrinter)
        {
            int iCount = PrintersList.dt.Rows.Count;
            if (iCount>0)
            {
                for (int i=0;i<iCount;i++)
                {
                    string sPrinterName = (string)PrintersList.dt.Rows[i][PrintersList.dcol_PrinterName];
                    if (sPrinterName.Equals(printerName))
                    {
                        selectedPrinter = null;
                        selectedPrinter = (Printer)PrintersList.dtPrinterObject.Rows[i][PrintersList.dcol_PrinterObject];
                        return true;
                    }
                }
            }
            return false;
        }

        private void GetSettings(Printer selectedPrinter)
        {
            SelectedPrinter = selectedPrinter;
            if (SelectedPrinter== null)
            {
                LogFile.Error.Show("WARNING:SelectedPrinter is not defined!");
                return;
            }
            if (SelectedPrinter.printer_settings==null)
            {
                LogFile.Error.Show("WARNING:printer_settings is not defined!");
                return;
            }
            try
            {
                if (SelectedPrinter.printer_settings.DefaultPageSettings.Landscape)
                {
                    this.rdb_Landscape.Checked = true;
                }
                else
                {
                    this.rdb_Portrait.Checked = true;
                }
                if (SelectedPrinter.printer_settings.DefaultPageSettings.PaperSize != null)
                {
                    if (SelectedPrinter.printer_settings.DefaultPageSettings.PaperSize.PaperName.Contains("A4"))
                    {
                        rdb_A4.Checked = true;
                    }
                    else
                    {
                        rdb_A4.Checked = false;
                    }
                }
                else
                {

                    LogFile.Error.Show("WARNING:Selected printer:" + SelectedPrinter.PrinterName + " has no Paper Size information");
                }
            }
            catch (Exception ex)
            {
                LogFile.Error.Show("WARNING:Selected printer:" + SelectedPrinter.PrinterName + " printer exception ="+ex.Message);
            }
            if (SettingsChanged!=null)
            {
                SettingsChanged();
            }
            return;
        }

        private void cmb_Language_SelectedValueChanged(object sender, EventArgs e)
        {
            if (SettingsChanged != null)
            {
                SettingsChanged();
            }
        }

        private void cmb_SelectPrintTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SettingsChanged != null)
            {
                SettingsChanged();
            }
        }

        private void btn_EditTemplates_Click(object sender, EventArgs e)
        {
            SQLTable tbl_doc = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(doc)));
            Form_Templates edt_doc_dlg = new Form_Templates(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                            tbl_doc,
                                                            "doc_$$Name");
            if (edt_doc_dlg.ShowDialog() == DialogResult.OK)
            {
                long id = edt_doc_dlg.ID_v.v;
                string doc_name = null;
                f_doc.SetDefault(id);
                if (f_doc.GetTemplate(id, ref doc_name, ref Doc, ref bCompressedDocumentTemplate))
                {
                    this.TemplateName = doc_name;
                }
            }
        }
    }
}
