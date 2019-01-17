using DBConnectionControl40;
using LanguageControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TangentaDB;

namespace ShopC_Forms
{
    public partial class Form_Show_Documents_Where_stock_item_was_sold_or_reserved : Form
    {
        ID Stock_ID = null;
        TangentaDB.Consumption_ShopC_Item_Data[] adata = null;
        DataTable dt_Where_stock_item_was_sold_or_reserved = new DataTable();
        DataColumn dcol_DocumentType = null;
        DataColumn dcol_DocumentTypeName = null;
        DataColumn dcol_Draft = null;
        DataColumn dcol_DraftNumber = null;
        DataColumn dcol_NumberInFinancialYear = null;
        DataColumn dcol_FinancialYear = null;
        DataColumn dcol_Item_UniqueName = null;
        DataColumn dcol_StockTakeName = null;
        DataColumn dcol_QuantityTakenFromStock = null;
        DataColumn dcol_ExpiryDate = null;
        DataColumn dcol_StockTakeDate = null;
        DataColumn dcol_Addressee = null;

        f_DocInvoice.fData DocInvoice_data = new f_DocInvoice.fData();
        f_DocProformaInvoice.fData DocProformaInvoice_data = new f_DocProformaInvoice.fData();


        public Form_Show_Documents_Where_stock_item_was_sold_or_reserved(ID xStock_ID, TangentaDB.Consumption_ShopC_Item_Data[] xadata)
        {
            InitializeComponent();
            Stock_ID = xStock_ID;
            adata = xadata;
            dcol_DocumentType = new DataColumn("DocumentType", typeof(bool));
            dt_Where_stock_item_was_sold_or_reserved.Columns.Add(dcol_DocumentType);

            dcol_DocumentTypeName = new DataColumn("DocumentTypeName", typeof(string));
            dt_Where_stock_item_was_sold_or_reserved.Columns.Add(dcol_DocumentTypeName);

            dcol_Addressee = new DataColumn("Addressee", typeof(string));
            dt_Where_stock_item_was_sold_or_reserved.Columns.Add(dcol_Addressee);

            dcol_Draft = new DataColumn("Draft", typeof(bool));
            dt_Where_stock_item_was_sold_or_reserved.Columns.Add(dcol_Draft);

            dcol_DraftNumber = new DataColumn("DraftNumber", typeof(long));
            dt_Where_stock_item_was_sold_or_reserved.Columns.Add(dcol_DraftNumber);

            dcol_FinancialYear = new DataColumn("FinancialYear", typeof(long));
            dt_Where_stock_item_was_sold_or_reserved.Columns.Add(dcol_FinancialYear);

            dcol_NumberInFinancialYear = new DataColumn("NumberInFinancialYear", typeof(long));
            dt_Where_stock_item_was_sold_or_reserved.Columns.Add(dcol_NumberInFinancialYear);

            dcol_Item_UniqueName = new DataColumn("Item_UniqueName", typeof(string));
            dt_Where_stock_item_was_sold_or_reserved.Columns.Add(dcol_Item_UniqueName);

            dcol_StockTakeName = new DataColumn("StockTakeName", typeof(string));
            dt_Where_stock_item_was_sold_or_reserved.Columns.Add(dcol_StockTakeName);

            
            dcol_QuantityTakenFromStock = new DataColumn("QuantityTakenFromStock", typeof(decimal));
            dt_Where_stock_item_was_sold_or_reserved.Columns.Add(dcol_QuantityTakenFromStock);

            dcol_ExpiryDate = new DataColumn("ExpiryDate", typeof(DateTime));
            dt_Where_stock_item_was_sold_or_reserved.Columns.Add(dcol_ExpiryDate);

            dcol_StockTakeDate = new DataColumn("StockTakeDate", typeof(DateTime));
            dt_Where_stock_item_was_sold_or_reserved.Columns.Add(dcol_StockTakeDate);


            lng.s_Form_Show_Documents_Where_stock_item_was_sold_or_reserved.Text(this);
        }

