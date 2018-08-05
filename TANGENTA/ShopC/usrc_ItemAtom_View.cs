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
using System.Windows.Forms;
using DataGridView_2xls;
using LanguageControl;
using TangentaDB;
using DBConnectionControl40;

namespace ShopC
{

    public partial class usrc_Atom_Item_View : UserControl
    {
        private TangentaDB.ShopABC m_InvoiceDB = null;
        private ID m_Atom_Item_ID = null;
        private List<object> appisd_List = new List<object>();
        private DataTable dt_DocInvoice_Atom_Item_Stock_view = new DataTable();
        private Color Color_null;
        public usrc_Atom_Item_View()
        {
            InitializeComponent();
            Color_null = Color.DarkGray;
        }

        private void usrc_Atom_Item_View_Load(object sender, EventArgs e)
        {

        }

        public bool Init(TangentaDB.ShopABC x_InvoiceDB, ID x_Atom_Item_ID)
        {

            m_InvoiceDB = x_InvoiceDB;
            m_Atom_Item_ID = x_Atom_Item_ID;
            String Err = null;
            string scond = " and "+ m_InvoiceDB.DocTyp+ "_ShopC_Item.dQuantity > 0";
            if (m_InvoiceDB.Read_Doc_Atom_Item_Stock_Table(m_InvoiceDB.m_CurrentDoc.Doc_ID, m_Atom_Item_ID, ref dt_DocInvoice_Atom_Item_Stock_view, scond,ref Err))
            {
                if (dt_DocInvoice_Atom_Item_Stock_view.Rows.Count > 0)
                {
                    dgvx_DocInvoice_Atom_Item_Stock.DataSource = dt_DocInvoice_Atom_Item_Stock_view;
                    DBSync.DBSync.DB_for_Tangenta.t_DocInvoice_ShopC_Item.SetView_DataGridViewImageColumns_Headers((DataGridView)dgvx_DocInvoice_Atom_Item_Stock);
                    foreach (DataGridViewColumn c in dgvx_DocInvoice_Atom_Item_Stock.Columns)
                    {
                        c.Visible = false;
                    }
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Stock_ID"].Visible = true;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Stock_ID"].DisplayIndex = 0;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Stock_ID"].HeaderText = lng.s_Stock_ID.s;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["dQuantity"].Visible = true;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["dQuantity"].DisplayIndex = 1;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["dQuantity"].HeaderText = lng.s_Quantity.s;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["ExpiryDate"].Visible = true;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["ExpiryDate"].DisplayIndex = 2;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["ExpiryDate"].HeaderText = lng.s_ExpiryDate.s;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Stock_dQuantity"].Visible = true;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Stock_dQuantity"].DisplayIndex = 3;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Stock_dQuantity"].HeaderText = lng.s_Stock_dQuantity.s;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["PurchasePricePerUnit"].Visible = true;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["PurchasePricePerUnit"].DisplayIndex = 4;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["PurchasePricePerUnit"].HeaderText = lng.s_PurchasePricePerUnit.s;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["RetailPricePerUnit"].Visible = true;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["RetailPricePerUnit"].DisplayIndex = 5;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["RetailPricePerUnit"].HeaderText = lng.s_RetailPricePerUnit.s;

                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Stock_ImportTime"].Visible = true;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Stock_ImportTime"].DisplayIndex = 6;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Stock_ImportTime"].HeaderText = lng.s_Stock_ImportTime.s;

                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Stock_ExpiryDate"].Visible = true;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Stock_ExpiryDate"].DisplayIndex = 7;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Stock_ExpiryDate"].HeaderText = lng.s_Stock_ExpiryDate.s;

                    dgvx_DocInvoice_Atom_Item_Stock.Columns["StockTake_Name"].Visible = true;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["StockTake_Name"].DisplayIndex = 8;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["StockTake_Name"].HeaderText = lng.s_StockTake_Name.s;

                    dgvx_DocInvoice_Atom_Item_Stock.Columns["StockTakeDate"].Visible = true;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["StockTakeDate"].DisplayIndex = 9;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["StockTakeDate"].HeaderText = lng.s_StockTakeDate.s;

                    dgvx_DocInvoice_Atom_Item_Stock.Columns["StockTakePriceTotal"].Visible = true;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["StockTakePriceTotal"].DisplayIndex = 10;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["StockTakePriceTotal"].HeaderText = lng.s_StockTakePriceTotal.s;

                    dgvx_DocInvoice_Atom_Item_Stock.Columns["StockTake_ReferenceNote"].Visible = true;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["StockTake_ReferenceNote"].DisplayIndex = 11; 
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["StockTake_ReferenceNote"].HeaderText = lng.s_StockTake_ReferenceNote.s;

                    dgvx_DocInvoice_Atom_Item_Stock.Columns["StockTake_ID"].Visible = false;

                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Supplier_Organisation_Name"].Visible = true;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Supplier_Organisation_Name"].DisplayIndex = 12;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Supplier_Organisation_Name"].HeaderText = lng.s_Supplier_Organisation_Name.s;


                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Supplier_Organisation_Tax_ID"].Visible = true;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Supplier_Organisation_Tax_ID"].DisplayIndex = 13;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Supplier_Organisation_Tax_ID"].HeaderText = lng.s_Supplier_Organisation_Tax_ID.s;


                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Supplier_Organisation_PhoneNumber"].Visible = true;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Supplier_Organisation_PhoneNumber"].DisplayIndex = 14; 
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Supplier_Organisation_PhoneNumber"].HeaderText = lng.s_Supplier_Organisation_PhoneNumber.s;

                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Supplier_Organisation_Email"].Visible = true;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Supplier_Organisation_Email"].DisplayIndex = 15;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Supplier_Organisation_Email"].HeaderText = lng.s_Supplier_Organisation_Email.s;

                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Supplier_Organisation_HomePage"].Visible = true;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Supplier_Organisation_HomePage"].DisplayIndex = 16;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Supplier_Organisation_HomePage"].HeaderText = lng.s_Supplier_Organisation_HomePage.s;

                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Supplier_Person_First_Name"].Visible = true;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Supplier_Person_First_Name"].DisplayIndex = 17;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Supplier_Person_First_Name"].HeaderText = lng.s_Supplier_Person_First_Name.s;

                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Supplier_Person_Last_Name"].Visible = true;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Supplier_Person_Last_Name"].DisplayIndex = 18;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Supplier_Person_Last_Name"].HeaderText = lng.s_Supplier_Person_Last_Name.s;

                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Supplier_Person_GsmNumber"].Visible = true;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Supplier_Person_GsmNumber"].DisplayIndex = 19; 
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Supplier_Person_GsmNumber"].HeaderText = lng.s_Supplier_Person_GsmNumber.s;


                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Supplier_Person_PhoneNumber"].Visible = true;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Supplier_Person_PhoneNumber"].DisplayIndex = 20;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Supplier_Person_PhoneNumber"].HeaderText = lng.s_Supplier_Person_PhoneNumber.s;


                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Supplier_Person_Email"].Visible = true;
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Supplier_Person_Email"].DisplayIndex = 21; 
                    dgvx_DocInvoice_Atom_Item_Stock.Columns["Supplier_Person_Email"].HeaderText = lng.s_Supplier_Person_Email.s;

                    int iCol_Stock_ExpiryDate =dt_DocInvoice_Atom_Item_Stock_view.Columns.IndexOf("Stock_ExpiryDate");
                    int iCol_ExpiryDate = dt_DocInvoice_Atom_Item_Stock_view.Columns.IndexOf("ExpiryDate");
                    int iCount = dt_DocInvoice_Atom_Item_Stock_view.Rows.Count;
                    for (int i =0;i<iCount;i++)
                    {
                        DataRow dria = dt_DocInvoice_Atom_Item_Stock_view.Rows[i];

                        Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd = new Atom_DocInvoice_ShopC_Item_Price_Stock_Data();
                        appisd.Set(m_InvoiceDB.DocTyp, dria,ref appisd_List);

                        if (dria[iCol_Stock_ExpiryDate] is DateTime)
                        {
                            dria[iCol_ExpiryDate] = dria[iCol_Stock_ExpiryDate];
                        }
                    }
                    Atom_DocInvoice_ShopC_Item_Price_Stock_Data xappisd= (Atom_DocInvoice_ShopC_Item_Price_Stock_Data)appisd_List[0];
                    this.txt_Atom_Item_Name.Text = xappisd.Atom_Item_Name_Name.v;
                    if (xappisd.Atom_Item_Description_Description != null)
                    {
                        this.txt_V_Atom_Item_Description.Text = xappisd.Atom_Item_Description_Description.v;
                    }
                    else
                    {
                        this.txt_V_Atom_Item_Description.Text = "";
                        txt_V_Atom_Item_Description.BackColor = Color_null;

                    }
                    decimal FromFactory_Count_sum = 0;
                    decimal FromStock_Count_sum = 0;
                    decimal CountAll = 0;
                    
                    FromFactory_Count_sum = xappisd.m_ShopShelf_Source.dQuantity_from_factory;
                    FromStock_Count_sum = xappisd.m_ShopShelf_Source.dQuantity_from_stock;
                    CountAll = FromFactory_Count_sum + FromStock_Count_sum;

                    this.txt_V_FromFactory.Text = FromFactory_Count_sum.ToString();
                    this.txt_V_FromStock.Text = FromStock_Count_sum.ToString();
                    this.lbl_V_Quantity.Text = CountAll.ToString();

                    if (xappisd.Atom_Expiry_ExpiryDescription != null)
                    {
                        this.txt_V_ExpiryDescription.Text = xappisd.Atom_Expiry_ExpiryDescription.v;
                    }
                    else
                    {
                        this.txt_V_ExpiryDescription.Text = "";
                        txt_V_ExpiryDescription.BackColor = Color_null;
                    }

                    if (xappisd.Atom_Warranty_WarrantyConditions != null)
                    {
                        this.txt_V_WarrantyConditions.Text = xappisd.Atom_Warranty_WarrantyConditions.v;
                    }
                    else
                    {
                        this.txt_V_WarrantyConditions.Text = "";
                        txt_V_WarrantyConditions.BackColor = Color_null;
                    }

                    if (xappisd.Atom_Expiry_ID != null)
                    {
                        chk_V_NeverExpires.Checked = true;
                        chk_V_NeverExpires.Enabled = true;
                    }
                    else
                    {
                        chk_V_NeverExpires.BackColor = Color_null;
                        chk_V_NeverExpires.Checked = false;
                        chk_V_NeverExpires.Enabled = false;
                    }

                    if (xappisd.Atom_Warranty_ID != null)
                    {
                        chk_V_Warranty.Enabled = true;
                        chk_V_Warranty.Checked = true;
                    }
                    else
                    {
                        chk_V_Warranty.BackColor = Color_null;
                        chk_V_Warranty.Enabled = false;
                        chk_V_Warranty.Checked = false;
                    }

                    if ((xappisd.Atom_Warranty_WarrantyDurationType != null) && (xappisd.Atom_Warranty_WarrantyDuration != null))
                    {
                        this.lbl_V_WarantyDuration.Text = m_InvoiceDB.SetWarrantyDurationText(xappisd.Atom_Warranty_WarrantyDurationType.v, xappisd.Atom_Warranty_WarrantyDuration.v);
                    }
                    else
                    {
                        this.lbl_V_WarantyDuration.Text = "";
                        lbl_V_WarantyDuration.BackColor = Color_null;
                    }

                    if (xappisd.Atom_Expiry_ExpectedShelfLifeInDays != null)
                    {
                        this.lbl_V_ExpectedShelfLifeInDays.Text = xappisd.Atom_Expiry_ExpectedShelfLifeInDays.v.ToString();
                    }
                    else
                    {
                        this.lbl_V_ExpectedShelfLifeInDays.Text = "";
                        lbl_V_ExpectedShelfLifeInDays.BackColor = Color_null;
                    }

                    if (xappisd.Atom_Expiry_SaleBeforeExpiryDateInDays != null)
                    {
                        this.lbl_V_SaleBeforeExpiryDateInDays.Text = xappisd.Atom_Expiry_SaleBeforeExpiryDateInDays.v.ToString();
                    }
                    else
                    {
                        this.lbl_V_SaleBeforeExpiryDateInDays.Text = "";
                        lbl_V_SaleBeforeExpiryDateInDays.BackColor = Color_null;
                    }

                    if (xappisd.Atom_Expiry_DiscardBeforeExpiryDateInDays != null)
                    {
                        this.lbl_V_DiscardBeforeExpiryDateInDays.Text = xappisd.Atom_Expiry_DiscardBeforeExpiryDateInDays.v.ToString();
                    }
                    else
                    {
                        this.lbl_V_DiscardBeforeExpiryDateInDays.Text = "";
                        lbl_V_DiscardBeforeExpiryDateInDays.BackColor = Color_null;
                    }

                    if (xappisd.Atom_Taxation_Name != null)
                    {
                        this.lbl_V_Taxation_Name.Text = xappisd.Atom_Taxation_Name.v;
                    }
                    else
                    {
                        this.lbl_V_Taxation_Name.Text = "";
                        lbl_V_Taxation_Name.BackColor = Color_null;
                    }

                    if (xappisd.Atom_Taxation_Rate != null)
                    {
                        this.lbl_V_Taxation_Rate.Text = (xappisd.Atom_Taxation_Rate.v * 100).ToString() + "%";
                    }
                    else
                    {
                        this.lbl_V_Taxation_Rate.Text = "";
                        lbl_V_Taxation_Rate.BackColor = Color_null;
                    }


                    if (xappisd.Atom_Item_barcode_barcode != null)
                    {
                        this.txt_barcode_value.Text = xappisd.Atom_Item_barcode_barcode.v;
                    }
                    else
                    {
                        this.txt_barcode_value.Text = "";
                        this.txt_barcode_value.BackColor = Color_null;
                    }

                    //Price 
                    decimal RetailPricePerUnit = -1;
                    if (xappisd.RetailPricePerUnit != null)
                    {
                        lbl_V_RetailPricePerUnit.Text = xappisd.RetailPricePerUnit.v.ToString();
                        RetailPricePerUnit = xappisd.RetailPricePerUnit.v;
                    }
                    else
                    {
                        lbl_V_RetailPricePerUnit.Text = "";
                        lbl_V_RetailPricePerUnit.BackColor = Color_null;

                    }
                    decimal RetailPrice = -1;
                    if (RetailPricePerUnit>=0)
                    {
                        RetailPrice = RetailPricePerUnit*CountAll;
                    }

                    decimal discount = 0;
                    if (xappisd.Discount != null)
                    {
                        discount = xappisd.Discount.v;
                        lbl_V_Discount.Text = (discount * 100).ToString() + "%";
                    }
                    else
                    {
                        lbl_V_Discount.Text = "";
                        lbl_V_Discount.BackColor = Color_null;
                    }

                    decimal RetailPriceWithDiscount = -1;
                    if (RetailPrice >= 0)
                    {
                        RetailPriceWithDiscount = RetailPrice * (1- discount);
                        lbl_V_RetailPriceWithDiscount.Text = RetailPriceWithDiscount.ToString();
                    }
                    else
                    {
                        lbl_V_RetailPriceWithDiscount.Text = "";
                        lbl_V_RetailPriceWithDiscount.BackColor = Color_null;
                    }

                    decimal TaxPrice = -1;
                    decimal TaxPricePerUnit = -1;
                    if (xappisd.TaxPrice != null)
                    {
                        TaxPricePerUnit = xappisd.TaxPrice.v;
                    }

                    if (TaxPricePerUnit >= 0)
                    {
                        TaxPrice = TaxPricePerUnit * CountAll;
                        lbl_V_TaxPrice.Text = TaxPrice.ToString();
                    }
                    else
                    {
                        lbl_V_TaxPrice.Text = "";
                        lbl_V_TaxPrice.BackColor = Color_null;
                    }


                    decimal NetPrice = -1;
                    if ((RetailPriceWithDiscount >= 0) && (TaxPrice >= 0))
                    {
                        NetPrice = RetailPriceWithDiscount - TaxPrice;
                        lbl_V_NetPrice.Text = NetPrice.ToString();
                    }
                    else
                    {
                        lbl_V_NetPrice.Text = "";
                        lbl_V_NetPrice.BackColor = Color_null;
                    }

                    string sql_get_image = "select Atom_Item_ImageLib.Image_Data from Atom_Item_ImageLib inner join Atom_Item_Image on Atom_Item_Image.Atom_Item_ImageLib_ID = Atom_Item_ImageLib.ID where Atom_Item_Image.Atom_Item_ID = " + xappisd.Atom_Item_ID.ToString();
                    DataTable dt = new DataTable();
                    if (DBSync.DBSync.ReadDataTable(ref dt, sql_get_image, null, ref Err))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            ImageConverter ic = new ImageConverter();
                            byte[] image_bytes = (byte[])dt.Rows[0]["Image_Data"];
                            this.pic_Atom_Item.Image = (Image)ic.ConvertFrom(image_bytes);
                        }
                    }
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Atom_Item_View:Init:No Atom_Item data for Atom_Item_ID = " + m_Atom_Item_ID.ToString());
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:Atom_Item_ViewForm_Load:Err=" + Err);
                return false;

            }
        }
        private void txt_V_FromStock_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
