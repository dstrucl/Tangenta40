using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangenta
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

        private string meShopsMode = "";
        public string eShopsMode
        {
            get
            {
                return meShopsMode;
            }
            set
            {
                meShopsMode = value;
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
                return 400;
                //return mShopC_SplitControl1_spliterdistance;
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
                return 600;
                //return mShopC_SplitControl2_spliterdistance;
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
                return 1000;
                //return mDocumentMan_SplitControl1_splitterdistance;
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
                return 600;
                //return mDocumentEditor_SplitControl1_spliterdistance;
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
                return 200;
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

        public int mForm_Document_WindowState = -1;
        public int Form_Document_WindowState
        {
            get
            {
                return mForm_Document_WindowState;
            }
            set
            {
                mForm_Document_WindowState = value;
            }
        }

        public int mForm_Document_Left = -1;
        public int Form_Document_Left
        {
            get
            {
                return mForm_Document_Left;
            }
            set
            {
                mForm_Document_Left = value;
            }
        }

        public int mForm_Document_Top = -1;
        public int Form_Document_Top
        {
            get
            {
                return mForm_Document_Top;
            }
            set
            {
                mForm_Document_Top = value;
            }
        }

        public int mForm_Document_Width = -1;
        public int Form_Document_Width
        {
            get
            {
                return mForm_Document_Width;
            }
            set
            {
                mForm_Document_Width = value;
            }
        }

        public int mForm_Document_Height = -1;
        public int Form_Document_Height
        {
            get
            {
                return mForm_Document_Height;
            }
            set
            {
                mForm_Document_Height = value;
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


        internal void Fill_DataTable(ref DataTable dt)
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
            dt.Columns.Clear();
            dt.Columns.Add(dcol_SettingsName);
            dt.Columns.Add(dcol_SettingsType);
            dt.Columns.Add(dcol_SettingsValue);

            AddRow(dt, "InvoiceHeaderChecked", InvoiceHeaderChecked);
            AddRow(dt, "Color_DocInvoiceBackGround", Color_DocInvoiceBackGround);
            AddRow(dt, "Color_DocProformaInvoiceForeGround", Color_DocProformaInvoiceForeGround);
            AddRow(dt, "FinancialYear", FinancialYear);
            AddRow(dt, "eShopsMode", eShopsMode);
            AddRow(dt, "eShopsInUse", eShopsInUse);
            AddRow(dt, "SplitContainerDistanceUserSettings", SplitContainerDistanceUserSettings);
            AddRow(dt, "LastDocInvoiceType", LastDocInvoiceType);
            AddRow(dt, "ShopC_SplitControl1_spliterdistance", ShopC_SplitControl1_spliterdistance);
            AddRow(dt, "ShopC_SplitControl2_spliterdistance", ShopC_SplitControl2_spliterdistance);
            AddRow(dt, "ShopB_SplitControl1_spliterdistance", ShopB_SplitControl1_spliterdistance);
            AddRow(dt, "ShopB_SplitControl2_spliterdistance", ShopB_SplitControl2_spliterdistance);
            AddRow(dt, "ShopA_SplitControl1_spliterdistance", ShopA_SplitControl1_spliterdistance);
            AddRow(dt, "DocumentMan_SplitControl1_splitterdistance", DocumentMan_SplitControl1_splitterdistance);
            AddRow(dt, "ShopA_Editor_SplitControl1_spliterdistance", ShopA_Editor_SplitControl1_spliterdistance);
            AddRow(dt, "ShopA_Editor_SplitControl2_spliterdistance", ShopA_Editor_SplitControl2_spliterdistance);
            AddRow(dt, "ShopA_Editor_SplitControl3_spliterdistance", ShopA_Editor_SplitControl3_spliterdistance);
            AddRow(dt, "DocumentEditor_SplitControl1_spliterdistance", DocumentEditor_SplitControl1_spliterdistance);
            AddRow(dt, "DocumentEditor_SplitControl2_spliterdistance", DocumentEditor_SplitControl2_spliterdistance);
            AddRow(dt, "DocumentEditor_SplitControl3_spliterdistance", DocumentEditor_SplitControl3_spliterdistance);
            AddRow(dt, "Form_Document_WindowState", Form_Document_WindowState);
            AddRow(dt, "Form_Document_Left", Form_Document_Left);
            AddRow(dt, "Form_Document_Top", Form_Document_Top);
            AddRow(dt, "Form_Document_Width", Form_Document_Width);
            AddRow(dt, "Form_Document_Height", Form_Document_Height);
            AddRow(dt, "Color_DocInvoiceForeGround", Color_DocInvoiceForeGround);
            AddRow(dt, "Color_DocProformaInvoiceBackGround", Color_DocProformaInvoiceBackGround);

    }

        private void AddRow(DataTable dt, string v, string eShopsMode)
        {
            DataRow dr = dt.NewRow();
            dr["Name"] = v;
            dr["Type"] = eShopsMode.GetType();
            dr["Value"] = eShopsMode;
            dt.Rows.Add(dr);
        }

        private void AddRow(DataTable dt, string v, int inum)
        {
            DataRow dr = dt.NewRow();
            dr["Name"] = v;
            dr["Type"] = inum.GetType();
            dr["Value"] = inum;
            dt.Rows.Add(dr);
        }

        private void AddRow(DataTable dt, string v, Color color)
        {
            DataRow dr = dt.NewRow();
            dr["Name"] = v;
            dr["Type"] = color.GetType();
            dr["Value"] = color.R.ToString()+";"+ color.G.ToString() + ";" + color.B.ToString();
            dt.Rows.Add(dr);
        }

        private void AddRow(DataTable dt, string v, bool b)
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
            dt.Rows.Add(dr);
        }
    }
}
