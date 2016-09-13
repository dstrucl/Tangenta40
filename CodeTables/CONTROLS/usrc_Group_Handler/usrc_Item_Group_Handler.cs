#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
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
    public partial class usrc_Item_Group_Handler : UserControl
    {
        public List<string> m_sGroupList = new List<string>();
        public Button btn_GroupLevel = null;

        public delegate void delegate_GroupsRedefined(int Level);
        public event delegate_GroupsRedefined GroupsRedefined = null;

        public delegate void delegate_PaintGroup(string[] s_name);
        public event delegate_PaintGroup PaintGroup = null;
        private DataTable m_dt_Group = null;
        Form_GroupHandler form_group_handler = null;
        int ypos = 0;

        private GroupList m_GroupList = new GroupList();
        public Group CurrentGroup = null;
        private int m_NumberOfGroupLevels = -1;
        private int m_LastNumberOfGroupLevels = -1;

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

                if (m_NumberOfGroupLevels > 0)
                {
                    if (m_NumberOfGroupLevels == 1)
                    {
                        if (form_group_handler != null)
                        {
                            form_group_handler.Dispose();
                            form_group_handler = null;
                        }
                        if (btn_GroupLevel != null)
                        {
                            btn_GroupLevel.Click -= Btn_GroupLevel_Click;
                            pnl_Group.Controls.Remove(btn_GroupLevel);
                            btn_GroupLevel.Dispose();
                            btn_GroupLevel = null;
                        }

                        Create_NumberOfGroupLevel_EQ_1();
                    }
                    else if (m_NumberOfGroupLevels > 1)
                    {
                        if (m_LastNumberOfGroupLevels != m_NumberOfGroupLevels)
                        {
                            if (form_group_handler == null)
                            {
                                form_group_handler = new Form_GroupHandler();
                            }
                            pnl_Group.Controls.Clear();
                            if (btn_GroupLevel == null)
                            {
                                btn_GroupLevel = new Button();
                                btn_GroupLevel.Text = "";
                                btn_GroupLevel.Image = Properties.Resources.GroupTree;
                                btn_GroupLevel.Dock = DockStyle.Fill;
                                btn_GroupLevel.ImageAlign = ContentAlignment.MiddleCenter;
                                btn_GroupLevel.Click += Btn_GroupLevel_Click;
                                pnl_Group.Controls.Add(btn_GroupLevel);
                            }
                        }
                        switch (m_NumberOfGroupLevels)
                        {
                            case 2:
                                form_group_handler.SetLevel2();
                                break;
                            case 3:
                                form_group_handler.SetLevel3();
                                break;
                        }
                        Create_NumberOfGroupLevel_GT_1();
                    }
                }
            }
            if (GroupsRedefined != null)
            {
                GroupsRedefined(m_NumberOfGroupLevels);
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
            m_LastNumberOfGroupLevels = m_NumberOfGroupLevels;

            DoPaintGroup();
            return (m_NumberOfGroupLevels > 0);
        }

        private void Btn_GroupLevel_Click(object sender, EventArgs e)
        {
            form_group_handler.Show();
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

        public void SetVisible(bool v)
        {
            if (v)
            {
                this.Visible = true;
                if (form_group_handler != null)
                {
                    form_group_handler.Show();
                }
            }
            else
            {
                this.Visible = false;
                if (form_group_handler != null)
                {
                    form_group_handler.Visible = false;
                }
            }
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
            foreach (Group xgrp in m_GroupList.Items)
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
                    grp = new Group(null,this.pnl_Group, null, DoPaintGroup,ref ypos,64,14);
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

        //private void Create_NumberOfGroupLevel_EQ_2()
        //{
        //    int ypos_pnl1 = 0;
        //    int ypos_pnl2 = 0;
        //    if (form_group_handler == null)
        //    {
        //        form_group_handler = new Form_GroupHandler();
        //    }
        //    form_group_handler.SetLevel2();
        //    DataRow[] drs_spnl2 = null;
        //    drs_spnl2 = m_dt_Group.Select("s2_name is not null");
        //    if (drs_spnl2.Count() > 0)
        //    {
        //        foreach (DataRow dr_pnl2 in drs_spnl2)
        //        {
        //            string sGroupName_pnl1 = null;
        //            if (dr_pnl2["s2_name"] is string)
        //            {
        //                sGroupName_pnl1 = (string)dr_pnl2["s2_name"];
        //                if (this.m_GroupList.Find(sGroupName_pnl1) != null)
        //                {
        //                    continue;
        //                }
        //                Group grp_pnl1 = new Group(sGroupName_pnl1, this.form_group_handler.s3_pnl, null, DoPaintGroup, ref ypos_pnl1, 32, 10);
        //                this.m_GroupList.Add(grp_pnl1);
        //                DataRow[] drs_s2 = null;
        //                drs_s2 = m_dt_Group.Select("s2_name ='" + sGroupName_pnl1 + "'");
        //                if (drs_s2.Count() > 0)
        //                {
        //                    ypos_pnl2 = 0;
        //                    foreach (DataRow dr_pnl1 in drs_s2)
        //                    {
        //                        string s2GroupName = null;
        //                        if (dr_pnl2["s1_name"] is string)
        //                        {
        //                            s2GroupName = (string)dr_pnl2["s1_name"];
        //                            if (grp_pnl1.m_GroupList == null)
        //                            {
        //                                grp_pnl1.m_GroupList = new GroupList();
        //                            }
        //                            else
        //                            {
        //                                if (grp_pnl1.m_GroupList.Find(s2GroupName) != null)
        //                                {
        //                                    continue;
        //                                }
        //                            }
        //                            Group grp2 = new Group(s2GroupName, this.form_group_handler.s2_pnl, grp_pnl1, DoPaintGroup, ref ypos_pnl2, 32, 10);
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    LogFile.Error.Show("ERROR:usrc_Item_Group_Handler:Create_NumberOfGroupLevel_EQ_3: NumberOfGroupLevel is not 3 or 2 !");
        //                }
        //                DataRow[] drs_s2_root = null;
        //                drs_s2_root = m_dt_Group.Select("s1_name ='" + sGroupName_pnl1 + "' and s2_name is null");
        //                if (drs_s2_root.Count() > 0)
        //                {
        //                    string s2GroupName_root = lngRPM.s_Other.s;
        //                    Group grp2_root = new Group(s2GroupName_root, this.form_group_handler.s2_pnl, grp_pnl1, DoPaintGroup, ref ypos_pnl2, 32, 10);
        //                }
        //            }
        //        }
        //    }
        //    DataRow[] drs_spnl3 = m_dt_Group.Select("s2_name is null and s1_name is not null");
        //    if (drs_spnl3.Count() > 0)
        //    {
        //        foreach (DataRow dr_pnl3 in drs_spnl3)
        //        {
        //            string sGroupName_pnl1 = null;
        //            if (dr_pnl3["s1_name"] is string)
        //            {
        //                sGroupName_pnl1 = (string)dr_pnl3["s1_name"];
        //                if (this.m_GroupList.Find(sGroupName_pnl1) != null)
        //                {
        //                    continue;
        //                }
        //                Group grp_pnl1 = new Group(sGroupName_pnl1, this.form_group_handler.s3_pnl, null, DoPaintGroup, ref ypos_pnl1, 32, 10);
        //                this.m_GroupList.Add(grp_pnl1);
        //            }
        //        }
        //    }
        //    DataRow[] drs_spnl1 = m_dt_Group.Select("s2_name is null and s1_name is null");
        //    if (drs_spnl3.Count() > 0)
        //    {
        //        string sGroupName_pnl1 = lngRPM.s_Other.s;
        //        Group grp_pnl1 = new Group(sGroupName_pnl1, this.form_group_handler.s3_pnl, null, DoPaintGroup, ref ypos_pnl1, 32, 10);
        //        this.m_GroupList.Add(grp_pnl1);
        //    }
        //    form_group_handler.Show();
        //}

        private void Create_NumberOfGroupLevel_GT_1()
        {
            int ypos_pnl1 = 0;
            int ypos_pnl2 = 0;
            int ypos_pnl3 = 0;
            DataRow[] drs_spnl3 = null;
            drs_spnl3 = m_dt_Group.Select("s3_name is not null");
            if (drs_spnl3.Count() > 0)
            {
                SetLevel3();
                foreach (DataRow dr_pnl3 in drs_spnl3)
                {
                    string sGroupName_pnl1 = null;
                    if (dr_pnl3["s3_name"] is string)
                    {
                        sGroupName_pnl1 = (string)dr_pnl3["s3_name"];
                        if (this.m_GroupList.Find(sGroupName_pnl1) != null)
                        {
                            continue;
                        }
                        Group grp_pnl1 = new Group(sGroupName_pnl1, this.form_group_handler.s3_pnl, null, DoPaintGroup, ref ypos_pnl1, 32, 10);
                        this.m_GroupList.Add(grp_pnl1);
                        DataRow[] drs_s2 = null;
                        drs_s2 = m_dt_Group.Select("s3_name ='" + sGroupName_pnl1 + "'");
                        if (drs_s2.Count() > 0)
                        {
                            ypos_pnl2 = 0;
                            foreach (DataRow dr_pnl2 in drs_s2)
                            {
                                string s2GroupName = null;
                                if (dr_pnl2["s2_name"] is string)
                                {
                                    s2GroupName = (string)dr_pnl2["s2_name"];
                                    if (grp_pnl1.m_GroupList == null)
                                    {
                                        grp_pnl1.m_GroupList = new GroupList();
                                    }
                                    else
                                    {
                                        if (grp_pnl1.m_GroupList.Find(s2GroupName) != null)
                                        {
                                            continue;
                                        }
                                    }
                                    Group grp2 = new Group(s2GroupName, this.form_group_handler.s2_pnl, grp_pnl1, DoPaintGroup, ref ypos_pnl2, 32, 10);
                                    DataRow[] drs_s1 = null;
                                    drs_s1 = m_dt_Group.Select("s2_name ='" + s2GroupName + "' and s3_name = '" + sGroupName_pnl1 + "'");
                                    if (drs_s1.Count() > 0)
                                    {
                                        ypos_pnl3 = 0;
                                        foreach (DataRow dr1 in drs_s1)
                                        {
                                            if (dr1["s1_name"] is string)
                                            {
                                                string s1GroupName = (string)dr1["s1_name"];
                                                if (grp2.m_GroupList == null)
                                                {
                                                    grp2.m_GroupList = new GroupList();
                                                }
                                                else
                                                {
                                                    if (grp2.m_GroupList.Find(s1GroupName) != null)
                                                    {
                                                        continue;
                                                    }
                                                }
                                                Group grp1 = new Group(s1GroupName, this.form_group_handler.s1_pnl, grp2, DoPaintGroup, ref ypos_pnl3, 32, 10);
                                            }
                                        }
                                        DataRow[] drs_s1_root = null;
                                        drs_s1_root = m_dt_Group.Select("s1_name ='" + s2GroupName + "' and s2_name = '" + sGroupName_pnl1 + "' and s3_name is null");
                                        if (drs_s1_root.Count() > 0)
                                        {
                                            Group grp2_root = new Group(null, this.form_group_handler.s1_pnl, grp2, DoPaintGroup, ref ypos_pnl2, 32, 10);
                                        }
                                    }
                                    else
                                    {
                                        LogFile.Error.Show("ERROR:usrc_Item_Group_Handler:Create_NumberOfGroupLevel_EQ_3: NumberOfGroupLevel is not 3,2 or 1 !");
                                    }
                                }
                            }
                            DataRow[] drs_s2_root = null;
                            drs_s2_root = m_dt_Group.Select("s2_name ='" + sGroupName_pnl1 + "' and s3_name is null");
                            if (drs_s2_root.Count() > 0)
                            {
                                Group grp2_root = new Group(null, this.form_group_handler.s2_pnl, grp_pnl1, DoPaintGroup, ref ypos_pnl2, 32, 10);
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:usrc_Item_Group_Handler:Create_NumberOfGroupLevel_EQ_3: NumberOfGroupLevel is not 3 or 2 !");
                        }
                    }
                }
            }
            drs_spnl3 = m_dt_Group.Select("s2_name is not null and s3_name is null");
            if (drs_spnl3.Count() > 0)
            {
                form_group_handler.SetLevel2();
                foreach (DataRow dr_pnl3 in drs_spnl3)
                {
                    string sGroupName_pnl1 = null;
                    if (dr_pnl3["s2_name"] is string)
                    {
                        sGroupName_pnl1 = (string)dr_pnl3["s2_name"];
                        if (this.m_GroupList.Find(sGroupName_pnl1) != null)
                        {
                            continue;
                        }
                        Group grp_pnl1 = new Group(sGroupName_pnl1, this.form_group_handler.s3_pnl, null, DoPaintGroup, ref ypos_pnl1, 32, 10);
                        this.m_GroupList.Add(grp_pnl1);
                        DataRow[] drs_s1 = null;
                        drs_s1 = m_dt_Group.Select("s2_name ='" + sGroupName_pnl1 + "'");
                        if (drs_s1.Count() > 0)
                        {
                            ypos_pnl2 = 0;
                            foreach (DataRow dr_pnl2 in drs_s1)
                            {
                                if (dr_pnl2["s1_name"] is string)
                                {
                                    string s1GroupName = (string)dr_pnl2["s1_name"];
                                    if (grp_pnl1.m_GroupList == null)
                                    {
                                        grp_pnl1.m_GroupList = new GroupList();
                                    }
                                    else
                                    {
                                        if (grp_pnl1.m_GroupList.Find(s1GroupName) != null)
                                        {
                                            continue;
                                        }
                                    }
                                    Group grp1 = new Group(s1GroupName, this.form_group_handler.s1_pnl, grp_pnl1, DoPaintGroup, ref ypos_pnl3, 32, 10);
                                }
                            }
                        }
                    }
                }
            }
            drs_spnl3 = m_dt_Group.Select("s1_name is not null and s2_name is null and s3_name is null");
            if (drs_spnl3.Count() > 0)
            {
                foreach (DataRow dr_pnl3 in drs_spnl3)
                {
                    string sGroupName_pnl1 = null;
                    if (dr_pnl3["s1_name"] is string)
                    {
                        sGroupName_pnl1 = (string)dr_pnl3["s1_name"];
                        if (this.m_GroupList.Find(sGroupName_pnl1) != null)
                        {
                            continue;
                        }
                        Group grp_pnl1 = new Group(sGroupName_pnl1, this.form_group_handler.s3_pnl, null, DoPaintGroup, ref ypos_pnl1, 32, 10);
                        this.m_GroupList.Add(grp_pnl1);
                    }
                }
            }
            drs_spnl3 = m_dt_Group.Select("s1_name is null and s2_name is null and s3_name is null");
            if (drs_spnl3.Count() > 0)
            {
                Group grp_pnl1 = new Group(null, this.form_group_handler.s3_pnl, null, DoPaintGroup, ref ypos_pnl1, 32, 10);
                this.m_GroupList.Add(grp_pnl1);
            }
        }

        private void SetLevel3()
        {
            form_group_handler.SetLevel3();
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
            if ((sGroupArr[0] == null) && (sGroupArr[1] == null) && (sGroupArr[2] == null))
            {
                foreach (Group grp3 in m_GroupList.Items)
                {
                    if (grp3.Name == null)
                    {
                        grp3.rbtn.Checked = true;
                        return true;
                    }
                    else
                    {
                        grp3.rbtn.Checked = false;
                    }
                }
            }

            this.Visible = true;

            if (sGroupArr[2]!=null)
            {
                foreach (Group grp3 in m_GroupList.Items)
                {
                    if (grp3.Name != null)
                    {
                        if (grp3.Name.Equals(sGroupArr[2]))
                        {
                            grp3.rbtn.Checked = true;
                            foreach (Group grp2 in grp3.m_GroupList.Items)
                            {
                                if (grp2.Name != null)
                                {
                                    if (grp2.Name.Equals(sGroupArr[1]))
                                    {
                                        grp2.rbtn.Checked = true;
                                        foreach (Group grp1 in grp2.m_GroupList.Items)
                                        {
                                            if (grp1.Name != null)
                                            {
                                                if (grp1.Name.Equals(sGroupArr[0]))
                                                {
                                                    grp1.rbtn.Checked = true;
                                                    return true;
                                                }
                                                else
                                                {
                                                    grp1.rbtn.Checked = false;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        grp2.rbtn.Checked = false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            grp3.rbtn.Checked = false;
                        }
                    }
                }
            }
            else if (sGroupArr[1]!=null)
            {
                foreach (Group grp2 in m_GroupList.Items)
                {
                    if (grp2.Name != null)
                    {
                        if (grp2.Name.Equals(sGroupArr[1]))
                        {
                            grp2.rbtn.Checked = true;
                            foreach (Group grp1 in grp2.m_GroupList.Items)
                            {
                                if (grp1.Name != null)
                                {
                                    if (grp1.Name.Equals(sGroupArr[0]))
                                    {
                                        grp1.rbtn.Checked = true;
                                        return true;
                                    }
                                    else
                                    {
                                        grp1.rbtn.Checked = false;
                                        return true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            grp2.rbtn.Checked = false;
                        }
                    }
                }
            }
            else if (sGroupArr[0] != null)
            {
                foreach (Group grp in m_GroupList.Items)
                {
                    if (grp.Name != null)
                    {
                        if (grp.Name.Equals(sGroupArr[0]))
                        {
                            grp.rbtn.Checked = true;
                            return true;
                        }
                        else
                        {
                            grp.rbtn.Checked = false;
                        }
                    }
                }
            }
            else
            {
                foreach (Group grp in m_GroupList.Items)
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
