using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataGridView_2xls;
using System.Windows.Forms;

namespace LoginControl
{
    internal class AWPData
    {
        AWP_UserManager frm = null;
        internal List<AWPColName> AWP_col_Names = new List<AWPColName>();

        internal AWPColName mcn_Selected = null;
        internal AWPColName mcn_Administrator = null;
        internal AWPColName mcn_myOrganisation_Person_office_Name = null;
        internal AWPColName mcn_myOrganisation_Person__office_ShortName = null;
        internal AWPColName mcn_myOrganisation_Person_UserName = null;
        internal AWPColName mcn_myOrganisation_Person__per__cfn_FirstName = null;
        internal AWPColName mcn_myOrganisation_Person__per__cln_LastName = null;
        internal AWPColName mcn_myOrganisation_Person__per_Tax_ID = null;
        internal AWPColName mcn_myOrganisation_Person__per_Registration_ID = null;
        internal AWPColName mcn_myOrganisation_Person_Active = null;
        internal AWPColName mcn_myOrganisation_Person_Job = null;
        internal AWPColName mcn_myOrganisation_Person_Description = null;
        internal AWPColName mcn_myOrganisation_Person__per_DateOfBirth = null;
        internal AWPColName mcn_myOrganisation_Person__per_Gender = null;
        internal AWPColName mcn_PersonData__cemailper_Email = null;
        internal AWPColName mcn_PersonData__cgsmnper_GsmNumber = null;
        internal AWPColName mcn_PersonData__cphnnper_PhoneNumber = null;
        internal AWPColName mcn_PersonData__cadrper__cstrnper_StreetName = null;
        internal AWPColName mcn_PersonData__cadrper__chounper_HouseNumber = null;
        internal AWPColName mcn_PersonData__cadrper__zipper_ZIP = null;
        internal AWPColName mcn_PersonData__cadrper__ccitper_City = null;
        internal AWPColName mcn_PersonData__cadrper__cstper_Country = null;
        internal AWPColName mcn_PersonData__cadrper__ccouper_State = null;
        internal AWPColName mcn_PersonData_Description = null;
        internal AWPColName mcn_PersonData__cardtper_CardType = null;
        internal AWPColName mcn_PersonData_CardNumber = null;
        internal AWPColName mcn_myOrganisation_Person_ID = null;

        //Columns from LoginUsers Table
        internal AWPColName mcn_PasswordNeverExpires = null;
        internal AWPColName mcn_Enabled = null;
        internal AWPColName mcn_Time_When_AdministratorSetsPassword = null;
        internal AWPColName mcn_Time_When_UserSetsItsOwnPassword_FirstTime = null;
        internal AWPColName mcn_Time_When_UserSetsItsOwnPassword_LastTime = null;
        internal AWPColName mcn_Administrator_LoginUsers_ID = null;
        internal AWPColName mcn_ChangePasswordOnFirstLogin = null;
        internal AWPColName mcn_Maximum_password_age_in_days = null;
        internal AWPColName mcn_NotActiveAfterPasswordExpires = null;


