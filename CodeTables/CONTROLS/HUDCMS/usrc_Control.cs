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
        private usrc_Help uH = null;
        public usrc_Control()
        {
            InitializeComponent();
            this.usrc_SelectPictureFile.Title = "Save Image";
        }

        internal void Init(usrc_Help xuH, hctrl xhc)
        {
            uH = xuH;
            string sText = "";
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
            this.lbl_Control.Text = HUDCMS_static.slng_UserControlName + "=" + xhc.ctrl.Name+ "  Type:"+ xhc.ctrl.GetType().ToString()+ sText;

            if (xhc.ctrlbmp != null)
            {
                this.usrc_SelectPictureFile.Enabled = true;
                this.pic_Control.Image = xhc.ctrlbmp;
                if (xhc.ctrlbmp.Width < this.splitContainer1.Width / 2)
                {
                    this.splitContainer1.Orientation = Orientation.Vertical;
                    this.splitContainer1.SplitterDistance = xhc.ctrlbmp.Width;
                    this.pic_Control.SizeMode = PictureBoxSizeMode.Normal;
                    this.pic_Control.Width = xhc.ctrlbmp.Width;
                    this.pic_Control.Height = xhc.ctrlbmp.Height;
                    if (xhc.ctrlbmp.Height > 200)
                    {
                        this.splitContainer1.Height = xhc.ctrlbmp.Height + 4;
                    }
                    else
                    {
                        this.splitContainer1.Height = 200;
                    }
                }
                else
                {
                    this.splitContainer1.Orientation = Orientation.Horizontal;
                    if (xhc.ctrlbmp.Height > 200)
                    {
                        this.splitContainer1.SplitterDistance = 300;
                        this.pic_Control.SizeMode = PictureBoxSizeMode.Normal;
                        this.pic_Control.Width = xhc.ctrlbmp.Width;
                        this.pic_Control.Height = xhc.ctrlbmp.Height;
                        this.splitContainer1.Height = 4 + 600;
                    }
                    else
                    {
                        this.pic_Control.SizeMode = PictureBoxSizeMode.Normal;
                        this.splitContainer1.SplitterDistance = xhc.ctrlbmp.Height;
                        this.splitContainer1.Height = xhc.ctrlbmp.Height + 200;
                        this.pic_Control.Width = xhc.ctrlbmp.Width;
                        this.pic_Control.Height = xhc.ctrlbmp.Height;
                    }
                    this.usrc_SelectPictureFile.Title = "Save Image";
                    string path = Path.GetDirectoryName(uH.sLocalHtmlFile);
                    this.usrc_SelectPictureFile.FileName = path + "\\" + xhc.ctrl.Name + ".png";
                    this.usrc_SelectPictureFile.Text = this.usrc_SelectPictureFile.FileName;
                    this.usrc_SelectPictureFile.InitialDirectory = path;
                    this.usrc_SelectPictureFile.DefaultExtension = "png";
                    this.usrc_SelectPictureFile.Filter = "Image files (*.png)|*.png|(*.jpg)|*.jpg|All files (*.*)|*.*";
                }
            }
            else
            {
                this.usrc_SelectPictureFile.Enabled = false;
            }
                this.Height = this.splitContainer1.Bottom + 4;
            this.Refresh();
        }

      

        private bool usrc_SelectPictureFile_SaveFile(string FileName, ref string Err)
        {
            Err = null;
            try
            {
                this.pic_Control.Image.Save(FileName, ImageFormat.Png);
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
