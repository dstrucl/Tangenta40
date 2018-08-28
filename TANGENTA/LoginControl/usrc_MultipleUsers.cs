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
using static TangentaDB.CashierActivity;

namespace LoginControl
{
    public partial class usrc_MultipleUsers : UserControl
    {
        

        private AWP m_awp = null;
        DataTable dtLoginUsersGroup = null;
        DataTable m_AWP_dtLoginView = null;
        int ipnl_Items_Width_default = -1;

        private ID m_CashierActivity_ID = null;

        public ID CashierActivity_ID
        {
            get
            {
                if (m_CashierActivity != null)
                {
                    return m_CashierActivity.ID;
                }
                return null;
            }
            internal set
            {
                m_CashierActivity.ID = value;
            }
        }

        public CashierActivity m_CashierActivity = null;

        public ID CashierActivityOpened_ID
        {
            get
            {
                if (m_CashierActivity != null)
                {
                    return m_CashierActivity.CashierActivityOpened_ID;
                }
                return null;
            }
            internal set
            {

                if (m_CashierActivity != null)
                {
                    m_CashierActivity.CashierActivityOpened_ID = value;
                }
            }
        }

       
        public eCashierState CashierState
        {
            get
            {
                if (m_CashierActivity != null)
                {
                    return m_CashierActivity.CashierState;
                }
                return eCashierState.CLOSED;
            }
            internal set
            {
                eCashierState estate = value;
                if (m_CashierActivity != null)
                {
                    m_CashierActivity.CashierState = estate;
                    if (estate == eCashierState.OPENED)
                    {
                        lbl_OpenedClosed.Text = lng.s_CashierOpened.s;
                        lbl_OpenedClosed.ForeColor = Color.Green;
                    }
                    else
                    {
                        lbl_OpenedClosed.Text = lng.s_CashierClosed.s;
                        lbl_OpenedClosed.ForeColor = Color.Red;
                    }
                }
            }
        }


     

        public int CashierActivityNumber
        {
            get
            {
                if (m_CashierActivity!=null)
                {
                    return m_CashierActivity.CashierActivityNumber;
                }
                return -1;
            }
            internal set
            {
                if (m_CashierActivity != null)
                {
                    m_CashierActivity.CashierActivityNumber = value;
                }
            }
        }


        public DataTable AWP_dtLoginView
        {
            get
            {
                return m_AWP_dtLoginView;
            }
            set
            {
                m_AWP_dtLoginView = value;
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
                Init(m_awp, this.chk_ShowAdministrators.Checked);
            }
        }

        public usrc_LMOUser[] usrc_Item_aray = null;

        public usrc_MultipleUsers()
        {
            InitializeComponent();
            ipnl_Items_Width_default = pnl_Items.Width;
            lng.s_chk_ShowAdministrators.Text(chk_ShowAdministrators);
            lng.s_Cashier.Text(lbl_Cashier);
        }

