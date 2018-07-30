#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
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
using TangentaTableClass;
using CodeTables;
using DBConnectionControl40;

namespace ShopA
{
    public partial class usrc_Editor : UserControl
    {
        public delegate void delegate_AddRow(DocInvoice_ShopA_Item m_DocInvoice_ShopA_Item);
        public event delegate_AddRow AddRow = null;
        public delegate bool delegate_EditUnis();
        public event delegate_EditUnis EditUnits;
        public Form_Tool_SelectItem m_tool_SelectItem = null;


        ShopABC m_ShopABC = null;
        DocInvoice_ShopA_Item m_DocInvoice_ShopA_Item = null;
        public decimal TaxValue = 0;
        public decimal EndNetPrice = 0;
        public decimal Discount = 0;
        public decimal EndPriceWithDiscountAndTax = 0;

        //private string m_DocInvoice = "DocInvoice";
        public int SplitContainer1_spd
        {
            get
            {
                return splitContainer1.SplitterDistance;
            }
            set
            {
                string Err = null;
                if (!StaticLib.Func.SetSplitContainerValue(splitContainer1, value, ref Err))
                {
                    LogFile.Error.Show("ERROR:ShopA:usrc_Editor:SetSplitContainer 1 SplitterDistance:Err=" + Err);
                }
            }
        }

        //private string m_DocInvoice = "DocInvoice";
        public int SplitContainer2_spd
        {
            get
            {
                return splitContainer2.SplitterDistance;
            }
            set
            {
                string Err = null;
                if (!StaticLib.Func.SetSplitContainerValue(splitContainer2, value, ref Err))
                {
                    LogFile.Error.Show("ERROR:ShopA:usrc_Editor:SetSplitContainer 2 SplitterDistance:Err=" + Err);
                }
            }
        }

        public string DocInvoice
        {
            get { return m_ShopABC.DocInvoice; }
        }

        public bool IsDocInvoice
        {
            get
            { return DocInvoice.Equals("DocInvoice"); }
        }

        public bool IsDocProformaInvoice
        {
            get
            { return DocInvoice.Equals("DocProformaInvoice"); }
        }


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

        internal void Init(ShopABC xShopABC, DocInvoice_ShopA_Item xDocInvoice_ShopA_Item)
        {
            m_ShopABC = xShopABC;
            m_DocInvoice_ShopA_Item = xDocInvoice_ShopA_Item;
            this.usrc_Edit_Item_Tax1.Init(m_ShopABC.m_xTaxationList);
            this.usrc_Edit_Item_Unit1.Init(m_ShopABC.m_xUnitList);
            chk_PriceWithTax.Checked = Properties.Settings.Default.EnterPriceWithTax;
            chk_PriceWithTax.CheckedChanged += Chk_PriceWithTax_CheckedChanged;
            lng.s_btn_AddNewLine.Text(btn_AddNewLine);
            lng.s_lbl_EndNetPrice.Text(lbl_EndNetPrice);
            lng.s_lbl_EndPriceWidthDisocunt.Text(lbl_EndPriceWidthDisocunt);
            lng.s_lbl_Tax.Text(lbl_Tax);
            lng.s_chk_PriceWithTax.Text(chk_PriceWithTax);
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
                m_DocInvoice_ShopA_Item.TAX.set(TaxValue);
                m_DocInvoice_ShopA_Item.EndPriceWithDiscountAndTax.set(EndPriceWithDiscountAndTax);
                m_DocInvoice_ShopA_Item.Discount.set(Discount);
                m_DocInvoice_ShopA_Item.m_DocInvoice.ID.Set(m_ShopABC.m_CurrentInvoice.Doc_ID);
                if (this.usrc_Edit_Item_Unit1.UnitsEnabled)
                {
                    m_DocInvoice_ShopA_Item.PricePerUnit.set(usrc_Edit_Item_Unit1.PricePerUnit);
                    m_DocInvoice_ShopA_Item.dQuantity.set(usrc_Edit_Item_Unit1.Quantity);

                }
                else
                {
                    m_DocInvoice_ShopA_Item.PricePerUnit.set(null);
                    m_DocInvoice_ShopA_Item.dQuantity.set(null);
                }
                m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.ID.Set(null);
                ID DocInvoice_ShopA_Item_ID = null;
                if (ShopA_dbfunc.dbfunc.insert(DocInvoice,m_DocInvoice_ShopA_Item, ref DocInvoice_ShopA_Item_ID))
                {
                    // Add Row
                    m_DocInvoice_ShopA_Item.ID.Set(DocInvoice_ShopA_Item_ID);
                    if (AddRow!=null)
                    {
                        AddRow(m_DocInvoice_ShopA_Item);
                        this.Clear();
                    }
                }
            }
        }

        private void Clear()
        {
            this.usrc_Edit_Item_Name1.Clear();
            this.usrc_Edit_Item_Description1.Clear();
            this.usrc_Edit_Item_Price1.Clear();
            this.usrc_Edit_Item_Unit1.Clear();


        }

        internal void Form_Tool_SelectItem_FormClosed()
        {
            m_tool_SelectItem = null;
        }

        private bool Fill()
        {
            if (this.usrc_Edit_Item_Name1.Fill(ref m_DocInvoice_ShopA_Item.m_Atom_ItemShopA))
            {
                if (this.usrc_Edit_Item_Tax1.Fill(ref m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.m_Taxation))
                {
                    this.usrc_Edit_Item_Description1.Fill(ref m_DocInvoice_ShopA_Item.m_Atom_ItemShopA);
                    this.usrc_Edit_Item_Unit1.Fill(ref m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.m_Unit);
                    this.usrc_Edit_Item_Price1.Fill(ref m_DocInvoice_ShopA_Item);
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

        internal void SetControls(Atom_ItemShopA xAtom_ItemShopA)
        {
            this.usrc_Edit_Item_Name1.SetControls(xAtom_ItemShopA.Name.type_v);
            this.usrc_Edit_Item_Description1.SetControls(xAtom_ItemShopA.Description.type_v);
            this.usrc_Edit_Item_Unit1.SetControls(xAtom_ItemShopA.m_Unit);
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
            Form_Discount.Form_Discount fdiscount = new Form_Discount.Form_Discount(usrc_Edit_Item_Price1.Price, null, 0, usrc_Edit_Item_Name1.ItemName);
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

        private void btn_EditItem_Click(object sender, EventArgs e)
        {
            EditShopAItem();
        }

        public bool EditShopAItem()
        {
            SQLTable tbl_ShopAItem = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Atom_ItemShopA)));
            Form_ShopAItem_Edit edt_ShopAItem_dlg = new Form_ShopAItem_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                                    tbl_ShopAItem,
                                                                    "Atom_ItemShopA_$$Name asc");
            edt_ShopAItem_dlg.ShowDialog();
            return true;
        }

        private bool usrc_Edit_Item_Unit1_EditUnits()
        {
            if (EditUnits!=null)
            {
                return EditUnits();
            }
            return false;
        }

        private void btn_SelectItem_Click(object sender, EventArgs e)
        {
            if (m_tool_SelectItem == null)
            {
                m_tool_SelectItem = new Form_Tool_SelectItem(m_DocInvoice_ShopA_Item.m_Atom_ItemShopA,this);
                m_tool_SelectItem.Show(this);
            }
            else
            {
                m_tool_SelectItem.Focus();
            }
        }
    }
}
