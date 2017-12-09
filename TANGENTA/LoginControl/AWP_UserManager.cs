
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using NavigationButtons;

namespace LoginControl
{

    public partial class AWP_UserManager : Form
    {

     
     
      

        private const string Column_Select = "Select";
        private Form myParent;


        AWP awp = null;
        internal AWPBindingData awpbd = null;
        internal AWPLoginData awpld = null;

        internal DataTable dtLoginUsers = null;

        private bool bFirstTimeStartup = false;

        public AWP_UserManager(Navigation xnav,Form pParent, AWP xawp)
        {
            awp = xawp;
            InitializeComponent();

            awpbd = awp.awpd;
           

            if (xnav.m_eButtons == Navigation.eButtons.PrevNextExit)
            {
                bFirstTimeStartup = true;
            }

            usrc_NavigationButtons1.Init(xnav);

            myParent = pParent;


            lng.s_Max_Password_Age.Text(lbl_Max_Password_Age);
            lng.s_chk_ChangePasswordOnFirstLogIn.Text(chk_ChangePasswordOnFirstLogIn);
            lng.s_chk_PasswordNeverExpires.Text(rdb_PaswordExpires_Never);
            lng.s_rdb_DeactivateAfterNumberOfDays.Text(rdb_DeactivateAfterNumberOfDays);
            lng.s_rdb_AfterNumberOfDays.Text(rdb_AfterNumberOfDays);


             lng.s_btnAddUser_UserManager.Text(this.btnAddUser);

            lng.s_btnChangeData_UserManager.Text(this.btnChangeData);
            
            lng.s_PasswordExpires.Text(this.grp_PasswordExpires);
            lng.s_ManageUSers.Text(this);
            lng.s_lbl_UserRoles.Text(lbl_UserRoles);
            lng.s_lbl_OtherRoles.Text(lbl_OtherRoles);
            lng.s_btn_Edit_myOrganisation_Person.Text(btn_Edit_myOrganisation_Person);
            lng.s_LoginHistory.Text(btn_LoginHistory);

            
            
            this.txtUserName.Tag = null;

            this.Icon = Properties.Resources.user;


            this.chk_ChangePasswordOnFirstLogIn.Checked = true;
            this.rdb_PaswordExpires_Never.Checked = true;
            this.nmUpDn_MaxPasswordAge.Value = 90.0M;
            txtUserName.Text = "";
            //txtPassword.Text = "";
            //txtConfirmPassword.Text = "";
            awpbd.BindingControls(this);
            this.txtUserName.Focus();
        }

        private void AWP_UserManager_Load(object sender, EventArgs e)
        {
            if (bFirstTimeStartup)
            {
                awpld = awp.m_AWPLoginData;
            }
            else
            {
                // use new created awpld 
                awpld = new AWPLoginData();
            }
            LoadData(null);
        }

        private void LoadData(string sUserName)
        {
            RemoveHandlers();
            InitRoles();
            DataTable dtOfUserName = null;
            AWPLoginData.eGetDateResult eres = AWPLoginData.eGetDateResult.ERROR;
            if (sUserName == null)
            {
                if (dtLoginUsers == null)
                {
                    dtLoginUsers = new DataTable();
                }
                else
                {
                    dtLoginUsers.Clear();
                    dtLoginUsers.Columns.Clear();
                }
                dgv_LoginUsers.DataSource = null;
                eres = awpld.GetData(ref dtLoginUsers, sUserName, awpbd);
            }
            else
            {
                dtOfUserName = new DataTable();
                eres = awpld.GetData(ref dtOfUserName, sUserName, awpbd);
            }
            
            switch (eres)
            {

                case AWPLoginData.eGetDateResult.OK:
                case AWPLoginData.eGetDateResult.USER_HAS_NO_RULES:

                    DataTable dt = null;

                    if (dtOfUserName == null)
                    {
                        dt = dtLoginUsers;
                        //dgv_LoginUsers.Columns.Clear();
                        dgv_LoginUsers.DataSource = dtLoginUsers;
                        awpbd.SetControls(dgv_LoginUsers, dt.Rows[0], dtLoginUsers.TableName);
                    }
                    else
                    {
                        dt = dtOfUserName;
                        awpbd.SetControls(null,dt.Rows[0], null);

                    }

                  
                    this.webBrowser1.DocumentText = awpld.GetHtml();
                    if (bFirstTimeStartup)
                    {
                        awpld.ChangePasswordOnFirstLogin = false;
                        awpld.PasswordNeverExpires = true;
                    }
                    chk_ChangePasswordOnFirstLogIn.Checked = awpld.ChangePasswordOnFirstLogin;
                    if (awpld.PasswordNeverExpires)
                    {
                        rdb_PaswordExpires_Never.Checked = true;
                        nmUpDn_MaxPasswordAge.Enabled = false;
                    }
                    if (awpld.NotActiveAfterPasswordExpires)
                    {
                        rdb_DeactivateAfterNumberOfDays.Checked = true;
                        nmUpDn_MaxPasswordAge.Enabled = true;
                    }
                    if (!awpld.PasswordNeverExpires && !awpld.NotActiveAfterPasswordExpires)
                    {
                        rdb_AfterNumberOfDays.Checked = true;
                        nmUpDn_MaxPasswordAge.Enabled = true;
                    }

                    chk_Enabled.Checked = awpld.Enabled;

                    nmUpDn_MaxPasswordAge.Value = awpld.Maximum_password_age_in_days;
                    usrc_PasswordBytes1.SetPassword(awpld.Password, 5);
                   

                    SetRoles();
                    break;

                case AWPLoginData.eGetDateResult.USER_NOT_FOUND:
                    sUserName = null;
                    break;

                case AWPLoginData.eGetDateResult.ERROR:
                    DialogResult = DialogResult.Cancel;
                    this.Close();
                    break;
            }
            awpld.Changed = false;
            AddHandlers();
        }

      

