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
        internal MyControl my_Control = null;

        private Control ctrlx = null;
        public usrc_EditLayout()
        {
            InitializeComponent();
        }

        internal void Init(MyControl myctrl)
        {
            if (my_Control != null)
            {
                // save previous user_Control edited data!
                if (my_Control.hc!=null)
                {
                    if (my_Control.hc.ctrl != null)
                    {
                        my_Control.SetControlProperties(my_Control.hc.ctrl);
                    }
                }
            }

            my_Control = myctrl;

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
            my_Control.Left = ctrlx.Left;
        }

        private void nmUpDnY_ValueChanged(object sender, EventArgs e)
        {
            ctrlx.Top = Convert.ToInt32(nmUpDnY.Value);
            ctrlx.Refresh();
            my_Control.Top = ctrlx.Top;
        }

        private void nmUpDnWidth_ValueChanged(object sender, EventArgs e)
        {
            ctrlx.Width = Convert.ToInt32(nmUpDnWidth.Value);
            ctrlx.Refresh();
            my_Control.Width = ctrlx.Width;
        }

        private void nmUpDnHeight_ValueChanged(object sender, EventArgs e)
        {
            ctrlx.Height = Convert.ToInt32(nmUpDnHeight.Value);
            ctrlx.Refresh();
            my_Control.Height = ctrlx.Height;

        }

        private void btn_Up_Click(object sender, EventArgs e)
        {
            nmUpDnY.Value = nmUpDnY.Value+1;
        }

        private void btn_Down_Click(object sender, EventArgs e)
        {
            nmUpDnY.Value = nmUpDnY.Value-1;
        }

        private void btn_Left_Click(object sender, EventArgs e)
        {
            nmUpDnX.Value = nmUpDnX.Value - 1;
        }

        private void btn_Right_Click(object sender, EventArgs e)
        {
            nmUpDnX.Value = nmUpDnX.Value + 1;
        }

        private void btn_WidthMinus_Click(object sender, EventArgs e)
        {
            nmUpDnWidth.Value = nmUpDnWidth.Value - 1;
        }

        private void btn_WidthPlus_Click(object sender, EventArgs e)
        {
            nmUpDnWidth.Value = nmUpDnWidth.Value + 1;
        }

        private void btn_HeightMinus_Click(object sender, EventArgs e)
        {
            nmUpDnHeight.Value = nmUpDnHeight.Value - 1;
        }

        private void btn_HeightPlus_Click(object sender, EventArgs e)
        {
            nmUpDnHeight.Value = nmUpDnHeight.Value + 1;
        }
    }
}
