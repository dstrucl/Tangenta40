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
using DBTypes;

namespace TangentaPrint
{
    public partial class usrc_SelectPrintTemplate : UserControl
    {
        object dataSource;
        string displayMember, valueMember;

        public delegate void delagate_SettingsChanged();
        public event delagate_SettingsChanged SettingsChanged = null;
        public byte_array_v Doc_v = null;

        public Printer SelectedPrinter = null;

        public DataTable dtTemplates = null;

        public InvoiceData m_InvoiceData = null;

        public f_doc.StandardPages f_doc_PageType
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


        public f_doc.PageOreintation f_doc_PageOrientation
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



        public string f_doc_TemplateName
        {
            get { return cmb_SelectPrintTemplate.Text; }
            set { string sname = value;
                  cmb_SelectPrintTemplate.Text = sname;
                }
        }

        public long_v Default_DocType_ID_v { get
            {
              if (m_InvoiceData.IsDocInvoice)
                {
                    return GlobalData.doc_type_definitions.HTMLPrintTemplate_Invoice_doc_type_ID;
                }
               else if (m_InvoiceData.IsDocProformaInvoice)
                {
                    return GlobalData.doc_type_definitions.HTMLPrintTemplate_Proforma_Invoice_doc_type_ID;
                }
              else
                {
                    LogFile.Error.Show("ERROR:TangentaPrint:usrc_SelectprintTemplate:Default_DocType_ID_v:Unknown doc type!");
                    return null;
                }
            }
        }

        private long_v m_f_doc_DocType_ID_v = null;
        public long_v f_doc_DocType_ID_v
        {
            get
            {
                return m_f_doc_DocType_ID_v;
            }
            set
            {
                m_f_doc_DocType_ID_v = value;
            }
        }

        public long_v Default_page_type_ID_v
        {
            get
            {
                switch (f_doc_PageOrientation)
                {
                    case f_doc.PageOreintation.PORTRAIT:
                        return GlobalData.doc_page_type_definitions.HTML_doc_page_type_A4_Portrait_ID_v;
                    case f_doc.PageOreintation.LANDSCAPE:
                        return GlobalData.doc_page_type_definitions.HTML_doc_page_type_A4_Landscape_ID_v;
                }
                return null;
            }
        }

        private long_v m_f_doc_page_type_ID_v = null;
        public long_v f_doc_page_type_ID_v
        {
            get
            {
                return m_f_doc_page_type_ID_v;
            }
            set
            {
                m_f_doc_page_type_ID_v = value;
            }
        }
                
        public long_v Default_Language_ID_v {
            get
            {
                return GlobalData.language_definitions.Language_ID_v;
            }

        }

        public long_v m_f_doc_Language_ID_v = null;
        public long_v f_doc_Language_ID_v
        {
            get
            {
                return m_f_doc_Language_ID_v;
            }
            set
            {
                m_f_doc_Language_ID_v = value;
            }

        }

        private string m_f_doc_xDocument_Hash = null;
        public string f_doc_xDocument_Hash
        {
            get
            {
                return m_f_doc_xDocument_Hash;
            }
            set
            {
                m_f_doc_xDocument_Hash = value;
            }
        }

        public string_v f_doc_TemplateDescription {
            get
              {
                if (this.txt_Description.Text.Length == 0)
                {
                    return null;
                }
                else
                {
                    return new string_v(this.txt_Description.Text);
                }
              }
            set
            {
                string_v desc_v = value;
                if (desc_v != null)
                {
                    this.txt_Description.Text = desc_v.v;
                }
                else
                {
                    this.txt_Description.Text = "";
                }
            }
        }

        private bool m_bActive = false;

        public bool f_doc_bActive {
             get { return m_bActive; }
             set { m_bActive = value; }
        }

        private bool m_bCompressed = false;

        public bool f_doc_bCompressed
        {
            get { return m_bCompressed; }
            set { m_bCompressed = value;
                 }
        }

        public bool f_doc_bDefault { get
            {
                return chk_Default.Checked;
            }
            set { chk_Default.Checked = value; }
        }

