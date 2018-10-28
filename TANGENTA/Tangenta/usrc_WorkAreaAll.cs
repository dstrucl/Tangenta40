using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBTypes;
using TangentaDB;
using DBConnectionControl40;

namespace Tangenta
{
    public partial class usrc_WorkAreaAll : UserControl
    {
        public delegate void delegate_Selected(WArea warea);

        public event delegate_Selected Selected = null;

        public delegate void delegate_Exit();

        public event delegate_Exit Exit = null;

        DataTable dtWorkAreaGroup = null;
        DataTable m_dtWorkAreaAll = null;
        int ipnl_Items_Width_default = -1;

        public DataTable dtWorkAreaAll
        {
            get
            {
                return m_dtWorkAreaAll;
            }
            set
            {
                m_dtWorkAreaAll = value;
            }
        }

        public string[] s_name_Group = null;

        public int m_NumberOfItemsPerPage = 10;
        public int NumberOfItemsPerPage
        {
            get { return m_NumberOfItemsPerPage; }
            set
            {
                m_NumberOfItemsPerPage = value;
                Init();
            }
        }

        public usrc_WorkArea[] usrc_WorkArea_aray = null;

        public usrc_WorkAreaAll()
        {
            InitializeComponent();
            ipnl_Items_Width_default = pnl_Items.Width;
        }

        internal void Init()
        {
            lbl_Tangenta.ForeColor = ColorSettings.Sheme.Current().Colorpair[1].ForeColor;
            
            usrc_WorkArea_aray = new usrc_WorkArea[NumberOfItemsPerPage];

            int i = 0;
            int yPos = 0;
            while (pnl_Items.Controls.Count > 0)
            {
                Control ctrl = pnl_Items.Controls[0];
                this.pnl_Items.Controls.Remove(ctrl);
                ctrl.Dispose();
            }
            pnl_Items.AutoScrollOffset = new Point(0, 0);
            pnl_Items.AutoScrollPosition = new Point(0, 0);
            for (i = 0; i < m_NumberOfItemsPerPage; i++)
            {
                usrc_WorkArea usrc_item = new usrc_WorkArea();
                usrc_item.Selected += Usrc_item_Selected;
                usrc_item.m_usrc_WorkAreaAll = this;
                usrc_item.Top = yPos;
                usrc_item.Left = 5;
                usrc_item.Width = this.pnl_Items.Width - 10;
                usrc_item.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                yPos += usrc_item.Height + 1;
                //usrc_item.BackColor = Colors.ItemFromStock.BackColor;
                //usrc_item.ForeColor = Colors.ItemFromStock.ForeColor;
                usrc_WorkArea_aray[i] = usrc_item;
                this.pnl_Items.Controls.Add(usrc_item);
            }
            this.pnl_Items.AutoScroll = true;
            this.pnl_Items.HorizontalScroll.Enabled = true;
            this.pnl_Items.VerticalScroll.Enabled = true;
            if (this.Visible)
            {
                LogFile.LogFile.WriteDEBUG("-> usrc_ItemList:Init(..) Visible=TRUE");
            }
            else
            {
                LogFile.LogFile.WriteDEBUG("-> usrc_ItemList:Init(..) Visible=FALSE");
            }
            Get_WorkArea_Data();

        }

        private void Usrc_item_Selected(WArea warea)
        {
           if (Selected!=null)
            {
                Selected(warea); 
            }
        }

