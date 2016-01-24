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

namespace ShopA
{
    public partial class usrc_ShopA: UserControl
    {
        private const string column_deselect = "deselect";
        DataGridViewImageButtonColumn dgvxc_btn_Remove = null;

        public enum eMode { VIEW, EDIT };
        ShopABC m_ShopBC = null;
        DBTablesAndColumnNames DBtcn = null;
        DataTable dt_Item_Price = new DataTable();
        Atom_ItemShopA_Price m_Atom_ItemShopA_Price = new Atom_ItemShopA_Price();
        SQLTable t_Atom_ItemShopA_Price = null;

        public usrc_ShopA()
        {
            InitializeComponent();
            t_Atom_ItemShopA_Price = new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Atom_ItemShopA_Price)));
        }

        public void Init(ShopABC xm_ShopBC, DBTablesAndColumnNames xDBtcn)
        {
            m_ShopBC = xm_ShopBC;
            DBtcn = xDBtcn;
            dt_Item_Price.Clear();
            if (dbfunc.ReadItems(ref dt_Item_Price, ref m_Atom_ItemShopA_Price, m_ShopBC.m_CurrentInvoice.ProformaInvoice_ID))
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
            }

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
                this.usrc_Editor1.Init(m_ShopBC, m_Atom_ItemShopA_Price);
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
    }
}
