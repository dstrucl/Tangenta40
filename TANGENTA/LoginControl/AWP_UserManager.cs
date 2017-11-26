
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

        bool bLoginUsers_Read = false;

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
            lng.s_btn_DeleteUser.Text(this.btnDeleteUser);
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
            if (dtLoginUsers == null)
            {
                dtLoginUsers = new DataTable();
            }
            else
            {
                dtLoginUsers.Clear();
                dtLoginUsers.Columns.Clear();
            }

            bLoginUsers_Read = false;
            dgv_LoginUsers.DataSource = null;
            switch (awpld.GetData(ref dtLoginUsers, sUserName, awpbd))
            {

                case AWPLoginData.eGetDateResult.OK:
                    dgv_LoginUsers.Rows.Clear();
                    dgv_LoginUsers.DataSource = dtLoginUsers;

                    awpbd.SetControls(dgv_LoginUsers, dtLoginUsers.Rows[0], dtLoginUsers.TableName);
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
                    }
                    if (awpld.NotActiveAfterPasswordExpires)
                    {
                        rdb_DeactivateAfterNumberOfDays.Checked = true;
                    }
                    nmUpDn_MaxPasswordAge.Value = awpld.Maximum_password_age_in_days;

                    this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
                    this.dgv_LoginUsers.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
                    bLoginUsers_Read = true;
                    break;
                case AWPLoginData.eGetDateResult.USER_NOT_FOUND:
                    sUserName = null;
                    break;
                case AWPLoginData.eGetDateResult.ERROR:
                    DialogResult = DialogResult.Cancel;
                    this.Close();
                    break;
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            bUserNameChanged = true;
            if (txtUserName.Text.Length > 0)
            {
                this.lblPassword.Enabled = true;
                this.txtPassword.Enabled = true;
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

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text.Length > 0)
            {
                this.btnChangeData.Enabled = true;
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
                string Err = null;
                if (dgv_LoginUsers.SelectedRows.Count > 0)
                {
                    DataGridViewRow dgvr = dgv_LoginUsers.SelectedRows[0];
                    int iRowIndex = dgvr.Cells[0].RowIndex;
                    if ((iRowIndex >= 0) && (iRowIndex < dtLoginUsers.Rows.Count))
                    {
                        btnDeleteUser.Enabled = true;
                        btnAddUser.Text = lng.s_NewUser.s;
                        this.txtUserName.Enabled = true;
                        this.txtUserName.Tag = iRowIndex;
                        btnChangeData.Enabled = true;
                        this.txtUserName.ReadOnly = true;
                        this.txtPassword.Enabled = true;
                        this.txtConfirmPassword.Enabled = true;
                        this.txtUserName.TextChanged -= new System.EventHandler(this.txtUserName_TextChanged);
                        this.txtUserName.Text = dtLoginUsers.Rows[iRowIndex]["UserName"].ToString();
                        this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
                        if (dtLoginUsers.Rows[iRowIndex][LoginDB_DataSet.LoginUsers.password.name].GetType() != typeof(DBNull))
                        {
                            this.txtPassword.Text = TEXT_PASSWORD_WILDCARDS;
                            this.txtPassword.Tag = TAG_PASSWORD_DEFINED;
                        }
                        else
                        {
                            this.txtPassword.Text = "";
                            this.txtPassword.Tag = TAG_PASSWORD_UNDEFINED;
                        }

                        if (txtUserName.Text.Equals("Administrator"))
                        {
                            this.rdb_PaswordExpires_Never.Checked = (bool)dtLoginUsers.Rows[iRowIndex][LoginDB_DataSet.LoginUsers.PasswordNeverExpires.name];
                            this.rdb_PaswordExpires_Never.Checked = true;
                            this.rdb_DeactivateAfterNumberOfDays.Checked = false;
                            this.rdb_DeactivateAfterNumberOfDays.Enabled = false;
                            this.rdb_AfterNumberOfDays.Enabled = false;
                            this.rdb_AfterNumberOfDays.Checked = false;
                            this.nmUpDn_MaxPasswordAge.Enabled = false;
                            this.chk_ChangePasswordOnFirstLogIn.Checked = false;
                        }
                        else
                        {
                            this.rdb_PaswordExpires_Never.Checked = (bool)dtLoginUsers.Rows[iRowIndex][LoginDB_DataSet.LoginUsers.PasswordNeverExpires.name];
                            this.chk_ChangePasswordOnFirstLogIn.Checked = (bool)dtLoginUsers.Rows[iRowIndex][LoginDB_DataSet.LoginUsers.ChangePasswordOnFirstLogin.name];
                            this.nmUpDn_MaxPasswordAge.Value = Convert.ToDecimal(dtLoginUsers.Rows[iRowIndex][LoginDB_DataSet.LoginUsers.Maximum_password_age_in_days.name]);
                            this.rdb_DeactivateAfterNumberOfDays.Checked = (bool)dtLoginUsers.Rows[iRowIndex][LoginDB_DataSet.LoginUsers.NotActiveAfterPasswordExpires.name];
                            if ((!rdb_DeactivateAfterNumberOfDays.Checked) && (!rdb_PaswordExpires_Never.Checked))
                            {
                                this.rdb_AfterNumberOfDays.Checked = true;
                            }
                            else
                            {
                                this.rdb_AfterNumberOfDays.Checked = false;
                            }
                        }
                        this.txtConfirmPassword.Text = this.txtPassword.Text;
                        this.lbl_UserName.Enabled = true;
                        this.lblPassword.Enabled = true;
                        this.lbl_ConfirmPasword.Enabled = true;
                        if (!bLoginUsers_Read)
                        {
                            if (!LoginRolesReload(iRowIndex, ref Err))
                            {
                                LogFile.Error.Show(Err);
                            }
                        }
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
                    btnDeleteUser.Enabled = true;
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
                    btnDeleteUser.Enabled = false;
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

        private bool DoChangeData()
        {
            if (txtUserName.Text.Length > 0)
            {
                string Err = null;
                if (bUserNameChanged)
                {
                    if (AWP_func.UserNameExist(txtUserName.Text, ref Err))
                    {
                        MessageBox.Show(lng.s_UserName_AllreadyExist.s);
                        return false;
                    }
                }
                if (Err == null)
                {
                    if (txtPassword.Text.Length >= awp.lctrl.MinPasswordLength)
                    { 
                        if (txtPassword.Text.Equals(txtConfirmPassword.Text))
                        {
                            awpld.UserName = txtUserName.Text;
                            byte[] Password = LoginControl.CalculateSHA256(txtPassword.Text);
                            awpld.Password = Password;
                            bool bRes = AWP_func.Update_LoginUsers_ID(awpld, true);
                            if (bRes)
                            {
                                bUserNameChanged = false;
                            }
                            return bRes;
                        }
                        else
                        {
                            MessageBox.Show(lng.s_Password_does_not_match.s);
                        }
                    }
                    else
                    {
                        MessageBox.Show(lng.s_YouMustDefinePasswordThatHasAtLeastXCharactersOrNumbers.s+" "+ awp.lctrl.MinPasswordLength.ToString());
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                MessageBox.Show(lng.s_UserName_Is_Not_Defined.s);
            }
            return false;
        }

        private void MakeListOfAWPRoles(ref List<AWPRole> roles)
        {
        }

        private bool Write_LoginUsersAndLoginAWPRoles(int usr_id,List<AWPRole> roles,ref string Err)
        {
            string sql_change_roles = " delete " + LoginDB_DataSet.LoginUsersAndLoginRoles.tablename_const + " where " + LoginDB_DataSet.LoginUsersAndLoginRoles.LoginUsers_id.name + " = " + usr_id.ToString();
            foreach (AWPRole role in roles)
            {
//                    sql_change_roles += "\r\n insert into " +LoginDB_DataSet.LoginUsersAndLoginRoles.tablename_const + " ( " + LoginDB_DataSet.LoginUsersAndLoginRoles.LoginUsers_id.name + "," + LoginDB_DataSet.LoginUsersAndLoginRoles.LoginRoles_id.name + ") values ("+ usr_id.ToString()+"," + role.id.ToString()+")";
            }
            object res = null;
            //if (Login_con.ExecuteNonQuerySQL(sql_change_roles,null,ref res,ref Err))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return false;
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

        public bool Func_FindUser(string UserName, ref Int64 id, ref bool bActive, ref string csError)
        {
            //DataTable dt = new DataTable();
            //string sColumn1 = "amb_username_UserName";
            //string sColumn2 = "amb_user_Active";
            //string sColumns = "[ID]," + sColumn1 + "," + sColumn2;
            //string sWhere = " WHERE " + sColumn1 + " = '" + UserName + "'";
            //if (m_tbl_amb_user.GetTableView(m_DB_Local.m_DBTables.m_con, ref dt, ref csError, -1, sColumns, sWhere))
            //{
            //    if (dt.Rows.Count > 0)
            //    {
            //        id = (Int64)dt.Rows[0][0];
            //        bActive = (bool)dt.Rows[0][sColumn2];
            //        return true;
            //    }
            //}
            return false;
        }

        public bool Func_AddUser(STD_username_Data userdata, ref Int64 row_ID, ref string csError)
        {
        ////    if (m_tbl_amb_user != null)
        ////    {
        ////        amb_user m_amb_user = (amb_user)this.m_DB_Local.m_DBTables.UndefineAllValues(m_tbl_amb_user);
        ////        m_amb_user.amb_localdatabase_ID.ComputerName.val = SystemInformation.ComputerName;
        ////        m_amb_user.amb_localdatabase_ID.DataBaseFile.val = m_DB_Local.m_DBTables.m_con.SQLiteDataBaseFile;
        ////        m_amb_user.amb_localdatabase_ID.DataBaseFileCreationTime.val = m_DB_Local.m_DBTables.m_con.SQLiteDataBaseFileCreationTime;
        ////        m_amb_user.amb_role_ID.RoleName.val = RoleName;
        ////        m_amb_user.amb_group_ID.GroupName.val = GroupName;
        ////        m_amb_user.amb_username_ID.UserName.val = userdata.username;
        ////        m_amb_user.amb_username_ID.Password.val = m_Login.EncryptString(userdata.password);
        ////        m_amb_user.amb_username_ID.amb_username_PersonalData_ID.FirstName.val = userdata.FirstName;
        ////        m_amb_user.amb_username_ID.amb_username_PersonalData_ID.LastName.val = userdata.LastName;
        ////        m_amb_user.amb_username_ID.amb_username_PersonalData_ID.IdentityNumber.val = userdata.IdentityNumber;
        ////        m_amb_user.amb_username_ID.amb_username_PersonalData_ID.Contact.val = userdata.Contact;
        ////        m_amb_user.Active.val = true;
        ////        m_tbl_amb_user.SetColumnValues(m_amb_user);
        ////        row_ID = -1;
        ////        if (m_tbl_amb_user.SQLcmd_InsertInto(m_DB_Local.m_DBTables.m_con, m_DB_Local.m_DBTables.items, ref csError, m_DB_Local.m_DBTables.m_strSQLUseDatabase, ref row_ID))
        ////        {
        ////            return true;
        ////        }
        ////        else
        ////        {
        ////            return false;
        ////        }
        ////    }
        ////    else
        ////    {
        ////        csError = "Error: m_tbl_amb_user == null";
        ////        return false;
        ////    }
            return true;
        }

        internal bool Func_ChangeData(AWPBindingData awpd, bool bActive,ref string csError)
        {
            //bool bPasswordChanged = false;
            //string Err = null;

            //    if (LoginUsers.RowsCount > 0)
            //    {
            //        if (userdata.password.Length >= login_control.MinPasswordLength)
            //        {
            //            if (LoginUsers.o_password.password_ == null)
            //            {
            //                bPasswordChanged = true;
            //            }
            //            else
            //            {
            //                if (userdata.password_changed)
            //                {
            //                    if (!login_control.PasswordMatch(LoginUsers.o_password.password_, userdata.password))
            //                    {
            //                        bPasswordChanged = true;
            //                    }
            //                }
            //            }
            //        }
            //        else
            //        {

            //            if ((LoginUsers.o_password.password_ == null) && ((userdata.password.Length < login_control.MinPasswordLength)))
            //            {
            //                MessageBox.Show(lng.s_PasswordIsNotDefined_YouMustDefinePasswordThatHasAtLeastXCharactersOrNumbers1.s
            //                                + login_control.MinPasswordLength.ToString() +
            //                                lng.s_PasswordIsNotDefined_YouMustDefinePasswordThatHasAtLeastXCharactersOrNumbers2.s);
            //                return false;
            //            }
            //            else
            //            {
            //                if ((LoginUsers.o_password.password_ != null) && ((userdata.password.Length < login_control.MinPasswordLength)) && ((userdata.password.Length > 0)))
            //                {
            //                    MessageBox.Show(lng.s_YouMustDefinePasswordThatHasAtLeastXCharactersOrNumbers3.s
            //                                  + login_control.MinPasswordLength.ToString() +
            //                                  lng.s_PasswordIsNotDefined_YouMustDefinePasswordThatHasAtLeastXCharactersOrNumbers2.s);
            //                    return false;
            //                }
            //            }
            //        }

            //        string Res = null;
            //        m_LoginDB_DataSet_Procedures.LoginUsers_ChangeData(LoginUsers.o_id.id_,
            //                                                           userdata.FirstName,
            //                                                           userdata.LastName,
            //                                                           userdata.IdentityNumber,
            //                                                           userdata.Contact,
            //                                                           ref Res,
            //                                                           ref Err);
            //        if (Res.Equals("OK"))
            //        {
            //            m_LoginDB_DataSet_Procedures.LoginUsers_Administrator_ChangePasswordParameters(LoginUsers.o_id.id_,
            //                                                                                           login_control.m_LoginData.m_LoginUsers_id,
            //                                                                                           userdata.bPasswordNeverExpires,
            //                                                                                           chk_Active.Checked,
            //                                                                                           userdata.bChangePasswordOnFirstLogin,
            //                                                                                           userdata.iMaxPasswordAge,
            //                                                                                           userdata.bNotActiveAfterPasswordExpires,
            //                                                                                         ref Res,
            //                                                                                         ref Err);

            //            if (Res.Equals("OK"))
            //            {
            //                if (bPasswordChanged)
            //                {
            //                    m_LoginDB_DataSet_Procedures.LoginUsers_Administrator_ChangePassword(LoginUsers.o_id.id_,
            //                                                                                         login_control.CalculateSHA256(userdata.password),//crypted password
            //                                                                                         login_control.m_LoginData.m_LoginUsers_id,
            //                                                                                         ref Res,
            //                                                                                         ref Err);
            //                    if (Res.Equals("OK"))
            //                    {
            //                        if (LoginUsers_Read(LoginUsers.m_bs_dt.Position, ref Err))
            //                        {
            //                            if (!LoginRolesReload(LoginUsers.m_bs_dt.Position, ref Err))
            //                            {
            //                                LogFile.Error.Show(Err);
            //                            }
            //                            return true;
            //                        }
            //                        else
            //                        {
            //                            LogFile.Error.Show("Error:Func_ChangeData:LoginUsers_Read: Error = " + Err);
            //                            return false;
            //                        }
            //                    }
            //                    else
            //                    {
            //                        LogFile.Error.Show("Error:Func_ChangeData:LoginUsers_Administrator_ChangePassword: Res = " + Res);
            //                        return false;
            //                    }
            //                }
            //                else
            //                {
            //                    if (LoginUsers_Read(LoginUsers.m_bs_dt.Position, ref Err))
            //                    {
            //                        if (!LoginRolesReload(LoginUsers.m_bs_dt.Position, ref Err))
            //                        {
            //                            LogFile.Error.Show(Err);
            //                        }
            //                        return true;
            //                    }
            //                    else
            //                    {
            //                        LogFile.Error.Show("Error:Func_ChangeData:LoginUsers_Read: Error = " + Err);
            //                        return false;
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                LogFile.Error.Show("Error:Func_ChangeData:LoginUsers_Administrator_ChangePasswordParameters: Res = " + Res);
            //                return false;
            //            }
            //        }
            //        else
            //        {
            //            LogFile.Error.Show("Error:Func_ChangeData:LoginUsers_ChangeData: Res = " + Res);
            //            return false;
            //        }
            //        return true;
            //    }
            //    else
            //    {
            //        LogFile.Error.Show("Error:UserManager:LoginUsers: RowsCount = 0");
            //        return false;
            //    }
            return false;
        }

        public bool Func_RemoveUser(string UserName, ref bool bDeleted, ref string csError)
        {
            return false;
            //DataTable dt = new DataTable();
            //string sColumn1 = "amb_username_UserName";
            //string sColumns = "[ID]," + sColumn1;
            //string sWhere = " WHERE " + sColumn1 + " = '" + UserName + "'";
            //if (m_tbl_amb_user.GetTableView(m_DB_Local.m_DBTables.m_con, ref dt, ref csError, -1, sColumns, sWhere))
            //{
            //    if (dt.Rows.Count > 0)
            //    {
            //        Int64 id = (Int64)dt.Rows[0][0];
            //        // We have id of amb_user 
            //        // Check if this user is used in Local table
            //        sColumns = sColumn1;
            //        sWhere = " WHERE " + sColumn1 + " = '" + UserName + "'";
            //        dt.Clear();
            //        if (this.m_tbl_amb_queue.GetTableView(m_DB_Local.m_DBTables.m_con, ref dt, ref csError, 2, sColumns, sWhere))
            //        {
            //            if (dt.Rows.Count > 0)
            //            {
            //                amb_user m_amb_user = (amb_user)this.m_DB_Local.m_DBTables.UndefineAllValues(m_tbl_amb_user);
            //                m_amb_user.ID.val = id;
            //                m_amb_user.Active.val = false;
            //                m_tbl_amb_user.SetColumnValues(m_amb_user);
            //                if (m_tbl_amb_user.SQLcmd_Update(m_DB_Local.m_DBTables, ref  csError))
            //                {
            //                    bDeleted = false;
            //                    return true;
            //                }
            //                else
            //                {
            //                    LogFile.Error.Show("Error:" + csError);
            //                    return false;
            //                }
            //            }
            //            else
            //            {
            //                // No amb_user_ID found in amb_queue , so we can delete it without compromising foreign key constraint
            //                string sql_delete = "DELETE FROM " + m_tbl_amb_user.TableName + " WHERE id = " + id.ToString();
            //                object oResult = null;
            //                if (m_DB_Local.m_DBTables.m_con.ExecuteNonQuerySQL(sql_delete, null, ref oResult, ref csError, "DELETE User from user table"))
            //                {
            //                    bDeleted = true;
            //                    return true;
            //                }
            //                else
            //                {
            //                    LogFile.Error.Show("Error:" + csError);
            //                    return false;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            LogFile.Error.Show("Error:" + csError);
            //            return false;
            //        }
            //    }
            //    else
            //    {
            //        LogFile.Error.Show("Error: Unexpected: UserName= " + UserName + "Are not in table " + m_tbl_amb_user.TableName + ". They should be in table!");
            //        return false;
            //    }
            //}
            //else
            //{
            //    csError = "Error:dt.Rows.Count == 0";
            //    return false;
            //}
        }

     

        private void rdb_PaswordExpires_Never_CheckedChanged(object sender, EventArgs e)
        {
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

        private bool DoOK()
        {
            if (awpld.Password!=null)
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


    }
}
