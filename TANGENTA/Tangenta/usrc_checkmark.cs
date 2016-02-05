#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tangenta
{
    public partial class usrc_checkmark : UserControl
    {
        private bool m_Checked;
        public usrc_checkmark()
        {
            InitializeComponent();
            m_Checked = false;
            pic.Left = 0;
            pic.Top = 0;
            pic.Width = this.Width;
            pic.Height = this.Height;
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public bool Checked
        {
            get { return m_Checked; }
            set { m_Checked = value;
                    if (m_Checked)
                    {
                        pic.Image = Properties.Resources.checkmark_Yes;
                    }
                    else
                    {
                        pic.Image = Properties.Resources.checkmark_No;
                    }
                    
                }
        }

    }
}
