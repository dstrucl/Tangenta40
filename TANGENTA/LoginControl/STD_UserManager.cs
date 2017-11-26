
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;


namespace LoginControl
{

    public partial class STD_UserManager : Form
    {

        bool bLoginUsers_Read = false;

        private const string TEXT_PASSWORD_WILDCARDS = "***********";
        private const string TAG_PASSWORD_UNDEFINED = "TAG_PASSWORD_UNDEFINED";
        private const string TAG_PASSWORD_DEFINED = "TAG_PASSWORD_DEFINED";
        private const string TAG_PASSWORD_CHANGED = "TAG_PASSWORD_CHANGED";

        private const string Column_Select = "Select";
        private Form myParent;
        private string m_DataBaseFile;
        private DateTime m_DataBaseFileCreationTime;
        DBConnectionControl40.DBConnection Login_con;

        LoginDB_DataSet.LoginUsers LoginUsers = null;
        LoginDB_DataSet.LoginRoles LoginRoles = null;
        LoginDB_DataSet.LoginRoles_lang LoginRoles_lang = new LoginDB_DataSet.LoginRoles_lang();
        LoginDB_DataSet.LoginUsersAndLoginRoles LoginUsersAndLoginRoles = null;
        LoginDB_DataSet.LoginDB_DataSet_Procedures m_LoginDB_DataSet_Procedures = null;
        LoginDB_DataSet.LoginUsers_lang LoginUsers_lang = new LoginDB_DataSet.LoginUsers_lang();
        STD std = null;


