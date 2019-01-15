using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaProperties
{
    public class SettingsUserValues
    {
        public bool mInvoiceHeaderChecked = true;

        public bool InvoiceHeaderChecked
        {
            get
            {
                return mInvoiceHeaderChecked;
            }
            set
            {
                mInvoiceHeaderChecked = value;
            }
        }

        private System.Drawing.Color mColor_DocInvoiceBackGround = System.Drawing.Color.FromArgb(226, 255, 186);
        public System.Drawing.Color Color_DocInvoiceBackGround
        {
            get
            {
                return mColor_DocInvoiceBackGround;
            }
            set
            {
                mColor_DocInvoiceBackGround = value;
            }
        }


        private System.Drawing.Color mColor_DocProformaInvoiceForeGround = System.Drawing.Color.FromName("Black");
        public System.Drawing.Color Color_DocProformaInvoiceForeGround
        {
            get
            {
                return mColor_DocProformaInvoiceForeGround;
            }
            set
            {
                mColor_DocProformaInvoiceForeGround = value;
            }
        }


        private int mFinancialYear = 0;
        public int FinancialYear
        {
            get
            {
                return mFinancialYear;
            }
            set
            {
                mFinancialYear = value;
            }
        }

        private string meShowShops = "";
        public string eShowShops
        {
            get
            {
                return meShowShops;
            }
            set
            {
                meShowShops = value;
                Properties.Settings.Default.eShowShops = meShowShops;
                Properties.Settings.Default.Save();
            }
        }

        public string meShopsInUse = "";
        public string eShopsInUse
        {
            get
            {
                return meShopsInUse;
            }
            set
            {
                meShopsInUse = value;
                Properties.Settings.Default.eShopsInUse = meShopsInUse;
                Properties.Settings.Default.Save();
            }
        }

        private string mSplitContainerDistanceUserSettings = "";

        public string SplitContainerDistanceUserSettings
        {
            get
            {
                return mSplitContainerDistanceUserSettings;
            }
            set
            {
                mSplitContainerDistanceUserSettings = value;
            }
        }

        private string mLastDocInvoiceType = "";
        public string LastDocInvoiceType
        {
            get
            {
                return mLastDocInvoiceType;
            }
            set
            {
                mLastDocInvoiceType = value;
            }
        }

        public int mShopC_SplitControl1_spliterdistance = -1;
        public int ShopC_SplitControl1_spliterdistance
        {
            get
            {
                //return 400;
                return mShopC_SplitControl1_spliterdistance;
            }
            set
            {
                mShopC_SplitControl1_spliterdistance = value;
            }
        }

        public int mShopC_SplitControl2_spliterdistance = -1;
        public int ShopC_SplitControl2_spliterdistance
        {
            get
            {
                //return 600;
                return mShopC_SplitControl2_spliterdistance;
            }
            set
            {
                mShopC_SplitControl2_spliterdistance = value;
            }
        }

        public int mShopB_SplitControl1_spliterdistance = -1;
        public int ShopB_SplitControl1_spliterdistance
        {
            get
            {
                return mShopB_SplitControl1_spliterdistance;
            }
            set
            {
                mShopB_SplitControl1_spliterdistance = value;
            }
        }

        public int mShopB_SplitControl2_spliterdistance = -1;
        public int ShopB_SplitControl2_spliterdistance
        {
            get
            {
                return mShopB_SplitControl2_spliterdistance;
            }
            set
            {
                mShopB_SplitControl2_spliterdistance = value;
            }
        }

        public int mShopA_SplitControl1_spliterdistance = -1;
        public int ShopA_SplitControl1_spliterdistance
        {
            get
            {
                return mShopA_SplitControl1_spliterdistance;
            }
            set
            {
                mShopA_SplitControl1_spliterdistance = value;
            }
        }

        public int mDocumentMan_SplitControl1_splitterdistance = -1;
        public int DocumentMan_SplitControl1_splitterdistance
        {
            get
            {
                //return 1000;
                return mDocumentMan_SplitControl1_splitterdistance;
            }
            set
            {
                mDocumentMan_SplitControl1_splitterdistance = value;
            }
        }

        public int mShopA_Editor_SplitControl1_spliterdistance = -1;
        public int ShopA_Editor_SplitControl1_spliterdistance
        {
            get
            {
                return mShopA_Editor_SplitControl1_spliterdistance;
            }
            set
            {
                mShopA_Editor_SplitControl1_spliterdistance = value;
            }
        }

        public int mShopA_Editor_SplitControl2_spliterdistance = -1;
        public int ShopA_Editor_SplitControl2_spliterdistance
        {
            get
            {
                return mShopA_Editor_SplitControl2_spliterdistance;
            }
            set
            {
                mShopA_Editor_SplitControl2_spliterdistance = value;
            }
        }

        public int mShopA_Editor_SplitControl3_spliterdistance = -1;
        public int ShopA_Editor_SplitControl3_spliterdistance
        {
            get
            {
                return mShopA_Editor_SplitControl3_spliterdistance;
            }
            set
            {
                mShopA_Editor_SplitControl3_spliterdistance = value;
            }
        }

        public int mDocumentEditor_SplitControl1_spliterdistance = -1;
        public int DocumentEditor_SplitControl1_spliterdistance
        {
            get
            {
                //return 600;
                return mDocumentEditor_SplitControl1_spliterdistance;
            }
            set
            {
                mDocumentEditor_SplitControl1_spliterdistance = value;
            }
        }

        public int mDocumentEditor_SplitControl2_spliterdistance = -1;
        public int DocumentEditor_SplitControl2_spliterdistance
        {
            get
            {
                //return 200;
                return mDocumentEditor_SplitControl2_spliterdistance;
            }
            set
            {
                mDocumentEditor_SplitControl2_spliterdistance = value;
            }
        }

        public int mDocumentEditor_SplitControl3_spliterdistance = -1;
        public int DocumentEditor_SplitControl3_spliterdistance
        {
            get
            {
                return mDocumentEditor_SplitControl3_spliterdistance;
            }
            set
            {
                mDocumentEditor_SplitControl3_spliterdistance = value;
            }
        }

        public int mForm_WindowState = -1;
        public int Form_WindowState
        {
            get
            {
                return mForm_WindowState;
            }
            set
            {
                mForm_WindowState = value;
            }
        }

        public int mForm_Left = -1;
        public int Form_Left
        {
            get
            {
                return mForm_Left;
            }
            set
            {
                mForm_Left = value;
            }
        }

        public int mForm_Top = -1;
        public int Form_Top
        {
            get
            {
                return mForm_Top;
            }
            set
            {
                mForm_Top = value;
            }
        }

        public int mForm_Width = -1;
        public int Form_Width
        {
            get
            {
                return mForm_Width;
            }
            set
            {
                mForm_Width = value;
            }
        }

        public int mForm_Height = -1;
        public int Form_Height
        {
            get
            {
                return mForm_Height;
            }
            set
            {
                mForm_Height = value;
            }
        }

        private System.Drawing.Color mColor_DocInvoiceForeGround = System.Drawing.Color.FromName("Black");
        public System.Drawing.Color Color_DocInvoiceForeGround
        {
            get
            {
                return mColor_DocInvoiceForeGround;
            }
            set
            {
                mColor_DocInvoiceForeGround = value;
            }
        }

        public System.Drawing.Color mColor_DocProformaInvoiceBackGround = System.Drawing.Color.FromName("Azure");
        public System.Drawing.Color Color_DocProformaInvoiceBackGround
        {
            get
            {
                return mColor_DocProformaInvoiceBackGround;
            }
            set
            {
                mColor_DocProformaInvoiceBackGround = value;
            }
        }


        public void Fill_DataTable(ref DataTable dt)
        {
            if (dt!=null)
            {
                dt.Dispose();
                dt = new DataTable();
            }
            else
            {
                dt = new DataTable();
            }
            DataColumn dcol_SettingsName = new DataColumn("Name", typeof(string));
            DataColumn dcol_SettingsType = new DataColumn("Type", typeof(string));
            DataColumn dcol_SettingsValue = new DataColumn("Value", typeof(string));
            DataColumn dcol_ReadOnly = new DataColumn("ReadOnly", typeof(bool));
            dt.Columns.Clear();
            dt.Columns.Add(dcol_SettingsName);
            dt.Columns.Add(dcol_SettingsType);
            dt.Columns.Add(dcol_SettingsValue);
            dt.Columns.Add(dcol_ReadOnly);

            AddRow(dt, "InvoiceHeaderChecked", InvoiceHeaderChecked,false);
            AddRow(dt, "Color_DocInvoiceBackGround", Color_DocInvoiceBackGround,false);
            AddRow(dt, "Color_DocProformaInvoiceForeGround", Color_DocProformaInvoiceForeGround, false);
            AddRow(dt, "FinancialYear", FinancialYear, true);
            AddRow(dt, "eShopsMode", eShowShops, true);
            AddRow(dt, "eShopsInUse", eShopsInUse,true);
            AddRow(dt, "SplitContainerDistanceUserSettings", SplitContainerDistanceUserSettings, false);
            AddRow(dt, "LastDocInvoiceType", LastDocInvoiceType, true);
            AddRow(dt, "ShopC_SplitControl1_spliterdistance", ShopC_SplitControl1_spliterdistance, false);
            AddRow(dt, "ShopC_SplitControl2_spliterdistance", ShopC_SplitControl2_spliterdistance, false);
            AddRow(dt, "ShopB_SplitControl1_spliterdistance", ShopB_SplitControl1_spliterdistance, false);
            AddRow(dt, "ShopB_SplitControl2_spliterdistance", ShopB_SplitControl2_spliterdistance, false);
            AddRow(dt, "ShopA_SplitControl1_spliterdistance", ShopA_SplitControl1_spliterdistance, false);
            AddRow(dt, "DocumentMan_SplitControl1_splitterdistance", DocumentMan_SplitControl1_splitterdistance, false);
            AddRow(dt, "ShopA_Editor_SplitControl1_spliterdistance", ShopA_Editor_SplitControl1_spliterdistance, false);
            AddRow(dt, "ShopA_Editor_SplitControl2_spliterdistance", ShopA_Editor_SplitControl2_spliterdistance, false);
            AddRow(dt, "ShopA_Editor_SplitControl3_spliterdistance", ShopA_Editor_SplitControl3_spliterdistance, false);
            AddRow(dt, "DocumentEditor_SplitControl1_spliterdistance", DocumentEditor_SplitControl1_spliterdistance, false);
            AddRow(dt, "DocumentEditor_SplitControl2_spliterdistance", DocumentEditor_SplitControl2_spliterdistance, false);
            AddRow(dt, "DocumentEditor_SplitControl3_spliterdistance", DocumentEditor_SplitControl3_spliterdistance, false);
            AddRow(dt, "Form_WindowState", Form_WindowState, false);
            AddRow(dt, "Form_Left", Form_Left, false);
            AddRow(dt, "Form_Top", Form_Top, false);
            AddRow(dt, "Form_Width", Form_Width, false);
            AddRow(dt, "Form_Height", Form_Height, false);
            AddRow(dt, "Color_DocInvoiceForeGround", Color_DocInvoiceForeGround, false);
            AddRow(dt, "Color_DocProformaInvoiceBackGround", Color_DocProformaInvoiceBackGround, false);

    }

        private void AddRow(DataTable dt, string v, string eShopsMode, bool breadonly)
        {
            DataRow dr = dt.NewRow();
            dr["Name"] = v;
            dr["Type"] = eShopsMode.GetType();
            dr["Value"] = eShopsMode;
            dr["ReadOnly"] = breadonly;
            dt.Rows.Add(dr);
        }

        private void AddRow(DataTable dt, string v, int inum, bool breadonly)
        {
            DataRow dr = dt.NewRow();
            dr["Name"] = v;
            dr["Type"] = inum.GetType();
            dr["Value"] = inum;
            dr["ReadOnly"] = breadonly;
            dt.Rows.Add(dr);
        }

        private void AddRow(DataTable dt, string v, Color color, bool breadonly)
        {
            DataRow dr = dt.NewRow();
            dr["Name"] = v;
            dr["Type"] = color.GetType();
            dr["Value"] = color.R.ToString()+";"+ color.G.ToString() + ";" + color.B.ToString();
            dr["ReadOnly"] = breadonly;
            dt.Rows.Add(dr);
        }

        private void AddRow(DataTable dt, string v, bool b, bool breadonly)
        {
            DataRow dr = dt.NewRow();
            dr["Name"] = v;
            dr["Type"] = b.GetType();
            if (b)
            {
                dr["Value"] = "true";
            }
            else
            {
                dr["Value"] = "false";
            }
            dr["ReadOnly"] = breadonly;
            dt.Rows.Add(dr);
        }
    }
}
