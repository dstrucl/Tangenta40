using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace SQLTableControl
{
    public partial class ResizeImage_Form : Form
    {
        private int m_NewWidth = 0;
        private int m_NewHeight = 0;
        public Image m_NewImage;
        public System.Drawing.Imaging.ImageFormat imgFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
        public System.Drawing.Imaging.PixelFormat pixFormat = System.Drawing.Imaging.PixelFormat.Format24bppRgb;
        private Image m_OrgImage;
        private bool bChangeTargetHeight = false;
        private bool bChangeTargetWidth = false;

        public ResizeImage_Form(Image OrgImage)
        {
            InitializeComponent();

            this.numericUpDown_TargetWidth.Maximum = 20000;
            this.numericUpDown_TargetWidth.Minimum = 0;
            this.numericUpDown_TargetHeight.Maximum = 20000;
            this.numericUpDown_TargetHeight.Minimum = 0;

            m_OrgImage = OrgImage;
            m_NewWidth = Properties.Settings.Default.TargetImageWidth;
            m_NewHeight = Properties.Settings.Default.TargetImageHeight;
            chkBox_KeepAspectRatio.Checked = Properties.Settings.Default.KeepAspectRatio;
            EnsureAspectRatio();

            //List<string> ImageDecoders = StaticLib.Func.GetImageDecoders();


            this.numericUpDown_TargetWidth.Value = m_NewWidth;
            this.numericUpDown_TargetHeight.Value = m_NewHeight;
            chkBox_KeepAspectRatio.Checked = Properties.Settings.Default.KeepAspectRatio;
            WriteSourceDimensions();
            this.lblDestinationWidth.Text = lngRPM.s_Width.s + "=";
            this.lblDestinationHeight.Text = lngRPM.s_Height.s + "=";
            this.chkBox_KeepAspectRatio.Text = lngRPM.s_KeepAspectRation.s;
            this.Text = lngRPM.s_ResizeImage.s;
            this.btnChangeSize.Text = "> "+lngRPM.s_ResizeImage.s + " >";
            this.pictureBox_Source.Image = OrgImage;
            this.btnOK.Text = lngRPM.s_OK.s;
            this.btn_Cancel.Text = lngRPM.s_Cancel.s;
            if (chkBox_KeepAspectRatio.Checked)
            {
                m_NewImage = StaticLib.Func.PutImageInBoundaries(m_OrgImage, m_NewWidth, m_NewHeight, OrgImage.RawFormat);
            }
            else
            {
                Size size = new Size(m_NewWidth,m_NewHeight);
                m_NewImage = StaticLib.Func.resizeImage(m_OrgImage, size, OrgImage.RawFormat);
            }
            this.pictureBox_Destination.Image = m_NewImage;
            WriteSize();

        }

        private void WriteSourceDimensions()
        {
            this.lblSourceWidth.Text = lngRPM.s_Width.s + " = " + m_OrgImage.Width.ToString();
            this.lblSourceHeight.Text = lngRPM.s_Height.s + " = " + m_OrgImage.Height.ToString();
        }

        private void WriteDestinationDimensions()
        {
            this.numericUpDown_TargetWidth.Value = pictureBox_Destination.Image.Width;
            this.numericUpDown_TargetHeight.Value = pictureBox_Destination.Image.Height;
        }

        private void WriteSize()
        {
            this.lbl_SourceSize.Text = lngRPM.s_Format.s + "=" +StaticLib.Func.GetImageFormatName(m_OrgImage) + ", " + lngRPM.s_Size.s + "=" + DBTypes.DBtypesFunc.GetObjectSize(m_OrgImage).ToString("n") + " " + lngRPM.s_Bytes.s;
            this.lbl_DestinationSize.Text = lngRPM.s_Size.s + "=" + DBTypes.DBtypesFunc.GetObjectSize(m_NewImage).ToString("n") + " " + lngRPM.s_Bytes.s;
            this.lbl_Format.Text = lngRPM.s_Format.s + ":";
            this.cmbBoxPictureFormat.Text = StaticLib.Func.GetImageFormatName(m_NewImage);
        }

        private void ChangeSize()
        {
            m_NewWidth = Convert.ToInt32(this.numericUpDown_TargetWidth.Value);
            m_NewHeight = Convert.ToInt32(this.numericUpDown_TargetHeight.Value);
            if (chkBox_KeepAspectRatio.Checked)
            {
                if (GetImageFormat(ref imgFormat,ref pixFormat))
                {
                    m_NewImage = StaticLib.Func.PutImageInBoundaries(m_OrgImage, m_NewWidth, m_NewHeight, imgFormat);
                    pictureBox_Destination.Image = m_NewImage;
                }
            }
            else
            {
                if (GetImageFormat(ref imgFormat, ref pixFormat))
                {
                    Size size = new Size(m_NewWidth, m_NewHeight);
                    m_NewImage = StaticLib.Func.resizeImage(m_OrgImage, size, imgFormat);
                    pictureBox_Destination.Image = m_NewImage;
                }
            }
            WriteSize();
            WriteDestinationDimensions();
        }
        private void btnChangeSize_Click(object sender, EventArgs e)
        {
            ChangeSize();
        }

        private bool GetImageFormat(ref System.Drawing.Imaging.ImageFormat imFormat, ref System.Drawing.Imaging.PixelFormat pxFormat)
        {
            if (cmbBoxPictureFormat.Text.Equals("Jpeg"))
            {
                imFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
            }
            else if (cmbBoxPictureFormat.Text.Equals("Gif"))
            {
                imFormat = System.Drawing.Imaging.ImageFormat.Gif;
            }
            else if (cmbBoxPictureFormat.Text.Equals("Bmp"))
            {
                imFormat = System.Drawing.Imaging.ImageFormat.Bmp;
            }
            else if (cmbBoxPictureFormat.Text.Equals("Bmp 1Bit"))
            {
                imFormat = System.Drawing.Imaging.ImageFormat.Bmp;
                pxFormat = System.Drawing.Imaging.PixelFormat.Format1bppIndexed;
            }
            else if (cmbBoxPictureFormat.Text.Equals("Png"))
            {
                imFormat = System.Drawing.Imaging.ImageFormat.Png;
            }
            else if (cmbBoxPictureFormat.Text.Equals("Tiff"))
            {
                imFormat = System.Drawing.Imaging.ImageFormat.Tiff;
            }
            else if (cmbBoxPictureFormat.Text.Equals("Wmf"))
            {
                imFormat = System.Drawing.Imaging.ImageFormat.Wmf;
            }
            else if (cmbBoxPictureFormat.Text.Equals("Exif"))
            {
                imFormat = System.Drawing.Imaging.ImageFormat.Exif;
            }
            else if (cmbBoxPictureFormat.Text.Equals("Emf"))
            {
                imFormat = System.Drawing.Imaging.ImageFormat.Emf;
            }
            else if (cmbBoxPictureFormat.Text.Equals("Icon"))
            {
                imFormat = System.Drawing.Imaging.ImageFormat.Icon;
            }
            else
            {
                if (MessageBox.Show(lngRPM.s_UnknownPictureFormatSaveInJpg.s, lngRPM.s_SaveInJpgQuestion.s, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    imFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.KeepAspectRatio = chkBox_KeepAspectRatio.Checked;
            Properties.Settings.Default.TargetImageWidth = m_NewWidth;
            Properties.Settings.Default.TargetImageHeight = m_NewHeight;
            Properties.Settings.Default.Save();
            GetImageFormat(ref imgFormat, ref pixFormat);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();

        }

        private void EnsureAspectRatio()
        {
            if (chkBox_KeepAspectRatio.Checked)
            {
                if (m_OrgImage.Width > m_OrgImage.Height)
                {
                    if (m_OrgImage.Width > m_NewWidth)
                    {
                        m_NewHeight = (m_NewWidth * m_OrgImage.Height) / m_OrgImage.Size.Width;
                        this.numericUpDown_TargetHeight.Value = m_NewHeight;
                    }
                }
                else
                {
                    if (m_OrgImage.Height > m_NewHeight)
                    {
                        m_NewWidth = (m_NewHeight * m_OrgImage.Width) / m_OrgImage.Size.Height;
                        this.numericUpDown_TargetWidth.Value = m_NewWidth;
                    }
                }
            }
        }
        private void chkBox_KeepAspectRatio_CheckedChanged(object sender, EventArgs e)
        {
            EnsureAspectRatio();
        }

        private void numericUpDown_TargetWidth_ValueChanged(object sender, EventArgs e)
        {
            if (chkBox_KeepAspectRatio.Checked)
            {
                if (!bChangeTargetHeight)
                {
                    bChangeTargetWidth = true;
                    int width = Convert.ToInt32(numericUpDown_TargetWidth.Value);
                    this.numericUpDown_TargetHeight.Value = ((int)(width * m_OrgImage.Height) / m_OrgImage.Width);
                    bChangeTargetWidth = false;
                }
            }
        }

        private void numericUpDown_TargetHeight_ValueChanged(object sender, EventArgs e)
        {
            if (chkBox_KeepAspectRatio.Checked)
            {

                if (!bChangeTargetWidth)
                {
                    bChangeTargetHeight = true;
                    int height = Convert.ToInt32(numericUpDown_TargetHeight.Value);
                    this.numericUpDown_TargetWidth.Value = ((int)(height * m_OrgImage.Width) / m_OrgImage.Height);
                    bChangeTargetHeight = false;
                }
            }
        }

        private void RotateFlipImage(RotateFlipType flip)
        {
            Cursor.Current = Cursors.WaitCursor;
            m_OrgImage.RotateFlip(flip);
            pictureBox_Source.Image = m_OrgImage;
            WriteSourceDimensions();
            ChangeSize();
            pictureBox_Source.Refresh();
            pictureBox_Destination.Refresh();
            Cursor.Current = Cursors.Arrow;

        }

        private void btnRotate90clockwise_Click(object sender, EventArgs e)
        {
            RotateFlipImage(RotateFlipType.Rotate90FlipNone);
        }

        private void btnRotate90contra_clockwise_Click(object sender, EventArgs e)
        {
            RotateFlipImage(RotateFlipType.Rotate270FlipNone);
        }

        private void btnFlipHorisontal_Click(object sender, EventArgs e)
        {
            RotateFlipImage(RotateFlipType.RotateNoneFlipX);
        }

        private void btnFlipVertical_Click(object sender, EventArgs e)
        {
            RotateFlipImage(RotateFlipType.RotateNoneFlipY);
        }

        private void lbl_SourceSize_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Format_Click(object sender, EventArgs e)
        {

        }

    }
}
