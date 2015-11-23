using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQLTableControl
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
