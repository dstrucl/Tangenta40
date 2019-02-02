using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LayoutManager
{
    public partial class usrc_EditLayout : UserControl
    {
        private Control ctrlx = null;
        public usrc_EditLayout()
        {
            InitializeComponent();
        }

        internal void Init(MyControl myctrl)
        {
            ctrlx = myctrl.hc.ctrl;
            setNumUpDn(this.nmUpDnX, ctrlx.Left);
            setNumUpDn(this.nmUpDnY,ctrlx.Top);
            setNumUpDn(this.nmUpDnWidth, ctrlx.Width);
            setNumUpDn(this.nmUpDnHeight, ctrlx.Height);
            this.txtControl.Text = myctrl.ControlUniqueName;
            setAnchor(ctrlx);
            if (myctrl.hc.ctrlbmp!=null)
            {
                this.pictureBox1.Image = myctrl.hc.ctrlbmp;
            }
        }

        private void setAnchor(Control ctrlx)
        {
            if ((ctrlx.Anchor & AnchorStyles.Left) !=0)
            {
                chkAnchorLeft.Checked = true;
            }
            else
            {
                chkAnchorLeft.Checked = false;
            }
            if ((ctrlx.Anchor & AnchorStyles.Right) != 0)
            {
                chkAnchorRight.Checked = true;
            }
            else
            {
                chkAnchorRight.Checked = false;
            }
            if ((ctrlx.Anchor & AnchorStyles.Top) != 0)
            {
                chkAnchorTop.Checked = true;
            }
            else
            {
                chkAnchorTop.Checked = false;
            }

            if ((ctrlx.Anchor & AnchorStyles.Bottom) != 0)
            {
                chkAnchorBottom.Checked = true;
            }
            else
            {
                chkAnchorBottom.Checked = false;
            }

        }

        private void setNumUpDn(NumericUpDown nmUpDnX, int i)
        {
            nmUpDnX.Minimum = -1000;
            nmUpDnX.Maximum = 10000;
            nmUpDnX.DecimalPlaces = 0;
            nmUpDnX.Value = Convert.ToDecimal(i);
            nmUpDnX.Increment = 1;
        }

        private void nmUpDnX_ValueChanged(object sender, EventArgs e)
        {
            ctrlx.Left = Convert.ToInt32(nmUpDnX.Value);
            ctrlx.Refresh();
        }
    }
}
