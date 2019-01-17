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
using TangentaTableClass;
using DBTypes;
using CodeTables;
using LanguageControl;
using TangentaDB;
using Form_Discount;
using DBConnectionControl40;
using DynEditControls;

namespace ShopC_Forms
{
    public partial class usrc_Item_selected : UserControl
    {


        private int ipenindex = 0;
        private float penwidth = 2;
        private Pen[] pen = new Pen[5] { null, null, null, null, null };

        private TangentaDB.Doc_ShopC_Item dsci = null;
        private Item_Data itemdata = null;

        private usrc_Atom_Item m_usrc_Atom_Item = null;
        private usrc_Item m_usrc_Item = null;
        private usrc_ItemList m_usrc_ItemList = null;


        public delegate void delegate_SetItemQuantityInBasket(usrc_Item_selected xusrc_Item_selected,
                                                              usrc_Atom_Item xusrc_Atom_Item,
                                                              TangentaDB.Doc_ShopC_Item xdsci,
                                                              Item_Data idata,
                                                              usrc_ItemList xusrc_ItemList,
                                                              usrc_Item xusrc_Item
                                                              );

        public event delegate_SetItemQuantityInBasket event_SetItemQuantityInBasket = null;


        bool disposed = false;


        public usrc_Item_selected()
        {
            InitializeComponent();
            //Color color = Color.FromArgb(255 - this.BackColor.R, 255 - this.BackColor.G, 255 - this.BackColor.B);
            Color color = Color.Black;
            Brush br = new SolidBrush(color);
            float[] dashValues0 = { 0.01F, 5, 5, 5, 5, 5, 5 };
            float[] dashValues1 = { 1.01F, 5, 5, 5, 5, 5, 5 };
            float[] dashValues2 = { 2.01F, 5, 5, 5, 5, 5, 5 };
            float[] dashValues3 = { 3.01F, 5, 5, 5, 5, 5, 5 };
            float[] dashValues4 = { 4.01F, 5, 5, 5, 5, 5, 5 };
            pen[0] = new Pen(br, penwidth);
            pen[0].DashPattern = dashValues0;
            pen[1] = new Pen(br, penwidth);
            pen[1].DashPattern = dashValues1;
            pen[2] = new Pen(br, penwidth);
            pen[2].DashPattern = dashValues2;
            pen[3] = new Pen(br, penwidth);
            pen[3].DashPattern = dashValues3;
            pen[4] = new Pen(br, penwidth);
            pen[4].DashPattern = dashValues4;

            lbl_from_Stock.Text = "";
            lbl_Item.Text = "";
            lbl_bypass_Stock.Text = "";
            lbl_VAT.Text = "";
        }

        public void Init(usrc_ItemList x_usrc_ItemList)
        {
            m_usrc_ItemList = x_usrc_ItemList;
        }

        // Protected implementation of Dispose pattern. 
        protected override void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                int i= 0;
                for (i = Controls.Count-1;i >= 0 ;i--)
                {
                    Control c = Controls[i];
                    Controls.Remove(c);
                    c.Dispose();
                }
                Controls.Clear();
            }

            // Free any unmanaged objects here. 
            //
            disposed = true;
            // Call base class implementation. 
            base.Dispose(disposing);
        }


        public new event EventHandler<EventArgs> Click;

        protected override void OnClick(EventArgs e)
        {
            EventArgs myArgs = new EventArgs();
            EventHandler<EventArgs> myEvent = Click;
            if (myEvent != null)
                myEvent(this, myArgs);
            //base.OnClick(e);
            if (event_SetItemQuantityInBasket!=null)
            {
                event_SetItemQuantityInBasket(this,
                                             m_usrc_Atom_Item,
                                             dsci,
                                             itemdata,
                                             m_usrc_ItemList,
                                             m_usrc_Item);
            }
        }

        internal void DoPaint(object oxdsci,
                                             Control ctrl_appisd,
                                             object oitemdata,
                                             Control ctrl_itemdata)
        {
            if (oxdsci is TangentaDB.Doc_ShopC_Item)
            {
                dsci = (TangentaDB.Doc_ShopC_Item)oxdsci;
                if (ctrl_appisd is usrc_Atom_Item)
                {
                    m_usrc_Atom_Item = (usrc_Atom_Item)ctrl_appisd;
                }
                if (oitemdata is Item_Data)
                {
                    itemdata = (Item_Data)oitemdata;
                }

                if (ctrl_itemdata is usrc_Item)
                {
                    m_usrc_Item = (usrc_Item)ctrl_itemdata;
                }

                this.lbl_Item.Text = dsci.Atom_Item_UniqueName_v.v;
                this.lbl_from_Stock.Text = lng.s_FromStock.s + ":" + dsci.dQuantity_FromStock.ToString();
                this.lbl_bypass_Stock.Text = lng.s_AvoidStock.s + ":" + dsci.dQuantity_FromFactory.ToString();
                this.lbl_VAT.Text = lng.s_Taxation.s + ":" + dsci.Atom_Taxation_Name_v.v;
            }
        }
        internal void FillControl(int index, object oxdsci,
                                             Control ctrl_appisd,
                                             object oitemdata,
                                             Control ctrl_itemdata)
        {
            if (index>=0)
            {
                this.Enabled = true;
                timer1.Enabled = true;
                DoPaint(oxdsci,
                        ctrl_appisd,
                        oitemdata,
                        ctrl_itemdata);
            }
            else
            {
                dsci = null;
                m_usrc_Atom_Item = null;
                timer1.Enabled = false;
                this.Enabled = false;
                this.lbl_Item.Text = "";
                this.lbl_from_Stock.Text = "";
                this.lbl_bypass_Stock.Text = "";
                this.lbl_VAT.Text = "";
                this.Refresh();
            }
        }

        private Rectangle insideRect(Rectangle clientRectangle, int penwidth)
        {
            return new Rectangle(clientRectangle.Left + penwidth, clientRectangle.Top + penwidth, clientRectangle.Width - 2 * penwidth, clientRectangle.Height - 2 * penwidth);
        }

        private void usrc_Item_selected_Paint(object sender, PaintEventArgs e)
        {
            if (timer1.Enabled)
            {
                Rectangle rect = insideRect(((Control)sender).ClientRectangle, Convert.ToInt32(penwidth));
                e.Graphics.DrawRectangle(pen[ipenindex], rect);
                ipenindex++;
                if (ipenindex >= pen.Length)
                {
                    ipenindex = 0;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }

        
        private void Controls_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
    }
}
