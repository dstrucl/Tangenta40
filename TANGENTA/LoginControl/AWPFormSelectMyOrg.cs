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
    public partial class AWPFormSelectMyOrgPer : Form
    {
        public enum eSelectionType { NotInLoginUsers, ExistInLoginUsers };

        public ID LoginUsers_ID = null;
        public string UniqueUserName = null;

        private eSelectionType m_eSelectionType = eSelectionType.NotInLoginUsers;

        DataTable dt_myOrgPerNotInLoginUsers = new DataTable();

        public AWPFormSelectMyOrgPer(eSelectionType xeSelectionType)
        {
            InitializeComponent();
            m_eSelectionType = xeSelectionType;
            lng.s_ImportNewEmpleyees.Text(this);
            lng.s_btn_Select.Text(btn_Select);
            lbl_SelectedPerson.Text = "";
        }


        private void AWPFormSelectMyOrgPer_Load(object sender, EventArgs e)
        {
            if (m_eSelectionType == eSelectionType.NotInLoginUsers)
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
                        dgvx.ClearSelection();
                        dgvx.SelectionChanged += Dgvx_SelectionChanged;
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
            else
            {
                if (AWP_func.GetMyOrgPerThatExistsInLoginUsers(ref dt_myOrgPerNotInLoginUsers))
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
                        dgvx.ClearSelection();
                        dgvx.SelectionChanged += Dgvx_SelectionChanged;
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
        }

        private void Dgvx_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgvc = this.dgvx.SelectedRows;
            if (dgvc.Count > 0)
            {
                DataGridViewRow dgvr = dgvc[0];
                string_v firstname_v = tf.set_string(dgvr.Cells["FirstName"].Value);
                string_v lastname_v = tf.set_string(dgvr.Cells["LastName"].Value);
                this.lbl_SelectedPerson.Text = "";
                if (firstname_v != null)
                {
                    this.lbl_SelectedPerson.Text += firstname_v.v;
                }
                if (lastname_v != null)
                {
                    this.lbl_SelectedPerson.Text += " "+lastname_v.v;
                }
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
                UniqueUserName = AWP_func.GetUniqueUserName(FirstName);
                if (UniqueUserName != null)
                {
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