        public string f_doc_LastTemplateName
        {
            get
            {
                if (m_InvoiceData.IsDocInvoice)
                {
                    if (Properties.Settings.Default.DocInvoicePrintTemplate.Length > 0)
                    {
                        return Properties.Settings.Default.DocInvoicePrintTemplate;
                    }
                    else
                    {
                        return null;
                    }
                }
                else if (m_InvoiceData.IsDocProformaInvoice)
                {
                    if (Properties.Settings.Default.DocProformaInvoicePrintTemplate.Length>0)
                    {
                        return Properties.Settings.Default.DocProformaInvoicePrintTemplate;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaPrint:usrc_SelectPrintTemplate:LastTemplateName: Unknown document type");
                    return null;
                }

            }
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
            lngRPM.s_Default.Text(chk_Default);
            cmb_Language.DataSource = LanguageControl.DynSettings.s_language.sTextArr;
            cmb_Language.SelectedIndex = LanguageControl.DynSettings.LanguageID;
        }


        internal f_doc.eGetPrintDocumentTemplateResult Init(InvoiceData x_InvoiceData)
        {
            this.cmb_SelectPrinter.TextChanged -= new System.EventHandler(this.cmb_SelectPrinter_TextChanged);
            ProgramDiagnostic.Diagnostic.Meassure("f_doc.eGetPrintDocumentTemplateResult Init(InvoiceData x_InvoiceData)", "START");

            m_InvoiceData = x_InvoiceData;
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
                return f_doc.eGetPrintDocumentTemplateResult.ERROR;
            }
            this.rdb_Landscape.CheckedChanged += Rdb_Landscape_CheckedChanged;
            this.rdb_Portrait.CheckedChanged += Rdb_Portrait_CheckedChanged;
            this.rdb_A4.CheckedChanged += Rdb_A4_CheckedChanged; ;
            this.rdb_80.CheckedChanged += Rdb_80_CheckedChanged;
            this.rdb_58.CheckedChanged += Rdb_58_CheckedChanged;

            
            f_doc.eGetPrintDocumentTemplateResult eres = f_doc.GetTemplates(ref dtTemplates,
                           Default_DocType_ID_v,
                           Default_page_type_ID_v,
                           Default_Language_ID_v
                          );
            switch (eres)
            {
                case f_doc.eGetPrintDocumentTemplateResult.OK:
                    {
                        cmb_SelectPrintTemplate.BeginInit();
                        dataSource = dtTemplates;
                        displayMember = "Name";
                        valueMember = "ID";
                        if (dataSource != null)
                        {
                            cmb_SelectPrintTemplate.DisplayMember = displayMember;
                            cmb_SelectPrintTemplate.ValueMember = valueMember;
                            cmb_SelectPrintTemplate.DataSource = dataSource;
                        }
                        cmb_SelectPrintTemplate.EndInit();
                        bool btemplate_selected = false;
                        if (f_doc_LastTemplateName != null)
                        {
                            foreach (DataRow dr in dtTemplates.Rows)
                            {
                                string name = (string)dr["Name"];
                                if (name.Equals(f_doc_LastTemplateName))
                                {
                                    SetValues(dr);
                                    btemplate_selected = true;
                                    ProgramDiagnostic.Diagnostic.Meassure("f_doc.eGetPrintDocumentTemplateResult Init(InvoiceData x_InvoiceData)", "END1");
                                    return eres;
                                }
                            }
                        }
                        else
                        {
                            foreach (DataRow dr in dtTemplates.Rows)
                            {
                                if ((bool)dr["bDefault"])
                                {
                                    SetValues(dr);
                                    btemplate_selected = true;
                                    ProgramDiagnostic.Diagnostic.Meassure("f_doc.eGetPrintDocumentTemplateResult Init(InvoiceData x_InvoiceData)", "END2");
                                    return eres;
                                }
                            }
                        }

                        if (!btemplate_selected)
                        {
                            if (dtTemplates.Rows.Count > 0)
                            {
                                DataRow dr = dtTemplates.Rows[0];
                                SetValues(dr);
                                btemplate_selected = true;
                                ProgramDiagnostic.Diagnostic.Meassure("f_doc.eGetPrintDocumentTemplateResult Init(InvoiceData x_InvoiceData)", "END3");
                                return eres;
                            }
                        }

                    }
                    break;

            }

            ProgramDiagnostic.Diagnostic.Meassure("f_doc.eGetPrintDocumentTemplateResult Init(InvoiceData x_InvoiceData)", "END4");
            this.cmb_SelectPrinter.TextChanged += new System.EventHandler(this.cmb_SelectPrinter_TextChanged);

            return eres;
        }

