using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Check;
using DBConnectionControl40;

namespace LoginControl
{
    public partial class AWP_UserInfo_Form : Form
    {
        private LMOUser m_LMOUser = null;
        private AWPBindingData awpbd = null;
        private Form myParent = null;
        private string sUserName = null;
        internal AWPLoginData awpld = null;

        public AWP_UserInfo_Form( Form pParent,string sxUserName, LMOUser xLMOUser)
        {
            m_LMOUser = xLMOUser;
            InitializeComponent();
            sUserName = sxUserName;
            awpbd = AWP.awpd;


         
            myParent = pParent;


            lng.s_Max_Password_Age.Text(lbl_Max_Password_Age);
            lng.s_chk_ChangePasswordOnFirstLogIn.Text(lbl_ChangePasswordOnFirstLogIn);
            lng.s_chk_PasswordNeverExpires.Text(lbl_PaswordExpires_Never);
            lng.s_rdb_DeactivateAfterNumberOfDays.Text(lbl_DeactivateAfterNumberOfDays);
            lng.s_rdb_AfterNumberOfDays.Text(lbl_AfterNumberOfDays);

            lng.s_UserInfo.Text(this, ":" + sUserName);

            lng.s_PasswordExpires.Text(this.grp_PasswordExpires);
            lng.s_ManageUSers.Text(this);

            lng.s_ChangePassord.Text(this.btn_ChangePassword);
            lng.s_LoginHistory.Text(this.btn_LoginHistory);



            this.txtUserName.Tag = null;

            this.Icon = Properties.Resources.user;


           
            this.nmUpDn_MaxPasswordAge.Value = 90.0M;
            txtUserName.Text = "";
            //txtPassword.Text = "";
            //txtConfirmPassword.Text = "";
            this.txtUserName.Focus();
        }

        private void AWP_UserInfo_Form_Load(object sender, EventArgs e)
        {
            awpld = new AWPLoginData();
               LoadData(sUserName);
        }

        private void LoadData(string sUserName)
        {

            InitRoles();
            DataTable dtOfUserName = null;
            AWPLoginData.eGetDateResult eres = AWPLoginData.eGetDateResult.ERROR;
           
           
                dtOfUserName = new DataTable();
                eres = awpld.GetData(ref dtOfUserName, sUserName, awpbd);
           

            switch (eres)
            {

                case AWPLoginData.eGetDateResult.OK:
                case AWPLoginData.eGetDateResult.USER_HAS_NO_RULES:

                    DataTable dt = null;
                    awpld.Changed = false;
                    this.btn_ChangePassword.Visible = false;
                    dt = dtOfUserName;

                    this.txtUserName.Text = awpld.UserName;
                    this.usrc_PasswordBytes1.SetPassword(awpld.Password, 5);
                    
                    this.webBrowser1.DocumentText = awpld.GetHtml();

                    SetCheckState(chkp_ChangePasswordOnFirstLogin, awpld.ChangePasswordOnFirstLogin);
                   
                        
           
                  
                    if (awpld.PasswordNeverExpires)
                    {
                        SetCheckState(chkp_PasswordNeverExpires, true);
                        nmUpDn_MaxPasswordAge.Enabled = false;
                    }
                    if (awpld.NotActiveAfterPasswordExpires)
                    {
                        SetCheckState(chkp_PasswordNotActiveAfterNumberOfDays, true);
                        nmUpDn_MaxPasswordAge.Enabled = true;
                    }
                    if (!awpld.PasswordNeverExpires && !awpld.NotActiveAfterPasswordExpires)
                    {
                        SetCheckState(this.chkp_PasswordExpiresAfterNumbersOfDays,true);
                        nmUpDn_MaxPasswordAge.Enabled = true;
                    }

                    SetCheckState(chkp_Enabled,awpld.Enabled);

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


        }

        private void SetCheckState(check chkp, bool bValue)
        {
            if (bValue)
            {
                chkp.State = check.eState.TRUE;
            }
            else
            {
                chkp.State = check.eState.UNDEFINED;
            }
        }

        private void InitRoles()
        {
            dgvx_UserRoles.DataSource = null;
            dgvx_UserRoles.Columns.Clear();
        }
        private void SetRoles()
        {

            dgvx_UserRoles.DataSource = awpld.dt_AWP_UserRoles;
            dgvx_UserRoles.Columns[0].HeaderText = lng.s_lbl_UserRoles.s;


        }

        private void usrc_PasswordBytes1_PasswordChanged()
        {
            awpld.Changed = true;
            this.btn_ChangePassword.Visible = true;
        }

        private void btn_ChangePassword_Click(object sender, EventArgs e)
        {
            if (UpdateAWPLoginData())
            {
                XMessage.Box.Show(this, lng.s_YouHaveChangedYourPassord,MessageBoxIcon.Information);
            }
        }

        private bool UpdateAWPLoginData()
        {
            bool bRes = false;
            awpld.UserName = txtUserName.Text;
            if (usrc_PasswordBytes1.GetPassword(ref awpld.Password))
            {
                Transaction transaction_AWP_UserInfo_Form_UpdateAWPLoginData_AWP_func_Update_LoginUsers_ID = new Transaction("AWP_UserInfo_Form.UpdateAWPLoginData.AWP_func.Update_LoginUsers_ID");
                bRes = AWP_func.Update_LoginUsers_ID(awpld, usrc_PasswordBytes1.Changed, transaction_AWP_UserInfo_Form_UpdateAWPLoginData_AWP_func_Update_LoginUsers_ID);
                if (bRes)
                {
                    if (transaction_AWP_UserInfo_Form_UpdateAWPLoginData_AWP_func_Update_LoginUsers_ID.Commit())
                    {
                        awpld.Changed = false;
                        btn_ChangePassword.Visible = false;
                    }
                }
                else
                {
                    transaction_AWP_UserInfo_Form_UpdateAWPLoginData_AWP_func_Update_LoginUsers_ID.Rollback();
                }
            }
            return bRes;

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void btn_LoginHistory_Click(object sender, EventArgs e)
        {
            AWPLoginHistoryForm awphfrm = new AWPLoginHistoryForm(m_LMOUser);
            awphfrm.ShowDialog(this);
        }
    }
}