        internal AWPData(AWP_UserManager xfrm)
        {
            frm = xfrm;
            AWP_col_Names.Clear();
            int i=0;
            mcn_Selected = new AWPColName("Selected", lng.cn_Selected, i++, null, null);
            mcn_Administrator = new AWPColName("Administrator", lng.cn_Administrator, i++, null, null);
            mcn_myOrganisation_Person_office_Name = new AWPColName("myOrganisation_Person_$_office_$$Name", lng.cn_myOrganisation_Person_office_Name, i++, frm.lbl_Office, frm.cmb_Office);
            mcn_myOrganisation_Person__office_ShortName = new AWPColName("myOrganisation_Person_$_office_$$ShortName", lng.cn_myOrganisation_Person__office_ShortName, i++, frm.lbl_OfficeShortName, frm.txt_OfficeShortName);
            mcn_myOrganisation_Person_UserName = new AWPColName("myOrganisation_Person_$$UserName", lng.cn_myOrganisation_Person_UserName, i++, frm.lbl_UserName, frm.txtUserName);
            mcn_myOrganisation_Person__per__cfn_FirstName = new AWPColName("myOrganisation_Person_$_per_$_cfn_$$FirstName", lng.cn_myOrganisation_Person__per__cfn_FirstName, i++, frm.lbl_UserFirstName, frm.txtFirstName);
            mcn_myOrganisation_Person__per__cln_LastName = new AWPColName("myOrganisation_Person_$_per_$_cln_$$LastName", lng.cn_myOrganisation_Person__per__cln_LastName, i++, frm.lbl_UserLastName, frm.txtLastName);
            mcn_myOrganisation_Person__per_Tax_ID = new AWPColName("myOrganisation_Person_$_per_$$Tax_ID", lng.cn_myOrganisation_Person__per_Tax_ID, i++, frm.lbl_UserTax_ID, frm.lbl_UserTax_ID);
            mcn_myOrganisation_Person__per_Registration_ID = new AWPColName("myOrganisation_Person_$_per_$$Registration_ID", lng.cn_myOrganisation_Person__per_Registration_ID, i++, frm.lbl_UserIdentity, frm.txtIdentityNumber);
            mcn_Enabled = new AWPColName("Enabled", lng.cn_myOrganisation_Person_Active, i++, frm.chk_Enabled, frm.chk_Enabled);
            mcn_myOrganisation_Person_Active = new AWPColName("myOrganisation_Person_$$Active", lng.cn_myOrganisation_Person_Active, i++, frm.chk_Active, frm.chk_Active);
            mcn_myOrganisation_Person_Job = new AWPColName("myOrganisation_Person_$$Job", lng.cn_myOrganisation_Person_Job, i++, frm.lbl_Job, frm.txt_Job);
            mcn_myOrganisation_Person_Description = new AWPColName("myOrganisation_Person_$$Description", lng.cn_myOrganisation_Person_Description, i++, frm.lbl_Description, frm.txt_Description);
            mcn_myOrganisation_Person__per_DateOfBirth = new AWPColName("myOrganisation_Person_$_per_$$DateOfBirth", lng.cn_myOrganisation_Person__per_DateOfBirth, i++, frm.lbl_DateOfBirth, frm.dtp_DateOfBirth);
            mcn_myOrganisation_Person__per_Gender = new AWPColName("myOrganisation_Person_$_per_$$Gender", lng.cn_myOrganisation_Person__per_Gender, i++, frm.lbl_Gender, frm.usrc_SelectGender1);
            mcn_PersonData__cemailper_Email = new AWPColName("PersonData_$_cemailper_$$Email", lng.cn_PersonData__cemailper_Email, i++, frm.lbl_Email, frm.txt_Email);
            mcn_PersonData__cgsmnper_GsmNumber = new AWPColName("PersonData_$_cgsmnper_$$GsmNumber", lng.cn_PersonData__cgsmnper_GsmNumber, i++, frm.lbl_Gsm, frm.txt_GSM);
            mcn_PersonData__cphnnper_PhoneNumber = new AWPColName("PersonData_$_cphnnper_$$PhoneNumber", lng.cn_PersonData__cphnnper_PhoneNumber, i++, frm.lbl_Tel, frm.txt_TEL);
            mcn_PersonData__cadrper__cstrnper_StreetName = new AWPColName("PersonData_$_cadrper_$_cstrnper_$$StreetName", lng.cn_PersonData__cadrper__cstrnper_StreetName, i++, frm.lbl_Street, frm.txt_StreetName);
            mcn_PersonData__cadrper__chounper_HouseNumber = new AWPColName("PersonData_$_cadrper_$_chounper_$$HouseNumber", lng.cn_PersonData__cadrper__chounper_HouseNumber, i++, frm.lbl_HouseNumber, frm.txt_HouseNumber);
            mcn_PersonData__cadrper__zipper_ZIP = new AWPColName("PersonData_$_cadrper_$_zipper_$$ZIP", lng.cn_PersonData__cadrper__zipper_ZIP, i++, frm.lbl_ZIP, frm.txt_ZIP);
            mcn_PersonData__cadrper__ccitper_City = new AWPColName("PersonData_$_cadrper_$_ccitper_$$City", lng.cn_PersonData__cadrper__ccitper_City, i++, frm.lbl_City, frm.txt_City);
            mcn_PersonData__cadrper__cstper_Country = new AWPColName("PersonData_$_cadrper_$_cstper_$$Country", lng.cn_PersonData__cadrper__cstper_Country, i++, frm.lbl_Country, frm.cmb_Country);
            mcn_PersonData__cadrper__ccouper_State = new AWPColName("PersonData_$_cadrper_$_ccouper_$$State", lng.cn_PersonData__cadrper__ccouper_State, i++, frm.lbl_State, frm.txt_State);
            mcn_PersonData_Description = new AWPColName("PersonData_$$Description", lng.cn_PersonData_Description, i++, null, null);
            mcn_PersonData__cardtper_CardType = new AWPColName("PersonData_$_cardtper_$$CardType", lng.cn_PersonData__cardtper_CardType, i++, null, null);
            mcn_PersonData_CardNumber = new AWPColName("PersonData_$$CardNumber", lng.cn_PersonData_CardNumber, i++, null, null);
            mcn_myOrganisation_Person_ID = new AWPColName("myOrganisation_Person_ID", null, i++, null, null);
            mcn_PasswordNeverExpires = new AWPColName("PasswordNeverExpires", null, i++, frm.rdb_PaswordExpires_Never, frm.rdb_PaswordExpires_Never);
            mcn_Time_When_AdministratorSetsPassword = new AWPColName("Time_When_AdministratorSetsPassword", null, i++, null, null);
            mcn_Time_When_UserSetsItsOwnPassword_FirstTime = new AWPColName("Time_When_UserSetsItsOwnPassword_FirstTime", null, i++, null, null);
            mcn_Time_When_UserSetsItsOwnPassword_LastTime = new AWPColName("Time_When_UserSetsItsOwnPassword_LastTime", null, i++, null, null);
            mcn_Administrator_LoginUsers_ID = new AWPColName("Administrator_LoginUsers_ID", null, i++, null, null);
            mcn_ChangePasswordOnFirstLogin = new AWPColName("ChangePasswordOnFirstLogin", null, i++, frm.chk_ChangePasswordOnFirstLogIn, frm.chk_ChangePasswordOnFirstLogIn);
            mcn_Maximum_password_age_in_days = new AWPColName("Maximum_password_age_in_days", null, i++, frm.lbl_Max_Password_Age, frm.nmUpDn_MaxPasswordAge);
            mcn_NotActiveAfterPasswordExpires = new AWPColName("NotActiveAfterPasswordExpires", null, i++, frm.rdb_DeactivateAfterNumberOfDays, frm.rdb_DeactivateAfterNumberOfDays);






            AWP_col_Names.Add(mcn_Selected);
            AWP_col_Names.Add(mcn_Administrator);
            AWP_col_Names.Add(mcn_myOrganisation_Person_office_Name);
            AWP_col_Names.Add(mcn_myOrganisation_Person__office_ShortName);
            AWP_col_Names.Add(mcn_myOrganisation_Person_UserName);
            AWP_col_Names.Add(mcn_myOrganisation_Person__per__cfn_FirstName);
            AWP_col_Names.Add(mcn_myOrganisation_Person__per__cln_LastName);
            AWP_col_Names.Add(mcn_myOrganisation_Person__per_Tax_ID);
            AWP_col_Names.Add(mcn_myOrganisation_Person__per_Registration_ID);
            AWP_col_Names.Add(mcn_Enabled);
            AWP_col_Names.Add(mcn_myOrganisation_Person_Active);
            AWP_col_Names.Add(mcn_myOrganisation_Person_Job);
            AWP_col_Names.Add(mcn_myOrganisation_Person_Description);
            AWP_col_Names.Add(mcn_myOrganisation_Person__per_DateOfBirth);
            AWP_col_Names.Add(mcn_myOrganisation_Person__per_Gender);
            AWP_col_Names.Add(mcn_PersonData__cemailper_Email);
            AWP_col_Names.Add(mcn_PersonData__cgsmnper_GsmNumber);
            AWP_col_Names.Add(mcn_PersonData__cphnnper_PhoneNumber);
            AWP_col_Names.Add(mcn_PersonData__cadrper__cstrnper_StreetName);
            AWP_col_Names.Add(mcn_PersonData__cadrper__chounper_HouseNumber);
            AWP_col_Names.Add(mcn_PersonData__cadrper__zipper_ZIP);
            AWP_col_Names.Add(mcn_PersonData__cadrper__ccitper_City);
            AWP_col_Names.Add(mcn_PersonData__cadrper__cstper_Country);
            AWP_col_Names.Add(mcn_PersonData__cadrper__ccouper_State);
            AWP_col_Names.Add(mcn_PersonData_Description);
            AWP_col_Names.Add(mcn_PersonData__cardtper_CardType);
            AWP_col_Names.Add(mcn_PersonData_CardNumber);
            AWP_col_Names.Add(mcn_myOrganisation_Person_ID);
            AWP_col_Names.Add(mcn_PasswordNeverExpires);
            AWP_col_Names.Add(mcn_Time_When_AdministratorSetsPassword );
            AWP_col_Names.Add(mcn_Time_When_UserSetsItsOwnPassword_FirstTime);
            AWP_col_Names.Add(mcn_Time_When_UserSetsItsOwnPassword_LastTime);
            AWP_col_Names.Add(mcn_Administrator_LoginUsers_ID);
            AWP_col_Names.Add(mcn_ChangePasswordOnFirstLogin);
            AWP_col_Names.Add(mcn_Maximum_password_age_in_days);
            AWP_col_Names.Add(mcn_NotActiveAfterPasswordExpires);

        }