        public STD_UserManager(Form pParent,STD xstd)
        {
            std = xstd;
            InitializeComponent();
            Login_con = std.Login_con;

            int Index_OfDefaultUserName = -1;


            myParent = pParent;

            this.txt_ComputerName_DataBaseFile_DataBaseFileCreationTime.Text = lng.s_ComputerName.s + SystemInformation.ComputerName + "  ; " + lng.s_DataBaseFile.s + m_DataBaseFile + " ; " + lng.s_DataBaseFileCreationTime.s + m_DataBaseFileCreationTime.ToString();




            lbl_Max_Password_Age.Text = lng.s_Max_Password_Age.s;
            chk_ChangePasswordOnFirstLogIn.Text = lng.s_chk_ChangePasswordOnFirstLogIn.s;
            rdb_PaswordExpires_Never.Text = lng.s_chk_PasswordNeverExpires.s;
            rdb_DeactivateAfterNumberOfDays.Text = lng.s_rdb_DeactivateAfterNumberOfDays.s;
            rdb_AfterNumberOfDays.Text = lng.s_rdb_AfterNumberOfDays.s;
            lbl_UserFirstName.Text = lng.s_FirstName.s;
            lbl_UserLastName.Text = lng.s_LastName.s;
            lbl_UserIdentity.Text = lng.s_IdentityNumber.s;
            lbl_Contact.Text = lng.s_Contact.s;

           
            this.lbl_UserName.Text = lng.s_lblUserName_UserManager.s;
            this.lblPassword.Text = lng.s_lblPassword_UserManager.s;
            this.lbl_ConfirmPasword.Text = lng.s_lblConfirmPassword_UserManager.s;
            this.btnAddUser.Text = lng.s_btnAddUser_UserManager.s;
            this.btnDeleteUser.Text = lng.s_btn_DeleteUser.s;
            this.btnChangeData.Text = lng.s_btnChangeData_UserManager.s;
            this.btnOK.Text = lng.s_btnOK_UserManager.s;
            this.btnCancel.Text = lng.s_btnCancel_UserManager.s;
            this.txtUserName.Tag = null;
            this.grp_PasswordExpires.Text = lng.s_PasswordExpires.s;
            btnDeleteUser.Enabled = false;
            this.lbl_ConfirmPasword.Enabled = false;
            this.lblPassword.Enabled = false;
            this.txtPassword.Enabled = false;
            this.txtConfirmPassword.Enabled = false;
            this.btnAddUser.Enabled = false;
            this.btnChangeData.Enabled = false;
            this.Icon = Properties.Resources.user;
            this.Text = lng.s_ManageUSers.s;
            lbl_ManageRoles.Text = lng.s_lbl_UserRoles.s;
            btn_ManageRoles.Text = lng.s_btn_ManageRoles.s;

            chk_Active.Text = lng.s_Active.s;

  
            this.Text = lng.s_ManageUSers.s + " " + lng.s_OnComputer.s + " " + SystemInformation.ComputerName;

            if (Index_OfDefaultUserName >= 0)
            {
                this.txtUserName.Text = LoginUsers.dt.Rows[Index_OfDefaultUserName][LoginDB_DataSet.LoginUsers.username.name].ToString();
                this.txtPassword.Text = LoginUsers.dt.Rows[Index_OfDefaultUserName][LoginDB_DataSet.LoginUsers.password.name].ToString();
                this.txtFirstName.Text = LoginUsers.dt.Rows[Index_OfDefaultUserName][LoginDB_DataSet.LoginUsers.first_name.name].ToString();
                this.txtLastName.Text = LoginUsers.dt.Rows[Index_OfDefaultUserName][LoginDB_DataSet.LoginUsers.last_name.name].ToString();
                this.txtIdentityNumber.Text = LoginUsers.dt.Rows[Index_OfDefaultUserName][LoginDB_DataSet.LoginUsers.Identity.name].ToString();
                this.txtContact.Text = LoginUsers.dt.Rows[Index_OfDefaultUserName][LoginDB_DataSet.LoginUsers.Contact.name].ToString();
                this.chk_ChangePasswordOnFirstLogIn.Checked = (bool)LoginUsers.dt.Rows[Index_OfDefaultUserName][LoginDB_DataSet.LoginUsers.ChangePasswordOnFirstLogin.name];
                this.rdb_PaswordExpires_Never.Checked = (bool)LoginUsers.dt.Rows[Index_OfDefaultUserName][LoginDB_DataSet.LoginUsers.PasswordNeverExpires.name];
                this.nmUpDn_MaxPasswordAge.Value = Convert.ToDecimal(LoginUsers.dt.Rows[Index_OfDefaultUserName][LoginDB_DataSet.LoginUsers.Maximum_password_age_in_days.name]);
                this.chk_Active.Checked = (bool)LoginUsers.dt.Rows[Index_OfDefaultUserName][LoginDB_DataSet.LoginUsers.enabled.name];
                this.txtConfirmPassword.Text = this.txtPassword.Text;
            }
            else
            {
                this.chk_ChangePasswordOnFirstLogIn.Checked = true;
                this.rdb_PaswordExpires_Never.Checked = true;
                this.nmUpDn_MaxPasswordAge.Value = 90.0M;
                this.chk_Active.Checked = true;
                txtUserName.Text = "";
                txtPassword.Text = "";
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtIdentityNumber.Text = "";
                txtContact.Text = "";
                txtConfirmPassword.Text = "";
            }
            this.txtUserName.Focus();
        }


        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
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

