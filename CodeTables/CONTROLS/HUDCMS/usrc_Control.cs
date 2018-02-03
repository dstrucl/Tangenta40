using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace HUDCMS
{
    public partial class usrc_Control : UserControl
    {
        internal List<usrc_Control> AvailableLink = null;
        internal List<usrc_Control> Link = null;

        internal hctrl hc = null;
        internal usrc_Help uH = null;

        public string ControlName
        {
            get { return hc.GetName(); }
        }

        private int m_MaxPanelHeight = 400;
        public int MaxPanelHeight
        {
            get { return m_MaxPanelHeight; }
            set { m_MaxPanelHeight = value; }
        }

        private int m_MaxPanelWidth = 400;
        public int MaxPanelWidth
        {
            get { return m_MaxPanelWidth; }
            set { m_MaxPanelWidth = value; }
        }

        public usrc_Control()
        {
            InitializeComponent();
           
        }

        private void Set_pic_Control()
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
            this.lbl_LinkedControls.Left = this.pic_Control.Right + 4;
            this.list_Link.Left = this.pic_Control.Right + 4;
        }
        internal void Init(usrc_Help xuH, hctrl xhc)
        {
            uH = xuH;
            hc = xhc;
            string sText = "";
            string sControl = HUDCMS_static.slng_UserControlName;
            if (xhc.ctrl is Form)
            {
                sControl = "Form";
                this.txt_Control.ForeColor = Color.DarkGreen;
            }
            else if (xhc.ctrl is UserControl)
            {
                this.txt_Control.ForeColor = Color.DarkBlue;
            }
            else
            {
                sControl = "Control";
                this.txt_Control.ForeColor = Color.Black;
                if (xhc.ctrl is Button)
                {
                    sText = "  TEXT:\"" + ((Button)xhc.ctrl).Text + "\"";
                }
                else if (xhc.ctrl is GroupBox)
                {
                    sText = "  TEXT:\"" + ((GroupBox)xhc.ctrl).Text + "\""; ;
                }
                else if (xhc.ctrl is Label)
                {
                    sText = "  TEXT:\"" + ((Label)xhc.ctrl).Text + "\""; ;
                }
            }


            if (xhc.ctrl == null)
            {
                if (xhc.pForm != null)
                {
                    this.txt_Control.Text = sControl + "=" + xhc.pForm.Name + "  Type:" + xhc.pForm.GetType().ToString() + sText;
                }
                else
                {
                    MessageBox.Show("ERROR:HUDCMS:usrc_Control:(xhc.ctrl == null)&&(xhc.pForm != null)!");
                }
            }
            else
            {
                this.txt_Control.Text = sControl + "=" + xhc.ctrl.Name + "  Type:" + xhc.ctrl.GetType().ToString() + sText;
            }

            txt_ControlName.Text = hc.GetName();

            if (hc.ctrlbmp != null)
            {
                Set_pic_Control();


                string path = Path.GetDirectoryName(uH.sLocalHtmlFile);
       
                this.panel1.Height = this.pic_Control.Bottom + 4;
                if (this.panel1.Height>MaxPanelHeight)
                {
                    this.panel1.Height = MaxPanelHeight;
                }
                this.Height = this.panel1.Bottom + 4;
             
            }
            else
            {
               
            }
            this.list_Link.Visible = false;
            this.list_Link.DataSource = null;
            if (this.Link!=null)
            {
                if (this.Link.Count>0)
                {
                    this.list_Link.Visible = true;
                    this.list_Link.DataSource = Link;
                    this.list_Link.DisplayMember = "ControlName";
                    this.list_Link.ValueMember = "ControlName";
                }
            }
            this.Refresh();
        }

      


        private void pic_Control_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonGlobal1_CheckChanged()
        {
            if (radioButtonGlobal1.Checked)
            {
                this.BackColor = radioButtonGlobal1.HighlightBackColor;
                uH.hlp_dlg.usrc_web_Help1.frm_HUDCMS.usrc_EditControl1.Init(this);
                uH.hlp_dlg.usrc_web_Help1.frm_HUDCMS.usrc_Control_Selected = this;
                uH.hlp_dlg.usrc_web_Help1.frm_HUDCMS.HideLinks();
                uH.hlp_dlg.usrc_web_Help1.frm_HUDCMS.ShowAvailableLinks();
            }
        }

        private void radioButtonGlobal1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Link_Click(object sender, EventArgs e)
        {
            //Link Form_HUDCMS.usrc_Control_Selected with this !
            if (uH.hlp_dlg.usrc_web_Help1.frm_HUDCMS.usrc_Control_Selected !=null)
            {
                usrc_Control Control_Selected = uH.hlp_dlg.usrc_web_Help1.frm_HUDCMS.usrc_Control_Selected;
                if (Control_Selected.Link == null)
                {
                    Control_Selected.Link = new List<usrc_Control>();
                }
                AddLink(Control_Selected.Link, this);
                Control_Selected.CreateImageOfLinkedControls();
            }
        }

        private void CreateImageOfLinkedControls()
        {
            this.list_Link.Visible = false;
            this.list_Link.DataSource = null;
            if (this.Link != null)
            {
                if (this.Link.Count > 0)
                {
                    this.list_Link.Visible = true;
                    this.list_Link.DataSource = Link;
                    this.list_Link.DisplayMember = "ControlName";
                    this.list_Link.ValueMember = "ControlName";
                }
                Rectangle snap_rect = new Rectangle();
                GetParentSnapshotArea(ref snap_rect, this, this.Link);
                if (this.Parent != null)
                {
                    if (this.Parent is usrc_Control)
                    {
                        if (((usrc_Control)this.Parent).hc.ctrlbmp != null)
                        {
                            Bitmap myBitmap = new Bitmap(((usrc_Control)this.Parent).hc.ctrlbmp);
                            System.Drawing.Imaging.PixelFormat format =
                                myBitmap.PixelFormat;
                            Bitmap cloneBitmap = myBitmap.Clone(snap_rect, format);


                            if (this.hc.ctrlbmp != null)
                            {
                                this.hc.ctrlbmp.Dispose();
                                this.hc.ctrlbmp = null;
                            }
                            this.hc.ctrlbmp = cloneBitmap;
                            this.Set_pic_Control();
                            this.pic_Control.Refresh();
                            if (uH.hlp_dlg.usrc_web_Help1.frm_HUDCMS.usrc_EditControl1.m_usrc_Control == this)
                            {
                                uH.hlp_dlg.usrc_web_Help1.frm_HUDCMS.usrc_EditControl1.Init(this);
                            }
                        }
                    }
                }
            }
        }

        private void GetParentSnapshotArea(ref Rectangle snap_rect, usrc_Control xusrc_Control, List<usrc_Control> link)
        {
            int xLeft = GetLeftMost(xusrc_Control, link);
            int yTop = GetTopMost(xusrc_Control, link);
            int xRight = GetRightMost(xusrc_Control, link);
            int yBottom = GetBottomMost(xusrc_Control, link);
            snap_rect = new Rectangle(xLeft, yTop, xRight - xLeft, yBottom - yTop);
        }

        private int GetBottomMost(List<usrc_Control> link)
        {
            bool bDefined = false;
            int bottom = -1;

            foreach(usrc_Control c in link)
            {
                if (!bDefined)
                {
                     bottom = c.hc.Bottom;
                     bDefined = true;
                }
                else
                {
                    if (c.hc.Bottom > bottom)
                    {
                        bottom = c.hc.ctrl.Bottom;
                    }
                }
            }
            return bottom;
        }

        private int GetBottomMost(usrc_Control xusrc_Control, List<usrc_Control> link)
        {
            int bottom_most_in_Link = GetBottomMost(link);
            if (xusrc_Control.hc.Bottom > bottom_most_in_Link)
            {
                return xusrc_Control.hc.Bottom;
            }
            else
            {
                return bottom_most_in_Link;
            }
        }

        private int GetRightMost(List<usrc_Control> link)
        {
            bool bDefined = false;
            int right = -1;
            foreach (usrc_Control c in link)
            {
                if (!bDefined)
                {
                    right = c.hc.Right;
                    bDefined = true;
                }
                else
                {
                    if (c.hc.Right > Right)
                    {
                        right = c.hc.Right;
                    }
                }
            }
            return right;
        }

        private int GetRightMost(usrc_Control xusrc_Control, List<usrc_Control> link)
        {
            int right_most_in_Link = GetRightMost(link);
            if (xusrc_Control.hc.Right > right_most_in_Link)
            {
                return xusrc_Control.hc.Right;
            }
            else
            {
                return right_most_in_Link;
            }
        }

        private int GetTopMost(List<usrc_Control> link)
        {
            bool bDefined = false;
            int top = -1;
            foreach (usrc_Control c in link)
            {
                if (!bDefined)
                {
                    top = c.hc.Top;
                    bDefined = true;
                }
                else
                {
                    if (c.hc.Top < top)
                    {
                        top = c.hc.Top;
                    }
                }
            }
            return top;
        }

        private int GetTopMost(usrc_Control xusrc_Control, List<usrc_Control> link)
        {
            int top_most_in_Link = GetRightMost(link);
            if (xusrc_Control.hc.Top < top_most_in_Link)
            {
                return xusrc_Control.hc.Top;
            }
            else
            {
                return top_most_in_Link;
            }
        }

        private int GetLeftMost(List<usrc_Control> link)
        {
            bool bDefined = false;
            int left = -1;
            foreach (usrc_Control c in link)
            {
                if (!bDefined)
                {
                    left = c.hc.Left;
                    bDefined = true;
                }
                else
                {
                    if (c.hc.Left < left)
                    {
                        left = c.hc.Left;
                    }
                }
            }
            return left;
        }

        private int GetLeftMost(usrc_Control xusrc_Control, List<usrc_Control> link)
        {
            int left_most_in_Link = GetLeftMost(link);
            if (xusrc_Control.hc.Left < left_most_in_Link)
            {
                return xusrc_Control.hc.Left;
            }
            else
            {
                return left_most_in_Link;
            }
        }

        private void AddLink(List<usrc_Control> link, usrc_Control xusrc_Control)
        {
            if (link!=null)
            {
                foreach (usrc_Control c in link)
                {
                    if (c== xusrc_Control)
                    {
                        //allready added
                        MessageBox.Show("Link allready added!");
                        return;
                    }
                }
                link.Add(xusrc_Control);
            }
        }
    }
}