        private void InitRoles()
        {
            dgvx_UserRoles.DataSource = null;
            dgvx_OtherRoles.DataSource = null;
            dgvx_UserRoles.Columns.Clear();
            dgvx_OtherRoles.Columns.Clear();
        }

        private void SetRoles()
        {
            dgvx_OtherRoles.DataSource = awpld.dt_AWP_MissingUserRoles;
            dgvx_UserRoles.DataSource = awpld.dt_AWP_UserRoles;
            DataGridViewButtonColumn dgvcb_MoveLeft = new DataGridViewButtonColumn();
            dgvcb_MoveLeft.Name = "MoveLeft";
            dgvcb_MoveLeft.Width = 60;
            dgvcb_MoveLeft.Text = "<=";
            dgvcb_MoveLeft.HeaderText = "<=";
            dgvcb_MoveLeft.UseColumnTextForButtonValue = true;
            dgvcb_MoveLeft.ValueType = typeof(string);
            dgvcb_MoveLeft.MinimumWidth = 40;
            dgvx_OtherRoles.Columns.Insert(0, dgvcb_MoveLeft);


            DataGridViewButtonColumn dgvcb_MoveRight = new DataGridViewButtonColumn();
            dgvcb_MoveRight.Name = "MoveRight";
            dgvcb_MoveRight.Width = 60;
            dgvcb_MoveRight.Text = "=>";
            dgvcb_MoveRight.HeaderText = "=>";
            dgvcb_MoveRight.ValueType = typeof(string);
            dgvcb_MoveRight.UseColumnTextForButtonValue = true;
            dgvcb_MoveRight.MinimumWidth = 40;

            dgvx_UserRoles.Columns.Add(dgvcb_MoveRight);
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            awpld.Changed = true;
            if (txtUserName.Text.Length > 0)
            {
                usrc_PasswordBytes1.Enabled = true;
                

                this.btnAddUser.Enabled = true;
                this.btnAddUser.Text = lng.s_AddUser.s;
            }
            else
            {
                usrc_PasswordBytes1.Enabled = false;
                
            }
        }

    

 
        private void AddUser()
        {
            AWPFormSelectMyOrgPerNotInLoginUsers awpFormSelectMyOrgPerNotInLoginUsers = new AWPFormSelectMyOrgPerNotInLoginUsers();
            DialogResult dlgres = awpFormSelectMyOrgPerNotInLoginUsers.ShowDialog(this);
            switch (dlgres)
            {
                case DialogResult.No:
                    MessageBox.Show(lng.s_AllEmpleyeesHaveUserAccount.s + lng.s_btn_Edit_myOrganisation_Person.s);
                    break;
                case DialogResult.OK:
                    LoadData(null);
                    break;
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUser();
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string s = dgv_LoginUsers.Columns[e.ColumnIndex].Name;
            if ((s.Equals(LoginDB_DataSet.LoginUsers.password.name)) && e.Value != null)
            {
                dgv_LoginUsers.Rows[e.RowIndex].Tag = e.Value;
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }

        private void dataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgv_LoginUsers.CurrentRow.Tag != null)
                e.Control.Text = dgv_LoginUsers.CurrentRow.Tag.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {

                if (dgv_LoginUsers.SelectedRows.Count > 0)
                {
                    DataGridViewRow dgvr = dgv_LoginUsers.SelectedRows[0];
                    int iRowIndex = dgvr.Cells[0].RowIndex;
                    if ((iRowIndex >= 0) && (iRowIndex < dtLoginUsers.Rows.Count))
                    {
                        object oUserName = dtLoginUsers.Rows[iRowIndex]["UserName"];
                        if (oUserName is string)
                        {
                            LoadData((string)oUserName);
                        }
                     }
                }
            }
            catch
            {
            }
        }


 
        private bool UpdateAWPLoginData()
        {
            bool bRes = false;
            awpld.UserName = txtUserName.Text;
            if (usrc_PasswordBytes1.GetPassword(ref awpld.Password))
            {
                awpld.Enabled = chk_Enabled.Checked;
                awpld.ChangePasswordOnFirstLogin = chk_ChangePasswordOnFirstLogIn.Checked;
                awpld.PasswordNeverExpires = rdb_PaswordExpires_Never.Checked;
                awpld.NotActiveAfterPasswordExpires = rdb_DeactivateAfterNumberOfDays.Checked;
                awpld.Maximum_password_age_in_days = Convert.ToInt32(nmUpDn_MaxPasswordAge.Value);
                bRes = AWP_func.Update_LoginUsers_ID(awpld, usrc_PasswordBytes1.Changed);
                if (bRes)
                {
                    awpld.Changed = false;
                }   
            }
            return bRes;

        }

