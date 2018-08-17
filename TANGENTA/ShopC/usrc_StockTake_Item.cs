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
using DBConnectionControl40;
using DBTypes;

namespace ShopC
{
    public partial class usrc_StockTake_Item : UserControl
    {
        private DataTable dtPurchasePrices = null;
        private ToolTip toolTip_cmb_PurchasePrice = null;

        private bool m_PPriceDefined = false;
        public bool PPriceDefined
        {
            get
            {
                return m_PPriceDefined;
            }
            set
            {
                m_PPriceDefined = value;
            }
        }

        private decimal m_PurchasePricePerUnitWithoutTax = 0;
        private decimal PurchasePricePerUnitWithoutTax
        {
            get
            {
                return m_PurchasePricePerUnitWithoutTax;
            }
            set
            {
                m_PurchasePricePerUnitWithoutTax = value;
            }
        }

        private decimal m_PurchasePricePerUnitWithTax = 0;
        private decimal PurchasePricePerUnitWithTax
        {
            get
            {
                return m_PurchasePricePerUnitWithTax;
            }
            set
            {
                m_PurchasePricePerUnitWithTax = value;
            }
        }

        private decimal m_Discount = 0;
        private decimal Discount
        {
            get
            {
                return m_Discount;
            }
            set
            {
                m_Discount = value;
            }
        }

        private decimal m_VAT = 0;
        private decimal VAT
        {
            get
            {
                return m_VAT;
            }
            set
            {
                m_VAT = value;
            }
        }

        private decimal m_PriceWithDiscountWithoutTax = 0;
        private decimal PriceWithDiscountWithoutTax
        {
            get
            {
                return m_PriceWithDiscountWithoutTax;
            }
            set
            {
                m_PriceWithDiscountWithoutTax = value;
            }
        }


        private decimal m_PriceWithDiscountWithTax = 0;
        private decimal PriceWithDiscountWithTax
        {
            get
            {
                return m_PriceWithDiscountWithTax;
            }
            set
            {
                m_PriceWithDiscountWithTax = value;
            }
        }

        private decimal m_TotalWithoutTax = 0;
        private decimal TotalWithoutTax
        {
            get
            {
                return m_TotalWithoutTax;
            }
            set
            {
                m_TotalWithoutTax = value;
            }
        }

        private decimal m_TotalWithTax = 0;
        private decimal TotalWitTax
        {
            get
            {
                return m_TotalWithTax;
            }
            set
            {
                m_TotalWithTax = value;
            }
        }


        public usrc_StockTake_Item()
        {
            InitializeComponent();
            nmUpDn_Quantity.Maximum = decimal.MaxValue;
            lng.s_Quantity.Text(lbl_Quantity);
            lng.s_PurchasePricePerUnit.Text(lbl_PurchasePrice);
            lng.s_Taxation.Text(lbl_Taxation);
            lng.s_lbl_PriceWithoutVAT.Text(lbl_PriceWithoutVAT);
            lng.s_lbl_PriceWithVAT.Text(lbl_PriceWithVAT);
            lng.s_lbl_Discount.Text(lbl_Discount);
            lng.s_lbl_Total.Text(lbl_Total);
            lng.s_chk_VAT_is_deducted.Text(chk_VATCanNotBeDeducted);
            if (toolTip_cmb_PurchasePrice == null)
            {
                toolTip_cmb_PurchasePrice = new ToolTip();
            }

            // Set up the delays for the ToolTip.
            toolTip_cmb_PurchasePrice.AutoPopDelay = 5000;
            toolTip_cmb_PurchasePrice.InitialDelay = 1000;
            toolTip_cmb_PurchasePrice.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip_cmb_PurchasePrice.ShowAlways = true;

            cmb_Taxation.DataSource = TangentaDB.f_Taxation.GetTable(false);
            cmb_Taxation.DisplayMember = "Name";
            cmb_Taxation.ValueMember = "ID";
            AddHandlers();
        }

        internal void EnableControls(bool v)
        {
            nmUpDn_Quantity.Enabled = v;
            cmb_PurchasePrice.Enabled = v;
            cmb_Taxation.Enabled = v;
        }

        internal void SetInitialValues()
        {
            cmb_PurchasePrice.Text = "";
            nmUpDn_Quantity.Minimum = 0;
            nmUpDn_Quantity.Value = 0;
        }

        internal void SetQuantity_NumericUpdDown(object xiItem_UnitDecimalPlaces)
        {
            fs.SetNumericUpDown(ref nmUpDn_Quantity, xiItem_UnitDecimalPlaces);
        }

        internal void Set_cmb_PurchasePrice(ID item_ID, ID currency_ID)
        {
            RemoveHandlers();

            toolTip_cmb_PurchasePrice.SetToolTip(cmb_PurchasePrice, lng.s_PurchasePricesNotDefinedYeet.s);

            cmb_PurchasePrice.DataSource = null;
            cmb_PurchasePrice.Items.Clear();
            cmb_PurchasePrice.Text = "0";
            if (ID.Validate(item_ID))
            {
                if (ID.Validate(currency_ID))
                {
                    if (f_PurchasePrice_Item.GetLastItemPrices(item_ID, currency_ID, ref dtPurchasePrices, 5))
                    {
                        if (dtPurchasePrices.Rows.Count > 0)
                        {
                            cmb_PurchasePrice.DataSource = dtPurchasePrices;
                            cmb_PurchasePrice.DisplayMember = "PurchasePricePerUnit";
                            cmb_PurchasePrice.ValueMember = "PurchasePricePerUnit";
                            cmb_PurchasePrice.SelectedIndex = 0;
                            string sPurchasePricesInThePast = GetPastPurchasePrices(dtPurchasePrices);
                            toolTip_cmb_PurchasePrice.SetToolTip(cmb_PurchasePrice, sPurchasePricesInThePast);
                        }
                    }
                }
            }
            AddHandlers();
        }

