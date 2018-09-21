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
using usrc_Item_InsidePage_Handler;

namespace usrc_Item_InsideGroup_Handler
{
    public partial class usrc_Item_InsideGroupHandler : UserControl
    {
        private string[] currentGroups = null;

        public List<string> m_sGroupList = new List<string>();
        private bool bGroupChanged = false;

        public delegate void delegate_SizeChanged(int height);
        public event delegate_SizeChanged SizeChanged = null;

        public delegate void delegate_SelectionChanged(string []sgroup);
        public event delegate_SelectionChanged SelectionChanged = null;

        //public delegate void delegate_GroupsRedefined(int Level);
        //public event delegate_GroupsRedefined GroupsRedefined = null;

        //public delegate void delegate_PaintGroup(string[] s_name);
        //public event delegate_PaintGroup PaintGroup = null;


        private int m_ctrlWidth = 100;

        public int CtrlWidth
        {
            get
            {
                return m_ctrlWidth;
            }
            set
            {
                m_ctrlWidth = value;
                if (usrc_Item_InsidePageHandler1 != null)
                {
                    usrc_Item_InsidePageHandler1.CtrlWidth = m_ctrlWidth;
                }
                if (usrc_Item_InsidePageHandler2 != null)
                {
                    usrc_Item_InsidePageHandler2.CtrlWidth = m_ctrlWidth;
                }
                if (usrc_Item_InsidePageHandler3 != null)
                {
                    usrc_Item_InsidePageHandler3.CtrlWidth = m_ctrlWidth;
                }
            }
        }

