#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using BlagajnaTableClass;
using SQLTableControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopA
{
    public partial class Form_Tool_SelectItem : Form
    {
        public Atom_ItemShopA m_Atom_ItemShopA = null;
        DataTable dt_Atom_ItemShopA = new DataTable();
        usrc_Editor m_usrc_Editor = null;
        SQLTable t_Atom_ItemShopA = null;


        public Form_Tool_SelectItem(Atom_ItemShopA xAtom_ItemShopA, usrc_Editor xusrc_Editor)
        {
            InitializeComponent();
            m_Atom_ItemShopA = xAtom_ItemShopA;
            m_usrc_Editor = xusrc_Editor;
            t_Atom_ItemShopA = new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Atom_ItemShopA)));
        }

        public bool Reload()
        {
            this.dgvx_Item.SelectionChanged -= new System.EventHandler(this.dgvx_Item_SelectionChanged);
            string Err = null;
            string sql = @"SELECT
                ID,
                Atom_ItemShopA_$$Name,
                Atom_ItemShopA_$$Description,
                Atom_ItemShopA_$_tax_$$ID,
                Atom_ItemShopA_$_tax_$$Name,
                Atom_ItemShopA_$_tax_$$Rate,
                Atom_ItemShopA_$_u_$$ID,
                Atom_ItemShopA_$_u_$$Name,
                Atom_ItemShopA_$_u_$$Symbol,
                Atom_ItemShopA_$_u_$$DecimalPlaces,
                Atom_ItemShopA_$_u_$$StorageOption,
                Atom_ItemShopA_$_u_$$Description,
                Atom_ItemShopA_$_sup_$$ID,
                Atom_ItemShopA_$_sup_$_org_$$ID,
                Atom_ItemShopA_$_sup_$_org_$$Name,
                Atom_ItemShopA_$_sup_$_org_$$Tax_ID,
                Atom_ItemShopA_$_sup_$_org_$$Registration_ID
                FROM Atom_ItemShopA_VIEW
                where Atom_ItemShopA_$$VisibleForSelection = 1";
            dt_Atom_ItemShopA.Clear();
            this.dgvx_Item.DataSource = null;
            if (DBSync.DBSync.ReadDataTable(ref dt_Atom_ItemShopA,sql,ref Err))
            {
                this.dgvx_Item.DataSource = dt_Atom_ItemShopA;
                t_Atom_ItemShopA.SetVIEW_DataGridViewImageColumns_Headers((DataGridView)dgvx_Item, DBSync.DBSync.DB_for_Blagajna.m_DBTables);
                dgvx_Item.Columns["ID"].Visible = false;
                dgvx_Item.Columns["Atom_ItemShopA_$_tax_$$ID"].Visible = false;
                dgvx_Item.Columns["Atom_ItemShopA_$_u_$$ID"].Visible = false;
                dgvx_Item.Columns["Atom_ItemShopA_$_sup_$$ID"].Visible = false;
                dgvx_Item.Columns["Atom_ItemShopA_$_sup_$_org_$$ID"].Visible = false;
                dgvx_Item.ClearSelection();
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:Read_Atom_SimpleItem_Table:select ... from Atom_SimpleItem:\r\n Err=" + Err);
                return false;
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
                int iIndex = dgvx_Item.Rows.IndexOf(dgvr);
                m_Atom_ItemShopA.ID.set(dt_Atom_ItemShopA.Rows[iIndex]["ID"]);
                m_Atom_ItemShopA.Name.set(dt_Atom_ItemShopA.Rows[iIndex]["Atom_ItemShopA_$$Name"]);
                m_Atom_ItemShopA.Description.set(dt_Atom_ItemShopA.Rows[iIndex]["Atom_ItemShopA_$$Description"]);
                m_Atom_ItemShopA.m_Unit.ID.set(dt_Atom_ItemShopA.Rows[iIndex]["Atom_ItemShopA_$_u_$$ID"]);
                m_Atom_ItemShopA.m_Unit.Name.set(dt_Atom_ItemShopA.Rows[iIndex]["Atom_ItemShopA_$_u_$$Name"]);
                m_Atom_ItemShopA.m_Unit.Symbol.set(dt_Atom_ItemShopA.Rows[iIndex]["Atom_ItemShopA_$_u_$$Symbol"]);
                short decimal_places = 0;
                if (dt_Atom_ItemShopA.Rows[iIndex]["Atom_ItemShopA_$_u_$$DecimalPlaces"] is int)
                {
                    decimal_places = Convert.ToInt16(dt_Atom_ItemShopA.Rows[iIndex]["Atom_ItemShopA_$_u_$$DecimalPlaces"]);
                    m_Atom_ItemShopA.m_Unit.DecimalPlaces.set(decimal_places);
                }
                else if (dt_Atom_ItemShopA.Rows[iIndex]["Atom_ItemShopA_$_u_$$DecimalPlaces"] is System.DBNull)
                {
                    m_Atom_ItemShopA.m_Unit.DecimalPlaces.set(null);
                }
                
                m_usrc_Editor.SetControls(m_Atom_ItemShopA);
            }
        }

        private void Form_Tool_SelectItem_Shown(object sender, EventArgs e)
        {
            this.dgvx_Item.SelectionChanged += new System.EventHandler(this.dgvx_Item_SelectionChanged);
        }
    }
}
