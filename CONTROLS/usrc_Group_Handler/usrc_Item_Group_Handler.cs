using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LanguageControl;

namespace usrc_Item_Group_Handler
{
    public partial class usrc_Item_Group_Handler: UserControl
    {
        public List<string> m_sGroupList = new List<string>();

        public delegate void delegate_GroupsRedefined(int Level);
        public event delegate_GroupsRedefined GroupsRedefined = null;

        public delegate void delegate_PaintGroup(string[] s_name);
        public event delegate_PaintGroup PaintGroup = null;
        private DataTable m_dt_Group = null;
        


        private GroupList m_GroupList = new GroupList();
        public Group CurrentGroup = null;
        private int m_NumberOfGroupLevels = -1;

        public int NumberOfGroupLevels
        {
            get { return m_NumberOfGroupLevels; }
        }

        public usrc_Item_Group_Handler()
        {
            InitializeComponent();
        }

        public bool Set_Groups(DataTable xdt_Group)
        {
            if (Table_Equals(xdt_Group))
            {
                DoPaintGroup();
                return (m_NumberOfGroupLevels > 0); 
            }
            else
            {
                m_dt_Group = xdt_Group.Copy();
                m_sGroupList.Clear();
                DataRow[] drs = null;
                drs = m_dt_Group.Select("s3_name is not null");
                if (drs.Count() > 0)
                {
                    m_NumberOfGroupLevels = 3;
                }
                else
                {
                    drs = m_dt_Group.Select("s2_name is not null");
                    if (drs.Count() > 0)
                    {
                        m_NumberOfGroupLevels = 2;
                    }
                    else
                    {
                        drs = m_dt_Group.Select("s1_name is not null");
                        if (drs.Count() > 0)
                        {
                            m_NumberOfGroupLevels = 1;
                        }
                        else
                        {
                            m_NumberOfGroupLevels = 0;
                        }
                    }
                }
                if (GroupsRedefined!=null)
                {
                    GroupsRedefined(m_NumberOfGroupLevels);
                }
                if (m_NumberOfGroupLevels > 0)
                {
                    if (m_NumberOfGroupLevels == 1)
                    {
                        Create_NumberOfGroupLevel_EQ_1();
                    }
                    else
                    {
                        Create_NumberOfGroupLevel_GT_1();
                    }
                }

                if (CurrentGroup == null)
                {
                    CurrentGroup = m_GroupList.SetFirst();
                }
                else
                {
                    if (!CurrentGroup.SetCurrent())
                    {
                        CurrentGroup = m_GroupList.SetFirst();
                    }
                }
                DoPaintGroup();
                return (m_NumberOfGroupLevels > 0);
            }
        }

        private bool Table_Equals(DataTable xdt_Group)
        {
            if (m_dt_Group!=null)
            {
                int irows_count =m_dt_Group.Rows.Count;
                if (irows_count==xdt_Group.Rows.Count)
                {
                    int jcolumn_count = m_dt_Group.Columns.Count;
                    if (jcolumn_count == xdt_Group.Columns.Count)
                    {
                        for (int i = 0; i<irows_count;i++)
                        {
                            for (int j = 0; j < jcolumn_count; j++)
                            {
                                if (!Object_Equals(m_dt_Group.Rows[i][j], xdt_Group.Rows[i][j]))
                                {
                                    return false;
                                }
                            }
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        private bool Object_Equals(object p1, object p2)
        {
            Type p1_type = p1.GetType();
            Type p2_type = p1.GetType();
            if (p1_type.Equals(p2_type))
            {
                if (p1 is string)
                {
                    return ((string)p1).Equals((string)p2);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private bool Table_Equals(DataTable xdt_Group, DataTable m_dt_Group)
        {
            throw new NotImplementedException();
        }

        private bool Find(string sx_name)
        {
            foreach (Group xgrp in m_GroupList.Group_list)
            {
                if (xgrp.EqualsTo(sx_name))
                {
                    return true;
                }

            }
            return false;
        }

        private void Create_NumberOfGroupLevel_EQ_1()
        {
            DataRow[] drs_null = null;
            drs_null = m_dt_Group.Select("s1_name is null");
            Group grp = null;
            if (drs_null.Count() > 0)
            {
                grp = m_GroupList.Find(null);
                if (grp == null)
                {
                    grp = new Group(null,this.pnl_Group, null, DoPaintGroup);
                    m_GroupList.Add(grp);
                }
            }
            else
            {
                grp = m_GroupList.Find(null);
                if (grp != null)
                {
                    if (CurrentGroup.EqualsTo(grp.Name))
                    {
                        CurrentGroup = null;
                    }
                    m_GroupList.PurgeNull(this.pnl_Group);
                }
            }

            DataRow[] drs_not_null = null;
            drs_not_null = m_dt_Group.Select("s1_name is not null");
            m_GroupList.PurgeNotNull(this.pnl_Group, drs_not_null,DoPaintGroup);
        }

        private void Create_NumberOfGroupLevel_GT_1()
        {

        }

        private void DoPaintGroup()
        {
            
            if (PaintGroup!=null)
            {
                m_sGroupList.Clear();
                m_GroupList.CurrentPath(ref m_sGroupList);
                int icount = m_sGroupList.Count;
                string[] sgrups = new string[icount];
                int i;
                for (i=0;i<icount;i++)
                {
                    sgrups[i] = m_sGroupList[i];
                }
                PaintGroup(sgrups);
            }
        }

     
        public string GroupPath 
        {
            get
            {
                string sPath ="";
                
                int iLevel = 0;
                foreach (string s in m_sGroupList)
                {
                    if (iLevel < m_NumberOfGroupLevels)
                    {
                        if (s == null)
                        {
                            sPath += "\\" + lngRPM.s_Other.s ;
                        }
                        else
                        {
                            sPath += "\\" + s;
                        }
                        iLevel++;
                    }
                    else
                    {
                        break;
                    }
                }
                return sPath;}
        }

        public bool Set(string[] sGroupArr)
        {
            if ((sGroupArr[0] == null)&&(sGroupArr[1] == null)&&(sGroupArr[2] == null))
            {
                return true;
            }

            this.Visible = true;

            if (sGroupArr[2]!=null)
            {

            }
            else if (sGroupArr[1]!=null)
            {

            }
            else if (sGroupArr[0] != null)
            {
                foreach (Group grp in m_GroupList.Group_list)
                {
                    if (grp.Name != null)
                    {
                        if (grp.Name.Equals(sGroupArr[0]))
                        {
                            grp.rbtn.Checked = true;
                            return true;
                        }
                    }
                }
            }
            else
            {
                foreach (Group grp in m_GroupList.Group_list)
                {
                    if (grp.Name == null)
                    {
                        grp.rbtn.Checked = true;
                        return true;
                    }
                }
            }
            return true;
            
        }
    }
}
