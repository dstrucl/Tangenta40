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
using ShopA_dbfunc;
using TangentaTableClass;
using CodeTables;
using DBTypes;
using System.Windows.Forms.VisualStyles;

namespace ShopA
{
    public partial class usrc_ShopA : UserControl
    {
        public delegate void delegate_aa_ItemAdded(long ID, DataTable dt);
        public event delegate_aa_ItemAdded aa_ItemAdded = null;
        public delegate void delegate_ItemRemoved(long ID, DataTable dt);
        public event delegate_ItemRemoved aa_ItemRemoved = null;

        public delegate bool delegate_EditUnis();
        public event delegate_EditUnis EditUnits;


        private const string column_deselect = "deselect";
        DataGridViewImageButtonColumn dgvxc_btn_Remove = null;

        public enum eMode { VIEW, EDIT };
        ShopABC m_ShopABC = null;
        DBTablesAndColumnNames DBtcn = null;
        public DataTable dt_Item_Price = new DataTable();
        DocInvoice_ShopA_Item m_DocInvoice_ShopA_Item = new DocInvoice_ShopA_Item();
        SQLTable t_DocInvoice_ShopA_Item = null;

        private string m_DocInvoice = "DocInvoice";

        public string DocInvoice
        {
            get { return m_DocInvoice; }
            set
            {
                m_DocInvoice = value;
                if (usrc_Editor1!=null)
                {
                    usrc_Editor1.DocInvoice = m_DocInvoice;
                }
            }
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


        public usrc_ShopA()
        {
            InitializeComponent();
            t_DocInvoice_ShopA_Item = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(DocInvoice_ShopA_Item)));
        }

        public void Init(ShopABC xm_ShopABC, DBTablesAndColumnNames xDBtcn)
        {
            m_ShopABC = xm_ShopABC;
            DBtcn = xDBtcn;

        }

        public void SetView()
        {
            if (dgvxc_btn_Remove != null)
            {
                this.dgvx_ShopA.Columns.Remove(dgvxc_btn_Remove);
                dgvxc_btn_Remove.Dispose();
                dgvxc_btn_Remove = null;
            }
            dt_Item_Price.Clear();
            this.dgvx_ShopA.DataSource = null;
            long xDocInvoice_ID = m_ShopABC.m_CurrentInvoice.DocInvoice_ID;
            if (IsDocInvoice)
            {
                if (m_ShopABC.m_CurrentInvoice.TInvoice.StornoDocInvoice_ID_v != null)
                {
                    xDocInvoice_ID = m_ShopABC.m_CurrentInvoice.TInvoice.StornoDocInvoice_ID_v.v;
                }
            }
            if (dbfunc.Read_ShopA_Price_Item_Table(DocInvoice,xDocInvoice_ID, ref dt_Item_Price))
            {
                this.dgvx_ShopA.DataSource = dt_Item_Price;
                t_DocInvoice_ShopA_Item.SetVIEW_DataGridViewImageColumns_Headers((DataGridView)dgvx_ShopA, DBSync.DBSync.DB_for_Tangenta.m_DBTables);
                HideNotImportantColumns();
            }
        }

