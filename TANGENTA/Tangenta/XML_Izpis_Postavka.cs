using InvoiceDB;
using LanguageControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Tangenta
{
    public class XML_Izpis_Postavka
    {
        Form frm_parent = null;
        public List<XML_Postavka> XML_Postavka_List = new List<XML_Postavka>();

        public XML_Izpis_Postavka(Form_XML_output frm)
        {
            frm_parent = frm;
        }
        internal bool Create(long ProformaInvoice_ID,
                             string gl1_Davcna_stevilka_zavezanca_za_davek,
                             string gl2_Stevilka_racuna,
                             DateTime InovoiceTime,
                             string gl5_Oznaka_Poslovne_Enote,
                             string gl6_Oznaka_Elektronske_Naprave,
                             ref string gl10_Obracunan_DDV_po_9_5,
                             ref string gl11_Obracunan_DDV_po_22,
                             ref DataTable Postavke,
                             ref cp_Items p)
        {
            XML_Postavka_List.Clear();
            string Err = null;
            decimal Obracunan_DDV_po_9_5 = 0;
            decimal Obracunan_DDV_po_22 = 0;
            string sql = @" select apsi.RetailSimpleItemPrice,
                                   apsi.RetailSimpleItemPriceWithDiscount,
                                   apsi.Discount,
                                   apsi.iQuantity,
                                   apsi.ExtraDiscount,
                                   apsi.TaxPrice,
                                    asin.Name as SimpleItem_Name,
                                    asin.Abbreviation as SimpleItem_Abbreviation,
                                    atax.Name,
                                    atax.Rate
                                    from atom_price_simpleitem  apsi
                                    inner join atom_simpleitem  asi on apsi.atom_simpleitem_ID = asi.ID
                                    inner join atom_simpleitem_name  asin on asi.atom_simpleitem_name_ID = asin.ID
                                    inner join Atom_Taxation atax on apsi.Atom_Taxation_ID = atax.ID
                                    where ProformaInvoice_ID = " + ProformaInvoice_ID.ToString();
            DataTable dt_simple_item_tax = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt_simple_item_tax, sql, ref Err))
            {
                SimpleItem_postavka(dt_simple_item_tax, 
                                    gl1_Davcna_stevilka_zavezanca_za_davek,
                                    gl2_Stevilka_racuna,
                                    InovoiceTime,
                                    gl5_Oznaka_Poslovne_Enote,
                                    gl6_Oznaka_Elektronske_Naprave,
                                    ref Obracunan_DDV_po_9_5,
                                    ref Obracunan_DDV_po_22,
                                    ref Postavke,
                                    p
                                    );

                sql = @" select appis.TaxPrice,
                                ai.UniqueName,
                                appis.dQuantity,
                                api.RetailPricePerUnit,
                                appis.RetailPriceWithDiscount,
                                appis.ExtraDiscount,
                                api.Discount,
                                ain.Name as Item_Name,
                                atax.Name as Taxation_Name,
                                atax.Rate,
                                au.Name as UnitName
                                from atom_proformainvoice_price_item_stock  appis
                                inner join atom_price_item api on appis.atom_price_item_ID = api.ID
                                inner join atom_item ai on api.atom_item_ID = ai.ID
                                inner join atom_unit au on ai.atom_unit_ID = au.ID
                                inner join atom_item_name ain on ai.atom_item_name_ID = ain.ID
                                inner join Atom_Taxation atax on api.Atom_Taxation_ID = atax.ID
                                where ProformaInvoice_ID = " + ProformaInvoice_ID.ToString();
                DataTable dt_item_tax = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt_item_tax, sql, ref Err))
                {

                    Item_Postavka(dt_item_tax,
                                   gl1_Davcna_stevilka_zavezanca_za_davek,
                                   gl2_Stevilka_racuna,
                                   InovoiceTime,
                                   gl5_Oznaka_Poslovne_Enote,
                                   gl6_Oznaka_Elektronske_Naprave,
                                   ref Obracunan_DDV_po_9_5,
                                   ref Obracunan_DDV_po_22,
                                   ref Postavke,
                                   p);

                    gl10_Obracunan_DDV_po_9_5 = fs.Decimal2String(Obracunan_DDV_po_9_5, 2);
                    gl11_Obracunan_DDV_po_22 = fs.Decimal2String(Obracunan_DDV_po_22, 2);


                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:TaxSum:Create:sql= " + sql + "\r\nErr=" + Err);
                    return false;

                }

            }
            else
            {
                LogFile.Error.Show("ERROR:TaxSum:Create:sql= " + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private void SimpleItem_postavka(DataTable dt_simple_item_tax,
                                        string gl1_Davcna_stevilka_zavezanca_za_davek,
                                        string gl2_Stevilka_racuna,
                                        DateTime InvoiceTime,
                                        string gl5_Oznaka_Poslovne_Enote,
                                        string gl6_Oznaka_Elektronske_Naprave,
                                        ref decimal Obracunan_DDV_po_9_5,
                                        ref decimal Obracunan_DDV_po_22,
                                        ref DataTable dt_Postavke,
                                        cp_Items p
                                        )
        {
            int i = 0;
            int ic_SimpleItem_Name = dt_simple_item_tax.Columns.IndexOf("SimpleItem_Name");
            int ic_SimpleItem_Abbreviation = dt_simple_item_tax.Columns.IndexOf("SimpleItem_Abbreviation");
            int ic_iQuantity = dt_simple_item_tax.Columns.IndexOf("iQuantity");
            int ic_RetailSimpleItemPriceWithDiscount = dt_simple_item_tax.Columns.IndexOf("RetailSimpleItemPriceWithDiscount");
            int ic_RetailSimpleItemPrice = dt_simple_item_tax.Columns.IndexOf("RetailSimpleItemPrice");
            int ic_Discount = dt_simple_item_tax.Columns.IndexOf("Discount");
            int ic_ExtraDiscount = dt_simple_item_tax.Columns.IndexOf("ExtraDiscount");
            int ic_TaxPrice = dt_simple_item_tax.Columns.IndexOf("TaxPrice");
            int ic_Rate = dt_simple_item_tax.Columns.IndexOf("Rate");
            foreach (DataRow dr in dt_simple_item_tax.Rows)
            {
                i++;
                XML_Postavka dp = new XML_Postavka();
                dp.po1_Davcna_Stevilka = gl1_Davcna_stevilka_zavezanca_za_davek;
                dp.po2_Stevilka_Racuna = gl2_Stevilka_racuna;
                dp.po4_Oznaka_Poslovne_Enote = gl5_Oznaka_Poslovne_Enote;
                dp.po5_Oznaka_Elektronske_Naprave = gl6_Oznaka_Elektronske_Naprave;
                dp.po6_Zaporedna_stevilka_postavke_na_racunu = i.ToString();
                dp.po7_Oznaka_ali_sifra_blaga_oziroma_storitve = (string)dr[ic_SimpleItem_Abbreviation];
                dp.po8_Naziv_blaga_oziroma_storitve = (string)dr[ic_SimpleItem_Name];
                decimal dQuantity = Convert.ToDecimal((int)dr[ic_iQuantity]);
                dp.po9_Kolicina_blaga_oziroma_storitve = fs.Decimal2String(dQuantity, 2);
                dp.po10_Enota_mere_blaga_oziroma_storitve = "x";
                decimal calc_RetailPriceWithDiscount = 0;
                decimal calc_NetPrice = 0;
                decimal TaxPrice = 0;
                StaticLib.Func.CalculatePrice((decimal)dr[ic_RetailSimpleItemPrice], dQuantity, (decimal)dr[ic_Discount], (decimal)dr[ic_ExtraDiscount], (decimal)dr[ic_Rate], ref calc_RetailPriceWithDiscount, ref TaxPrice, ref calc_NetPrice, 2);
                decimal PricePerUnit = decimal.Round(calc_RetailPriceWithDiscount / dQuantity, 2);
                dp.po11_Cena_blaga_oziroma_storitve_na_enoto_mere_skupaj_z_DDV = fs.Decimal2String(PricePerUnit, 2);

                if ((decimal)dr[ic_Rate] == 0.095M)
                {
                    Obracunan_DDV_po_9_5 += (decimal)dr[ic_TaxPrice];
                    dp.po12_Obracunan_DDV_po_stopnji_9_5 = fs.Decimal2String(TaxPrice, 2);
                    dp.po13_Obracunan_DDV_po_stopnji_22 = "0,00";
                }
                else if ((decimal)dr[ic_Rate] == 0.22M)
                {
                    Obracunan_DDV_po_22 += (decimal)dr[ic_TaxPrice];
                    dp.po12_Obracunan_DDV_po_stopnji_9_5 = "0,00";
                    dp.po13_Obracunan_DDV_po_stopnji_22 = fs.Decimal2String(TaxPrice, 2);
                }
                else
                {
                    string sMsg = "Davčna Stopnja :" + ((decimal)dr[ic_Rate]).ToString() + " z imenom " + (string)dr["Taxation_Name"] + " ni podprta in veljavna v izpisih za XML!\r\n";
                    System.Windows.Forms.MessageBox.Show(frm_parent, sMsg);
                }

                DataRow dr_Postavka = dt_Postavke.NewRow();

                dr_Postavka[p.cp_Davcna_stevilka_zavezanca_za_davek] = dp.po1_Davcna_Stevilka;
                dr_Postavka[p.cp_Stevilka_Racuna] = dp.po2_Stevilka_Racuna;
                dr_Postavka[p.cp_Cas_Racuna] = InvoiceTime;
                dr_Postavka[p.cp_Oznaka_Poslovne_Enote] = dp.po4_Oznaka_Poslovne_Enote;
                dr_Postavka[p.cp_Oznaka_Elektronske_Naprave] = dp.po5_Oznaka_Elektronske_Naprave;
                dr_Postavka[p.cp_Zaporedna_stevilka_postavke_na_racunu] = i;
                dr_Postavka[p.cp_Oznaka_ali_sifra_blaga_oziroma_storitve] = dp.po7_Oznaka_ali_sifra_blaga_oziroma_storitve;
                dr_Postavka[p.cp_Naziv_blaga_oziroma_storitve] = dp.po8_Naziv_blaga_oziroma_storitve;
                dr_Postavka[p.cp_Kolicina_blaga_oziroma_storitve] = dQuantity;
                dr_Postavka[p.cp_Enota_mere_blaga_oziroma_storitve] = dp.po10_Enota_mere_blaga_oziroma_storitve;
                dr_Postavka[p.cp_Cena_blaga_oziroma_storitve_na_enoto_mere_skupaj_z_DDV] = PricePerUnit;
                dr_Postavka[p.cp_Obracunan_DDV_po_stopnji_9_5] = fs.String2Decimal(dp.po12_Obracunan_DDV_po_stopnji_9_5);
                dr_Postavka[p.cp_Obracunan_DDV_po_stopnji_22] = fs.String2Decimal(dp.po13_Obracunan_DDV_po_stopnji_22);
                dr_Postavka[p.cp_Zaporedna_stevilka_spremembe] = 0;
                dr_Postavka[p.cp_OPOMBE] = dp.po15_OPOMBE;

                dt_Postavke.Rows.Add(dr_Postavka);
                //dp.po14_Zoporedna_stevilka_spremembe = "";
                //dp.po15_OPOMBE = "";
                //s_postavka =
                //                    dp.po1_Davcna_Stevilka
                //            + ";" + dp.po2_Stevilka_Racuna
                //            + ";" + dp.po3_Datum_Racuna_DDMMLLLL
                //            + ";" + dp.po4_Oznaka_Poslovne_Enote
                //            + ";" + dp.po5_Oznaka_Elektronske_Naprave
                //            + ";" + dp.po6_Zaporedna_stevilka_postavke_na_racunu
                //            + ";" + dp.po7_Oznaka_ali_sifra_blaga_oziroma_storitve
                //            + ";" + dp.po8_Naziv_blaga_oziroma_storitve
                //            + ";" + dp.po9_Kolicina_blaga_oziroma_storitve
                //            + ";" + dp.po10_Enota_mere_blaga_oziroma_storitve
                //            + ";" + dp.po11_Cena_blaga_oziroma_storitve_na_enoto_mere_skupaj_z_DDV
                //            + ";" + dp.po12_Obracunan_DDV_po_stopnji_9_5
                //            + ";" + dp.po13_Obracunan_DDV_po_stopnji_22
                //            + ";" + dp.po14_Zoporedna_stevilka_spremembe
                //            + ";" + dp.po15_OPOMBE;

                //Postavke += s_postavka + "\r\n";

                XML_Postavka_List.Add(dp);
            }

        }

        private void Item_Postavka(DataTable dt_item_tax,
                                        string gl1_Davcna_stevilka_zavezanca_za_davek,
                                        string gl2_Stevilka_racuna,
                                        DateTime InvoiceTime,
                                        string gl5_Oznaka_Poslovne_Enote,
                                        string gl6_Oznaka_Elektronske_Naprave,
                                        ref decimal Obracunan_DDV_po_9_5,
                                        ref decimal Obracunan_DDV_po_22,
                                        ref DataTable dt_Postavke,
                                        cp_Items p)
        {

            int i = 0;
            int ici_UniqueName = dt_item_tax.Columns.IndexOf("UniqueName");
            int ici_ItemName = dt_item_tax.Columns.IndexOf("Item_Name");
            int ici_dQuantity = dt_item_tax.Columns.IndexOf("dQuantity");
            int ici_RetailPricePerUnit = dt_item_tax.Columns.IndexOf("RetailPricePerUnit");
            int ici_RetailPriceWithDiscount = dt_item_tax.Columns.IndexOf("RetailPriceWithDiscount");
            int ici_Discount = dt_item_tax.Columns.IndexOf("Discount");
            int ici_ExtraDiscount = dt_item_tax.Columns.IndexOf("ExtraDiscount");
            int ici_TaxPrice = dt_item_tax.Columns.IndexOf("TaxPrice");
            int ici_Rate = dt_item_tax.Columns.IndexOf("Rate");
            int ici_UnitName = dt_item_tax.Columns.IndexOf("UnitName");
            foreach (DataRow dr in dt_item_tax.Rows)
            {
                i++;
                //string s_postavka = "";
                XML_Postavka dp = new XML_Postavka();
                dp.po1_Davcna_Stevilka = gl1_Davcna_stevilka_zavezanca_za_davek;
                dp.po2_Stevilka_Racuna = gl2_Stevilka_racuna;
                //dp.po3_Datum_Racuna_DDMMLLLL = gl3_Datum_Racuna_DDMMLL;
                dp.po4_Oznaka_Poslovne_Enote = gl5_Oznaka_Poslovne_Enote;
                dp.po5_Oznaka_Elektronske_Naprave = gl6_Oznaka_Elektronske_Naprave;
                dp.po6_Zaporedna_stevilka_postavke_na_racunu = i.ToString();
                dp.po7_Oznaka_ali_sifra_blaga_oziroma_storitve = (string)dr[ici_UniqueName];
                dp.po8_Naziv_blaga_oziroma_storitve = (string)dr[ici_ItemName];
                decimal dQuantity = (decimal)dr[ici_dQuantity];
                dp.po9_Kolicina_blaga_oziroma_storitve = fs.Decimal2String(dQuantity, 2);
                dp.po10_Enota_mere_blaga_oziroma_storitve = (string)dr[ici_UnitName]; 
                decimal calc_RetailPriceWithDiscount = 0;
                decimal calc_NetPrice = 0;
                decimal TaxPrice = 0;
                StaticLib.Func.CalculatePrice((decimal)dr[ici_RetailPricePerUnit], dQuantity, (decimal)dr[ici_Discount], (decimal)dr[ici_ExtraDiscount], (decimal)dr[ici_Rate], ref calc_RetailPriceWithDiscount, ref TaxPrice, ref calc_NetPrice, 2);
                decimal PricePerUnit = decimal.Round(calc_RetailPriceWithDiscount / dQuantity, 2);
                dp.po11_Cena_blaga_oziroma_storitve_na_enoto_mere_skupaj_z_DDV = fs.Decimal2String(PricePerUnit, 2);

                if ((decimal)dr[ici_Rate] == 0.095M)
                {
                    Obracunan_DDV_po_9_5 += (decimal)dr[ici_TaxPrice];
                    dp.po12_Obracunan_DDV_po_stopnji_9_5 = fs.Decimal2String(TaxPrice, 2);
                    dp.po13_Obracunan_DDV_po_stopnji_22 = "0,00";
                }
                else if ((decimal)dr[ici_Rate] == 0.22M)
                {
                    Obracunan_DDV_po_22 += (decimal)dr[ici_TaxPrice];
                    dp.po12_Obracunan_DDV_po_stopnji_9_5 = "0,00";
                    dp.po13_Obracunan_DDV_po_stopnji_22 = fs.Decimal2String(TaxPrice, 2);
                }
                else
                {
                    string sMsg = "Davčna Stopnja :" + ((decimal)dr[ici_Rate]).ToString() + " z imenom " + (string)dr["Taxation_Name"] + " ni podprta in veljavna v izpisih za XML!\r\n";
                    System.Windows.Forms.MessageBox.Show(frm_parent, sMsg);
                }

                dp.po14_Zoporedna_stevilka_spremembe = "";
                dp.po15_OPOMBE = "";

                DataRow dr_Postavka = dt_Postavke.NewRow();

                dr_Postavka[p.cp_Davcna_stevilka_zavezanca_za_davek] = dp.po1_Davcna_Stevilka;
                dr_Postavka[p.cp_Stevilka_Racuna] = dp.po2_Stevilka_Racuna;
                dr_Postavka[p.cp_Cas_Racuna] = InvoiceTime;
                dr_Postavka[p.cp_Oznaka_Poslovne_Enote] = dp.po4_Oznaka_Poslovne_Enote;
                dr_Postavka[p.cp_Oznaka_Elektronske_Naprave] = dp.po5_Oznaka_Elektronske_Naprave;
                dr_Postavka[p.cp_Zaporedna_stevilka_postavke_na_racunu] = i;
                dr_Postavka[p.cp_Oznaka_ali_sifra_blaga_oziroma_storitve] = dp.po7_Oznaka_ali_sifra_blaga_oziroma_storitve;
                dr_Postavka[p.cp_Naziv_blaga_oziroma_storitve] = dp.po8_Naziv_blaga_oziroma_storitve;
                dr_Postavka[p.cp_Kolicina_blaga_oziroma_storitve] = dQuantity;
                dr_Postavka[p.cp_Enota_mere_blaga_oziroma_storitve] = dp.po10_Enota_mere_blaga_oziroma_storitve;
                dr_Postavka[p.cp_Cena_blaga_oziroma_storitve_na_enoto_mere_skupaj_z_DDV] = PricePerUnit;
                dr_Postavka[p.cp_Obracunan_DDV_po_stopnji_9_5] = fs.String2Decimal(dp.po12_Obracunan_DDV_po_stopnji_9_5);
                dr_Postavka[p.cp_Obracunan_DDV_po_stopnji_22] = fs.String2Decimal(dp.po13_Obracunan_DDV_po_stopnji_22);
                dr_Postavka[p.cp_Zaporedna_stevilka_spremembe] = 0;// dp.po14_Zoporedna_stevilka_spremembe;
                dr_Postavka[p.cp_OPOMBE] = dp.po15_OPOMBE;

                dt_Postavke.Rows.Add(dr_Postavka);

                //s_postavka =
                //                    dp.po1_Davcna_Stevilka
                //            + ";" + dp.po2_Stevilka_Racuna
                //            + ";" + dp.po3_Datum_Racuna_DDMMLLLL
                //            + ";" + dp.po4_Oznaka_Poslovne_Enote
                //            + ";" + dp.po5_Oznaka_Elektronske_Naprave
                //            + ";" + dp.po6_Zaporedna_stevilka_postavke_na_racunu
                //            + ";" + dp.po7_Oznaka_ali_sifra_blaga_oziroma_storitve
                //            + ";" + dp.po8_Naziv_blaga_oziroma_storitve
                //            + ";" + dp.po9_Kolicina_blaga_oziroma_storitve
                //            + ";" + dp.po10_Enota_mere_blaga_oziroma_storitve
                //            + ";" + dp.po11_Cena_blaga_oziroma_storitve_na_enoto_mere_skupaj_z_DDV
                //            + ";" + dp.po12_Obracunan_DDV_po_stopnji_9_5
                //            + ";" + dp.po13_Obracunan_DDV_po_stopnji_22
                //            + ";" + dp.po14_Zoporedna_stevilka_spremembe
                //            + ";" + dp.po15_OPOMBE;

                //Postavke += s_postavka + "\r\n";

                XML_Postavka_List.Add(dp);
            }
        }
    }

    public class XML_Postavka
    {
        public string po1_Davcna_Stevilka = null;
        public string po2_Stevilka_Racuna = null;
        public string po3_Datum_Racuna_DDMMLLLL = null;
        public string po4_Oznaka_Poslovne_Enote = null;
        public string po5_Oznaka_Elektronske_Naprave = null;
        public string po6_Zaporedna_stevilka_postavke_na_racunu = null;
        public string po7_Oznaka_ali_sifra_blaga_oziroma_storitve = null;
        public string po8_Naziv_blaga_oziroma_storitve = null;
        public string po9_Kolicina_blaga_oziroma_storitve = null;
        public string po10_Enota_mere_blaga_oziroma_storitve = null;
        public string po11_Cena_blaga_oziroma_storitve_na_enoto_mere_skupaj_z_DDV = null;
        public string po12_Obracunan_DDV_po_stopnji_9_5 = null;
        public string po13_Obracunan_DDV_po_stopnji_22 = null;
        public string po14_Zoporedna_stevilka_spremembe = null;
        public string po15_OPOMBE = null;
    }

}