        private bool AddUser()
        {
            int New_LoginUsers_id = -1;
            string Res = null;
            string Err = null;
            Int64 id = -1;
            bool bActive = false;
            string csError = null;

            if (this.txtUserName.Tag != null)
            {
                this.txtUserName.Tag = null;

                //txtUserName.TabIndex = 0;
                //txtPassword.TabIndex = 1;
                //txtConfirmPassword.TabIndex = 2;
                //btnAddUser.TabIndex = 3;
                //this.btnOK.TabIndex = 4;

                //this.cmb_Group.TabIndex = 15;
                //this.chk_Active.TabIndex = 14;
                //this.dataGridView.TabIndex = 13;

                txtUserName.Text = "";
                txtPassword.Text = "";
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtIdentityNumber.Text = "";
                txtContact.Text = "";
                txtConfirmPassword.Text = "";
                txtUserName.ReadOnly = false;
                txtUserName.Enabled = true;
                txtPassword.Enabled = true;
                lblPassword.Enabled = true;
                txtConfirmPassword.Enabled = true;
                chk_Active.Checked = true;
                this.lbl_ConfirmPasword.Enabled = true;
                chk_ChangePasswordOnFirstLogIn.Checked = true;
                txtUserName.Focus();
                foreach (DataGridViewRow dgvr in dgv_Roles.Rows)
                {
                    dgvr.Cells[Column_Select].Value = false;
                }
                return true;
            }
            else
            {
                //this.cmb_Group.TabIndex = 0;
                //this.chk_Active.TabIndex = 1;
                //txtUserName.TabIndex = 2;
                //txtPassword.TabIndex = 3;
                //txtConfirmPassword.TabIndex = 4;

                //btnAddUser.TabIndex = 10;
                //this.btnOK.TabIndex = 11;
                //this.dataGridView.TabIndex = 15;

                if (txtUserName.Text.Length == 0)
                {
                    MessageBox.Show(lng.s_UserNameIsNotWritten.s, lng.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (!txtPassword.Text.Equals(txtConfirmPassword.Text))
                {
                    MessageBox.Show(lng.s_Password_does_not_match.s, lng.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                int iRow = LoginUsers.dt.Rows.Count - 1;

                if (iRow >= 0)
                {
                    this.txtUserName.Tag = iRow;
                    btnDeleteUser.Enabled = true;
                    this.btnChangeData.Enabled = true;
                    btnAddUser.Text = lng.s_NewUser.s;
                    txtUserName.ReadOnly = true;
                }

                m_LoginDB_DataSet_Procedures.LoginUsers_Administrator_AddUser(txtUserName.Text,
                                                                              LoginControl.CalculateSHA256(txtPassword.Text),
                                                                              chk_Active.Checked,
                                                                              txtFirstName.Text,
                                                                              txtLastName.Text,
                                                                              txtIdentityNumber.Text,
                                                                              txtContact.Text,
                                                                              Convert.ToInt32(std.lctrl.LoginUsers_id),
                                                                              this.rdb_PaswordExpires_Never.Checked,
                                                                              chk_ChangePasswordOnFirstLogIn.Checked,
                                                                              Convert.ToInt32(nmUpDn_MaxPasswordAge.Value),
                                                                              rdb_DeactivateAfterNumberOfDays.Checked,
                                                                              ref New_LoginUsers_id,
                                                                              ref Res,
                                                                              ref Err);

                if (Res.Equals("OK"))
                {
                    List<STDRole> roles = new List<STDRole>();
                    MakeListOfSTDRoles(ref roles);
                    if (!Write_LoginUsersAndLoginSTDRoles(New_LoginUsers_id, roles, ref Err))
                    {
                        LogFile.Error.Show("Error:UserManager:AddUser:Write_LoginUsersAndLoginRoles:Err=" + Err);
                    }

                    if (LoginUsers_Read(-1, ref Err))
                    {
                        LoginUsers.m_bs_dt.Position = LoginUsers.dt.Rows.Count-1;

                        if (!LoginRolesReload(LoginUsers.m_bs_dt.Position, ref Err))
                        {
                            LogFile.Error.Show("Error:UserManager_Load:LoginUsers.Read: Err = " + Err);
                            return false;
                        }

                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show(Err);
                        return false;
                    }
                    
                }
                else
                {
                    if (Err!=null)
                    {
                        LogFile.Error.Show(Err);
                    }
                    else
                    {
                        LogFile.Error.Show(Res);
                    }
                    return false;
                }
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
                    if ((iRowIndex >= 0) && (iRowIndex < LoginUsers.dt.Rows.Count))
                    {
                        btnDeleteUser.Enabled = true;
                        btnAddUser.Text = lng.s_NewUser.s;
                        this.txtUserName.Enabled = true;
                        this.txtUserName.Tag = iRowIndex;
                        btnChangeData.Enabled = true;
                        this.txtUserName.ReadOnly = true;
                        this.txtPassword.Enabled = true;
                        this.txtConfirmPassword.Enabled = true;
                        this.txtUserName.Text = LoginUsers.dt.Rows[iRowIndex][LoginDB_DataSet.LoginUsers.username.name].ToString();
                        if (LoginUsers.dt.Rows[iRowIndex][LoginDB_DataSet.LoginUsers.password.name].GetType() != typeof(DBNull))
                        {
                            this.txtPassword.Text = TEXT_PASSWORD_WILDCARDS;
                            this.txtPassword.Tag = TAG_PASSWORD_DEFINED;
                        }
                        else
                        {
                            this.txtPassword.Text = "";
                            this.txtPassword.Tag = TAG_PASSWORD_UNDEFINED;
                        }
                        this.txtFirstName.Text = LoginUsers.dt.Rows[iRowIndex][LoginDB_DataSet.LoginUsers.first_name.name].ToString();
                        this.txtLastName.Text = LoginUsers.dt.Rows[iRowIndex][LoginDB_DataSet.LoginUsers.last_name.name].ToString();
                        this.txtIdentityNumber.Text = LoginUsers.dt.Rows[iRowIndex][LoginDB_DataSet.LoginUsers.Identity.name].ToString();
                        this.txtContact.Text = LoginUsers.dt.Rows[iRowIndex][LoginDB_DataSet.LoginUsers.Contact.name].ToString();

                        this.chk_Active.Checked = (bool)LoginUsers.dt.Rows[iRowIndex][LoginDB_DataSet.LoginUsers.enabled.name];
                        if (txtUserName.Text.Equals("Administrator"))
                        {
                            this.rdb_PaswordExpires_Never.Checked = (bool)LoginUsers.dt.Rows[iRowIndex][LoginDB_DataSet.LoginUsers.PasswordNeverExpires.name];
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
                            this.rdb_PaswordExpires_Never.Checked = (bool)LoginUsers.dt.Rows[iRowIndex][LoginDB_DataSet.LoginUsers.PasswordNeverExpires.name];
                            this.chk_ChangePasswordOnFirstLogIn.Checked = (bool)LoginUsers.dt.Rows[iRowIndex][LoginDB_DataSet.LoginUsers.ChangePasswordOnFirstLogin.name];
                            this.nmUpDn_MaxPasswordAge.Value = Convert.ToDecimal(LoginUsers.dt.Rows[iRowIndex][LoginDB_DataSet.LoginUsers.Maximum_password_age_in_days.name]);
                            this.rdb_DeactivateAfterNumberOfDays.Checked = (bool)LoginUsers.dt.Rows[iRowIndex][LoginDB_DataSet.LoginUsers.NotActiveAfterPasswordExpires.name];
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
            if (LoginRoles_Read((int)LoginUsers.dt.Rows[iRowIndex][LoginDB_DataSet.LoginUsers.id.name], ref Err))
            {
                foreach (DataGridViewRow dgvroles in dgv_Roles.Rows)
                {
                    int LoginRole_id = (int)dgvroles.Cells[LoginDB_DataSet.LoginRoles.id.name].Value;
                    if (LoginRole_id_IN_LoginUsersAndLoginRoles(LoginRole_id))
                    {
                        dgvroles.Cells[Column_Select].Value = true;
                    }
                    else
                    {
                        dgvroles.Cells[Column_Select].Value = false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }


        }

        private bool LoginRole_id_IN_LoginUsersAndLoginRoles(int LoginRole_id)
        {
            foreach (DataRow dr in LoginUsersAndLoginRoles.dt.Rows)
            {
                if ((int)dr[LoginDB_DataSet.LoginUsersAndLoginRoles.LoginRoles_id.name] == LoginRole_id)
                {
                    return true;
                }
            }
            return false;
        }

        private bool LoginRoles_Read(int LoginUsers_id, ref string Err)
        {
            if (LoginRoles == null)
            {
                LoginRoles = new LoginDB_DataSet.LoginRoles(std.Login_con);
            }
            LoginRoles.Clear();
            LoginRoles.select.all(true);
            if (LoginRoles.Read(ref Err))
            {
                if (dgv_Roles.DataSource == null)
                {
                    dgv_Roles.DataSource = LoginRoles.m_bs_dt;
                    dgv_Roles.Columns[LoginDB_DataSet.LoginRoles.id.name].Visible = false;
                    dgv_Roles.Columns[LoginDB_DataSet.LoginRoles.Name.name].ReadOnly = true;
                    dgv_Roles.Columns[LoginDB_DataSet.LoginRoles.Name.name].DefaultCellStyle.BackColor = Color.LightGray;
                    dgv_Roles.Columns[LoginDB_DataSet.LoginRoles.PrivilegesLevel.name].ReadOnly = true;
                    dgv_Roles.Columns[LoginDB_DataSet.LoginRoles.PrivilegesLevel.name].DefaultCellStyle.BackColor = Color.LightGray;
                    dgv_Roles.Columns[LoginDB_DataSet.LoginRoles.description.name].ReadOnly = true;
                    dgv_Roles.Columns[LoginDB_DataSet.LoginRoles.description.name].DefaultCellStyle.BackColor = Color.LightGray;
                    DataGridViewColumn dgvcol = new DataGridViewCheckBoxColumn();
                    dgvcol.ReadOnly = false;
                    dgvcol.Name = Column_Select;
                    dgvcol.HeaderText = "";
                    dgv_Roles.Columns.Insert(0, dgvcol);
                    LoginDB_DataSet.HeaderText.Set(dgv_Roles, LoginRoles_lang.col_headers);
                }
                if (LoginUsersAndLoginRoles == null)
                {
                    LoginUsersAndLoginRoles = new LoginDB_DataSet.LoginUsersAndLoginRoles(std.Login_con);
                }
                LoginUsersAndLoginRoles.Clear();
                LoginUsersAndLoginRoles.select.all(false);
                LoginUsersAndLoginRoles.select.LoginRoles_id = true;
                LoginUsersAndLoginRoles.where.all(false);
                LoginUsersAndLoginRoles.where.LoginUsers_id = true;
                LoginUsersAndLoginRoles.where.LoginUsers_id_Expression(" = " + LoginUsers_id.ToString());
                if (LoginUsersAndLoginRoles.Read(ref Err))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
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
                    LoginUsers.dt.Rows.RemoveAt(iRowIndex);
                }
                else
                {
                    //m_DataTable.Rows[iRowIndex][Login.COL_amb_user_Active] = false;
                }
                if (iRowIndex >= LoginUsers.dt.Rows.Count)
                {
                    iRowIndex = LoginUsers.dt.Rows.Count - 1;
                }
                if (LoginUsers.dt.Rows.Count > 0)
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
                    this.txtUserName.Text = LoginUsers.dt.Rows[iRowIndex][LoginDB_DataSet.LoginUsers.username.name].ToString();
                    this.txtPassword.Text = LoginUsers.dt.Rows[iRowIndex][LoginDB_DataSet.LoginUsers.password.name].ToString();
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
            if (txtUserName.Tag != null)
            {
                if (txtPassword.Text.Equals(txtConfirmPassword.Text))
                {
                    int iRow = (int)txtUserName.Tag;
                    string csError = null;
                    //Role myRole = m_Login.FindRoleInLanguage(cmb_Role.Text);
                    //string RoleName = myRole.name;
                    STD_username_Data userdata = new STD_username_Data();

                    userdata.username = txtUserName.Text;
                    if (txtPassword.Tag.Equals(TAG_PASSWORD_DEFINED))
                    {
                        userdata.password = TEXT_PASSWORD_WILDCARDS;
                        userdata.password_changed = false;
                    }

                    if (txtPassword.Tag.Equals(TAG_PASSWORD_UNDEFINED))
                    {
                        userdata.password = txtPassword.Text;
                        userdata.password_changed = true;
                    }

                    if (txtPassword.Tag.Equals(TAG_PASSWORD_CHANGED))
                    {
                        userdata.password = txtPassword.Text;
                        userdata.password_changed = true;
                    }

                    userdata.FirstName = txtFirstName.Text;
                    userdata.LastName = txtLastName.Text;
                    userdata.IdentityNumber = txtIdentityNumber.Text;
                    userdata.Contact = txtContact.Text;
                    userdata.bPasswordNeverExpires = this.rdb_PaswordExpires_Never.Checked;
                    userdata.bChangePasswordOnFirstLogin = chk_ChangePasswordOnFirstLogIn.Checked;
                    userdata.iMaxPasswordAge = Convert.ToInt32(nmUpDn_MaxPasswordAge.Value);
                    
                    userdata.m_Roles.Clear();

                    MakeListOfSTDRoles(ref userdata.m_Roles);

                    bool bActive = chk_Active.Checked;

                    string Err = null;
                    if (Write_LoginUsersAndLoginSTDRoles(LoginUsers.o_id.id_, userdata.m_Roles, ref Err))
                    {
                        if (Func_ChangeData(userdata, bActive,  ref csError))
                        {
                            MessageBox.Show(lng.sUserDataAreChanged.s);
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                    else
                    {
                        LogFile.Error.Show("Error:UserManager:DoChangeData:Write_LoginUsersAndLoginRoles:" + Err);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show(lng.s_Password_does_not_match.s);
                }
            }
            return false;
        }

        private void MakeListOfSTDRoles(ref List<STDRole> roles)
        {
            foreach (DataGridViewRow dgvr in dgv_Roles.Rows)
            {
                if ((bool)dgvr.Cells[Column_Select].Value == true)
                {
                    STDRole role = new STDRole();
                    role.id = (int)dgvr.Cells[LoginDB_DataSet.LoginRoles.id.name].Value;
                    role.Name = (string)dgvr.Cells[LoginDB_DataSet.LoginRoles.Name.name].Value;
                    role.PrivilegesLevel = (int)dgvr.Cells[LoginDB_DataSet.LoginRoles.PrivilegesLevel.name].Value;
                    if (dgvr.Cells[LoginDB_DataSet.LoginRoles.description.name].Value.GetType() == typeof(string))
                    {
                        role.description = (string)dgvr.Cells[LoginDB_DataSet.LoginRoles.description.name].Value;
                    }
                    else
                    {
                        role.description = "";
                    }
                    roles.Add(role);
                }
            }
        }

        private bool Write_LoginUsersAndLoginSTDRoles(int usr_id,List<STDRole> roles,ref string Err)
        {
            string sql_change_roles = " delete " + LoginDB_DataSet.LoginUsersAndLoginRoles.tablename_const + " where " + LoginDB_DataSet.LoginUsersAndLoginRoles.LoginUsers_id.name + " = " + usr_id.ToString();
            foreach (STDRole role in roles)
            {
                    sql_change_roles += "\r\n insert into " +LoginDB_DataSet.LoginUsersAndLoginRoles.tablename_const + " ( " + LoginDB_DataSet.LoginUsersAndLoginRoles.LoginUsers_id.name + "," + LoginDB_DataSet.LoginUsersAndLoginRoles.LoginRoles_id.name + ") values ("+ usr_id.ToString()+"," + role.id.ToString()+")";
            }
            object res = null;
            if (Login_con.ExecuteNonQuerySQL(sql_change_roles,null,ref res,ref Err))
            {
                return true;
            }
            else
            {
                return false;
            }
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

        private void chk_Active_CheckedChanged(object sender, EventArgs e)
        {

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

        private void cmb_Role_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtFirstName.Focus();
                e.Handled = true;
            }
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.txtLastName.Focus();
                e.Handled = true;
            }

        }
        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.txtIdentityNumber.Focus();
                e.Handled = true;
            }

        }

        private void txtIdentityNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.txtContact.Focus();
                e.Handled = true;
            }

        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (this.txtUserName.Tag != null)
                {

                    this.btnChangeData.Focus();
                }
                else
                {
                    this.btnAddUser.Focus();
                }
                e.Handled = true;
            }
        }

        private void cmb_Group_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.txtUserName.Focus();
                e.Handled = true;
            }
        }



        private void btnChangeData_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (DoChangeData())
                {
                    this.btnOK.Focus();
                }
                e.Handled = true;
            }
        }

        private void btnAddUser_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (AddUser())
                {
                    this.btnOK.Focus();
                }
                e.Handled = true;
            }

        }
        private bool LoginUsers_Read(int current_pos,ref string Err)
        {
            bLoginUsers_Read = true;
            LoginUsers.Clear();
            LoginUsers.select.all(true);
            if (LoginUsers.Read(ref Err))
            {
                if (current_pos >= 0)
                {
                    LoginUsers.m_bs_dt.Position = current_pos;
                }
                bLoginUsers_Read = false;
                return true;
            }
            else
            {
                bLoginUsers_Read = false;
                return false;
            }
        }

