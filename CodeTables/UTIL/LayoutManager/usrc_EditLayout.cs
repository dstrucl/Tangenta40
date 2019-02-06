using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ColorSettings;

namespace LayoutManager
{
    public partial class usrc_EditLayout : UserControl
    {
        public delegate void delegate_LayoutChanged();
        public event delegate_LayoutChanged LayoutChanged = null;
        private bool bInit =  true;

        private Screen screen = null;
        internal MyControl my_Control = null;
        private Color default_backColor = Color.LightGray;
        private Color default_foreColor = Color.Black;

        private Color timer_backColor = Color.LightGray;

        private int timer_highlicht_counter = 0;

        private Control ctrlx = null;
        public usrc_EditLayout()
        {
            InitializeComponent();
        }

        internal void Init(MyControl myctrl,Screen xscreen)
        {
            bInit = true;
            this.Enabled = true;
            screen = xscreen;
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

            if (ctrlx != null)
            {
                txt_ControlText.Text = "";
                if (ctrlx.Text != null)
                {
                    txt_ControlText.Text = ctrlx.Text;
                }

                txt_Font.Text = "";

                if (ctrlx.Font != null)
                {
                    string originalfontname = ctrlx.Font.OriginalFontName;
                    string sItalic = "";
                    if (ctrlx.Font.Italic)
                    {
                        sItalic = "Italic";
                    }
                    string sBold = "";
                    if (ctrlx.Font.Bold)
                    {
                        sBold = "Bold";
                    }
                    string sUnderline = "";
                    if (ctrlx.Font.Underline)
                    {
                        sUnderline = "Underline";
                    }
                    string sStrikeout = "";
                    if (ctrlx.Font.Strikeout)
                    {
                        sStrikeout = "Strikeout";
                    }

                    string sFontFamilyName = ctrlx.Font.FontFamily.Name;

                    decimal fontsize = decimal.Round(Convert.ToDecimal(ctrlx.Font.SizeInPoints), 2);
                    string sFontSize = fontsize.ToString();
                    string sFontHeight = ctrlx.Font.Height.ToString();
                    string sFont = sFontFamilyName + ";" + originalfontname + ";" + sFontSize + ";" + sFontHeight + ";" + sBold + ";" + sItalic + ";" + sUnderline + ";" + sStrikeout;
                    txt_Font.Text = sFont;
                }

                default_backColor = ctrlx.BackColor;
                default_foreColor = ctrlx.ForeColor;

                setNumUpDn(this.nmUpDnX, ctrlx.Left);
                setNumUpDn(this.nmUpDnY, ctrlx.Top);

                CheckBounds();

                setNumUpDn(this.nmUpDnWidth, ctrlx.Width);
                setNumUpDn(this.nmUpDnHeight, ctrlx.Height);

                this.btn_ForeColorDefault.ForeColor = ctrlx.ForeColor;
                this.btn_BackColorDefault.BackColor = ctrlx.BackColor;

                this.btn_ForeColor.ForeColor = ctrlx.ForeColor;
                this.btn_BackColor.BackColor = ctrlx.BackColor;


                txt_ControlText.ForeColor = ctrlx.ForeColor;
                txt_ControlText.BackColor = ctrlx.BackColor;
                txt_ControlText.Font = ctrlx.Font;

                txt_Info.Text = "Info:Control Type:" + myctrl.GetControlType();
                

                if (ctrlx is UserControl)
                {
                    switch (((UserControl)ctrlx).AutoScaleMode)
                    {
                        case AutoScaleMode.Font:
                            txt_Info.Text += ";AutoScaleMode.Font";
                            break;
                        case AutoScaleMode.Dpi:
                            txt_Info.Text += ";AutoScaleMode.Dpi";
                            break;
                        case AutoScaleMode.None:
                            txt_Info.Text += ";AutoScaleMode.None";
                            break;
                        case AutoScaleMode.Inherit:
                            txt_Info.Text += ";AutoScaleMode.Inherit";
                            break;
                    }
                }

                switch (ctrlx.Dock)
                {
                    case DockStyle.Bottom:
                        txt_Info.Text += ";DockStyle.Bottom";
                        break;
                    case DockStyle.Fill:
                        txt_Info.Text += ";DockStyle.Fill";
                        break;
                    case DockStyle.Left:
                        txt_Info.Text += ";DockStyle.Left";
                        break;
                    case DockStyle.None:
                        txt_Info.Text += ";DockStyle.None";
                        break;
                    case DockStyle.Right:
                        txt_Info.Text += ";DockStyle.Right";
                        break;
                    case DockStyle.Top:
                        txt_Info.Text += ";DockStyle.Top";
                        break;
                }

                this.txtControl.Text = myctrl.ControlUniqueName;
                setAnchor(ctrlx);
                doHighlight(ctrlx);
            }
            else if (myctrl.hc.pForm!=null)
            {
                Form xForm = myctrl.hc.pForm;
                switch (xForm.AutoScaleMode)
                {
                    case AutoScaleMode.Font:
                        txt_Info.Text += ";AutoScaleMode.Font";
                        break;
                    case AutoScaleMode.Dpi:
                        txt_Info.Text += ";AutoScaleMode.Dpi";
                        break;
                    case AutoScaleMode.None:
                        txt_Info.Text += ";AutoScaleMode.None";
                        break;
                    case AutoScaleMode.Inherit:
                        txt_Info.Text += ";AutoScaleMode.Inherit";
                        break;
                }
                if (xForm.TopMost)
                {
                    txt_Info.Text += ";TopMost";
                }

                switch (xForm.FormBorderStyle)
                {
                    case FormBorderStyle.Fixed3D:
                        txt_Info.Text += ";FormBorderStyle.Fixed3D";
                        break;
                    case FormBorderStyle.FixedDialog:
                        txt_Info.Text += ";FormBorderStyle.FixedDialog";
                        break;
                    case FormBorderStyle.FixedSingle:
                        txt_Info.Text += ";FormBorderStyle.FixedSingle";
                        break;
                    case FormBorderStyle.FixedToolWindow:
                        txt_Info.Text += ";FormBorderStyle.FixedToolWindow";
                        break;
                    case FormBorderStyle.None:
                        txt_Info.Text += ";FormBorderStyle.None";
                        break;
                    case FormBorderStyle.Sizable:
                        txt_Info.Text += ";FormBorderStyle.Sizable";
                        break;
                    case FormBorderStyle.SizableToolWindow:
                        txt_Info.Text += ";FormBorderStyle.SizableToolWindow";
                        break;
                }

                string originalfontname = xForm.Font.OriginalFontName;
                string sItalic = "";
                if (xForm.Font.Italic)
                {
                    sItalic = "Italic";
                }
                string sBold = "";
                if (xForm.Font.Bold)
                {
                    sBold = "Bold";
                }
                string sUnderline = "";
                if (xForm.Font.Underline)
                {
                    sUnderline = "Underline";
                }
                string sStrikeout = "";
                if (xForm.Font.Strikeout)
                {
                    sStrikeout = "Strikeout";
                }

                string sFontFamilyName = xForm.Font.FontFamily.Name;

                decimal fontsize = decimal.Round(Convert.ToDecimal(xForm.Font.SizeInPoints), 2);
                string sFontSize = fontsize.ToString();
                string sFontHeight = xForm.Font.Height.ToString();
                string sFont = sFontFamilyName + ";" + originalfontname + ";" + sFontSize + ";" + sFontHeight + ";" + sBold + ";" + sItalic + ";" + sUnderline + ";" + sStrikeout;
                txt_Font.Text = sFont;
            }

            if (myctrl.hc.ctrlbmp!=null)
            {
                this.pictureBox1.Image = myctrl.hc.ctrlbmp;
            }

            bInit = false;
        }

