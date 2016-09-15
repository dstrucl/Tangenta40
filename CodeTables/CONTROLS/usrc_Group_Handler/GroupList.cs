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

namespace usrc_Item_Group_Handler
{
    public class GroupList
    {
        public List<Group> Items = new List<Group>();
        public Group m_GroupParent = null;
        public void Add(Group grp)
        {
            Items.Add(grp);
        }

        public GroupList(Group xGroupParent)
        {
            m_GroupParent = xGroupParent;
        }
        public Group Find(string sx_name)
        {
            foreach (Group xgrp in Items)
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

        internal void Remove(Group grp)
        {
            Items.Remove(grp);
        }

        public Group First()
        {
            return Items[0];
        }

        internal Group SelectFirst()
        {
            if (Items.Count > 0)
            {
                Group grpFirst = Items.First();
                grpFirst.SingleSelected = true;
                Group sub_grp = grpFirst;
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

        internal Group Set(string s1_name,string s2_name,string s3_name)
        {
            if (s3_name != null)
            {
                foreach (Group grp1 in Items)
                {
                    if (s3_name.Equals(grp1.Name))
                    {
                        foreach (Group grp2 in grp1.m_GroupList.Items)
                        {
                            if (s2_name.Equals(grp2.Name))
                            {
                                foreach (Group grp3 in grp2.m_GroupList.Items)
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
            foreach(Group g in Items)
            {
                g.SingleSelected = false;
            }
            Group grp = Items.First();
            Group sub_grp = grp;
            while (sub_grp.m_GroupList != null)
            {
                sub_grp = sub_grp.m_GroupList.SelectFirst();
            }
            grp.SingleSelected = true; 
            return grp;
        }

        internal void CurrentPath(ref List<string > sGroupList)
        {
            Group g = Current();
            if (g != null)
            {
                if (g.m_GroupList != null)
                {
                    GroupList gl = g.m_GroupList;
                    if (gl != null)
                    {
                        gl.CurrentPath(ref sGroupList);
                    }
                }
                sGroupList.Add(g.Name);
            }
        }

        internal Group Current()
        {
            foreach (Group grp in Items)
            {
                if (grp.rbtn != null)
                {
                    if (grp.rbtn.Checked)
                    {
                        return grp;
                    }
                }
            }
            return null;
        }

        internal void PurgeNull(Panel pnl)
        {
            List<Group> groups_to_remove = new List<Group>();
            foreach (Group xgrp in Items)
            {
                if (xgrp.Name == null)
                {
                    groups_to_remove.Add(xgrp);
                }
            }
            foreach (Group xgrp in groups_to_remove)
            {
                Items.Remove(xgrp);
                pnl.Controls.Remove(xgrp.rbtn);
                xgrp.rbtn.Dispose();
                xgrp.rbtn = null;
            }
            Arrange(pnl);
        }

        internal void PurgeNotNull(Panel pnl, System.Data.DataRow[] drs_not_null, Group.delegate_NewGroupSelected NewGroupSelected)
        {
            int ypos = 0;
            foreach (DataRow dr in drs_not_null)
            {
                string name = (string)dr["s1_name"];
                Group grp = this.Find(name);
                if (grp==null)
                {
                    grp = new Group(name,pnl,null, NewGroupSelected, ref ypos, 64,14);
                    grp.rbtn.CheckedChanged += grp.rbtn_CheckedChanged;
                    Add(grp);

                }
            }

            List<Group> groups_to_remove = new List<Group>();
            foreach (Group xgrp in Items)
            {
                if (!find_in_drs_not_null(xgrp.Name,drs_not_null))
                {
                    groups_to_remove.Add(xgrp);
                }
            }

            foreach (Group xgrp in groups_to_remove)
            {
                Items.Remove(xgrp);
                pnl.Controls.Remove(xgrp.rbtn);
                xgrp.rbtn.Dispose();
                xgrp.rbtn = null;
            }
            Arrange(pnl);
        }

        private void Arrange(Panel pnl)
        {
            Items.Sort(delegate(Group x, Group y)
            {
                if (x.Name == null && y.Name == null) return 0;
                else if (x.Name == null) return -1;
                else if (y.Name == null) return 1;
                else return x.Name.CompareTo(y.Name);
            });
            int yy = 0;
            pnl.AutoScrollOffset = new System.Drawing.Point(0, 0);
            pnl.AutoScrollPosition = new System.Drawing.Point(0, 0);
            foreach(Group g in Items)
            {
                g.rbtn.Top = yy;
                yy += g.rbtn.Height;
            }
            pnl.Refresh();
            
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

        internal void SetButtonsVisible()
        {
            int mypos = 0;
            int i = 0;
            int iCount = Items.Count();
            for (i=0;i< iCount;i++)
            {
                Items[i].ShowButton(i, ref mypos);
            }
        }
    }
}
