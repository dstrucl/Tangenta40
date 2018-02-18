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
            int icolors = m_color_sheme.color.Length;
            for (int i =0;i< icolors;i++)
            {
                Label lbl = GetLabel(i);
                if (lbl!=null)
                {
                    lbl.Tag = i;
                    lbl.BackColor = m_color_sheme.color[i];
                    lbl.Click += Lbl_Click;
                }
            }
        }

        private void Lbl_Click(object sender, EventArgs e)
        {
            if (sender is Label)
            {
                Label lbl = (Label)sender;
                ColorDialog MyDialog = new ColorDialog();
                // Keeps the user from selecting a custom color.
                MyDialog.AllowFullOpen = true;
                // Allows the user to get help. (The default is false.)
                MyDialog.ShowHelp = true;
                // Sets the initial color select to the current label color.
                MyDialog.Color = lbl.BackColor;

                // Update the label color if the user clicks OK 
                if (MyDialog.ShowDialog() == DialogResult.OK)
                {
                    lbl.BackColor = MyDialog.Color;
                    if (ColorChanged!=null)
                    {
                        m_color_sheme.color[(int)lbl.Tag] = MyDialog.Color;
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
    }
}