        private void HideNotImportantColumns()
        {
            this.dgvx_ShopA.Columns["ID"].Visible = false;
            if (IsDocInvoice)
            {
                this.dgvx_ShopA.Columns["DocInvoice_ShopA_Item_$_dinv_$$ID"].Visible = false;
                this.dgvx_ShopA.Columns["DocInvoice_ShopA_Item_$_aisha_$_tax_$$ID"].Visible = false;
                this.dgvx_ShopA.Columns["DocInvoice_ShopA_Item_$_aisha_$_u_$$ID"].Visible = false;
                this.dgvx_ShopA.Columns["DocInvoice_ShopA_Item_$_aisha_$$ID"].Visible = false;
                this.dgvx_ShopA.Columns["DocInvoice_ShopA_Item_$_dinv_$$Draft"].Visible = false;
                this.dgvx_ShopA.Columns["DocInvoice_ShopA_Item_$_aisha_$_u_$$Symbol"].Visible = false;
                this.dgvx_ShopA.Columns["DocInvoice_ShopA_Item_$_aisha_$_u_$$DecimalPlaces"].Visible = false;
            }
            else if (IsDocProformaInvoice)
            {
                this.dgvx_ShopA.Columns["DocProformaInvoice_ShopA_Item_$_dpinv_$$ID"].Visible = false;
                this.dgvx_ShopA.Columns["DocProformaInvoice_ShopA_Item_$_aisha_$_tax_$$ID"].Visible = false;
                this.dgvx_ShopA.Columns["DocProformaInvoice_ShopA_Item_$_aisha_$_u_$$ID"].Visible = false;
                this.dgvx_ShopA.Columns["DocProformaInvoice_ShopA_Item_$_aisha_$$ID"].Visible = false;
                this.dgvx_ShopA.Columns["DocProformaInvoice_ShopA_Item_$_dpinv_$$Draft"].Visible = false;
                this.dgvx_ShopA.Columns["DocProformaInvoice_ShopA_Item_$_aisha_$_u_$$Symbol"].Visible = false;
                this.dgvx_ShopA.Columns["DocProformaInvoice_ShopA_Item_$_aisha_$_u_$$DecimalPlaces"].Visible = false;
            }
        }

