using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using SQLTableControl;
using DBTypes;
using InvoiceDB;

namespace ShopC
{
    public partial class Form_Item_Edit : Form
    {
        public enum eItem_EditMode { SELECT_VALID, SELECT_UNVALID, SELECT_ALL };
        private eItem_EditMode ItemEditMode = eItem_EditMode.SELECT_VALID;

        public List<long> List_of_Inserted_Items_ID = null; 
        DataTable dt_Item = new DataTable();
        SQLTableControl.DBTableControl dbTables = null;
        SQLTable tbl = null;
        long_v ID_v = null;
        string ColumnOrderBy = "";
        private bool m_bChanged = false;
        public bool Changed
        {
            get { return m_bChanged; }
        }


        public bool bShopC_Item_NotIn_PriceList = false;

        public Form_Item_Edit(SQLTableControl.DBTableControl xdbTables, SQLTable xtbl,string xColumnOrderBy)
        {
            InitializeComponent();
            dbTables = xdbTables;
            tbl = xtbl;
            ColumnOrderBy = xColumnOrderBy;
            this.Text = lngRPM.s_Items.s;
            rdb_OnlyInOffer.Checked = true;
            this.rdb_OnlyInOffer.Text = lngRPM.s_OnlyInOffer.s;
            this.rdb_All.Text = lngRPM.s_AllItems.s;
            this.rdb_OnlyNotInOffer.Text = lngRPM.s_OnlyNotInOffer.s;

        }

        public Form_Item_Edit(SQLTableControl.DBTableControl xdbTables, SQLTable xtbl, string xColumnOrderBy, long ID)
        {
            InitializeComponent();
            dbTables = xdbTables;
            tbl = xtbl;
            ColumnOrderBy = xColumnOrderBy;
            ID_v = new long_v();
            ID_v.v = ID;
            this.Text = lngRPM.s_Items.s;
            rdb_OnlyInOffer.Checked = true;
            this.rdb_OnlyInOffer.Text = lngRPM.s_OnlyInOffer.s;
            this.rdb_All.Text = lngRPM.s_AllItems.s;
            this.rdb_OnlyNotInOffer.Text = lngRPM.s_OnlyNotInOffer.s;

        }

        private bool Init()
        {
            string selection = @" ID,
                                  Item_$$UniqueName,
                                  Item_$_ipg1_$$Name,
                                  Item_$_ipg1_$_ipg2_$$Name,
                                  Item_$_ipg1_$_ipg2_$_ipg3_$$Name,
                                  Item_$_iimg_$$Image_Data,
                                  Item_$$Name,
                                  Item_$$ToOffer,
                                  Item_$$barcode,
                                  Item_$$Description,
                                  Item_$_exp_$$ExpectedShelfLifeInDays,
                                  Item_$_exp_$$SaleBeforeExpiryDateInDays,
                                  Item_$_exp_$$DiscardBeforeExpiryDateInDays,
                                  Item_$_exp_$$ExpiryDescription,
                                  Item_$_wrty_$$WarrantyDuration,
                                  Item_$_wrty_$$WarrantyDurationType,
                                  Item_$_wrty_$$WarrantyConditions
            ";
            string sWhereCondition = "";
            switch (ItemEditMode)
            {
                case eItem_EditMode.SELECT_VALID:
                    sWhereCondition = " where  Item_$$ToOffer = 1 ";
                    break;
                case eItem_EditMode.SELECT_UNVALID:
                    sWhereCondition = " where  Item_$$ToOffer = 0 ";
                    break;
            }
            return usrc_EditTable.Init(dbTables, tbl, selection, ColumnOrderBy, false, sWhereCondition, ID_v, false);

        }
        private void MyCompanyData_EditForm_Load(object sender, EventArgs e)
        {
            ItemEditMode = eItem_EditMode.SELECT_VALID;
            rdb_OnlyInOffer.Checked = true;
            if (Init())
            {
                rdb_All.CheckedChanged +=rdb_All_CheckedChanged;
                rdb_OnlyNotInOffer.CheckedChanged +=rdb_OnlyNotInOffer_CheckedChanged;
                rdb_OnlyInOffer.CheckedChanged +=rdb_OnlyInOffer_CheckedChanged;
                List_of_Inserted_Items_ID = new List<long>();
            }
            else
            {
                Close();
                DialogResult = DialogResult.Abort;
            }
        }


        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (usrc_EditTable.Changed)
            {
                if (MessageBox.Show(lngRPM.s_DataChangedSaveYourData.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    usrc_EditTable.Save();
                }
            }
            this.Close();
            DialogResult = DialogResult.Yes;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (usrc_EditTable.Changed)
            {
                if (MessageBox.Show(lngRPM.s_DataChangedSaveYourData.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    usrc_EditTable.Save();
                }
            }
            this.Close();
            DialogResult = DialogResult.No;
        }

        private void usrc_EditTable_after_InsertInDataBase(SQLTable m_tbl, long ID, bool bRes)
        {
            if (bRes)
            {
                List_of_Inserted_Items_ID.Add(ID);
                m_bChanged = true;
            }
        }

        private void Item_EditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataTable dt_ShopC_Item_NotIn_PriceList = new DataTable();
            bShopC_Item_NotIn_PriceList = f_PriceList.Check_All_ShopC_Items_In_PriceList(ref dt_ShopC_Item_NotIn_PriceList);
            if (bShopC_Item_NotIn_PriceList)
            {
                if (PriseLists.usrc_PriceList.Ask_To_Update('C',dt_ShopC_Item_NotIn_PriceList,  this))
                {
                    f_PriceList.Insert_ShopC_Items_in_PriceList(dt_ShopC_Item_NotIn_PriceList, this);
                }
            }
        }


        private void rdb_OnlyInOffer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_OnlyInOffer.Checked)
            {
                ItemEditMode = eItem_EditMode.SELECT_VALID;
                Init();
            }
        }

        private void rdb_OnlyNotInOffer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_OnlyNotInOffer.Checked)
            {
                ItemEditMode = eItem_EditMode.SELECT_UNVALID;
                Init();
            }
        }

        private void rdb_All_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_All.Checked)
            {
                ItemEditMode = eItem_EditMode.SELECT_ALL;
                Init();
            }
        }


        private void usrc_EditTable_after_UpdateDataBase(SQLTable m_tbl, long ID, bool bRes)
        {
            m_bChanged = true;
        }

        private bool usrc_EditTable_RowReferenceFromTable_Check_NoChangeToOther(SQLTableControl.SQLTable pSQL_Table, System.Collections.Generic.List<SQLTableControl.usrc_RowReferencedFromTable> usrc_RowReferencedFromTable_List, SQLTableControl.ID_v id_v, ref bool bCancelDialog, ref ltext Instruction)
        {
            bCancelDialog = true;
            if (pSQL_Table.TableName.Equals("Item"))
            {
                
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