        private void Form_Show_Documents_Where_stock_item_was_sold_or_reserved_Load(object sender, EventArgs e)
        {
            foreach (TangentaDB.Consumption_ShopC_Item_Data data in adata)
            {
                DataRow dr = dt_Where_stock_item_was_sold_or_reserved.NewRow();


                if (ID.Validate(data.DocInvoice_ID))
                {

                    dr[dcol_DocumentType.ColumnName] = true;
                    dr[dcol_DocumentTypeName.ColumnName] = lng.s_DocInvoice.s;
                    if (f_DocInvoice.Get(data.DocInvoice_ID, data.DocInvoice_ShopC_Item_ID, ref DocInvoice_data))
                    {
                        dr[dcol_Draft.ColumnName] = DocInvoice_data.bDraft;
                        dr[dcol_DraftNumber.ColumnName] = DocInvoice_data.DraftNumber;
                        dr[dcol_FinancialYear.ColumnName] = DocInvoice_data.FinancialYear;
                        dr[dcol_NumberInFinancialYear.ColumnName] = DocInvoice_data.NumberInFinancialYear;
                        dr[dcol_QuantityTakenFromStock.ColumnName] = DocInvoice_data.ShopC_Item_Data.QuantityTakenFromStock;
                        dr[dcol_ExpiryDate.ColumnName] = DocInvoice_data.ShopC_Item_Data.ExpiryDate;
                        dr[dcol_Item_UniqueName.ColumnName] = DocInvoice_data.ShopC_Item_Data.Item_UniqueName;
                        dr[dcol_StockTakeName.ColumnName] = DocInvoice_data.ShopC_Item_Data.StockTakeName;
                        dr[dcol_StockTakeDate.ColumnName] = DocInvoice_data.ShopC_Item_Data.StockTakeDate;
                        dr[dcol_Addressee] = DocInvoice_data.Addressee;
                    }
                }
                else
                {
                    dr[dcol_DocumentType.ColumnName] = false;
                    dr[dcol_DocumentTypeName.ColumnName] = lng.s_DocProformaInvoice.s;
                    if (f_DocProformaInvoice.Get(data.DocProformaInvoice_ID, data.DocProformaInvoice_ShopC_Item_ID, ref DocProformaInvoice_data))
                    {
                        dr[dcol_Draft.ColumnName] = DocProformaInvoice_data.bDraft;
                        dr[dcol_DraftNumber.ColumnName] = DocProformaInvoice_data.DraftNumber;
                        dr[dcol_FinancialYear.ColumnName] = DocProformaInvoice_data.FinancialYear;
                        dr[dcol_NumberInFinancialYear.ColumnName] = DocProformaInvoice_data.NumberInFinancialYear;
                        dr[dcol_QuantityTakenFromStock.ColumnName] = DocProformaInvoice_data.ShopC_Item_Data.QuantityTakenFromStock;
                        dr[dcol_ExpiryDate.ColumnName] = DocProformaInvoice_data.ShopC_Item_Data.ExpiryDate;
                        dr[dcol_Item_UniqueName.ColumnName] = DocProformaInvoice_data.ShopC_Item_Data.Item_UniqueName;
                        dr[dcol_StockTakeName.ColumnName] = DocProformaInvoice_data.ShopC_Item_Data.StockTakeName;
                        dr[dcol_StockTakeDate.ColumnName] = DocProformaInvoice_data.ShopC_Item_Data.StockTakeDate;
                        dr[dcol_Addressee] = DocProformaInvoice_data.Addressee;
                    }
                }
                dt_Where_stock_item_was_sold_or_reserved.Rows.Add(dr);
            }
            dgvx_Stock_Item_OnDocument.DataSource = dt_Where_stock_item_was_sold_or_reserved;

            dgvx_Stock_Item_OnDocument.Columns[dcol_DocumentType.ColumnName].HeaderText = lng.s_Document_Type.s;
            dgvx_Stock_Item_OnDocument.Columns[dcol_Draft.ColumnName].HeaderText = lng.s_Draft.s;
            dgvx_Stock_Item_OnDocument.Columns[dcol_DraftNumber.ColumnName].HeaderText = lng.s_DraftNumber.s;
            dgvx_Stock_Item_OnDocument.Columns[dcol_FinancialYear.ColumnName].HeaderText = lng.s_FinancialYear.s;
            dgvx_Stock_Item_OnDocument.Columns[dcol_NumberInFinancialYear.ColumnName].HeaderText = lng.s_NumberInFinancialYear.s;
            dgvx_Stock_Item_OnDocument.Columns[dcol_QuantityTakenFromStock.ColumnName].HeaderText = lng.s_QuantityTakenFromStock.s;
            dgvx_Stock_Item_OnDocument.Columns[dcol_ExpiryDate.ColumnName].HeaderText = lng.s_ExpiryDate.s;
            dgvx_Stock_Item_OnDocument.Columns[dcol_Item_UniqueName.ColumnName].HeaderText = lng.s_ItemUniqueName.s;
            dgvx_Stock_Item_OnDocument.Columns[dcol_StockTakeName.ColumnName].HeaderText = lng.s_StockTakeName.s;
            dgvx_Stock_Item_OnDocument.Columns[dcol_StockTakeDate.ColumnName].HeaderText = lng.s_StockTakeDate.s;
            dgvx_Stock_Item_OnDocument.Columns[dcol_Addressee.ColumnName].HeaderText = lng.s_Addressee.s;
            dgvx_Stock_Item_OnDocument.Columns[dcol_DocumentType.ColumnName].Visible = false;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }
    }
}