        private int m_ctrlHeight = 40;
        public int CtrlHeight
        {
            get
            {
                return m_ctrlHeight;
            }
            set
            {
                m_ctrlHeight = value;
                if (usrc_Item_InsidePageHandler1!=null)
                {
                    usrc_Item_InsidePageHandler1.CtrlHeight = m_ctrlHeight;
                }
                if (usrc_Item_InsidePageHandler2 != null)
                {
                    usrc_Item_InsidePageHandler2.CtrlHeight = m_ctrlHeight;
                }
                if (usrc_Item_InsidePageHandler3 != null)
                {
                    usrc_Item_InsidePageHandler3.CtrlHeight = m_ctrlHeight;
                }
            }
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

        public DataTable m_dt_Group = null;


        internal GroupInsideControl m_GroupRoot = null;
        internal GroupInsideControl m_CurrentGroup = null;

        private int m_NumberOfGroupLevels = -1;
        private int m_LastNumberOfGroupLevels = -1;

        public int NumberOfGroupLevels
        {
            get { return m_NumberOfGroupLevels; }
        }

        public usrc_Item_InsideGroupHandler()
        {
            InitializeComponent();
            
        }

        public void SelectGroup(string[] sgroup)
        {
            if (sgroup[2] != null)
            {
                int index = usrc_Item_InsidePageHandler1.FindItem(sgroup[2]);
                if (index >= 0)
                {
                    usrc_Item_InsidePageHandler1.SelectObject(index,usrc_Item_InsidePageHandler.eSelection.ON_SELECT_GROUP);
                    if (sgroup[1] != null)
                    {
                        index = usrc_Item_InsidePageHandler2.FindItem(sgroup[1]);
                        if (index >= 0)
                        {
                            usrc_Item_InsidePageHandler2.SelectObject(index, usrc_Item_InsidePageHandler.eSelection.ON_SELECT_GROUP);
                        }
                        if (sgroup[0] != null)
                        {
                            index = usrc_Item_InsidePageHandler3.FindItem(sgroup[0]);
                            if (index >= 0)
                            {
                                usrc_Item_InsidePageHandler3.SelectObject(index, usrc_Item_InsidePageHandler.eSelection.ON_SELECT_GROUP);
                            }
                        }
                    }
                }
            }
            else
            {
                if (sgroup[1] != null)
                {
                    int index = usrc_Item_InsidePageHandler1.FindItem(sgroup[1]);
                    if (index >= 0)
                    {
                        usrc_Item_InsidePageHandler1.SelectObject(index, usrc_Item_InsidePageHandler.eSelection.ON_SELECT_GROUP);
                        if (sgroup[0] != null)
                        {
                            index = usrc_Item_InsidePageHandler2.FindItem(sgroup[0]);
                            if (index >= 0)
                            {
                                usrc_Item_InsidePageHandler2.SelectObject(index, usrc_Item_InsidePageHandler.eSelection.ON_SELECT_GROUP);
                            }
                        }
                    }
                }
                else
                {
                    if (sgroup[0] != null)
                    {
                        int index = usrc_Item_InsidePageHandler1.FindItem(sgroup[0]);
                        if (index >= 0)
                        {
                            usrc_Item_InsidePageHandler1.SelectObject(index, usrc_Item_InsidePageHandler.eSelection.ON_SELECT_GROUP);
                        }
                    }
                }
            }
            if (SelectionChanged!=null)
            {
                string[] s =  usrc_Item_InsideGroupHandler.reversegroup(sgroup);
                SelectionChanged(s);
            }
        }

        public static string[] reversegroup(string[] groups)
        {
            string[] sr = new string[3] { null, null, null };
            if (groups[2] == null)
            {
                if (groups[1] == null)
                {
                    sr[0] = groups[0];
                }
                else
                {
                    sr[0] = groups[1];
                    sr[1] = groups[0];
                }
            }
            else
            {
                sr[0] = groups[0];
                sr[1] = groups[1];
                sr[2] = groups[2];
            }
            return sr;
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
                        ShowRootLevel3();
                        break;
                    default:
                        LogFile.Error.Show("ERROR:usrc_Group_Handler:usrc_Item_InsideGroup_Handler group level = " + m_NumberOfGroupLevels.ToString() + " not implemented!\r\nMaximal group levels = 3");
                        break;
                }

                CreateGroupTree();

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
            usrc_Item_InsidePageHandler1.SetName += Usrc_Item_InsidePageHandler1_SetName;
            usrc_Item_InsidePageHandler1.CreateControl += Usrc_Item_InsidePageHandler1_CreateControl;
            usrc_Item_InsidePageHandler1.FillControl += Usrc_Item_InsidePageHandler1_FillControl;
            usrc_Item_InsidePageHandler1.SelectControl += Usrc_Item_InsidePageHandler1_SelectControl;
            usrc_Item_InsidePageHandler1.Paint += Usrc_Item_InsidePageHandler1_Paint;
            usrc_Item_InsidePageHandler1.SelectionChanged += Usrc_Item_InsidePageHandler1_SelectionChanged;

            usrc_Item_InsidePageHandler2.SetName += Usrc_Item_InsidePageHandler2_SetName;
            usrc_Item_InsidePageHandler2.CreateControl += Usrc_Item_InsidePageHandler2_CreateControl;
            usrc_Item_InsidePageHandler2.FillControl += Usrc_Item_InsidePageHandler2_FillControl;
            usrc_Item_InsidePageHandler2.SelectControl += Usrc_Item_InsidePageHandler2_SelectControl;
            usrc_Item_InsidePageHandler2.Paint += Usrc_Item_InsidePageHandler2_Paint;
            usrc_Item_InsidePageHandler2.SelectionChanged += Usrc_Item_InsidePageHandler2_SelectionChanged;

            usrc_Item_InsidePageHandler3.SetName += Usrc_Item_InsidePageHandler3_SetName;
            usrc_Item_InsidePageHandler3.CreateControl += Usrc_Item_InsidePageHandler3_CreateControl;
            usrc_Item_InsidePageHandler3.FillControl += Usrc_Item_InsidePageHandler3_FillControl;
            usrc_Item_InsidePageHandler3.SelectControl += Usrc_Item_InsidePageHandler3_SelectControl;
            usrc_Item_InsidePageHandler3.Paint += Usrc_Item_InsidePageHandler3_Paint;
            usrc_Item_InsidePageHandler3.SelectionChanged += Usrc_Item_InsidePageHandler3_SelectionChanged;

        }


        private bool Usrc_Item_InsidePageHandler3_SetName(object oData, ref string name)
        {
            if (oData is GroupInsideControl)
            {
                GroupInsideControl gic = (GroupInsideControl)oData;
                name = gic.Name;
                return true;
            }
            return false;
        }

        private bool Usrc_Item_InsidePageHandler2_SetName(object oData, ref string name)
        {
            if (oData is GroupInsideControl)
            {
                GroupInsideControl gic = (GroupInsideControl)oData;
                name = gic.Name;
                return true;
            }
            return false;
        }

