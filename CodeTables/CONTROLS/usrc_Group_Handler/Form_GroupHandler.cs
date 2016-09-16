using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace usrc_Item_Group_Handler
{
    public partial class Form_GroupHandler : Form
    {
        public int RIGHT_MARGIN = 6;

        private int pnl3_width = -1;
        private int pnl2_width = -1;
        private int pnl1_width = -1;
        private int SplitContainer1_Width = -1;
        private int SplitContainer2_Width = -1;
        private int SplitContainer1_SplitterDistance = -1;
        private int SplitContainer2_SplitterDistance = -1;
        private int This_Width = -1;

        private string m_ShopName = "";
        private string m_GroupPath = "";

        public string ShopName
        {
            get { return m_ShopName; }
            set
            {
                m_ShopName = value;
                if (m_ShopName != null)
                {
                    this.Text = m_ShopName + " " + GroupPath;
                }
            }
        }
        public string GroupPath
        {
            get { return m_GroupPath; }
            set
            {
                m_GroupPath = value;
                if (m_GroupPath != null)
                {
                    this.Text = m_ShopName + " " + m_GroupPath;
                }
            }
        }

        public Form_GroupHandler()
        {
            InitializeComponent();
            pnl3_width = this.s3_pnl.Width;
            pnl2_width = this.s2_pnl.Width;
            pnl1_width = this.s1_pnl.Width;
            SplitContainer1_Width = this.splitContainer1.Width;
            SplitContainer2_Width = this.splitContainer2.Width;
            SplitContainer1_SplitterDistance = this.splitContainer1.SplitterDistance;
            SplitContainer2_SplitterDistance = this.splitContainer2.SplitterDistance;
            This_Width = this.Width;
            this.Visible = false;
    }


    private void Form_GroupHandler_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        internal void ShowRootLevel1()
        {
            this.splitContainer1.Panel1Collapsed = false;
            this.splitContainer1.Panel2Collapsed = true;
            this.Width = RIGHT_MARGIN + pnl3_width + RIGHT_MARGIN;
        }
        internal void ShowRootLevel2()
        {
            this.splitContainer1.Panel2Collapsed = false;
            this.splitContainer2.Panel2Collapsed = true;
            this.Width = RIGHT_MARGIN + pnl3_width + RIGHT_MARGIN  + pnl2_width +  RIGHT_MARGIN;
        }

        internal void ShowRootLevel3()
        {

            this.splitContainer1.Panel2Collapsed = false;
            this.splitContainer2.Panel2Collapsed = false;
            this.Width = This_Width;
        }

        internal void LimitHeight()
        {
            int iMaxHeight = 0;
            int iHeight = 0;
            if (!this.splitContainer2.Panel2Collapsed)
            {
                iHeight = getHeight(this.s1_pnl);
                if (iMaxHeight < iHeight)
                {
                    iMaxHeight = iHeight;
                }
            }
            if (!this.splitContainer1.Panel2Collapsed)
            {
                iHeight = getHeight(this.s2_pnl);
                if (iMaxHeight < iHeight)
                {
                    iMaxHeight = iHeight;
                }
            }
            iHeight = getHeight(this.s3_pnl);
            if (iMaxHeight < iHeight)
            {
                iMaxHeight = iHeight;
            }
            Rectangle screenRectangle = RectangleToScreen(this.ClientRectangle);
            int titleHeight = screenRectangle.Top - this.Top;

            int form_height = RIGHT_MARGIN + iMaxHeight + RIGHT_MARGIN + titleHeight;
            Screen scr = System.Windows.Forms.Screen.FromControl(this);
            if (form_height < (scr.WorkingArea.Height * 2)/3)
            {
                this.Height = form_height;
            }
            else
            {
                form_height = (scr.WorkingArea.Height * 2) / 3;
                this.Height = form_height;
            }
        }

        private int getHeight(Panel pnl)
        {
            int ibottom = 0;
            int i = 0;
            int iCount = pnl.Controls.Count;

            for (i=0;i< iCount;i++)
            {
                Control ctrl = pnl.Controls[i];
                if (ibottom < ctrl.Bottom)
                {
                    ibottom = ctrl.Bottom;
                }
            }
            return ibottom;
        }
    }
}