        private bool DoChangeData()
        {
            return SaveIfChanged();
        }

        private bool SaveIfChanged()
        {
            if (awpld.Changed)
            {
                if (CheckIfUserDefined())
                {
                    long LoginUsers_ID = -1;
                    if (awpld.UserName.Equals(txtUserName.Text))
                    {
                        return UpdateAWPLoginData();
                    }
                    else
                    {
                        if (AWP_func.UserNameExist(txtUserName.Text, ref LoginUsers_ID))
                        {
                            MessageBox.Show(lng.s_UserName_AllreadyExist.s);//you can not overwrite existig yuser
                            return false;


                        }
                        else
                        {
                            return UpdateAWPLoginData();
                        }
                    }
                }
                else
                {
                    MessageBox.Show(this, lng.s_UserName_Is_Not_Defined.s);
                    return false;
                }
            }
            else
            {
                //nothing changed
                return true;
            }
        }
            
            
        private bool DoOK()
        {
            return SaveIfChanged();
        }
      



        private void btnChangeData_Click(object sender, EventArgs e)
        {
            DoChangeData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void UserManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            //TranslateRoleNamesFromLanguage(m_DataTable);
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (txtUserName.Text.Length > 0)
                {
                    //txtUserName.SelectNextControl(txtPassword, true, false, false, false);
                    // txtPassword.Focus();
                }
                else
                {
                    MessageBox.Show(lng.s_UserNameIsNotWritten.s, lng.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                e.Handled = true;
            }
        }

 

        private void btnChangeData_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (DoChangeData())
                {
                   // this.btnOK.Focus();
                }
                e.Handled = true;
            }
        }

