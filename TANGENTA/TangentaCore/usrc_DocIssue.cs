using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TangentaCore
{
    public partial class usrc_DocIssue : UserControl
    {
        public delegate void delegate_Click(object sender, EventArgs e);
        public event delegate_Click DoClick;

        public usrc_DocIssue()
        {
            InitializeComponent();
        }

        private void do_myclick(EventArgs e)
        {
            if (btn_Issue.Visible)
            {
                timer1.Enabled = true;
                this.BackgroundImage = TangentaResources.Properties.Resources.IssuePressed;
                if (DoClick != null)
                {
                    DoClick(this, e);
                }
            }
        }
    
        public string Total
        {
            get
            {
                return lbl_Sum.Text;
            }
            set
            {
                lbl_Sum.Text = value;
            }
        }

        public Color TotalColor
        {
            get
            {
                return lbl_Sum.ForeColor;
            }
            set
            {
                lbl_Sum.ForeColor = value;
            }
        }

        public bool BtnIssueVisible
        {
            get
            {
                return btn_Issue.Visible;
            }
            set
            {
                btn_Issue.Visible = value;
            }
        }
        public string BtnIssueLabel
        {
            get
            {
                return btn_Issue.Text;
            }
            set
            {
                btn_Issue.Text = value;
            }
        }
        
        private void usrc_DocIssue_Click(object sender, EventArgs e)
        {
            do_myclick(e);
        }

        private void lbl_Sum_Click(object sender, EventArgs e)
        {
            do_myclick(e);
        }

        private void btn_Issue_Click(object sender, EventArgs e)
        {
            do_myclick(e);
        }

        private void usrc_DocIssue_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = TangentaResources.Properties.Resources.IssueUnpressed;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.BackgroundImage = TangentaResources.Properties.Resources.IssueUnpressed;
        }
    }
}
