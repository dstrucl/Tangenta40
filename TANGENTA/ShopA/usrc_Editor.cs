using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InvoiceDB;
using BlagajnaTableClass;

namespace ShopA
{
    public partial class usrc_Editor : UserControl
    {
        public delegate void delegate_AddRow(Atom_ItemShopA_Price m_Atom_ItemShopA_Price);
        public event delegate_AddRow AddRow = null;


        ShopABC m_ShopABC = null;
        Atom_ItemShopA_Price m_Atom_ItemShopA_Price = null;
        public decimal TaxValue = 0;
        public decimal EndNetPrice = 0;
        public decimal Discount = 0;
        public decimal EndPriceWithDiscountAndTax = 0;

        public usrc_Editor()
        {
            InitializeComponent();
            this.lbl_EndPriceWidthDisocunt_Value.Text = "";
            this.lbl_Tax_Value.Text = "";
            this.lbl_NetPrice_Value.Text = "";
        }

        private void usrc_Edit_Item_Name2_Load(object sender, EventArgs e)
        {

        }

        internal void Init(ShopABC xShopABC, Atom_ItemShopA_Price xAtom_ItemShopA_Price)
        {
            m_ShopABC = xShopABC;
            m_Atom_ItemShopA_Price = xAtom_ItemShopA_Price;
            this.usrc_Edit_Item_Tax1.Init(m_ShopABC.m_xTaxationList);
            this.usrc_Edit_Item_Unit1.Init(m_ShopABC.m_xUnitList);
            chk_PriceWithTax.Checked = Properties.Settings.Default.EnterPriceWithTax;
            chk_PriceWithTax.CheckedChanged += Chk_PriceWithTax_CheckedChanged;
        }

        private void Chk_PriceWithTax_CheckedChanged(object sender, EventArgs e)
        {
            calculate_tax();
            Properties.Settings.Default.EnterPriceWithTax = chk_PriceWithTax.Checked;
            Properties.Settings.Default.Save();
        }

        private void btn_AddNewLine_Click(object sender, EventArgs e)
        {
            if (Fill())
            {
                m_Atom_ItemShopA_Price.TAX.set(TaxValue);
                m_Atom_ItemShopA_Price.EndPriceWithDiscountAndTax.set(EndPriceWithDiscountAndTax);
                m_Atom_ItemShopA_Price.Discount.set(Discount);
                m_Atom_ItemShopA_Price.m_ProformaInvoice.ID.set(m_ShopABC.m_CurrentInvoice.ProformaInvoice_ID);
                if (this.usrc_Edit_Item_Unit1.UnitsEnabled)
                {
                    m_Atom_ItemShopA_Price.PricePerUnit.set(usrc_Edit_Item_Unit1.PricePerUnit);
                    m_Atom_ItemShopA_Price.dQuantity.set(usrc_Edit_Item_Unit1.Quantity);

                }
                else
                {
                    m_Atom_ItemShopA_Price.PricePerUnit.set(null);
                    m_Atom_ItemShopA_Price.dQuantity.set(null);
                }
                long Atom_ItemShopA_Price_ID = -1;
                if (ShopA_dbfunc.dbfunc.insert(m_Atom_ItemShopA_Price, ref Atom_ItemShopA_Price_ID))
                {
                    // Add Row
                    m_Atom_ItemShopA_Price.ID.set(Atom_ItemShopA_Price_ID);
                    if (AddRow!=null)
                    {
                        AddRow(m_Atom_ItemShopA_Price);
                    }
                }
            }
        }

        private bool Fill()
        {
            if (this.usrc_Edit_Item_Name1.Fill(ref m_Atom_ItemShopA_Price.m_Atom_ItemShopA))
            {
                if (this.usrc_Edit_Item_Tax1.Fill(ref m_Atom_ItemShopA_Price.m_Atom_ItemShopA.m_Taxation))
                {
                    this.usrc_Edit_Item_Description1.Fill(ref m_Atom_ItemShopA_Price.m_Atom_ItemShopA);
                    this.usrc_Edit_Item_Unit1.Fill(ref m_Atom_ItemShopA_Price.m_Atom_ItemShopA.m_Unit);
                    this.usrc_Edit_Item_Price1.Fill(ref m_Atom_ItemShopA_Price);
                    return true;
                }

            }
            return false;
        }

        private void calculate_tax()
        {
            if (chk_PriceWithTax.Checked)
            {
                EndPriceWithDiscountAndTax = decimal.Round(usrc_Edit_Item_Price1.Price - usrc_Edit_Item_Price1.Price * Discount, GlobalData.BaseCurrency.DecimalPlaces);
                TaxValue = decimal.Round((EndPriceWithDiscountAndTax / (1 + usrc_Edit_Item_Tax1.TaxRate)) * usrc_Edit_Item_Tax1.TaxRate, GlobalData.BaseCurrency.DecimalPlaces);
                EndNetPrice = EndPriceWithDiscountAndTax- TaxValue;
            }
            else
            {
                EndNetPrice = decimal.Round(usrc_Edit_Item_Price1.Price - usrc_Edit_Item_Price1.Price * Discount, GlobalData.BaseCurrency.DecimalPlaces);
                TaxValue = decimal.Round(EndNetPrice * usrc_Edit_Item_Tax1.TaxRate, GlobalData.BaseCurrency.DecimalPlaces);
                EndPriceWithDiscountAndTax = EndNetPrice + TaxValue;
            }
            this.lbl_EndPriceWidthDisocunt_Value.Text = EndPriceWithDiscountAndTax.ToString() + " " + GlobalData.BaseCurrency.Symbol;
            this.lbl_Tax_Value.Text = TaxValue.ToString() + " " + GlobalData.BaseCurrency.Symbol;
            this.lbl_NetPrice_Value.Text = EndNetPrice.ToString() + " " + GlobalData.BaseCurrency.Symbol;

        }
        private void usrc_Edit_Item_Unit1_ValueChanged()
        {
            if (usrc_Edit_Item_Unit1.PriceSum_v != null)
            {
                usrc_Edit_Item_Price1.set(usrc_Edit_Item_Unit1.PriceSum_v.v);
            }
            calculate_tax();

        }

        private void usrc_Edit_Item_EndPrice1_ValueChanged(decimal d)
        {
            usrc_Edit_Item_Unit1.set_when_endprice_changed(d);
            calculate_tax();
        }

    private void btn_Discount_Click(object sender, EventArgs e)
        {
            FormDiscount.Form_Discount fdiscount = new FormDiscount.Form_Discount(usrc_Edit_Item_Price1.Price, null, 0, usrc_Edit_Item_Name1.ItemName);
            if (fdiscount.ShowDialog(this)==DialogResult.OK)
            {
                Discount = fdiscount.ExtraDiscount;
                txt_Discount.Text = (Discount * 100).ToString()+"%";
                calculate_tax();
            }
        }

        private void usrc_Edit_Item_Tax1_ValueChanged()
        {
            calculate_tax();
        }
    }
}
