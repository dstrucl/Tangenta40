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
using usrc_Item_InsidePage_Handler;

namespace usrc_Item_InsideGroup_Handler
{
    public class GroupInsideControl
    {


        public delegate void delegate_NewGroupSelected(GroupInsideControl grp);


        private bool m_bSelected = false;
        public bool bSelected
        {
            get
            {
                return m_bSelected;
            }
            set
            {
                m_bSelected = value;
            }
        }

        public GroupInsideControl m_CurrentSubGroup_In_m_GroupList = null;
        internal GroupInsideControl m_pParent = null;
        internal GroupListInsideControl m_GroupList = null;



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

       


        public GroupInsideControl(
                    GroupInsideControl pParent,
                    string xName)
        {
            m_pParent = pParent;
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

        //internal GroupInsideControl SetFirst()
        //{
        //    if (m_GroupList != null)
        //    {
        //        return m_GroupList.SelectFirst();
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}



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
    }
}