        private void CheckBounds()
        {
            int ofsx = my_Control.GetOfsX();
            btn_OfsX.Text = ofsx.ToString();

            btn_MaxX.Text = ((int)(screen.Bounds.Width - ofsx)).ToString();
            btn_MaxWidth.Text = ((int)(screen.Bounds.Width - ofsx - ctrlx.Left)).ToString();
            int rightbound = ofsx + ctrlx.Left + ctrlx.Width;

            if (rightbound > screen.Bounds.Width)
            {
                if (ofsx + ctrlx.Left > screen.Bounds.Width)
                {
                    this.nmUpDnX.ForeColor = Color.Red;
                }
                else
                {
                    this.nmUpDnX.ForeColor = Color.Green;
                }
                this.nmUpDnWidth.ForeColor = Color.Red;
            }
            else
            {
                this.nmUpDnWidth.ForeColor = Color.Green;
                this.nmUpDnX.ForeColor = Color.Green;
            }

            int ofsy = my_Control.GetOfsY();
            btn_OfsY.Text = ofsy.ToString();

            btn_MaxY.Text = ((int)(screen.Bounds.Height - ofsy)).ToString();
            btn_MaxHeight.Text = ((int)(screen.Bounds.Height - ofsy - ctrlx.Top)).ToString();
            int bottombound = ofsy + ctrlx.Top + ctrlx.Height;

            if (bottombound > screen.Bounds.Height)
            {
                if (ofsy + ctrlx.Top > screen.Bounds.Height)
                {
                    this.nmUpDnY.ForeColor = Color.Red;
                }
                else
                {
                    this.nmUpDnY.ForeColor = Color.Green;
                }
                this.nmUpDnHeight.ForeColor = Color.Red;
            }
            else
            {
                this.nmUpDnHeight.ForeColor = Color.Green;
                this.nmUpDnY.ForeColor = Color.Green;
            }
        }
        private void doHighlight(Control ctrlx)
        {
            ctrlx.BackColor = SystemColors.Highlight;
            timer_highlicht_counter = 5;
            timer_ControlHighlight.Enabled = true;

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
            CheckBounds();
            changed();
        }

        private void changed()
        {
            if (!bInit)
            {
                if (LayoutChanged != null)
                {
                    LayoutChanged();
                }
            }
        }

