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

namespace ShopC
{
    public partial class Form_Show_Documents_Where_stock_item_was_sold_or_reserved : Form
    {
        long Stock_ID = -1;
        Doc_ShopC_Item_Data[] adata = null;
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

        public Form_Show_Documents_Where_stock_item_was_sold_or_reserved(long xStock_ID, Doc_ShopC_Item_Data[] xadata)
        {
            InitializeComponent();
            Stock_ID = xStock_ID;
            adata = xadata;
            dcol_DocumentType = new DataColumn("DocumentType", typeof(bool));
            dt_Where_stock_item_was_sold_or_reserved.Columns.Add(dcol_DocumentType);

            dcol_DocumentTypeName = new DataColumn("DocumentTypeName", typeof(string));
            dt_Where_stock_item_was_sold_or_reserved.Columns.Add(dcol_DocumentTypeName);

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

        }

        private void Form_Show_Documents_Where_stock_item_was_sold_or_reserved_Load(object sender, EventArgs e)
        {
            foreach (Doc_ShopC_Item_Data data in adata)
            {
                DataRow dr = dt_Where_stock_item_was_sold_or_reserved.NewRow();

                if (fs.IDisValid(data.DocInvoice_ID))
                {
                    
                    dr[dcol_DocumentType.ColumnName] = true;
                    dr[dcol_DocumentTypeName.ColumnName] = lngRPM.s_DocInvoice.s;
                    FillDocInvoiceCells(data.DocInvoice_ID, ref dr);
                    FillDocInvoiceItemStockCells(data.DocInvoice_ShopC_Item_ID, ref dr);
                }
                else
                {
                    dr[dcol_DocumentType.ColumnName] = false;
                    dr[dcol_DocumentTypeName.ColumnName] = lngRPM.s_DocProformaInvoice.s;
                    FillDocProformaInvoiceCells(data.DocProformaInvoice_ID, ref dr);
                    FillDocProformaInvoiceItemStockCells(data.DocProformaInvoice_ShopC_Item_ID, ref dr);
                }
                dt_Where_stock_item_was_sold_or_reserved.Rows.Add(dr);
            }
            dgvx_Stock_Item_OnDocument.DataSource = dt_Where_stock_item_was_sold_or_reserved;
        }

        private void FillDocInvoiceItemStockCells(long docInvoice_ShopC_Item_ID, ref DataRow dr)
        {
            decimal QuantityTakenFromStock = -1;
            string Item_UniqueName = "";
            string StockTakeName = "";
            DateTime ExpiryDate = DateTime.MinValue;
           DateTime StockTakeDate = DateTime.MinValue;
            if (f_DocInvoice_ShopC_Item.Get(docInvoice_ShopC_Item_ID,
                                        ref QuantityTakenFromStock,
                                        ref ExpiryDate,
                                        ref Item_UniqueName,
                                        ref StockTakeName,
                                        ref StockTakeDate
                                        ))
            {
                dr[dcol_QuantityTakenFromStock.ColumnName] = QuantityTakenFromStock;
                dr[dcol_ExpiryDate.ColumnName] = ExpiryDate;
                dr[dcol_Item_UniqueName.ColumnName] = Item_UniqueName;
                dr[dcol_StockTakeName.ColumnName] = StockTakeName;
                dr[dcol_StockTakeDate.ColumnName] = StockTakeDate;
            }
        }

        private void FillDocProformaInvoiceItemStockCells(long docInvoice_ShopC_Item_ID, ref DataRow dr)
        {
            decimal QuantityTakenFromStock = -1;
            string Item_UniqueName = "";
            string StockTakeName = "";
            DateTime ExpiryDate = DateTime.MinValue;
            DateTime StockTakeDate = DateTime.MinValue;
            if (f_DocProformaInvoice_ShopC_Item.Get(docInvoice_ShopC_Item_ID,
                                        ref QuantityTakenFromStock,
                                        ref ExpiryDate,
                                        ref Item_UniqueName,
                                        ref StockTakeName,
                                        ref StockTakeDate
                                        ))
            {
                dr[dcol_QuantityTakenFromStock.ColumnName] = QuantityTakenFromStock;
                dr[dcol_ExpiryDate.ColumnName] = ExpiryDate;
                dr[dcol_Item_UniqueName.ColumnName] = Item_UniqueName;
                dr[dcol_StockTakeName.ColumnName] = StockTakeName;
                dr[dcol_StockTakeDate.ColumnName] = StockTakeDate;
            }
        }

        private void FillDocInvoiceCells(long DocProformaInvoice_ID, ref DataRow dr)
        {
            bool bDraft = false;
            long DraftNumber = -1;
            long FinancialYear = -1;
            long NumberInFinancialYear = -1;
            if (f_DocInvoice.Get(DocProformaInvoice_ID,
                             ref bDraft,
                             ref DraftNumber,
                             ref FinancialYear,
                             ref NumberInFinancialYear
                            ))
            {
                dr[dcol_Draft.ColumnName] = bDraft;
                dr[dcol_DraftNumber.ColumnName] = DraftNumber;
                dr[dcol_FinancialYear.ColumnName] = FinancialYear;
                dr[dcol_NumberInFinancialYear.ColumnName] = NumberInFinancialYear;
            }
        }

        private void FillDocProformaInvoiceCells(long DocProformaInvoice_ID, ref DataRow dr)
        {
            bool bDraft = false;
            long DraftNumber = -1;
            long FinancialYear = -1;
            long NumberInFinancialYear = -1;
            if (f_DocProformaInvoice.Get(DocProformaInvoice_ID,
                             ref bDraft,
                             ref DraftNumber,
                             ref FinancialYear,
                             ref NumberInFinancialYear
                            ))
            {
                dr[dcol_Draft.ColumnName] = bDraft;
                dr[dcol_DraftNumber.ColumnName] = DraftNumber;
                dr[dcol_FinancialYear.ColumnName] = FinancialYear;
                dr[dcol_NumberInFinancialYear.ColumnName] = NumberInFinancialYear;
            }
        }

    }
}
