using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorSettings
{
    public partial class usrc_ColorSheme : UserControl
    {
        public delegate void delegate_ColorChanged(ColorSheme csheme);
        public event delegate_ColorChanged ColorChanged = null;

        ColorSheme m_color_sheme = null;
        private bool m_ReadOnly = true;
        public bool ReadOnly
        {
            get { return m_ReadOnly; }
            set { m_ReadOnly = value; }
        }

        public usrc_ColorSheme()
        {
            InitializeComponent();
        }

        internal void Init(ColorSheme sheme)
        {
            m_color_sheme = sheme;
            int icolors = m_color_sheme.Colorpair.Length;
            for (int i =0;i< icolors;i++)
            {
                Label lbl = GetLabel(i);
                if (lbl!=null)
                {
                    lbl.Tag = i;
                    lbl.BackColor = m_color_sheme.Colorpair[i].BackColor;
                    lbl.ForeColor = m_color_sheme.Colorpair[i].ForeColor;
                    lbl.Click += Lbl_Click;
                }
            }
        }

        private void Lbl_Click(object sender, EventArgs e)
        {
            if (sender is Label)
            {
                Label lbl = (Label)sender;
                Color forecolor = m_color_sheme.Colorpair[(int)lbl.Tag].ForeColor;
                Color backcolor = m_color_sheme.Colorpair[(int)lbl.Tag].BackColor;
                Form_ColorpairPicker frm_ColorpairPicker = new Form_ColorpairPicker(forecolor, backcolor);
                // Update the label color if the user clicks OK 
                if (frm_ColorpairPicker.ShowDialog() == DialogResult.OK)
                {
                    lbl.ForeColor = frm_ColorpairPicker.ForeColorSelected;
                    lbl.BackColor = frm_ColorpairPicker.BackColorSelected;
                    if (ColorChanged!=null)
                    {
                        m_color_sheme.Colorpair[(int)lbl.Tag].ForeColor = frm_ColorpairPicker.ForeColorSelected;
                        m_color_sheme.Colorpair[(int)lbl.Tag].BackColor = frm_ColorpairPicker.BackColorSelected;
                        ColorChanged(m_color_sheme);
                    }
                }
            }
        }

    

        private Label GetLabel(int i)
        {
            foreach(Control ctrl in this.Controls)
            {
                if (ctrl is Label)
                {
                    string lbl_Name = "lbl_Col" + i.ToString();
                    if (ctrl.Name.Equals(lbl_Name))
                    {
                        return (Label)ctrl;
                    }
                }
            }
            return null;
        }

        private void lbl_Col0_Click(object sender, EventArgs e)
        {

        }
    }
}
