﻿using LanguageControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace usrc_Item_InsidePageHandler
{
    public partial class Form_Items_Samples : Form
    {
        public SampleDB sbd = null;
        public bool bAutoGenerateDemoSampleItems = false;
        public int iNumberOfGroupsInLevel1 = 0;
        public int iNumberOfGroupsInLevel2 = 0;
        public int iNumberOfGroupsInLevel3 = 0;
        public int iNumberOfItemsPerGroup = 3;
        private string m_shopName = null;

        public Form_Items_Samples()
        {
            InitializeComponent();
            sbd = new SampleDB();
            this.lbl_ItemPrefix.Text = "Item Name Prefix";
            this.lbl_ItemAbbreviationPrefix.Text = "Item Abbreviation Prefix";
            this.lbl_Number_Of_Groups_in_Level1.Text ="Number Of Groups in Level1:";
            this.lbl_Number_Of_Groups_in_Level2.Text = "Number_Of_Groups_in_Level2:";
            this.lbl_Number_Of_Groups_in_Level3.Text ="Number_Of_Groups_in_Level3:";
            this.lbl_NumberOfItemsPerGroup.Text ="Number_Of_Items_per_group";

            this.nm_UpDn_NumberOfGroupsInLevel1.Value = iNumberOfGroupsInLevel1;
            this.nm_UpDn_NumberOfGroupsInLevel2.Value = iNumberOfGroupsInLevel2;
            this.nm_UpDn_NumberOfGroupsInLevel3.Value = iNumberOfGroupsInLevel3;
            this.nmUpDn_NumberOfItemsPerGroup.Value = iNumberOfItemsPerGroup;

            this.nm_UpDn_NumberOfGroupsInLevel1.ValueChanged += new System.EventHandler(this.nm_UpDn_NumberOfGroupsInLevel1_ValueChanged);
            this.nm_UpDn_NumberOfGroupsInLevel2.ValueChanged += new System.EventHandler(this.nm_UpDn_NumberOfGroupsInLevel2_ValueChanged);
            this.nm_UpDn_NumberOfGroupsInLevel3.ValueChanged += new System.EventHandler(this.nm_UpDn_NumberOfGroupsInLevel3_ValueChanged);
            this.nmUpDn_NumberOfItemsPerGroup.ValueChanged += new System.EventHandler(this.nmUpDn_NumberOfItemsPerGroup_ValueChanged);
            ShowAllItemsToInsert();
        }
        public int iNumberOffAll()
        {
            int iAll = 1;
            if (iNumberOfGroupsInLevel3 > 0)
            {
                iAll = (iNumberOfGroupsInLevel3 * iNumberOfGroupsInLevel2 * iNumberOfGroupsInLevel1) * iNumberOfItemsPerGroup
                       + (iNumberOfGroupsInLevel3 * iNumberOfGroupsInLevel2) * iNumberOfItemsPerGroup
                       + iNumberOfGroupsInLevel3 * iNumberOfItemsPerGroup
                       + iNumberOfItemsPerGroup;
            }
            else if (iNumberOfGroupsInLevel2 > 0)
            {
                iAll = (iNumberOfGroupsInLevel2 * iNumberOfGroupsInLevel1) * iNumberOfItemsPerGroup
                       + iNumberOfGroupsInLevel2 * iNumberOfItemsPerGroup
                       + iNumberOfItemsPerGroup;
            }
            else if (iNumberOfGroupsInLevel1 > 0)
            {
                iAll = (iNumberOfGroupsInLevel1) * iNumberOfItemsPerGroup
                       + iNumberOfItemsPerGroup;
            }
            else
            {
                iAll = iNumberOfItemsPerGroup;
            }
            return iAll;
        }


        private void nm_UpDn_NumberOfGroupsInLevel1_ValueChanged(object sender, EventArgs e)
        {
            if (nm_UpDn_NumberOfGroupsInLevel1.Value>0)
            {
                EnableLevel(2);
            }
            else
            {
                DisableLevel(2);
                DisableLevel(3);
            }
            iNumberOfGroupsInLevel1 = Convert.ToInt32(nm_UpDn_NumberOfGroupsInLevel1.Value);
            ShowAllItemsToInsert();
        }

        private void nm_UpDn_NumberOfGroupsInLevel2_ValueChanged(object sender, EventArgs e)
        {
            if (nm_UpDn_NumberOfGroupsInLevel2.Value > 0)
            {
                EnableLevel(3);
            }
            else
            {
                DisableLevel(3);
            }
            iNumberOfGroupsInLevel2 = Convert.ToInt32(nm_UpDn_NumberOfGroupsInLevel2.Value);
            ShowAllItemsToInsert();
        }

        private void DisableLevel(int v)
        {
            switch (v)
            {
                case 2:
                    nm_UpDn_NumberOfGroupsInLevel2.Enabled = false;
                    lbl_Number_Of_Groups_in_Level2.Enabled = false;
                    break;
                case 3:
                    nm_UpDn_NumberOfGroupsInLevel3.Enabled = false;
                    lbl_Number_Of_Groups_in_Level3.Enabled = false;
                    break;
            }

        }

        private void EnableLevel(int v)
        {
            switch (v)
            {
                case 2:
                    nm_UpDn_NumberOfGroupsInLevel2.Enabled = true;
                    lbl_Number_Of_Groups_in_Level2.Enabled = true;
                    break;
                case 3:
                    nm_UpDn_NumberOfGroupsInLevel3.Enabled = true;
                    lbl_Number_Of_Groups_in_Level3.Enabled = true;
                    break;
            }
        }

        private void ShowAllItemsToInsert()
        {
            int iNumberOfAllToBeInserted = iNumberOffAll();
            this.lbl_NumberOfTitemsToBeInserted.Text = "Number Of Items To Insert = " + iNumberOfAllToBeInserted;
        }
        private void nm_UpDn_NumberOfGroupsInLevel3_ValueChanged(object sender, EventArgs e)
        {
            iNumberOfGroupsInLevel3 = Convert.ToInt32(nm_UpDn_NumberOfGroupsInLevel3.Value);
            ShowAllItemsToInsert();
        }

        private void nmUpDn_NumberOfItemsPerGroup_ValueChanged(object sender, EventArgs e)
        {
            iNumberOfItemsPerGroup = Convert.ToInt32(nmUpDn_NumberOfItemsPerGroup.Value);
            ShowAllItemsToInsert();
        }

        private void Form_Items_Samples_Shown(object sender, EventArgs e)
        {
            if (SampleDB.eType == SampleDB.eSampleType.NONE)
            {
                if (MessageBox.Show(this, "IfYouAreRunningThisApplicationOnlyForDemoOrTestPurposesPressYes","?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    SampleDB.eType = SampleDB.eSampleType.DEMO;
                }
                else
                {
                    SampleDB.eType = SampleDB.eSampleType.REAL;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sbd != null)
            {
                if (sbd.SampleDB_Price_ShopC_Item_List==null)
                {
                    sbd.Write_ShopC_Items(this);
                }
            }
        }
    }
}
