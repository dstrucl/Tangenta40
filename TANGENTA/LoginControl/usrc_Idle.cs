using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginControl
{
    public partial class usrc_Idle : UserControl
    {
        internal IdleControl m_IdleCtrl = null;
        internal usrc_MultipleUsers m_usrc_MultipleUsers = null;

        WebBrowser wb = null;

        public usrc_Idle()
        {
            InitializeComponent();

        }

        internal void Show(IdleControl.eShow xShow)
        {
            if (m_IdleCtrl!=null)
            {
                if (m_IdleCtrl.ImageUrl1!=null)
                {
                    btn_URL1.Image = m_IdleCtrl.ImageUrl1;
                    btn_URL1.Text = "";
                }
                if (m_IdleCtrl.ImageUrl2 != null)
                {
                    btn_URL2.Image = m_IdleCtrl.ImageUrl2;
                    btn_URL2.Text = "";
                }
            }

            if (wb!=null)
            {
                this.Controls.Remove(wb);
                wb.Dispose();
                wb = null;
            }
            wb = new WebBrowser();
            string xurl = "";

            wb.Top = this.btn_WebBrowserGoBack.Top + this.btn_WebBrowserGoBack.Height + 2;
            wb.Left = 0;
            wb.Width = this.Width;
            wb.Height = this.Height - wb.Top;
            wb.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            wb.Visible = true;

            switch (xShow)
            {
                case IdleControl.eShow.URL1:
                    xurl = m_IdleCtrl.URL1;
                    btn_URL1.Visible = false;
                    m_IdleCtrl.TimerCounter_Stop();
                    if (m_IdleCtrl.UseExitButton)
                    {
                        btn_URL2.Visible = true;
                        btn_Exit.Visible = true;
                        btn_WebBrowserGoBack.Visible = true;
                        btn_WebBrowserGoForward.Visible = true;
                        btn_WebBrowserGoHome.Visible = true;
                        txt_URL.Visible = true;
                        txt_URL.Text = xurl;
                    }
                    else
                    {
                        btn_URL2.Visible = false;
                        btn_Exit.Visible = false;
                        btn_WebBrowserGoBack.Visible = false;
                        btn_WebBrowserGoForward.Visible = false;
                        btn_WebBrowserGoHome.Visible = false;
                        txt_URL.Visible = false;
                        wb.DocumentCompleted += Wb_DocumentCompleted;
                        wb.Top = 0;
                        wb.Left = 0;
                        wb.Width = this.Width;
                        wb.Height = this.Width;
                    }
                    break;
                case IdleControl.eShow.URL2:
                    xurl = m_IdleCtrl.URL2;
                    btn_URL1.Visible = true;
                    btn_URL2.Visible = false;
                    m_IdleCtrl.TimerCounter_Start();
                    break;
            }
            wb.Url = new Uri(xurl);
            this.Controls.Add(wb);
        }

        private void Wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlDocument document = wb.Document;
            document.Body.KeyDown += Body_KeyDown;
            document.Body.MouseUp += Body_MouseUp; 

        }

        private void Body_MouseUp(object sender, HtmlElementEventArgs e)
        {
            Exit();
        }

        private void Body_KeyDown(object sender, HtmlElementEventArgs e)
        {
            Exit();
        }

        private void Exit()
        {
            if (wb != null)
            {
                this.Controls.Remove(wb);
                wb.Dispose();
                wb = null;
            }
            this.Visible = false;
            m_usrc_MultipleUsers.Visible = true;
            m_IdleCtrl.TimerCounter_Start();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {

            Exit();
        }

        private void btn_URL1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Form_ImageOfUrl frm_imgurl = new Form_ImageOfUrl(IdleControl.eShow.URL1,wb, this.btn_URL1, m_IdleCtrl);
                frm_imgurl.ShowDialog(this);
            }
        }

        private void btn_URL1_Click(object sender, EventArgs e)
        {
            if (m_IdleCtrl != null)
            {
                if (m_IdleCtrl.URL1 != null)
                {
                    if (m_IdleCtrl.URL1.Length > 0)
                    {
                        Show(IdleControl.eShow.URL1);
                    }
                }
            }
        }

        private void btn_URL2_Click(object sender, EventArgs e)
        {
            if (m_IdleCtrl != null)
            {
                if (m_IdleCtrl.URL2 != null)
                {
                    if (m_IdleCtrl.URL2.Length > 0)
                    {
                        Show(IdleControl.eShow.URL2);
                    }
                }
            }
        }

        private void btn_URL2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Form_ImageOfUrl frm_imgurl = new Form_ImageOfUrl(IdleControl.eShow.URL2, wb, this.btn_URL2, m_IdleCtrl);
                frm_imgurl.ShowDialog(this);
            }
        }

    }
}
