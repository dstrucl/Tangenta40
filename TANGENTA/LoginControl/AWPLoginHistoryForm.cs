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
        LMOUser m_LMOUser = null;
        string UserName = null;
        DataTable dtWorkingPeriod = new DataTable();
        DateTime date_From;
        DateTime date_To;
        public AWPLoginHistoryForm(LMOUser xLMOUser)
        {
            InitializeComponent();
            m_LMOUser = xLMOUser;
            UserName = m_LMOUser.UserName;
            date_To = DateTime.Now;
            date_From = date_To.AddMonths(-1);
            dtp_To.Value = date_To;
            dtp_From.Value = date_From;
            

            lng.s_LoginHistoryForUser.Text(lbl_LoginHistory,":" + UserName);
            lng.s_LoginHistoryForUser.Text(this, ":" + UserName);
            lng.s_TotalWorkTime.Text(lbl_TotalTimeSpan);
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Reload(ref TimeSpan timespan)
        {
            date_From = dtp_From.Value;
            date_To = dtp_To.Value;
            date_To = date_To.AddDays(1);

            dgv_LoginHistory.DataSource = null;

            if (dtWorkingPeriod != null)
            {
                dtWorkingPeriod.Rows.Clear();
                dtWorkingPeriod.Columns.Clear();
            }
            timespan = TimeSpan.Zero;
            if (AWP_func.GetWorkingPeriod(ref dtWorkingPeriod, date_From, date_To, UserName))
            {
                DataColumn dcol = new DataColumn("Duration", typeof(string));
                dtWorkingPeriod.Columns.Add(dcol);

                foreach (DataRow dr in dtWorkingPeriod.Rows)
                {
                    object oLoginTime = dr["Atom_WorkPeriod_$$LoginTime"];
                    if (oLoginTime is DateTime)
                    {
                        DateTime time_From = (DateTime)oLoginTime;
                        object oLogoutTime = dr["Atom_WorkPeriod_$$LogoutTime"];
                        if (oLogoutTime is DateTime)
                        {
                            DateTime time_To = (DateTime)oLogoutTime;
                            TimeSpan ts = time_To - time_From;
                            timespan = timespan.Add(ts);
                            dr["Duration"] = ts.Hours + " h , " + ts.Minutes.ToString() + " min , " + ts.Seconds.ToString() + " sec";
                        }
                    }
                }

                int iHours = Convert.ToInt32(timespan.TotalHours);
                lbl_WorkHoursResult.Text = iHours.ToString() + "h , " + timespan.Minutes.ToString() + "min ";
                dgv_LoginHistory.DataSource = dtWorkingPeriod;

                foreach (DataGridViewColumn dgvc in dgv_LoginHistory.Columns)
                {
                    dgvc.Visible = false;
                    if (dgvc.Name.Equals("Duration"))
                    {
                        dgvc.HeaderText = lng.s_Duration.s;
                        dgvc.Visible = true;
                        dgvc.DisplayIndex = 2;
                    }
                    else if (dgvc.Name.Equals("Atom_WorkPeriod_$$LoginTime"))
                    {
                        dgvc.HeaderText = lng.s_LoginTime.s;
                        dgvc.Visible = true;
                        dgvc.DisplayIndex = 0;
                    }
                    else if (dgvc.Name.Equals("Atom_WorkPeriod_$$LogoutTime"))
                    {
                        dgvc.HeaderText = lng.s_LogoutTime.s;
                        dgvc.Visible = true;
                        dgvc.DisplayIndex = 1;
                    }
                    else if (dgvc.Name.Equals("Atom_WorkPeriod_$_aed_$$Name"))
                    {
                        dgvc.HeaderText = lng.s_ElectronicDevice_ID.s;
                        dgvc.Visible = true;
                        dgvc.DisplayIndex = 3;
                    }
                    else if (dgvc.Name.Equals("Atom_WorkPeriod_$_amcper_$_aoffice_$$Name"))
                    {
                        dgvc.HeaderText = lng.s_OfficeName.s;
                        dgvc.Visible = true;
                        dgvc.DisplayIndex = 4;
                    }
                    else if (dgvc.Name.Equals("Atom_WorkPeriod_$_amcper_$_aoffice_$$ShortName"))
                    {
                        dgvc.HeaderText = lng.s_OfficeNameShort.s;
                        dgvc.Visible = true;
                        dgvc.DisplayIndex = 5;
                    }
                    else if (dgvc.Name.Equals("Atom_WorkPeriod_$_acomp_$_acn_$$Name"))
                    {
                        dgvc.HeaderText = lng.s_ComputerName.s;
                        dgvc.Visible = true;
                        dgvc.DisplayIndex = 6;
                    }
                    else if (dgvc.Name.Equals("Atom_WorkPeriod_$_acomp_$_acun_$$UserName"))
                    {
                        dgvc.HeaderText = lng.s_ComputerUserName.s;
                        dgvc.Visible = true;
                        dgvc.DisplayIndex = 8;
                    }
                    else if (dgvc.Name.Equals("Atom_WorkPeriod_$_acomp_$$IP_address"))
                    {
                        dgvc.HeaderText = lng.s_IP_Address.s;
                        dgvc.Visible = true;
                        dgvc.DisplayIndex = 9;
                    }
                    else if (dgvc.Name.Equals("Atom_WorkPeriod_$_acomp_$_amac_$$Mac_address"))
                    {
                        dgvc.HeaderText = lng.s_MAC_address.s;
                        dgvc.Visible = true;
                        dgvc.DisplayIndex = 10;
                    }
                    else if (dgvc.Name.Equals("Atom_WorkPeriod_$_amcper_$_aper_$_acfn_$$FirstName"))
                    {
                        dgvc.HeaderText = lng.s_FirstName.s;
                        dgvc.Visible = true;
                        dgvc.DisplayIndex = 11;
                    }
                    else if (dgvc.Name.Equals("Atom_WorkPeriod_$_amcper_$_aper_$_acln_$$LastName"))
                    {
                        dgvc.HeaderText = lng.s_LastName.s;
                        dgvc.Visible = true;
                        dgvc.DisplayIndex = 12;
                    }
                }
            }
        }
        private void LoginHistoryForm_Load(object sender, EventArgs e)
        {
            TimeSpan tsAll = TimeSpan.Zero;
            Reload(ref tsAll);
           
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            TimeSpan tsAll = TimeSpan.Zero;
            Reload(ref tsAll);
        }
    }
}
