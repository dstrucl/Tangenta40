using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LogFile;
using LanguageControl;
namespace LoginControl
{
    public partial class STDRoleManager : Form
    {
        LoginDB_DataSet.LoginRoles LoginRoles = null;
        LoginDB_DataSet.LoginRoles_lang LoginRoles_lang = new LoginDB_DataSet.LoginRoles_lang();
        STD std = null;
        public STDRoleManager(STD xstd)
        {
            InitializeComponent();
            std = xstd;
            this.Text = lng.s_STDRoleManagerForm.s;
        }

        private void RoleManager_Load(object sender, EventArgs e)
        {
            string Err = null;
            if (LoginRoles == null)
            {
                LoginRoles = new LoginDB_DataSet.LoginRoles(std.Login_con);
            }
            LoginRoles.Clear();
            LoginRoles.select.all(true);
            if (LoginRoles.Read(ref Err))
            {
                dgv_Roles.DataSource = LoginRoles.m_bs_dt;
                dgv_Roles.Columns[LoginDB_DataSet.LoginRoles.id.name].Visible = false;
                LoginDB_DataSet.HeaderText.Set(dgv_Roles, LoginRoles_lang.col_headers);

            }
            else
            {
                LogFile.Error.Show(Err);
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (LoginRoles.bModified)
            {
                if (MessageBox.Show(this, lng.s_RolesDataTableIsChanged_Question_SAVE.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    string Err = null;
                    if (LoginRoles.update(ref Err))
                    {
                        DialogResult = DialogResult.Yes;
                        this.Close();
                    }
                }
                else
                {
                    DialogResult = DialogResult.No;
                    this.Close();
                }
            }
            else
            {
                DialogResult = DialogResult.No;
                this.Close();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
