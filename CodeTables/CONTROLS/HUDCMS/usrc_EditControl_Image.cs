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
    public partial class usrc_EditControl_Image : UserControl
    {
        usrc_EditControl m_usrc_EditControl = null;
        public usrc_EditControl_Image()
        {
            InitializeComponent();
        }

        private void fastColoredTextBox1_Load(object sender, EventArgs e)
        {
            usrc_EditControl.GetUsrcEditControl(this, ref m_usrc_EditControl);
        }

        private void nmUpDn_SnapShotMargin_ValueChanged(object sender, EventArgs e)
        {
            this.nmUpDn_SnapShotMargin.ValueChanged -= new System.EventHandler(this.nmUpDn_SnapShotMargin_ValueChanged);
            m_usrc_EditControl.SnapShotMargin = Convert.ToInt32(nmUpDn_SnapShotMargin.Value);
            this.nmUpDn_SnapShotMargin.ValueChanged += new System.EventHandler(this.nmUpDn_SnapShotMargin_ValueChanged);
        }
    }
}
