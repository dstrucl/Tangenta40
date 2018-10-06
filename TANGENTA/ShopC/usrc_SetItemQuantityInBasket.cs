using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TangentaDB;

namespace ShopC
{
    public partial class usrc_SetItemQuantityInBasket : UserControl
    {

        private DynEditControls.usrc_NumericUpDown3 active_nm_UpDn = null;
        private string unitsymbol = "";
        private string taxation_name = "";

        private decimal dRetailPricePerUnit = 0;
        private decimal extradiscount = 0;
        private decimal discount = 0;
        private decimal taxrate = 0;

        usrc_Item1366x768_selected m_usrc_Item1366x768_selected = null;
        usrc_Atom_Item1366x768 m_usrc_Atom_Item1366x768 = null;
        Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd = null;
        Item_Data idata = null;
        usrc_Item1366x768 m_usrc_Item1366x768 = null;

        public delegate void delegate_ExitClick();
        public event delegate_ExitClick ExitClick;

        public delegate void delegate_ChangeClick();
        public event delegate_ExitClick ChangeClick;

        public usrc_SetItemQuantityInBasket()
        {
            InitializeComponent();
            lng.s_Update.Text(btn_Change);
            lng.s_FromStock.Text(grp_From_Stock);
            lng.s_AvoidStock.Text(grp_FromFactory);
            lng.s_RetailPrice.Text(usrc_nmUpDn_FromStock.label1);
            lng.s_Taxation.Text(usrc_nmUpDn_FromStock.label4);

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            if (ExitClick!=null)
            {
                ExitClick();
            }
    

        }

        private void btn_Change_Click(object sender, EventArgs e)
        {

        }

        private void btn_Discount_Click(object sender, EventArgs e)
        {
            Form_Discount.Form_Discount frm_Discount = new Form_Discount.Form_Discount(dRetailPricePerUnit,
                idata.PurchasePricePerUnit,
                discount,
                this.lbl_Item_UniqueName.Text);
            if (frm_Discount.ShowDialog(this)== DialogResult.OK)
            {
                extradiscount = frm_Discount.ExtraDiscount;
                btn_Discount.Text = Global.f.GetPercent(extradiscount, 4);
                set_NmUpDn(usrc_nmUpDn_FromStock, unitsymbol, taxation_name, lng.s_FromStock.s,idata);
                set_NmUpDn(usrc_nmUpDn_FromFactory, unitsymbol, taxation_name, lng.s_AvoidStock.s, idata);
            }
        }

        private void set_NmUpDn(DynEditControls.usrc_NumericUpDown3 unmupdn3,
                                string sunit_symbol,
                                string stax_name,
                                string squantity_taken_from,
                                Item_Data xdata
                                )
                                
        {

            decimal xRetailPriceWithDiscount = 0;
            decimal xTaxPrice = 0;
            decimal xNetPrice = 0;
            StaticLib.Func.CalculatePrice(dRetailPricePerUnit,
                                          unmupdn3.Value,
                                          discount,
                                          extradiscount,
                                          taxrate,
                                          ref xRetailPriceWithDiscount, ref xTaxPrice, ref xNetPrice, GlobalData.BaseCurrency.DecimalPlaces);

            string sRetailPriceWithDiscount = LanguageControl.DynSettings.SetLanguageCurrencyString(xRetailPriceWithDiscount, GlobalData.BaseCurrency.DecimalPlaces, GlobalData.BaseCurrency.Symbol);
            string sTaxPrice = LanguageControl.DynSettings.SetLanguageCurrencyString(xTaxPrice, GlobalData.BaseCurrency.DecimalPlaces, GlobalData.BaseCurrency.Symbol);
            string sNetPrice = LanguageControl.DynSettings.SetLanguageCurrencyString(xNetPrice, GlobalData.BaseCurrency.DecimalPlaces, GlobalData.BaseCurrency.Symbol);
            unmupdn3.Label1 = lng.s_lbl_PriceWithVAT.s + ":" + sRetailPriceWithDiscount;
            unmupdn3.Label2 = squantity_taken_from + " " + lng.s_Unit.s + ":" + sunit_symbol;

            decimal dquantity_of_items_instock = xdata.dQuantity_OfStockItems;

            int iunit_decimal_places = 2;
            
            if (xdata.Unit_DecimalPlaces!=null)
            {
                iunit_decimal_places = xdata.Unit_DecimalPlaces.v;
            }

            if (unmupdn3.Name.ToLower().Contains("stock"))
            {
                unmupdn3.label3.BackColor = Color.PeachPuff;
                unmupdn3.Label3 = lng.s_StockShort.s+":" + LanguageControl.DynSettings.SetLanguageDecimalString(dquantity_of_items_instock, iunit_decimal_places, sunit_symbol);
                unmupdn3.Label4 = lng.s_Tax.s + ":" + stax_name + "," + sTaxPrice;// + " " + lng.s_lbl_PriceWithoutVAT.s + ":" + sNetPrice;
                if ((appisd.dQuantity_FromStock == 0) && (idata.dQuantity_OfStockItems == 0))
                {
                    unmupdn3.Enabled = false;
                }
                else
                {
                    unmupdn3.Enabled = true;
                }

            }
            else
            {
                unmupdn3.Label3 = lng.s_Tax.s + ":" + stax_name + "," + sTaxPrice;
                unmupdn3.Label4 = lng.s_lbl_PriceWithoutVAT.s + ":" + sNetPrice;
            }

        }

