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
    public partial class usrc_Item_InsideGroup_Handler : UserControl
    {
        public List<string> m_sGroupList = new List<string>();
        private bool bGroupChanged = false;

        public delegate void delegate_GroupsRedefined(int Level);
        public event delegate_GroupsRedefined GroupsRedefined = null;

        public delegate void delegate_PaintGroup(string[] s_name);
        public event delegate_PaintGroup PaintGroup = null;

        private int m_Button_Height = 40;
        private int m_Font_Height = 10;
        public int Button_Height
        {
            get { return m_Button_Height; }
            set { m_Button_Height = value; }
        }
        public int Font_Height
        {
            get { return m_Font_Height; }
            set { m_Font_Height = value; }
        }

   

        private DataTable m_dt_Group = null;
        int ypos = 0;


        internal GroupInsideControl m_GroupRoot = null;
        internal GroupInsideControl m_CurrentGroup = null;

        private int m_NumberOfGroupLevels = -1;
        private int m_LastNumberOfGroupLevels = -1;
        private int m_Last_CurrentGroup_GroupLevel = -1;
        private int m_Last_CurrentSelectedGroup_GroupLevel = -1;

        public int NumberOfGroupLevels
        {
            get { return m_NumberOfGroupLevels; }
        }

        public usrc_Item_InsideGroup_Handler()
        {
            InitializeComponent();
            
        }

        private void set_groups()
        {
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

            if (m_GroupRoot == null)
            {
                m_GroupRoot = new GroupInsideControl( null, null, null, DoPaintGroup, ref ypos, m_Button_Height, m_Font_Height);
            }
            m_GroupRoot.Clear();

            if (m_NumberOfGroupLevels > 0)
            {
                switch (m_NumberOfGroupLevels)
                {
                    case 1:
                        ShowRootLevel1();
                        break;

                    case 2:
                        ShowRootLevel2();
                        break;

                    case 3:
                        break;
                    default:
                        LogFile.Error.Show("ERROR:usrc_Group_Handler:usrc_Item_InsideGroup_Handler group level = " + m_NumberOfGroupLevels.ToString() + " not implemented!\r\nMaximal group levels = 3");
                        break;
                }

                CreateGroupTree();

            }
            else
            {
                usrc_Item_InsidePageHandler1.Visible = false;
                usrc_Item_InsidePageHandler2.Visible = false;
                usrc_Item_InsidePageHandler3.Visible = false;
                this.Height = Button_Height;
            }

            if (GroupsRedefined != null)
            {
                GroupsRedefined(m_NumberOfGroupLevels);
            }

            if (m_GroupRoot.m_CurrentSubGroup_In_m_GroupList == null)
            {
                m_GroupRoot.m_CurrentSubGroup_In_m_GroupList = m_GroupRoot.SetFirst();
            }
        }

        public bool Init(DataTable xdt_Group)
        {
            bGroupChanged = false;
            if (!Set_Groups_Table_Equals(xdt_Group))
            {
                bGroupChanged = true;
                m_dt_Group = xdt_Group.Copy();
                set_groups();
            }
            m_LastNumberOfGroupLevels = m_NumberOfGroupLevels;
            return m_NumberOfGroupLevels > 0;
        }

        private Form getParentForm()
        {
            Control ctrl_parent = this.Parent;
            while (ctrl_parent != null)
            {
                if (ctrl_parent is Form)
                {
                    return (Form)ctrl_parent;
                }
                ctrl_parent = ctrl_parent.Parent;
            }
            return null;
        }


        public bool Select(string[] sGroupArr)
        {
            m_CurrentGroup = m_GroupRoot.Select(m_NumberOfGroupLevels, sGroupArr);
            if (m_CurrentGroup != null)
            {
                DoPaintGroup(m_CurrentGroup);
            }
            else
            {
                string Err = "ERROR:usrc_Item_Group_Handler:Select(string[] sGroupArr)";
                string s1_name_cond = " s1_name == null ";
                string s2_name_cond = " s2_name == null ";
                string s3_name_cond = " s3_name == null ";
                if (sGroupArr.Count()==3)
                {
                    if (sGroupArr[0]!=null)
                    {
                        s1_name_cond = " s1_name =='" + sGroupArr[0] + "' ";
                    }
                    if (sGroupArr[1] != null)
                    {
                        s2_name_cond = " s2_name =='" + sGroupArr[1] + "' ";
                    }
                    if (sGroupArr[2] != null)
                    {
                        s3_name_cond = " s3_name =='" + sGroupArr[2] + "' ";
                    }
                    //Err += " Group not found :" + s1_name_cond + " and " + s2_name_cond + " and " + s3_name_cond;
                }
                else
                {
                    Err += ":sGroupArr.Count() != 3 ";
                    LogFile.Error.Show(Err);
                }

                
            }
            return m_CurrentGroup != null;

        }

        private bool Set_Groups_Table_Equals(DataTable xdt_Group)
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
                                if (!Set_Groups_Object_Equals(m_dt_Group.Rows[i][j], xdt_Group.Rows[i][j]))
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

        private bool Set_Groups_Object_Equals(object p1, object p2)
        {
            Type p1_type = p1.GetType();
            Type p2_type = p2.GetType();
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

  
        private void Set_Groups_NumberOfGroupLevel_EQ_1()
        {
            DataRow[] drs_null = null;
            if (m_GroupRoot!=null)
            {
                m_GroupRoot.Clear();
            }

            drs_null = m_dt_Group.Select("s1_name is null");
            GroupInsideControl grp = null;
            if (drs_null.Count() > 0)
            {
                grp = m_GroupRoot.Find(null);
                if (grp == null)
                {
                    grp = new GroupInsideControl( null,this.usrc_Item_InsidePageHandler1, m_GroupRoot, DoPaintGroup,ref ypos,64,14);
                }
            }
            else
            {
                grp = m_GroupRoot.Find(null);
                if (grp != null)
                {
                    if (m_CurrentGroup != null)
                    {
                        if (m_CurrentGroup.EqualsTo(grp.Name))
                        {
                            m_CurrentGroup = null;
                        }
                    }
                }
            }

            DataRow[] drs_not_null = null;
            drs_not_null = m_dt_Group.Select("s1_name is not null");
        }

        private void CreateGroupTree()
        {
            int ypos_pnl1 = 0;
            int ypos_pnl2 = 0;
            int ypos_pnl3 = 0;
            DataRow[] drs_spnl3 = null;
            drs_spnl3 = m_dt_Group.Select("s3_name is not null");
            if (drs_spnl3.Count() > 0)
            {
                foreach (DataRow dr_pnl3 in drs_spnl3)
                {
                    string sGroupName_pnl1 = null;
                    if (dr_pnl3["s3_name"] is string)
                    {
                        sGroupName_pnl1 = (string)dr_pnl3["s3_name"];
                        if (this.m_GroupRoot.Find(sGroupName_pnl1) != null)
                        {
                            continue;
                        }
                        GroupInsideControl grp_pnl1 = new GroupInsideControl( sGroupName_pnl1, this.usrc_Item_InsidePageHandler3,m_GroupRoot, DoPaintGroup, ref ypos_pnl1, m_Button_Height, m_Font_Height);
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
                                        grp_pnl1.m_GroupList = new GroupListInsideControl( grp_pnl1);
                                    }
                                    else
                                    {
                                        if (grp_pnl1.m_GroupList.Find(s2GroupName) != null)
                                        {
                                            continue;
                                        }
                                    }
                                    GroupInsideControl grp2 = new GroupInsideControl( s2GroupName, this.usrc_Item_InsidePageHandler2, grp_pnl1, DoPaintGroup, ref ypos_pnl2, m_Button_Height, m_Font_Height);
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
                                                    grp2.m_GroupList = new GroupListInsideControl( grp2);
                                                }
                                                else
                                                {
                                                    if (grp2.m_GroupList.Find(s1GroupName) != null)
                                                    {
                                                        continue;
                                                    }
                                                }
                                                GroupInsideControl grp1 = new GroupInsideControl( s1GroupName, this.usrc_Item_InsidePageHandler2, grp2, DoPaintGroup, ref ypos_pnl3, m_Button_Height, m_Font_Height);
                                            }
                                        }
                                        DataRow[] drs_s1_root = null;
                                        drs_s1_root = m_dt_Group.Select("s1_name ='" + s2GroupName + "' and s2_name = '" + sGroupName_pnl1 + "' and s3_name is null");
                                        if (drs_s1_root.Count() > 0)
                                        {
                                            GroupInsideControl grp2_root = new GroupInsideControl( null, this.usrc_Item_InsidePageHandler1, grp2, DoPaintGroup, ref ypos_pnl2, m_Button_Height, m_Font_Height);
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
                                GroupInsideControl grp2_root = new GroupInsideControl( null, this.usrc_Item_InsidePageHandler2, grp_pnl1, DoPaintGroup, ref ypos_pnl2, m_Button_Height, m_Font_Height);
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
                foreach (DataRow dr_pnl3 in drs_spnl3)
                {
                    string sGroupName_pnl1 = null;
                    if (dr_pnl3["s2_name"] is string)
                    {
                        sGroupName_pnl1 = (string)dr_pnl3["s2_name"];
                        if (this.m_GroupRoot.Find(sGroupName_pnl1) != null)
                        {
                            continue;
                        }
                        GroupInsideControl grp_pnl1 = new GroupInsideControl( sGroupName_pnl1, this.usrc_Item_InsidePageHandler3, m_GroupRoot, DoPaintGroup, ref ypos_pnl1, m_Button_Height, m_Font_Height);
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
                                        grp_pnl1.m_GroupList = new GroupListInsideControl( grp_pnl1);
                                    }
                                    else
                                    {
                                        if (grp_pnl1.m_GroupList.Find(s1GroupName) != null)
                                        {
                                            continue;
                                        }
                                    }
                                    GroupInsideControl grp1 = new GroupInsideControl( s1GroupName, this.usrc_Item_InsidePageHandler2, grp_pnl1, DoPaintGroup, ref ypos_pnl3, m_Button_Height, m_Font_Height);
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
                        if (this.m_GroupRoot.Find(sGroupName_pnl1) != null)
                        {
                            continue;
                        }
                        if (m_NumberOfGroupLevels > 1)
                        {
                            GroupInsideControl grp_pnl1 = new GroupInsideControl( sGroupName_pnl1, this.usrc_Item_InsidePageHandler3, m_GroupRoot, DoPaintGroup, ref ypos_pnl1, m_Button_Height, m_Font_Height);
                        }
                        else
                        {
                            GroupInsideControl grp_pnl1 = new GroupInsideControl( sGroupName_pnl1, this.usrc_Item_InsidePageHandler1, m_GroupRoot, DoPaintGroup, ref ypos_pnl1, m_Button_Height, m_Font_Height);
                        }
                    }
                }
            }
            drs_spnl3 = m_dt_Group.Select("s1_name is null and s2_name is null and s3_name is null");
            if (drs_spnl3.Count() > 0)
            {
                if (m_NumberOfGroupLevels > 1)
                {
                    GroupInsideControl grp_pnl1 = new GroupInsideControl( null, this.usrc_Item_InsidePageHandler3, m_GroupRoot, DoPaintGroup, ref ypos_pnl1, m_Button_Height, m_Font_Height);
                }
                else
                {
                    GroupInsideControl grp_pnl1 = new GroupInsideControl( null, this.usrc_Item_InsidePageHandler1, m_GroupRoot, DoPaintGroup, ref ypos_pnl1, m_Button_Height, m_Font_Height);
                }
            }
        }



        private void Btn_GroupLevel_Click(object sender, EventArgs e)
        {

            //form_group_handler.SetInitialPosition(this);
            //form_group_handler.Show();
            //form_group_handler.Visible = true;
            //form_group_handler.Focus();
        }


        public void SetVisible(bool v)
        {
            if (v)
            {
                this.Visible = true;
            }
            else
            {
                this.Visible = false;
            }
        }

        private void DoPaintGroup(GroupInsideControl SelectedGroup)
        {
            m_CurrentGroup = m_GroupRoot.GetCurrent();
            if (m_CurrentGroup != null)
            {
                m_sGroupList.Clear();
                m_CurrentGroup.Path(ref m_sGroupList);
                int icount = m_sGroupList.Count;
                string[] sgrups = new string[icount];
                int i;
                for (i = 0; i < icount; i++)
                {
                    sgrups[i] = m_sGroupList[i];
                }
                if (m_NumberOfGroupLevels > 1)
                {
                    int iCurrentGroup_GroupLevel = m_CurrentGroup.GroupLevel;
                    int iCurrentSelectedGroup_GroupLevel = SelectedGroup.GroupLevel;
                    if ((m_Last_CurrentGroup_GroupLevel != iCurrentGroup_GroupLevel) ||
                        (m_Last_CurrentSelectedGroup_GroupLevel != iCurrentSelectedGroup_GroupLevel) ||
                        (iCurrentSelectedGroup_GroupLevel< m_NumberOfGroupLevels) || bGroupChanged)
                    {
                        bGroupChanged = false;
                        m_Last_CurrentGroup_GroupLevel = iCurrentGroup_GroupLevel;
                        m_Last_CurrentSelectedGroup_GroupLevel = iCurrentSelectedGroup_GroupLevel;
                        m_CurrentGroup.SetVisible();
                        switch (iCurrentGroup_GroupLevel)
                        {
                            case 1:
                                ShowRootLevel1();
                                break;
                            case 2:
                                ShowRootLevel2();
                                break;
                            case 3:
                                ShowRootLevel3();
                                break;
                        }
                    }
                }
                else
                {
                    if (bGroupChanged)
                    {
                        bGroupChanged = false;
                        m_CurrentGroup.SetVisible();
                    }
                }
                if (PaintGroup != null)
                {
                    PaintGroup(sgrups);
                }
            }
            else
            {
                //No Groups
                if (PaintGroup != null)
                {
                    PaintGroup(null);
                }
            }
        }

        internal void ShowRootLevel1()
        {
            usrc_Item_InsidePageHandler1.Top = 0;
            usrc_Item_InsidePageHandler1.Visible = true;
            usrc_Item_InsidePageHandler2.Visible = false;
            usrc_Item_InsidePageHandler3.Visible = false;
            this.Height = Button_Height;
        }
        internal void ShowRootLevel2()
        {
            usrc_Item_InsidePageHandler2.Top = 0;
            usrc_Item_InsidePageHandler1.Top = Button_Height;
            usrc_Item_InsidePageHandler1.Visible = true;
            usrc_Item_InsidePageHandler2.Visible = true;
            usrc_Item_InsidePageHandler3.Visible = false;
            this.Height = Button_Height * 2;
        }

        internal void ShowRootLevel3()
        {
            usrc_Item_InsidePageHandler3.Top = 0;
            usrc_Item_InsidePageHandler2.Top = Button_Height;
            usrc_Item_InsidePageHandler1.Top = Button_Height * 2;
            usrc_Item_InsidePageHandler1.Visible = true;
            usrc_Item_InsidePageHandler2.Visible = true;
            usrc_Item_InsidePageHandler3.Visible = true;
            this.Height = Button_Height * 3;
        }

        public string GroupPath 
        {
            get
            {
                string s = "";
                if (m_CurrentGroup != null)
                {
                    m_CurrentGroup.Path(ref s);
                }
                return s;
            }
        }

        private void pnl_Group_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