        private bool Usrc_Item_InsidePageHandler1_SetName(object oData, ref string name)
        {
            if (oData is GroupInsideControl)
            {
                GroupInsideControl gic = (GroupInsideControl)oData;
                name = gic.Name;
                return true;
            }
            return false;
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
                        usrc_Item_InsidePageHandler1.Init(m_GroupRoot.m_GroupList.Items.Cast<object>().ToList(), usrc_Item_InsidePageHandler.eMode.EDIT);
                        usrc_Item_InsidePageHandler1.SelectObject(0, usrc_Item_InsidePageHandler.eSelection.ON_SELECT_GROUP);
                        getSelectedGroups();
                        return;
                    }
                }
            }
            ShowRootLevel0();
            if (SelectionChanged!=null)
            {
                SelectionChanged(new string[3] { null, null, null });
            }
        }

        private void getSelectedGroups()
        {
            s1_name = null;
            s2_name = null;
            s3_name = null;

            if (usrc_Item_InsidePageHandler3.Visible)
            {
                s3_name = usrc_Item_InsidePageHandler1.SelectedItemName;
                s2_name = usrc_Item_InsidePageHandler2.SelectedItemName;
                s1_name = usrc_Item_InsidePageHandler3.SelectedItemName;
                if (s1_name==null)
                {
                    s1_name = s2_name;
                    s2_name = s3_name;
                    s3_name = null;
                }
            }
            else
            {
                if (usrc_Item_InsidePageHandler2.Visible)
                {
                    s1_name = usrc_Item_InsidePageHandler1.SelectedItemName;
                    s2_name = usrc_Item_InsidePageHandler2.SelectedItemName;
                }
                else
                {
                    if (usrc_Item_InsidePageHandler1.Visible)
                    {
                        s1_name = usrc_Item_InsidePageHandler1.SelectedItemName;
                    }
                }

            }
            string[] newgroups = new string[3] { s1_name, s2_name, s3_name };

            if (currentGroups==null)
            {
                currentGroups = newgroups;
                if (SelectionChanged != null)
                {
                    SelectionChanged(newgroups);
                }
            }
            else
            {
                if (!groupsEqual(currentGroups, newgroups))
                {
                    currentGroups = newgroups;
                    if (SelectionChanged!=null)
                    {
                        SelectionChanged(newgroups);
                    }
                }
            }
        }

        private bool groupsEqual(string[] currentGroups, string[] newgroups)
        {
            if (currentGroups.Length == newgroups.Length)
            {
                int ilen = currentGroups.Length;
                for (int i = 0; i < ilen; i++)
                {
                    if ((currentGroups[i] != null) && (newgroups[i] != null))
                    {
                        if (!currentGroups[i].Equals(newgroups[i]))
                        {
                            return false;
                        }
                    }
                    else if ((currentGroups[i] == null) && (newgroups[i] == null))
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Usrc_Item_InsidePageHandler1_Paint(Control ctrl, object oData, int index)
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
                        usrc_Item_InsidePageHandler2.Init(gic.m_GroupList.Items.Cast<object>().ToList(), usrc_Item_InsidePage_Handler.usrc_Item_InsidePageHandler.eMode.EDIT);
                        usrc_Item_InsidePageHandler2.SelectObject(0,usrc_Item_InsidePageHandler.eSelection.ON_PAINT);
                        return;
                    }
                }
            }
            ShowRootLevel1();
        }

        private void Usrc_Item_InsidePageHandler1_SelectionChanged(Control ctrl, object oData, int index, bool selected)
        {
            getSelectedGroups();
        }

        private void Usrc_Item_InsidePageHandler2_SelectionChanged(Control ctrl, object oData, int index, bool selected)
        {
            getSelectedGroups();
        }

        private void Usrc_Item_InsidePageHandler3_SelectionChanged(Control ctrl, object oData, int index, bool selected)
        {
            getSelectedGroups();
        }

        private void Usrc_Item_InsidePageHandler2_Paint(Control ctrl, object oData, int index)
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
                        ShowRootLevel3();
                        usrc_Item_InsidePageHandler3.Init(gic.m_GroupList.Items.Cast<object>().ToList(), usrc_Item_InsidePageHandler.eMode.EDIT);
                        usrc_Item_InsidePageHandler3.SelectObject(0,usrc_Item_InsidePageHandler.eSelection.ON_PAINT);
                        return;
                    }
                }
            }
            ShowRootLevel2();
        }

        private void Usrc_Item_InsidePageHandler3_Paint(Control ctrl, object oData, int index)
        {
            if (oData is GroupInsideControl)
            {
                GroupInsideControl gic = (GroupInsideControl)oData;
                s3_name = gic.Name;
                ShowRootLevel3();
                return;
                // Show Items of GroupInsideControl
            }
            ShowRootLevel2();
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

        private void fillControl(Control ctrl, object oData, usrc_Item_InsidePageHandler.eMode emode)
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
                
        private void Usrc_Item_InsidePageHandler1_FillControl(Control ctrl, object oData, usrc_Item_InsidePageHandler.eMode emode)
        {
            fillControl(ctrl, oData, emode);
        }

        private void Usrc_Item_InsidePageHandler2_FillControl(Control ctrl, object oData, usrc_Item_InsidePageHandler.eMode emode)
        {
            fillControl(ctrl, oData, emode);
        }

        private void Usrc_Item_InsidePageHandler3_FillControl(Control ctrl, object oData, usrc_Item_InsidePageHandler.eMode emode)
        {
            fillControl(ctrl, oData,emode);
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


        private bool Set_Groups_Table_Equals(DataTable xdt_Group)
        {
            if (m_dt_Group != null)
            {
                int irows_count = m_dt_Group.Rows.Count;
                if (irows_count == xdt_Group.Rows.Count)
                {
                    int jcolumn_count = m_dt_Group.Columns.Count;
                    if (jcolumn_count == xdt_Group.Columns.Count)
                    {
                        for (int i = 0; i < irows_count; i++)
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

      
        internal void ShowRootLevel0()
        {
            usrc_Item_InsidePageHandler1.Top = 0;
            usrc_Item_InsidePageHandler1.Visible = false;
            usrc_Item_InsidePageHandler2.Visible = false;
            usrc_Item_InsidePageHandler3.Visible = false;
            this.Height = 0;
            if (SizeChanged != null)
            {
                SizeChanged(this.Height);
            }
        }

        internal void ShowRootLevel1()
        {
            usrc_Item_InsidePageHandler1.Top = 0;
            usrc_Item_InsidePageHandler1.Visible = true;
            usrc_Item_InsidePageHandler2.Visible = false;
            usrc_Item_InsidePageHandler3.Visible = false;
            this.Height = this.CtrlHeight;
            if (SizeChanged!=null)
            {
                SizeChanged(this.Height);
            }
        }
        internal void ShowRootLevel2()
        {
            usrc_Item_InsidePageHandler2.Top = 0;
            usrc_Item_InsidePageHandler1.Top = this.CtrlHeight;
            usrc_Item_InsidePageHandler1.Visible = true;
            usrc_Item_InsidePageHandler2.Visible = true;
            usrc_Item_InsidePageHandler3.Visible = false;
            this.Height = this.CtrlHeight * 2;
            if (SizeChanged != null)
            {
                SizeChanged(this.Height);
            }
        }

        internal void ShowRootLevel3()
        {
            usrc_Item_InsidePageHandler3.Top = 0;
            usrc_Item_InsidePageHandler2.Top = this.CtrlHeight;
            usrc_Item_InsidePageHandler1.Top = this.CtrlHeight * 2;
            usrc_Item_InsidePageHandler1.Visible = true;
            usrc_Item_InsidePageHandler2.Visible = true;
            usrc_Item_InsidePageHandler3.Visible = true;
            this.Height = this.CtrlHeight * 3;
            if (SizeChanged != null)
            {
                SizeChanged(this.Height);
            }
        }

        private bool usrc_Item_InsidePageHandler1_CompareWithString(object oData, string s)
        {
            if (oData is GroupInsideControl)
            {
                return ((GroupInsideControl)oData).Name.Equals(s);
            }
            return false;
        }

        private bool usrc_Item_InsidePageHandler2_CompareWithString(object oData, string s)
        {

            if (oData is GroupInsideControl)
            {
                return ((GroupInsideControl)oData).Name.Equals(s);
            }
            return false;
        }

        private bool usrc_Item_InsidePageHandler3_CompareWithString(object oData, string s)
        {
            if (oData is GroupInsideControl)
            {
                return ((GroupInsideControl)oData).Name.Equals(s);
            }
            return false;
        }
    }
}
