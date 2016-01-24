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
using ShopA_dbfunc;
using BlagajnaTableClass;
using SQLTableControl;
using DBTypes;
using System.Windows.Forms.VisualStyles;

namespace ShopA
{
    public partial class usrc_ShopA : UserControl
    {
        public delegate void delegate_aa_ItemAdded(long ID, DataTable dt);
        public event delegate_aa_ItemAdded aa_ItemAdded = null;

        private const string column_deselect = "deselect";
        DataGridViewImageButtonColumn dgvxc_btn_Remove = null;

        public enum eMode { VIEW, EDIT };
        ShopABC m_ShopABC = null;
        DBTablesAndColumnNames DBtcn = null;
        public DataTable dt_Item_Price = new DataTable();
        Atom_ItemShopA_Price m_Atom_ItemShopA_Price = new Atom_ItemShopA_Price();
        SQLTable t_Atom_ItemShopA_Price = null;

        public usrc_ShopA()
        {
            InitializeComponent();
            t_Atom_ItemShopA_Price = new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Atom_ItemShopA_Price)));
        }

        public void Init(ShopABC xm_ShopABC, DBTablesAndColumnNames xDBtcn)
        {
            m_ShopABC = xm_ShopABC;
            DBtcn = xDBtcn;

        }

        public void SetDraft()
        {
            if (dgvxc_btn_Remove == null)
            {
                dgvxc_btn_Remove = new DataGridViewImageButtonColumn();
                dgvxc_btn_Remove.HeaderText = "Odstrani";
                dgvxc_btn_Remove.Text = "-";
                dgvxc_btn_Remove.Name = column_deselect;
                this.dgvx_ShopA.Columns.Add(dgvxc_btn_Remove);
                this.usrc_Editor1.Init(m_ShopABC, m_Atom_ItemShopA_Price);
            }
            dt_Item_Price.Clear();
            this.dgvx_ShopA.DataSource = null;
            if (dbfunc.ReadItems(ref dt_Item_Price, m_ShopABC.m_CurrentInvoice.ProformaInvoice_ID))
            {
                this.dgvx_ShopA.DataSource = dt_Item_Price;
                t_Atom_ItemShopA_Price.SetVIEW_DataGridViewImageColumns_Headers((DataGridView)dgvx_ShopA, DBSync.DBSync.DB_for_Blagajna.m_DBTables);
                this.dgvx_ShopA.Columns["ID"].Visible = false;
                this.dgvx_ShopA.Columns["Atom_ItemShopA_Price_$_pinv_$$ID"].Visible = false;
                this.dgvx_ShopA.Columns["Atom_ItemShopA_Price_$_aisha_$_tax_$$ID"].Visible = false;
                this.dgvx_ShopA.Columns["Atom_ItemShopA_Price_$_aisha_$_u_$$ID"].Visible = false;
                this.dgvx_ShopA.Columns["Atom_ItemShopA_Price_$_aisha_$$ID"].Visible = false;
                this.dgvx_ShopA.Columns["Atom_ItemShopA_Price_$_pinv_$$Draft"].Visible = false;
                this.dgvx_ShopA.Columns["Atom_ItemShopA_Price_$_aisha_$_u_$$Symbol"].Visible = false;
                this.dgvx_ShopA.Columns["Atom_ItemShopA_Price_$_aisha_$_u_$$DecimalPlaces"].Visible = false;

                if (dt_Item_Price.Rows.Count > 0)
                {
                    m_Atom_ItemShopA_Price.ID.type_v = tf.set_long(dt_Item_Price.Rows[0]["ID"]);
                    m_Atom_ItemShopA_Price.m_ProformaInvoice.ID.set(dt_Item_Price.Rows[0]["Atom_ItemShopA_Price_$_pinv_$$ID"]);
                    m_Atom_ItemShopA_Price.m_ProformaInvoice.Draft.set(dt_Item_Price.Rows[0]["Atom_ItemShopA_Price_$_pinv_$$Draft"]);
                    m_Atom_ItemShopA_Price.m_Atom_ItemShopA.ID.set(dt_Item_Price.Rows[0]["Atom_ItemShopA_Price_$_aisha_$$ID"]);
                    m_Atom_ItemShopA_Price.m_Atom_ItemShopA.Name.set(dt_Item_Price.Rows[0]["Atom_ItemShopA_Price_$_aisha_$$Name"]);
                    m_Atom_ItemShopA_Price.m_Atom_ItemShopA.Name.set(dt_Item_Price.Rows[0]["Atom_ItemShopA_Price_$_aisha_$$Description"]);
                    m_Atom_ItemShopA_Price.m_Atom_ItemShopA.m_Taxation.ID.set(dt_Item_Price.Rows[0]["Atom_ItemShopA_Price_$_aisha_$_tax_$$ID"]);
                    m_Atom_ItemShopA_Price.m_Atom_ItemShopA.m_Taxation.Name.set(dt_Item_Price.Rows[0]["Atom_ItemShopA_Price_$_aisha_$_tax_$$Name"]);
                    m_Atom_ItemShopA_Price.m_Atom_ItemShopA.m_Taxation.Rate.set(dt_Item_Price.Rows[0]["Atom_ItemShopA_Price_$_aisha_$_tax_$$Rate"]);
                    m_Atom_ItemShopA_Price.m_Atom_ItemShopA.m_Unit.ID.set(dt_Item_Price.Rows[0]["Atom_ItemShopA_Price_$_aisha_$_u_$$ID"]);
                    m_Atom_ItemShopA_Price.m_Atom_ItemShopA.m_Unit.Name.set(dt_Item_Price.Rows[0]["Atom_ItemShopA_Price_$_aisha_$_u_$$Name"]);
                    m_Atom_ItemShopA_Price.m_Atom_ItemShopA.m_Unit.Symbol.set(dt_Item_Price.Rows[0]["Atom_ItemShopA_Price_$_aisha_$_u_$$Symbol"]);
                    m_Atom_ItemShopA_Price.m_Atom_ItemShopA.m_Unit.DecimalPlaces.set(dt_Item_Price.Rows[0]["Atom_ItemShopA_Price_$_aisha_$_u_$$DecimalPlaces"]);
                    m_Atom_ItemShopA_Price.Discount.set(dt_Item_Price.Rows[0]["Atom_ItemShopA_Price_$$Discount"]);
                    m_Atom_ItemShopA_Price.dQuantity.set(dt_Item_Price.Rows[0]["Atom_ItemShopA_Price_$$dQuantity"]);
                    m_Atom_ItemShopA_Price.PricePerUnit.set(dt_Item_Price.Rows[0]["Atom_ItemShopA_Price_$$PricePerUnit"]);
                    m_Atom_ItemShopA_Price.EndPriceWithDiscountAndTax.set(dt_Item_Price.Rows[0]["Atom_ItemShopA_Price_$$EndPriceWithDiscountAndTax"]);
                    m_Atom_ItemShopA_Price.TAX.set(dt_Item_Price.Rows[0]["Atom_ItemShopA_Price_$$TAX"]);
                }

            }
        }


        public void SetMode(eMode mode)
        {
            switch (mode)
            {
                case eMode.VIEW:
                    this.splitContainer1.Panel1Collapsed = true;
                    if (dgvxc_btn_Remove != null)
                    {
                        this.dgvx_ShopA.Columns.Remove(dgvxc_btn_Remove);
                        dgvxc_btn_Remove.Dispose();
                        dgvxc_btn_Remove = null;
                    }
                    break;

                case eMode.EDIT:
                    this.splitContainer1.Panel1Collapsed = false;
                    SetDraft();
                    break;
            }

        }

        private void usrc_Editor1_Load(object sender, EventArgs e)
        {

        }
        /*
                        Atom_ItemShopA_Price.ID,
                                    Atom_ItemShopA_Price_$_pinv_$$ID,
                                    Atom_ItemShopA_Price_$_pinv_$$Draft,
                                    Atom_ItemShopA_Price_$_aisha_$$ID,
                                    Atom_ItemShopA_Price_$_aisha_$$Name,
                                    Atom_ItemShopA_Price_$_aisha_$$Description,
                                    Atom_ItemShopA_Price_$_aisha_$_tax_$$ID,
                                    Atom_ItemShopA_Price_$_aisha_$_tax_$$Name,
                                    Atom_ItemShopA_Price_$_aisha_$_tax_$$Rate,
                                    Atom_ItemShopA_Price_$_aisha_$_u_$$ID,
                                    Atom_ItemShopA_Price_$_aisha_$_u_$$Name,
                                    Atom_ItemShopA_Price_$_aisha_$_u_$$Symbol,
                                    Atom_ItemShopA_Price_$_aisha_$_u_$$DecimalPlaces,
                                    Atom_ItemShopA_Price_$$Discount,
                                    Atom_ItemShopA_Price_$$dQuantity,
                                    Atom_ItemShopA_Price_$$PricePerUnit,
                                    Atom_ItemShopA_Price_$$EndPriceWithDiscountAndTax,
                                    Atom_ItemShopA_Price_$$TAX
        */

        private void usrc_Editor1_AddRow(Atom_ItemShopA_Price m_Atom_ItemShopA_Price)
        {
            DataRow dr = dt_Item_Price.NewRow();
            dr["ID"] = m_Atom_ItemShopA_Price.ID.type_v.v;
            dr["Atom_ItemShopA_Price_$_pinv_$$ID"] = tf.type_v_ret(m_Atom_ItemShopA_Price.m_ProformaInvoice.ID.type_v);
            dr["Atom_ItemShopA_Price_$_pinv_$$Draft"] = 1;
            dr["Atom_ItemShopA_Price_$_aisha_$$Name"] = tf.type_v_ret(m_Atom_ItemShopA_Price.m_Atom_ItemShopA.Name.type_v);
            dr["Atom_ItemShopA_Price_$_aisha_$$Description"] = tf.type_v_ret(m_Atom_ItemShopA_Price.m_Atom_ItemShopA.Description.type_v);
            dr["Atom_ItemShopA_Price_$_aisha_$_tax_$$ID"] = tf.type_v_ret(m_Atom_ItemShopA_Price.m_Atom_ItemShopA.m_Taxation.ID.type_v);
            dr["Atom_ItemShopA_Price_$_aisha_$_tax_$$Name"] = tf.type_v_ret(m_Atom_ItemShopA_Price.m_Atom_ItemShopA.m_Taxation.Name.type_v);
            dr["Atom_ItemShopA_Price_$_aisha_$_tax_$$Rate"] = tf.type_v_ret(m_Atom_ItemShopA_Price.m_Atom_ItemShopA.m_Taxation.Rate.type_v);
            dr["Atom_ItemShopA_Price_$_aisha_$_u_$$ID"] = tf.type_v_ret(m_Atom_ItemShopA_Price.m_Atom_ItemShopA.m_Unit.ID.type_v);
            dr["Atom_ItemShopA_Price_$_aisha_$_u_$$Name"] = tf.type_v_ret(m_Atom_ItemShopA_Price.m_Atom_ItemShopA.m_Unit.Name.type_v);
            dr["Atom_ItemShopA_Price_$_aisha_$_u_$$Symbol"] = tf.type_v_ret(m_Atom_ItemShopA_Price.m_Atom_ItemShopA.m_Unit.Symbol.type_v);
            dr["Atom_ItemShopA_Price_$_aisha_$_u_$$DecimalPlaces"] = tf.type_v_ret(m_Atom_ItemShopA_Price.m_Atom_ItemShopA.m_Unit.DecimalPlaces.type_v);
            dr["Atom_ItemShopA_Price_$_aisha_$$ID"] = tf.type_v_ret(m_Atom_ItemShopA_Price.m_Atom_ItemShopA.ID.type_v);
            dr["Atom_ItemShopA_Price_$$Discount"] = tf.type_v_ret(m_Atom_ItemShopA_Price.Discount.type_v);
            dr["Atom_ItemShopA_Price_$$dQuantity"] = tf.type_v_ret(m_Atom_ItemShopA_Price.dQuantity.type_v);
            dr["Atom_ItemShopA_Price_$$PricePerUnit"] = tf.type_v_ret(m_Atom_ItemShopA_Price.PricePerUnit.type_v);
            dr["Atom_ItemShopA_Price_$$EndPriceWithDiscountAndTax"] = tf.type_v_ret(m_Atom_ItemShopA_Price.EndPriceWithDiscountAndTax.type_v);
            dr["Atom_ItemShopA_Price_$$TAX"] = tf.type_v_ret(m_Atom_ItemShopA_Price.TAX.type_v);
            dt_Item_Price.Rows.Add(dr);
            if (aa_ItemAdded != null)
            {
                aa_ItemAdded(m_Atom_ItemShopA_Price.ID.type_v.v, dt_Item_Price);
            }
        }

        private void dgvx_ShopA_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

            if ((e.ColumnIndex >= 0) && (e.RowIndex >= 0))
            {
                SetGridButtonState(this.dgvx_ShopA, e.RowIndex, e.ColumnIndex, PushButtonState.Normal);
                if (dgvx_ShopA.Columns[e.ColumnIndex].Name.Equals(column_deselect))
                {
                    ItemDeselect(e.RowIndex);
                }
            }
        }

        private void SetGridButtonState(DataGridView dgv, int rowIndex, int columnIndex, PushButtonState pushButtonState)
        {
            if ((rowIndex > -1) && (columnIndex > -1))
            {
                if (dgv.Columns[columnIndex].GetType().Equals(typeof(DataGridViewImageButtonColumn)))
                {
                    DataGridViewImageButtonCell buttonCell =
                        (DataGridViewImageButtonCell)dgv.
                        Rows[rowIndex].Cells[columnIndex];

                    if (buttonCell.Enabled)
                    {
                        buttonCell.ButtonState = pushButtonState;
                    }
                }
            }
        }

        private void ItemDeselect(int iSelectedItemRow)
        {
            DataRow dr = dt_Item_Price.Rows[iSelectedItemRow];
            long Atom_ItemShopA_Price_ID = (long) dr["ID"];
            if (dbfunc.delete(Atom_ItemShopA_Price_ID))
            {
                dt_Item_Price.Rows.Remove(dr);
            }
        }
    }
}