        internal void Init(usrc_Item1366x768_selected x_usrc_Item1366x768_selected, usrc_Atom_Item1366x768 x_usrc_Atom_Item1366x768, Atom_DocInvoice_ShopC_Item_Price_Stock_Data xappisd, Item_Data xidata, usrc_Item1366x768 xusrc_Item1366x768)
        {
            m_usrc_Item1366x768_selected = x_usrc_Item1366x768_selected;
            m_usrc_Atom_Item1366x768 = x_usrc_Atom_Item1366x768;
            appisd = xappisd;
            idata = xidata;
            m_usrc_Item1366x768 = xusrc_Item1366x768;
            if (appisd.Atom_Item_UniqueName != null)
            {
                this.lbl_Item_UniqueName.Text = appisd.Atom_Item_UniqueName.v;
            }
            else
            {
                this.lbl_Item_UniqueName.Text = "";
            }

            if (appisd.Atom_Item_Name_Name != null)
            {
                this.lbl_ItemDescription.Text = appisd.Atom_Item_Name_Name.v;
            }
            else
            {
                this.lbl_ItemDescription.Text = "";
            }

            if (appisd.Atom_Unit_Symbol != null)
            {
                unitsymbol = appisd.Atom_Unit_Symbol.v;
            }

            if (appisd.Atom_Taxation_Name != null)
            {
                taxation_name = appisd.Atom_Taxation_Name.v;
            }

            if (appisd.RetailPricePerUnit != null)
            {
                dRetailPricePerUnit = appisd.RetailPricePerUnit.v;
            }

            if (appisd.Discount!=null)
            {
                discount = appisd.Discount.v;
            }

            if (appisd.ExtraDiscount != null)
            {
                extradiscount = appisd.ExtraDiscount.v;
            }

            btn_Discount.Text = Global.f.GetPercent(extradiscount, 4);

            if (appisd.Atom_Taxation_Rate != null)
            {
                taxrate = appisd.Atom_Taxation_Rate.v;
            }


            usrc_nmUpDn_FromStock.Value = appisd.dQuantity_FromStock;
            set_NmUpDn(usrc_nmUpDn_FromStock, unitsymbol, taxation_name, lng.s_FromStock.s,idata);

            usrc_nmUpDn_FromFactory.Value = appisd.dQuantity_FromFactory;
            set_NmUpDn(usrc_nmUpDn_FromFactory, unitsymbol, taxation_name, lng.s_AvoidStock.s, idata);

            this.usrc_nmUpDn_FromStock.ValueChanged += new System.EventHandler(this.usrc_nmUpDn_FromStock_ValueChanged);
            this.usrc_nmUpDn_FromFactory.ValueChanged += new System.EventHandler(this.usrc_nmUpDn_FromFactory_ValueChanged);


        }

        private void usrc_nmUpDn_FromStock_ValueChanged(object sender, EventArgs e)
        {
            set_NmUpDn(usrc_nmUpDn_FromStock, unitsymbol, taxation_name, lng.s_FromStock.s, idata);
        }

        private void usrc_nmUpDn_FromFactory_ValueChanged(object sender, EventArgs e)
        {
            set_NmUpDn(usrc_nmUpDn_FromFactory, unitsymbol, taxation_name, lng.s_AvoidStock.s, idata);
        }

        private void usrc_nmUpDn_FromStock_TextEnter(object sender, EventArgs e)
        {
            active_nm_UpDn = this.usrc_nmUpDn_FromStock;
        }

        private void usrc_nmUpDn_FromFactory_TextEnter(object sender, EventArgs e)
        {
            active_nm_UpDn = this.usrc_nmUpDn_FromFactory;
        }

        private void usrc_NumKeys1_ButtonClicked(char ch)
        {
            if (active_nm_UpDn!=null)
            {
                string s = null;
                decimal dv = 0;
                if (usrc_NumKeys1.IsDecimalPoint(ch))
                {
                    if (active_nm_UpDn.Tag == null)
                    {
                        active_nm_UpDn.Tag = true;
                    }
                    else
                    {
                        if (active_nm_UpDn.Tag is bool)
                        {
                            if (!(bool)active_nm_UpDn.Tag)
                            {
                                active_nm_UpDn.Tag = true;
                            }
                        }
                    }
                }
                else if (active_nm_UpDn.Tag is bool)
                {
                    if ((bool)active_nm_UpDn.Tag)
                    {
                        s = active_nm_UpDn.Value.ToString();
                        if (s.Contains(","))
                        {
                            s += ch;
                        }
                        else
                        {
                            s += "," + ch;
                        }

                        dv = 0;
                        try
                        {
                            dv = Convert.ToDecimal(s);
                            active_nm_UpDn.Value = dv;
                        }
                        catch
                        {
                        }
                        return;
                    }
                }

                s = active_nm_UpDn.Value.ToString(); 
                s += ch;
                dv = 0;
                try
                {
                    dv = Convert.ToDecimal(s);
                    active_nm_UpDn.Value = dv;
                }
                catch
                {
                }
            }
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {

            if (active_nm_UpDn != null)
            {
                 active_nm_UpDn.Value = 0;
                active_nm_UpDn.Tag = null;
            }
        }

        private void btn_DelBack_Click(object sender, EventArgs e)
        {
            string s = active_nm_UpDn.Value.ToString();
            if (s.Length>0)
            {
                s = s.Substring(0, s.Length - 1);
            }

            if (!s.Contains(","))
            {
                active_nm_UpDn.Tag = null;
            }

            decimal dv = 0;
            if (s.Length>0)
            {
                try
                {
                    dv = Convert.ToDecimal(s);
                    active_nm_UpDn.Value = dv;
                }
                catch
                {
                }
            }
            else
            {
                active_nm_UpDn.Value = 0;
            }
        }
    }
}