        public void SetDraft()
        {
            dt_Item_Price.Clear();
            this.dgvx_ShopA.DataSource = null;
            if (dbfunc.Read_ShopA_Price_Item_Table(DocInvoice,m_ShopABC.m_CurrentInvoice.DocInvoice_ID,ref dt_Item_Price))
            {
                this.dgvx_ShopA.DataSource = dt_Item_Price;
                t_DocInvoice_ShopA_Item.SetVIEW_DataGridViewImageColumns_Headers((DataGridView)dgvx_ShopA, DBSync.DBSync.DB_for_Tangenta.m_DBTables);
                HideNotImportantColumns();

                if (dt_Item_Price.Rows.Count > 0)
                {
                    object oDecimalPlaces = null;
                    if (IsDocInvoice)
                    {
                        oDecimalPlaces = dt_Item_Price.Rows[0]["DocInvoice_ShopA_Item_$_aisha_$_u_$$DecimalPlaces"];
                    }
                    else if (IsDocProformaInvoice)
                    {
                        oDecimalPlaces = dt_Item_Price.Rows[0]["DocProformaInvoice_ShopA_Item_$_aisha_$_u_$$DecimalPlaces"];
                    }
                    if ((oDecimalPlaces is int)||(oDecimalPlaces is short))
                    {
                        oDecimalPlaces = Convert.ToInt16(oDecimalPlaces);
                    }
                    else
                    {
                        oDecimalPlaces = null;
                    }

                    m_DocInvoice_ShopA_Item.ID.type_v = tf.set_long(dt_Item_Price.Rows[0]["ID"]);
                    if (IsDocInvoice)
                    {
                        m_DocInvoice_ShopA_Item.m_DocInvoice.ID.set(dt_Item_Price.Rows[0]["DocInvoice_ShopA_Item_$_dinv_$$ID"]);
                        m_DocInvoice_ShopA_Item.m_DocInvoice.Draft.set(dt_Item_Price.Rows[0]["DocInvoice_ShopA_Item_$_dinv_$$Draft"]);
                        m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.ID.set(dt_Item_Price.Rows[0]["DocInvoice_ShopA_Item_$_aisha_$$ID"]);
                        m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.Name.set(dt_Item_Price.Rows[0]["DocInvoice_ShopA_Item_$_aisha_$$Name"]);
                        m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.Name.set(dt_Item_Price.Rows[0]["DocInvoice_ShopA_Item_$_aisha_$$Description"]);
                        m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.m_Taxation.ID.set(dt_Item_Price.Rows[0]["DocInvoice_ShopA_Item_$_aisha_$_tax_$$ID"]);
                        m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.m_Taxation.Name.set(dt_Item_Price.Rows[0]["DocInvoice_ShopA_Item_$_aisha_$_tax_$$Name"]);
                        m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.m_Taxation.Rate.set(dt_Item_Price.Rows[0]["DocInvoice_ShopA_Item_$_aisha_$_tax_$$Rate"]);
                        m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.m_Unit.ID.set(dt_Item_Price.Rows[0]["DocInvoice_ShopA_Item_$_aisha_$_u_$$ID"]);
                        m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.m_Unit.Name.set(dt_Item_Price.Rows[0]["DocInvoice_ShopA_Item_$_aisha_$_u_$$Name"]);
                        m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.m_Unit.Symbol.set(dt_Item_Price.Rows[0]["DocInvoice_ShopA_Item_$_aisha_$_u_$$Symbol"]);
                        m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.m_Unit.DecimalPlaces.set(oDecimalPlaces);
                        m_DocInvoice_ShopA_Item.Discount.set(dt_Item_Price.Rows[0]["DocInvoice_ShopA_Item_$$Discount"]);
                        m_DocInvoice_ShopA_Item.dQuantity.set(dt_Item_Price.Rows[0]["DocInvoice_ShopA_Item_$$dQuantity"]);
                        m_DocInvoice_ShopA_Item.PricePerUnit.set(dt_Item_Price.Rows[0]["DocInvoice_ShopA_Item_$$PricePerUnit"]);
                        m_DocInvoice_ShopA_Item.EndPriceWithDiscountAndTax.set(dt_Item_Price.Rows[0]["DocInvoice_ShopA_Item_$$EndPriceWithDiscountAndTax"]);
                        m_DocInvoice_ShopA_Item.TAX.set(dt_Item_Price.Rows[0]["DocInvoice_ShopA_Item_$$TAX"]);
                    }
                    else if (IsDocProformaInvoice)
                    {
                        m_DocInvoice_ShopA_Item.m_DocInvoice.ID.set(dt_Item_Price.Rows[0]["DocProformaInvoice_ShopA_Item_$_dpinv_$$ID"]);
                        m_DocInvoice_ShopA_Item.m_DocInvoice.Draft.set(dt_Item_Price.Rows[0]["DocProformaInvoice_ShopA_Item_$_dpinv_$$Draft"]);
                        m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.ID.set(dt_Item_Price.Rows[0]["DocProformaInvoice_ShopA_Item_$_aisha_$$ID"]);
                        m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.Name.set(dt_Item_Price.Rows[0]["DocProformaInvoice_ShopA_Item_$_aisha_$$Name"]);
                        m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.Name.set(dt_Item_Price.Rows[0]["DocProformaInvoice_ShopA_Item_$_aisha_$$Description"]);
                        m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.m_Taxation.ID.set(dt_Item_Price.Rows[0]["DocProformaInvoice_ShopA_Item_$_aisha_$_tax_$$ID"]);
                        m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.m_Taxation.Name.set(dt_Item_Price.Rows[0]["DocProformaInvoice_ShopA_Item_$_aisha_$_tax_$$Name"]);
                        m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.m_Taxation.Rate.set(dt_Item_Price.Rows[0]["DocProformaInvoice_ShopA_Item_$_aisha_$_tax_$$Rate"]);
                        m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.m_Unit.ID.set(dt_Item_Price.Rows[0]["DocProformaInvoice_ShopA_Item_$_aisha_$_u_$$ID"]);
                        m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.m_Unit.Name.set(dt_Item_Price.Rows[0]["DocProformaInvoice_ShopA_Item_$_aisha_$_u_$$Name"]);
                        m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.m_Unit.Symbol.set(dt_Item_Price.Rows[0]["DocProformaInvoice_ShopA_Item_$_aisha_$_u_$$Symbol"]);
                        m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.m_Unit.DecimalPlaces.set(oDecimalPlaces);
                        m_DocInvoice_ShopA_Item.Discount.set(dt_Item_Price.Rows[0]["DocProformaInvoice_ShopA_Item_$$Discount"]);
                        m_DocInvoice_ShopA_Item.dQuantity.set(dt_Item_Price.Rows[0]["DocProformaInvoice_ShopA_Item_$$dQuantity"]);
                        m_DocInvoice_ShopA_Item.PricePerUnit.set(dt_Item_Price.Rows[0]["DocProformaInvoice_ShopA_Item_$$PricePerUnit"]);
                        m_DocInvoice_ShopA_Item.EndPriceWithDiscountAndTax.set(dt_Item_Price.Rows[0]["DocProformaInvoice_ShopA_Item_$$EndPriceWithDiscountAndTax"]);
                        m_DocInvoice_ShopA_Item.TAX.set(dt_Item_Price.Rows[0]["DocProformaInvoice_ShopA_Item_$$TAX"]);
                    }
                }
                if (dgvxc_btn_Remove == null)
                {
                    dgvxc_btn_Remove = new DataGridViewImageButtonColumn();
                    dgvxc_btn_Remove.HeaderText = "Odstrani";
                    dgvxc_btn_Remove.Text = "-";
                    dgvxc_btn_Remove.Name = column_deselect;
                    this.dgvx_ShopA.Columns.Add(dgvxc_btn_Remove);
                    this.usrc_Editor1.Init(m_ShopABC, m_DocInvoice_ShopA_Item);
                }


            }
        }


