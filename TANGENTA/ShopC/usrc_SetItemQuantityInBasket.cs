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

        private decimal dv_remains_in_stock = 0;
        private decimal last_usrc_nmUpDn_FromStock_Value = 0;

        private ShopABC m_ShopBC = null;
        private usrc_Item1366x768_selected m_usrc_Item1366x768_selected = null;
        private usrc_Atom_Item1366x768 m_usrc_Atom_Item1366x768 = null;
        private Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd = null;
        private Item_Data idata = null;
        private usrc_Item1366x768 m_usrc_Item1366x768 = null;


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
            ChangeQuantitiesInDB();
        }

        private void ChangeQuantitiesInDB()
        {
            // first stock items !
            decimal dallstocks = appisd.dQuantity_FromStock + idata.dQuantity_OfStockItems;
            decimal dToTakeFromStock = usrc_nmUpDn_FromStock.Value;
            decimal dToTakeFromFactory = usrc_nmUpDn_FromFactory.Value;
            if (dToTakeFromStock <= dallstocks)
            {
                // take from stock is possible
                takeFromStock(dToTakeFromStock);
                take_FromFactory(dToTakeFromFactory);
                m_usrc_Atom_Item1366x768.DoRefresh();
                m_usrc_Item1366x768.DoPaint(idata, m_ShopBC.m_CurrentDoc.m_Basket);
                m_usrc_Item1366x768_selected.DoPaint(appisd, m_usrc_Atom_Item1366x768, idata, m_usrc_Item1366x768);
            }
            else
            {
                XMessage.Box.Show(this, lng.s_ThereAreNotsoManyArticlesInStock, MessageBoxIcon.Information);
            }
        }

        private void take_FromFactory(decimal dToTakeFromFactory)
        {
            foreach (Stock_Data std_appisd in appisd.m_ShopShelf_Source.Stock_Data_List)
            {
                if (!ID.Validate(std_appisd.Stock_ID))
                {
                    if (m_ShopBC.IsDocInvoice)
                    {
                        if (f_DocInvoice_ShopC_Item.UpdateQuantity(std_appisd.Doc_ShopC_Item_ID, dToTakeFromFactory))
                        {
                            std_appisd.dQuantity_v.v = dToTakeFromFactory;
                            return;
                        }
                    }
                    else
                    {
                        if (f_DocProformaInvoice_ShopC_Item.UpdateQuantity(std_appisd.Doc_ShopC_Item_ID, dToTakeFromFactory))
                        {
                            std_appisd.dQuantity_v.v = dToTakeFromFactory;
                            return;
                        }

                    }
                }
            }

            // no factory element yet

            decimal xRetailPriceWithDiscount = 0;
            decimal xTaxPrice = 0;
            decimal xNetPrice = 0;
            StaticLib.Func.CalculatePrice(dRetailPricePerUnit,
                                          dToTakeFromFactory,
                                          discount,
                                          extradiscount,
                                          taxrate,
                                          ref xRetailPriceWithDiscount, ref xTaxPrice, ref xNetPrice, GlobalData.BaseCurrency.DecimalPlaces);
            if (m_ShopBC.IsDocInvoice)
            {
             
                ID doc_ShopC_Item_ID = null;
                if (f_DocInvoice_ShopC_Item.Insert(dToTakeFromFactory,
                                                   new decimal_v(extradiscount), 
                                                   xRetailPriceWithDiscount, 
                                                   xTaxPrice,
                                                   m_ShopBC.m_CurrentDoc.Doc_ID,
                                                   appisd.Atom_Price_Item_ID,
                                                   null,
                                                   null,
                                                   ref doc_ShopC_Item_ID
                                                   ))
                {
                    Stock_Data stdx = new Stock_Data();
                    stdx.Doc_ShopC_Item_ID = doc_ShopC_Item_ID;
                    stdx.dQuantity_v = new decimal_v(dToTakeFromFactory);
                    appisd.m_ShopShelf_Source.Stock_Data_List.Add(stdx);
                    return;
                }
            }
            else
            {
                ID doc_ShopC_Item_ID = null;
                if (f_DocProformaInvoice_ShopC_Item.Insert(dToTakeFromFactory,
                                                   new decimal_v(extradiscount),
                                                   xRetailPriceWithDiscount,
                                                   xTaxPrice,
                                                   m_ShopBC.m_CurrentDoc.Doc_ID,
                                                   appisd.Atom_Price_Item_ID,
                                                   null,
                                                   null,
                                                   ref doc_ShopC_Item_ID
                                                   ))
                {
                    Stock_Data stdx = new Stock_Data();
                    stdx.Doc_ShopC_Item_ID = doc_ShopC_Item_ID;
                    stdx.dQuantity_v = new decimal_v(dToTakeFromFactory);
                    appisd.m_ShopShelf_Source.Stock_Data_List.Add(stdx);
                    return;
                }
            }
        }

        private bool putBackToTheSameStockElement(Stock_Data std_idata, Stock_Data std_appisd, ref decimal dput_back_to_stock)
        {
            if (ID.Validate(std_appisd.Stock_ID))
            {
                if (std_appisd.dQuantity_v!=null)
                {
                    if (std_appisd.dQuantity_v.v>0)
                    {
                        if (std_appisd.dQuantity_v.v >= dput_back_to_stock)
                        {
                            decimal dallready_in_stock = std_idata.dQuantity_v.v;
                            decimal dnewinstock = dallready_in_stock + dput_back_to_stock;
                            if (f_Stock.UpdateQuantity(std_appisd.Stock_ID, dnewinstock))
                            {
                                std_idata.dQuantity_v.v = dnewinstock;
                                decimal dnewinbasketfromstock = std_appisd.dQuantity_v.v - dput_back_to_stock;
                                if (dnewinbasketfromstock > 0)
                                {
                                    if (m_ShopBC.IsDocInvoice)
                                    {
                                        if (f_DocInvoice_ShopC_Item.UpdateQuantity(std_appisd.Doc_ShopC_Item_ID, dnewinbasketfromstock))
                                        {
                                            std_appisd.dQuantity_v.v = dnewinbasketfromstock;
                                            dput_back_to_stock = 0;
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        if (f_DocProformaInvoice_ShopC_Item.UpdateQuantity(std_appisd.Doc_ShopC_Item_ID, dnewinbasketfromstock))
                                        {
                                            std_appisd.dQuantity_v.v = dnewinbasketfromstock;
                                            dput_back_to_stock = 0;
                                            return true;
                                        }
                                    }

                                }
                                else
                                {
                                    if (m_ShopBC.IsDocInvoice)
                                    {
                                        if (f_DocInvoice_ShopC_Item.Delete(std_appisd.Doc_ShopC_Item_ID))
                                        {
                                            m_ShopBC.m_CurrentDoc.m_Basket.Remove(std_appisd.Doc_ShopC_Item_ID);
                                            dput_back_to_stock = 0;
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        if (f_DocProformaInvoice_ShopC_Item.Delete(std_appisd.Doc_ShopC_Item_ID))
                                        {
                                            m_ShopBC.m_CurrentDoc.m_Basket.Remove(std_appisd.Doc_ShopC_Item_ID);
                                            dput_back_to_stock = 0;
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            decimal dallready_in_stock = std_idata.dQuantity_v.v;
                            decimal dinbasketfromstock = std_appisd.dQuantity_v.v;
                            decimal dnewinstock = dallready_in_stock + dinbasketfromstock;
                            if (f_Stock.UpdateQuantity(std_appisd.Stock_ID, dnewinstock))
                            {
                                std_idata.dQuantity_v.v = dnewinstock;
                                if (m_ShopBC.IsDocInvoice)
                                {
                                    if (f_DocInvoice_ShopC_Item.Delete(std_appisd.Doc_ShopC_Item_ID))
                                    {
                                        m_ShopBC.m_CurrentDoc.m_Basket.Remove(std_appisd.Doc_ShopC_Item_ID);
                                        dput_back_to_stock = dput_back_to_stock - dinbasketfromstock;
                                        return true;
                                    }
                                }
                                else
                                {
                                    if (f_DocProformaInvoice_ShopC_Item.Delete(std_appisd.Doc_ShopC_Item_ID))
                                    {
                                        m_ShopBC.m_CurrentDoc.m_Basket.Remove(std_appisd.Doc_ShopC_Item_ID);
                                        dput_back_to_stock = dput_back_to_stock - dinbasketfromstock;
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        private bool putBackToTheSameStockElement(Stock_Data std_appisd, ref decimal dput_back_to_stock)
        {
            if (ID.Validate(std_appisd.Stock_ID))
            {
                if (std_appisd.dQuantity_v != null)
                {
                    if (std_appisd.dQuantity_v.v > 0)
                    {
                        if (std_appisd.dQuantity_v.v >= dput_back_to_stock)
                        {
                            decimal dallready_in_stock = 0;
                            decimal dnewinstock = dallready_in_stock + dput_back_to_stock;
                            if (f_Stock.UpdateQuantity(std_appisd.Stock_ID, dnewinstock))
                            {
                                idata.SetNewStock(std_appisd.Stock_ID, dnewinstock);
                                decimal dnewinbasketfromstock = std_appisd.dQuantity_v.v - dput_back_to_stock;
                                if (dnewinbasketfromstock > 0)
                                {
                                    if (m_ShopBC.IsDocInvoice)
                                    {
                                        if (f_DocInvoice_ShopC_Item.UpdateQuantity(std_appisd.Doc_ShopC_Item_ID, dnewinbasketfromstock))
                                        {
                                            std_appisd.dQuantity_v.v = dnewinbasketfromstock;
                                            dput_back_to_stock = 0;
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        if (f_DocProformaInvoice_ShopC_Item.UpdateQuantity(std_appisd.Doc_ShopC_Item_ID, dnewinbasketfromstock))
                                        {
                                            std_appisd.dQuantity_v.v = dnewinbasketfromstock;
                                            dput_back_to_stock = 0;
                                            return true;
                                        }
                                    }

                                }
                                else
                                {
                                    if (m_ShopBC.IsDocInvoice)
                                    {
                                        if (f_DocInvoice_ShopC_Item.Delete(std_appisd.Doc_ShopC_Item_ID))
                                        {
                                            m_ShopBC.m_CurrentDoc.m_Basket.Remove(std_appisd.Doc_ShopC_Item_ID);
                                            dput_back_to_stock = 0;
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        if (f_DocProformaInvoice_ShopC_Item.Delete(std_appisd.Doc_ShopC_Item_ID))
                                        {
                                            m_ShopBC.m_CurrentDoc.m_Basket.Remove(std_appisd.Doc_ShopC_Item_ID);
                                            dput_back_to_stock = 0;
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            decimal dallready_in_stock = 0;
                            decimal dinbasketfromstock = std_appisd.dQuantity_v.v;
                            decimal dnewinstock = dallready_in_stock + dinbasketfromstock;
                            if (f_Stock.UpdateQuantity(std_appisd.Stock_ID, dnewinstock))
                            {
                                idata.SetNewStock(std_appisd.Stock_ID, dnewinstock);
                                if (m_ShopBC.IsDocInvoice)
                                {
                                    if (f_DocInvoice_ShopC_Item.Delete(std_appisd.Doc_ShopC_Item_ID))
                                    {
                                        m_ShopBC.m_CurrentDoc.m_Basket.Remove(std_appisd.Doc_ShopC_Item_ID);
                                        dput_back_to_stock = dput_back_to_stock - dinbasketfromstock;
                                        return true;
                                    }
                                }
                                else
                                {
                                    if (f_DocProformaInvoice_ShopC_Item.Delete(std_appisd.Doc_ShopC_Item_ID))
                                    {
                                        m_ShopBC.m_CurrentDoc.m_Basket.Remove(std_appisd.Doc_ShopC_Item_ID);
                                        dput_back_to_stock = dput_back_to_stock - dinbasketfromstock;
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        private bool takefromTheSameStockElement(Stock_Data std_idata, Stock_Data std_appisd, ref decimal additional_quantity_to_take_from_stock)
        {
            if (std_idata.dQuantity_v.v >= additional_quantity_to_take_from_stock)
            {
                decimal dnewquantityinstock = std_idata.dQuantity_v.v - additional_quantity_to_take_from_stock;
                if (f_Stock.UpdateQuantity(std_idata.Stock_ID, dnewquantityinstock))
                {
                    std_idata.dQuantity_v.v = dnewquantityinstock;
                    if (std_idata.dQuantity_Taken_v == null)
                    {
                        std_idata.dQuantity_Taken_v = new DBTypes.decimal_v(additional_quantity_to_take_from_stock);
                    }
                    else
                    {
                        std_idata.dQuantity_Taken_v.v = additional_quantity_to_take_from_stock;
                    }

                    decimal dnewquantityinbasketstock = std_appisd.dQuantity_v.v + additional_quantity_to_take_from_stock;
                    if (f_DocInvoice_ShopC_Item.UpdateQuantity(std_appisd.Doc_ShopC_Item_ID, dnewquantityinbasketstock))
                    {
                        std_appisd.dQuantity_v.v = dnewquantityinbasketstock;
                        additional_quantity_to_take_from_stock = 0;
                        // taken finished
                        return true;
                    }
                }
            }
            else
            {
                // take all quantity from this stock element
                if (f_Stock.UpdateQuantity(std_idata.Stock_ID, 0))
                {

                    decimal dnewquantityinbasketstock = std_appisd.dQuantity_v.v + std_idata.dQuantity_v.v;

                    if (f_DocInvoice_ShopC_Item.UpdateQuantity(std_appisd.Doc_ShopC_Item_ID, dnewquantityinbasketstock))
                    {
                        additional_quantity_to_take_from_stock = additional_quantity_to_take_from_stock - std_idata.dQuantity_v.v;
                        std_appisd.dQuantity_v.v = dnewquantityinbasketstock;
                        if (std_idata.dQuantity_Taken_v == null)
                        {
                            std_idata.dQuantity_Taken_v = new DBTypes.decimal_v(std_idata.dQuantity_v.v);
                        }
                        else
                        {
                            std_idata.dQuantity_Taken_v.v = std_idata.dQuantity_v.v;
                        }
                        std_idata.dQuantity_v.v = 0;
                    }
                }
            }
            return false;
        }

        private bool takefromAnotherStockElement(Stock_Data std_idata, Stock_Data std_appisd, ref decimal additional_quantity_to_take_from_stock)
        {
            if (std_idata.dQuantity_v.v >= additional_quantity_to_take_from_stock)
            {
                decimal dnewquantityinstock = std_idata.dQuantity_v.v - additional_quantity_to_take_from_stock;
                if (f_Stock.UpdateQuantity(std_idata.Stock_ID, dnewquantityinstock))
                {
                    std_idata.dQuantity_v.v = dnewquantityinstock;
                    if (std_idata.dQuantity_Taken_v == null)
                    {
                        std_idata.dQuantity_Taken_v = new DBTypes.decimal_v(additional_quantity_to_take_from_stock);
                    }
                    else
                    {
                        std_idata.dQuantity_Taken_v.v = additional_quantity_to_take_from_stock;
                    }

                    decimal dnewquantityinbasketstock = std_appisd.dQuantity_v.v + additional_quantity_to_take_from_stock;

                    ID atom_Item_Price_ID = null;
                    ID doc_ShopC_Item_ID = null;
                    if (m_ShopBC.Add_Doc_ShopC_Item(idata, dnewquantityinbasketstock, std_idata.Stock_ID,ref atom_Item_Price_ID,ref doc_ShopC_Item_ID))
                    {
                        Stock_Data stdx = new Stock_Data();
                        stdx.Doc_ShopC_Item_ID = doc_ShopC_Item_ID;
                        stdx.dQuantity_v = new decimal_v(dnewquantityinbasketstock);
                        appisd.m_ShopShelf_Source.Stock_Data_List.Add(stdx);
                        additional_quantity_to_take_from_stock = 0;
                        // taken finished
                        return true;
                    }
                }
            }
            else
            {
                // take all quantity from this stock element
                if (f_Stock.UpdateQuantity(std_idata.Stock_ID, 0))
                {

                    decimal dnewquantityinbasketstock = std_appisd.dQuantity_v.v + std_idata.dQuantity_v.v;
                    ID atom_Item_Price_ID = null;
                    ID doc_ShopC_Item_ID = null;
                    if (m_ShopBC.Add_Doc_ShopC_Item(idata, dnewquantityinbasketstock, std_idata.Stock_ID, ref atom_Item_Price_ID, ref doc_ShopC_Item_ID))
                    {
                        Stock_Data stdx = new Stock_Data();
                        stdx.Doc_ShopC_Item_ID = doc_ShopC_Item_ID;
                        stdx.dQuantity_v = new decimal_v(dnewquantityinbasketstock);
                        appisd.m_ShopShelf_Source.Stock_Data_List.Add(stdx);
                        additional_quantity_to_take_from_stock = additional_quantity_to_take_from_stock - std_idata.dQuantity_v.v;
                    }
                }
            }
            return false;
        }

        private void takeFromStock(decimal dToTakeFromStock)
        {
            if (dToTakeFromStock > appisd.dQuantity_FromStock)
            {
                // Take additional quantity from stock
                decimal additional_quantity_to_take_from_stock = dToTakeFromStock - appisd.dQuantity_FromStock;

                foreach (Stock_Data std_appisd in appisd.m_ShopShelf_Source.Stock_Data_List)
                {
                    if (ID.Validate(std_appisd.Stock_ID))
                    {
                        Stock_Data std_idata = find_Item_Data_Stock_Data_not_zero_quantity(std_appisd.Stock_ID);
                        if (std_idata != null)
                        {
                            if (takefromTheSameStockElement(std_idata, std_appisd, ref additional_quantity_to_take_from_stock))
                            {
                                break;
                            }
                        }
                        else
                        {
                            std_idata = find_Item_Data_Stock_Data_not_zero_quantity();
                            if (std_idata!=null)
                            {
                                if (takefromAnotherStockElement(std_idata, std_appisd, ref additional_quantity_to_take_from_stock))
                                {
                                    if (additional_quantity_to_take_from_stock == 0)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (dToTakeFromStock < appisd.dQuantity_FromStock)
            {
                // Put back to stock
                decimal dput_back_to_stock = appisd.dQuantity_FromStock - dToTakeFromStock;
                foreach (Stock_Data std_appisd in appisd.m_ShopShelf_Source.Stock_Data_List)
                {
                    if (ID.Validate(std_appisd.Stock_ID))
                    {
                        Stock_Data std_idata = find_Item_Data_Stock_Data_not_zero_quantity(std_appisd.Stock_ID);
                        if (std_idata != null)
                        {
                            if (putBackToTheSameStockElement(std_idata, std_appisd, ref dput_back_to_stock))
                            {
                                if (dput_back_to_stock == 0)
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (putBackToTheSameStockElement( std_appisd, ref dput_back_to_stock))
                            {
                                if (dput_back_to_stock == 0)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                //nothing has changed!
            }
        }

     

        private Stock_Data find_Item_Data_Stock_Data_not_zero_quantity()
        {
            foreach (Stock_Data std in idata.Stock_Data_List)
            {
                if (ID.Validate(std.Stock_ID))
                {
                    if (std.dQuantity_v != null)
                    {
                        if (std.dQuantity_v.v > 0)
                        {
                            return std;
                        }
                    }
                }
            }
            return null;
        }

        private Stock_Data find_Item_Data_Stock_Data_not_zero_quantity(ID stock_ID)
        {
              foreach (Stock_Data std  in idata.Stock_Data_List )
              {
                if (ID.Validate(std.Stock_ID))
                {
                    if (std.dQuantity_v != null)
                    {
                        if (std.dQuantity_v.v > 0)
                        {
                            if (std.Stock_ID.Equals(stock_ID))
                            {
                                return std;
                            }
                        }
                    }
                }
              }
            return null;
        }

        private Stock_Data find_Item_Data_Stock_Data(ID stock_ID)
        {
            foreach (Stock_Data std in idata.Stock_Data_List)
            {
                if (ID.Validate(std.Stock_ID))
                {
                    if (std.Stock_ID.Equals(stock_ID))
                    {
                        return std;
                    }
                }
            }
            return null;
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
                set_NmUpDn(usrc_nmUpDn_FromStock, unitsymbol, taxation_name, lng.s_FromStock.s,dv_remains_in_stock, idata);
                set_NmUpDn(usrc_nmUpDn_FromFactory, unitsymbol, taxation_name, lng.s_AvoidStock.s, dv_remains_in_stock, idata);
            }
        }

        private void set_NmUpDn(DynEditControls.usrc_NumericUpDown3 unmupdn3,
                                string sunit_symbol,
                                string stax_name,
                                string squantity_taken_from,
                                decimal xv_remains_in_stock,
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

           

            int iunit_decimal_places = 2;
            
            if (xdata.Unit_DecimalPlaces!=null)
            {
                iunit_decimal_places = xdata.Unit_DecimalPlaces.v;
            }

            if (unmupdn3.Name.ToLower().Contains("stock"))
            {
                unmupdn3.label3.BackColor = Color.PeachPuff;
                unmupdn3.Label3 = lng.s_StockShort.s+":" + LanguageControl.DynSettings.SetLanguageDecimalString(xv_remains_in_stock, iunit_decimal_places, sunit_symbol);
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

        internal void Init(ShopABC xShopBC,usrc_Item1366x768_selected x_usrc_Item1366x768_selected, usrc_Atom_Item1366x768 x_usrc_Atom_Item1366x768, Atom_DocInvoice_ShopC_Item_Price_Stock_Data xappisd, Item_Data xidata, usrc_Item1366x768 xusrc_Item1366x768)
        {
            m_ShopBC = xShopBC;
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
            last_usrc_nmUpDn_FromStock_Value = usrc_nmUpDn_FromStock.Value;
            dv_remains_in_stock = idata.dQuantity_OfStockItems;
            set_NmUpDn(usrc_nmUpDn_FromStock, unitsymbol, taxation_name, lng.s_FromStock.s, dv_remains_in_stock,idata);

            usrc_nmUpDn_FromFactory.Value = appisd.dQuantity_FromFactory;
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
