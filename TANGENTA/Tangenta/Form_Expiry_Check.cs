#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using TangentaTableClass;
using InvoiceDB;
using LanguageControl;
using CodeTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tangenta
{
    public partial class Form_Expiry_Check : Form
    {
        string m_sNoExpiryDate = null;
        string m_sNoSaleBeforeExpiryDateInDays = null;
        string m_sNoDiscardBeforeExpiryDateInDays = null;
        DataTable dt_ExpiryCheck = null;
        int iSaleBeforeExpiryDateInDays_COUNT = 0;
        int iDiscardBeforeExpiryDateInDays_Count = 0;
        public Form_Expiry_Check()
        {
            InitializeComponent();
        }

     
        public Form_Expiry_Check(DataTable dt_ExpiryCheck, Control ctrl, string sNoExpiryDate, string sNoSaleBeforeExpiryDateInDays, string sNoDiscardBeforeExpiryDateInDays) 
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.dt_ExpiryCheck = dt_ExpiryCheck;
            this.Owner = GetForm(ctrl);
            lngRPM.s_Legend.Text(this.lbl_Legend);
            lbl_Color_Items_for_discount.BackColor = Color.Cyan;
            lbl_Color_ItemsToDestroy.BackColor = Color.Pink;
            lbl_Color_ItemsWithNoExpiryData.BackColor = Color.Gray;
            lbl_Items_for_discount.BackColor = Color.Cyan;
            lbl_ItemsToDestroy.BackColor = Color.Pink;
            lbl_Items_WithNoExpiryData.BackColor = Color.Gray;
            lngRPM.s_ItemsToDiscart.Text(lbl_ItemsToDestroy);
            lngRPM.s_ItemsToSale.Text(lbl_Items_for_discount);
            lngRPM.s_ItemsWithNoExpiryData.Text(lbl_Items_WithNoExpiryData);
            lngRPM.s_ExpiryStockCheck.Text(this);

            m_sNoExpiryDate = sNoExpiryDate;
            m_sNoSaleBeforeExpiryDateInDays = sNoSaleBeforeExpiryDateInDays;
            m_sNoDiscardBeforeExpiryDateInDays = sNoDiscardBeforeExpiryDateInDays;
        }

        private Form GetForm(Control ctrl)
        {
            if (ctrl is Form)
            {
                return (Form)ctrl;
            }
            Control c = ctrl.Parent;
            while (c!=null)
            {
                if (c is Form)
                {
                    return (Form)c;
                }
                else
                {
                    c = c.Parent;
                }
            }
            return null;
        }



        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void Form_Expiry_Check_Load(object sender, EventArgs e)
        {
            if (dt_ExpiryCheck == null)
            {
                if (fs.ExpiryCheckData(ref dt_ExpiryCheck))
                {
                    dgvx_ExpiryCheck.DataSource = dt_ExpiryCheck;
                    SQLTable tbl = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Stock)));
                    tbl.SetVIEW_DataGridViewImageColumns_Headers((DataGridView)dgvx_ExpiryCheck, DBSync.DBSync.DB_for_Tangenta.m_DBTables);
                }
                else
                {
                    this.Close();
                    DialogResult = DialogResult.Abort;
                }
            }
            else
            {
                dgvx_ExpiryCheck.DataSource = dt_ExpiryCheck;
                SQLTable tbl = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Stock)));
                tbl.SetVIEW_DataGridViewImageColumns_Headers((DataGridView)dgvx_ExpiryCheck, DBSync.DBSync.DB_for_Tangenta.m_DBTables);
            }
        }

        private void dgvx_ExpiryCheck_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            int iRow = e.RowIndex;
            int iCol = e.ColumnIndex;
            if (iCol == 0)
            {
                object oStock_ExpiryDate = dt_ExpiryCheck.Rows[iRow]["Stock_$$ExpiryDate"];
                if (oStock_ExpiryDate is DateTime)
                {
                    DateTime dt_Expiry_Date = (DateTime)oStock_ExpiryDate;
                    object oStock_ppi_i_exp_SaleBeforeExpiryDateInDays = dt_ExpiryCheck.Rows[iRow]["Stock_$_ppi_$_i_$_exp_$$SaleBeforeExpiryDateInDays"];
                    if (oStock_ppi_i_exp_SaleBeforeExpiryDateInDays is int)
                    {
                        int iSaleBeforeExpiryDateInDays = (int)oStock_ppi_i_exp_SaleBeforeExpiryDateInDays;
                        object oStock_ppi_i_exp_DiscardBeforeExpiryDateInDays = dt_ExpiryCheck.Rows[iRow]["Stock_$_ppi_$_i_$_exp_$$DiscardBeforeExpiryDateInDays"];
                        if (oStock_ppi_i_exp_DiscardBeforeExpiryDateInDays is int)
                        {
                            int iDiscardBeforeExpiryDateInDays = (int)oStock_ppi_i_exp_DiscardBeforeExpiryDateInDays;
                            DateTime datet_SaleBeforeExpiryDateInDays = dt_Expiry_Date.AddDays(-iSaleBeforeExpiryDateInDays);
                            DateTime datet_DiscardBeforeExpiryDateInDays = dt_Expiry_Date.AddDays(-iDiscardBeforeExpiryDateInDays);
                            DateTime dtNow = DateTime.Now;
                            if (dtNow.CompareTo(datet_DiscardBeforeExpiryDateInDays) > 0)
                            {
                                foreach (DataGridViewCell dgvc in dgvx_ExpiryCheck.Rows[iRow].Cells)
                                {
                                    dgvc.Style.BackColor = Color.Pink;
                                }

                            }
                            else
                            {
                                if (dtNow.CompareTo(datet_SaleBeforeExpiryDateInDays) > 0)
                                {
                                    foreach (DataGridViewCell dgvc in dgvx_ExpiryCheck.Rows[iRow].Cells)
                                    {
                                        dgvc.Style.BackColor = Color.Cyan;
                                    }
                                    iSaleBeforeExpiryDateInDays_COUNT++;
                                }
                            }
                        }
                        else
                        {
                            foreach (DataGridViewCell dgvc in dgvx_ExpiryCheck.Rows[iRow].Cells)
                            {
                                dgvc.Style.BackColor = Color.Gray;
                            }
                        }
                    }
                    else
                    {
                        foreach (DataGridViewCell dgvc in dgvx_ExpiryCheck.Rows[iRow].Cells)
                        {
                            dgvc.Style.BackColor = Color.Gray;
                        }
                    }
                }
                else
                {
                    foreach (DataGridViewCell dgvc in dgvx_ExpiryCheck.Rows[iRow].Cells)
                    {
                        dgvc.Style.BackColor = Color.Gray;
                    }
                }
            }
        }
    }
}
