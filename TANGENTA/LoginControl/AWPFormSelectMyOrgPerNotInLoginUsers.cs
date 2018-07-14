using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoginControl
{
    public partial class AWPFormSelectMyOrgPerNotInLoginUsers : Form
    {
        DataTable dt_myOrgPerNotInLoginUsers = new DataTable();

        public AWPFormSelectMyOrgPerNotInLoginUsers()
        {
            InitializeComponent();
            lng.s_ImportNewEmpleyees.Text(this);
        }


        private void AWPFormSelectMyOrganisationPersonNotInLoginUsers_Load(object sender, EventArgs e)
        {
            if (AWP_func.GetMyOrgPerNotInLoginUsers(ref dt_myOrgPerNotInLoginUsers))
            {
                if (dt_myOrgPerNotInLoginUsers.Rows.Count > 0)
                {
                    dgvx.DataSource = dt_myOrgPerNotInLoginUsers;
                    dgvx.Columns["FirstName"].HeaderText = lng.s_FirstName.s;
                    dgvx.Columns["LastName"].HeaderText = lng.s_LastName.s;
                    dgvx.Columns["Tax_ID"].HeaderText = lng.s_Tax_ID.s;
                    dgvx.Columns["Registration_ID"].HeaderText = lng.s_Registration_ID.s;
                    dgvx.Columns["DateOfBirth"].HeaderText = lng.s_DateOfBirth.s;
                    dgvx.Columns["ID"].Visible = false;
                }
                else
                {
                    DialogResult = DialogResult.No;
                    Close();
                    return;
                }
            }
            else
            {
                DialogResult = DialogResult.Abort;
                Close();
                return;
            }


        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgvxrows = dgvx.SelectedRows;
            DataRow[] drs = new DataRow[dgvxrows.Count];
            int i = 0;
            foreach (DataGridViewRow dgvxr in dgvxrows)
            {
                drs[i] = dt_myOrgPerNotInLoginUsers.Rows[dgvxr.Index];
                i++;
            }
            int iCount = i;
            for (i=0;i<iCount;i++)
            {
                ID myOrganisation_Person_ID = tf.set_ID(drs[i]["ID"]);
                string FirstName = (string)drs[i]["FirstName"];
                string UniqueUserName = AWP_func.GetUniqueUserName(FirstName);
                if (UniqueUserName != null)
                {
                    ID LoginUsers_ID = null;
                    if (AWP_func.InsertNewDefaultLoginUsersRow(myOrganisation_Person_ID, UniqueUserName, ref LoginUsers_ID))
                    {
                        continue;
                    }
                    else
                    {
                        // Error
                        DialogResult = DialogResult.Abort;
                        Close();
                        return;
                    }
                }
            }
            DialogResult = DialogResult.OK;
            Close();
            return;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
