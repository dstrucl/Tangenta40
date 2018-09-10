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
using usrc_Item_PageHandler;

namespace usrc_Item_Group_Handler
{
    public partial class usrc_Item_InsideGroup_Handler : UserControl
    {
        public List<string> m_sGroupList = new List<string>();
        private bool bGroupChanged = false;

        public delegate void delegate_SizeChanged(int top, int height);
        public event delegate_SizeChanged SizeChanged = null;



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

        private string s1_name = null;
        private string s2_name = null;
        private string s3_name = null;

        private bool b_usrc_Item_InsidePageHandler_Defined = false;
        public bool usrc_Item_InsidePageHandler_Defined
        {
            get
            {
                return b_usrc_Item_InsidePageHandler_Defined;
            }
            set
            {
                b_usrc_Item_InsidePageHandler_Defined = value;
            }
        }

        private DataTable m_dt_Group = null;


        internal GroupInsideControl m_GroupRoot = null;
        internal GroupInsideControl m_CurrentGroup = null;

        private int m_NumberOfGroupLevels = -1;
        private int m_LastNumberOfGroupLevels = -1;

        public int NumberOfGroupLevels
        {
            get { return m_NumberOfGroupLevels; }
        }

        public usrc_Item_InsideGroup_Handler()
        {
            InitializeComponent();
            
        }

        private void groups_set()
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
                m_GroupRoot = new GroupInsideControl(null, null);
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
            if (!usrc_Item_InsidePageHandler_Defined)
            {
                AddHandlers();
                usrc_Item_InsidePageHandler_Defined = true;
            }
            if (!Set_Groups_Table_Equals(xdt_Group))
            {
                bGroupChanged = true;
                m_dt_Group = xdt_Group.Copy();
                groups_set();
                groups_createcontrols();
            }
            m_LastNumberOfGroupLevels = m_NumberOfGroupLevels;
            return m_NumberOfGroupLevels > 0;
        }

        private void AddHandlers()
        {
            usrc_Item_InsidePageHandler1.CreateControl += Usrc_Item_InsidePageHandler1_CreateControl;
            usrc_Item_InsidePageHandler1.FillControl += Usrc_Item_InsidePageHandler1_FillControl;
            usrc_Item_InsidePageHandler1.Select += Usrc_Item_InsidePageHandler1_Select;
            usrc_Item_InsidePageHandler1.Deselect += Usrc_Item_InsidePageHandler1_Deselect;
            usrc_Item_InsidePageHandler1.SelectControl += Usrc_Item_InsidePageHandler1_SelectControl;
            usrc_Item_InsidePageHandler1.SelectionChanged += Usrc_Item_InsidePageHandler1_SelectionChanged;

            usrc_Item_InsidePageHandler2.CreateControl += Usrc_Item_InsidePageHandler2_CreateControl;
            usrc_Item_InsidePageHandler2.FillControl += Usrc_Item_InsidePageHandler2_FillControl;
            usrc_Item_InsidePageHandler2.Select += Usrc_Item_InsidePageHandler2_Select;
            usrc_Item_InsidePageHandler2.Deselect += Usrc_Item_InsidePageHandler2_Deselect;
            usrc_Item_InsidePageHandler2.SelectControl += Usrc_Item_InsidePageHandler2_SelectControl;
            usrc_Item_InsidePageHandler2.SelectionChanged += Usrc_Item_InsidePageHandler2_SelectionChanged;

            usrc_Item_InsidePageHandler3.CreateControl += Usrc_Item_InsidePageHandler3_CreateControl;
            usrc_Item_InsidePageHandler3.FillControl += Usrc_Item_InsidePageHandler3_FillControl;
            usrc_Item_InsidePageHandler3.Select += Usrc_Item_InsidePageHandler3_Select;
            usrc_Item_InsidePageHandler3.Deselect += Usrc_Item_InsidePageHandler3_Deselect;
            usrc_Item_InsidePageHandler3.SelectControl += Usrc_Item_InsidePageHandler3_SelectControl;
            usrc_Item_InsidePageHandler3.SelectionChanged += Usrc_Item_InsidePageHandler3_SelectionChanged;
        }
        private void groups_createcontrols()
        {
            if (m_GroupRoot!=null)
            {
                if (m_GroupRoot.m_GroupList!=null)
                {
                    int icount = m_GroupRoot.m_GroupList.Items.Count;
                    if (icount > 0)
                    {
                        usrc_Item_InsidePageHandler1.Init(m_GroupRoot.m_GroupList.Items.Cast<object>().ToList());
                        usrc_Item_InsidePageHandler1.ShowPage(0);
                        usrc_Item_InsidePageHandler1.SelectObject(0);
                    }
                }
            }
        }

