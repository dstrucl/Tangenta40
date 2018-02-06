using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

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
                return Convert.ToInt32(usrc_EditControl_Image1.nmUpDn_SnapShotMargin.Value);
            }
            set
            {
                usrc_EditControl_Image1.nmUpDn_SnapShotMargin.Value = value;
                if (m_usrc_Control!=null)
                {
                    m_usrc_Control.SnapShotMargin = Convert.ToInt32(usrc_EditControl_Image1.nmUpDn_SnapShotMargin.Value);
                }
            }
        }

        internal static bool GetUsrcEditControl(Control ctrl, ref usrc_EditControl m_usrc_EditControl)
        {
            if (ctrl is usrc_EditControl)
            {
                m_usrc_EditControl = (usrc_EditControl)ctrl;
                return true;
            }
            else if (ctrl.Parent!=null)
            {
                if (GetUsrcEditControl(ctrl.Parent, ref m_usrc_EditControl))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        internal void Init(usrc_Control usrc_Control)
        {
            if (m_usrc_Control!=null)
            {
                m_usrc_Control.Title = usrc_EditControl_Title1.fctb_CtrlTitle.Text;
                m_usrc_Control.About = usrc_EditControl_About1.fctb_CtrlAbout.Text;
                m_usrc_Control.ImageCaption = usrc_EditControl_Image1.fctb_CtrlImageCaption.Text;
                m_usrc_Control.Description = usrc_EditControl_Description1.fctb_CtrlDescription.Text;
            }
            

            m_usrc_Control = usrc_Control;

            usrc_EditControl_Title1.fctb_CtrlTitle.Text = m_usrc_Control.Title;
            usrc_EditControl_About1.fctb_CtrlAbout.Text = m_usrc_Control.About;
            usrc_EditControl_Image1.fctb_CtrlImageCaption.Text = m_usrc_Control.ImageCaption;
            usrc_EditControl_Description1.fctb_CtrlDescription.Text = m_usrc_Control.Description;


            this.txt_Control.Text = m_usrc_Control.txt_Control.Text;
            this.txt_Control.ForeColor = m_usrc_Control.txt_Control.ForeColor;
            this.txt_ControlName.Text = m_usrc_Control.txt_ControlName.Text;
            this.usrc_EditControl_Image1.pic_Control.Image = m_usrc_Control.pic_Control.Image;
            this.usrc_EditControl_Image1.pic_Control.SizeMode = PictureBoxSizeMode.Normal;
            this.usrc_EditControl_Image1.lbl_LinkedControls.Text = m_usrc_Control.lbl_LinkedControls.Text;
            this.usrc_EditControl_Image1.lbl_LinkedControls.Visible = m_usrc_Control.lbl_LinkedControls.Visible;
            this.usrc_EditControl_Image1.list_Link.Visible = m_usrc_Control.list_Link.Visible;
            this.usrc_EditControl_Image1.list_Link.DataSource = m_usrc_Control.Link;
            this.usrc_EditControl_Image1.list_Link.DisplayMember = "ControlName";
            this.usrc_EditControl_Image1.list_Link.ValueMember = "ControlName";
            if (m_usrc_Control.hc.ctrlbmp != null)
            {
                this.usrc_EditControl_Image1.pic_Control.Size = m_usrc_Control.hc.ctrlbmp.Size;
            }
            this.BackColor = usrc_Control.BackColor;

            string sPictureFile = m_usrc_Control.Name + ".png";
            this.usrc_EditControl_Image1.usrc_SelectPictureFile.FileName = sPictureFile;
            this.usrc_EditControl_Image1.usrc_SelectPictureFile.Title = "Save Image";
            this.usrc_EditControl_Image1.usrc_SelectPictureFile.Enabled = true;
            this.usrc_EditControl_Image1.usrc_SelectPictureFile.Title = "Save Image";
            this.usrc_EditControl_Image1.usrc_SelectPictureFile.Text = this.usrc_EditControl_Image1.usrc_SelectPictureFile.FileName;
            this.usrc_EditControl_Image1.usrc_SelectPictureFile.InitialDirectory = HUDCMS_static.LocalHelpPath;
            this.usrc_EditControl_Image1.usrc_SelectPictureFile.DefaultExtension = "png";
            this.usrc_EditControl_Image1.usrc_SelectPictureFile.Filter = "Image files (*.png)|*.png|(*.jpg)|*.jpg|All files (*.*)|*.*";

            this.usrc_EditControl_Image1.usrc_SelectPictureFile.SaveFile += Usrc_SelectPictureFile_SaveFile; ;
            this.usrc_EditControl_Image1.usrc_SelectPictureFile.Enabled = true;
            this.SnapShotMargin = m_usrc_Control.SnapShotMargin;

        }

        private bool Usrc_SelectPictureFile_SaveFile(string FileName, ref string Err)
        {
            Err = null;
            try
            {
                this.usrc_EditControl_Image1.pic_Control.Image.Save(FileName, ImageFormat.Png);
                return true;
            }
            catch (Exception ex)
            {
                Err = ex.Message;
            }
            return false;
        }

    }
}
