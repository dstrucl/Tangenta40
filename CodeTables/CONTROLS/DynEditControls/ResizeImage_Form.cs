#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
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
using System.IO;

namespace DynEditControls
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
            this.lblDestinationWidth.Text = lng.s_Width.s + "=";
            this.lblDestinationHeight.Text = lng.s_Height.s + "=";
            this.chkBox_KeepAspectRatio.Text = lng.s_KeepAspectRation.s;
            this.Text = lng.s_ResizeImage.s;
            this.btnChangeSize.Text = "> "+lng.s_ResizeImage.s + " >";
            this.pictureBox_Source.Image = OrgImage;
            this.btnOK.Text = lng.s_OK.s;
            this.btn_Cancel.Text = lng.s_Cancel.s;
            if (chkBox_KeepAspectRatio.Checked)
            {
                m_NewImage = PutImageInBoundaries(m_OrgImage, m_NewWidth, m_NewHeight, OrgImage.RawFormat);
            }
            else
            {
                Size size = new Size(m_NewWidth,m_NewHeight);
                m_NewImage = resizeImage(m_OrgImage, size, OrgImage.RawFormat);
            }
            this.pictureBox_Destination.Image = m_NewImage;
            WriteSize();

        }

        private void WriteSourceDimensions()
        {
            this.lblSourceWidth.Text = lng.s_Width.s + " = " + m_OrgImage.Width.ToString();
            this.lblSourceHeight.Text = lng.s_Height.s + " = " + m_OrgImage.Height.ToString();
        }

        private void WriteDestinationDimensions()
        {
            this.numericUpDown_TargetWidth.Value = pictureBox_Destination.Image.Width;
            this.numericUpDown_TargetHeight.Value = pictureBox_Destination.Image.Height;
        }

        private void WriteSize()
        {
            this.lbl_SourceSize.Text = lng.s_Format.s + "=" + GetImageFormatName(m_OrgImage) + ", " + lng.s_Size.s + "=" + DBTypes.DBtypesFunc.GetObjectSize(m_OrgImage).ToString("n") + " " + lng.s_Bytes.s;
            this.lbl_DestinationSize.Text = lng.s_Size.s + "=" + DBTypes.DBtypesFunc.GetObjectSize(m_NewImage).ToString("n") + " " + lng.s_Bytes.s;
            this.lbl_Format.Text = lng.s_Format.s + ":";
            this.cmbBoxPictureFormat.Text = GetImageFormatName(m_NewImage);
        }

        private void ChangeSize()
        {
            m_NewWidth = Convert.ToInt32(this.numericUpDown_TargetWidth.Value);
            m_NewHeight = Convert.ToInt32(this.numericUpDown_TargetHeight.Value);
            if (chkBox_KeepAspectRatio.Checked)
            {
                if (GetImageFormat(ref imgFormat,ref pixFormat))
                {
                    m_NewImage = PutImageInBoundaries(m_OrgImage, m_NewWidth, m_NewHeight, imgFormat);
                    pictureBox_Destination.Image = m_NewImage;
                }
            }
            else
            {
                if (GetImageFormat(ref imgFormat, ref pixFormat))
                {
                    Size size = new Size(m_NewWidth, m_NewHeight);
                    m_NewImage = resizeImage(m_OrgImage, size, imgFormat);
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

        public Image resizeImage(Image imgToResize, Size size, System.Drawing.Imaging.ImageFormat destformat)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);

            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            Image img = (Image)b;

            byte[] bin = DBTypes.DBtypesFunc.imageToByteArray(img, destformat);
            //byte[] bin = DBTypes.DBtypesFunc.imageToByteArray(img);
            ImageConverter ic = new ImageConverter();
            return (Image)ic.ConvertFrom(bin);

        }

        public Image resizeImage(Image imgToResize, Size size, System.Drawing.Imaging.ImageFormat destformat, PixelFormat pixel_format)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(size.Width, size.Height, PixelFormat.Format1bppIndexed);

            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.Bicubic;

            g.DrawImage(imgToResize, 0, 0, size.Width, size.Height);
            g.Dispose();

            Image img = (Image)b;

            byte[] bin = imageToByteArray(img, destformat);
            //byte[] bin = DBTypes.DBtypesFunc.imageToByteArray(img);
            ImageConverter ic = new ImageConverter();
            return (Image)ic.ConvertFrom(bin);

        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn, System.Drawing.Imaging.ImageFormat imgformat)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, imgformat);
            //SaveImageInFormat(imageIn, ms);
            return ms.ToArray();
        }

        public Image PutImageInBoundaries(Image OrgImage, int MAX_PICTURE_WIDTH, int MAX_PICTURE_HEIGHT, System.Drawing.Imaging.ImageFormat destformat)
        {
            int myWidth;
            int myHeight;
            if (OrgImage.Width > OrgImage.Height)
            {
                if (OrgImage.Width > MAX_PICTURE_WIDTH)
                {
                    myWidth = MAX_PICTURE_WIDTH;
                    myHeight = (MAX_PICTURE_WIDTH * OrgImage.Height) / OrgImage.Size.Width;
                    Size size = new Size(myWidth, myHeight);
                    return resizeImage(OrgImage, size, destformat);
                }
                else
                {
                    return OrgImage;
                }
            }
            else
            {
                if (OrgImage.Height > MAX_PICTURE_HEIGHT)
                {
                    myHeight = MAX_PICTURE_HEIGHT;
                    myWidth = (MAX_PICTURE_HEIGHT * OrgImage.Width) / OrgImage.Size.Height;
                    Size size = new Size(myWidth, myHeight);
                    return resizeImage(OrgImage, size, destformat);
                }
                else
                {
                    return OrgImage;
                }
            }


        }

        public static List<string> GetImageDecoders()
        {
            List<string> ImageDecoderList = new List<string>();
            // Get an array of available decoders.
            ImageCodecInfo[] myCodecs;
            myCodecs = ImageCodecInfo.GetImageDecoders();
            int numCodecs = myCodecs.GetLength(0);


            // Check to determine whether any codecs were found. 
            if (numCodecs > 0)
            {
                // Set up an array to hold codec information. There are 9 
                // information elements plus 1 space for each codec, so 10 times 
                // the number of codecs found is allocated. 
                string[] myCodecInfo = new string[numCodecs * 10];
                int i;

                // Write all the codec information to the array. 
                for (i = 0; i < numCodecs; i++)
                {
                    myCodecInfo[i * 10] = "Codec Name = " + myCodecs[i].CodecName;
                    myCodecInfo[(i * 10) + 1] = "Class ID = " +
                        myCodecs[i].Clsid.ToString();
                    myCodecInfo[(i * 10) + 2] = "DLL Name = " + myCodecs[i].DllName;
                    myCodecInfo[(i * 10) + 3] = "Filename Ext. = " +
                        myCodecs[i].FilenameExtension;
                    myCodecInfo[(i * 10) + 4] = "Flags = " +
                        myCodecs[i].Flags.ToString();
                    myCodecInfo[(i * 10) + 5] = "Format Descrip. = " +
                        myCodecs[i].FormatDescription;
                    myCodecInfo[(i * 10) + 6] = "Format ID = " +
                        myCodecs[i].FormatID.ToString();
                    myCodecInfo[(i * 10) + 7] = "MimeType = " + myCodecs[i].MimeType;
                    myCodecInfo[(i * 10) + 8] = "Version = " +
                        myCodecs[i].Version.ToString();
                    myCodecInfo[(i * 10) + 9] = " ";
                }
                int numMyCodecInfo = myCodecInfo.GetLength(0);

                // Render all of the information to the screen. 
                for (i = 0; i < numMyCodecInfo; i++)
                {
                    ImageDecoderList.Add(myCodecInfo[i]);
                }
            }
            return ImageDecoderList;
        }

        public static string GetImageFormatName(Image img)
        {

            if (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Bmp.Guid)
                return "Bmp";
            else if (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Emf.Guid)
                return "Emf";
            else if (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Exif.Guid)
                return "Exif";
            else if (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Gif.Guid)
                return "Gif";
            else if (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Icon.Guid)
                return "Icon";
            else if (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Jpeg.Guid)
                return "Jpeg";
            else if (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.MemoryBmp.Guid)
                return "MemoryBmp";
            else if (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Png.Guid)
                return "Png";
            else if (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Tiff.Guid)
                return "Tiff";
            else if (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Wmf.Guid)
                return "Wmf";
            else
                return "Unknown Image Format!";
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
                if (MessageBox.Show(lng.s_UnknownPictureFormatSaveInJpg.s, lng.s_SaveInJpgQuestion.s, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
