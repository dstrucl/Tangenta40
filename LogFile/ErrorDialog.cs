using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



namespace LogFile
{
    public partial class ErrorDialog : Form
    {
        private Object m_MainWindow = null;
        private string m_Text = null;
        private string m_Title = null;
        private Icon m_icon = null;


        public ErrorDialog(string sText, string sTitle, Object MainWnd, System.Windows.Forms.MessageBoxButtons MB_buttons, Icon ico)
        {

            m_Text = sText;
            m_Title = sTitle;
            m_MainWindow = MainWnd;
            m_icon = ico;
            InitializeComponent();
            switch (MB_buttons)
            {
                case MessageBoxButtons.OK:
                    btn1.Text = "OK";
                    btn1.Tag = DialogResult.OK;
                    btn1.Visible = true;
                    btn2.Visible = false;
                    btn3.Visible = false;

                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    btn1.Text = "Abort";
                    btn1.Tag = DialogResult.Abort;
                    btn2.Text = "Retry";
                    btn2.Tag = DialogResult.Retry;
                    btn3.Text = "Ignore";
                    btn3.Tag = DialogResult.Ignore;
                    btn1.Visible = true;
                    btn2.Visible = true;
                    btn3.Visible = true;
                    break;
                case MessageBoxButtons.OKCancel:
                    btn1.Text = "OK";
                    btn1.Tag = DialogResult.OK;
                    btn2.Text = "Cancel";
                    btn2.Tag = DialogResult.Cancel;
                    btn3.Text = "";
                    btn1.Visible = true;
                    btn2.Visible = true;
                    btn3.Visible = false;
                    break;
                case MessageBoxButtons.RetryCancel:
                    btn1.Text = "Retry";
                    btn1.Tag = DialogResult.Retry;
                    btn2.Text = "Cancel";
                    btn2.Tag = DialogResult.Cancel;
                    btn3.Text = "";
                    btn1.Visible = true;
                    btn2.Visible = true;
                    btn3.Visible = false;
                    break;
                case MessageBoxButtons.YesNo:
                    btn1.Text = "Yes";
                    btn1.Tag = DialogResult.Yes;
                    btn2.Text = "No";
                    btn2.Tag = DialogResult.No;
                    btn3.Text = "";
                    btn1.Visible = true;
                    btn2.Visible = true;
                    btn3.Visible = false;
                    break;
                case MessageBoxButtons.YesNoCancel:
                    btn1.Text = "Yes";
                    btn1.Tag = DialogResult.Yes;
                    btn2.Text = "No";
                    btn2.Tag = DialogResult.No;
                    btn3.Text = "Cancel";
                    btn3.Tag = DialogResult.Cancel;
                    btn1.Visible = true;
                    btn2.Visible = true;
                    btn3.Visible = true;
                    break;
                default:
                    btn1.Text = "OK";
                    btn1.Tag = DialogResult.OK;
                    btn1.Visible = true;
                    btn2.Visible = false;
                    btn3.Visible = false;
                    break;
            }
            this.TopMost = true;
        }

        public ErrorDialog(string sText, string sTitle, Object MainWnd, Icon ico)
        {

            m_Text = sText;
            m_Title = sTitle;
            m_MainWindow = MainWnd;
            m_icon = ico;
            InitializeComponent();

            btn1.Text = "OK";
            btn1.Tag = DialogResult.OK;
            btn1.Visible = true;
            btn2.Visible = false;
            btn3.Visible = false;

            this.TopMost = true;
            Screen scr = Screen.FromControl(this);
            Point pt = new Point((scr.Bounds.Size.Width / 2) - (this.Size.Width / 2), (scr.Bounds.Size.Height / 2) - (this.Size.Height / 2));
            this.Left = pt.X;
            this.Top = pt.Y;

        }

        private void ErrorDialog_Load(object sender, EventArgs e)
        {


  

            if (m_MainWindow!=null)
            {
                if ((m_MainWindow.GetType() == typeof(Form))
                    || (m_MainWindow.GetType().BaseType == typeof(Form)))
                {
                    this.Owner = (Form) m_MainWindow;
                }
            }
            this.txtErrorMessage.Text = m_Text;
            this.Text = m_Title;
            if (m_icon != null)
            {
                this.Icon = m_icon;
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            DialogResult = (DialogResult)btn.Tag;
            Close();
        }

    }
}
