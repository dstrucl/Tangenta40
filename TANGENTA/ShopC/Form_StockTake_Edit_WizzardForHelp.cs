﻿using HUDCMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopC
{
    public partial class Form_StockTake_Edit_WizzardForHelp : Form
    {
        private HUDCMS.MyControl root_ctrl = null;
        private Control control_ForWizzard = null;
        private Form_StockTake_Edit form_stocktake_edit = null;
        private string styleFile = null;
        private string header = null;


        public Form_StockTake_Edit_WizzardForHelp(Control ctrl, HUDCMS.MyControl xroot_ctrl,string xheader, string xstyleFile)
        {
            InitializeComponent();
            control_ForWizzard = ctrl;
            root_ctrl = xroot_ctrl;
            header = xheader;
            styleFile = xstyleFile;
            txt_DocumentType.Text = xstyleFile;
        }

        private void bn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.Cancel;
        }


        private void btn_Start_Click(object sender, EventArgs e)
        {
            MakeHtml(header,styleFile);
        }




        private bool MakeHtml(string xheader,string styleFile)
        {
            long numberOfAllControls = -1;
            string[] sTagConditions = null;
            string sxmlfilesuffix = null;
            string sNewTag = form_stocktake_edit.GetStringTag(ref numberOfAllControls, ref sTagConditions, ref sxmlfilesuffix);
            string sResult = null;
            if (HUDCMS.MyControl.MakeHtml(form_stocktake_edit, sNewTag, sTagConditions, xheader,styleFile, root_ctrl, ref sResult))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ExecuteStep()
        {
        }

        private void Form_NewDocument_WizzardForHelp_Load(object sender, EventArgs e)
        {
            if (control_ForWizzard is Form_StockTake_Edit)
            {
                form_stocktake_edit = (Form_StockTake_Edit)control_ForWizzard;
                return;
            }
            else
            {
                MessageBox.Show("WARNING:Control of type " + control_ForWizzard.GetType().ToString() + " not implemented in Wizzard");
                this.Close();
                DialogResult = DialogResult.Abort;
            }
        }
    }
}

