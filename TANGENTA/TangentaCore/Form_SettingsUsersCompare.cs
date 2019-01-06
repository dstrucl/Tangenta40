using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentManager
{
    public partial class Form_SettingsUsersCompare : Form
    {
        private DataTable dtAfterLoad = null;
        private DataTable dtAfterSave = null;
        LoginControl.LMOUser mLMOUser = null;
        public Form_SettingsUsersCompare(LoginControl.LMOUser xLMOUser)
        {
            InitializeComponent();
            mLMOUser = xLMOUser;
            label1.Text = "User:" + mLMOUser.UserName;
        }

        public void InitAfterLoad()
        {
            dgv_AfterLoad.DataSource = null;
            ((SettingsUser)mLMOUser.oSettings).mSettingsUserValues.Fill_DataTable(ref dtAfterLoad);
            dgv_AfterLoad.DataSource = dtAfterLoad;
        }

        public void InitAfterSave()
        {
            dgv_AfterSave.DataSource = null;
            ((SettingsUser)mLMOUser.oSettings).mSettingsUserValues.Fill_DataTable(ref dtAfterSave);
            dgv_AfterSave.DataSource = dtAfterSave;
        }

    }
}
