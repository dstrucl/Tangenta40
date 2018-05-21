#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using TangentaTableClass;
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
using LanguageControl;

namespace ShopA
{
    public partial class Form_Tool_SelectItem : Form
    {
        public Atom_ItemShopA m_Atom_ItemShopA = null;
        public int iSelectedIndex = -1;
        DataTable dt_Atom_ItemShopA = new DataTable();
        usrc_Editor m_usrc_Editor = null;
        SQLTable t_Atom_ItemShopA = null;
        long dgSortingSelectedItem_ID = -1;

        public Form_Tool_SelectItem(Atom_ItemShopA xAtom_ItemShopA, usrc_Editor xusrc_Editor)
        {
            InitializeComponent();
            m_Atom_ItemShopA = xAtom_ItemShopA;
            m_usrc_Editor = xusrc_Editor;
            lng.s_Select_ShopA_Item.Text(this);
            t_Atom_ItemShopA = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Atom_ItemShopA)));
        }

        public bool Reload()
        {
            this.Owner.Cursor = Cursors.WaitCursor;
            dgvx_Item.CellMouseDown -= Dgvx_Item_CellMouseDown;
            dgvx_Item.Sorted -= Dgvx_Item_Sorted;
            this.dgvx_Item.SelectionChanged -= new System.EventHandler(this.dgvx_Item_SelectionChanged);
            string Err = null;
            //string sql = @"SELECT
            //    ID,
            //    Atom_ItemShopA_$$Name,
            //    Atom_ItemShopA_$$Description,
            //    Atom_ItemShopA_$_tax_$$ID,
            //    Atom_ItemShopA_$_tax_$$Name,
            //    Atom_ItemShopA_$_tax_$$Rate,
            //    Atom_ItemShopA_$_u_$$ID,
            //    Atom_ItemShopA_$_u_$$Name,
            //    Atom_ItemShopA_$_u_$$Symbol,
            //    Atom_ItemShopA_$_u_$$DecimalPlaces,
            //    Atom_ItemShopA_$_u_$$StorageOption,
            //    Atom_ItemShopA_$_u_$$Description,
            //    Atom_ItemShopA_$_sup_$$ID,
            //    Atom_ItemShopA_$_sup_$_c_$_orgd_$_org_$$ID,
            //    Atom_ItemShopA_$_sup_$_c_$_orgd_$_org_$$Name,
            //    Atom_ItemShopA_$_sup_$_c_$_orgd_$_org_$$Tax_ID,
            //    Atom_ItemShopA_$_sup_$_c_$_orgd_$_org_$$Registration_ID
            //    FROM Atom_ItemShopA_VIEW
            //    where Atom_ItemShopA_$$VisibleForSelection = 1";

            string sql = @"SELECT
            Atom_ItemShopA.ID,
            Atom_ItemShopA.Name AS Atom_ItemShopA_$$Name,
            Atom_ItemShopA.Description AS Atom_ItemShopA_$$Description,
            Atom_ItemShopA_$_tax.ID AS Atom_ItemShopA_$_tax_$$ID,
            Atom_ItemShopA_$_tax.Name AS Atom_ItemShopA_$_tax_$$Name,
            Atom_ItemShopA_$_tax.Rate AS Atom_ItemShopA_$_tax_$$Rate,
            Atom_ItemShopA_$_u.ID AS Atom_ItemShopA_$_u_$$ID,
            Atom_ItemShopA_$_u.Name AS Atom_ItemShopA_$_u_$$Name,
            Atom_ItemShopA_$_u.Symbol AS Atom_ItemShopA_$_u_$$Symbol,
             Atom_ItemShopA_$_u.DecimalPlaces AS Atom_ItemShopA_$_u_$$DecimalPlaces,
             Atom_ItemShopA_$_u.StorageOption AS Atom_ItemShopA_$_u_$$StorageOption,
             Atom_ItemShopA_$_u.Description AS Atom_ItemShopA_$_u_$$Description,
             Atom_ItemShopA_$_sup.ID AS Atom_ItemShopA_$_sup_$$ID,
             Atom_ItemShopA_$_sup_$_c_$_orgd_$_org.ID AS Atom_ItemShopA_$_sup_$_c_$_orgd_$_org_$$ID,
             Atom_ItemShopA_$_sup_$_c_$_orgd_$_org.Name AS Atom_ItemShopA_$_sup_$_c_$_orgd_$_org_$$Name,
             Atom_ItemShopA_$_sup_$_c_$_orgd_$_org.Tax_ID AS Atom_ItemShopA_$_sup_$_c_$_orgd_$_org_$$Tax_ID,
             Atom_ItemShopA_$_sup_$_c_$_orgd_$_org.Registration_ID AS Atom_ItemShopA_$_sup_$_c_$_orgd_$_org_$$Registration_ID
             FROM Atom_ItemShopA
             INNER JOIN Taxation Atom_ItemShopA_$_tax ON Atom_ItemShopA.Taxation_ID = Atom_ItemShopA_$_tax.ID
             LEFT JOIN Unit Atom_ItemShopA_$_u ON Atom_ItemShopA.Unit_ID = Atom_ItemShopA_$_u.ID
             LEFT JOIN Supplier Atom_ItemShopA_$_sup ON Atom_ItemShopA.Supplier_ID = Atom_ItemShopA_$_sup.ID
             LEFT JOIN Contact Atom_ItemShopA_$_sup_$_c ON Atom_ItemShopA_$_sup.Contact_ID = Atom_ItemShopA_$_sup_$_c.ID
             LEFT JOIN OrganisationData Atom_ItemShopA_$_sup_$_c_$_orgd ON Atom_ItemShopA_$_sup_$_c.OrganisationData_ID = Atom_ItemShopA_$_sup_$_c_$_orgd.ID
             LEFT JOIN Organisation Atom_ItemShopA_$_sup_$_c_$_orgd_$_org ON Atom_ItemShopA_$_sup_$_c_$_orgd.Organisation_ID = Atom_ItemShopA_$_sup_$_c_$_orgd_$_org.ID
             where Atom_ItemShopA.VisibleForSelection = 1";

            dt_Atom_ItemShopA.Clear();
            this.dgvx_Item.DataSource = null;
            if (DBSync.DBSync.ReadDataTable(ref dt_Atom_ItemShopA,sql,ref Err))
            {
                this.dgvx_Item.DataSource = dt_Atom_ItemShopA;
                t_Atom_ItemShopA.SetVIEW_DataGridViewImageColumns_Headers((DataGridView)dgvx_Item, DBSync.DBSync.DB_for_Tangenta.m_DBTables);
                dgvx_Item.Columns["ID"].Visible = false;
                dgvx_Item.Columns["Atom_ItemShopA_$_tax_$$ID"].Visible = false;
                dgvx_Item.Columns["Atom_ItemShopA_$_u_$$ID"].Visible = false;
                dgvx_Item.Columns["Atom_ItemShopA_$_sup_$$ID"].Visible = false;
                dgvx_Item.Columns["Atom_ItemShopA_$_sup_$_c_$_orgd_$_org_$$ID"].Visible = false;
                dgvx_Item.ClearSelection();
                this.Owner.Cursor = Cursors.Arrow;
                dgvx_Item.CellMouseDown += Dgvx_Item_CellMouseDown;
                dgvx_Item.Sorted += Dgvx_Item_Sorted;
                this.dgvx_Item.SelectionChanged += new System.EventHandler(this.dgvx_Item_SelectionChanged);
                return true;
            }
            else
            {
                this.Owner.Cursor = Cursors.Arrow;
                LogFile.Error.Show("ERROR:Read_Atom_SimpleItem_Table:select ... from Atom_SimpleItem:\r\n Err=" + Err);
                return false;
            }
        }

        private void Dgvx_Item_Sorted(object sender, EventArgs e)
        {
            if (dgSortingSelectedItem_ID >= 0)
            {
                foreach (DataGridViewRow dgRow in dgvx_Item.Rows)
                {
                    //Locate the row after the sort
                    string cellid = "ID";

                    if ((long)dgRow.Cells[cellid].Value == dgSortingSelectedItem_ID)
                    {
                        //Clear the datagridview selections
                        dgvx_Item.ClearSelection();
                        //Select the row at its new position
                        dgRow.Selected = true;
                        //Set currentcell using the 1st cell of the row in its new position
                        dgvx_Item.CurrentCell = dgRow.Cells["Atom_ItemShopA_$$Name"];
                        //Exit the routine
                        break;
                    }
                }
                dgSortingSelectedItem_ID = -1;
            }
        }

        private void Dgvx_Item_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //If a column header was clicked
            if ((e.RowIndex == -1) && (e.ColumnIndex >= 0))
            {
                //And a row is selected
                if (!(dgvx_Item.SelectedRows.Count == 0))
                {
                    //Record the unique value from the column called "Name"

                    string cellid = "ID";

                    dgSortingSelectedItem_ID = (long)dgvx_Item.SelectedRows[0].Cells[cellid].Value;
                }
            }
        }

        private void Form_Tool_SelectItem_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void Form_Tool_SelectItem_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_usrc_Editor.Form_Tool_SelectItem_FormClosed();
        }

        private void dgvx_Item_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgvrcol = dgvx_Item.SelectedRows;
            if (dgvrcol.Count==1)
            {
                DataGridViewRow dgvr = dgvrcol[0];
                m_Atom_ItemShopA.ID.set(dgvr.Cells["ID"].Value);
                m_Atom_ItemShopA.Name.set(dgvr.Cells["Atom_ItemShopA_$$Name"].Value);
                m_Atom_ItemShopA.Description.set(dgvr.Cells["Atom_ItemShopA_$$Description"].Value);
                m_Atom_ItemShopA.m_Unit.ID.set(dgvr.Cells["Atom_ItemShopA_$_u_$$ID"].Value);
                m_Atom_ItemShopA.m_Unit.Name.set(dgvr.Cells["Atom_ItemShopA_$_u_$$Name"].Value);
                m_Atom_ItemShopA.m_Unit.Symbol.set(dgvr.Cells["Atom_ItemShopA_$_u_$$Symbol"].Value);
                short decimal_places = 0;
                if (dgvr.Cells["Atom_ItemShopA_$_u_$$DecimalPlaces"].Value is int)
                {
                    decimal_places = Convert.ToInt16(dgvr.Cells["Atom_ItemShopA_$_u_$$DecimalPlaces"].Value);
                    m_Atom_ItemShopA.m_Unit.DecimalPlaces.set(decimal_places);
                }
                else if (dgvr.Cells["Atom_ItemShopA_$_u_$$DecimalPlaces"].Value is System.DBNull)
                {
                    m_Atom_ItemShopA.m_Unit.DecimalPlaces.set(null);
                }
                
                m_usrc_Editor.SetControls(m_Atom_ItemShopA);
            }
        }

        private void Form_Tool_SelectItem_Shown(object sender, EventArgs e)
        {
            dgvx_Item.ClearSelection();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (dgvx_Item.SelectedRows.Count>0)
            {
                DataGridViewSelectedRowCollection dgvrc = dgvx_Item.SelectedRows;
                iSelectedIndex = dgvrc[0].Index;

                m_Atom_ItemShopA.ID.set(dt_Atom_ItemShopA.Rows[iSelectedIndex]["ID"]);
                m_Atom_ItemShopA.Name.set(dt_Atom_ItemShopA.Rows[iSelectedIndex]["Atom_ItemShopA_$$Name"]);
                m_Atom_ItemShopA.Description.set(dt_Atom_ItemShopA.Rows[iSelectedIndex]["Atom_ItemShopA_$$Description"]);
                m_Atom_ItemShopA.m_Unit.ID.set(dt_Atom_ItemShopA.Rows[iSelectedIndex]["Atom_ItemShopA_$_u_$$ID"]);
                m_Atom_ItemShopA.m_Unit.Name.set(dt_Atom_ItemShopA.Rows[iSelectedIndex]["Atom_ItemShopA_$_u_$$Name"]);
                m_Atom_ItemShopA.m_Unit.Symbol.set(dt_Atom_ItemShopA.Rows[iSelectedIndex]["Atom_ItemShopA_$_u_$$Symbol"]);
                short decimal_places = 0;
                if (dt_Atom_ItemShopA.Rows[iSelectedIndex]["Atom_ItemShopA_$_u_$$DecimalPlaces"] is int)
                {
                    decimal_places = Convert.ToInt16(dt_Atom_ItemShopA.Rows[iSelectedIndex]["Atom_ItemShopA_$_u_$$DecimalPlaces"]);
                    m_Atom_ItemShopA.m_Unit.DecimalPlaces.set(decimal_places);
                }
                else if (dt_Atom_ItemShopA.Rows[iSelectedIndex]["Atom_ItemShopA_$_u_$$DecimalPlaces"] is System.DBNull)
                {
                    m_Atom_ItemShopA.m_Unit.DecimalPlaces.set(null);
                }

                this.Close();
                DialogResult = DialogResult.OK;

            }
        }
    }
}