        private void SetValues(DataRow dr)
        {
            f_doc_bDefault = (bool)dr["bDefault"];
            f_doc_TemplateName = (string)dr["Name"];
            f_doc_TemplateDescription = tf.set_string(dr["Description"]);
            long doc_ID = (long)dr["ID"];
            byte_array_v xDoc_v = null;
            string_v xDoc_Hash_v = null;
            long_v DocType_ID_v = null;
            long_v doc_page_type_ID_v = null;
            long_v Language_ID_v = null;
            bool_v Compressed_v = null;
            switch (f_doc.GetTemplate(doc_ID, ref xDoc_v, ref xDoc_Hash_v, ref DocType_ID_v, ref doc_page_type_ID_v, ref Language_ID_v, ref Compressed_v))
            {
                case f_doc.eGetPrintDocumentTemplateResult.OK:
                    f_doc_DocType_ID_v = DocType_ID_v;
                    f_doc_page_type_ID_v = doc_page_type_ID_v;
                    f_doc_xDocument_Hash = xDoc_Hash_v.v;
                    f_doc_Language_ID_v = Language_ID_v;
                    if (Compressed_v != null)
                    {
                        f_doc_bCompressed = Compressed_v.v;
                    }
                    else
                    {
                        f_doc_bCompressed = false;
                    }
                    Doc_v = xDoc_v;
                    break;
                default:
                    Doc_v = null;
                    f_doc_DocType_ID_v = null;
                    f_doc_page_type_ID_v = null;
                    f_doc_xDocument_Hash = null;
                    f_doc_bCompressed = false;
                    f_doc_Language_ID_v = null;
                    break;
            }
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
            ProgramDiagnostic.Diagnostic.Meassure("MakeInvoicePrinterSelection", "START");

            this.cmb_SelectPrinter.Items.Clear();
            bool bSelected = false;
            int iCount = PrintersList.dt.Rows.Count;
            ProgramDiagnostic.Diagnostic.Meassure("MakeInvoicePrinterSelection", "before for (int i=0;i<iCount;i++)");
            for (int i=0;i<iCount;i++)
            {
                ProgramDiagnostic.Diagnostic.Meassure("MakeInvoicePrinterSelection", "before if (Match_m_MethodOfPayment(PrintersList.dt.Rows[i]))");
                if (Match_m_MethodOfPayment(PrintersList.dt.Rows[i]))
                {
                    ProgramDiagnostic.Diagnostic.Meassure("MakeInvoicePrinterSelection", "after if (Match_m_MethodOfPayment(PrintersList.dt.Rows[i])) = true");
                    this.cmb_SelectPrinter.Items.Add((string)PrintersList.dt.Rows[i][PrintersList.dcol_PrinterName]);
                    bSelected = true;
                }
            }
            ProgramDiagnostic.Diagnostic.Meassure("MakeInvoicePrinterSelection", "after for (int i=0;i<iCount;i++)");
            if (bSelected)
            {
                ProgramDiagnostic.Diagnostic.Meassure("MakeInvoicePrinterSelection", "before this.cmb_SelectPrinter.SelectedIndex = 0;");
                this.cmb_SelectPrinter.SelectedIndex = 0;
                ProgramDiagnostic.Diagnostic.Meassure("MakeInvoicePrinterSelection", "after this.cmb_SelectPrinter.SelectedIndex = 0;");
            }
            else
            {
                SelectPrinter();
            }
            ProgramDiagnostic.Diagnostic.Meassure("MakeInvoicePrinterSelection", "END");
        }

        private bool Match_m_MethodOfPayment(DataRow dr)
        {
            switch (m_InvoiceData.AddOnDI.m_MethodOfPayment.eType)
            {
                case GlobalData.ePaymentType.CASH:
                    return ((bool)dr[PrintersList.dcol_InvoicePrinting_PaymentCash]);
                case GlobalData.ePaymentType.CASH_OR_PAYMENT_CARD:
                    return (((bool)dr[PrintersList.dcol_InvoicePrinting_PaymentCash])
                            || ((bool)dr[PrintersList.dcol_InvoicePrinting_PaymentCard]));
                case GlobalData.ePaymentType.PAYMENT_CARD:
                    return ((bool)dr[PrintersList.dcol_InvoicePrinting_PaymentCard]);

                case GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER:
                    return ((bool)dr[PrintersList.dcol_InvoicePrinting_PaymentBankAccount]);

                default:
                    rdb_A4.Checked = true;
                    grp_Orientation.Enabled = true;
                    rdb_Portrait.Checked = true;
                    return false;

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
                if (f_doc.GetTemplate(id, ref doc_name, ref Doc_v.v, ref m_bCompressed))
                {
                    this.f_doc_TemplateName = doc_name;
                }
            }
        }
    }
}