        internal void Init(AWP xawp,
                           bool bRecordCashierActivity,
                           bool bShowAdministratorUsers)
        {

            m_awp = xawp;
            m_awp.lctrl.RecordCashierActivity = bRecordCashierActivity;
            lbl_OpenedClosed.Text = lng.s_CashierOpened.s;
            lbl_OpenedClosed.ForeColor = Color.Green;
            this.chk_ShowAdministrators.Checked = bShowAdministratorUsers;
            lbl_Tangenta.ForeColor = ColorSettings.Sheme.Current().Colorpair[1].ForeColor;
            if (myOrg.m_myOrg_Office != null)
            {
                if (myOrg.m_myOrg_Office.Name_v != null)
                {
                    lbl_Tangenta.Text = myOrg.m_myOrg_Office.Name_v.v;
                }
            }

            usrc_Item_aray = new usrc_LMOUser[NumberOfItemsPerPage];
            ID xCashierActivityOpened_ID = null;
            ID xCashierActivity_ID = null;
            int lastCashierActivityNumber = -1;
            string atom_electronicdevicename = null;
            string atom_office_shortname = null;
            if (myOrg.m_myOrg_Office!=null)
            {
                if (myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice != null)
                {
                    atom_electronicdevicename = myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice.ElectronicDevice_Name;
                }
                if (myOrg.m_myOrg_Office.ShortName_v!=null)
                {
                    atom_office_shortname = myOrg.m_myOrg_Office.ShortName_v.v;
                }
            }
            lbl_OpenedClosed.Text = "";
            if ((atom_electronicdevicename != null) && (atom_office_shortname != null))
            {
                if (f_CashierActivity.GetOpened(atom_electronicdevicename,
                                               atom_office_shortname,
                                               ref xCashierActivityOpened_ID,
                                                ref xCashierActivity_ID,
                                                ref lastCashierActivityNumber
                                               ))
                {
                    if (ID.Validate(xCashierActivity_ID))
                    {
                        CashierActivityOpened_ID = xCashierActivityOpened_ID;
                        CashierActivity_ID = xCashierActivity_ID;
                        CashierActivityNumber = lastCashierActivityNumber;
                        CashierState = eCashierState.OPENED;
                    }
                    else
                    {
                        CashierActivity_ID = null;
                        CashierActivityNumber = -1;
                        CashierState = eCashierState.CLOSED;
                    }
                }
            }

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
                usrc_LMOUser usrc_item = new usrc_LMOUser(m_awp.lctrl);
                usrc_item.m_usrc_MultipleUsers = this;
                usrc_item.Top = yPos;
                usrc_item.Left = 5;
                usrc_item.Width = this.pnl_Items.Width - 10;
                usrc_item.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                yPos += usrc_item.Height + 1;
                //usrc_item.BackColor = Colors.ItemFromStock.BackColor;
                //usrc_item.ForeColor = Colors.ItemFromStock.ForeColor;
                usrc_Item_aray[i] = usrc_item;
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
            Get_LoginUsers_Data();
            if (m_awp.lctrl.IdleCtrl.m_usrc_MultipleUsers==null)
            {
                m_awp.lctrl.IdleCtrl.m_usrc_MultipleUsers = this;
            }

            if (m_awp.lctrl.IdleControlImageUrl1 != null)
            {
                btn_IdleCtrl_ShowURL1.Image = m_awp.lctrl.IdleControlImageUrl1;
                btn_IdleCtrl_ShowURL1.Text = "";
                btn_IdleCtrl_ShowURL1.ImageAlign = ContentAlignment.MiddleRight;
                btn_IdleCtrl_ShowURL1.TextAlign = ContentAlignment.MiddleLeft;
            }

            if (m_awp.lctrl.IdleControlImageUrl2 != null)
            {
                btn_IdleCtrl_ShowURL2.Image = m_awp.lctrl.IdleControlImageUrl2;
                btn_IdleCtrl_ShowURL2.Text = "";
                btn_IdleCtrl_ShowURL2.ImageAlign = ContentAlignment.MiddleRight;
                btn_IdleCtrl_ShowURL2.TextAlign = ContentAlignment.MiddleLeft;
            }

            m_awp.lctrl.IdleCtrl.TimerCounter_Start();

        }

        internal void CashierActivity_InfoShow(bool bshow)
        {
            lbl_Cashier.Visible = bshow;
            lbl_OpenedClosed.Visible = bshow;
        }

        internal void IdleControlTimerCountDown(int timeoutCounter)
        {
            if (btn_IdleCtrl_ShowURL1.Image == null)
            {
                this.btn_IdleCtrl_ShowURL1.Text = timeoutCounter.ToString() + "   URL1";
            }
            else
            {
                this.btn_IdleCtrl_ShowURL1.Text = timeoutCounter.ToString();
            }
        }

