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
using usrc_Item_PageHandler;

namespace usrc_Item_Group_Handler
{
    public class GroupInsideControl
    {


        public delegate void delegate_NewGroupSelected(GroupInsideControl grp);


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
        public GroupInsideControl m_CurrentSubGroup_In_m_GroupList = null;
        internal GroupInsideControl m_pParent = null;
        internal GroupListInsideControl m_GroupList = null;

        internal usrc_Item_InsidePageHandler m_pgh = null;


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

        private bool m_bSingleSelected = false;
        public bool SingleSelected
        {
            get { return m_bSingleSelected; }
            set
            {
                bool b = value;
                m_bSingleSelected = b;
            }
        }

        public bool IsRoot { get { return m_pgh == null; } }

        public int GroupLevel { get
                                { int iLevel = 0;
                                  GroupInsideControl g = this;
                                  while (g.m_pParent!=null)
                                  { iLevel++;
                                    g = g.m_pParent;
                                  }
                                 return iLevel;
                                }
                              }


        public Color default_back_color = Color.Gray;


        public GroupInsideControl(string xName,
                    usrc_Item_InsidePageHandler xpgh,
                    GroupInsideControl pParent,
                    delegate_NewGroupSelected delegate_NewGroupSelected_trigger,
                    ref int yPos,
                    int xbutton_height,
                    int xfont_height)
        {
            button_height = xbutton_height;
            font_height = xfont_height;
            m_delegate_NewGroupSelected_trigger = delegate_NewGroupSelected_trigger;
            m_pgh = xpgh;
            if (m_pgh!=null)
            {
                default_back_color = m_pgh.BackColor;
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
                    m_pParent.m_GroupList = new GroupListInsideControl( this);
                }
                m_pParent.m_GroupList.Add(this);
            }
        }

        public void rbtn_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                if (rb.Tag is GroupInsideControl)
                {
                    GroupInsideControl grp = (GroupInsideControl)rb.Tag;
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
        }

        private object GetGroupHandlerControl()
        {
            if (m_pgh != null)
            {
                if (m_pgh.Parent != null)
                {
                    if (m_pgh.Parent is System.Windows.Forms.SplitterPanel)
                    {
                        if (m_pgh.Parent.Parent != null)
                        {
                            if (m_pgh.Parent.Parent is System.Windows.Forms.SplitContainer)
                            {
                                if (m_pgh.Parent.Parent.Parent != null)
                                {
                                    if (m_pgh.Parent.Parent.Parent is System.Windows.Forms.SplitterPanel)
                                    {
                                        if (m_pgh.Parent.Parent.Parent.Parent != null)
                                        {
                                            if (m_pgh.Parent.Parent.Parent.Parent is System.Windows.Forms.SplitContainer)
                                            {
                                                return m_pgh.Parent.Parent.Parent.Parent.Parent;
                                            }
                                        }
                                    }
                                    else if (m_pgh.Parent.Parent.Parent is Form_GroupHandler)
                                    {
                                        return m_pgh.Parent.Parent.Parent;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        return m_pgh.Parent;
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
                    if (m_pgh!=null)
                    {
                        if (m_pParent.m_GroupList.Items != null)
                        {
                            if (m_pParent.m_GroupList.Items.Count > 0)
                            {
                                m_pgh.CreateControl += M_pgh_CreateControl;
                                m_pgh.Init(m_pParent.m_GroupList.Items);
                                m_pgh.ShowPage(0);
                                m_pgh.Visible = true;
                            }
                        }
                    }
                    //int mypos = 0;
                    //int i = 0;
                    //int iCount = m_pParent.m_GroupList.Items.Count;
                    //Control xpnl = null;
                    //for (i = 0; i < iCount; i++)
                    //{
                    //    if (xpnl == null)
                    //    {
                    //        xpnl = m_pParent.m_GroupList.Items[i].m_pgh;
                    //    }
                    //}
                    //if (xpnl != null)
                    //{
                    //    if (xpnl is usrc_Item_InsidePageHandler)
                    //    {
                    //        ((usrc_Item_InsidePageHandler)xpnl).AutoScrollPosition = new Point(0, 0);
                    //    }
                    //}

                    //int TopPosition = -1;
                    //for (i = 0; i < iCount; i++)
                    //{
                    //    m_pParent.m_GroupList.Items[i].ShowButton(i, ref mypos);
                    //    if (m_pParent.m_GroupList.Items[i].SingleSelected)
                    //    {
                    //        TopPosition = m_pParent.m_GroupList.Items[i].rbtn.Top;
                    //    }
                    //}
                    //// hide to many buttons !
                    //if (xpnl != null)
                    //{
                    //    //xpnl.AutoScrollPosition = new Point(0, 0);
                    //    int iCountOfRadioButtons = xpnl.Controls.Count;
                    //    while (iCountOfRadioButtons > iCount)
                    //    {
                    //        iCountOfRadioButtons--;
                    //        xpnl.Controls[iCountOfRadioButtons].Visible = false;
                    //    }
                    //}

                }
            }
        }

        private void M_pgh_CreateControl(ref Control ctrl)
        {
            ctrl = new Button();
        }

        private int GetGroupLevel()
        {
            int level = 0;
            GroupInsideControl xParent = m_pParent;
            while (xParent != null)
            {
                xParent = xParent.m_pParent;
                level++;
            }
            return level;
        }

        internal GroupInsideControl SetFirst()
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
            foreach (Control ctrl in m_pgh.Controls)
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
            foreach (Control ctrl in m_pgh.Controls)
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

        internal GroupInsideControl Find(string sGroupName)
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

        internal void Add(GroupInsideControl grp)
        {
            if (this.m_GroupList== null)
            {
                this.m_GroupList = new GroupListInsideControl(this);
            }
            this.m_GroupList.Add(grp);
        }



        public GroupInsideControl Select(int NumberOfGroupLevel,string[] sGroupArr)
        {
            if (IsRoot)
            {
                if (m_GroupList != null)
                {
                    foreach (GroupInsideControl grp in m_GroupList.Items)
                    {
                        GroupInsideControl g =  grp.Select(NumberOfGroupLevel - 1, sGroupArr);
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
                                    foreach (GroupInsideControl grp in m_GroupList.Items)
                                    {
                                        GroupInsideControl g = grp.Select(NumberOfGroupLevel - 1, sGroupArr);
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
                                foreach (GroupInsideControl grp in m_GroupList.Items)
                                {
                                    GroupInsideControl g = grp.Select(NumberOfGroupLevel - 1, sGroupArr);
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

        public GroupInsideControl GetCurrent()
        {
            if (m_GroupList!=null)
            {
                int i = 0;
                int iCount = m_GroupList.Items.Count;
                if (iCount > 0)
                {
                    GroupInsideControl g = null;
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
