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
    public partial class usrc_SelectColorSheme : UserControl
    {
        public usrc_SelectColorSheme()
        {
            InitializeComponent();
        }

        private void usrc_SelectColorSheme_Load(object sender, EventArgs e)
        {
            int y = 0;
            int i = 0;
            foreach (ColorSheme sheme in ShemeList.items)
            {
                usrc_ColorSheme usrc_colorsheme = new usrc_ColorSheme();
                usrc_colorsheme.Name = sheme.Name;
                usrc_colorsheme.Init(sheme);
                usrc_colorsheme.Left = 2;
                usrc_colorsheme.Top = y;
                usrc_colorsheme.ColorChanged += Usrc_colorsheme_ColorChanged;
                this.Controls.Add(usrc_colorsheme);
                RadioButton rdb_colorSheme = new RadioButton();
                rdb_colorSheme.Name = "rdb_"+ sheme.Name;
                rdb_colorSheme.Text = sheme.Name;
                rdb_colorSheme.Top = y;
                rdb_colorSheme.Tag = i;
                rdb_colorSheme.Left = usrc_colorsheme.Right+2;
                rdb_colorSheme.Height = usrc_colorsheme.Height;
                if (i==Properties.Settings.Default.CurrentColorsIndex)
                {
                    rdb_colorSheme.Checked = true;
                }
                else
                {
                    rdb_colorSheme.Checked = false;
                }
                rdb_colorSheme.CheckedChanged += Rdb_colorSheme_CheckedChanged;
                this.Controls.Add(rdb_colorSheme);
                y += usrc_colorsheme.Height + 4;
                i++;
            }
        }

        private void Usrc_colorsheme_ColorChanged(ColorSheme csheme)
        {
            Sheme.Save(csheme);
        }

        private void Rdb_colorSheme_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                if(((RadioButton)sender).Checked)
                {
                    Properties.Settings.Default.CurrentColorsIndex = (int)((RadioButton)sender).Tag;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void usrc_SelectColorSheme_DoubleClick(object sender, EventArgs e)
        {
            Form_FCTB_Editor fctb_Editor = new Form_FCTB_Editor();
            fctb_Editor.ShowDialog();
        }
    }
}
