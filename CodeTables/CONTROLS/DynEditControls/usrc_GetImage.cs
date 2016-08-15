using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace DynEditControls
{
    public partial class usrc_GetImage : UserControl
    {
        private Image m_Image = null;
        private string m_Image_Hash = null;
        public System.Drawing.Imaging.ImageFormat imgFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
        public System.Drawing.Imaging.PixelFormat pixFormat = System.Drawing.Imaging.PixelFormat.Format24bppRgb;

        private SHA1CryptoServiceProvider my_SHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();


        public Image Image
        {
            get { return m_Image; }
            set
            {
                m_Image = value;
                if (m_Image!=null)
                {
                    pic.Image = m_Image;
                    pic.Refresh();
                    byte[] ba = imageToByteArray(m_Image);
                    m_Image_Hash = GetHash_SHA1(ba);
                }
                else
                {
                    m_Image_Hash = null;
                }
            }
        }

        public string Image_Hash
        {
            get { return m_Image_Hash; }
        }

        public byte[] Image_Bytes
        {
            get
            {
                if (m_Image != null)
                {
                    byte[] ba = imageToByteArray(m_Image);
                    m_Image_Hash = GetHash_SHA1(ba);
                    return ba;
                }
                else
                {
                    m_Image_Hash = null;
                    return null;
                }
            }
        }

        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public string GetHash_SHA1(byte[] byteArray)
        {
            string hash = "";
            hash = Convert.ToBase64String(my_SHA1CryptoServiceProvider.ComputeHash(byteArray));
            return hash;
        }

        public usrc_GetImage()
        {
            InitializeComponent();
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            DialogResult dRes;
            OpenFileDialog opnFileDlg = new OpenFileDialog();
            opnFileDlg.Filter = "Picture files (*.jpg)|*.jpg|All files (*.*)|*.* ";
            opnFileDlg.FilterIndex = 2;
            opnFileDlg.FileName = "*.*"; //PathImport + "\\" + btnSelectFile.m_InputTextBox.Text;
            opnFileDlg.RestoreDirectory = true;
            dRes = opnFileDlg.ShowDialog();
            if (dRes == DialogResult.OK)
            {
                Image OrgImage = new Bitmap(opnFileDlg.FileName);
                //if ((OrgImage.Width <= MAX_PICTURE_WIDTH) && (OrgImage.Height <= MAX_PICTURE_HEIGHT))
                //{
                //    Picture.Image = OrgImage;
                //}
                //else
                //{

                //}

                ResizeImage_Form resdlg = new ResizeImage_Form(OrgImage);
                if (resdlg.ShowDialog() == DialogResult.OK)
                {
                    this.Image = (Image)resdlg.m_NewImage.Clone();
                    imgFormat = this.Image.RawFormat;
                }
                else
                {
                    this.Image = OrgImage;
                    imgFormat = this.Image.RawFormat;
                }
                pic.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
    }
}
