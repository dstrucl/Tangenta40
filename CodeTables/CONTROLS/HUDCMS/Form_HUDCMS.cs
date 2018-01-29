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
        Form pForm = null;
        string sLocalHtmlFile = null;
        public Form_HUDCMS(Form xpForm, string xsLocalHtmlFile)
        {
            InitializeComponent();
            pForm = xpForm;
            sLocalHtmlFile = xsLocalHtmlFile;
            hc = new hctrl(pForm);
            if (hc.ctrlbmp != null)
            {
                pic_Form.Width = hc.ctrlbmp.Width;
                pic_Form.Height = hc.ctrlbmp.Height;
                pic_Form.Image = hc.ctrlbmp;
            }
        }
    }
}
