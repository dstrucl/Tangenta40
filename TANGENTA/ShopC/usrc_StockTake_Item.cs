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
        private DataTable dtCurrency = null;

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

        private int m_Currency_DecimalPlaces = 2;


        public int Currency_DecimalPlaces 
        {
            get
            {
                return m_Currency_DecimalPlaces;
            }
            set
            {
                m_Currency_DecimalPlaces = value;
            }
        }

        private int m_Currency_Code;
        public int Currency_Code
        {
            get
            {
                return m_Currency_Code;
            }
            set
            {
                m_Currency_Code = value;
            }
        }

        private string m_Currency_Symbol = null;
        public string Currency_Symbol
        {
            get
            {
                return m_Currency_Symbol;
            }
            set
            {
                m_Currency_Symbol = value;
            }
        }


        private string m_Currency_Abbreviation = null;
        public string Currency_Abbreviation
        {
            get
            {
                return m_Currency_Abbreviation;
            }
            set
            {
                m_Currency_Abbreviation = value;
            }
        }

        private string m_Currency_Name = null;
        public string Currency_Name
        {
            get
            {
                return m_Currency_Name;
            }
            set
            {
                m_Currency_Name = value;
            }
        }

        private decimal m_Quantity = 0;
        public decimal Quantity
        {
            get
            {
                return m_Quantity;
            }
            set
            {
                m_Quantity = value;
            }
        }

        private decimal m_PurchasePricePerUnitWithoutTax = 0;
        public decimal PurchasePricePerUnitWithoutTax
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

        
        private decimal m_PurchasePricePerUnitWithoutTaxWithDiscount = 0;
        public decimal PurchasePricePerUnitWithoutTaxWithDiscount
        {
            get
            {
                return m_PurchasePricePerUnitWithoutTaxWithDiscount;
            }
            set
            {
                m_PurchasePricePerUnitWithoutTaxWithDiscount = value;
            }
        }

        private decimal m_PurchasePricePerUnitWithTaxWithDiscount = 0;
        public decimal PurchasePricePerUnitWithTaxWithDiscount
        {
            get
            {
                return m_PurchasePricePerUnitWithTaxWithDiscount;
            }
            set
            {
                m_PurchasePricePerUnitWithTaxWithDiscount = value;
            }
        }


        private decimal m_TotalWithoutTaxWithDiscount = 0;
        public decimal TotalWithoutTaxWithDiscount
        {
            get
            {
                return m_TotalWithoutTaxWithDiscount;
            }
            set
            {
                m_TotalWithoutTaxWithDiscount = value;
            }
        }



        private decimal m_TotalWithTaxWithDiscount = 0;
        public decimal TotalWithTaxWithDiscount
        {
            get
            {
                return m_TotalWithTaxWithDiscount;
            }
            set
            {
                m_TotalWithTaxWithDiscount = value;
            }
        }

        private decimal m_PurchasePricePerUnitWithTax = 0;
        public decimal PurchasePricePerUnitWithTax
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
        public decimal Discount
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

        private decimal m_TaxationRate = 0;
        public decimal TaxationRate
        {
            get
            {
                return m_TaxationRate;
            }
            set
            {
                m_TaxationRate = value;
            }
        }

        private decimal m_PriceWithDiscountWithoutTax = 0;
        public decimal PriceWithDiscountWithoutTax
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
        public decimal TotalWithoutTax
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
        public decimal TotalWithTax
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

        public ID Taxation_ID
        {
            get
            {
                if (cmb_Taxation.SelectedValue is DataRowView)
                {
                    return tf.set_ID(((DataRowView)cmb_Taxation.SelectedValue)["ID"]);
                }
                else if (cmb_Taxation.SelectedValue is long)
                {
                    return tf.set_ID(cmb_Taxation.SelectedValue);
                }
                else if (cmb_Taxation.SelectedValue is int)
                {
                    return tf.set_ID(cmb_Taxation.SelectedValue);
                }
                else if (cmb_Taxation.SelectedValue is Guid)
                {
                    return tf.set_ID(cmb_Taxation.SelectedValue);
                }

                return null;
            }
        }

        private bool m_PriceWithoutVAT = true;

        public bool PriceWithoutVAT
        {
            get
            {
                return m_PriceWithoutVAT;
            }
            set
            {
                m_PriceWithoutVAT = value;
            }


    }
        public bool VATCanNotBeDeducted
        {
            get
            {
                return chk_VATCanNotBeDeducted.Checked;
            }
        }

        public ID Selected_Currency_ID
        {

            get
            {
                object oID = cmb_Currency.SelectedValue;
                return tf.set_ID(oID);
            }
        }

        public usrc_StockTake_Item()
        {
            InitializeComponent();
            nmUpDn_Quantity.Maximum = decimal.MaxValue;
            lng.s_Quantity.Text(lbl_Quantity);
            lng.s_Currency.Text(lbl_Currency);
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


            nmUpDn_Quantity.Maximum = decimal.MaxValue;

        }

        public void Init(DataRow dr)
        {
            SetInitialValues();


            decimal dValue = ((decimal)dr["dQuantity"]);
            if (nmUpDn_Quantity.Minimum > dValue)
            {
                nmUpDn_Quantity.Minimum = dValue;
            }
            nmUpDn_Quantity.Value = dValue;

            ID xtaxation_ID = tf.set_ID(dr["Taxation_ID"]);
            Get_cmb_Taxation_SelectedIndex(xtaxation_ID);
            //cmb_Currency.SelectedIndex = Convert.ToInt32(dr["Currency_ID"]) - 1;
            cmb_PurchasePriceWithoutDiscountAndWithoutTax.Text = Convert.ToString(dr["PurchasePricePerUnit"]);

            cmb_Discount.Text = getDiscount(dr["Discount"]);

            PriceWithoutVAT = get_bool(dr["PriceWithoutVAT"]);

            chk_VATCanNotBeDeducted.Checked = get_bool(dr["VATCanNotBeDeducted"]);

        }

        private void Get_cmb_Taxation_SelectedIndex(ID xtaxationID)
        {
            if (ID.Validate((ID)xtaxationID))
            {
                int iCount = cmb_Taxation.Items.Count;
                for (int i=0;i<iCount;i++)
                {
                    DataRowView drv = (DataRowView)cmb_Taxation.Items[i];
                    ID xID = tf.set_ID(drv["ID"]);
                    if (xID.Equals(xtaxationID))
                    {
                        cmb_Taxation.SelectedIndex = i;
                        return;
                    }
                }
            }
        }

        private string getDiscount(object discount)
        {
            if (discount is decimal)
            {
                try
                {
                    decimal dpercent = ((decimal)discount) * 100;
                    string spercent = Convert.ToString(dpercent) + "%";
                    return spercent;
                }
                catch
                {
                    return "Error";
                }
            }
            else
            {
                return "0";
            }
        }

        private bool get_bool(object xb)
        {
            if (xb is bool)
            {
                try
                {
                    return (bool)xb;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        internal void EnableControls(bool v)
        {
            nmUpDn_Quantity.Enabled = v;
            cmb_PurchasePriceWithoutDiscountAndWithoutTax.Enabled = v;
            cmb_PurchasePriceWithoutDiscountAndWithTax.Enabled = v;
            cmb_Discount.Enabled = v;
            cmb_Taxation.Enabled = v;
            cmb_Currency.Enabled = v;

        }

        internal void SetInitialValues()
        {
            RemoveHandlers();
            cmb_Taxation.DataSource = TangentaDB.f_Taxation.GetTable(true);
            cmb_Taxation.DisplayMember = "Name";
            cmb_Taxation.ValueMember = "ID";

            dtCurrency = TangentaDB.f_Currency.GetTable(false);
            cmb_Currency.DataSource = dtCurrency;
            cmb_Currency.DisplayMember = "Symbol";
            cmb_Currency.ValueMember = "ID";
            if (ID.Validate(TangentaDB.myOrg.Default_Currency_ID))
            {
                cmb_Currency.SelectedIndex = 0;
            }

            f_Currency.Get(TangentaDB.myOrg.Default_Currency_ID,ref m_Currency_Abbreviation, ref m_Currency_Name, ref m_Currency_Symbol,ref m_Currency_Code, ref m_Currency_DecimalPlaces);
            cmb_Discount.Text = Convert.ToString(Discount);
            cmb_PurchasePriceWithoutDiscountAndWithoutTax.Text = "";
            nmUpDn_Quantity.Minimum = 0;
            nmUpDn_Quantity.Value = 0;
            AddHandlers();
        }

        internal void SetQuantity_NumericUpdDown(object xiItem_UnitDecimalPlaces)
        {
            fs.SetNumericUpDown(ref nmUpDn_Quantity, xiItem_UnitDecimalPlaces);
        }

        internal void Set_cmb_PurchasePrice(ID item_ID, ID currency_ID)
        {
            RemoveHandlers();

            toolTip_cmb_PurchasePrice.SetToolTip(cmb_PurchasePriceWithoutDiscountAndWithoutTax, lng.s_PurchasePricesNotDefinedYeet.s);

            cmb_PurchasePriceWithoutDiscountAndWithoutTax.DataSource = null;
            cmb_PurchasePriceWithoutDiscountAndWithoutTax.Items.Clear();
            cmb_PurchasePriceWithoutDiscountAndWithoutTax.Text = "0";
            if (ID.Validate(item_ID))
            {
                if (ID.Validate(currency_ID))
                {
                    if (f_PurchasePrice_Item.GetLastItemPrices(item_ID, currency_ID, ref dtPurchasePrices, 5))
                    {
                        if (dtPurchasePrices.Rows.Count > 0)
                        {
                            cmb_PurchasePriceWithoutDiscountAndWithoutTax.DataSource = dtPurchasePrices;
                            cmb_PurchasePriceWithoutDiscountAndWithoutTax.DisplayMember = "PurchasePricePerUnit";
                            cmb_PurchasePriceWithoutDiscountAndWithoutTax.ValueMember = "PurchasePricePerUnit";
                            cmb_PurchasePriceWithoutDiscountAndWithoutTax.SelectedIndex = 0;
                            string sPurchasePricesInThePast = GetPastPurchasePrices(dtPurchasePrices);
                            toolTip_cmb_PurchasePrice.SetToolTip(cmb_PurchasePriceWithoutDiscountAndWithoutTax, sPurchasePricesInThePast);

                            Set_On_cmb_PurchasePriceWithoutDiscountAndWithoutTax();

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
                d = Convert.ToDecimal(cmb_PurchasePriceWithoutDiscountAndWithoutTax.Text);
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

        private void Set_On_cmb_PurchasePriceWithoutDiscountAndWithoutTax()
        {
            object oDecimalValue = cmb_PurchasePriceWithoutDiscountAndWithoutTax.SelectedValue;
            if (oDecimalValue is decimal)
            {
                SetPrices_PurchasePricePerUnitWithoutTax((decimal)oDecimalValue);
            }
            else if (oDecimalValue is DataRowView)
            {
                if (((DataRowView)oDecimalValue)["PurchasePricePerUnit"] is decimal)
                {
                    decimal pprice =(decimal) ((DataRowView)oDecimalValue)["PurchasePricePerUnit"];
                    SetPrices_PurchasePricePerUnitWithoutTax((pprice));
                }
            }
            else
            {
                string sValue = cmb_PurchasePriceWithoutDiscountAndWithoutTax.Text;
                if (sValue.Length > 0)
                {
                    try
                    {
                        SetPrices_PurchasePricePerUnitWithoutTax(Convert.ToDecimal(sValue));
                    }
                    catch
                    {
                        XMessage.Box.ShowTopMost(this, lng.s_InvalidPurchasePrice, lng.s_Warning.s, MessageBoxButtons.OK, null, MessageBoxDefaultButton.Button1);
                    }
                }
            }
        }
        private void cmb_PurchasePrice_TextChanged(object sender, EventArgs e)
        {
//            RemoveHandlers();
            Set_On_cmb_PurchasePriceWithoutDiscountAndWithoutTax();
            //            AddHandlers();
        }

        private void cmb_Discount_TextChanged(object sender, EventArgs e)
        {
            //            RemoveHandlers();
            Set_On_cmb_Discount();
            //            AddHandlers();
        }

        private void Set_On_cmb_Discount()
        {
            string sValue = cmb_Discount.Text;
            if (sValue.Length > 0)
            {
                try
                {
                    string sv = null;
                    if (sValue.Contains("%"))
                    {
                        sv = sValue.Replace("%", "");
                    }
                    else
                    {
                        sv = sValue;
                    }
                    decimal discount = Convert.ToDecimal(sv) / 100;
                    SetPrices_Discount(discount);
                }
                catch
                {
                    XMessage.Box.ShowTopMost(this, lng.s_InvalidDiscount, lng.s_Warning.s, MessageBoxButtons.OK, null, MessageBoxDefaultButton.Button1);
                }
            }

            //object oDecimalValue = cmb_Discount.SelectedValue;
            //if (oDecimalValue is decimal)
            //{
            //    SetPrices_PurchasePricePerUnitWithoutTax((decimal)oDecimalValue);
            //}
            //else
            //{
            //}
        }

        private void SetPrices_Discount(decimal xDiscount)
        {
            Discount = xDiscount;
            CalculateAll_from_PurchasePricePerUnitWithoutTax();
            SetControls();
        }

        public void CalculateAll_from_PurchasePricePerUnitWithoutTax()
        {
            PurchasePricePerUnitWithTax = PurchasePricePerUnitWithoutTax * (1 + TaxationRate);

            PurchasePricePerUnitWithoutTaxWithDiscount = decimal.Round(PurchasePricePerUnitWithoutTax * (1 - Discount),4);

            PurchasePricePerUnitWithTaxWithDiscount = PurchasePricePerUnitWithoutTaxWithDiscount * (1 + TaxationRate);

            TotalWithoutTaxWithDiscount = decimal.Round(PurchasePricePerUnitWithoutTax * (1 - Discount) * Quantity,4);

            TotalWithTaxWithDiscount = decimal.Round(TotalWithoutTaxWithDiscount * (1 + TaxationRate),Currency_DecimalPlaces);

        }

        public void SetControls()
        {
            RemoveHandlers();
            cmb_PurchasePriceWithoutDiscountAndWithoutTax.Text = Convert.ToString(PurchasePricePerUnitWithoutTax);
            cmb_PurchasePriceWithoutDiscountAndWithTax.Text = Convert.ToString(PurchasePricePerUnitWithTax);
            txt_PriceWithDiscountWithoutTax.Text = Convert.ToString(PurchasePricePerUnitWithoutTaxWithDiscount);
            txt_PriceWithDiscountWithTax.Text = Convert.ToString(PurchasePricePerUnitWithTaxWithDiscount);
            txt_TotalWithoutTax.Text = Convert.ToString(TotalWithoutTaxWithDiscount);
            txt_TotalWithTax.Text = Convert.ToString(TotalWithTaxWithDiscount);
            AddHandlers();
        }

        private void SetPrices_PurchasePricePerUnitWithoutTax(decimal xPurchasePricePerUnitWithoutTax)
        {
            PurchasePricePerUnitWithoutTax = xPurchasePricePerUnitWithoutTax;

            string_v Taxation_Name_v = null;
            decimal_v Taxation_Rate_v = null;
            if (f_Taxation.Get(this.Taxation_ID, ref Taxation_Name_v, ref Taxation_Rate_v))
            {
                if (Taxation_Rate_v!=null)
                {
                    TaxationRate = Taxation_Rate_v.v;

                    CalculateAll_from_PurchasePricePerUnitWithoutTax();

                    SetControls();

                }
            }



            PPriceDefined = true;
        }

        private void AddHandlers()
        {
            this.cmb_PurchasePriceWithoutDiscountAndWithoutTax.TextChanged += new System.EventHandler(this.cmb_PurchasePrice_TextChanged);
            this.cmb_Discount.TextChanged += new System.EventHandler(this.cmb_Discount_TextChanged);
            this.cmb_PurchasePriceWithoutDiscountAndWithTax.TextChanged += new System.EventHandler(this.cmb_PurchasePriceWithoutDiscountAndWithTax_TextChanged);
            this.cmb_Taxation.SelectedValueChanged += new System.EventHandler(this.cmb_Taxation_SelectedValueChanged);


        }

        private void RemoveHandlers()
        {
            this.cmb_PurchasePriceWithoutDiscountAndWithoutTax.TextChanged -= new System.EventHandler(this.cmb_PurchasePrice_TextChanged);
            this.cmb_Discount.TextChanged -= new System.EventHandler(this.cmb_Discount_TextChanged);
            this.cmb_PurchasePriceWithoutDiscountAndWithTax.TextChanged -= new System.EventHandler(this.cmb_PurchasePriceWithoutDiscountAndWithTax_TextChanged);
            this.cmb_Taxation.SelectedValueChanged -= new System.EventHandler(this.cmb_Taxation_SelectedValueChanged);
        }

        private void cmb_Taxation_SelectedValueChanged(object sender, EventArgs e)
        {
//            RemoveHandlers();
            string_v Taxation_Name_v = null;
            decimal_v Taxation_Rate_v = null;
            if (ID.Validate(this.Taxation_ID))
            {
                if (f_Taxation.Get(this.Taxation_ID, ref Taxation_Name_v, ref Taxation_Rate_v))
                {
                    if (Taxation_Rate_v != null)
                    {
                        TaxationRate = Taxation_Rate_v.v;
                        CalculateAll_from_PurchasePricePerUnitWithoutTax();
                        SetControls();

                    }
                }
            }
//            AddHandlers();
        }

        private void usrc_StockTake_Item_Load(object sender, EventArgs e)
        {
            AddHandlers();
        }

        private void cmb_PurchasePriceWithoutDiscountAndWithTax_TextChanged(object sender, EventArgs e)
        {

        }

        private void nmUpDn_Quantity_ValueChanged(object sender, EventArgs e)
        {
//            RemoveHandlers();
            Quantity = nmUpDn_Quantity.Value;
            CalculateAll_from_PurchasePricePerUnitWithoutTax();
            SetControls();
//            AddHandlers();
        }

        private void txt_TotalWithoutTax_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //enter key is down
                RemoveHandlers();
                string sval = this.txt_TotalWithoutTax.Text;
                try
                {
                    decimal dval = Convert.ToDecimal(sval);
                    //(priceperunitWithoutTax * (1 - discount)) * Quantity = TotalWithoutTaxWithDiscount
                    decimal dpriceperunitWithoutTax =  dval / ((1 - Discount) * Quantity);
                    PurchasePricePerUnitWithoutTax = dpriceperunitWithoutTax;
                    CalculateAll_from_PurchasePricePerUnitWithoutTax();
                    SetControls();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, lng.s_CannotConvertToDecimal.s + ":" + sval);
                }
                AddHandlers();

            }
        }

        private void txt_TotalWithTax_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //enter key is down
  //              RemoveHandlers();
                string sval = this.txt_TotalWithTax.Text;
                try
                {
                    decimal dval = Convert.ToDecimal(sval);
                    decimal dTotalWithoutTaxWithDiscount = dval / (1 + TaxationRate);
                    //(priceperunitWithoutTax * (1 - discount)) * Quantity = TotalWithoutTaxWithDiscount
                    decimal dpriceperunitWithoutTax = dTotalWithoutTaxWithDiscount / ((1 - Discount) * Quantity);
                    PurchasePricePerUnitWithoutTax = dpriceperunitWithoutTax;
                    CalculateAll_from_PurchasePricePerUnitWithoutTax();
                    SetControls();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, lng.s_CannotConvertToDecimal.s + ":" + sval);
                }
    //            AddHandlers();
            }
        }

        private void cmb_PurchasePriceWithoutDiscountAndWithoutTax_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //enter key is down
//                RemoveHandlers();
                string sval = this.cmb_PurchasePriceWithoutDiscountAndWithoutTax.Text;
                try
                {
                    decimal dval = Convert.ToDecimal(sval);
                    PurchasePricePerUnitWithoutTax = dval;
                    CalculateAll_from_PurchasePricePerUnitWithoutTax();
                    SetControls();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, lng.s_CannotConvertToDecimal.s + ":" + sval);
                }
//                AddHandlers();
            }
        }

        private void cmb_PurchasePriceWithoutDiscountAndWithTax_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                //enter key is down
//                RemoveHandlers();
                string sval = this.cmb_PurchasePriceWithoutDiscountAndWithTax.Text;
                try
                {
                    decimal dval = Convert.ToDecimal(sval);
                    PurchasePricePerUnitWithoutTax = dval/(1+TaxationRate);
                    CalculateAll_from_PurchasePricePerUnitWithoutTax();
                    SetControls();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, lng.s_CannotConvertToDecimal.s + ":" + sval);
                }
                //AddHandlers();
            }
        }
    }
}
