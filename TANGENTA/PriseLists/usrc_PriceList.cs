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
using System.Windows.Forms;
using LanguageControl;
using TangentaDB;
using DBTypes;
using DBConnectionControl40;

namespace PriseLists
{
    public partial class usrc_PriceList : UserControl
    {
        int xPriceList_Count = 0;
        public ID m_Currency_ID = null;
        private usrc_PriceList_Edit.eShopType m_eShopType;

        public TangentaDB.xPriceList m_xPriceList = null;

        public delegate void delegate_PriceListChanged();
        public event delegate_PriceListChanged PriceListChanged = null;

        public delegate bool delegate_CheckAccess();
        public event delegate_CheckAccess CheckAccess = null;


        public usrc_PriceList()
        {
            InitializeComponent();
            lbl_PriceList.Text = lng.s_PriceList.s + ":";
        }

        public ID ID
        {
            get
            {
                object o_ID = cmb_PriceListType.SelectedValue;
                return tf.set_ID(o_ID);
            }
        }

       


        public bool Init(ID Currency_ID,usrc_PriceList_Edit.eShopType xeShopType,string ShopsInUse,  ref string Err)
        {
            this.cmb_PriceListType.SelectedIndexChanged -= new System.EventHandler(this.cmb_PriceListType_SelectedIndexChanged);
            m_eShopType = xeShopType;
            m_Currency_ID = Currency_ID;
            if (m_xPriceList == null)
            {
                m_xPriceList = new xPriceList();
            }


            if (m_xPriceList.Get_PriceLists_of_Currency(Currency_ID, ref xPriceList_Count, ref Err))
            {
                if (xPriceList_Count > 0)
                {
                    this.cmb_PriceListType.DataSource = m_xPriceList.List_xPriceList;
                    this.cmb_PriceListType.DisplayMember = "xPriceList_Name";
                    this.cmb_PriceListType.ValueMember = "xPriceList_ID";
                }
                this.cmb_PriceListType.SelectedIndexChanged += new System.EventHandler(this.cmb_PriceListType_SelectedIndexChanged);
                return true;
            }
            else
            {
                LogFile.Error.Show(Err);
                return false;
            }
        }

        private void btn_PriceListType_Click(object sender, EventArgs e)
        {
            if (CheckAccess!=null)
            {
                if (!CheckAccess())
                {
                    return;
                }
            }
            bool bPriceListChanged = false;
            this.Cursor = Cursors.WaitCursor;
            Control pctrl = null;
            if (this.Parent!=null)
            { 
                pctrl = this.Parent;
                pctrl.Cursor = Cursors.WaitCursor; 
            }
            NavigationButtons.Navigation nav_PriceList_Edit = new NavigationButtons.Navigation(null);
            nav_PriceList_Edit.m_eButtons = NavigationButtons.Navigation.eButtons.OkCancel;
            PriceList_Edit(false,  ref bPriceListChanged);
            this.Cursor = Cursors.Arrow;
            if (pctrl != null)
            {
                pctrl.Cursor = Cursors.Arrow;
            }
            if (bPriceListChanged)
            {
                if (PriceListChanged!=null)
                {
                    PriceListChanged();
                }
            }
        }

        public void PriceList_Edit(bool bEditUndefined, ref bool bChanged)
        {

            string Err = null;
            bChanged = false;
            int xPriceListType_Count = 0;
            Form_PriceList_Edit PriceList_Edit_dlg = new Form_PriceList_Edit(bEditUndefined, m_eShopType,null);
            if (PriceList_Edit_dlg.ShowDialog() == DialogResult.OK)
            {
                bChanged = PriceList_Edit_dlg.Changed;
                if (m_xPriceList.Get_PriceLists_of_Currency(m_Currency_ID, ref xPriceListType_Count, ref Err))
                {
                    if (xPriceListType_Count > 0)
                    {
                        cmb_PriceListType.DataSource = m_xPriceList.List_xPriceList;
                        cmb_PriceListType.DisplayMember = "xPriceList_Name";
                        cmb_PriceListType.ValueMember = "xPriceList_ID";
                    }
                }
                else
                {
                    LogFile.Error.Show(Err);
                }
            }
        }

        public static bool Ask_To_Update(char chShopType,DataTable dt_Item_NotIn_PriceList, Control pparent_ctrl)
        {
            Form_PriceList_NotComplete PriceList_NotComplete_Form_dlg = new Form_PriceList_NotComplete(chShopType, dt_Item_NotIn_PriceList, pparent_ctrl);
            if (pparent_ctrl != null)
            {
                if (pparent_ctrl is Form)
                {
                    PriceList_NotComplete_Form_dlg.TopMost = ((Form)pparent_ctrl).TopMost;
                }
            }
            if (PriceList_NotComplete_Form_dlg.ShowDialog(pparent_ctrl) == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void cmb_PriceListType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PriceListChanged != null)
            {
                PriceListChanged();
            }
        }
    }
}
