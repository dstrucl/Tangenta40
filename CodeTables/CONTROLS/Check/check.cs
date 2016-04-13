#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System.Windows.Forms;


namespace Check
{
    public class check: PictureBox
    {
        private bool m_value = false;
        public bool Value
        {
            get { return m_value; }
            set { m_value = value;
                  if (m_value)
                  {
                    base.Image = Properties.Resources.check_true;
                  }
                  else
                  {
                    base.Image = Properties.Resources.check_false;
                  }
                this.Refresh();
                }
        }
        public check()
        {
            m_value = false;
            base.Image = Properties.Resources.check_false;
        }
    }
}