        private void select(object oData, int index)
        {
            if (oData is GroupInsideControl)
            {
                ((GroupInsideControl)oData).bSelected = true;
            }
        }

        private void deselect(object oData, int index)
        {
            if (oData is GroupInsideControl)
            {
                ((GroupInsideControl)oData).bSelected = false;
            }
        }

        private void selectControl(Control ctrl, object oData, int index, bool selected)
        {
            ctrl.Visible = true;
            if (selected)
            {
                ctrl.BackColor = Color.MistyRose;
                if (oData is GroupInsideControl)
                {
                    ((GroupInsideControl)oData).bSelected = true;
                }
            }
            else
            {
                ctrl.BackColor = Color.White;
                if (oData is GroupInsideControl)
                {
                    ((GroupInsideControl)oData).bSelected = false;
                }
            }
        }

        private void Usrc_Item_InsidePageHandler1_SelectControl(Control ctrl, object oData, int index, bool selected)
        {
            selectControl(ctrl, oData, index, selected);
        }


        private void Usrc_Item_InsidePageHandler2_SelectControl(Control ctrl, object oData, int index, bool selected)
        {
            selectControl(ctrl, oData, index, selected);
        }

        private void Usrc_Item_InsidePageHandler3_SelectControl(Control ctrl, object oData, int index, bool selected)
        {
            selectControl(ctrl, oData, index, selected);
        }

        private void Usrc_Item_InsidePageHandler1_Deselect(object oData, int index)
        {
            deselect(oData, index);
        }
        private void Usrc_Item_InsidePageHandler2_Deselect(object oData, int index)
        {
            deselect(oData, index);
        }
        private void Usrc_Item_InsidePageHandler3_Deselect(object oData, int index)
        {
            deselect(oData, index);
        }


        private void Usrc_Item_InsidePageHandler1_Select(object oData, int index)
        {
            select(oData, index);
        }
        private void Usrc_Item_InsidePageHandler2_Select(object oData, int index)
        {
            select(oData, index);
        }
        private void Usrc_Item_InsidePageHandler3_Select(object oData, int index)
        {
            select(oData, index);
        }

        private void Usrc_Item_InsidePageHandler1_SelectionChanged(Control ctrl, object oData, int index)
        {
            if (oData is GroupInsideControl)
            {
                GroupInsideControl gic = (GroupInsideControl)oData;
                s1_name = gic.Name;
                if (gic.m_GroupList != null)
                {
                    int iCount = gic.m_GroupList.Items.Count;
                    if (iCount > 0)
                    {
                        ShowRootLevel2();
                        usrc_Item_InsidePageHandler2.Init(gic.m_GroupList.Items.Cast<object>().ToList());
                        usrc_Item_InsidePageHandler2.ShowPage(0);
                        usrc_Item_InsidePageHandler2.SelectObject(0);
                    }
                    else
                    {
                        ShowRootLevel1();
                    }
                }
                else
                {
                    ShowRootLevel1();
                }
            }
        }

        private void add_usrc_Item_InsidePageHandlers(usrc_Item_InsidePageHandler usrc_Item_InsidePageHandler)
        {
            throw new NotImplementedException();
        }

