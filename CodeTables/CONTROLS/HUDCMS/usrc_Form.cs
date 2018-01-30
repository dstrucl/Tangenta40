using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HUDCMS
{
    public partial class usrc_Form : UserControl
    {
        public usrc_Form()
        {
            InitializeComponent();
        }

        internal void Init(hctrl hc)
        {
            if (hc.pForm != null)
            {
                string sModal = null;
                if (hc.pForm.Modal)
                {
                    sModal = "Yes";
                }
                else
                {
                    sModal = "No";
                }
                this.lbl_Dialog.Text = HUDCMS_static.slng_FormName + "=" + hc.pForm.Name + " " + HUDCMS_static.slng_FormTitle +":\""+ hc.pForm.Text+"\" Modal:" + sModal;
                this.pic_Form.Image = hc.ctrlbmp;
            }
            else
            {
                MessageBox.Show("ERROR:usrc_Form:(hc.pForm != null)");
            }
        }
    }
}
