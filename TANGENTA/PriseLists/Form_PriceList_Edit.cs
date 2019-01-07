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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeTables;
using TangentaTableClass;
using LanguageControl;
using DBTypes;

namespace PriseLists
{
    public partial class Form_PriceList_Edit : Form
    {
        usrc_PriceList_Edit.eShopType m_eShopType;
        SQLTable m_tbl_PriceList = null;
        private bool bEditUndefined = false;
        NavigationButtons.Navigation nav = null;
        public bool Changed
        {
            get { return this.usrc_PriceList_Edit.Changed; }
        }


        public Form_PriceList_Edit(bool xbEditUndefined,usrc_PriceList_Edit.eShopType xeShopType,NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            if (xnav != null)
            {
                nav = xnav;
            }
            else
            {
                nav = new NavigationButtons.Navigation(null);
                nav.bDoModal = true;
                nav.m_eButtons = NavigationButtons.Navigation.eButtons.OkCancel;
            }
            m_eShopType = xeShopType;
            bEditUndefined = xbEditUndefined;
            m_tbl_PriceList = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(PriceList)));
            m_tbl_PriceList.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.DBT.items);
            this.Text = lng.s_PriceListType.s;
        }

        private bool Init()
        {
            
            m_tbl_PriceList.DeleteInputControls();
            if (this.usrc_PriceList_Edit.Init(m_tbl_PriceList,bEditUndefined, m_eShopType,nav))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void PriceListType_Edit_Form_Load(object sender, EventArgs e)
        {
            if (Init())
            {
            }
            else
            {
                Close();
                DialogResult = DialogResult.Abort;
            }
        }

        private void usrc_PriceListType_Edit_Button_Cancel_Click()
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void usrc_PriceListType_Edit_Button_OK_Click()
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }
    }
}
