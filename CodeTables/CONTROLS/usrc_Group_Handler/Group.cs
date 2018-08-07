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
        public delegate void delegate_NewGroupSelected(Group grp);

        private delegate_NewGroupSelected m_delegate_NewGroupSelected_trigger = null;
        private int m_button_height = 48;
        
        private int button_height
        {
            get {
                return m_button_height;
            }
            set
            {
                m_button_height = value;
            }
        }
        int font_height = 10;
        private bool m_bSingleSelected = false;
        public Group m_CurrentSubGroup_In_m_GroupList = null;
        internal Group m_pParent = null;
        internal GroupList m_GroupList = null;
        internal Panel m_pnl = null;
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

        public bool SingleSelected
        {
            get { return m_bSingleSelected; }
            set
            {
                bool b = value;
                if (b)
                {
                    if (m_pParent != null)
                    {
                        if (m_pParent.m_GroupList != null)
                        {
                            foreach (Group g in m_pParent.m_GroupList.Items)
                            {
                                g.m_bSingleSelected = false;
                                if (g.rbtn != null)
                                {
                                    g.rbtn.BackColor = default_back_color;
                                }
                            }
                        }
                    }
                    if (this.rbtn != null)
                    {
                        this.rbtn.BackColor = Color.LightBlue;
                    }
                }
                m_bSingleSelected = b;
            }
        }

        public bool IsRoot { get { return m_pnl == null; } }

        public int GroupLevel { get
                                { int iLevel = 0;
                                  Group g = this;
                                  while (g.m_pParent!=null)
                                  { iLevel++;
                                    g = g.m_pParent;
                                  }
                                 return iLevel;
                                }
                              }

        internal RadioButton rbtn = null;

        public Color default_back_color = Color.Gray;


        public Group(string xName,Panel pnl,Group pParent, delegate_NewGroupSelected delegate_NewGroupSelected_trigger,ref int yPos,int xbutton_height,int xfont_height)
        {
            button_height = xbutton_height;
            font_height = xfont_height;
            m_delegate_NewGroupSelected_trigger = delegate_NewGroupSelected_trigger;
            m_pnl = pnl;
            if (m_pnl!=null)
            {
                default_back_color = m_pnl.BackColor;
            }
            m_pParent = pParent;
            yPos += button_height + 2;
            m_Name = xName;
            if (xName == null)
            {
               m_Name_In_Language += " " + lng.s_Other.s;
            }
            else
            {
            
                m_Name_In_Language = m_Name;
            }
            
            if (m_pParent != null)
            {
                if (m_pParent.m_GroupList== null)
                {
                    m_pParent.m_GroupList = new GroupList(this);
                }
                m_pParent.m_GroupList.Add(this);
            }
        }

        public void rbtn_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                if (rb.Tag is Group)
                {
                    Group grp = (Group)rb.Tag;
                    if (grp != null)
                    {
                        grp.SingleSelected = true;
                        grp.m_delegate_NewGroupSelected_trigger(grp);
                    }
                }
            }
        }

        internal void ShowButton(int i, ref int ypos)
        {
            if (i>=this.m_pnl.Controls.Count )
            {
                if (rbtn != null)
                {
                    rbtn.Dispose();
                    rbtn = null;
                }
                if (rbtn == null)
                {
                    rbtn = new RadioButton();
                    this.m_pnl.Controls.Add(rbtn);
                    rbtn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    rbtn.Appearance = Appearance.Button;
                    rbtn.Left = 0;
                    FontFamily ff = rbtn.Font.FontFamily;
                    Font f = new Font(ff, font_height);
                    rbtn.Font = f;
                    rbtn.ForeColor = Color.Black;
                }
            }
            else
            {
                rbtn = (RadioButton)this.m_pnl.Controls[i];
            }

            rbtn.Tag = this;
            rbtn.Text = m_Name_In_Language;
            rbtn.CheckedChanged -= rbtn_CheckedChanged;
            if (m_bSingleSelected)
            {
                rbtn.Checked = true;
                rbtn.BackColor = Color.LightBlue;
                if (m_GroupList!=null)
                {
                    if (m_GroupList.Items.Count>0)
                    {
                    }
                }
            }
            else
            {
                rbtn.Checked = false;
                rbtn.BackColor = default_back_color;
            }
            rbtn.CheckedChanged += rbtn_CheckedChanged;
            rbtn.Width = m_pnl.Width;
            rbtn.Height = button_height;
            rbtn.Top = ypos;
            rbtn.Visible = true;
            ypos += button_height + 2;
        }

        private object GetGroupHandlerControl()
        {
            if (m_pnl != null)
            {
                if (m_pnl.Parent != null)
                {
                    if (m_pnl.Parent is System.Windows.Forms.SplitterPanel)
                    {
                        if (m_pnl.Parent.Parent != null)
                        {
                            if (m_pnl.Parent.Parent is System.Windows.Forms.SplitContainer)
                            {
                                if (m_pnl.Parent.Parent.Parent != null)
                                {
                                    if (m_pnl.Parent.Parent.Parent is System.Windows.Forms.SplitterPanel)
                                    {
                                        if (m_pnl.Parent.Parent.Parent.Parent != null)
                                        {
                                            if (m_pnl.Parent.Parent.Parent.Parent is System.Windows.Forms.SplitContainer)
                                            {
                                                return m_pnl.Parent.Parent.Parent.Parent.Parent;
                                            }
                                        }
                                    }
                                    else if (m_pnl.Parent.Parent.Parent is Form_GroupHandler)
                                    {
                                        return m_pnl.Parent.Parent.Parent;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        return m_pnl.Parent;
                    }
                }
            }
            return null;
        }


        internal void SetVisible()
        {
            if (m_pParent!=null)
            {
                m_pParent.SetVisible();
                if (m_pParent.m_GroupList != null)
                {
                    int mypos = 0;
                    int i = 0;
                    int iCount = m_pParent.m_GroupList.Items.Count;
                    Panel xpnl = null;
                    for (i = 0; i < iCount; i++)
                    {
                        if (xpnl == null)
                        {
                            xpnl = m_pParent.m_GroupList.Items[i].m_pnl;
                        }
                    }
                    if (xpnl != null)
                    {
                        xpnl.AutoScrollPosition = new Point(0, 0);
                    }

                    int TopPosition = -1;
                    for (i = 0; i < iCount; i++)
                    {
                        m_pParent.m_GroupList.Items[i].ShowButton(i, ref mypos);
                        if (m_pParent.m_GroupList.Items[i].SingleSelected)
                        {
                            TopPosition = m_pParent.m_GroupList.Items[i].rbtn.Top;
                        }
                    }
                    // hide to many buttons !
                    if (xpnl != null)
                    {
                        //xpnl.AutoScrollPosition = new Point(0, 0);
                        int iCountOfRadioButtons = xpnl.Controls.Count;
                        while (iCountOfRadioButtons > iCount)
                        {
                            iCountOfRadioButtons--;
                            xpnl.Controls[iCountOfRadioButtons].Visible = false;
                        }
                    }

                }
            }
        }

        private int GetGroupLevel()
        {
            int level = 0;
            Group xParent = m_pParent;
            while (xParent != null)
            {
                xParent = xParent.m_pParent;
                level++;
            }
            return level;
        }

        internal Group SetFirst()
        {
            if (m_GroupList != null)
            {
                return m_GroupList.SelectFirst();
            }
            else
            {
                return null;
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

        internal void Clear()
        {
            if (this.m_GroupList != null)
            {
                this.m_GroupList.Clear();
            }
        }

        internal Group Find(string sGroupName)
        {
            if (this.m_GroupList != null)
            {
                return this.m_GroupList.Find(sGroupName);
            }
            else
            {
                return null;
            }
        }

        internal void Add(Group grp)
        {
            if (this.m_GroupList== null)
            {
                this.m_GroupList = new GroupList(this);
            }
            this.m_GroupList.Add(grp);
        }

        internal void PurgeNotNull(Panel pnl_Group, DataRow[] drs_not_null, delegate_NewGroupSelected doPaintGroup)
        {
            if (this.m_GroupList != null)
            {
                this.m_GroupList.PurgeNotNull(pnl_Group, drs_not_null, doPaintGroup);
            }
        }

        internal void PurgeNull(Panel pnl_Group)
        {
            if (this.m_GroupList != null)
            {
                this.m_GroupList.PurgeNull(pnl_Group);
            }
        }


        public Group Select(int NumberOfGroupLevel,string[] sGroupArr)
        {
            if (IsRoot)
            {
                if (m_GroupList != null)
                {
                    foreach (Group grp in m_GroupList.Items)
                    {
                        Group g =  grp.Select(NumberOfGroupLevel - 1, sGroupArr);
                        if (g!=null)
                        {
                            this.m_CurrentSubGroup_In_m_GroupList = g;
                            return g;
                        }
                    }
                }
                else
                {
                    foreach (string s in sGroupArr)
                    {
                        if (s!=null)
                        {
                            return null;
                        }
                    }
                    return this;
                }
            }
            else
            {
                if (NumberOfGroupLevel >= 0)
                {
                    if (sGroupArr[NumberOfGroupLevel] != null)
                    {
                        if (this.Name != null)
                        {
                            if (this.Name.Equals(sGroupArr[NumberOfGroupLevel]))
                            {
                                this.SingleSelected = true;
                                if (m_GroupList != null)
                                {
                                    foreach (Group grp in m_GroupList.Items)
                                    {
                                        Group g = grp.Select(NumberOfGroupLevel - 1, sGroupArr);
                                        if (g != null)
                                        {
                                            this.m_CurrentSubGroup_In_m_GroupList = g;
                                            return g;
                                        }
                                    }
                                }
                                else
                                {
                                    return this;
                                }
                            }
                        }
                        else
                        {
                            if (m_GroupList != null)
                            {
                                foreach (Group grp in m_GroupList.Items)
                                {
                                    Group g = grp.Select(NumberOfGroupLevel - 1, sGroupArr);
                                    if (g != null)
                                    {
                                        this.m_CurrentSubGroup_In_m_GroupList = g;
                                        return g;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (this.Name == null)
                        {
                            if (NumberOfGroupLevel == 0)
                            {
                                this.SingleSelected = true;
                                return this;
                            }
                            else
                            {
                                return Select(NumberOfGroupLevel - 1, sGroupArr);
                            }
                        }
                        else
                        {
                            if (NumberOfGroupLevel > 0)
                            {
                                return Select(NumberOfGroupLevel - 1, sGroupArr);
                            }
                        }
                    }
                }
            }
            return null;
        }

        public Group GetCurrent()
        {
            if (m_GroupList!=null)
            {
                int i = 0;
                int iCount = m_GroupList.Items.Count;
                if (iCount > 0)
                {
                    Group g = null;
                    for (i = 0; i < iCount; i++)
                    {
                        g = m_GroupList.Items[i];
                        if (g.SingleSelected)
                        {
                            if (g.m_GroupList != null)
                            {
                                return g.GetCurrent();
                            }
                            else
                            {
                                return g;
                            }
                        }
                    }
                    g = m_GroupList.Items[0];
                    g.SingleSelected = true;
                    if (g.m_GroupList != null)
                    {
                        return g.GetCurrent();
                    }
                    else
                    {
                        return g;
                    }
                }
            }
            return null;
        }

        internal void Path(ref List<string> m_sGroupList)
        {
            m_sGroupList.Add(this.m_Name);
            if (m_pParent!=null)
            {
                if (m_pParent.IsRoot)
                {
                    return;
                }
                else
                {
                    m_pParent.Path(ref m_sGroupList);
                }
            }
        }

        public string Path(ref string s)
        {
            s = "\\"+this.m_Name_In_Language + s;
            if (m_pParent != null)
            {
                if (!m_pParent.IsRoot)
                {
                    m_pParent.Path(ref s);
                }
            }
            return s;
        }
    }
}