        public bool Get_LoginUsers_Data()
        {
            if (AWP_func.GetGroupsTable(ref dtLoginUsersGroup))
            {
                if (usrc_Item_Group_Handler1.Set_Groups(dtLoginUsersGroup))
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
                    if (dtLoginUsersGroup.Rows.Count > 0)
                    {
                        string s1_name = null;
                        string s2_name = null;
                        string s3_name = null;
                        if (dtLoginUsersGroup.Rows[0]["s1_name"] is string)
                        {
                            s1_name = (string)dtLoginUsersGroup.Rows[0]["s1_name"];
                        }
                        if (dtLoginUsersGroup.Rows[0]["s2_name"] is string)
                        {
                            s2_name = (string)dtLoginUsersGroup.Rows[0]["s2_name"];
                        }
                        if (dtLoginUsersGroup.Rows[0]["s3_name"] is string)
                        {
                            s3_name = (string)dtLoginUsersGroup.Rows[0]["s3_name"];
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

        internal void LogoutAll()
        {
            foreach (Control ctrl in this.pnl_Items.Controls)
            {
                if (ctrl is usrc_LMOUser)
                {
                    usrc_LMOUser xusrc_LMOUser = (usrc_LMOUser)ctrl;
                    if (xusrc_LMOUser.m_LMOUser != null)
                    {
                        if (xusrc_LMOUser.m_LMOUser.LoggedIn)
                        {
                            xusrc_LMOUser.DoLogout();
                        }
                    }
                }
            }
        }

        internal int LoggedIn_Count()
        {
            int iCount = 0;
            foreach (Control ctrl in this.pnl_Items.Controls)
            {
                if (ctrl is usrc_LMOUser)
                {
                    usrc_LMOUser xusrc_LMOUser = (usrc_LMOUser)ctrl;
                    if (xusrc_LMOUser.m_LMOUser != null)
                    {
                        if (xusrc_LMOUser.m_LMOUser.LoggedIn)
                        {
                            iCount++;
                        }
                    }
                }
            }
            return iCount;
        }

        private void m_usrc_Item_PageHandler_ShowObject(int Item_id_index, object o_data, object o_usrc, bool bVisible)
        {
            if (this.Visible)
            {
                LogFile.LogFile.WriteDEBUG("-> usrc_ItemList:m_usrc_Item_PageHandler_ShowObject(..) Visible=TRUE");
                usrc_LMOUser usrc_item = (usrc_LMOUser)o_usrc;
                if (bVisible)
                {
                    if (o_data is DataRow)
                    {
                        usrc_item.SetData((DataRow)o_data);
                        if (usrc_item.m_LMOUser!=null)
                        {
                            if (usrc_item.m_LMOUser.HasLoginControlRole(new string[] { AWP.ROLE_Administrator }))
                            {
                                if (!chk_ShowAdministrators.Checked)
                                {
                                    usrc_item.Visible = false;
                                    usrc_item.Enabled = false;
                                    return;
                                }
                            }
                        }
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
            this.chk_ShowAdministrators.CheckedChanged -= new System.EventHandler(this.chk_ShowAdministrators_CheckedChanged);
            if (LoginUsers_Load(s_name))
            {
                lbl_GroupPath.Text = this.usrc_Item_Group_Handler1.GroupPath;
                this.usrc_Item_PageHandler1.Init(m_AWP_dtLoginView, 5, usrc_Item_aray);
            }
            this.chk_ShowAdministrators.CheckedChanged += new System.EventHandler(this.chk_ShowAdministrators_CheckedChanged);
        }

        private bool LoginUsers_Load(string[] s_name)
        {
            return true;
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
            int index = this.m_AWP_dtLoginView.Rows.IndexOf(dr);
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
            foreach (Control ctrl in this.pnl_Items.Controls)
            {
                if (ctrl is usrc_LMOUser)
                {
                    usrc_LMOUser xusrc_LMOUser = (usrc_LMOUser)ctrl;
                    if (xusrc_LMOUser.m_LMOUser != null)
                    {
                        if (xusrc_LMOUser.m_LMOUser.LoggedIn)
                        {
                            XMessage.Box.Show(this,lng.s_YouCanNotExitProgramUntilAllUsersAreLoggedOut,MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
            m_awp.lctrl.DoEndProgram(LoginControl.LoginCtrl.eExitReason.LOGIN_CONTROL);
        }

        private void chk_ShowAdministrators_CheckedChanged(object sender, EventArgs e)
        {
            Paint_Current_Group();
        }

        internal void ReloadAdministratorsAndUserManagers()
        {
            foreach (Control ctrl in this.pnl_Items.Controls)
            {
                if (ctrl is usrc_LMOUser)
                {
                    usrc_LMOUser xusrc_LMOUser = (usrc_LMOUser)ctrl;
                    if (xusrc_LMOUser.m_LMOUser != null)
                    {
                        if (xusrc_LMOUser.m_LMOUser.LoggedIn)
                        {
                            if (xusrc_LMOUser.m_LMOUser.HasLoginControlRole(new string[] { AWP.ROLE_Administrator, AWP.ROLE_UserManagement }))
                            {
                                xusrc_LMOUser.m_LMOUser.ReloadRequest = true;
                            }
                        }
                    }
                }
            }
        }

        private void btn_IdleCtrl_ShowURL1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            if (m_awp.lctrl.IdleCtrl.m_usrc_MultipleUsers==null)
            {
                m_awp.lctrl.IdleCtrl.m_usrc_MultipleUsers = this;
            }
            m_awp.lctrl.IdleCtrl.Show(IdleControl.eShow.URL1);
        }

        private void btn_IdleCtrl_ShowURL2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            if (m_awp.lctrl.IdleCtrl.m_usrc_MultipleUsers == null)
            {
                m_awp.lctrl.IdleCtrl.m_usrc_MultipleUsers = this;
            }
            m_awp.lctrl.IdleCtrl.Show(IdleControl.eShow.URL2);

        }
    }
}
