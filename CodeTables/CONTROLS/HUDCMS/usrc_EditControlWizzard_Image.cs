﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HUDCMS
{
    public partial class usrc_EditControlWizzard_Image : UserControl
    {
        usrc_EditControlWizzard m_usrc_EditControlWizzard = null;

        private int m_MaxPanelHeight = 400;
        public int MaxPanelHeight
        {
            get { return m_MaxPanelHeight; }
            set { m_MaxPanelHeight = value; }
        }

        private int m_MinPanelHeight = 80;
        public int MinPanelHeight
        {
            get { return m_MinPanelHeight; }
            set { m_MinPanelHeight = value; }
        }


        private int m_MaxPanelWidth = 400;
        public int MaxPanelWidth
        {
            get { return m_MaxPanelWidth; }
            set { m_MaxPanelWidth = value; }
        }



        public usrc_EditControlWizzard_Image()
        {
            InitializeComponent();
        }

        private void fastColoredTextBox1_Load(object sender, EventArgs e)
        {
            usrc_EditControlWizzard.GetUsrcEditControlWizzard(this, ref m_usrc_EditControlWizzard);
        }

        private void nmUpDn_SnapShotMargin_ValueChanged(object sender, EventArgs e)
        {
            this.nmUpDn_SnapShotMargin.ValueChanged -= new System.EventHandler(this.nmUpDn_SnapShotMargin_ValueChanged);
            if (m_usrc_EditControlWizzard != null)
            {
                m_usrc_EditControlWizzard.SnapShotMargin = Convert.ToInt32(nmUpDn_SnapShotMargin.Value);
            }
            this.nmUpDn_SnapShotMargin.ValueChanged += new System.EventHandler(this.nmUpDn_SnapShotMargin_ValueChanged);
        }

        private void btn_Link_Click(object sender, EventArgs e)
        {
            Form_Wizzard frm_Wizzard = (Form_Wizzard) Global.f.GetParentForm(this);
            if (frm_Wizzard.frm_AddLinks!=null)
            {
                if (frm_Wizzard.frm_AddLinks.IsDisposed)
                {
                    frm_Wizzard.frm_AddLinks = null;
                }
            }
            
            if (frm_Wizzard.frm_AddLinks==null)
            {
                frm_Wizzard.frm_AddLinks = new Form_AddLinks(frm_Wizzard);
                frm_Wizzard.frm_AddLinks.Owner = frm_Wizzard;
            }
            frm_Wizzard.frm_AddLinks.Show();
        }


        internal void Set_pic_Control(hctrl hc)
        {
            this.pic_Control.Image = hc.ctrlbmp;
            this.pic_Control.SizeMode = PictureBoxSizeMode.Zoom;
            this.pic_Control.Width = hc.ctrlbmp.Width;
            if (this.pic_Control.Width > MaxPanelWidth)
            {
                this.pic_Control.Width = MaxPanelWidth - 60;
                this.pic_Control.Height = hc.ctrlbmp.Height * this.pic_Control.Width / hc.ctrlbmp.Width + 4;
            }
            else
            {
                this.pic_Control.Height = hc.ctrlbmp.Height;
            }
            this.pic_Control.Top = this.chk_ImageIncluded.Bottom + 4;
            this.lbl_LinkedControls.Left = this.pic_Control.Right + 4;
            //this.list_Link.Left = this.pic_Control.Right + 4;
        }

        private void dgv_link_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView)
            {
                if (e.RowIndex>=0)
                {
                    if (e.ColumnIndex == dgv_link.Columns["Remove"].Index)
                    {
                        m_usrc_EditControlWizzard.dtLink.Rows.RemoveAt(e.RowIndex);
                        m_usrc_EditControlWizzard.my_Control.Link.RemoveAt(e.RowIndex);
                        this.dgv_link.Refresh();
                        m_usrc_EditControlWizzard.set_dgv_link(m_usrc_EditControlWizzard.my_Control);
                        m_usrc_EditControlWizzard.my_Control.ShowLink();
                    }
                }
            }
        }
    }
}