        public bool Get_WorkArea_Data()
        {
            if (f_WorkArea.GetGroupsTable(ref dtWorkAreaGroup))
            {
                if (usrc_Item_Group_Handler1.Set_Groups(dtWorkAreaGroup))
                {
                    splitContainer1.Panel2Collapsed = false;
                    if (usrc_Item_Group_Handler1.NumberOfGroupLevels > 1)
                    {
                        splitContainer1.SplitterDistance = splitContainer1.Width - 32;
                    }
                    else
                    {
                        splitContainer1.SplitterDistance = splitContainer1.Width - 82;
                    }
                    if (dtWorkAreaGroup.Rows.Count > 0)
                    {
                        string s1_name = null;
                        string s2_name = null;
                        string s3_name = null;
                        if (dtWorkAreaGroup.Rows[0]["s1_name"] is string)
                        {
                            s1_name = (string)dtWorkAreaGroup.Rows[0]["s1_name"];
                        }
                        if (dtWorkAreaGroup.Rows[0]["s2_name"] is string)
                        {
                            s2_name = (string)dtWorkAreaGroup.Rows[0]["s2_name"];
                        }
                        if (dtWorkAreaGroup.Rows[0]["s3_name"] is string)
                        {
                            s3_name = (string)dtWorkAreaGroup.Rows[0]["s3_name"];
                        }

                        string[] sGroup = new string[] { s1_name, s2_name, s3_name };
                        usrc_Item_Group_Handler1.Select(sGroup);
                        return true;
                    }
                }
                else
                {
                    splitContainer1.Panel2Collapsed = true;
                    string[] sGroup = new string[] { null, null, null };
                    usrc_Item_Group_Handler1.Select(sGroup);
                    return true;
                }
            }
            return false;
        }

        private void m_usrc_Item_PageHandler_ShowObject(int Item_id_index, object o_data, object o_usrc, bool bVisible)
        {
            if (this.Visible)
            {
                LogFile.LogFile.WriteDEBUG("-> usrc_ItemList:m_usrc_Item_PageHandler_ShowObject(..) Visible=TRUE");
                usrc_WorkArea usrc_item = (usrc_WorkArea)o_usrc;
                if (bVisible)
                {
                    if (o_data is DataRow)
                    {
                        usrc_item.SetData((DataRow)o_data);
                        //Item_Data iData = (Item_Data)o_data;
                        usrc_item.Visible = true;
                        usrc_item.Enabled = true;
                        usrc_item.DoPaint(null, s_name_Group, null);
                    }
                }
                else
                {
                    usrc_item.Visible = false;
                    usrc_item.Enabled = false;
                }
            }
            else
            {
                LogFile.LogFile.WriteDEBUG("-> usrc_ItemList:m_usrc_Item_PageHandler_ShowObject(..) Visible=FALSE");
            }
        }



        private void Paint_Group(string[] s_name)
        {
            if (usrc_WorkAreaAll_Load(s_name))
            {
                lbl_GroupPath.Text = this.usrc_Item_Group_Handler1.GroupPath;
                this.usrc_Item_PageHandler1.Init(m_dtWorkAreaAll, 5, usrc_WorkArea_aray);
            }
        }

        private bool usrc_WorkAreaAll_Load(string[] s_name)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string s_group_condition = fs.GetGroupCondition(ref lpar, s_name);
            string where_condition = " where WorkArea.Active = 1 "+ s_group_condition;
            if (f_WorkArea.Read_WorkArea_VIEW(ref m_dtWorkAreaAll, where_condition, lpar))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void usrc_Item_Group_Handler1_GroupChanged(string[] s_name)
        {
            s_name_Group = s_name;
            Paint_Group(s_name_Group);
        }

        public void Paint_Current_Group()
        {
            Paint_Group(s_name_Group);
        }


        internal bool Show(DataRow dr)
        {
            string[] sGroupArr = new string[3];
            sGroupArr[0] = tf._set_string(dr["s1_name"]);
            sGroupArr[1] = tf._set_string(dr["s2_name"]);
            sGroupArr[2] = tf._set_string(dr["s3_name"]); 
            usrc_Item_Group_Handler1.Select(sGroupArr);
            int index = this.m_dtWorkAreaAll.Rows.IndexOf(dr);
            if (index >= 0)
            {
                usrc_Item_PageHandler1.Show(index);
                return true;
            }
            return false;
        }

        private void usrc_Item_Group_Handler1_GroupsRedefined(int Level)
        {
            if (Level == 0)
            {
                pnl_Items.Width = ipnl_Items_Width_default + usrc_Item_Group_Handler1.Width + 2;
                usrc_Item_Group_Handler1.SetVisible(false);
            }
            else
            {
                usrc_Item_Group_Handler1.SetVisible(true);
                pnl_Items.Width = ipnl_Items_Width_default;
            }

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
           if (Exit!=null)
            {
                Exit();
            }
        }
    }
}
