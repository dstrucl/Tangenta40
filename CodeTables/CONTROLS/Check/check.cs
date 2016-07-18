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
        public enum eState { TRUE, FALSE,WAIT, UNDEFINED };
        private eState m_eState = eState.UNDEFINED;
        public eState State
        {
            get { return m_eState; }
            set {
                    m_eState = value;
                    switch (m_eState)
                    {
                        case eState.UNDEFINED:
                            base.Image = Properties.Resources.check_undefined;
                            break;

                        case eState.WAIT:
                            base.Image = Properties.Resources.Wait;
                            break;

                        case eState.TRUE:
                                base.Image = Properties.Resources.check_true;
                                break;

                        case eState.FALSE:
                            base.Image = Properties.Resources.check_false;
                            break;
                    }
                }
        }
        public check()
        {
            m_eState = eState.UNDEFINED;
            base.Image = Properties.Resources.check_undefined;
        }
    }
}