        internal void SetControls(DataGridView2xls dgv_LoginUsers, DataRow dataRow,string TableName)
        {
            foreach (DataGridViewColumn dgvc in dgv_LoginUsers.Columns)
            {
                dgvc.Visible = false;
            }
            foreach (AWPColName awpcn in AWP_col_Names)
            {
                if (awpcn.ColumnName.Equals(mcn_Selected.ColumnName))
                {
                    continue;
                }
                else if (awpcn.ColumnName.Equals(mcn_Administrator.ColumnName))
                {
                    continue;
                }
                else
                {
                    try
                    {
                        dgv_LoginUsers.Columns[awpcn.ColumnName].Visible = true;
                        dgv_LoginUsers.Columns[awpcn.ColumnName].HeaderText = awpcn.NameInLanguage.s;
                    }
                    catch (Exception ex)
                    {
                        LogFile.Error.Show("ERROR:LoginControl:AWPData:SetControls: awpcn.ColumnName = " + awpcn.ColumnName + " not in dgv_LoginUsers!\r\nException =" + ex.Message);
                    }

                    try
                    {
                        if (awpcn.lbl_ctrl!=null)
                        {
                            if (awpcn.lbl_ctrl is Label)
                            {
                                if (awpcn.NameInLanguage != null)
                                {
                                    awpcn.NameInLanguage.Text(awpcn.lbl_ctrl);
                                }
                            }
                        }
                        if (awpcn.edit_ctrl != null)
                        {
                            if (awpcn.edit_ctrl is TextBox)
                            {
                                object o = dataRow[awpcn.ColumnName];
                                if (o is string)
                                {
                                    awpcn.edit_ctrl.Text = (string)o;
                                }
                                else
                                {
                                    awpcn.edit_ctrl.Text = "";
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogFile.Error.Show("ERROR:LoginControl:AWPData:SetControls: awpcn.ColumnName = " + awpcn.ColumnName + " not in dataRow!\r\nException =" + ex.Message);
                    }
                }
            }
        }
    }
}
