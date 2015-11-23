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
        public List<Group> Group_list = new List<Group>();

        public void Add(Group grp)
        {
            Group_list.Add(grp);
        }

        public Group Find(string sx_name)
        {
            foreach (Group xgrp in Group_list)
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
            Group_list.Clear();
        }

        internal void Remove(Group grp)
        {
            Group_list.Remove(grp);
        }

        public Group First()
        {
            return Group_list[0];
        }

        internal Group SetFirst()
        {
            if (Group_list.Count > 0)
            {
                Group grp = Group_list.First();
                Group sub_grp = grp;
                while (sub_grp.m_GroupList != null)
                {
                    sub_grp = sub_grp.m_GroupList.SetFirst();
                }
                grp.SetCurrent();
                return grp;
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
                foreach (Group grp1 in Group_list)
                {
                    if (s3_name.Equals(grp1.Name))
                    {
                        foreach (Group grp2 in grp1.m_GroupList.Group_list)
                        {
                            if (s2_name.Equals(grp2.Name))
                            {
                                foreach (Group grp3 in grp2.m_GroupList.Group_list)
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
            Group grp = Group_list.First();
            Group sub_grp = grp;
            while (sub_grp.m_GroupList != null)
            {
                sub_grp = sub_grp.m_GroupList.SetFirst();
            }
            grp.SetCurrent();
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
            foreach (Group grp in Group_list)
            {
                if (grp.rbtn.Checked)
                {
                    return grp;
                }
            }
            return null;
        }

        internal void PurgeNull(Panel pnl)
        {
            List<Group> groups_to_remove = new List<Group>();
            foreach (Group xgrp in Group_list)
            {
                if (xgrp.Name == null)
                {
                    groups_to_remove.Add(xgrp);
                }
            }
            foreach (Group xgrp in groups_to_remove)
            {
                Group_list.Remove(xgrp);
                pnl.Controls.Remove(xgrp.rbtn);
                xgrp.rbtn.Dispose();
                xgrp.rbtn = null;
            }
            Arrange(pnl);
        }

        internal void PurgeNotNull(Panel pnl, System.Data.DataRow[] drs_not_null, Group.delegate_NewGroupSelected NewGroupSelected)
        {
            foreach (DataRow dr in drs_not_null)
            {
                string name = (string)dr["s1_name"];
                Group grp = this.Find(name);
                if (grp==null)
                {
                    grp = new Group(name,pnl, null, NewGroupSelected);
                    grp.rbtn.CheckedChanged += grp.rbtn_CheckedChanged;
                    Add(grp);

                }
            }

            List<Group> groups_to_remove = new List<Group>();
            foreach (Group xgrp in Group_list)
            {
                if (!find_in_drs_not_null(xgrp.Name,drs_not_null))
                {
                    groups_to_remove.Add(xgrp);
                }
            }

            foreach (Group xgrp in groups_to_remove)
            {
                Group_list.Remove(xgrp);
                pnl.Controls.Remove(xgrp.rbtn);
                xgrp.rbtn.Dispose();
                xgrp.rbtn = null;
            }
            Arrange(pnl);
        }

        private void Arrange(Panel pnl)
        {
            Group_list.Sort(delegate(Group x, Group y)
            {
                if (x.Name == null && y.Name == null) return 0;
                else if (x.Name == null) return -1;
                else if (y.Name == null) return 1;
                else return x.Name.CompareTo(y.Name);
            });
            int yy = 0;
            pnl.AutoScrollOffset = new System.Drawing.Point(0, 0);
            pnl.AutoScrollPosition = new System.Drawing.Point(0, 0);
            foreach(Group g in Group_list)
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
    }
}
