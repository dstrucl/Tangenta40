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
    public partial class usrc_RootControl : UserControl
    {
        private usrc_Help uH = null;

        public usrc_RootControl()
        {
            InitializeComponent();
        }

        internal void Init(usrc_Help xuH, hctrl hc)
        {
            uH = xuH;
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
                this.pic_Control.Image = hc.ctrlbmp;
            }
            else
            {
                this.lbl_Dialog.Text = HUDCMS_static.slng_UserControlName + "=" + hc.ctrl.Name;
            }
        }
    }
}
