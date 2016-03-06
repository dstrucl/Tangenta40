#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeTables
{
    public class PictureBoxChanged : PictureBox
    {
        private bool m_bChanged = false;

        public bool Changed
        {
            get
            {
                return m_bChanged;
            }
            set
            {
                m_bChanged = value;
                if (m_bChanged)
                {
                    Image = Properties.Resources.ObjectChanged;

                }
                else
                {
                    Image = Properties.Resources.ObjectNotChanged;
                }
            }
        }

        public PictureBoxChanged()
               : base()
        {
            Image = Properties.Resources.ObjectNotChanged;
        }
    }
}
