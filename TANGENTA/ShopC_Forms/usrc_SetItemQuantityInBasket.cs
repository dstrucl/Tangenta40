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
using DynEditControls;
using DBConnectionControl40;
using DBTypes;
using ShopC_Forms;

namespace ShopC_Forms
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

        private decimal dv_remains_in_stock = 0;
        private decimal last_usrc_nmUpDn_FromStock_Value = 0;

        private ConsumptionEditor m_ConsE = null;
        private usrc_CItem_selected m_usrc_Item_selected = null;
        private usrc_Atom_CItem m_usrc_Atom_Item = null;
        private TangentaDB.Consumption_ShopC_Item dsci = null;
        private CItem_Data idata = null;
        private usrc_CItemList m_usrc_ItemList = null;
        private usrc_CItem m_usrc_Item = null;


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
            if (dsci != null)
            {
                //if (dsci.ExtraDiscount != extradiscount)
                //{
                //    Transaction transaction_usrc_SetItemQuantityInBasket_btn_Change_Click_UpdateExtraDiscount = DBSync.DBSync.NewTransaction("usrc_SetItemQuantityInBasket.btn_Change_Click.UpdateExtraDiscount");
                //    if (dsci.UpdateExtraDiscount(m_ConsE.DocTyp, extradiscount, transaction_usrc_SetItemQuantityInBasket_btn_Change_Click_UpdateExtraDiscount))
                //    {
                //        if (transaction_usrc_SetItemQuantityInBasket_btn_Change_Click_UpdateExtraDiscount.Commit())
                //        {
                //            dsci.ExtraDiscount = extradiscount;
                //        }
                //    }
                //    else
                //    {
                //        transaction_usrc_SetItemQuantityInBasket_btn_Change_Click_UpdateExtraDiscount.Rollback();
                //    }
                //}
            }
            ChangeQuantitiesInDB();
        }

        private void ChangeQuantitiesInDB()
        {
            // first stock items !
            decimal dallstocks = dsci.dQuantity_FromStock + idata.dQuantity_OfCStockItems;
            decimal dToTakeFromStock = usrc_nmUpDn_FromStock.Value;
            decimal dToTakeFromFactory = usrc_nmUpDn_FromFactory.Value;
            if (dToTakeFromStock <= dallstocks)
            {
                // take from stock is possible
                if (dToTakeFromStock + dToTakeFromFactory ==0)
                {
                    //ask to remove item from basket
                    if (XMessage.Box.Show(this,lng.sYouSetAllQuantitiesToZeroDoYouwantToRemoveItem,"?",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
                    {
                     
                        m_usrc_Atom_Item.RemoveFromBasket();
                        if (ExitClick != null)
                        {
                            ExitClick();
                        }
                        return;
                    }
                    else
                    {
                        return;
                    }
                }

                bool bresFromStock = true;

                if (dToTakeFromStock > dsci.dQuantity_FromStock)
                {
                    decimal dadd_QuantityFromStock = dToTakeFromStock - dsci.dQuantity_FromStock;

                    if (m_usrc_ItemList.SelectItemsFromStockDialog)
                    {
                        bresFromStock = m_ConsE.CurrentCons.m_Basket.Add2Basket(ref dsci,m_ConsE.DocTyp, m_ConsE.CurrentCons.m_Doc_ID, dadd_QuantityFromStock, idata, this.m_usrc_ItemList.Select_Items_From_Stock_Dialog);
                    }
                    else
                    {
                        bresFromStock = m_ConsE.CurrentCons.m_Basket.Add2Basket(ref dsci, m_ConsE.DocTyp, m_ConsE.CurrentCons.m_Doc_ID, dadd_QuantityFromStock, idata, null);
                    }
                }
                else
                {
                    decimal dRemoveAndPutBack2Stock = dsci.dQuantity_FromStock-dToTakeFromStock;
                    if (dToTakeFromStock <= dsci.dQuantity_FromStock)
                    {
                        Transaction transaction_usrc_SetItemQuantityInBasket_ChangeQuantitiesInDB_RemoveFromBasket_And_put_back_to_Stock = DBSync.DBSync.NewTransaction("usrc_SetItemQuantityInBasket.ChangeQuantitiesInDB.RemoveFromBasket_And_put_back_to_Stock");
                        bresFromStock = m_ConsE.CurrentCons.m_Basket.RemoveFromBasket_And_put_back_to_Stock(m_ConsE.DocTyp,
                                                                                                              m_ConsE.CurrentCons.m_Doc_ID,
                                                                                                              dRemoveAndPutBack2Stock,
                                                                                                              idata,
                                                                                                              transaction_usrc_SetItemQuantityInBasket_ChangeQuantitiesInDB_RemoveFromBasket_And_put_back_to_Stock);
                       if (bresFromStock)
                        {
                            transaction_usrc_SetItemQuantityInBasket_ChangeQuantitiesInDB_RemoveFromBasket_And_put_back_to_Stock.Commit();
                        }
                       else
                        {
                            transaction_usrc_SetItemQuantityInBasket_ChangeQuantitiesInDB_RemoveFromBasket_And_put_back_to_Stock.Rollback();
                            return;
                        }

                    }
                }


                //bool bresFromFactory = true;

                //Transaction transaction_usrc_SetItemQuantityInBasket_ChangeQuantitiesInDB_SetFactory = DBSync.DBSync.NewTransaction("usrc_SetItemQuantityInBasket.ChangeQuantitiesInDB.SetFactory");
                //bresFromFactory = m_ConsE.CurrentCons.m_Basket.SetFactory(m_ConsE.DocTyp,
                //                                                            m_ConsE.CurrentCons.m_Doc_ID,
                //                                                            dToTakeFromFactory,
                //                                                            idata,
                //                                                            transaction_usrc_SetItemQuantityInBasket_ChangeQuantitiesInDB_SetFactory);

                //if (bresFromFactory)
                //{
                //    transaction_usrc_SetItemQuantityInBasket_ChangeQuantitiesInDB_SetFactory.Commit();
                //}
                //else
                //{
                //    transaction_usrc_SetItemQuantityInBasket_ChangeQuantitiesInDB_SetFactory.Rollback();
                //    return;
                //}
                if (bresFromStock/* && bresFromFactory*/)
                {
                    m_usrc_Atom_Item.DoRefresh();
                    m_usrc_Item.DoPaint(idata, m_ConsE.CurrentCons.m_Basket);
                    m_usrc_Item_selected.DoPaint(dsci, m_usrc_Atom_Item, idata, m_usrc_Item);
                }

            }
            else
            {
                XMessage.Box.Show(this, lng.s_ThereAreNotsoManyArticlesInStock, MessageBoxIcon.Information);
            }
        }

     




  

  

        private void btn_Discount_Click(object sender, EventArgs e)
        {
            Form_Discount.Form_Discount frm_Discount = new Form_Discount.Form_Discount(dRetailPricePerUnit,
                idata.PurchasePricePerUnit_v,
                discount,
                this.lbl_Item_UniqueName.Text);
            if (frm_Discount.ShowDialog(this)== DialogResult.OK)
            {
                extradiscount = frm_Discount.ExtraDiscount;
              
                btn_Discount.Text = Global.f.GetPercent(extradiscount, 4);
                set_NmUpDn(usrc_nmUpDn_FromStock, unitsymbol, taxation_name, lng.s_FromStock.s,dv_remains_in_stock, idata);
                set_NmUpDn(usrc_nmUpDn_FromFactory, unitsymbol, taxation_name, lng.s_AvoidStock.s, dv_remains_in_stock, idata);
            }
        }

        private void set_NmUpDn(DynEditControls.usrc_NumericUpDown3 unmupdn3,
                                string sunit_symbol,
                                string stax_name,
                                string squantity_taken_from,
                                decimal xv_remains_in_stock,
                                CItem_Data xdata
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

           

            int iunit_decimal_places = 2;
            
            if (xdata.Unit_DecimalPlaces_v!=null)
            {
                iunit_decimal_places = xdata.Unit_DecimalPlaces_v.v;
            }

            if (unmupdn3.Name.ToLower().Contains("stock"))
            {
                unmupdn3.label3.BackColor = Color.PeachPuff;
                unmupdn3.Label3 = lng.s_StockShort.s+":" + LanguageControl.DynSettings.SetLanguageDecimalString(xv_remains_in_stock, iunit_decimal_places, sunit_symbol);
                unmupdn3.Label4 = lng.s_Tax.s + ":" + stax_name + "," + sTaxPrice;// + " " + lng.s_lbl_PriceWithoutVAT.s + ":" + sNetPrice;
                if ((dsci.dQuantity_FromStock == 0) && (idata.dQuantity_OfCStockItems == 0))
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

        internal void Init(ConsumptionEditor xconsE,
                           usrc_CItem_selected x_usrc_Item_selected,
                           usrc_Atom_CItem x_usrc_Atom_Item,
                           TangentaDB.Consumption_ShopC_Item xdsci,
                           CItem_Data xidata,
                           usrc_CItemList xusrc_ItemList,
                           usrc_CItem xusrc_Item)
        {
            m_ConsE = xconsE;
            m_usrc_Item_selected = x_usrc_Item_selected;
            m_usrc_Atom_Item = x_usrc_Atom_Item;
            dsci = xdsci;
            idata = xidata;
            m_usrc_ItemList = xusrc_ItemList;
            m_usrc_Item = xusrc_Item;
            if (dsci==null)
            {
                return;
            }
            if (dsci.Atom_Item_UniqueName_v != null)
            {
                this.lbl_Item_UniqueName.Text = dsci.Atom_Item_UniqueName_v.v;
            }
            else
            {
                this.lbl_Item_UniqueName.Text = "";
            }

            if (dsci.Atom_Item_Name_Name_v != null)
            {
                this.lbl_ItemDescription.Text = dsci.Atom_Item_Name_Name_v.v;
            }
            else
            {
                this.lbl_ItemDescription.Text = "";
            }

            if (dsci.Atom_Unit_Symbol_v != null)
            {
                unitsymbol = dsci.Atom_Unit_Symbol_v.v;
            }

            if (dsci.Atom_Taxation_Name_v != null)
            {
                taxation_name = dsci.Atom_Taxation_Name_v.v;
            }

            
            dRetailPricePerUnit = dsci.RetailPricePerUnit;
            
            discount = dsci.Discount;
            
            extradiscount = dsci.ExtraDiscount;
           

            btn_Discount.Text = Global.f.GetPercent(extradiscount, 4);

            if (dsci.Atom_Taxation_Rate_v != null)
            {
                taxrate = dsci.Atom_Taxation_Rate_v.v;
            }


            usrc_nmUpDn_FromStock.Value = dsci.dQuantity_FromStock;
            last_usrc_nmUpDn_FromStock_Value = usrc_nmUpDn_FromStock.Value;
            dv_remains_in_stock = idata.dQuantity_OfCStockItems;
            set_NmUpDn(usrc_nmUpDn_FromStock, unitsymbol, taxation_name, lng.s_FromStock.s, dv_remains_in_stock,idata);

            usrc_nmUpDn_FromFactory.Value = dsci.dQuantity_FromFactory;
            set_NmUpDn(usrc_nmUpDn_FromFactory, unitsymbol, taxation_name, lng.s_AvoidStock.s, dv_remains_in_stock, idata);

            this.usrc_nmUpDn_FromStock.ValueChanged += new System.EventHandler(this.usrc_nmUpDn_FromStock_ValueChanged);
            this.usrc_nmUpDn_FromFactory.ValueChanged += new System.EventHandler(this.usrc_nmUpDn_FromFactory_ValueChanged);


        }

        private void usrc_nmUpDn_FromStock_ValueChanged(object sender, EventArgs e)
        {
            decimal dif_stock_value = usrc_nmUpDn_FromStock.Value - last_usrc_nmUpDn_FromStock_Value;
            if (dv_remains_in_stock - dif_stock_value>=0)
            {
                dv_remains_in_stock = dv_remains_in_stock - dif_stock_value;
                last_usrc_nmUpDn_FromStock_Value = usrc_nmUpDn_FromStock.Value;
            }
            else
            {
                this.usrc_nmUpDn_FromStock.ValueChanged -= new System.EventHandler(this.usrc_nmUpDn_FromStock_ValueChanged);
                usrc_nmUpDn_FromStock.Value = last_usrc_nmUpDn_FromStock_Value;
                this.usrc_nmUpDn_FromStock.ValueChanged += new System.EventHandler(this.usrc_nmUpDn_FromStock_ValueChanged);
            }
            set_NmUpDn(usrc_nmUpDn_FromStock, unitsymbol, taxation_name, lng.s_FromStock.s, dv_remains_in_stock, idata);
        }

        private void usrc_nmUpDn_FromFactory_ValueChanged(object sender, EventArgs e)
        {
            set_NmUpDn(usrc_nmUpDn_FromFactory, unitsymbol, taxation_name, lng.s_AvoidStock.s, dv_remains_in_stock, idata);
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
                    if (dsci.Atom_Unit_DecimalPlaces_v!=null)
                    {
                       if (dsci.Atom_Unit_DecimalPlaces_v.v == 0)
                        {
                            string sUnitName = "";
                            if (dsci.Atom_Unit_Name_v!=null)
                            {
                                sUnitName = dsci.Atom_Unit_Name_v.v;
                            }

                            string smsg = lng.s_Unit.s + " " + sUnitName + " " + lng.s_HasNoDecimalPlaces.s;
                            XMessage.Box.Show(this, smsg, lng.s_DecimalPlaces.s);
                            return;
                        }
                    }
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
