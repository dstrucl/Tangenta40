#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using TangentaDB;
using LanguageControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBTypes;

namespace Tangenta
{
    public partial class Form_VODxml_OPAL_output : Form
    {
        public string VOD_xsd_shema_file = "";
        DataSet ds_VOD = new DataSet();
        public string XML_Destination_Folder = "";
        usrc_InvoiceTable m_usrc_InvoiceTable = null;
        public string IZPIS_RACUNI_GLAVE = "VOD";
        public string filename_XML_IZPIS_RACUNI_GLAVE_TXT = null;
        DataTable dt_XML_Invoices = new DataTable();



        public cp_Items Items = new cp_Items();
        public cp_Invoices Invoices = new cp_Invoices();

        private DataTable dt_Glava = null;
        private DataTable dt_Dokument = null;
        private DataTable dt_Telo = null;
        private DataTable dt_Obracunsko_obdobje = null;
        private DataTable dt_Partner = null;
        private DataTable dt_Knjizba = null;

        int iObracunsko_Obdobje = 0;
        int iLeto_Obracunskega_Obdobja = 0;

        
        
        public Form_VODxml_OPAL_output(usrc_InvoiceTable xusrc_InvoiceTable)
        {
            InitializeComponent();
            m_usrc_InvoiceTable = xusrc_InvoiceTable;

            string company_name = myOrg.Name_v.vs;

            company_name = company_name.Replace(' ', '_');
            company_name = company_name.Replace('.', '_');

            filename_XML_IZPIS_RACUNI_GLAVE_TXT = company_name + IZPIS_RACUNI_GLAVE + m_usrc_InvoiceTable.sFromTo_Suffix + ".XML";
            DateTime dt = DateTime.Now;
            string s_time_extension = dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString() + "_" + dt.Hour.ToString() + "-" + dt.Minute.ToString() + "-" + dt.Second.ToString() + "-" + dt.Millisecond.ToString();
            lbl_FileNames.Text =  filename_XML_IZPIS_RACUNI_GLAVE_TXT + "\r\n";
            XML_Destination_Folder = Properties.Settings.Default.XML_output_folder;
            this.lbl_VOD_xml_shema.Text = lng.s_VOD_xml_shema_file_path.s;
            this.cmbR_FilePath.Text = XML_Destination_Folder;

            this.btn_Save.Text = lng.s_Save.s;
            this.lbl_Folder.Text = lng.s_Folder.s;
            this.Text = lng.s_Export_to_VOD_XML.s;
            this.btn_View.Text = lng.s_View.s;


            this.lbl_Konto_Price_with_tax_for_cash.Text = lng.s_Konto_Price_with_tax_for_cash.s;
            this.lbl_Konto_Price_with_tax_for_payment_cards.Text = lng.s_Konto_Price_with_tax_for_payment_cards.s;
            this.lbl_Konto_Net_price.Text = lng.s_Konto_Net_price.s;
            this.lbl_Konto_VAT_general_rate.Text = lng.s_Konto_VAT_general_rate.s;
            this.lbl_End_Customers_Code.Text = lng.s_End_Customers_Code.s;
            this.lbl_End_Customes_Name.Text = lng.s_End_Customes_Name.s;
            lng.s_VOD_Head.Text(this.lbl_Glava);


            //dt_IZPIS_RACUNI_GLAVE = new DataTable();
            //Progra


            //dt_IZPIS_RACUNI_GLAVE.TableName = IZPIS_RACUNI_GLAVE;



            //dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Davcna_stevilka_zavezanca_za_davek, typeof(string));
            //dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Stevilka_Racuna, typeof(string));
            //dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Cas_Racuna, typeof(DateTime));
            //dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Oznaka_Poslovne_Enote, typeof(string));
            //dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Oznaka_Elektronske_Naprave, typeof(string));
            //dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Firma_ime_in_sedez_kupca, typeof(string));
            //dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Kupceva_identifikacijska_stevilka_za_DDV, typeof(string));
            //dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Znesek_Racuna_skupaj_z_DDV, typeof(decimal));
            //dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Obracunan_DDV_po_9_5, typeof(decimal));
            //dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Obracunan_DDV_po_22, typeof(decimal));
            //dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Znesek_placila_z_gotovino_skupaj_z_DDV, typeof(decimal));
            //dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Znesek_placila_s_placilno_kartico_skupaj_z_DDV, typeof(decimal));
            //dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Znesek_placila_na_drug_nacin_skupaj_z_DDV, typeof(decimal));
            //dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Cas_spremembe_racuna, typeof(DateTime));
            //dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Zaporedna_stevilka_spremembe_racuna, typeof(long));
            //dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Oznaka_razloga_spremembe_racuna, typeof(string));
            //dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Opis_razloga_spremembe_racuna, typeof(string));
            //dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Uporabnisko_ime_osebe_ki_je_spremenila_racun, typeof(string));
            //dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Ime_in_Priimek_osebe_ki_je_spremenila_racun, typeof(string));
            //dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_OPOMBE, typeof(string));

            Items.cp_Davcna_stevilka_zavezanca_za_davek = Invoices.c_Davcna_stevilka_zavezanca_za_davek;
            Items.cp_Stevilka_Racuna = Invoices.c_Stevilka_Racuna;
            Items.cp_Cas_Racuna = Invoices.c_Cas_Racuna;
            Items.cp_Oznaka_Poslovne_Enote = Invoices.c_Oznaka_Poslovne_Enote;
            Items.cp_Oznaka_Elektronske_Naprave = Invoices.c_Oznaka_Elektronske_Naprave;


        }



        private bool Read_VOD_XSD_shema()
        {
            VOD_xsd_shema_file = Properties.Settings.Default.OPAL_VOD_XSD_shema;
            if (VOD_xsd_shema_file.Length==0)
            {
                string xVodShemaFolder = null;
                string Err = null;
                if (StaticLib.Func.SetApplicationSubFolder(ref xVodShemaFolder, Program.TANGENTA_VODSHEMA_SUB_FOLDER,ref Err))
                {
                    string shema = Properties.Resources.VOD_shema;

                    VOD_xsd_shema_file = xVodShemaFolder + "\\VOD.xsd";
                    try
                    {
                        File.WriteAllText(VOD_xsd_shema_file, shema);
                        Properties.Settings.Default.OPAL_VOD_XSD_shema = VOD_xsd_shema_file;
                        Properties.Settings.Default.Save();
                    }
                    catch (Exception Ex)
                    {
                        LogFile.Warning.Show("Warning: Can not write VOD shema file:" + VOD_xsd_shema_file);
                    }
                }
            }
            cmb_VOD_xml_shema.Text = VOD_xsd_shema_file;
            for (;;)
            {
                if (Get_VOD_XSD_shema())
                {
                    btn_Save.Enabled = true;
                    return true;
                }
                else
                {
                    if (Open_VOD_XSD_shema())
                    {
                        btn_Save.Enabled = true;
                        return true;
                    }
                    else
                    {
                        btn_Save.Enabled = false;
                        return false;
                    }
                }
            }
        }