        private void btnAddUser_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddUser();
                e.Handled = true;
            }

        }

  
        private void dgv_LoginUsers_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

     
       private void AddHandlers()
        {

            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            this.chk_Enabled.CheckedChanged += new System.EventHandler(this.chk_Enabled_CheckedChanged);
            this.rdb_DeactivateAfterNumberOfDays.CheckedChanged += new System.EventHandler(this.rdb_DeactivateAfterNumberOfDays_CheckedChanged);
            this.rdb_AfterNumberOfDays.CheckedChanged += new System.EventHandler(this.rdb_AfterNumberOfDays_CheckedChanged);
            this.rdb_PaswordExpires_Never.CheckedChanged += new System.EventHandler(this.rdb_PaswordExpires_Never_CheckedChanged);
            this.txtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserName_KeyPress);
            this.chk_ChangePasswordOnFirstLogIn.CheckedChanged += new System.EventHandler(this.chk_ChangePasswordOnFirstLogIn_CheckedChanged);
            this.dgv_LoginUsers.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            this.dgvx_OtherRoles.CellClick += Dgvx_OtherRoles_CellClick;
            this.dgvx_UserRoles.CellClick += Dgvx_UserRoles_CellClick;
            usrc_PasswordBytes1.AddHandlers();
        }

        private void Dgvx_UserRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                if (e.ColumnIndex==1)
                {
                    //button MoveRight clicked
                    //Remove Role
                    awpld.RemoveRole(e.RowIndex);
                    InitRoles();
                    awpld.GetUserRoles();
                    SetRoles();

                }
            }
        }

        private void Dgvx_OtherRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 0)
                {
                    //button MoveRight clicked
                    awpld.AddRole(e.RowIndex);
                    InitRoles();
                    awpld.GetUserRoles();
                    SetRoles();
                }
            };
        }

        private void RemoveHandlers()
        {
            this.txtUserName.TextChanged -= new System.EventHandler(this.txtUserName_TextChanged);
            this.chk_Enabled.CheckedChanged -= new System.EventHandler(this.chk_Enabled_CheckedChanged);
            this.rdb_DeactivateAfterNumberOfDays.CheckedChanged -= new System.EventHandler(this.rdb_DeactivateAfterNumberOfDays_CheckedChanged);
            this.rdb_AfterNumberOfDays.CheckedChanged -= new System.EventHandler(this.rdb_AfterNumberOfDays_CheckedChanged);
            this.rdb_PaswordExpires_Never.CheckedChanged -= new System.EventHandler(this.rdb_PaswordExpires_Never_CheckedChanged);
            this.txtUserName.KeyPress -= new System.Windows.Forms.KeyPressEventHandler(this.txtUserName_KeyPress);
            this.chk_ChangePasswordOnFirstLogIn.CheckedChanged -= new System.EventHandler(this.chk_ChangePasswordOnFirstLogIn_CheckedChanged);
            this.dgv_LoginUsers.SelectionChanged -= new System.EventHandler(this.dataGridView_SelectionChanged);
            this.dgvx_OtherRoles.CellClick -= Dgvx_OtherRoles_CellClick;
            this.dgvx_UserRoles.CellClick -= Dgvx_UserRoles_CellClick;
            usrc_PasswordBytes1.RemoveHandlers();
        }

        private void rdb_PaswordExpires_Never_CheckedChanged(object sender, EventArgs e)
        {
            awpld.Changed = true;
            if (rdb_PaswordExpires_Never.Checked)
            {
                this.nmUpDn_MaxPasswordAge.Enabled = false;
            }
            else
            {
                this.nmUpDn_MaxPasswordAge.Enabled = true;
            }
        }

   

       
      

        private void btn_Edit_myOrganisation_Person_Click(object sender, EventArgs e)
        {
            bool bChanged = false;
            long new_myOrganisation_Person_ID = -1;
            awp.call_Edit_myOrganisationPerson(this, awpld.myOrganisation_Person_ID, ref bChanged, ref new_myOrganisation_Person_ID);
        }

    

        private bool CheckIfUserDefined()
        {
            return (txtUserName.Text.Length > 0);
        }

        private bool DoCancel()
        {
            return true;
        }

        private void usrc_NavigationButtons1_ButtonPressed(NavigationButtons.Navigation.eEvent evt)
        {
            switch (evt)
            {
                case Navigation.eEvent.OK:
                case Navigation.eEvent.NEXT:
                    if (DoOK())
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    break;

                case Navigation.eEvent.PREV:
                    if (DoCancel())
                    {
                        DialogResult = DialogResult.Cancel;
                        Close();
                    }
                    break;

                case Navigation.eEvent.CANCEL:
                case Navigation.eEvent.EXIT:
                    if (DoCancel())
                    {
                        DialogResult = DialogResult.Cancel;
                        Close();
                    }
                    break;

            }
        }

        private void chk_Enabled_CheckedChanged(object sender, EventArgs e)
        {
            awpld.Changed = true;
        }

        private void chk_ChangePasswordOnFirstLogIn_CheckedChanged(object sender, EventArgs e)
        {
            awpld.Changed = true;
        }

        private void rdb_AfterNumberOfDays_CheckedChanged(object sender, EventArgs e)
        {
            awpld.Changed = true;
        }

        private void rdb_DeactivateAfterNumberOfDays_CheckedChanged(object sender, EventArgs e)
        {
            awpld.Changed = true;
        }

 

        private void usrc_PasswordBytes1_PasswordChanged()
        {
            awpld.Changed = true;
        }

        private void btn_LoginHistory_Click(object sender, EventArgs e)
        {
            AWPLoginHistoryForm awplhfrm = new AWPLoginHistoryForm(awp, awpld.UserName);
            awplhfrm.ShowDialog(this);
        }
    }
}
