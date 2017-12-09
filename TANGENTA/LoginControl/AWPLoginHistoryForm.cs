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
    public partial class AWPLoginHistoryForm : Form
    {
        AWP awp = null;
        string UserName = null;
        DataTable dtWorkingPeriod = new DataTable();
        public AWPLoginHistoryForm(AWP xawp, string xUserName)
        {
            InitializeComponent();
            awp = xawp;
            UserName = xUserName;
            lng.s_LoginHistoryForUser.Text(lbl_LoginHistory,":" + UserName);
            lng.s_LoginHistoryForUser.Text(this, ":" + UserName);
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void LoginHistoryForm_Load(object sender, EventArgs e)
        {
            
            if(AWP_func.GetWorkingPeriod(ref dtWorkingPeriod, UserName))
            {
                dgv_LoginHistory.DataSource = dtWorkingPeriod;
                foreach (DataGridViewColumn dgvc in dgv_LoginHistory.Columns)
                {
                    dgvc.Visible = false;
                    if (dgvc.Name.Equals("Atom_WorkPeriod_$$LoginTime"))
                    {
                        dgvc.HeaderText = lng.s_LoginTime.s;
                        dgvc.Visible = true;
                    }
                    else if (dgvc.Name.Equals("Atom_WorkPeriod_$$LogoutTime"))
                    {
                        dgvc.HeaderText = lng.s_LogoutTime.s;
                        dgvc.Visible = true;
                    }
                    else if (dgvc.Name.Equals("Atom_WorkPeriod_$_aed_$$Name"))
                    {
                        dgvc.HeaderText = lng.s_ElectronicDevice_ID.s;
                        dgvc.Visible = true;
                    }
                    else if (dgvc.Name.Equals("Atom_WorkPeriod_$_amcper_$_aoffice_$$Name"))
                    {
                        dgvc.HeaderText = lng.s_OfficeName.s;
                        dgvc.Visible = true;
                    }
                    else if (dgvc.Name.Equals("Atom_WorkPeriod_$_amcper_$_aoffice_$$ShortName"))
                    {
                        dgvc.HeaderText = lng.s_OfficeNameShort.s;
                        dgvc.Visible = true;
                    }
                    else if (dgvc.Name.Equals("Atom_WorkPeriod_$_acomp_$$Name"))
                    {
                        dgvc.HeaderText = lng.s_ComputerName.s;
                        dgvc.Visible = true;
                    }
                    else if (dgvc.Name.Equals("Atom_WorkPeriod_$_acomp_$$Name"))
                    {
                        dgvc.HeaderText = lng.s_ComputerName.s;
                        dgvc.Visible = true;
                    }
                    else if (dgvc.Name.Equals("Atom_WorkPeriod_$_acomp_$$UserName"))
                    {
                        dgvc.HeaderText = lng.s_ComputerUserName.s;
                        dgvc.Visible = true;
                    }
                    else if (dgvc.Name.Equals("Atom_WorkPeriod_$_acomp_$$IP_address"))
                    {
                        dgvc.HeaderText = lng.s_IP_Address.s;
                        dgvc.Visible = true;
                    }
                    else if (dgvc.Name.Equals("Atom_WorkPeriod_$_acomp_$$MAC_address"))
                    {
                        dgvc.HeaderText = lng.s_MAC_address.s;
                        dgvc.Visible = true;
                    }
                    else if (dgvc.Name.Equals("Atom_WorkPeriod_$_amcper_$_aper_$_acfn_$$FirstName"))
                    {
                        dgvc.HeaderText = lng.s_FirstName.s;
                        dgvc.Visible = true;
                    }
                    else if (dgvc.Name.Equals("Atom_WorkPeriod_$_amcper_$_aper_$_acln_$$LastName"))
                    {
                        dgvc.HeaderText = lng.s_LastName.s;
                        dgvc.Visible = true;
                    }
                }   
            }
        }
    }
}
