using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public Form_ImageOfUrl()
        {
            InitializeComponent();
        }

        public Form_ImageOfUrl(WebBrowser wb,Button btn, IdleControl x_IdleCtrl)
        {
            InitializeComponent();
            m_IdleCtrl = x_IdleCtrl;
            m_wb = wb;
            m_btn = btn;
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }



        private void btn_SetImage_Click(object sender, EventArgs e)
        {
            Size size = new Size(m_btn.Width, m_btn.Height);
            this.pictureBox2.Image = resizeImage(pictureBox1.Image, size);
            m_btn.Image = this.pictureBox2.Image;
            m_btn.Text = "";

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
    }
}
