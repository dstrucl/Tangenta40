using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HUDCMS
{
    public partial class Form_HUDCMS : Form
    {
        private hctrl hc = null;
        private usrc_Help mH = null;

        public Form_HUDCMS(usrc_Help xH)
        {
            InitializeComponent();
            mH = xH;
            hc = new hctrl(mH.pForm);
            int y= 0;
            CreateControls(ref y,hc);
        }

        private void CreateControls(ref int y, hctrl hc)
        {

            if (hc.pForm!=null)
            {
                //this is a Form control
                usrc_Form uForm = new usrc_Form();
                uForm.Init(hc);
                uForm.Top = y;
                uForm.Left = 2;
                uForm.Width = this.Width - uForm.Left;
                uForm.Visible = true;
                HUDCMS_static.SetControlAnchorAll(uForm);
                this.Controls.Add(uForm);
            }
        }
    }
}
