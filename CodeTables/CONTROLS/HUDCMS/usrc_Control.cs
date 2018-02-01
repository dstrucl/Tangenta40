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

        internal hctrl hc = null;
        internal usrc_Help uH = null;

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

        internal void Init(usrc_Help xuH, hctrl xhc)
        {
            uH = xuH;
            hc = xhc;
            string sText = "";
            string sControl = HUDCMS_static.slng_UserControlName;
            if (xhc.ctrl is Form)
            {
                sControl = "Form";
                this.lbl_Control.ForeColor = Color.DarkGreen;
            }
            else if (xhc.ctrl is UserControl)
            {
                this.lbl_Control.ForeColor = Color.DarkBlue;
            }
            else
            {
                sControl = "Control";
                this.lbl_Control.ForeColor = Color.Black;
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
                    this.lbl_Control.Text = sControl + "=" + xhc.pForm.Name + "  Type:" + xhc.pForm.GetType().ToString() + sText;
                }
                else
                {
                    MessageBox.Show("ERROR:HUDCMS:usrc_Control:(xhc.ctrl == null)&&(xhc.pForm != null)!");
                }
            }
            else
            {
                this.lbl_Control.Text = sControl + "=" + xhc.ctrl.Name + "  Type:" + xhc.ctrl.GetType().ToString() + sText;
            }


            if (xhc.ctrlbmp != null)
            {

                this.pic_Control.Image = xhc.ctrlbmp;
                this.pic_Control.SizeMode = PictureBoxSizeMode.Zoom;
                this.pic_Control.Width = xhc.ctrlbmp.Width;
                if (this.pic_Control.Width > MaxPanelWidth)
                {
                    this.pic_Control.Width = MaxPanelWidth - 60;
                    this.pic_Control.Height = xhc.ctrlbmp.Height * this.pic_Control.Width / xhc.ctrlbmp.Width + 4;
                }
                else
                {
                    this.pic_Control.Height = xhc.ctrlbmp.Height;
                }
           
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
            }
        }
    }
}
