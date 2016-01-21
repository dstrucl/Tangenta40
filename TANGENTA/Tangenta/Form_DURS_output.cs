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
using InvoiceDB;

namespace Tangenta
{
    public partial class Form_DURS_output : Form
    {
        public string DURS_Destination_Folder = "";
        usrc_InvoiceTable m_usrc_InvoiceTable = null;
        public string filename_DURS_IZPIS_RACUNI_GLAVE_TXT = "IZPIS RAČUNI GLAVE.TXT";
        public string filename_DURS_IZPIS_RACUNI_POSTAVKE_TXT = "IZPIS RAČUNI POSTAVKE.TXT";
        string DURS_IZPIS_RACUNI_GLAVE_TXT = "";
        string DURS_IZPIS_RACUNI_POSTAVKE_TXT = "";
        DataTable dt_DURS_Invoices = new DataTable();
        string Postavke = null;
        string Glava = null;

        public Form_DURS_output(usrc_InvoiceTable xusrc_InvoiceTable)
        {
            InitializeComponent();
            m_usrc_InvoiceTable = xusrc_InvoiceTable;
            DateTime dt = DateTime.Now;
            string s_time_extension = dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString() + "_" + dt.Hour.ToString() + "-" + dt.Minute.ToString() + "-" + dt.Second.ToString() + "-" + dt.Millisecond.ToString();
            lbl_FileNames.Text = filename_DURS_IZPIS_RACUNI_GLAVE_TXT + "\r\n" + filename_DURS_IZPIS_RACUNI_POSTAVKE_TXT;
            DURS_Destination_Folder = Properties.Settings.Default.DURS_output_folder;
            this.cmbR_FilePath.Text = DURS_Destination_Folder;
            this.btn_Save.Text = lngRPM.s_Save.s;
            this.lbl_Folder.Text = lngRPM.s_Folder.s;
            this.Text = lngRPM.s_DURS_Files.s;
            this.btn_View.Text = lngRPM.s_View.s;
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
                DURS_Destination_Folder = cmbR_FilePath.Text;
                Properties.Settings.Default.DURS_output_folder = DURS_Destination_Folder;
                Properties.Settings.Default.Save();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private bool Make_Durs_output()
        {
            this.Cursor = Cursors.WaitCursor;

            // write DURS_IZPIS_RACUNI_GLAVE_TXT
            Postavke = "Dav št;Rac st;Rac dat;PE id;Blag id;Post st;Post id;Post opis;Post kol;Pos+t em;Post znesek;Post 9,5 % DDV;Post 22 % DDV;Sprem st;Rac opombe\r\n";
            Glava = "Dav št;Rac st;Rac dat;Rac ura;PE id;Blag id;Kupec;IŠ za DDV;Rac znesek;Rac 9,5 % DDV;Rac 22 % DDV;Plac got;Plac kart;Plac ostalo;Sprem dat;Sprem ura;Sprem st;Sprem id;Sprem razlog;Sprem upor;Sprem oseba;Rac opombe\r\n";

            string DestinationFullFileNamePath_DURS_IZPIS_RACUNI_GLAVE = DURS_Destination_Folder + filename_DURS_IZPIS_RACUNI_GLAVE_TXT;
            string DestinationFullFileNamePath_DURS_IZPIS_RACUNI_POSTAVKE_TXT = DURS_Destination_Folder + filename_DURS_IZPIS_RACUNI_POSTAVKE_TXT;
            try
            {
                int iRowsCount = -1;
                string sInvoiceCondition = " and JOURNAL_ProformaInvoice_$_jpinvt_$$ID = " + GlobalData.JOURNAL_ProformaInvoice_Type_definitions.InvoiceTime.ID.ToString() + " ";
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
                            from JOURNAL_ProformaInvoice_VIEW " + m_usrc_InvoiceTable.cond + sInvoiceCondition + " order by JOURNAL_ProformaInvoice_$_pinv_$$FinancialYear desc,JOURNAL_ProformaInvoice_$_pinv_$$Draft desc, JOURNAL_ProformaInvoice_$_pinv_$$NumberInFinancialYear desc, JOURNAL_ProformaInvoice_$_pinv_$$DraftNumber desc";
                string Err = null;
                bool bRes = DBSync.DBSync.ReadDataTable(ref dt_DURS_Invoices, sql, m_usrc_InvoiceTable.lpar_ExtraCondition, ref Err);
                if (bRes)
                {
                    DURS_Izpis_Postavka DURS_postavka = new DURS_Izpis_Postavka(this);
                    iRowsCount = dt_DURS_Invoices.Rows.Count;
                    if (iRowsCount>0)
                    {
                        int i = 0;
                        int ic_Invoice_ID = dt_DURS_Invoices.Columns.IndexOf("JOURNAL_ProformaInvoice_$_pinv_$_inv_$$ID");
                        int ic_ID = dt_DURS_Invoices.Columns.IndexOf("ID");
                        int ic_Draft = dt_DURS_Invoices.Columns.IndexOf("JOURNAL_ProformaInvoice_$_pinv_$$Draft");
                        int ic_TaxNumber = dt_DURS_Invoices.Columns.IndexOf("JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg_$$Tax_ID");
                        int ic_FinancialYear = dt_DURS_Invoices.Columns.IndexOf("JOURNAL_ProformaInvoice_$_pinv_$$FinancialYear");
                        int ic_NumberInFinancialYear = dt_DURS_Invoices.Columns.IndexOf("JOURNAL_ProformaInvoice_$_pinv_$$NumberInFinancialYear");
                        int ic_ProformaInvoiceTime = dt_DURS_Invoices.Columns.IndexOf("JOURNAL_ProformaInvoice_$$EventTime");
                        int ic_GrossSum = dt_DURS_Invoices.Columns.IndexOf("JOURNAL_ProformaInvoice_$_pinv_$$GrossSum");
                        int ic_Organisation_Name = dt_DURS_Invoices.Columns.IndexOf("JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg_$$Name");
                        int ic_Organisation_StreetName = dt_DURS_Invoices.Columns.IndexOf("JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_astrnorg_$$StreetName");
                        int ic_Organisation_HouseNumber = dt_DURS_Invoices.Columns.IndexOf("JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_ahounorg_$$HouseNumber");
                        int ic_Organisation_ZIP = dt_DURS_Invoices.Columns.IndexOf("JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_aziporg_$$ZIP");
                        int ic_Organisation_City = dt_DURS_Invoices.Columns.IndexOf("JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_acitorg_$$City");
                        int ic_PaymentType = dt_DURS_Invoices.Columns.IndexOf("JOURNAL_ProformaInvoice_$_pinv_$_inv_$_metopay_$$PaymentType");

                        for (i=0;i<iRowsCount;i++)
                        {
                            if ((bool)  dt_DURS_Invoices.Rows[i][ic_Draft])
                            {
                                continue;
                            }
                            else
                            {

                                long Invoice_ID = (long)dt_DURS_Invoices.Rows[i][ic_Invoice_ID];
                                long ProformaInvoice_ID = (long)dt_DURS_Invoices.Rows[i][ic_ID];
                                string Davcna_Stevilka = (string)dt_DURS_Invoices.Rows[i][ic_TaxNumber];
                                if (!Davcna_Stevilka.ToUpper().Contains("SI"))
                                {
                                    Davcna_Stevilka = "SI" + Davcna_Stevilka;
                                }
                                string gl1_Davcna_stevilka_zavezanca_za_davek = Davcna_Stevilka;
                                string gl2_Stevilka_racuna = Program.GetInvoiceNumber(false, (int)dt_DURS_Invoices.Rows[i][ic_FinancialYear], (int)dt_DURS_Invoices.Rows[i][ic_NumberInFinancialYear], -1);
                                string gl3_Datum_Racuna_DDMMLL = fs.Date_DDMMYYYY((DateTime)dt_DURS_Invoices.Rows[i][ic_ProformaInvoiceTime]);
                                string gl4_Ura_izdaje_racuna_HH_MM = fs.Time_HH_MM(':',(DateTime)dt_DURS_Invoices.Rows[i][ic_ProformaInvoiceTime]);
                                string gl5_Oznaka_Poslovne_Enote = "P1";
                                string gl6_Oznaka_Elektronske_Naprave = "1";
                                string gl7_Firma_ime_in_sedez_kupca = "";// (string)dt_DURS_Invoices.Rows[i][ic_Organisation_Name] + " " + (string)dt_DURS_Invoices.Rows[i][ic_Organisation_StreetName] + " " + (string)dt_DURS_Invoices.Rows[i][ic_Organisation_HouseNumber];
                                string gl8_Kupceva_identifikacijska_stevilka_za_DDV = "";
                                string gl9_Znesek_Racuna_skupaj_z_DDV = fs.Decimal2String((decimal)dt_DURS_Invoices.Rows[i][ic_GrossSum], 2);
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
                                string gl22_OPOMBE = "";

                                if (((string)dt_DURS_Invoices.Rows[i][ic_PaymentType]).ToLower().Contains("gotovina"))
                                {
                                    gl12_Znesek_placila_z_gotovino_skupaj_z_DDV = gl9_Znesek_Racuna_skupaj_z_DDV;
                                }
                                else if (((string)dt_DURS_Invoices.Rows[i][ic_PaymentType]).ToLower().Contains("kartica"))
                                {
                                    gl13_Znesek_placila_s_placilno_kartico_skupaj_z_DDV = gl9_Znesek_Racuna_skupaj_z_DDV;
                                }
                                else
                                {
                                    gl14_Znesek_placila_na_drug_nacin_skupaj_z_DDV = gl9_Znesek_Racuna_skupaj_z_DDV;
                                }

                                DURS_postavka.Create(ProformaInvoice_ID,
                                                        gl1_Davcna_stevilka_zavezanca_za_davek,
                                                        gl2_Stevilka_racuna,
                                                        gl3_Datum_Racuna_DDMMLL,
                                                        gl5_Oznaka_Poslovne_Enote,
                                                        gl6_Oznaka_Elektronske_Naprave,
                                                        ref gl10_Obracunan_DDV_po_9_5,
                                                        ref gl11_Obracunan_DDV_po_22,
                                                        ref Postavke);

                                string s_Invoice_Storno = null;
                                string s_Invoice = 
                                        gl1_Davcna_stevilka_zavezanca_za_davek
                                 + ";" +gl2_Stevilka_racuna
                                 + ";" +gl3_Datum_Racuna_DDMMLL
                                 + ";" +gl4_Ura_izdaje_racuna_HH_MM
                                 + ";" +gl5_Oznaka_Poslovne_Enote
                                 + ";" +gl6_Oznaka_Elektronske_Naprave
                                 + ";" +gl7_Firma_ime_in_sedez_kupca
                                 + ";" +gl8_Kupceva_identifikacijska_stevilka_za_DDV
                                 + ";" +gl9_Znesek_Racuna_skupaj_z_DDV
                                 + ";" +gl10_Obracunan_DDV_po_9_5
                                 + ";" +gl11_Obracunan_DDV_po_22
                                 + ";" +gl12_Znesek_placila_z_gotovino_skupaj_z_DDV
                                 + ";" +gl13_Znesek_placila_s_placilno_kartico_skupaj_z_DDV
                                 + ";" +gl14_Znesek_placila_na_drug_nacin_skupaj_z_DDV
                                 + ";" +gl15_Datum_spremembe_racuna_DDMMLLL
                                 + ";" +gl16_Ura_spremembe_racuna
                                 + ";" +gl17_Zaporedna_stevilka_spremembe_racuna
                                 + ";" +gl18_Oznaka_razloga_spremembe_racuna
                                 + ";" +gl19_Opis_razloga_spremembe_racuna
                                 + ";" +gl20_Uporabnisko_ime_osebe_ki_je_spremenila_racun
                                 + ";" +gl21_Ime_in_Priimek_osebe_ki_je_spremenila_racun
                                  + ";" +gl22_OPOMBE + "\r\n";

                                sql = @"select 
                                            JOURNAL_Invoice_$_jinvt_$$Description,
                                            JOURNAL_Invoice_$$EventTime,
                                            JOURNAL_Invoice_$_awperiod_$_amcper_$$UserName,
                                            JOURNAL_Invoice_$_awperiod_$_amcper_$_aper_$_acfn_$$FirstName,
                                            JOURNAL_Invoice_$_awperiod_$_amcper_$_aper_$_acln_$$LastName
                                       from JOURNAL_Invoice_VIEW where JOURNAL_Invoice_$_jinvt_$$Name = 'Storno*' and JOURNAL_Invoice_$_inv_$$Storno = 1 and JOURNAL_Invoice_$_inv_$$ID = " + Invoice_ID.ToString();

                                DataTable dt_DURS_Invoice_Storno = new DataTable();
                                if (DBSync.DBSync.ReadDataTable(ref dt_DURS_Invoice_Storno,sql, ref Err))
                                {
                                    if (dt_DURS_Invoice_Storno.Rows.Count>0)
                                    {
                                        gl15_Datum_spremembe_racuna_DDMMLLL = (string) fs.Date_DDMMYYYY((DateTime)dt_DURS_Invoice_Storno.Rows[0]["JOURNAL_Invoice_$$EventTime"]);
                                        gl16_Ura_spremembe_racuna = (string) fs.Time_HH_MM(':',(DateTime)dt_DURS_Invoice_Storno.Rows[0]["JOURNAL_Invoice_$$EventTime"]);
                                        gl17_Zaporedna_stevilka_spremembe_racuna = "1";
                                        gl18_Oznaka_razloga_spremembe_racuna = "S";
                                        gl19_Opis_razloga_spremembe_racuna = (string)dt_DURS_Invoice_Storno.Rows[0]["JOURNAL_Invoice_$_jinvt_$$Description"];
                                        gl20_Uporabnisko_ime_osebe_ki_je_spremenila_racun = (string)dt_DURS_Invoice_Storno.Rows[0]["JOURNAL_Invoice_$_awperiod_$_amcper_$$UserName"];
                                        string sFirstName = "";
                                        object oFirstName = dt_DURS_Invoice_Storno.Rows[0]["JOURNAL_Invoice_$_awperiod_$_amcper_$_aper_$_acfn_$$FirstName"];
                                        if (oFirstName is string)
                                        {
                                            sFirstName = (string)oFirstName;
                                        }
                                        string sLastName = "";
                                        object oLastName = dt_DURS_Invoice_Storno.Rows[0]["JOURNAL_Invoice_$_awperiod_$_amcper_$_aper_$_acln_$$LastName"];
                                        if (oLastName is string)
                                        {
                                            sLastName = (string)oLastName;
                                        }

                                        gl21_Ime_in_Priimek_osebe_ki_je_spremenila_racun = sFirstName + " " + sLastName;

                                        s_Invoice_Storno = gl1_Davcna_stevilka_zavezanca_za_davek
                                         + ";" + gl2_Stevilka_racuna
                                         + ";" + gl3_Datum_Racuna_DDMMLL
                                         + ";" + gl4_Ura_izdaje_racuna_HH_MM
                                         + ";" + gl5_Oznaka_Poslovne_Enote
                                         + ";" + gl6_Oznaka_Elektronske_Naprave
                                         + ";" + gl7_Firma_ime_in_sedez_kupca
                                         + ";" + gl8_Kupceva_identifikacijska_stevilka_za_DDV
                                         + ";" + gl9_Znesek_Racuna_skupaj_z_DDV
                                         + ";" + gl10_Obracunan_DDV_po_9_5
                                         + ";" + gl11_Obracunan_DDV_po_22
                                         + ";" + gl12_Znesek_placila_z_gotovino_skupaj_z_DDV
                                         + ";" + gl13_Znesek_placila_s_placilno_kartico_skupaj_z_DDV
                                         + ";" + gl14_Znesek_placila_na_drug_nacin_skupaj_z_DDV
                                         + ";" + gl15_Datum_spremembe_racuna_DDMMLLL
                                         + ";" + gl16_Ura_spremembe_racuna
                                         + ";" + gl17_Zaporedna_stevilka_spremembe_racuna
                                         + ";" + gl18_Oznaka_razloga_spremembe_racuna
                                         + ";" + gl19_Opis_razloga_spremembe_racuna
                                         + ";" + gl20_Uporabnisko_ime_osebe_ki_je_spremenila_racun
                                         + ";" + gl21_Ime_in_Priimek_osebe_ki_je_spremenila_racun
                                          + ";" + gl22_OPOMBE + "\r\n";
                                    }
                                }
                                else
                                {
                                    this.Cursor = Cursors.Arrow;
                                    LogFile.Error.Show("ERROR:Form_DURS_output:Make_Durs_output:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }

                                if (s_Invoice_Storno!=null)
                                {
                                    Glava += s_Invoice_Storno + s_Invoice; 
                                }
                                else
                                {
                                    Glava += s_Invoice;
                                }

                            }
                        }
                        bool res = true;
                        try
                        { 
                            File.WriteAllText(this.cmbR_FilePath.Text + filename_DURS_IZPIS_RACUNI_GLAVE_TXT, Glava, Encoding.GetEncoding(1250));
                        }
                        catch (Exception ex)
                        {
                            res = false;
                            MessageBox.Show(lngRPM.s_Err_Write_File.s + this.cmbR_FilePath.Text + filename_DURS_IZPIS_RACUNI_GLAVE_TXT + "\r\n" + lngRPM.s_Error.s + "=" + ex.Message);
                        }

                        try
                        {
                            File.WriteAllText(this.cmbR_FilePath.Text + filename_DURS_IZPIS_RACUNI_POSTAVKE_TXT, Postavke, Encoding.GetEncoding(1250));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(lngRPM.s_Err_Write_File.s + this.cmbR_FilePath.Text + filename_DURS_IZPIS_RACUNI_POSTAVKE_TXT + "\r\n" + lngRPM.s_Error.s + "=" + ex.Message);
                        }
                        MessageBox.Show(this,lngRPM.s_DURS_Files.s+":\r\n    "+this.cmbR_FilePath.Text + filename_DURS_IZPIS_RACUNI_GLAVE_TXT+"\r\n    "+this.cmbR_FilePath.Text + filename_DURS_IZPIS_RACUNI_POSTAVKE_TXT +"\r\n"+lngRPM.s_DURS_files_Saved_OK.s);
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
                    LogFile.Error.Show("ERROR:Form_DURS_output:Make_Durs_output:sql="+sql+"\r\nErr=" + Err);
                    return false;
                }
            }
            catch (Exception Ex)
            {
                this.Cursor = Cursors.Arrow;
                LogFile.Error.Show("ERROR:Form_DURS_output:Make_Durs_output:Exception=" + Ex.Message);
                return false;
            }

        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (Make_Durs_output())
            {

            }
        }

        private void btn_View_Click(object sender, EventArgs e)
        {
            Form_DURS_FilesPreview DURS_FilesPreview_dlg = new Form_DURS_FilesPreview(this);
            DURS_FilesPreview_dlg.ShowDialog();
        }
    }
}
