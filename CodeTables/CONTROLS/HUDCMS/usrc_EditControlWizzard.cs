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
    public partial class usrc_EditControlWizzard : UserControl
    {
        internal MyControl my_Control = null;
        internal DataTable dtLink = null;

        public usrc_EditControlWizzard()
        {
            InitializeComponent();
        }

        public int SnapShotMargin
        {
            get
            {
                return Convert.ToInt32(usrc_EditControlWizzard_Image1.nmUpDn_SnapShotMargin.Value);
            }
            set
            {
                usrc_EditControlWizzard_Image1.nmUpDn_SnapShotMargin.Value = value;
                if (my_Control != null)
                {
                    my_Control.SnapShotMargin = Convert.ToInt32(usrc_EditControlWizzard_Image1.nmUpDn_SnapShotMargin.Value);
                }
            }
        }

        //internal static bool GetUsrcEditControl(Control ctrl, ref usrc_EditControl m_usrc_EditControl)
        //{
        //    if (ctrl is usrc_EditControl)
        //    {
        //        m_usrc_EditControl = (usrc_EditControl)ctrl;
        //        return true;
        //    }
        //    else if (ctrl.Parent!=null)
        //    {
        //        if (GetUsrcEditControl(ctrl.Parent, ref m_usrc_EditControl))
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        internal void Init(MyControl myControl,HelpWizzardTag wiztag)
        {

            if (my_Control != null)
            {
                // save previous user_Control edited data!
                my_Control.ImageIncluded = usrc_EditControlWizzard_Image1.chk_ImageIncluded.Checked;
                if (usrc_EditControlWizzard_Image1.pic_Control.Image != null)
                {
                    my_Control.ImageOfControl = (Image)usrc_EditControlWizzard_Image1.pic_Control.Image.Clone();
                }
                else
                {
                    my_Control.ImageOfControl = null;
                }

                my_Control.HelpTitle = usrc_EditControlWizzard_Title1.fctb_CtrlTitle.Text;
                my_Control.HeadingTag = usrc_EditControlWizzard_Title1.cmb_HtmlTag.Text;
                //my_Control.About = usrc_EditControlWizzard_About1.fctb_CtrlAbout.Text;
                if (my_Control.hc.ctrlbmp != null)
                {
                    my_Control.ImageCaption = usrc_EditControlWizzard_Image1.fctb_CtrlImageCaption.Text;
                }
                //my_Control.Description = usrc_EditControlWizzard_Description1.fctb_CtrlDescription.Text;

            }


            // now set new control to  edit !
            my_Control = myControl;

            if (my_Control.hc.ctrlbmp != null)
            {
                usrc_EditControlWizzard_Image1.Enabled = true;
                splitContainer2.Panel1Collapsed = false;
            }
            else
            {
                usrc_EditControlWizzard_Image1.Enabled = false;
                splitContainer2.Panel1Collapsed = true;
            }


            string stitle = "";
            if (my_Control.HelpTitle != null)
            {
                stitle = my_Control.HelpTitle;
            }

            usrc_EditControlWizzard_Image1.chk_ImageIncluded.Checked = my_Control.ImageIncluded;
            usrc_EditControlWizzard_Title1.fctb_CtrlTitle.Text = stitle;
            usrc_EditControlWizzard_Title1.SetHeadingTag(my_Control.HeadingTag);
            usrc_EditControlWizzard_About1.Init(wiztag);
            //usrc_EditControlWizzard_About1.fctb_CtrlAbout.Text = my_Control.About;

            usrc_EditControlWizzard_Image1.fctb_CtrlImageCaption.Text = my_Control.ImageCaption;
            usrc_EditControlWizzard_Description1.Init(wiztag);
            //usrc_EditControlWizzard_Description1.fctb_CtrlDescription.Text = my_Control.Description;


            this.txt_Control.Text = my_Control.ControlName;// m_usrc_Control.txt_Control.Text;
            //this.txt_Control.ForeColor = m_usrc_Control.txt_Control.ForeColor;
            this.txt_ControlName.Text = my_Control.ControlUniqueName;// m_usrc_Control.txt_ControlName.Text;
            this.usrc_EditControlWizzard_Image1.pic_Control.Image = my_Control.hc.ctrlbmp;// m_usrc_Control.pic_Control.Image;
            this.usrc_EditControlWizzard_Image1.pic_Control.SizeMode = PictureBoxSizeMode.Normal;
            //this.usrc_EditControlWizzard_Image1.lbl_LinkedControls.Text = m_usrc_Control.lbl_LinkedControls.Text;
            //this.usrc_EditControlWizzard_Image1.lbl_LinkedControls.Visible = m_usrc_Control.lbl_LinkedControls.Visible;
            set_dgv_link(my_Control);

            //this.usrc_EditControlWizzard_Image1.list_Link.Visible = m_usrc_Control.list_Link.Visible;
            //this.usrc_EditControlWizzard_Image1.list_Link.DataSource = m_usrc_Control.Link;
            //this.usrc_EditControlWizzard_Image1.list_Link.DisplayMember = "ControlName";
            //this.usrc_EditControlWizzard_Image1.list_Link.ValueMember = "ControlName";
            if (my_Control.hc.ctrlbmp != null)
            {
                this.usrc_EditControlWizzard_Image1.pic_Control.Size = my_Control.hc.ctrlbmp.Size;
            }
            //this.BackColor = usrc_Control.BackColor;

            string sPictureFile = my_Control.ControlName + ".png";
            this.usrc_EditControlWizzard_Image1.usrc_SelectPictureFile.FileName = sPictureFile;
            this.usrc_EditControlWizzard_Image1.usrc_SelectPictureFile.Title = "Save Image";
            this.usrc_EditControlWizzard_Image1.usrc_SelectPictureFile.Enabled = true;
            this.usrc_EditControlWizzard_Image1.usrc_SelectPictureFile.Title = "Save Image";
            this.usrc_EditControlWizzard_Image1.usrc_SelectPictureFile.Text = this.usrc_EditControlWizzard_Image1.usrc_SelectPictureFile.FileName;
            this.usrc_EditControlWizzard_Image1.usrc_SelectPictureFile.InitialDirectory = HUDCMS_static.LocalHelpPath;
            this.usrc_EditControlWizzard_Image1.usrc_SelectPictureFile.DefaultExtension = "png";
            this.usrc_EditControlWizzard_Image1.usrc_SelectPictureFile.Filter = "Image files (*.png)|*.png|(*.jpg)|*.jpg|All files (*.*)|*.*";

            this.usrc_EditControlWizzard_Image1.usrc_SelectPictureFile.SaveFile += Usrc_SelectPictureFile_SaveFile; ;
            this.usrc_EditControlWizzard_Image1.usrc_SelectPictureFile.Enabled = true;
            this.SnapShotMargin = my_Control.SnapShotMargin;

        }

        internal void set_dgv_link(MyControl my_Control)
        {
            if (this.dtLink == null)
            {
                this.dtLink = new DataTable();
                DataColumn dcol_Link = new DataColumn("ControlName", typeof(string));
                DataColumn dcol_MyControl = new DataColumn("MyControl", typeof(object));
                this.dtLink.Columns.Add(dcol_Link);
                this.dtLink.Columns.Add(dcol_MyControl);
            }
            this.dtLink.Rows.Clear();
            if (my_Control.Link!=null)
            {
                foreach (MyControl mctrl in my_Control.Link)
                {
                    DataRow dr = this.dtLink.NewRow();
                    dr["ControlName"] = mctrl.ControlName;
                    dr["MyControl"] = mctrl;
                    this.dtLink.Rows.Add(dr);
                }
            }

            this.usrc_EditControlWizzard_Image1.dgv_link.DataSource = null;
            this.usrc_EditControlWizzard_Image1.dgv_link.Columns.Clear();
            this.usrc_EditControlWizzard_Image1.dgv_link.DataSource = this.dtLink;
            DataGridViewButtonColumn dgvcb = new DataGridViewButtonColumn();
            dgvcb.Name = "Remove";
            dgvcb.HeaderText = "Remove";
            dgvcb.Text = "Remove";
            this.usrc_EditControlWizzard_Image1.dgv_link.Columns.Add(dgvcb);
            this.usrc_EditControlWizzard_Image1.dgv_link.Columns["MyControl"].Visible = false;
            this.usrc_EditControlWizzard_Image1.dgv_link.Refresh();
        }

   
        internal void AddLink(MyControl selectedControl)
        {
            if (!selectedControlInLink(selectedControl))
            {
                if (my_Control.Link==null)
                {
                    my_Control.Link = new List<MyControl>();
                }
                my_Control.Link.Add(selectedControl);
                set_dgv_link(my_Control);
                my_Control.ShowLink();
            }
        }

        private bool selectedControlInLink(MyControl selectedControl)
        {
            if (my_Control.Link!=null)
            {
                foreach(MyControl xctrl in my_Control.Link)
                {
                    if (xctrl.ControlUniqueName.Equals(selectedControl.ControlUniqueName))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void set_dgv_link(ListBox list_Link)
        {
            //this.usrc_EditControlWizzard_Image1.dgv_Link.Visible = m_usrc_Control.list_Link.Visible;
            //this.usrc_EditControlWizzard_Image1.dgv_Link.DataSource = m_usrc_Control.usrc_Link;
            //this.usrc_EditControlWizzard_Image1.list_Link.DisplayMember = "ControlName";
            //this.usrc_EditControlWizzard_Image1.list_Link.ValueMember = "ControlName";
        }

        private bool Usrc_SelectPictureFile_SaveFile(string FileName, ref string Err)
        {
            Err = null;
            try
            {
                this.usrc_EditControlWizzard_Image1.pic_Control.Image.Save(FileName, ImageFormat.Png);
                return true;
            }
            catch (Exception ex)
            {
                Err = ex.Message;
            }
            return false;
        }


        internal void Set_pic_Control(hctrl hc)
        {
            usrc_EditControlWizzard_Image1.Set_pic_Control(hc);
        }
    }
}