        private void Usrc_Item_InsidePageHandler2_SelectionChanged(Control ctrl, object oData, int index)
        {
            if (oData is GroupInsideControl)
            {
                GroupInsideControl gic = (GroupInsideControl)oData;
                s2_name = gic.Name;
                if (gic.m_GroupList != null)
                {
                    int iCount = gic.m_GroupList.Items.Count;
                    if (iCount > 0)
                    {
                        usrc_Item_InsidePageHandler3.Init(gic.m_GroupList.Items.Cast<object>().ToList());
                        usrc_Item_InsidePageHandler3.ShowPage(0);
                        usrc_Item_InsidePageHandler3.SelectObject(0);
                        ShowRootLevel3();
                    }
                    else
                    {
                        ShowRootLevel2();
                    }
                }
                else
                {
                    ShowRootLevel2();
                }
            }
        }

        private void Usrc_Item_InsidePageHandler3_SelectionChanged(Control ctrl, object oData, int index)
        {
            if (oData is GroupInsideControl)
            {
                GroupInsideControl gic = (GroupInsideControl)oData;
                s3_name = gic.Name;
                ShowRootLevel3();
                    // Show Items of GroupInsideControl
            }
        }


        private void Usrc_Item_InsidePageHandler1_CreateControl(ref Control ctrl)
        {
            Button btn = new Button();
            ctrl = btn;
        }

        private void Usrc_Item_InsidePageHandler2_CreateControl(ref Control ctrl)
        {
            Button btn = new Button();
            ctrl = btn;
        }

        private void Usrc_Item_InsidePageHandler3_CreateControl(ref Control ctrl)
        {
            Button btn = new Button();
            ctrl = btn;
        }

        private void fillControl(Control ctrl, object oData)
        {
            if (oData is GroupInsideControl)
            {
                Button btn = (Button)ctrl;
                GroupInsideControl gic = (GroupInsideControl)oData;
                if (gic.Name != null)
                {
                    btn.Text = gic.Name;
                }
                else
                {
                    btn.Text = lng.s_Other.s;
                }
            }
        }
                
        private void Usrc_Item_InsidePageHandler1_FillControl(Control ctrl, object oData)
        {
            fillControl(ctrl, oData);
        }

        private void Usrc_Item_InsidePageHandler2_FillControl(Control ctrl, object oData)
        {
            fillControl(ctrl, oData);
        }