        private void UserManager_Load(object sender, EventArgs e)
        {

            string Err = null;
            LoginUsers = new LoginDB_DataSet.LoginUsers(Login_con);
            m_LoginDB_DataSet_Procedures = new LoginDB_DataSet.LoginDB_DataSet_Procedures(Login_con);
            if (LoginUsers_Read(-1, ref Err))
            {
                dgv_LoginUsers.Rows.Clear();
                dgv_LoginUsers.DataSource = LoginUsers.m_bs_dt;
                dgv_LoginUsers.Columns[LoginDB_DataSet.LoginUsers.id.name].Visible = false;
                dgv_LoginUsers.Columns[LoginDB_DataSet.LoginUsers.password.name].Visible = false;
                dgv_LoginUsers.Columns[LoginDB_DataSet.LoginUsers.Administrator_LoginUsers_id.name].Visible = false;
                dgv_LoginUsers.Columns[LoginDB_DataSet.LoginUsers.Time_When_AdministratorSetsPassword.name].Visible = false;
                dgv_LoginUsers.Columns[LoginDB_DataSet.LoginUsers.Time_When_UserSetsItsOwnPassword_FirstTime.name].Visible = false;
                dgv_LoginUsers.Columns[LoginDB_DataSet.LoginUsers.Time_When_UserSetsItsOwnPassword_LastTime.name].Visible = false;
                LoginDB_DataSet.HeaderText.Set(dgv_LoginUsers, LoginUsers_lang.col_headers);
                DataGridViewCell dgvcell = new DataGridViewTextBoxCell();
                DataGridViewColumn dgvcol = new DataGridViewColumn(dgvcell);
                dgvcol.Name = "Password";
                dgvcol.HeaderText = lng.s_Password.s;
                dgv_LoginUsers.Columns.Insert(dgv_LoginUsers.Columns[LoginDB_DataSet.LoginUsers.password.name].Index, dgvcol);
                if (!LoginRolesReload(LoginUsers.m_bs_dt.Position, ref Err))
                {
                    LogFile.Error.Show("Error:UserManager_Load:LoginUsers.Read: Err = " + Err);
                    DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }
                return;
            }
            else
            {
                LogFile.Error.Show("Error:UserManager_Load:LoginUsers.Read: Err = " + Err);
                DialogResult = DialogResult.Cancel;
                this.Close();
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

        public bool Func_ChangeData(STD_username_Data userdata, bool bActive,ref string csError)
        {
            bool bPasswordChanged = false;
            string Err = null;

                if (LoginUsers.RowsCount > 0)
                {
                    if (userdata.password.Length >= std.lctrl.MinPasswordLength)
                    {
                        if (LoginUsers.o_password.password_ == null)
                        {
                            bPasswordChanged = true;
                        }
                        else
                        {
                            if (userdata.password_changed)
                            {
                                if (!std.lctrl.PasswordMatch(LoginUsers.o_password.password_, userdata.password))
                                {
                                    bPasswordChanged = true;
                                }
                            }
                        }
                    }
                    else
                    {

                        if ((LoginUsers.o_password.password_ == null) && ((userdata.password.Length < std.lctrl.MinPasswordLength)))
                        {
                            MessageBox.Show(lng.s_PasswordIsNotDefined_YouMustDefinePasswordThatHasAtLeastXCharactersOrNumbers1.s
                                            + std.lctrl.MinPasswordLength.ToString() +
                                            lng.s_PasswordIsNotDefined_YouMustDefinePasswordThatHasAtLeastXCharactersOrNumbers2.s);
                            return false;
                        }
                        else
                        {
                            if ((LoginUsers.o_password.password_ != null) && ((userdata.password.Length < std.lctrl.MinPasswordLength)) && ((userdata.password.Length > 0)))
                            {
                                MessageBox.Show(lng.s_YouMustDefinePasswordThatHasAtLeastXCharactersOrNumbers.s
                                              + std.lctrl.MinPasswordLength.ToString() +
                                              lng.s_PasswordIsNotDefined_YouMustDefinePasswordThatHasAtLeastXCharactersOrNumbers2.s);
                                return false;
                            }
                        }
                    }

                    string Res = null;
                    m_LoginDB_DataSet_Procedures.LoginUsers_ChangeData(LoginUsers.o_id.id_,
                                                                       userdata.FirstName,
                                                                       userdata.LastName,
                                                                       userdata.IdentityNumber,
                                                                       userdata.Contact,
                                                                       ref Res,
                                                                       ref Err);
                    if (Res.Equals("OK"))
                    {
                        m_LoginDB_DataSet_Procedures.LoginUsers_Administrator_ChangePasswordParameters(LoginUsers.o_id.id_,
                                                                                                       std.m_STDLoginData.m_LoginUsers_id,
                                                                                                       userdata.bPasswordNeverExpires,
                                                                                                       chk_Active.Checked,
                                                                                                       userdata.bChangePasswordOnFirstLogin,
                                                                                                       userdata.iMaxPasswordAge,
                                                                                                       userdata.bNotActiveAfterPasswordExpires,
                                                                                                     ref Res,
                                                                                                     ref Err);

                        if (Res.Equals("OK"))
                        {
                            if (bPasswordChanged)
                            {
                                m_LoginDB_DataSet_Procedures.LoginUsers_Administrator_ChangePassword(LoginUsers.o_id.id_,
                                                                                                     LoginControl.CalculateSHA256(userdata.password),//crypted password
                                                                                                     std.m_STDLoginData.m_LoginUsers_id,
                                                                                                     ref Res,
                                                                                                     ref Err);
                                if (Res.Equals("OK"))
                                {
                                    if (LoginUsers_Read(LoginUsers.m_bs_dt.Position, ref Err))
                                    {
                                        if (!LoginRolesReload(LoginUsers.m_bs_dt.Position, ref Err))
                                        {
                                            LogFile.Error.Show(Err);
                                        }
                                        return true;
                                    }
                                    else
                                    {
                                        LogFile.Error.Show("Error:Func_ChangeData:LoginUsers_Read: Error = " + Err);
                                        return false;
                                    }
                                }
                                else
                                {
                                    LogFile.Error.Show("Error:Func_ChangeData:LoginUsers_Administrator_ChangePassword: Res = " + Res);
                                    return false;
                                }
                            }
                            else
                            {
                                if (LoginUsers_Read(LoginUsers.m_bs_dt.Position, ref Err))
                                {
                                    if (!LoginRolesReload(LoginUsers.m_bs_dt.Position, ref Err))
                                    {
                                        LogFile.Error.Show(Err);
                                    }
                                    return true;
                                }
                                else
                                {
                                    LogFile.Error.Show("Error:Func_ChangeData:LoginUsers_Read: Error = " + Err);
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("Error:Func_ChangeData:LoginUsers_Administrator_ChangePasswordParameters: Res = " + Res);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("Error:Func_ChangeData:LoginUsers_ChangeData: Res = " + Res);
                        return false;
                    }
                    return true;
                }
                else
                {
                    LogFile.Error.Show("Error:UserManager:LoginUsers: RowsCount = 0");
                    return false;
                }
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

        private void btn_ManageRoles_Click(object sender, EventArgs e)
        {
            int iCurPos = LoginUsers.m_bs_dt.Position;
            STDRoleManager role_man = new STDRoleManager(std);
            if (role_man.ShowDialog() == DialogResult.Yes)
            {
                string Err = null;
                if (!LoginRolesReload(iCurPos,ref Err))
                {
                    LogFile.Error.Show(Err);
                }
            }
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
    }
}