        private void nmUpDnY_ValueChanged(object sender, EventArgs e)
        {
            ctrlx.Top = Convert.ToInt32(nmUpDnY.Value);
            ctrlx.Refresh();
            my_Control.Top = ctrlx.Top;
            CheckBounds();
            changed();
        }

        private void nmUpDnWidth_ValueChanged(object sender, EventArgs e)
        {
            ctrlx.Width = Convert.ToInt32(nmUpDnWidth.Value);
            ctrlx.Refresh();
            my_Control.Width = ctrlx.Width;
            CheckBounds();
            changed();
        }

        private void nmUpDnHeight_ValueChanged(object sender, EventArgs e)
        {
            ctrlx.Height = Convert.ToInt32(nmUpDnHeight.Value);
            ctrlx.Refresh();
            my_Control.Height = ctrlx.Height;
            CheckBounds();
            changed();
        }

        private void btn_Up_Click(object sender, EventArgs e)
        {
            nmUpDnY.Value = nmUpDnY.Value - 1;
        }

        private void btn_Down_Click(object sender, EventArgs e)
        {
            nmUpDnY.Value = nmUpDnY.Value + 1;
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


        private void btn_BackColorDefault_Click(object sender, EventArgs e)
        {

                                                             
        }

        private void btn_ForeColorDefault_Click(object sender, EventArgs e)
        {

        }

        private void btn_BackColor_Click(object sender, EventArgs e)
        {
            if (my_Control != null)
            {
                Form_ColorPicker frm_cpick = new Form_ColorPicker(my_Control.ControlUniqueName,
                                          this.btn_BackColor,
                                          my_Control.ForeColor,
                                          my_Control.BackColor,
                                          Form_ColorPicker.eColor.BackColor);
                frm_cpick.ColorChanged += Frm_cpick_ColorChanged;
                if (frm_cpick.ShowDialog(this) == DialogResult.OK)
                {
                    changed();
                    // my_Control.BackColor = frm_cpick.BackColor;
                }
            }
        }

        private void Frm_cpick_ColorChanged(Form_ColorPicker.eColor xecolor, Color color)
        {
            Control xctrl = null;
            if (my_Control != null)
            {
                if (my_Control.hc != null)
                {
                    if (my_Control.hc.ctrl != null)
                    {
                        xctrl = my_Control.hc.ctrl;
                    }
                }
            }
            if (xctrl != null)
            {
                switch (xecolor)
                {
                    case Form_ColorPicker.eColor.ForeColor:
                        xctrl.ForeColor = color;
                        my_Control.ForeColor = color;
                        default_foreColor = color;
                        changed();
                        break;
                    case Form_ColorPicker.eColor.BackColor:
                        xctrl.BackColor = color;
                        my_Control.BackColor = color;
                        default_backColor = color;
                        changed();
                        break;
                }
            }
        }

        private void btn_ForeColor_Click(object sender, EventArgs e)
        {
            if (my_Control != null)
            {
                Form_ColorPicker frm_cpick = new Form_ColorPicker(my_Control.ControlUniqueName,
                                       this.btn_ForeColor,
                                       my_Control.ForeColor,
                                       my_Control.BackColor,
                                       Form_ColorPicker.eColor.ForeColor);

                frm_cpick.ColorChanged += Frm_cpick_ColorChanged;

                if (frm_cpick.ShowDialog(this) == DialogResult.OK)
                {
                    my_Control.ForeColor = frm_cpick.ForeColor;
                    changed();
                }
            }
        }

        private void timer_ControlHighlight_Tick(object sender, EventArgs e)
        {
            Control xctrl = null;
            if (my_Control != null)
            {
                if (my_Control.hc != null)
                {
                    if (my_Control.hc.ctrl != null)
                    {
                        xctrl = my_Control.hc.ctrl;
                        if (timer_highlicht_counter > 0)
                        {
                            if (timer_highlicht_counter % 2 == 0)
                            {
                                xctrl.BackColor = timer_backColor;
                            }
                            else
                            {
                                xctrl.BackColor = SystemColors.Highlight;
                            }
                            timer_highlicht_counter--;
                            timer_ControlHighlight.Enabled = true;
                        }
                        else
                        {
                            timer_ControlHighlight.Enabled = false;
                            xctrl.BackColor = default_backColor;
                        }
                    }
                    else
                    {
                        timer_ControlHighlight.Enabled = false;
                        xctrl.BackColor = default_backColor;
                    }
                }
                else
                {
                    timer_ControlHighlight.Enabled = false;
                    xctrl.BackColor = default_backColor;
                }
            }
            else
            {
                timer_ControlHighlight.Enabled = false;
                xctrl.BackColor = default_backColor;
            }
        }

        private void btn_Highlight_Click(object sender, EventArgs e)
        {
            Control xctrl = null;
            if (my_Control != null)
            {
                if (my_Control.hc != null)
                {
                    if (my_Control.hc.ctrl != null)
                    {
                        xctrl = my_Control.hc.ctrl;
                        doHighlight(ctrlx);
                    }
                }
            }
        }
    }
}