        private void Usrc_Item_InsidePageHandler3_FillControl(Control ctrl, object oData)
        {
            fillControl(ctrl, oData);
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
            //m_CurrentGroup = m_GroupRoot.Select(m_NumberOfGroupLevels, sGroupArr);
            //if (m_CurrentGroup != null)
            //{
            //    DoPaintGroup(m_CurrentGroup);
            //}
            //else
            //{
            //    string Err = "ERROR:usrc_Item_Group_Handler:Select(string[] sGroupArr)";
            //    string s1_name_cond = " s1_name == null ";
            //    string s2_name_cond = " s2_name == null ";
            //    string s3_name_cond = " s3_name == null ";
            //    if (sGroupArr.Count()==3)
            //    {
            //        if (sGroupArr[0]!=null)
            //        {
            //            s1_name_cond = " s1_name =='" + sGroupArr[0] + "' ";
            //        }
            //        if (sGroupArr[1] != null)
            //        {
            //            s2_name_cond = " s2_name =='" + sGroupArr[1] + "' ";
            //        }
            //        if (sGroupArr[2] != null)
            //        {
            //            s3_name_cond = " s3_name =='" + sGroupArr[2] + "' ";
            //        }
            //        //Err += " Group not found :" + s1_name_cond + " and " + s2_name_cond + " and " + s3_name_cond;
            //    }
            //    else
            //    {
            //        Err += ":sGroupArr.Count() != 3 ";
            //        LogFile.Error.Show(Err);
            //    }

                
            //}
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
                    grp = new GroupInsideControl(m_GroupRoot, null);
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
            DataRow[] drs_s3_root = null;
            drs_s3_root = m_dt_Group.Select("s3_name is not null");
            if (drs_s3_root.Count() > 0)
            {
                foreach (DataRow dr_root in drs_s3_root)
                {
                    string sGroupName_root = null;
                    if (dr_root["s3_name"] is string)
                    {
                        sGroupName_root = (string)dr_root["s3_name"];
                        if (this.m_GroupRoot.Find(sGroupName_root) != null)
                        {
                            continue;
                        }
                        GroupInsideControl grp_root_child = new GroupInsideControl(m_GroupRoot, sGroupName_root);
                        DataRow[] drs_root_child = null;
                        drs_root_child = m_dt_Group.Select("s3_name ='" + sGroupName_root + "'");
                        if (drs_root_child.Count() > 0)
                        {
                            foreach (DataRow dr_root_child in drs_root_child)
                            {
                                string s_root_child = null;
                                if (dr_root_child["s2_name"] is string)
                                {
                                    s_root_child = (string)dr_root_child["s2_name"];
                                    if (grp_root_child.m_GroupList == null)
                                    {
                                        grp_root_child.m_GroupList = new GroupListInsideControl(grp_root_child);
                                    }
                                    else
                                    {
                                        if (grp_root_child.m_GroupList.Find(s_root_child) != null)
                                        {
                                            continue;
                                        }
                                    }
                                    GroupInsideControl grp_root_child_child = new GroupInsideControl(grp_root_child, s_root_child);
                                    DataRow[] drs_s1 = null;
                                    drs_s1 = m_dt_Group.Select("s2_name ='" + s_root_child + "' and s3_name = '" + sGroupName_root + "'");
                                    if (drs_s1.Count() > 0)
                                    {
                                        foreach (DataRow dr1 in drs_s1)
                                        {
                                            if (dr1["s1_name"] is string)
                                            {
                                                string s1GroupName = (string)dr1["s1_name"];
                                                if (grp_root_child_child.m_GroupList == null)
                                                {
                                                    grp_root_child_child.m_GroupList = new GroupListInsideControl(grp_root_child_child);
                                                }
                                                else
                                                {
                                                    if (grp_root_child_child.m_GroupList.Find(s1GroupName) != null)
                                                    {
                                                        continue;
                                                    }
                                                }
                                                GroupInsideControl grp1 = new GroupInsideControl(grp_root_child_child, s1GroupName);
                                            }
                                        }
                                        DataRow[] drs_s3_root_child_child = null;
                                        drs_s3_root_child_child = m_dt_Group.Select("s1_name ='" + s_root_child + "' and s2_name = '" + sGroupName_root + "' and s3_name is null");
                                        if (drs_s3_root_child_child.Count() > 0)
                                        {
                                            GroupInsideControl grp2_root = new GroupInsideControl(grp_root_child_child, null);
                                        }
                                    }
                                    else
                                    {
                                        LogFile.Error.Show("ERROR:usrc_Item_Group_Handler:Create_NumberOfGroupLevel_EQ_3: NumberOfGroupLevel is not 3,2 or 1 !");
                                    }
                                }
                            }
                            DataRow[] drs_root_child_child = null;
                            drs_root_child_child = m_dt_Group.Select("s2_name ='" + sGroupName_root + "' and s3_name is null");
                            if (drs_root_child_child.Count() > 0)
                            {
                                GroupInsideControl grp_root_child_child = new GroupInsideControl(grp_root_child, null);
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:usrc_Item_Group_Handler:Create_NumberOfGroupLevel_EQ_3: NumberOfGroupLevel is not 3 or 2 !");
                        }
                    }
                }
            }
            DataRow[] drs_s2_root = m_dt_Group.Select("s2_name is not null and s3_name is null");
            if (drs_s2_root.Count() > 0)
            {
                foreach (DataRow dr_s2_root in drs_s2_root)
                {
                    string sGroupName_s2_root = null;
                    if (dr_s2_root["s2_name"] is string)
                    {
                        sGroupName_s2_root = (string)dr_s2_root["s2_name"];
                        if (this.m_GroupRoot.Find(sGroupName_s2_root) != null)
                        {
                            continue;
                        }
                        GroupInsideControl grp_s2_root_child = new GroupInsideControl(m_GroupRoot, sGroupName_s2_root);
                        DataRow[] drs_s2_root_child = null;
                        drs_s2_root_child = m_dt_Group.Select("s2_name ='" + sGroupName_s2_root + "'");
                        if (drs_s2_root_child.Count() > 0)
                        {
                            foreach (DataRow dr_s2_root_child in drs_s2_root_child)
                            {
                                if (dr_s2_root_child["s1_name"] is string)
                                {
                                    string sGroup_s2_root_child = (string)dr_s2_root_child["s1_name"];
                                    if (grp_s2_root_child.m_GroupList == null)
                                    {
                                        grp_s2_root_child.m_GroupList = new GroupListInsideControl(grp_s2_root_child);
                                    }
                                    else
                                    {
                                        if (grp_s2_root_child.m_GroupList.Find(sGroup_s2_root_child) != null)
                                        {
                                            continue;
                                        }
                                    }
                                    GroupInsideControl grp1 = new GroupInsideControl(grp_s2_root_child, sGroup_s2_root_child);
                                }
                            }
                        }
                    }
                }
            }
            DataRow[] drs_s1_root = m_dt_Group.Select("s1_name is not null and s2_name is null and s3_name is null");
            if (drs_s1_root.Count() > 0)
            {
                foreach (DataRow dr_s1_root in drs_s1_root)
                {
                    string sGroupName_s1_root = null;
                    if (dr_s1_root["s1_name"] is string)
                    {
                        sGroupName_s1_root = (string)dr_s1_root["s1_name"];
                        if (this.m_GroupRoot.Find(sGroupName_s1_root) != null)
                        {
                            continue;
                        }
                        if (m_NumberOfGroupLevels > 1)
                        {
                            GroupInsideControl grp_pnl1 = new GroupInsideControl(m_GroupRoot, sGroupName_s1_root);
                        }
                        else
                        {
                            GroupInsideControl grp_pnl1 = new GroupInsideControl(m_GroupRoot, sGroupName_s1_root);
                        }
                    }
                }
            }

            DataRow[] drs_root = m_dt_Group.Select("s1_name is null and s2_name is null and s3_name is null");
            if (drs_s1_root.Count() > 0)
            {
                if (m_NumberOfGroupLevels > 1)
                {
                    GroupInsideControl grp_pnl1 = new GroupInsideControl(m_GroupRoot, null);
                }
                else
                {
                    GroupInsideControl grp_pnl1 = new GroupInsideControl(m_GroupRoot, null);
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


        internal void ShowRootLevel1()
        {
            usrc_Item_InsidePageHandler1.Top = Button_Height*2;
            usrc_Item_InsidePageHandler1.Visible = true;
            usrc_Item_InsidePageHandler2.Visible = false;
            usrc_Item_InsidePageHandler3.Visible = false;
            this.Height = Button_Height;
            if (SizeChanged!=null)
            {
                SizeChanged(usrc_Item_InsidePageHandler1.Top, this.Height);
            }
        }
        internal void ShowRootLevel2()
        {
            usrc_Item_InsidePageHandler2.Top = Button_Height;
            usrc_Item_InsidePageHandler1.Top = Button_Height*2;
            usrc_Item_InsidePageHandler1.Visible = true;
            usrc_Item_InsidePageHandler2.Visible = true;
            usrc_Item_InsidePageHandler3.Visible = false;
            this.Height = Button_Height * 2;
            if (SizeChanged != null)
            {
                SizeChanged(usrc_Item_InsidePageHandler2.Top, this.Height);
            }
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
            if (SizeChanged != null)
            {
                SizeChanged(usrc_Item_InsidePageHandler3.Top, this.Height);
            }
        }

        public string GroupPath 
        {
            get
            {
                string s = "";
                if (m_CurrentGroup != null)
                {
                    //m_CurrentGroup.Path(ref s);
                }
                return s;
            }
        }

        private void pnl_Group_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