        internal bool Check_dQuantity(bool bTopmost)
        {
            decimal dquantity = nmUpDn_Quantity.Value;
            if (dquantity == 0)
            {
                
                if (XMessage.Box.Show(bTopmost, this, lng.s_dQuantityEqualsZero_InsertItemInStock, "?", MessageBoxButtons.YesNo, null, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        internal bool Check_PurchasePricePerUnit(bool bTopmost)
        {
            decimal d = 0;
           
            try
            {
                d = Convert.ToDecimal(cmb_PurchasePrice.Text);
            }
            catch
            {
                XMessage.Box.Show(bTopmost, this, lng.s_PurchasePricePerUnitIsNotDefined, "?", MessageBoxButtons.OK, null, MessageBoxDefaultButton.Button1);
                return false;
            }
            if (d == 0)
            {
                if (XMessage.Box.Show(bTopmost, this, lng.s_PurchasePriceIsZeroAreYouSure, "?", MessageBoxButtons.YesNo, null, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }


        private string GetPastPurchasePrices(DataTable xdtPurchasePrices)
        {
            StringBuilder sb = new StringBuilder(lng.s_PurchasePricesInThePast.s + "\r\n");
            foreach (DataRow dr in xdtPurchasePrices.Rows)
            {
                decimal_v dPurchasePricePerUnit_v = tf.set_decimal(dr["PurchasePricePerUnit"]);
                DateTime_v dtPurchasePriceDatet_v = tf.set_DateTime(dr["PurchasePriceDate"]);
                string_v SupplierName_v = tf.set_string(dr["SupplierName"]);
                string_v StockTakeName_v = tf.set_string(dr["StockTakeName"]);
                DateTime_v StockTake_Date_v = tf.set_DateTime(dr["StockTake_Date"]);
                if (dPurchasePricePerUnit_v != null)
                {
                    sb.Append(lng.s_PurchasePricePerUnit.s);
                    sb.Append("=");
                    sb.Append(dPurchasePricePerUnit_v.v.ToString());
                    sb.Append(";");
                }
                if (dtPurchasePriceDatet_v != null)
                {
                    sb.Append(lng.s_PurchasePriceDate.s);
                    sb.Append("=");
                    sb.Append(LanguageControl.DynSettings.SetLanguageDateTimeString(dtPurchasePriceDatet_v.v));
                    sb.Append(";");
                }
                if (SupplierName_v != null)
                {
                    sb.Append(lng.s_Supplier.s);
                    sb.Append("=");
                    sb.Append(SupplierName_v.v);
                    sb.Append(";");
                }

                if (StockTakeName_v != null)
                {
                    sb.Append(lng.s_StockTakeName.s);
                    sb.Append("=");
                    sb.Append(StockTakeName_v.v);
                    sb.Append(";");
                }
                if (StockTake_Date_v != null)
                {
                    sb.Append(lng.s_StockTakeDate.s);
                    sb.Append("=");
                    sb.Append(LanguageControl.DynSettings.SetLanguageDateTimeString(StockTake_Date_v.v));
                    sb.Append(";");
                }
                sb.Append("\r\n");
            }
            return sb.ToString();
        }

        private void cmb_PurchasePrice_TextChanged(object sender, EventArgs e)
        {
            RemoveHandlers();
            object oDecimalValue = cmb_PurchasePrice.SelectedValue;
            if (oDecimalValue is decimal)
            {
                PurchasePricePerUnitWithoutTax = (decimal)oDecimalValue;

                PPriceDefined = true;
            }

            if (!m_PPriceDefined)
            {
                string sValue = cmb_PurchasePrice.Text;
                if (sValue.Length > 0)
                {
                    try
                    {
                        PurchasePricePerUnitWithoutTax = Convert.ToDecimal(sValue);
                        m_PPriceDefined = true;
                    }
                    catch
                    {
                        XMessage.Box.ShowTopMost(this, lng.s_InvalidPurchasePrice, lng.s_Warning.s, MessageBoxButtons.OK, null, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            AddHandlers();
        }

        private void AddHandlers()
        {
            this.cmb_PurchasePrice.TextChanged += new System.EventHandler(this.cmb_PurchasePrice_TextChanged);
            this.cmb_Taxation.SelectedValueChanged += new System.EventHandler(this.cmb_Taxation_SelectedValueChanged);

        }

        private void RemoveHandlers()
        {
            this.cmb_PurchasePrice.TextChanged -= new System.EventHandler(this.cmb_PurchasePrice_TextChanged);
            this.cmb_Taxation.SelectedValueChanged -= new System.EventHandler(this.cmb_Taxation_SelectedValueChanged);
        }

        private void cmb_Taxation_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
}
