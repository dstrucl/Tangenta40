﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SQLTableControl;
using BlagajnaTableClass;
using LanguageControl;

namespace Tangenta
{
    public partial class Form_PriceList_Edit : Form
    {
       
        SQLTable m_tbl_PriceList = null;
        private bool bEditUndefined = false;

        public Form_PriceList_Edit(bool xbEditUndefined)
        {
            InitializeComponent();

            bEditUndefined = xbEditUndefined;
            m_tbl_PriceList = new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(PriceList)));
            m_tbl_PriceList.CreateTableTree(DBSync.DBSync.DB_for_Blagajna.m_DBTables.items);
            this.Text = lngRPM.s_PriceListType.s;
        }
        private bool Init()
        {
            
            m_tbl_PriceList.DeleteInputControls();
            if (this.usrc_PriceList_Edit.Init(m_tbl_PriceList,bEditUndefined))
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