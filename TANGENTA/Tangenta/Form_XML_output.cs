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

namespace Tangenta
{
    public partial class Form_XML_output : Form
    {
        public string XML_Destination_Folder = "";
        usrc_InvoiceTable m_usrc_InvoiceTable = null;
        public string IZPIS_RACUNI_GLAVE = "IZPIS_RACUNI_GLAVE";
        public string IZPIS_RACUNI_POSTAVKE = "IZPIS_RACUNI_POSTAVKE";
        public string filename_XML_IZPIS_RACUNI_GLAVE_TXT = null;
        public string filename_XML_IZPIS_RACUNI_POSTAVKE_TXT = null;
        //string XML_IZPIS_RACUNI_GLAVE_TXT = "";
        //string XML_IZPIS_RACUNI_POSTAVKE_TXT = "";
        DataTable dt_XML_Invoices = new DataTable();
        string Postavke = null;
        string Glava = null;
        DataTable dt_IZPIS_RACUNI_GLAVE = null;
        DataTable dt_IZPIS_RACUNI_POSTAVKE = null;



        public cp_Items Items = new cp_Items();
        public cp_Invoices Invoices = new cp_Invoices();

        
        
        public Form_XML_output(usrc_InvoiceTable xusrc_InvoiceTable)
        {
            InitializeComponent();
            m_usrc_InvoiceTable = xusrc_InvoiceTable;
            filename_XML_IZPIS_RACUNI_GLAVE_TXT = IZPIS_RACUNI_GLAVE +m_usrc_InvoiceTable.sFromTo_Suffix+ ".XML";
            filename_XML_IZPIS_RACUNI_POSTAVKE_TXT = IZPIS_RACUNI_POSTAVKE +m_usrc_InvoiceTable.sFromTo_Suffix+".XML";
            DateTime dt = DateTime.Now;
            string s_time_extension = dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString() + "_" + dt.Hour.ToString() + "-" + dt.Minute.ToString() + "-" + dt.Second.ToString() + "-" + dt.Millisecond.ToString();
            lbl_FileNames.Text = filename_XML_IZPIS_RACUNI_GLAVE_TXT + "\r\n" + filename_XML_IZPIS_RACUNI_POSTAVKE_TXT;
            XML_Destination_Folder = Properties.Settings.Default.XML_output_folder;
            this.cmbR_FilePath.Text = XML_Destination_Folder;
            this.btn_Save.Text = lngRPM.s_Save.s;
            this.lbl_Folder.Text = lngRPM.s_Folder.s;
            this.Text = lngRPM.s_XML_Files.s;
            this.btn_View.Text = lngRPM.s_View.s;
            dt_IZPIS_RACUNI_GLAVE = new DataTable();


            dt_IZPIS_RACUNI_GLAVE.TableName = IZPIS_RACUNI_GLAVE;



            dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Davcna_stevilka_zavezanca_za_davek, typeof(string));
            dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Stevilka_Racuna, typeof(string));
            dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Cas_Racuna, typeof(DateTime));
            dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Oznaka_Poslovne_Enote, typeof(string));
            dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Oznaka_Elektronske_Naprave, typeof(string));
            dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Firma_ime_in_sedez_kupca, typeof(string));
            dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Kupceva_identifikacijska_stevilka_za_DDV, typeof(string));
            dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Znesek_Racuna_skupaj_z_DDV, typeof(decimal));
            dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Obracunan_DDV_po_9_5, typeof(decimal));
            dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Obracunan_DDV_po_22, typeof(decimal));
            dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Znesek_placila_z_gotovino_skupaj_z_DDV, typeof(decimal));
            dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Znesek_placila_s_placilno_kartico_skupaj_z_DDV, typeof(decimal));
            dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Znesek_placila_na_drug_nacin_skupaj_z_DDV, typeof(decimal));
            dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Cas_spremembe_racuna, typeof(DateTime));
            dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Zaporedna_stevilka_spremembe_racuna, typeof(long));
            dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Oznaka_razloga_spremembe_racuna, typeof(string));
            dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Opis_razloga_spremembe_racuna, typeof(string));
            dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Uporabnisko_ime_osebe_ki_je_spremenila_racun, typeof(string));
            dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_Ime_in_Priimek_osebe_ki_je_spremenila_racun, typeof(string));
            dt_IZPIS_RACUNI_GLAVE.Columns.Add(Invoices.c_OPOMBE, typeof(string));

            Items.cp_Davcna_stevilka_zavezanca_za_davek = Invoices.c_Davcna_stevilka_zavezanca_za_davek;
            Items.cp_Stevilka_Racuna = Invoices.c_Stevilka_Racuna;
            Items.cp_Cas_Racuna = Invoices.c_Cas_Racuna;
            Items.cp_Oznaka_Poslovne_Enote = Invoices.c_Oznaka_Poslovne_Enote;
            Items.cp_Oznaka_Elektronske_Naprave = Invoices.c_Oznaka_Elektronske_Naprave;


            dt_IZPIS_RACUNI_POSTAVKE = new DataTable();
            dt_IZPIS_RACUNI_POSTAVKE.TableName = IZPIS_RACUNI_POSTAVKE;

            dt_IZPIS_RACUNI_POSTAVKE.Columns.Add(Items.cp_Davcna_stevilka_zavezanca_za_davek, typeof(string));
            dt_IZPIS_RACUNI_POSTAVKE.Columns.Add(Items.cp_Stevilka_Racuna, typeof(string));
            dt_IZPIS_RACUNI_POSTAVKE.Columns.Add(Items.cp_Cas_Racuna, typeof(DateTime));
            dt_IZPIS_RACUNI_POSTAVKE.Columns.Add(Items.cp_Oznaka_Poslovne_Enote, typeof(string));
            dt_IZPIS_RACUNI_POSTAVKE.Columns.Add(Items.cp_Oznaka_Elektronske_Naprave, typeof(string));
            dt_IZPIS_RACUNI_POSTAVKE.Columns.Add(Items.cp_Zaporedna_stevilka_postavke_na_racunu, typeof(int));
            dt_IZPIS_RACUNI_POSTAVKE.Columns.Add(Items.cp_Oznaka_ali_sifra_blaga_oziroma_storitve, typeof(string));
            dt_IZPIS_RACUNI_POSTAVKE.Columns.Add(Items.cp_Naziv_blaga_oziroma_storitve, typeof(string));
            dt_IZPIS_RACUNI_POSTAVKE.Columns.Add(Items.cp_Kolicina_blaga_oziroma_storitve, typeof(decimal));
            dt_IZPIS_RACUNI_POSTAVKE.Columns.Add(Items.cp_Enota_mere_blaga_oziroma_storitve, typeof(string));
            dt_IZPIS_RACUNI_POSTAVKE.Columns.Add(Items.cp_Cena_blaga_oziroma_storitve_na_enoto_mere_skupaj_z_DDV, typeof(decimal));
            dt_IZPIS_RACUNI_POSTAVKE.Columns.Add(Items.cp_Obracunan_DDV_po_stopnji_9_5, typeof(decimal));
            dt_IZPIS_RACUNI_POSTAVKE.Columns.Add(Items.cp_Obracunan_DDV_po_stopnji_22, typeof(decimal));
            dt_IZPIS_RACUNI_POSTAVKE.Columns.Add(Items.cp_Zaporedna_stevilka_spremembe, typeof(int));
            dt_IZPIS_RACUNI_POSTAVKE.Columns.Add(Items.cp_OPOMBE, typeof(string));


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

        private bool Make_XML_output()
        {
            this.Cursor = Cursors.WaitCursor;

            // write XML_IZPIS_RACUNI_GLAVE_TXT
            Postavke = "Dav št;Rac st;Rac dat;PE id;Blag id;Post st;Post id;Post opis;Post kol;Pos+t em;Post znesek;Post 9,5 % DDV;Post 22 % DDV;Sprem st;Rac opombe\r\n";
            Glava = "Dav št;Rac st;Rac dat;Rac ura;PE id;Blag id;Kupec;IŠ za DDV;Rac znesek;Rac 9,5 % DDV;Rac 22 % DDV;Plac got;Plac kart;Plac ostalo;Sprem dat;Sprem ura;Sprem st;Sprem id;Sprem razlog;Sprem upor;Sprem oseba;Rac opombe\r\n";

            string DestinationFullFileNamePath_XML_IZPIS_RACUNI_GLAVE = XML_Destination_Folder + filename_XML_IZPIS_RACUNI_GLAVE_TXT;
            string DestinationFullFileNamePath_XML_IZPIS_RACUNI_POSTAVKE_TXT = XML_Destination_Folder + filename_XML_IZPIS_RACUNI_POSTAVKE_TXT;
            try
            {
                int iRowsCount = -1;
                string sInvoiceCondition = " and JOURNAL_ProformaInvoice_$_jpinvt_$$ID = " + Program.JOURNAL_ProformaInvoice_Type_definitions.InvoiceTime.ID.ToString() +" ";
                string sql = @" select 
                            JOURNAL_ProformaInvoice_$_pinv_$$ID as ID,
                            JOURNAL_ProformaInvoice_$_pinv_$$Draft,
                            JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg_$$Tax_ID,
                            JOURNAL_ProformaInvoice_$_pinv_$$FinancialYear,
                            JOURNAL_ProformaInvoice_$_pinv_$$NumberInFinancialYear,
                            JOURNAL_ProformaInvoice_$$EventTime,
                            JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg_$$Name,
                            JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_astrnorg_$$StreetName,
                            JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_ahounorg_$$HouseNumber,
                            JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_aziporg_$$ZIP,
                            JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_acitorg_$$City,
                            JOURNAL_ProformaInvoice_$_pinv_$$GrossSum,
                            JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acfn_$$FirstName,
                            JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acln_$$LastName,
                            JOURNAL_ProformaInvoice_$_pinv_$_inv_$_metopay_$$PaymentType,
                            JOURNAL_ProformaInvoice_$_pinv_$$NetSum,
                            JOURNAL_ProformaInvoice_$_pinv_$$TaxSum,
                            JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_astrnper_$$StreetName,
                            JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_ahounper_$$HouseNumber,
                            JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_azipper_$$ZIP,
                            JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_acitper_$$City,
                            JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_agsmnper_$$GsmNumber,
                            JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aphnnper_$$PhoneNumber,
                            JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aemailper_$$Email,
                            JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$$DateOfBirth,
                            JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg_$$Name,
                            JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg_$$Tax_ID,
                            JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg_$$Registration_ID
                            JOURNAL_ProformaInvoice_$_pinv_$_inv_$$Paid,
                            JOURNAL_ProformaInvoice_$_pinv_$_inv_$$Storno,
                            JOURNAL_ProformaInvoice_$_pinv_$$Discount,
                            JOURNAL_ProformaInvoice_$_pinv_$$EndSum,
                            JOURNAL_ProformaInvoice_$_pinv_$_inv_$$ID
                            from JOURNAL_ProformaInvoice_VIEW " + m_usrc_InvoiceTable.cond +sInvoiceCondition+" order by JOURNAL_ProformaInvoice_$_pinv_$$FinancialYear desc,JOURNAL_ProformaInvoice_$_pinv_$$Draft desc, JOURNAL_ProformaInvoice_$_pinv_$$NumberInFinancialYear desc, JOURNAL_ProformaInvoice_$_pinv_$$DraftNumber desc";
                string Err = null;
                bool bRes = DBSync.DBSync.ReadDataTable(ref dt_XML_Invoices, sql, m_usrc_InvoiceTable.lpar_ExtraCondition, ref Err);
                if (bRes)
                {
                    XML_Izpis_Postavka XML_postavka = new XML_Izpis_Postavka(this);
                    iRowsCount = dt_XML_Invoices.Rows.Count;
                    if (iRowsCount>0)
                    {
                        int i = 0;
                        int ic_Invoice_ID = dt_XML_Invoices.Columns.IndexOf("JOURNAL_ProformaInvoice_$_pinv_$_inv_$$ID");
                        int ic_ID = dt_XML_Invoices.Columns.IndexOf("ID");
                        int ic_Draft = dt_XML_Invoices.Columns.IndexOf("JOURNAL_ProformaInvoice_$_pinv_$$Draft");
                        int ic_TaxNumber = dt_XML_Invoices.Columns.IndexOf("JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg_$$Tax_ID");
                        int ic_FinancialYear = dt_XML_Invoices.Columns.IndexOf("JOURNAL_ProformaInvoice_$_pinv_$$FinancialYear");
                        int ic_NumberInFinancialYear = dt_XML_Invoices.Columns.IndexOf("JOURNAL_ProformaInvoice_$_pinv_$$NumberInFinancialYear");
                        int ic_ProformaInvoiceTime = dt_XML_Invoices.Columns.IndexOf("JOURNAL_ProformaInvoice_$$EventTime");
                        int ic_GrossSum = dt_XML_Invoices.Columns.IndexOf("JOURNAL_ProformaInvoice_$_pinv_$$GrossSum");
                        int ic_Organisation_Name = dt_XML_Invoices.Columns.IndexOf("JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg_$$Name");
                        int ic_Organisation_StreetName = dt_XML_Invoices.Columns.IndexOf("JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_astrnorg_$$StreetName");
                        int ic_Organisation_HouseNumber = dt_XML_Invoices.Columns.IndexOf("JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_ahounorg_$$HouseNumber");
                        int ic_Organisation_ZIP = dt_XML_Invoices.Columns.IndexOf("JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_aziporg_$$ZIP");
                        int ic_Organisation_City = dt_XML_Invoices.Columns.IndexOf("JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_acitorg_$$City");
                        int ic_PaymentType = dt_XML_Invoices.Columns.IndexOf("JOURNAL_ProformaInvoice_$_pinv_$_inv_$_metopay_$$PaymentType");
                        for (i=0;i<iRowsCount;i++)
                        {
                            if ((bool)  dt_XML_Invoices.Rows[i][ic_Draft])
                            {
                                continue;
                            }
                            else
                            {

                                long Invoice_ID = (long)dt_XML_Invoices.Rows[i][ic_Invoice_ID];
                                long ProformaInvoice_ID = (long)dt_XML_Invoices.Rows[i][ic_ID];
                                string Davcna_Stevilka = (string)dt_XML_Invoices.Rows[i][ic_TaxNumber];
                                if (!Davcna_Stevilka.ToUpper().Contains("SI"))
                                {
                                    Davcna_Stevilka = "SI" + Davcna_Stevilka;
                                }
                                string gl1_Davcna_stevilka_zavezanca_za_davek = Davcna_Stevilka;
                                string gl2_Stevilka_racuna = Program.GetInvoiceNumber(false, (int)dt_XML_Invoices.Rows[i][ic_FinancialYear], (int)dt_XML_Invoices.Rows[i][ic_NumberInFinancialYear], -1);
                                string gl3_Datum_Racuna_DDMMLL = fs.Date_DDMMYYYY((DateTime)dt_XML_Invoices.Rows[i][ic_ProformaInvoiceTime]);
                                string gl4_Ura_izdaje_racuna_HH_MM = fs.Time_HH_MM(':',(DateTime)dt_XML_Invoices.Rows[i][ic_ProformaInvoiceTime]);
                                string gl5_Oznaka_Poslovne_Enote = "P1";
                                string gl6_Oznaka_Elektronske_Naprave = "1";
                                string gl7_Firma_ime_in_sedez_kupca = "";// (string)dt_XML_Invoices.Rows[i][ic_Organisation_Name] + " " + (string)dt_XML_Invoices.Rows[i][ic_Organisation_StreetName] + " " + (string)dt_XML_Invoices.Rows[i][ic_Organisation_HouseNumber];
                                string gl8_Kupceva_identifikacijska_stevilka_za_DDV = "";
                                string gl9_Znesek_Racuna_skupaj_z_DDV = fs.Decimal2String((decimal)dt_XML_Invoices.Rows[i][ic_GrossSum], 2);
                                string gl10_Obracunan_DDV_po_9_5 = "0,00";
                                string gl11_Obracunan_DDV_po_22 = "0,00";
                                string gl12_Znesek_placila_z_gotovino_skupaj_z_DDV = "0,00";
                                string gl13_Znesek_placila_s_placilno_kartico_skupaj_z_DDV = "0,00";
                                string gl14_Znesek_placila_na_drug_nacin_skupaj_z_DDV = "0,00";
                                string gl15_Datum_spremembe_racuna_DDMMLLL = "";
                                string gl16_Ura_spremembe_racuna = "";
                                string gl17_Zaporedna_stevilka_spremembe_racuna = "";
                                string gl18_Oznaka_razloga_spremembe_racuna = "";
                                string gl19_Opis_razloga_spremembe_racuna = "";
                                string gl20_Uporabnisko_ime_osebe_ki_je_spremenila_racun = "";
                                string gl21_Ime_in_Priimek_osebe_ki_je_spremenila_racun = "";
                                //string gl22_OPOMBE = "";

                                if (((string)dt_XML_Invoices.Rows[i][ic_PaymentType]).ToLower().Contains("gotovina"))
                                {
                                    gl12_Znesek_placila_z_gotovino_skupaj_z_DDV = gl9_Znesek_Racuna_skupaj_z_DDV;
                                }
                                else if (((string)dt_XML_Invoices.Rows[i][ic_PaymentType]).ToLower().Contains("kartica"))
                                {
                                    gl13_Znesek_placila_s_placilno_kartico_skupaj_z_DDV = gl9_Znesek_Racuna_skupaj_z_DDV;
                                }
                                else
                                {
                                    gl14_Znesek_placila_na_drug_nacin_skupaj_z_DDV = gl9_Znesek_Racuna_skupaj_z_DDV;
                                }
                                XML_postavka.Create(ProformaInvoice_ID,
                                                        gl1_Davcna_stevilka_zavezanca_za_davek,
                                                        gl2_Stevilka_racuna,
                                                        (DateTime)dt_XML_Invoices.Rows[i][ic_ProformaInvoiceTime],
                                                        gl5_Oznaka_Poslovne_Enote,
                                                        gl6_Oznaka_Elektronske_Naprave,
                                                        ref gl10_Obracunan_DDV_po_9_5,
                                                        ref gl11_Obracunan_DDV_po_22,
                                                        ref dt_IZPIS_RACUNI_POSTAVKE,
                                                        ref Items);

                                //string s_Invoice_Storno = null;

                                DataRow dr_IZPIS_RACUNI_GLAVE = dt_IZPIS_RACUNI_GLAVE.NewRow();
                                dr_IZPIS_RACUNI_GLAVE[Invoices.c_Davcna_stevilka_zavezanca_za_davek] = gl1_Davcna_stevilka_zavezanca_za_davek;
                                dr_IZPIS_RACUNI_GLAVE[Invoices.c_Stevilka_Racuna] = gl2_Stevilka_racuna;
                                dr_IZPIS_RACUNI_GLAVE[Invoices.c_Cas_Racuna] = (DateTime)dt_XML_Invoices.Rows[i][ic_ProformaInvoiceTime];
                                dr_IZPIS_RACUNI_GLAVE[Invoices.c_Oznaka_Poslovne_Enote] = gl5_Oznaka_Poslovne_Enote;
                                dr_IZPIS_RACUNI_GLAVE[Invoices.c_Oznaka_Elektronske_Naprave] = gl6_Oznaka_Elektronske_Naprave;
                                dr_IZPIS_RACUNI_GLAVE[Invoices.c_Firma_ime_in_sedez_kupca] = gl7_Firma_ime_in_sedez_kupca;
                                dr_IZPIS_RACUNI_GLAVE[Invoices.c_Kupceva_identifikacijska_stevilka_za_DDV] = gl8_Kupceva_identifikacijska_stevilka_za_DDV;
                                dr_IZPIS_RACUNI_GLAVE[Invoices.c_Znesek_Racuna_skupaj_z_DDV] = fs.String2Decimal(gl9_Znesek_Racuna_skupaj_z_DDV);
                                dr_IZPIS_RACUNI_GLAVE[Invoices.c_Obracunan_DDV_po_9_5] = fs.String2Decimal(gl10_Obracunan_DDV_po_9_5);
                                dr_IZPIS_RACUNI_GLAVE[Invoices.c_Obracunan_DDV_po_22] = fs.String2Decimal(gl11_Obracunan_DDV_po_22);
                                dr_IZPIS_RACUNI_GLAVE[Invoices.c_Znesek_placila_z_gotovino_skupaj_z_DDV] = fs.String2Decimal(gl12_Znesek_placila_z_gotovino_skupaj_z_DDV);
                                dr_IZPIS_RACUNI_GLAVE[Invoices.c_Znesek_placila_s_placilno_kartico_skupaj_z_DDV] = fs.String2Decimal(gl13_Znesek_placila_s_placilno_kartico_skupaj_z_DDV);
                                dr_IZPIS_RACUNI_GLAVE[Invoices.c_Znesek_placila_na_drug_nacin_skupaj_z_DDV] = fs.String2Decimal(gl14_Znesek_placila_na_drug_nacin_skupaj_z_DDV);
                                dr_IZPIS_RACUNI_GLAVE[Invoices.c_Cas_spremembe_racuna] = fs.String2Date_DDMMYYYY_HH_MM(gl15_Datum_spremembe_racuna_DDMMLLL, gl16_Ura_spremembe_racuna);
                                dr_IZPIS_RACUNI_GLAVE[Invoices.c_Zaporedna_stevilka_spremembe_racuna] = fs.String2Int(gl17_Zaporedna_stevilka_spremembe_racuna);
                                dr_IZPIS_RACUNI_GLAVE[Invoices.c_Oznaka_razloga_spremembe_racuna] = gl18_Oznaka_razloga_spremembe_racuna;
                                dr_IZPIS_RACUNI_GLAVE[Invoices.c_Opis_razloga_spremembe_racuna] = gl19_Opis_razloga_spremembe_racuna;
                                dr_IZPIS_RACUNI_GLAVE[Invoices.c_Uporabnisko_ime_osebe_ki_je_spremenila_racun] = gl20_Uporabnisko_ime_osebe_ki_je_spremenila_racun;
                                dr_IZPIS_RACUNI_GLAVE[Invoices.c_Ime_in_Priimek_osebe_ki_je_spremenila_racun] = gl21_Ime_in_Priimek_osebe_ki_je_spremenila_racun;
                                dr_IZPIS_RACUNI_GLAVE[Invoices.c_OPOMBE] = "";

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
                                            JOURNAL_Invoice_$_jinvt_$$Description,
                                            JOURNAL_Invoice_$$EventTime,
                                            JOURNAL_Invoice_$_awperiod_$_amcper_$$UserName,
                                            JOURNAL_Invoice_$_awperiod_$_amcper_$$FirstName,
                                            JOURNAL_Invoice_$_awperiod_$_amcper_$$LastName
                                       from JOURNAL_Invoice_VIEW where JOURNAL_Invoice_$_jinvt_$$Name = 'Storno*' and JOURNAL_Invoice_$_inv_$$Storno = 1 and JOURNAL_Invoice_$_inv_$$ID = " + Invoice_ID.ToString();

                                DataTable dt_XML_Invoice_Storno = new DataTable();
                                DataRow dr_IZPIS_RACUNI_GLAVE_storno = null;
                                if (DBSync.DBSync.ReadDataTable(ref dt_XML_Invoice_Storno,sql, ref Err))
                                {
                                    if (dt_XML_Invoice_Storno.Rows.Count>0)
                                    {
                                        gl15_Datum_spremembe_racuna_DDMMLLL = (string) fs.Date_DDMMYYYY((DateTime)dt_XML_Invoice_Storno.Rows[0]["JOURNAL_Invoice_$$EventTime"]);
                                        gl16_Ura_spremembe_racuna = (string) fs.Time_HH_MM(':',(DateTime)dt_XML_Invoice_Storno.Rows[0]["JOURNAL_Invoice_$$EventTime"]);
                                        gl17_Zaporedna_stevilka_spremembe_racuna = "1";
                                        gl18_Oznaka_razloga_spremembe_racuna = "S";
                                        gl19_Opis_razloga_spremembe_racuna = (string)dt_XML_Invoice_Storno.Rows[0]["JOURNAL_Invoice_$_jinvt_$$Description"];
                                        gl20_Uporabnisko_ime_osebe_ki_je_spremenila_racun = (string)dt_XML_Invoice_Storno.Rows[0]["JOURNAL_Invoice_$_awperiod_$_amcper_$$UserName"];
                                        string sFirstName = "";
                                        object oFirstName = dt_XML_Invoice_Storno.Rows[0]["JOURNAL_Invoice_$_awperiod_$_amcper_$$FirstName"];
                                        if (oFirstName is string)
                                        {
                                            sFirstName = (string)oFirstName;
                                        }
                                        string sLastName = "";
                                        object oLastName = dt_XML_Invoice_Storno.Rows[0]["JOURNAL_Invoice_$_awperiod_$_amcper_$$LastName"];
                                        if (oLastName is string)
                                        {
                                            sLastName = (string)oLastName;
                                        }

                                        gl21_Ime_in_Priimek_osebe_ki_je_spremenila_racun = sFirstName + " " + sLastName;

                                        dr_IZPIS_RACUNI_GLAVE_storno = dt_IZPIS_RACUNI_GLAVE.NewRow();
                                        dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Davcna_stevilka_zavezanca_za_davek] = gl1_Davcna_stevilka_zavezanca_za_davek;
                                        dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Stevilka_Racuna] = gl2_Stevilka_racuna;
                                        dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Cas_Racuna] = fs.String2Date_DDMMYYYY_HH_MM(gl3_Datum_Racuna_DDMMLL, gl4_Ura_izdaje_racuna_HH_MM);
                                        dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Oznaka_Poslovne_Enote] = gl5_Oznaka_Poslovne_Enote;
                                        dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Oznaka_Elektronske_Naprave] = gl6_Oznaka_Elektronske_Naprave;
                                        dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Firma_ime_in_sedez_kupca] = gl7_Firma_ime_in_sedez_kupca;
                                        dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Kupceva_identifikacijska_stevilka_za_DDV] = gl8_Kupceva_identifikacijska_stevilka_za_DDV;
                                        dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Znesek_Racuna_skupaj_z_DDV] = fs.String2Decimal(gl9_Znesek_Racuna_skupaj_z_DDV);
                                        dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Obracunan_DDV_po_9_5] = fs.String2Decimal(gl10_Obracunan_DDV_po_9_5);
                                        dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Obracunan_DDV_po_22] = fs.String2Decimal(gl11_Obracunan_DDV_po_22);
                                        dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Znesek_placila_z_gotovino_skupaj_z_DDV] = fs.String2Decimal(gl12_Znesek_placila_z_gotovino_skupaj_z_DDV);
                                        dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Znesek_placila_s_placilno_kartico_skupaj_z_DDV] = fs.String2Decimal(gl13_Znesek_placila_s_placilno_kartico_skupaj_z_DDV);
                                        dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Znesek_placila_na_drug_nacin_skupaj_z_DDV] = fs.String2Decimal(gl14_Znesek_placila_na_drug_nacin_skupaj_z_DDV);
                                        dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Cas_spremembe_racuna] = fs.String2Date_DDMMYYYY_HH_MM(gl15_Datum_spremembe_racuna_DDMMLLL, gl16_Ura_spremembe_racuna);
                                        dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Zaporedna_stevilka_spremembe_racuna] = fs.String2Int(gl17_Zaporedna_stevilka_spremembe_racuna);
                                        dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Oznaka_razloga_spremembe_racuna] = gl18_Oznaka_razloga_spremembe_racuna;
                                        dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Opis_razloga_spremembe_racuna] = gl19_Opis_razloga_spremembe_racuna;
                                        dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Uporabnisko_ime_osebe_ki_je_spremenila_racun] = gl20_Uporabnisko_ime_osebe_ki_je_spremenila_racun;
                                        dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_Ime_in_Priimek_osebe_ki_je_spremenila_racun] = gl21_Ime_in_Priimek_osebe_ki_je_spremenila_racun;
                                        dr_IZPIS_RACUNI_GLAVE_storno[Invoices.c_OPOMBE] = "";

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
                                    LogFile.Error.Show("ERROR:Form_XML_output:Make_Durs_output:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }

                                if (dr_IZPIS_RACUNI_GLAVE_storno != null)
                                {
                                    dt_IZPIS_RACUNI_GLAVE.Rows.Add(dr_IZPIS_RACUNI_GLAVE);
                                    dt_IZPIS_RACUNI_GLAVE.Rows.Add(dr_IZPIS_RACUNI_GLAVE_storno);
                                    //Glava += s_Invoice_Storno + s_Invoice; 
                                }
                                else
                                {
                                    dt_IZPIS_RACUNI_GLAVE.Rows.Add(dr_IZPIS_RACUNI_GLAVE);
                                    //Glava += s_Invoice;
                                }

                            }
                        }
                        bool res = true;
                        try
                        {
                            dt_IZPIS_RACUNI_GLAVE.WriteXml(this.cmbR_FilePath.Text + filename_XML_IZPIS_RACUNI_GLAVE_TXT, XmlWriteMode.WriteSchema);
                            //File.WriteAllText(this.cmbR_FilePath.Text + filename_XML_IZPIS_RACUNI_GLAVE_TXT, Glava, Encoding.GetEncoding(1250));
                        }
                        catch (Exception ex)
                        {
                            res = false;
                            MessageBox.Show(lngRPM.s_Err_Write_File.s + this.cmbR_FilePath.Text + filename_XML_IZPIS_RACUNI_GLAVE_TXT + "\r\n" + lngRPM.s_Error.s + "=" + ex.Message);
                        }

                        try
                        {
                            dt_IZPIS_RACUNI_POSTAVKE.WriteXml(this.cmbR_FilePath.Text + filename_XML_IZPIS_RACUNI_POSTAVKE_TXT, XmlWriteMode.WriteSchema);
                            //File.WriteAllText(this.cmbR_FilePath.Text + filename_XML_IZPIS_RACUNI_POSTAVKE_TXT, Postavke, Encoding.GetEncoding(1250));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(lngRPM.s_Err_Write_File.s + this.cmbR_FilePath.Text + filename_XML_IZPIS_RACUNI_POSTAVKE_TXT + "\r\n" + lngRPM.s_Error.s + "=" + ex.Message);
                        }
                        MessageBox.Show(this,lngRPM.s_XML_Files.s+":\r\n    "+this.cmbR_FilePath.Text + filename_XML_IZPIS_RACUNI_GLAVE_TXT+"\r\n    "+this.cmbR_FilePath.Text + filename_XML_IZPIS_RACUNI_POSTAVKE_TXT +"\r\n"+lngRPM.s_XML_files_Saved_OK.s);
                        this.Cursor = Cursors.Arrow;
                        this.btn_View.Visible = true;
                        return res;
                    }
                    else
                    {
                        MessageBox.Show(lngRPM.s_NoInvoicesData.s);
                        this.Cursor = Cursors.Arrow;
                        return false;
                    }
                }
                else
                {
                    this.Cursor = Cursors.Arrow;
                    LogFile.Error.Show("ERROR:Form_XML_output:Make_Durs_output:sql="+sql+"\r\nErr=" + Err);
                    return false;
                }
            }
            catch (Exception Ex)
            {
                this.Cursor = Cursors.Arrow;
                LogFile.Error.Show("ERROR:Form_XML_output:Make_Durs_output:Exception=" + Ex.Message);
                return false;
            }

        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (Make_XML_output())
            {

            }
        }

        private void btn_View_Click(object sender, EventArgs e)
        {
            Form_XML_FilesPreview XML_FilesPreview_dlg = new Form_XML_FilesPreview(this);
            XML_FilesPreview_dlg.ShowDialog();
        }
    }
}
