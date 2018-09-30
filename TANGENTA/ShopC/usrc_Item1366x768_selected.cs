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

namespace ShopC
{
    public partial class usrc_Item1366x768_selected : UserControl
    {




        public TangentaDB.Item_Data m_Item_Data = null;

        bool disposed = false;


        public usrc_Item1366x768_selected()
        {
            InitializeComponent();
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

        internal void FillControl(int index, object odata)
        {
            if (index>=0)
            {
                this.Enabled = true;
                if (odata is TangentaDB.Atom_DocInvoice_ShopC_Item_Price_Stock_Data)
                {
                    TangentaDB.Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd = (TangentaDB.Atom_DocInvoice_ShopC_Item_Price_Stock_Data)odata;
                    this.lbl_Item.Text = appisd.Atom_Item_UniqueName.v;
                    this.lbl_from_Stock.Text = lng.s_FromStock.s+":"+appisd.dQuantity_FromStock.ToString();
                    this.lbl_bypass_Stock.Text = lng.s_AvoidStock.s + ":" + appisd.dQuantity_FromFactory.ToString();
                    this.lbl_VAT.Text = lng.s_Taxation.s + ":" + appisd.Atom_Taxation_Name.v;
                }
            }
            else
            {
                this.Enabled = false;
                this.lbl_Item.Text = "";
                this.lbl_from_Stock.Text = "";
                this.lbl_bypass_Stock.Text = "";
                this.lbl_VAT.Text = "";
            }
        }
    }
}
