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
            if (wb!=null)
            {
                this.Controls.Remove(wb);
                wb.Dispose();
                wb = null;
            }
            wb = new WebBrowser();
            string xurl = "";
            switch (xShow)
            {
                case IdleControl.eShow.URL1:
                    xurl = m_IdleCtrl.URL1;
                    break;
                case IdleControl.eShow.URL2:
                    xurl = m_IdleCtrl.URL2;
                    break;
            }
            wb.Url = new Uri(xurl);
            wb.Top = this.btn_WebBrowserGoBack.Top + this.btn_WebBrowserGoBack.Height + 2;
            wb.Left = 0;
            wb.Width = this.Width;
            wb.Height = this.Height - wb.Top;
            wb.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            wb.Visible = true;
            this.Controls.Add(wb);
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            m_usrc_MultipleUsers.Visible = true;
            m_IdleCtrl.TimerCounter_Start();

        }

        private void btn_URL1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Form_ImageOfUrl frm_imgurl = new Form_ImageOfUrl(wb, this.btn_URL1, m_IdleCtrl);
                frm_imgurl.ShowDialog(this);
            }
        }
    }
}
