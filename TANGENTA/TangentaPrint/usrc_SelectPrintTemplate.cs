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
    /// <summary>
    ///  usrc_SelectPrintTemplate inputs are: PrintersList and m_InvoiceData
    ///  in the constructor cmb_Languge is filled with languages
    ///  in the procedure Init on the base of m_InvoiceData and selected Language in cmb_Languge coresponding printers are selected from PrintersList and put (listed,displayed)
    ///  up to the selected printer in cmb_SelectPrinter.Text properties  PaperSize and Paper orientation are shown 
    ///  appropriate templates are selected from DataBase !
    /// <see cref="usrc_Invoice_Preview"/>
    /// </summary>
    /// <seealso cref="HtmlContainerInt"/>

    public partial class usrc_SelectPrintTemplate : UserControl
    {
        object dataSource;
        string displayMember, valueMember;

        public delegate void delagate_SettingsChanged();
        public event delagate_SettingsChanged SettingsChanged = null;
        public byte_array_v Doc_v = null;
        private Printer m_SelectedPrinter = null;

        string_v Page_Name_v = null;
        string_v Page_Description_v = null;
        decimal_v Page_Width_v = null;
        decimal_v Page_Height_v = null;


        public Printer SelectedPrinter
        {
            get
            {
                string printer_name = cmb_SelectPrinter.Text;
                return GetPrinter(printer_name);
            }
        }

        private Printer GetPrinter(string printer_name)
        {
            return new Printer(printer_name);
        }

        public DataTable dtTemplates = null;

        public InvoiceData m_InvoiceData = null;





        public string f_doc_TemplateName
        {
            get { return cmb_SelectPrintTemplate.Text; }
            set { string sname = value;
                  cmb_SelectPrintTemplate.Text = sname;
                }
        }
        public long_v Doc_Type_ID_v { get
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

        private long_v m_Doc_Page_Type_ID_v = null;

        public long_v Doc_Page_Type_ID_v
        {
            get
            {
                return m_Doc_Page_Type_ID_v;
            }
        }

        public long_v Default_Language_ID_v {
            get
            {
                return GlobalData.language_definitions.Language_ID_v;
            }

        }

        public long_v Language_ID_v
        {
            get
            {
                return new long_v((long)cmb_Language.SelectedValue);
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

        public long_v f_doc_DocType_ID_v { get; internal set; }

        public usrc_SelectPrintTemplate()
        {
            InitializeComponent();
            lngRPM.s_Printer.Text(lbl_printer);
            lngRPM.s_SelectPrinter.Text(btn_SelectPrinter);

            lngRPM.s_Language.Text(lbl_Language);
            lngRPM.s_PaperSize.Text(lbl_PaperSize);
            lngRPM.s_Template.Text(lbl_Template, ":");
            lngRPM.s_Description.Text(lbl_Description);
            lngRPM.s_Default.Text(chk_Default);
           
        }


        internal f_doc.eGetPrintDocumentTemplateResult Init(InvoiceData x_InvoiceData)
        {
            m_InvoiceData = x_InvoiceData;
            if (GlobalData.language_definitions != null)
            {
                if (GlobalData.language_definitions.Language_list != null)
                {
                    cmb_Language.DataSource = GlobalData.language_definitions.Language_list;
                    cmb_Language.DisplayMember = "Name";
                    cmb_Language.ValueMember = "ID";
                    cmb_Language.SelectedIndex = LanguageControl.DynSettings.LanguageID;
                }
            }
            return Init();
        }

        private f_doc.eGetPrintDocumentTemplateResult Init()
        {
            RemoveHandlers();
            SetPrinterSelection(m_InvoiceData);

            f_doc.eGetPrintDocumentTemplateResult eres = f_doc.GetTemplates(ref dtTemplates,
                           Doc_Type_ID_v,
                           Language_ID_v
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
                                    AddHandlers();
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
                                    AddHandlers();
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
                                AddHandlers();
                                return eres;
                            }
                        }

                    }
                    break;

            }

            AddHandlers();
            return eres;

        }

        private void AddHandlers()
        {
            this.cmb_Language.SelectedValueChanged += new System.EventHandler(this.cmb_Language_SelectedValueChanged);
            this.btn_EditTemplates.Click += new System.EventHandler(this.btn_EditTemplates_Click);
            this.cmb_SelectPrinter.TextChanged += new System.EventHandler(this.cmb_SelectPrinter_TextChanged);
            this.btn_SelectPrinter.Click += new System.EventHandler(this.btn_SelectPrinter_Click);
        }

        private void RemoveHandlers()
        {
            this.cmb_Language.SelectedValueChanged -= new System.EventHandler(this.cmb_Language_SelectedValueChanged);
            this.btn_EditTemplates.Click -= new System.EventHandler(this.btn_EditTemplates_Click);
            this.cmb_SelectPrinter.TextChanged -= new System.EventHandler(this.cmb_SelectPrinter_TextChanged);
            this.btn_SelectPrinter.Click -= new System.EventHandler(this.btn_SelectPrinter_Click);
        }

        private void SetValues(DataRow dr)
        {
            f_doc_bDefault = (bool)dr["bDefault"];
            f_doc_TemplateName = (string)dr["Name"];
            f_doc_TemplateDescription = tf.set_string(dr["Description"]);
            long doc_ID = (long)dr["ID"];
            string_v Name_v = null;
            string_v Description_v = null;
            byte_array_v xDoc_v = null;
            string_v xDoc_Hash_v = null;
            long_v DocType_ID_v = null;
            long_v doc_page_type_ID_v = null;
            long_v Language_ID_v = null;
            bool_v Compressed_v = null;
            switch (f_doc.GetTemplate(doc_ID,ref Name_v,ref Description_v, ref xDoc_v, ref xDoc_Hash_v, ref DocType_ID_v, ref doc_page_type_ID_v, ref Language_ID_v, ref Compressed_v))
            {
                case f_doc.eGetPrintDocumentTemplateResult.OK:
                    //f_doc_DocType_ID_v = DocType_ID_v;
                    //f_doc_page_type_ID_v = doc_page_type_ID_v;
                    //f_doc_xDocument_Hash = xDoc_Hash_v.v;
                    //f_doc_Language_ID_v = Language_ID_v;
                    if (Compressed_v != null)
                    {
                        f_doc_bCompressed = Compressed_v.v;
                    }
                    else
                    {
                        f_doc_bCompressed = false;
                    }
                    Doc_v = xDoc_v;
                    if (doc_page_type_ID_v!=null)
                    {
                        if (f_doc_page_type.Get(doc_page_type_ID_v.v,ref Page_Name_v,ref Page_Description_v,ref Page_Width_v,ref Page_Height_v))
                        {
                            if (Page_Description_v != null)
                            {
                                lbl_PaperSize_value.Text = Page_Description_v.v;
                            }
                        }
                    }

                    if (Description_v!=null)
                    {
                        this.txt_Description.Text = Description_v.v;
                    }
                    break;

                default:
                    Doc_v = null;
                    //f_doc_DocType_ID_v = null;
                    //f_doc_page_type_ID_v = null;
                    f_doc_xDocument_Hash = null;
                    f_doc_bCompressed = false;
                    //f_doc_Language_ID_v = null;
                    break;
            }
        }


        private void SetPrinterSelection(InvoiceData m_InvoiceData)
        {
            this.cmb_SelectPrinter.Items.Clear();
            bool bSelected = false;
            int iCount = PrintersList.dt.Rows.Count;
            for (int i=0;i<iCount;i++)
            {
                if (Match_m_MethodOfPayment(PrintersList.dt.Rows[i]))
                {
                    this.cmb_SelectPrinter.Items.Add((string)PrintersList.dt.Rows[i][PrintersList.dcol_PrinterName]);
                    bSelected = true;
                }
            }
            if (bSelected)
            {
                this.cmb_SelectPrinter.SelectedIndex = 0;
            }
            else
            {
                SelectPrinter();
            }
        }

        private bool Match_m_MethodOfPayment(DataRow dr)
        {
            m_InvoiceData.AddOnDI.Get(m_InvoiceData.DocInvoice_ID);
            switch (m_InvoiceData.AddOnDI.m_MethodOfPayment_DI.eType)
            {
                case GlobalData.ePaymentType.CASH:
                    return ((bool)dr[PrintersList.dcol_InvoicePrinting_PaymentCash]);

                case GlobalData.ePaymentType.CASH_OR_CARD:
                    return (((bool)dr[PrintersList.dcol_InvoicePrinting_PaymentCash])
                            || ((bool)dr[PrintersList.dcol_InvoicePrinting_PaymentCard]));

                case GlobalData.ePaymentType.CARD:
                    return ((bool)dr[PrintersList.dcol_InvoicePrinting_PaymentCard]);

                case GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER:
                    return ((bool)dr[PrintersList.dcol_InvoicePrinting_PaymentBankAccount]);

                default:
                    return false;

            }
        }

        public bool SelectPrinter()
        {
            Printer  prn = null;
            prn = new Printer(0);
            if (prn.Select((Form)this.Parent))
            {
                m_SelectedPrinter = null;
                m_SelectedPrinter = prn;
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
            Init();
        }

        public void GetSelectedPrinterSettings()
        {
            string PrinterName = cmb_SelectPrinter.Text;
            PrinterSettings.StringCollection printers = System.Drawing.Printing.PrinterSettings.InstalledPrinters;
            foreach (string printer in printers)
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
                            if (GetSelectedPrinterFromPrinterList(PrinterName, ref m_SelectedPrinter))
                            {
                                GetSettings(SelectedPrinter);
                                return;
                            }
                            else
                            {
                                m_SelectedPrinter = null;
                                m_SelectedPrinter = new Printer(0);
                                SelectedPrinter.PrinterName = PrinterName;
                                GetSettings(SelectedPrinter);
                            }
                        }
                    }
                    else
                    {
                        if (GetSelectedPrinterFromPrinterList(PrinterName, ref m_SelectedPrinter))
                        {
                            GetSettings(SelectedPrinter);
                            return;
                        }
                        else
                        {
                            m_SelectedPrinter = new Printer(0);
                            SelectedPrinter.PrinterName = PrinterName;
                            GetSettings(SelectedPrinter);
                        }
                        return;
                    }
                }
            }
        }

        private void cmb_SelectPrinter_TextChanged(object sender, EventArgs e)
        {
            GetSelectedPrinterSettings();
            Init();
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
                        selectedPrinter.bPrinting_Invoices = (bool) PrintersList.dt.Rows[i][PrintersList.dcol_InvoicePrinting];
                        selectedPrinter.bPrinting_ProformaInvoices = (bool)PrintersList.dt.Rows[i][PrintersList.dcol_ProformaInvoicePrinting];
                        selectedPrinter.bPrinting_Reports = (bool)PrintersList.dt.Rows[i][PrintersList.dcol_ReportsPrinting];
                        selectedPrinter.PrinterName = sPrinterName;
                        return true;
                    }
                }
            }
            return false;
        }

        private void GetSettings(Printer selectedPrinter)
        {
            m_SelectedPrinter = selectedPrinter;
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
                }
                else
                {
                }
                PaperSize paper_size = SelectedPrinter.printer_settings.DefaultPageSettings.PaperSize;
                if (paper_size != null)
                {
                    if (paper_size.PaperName.Contains("A4"))
                    {
                    }
                    else
                    {
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
            Init();
            if (SettingsChanged != null)
            {
                SettingsChanged();
            }
        }

        private void cmb_SelectPrintTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Init();
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
