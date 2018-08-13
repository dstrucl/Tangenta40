using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginControl
{
    public partial class Form_ImageOfUrl : Form
    {
        private IdleControl m_IdleCtrl = null;
        private WebBrowser m_wb = null;
        private Button m_btn = null;
        public Bitmap bmp = null;
        IdleControl.eShow eshow = IdleControl.eShow.URL1;

        public Form_ImageOfUrl()
        {
            InitializeComponent();
        }

        public Form_ImageOfUrl(IdleControl.eShow xshow,WebBrowser wb,Button btn, IdleControl x_IdleCtrl)
        {
            InitializeComponent();
            m_IdleCtrl = x_IdleCtrl;
            m_wb = wb;
            m_btn = btn;
            eshow = xshow;

            string s_url = null;
            switch (eshow)
            {
                case IdleControl.eShow.URL1:
                    s_url = m_IdleCtrl.URL1;
                    break;
                case IdleControl.eShow.URL2:
                    s_url = m_IdleCtrl.URL2;
                    break;
            }
            lng.s_Form_ImageOfUrl.Text(this, s_url);
            lng.s_btn_SetImage.Text(btn_SetImage);

        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }



        private void btn_SetImage_Click(object sender, EventArgs e)
        {
            Size size = new Size(m_btn.Height, m_btn.Height);
            this.pictureBox2.Image = resizeImage(pictureBox1.Image, size);
            m_btn.Image = this.pictureBox2.Image;
            m_btn.Text = "";
            string sappfolder = Global.f.GetApplicationDataFolder();
            switch (eshow)
            {
                case IdleControl.eShow.URL1:
                    m_IdleCtrl.ImageUrl1 = this.pictureBox2.Image;
                    m_IdleCtrl.FileImageUrl1 = sappfolder + "\\ImageUrl1.bmp";
                    if (File.Exists(m_IdleCtrl.FileImageUrl1))
                    {
                        try
                        {
                            File.Delete(m_IdleCtrl.FileImageUrl1);
                        }
                        catch (Exception ex)
                        {
                            LogFile.Error.Show("ERROR:LoginControl:Form_ImageOfURL: can not delete file :" + m_IdleCtrl.FileImageUrl1+"\r\nException="+ex.Message);
                        }
                    }
                    m_IdleCtrl.ImageUrl1.Save(m_IdleCtrl.FileImageUrl1, System.Drawing.Imaging.ImageFormat.Jpeg);
                    try
                    {
                        m_IdleCtrl.ImageUrl1.Save(m_IdleCtrl.FileImageUrl1, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch (Exception ex)
                    {
                        LogFile.Error.Show("ERROR:LoginControl:Form_ImageOfURL: can not save file :" + m_IdleCtrl.FileImageUrl1 + "\r\nException=" + ex.Message);
                    }
                    break;

                case IdleControl.eShow.URL2:
                    m_IdleCtrl.ImageUrl2 = this.pictureBox2.Image;
                    m_IdleCtrl.FileImageUrl2 = sappfolder + "\\ImageUrl2.bmp";
                    if (File.Exists(m_IdleCtrl.FileImageUrl2))
                    {
                        try
                        {
                            File.Delete(m_IdleCtrl.FileImageUrl2);
                        }
                        catch (Exception ex)
                        {
                            LogFile.Error.Show("ERROR:LoginControl:Form_ImageOfURL: can not delete file :" + m_IdleCtrl.FileImageUrl2 + "\r\nException=" + ex.Message);
                        }
                    }
                    try
                    {
                        m_IdleCtrl.ImageUrl2.Save(m_IdleCtrl.FileImageUrl2, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch(Exception ex)
                    {
                        LogFile.Error.Show("ERROR:LoginControl:Form_ImageOfURL: can not save file :" + m_IdleCtrl.FileImageUrl2 + "\r\nException=" + ex.Message);
                    }
                    break;

            }
        }

        private void Form_ImageOfUrl_Load(object sender, EventArgs e)
        {
            if (m_wb != null)
            {
                bmp = new Bitmap(m_wb.Width, m_wb.Height);
                Rectangle rect = new Rectangle(0, 0, m_wb.Width, m_wb.Height);
                m_wb.DrawToBitmap(bmp, rect);
                this.pictureBox1.Image = bmp;
            }
            else
            {
                LogFile.Error.Show("ERROR:LoginControl:Form_ImageOfUrl:Form_ImageOfUrl_Load:WebBrowser (m_wb) == null!");
                this.Close();
                DialogResult = DialogResult.Abort;
            }

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }
    }
}
