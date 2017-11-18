using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBConnectionControl40;

namespace LoginControl
{
    public partial class EditLoginData_Form : Form
    {
        LoginDB_DataSet.LoginUsers LoginUsers = null;
        private DBConnection my_con;
        public EditLoginData_Form(DBConnection con)
        {
            my_con = con;
            InitializeComponent();
        }

        private void EditLoginData_Form_Load(object sender, EventArgs e)
        {
            string Err = null;
            LoginUsers = new LoginDB_DataSet.LoginUsers(my_con);
            LoginUsers.Clear();
            LoginUsers.select.all(true);
            if (LoginUsers.Read(ref Err))
            {
                dgv_Users.DataSource = LoginUsers.m_bs_dt;
                dgv_Users.Columns[LoginDB_DataSet.LoginUsers.id.name].Visible = false;
                dgv_Users.Columns[LoginDB_DataSet.LoginUsers.password.name].Visible = false;
                dgv_Users.Columns[LoginDB_DataSet.LoginUsers.Time_When_UserSetsItsOwnPassword_FirstTime.name].ReadOnly = true;
                dgv_Users.Columns[LoginDB_DataSet.LoginUsers.Time_When_UserSetsItsOwnPassword_FirstTime.name].DefaultCellStyle.BackColor = Color.LightGray;
                dgv_Users.Columns[LoginDB_DataSet.LoginUsers.Time_When_UserSetsItsOwnPassword_LastTime.name].ReadOnly = true;
                dgv_Users.Columns[LoginDB_DataSet.LoginUsers.Time_When_UserSetsItsOwnPassword_LastTime.name].DefaultCellStyle.BackColor = Color.LightGray;
            }
            else
            {
                LogFile.Error.Show(Err);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
