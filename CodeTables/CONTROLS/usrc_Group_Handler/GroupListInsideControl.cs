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
using System.Threading.Tasks;
using LogFile;
using System.Data;
using System.Windows.Forms;
using usrc_Item_PageHandler;

namespace usrc_Item_Group_Handler
{
    public class GroupListInsideControl
    {
        
        public List<GroupInsideControl> Items = new List<GroupInsideControl>();

        public GroupInsideControl m_GroupParent = null;

        public void Add(GroupInsideControl grp)
        {
            Items.Add(grp);
        }

        public GroupListInsideControl(GroupInsideControl xGroupParent)
        {
            m_GroupParent = xGroupParent;
        }
        public GroupInsideControl Find(string sx_name)
        {
            foreach (GroupInsideControl xgrp in Items)
            {
                if (xgrp.EqualsTo(sx_name))
                {
                     return xgrp;
                }

            }
            return null;
        }

        internal void Clear()
        {
            Items.Clear();
        }

        internal void Remove(GroupInsideControl grp)
        {
            Items.Remove(grp);
        }

        public GroupInsideControl First()
        {
            return Items[0];
        }

        internal GroupInsideControl SelectFirst()
        {
            if (Items.Count > 0)
            {
                GroupInsideControl grpFirst = Items.First();
                grpFirst.SingleSelected = true;
                GroupInsideControl sub_grp = grpFirst;
                if (sub_grp.m_GroupList != null)
                {
                    sub_grp = sub_grp.m_GroupList.SelectFirst();
                }
                return sub_grp;
            }
            else
            {
                return null;
            }
        }

        internal GroupInsideControl Set(string s1_name,string s2_name,string s3_name)
        {
            if (s3_name != null)
            {
                foreach (GroupInsideControl grp1 in Items)
                {
                    if (s3_name.Equals(grp1.Name))
                    {
                        foreach (GroupInsideControl grp2 in grp1.m_GroupList.Items)
                        {
                            if (s2_name.Equals(grp2.Name))
                            {
                                foreach (GroupInsideControl grp3 in grp2.m_GroupList.Items)
                                {
                                    if (s1_name.Equals(grp3.Name))
                                    {
                                        return grp3;
                                    }
                                }
                            }
                        }
                    }
                }
                return null;
            }
            else if (s2_name != null)
            {

            }
            else if (s1_name != null)
            {

            }
            else
            {
                
            }
            foreach(GroupInsideControl g in Items)
            {
                g.SingleSelected = false;
            }
            GroupInsideControl grp = Items.First();
            GroupInsideControl sub_grp = grp;
            while (sub_grp.m_GroupList != null)
            {
                sub_grp = sub_grp.m_GroupList.SelectFirst();
            }
            grp.SingleSelected = true; 
            return grp;
        }

        internal void CurrentPath(ref List<string > sGroupList)
        {
            GroupInsideControl g = Current();
            if (g != null)
            {
                if (g.m_GroupList != null)
                {
                    GroupListInsideControl gl = g.m_GroupList;
                    if (gl != null)
                    {
                        gl.CurrentPath(ref sGroupList);
                    }
                }
                sGroupList.Add(g.Name);
            }
        }

        internal GroupInsideControl Current()
        {
            foreach (GroupInsideControl grp in Items)
            {
                if (grp.SingleSelected)
                {
                    return grp;
                }
            }
            return null;
        }


        private bool find_in_drs_not_null(string p, DataRow[] drs_not_null)
        {
            if (p != null)
            {
                 foreach (DataRow dr in drs_not_null)
                 {
                    string name = (string)dr["s1_name"];
                    if (p.Equals(name))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return true;
            }
            
        }
    }
}
