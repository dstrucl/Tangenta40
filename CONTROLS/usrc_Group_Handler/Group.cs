#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LanguageControl;

namespace usrc_Item_Group_Handler
{
    public class Group
    {
        public delegate void delegate_NewGroupSelected();

        private delegate_NewGroupSelected m_delegate_NewGroupSelected_trigger = null;

        public GroupList m_GroupList = null;
        public Panel m_pnl = null;
        private string m_Name = null;
        private string m_Name_In_Language = null;
        public string Name
        {
            get { return m_Name; }
        }
        public string Name_In_Language
        {
            get { return m_Name_In_Language; }
        }

        public RadioButton rbtn = null;
        public Color default_back_color = Color.Gray;


        public Group(string xName,Panel pnl, Group pParent, delegate_NewGroupSelected delegate_NewGroupSelected_trigger)
        {
            m_delegate_NewGroupSelected_trigger = delegate_NewGroupSelected_trigger;
            m_pnl = pnl;
            rbtn = new RadioButton();
            rbtn.Tag = this;
            rbtn.Appearance = Appearance.Button;
            rbtn.Left = 0;
            FontFamily ff = rbtn.Font.FontFamily;
            Font f = new Font(ff, 14);
            rbtn.Font = f;
            rbtn.ForeColor = Color.Black;
            default_back_color = pnl.BackColor;
            rbtn.Width = pnl.Width;
            rbtn.Height = 64;
            m_Name = xName;
            if (xName == null)
            {
               m_Name_In_Language += " " + lngRPM.s_Other.s;
               lngRPM.s_Other.Text(rbtn);
            }
            else
            {
                m_Name_In_Language = m_Name;
                rbtn.Text = m_Name_In_Language;
            }
            pnl.Controls.Add(rbtn);
            if (pParent!=null)
            {
                pParent.m_GroupList.Add(this);
            }
        }

        public void rbtn_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                m_delegate_NewGroupSelected_trigger();
                rb.BackColor = Color.LightBlue;
            }
            else
            {
                rb.BackColor = default_back_color;
            }
        }

        internal bool SetCurrent()
        {
            if (rbtn != null)
            {
                RemoveHandlers();
                rbtn.Checked = true;
                rbtn.BackColor = Color.LightBlue;
                ActivateHandlers();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ActivateHandlers()
        {
            foreach (Control ctrl in m_pnl.Controls)
            {
                if (ctrl is RadioButton)
                {
                    RadioButton rbtn = (RadioButton)ctrl;
                    rbtn.CheckedChanged +=rbtn_CheckedChanged;
                }
            }
        }

        private void RemoveHandlers()
        {
            foreach (Control ctrl in m_pnl.Controls)
            {
                if (ctrl is RadioButton)
                {
                    RadioButton rbtn = (RadioButton)ctrl;
                    rbtn.CheckedChanged -= rbtn_CheckedChanged;
                    rbtn.Checked = false;
                    rbtn.BackColor = default_back_color;
                }
            }
        }

        internal bool EqualsTo(string sx_name)
        {
            if ((m_Name == null)&&(sx_name==null))
            {
                return true;
            }
            else if ((m_Name != null) && (sx_name != null))
            {
                return m_Name.Equals(sx_name);
            }
            else
            {
                return false;
            }
        }
    }
}
