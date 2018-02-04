using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HUDCMS
{
    public partial class usrc_EditControl : UserControl
    {
        internal usrc_Control m_usrc_Control = null;
        public usrc_EditControl()
        {
            InitializeComponent();
        }

        public int SnapShotMargin
        {
            get
            {
                return Convert.ToInt32(nmUpDn_SnapShotMargin.Value);
            }
        }

        internal void Init(usrc_Control usrc_Control)
        {
            m_usrc_Control = usrc_Control;
            this.txt_Control.Text = m_usrc_Control.txt_Control.Text;
            this.txt_Control.ForeColor = m_usrc_Control.txt_Control.ForeColor;
            this.txt_ControlName.Text = m_usrc_Control.txt_ControlName.Text;
            this.pictureBox1.Image = m_usrc_Control.pic_Control.Image;
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            this.lbl_LinkedControls.Text = m_usrc_Control.lbl_LinkedControls.Text;
            this.lbl_LinkedControls.Visible = this.lbl_LinkedControls.Visible;
            this.list_Link.Visible = m_usrc_Control.list_Link.Visible;
            this.list_Link.DataSource = m_usrc_Control.Link;
            this.list_Link.DisplayMember = "ControlName";
            this.list_Link.ValueMember = "ControlName";
            if (m_usrc_Control.hc.ctrlbmp != null)
            {
                this.pictureBox1.Size = m_usrc_Control.hc.ctrlbmp.Size;
            }
            panel2.AutoScroll = true;
            panel2.PerformLayout();
            this.BackColor = usrc_Control.BackColor;

        }
        // this.usrc_SelectPictureFile.Title = "Save Image";
        //                this.usrc_SelectPictureFile.Enabled = true;
        ////     this.usrc_SelectPictureFile.Title = "Save Image";
        //         this.usrc_SelectPictureFile.FileName = path + "\\" + xhc.ctrl.Name + ".png";
        //        this.usrc_SelectPictureFile.Text = this.usrc_SelectPictureFile.FileName;
        //        this.usrc_SelectPictureFile.InitialDirectory = path;
        //        this.usrc_SelectPictureFile.DefaultExtension = "png";
        //        this.usrc_SelectPictureFile.Filter = "Image files (*.png)|*.png|(*.jpg)|*.jpg|All files (*.*)|*.*";

        //  this.usrc_SelectPictureFile.SaveFile += usrc_SelectPictureFile_SaveFile;
        // this.usrc_SelectPictureFile.Enabled = false;


        //private bool usrc_SelectPictureFile_SaveFile(string FileName, ref string Err)
        //{
        //    Err = null;
        //    try
        //    {
        //        this.pic_Control.Image.Save(FileName, ImageFormat.Png);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Err = ex.Message;
        //    }
        //    return false;
        //}
    }
}
