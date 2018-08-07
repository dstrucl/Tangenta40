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
        private DataTable dtSettingsUsers = null;
        private DataTable dtAfterSave = null;
        LoginControl.LMOUser mLMOUser = null;
        public Form_SettingsUsers(LoginControl.LMOUser xLMOUser)
        {
            InitializeComponent();
            mLMOUser = xLMOUser;
            label1.Text = lng.s_UserName.s +":"+ mLMOUser.UserName;
        }

        public void Init()
        {
            dgv_USet.DataSource = null;
            ((SettingsUser)mLMOUser.oSettings).mSettingsUserValues.Fill_DataTable(ref dtSettingsUsers);
            dgv_USet.DataSource = dtSettingsUsers;

            dgv_USet.Columns["Name"].ReadOnly = true;
            dgv_USet.Columns["Type"].ReadOnly = true;
            dgv_USet.Columns["Value"].ReadOnly = false;

            dgv_USet.Columns["Name"].HeaderText = lng.s_SettingsUser_Name.s;
            dgv_USet.Columns["Type"].HeaderText = lng.s_SettingsUser_Type.s; 
            dgv_USet.Columns["Value"].HeaderText = lng.s_SettingsUser_Value.s;
            dgv_USet.Columns["ReadOnly"].Visible = false;

        }

        private void dgv_AfterLoad_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                if ((bool)dgv_USet.Rows[e.RowIndex].Cells["ReadOnly"].Value)
                {
                    dgv_USet.Rows[e.RowIndex].ReadOnly = true;
                    foreach (DataGridViewCell dgvc in dgv_USet.Rows[e.RowIndex].Cells)
                    {
                        dgvc.Style.BackColor = Color.Gray;
                    }
                }
                else
                {
                    dgv_USet.Rows[e.RowIndex].ReadOnly = false;
                    dgv_USet.Rows[e.RowIndex].Cells["Value"].Style.BackColor = Color.White;
                }
            }
        }
    }
}
