using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cyotek.Windows.Forms;

namespace ColorSettings
{
    public partial class usrc_ColorPicker : UserControl
    {
        public delegate void delegate_ColorChanged(Color color);
        public event delegate_ColorChanged ColorChanged=null;

        private string m_ColorPickerType = "";

        public string ColorPickerType
        {
            get
            {
                return m_ColorPickerType;
            }
            set
            {
                m_ColorPickerType = value;
                lbl_ColorType.Text = m_ColorPickerType;
            }
        }

        private Color m_ColorSelected = Color.White;

        public Color ColorSelected
        {
            get
            {
                return m_ColorSelected;
            }
            set
            {
                m_ColorSelected = value;
                lbl_SelectedColor.Text = "";
                lbl_SelectedColor.BackColor = m_ColorSelected;
                this.colorEditorManager1.Color = m_ColorSelected;
            }
        }

        public usrc_ColorPicker()
        {
            InitializeComponent();
        }

        private void colorEditorManager1_ColorChanged(object sender, EventArgs e)
        {
            if (sender is ColorEditorManager)
            {
                ColorEditorManager color_editormanager = (ColorEditorManager)sender;
                m_ColorSelected = color_editormanager.Color;
                lbl_SelectedColor.BackColor = m_ColorSelected;
                if (ColorChanged!=null)
                {
                    ColorChanged(m_ColorSelected);
                }
            }
        }
    }
}
