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

namespace PriseLists
{
    public partial class usrc_PriceList : UserControl
    {
        int xPriceList_Count = 0;
        public long m_Currency_ID = -1;
        private usrc_PriceList_Edit.eShopType m_eShopType;

        public TangentaDB.xPriceList m_xPriceList = null;

        public usrc_PriceList()
        {
            InitializeComponent();
            lbl_PriceList.Text = lngRPM.s_PriceList.s + ":";
        }

        public long ID
        {
            get
            {
                object o_ID = cmb_PriceListType.SelectedValue;
                if (o_ID != null)
                {
                    if (o_ID.GetType() == typeof(long))
                    {
                        return (long)o_ID;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:PriceList_ID is not selected!");
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
        }


        public bool Init(long Currency_ID,usrc_PriceList_Edit.eShopType xeShopType,string ShopsInUse, NavigationButtons.Navigation xnav, ref string Err)
        {
            m_eShopType = xeShopType;
            m_Currency_ID = Currency_ID;
            if (m_xPriceList == null)
            {
                m_xPriceList = new xPriceList();
            }

            if (xnav != null)
            {
                if (xnav.LastStartupDialog_TYPE.Equals("TangentaSampleDB.Form_Items_Samples"))
                {
                    return DoEditPriceList(Currency_ID, xnav, ref Err);
                }
            }

            if (m_xPriceList.Get_PriceLists_of_Currency(Currency_ID, ref xPriceList_Count, ref Err))
            {
                if (xPriceList_Count > 0)
                {
                    this.cmb_PriceListType.DataSource = m_xPriceList.List_xPriceList;
                    this.cmb_PriceListType.DisplayMember = "xPriceList_Name";
                    this.cmb_PriceListType.ValueMember = "xPriceList_ID";
                }

                else
                {
                    bool bAsk = ((ShopsInUse.Contains("B") && (xeShopType == usrc_PriceList_Edit.eShopType.ShopB) ) || ((ShopsInUse.Contains("C") && (xeShopType == usrc_PriceList_Edit.eShopType.ShopC))));
                    if (bAsk)
                    {
                        bool bDialogResult = true;
                        if (xnav.m_eButtons == NavigationButtons.Navigation.eButtons.PrevNextExit)
                        {
                            bDialogResult = true;
                        }
                        else
                        {
                            bDialogResult = XMessage.Box.ShowTopMost(this, lngRPM.s_NoPriceList_AskToCreatePriceList, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
                        }
                        if (bDialogResult)
                        {
                            return DoEditPriceList(Currency_ID, xnav, ref Err);
                        }
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show(Err);
                return false;
            }
        }

        private bool DoEditPriceList(long Currency_ID,NavigationButtons.Navigation xnav, ref string Err)
        {
            Form_PriceList_Edit PriceListType_Edit_dlg = null;
            NavigationButtons.Navigation nav_Form_PriceList_Edit = null;
            if (xnav == null)
            {
                nav_Form_PriceList_Edit = new NavigationButtons.Navigation();
                nav_Form_PriceList_Edit.bDoModal = true;
                nav_Form_PriceList_Edit.m_eButtons = NavigationButtons.Navigation.eButtons.OkCancel;
                PriceListType_Edit_dlg = new Form_PriceList_Edit(false, m_eShopType, nav_Form_PriceList_Edit);
                nav_Form_PriceList_Edit.ChildDialog = PriceListType_Edit_dlg;
            }
            else
            {
                nav_Form_PriceList_Edit = xnav;
                if (nav_Form_PriceList_Edit.m_eButtons == NavigationButtons.Navigation.eButtons.OkCancel)
                {
                    nav_Form_PriceList_Edit.bDoModal = true;
                }
                PriceListType_Edit_dlg = new Form_PriceList_Edit(false, m_eShopType, nav_Form_PriceList_Edit);
                xnav.ChildDialog = PriceListType_Edit_dlg;
            }
            nav_Form_PriceList_Edit.ShowDialog();
            if ((nav_Form_PriceList_Edit.eExitResult == NavigationButtons.Navigation.eEvent.OK) || (nav_Form_PriceList_Edit.eExitResult == NavigationButtons.Navigation.eEvent.NEXT))
            {
                if (m_xPriceList.Get_PriceLists_of_Currency(Currency_ID, ref xPriceList_Count, ref Err))
                {
                    if (xPriceList_Count > 0)
                    {
                        this.cmb_PriceListType.DataSource = m_xPriceList.List_xPriceList;
                        this.cmb_PriceListType.DisplayMember = "xPriceList_Name";
                        this.cmb_PriceListType.ValueMember = "xPriceList_ID";
                    }
                }
                else
                {
                    LogFile.Error.Show(Err);
                    return false;
                }
            }
            else if (nav_Form_PriceList_Edit.eExitResult == NavigationButtons.Navigation.eEvent.PREV)
            {
                return true;
            }
            else
            {
                return false;
            }
            return true;
        }


        private void btn_PriceListType_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Control pctrl = null;
            if (this.Parent!=null)
            { 
                pctrl = this.Parent;
                pctrl.Cursor = Cursors.WaitCursor; 
            }
            NavigationButtons.Navigation nav_PriceList_Edit = new NavigationButtons.Navigation();
            nav_PriceList_Edit.m_eButtons = NavigationButtons.Navigation.eButtons.OkCancel;
            PriceList_Edit(false, nav_PriceList_Edit);
            this.Cursor = Cursors.Arrow;
            if (pctrl != null)
            {
                pctrl.Cursor = Cursors.Arrow;
            }
        }

        public void PriceList_Edit(bool bEditUndefined,NavigationButtons.Navigation xnav)
        {
            string Err = null;
            int xPriceListType_Count = 0;
            Form_PriceList_Edit PriceList_Edit_dlg = new Form_PriceList_Edit(bEditUndefined, m_eShopType, xnav);
            if (PriceList_Edit_dlg.ShowDialog() == DialogResult.OK)
            {
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

    }
}
