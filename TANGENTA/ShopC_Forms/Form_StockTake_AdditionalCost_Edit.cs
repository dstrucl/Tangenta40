using CodeTables;
using DBConnectionControl40;
using DBTypes;
using LanguageControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShopC_Forms
{
    public partial class Form_StockTake_AdditionalCost_Edit : Form
    {
        int current_index = -1;
        private ID StockTake_ID = null;
        private string StockTake_Name = null;
        DataTable dtStockTakeCostName = new DataTable();
        DataTable dtStockTake_AdditionalCost = new DataTable();
        ID StockTake_AdditionalCost_ID = null;

        private bool m_Changed = false;

        public bool Changed
        {
            get { return m_Changed; }
        }

        public Form_StockTake_AdditionalCost_Edit(ID xStockTake_ID,string xStockTake_Name)
        {
            InitializeComponent();
            StockTake_ID = xStockTake_ID;
            StockTake_Name = xStockTake_Name;
            lng.s_AddtionalCost_for_StockTake.Text(this, " : " + StockTake_Name);
            lng.s_Add.Text(btn_Add);
            lng.s_btn_Remove.Text(btn_Remove);
            lng.s_Update.Text(btn_Update);
            lng.s_lbl_StocTakeCostName.Text(lbl_StocTakeCostName);
            lng.s_lbl_Cost.Text(lbl_Cost);
            lng.s_lbl_Description.Text(lbl_StockTakeCostDescription);
            m_Changed = false;

        }

        private void Form_StockTake_AdditionalCost_Load(object sender, EventArgs e)
        {
            Reload(StockTake_ID);
        }

        private bool Reload(ID xStockTake_ID)
        {
            this.dgvx_StockTakeAdditionalCost.SelectionChanged -= new System.EventHandler(this.dgvx_StockTakeAdditionalCost_SelectionChanged);
            dgvx_StockTakeAdditionalCost.DataSource = null;
            if (TangentaDB.f_StockTakeCostName.ReadDataTable(ref dtStockTakeCostName))
            {
                this.cmb_StocTakeCostName.DataSource = dtStockTakeCostName;
                this.cmb_StocTakeCostName.DisplayMember = "Name";
                this.cmb_StocTakeCostName.ValueMember = "ID";
                if (TangentaDB.f_StockTake_AdditionalCost.ReadDataTable(ref dtStockTake_AdditionalCost, xStockTake_ID))
                {
                    dgvx_StockTakeAdditionalCost.DataSource = dtStockTake_AdditionalCost;
                    dgvx_StockTakeAdditionalCost.Columns["Name"].HeaderText = lng.s_CostName.s;
                    dgvx_StockTakeAdditionalCost.Columns["Cost"].HeaderText = lng.s_CostPrice.s;
                    dgvx_StockTakeAdditionalCost.Columns["Description"].HeaderText = lng.s_CostDescription.s;
                    dgvx_StockTakeAdditionalCost.Columns["ID"].Visible = false;
                    dgvx_StockTakeAdditionalCost.Columns["StockTakeCostName_ID"].Visible = false;
                    dgvx_StockTakeAdditionalCost.Columns["StockTake_Name"].Visible = false;
                    if (dtStockTake_AdditionalCost.Rows.Count>0 && current_index < 0)
                    {
                        current_index = 0;
                    }
                    if (current_index >= dtStockTake_AdditionalCost.Rows.Count)
                    {
                        if (dtStockTake_AdditionalCost.Rows.Count == 0)
                        {
                            current_index = -1;
                        }
                        else
                        {
                            current_index = dtStockTake_AdditionalCost.Rows.Count - 1;
                        }
                    }
                    if (current_index >= 0)
                    {
                        StockTake_AdditionalCost_ID = tf.set_ID(dtStockTake_AdditionalCost.Rows[current_index]["ID"]);
                        dgvx_StockTakeAdditionalCost.Rows[current_index].Selected = true;
                        btn_Remove.Visible = true;
                        btn_Update.Visible = true;
                    }
                    else
                    {
                        StockTake_AdditionalCost_ID = null;
                        btn_Remove.Visible = false;
                        btn_Update.Visible = false;
                    }
                    this.dgvx_StockTakeAdditionalCost.SelectionChanged += new System.EventHandler(this.dgvx_StockTakeAdditionalCost_SelectionChanged);
                    return true;
                }
            }
            return false;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            string name = cmb_StocTakeCostName.Text;
            if (name.Length > 0)
            {
                decimal cost = nmUpDn_Cost.Value;
                string description = txt_Description.Text;
                Transaction transaction_Form_StokTake_AdditionalCost_Edit_f_StockTake_AdditionalCost_Add = DBSync.DBSync.NewTransaction("Form_StokTake_AdditionalCost_Edit.f_StockTake_AdditionalCost.Add");
                if (TangentaDB.f_StockTake_AdditionalCost.Add(StockTake_ID, name, cost, description, ref StockTake_AdditionalCost_ID, transaction_Form_StokTake_AdditionalCost_Edit_f_StockTake_AdditionalCost_Add))
                {
                    if (transaction_Form_StokTake_AdditionalCost_Edit_f_StockTake_AdditionalCost_Add.Commit())
                    {
                        m_Changed = true;
                        Reload(StockTake_ID);
                        DataRow[] drs = dtStockTake_AdditionalCost.Select("ID = " + StockTake_AdditionalCost_ID);
                        if (drs.Length > 0)
                        {
                            current_index = dtStockTake_AdditionalCost.Rows.IndexOf(drs[0]);
                            dgvx_StockTakeAdditionalCost.Rows[current_index].Selected = true;
                        }
                    }
                }
                else
                {
                    transaction_Form_StokTake_AdditionalCost_Edit_f_StockTake_AdditionalCost_Add.Rollback();
                }
            }
            else
            {
                XMessage.Box.Show(this,true, lng.s_StockTake_Cost_Name_must_be_defined,MessageBoxIcon.Warning);

            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (ID.Validate(StockTake_AdditionalCost_ID))
            {
                string name = cmb_StocTakeCostName.Text;
                decimal cost = nmUpDn_Cost.Value;
                Transaction transaction_Form_StokTake_AdditionalCost_Edit_f_StockTake_AdditionalCost_Update = DBSync.DBSync.NewTransaction("Form_StokTake_AdditionalCost_Edit.f_StockTake_AdditionalCost.Update");

                if (TangentaDB.f_StockTake_AdditionalCost.Update(StockTake_AdditionalCost_ID, 
                                                                 StockTake_ID, 
                                                                 name,
                                                                 cost,
                                                                 txt_Description.Text,
                                                                 transaction_Form_StokTake_AdditionalCost_Edit_f_StockTake_AdditionalCost_Update))
                {
                    if (transaction_Form_StokTake_AdditionalCost_Edit_f_StockTake_AdditionalCost_Update.Commit())
                    {
                        m_Changed = true;
                        Reload(StockTake_ID);
                        FillControls();
                    }
                }
                else
                {
                    transaction_Form_StokTake_AdditionalCost_Edit_f_StockTake_AdditionalCost_Update.Rollback();

                }
            }
        }

        private void dgvx_StockTakeAdditionalCost_SelectionChanged(object sender, EventArgs e)
        {
            if (dtStockTake_AdditionalCost.Rows.Count > 0)
            {
                DataGridViewSelectedRowCollection dgvxrc = dgvx_StockTakeAdditionalCost.SelectedRows;
                if (dgvxrc.Count > 0)
                {
                    current_index = dgvxrc[0].Index;
                    if (current_index >= 0)
                    {
                        StockTake_AdditionalCost_ID = tf.set_ID(dtStockTake_AdditionalCost.Rows[current_index]["ID"]);
                        FillControls();
                    }
                    else
                    {
                        StockTake_AdditionalCost_ID = null;
                        ClearControls();
                    }
                }
            }
        }
        private void FillControls()
        {
            long StockTakeCostName_ID = (long)dtStockTake_AdditionalCost.Rows[current_index]["StockTakeCostName_ID"];
            int cmb_idx = find_cmb_StocTakeCostName(StockTakeCostName_ID);
            if (cmb_idx >= 0)
            {
                cmb_StocTakeCostName.SelectedIndex = cmb_idx;
            }
            this.nmUpDn_Cost.Value = (decimal)dtStockTake_AdditionalCost.Rows[current_index]["Cost"];
            object oDescription = dtStockTake_AdditionalCost.Rows[current_index]["Description"];
            this.txt_Description.Text = "";
            if (oDescription is string)
            {
                if (oDescription != null)
                {
                    this.txt_Description.Text = (string)oDescription;
                }
            }
        }

        private int find_cmb_StocTakeCostName(long stockTakeCostName_ID)
        {
            int iCount = cmb_StocTakeCostName.Items.Count;
            for(int i=0;i<iCount;i++)
            {
                object o = cmb_StocTakeCostName.Items[i];
                if (o  is System.Data.DataRowView)
                {
                    object oitem = ((System.Data.DataRowView)o).Row.ItemArray[0];
                    if (oitem is long)
                    if (((long)oitem)== stockTakeCostName_ID)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            if (ID.Validate(StockTake_AdditionalCost_ID))
            {
                Transaction transaction_Form_StockTake_AdditionalCost_Edit_btn_Remove_Click_f_StockTake_AdditionalCost_Remove = DBSync.DBSync.NewTransaction("Form_StockTake_AdditionalCost_Edit.btn_Remove_Click.f_StockTake_AdditionalCost.Remove");
                if (TangentaDB.f_StockTake_AdditionalCost.Remove(StockTake_AdditionalCost_ID,
                                                                 StockTake_ID,
                                                                 transaction_Form_StockTake_AdditionalCost_Edit_btn_Remove_Click_f_StockTake_AdditionalCost_Remove))
                {
                    if (transaction_Form_StockTake_AdditionalCost_Edit_btn_Remove_Click_f_StockTake_AdditionalCost_Remove.Commit())
                    {
                        m_Changed = true;
                        Reload(StockTake_ID);
                        if (dtStockTake_AdditionalCost.Rows.Count == 0)
                        {
                            current_index = -1;
                        }
                        if (current_index >= dtStockTake_AdditionalCost.Rows.Count)
                        {
                            current_index = dtStockTake_AdditionalCost.Rows.Count - 1;
                        }
                        if (current_index >= 0)
                        {
                            StockTake_AdditionalCost_ID = tf.set_ID(dtStockTake_AdditionalCost.Rows[current_index]["ID"]);
                            FillControls();
                        }
                        else
                        {
                            StockTake_AdditionalCost_ID = null;
                            ClearControls();
                        }
                    }
                }
                else
                {
                    transaction_Form_StockTake_AdditionalCost_Edit_btn_Remove_Click_f_StockTake_AdditionalCost_Remove.Rollback();
                }
            }
        }

        private void ClearControls()
        {
            cmb_StocTakeCostName.SelectedIndex = -1;
            cmb_StocTakeCostName.Text = "";
            this.nmUpDn_Cost.Value = 0;
            this.txt_Description.Text = "";
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }
    }
}
