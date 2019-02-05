using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorSettings
{
    public partial class Form_ColorPicker : Form
    {
        public delegate void delegate_ColorChanged(eColor xecolor,Color color);
        public event delegate_ColorChanged ColorChanged = null;

        private Control previewControl = null;
        public enum eColor { BackColor,ForeColor};

        private eColor ecolor = Form_ColorPicker.eColor.BackColor;
        private eColor Ecolor
        {
            get
            {
                return ecolor;
            }
        }
        private Color m_ForeColorSelected = Color.Black;
        public Color ForeColorSelected
        {
            get
            {
                return m_ForeColorSelected;
            }
            set
            {
                m_ForeColorSelected = value; 
            }
        }
        private Color m_BackColorSelected = Color.Black;
        public Color BackColorSelected
        {
            get
            {
                return m_BackColorSelected;
            }
            set
            {
                m_BackColorSelected = value;
            }
        }

        public Form_ColorPicker(string sControlName,Control xpreviewControl, Color xforecolor, Color xbackcolor, eColor xecolor)
        {
            InitializeComponent();
            previewControl = xpreviewControl;
            ecolor = xecolor;
            m_ForeColorSelected = xforecolor;
            m_BackColorSelected = xbackcolor;
            txt_ControlName.Text = sControlName + " : ";

            switch (ecolor)
            {
                case eColor.ForeColor:
                    this.usrc_ColorPicker.ColorPickerType = "Fore color";
                    this.Text = "Fore color";
                    this.usrc_ColorPicker.SetColorSelected(m_ForeColorSelected);
                    break;
                case eColor.BackColor:
                    this.usrc_ColorPicker.ColorPickerType = "Back color";
                    this.Text = "Back color";
                    this.usrc_ColorPicker.SetColorSelected(m_BackColorSelected);
                    break;
            }
            
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            m_ForeColorSelected = this.usrc_ColorPicker.ColorSelected;
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void Form_ColorpairPicker_Load(object sender, EventArgs e)
        {
            int x = lbl_ColorText1.Left;
            int y = lbl_ColorText1.Top;
            Font[] font = new Font[8];

            int iCount = 8;
            if (FontFamily.Families.Length< iCount)
            {
                iCount = FontFamily.Families.Length;
            }
            this.SuspendLayout();
            for (int i= 0;i< iCount; i++)
            {
                FontFamily ffamily = FontFamily.Families[i];
                font[i] = new Font(ffamily, 8 + i * 2);
                TextBox txt = new TextBox();
                txt.Name = "txt_Demo_" + i.ToString();
                txt.Multiline = true;
                txt.WordWrap = true;
                txt.ReadOnly = true;
                txt.Width = lbl_ColorText1.Width;
                txt.Height = lbl_ColorText1.Height * 2+i*10;
                txt.Font = font[i];
                txt.Left = x;
                txt.Top = y;
                txt.Text = Sheme.slng_ThisTextIsToDemostrateColorPairOnLabelForFontFamily+ ffamily.Name + " " + Sheme.slng_AndFontSize+ font[i].Size.ToString();
                txt.ScrollBars = ScrollBars.Both;
                txt.BackColor = m_BackColorSelected;
                txt.ForeColor = m_ForeColorSelected;
                this.Controls.Add(txt);
                y = txt.Bottom + 4;
            }
            lbl_ColorText1.Visible = false;
            this.Controls.Remove(lbl_ColorText1);
            lbl_ColorText1.Dispose();
            lbl_ColorText1 = null;
            this.ResumeLayout(false);
        }

        private void usrc_ColorPicker_ColorChanged(Color color)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox txt = (TextBox)ctrl;
                    if (txt.Name.Contains("txt_Demo_"))
                    {
                        switch (ecolor)
                        {
                            case eColor.ForeColor:
                                m_ForeColorSelected = color;
                                txt.ForeColor = color;
                                txt.BackColor = m_BackColorSelected;
                                if (previewControl!=null)
                                {
                                    previewControl.ForeColor = color;
                                }
                                if (ColorChanged != null)
                                {
                                    ColorChanged(ecolor, color);
                                }
                                break;
                            case eColor.BackColor:
                                txt.ForeColor = m_ForeColorSelected;
                                txt.BackColor = color;
                                m_BackColorSelected = color;
                                if (previewControl != null)
                                {
                                    previewControl.BackColor = color;
                                }
                                if (ColorChanged!=null)
                                {
                                    ColorChanged(ecolor, color);
                                }
                                break;
                        }
                    }
                }
            }
        }
    }
}