        public void SetMode(eMode mode)
        {
            switch (mode)
            {
                case eMode.VIEW:
                    this.splitContainer1.Panel1Collapsed = true;
                    SetView();
                    break;

                case eMode.EDIT:
                    this.splitContainer1.Panel1Collapsed = false;
                    SetDraft();
                    break;
            }

        }

        private void usrc_Editor1_AddRow(DocInvoice_ShopA_Item m_DocInvoice_ShopA_Item)
        {
            DataRow dr = dt_Item_Price.NewRow();
            dr["ID"] = m_DocInvoice_ShopA_Item.ID.type_v.v;
            if (IsDocInvoice)
            {
                dr["DocInvoice_ShopA_Item_$_dinv_$$ID"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.m_DocInvoice.ID.type_v);
                dr["DocInvoice_ShopA_Item_$_dinv_$$Draft"] = 1;
                dr["DocInvoice_ShopA_Item_$_aisha_$$Name"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.Name.type_v);
                dr["DocInvoice_ShopA_Item_$_aisha_$$Description"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.Description.type_v);
                dr["DocInvoice_ShopA_Item_$_aisha_$_tax_$$ID"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.m_Taxation.ID.type_v);
                dr["DocInvoice_ShopA_Item_$_aisha_$_tax_$$Name"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.m_Taxation.Name.type_v);
                dr["DocInvoice_ShopA_Item_$_aisha_$_tax_$$Rate"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.m_Taxation.Rate.type_v);
                dr["DocInvoice_ShopA_Item_$_aisha_$_u_$$ID"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.m_Unit.ID.type_v);
                dr["DocInvoice_ShopA_Item_$_aisha_$_u_$$Name"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.m_Unit.Name.type_v);
                dr["DocInvoice_ShopA_Item_$_aisha_$_u_$$Symbol"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.m_Unit.Symbol.type_v);
                dr["DocInvoice_ShopA_Item_$_aisha_$_u_$$DecimalPlaces"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.m_Unit.DecimalPlaces.type_v);
                dr["DocInvoice_ShopA_Item_$_aisha_$$ID"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.ID.type_v);
                dr["DocInvoice_ShopA_Item_$$Discount"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.Discount.type_v);
                dr["DocInvoice_ShopA_Item_$$dQuantity"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.dQuantity.type_v);
                dr["DocInvoice_ShopA_Item_$$PricePerUnit"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.PricePerUnit.type_v);
                dr["DocInvoice_ShopA_Item_$$EndPriceWithDiscountAndTax"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.EndPriceWithDiscountAndTax.type_v);
                dr["DocInvoice_ShopA_Item_$$TAX"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.TAX.type_v);
            }
            else if (IsDocProformaInvoice)
            {
                dr["DocProformaInvoice_ShopA_Item_$_dpinv_$$ID"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.m_DocInvoice.ID.type_v);
                dr["DocProformaInvoice_ShopA_Item_$_dpinv_$$Draft"] = 1;
                dr["DocProformaInvoice_ShopA_Item_$_aisha_$$Name"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.Name.type_v);
                dr["DocProformaInvoice_ShopA_Item_$_aisha_$$Description"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.Description.type_v);
                dr["DocProformaInvoice_ShopA_Item_$_aisha_$_tax_$$ID"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.m_Taxation.ID.type_v);
                dr["DocProformaInvoice_ShopA_Item_$_aisha_$_tax_$$Name"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.m_Taxation.Name.type_v);
                dr["DocProformaInvoice_ShopA_Item_$_aisha_$_tax_$$Rate"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.m_Taxation.Rate.type_v);
                dr["DocProformaInvoice_ShopA_Item_$_aisha_$_u_$$ID"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.m_Unit.ID.type_v);
                dr["DocProformaInvoice_ShopA_Item_$_aisha_$_u_$$Name"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.m_Unit.Name.type_v);
                dr["DocProformaInvoice_ShopA_Item_$_aisha_$_u_$$Symbol"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.m_Unit.Symbol.type_v);
                dr["DocProformaInvoice_ShopA_Item_$_aisha_$_u_$$DecimalPlaces"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.m_Unit.DecimalPlaces.type_v);
                dr["DocProformaInvoice_ShopA_Item_$_aisha_$$ID"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.ID.type_v);
                dr["DocProformaInvoice_ShopA_Item_$$Discount"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.Discount.type_v);
                dr["DocProformaInvoice_ShopA_Item_$$dQuantity"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.dQuantity.type_v);
                dr["DocProformaInvoice_ShopA_Item_$$PricePerUnit"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.PricePerUnit.type_v);
                dr["DocProformaInvoice_ShopA_Item_$$EndPriceWithDiscountAndTax"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.EndPriceWithDiscountAndTax.type_v);
                dr["DocProformaInvoice_ShopA_Item_$$TAX"] = tf.type_v_ret(m_DocInvoice_ShopA_Item.TAX.type_v);

            }
            dt_Item_Price.Rows.Add(dr);
            if (aa_ItemAdded != null)
            {
                aa_ItemAdded(m_DocInvoice_ShopA_Item.ID.type_v.v, dt_Item_Price);
            }
        }

        private void dgvx_ShopA_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

            if ((e.ColumnIndex >= 0) && (e.RowIndex >= 0))
            {
                SetGridButtonCountry(this.dgvx_ShopA, e.RowIndex, e.ColumnIndex, PushButtonState.Normal);
                if (dgvx_ShopA.Columns[e.ColumnIndex].Name.Equals(column_deselect))
                {
                    ItemDeselect(e.RowIndex);
                }
            }
        }

        private void SetGridButtonCountry(DataGridView dgv, int rowIndex, int columnIndex, PushButtonState pushButtonState)
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
            long DocInvoice_ShopA_Item_ID = (long) dr["ID"];
            if (dbfunc.delete(DocInvoice,DocInvoice_ShopA_Item_ID))
            {
                dt_Item_Price.Rows.Remove(dr);
                if (aa_ItemRemoved!=null)
                {
                    aa_ItemRemoved(DocInvoice_ShopA_Item_ID, dt_Item_Price);
                }
            }
        }

        private bool usrc_Editor1_EditUnits()
        {
            if (EditUnits!=null)
            {
                return EditUnits();
            }
            return false;
        }
    }
}
