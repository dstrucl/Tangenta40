using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tangenta
{
    public partial class Form_SettingsUsers : Form
    {
        private DataTable dtAfterLoad = null;
        private DataTable dtAfterSave = null;
        LoginControl.LoginOfMyOrgUser mLoginOfMyOrgUser = null;
        public Form_SettingsUsers(LoginControl.LoginOfMyOrgUser xLoginOfMyOrgUser)
        {
            InitializeComponent();
            mLoginOfMyOrgUser = xLoginOfMyOrgUser;
            label1.Text = "User:" + mLoginOfMyOrgUser.UserName;
        }

        public void InitAfterLoad()
        {
            dgv_AfterLoad.DataSource = null;
            ((SettingsUser)mLoginOfMyOrgUser.oSettings).mSettingsUserValues.Fill_DataTable(ref dtAfterLoad);
            dgv_AfterLoad.DataSource = dtAfterLoad;
        }

        public void InitAfterSave()
        {
            dgv_AfterSave.DataSource = null;
            ((SettingsUser)mLoginOfMyOrgUser.oSettings).mSettingsUserValues.Fill_DataTable(ref dtAfterSave);
            dgv_AfterSave.DataSource = dtAfterSave;
        }

    }
}