        private bool Open_VOD_XSD_shema()
        {
            for (; ; )
            {
                OpenFileDialog opnfiledlg = new OpenFileDialog();
                opnfiledlg.InitialDirectory = "c:\\";
                opnfiledlg.Filter = "XSD files (*.xsd)|*.xsd|All files (*.*)|*.*";
                opnfiledlg.FilterIndex = 1;
                opnfiledlg.RestoreDirectory = true;
                if (opnfiledlg.ShowDialog() == DialogResult.OK)
                {
                    VOD_xsd_shema_file = opnfiledlg.FileName;
                    if (Get_VOD_XSD_shema())
                    {
                        cmb_VOD_xml_shema.Text = VOD_xsd_shema_file;
                        Properties.Settings.Default.OPAL_VOD_XSD_shema = VOD_xsd_shema_file;
                        Properties.Settings.Default.Save();
                        return true;

                    }
                    else
                    {
                        string sMsg = lng.s_Can_not_read_VOD_shema_file_Do_you_want_to_exit.s;
                        sMsg.Replace("%%SHEMAFILE", VOD_xsd_shema_file);

                        if (MessageBox.Show(this, sMsg, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            return false;
                        }
                    }

                }
                else
                {
                    if (MessageBox.Show(this, lng.s_YouDidnot_select_VOD_shema_file_Do_you_want_to_exit.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        return false;
                    }
                }
            }
        }

        private bool Get_VOD_XSD_shema()
        {
            if (File.Exists(VOD_xsd_shema_file))
            {
                try
                {
                    ds_VOD.ReadXmlSchema(VOD_xsd_shema_file);
                    //ds_VOD.EnforceConstraints = false;
                    //dt_VOD.ReadXmlSchema("\\Vodxml\\Vod.xsd");
                    btn_Save.Enabled = true;
                    return true;
                }
                catch (Exception ex)
                {
                    LogFile.Error.Show("Error:Form_VODxml_OPAL_output" + ex.Message);
                    btn_Save.Enabled = false;
                    return false;
                }
            }
            else
            {
                btn_Save.Enabled = false;
                return false;
            }
        }


        private void btn_SelectFolder_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.RootFolder = Environment.SpecialFolder.MyComputer;
            if (folderDlg.ShowDialog(this) == DialogResult.OK)
            {
                this.cmbR_FilePath.Text = folderDlg.SelectedPath;
                if (!cmbR_FilePath.Text.EndsWith("\\"))
                {
                    cmbR_FilePath.Text += "\\";
                }
                XML_Destination_Folder = cmbR_FilePath.Text;
                Properties.Settings.Default.XML_output_folder = XML_Destination_Folder;
                Properties.Settings.Default.Save();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private bool Make_VODxml_OPAL_output()
        {
            this.Cursor = Cursors.WaitCursor;

            // write XML_IZPIS_RACUNI_GLAVE_TXT

            string DestinationFullFileNamePath_XML_IZPIS_RACUNI_GLAVE = XML_Destination_Folder + filename_XML_IZPIS_RACUNI_GLAVE_TXT;
            try
            {
                int iRowsCount = -1;
                string scond = m_usrc_InvoiceTable.cond.Replace("$_dinv.ID", "$_dinv_$$ID");
                scond = scond.Replace("$_dinv.FinancialYear", "$_dinv_$$FinancialYear");

                dt_XML_Invoices.Rows.Clear();
                string sInvoiceCondition = " and (JOURNAL_DocInvoice_$_jpinvt_$$ID = " + GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoiceTime.ID.ToString() + " or JOURNAL_DocInvoice_$_jpinvt_$$ID = " + GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoiceStornoTime.ID.ToString() +  ") ";
                string sql = @"select 
                            JOURNAL_DocInvoice_$_dinv_$$ID as ID,
                            JOURNAL_DocInvoice_$_dinv_$$Draft,
                            JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg_$$Tax_ID,
                            JOURNAL_DocInvoice_$_dinv_$$FinancialYear,
                            JOURNAL_DocInvoice_$_dinv_$$NumberInFinancialYear,
                            JOURNAL_DocInvoice_$$EventTime,
                            JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg_$$Name,
                            JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_astrnorg_$$StreetName,
                            JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_ahounorg_$$HouseNumber,
                            JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_aziporg_$$ZIP,
                            JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_acitorg_$$City,
                            JOURNAL_DocInvoice_$_dinv_$$GrossSum,
                            JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acfn_$$FirstName,
                            JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acln_$$LastName,
							pt.Name	as JOURNAL_DocInvoice_$_dinv_$_inv_$_metopay_$$PaymentType,
                            JOURNAL_DocInvoice_$_dinv_$$NetSum,
                            JOURNAL_DocInvoice_$_dinv_$$TaxSum,
                            JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acadrper_$_astrnper_$$StreetName,
                            JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acadrper_$_ahounper_$$HouseNumber,
                            JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acadrper_$_azipper_$$ZIP,
                            JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acadrper_$_acitper_$$City,
                            JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_agsmnper_$$GsmNumber,
                            JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_aphnnper_$$PhoneNumber,
                            JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_aemailper_$$Email,
                            JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$$DateOfBirth,
                            JOURNAL_DocInvoice_$_dinv_$_acusorg_$$ID,
                            JOURNAL_DocInvoice_$_dinv_$_acusorg_$_aorg_$$Name,
                            JOURNAL_DocInvoice_$_dinv_$_acusorg_$_aorg_$$Tax_ID,
                            JOURNAL_DocInvoice_$_dinv_$_acusorg_$_aorg_$$Registration_ID
                            JOURNAL_DocInvoice_$_dinv_$$Paid,
                            JOURNAL_DocInvoice_$_dinv_$$Storno,
                            JOURNAL_DocInvoice_$_dinv_$$Discount,
                            JOURNAL_DocInvoice_$_dinv_$$EndSum,
                            JOURNAL_DocInvoice_$_dinv_$$ID
                            from JOURNAL_DocInvoice_VIEW
							left join DocInvoiceAddOn diaon on JOURNAL_DocInvoice_$_dinv_$$ID = diaon.DocInvoice_ID
							left join MethodOfPayment_DI mofpdi on mofpdi.ID = diaon.MethodOfPayment_DI_ID
							left join PaymentType pt on pt.ID = mofpdi.PaymentType_ID " + scond + sInvoiceCondition + " order by JOURNAL_DocInvoice_$_dinv_$$FinancialYear desc,JOURNAL_DocInvoice_$_dinv_$$Draft desc, JOURNAL_DocInvoice_$_dinv_$$NumberInFinancialYear desc, JOURNAL_DocInvoice_$_dinv_$$DraftNumber desc";
                string Err = null;
                bool bRes = DBSync.DBSync.ReadDataTable(ref dt_XML_Invoices, sql, m_usrc_InvoiceTable.lpar_ExtraCondition, ref Err);

                if (bRes)
                {
                    iRowsCount = dt_XML_Invoices.Rows.Count;
                    if (iRowsCount>0)
                    {
                        int Dokument_ID = 0;
                        int Knjizba_ID = 0;
                        int Partner_ID = 0;

                        int i = 0;
                        int ic_Invoice_ID = dt_XML_Invoices.Columns.IndexOf("JOURNAL_DocInvoice_$_dinv_$$ID");
                        int ic_ID = dt_XML_Invoices.Columns.IndexOf("ID");
                        int ic_Atom_Customer_Org_ID = dt_XML_Invoices.Columns.IndexOf("JOURNAL_DocInvoice_$_dinv_$_acusorg_$$ID");
                        int ic_Draft = dt_XML_Invoices.Columns.IndexOf("JOURNAL_DocInvoice_$_dinv_$$Draft");
                        int ic_TaxNumber = dt_XML_Invoices.Columns.IndexOf("JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg_$$Tax_ID");
                        int ic_FinancialYear = dt_XML_Invoices.Columns.IndexOf("JOURNAL_DocInvoice_$_dinv_$$FinancialYear");
                        int ic_NumberInFinancialYear = dt_XML_Invoices.Columns.IndexOf("JOURNAL_DocInvoice_$_dinv_$$NumberInFinancialYear");
                        int ic_DocInvoiceTime = dt_XML_Invoices.Columns.IndexOf("JOURNAL_DocInvoice_$$EventTime");
                        int ic_GrossSum = dt_XML_Invoices.Columns.IndexOf("JOURNAL_DocInvoice_$_dinv_$$GrossSum");
                        int ic_NetSum = dt_XML_Invoices.Columns.IndexOf("JOURNAL_DocInvoice_$_dinv_$$NetSum");
                        int ic_TaxSum = dt_XML_Invoices.Columns.IndexOf("JOURNAL_DocInvoice_$_dinv_$$TaxSum");
                        int ic_Organisation_Name = dt_XML_Invoices.Columns.IndexOf("JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg_$$Name");
                        int ic_Organisation_StreetName = dt_XML_Invoices.Columns.IndexOf("JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_astrnorg_$$StreetName");
                        int ic_Organisation_HouseNumber = dt_XML_Invoices.Columns.IndexOf("JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_ahounorg_$$HouseNumber");
                        int ic_Organisation_ZIP = dt_XML_Invoices.Columns.IndexOf("JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_aziporg_$$ZIP");
                        int ic_Organisation_City = dt_XML_Invoices.Columns.IndexOf("JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_acitorg_$$City");
                        int ic_PaymentType = dt_XML_Invoices.Columns.IndexOf("JOURNAL_DocInvoice_$_dinv_$_inv_$_metopay_$$PaymentType");

                        dgvx_Dokumenti.DataSource = null;
                        dt_Obracunsko_obdobje.Rows.Clear();
                        dt_Partner.Rows.Clear(); ;
                        dt_Knjizba.Rows.Clear();
                        dt_Dokument.Rows.Clear();
                        dt_Dokument.Columns["Datum_dokumenta"].DataType = typeof(string);
                        dt_Dokument.Columns["Datum_dur"].DataType = typeof(string);
                        dt_Dokument.Columns["Datum_prejema_izdaje"].DataType = typeof(string);
                        dt_Dokument.Columns["Datum_DDV"].DataType = typeof(string);
                        dt_Dokument.Columns["Datum_zapadlosti"].DataType = typeof(string);
                        dt_Dokument.Columns["Datum_predvidenega_placila"].DataType = typeof(string);
                        dt_Knjizba.Columns["Datum_zapadlosti"].DataType = typeof(string);

                        for (i=0;i<iRowsCount;i++)
                        {
                            if ((bool)  dt_XML_Invoices.Rows[i][ic_Draft])
                            {
                                continue;
                            }
                            else
                            {
                                if (!(dt_XML_Invoices.Rows[i][ic_Atom_Customer_Org_ID] is System.DBNull))
                                {
                                    continue;
                                }
                                else
                                { 
                                    long Invoice_ID = (long)dt_XML_Invoices.Rows[i][ic_Invoice_ID];
                                    long DocInvoice_ID = (long)dt_XML_Invoices.Rows[i][ic_ID];
                                    string Davcna_Stevilka = (string)dt_XML_Invoices.Rows[i][ic_TaxNumber];
                                    if (!Davcna_Stevilka.ToUpper().Contains("SI"))
                                    {
                                        Davcna_Stevilka = "SI" + Davcna_Stevilka;
                                    }
                                    string gl1_Davcna_stevilka_zavezanca_za_davek = Davcna_Stevilka;
                                    string gl2_Stevilka_racuna = Program.GetInvoiceNumber(false, (int)dt_XML_Invoices.Rows[i][ic_FinancialYear], (int)dt_XML_Invoices.Rows[i][ic_NumberInFinancialYear], -1);
                                    string gl3_Datum_Racuna_DDMMLL = fs.Date_DDMMYYYY((DateTime)dt_XML_Invoices.Rows[i][ic_DocInvoiceTime]);
                                    DateTime date_time_invoice = (DateTime)dt_XML_Invoices.Rows[i][ic_DocInvoiceTime];
                                    string gl4_Ura_izdaje_racuna_HH_MM = fs.Time_HH_MM(':',date_time_invoice);
                                    //string gl5_Oznaka_Poslovne_Enote = "P1";
                                    //string gl6_Oznaka_Elektronske_Naprave = "1";
                                    //string gl7_Firma_ime_in_sedez_kupca = "";// (string)dt_XML_Invoices.Rows[i][ic_Organisation_Name] + " " + (string)dt_XML_Invoices.Rows[i][ic_Organisation_StreetName] + " " + (string)dt_XML_Invoices.Rows[i][ic_Organisation_HouseNumber];
                                    //string gl8_Kupceva_identifikacijska_stevilka_za_DDV = "";
                                    decimal Znesek_Racuna_skupaj_z_DDV = (decimal)dt_XML_Invoices.Rows[i][ic_GrossSum];
                                    decimal Neto_Znesek_Racuna = (decimal)dt_XML_Invoices.Rows[i][ic_NetSum];
                                    decimal Davek = (decimal)dt_XML_Invoices.Rows[i][ic_TaxSum];
                                    string gl9_Znesek_Racuna_skupaj_z_DDV = fs.Decimal2String(Znesek_Racuna_skupaj_z_DDV, 2);
                                    //string gl10_Obracunan_DDV_po_9_5 = "0,00";
                                    //string gl11_Obracunan_DDV_po_22 = "0,00";
                                    string gl12_Znesek_placila_z_gotovino_skupaj_z_DDV = "0,00";
                                    string gl13_Znesek_placila_s_placilno_kartico_skupaj_z_DDV = "0,00";
                                    string gl14_Znesek_placila_na_drug_nacin_skupaj_z_DDV = "0,00";
                                    string gl15_Datum_spremembe_racuna_DDMMLLL = "";
                                    string gl16_Ura_spremembe_racuna = "";
                                    //string gl17_Zaporedna_stevilka_spremembe_racuna = "";
                                    //string gl18_Oznaka_razloga_spremembe_racuna = "";
                                    string gl19_Opis_razloga_spremembe_racuna = "";
                                    string gl20_Uporabnisko_ime_osebe_ki_je_spremenila_racun = "";
                                    //string gl21_Ime_in_Priimek_osebe_ki_je_spremenila_racun = "";
                                    //string gl22_OPOMBE = "";
                                    bool bCash = false;

                                    object oPaymentType = dt_XML_Invoices.Rows[i][ic_PaymentType];
                                    if (oPaymentType is string)
                                    {
                                        if (((string)oPaymentType).ToLower().Contains("gotovina"))
                                        {
                                            bCash = true;
                                            gl12_Znesek_placila_z_gotovino_skupaj_z_DDV = gl9_Znesek_Racuna_skupaj_z_DDV;
                                        }
                                        else if (((string)oPaymentType).ToLower().Contains("kartica"))
                                        {
                                            gl13_Znesek_placila_s_placilno_kartico_skupaj_z_DDV = gl9_Znesek_Racuna_skupaj_z_DDV;
                                        }
                                        else
                                        {
                                            gl14_Znesek_placila_na_drug_nacin_skupaj_z_DDV = gl9_Znesek_Racuna_skupaj_z_DDV;
                                        }
                                    }
                                    else
                                    {
                                        gl14_Znesek_placila_na_drug_nacin_skupaj_z_DDV = gl9_Znesek_Racuna_skupaj_z_DDV;
                                    }

                                    //string s_Invoice_Storno = null;
                                    DataRow dr_Dokument = dt_Dokument.NewRow();
                                    dr_Dokument["Dokument"] = "Izdani_racun";
                                    dr_Dokument["Trg"] = "Domac";
                                    dr_Dokument["Stevilka_dokumenta"] = gl2_Stevilka_racuna;
                                    dr_Dokument["Datum_dokumenta"] = VOD_DateTime(date_time_invoice);
                                    dr_Dokument["Datum_dur"] = VOD_DateTime(date_time_invoice);
                                    dr_Dokument["Datum_prejema_izdaje"] = VOD_DateTime(date_time_invoice);
                                    dr_Dokument["Datum_DDV"] = VOD_DateTime(date_time_invoice);
                                    dr_Dokument["Datum_zapadlosti"] = VOD_DateTime(date_time_invoice);
                                    dr_Dokument["Datum_predvidenega_placila"] = VOD_DateTime(date_time_invoice);
                                    dr_Dokument["Dokument_Id"] = Dokument_ID;
                                    dr_Dokument["Telo_Id"] = 0;
                                    dt_Dokument.Rows.Add(dr_Dokument);

                                    DataRow dr_Partner_Dokument = dt_Partner.NewRow();
                                    dr_Partner_Dokument["Sifra"] = Convert.ToInt32(this.nmUpDn_End_Customers_Code.Value);
                                    dr_Partner_Dokument["Naziv1"] = txt_End_Customers_Name.Text;
                                    dr_Partner_Dokument["Partner_Id"] = Partner_ID;
                                    dr_Partner_Dokument["Dokument_Id"] = Dokument_ID;
                                    dt_Partner.Rows.Add(dr_Partner_Dokument);
                                    Partner_ID++;


                                    DataRow dr_Obracunsko_obdobje = dt_Obracunsko_obdobje.NewRow();
                                    dr_Obracunsko_obdobje["Mesec"] = iObracunsko_Obdobje;
                                    dr_Obracunsko_obdobje["Leto"] = iLeto_Obracunskega_Obdobja;
                                    dr_Obracunsko_obdobje["Dokument_Id"] = Dokument_ID;
                                    dt_Obracunsko_obdobje.Rows.Add(dr_Obracunsko_obdobje);

                                    int Konto = 0;
                                    if (bCash)
                                    {
                                        Konto =Convert.ToInt32(nmUpDn_Konto_Price_with_tax_for_cash.Value);
                                    }
                                    else
                                    {
                                        Konto =Convert.ToInt32(this.nmUpDn_Konto_Price_with_tax_for_payment_cards.Value);
                                    }

                                    DataRow dr_Knjizba_Znesek_z_ddv = dt_Knjizba.NewRow();
                                    dr_Knjizba_Znesek_z_ddv["Vrsta_knjizbe"] = "Znesek_z_ddv";
                                    dr_Knjizba_Znesek_z_ddv["Datum_zapadlosti"] = VOD_DateTime(date_time_invoice);
                                    dr_Knjizba_Znesek_z_ddv["Stroskovno_mesto"] = "001";
                                    dr_Knjizba_Znesek_z_ddv["Analitika6"] = "001";
                                    dr_Knjizba_Znesek_z_ddv["Vrsta_dokumenta"] = "IR";
                                    dr_Knjizba_Znesek_z_ddv["Konto"] = Konto;
                                    dr_Knjizba_Znesek_z_ddv["Debet"] = Znesek_Racuna_skupaj_z_DDV;
                                    dr_Knjizba_Znesek_z_ddv["Kredit"] = 0;
                                    dr_Knjizba_Znesek_z_ddv["Sifra_valute"] = 978;
                                    dr_Knjizba_Znesek_z_ddv["Valuta_debet"] = Znesek_Racuna_skupaj_z_DDV;
                                    dr_Knjizba_Znesek_z_ddv["Knjizba_Id"] = Knjizba_ID;
                                    dr_Knjizba_Znesek_z_ddv["Dokument_Id"] = Dokument_ID;
                                    dt_Knjizba.Rows.Add(dr_Knjizba_Znesek_z_ddv);

                                    DataRow dr_Partner_Knjizba_Znesek_z_ddv = dt_Partner.NewRow();
                                    dr_Partner_Knjizba_Znesek_z_ddv["Sifra"] = Convert.ToInt32(this.nmUpDn_End_Customers_Code.Value);
                                    dr_Partner_Knjizba_Znesek_z_ddv["Partner_Id"] = Partner_ID;
                                    dr_Partner_Knjizba_Znesek_z_ddv["Knjizba_Id"] = Knjizba_ID;
                                    dt_Partner.Rows.Add(dr_Partner_Knjizba_Znesek_z_ddv);
                                    Partner_ID++;

                                    Knjizba_ID++;


                                    DataRow dr_Knjizba_Osnova_splosna_stopnja = dt_Knjizba.NewRow();
                                    dr_Knjizba_Osnova_splosna_stopnja["Vrsta_knjizbe"] = "Osnova_splosna_stopnja";
                                    dr_Knjizba_Osnova_splosna_stopnja["Datum_zapadlosti"] = VOD_DateTime(date_time_invoice);
                                    dr_Knjizba_Osnova_splosna_stopnja["Stroskovno_mesto"] = "001";
                                    dr_Knjizba_Osnova_splosna_stopnja["Analitika6"] = "001";
                                    dr_Knjizba_Osnova_splosna_stopnja["Vrsta_dokumenta"] = "IR";
                                    dr_Knjizba_Osnova_splosna_stopnja["Konto"] = Convert.ToInt32(this.nmUpDn_Konto_NetPrice.Value);
                                    dr_Knjizba_Osnova_splosna_stopnja["Debet"] = 0;
                                    dr_Knjizba_Osnova_splosna_stopnja["Kredit"] = Neto_Znesek_Racuna;
                                    dr_Knjizba_Osnova_splosna_stopnja["Sifra_valute"] = 978;
                                    dr_Knjizba_Osnova_splosna_stopnja["Valuta_kredit"] = Neto_Znesek_Racuna;//Znesek_Racuna_skupaj_z_DDV;
                                    dr_Knjizba_Osnova_splosna_stopnja["Knjizba_Id"] = Knjizba_ID;
                                    dr_Knjizba_Osnova_splosna_stopnja["Dokument_Id"] = Dokument_ID;
                                    dt_Knjizba.Rows.Add(dr_Knjizba_Osnova_splosna_stopnja);

                                    DataRow dr_Partner_Knjizba_Osnovna_splosna_stopnja = dt_Partner.NewRow();
                                    dr_Partner_Knjizba_Osnovna_splosna_stopnja["Sifra"] = Convert.ToInt32(this.nmUpDn_End_Customers_Code.Value);
                                    dr_Partner_Knjizba_Osnovna_splosna_stopnja["Partner_Id"] = Partner_ID;
                                    dr_Partner_Knjizba_Osnovna_splosna_stopnja["Knjizba_Id"] = Knjizba_ID;
                                    dt_Partner.Rows.Add(dr_Partner_Knjizba_Osnovna_splosna_stopnja);
                                    Partner_ID++;

                                    Knjizba_ID++;


                                    DataRow dr_Knjizba_DDV_splosna_stopnja = dt_Knjizba.NewRow();
                                    dr_Knjizba_DDV_splosna_stopnja["Vrsta_knjizbe"] = "DDV_splosna_stopnja";
                                    dr_Knjizba_DDV_splosna_stopnja["Datum_zapadlosti"] = VOD_DateTime(date_time_invoice);
                                    dr_Knjizba_DDV_splosna_stopnja["Stroskovno_mesto"] = "001";
                                    dr_Knjizba_DDV_splosna_stopnja["Analitika6"] = "001";
                                    dr_Knjizba_DDV_splosna_stopnja["Vrsta_dokumenta"] = "IR";
                                    dr_Knjizba_DDV_splosna_stopnja["Konto"] = Convert.ToInt32(this.nmUpDn_Konto_VAT_general_rate.Value);
                                    dr_Knjizba_DDV_splosna_stopnja["Debet"] = 0;
                                    dr_Knjizba_DDV_splosna_stopnja["Kredit"] = Davek;
                                    dr_Knjizba_DDV_splosna_stopnja["Osnova"] = Neto_Znesek_Racuna;
                                    dr_Knjizba_DDV_splosna_stopnja["Sifra_valute"] = 978;
                                    dr_Knjizba_DDV_splosna_stopnja["Valuta_kredit"] = Davek;
                                    dr_Knjizba_DDV_splosna_stopnja["Knjizba_Id"] = Knjizba_ID;
                                    dr_Knjizba_DDV_splosna_stopnja["Dokument_Id"] = Dokument_ID;
                                    dt_Knjizba.Rows.Add(dr_Knjizba_DDV_splosna_stopnja);

                                    DataRow dr_Partner_Knjizba_DDV_splosna_stopnja = dt_Partner.NewRow();
                                    dr_Partner_Knjizba_DDV_splosna_stopnja["Sifra"] = Convert.ToInt32(this.nmUpDn_End_Customers_Code.Value);
                                    dr_Partner_Knjizba_DDV_splosna_stopnja["Partner_Id"] = Partner_ID;
                                    dr_Partner_Knjizba_DDV_splosna_stopnja["Knjizba_Id"] = Knjizba_ID;
                                    dt_Partner.Rows.Add(dr_Partner_Knjizba_DDV_splosna_stopnja);
                                    Partner_ID++;

                                    Knjizba_ID++;

                                    Dokument_ID++;





                                    //DataRow dr_IZPIS_RACUNI_GLAVE = dt_IZPIS_RACUNI_GLAVE.NewRow();
                                    //dr_IZPIS_RACUNI_GLAVE[Invoices.c_Davcna_stevilka_zavezanca_za_davek] = gl1_Davcna_stevilka_zavezanca_za_davek;
                                    //dr_IZPIS_RACUNI_GLAVE[Invoices.c_Stevilka_Racuna] = gl2_Stevilka_racuna;
                                    //dr_IZPIS_RACUNI_GLAVE[Invoices.c_Cas_Racuna] = (DateTime)dt_XML_Invoices.Rows[i][ic_DocInvoiceTime];
                                    //dr_IZPIS_RACUNI_GLAVE[Invoices.c_Oznaka_Poslovne_Enote] = gl5_Oznaka_Poslovne_Enote;
                                    //dr_IZPIS_RACUNI_GLAVE[Invoices.c_Oznaka_Elektronske_Naprave] = gl6_Oznaka_Elektronske_Naprave;
                                    //dr_IZPIS_RACUNI_GLAVE[Invoices.c_Firma_ime_in_sedez_kupca] = gl7_Firma_ime_in_sedez_kupca;
                                    //dr_IZPIS_RACUNI_GLAVE[Invoices.c_Kupceva_identifikacijska_stevilka_za_DDV] = gl8_Kupceva_identifikacijska_stevilka_za_DDV;
                                    //dr_IZPIS_RACUNI_GLAVE[Invoices.c_Znesek_Racuna_skupaj_z_DDV] = fs.String2Decimal(gl9_Znesek_Racuna_skupaj_z_DDV);
                                    //dr_IZPIS_RACUNI_GLAVE[Invoices.c_Obracunan_DDV_po_9_5] = fs.String2Decimal(gl10_Obracunan_DDV_po_9_5);
                                    //dr_IZPIS_RACUNI_GLAVE[Invoices.c_Obracunan_DDV_po_22] = fs.String2Decimal(gl11_Obracunan_DDV_po_22);
                                    //dr_IZPIS_RACUNI_GLAVE[Invoices.c_Znesek_placila_z_gotovino_skupaj_z_DDV] = fs.String2Decimal(gl12_Znesek_placila_z_gotovino_skupaj_z_DDV);
                                    //dr_IZPIS_RACUNI_GLAVE[Invoices.c_Znesek_placila_s_placilno_kartico_skupaj_z_DDV] = fs.String2Decimal(gl13_Znesek_placila_s_placilno_kartico_skupaj_z_DDV);
                                    //dr_IZPIS_RACUNI_GLAVE[Invoices.c_Znesek_placila_na_drug_nacin_skupaj_z_DDV] = fs.String2Decimal(gl14_Znesek_placila_na_drug_nacin_skupaj_z_DDV);
                                    //dr_IZPIS_RACUNI_GLAVE[Invoices.c_Cas_spremembe_racuna] = fs.String2Date_DDMMYYYY_HH_MM(gl15_Datum_spremembe_racuna_DDMMLLL, gl16_Ura_spremembe_racuna);
                                    //dr_IZPIS_RACUNI_GLAVE[Invoices.c_Zaporedna_stevilka_spremembe_racuna] = fs.String2Int(gl17_Zaporedna_stevilka_spremembe_racuna);
                                    //dr_IZPIS_RACUNI_GLAVE[Invoices.c_Oznaka_razloga_spremembe_racuna] = gl18_Oznaka_razloga_spremembe_racuna;
                                    //dr_IZPIS_RACUNI_GLAVE[Invoices.c_Opis_razloga_spremembe_racuna] = gl19_Opis_razloga_spremembe_racuna;
                                    //dr_IZPIS_RACUNI_GLAVE[Invoices.c_Uporabnisko_ime_osebe_ki_je_spremenila_racun] = gl20_Uporabnisko_ime_osebe_ki_je_spremenila_racun;
                                    //dr_IZPIS_RACUNI_GLAVE[Invoices.c_Ime_in_Priimek_osebe_ki_je_spremenila_racun] = gl21_Ime_in_Priimek_osebe_ki_je_spremenila_racun;
                                    //dr_IZPIS_RACUNI_GLAVE[Invoices.c_OPOMBE] = "";

                                    //string s_Invoice = 
                                    //       gl1_Davcna_stevilka_zavezanca_za_davek
                                    //+ ";" +gl2_Stevilka_racuna
                                    //+ ";" +gl3_Datum_Racuna_DDMMLL
                                    //+ ";" +gl4_Ura_izdaje_racuna_HH_MM
                                    //+ ";" +gl5_Oznaka_Poslovne_Enote
                                    //+ ";" +gl6_Oznaka_Elektronske_Naprave
                                    //+ ";" +gl7_Firma_ime_in_sedez_kupca
                                    //+ ";" +gl8_Kupceva_identifikacijska_stevilka_za_DDV
                                    //+ ";" +gl9_Znesek_Racuna_skupaj_z_DDV
                                    //+ ";" +gl10_Obracunan_DDV_po_9_5
                                    //+ ";" +gl11_Obracunan_DDV_po_22
                                    //+ ";" +gl12_Znesek_placila_z_gotovino_skupaj_z_DDV
                                    //+ ";" +gl13_Znesek_placila_s_placilno_kartico_skupaj_z_DDV
                                    //+ ";" +gl14_Znesek_placila_na_drug_nacin_skupaj_z_DDV
                                    //+ ";" +gl15_Datum_spremembe_racuna_DDMMLLL
                                    //+ ";" +gl16_Ura_spremembe_racuna
                                    //+ ";" +gl17_Zaporedna_stevilka_spremembe_racuna
                                    //+ ";" +gl18_Oznaka_razloga_spremembe_racuna
                                    //+ ";" +gl19_Opis_razloga_spremembe_racuna
                                    //+ ";" +gl20_Uporabnisko_ime_osebe_ki_je_spremenila_racun
                                    //+ ";" +gl21_Ime_in_Priimek_osebe_ki_je_spremenila_racun
                                    // + ";" +gl22_OPOMBE + "\r\n";

                                    sql = @"select 
                                        JOURNAL_DocInvoice_$_jpinvt_$$Description,
                                        JOURNAL_DocInvoice_$$EventTime,
                                        JOURNAL_DocInvoice_$_awperiod_$_acomp_$$UserName,
                                        JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acfn_$$FirstName,
                                        JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acln_$$LastName,
                                        JOURNAL_DocInvoice_$_awperiod_$$ID
                                    from JOURNAL_DocInvoice_VIEW where JOURNAL_DocInvoice_$_dinv_$$GrossSum < 0 and JOURNAL_DocInvoice_$_dinv_$$Storno = 1 and JOURNAL_DocInvoice_$_dinv_$$ID = " + Invoice_ID.ToString();

                                    DataTable dt_XML_Invoice_Storno = new DataTable();
                                    if (DBSync.DBSync.ReadDataTable(ref dt_XML_Invoice_Storno,sql, ref Err))
                                    {
                                        if (dt_XML_Invoice_Storno.Rows.Count>0)
                                        {
                                            gl15_Datum_spremembe_racuna_DDMMLLL = (string) fs.Date_DDMMYYYY((DateTime)dt_XML_Invoice_Storno.Rows[0]["JOURNAL_DocInvoice_$$EventTime"]);
                                            gl16_Ura_spremembe_racuna = (string) fs.Time_HH_MM(':',(DateTime)dt_XML_Invoice_Storno.Rows[0]["JOURNAL_DocInvoice_$$EventTime"]);
                                            //gl17_Zaporedna_stevilka_spremembe_racuna = "1";
                                            //gl18_Oznaka_razloga_spremembe_racuna = "S";
                                            gl19_Opis_razloga_spremembe_racuna = (string)dt_XML_Invoice_Storno.Rows[0]["JOURNAL_DocInvoice_$_jpinvt_$$Description"];
                                            string sUserName = null;
                                            if (Program.OperationMode.MultiUser)
                                            {
                                                long_v Atom_WorkPeriod_ID_v = tf.set_long(dt_XML_Invoice_Storno.Rows[0]["JOURNAL_DocInvoice_$_awperiod_$$ID"]);
                                                if (Atom_WorkPeriod_ID_v != null)
                                                {
                                                    string sql_get_username = @"select lu.UserName as UserName
                                                                    from LoginUsers lu
                                                                    inner join LoginSession ls on ls.LoginUsers_ID = lu.ID
                                                                    where ls.Atom_WorkPeriod_ID = " + Atom_WorkPeriod_ID_v.v.ToString();

                                                    DataTable dtUserName = new DataTable();
                                                    if (DBSync.DBSync.ReadDataTable(ref dtUserName, sql_get_username, ref Err))
                                                    {
                                                        if (dtUserName.Rows.Count > 0)
                                                        {
                                                            sUserName = (string)dtUserName.Rows[0]["UserName"];
                                                        }
                                                    }
                                                }
                                            }
                                            
                                            if (sUserName==null)
                                            {
                                                gl20_Uporabnisko_ime_osebe_ki_je_spremenila_racun = (string)dt_XML_Invoice_Storno.Rows[0]["JOURNAL_DocInvoice_$_awperiod_$_amcper_$$UserName"];
                                            }
                                            else
                                            {
                                                gl20_Uporabnisko_ime_osebe_ki_je_spremenila_racun = sUserName;
                                            }
                                            string sFirstName = "";
                                            object oFirstName = dt_XML_Invoice_Storno.Rows[0]["JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acfn_$$FirstName"];
                                            if (oFirstName is string)
                                            {
                                                sFirstName = (string)oFirstName;
                                            }
                                            string sLastName = "";
                                            object oLastName = dt_XML_Invoice_Storno.Rows[0]["JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acln_$$LastName"];
                                            if (oLastName is string)
                                            {
                                                sLastName = (string)oLastName;
                                            }

                                            //gl21_Ime_in_Priimek_osebe_ki_je_spremenila_racun = sFirstName + " " + sLastName;

                                            //dr_IZPIS_RACUNI_GLAVE_storno = dt_IZPIS_RACUNI_GLAVE.NewRow();
                                            //dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Davcna_stevilka_zavezanca_za_davek] = gl1_Davcna_stevilka_zavezanca_za_davek;
                                            //dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Stevilka_Racuna] = gl2_Stevilka_racuna;
                                            //dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Cas_Racuna] = fs.String2Date_DDMMYYYY_HH_MM(gl3_Datum_Racuna_DDMMLL, gl4_Ura_izdaje_racuna_HH_MM);
                                            //dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Oznaka_Poslovne_Enote] = gl5_Oznaka_Poslovne_Enote;
                                            //dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Oznaka_Elektronske_Naprave] = gl6_Oznaka_Elektronske_Naprave;
                                            //dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Firma_ime_in_sedez_kupca] = gl7_Firma_ime_in_sedez_kupca;
                                            //dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Kupceva_identifikacijska_stevilka_za_DDV] = gl8_Kupceva_identifikacijska_stevilka_za_DDV;
                                            //dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Znesek_Racuna_skupaj_z_DDV] = fs.String2Decimal(gl9_Znesek_Racuna_skupaj_z_DDV);
                                            //dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Obracunan_DDV_po_9_5] = fs.String2Decimal(gl10_Obracunan_DDV_po_9_5);
                                            //dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Obracunan_DDV_po_22] = fs.String2Decimal(gl11_Obracunan_DDV_po_22);
                                            //dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Znesek_placila_z_gotovino_skupaj_z_DDV] = fs.String2Decimal(gl12_Znesek_placila_z_gotovino_skupaj_z_DDV);
                                            //dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Znesek_placila_s_placilno_kartico_skupaj_z_DDV] = fs.String2Decimal(gl13_Znesek_placila_s_placilno_kartico_skupaj_z_DDV);
                                            //dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Znesek_placila_na_drug_nacin_skupaj_z_DDV] = fs.String2Decimal(gl14_Znesek_placila_na_drug_nacin_skupaj_z_DDV);
                                            //dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Cas_spremembe_racuna] = fs.String2Date_DDMMYYYY_HH_MM(gl15_Datum_spremembe_racuna_DDMMLLL, gl16_Ura_spremembe_racuna);
                                            //dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Zaporedna_stevilka_spremembe_racuna] = fs.String2Int(gl17_Zaporedna_stevilka_spremembe_racuna);
                                            //dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Oznaka_razloga_spremembe_racuna] = gl18_Oznaka_razloga_spremembe_racuna;
                                            //dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Opis_razloga_spremembe_racuna] = gl19_Opis_razloga_spremembe_racuna;
                                            //dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Uporabnisko_ime_osebe_ki_je_spremenila_racun] = gl20_Uporabnisko_ime_osebe_ki_je_spremenila_racun;
                                            //dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Ime_in_Priimek_osebe_ki_je_spremenila_racun] = gl21_Ime_in_Priimek_osebe_ki_je_spremenila_racun;
                                            //dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_OPOMBE] = "";

                                            //s_Invoice_Storno = gl1_Davcna_stevilka_zavezanca_za_davek
                                            // + ";" + gl2_Stevilka_racuna
                                            // + ";" + gl3_Datum_Racuna_DDMMLL
                                            // + ";" + gl4_Ura_izdaje_racuna_HH_MM
                                            // + ";" + gl5_Oznaka_Poslovne_Enote
                                            // + ";" + gl6_Oznaka_Elektronske_Naprave
                                            // + ";" + gl7_Firma_ime_in_sedez_kupca
                                            // + ";" + gl8_Kupceva_identifikacijska_stevilka_za_DDV
                                            // + ";" + gl9_Znesek_Racuna_skupaj_z_DDV
                                            // + ";" + gl10_Obracunan_DDV_po_9_5
                                            // + ";" + gl11_Obracunan_DDV_po_22
                                            // + ";" + gl12_Znesek_placila_z_gotovino_skupaj_z_DDV
                                            // + ";" + gl13_Znesek_placila_s_placilno_kartico_skupaj_z_DDV
                                            // + ";" + gl14_Znesek_placila_na_drug_nacin_skupaj_z_DDV
                                            // + ";" + gl15_Datum_spremembe_racuna_DDMMLLL
                                            // + ";" + gl16_Ura_spremembe_racuna
                                            // + ";" + gl17_Zaporedna_stevilka_spremembe_racuna
                                            // + ";" + gl18_Oznaka_razloga_spremembe_racuna
                                            // + ";" + gl19_Opis_razloga_spremembe_racuna
                                            // + ";" + gl20_Uporabnisko_ime_osebe_ki_je_spremenila_racun
                                            // + ";" + gl21_Ime_in_Priimek_osebe_ki_je_spremenila_racun
                                            //  + ";" + gl22_OPOMBE + "\r\n";
                                        }
                                    }
                                    else
                                    {
                                        this.Cursor = Cursors.Arrow;
                                        LogFile.Error.Show("ERROR:Form_VODxml_OPAL_output:Make_VODxml_OPAL_output:sql=" + sql + "\r\nErr=" + Err);
                                        return false;
                                    }

                                    //if (dr_IZPIS_RACUNI_GLAVE_storno != null)
                                    //{
                                    //    dt_IZPIS_RACUNI_GLAVE.Rows.Add(dr_IZPIS_RACUNI_GLAVE);
                                    //    dt_IZPIS_RACUNI_GLAVE.Rows.Add(dr_IZPIS_RACUNI_GLAVE_storno);
                                    //    //Glava += s_Invoice_Storno + s_Invoice; 
                                    //}
                                    //else
                                    //{
                                    //    dt_IZPIS_RACUNI_GLAVE.Rows.Add(dr_IZPIS_RACUNI_GLAVE);
                                    //    //Glava += s_Invoice;
                                    //}
                                }
                            }
                        }
                        bool res = true;
                        dgvx_Glava.DataSource = dt_Glava;
                        dgvx_Dokumenti.DataSource = dt_Dokument;
                        dgvx_Knjizbe.DataSource = dt_Knjizba;
                        try
                        {
                           // dt_IZPIS_RACUNI_GLAVE.WriteXml(this.cmbR_FilePath.Text + filename_XML_IZPIS_RACUNI_GLAVE_TXT, XmlWriteMode.WriteSchema);
                            //File.WriteAllText(this.cmbR_FilePath.Text + filename_XML_IZPIS_RACUNI_GLAVE_TXT, Glava, Encoding.GetEncoding(1250));
                            string xml_file_path = this.cmbR_FilePath.Text + filename_XML_IZPIS_RACUNI_GLAVE_TXT;
                            ds_VOD.WriteXml(xml_file_path);
                        }
                        catch (Exception ex)
                        {
                            res = false;
                            MessageBox.Show(lng.s_Err_Write_File.s + this.cmbR_FilePath.Text + filename_XML_IZPIS_RACUNI_GLAVE_TXT + "\r\n" + lng.s_Error.s + "=" + ex.Message);
                        }

                        MessageBox.Show(this, lng.s_VOD_XML_File.s + ":\r\n    " + this.cmbR_FilePath.Text + filename_XML_IZPIS_RACUNI_GLAVE_TXT + "\r\n    ");
                        this.Cursor = Cursors.Arrow;
                        this.btn_View.Visible = true;
                        return res;
                    }
                    else
                    {
                        MessageBox.Show(lng.s_NoInvoicesData.s);
                        this.Cursor = Cursors.Arrow;
                        return false;
                    }
                }
                else
                {
                    this.Cursor = Cursors.Arrow;
                    LogFile.Error.Show("ERROR:Form_VODxml_OPAL_output:Make_VODxml_OPAL_output:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            catch (Exception Ex)
            {
                this.Cursor = Cursors.Arrow;
                LogFile.Error.Show("ERROR:Form_VODxml_OPAL_output:Make_VODxml_OPAL_output:Exception=" + Ex.Message);
                return false;
            }

        }

        private string VOD_DateTime(DateTime date_time_invoice)
        {

            string smon = date_time_invoice.Month.ToString();
            if (smon.Length==1)
            {
                smon = "0"+smon;
            }

            string sday = date_time_invoice.Day.ToString();
            if (sday.Length==1)
            {
                sday = "0"+sday;
            }
            return date_time_invoice.Year.ToString() + "-" + smon + "-" + sday;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (Make_VODxml_OPAL_output())
            {

            }
        }

        private void btn_View_Click(object sender, EventArgs e)
        {
            Form_VODxml_OPAL_FilesPreview XML_FilesPreview_dlg = new Form_VODxml_OPAL_FilesPreview(this);
            XML_FilesPreview_dlg.ShowDialog();
        }

        private void btn_Select_Shema_Click(object sender, EventArgs e)
        {
           if (Open_VOD_XSD_shema())
           {
               btn_Save.Enabled = true;
           }
           else
           {
               btn_Save.Enabled = false;
           }
        }

        private bool Fill_ds_VOD()
        {
            if (Read_VOD_XSD_shema())
            {
                try
                {
                    dt_Glava = ds_VOD.Tables["Glava"];
                    DataRow dr_Glava = dt_Glava.NewRow();
                    dr_Glava["Program"] = "TANGENTA";
                    dr_Glava["Program_verzija"] = "1.0";
                    dr_Glava["Program_avtor"] = "Damjan Štrucl-Hrnčič";
                    dr_Glava["Verzija_xml"] = "0.1";
                    dt_Glava.Rows.Add(dr_Glava);

                    dt_Telo = ds_VOD.Tables["Telo"];
                    DataRow dr_Telo = dt_Telo.NewRow();
                    dr_Telo["Telo_id"] = 0;
                    dt_Telo.Rows.Add(dr_Telo);

                    dt_Dokument = ds_VOD.Tables["Dokument"];


                    dt_Obracunsko_obdobje = ds_VOD.Tables["Obracunsko_obdobje"];
                    dt_Partner = ds_VOD.Tables["Partner"];
                    dt_Knjizba = ds_VOD.Tables["Knjizba"];


                    return true;
                }
                catch (Exception ex)
                {
                    LogFile.Error.Show("ERROR:Form_VODxml_OPAL_output:Fill_ds_VOD:Exception=" + ex.Message);
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
        public string s_period()
        {
            DateTime xdtStartTime = m_usrc_InvoiceTable.dtStartTime;
            DateTime xdtEndTime = m_usrc_InvoiceTable.dtEndTime;
            string s = lng.s_from.s + " " + xdtStartTime.Day.ToString() + "." + xdtStartTime.Month.ToString() + "." + xdtStartTime.Year.ToString() + " " 
                       +lng.s_to.s + " " + xdtEndTime.Day.ToString() + "." + xdtEndTime.Month.ToString() + "." + xdtEndTime.Year.ToString();
            return s;

        }
        private bool CheckOneMonthPeriod()
        {
            DateTime xdtStartTime = m_usrc_InvoiceTable.dtStartTime;
            DateTime xdtEndTime = m_usrc_InvoiceTable.dtEndTime;

            int iStartYear = xdtStartTime.Year;
            int iStartMonth = xdtStartTime.Month;
            int iEndMonth = xdtEndTime.Month;
            int iEndDay = xdtEndTime.Day;
            DateTime dtnow = DateTime.Now;
            if (iStartYear==dtnow.Year)
            {
                if (iStartMonth == dtnow.Month )
                {
                    MessageBox.Show(lng.s_VODxml_export_for.s + s_period()+"\r\n"+lng.s_you_can_do_VODxml_Output_just_for_past_month.s);
                    return false;
                }
            }

            if (iStartMonth + 1 == iEndMonth)
            {
                if (iEndDay == 1)
                {
                    iObracunsko_Obdobje = iStartMonth;
                    iLeto_Obracunskega_Obdobja = iStartYear;
                    return true;
                }
            }
            else
            {
                if ((iStartMonth == 12)&&(iEndMonth==1))
                {
                    if (iEndDay == 1)
                    {
                        iObracunsko_Obdobje = iStartMonth;
                        iLeto_Obracunskega_Obdobja = iStartYear;
                        return true;
                    }
                }
            }
            MessageBox.Show(lng.s_VODxml_export_for.s + s_period() + "\r\n" + lng.s_you_must_have_select_one_month_period_to_do_VODxml_Output.s);
            return false;
        }

        private void ReadSettings()
        {
            int Konto_DDV_splosna_stopnja = Properties.Settings.Default.Konto_VAT_rate_ganeral;
            int Konto_Osnovna_splosna_stopnja = Properties.Settings.Default.Konto_Net_price;
            int Konto_Price_with_tax_cash = Properties.Settings.Default.Konto_Price_with_tax_cash;
            int Konto_Price_with_tax_payment_cards = Properties.Settings.Default.Konto_Price_with_tax_payment_cards;
            int End_Customers_code = Properties.Settings.Default.End_Customers_Code;

            decimal dKonto_DDV_splosna_stopnja = Konto_DDV_splosna_stopnja;
            decimal dKonto_Osnovna_splosna_stopnja = Konto_Osnovna_splosna_stopnja;
            decimal dKonto_Price_with_tax_cash = Konto_Price_with_tax_cash;
            decimal dKonto_Price_with_tax_payment_cards= Konto_Price_with_tax_payment_cards;
            decimal dEnd_Customers_code = End_Customers_code;


            nmUpDn_Konto_VAT_general_rate.Value = dKonto_DDV_splosna_stopnja;
            nmUpDn_Konto_NetPrice.Value = dKonto_Osnovna_splosna_stopnja;
            nmUpDn_Konto_Price_with_tax_for_cash.Value = dKonto_Price_with_tax_cash;
            nmUpDn_Konto_Price_with_tax_for_payment_cards.Value = dKonto_Price_with_tax_payment_cards;
            nmUpDn_End_Customers_Code.Value = dEnd_Customers_code;
            txt_End_Customers_Name.Text = Properties.Settings.Default.End_Customers_Name;
        }

        private void SaveSettings()
        {

            int Konto_VAT_general_rate = Convert.ToInt32(nmUpDn_Konto_VAT_general_rate.Value);
            int Konto_NetPrice = Convert.ToInt32(nmUpDn_Konto_NetPrice.Value);
            int Konto_Price_with_tax_for_cash = Convert.ToInt32(nmUpDn_Konto_Price_with_tax_for_cash.Value);
            int Konto_Price_with_tax_payment_cards = Convert.ToInt32(nmUpDn_Konto_Price_with_tax_for_payment_cards.Value);
            int End_Customers_Code = Convert.ToInt32(nmUpDn_End_Customers_Code.Value);
            Properties.Settings.Default.Konto_VAT_rate_ganeral = Konto_VAT_general_rate;
            Properties.Settings.Default.Konto_Net_price  = Konto_NetPrice;
            Properties.Settings.Default.Konto_Price_with_tax_cash =  Konto_Price_with_tax_for_cash;
            Properties.Settings.Default.Konto_Price_with_tax_payment_cards = Konto_Price_with_tax_payment_cards;
            Properties.Settings.Default.End_Customers_Code = End_Customers_Code;
            Properties.Settings.Default.End_Customers_Name = Properties.Settings.Default.End_Customers_Name;
            Properties.Settings.Default.Save();
        }

        private void Form_VODxml_OPAL_output_Load(object sender, EventArgs e)
        {
            ReadSettings();
            if (CheckOneMonthPeriod())
            {
                Fill_ds_VOD();
            }
            else
            {
                this.Close();
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }         
        }


        private void nmUpDn_Konto_Znesek_z_ddv_ValueChanged(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void nmUpDn_Konto_Osnovna_splosna_stopnja_ValueChanged(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void nmUpDn_Konto_DDV_splosna_stopnja_ValueChanged(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void txt_Sifra_Koncni_kupci_TextChanged(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void lbl_Konto_Price_with_tax_for_payment_cards_Click(object sender, EventArgs e)
        {

        }

        private void nmUpDn_Konto_Price_with_tax_for_payment_cards_ValueChanged(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void txt_End_Customers_Name_TextChanged(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void nmUpDn_End_Customers_Code_ValueChanged(object sender, EventArgs e)
        {
            SaveSettings();
        }
    }
    public class cp_Items
    {
        public string cp_Davcna_stevilka_zavezanca_za_davek = null;//c_Davcna_stevilka_zavezanca_za_davek;
        public string cp_Stevilka_Racuna = null; //c_Stevilka_Racuna;
        public string cp_Cas_Racuna = null; //c_Datum_Racuna;
        public string cp_Oznaka_Poslovne_Enote = null; //c_Oznaka_Poslovne_Enote
        public string cp_Oznaka_Elektronske_Naprave = null;// c_Oznaka_Elektronske_Naprave
        public string cp_Zaporedna_stevilka_postavke_na_racunu = "Zaporedna_stevilka_postavke_na_racunu";
        public string cp_Oznaka_ali_sifra_blaga_oziroma_storitve = "Oznaka_ali_sifra_blaga_oziroma_storitve";
        public string cp_Naziv_blaga_oziroma_storitve = "Naziv_blaga_oziroma_storitve";
        public string cp_Kolicina_blaga_oziroma_storitve = "Kolicina_blaga_oziroma_storitve";
        public string cp_Enota_mere_blaga_oziroma_storitve = "Enota_mere_blaga_oziroma_storitve";
        public string cp_Cena_blaga_oziroma_storitve_na_enoto_mere_skupaj_z_DDV = "Cena_blaga_oziroma_storitve_na_enoto_mere_skupaj_z_DDV";
        public string cp_Obracunan_DDV_po_stopnji_9_5 = "Obracunan_DDV_po_stopnji_9_5";
        public string cp_Obracunan_DDV_po_stopnji_22 = "Obracunan_DDV_po_stopnji_22";
        public string cp_Zaporedna_stevilka_spremembe = "Zaporedna_stevilka_spremembe";
        public string cp_OPOMBE = "OPOMBE";
    }

    public class cp_Invoices
    {
        public string c_Davcna_stevilka_zavezanca_za_davek = "Davcna_stevilka_zavezanca_za_davek";
        public string c_Stevilka_Racuna = "Stevilka_Racuna";
        public string c_Cas_Racuna = "Cas_izdaje_racuna";
        public string c_Oznaka_Poslovne_Enote = "Oznaka_Poslovne_Enote";
        public string c_Oznaka_Elektronske_Naprave = "Oznaka_Elektronske_Naprave";
        public string c_Firma_ime_in_sedez_kupca = "Firma_ime_in_sedez_kupca";
        public string c_Kupceva_identifikacijska_stevilka_za_DDV = "Kupceva_identifikacijska_stevilka_za_DDV";
        public string c_Znesek_Racuna_skupaj_z_DDV = "Znesek_Racuna_skupaj_z_DDV";
        public string c_Obracunan_DDV_po_9_5 = "Obracunan_DDV_po_9_5";
        public string c_Obracunan_DDV_po_22 = "Obracunan_DDV_po_22";
        public string c_Znesek_placila_z_gotovino_skupaj_z_DDV = "Znesek_placila_z_gotovino_skupaj_z_DDV";
        public string c_Znesek_placila_s_placilno_kartico_skupaj_z_DDV = "Znesek_placila_s_placilno_kartico_skupaj_z_DDV";
        public string c_Znesek_placila_na_drug_nacin_skupaj_z_DDV = "Znesek_placila_na_drug_nacin_skupaj_z_DDV";
        public string c_Cas_spremembe_racuna = "Ura_spremembe_racuna";
        public string c_Zaporedna_stevilka_spremembe_racuna = "Zaporedna_stevilka_spremembe_racuna";
        public string c_Oznaka_razloga_spremembe_racuna = "Oznaka_razloga_spremembe_racuna";
        public string c_Opis_razloga_spremembe_racuna = "Opis_razloga_spremembe_racuna";
        public string c_Uporabnisko_ime_osebe_ki_je_spremenila_racun = "Uporabnisko_ime_osebe_ki_je_spremenila_racun";
        public string c_Ime_in_Priimek_osebe_ki_je_spremenila_racun = "Ime_in_Priimek_osebe_ki_je_spremenila_racun";
        public string c_OPOMBE = "OPOMBE";
    }

}
