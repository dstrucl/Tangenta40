
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

     
        private const string TEXT_PASSWORD_WILDCARDS = "***********";
        private const string TAG_PASSWORD_UNDEFINED = "TAG_PASSWORD_UNDEFINED";
        private const string TAG_PASSWORD_DEFINED = "TAG_PASSWORD_DEFINED";
        private const string TAG_PASSWORD_CHANGED = "TAG_PASSWORD_CHANGED";

        private const string Column_Select = "Select";
        private Form myParent;


        AWP awp = null;
        internal AWPBindingData awpbd = null;
        internal AWPLoginData awpld = null;

        internal DataTable dtLoginUsers = null;

        private bool bUserNameChanged = false;
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


            lng.s_lblConfirmPassword_UserManager.Text(this.lbl_ConfirmPasword);
            lng.s_btnAddUser_UserManager.Text(this.btnAddUser);
            //lng.s_btn_DeleteUser.Text(this.btnDeleteUser);
            lng.s_btnChangeData_UserManager.Text(this.btnChangeData);
            
            lng.s_PasswordExpires.Text(this.grp_PasswordExpires);
            lng.s_ManageUSers.Text(this);
            lng.s_lbl_UserRoles.Text(lbl_UserRoles);
            lng.s_lbl_OtherRoles.Text(lbl_OtherRoles);
            lng.s_btn_Edit_myOrganisation_Person.Text(btn_Edit_myOrganisation_Person);

            

            this.txtUserName.Tag = null;

            //btnDeleteUser.Enabled = false;
            //this.lbl_ConfirmPasword.Enabled = false;
            //this.lblPassword.Enabled = false;
            //this.txtPassword.Enabled = false;
            //this.txtConfirmPassword.Enabled = false;
            //this.btnAddUser.Enabled = false;
            //this.btnChangeData.Enabled = false;
            this.Icon = Properties.Resources.user;


            this.chk_ChangePasswordOnFirstLogIn.Checked = true;
            this.rdb_PaswordExpires_Never.Checked = true;
            this.nmUpDn_MaxPasswordAge.Value = 90.0M;
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
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
                    if (!awpld.PasswordNeverExpires && awpld.NotActiveAfterPasswordExpires)
                    {
                        rdb_AfterNumberOfDays.Checked = true;
                        nmUpDn_MaxPasswordAge.Enabled = true;
                    }
                   

                    nmUpDn_MaxPasswordAge.Value = awpld.Maximum_password_age_in_days;
                    if (awpld.Password is byte[])
                    {
                        txtPassword.Tag = TAG_PASSWORD_DEFINED;
                        txtPassword.Text = TEXT_PASSWORD_WILDCARDS;
                        txtConfirmPassword.Text = TEXT_PASSWORD_WILDCARDS;
                    }
                    else
                    {

                        txtPassword.Tag = TAG_PASSWORD_UNDEFINED;
                        txtPassword.Text = "";
                        txtConfirmPassword.Text = "";
                    }

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
                this.lblPassword.Enabled = true;
                this.txtPassword.Enabled = true;
                this.txtPassword.Text = "";
                this.txtConfirmPassword.Text = "";
                this.btnAddUser.Enabled = true;
                this.btnAddUser.Text = lng.s_AddUser.s;
            }
            else
            {
                this.txtPassword.Enabled = false;
                this.lblPassword.Enabled = false;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            awpld.Changed = true;
            txtPassword.Tag = TAG_PASSWORD_CHANGED;
            if (txtPassword.Text.Length > 0)
            {
                this.lbl_ConfirmPasword.Enabled = true;
                this.txtConfirmPassword.Enabled = true;
            }
            else
            {
                this.txtConfirmPassword.Text = "";
                this.txtConfirmPassword.Enabled = false;
                this.lbl_ConfirmPasword.Enabled = false;
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
                    //    btnDeleteUser.Enabled = true;
                    //    btnAddUser.Text = lng.s_NewUser.s;
                    //    this.txtUserName.Enabled = true;
                    //    this.txtUserName.Tag = iRowIndex;
                    //    btnChangeData.Enabled = true;
                    //    this.txtUserName.ReadOnly = true;
                    //    this.txtPassword.Enabled = true;
                    //    this.txtConfirmPassword.Enabled = true;
                    //    this.txtUserName.TextChanged -= new System.EventHandler(this.txtUserName_TextChanged);
                    //    this.txtUserName.Text = dtLoginUsers.Rows[iRowIndex]["UserName"].ToString();
                    //    this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
                    //    if (dtLoginUsers.Rows[iRowIndex][LoginDB_DataSet.LoginUsers.password.name].GetType() != typeof(DBNull))
                    //    {
                    //        this.txtPassword.Text = TEXT_PASSWORD_WILDCARDS;
                    //        this.txtPassword.Tag = TAG_PASSWORD_DEFINED;
                    //    }
                    //    else
                    //    {
                    //        this.txtPassword.Text = "";
                    //        this.txtPassword.Tag = TAG_PASSWORD_UNDEFINED;
                    //    }

                    //    if (txtUserName.Text.Equals("Administrator"))
                    //    {
                    //        this.rdb_PaswordExpires_Never.Checked = (bool)dtLoginUsers.Rows[iRowIndex][LoginDB_DataSet.LoginUsers.PasswordNeverExpires.name];
                    //        this.rdb_PaswordExpires_Never.Checked = true;
                    //        this.rdb_DeactivateAfterNumberOfDays.Checked = false;
                    //        this.rdb_DeactivateAfterNumberOfDays.Enabled = false;
                    //        this.rdb_AfterNumberOfDays.Enabled = false;
                    //        this.rdb_AfterNumberOfDays.Checked = false;
                    //        this.nmUpDn_MaxPasswordAge.Enabled = false;
                    //        this.chk_ChangePasswordOnFirstLogIn.Checked = false;
                    //    }
                    //    else
                    //    {
                    //        this.rdb_PaswordExpires_Never.Checked = (bool)dtLoginUsers.Rows[iRowIndex][LoginDB_DataSet.LoginUsers.PasswordNeverExpires.name];
                    //        this.chk_ChangePasswordOnFirstLogIn.Checked = (bool)dtLoginUsers.Rows[iRowIndex][LoginDB_DataSet.LoginUsers.ChangePasswordOnFirstLogin.name];
                    //        this.nmUpDn_MaxPasswordAge.Value = Convert.ToDecimal(dtLoginUsers.Rows[iRowIndex][LoginDB_DataSet.LoginUsers.Maximum_password_age_in_days.name]);
                    //        this.rdb_DeactivateAfterNumberOfDays.Checked = (bool)dtLoginUsers.Rows[iRowIndex][LoginDB_DataSet.LoginUsers.NotActiveAfterPasswordExpires.name];
                    //        if ((!rdb_DeactivateAfterNumberOfDays.Checked) && (!rdb_PaswordExpires_Never.Checked))
                    //        {
                    //            this.rdb_AfterNumberOfDays.Checked = true;
                    //        }
                    //        else
                    //        {
                    //            this.rdb_AfterNumberOfDays.Checked = false;
                    //        }
                    //    }
                    //    this.txtConfirmPassword.Text = this.txtPassword.Text;
                    //    this.lbl_UserName.Enabled = true;
                    //    this.lblPassword.Enabled = true;
                    //    this.lbl_ConfirmPasword.Enabled = true;
                    //    if (!bLoginUsers_Read)
                    //    {
                    //        if (!LoginRolesReload(iRowIndex, ref Err))
                    //        {
                    //            LogFile.Error.Show(Err);
                    //        }
                    //    }
                    }
                }
            }
            catch
            {
            }
        }

        private bool LoginRolesReload(int iRowIndex, ref string Err)
        {
            if (LoginRoles_Read((int)dtLoginUsers.Rows[iRowIndex][LoginDB_DataSet.LoginUsers.id.name], ref Err))
            {
                //foreach (DataGridViewRow dgvroles in dgv_Roles.Rows)
                //{
                //    int LoginRole_id = (int)dgvroles.Cells[LoginDB_DataSet.LoginRoles.id.name].Value;
                //    if (LoginRole_id_IN_LoginUsersAndLoginRoles(LoginRole_id))
                //    {
                //        dgvroles.Cells[Column_Select].Value = true;
                //    }
                //    else
                //    {
                //        dgvroles.Cells[Column_Select].Value = false;
                //    }
                //}
                return true;
            }
            else
            {
                return false;
            }


        }

        private bool LoginRole_id_IN_LoginUsersAndLoginRoles(int LoginRole_id)
        {
            //foreach (DataRow dr in LoginUsersAndLoginRoles.dt.Rows)
            //{
            //    if ((int)dr[LoginDB_DataSet.LoginUsersAndLoginRoles.LoginRoles_id.name] == LoginRole_id)
            //    {
            //        return true;
            //    }
            //}
            return false;
        }

        private bool LoginRoles_Read(int LoginUsers_id, ref string Err)
        {
            //if (LoginRoles == null)
            //{
            //    LoginRoles = new LoginDB_DataSet.LoginRoles(login_control.Login_con);
            //}
            //LoginRoles.Clear();
            //LoginRoles.select.all(true);
            //if (LoginRoles.Read(ref Err))
            //{
            //    if (dgv_Roles.DataSource == null)
            //    {
            //        dgv_Roles.DataSource = LoginRoles.m_bs_dt;
            //        dgv_Roles.Columns[LoginDB_DataSet.LoginRoles.id.name].Visible = false;
            //        dgv_Roles.Columns[LoginDB_DataSet.LoginRoles.Name.name].ReadOnly = true;
            //        dgv_Roles.Columns[LoginDB_DataSet.LoginRoles.Name.name].DefaultCellStyle.BackColor = Color.LightGray;
            //        dgv_Roles.Columns[LoginDB_DataSet.LoginRoles.PrivilegesLevel.name].ReadOnly = true;
            //        dgv_Roles.Columns[LoginDB_DataSet.LoginRoles.PrivilegesLevel.name].DefaultCellStyle.BackColor = Color.LightGray;
            //        dgv_Roles.Columns[LoginDB_DataSet.LoginRoles.description.name].ReadOnly = true;
            //        dgv_Roles.Columns[LoginDB_DataSet.LoginRoles.description.name].DefaultCellStyle.BackColor = Color.LightGray;
            //        DataGridViewColumn dgvcol = new DataGridViewCheckBoxColumn();
            //        dgvcol.ReadOnly = false;
            //        dgvcol.Name = Column_Select;
            //        dgvcol.HeaderText = "";
            //        dgv_Roles.Columns.Insert(0, dgvcol);
            //        LoginDB_DataSet.HeaderText.Set(dgv_Roles, LoginRoles_lang.col_headers);
            //    }
            //    if (LoginUsersAndLoginRoles == null)
            //    {
            //        LoginUsersAndLoginRoles = new LoginDB_DataSet.LoginUsersAndLoginRoles(login_control.Login_con);
            //    }
            //    LoginUsersAndLoginRoles.Clear();
            //    LoginUsersAndLoginRoles.select.all(false);
            //    LoginUsersAndLoginRoles.select.LoginRoles_id = true;
            //    LoginUsersAndLoginRoles.where.all(false);
            //    LoginUsersAndLoginRoles.where.LoginUsers_id = true;
            //    LoginUsersAndLoginRoles.where.LoginUsers_id_Expression(" = " + LoginUsers_id.ToString());
            //    if (LoginUsersAndLoginRoles.Read(ref Err))
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //else
            //{
            //    return false;
            //}
            return false;
        }


        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (txtUserName.Tag != null)
            {
                bool bDelete = true;

                int iRowIndex = (int)txtUserName.Tag;

                //if (m_Login.DelegateFunc_RemoveUser != null)
                //{
                //    string csError = null;
                //    if (!m_Login.DelegateFunc_RemoveUser(txtUserName.Text, ref bDelete, ref csError))
                //    {

                //    }
                //}
                if (bDelete)
                {
                    dtLoginUsers.Rows.RemoveAt(iRowIndex);
                }
                else
                {
                    //m_DataTable.Rows[iRowIndex][Login.COL_amb_user_Active] = false;
                }
                if (iRowIndex >= dtLoginUsers.Rows.Count)
                {
                    iRowIndex = dtLoginUsers.Rows.Count - 1;
                }
                if (dtLoginUsers.Rows.Count > 0)
                {
                    dgv_LoginUsers.CurrentCell = dgv_LoginUsers[0, iRowIndex];
                    txtUserName.Tag = iRowIndex;
                    //btnDeleteUser.Enabled = true;
                    btnAddUser.Text = lng.s_NewUser.s;
                    this.txtUserName.Enabled = true;
                    this.txtUserName.Tag = iRowIndex;
                    btnChangeData.Enabled = true;
                    this.txtUserName.ReadOnly = true;
                    this.txtPassword.Enabled = true;
                    this.txtConfirmPassword.Enabled = true;
                    this.txtUserName.Text = dtLoginUsers.Rows[iRowIndex][LoginDB_DataSet.LoginUsers.username.name].ToString();
                    this.txtPassword.Text = dtLoginUsers.Rows[iRowIndex][LoginDB_DataSet.LoginUsers.password.name].ToString();
                    this.txtConfirmPassword.Text = this.txtPassword.Text;
                    this.lbl_UserName.Enabled = true;
                    this.lblPassword.Enabled = true;
                    this.lbl_ConfirmPasword.Enabled = true;
                }
                else
                {
                    //btnDeleteUser.Enabled = false;
                    btnChangeData.Enabled = false;
                    txtUserName.Tag = null;
                    txtUserName.Enabled = true;
                    txtUserName.ReadOnly = false;
                    txtUserName.Text = "";
                    this.txtPassword.Text = "";
                    this.txtConfirmPassword.Text = "";
                    this.btnAddUser.Text = lng.s_AddUser.s;
                    txtUserName.Focus();
                }
            }
        }

        private bool PasswordConfirmed()
        {
            if (txtPassword.Text.Length >= awp.lctrl.MinPasswordLength)
            {
                if (txtPassword.Text.Equals(txtConfirmPassword.Text))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(lng.s_Password_does_not_match.s);
                }
            }
            else
            {
                MessageBox.Show(lng.s_YouMustDefinePasswordThatHasAtLeastXCharactersOrNumbers.s + " " + awp.lctrl.MinPasswordLength.ToString());
            }
            return false;
        }

        private bool UpdateAWPLoginData()
        {
            awpld.UserName = txtUserName.Text;
            byte[] Password = LoginControl.CalculateSHA256(txtPassword.Text);
            awpld.Password = Password;
            awpld.Enabled = chk_Enabled.Checked;
            awpld.ChangePasswordOnFirstLogin = chk_ChangePasswordOnFirstLogIn.Checked;
            awpld.PasswordNeverExpires = rdb_PaswordExpires_Never.Checked;
            awpld.NotActiveAfterPasswordExpires = rdb_DeactivateAfterNumberOfDays.Checked;
            awpld.Maximum_password_age_in_days = Convert.ToInt32(nmUpDn_MaxPasswordAge.Value);
            bool bRes = AWP_func.Update_LoginUsers_ID(awpld, true);
            if (bRes)
            {
                awpld.Changed = false;
            }
            return bRes;
        }

        private bool DoChangeData()
        {
            if (txtUserName.Text.Length > 0)
            {
                if (bUserNameChanged)
                {
                    if (AWP_func.UserNameExist(txtUserName.Text))
                    {
                        MessageBox.Show(lng.s_UserName_AllreadyExist.s);
                        return false;
                    }
                }
                if (PasswordConfirmed())
                {
                  return UpdateAWPLoginData();
                }
            }
            else
            {
                MessageBox.Show(lng.s_UserName_Is_Not_Defined.s);
            }
            return false;
        }

        private bool DoOK()
        {
            if (awpld.Changed)
            {
                if (CheckIfUserDefined())
                {
                    long LoginUsers_ID = -1;
                    if (AWP_func.UserNameExist(txtUserName.Text, ref LoginUsers_ID))
                    {
                        if (txtPassword.Tag is string)
                        {
                            if (((string)txtPassword.Tag).Equals(TAG_PASSWORD_DEFINED))
                            {
                                return UpdateAWPLoginData(); 
                            }
                            else
                            {
                                //Password is not defined check if txtPassword.Text and txtConfirmPassword matches
                                if (PasswordConfirmed())
                                {
                                    return UpdateAWPLoginData();
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }

                    }
                    else
                    {
                        //User Name does not exist 
                        //Password is not defined check if txtPassword.Text and txtConfirmPassword matches
                        if (PasswordConfirmed())
                        {
                            return UpdateAWPLoginData();
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return false;
                }
                else
                {
                    MessageBox.Show(this, lng.s_PasswordIsNotDefined_YouMustDefinePasswordThatHasAtLeastXCharactersOrNumbers1.s + awp.lctrl.MinPasswordLength.ToString()
                                    + lng.s_PasswordIsNotDefined_YouMustDefinePasswordThatHasAtLeastXCharactersOrNumbers2.s);
                    return false;
                }
            }
            else
            {
                if (awpld.Password != null)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(this, lng.s_PasswordIsNotDefined_YouMustDefinePasswordThatHasAtLeastXCharactersOrNumbers1.s + awp.lctrl.MinPasswordLength.ToString()
                                   + lng.s_PasswordIsNotDefined_YouMustDefinePasswordThatHasAtLeastXCharactersOrNumbers2.s);
                    return false;
                }
            }

        }
        private void MakeListOfAWPRoles(ref List<AWPRole> roles)
        {
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
                    txtPassword.Focus();
                }
                else
                {
                    MessageBox.Show(lng.s_UserNameIsNotWritten.s, lng.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                e.Handled = true;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtConfirmPassword.Focus();
                e.Handled = true;
            }
        }

        private void txtConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (txtPassword.Text.Equals(txtConfirmPassword.Text))
                {
                    e.Handled = true;
                }
                else
                {
                    MessageBox.Show(lng.s_Password_does_not_match.s, lng.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Handled = true;
                }
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
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            this.chk_Enabled.CheckedChanged += new System.EventHandler(this.chk_Enabled_CheckedChanged);
            this.rdb_DeactivateAfterNumberOfDays.CheckedChanged += new System.EventHandler(this.rdb_DeactivateAfterNumberOfDays_CheckedChanged);
            this.rdb_AfterNumberOfDays.CheckedChanged += new System.EventHandler(this.rdb_AfterNumberOfDays_CheckedChanged);
            this.rdb_PaswordExpires_Never.CheckedChanged += new System.EventHandler(this.rdb_PaswordExpires_Never_CheckedChanged);
            this.txtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserName_KeyPress);
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            this.txtConfirmPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConfirmPassword_KeyPress);
            this.chk_ChangePasswordOnFirstLogIn.CheckedChanged += new System.EventHandler(this.chk_ChangePasswordOnFirstLogIn_CheckedChanged);
            this.dgv_LoginUsers.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            this.dgvx_OtherRoles.CellClick += Dgvx_OtherRoles_CellClick;
            this.dgvx_UserRoles.CellClick += Dgvx_UserRoles_CellClick;
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
            this.txtPassword.TextChanged -= new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.Enter -= new System.EventHandler(this.txtPassword_Enter);
            this.txtUserName.TextChanged -= new System.EventHandler(this.txtUserName_TextChanged);
            this.chk_Enabled.CheckedChanged -= new System.EventHandler(this.chk_Enabled_CheckedChanged);
            this.rdb_DeactivateAfterNumberOfDays.CheckedChanged -= new System.EventHandler(this.rdb_DeactivateAfterNumberOfDays_CheckedChanged);
            this.rdb_AfterNumberOfDays.CheckedChanged -= new System.EventHandler(this.rdb_AfterNumberOfDays_CheckedChanged);
            this.rdb_PaswordExpires_Never.CheckedChanged -= new System.EventHandler(this.rdb_PaswordExpires_Never_CheckedChanged);
            this.txtUserName.KeyPress -= new System.Windows.Forms.KeyPressEventHandler(this.txtUserName_KeyPress);
            this.txtPassword.KeyPress -= new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            this.txtConfirmPassword.KeyPress -= new System.Windows.Forms.KeyPressEventHandler(this.txtConfirmPassword_KeyPress);
            this.chk_ChangePasswordOnFirstLogIn.CheckedChanged -= new System.EventHandler(this.chk_ChangePasswordOnFirstLogIn_CheckedChanged);
            this.dgv_LoginUsers.SelectionChanged -= new System.EventHandler(this.dataGridView_SelectionChanged);
            this.dgvx_OtherRoles.CellClick -= Dgvx_OtherRoles_CellClick;
            this.dgvx_UserRoles.CellClick -= Dgvx_UserRoles_CellClick;
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

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Tag.Equals(TAG_PASSWORD_DEFINED) && (txtPassword.Text.Equals(TEXT_PASSWORD_WILDCARDS)))
            {
                txtPassword.Text = "";
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
    }
}
