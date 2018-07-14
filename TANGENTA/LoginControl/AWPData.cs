using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataGridView_2xls;
using System.Windows.Forms;

namespace LoginControl
{
    internal class AWPBindingData
    {
        AWP_UserManager frm = null;
        internal List<AWPColName> AWP_col_Names = new List<AWPColName>();

        internal AWPColName mcn_Selected = null;
        internal AWPColName mcn_Administrator = null;
        internal AWPColName mcn_myOrganisation_Person_office_Name = null;
        internal AWPColName mcn_myOrganisation_Person__office_ShortName = null;
        internal AWPColName mcn_ID = null;
        internal AWPColName mcn_UserName = null;
        internal AWPColName mcn_Password = null;
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


        internal AWPColName mcn_myOrganisation_Person__per_ID = null;
        internal AWPColName mcn_myOrganisation_Person__per__cfn_ID = null;
        internal AWPColName mcn_myOrganisation_Person__per__cln_ID = null;
        internal AWPColName mcn_myOrganisation_Person__office_ID = null;
        internal AWPColName mcn_myOrganisation_Person__office_Name = null;
        internal AWPColName mcn_PersonData_ID = null;
        internal AWPColName mcn_PersonData__cphnnper_ID = null;
        internal AWPColName mcn_PersonData__cemailper_ID = null;
        internal AWPColName mcn_PersonData__cadrper_ID = null;
        internal AWPColName mcn_PersonData__cadrper__cstrnper_ID = null;
        internal AWPColName mcn_PersonData__cadrper__chounper_ID = null;
        internal AWPColName mcn_PersonData__cadrper__ccitper_ID = null;
        internal AWPColName mcn_PersonData__cadrper__zipper_ID = null;
        internal AWPColName mcn_PersonData__cadrper__cstper_ID = null;
        internal AWPColName mcn_PersonData__cadrper__cstper_Country_ISO_3166_a2 = null;
        internal AWPColName mcn_PersonData__cadrper__cstper_Country_ISO_3166_a3 = null;
        internal AWPColName mcn_PersonData__cadrper__ccouper_ID = null;
        internal AWPColName mcn_PersonData__cardtper_ID = null;
        internal AWPColName mcn_PersonData__perimg_ID = null;
        internal AWPColName mcn_PersonData__perimg_Image_Hash = null;
        internal AWPColName mcn_PersonData__perimg_Image_Data = null;

        internal List<AWPRole> AllRoles = null;




        internal AWPBindingData()
        {

            AWP_col_Names.Clear();
            int i=0;
            mcn_Selected = new AWPColName("Selected", lng.cn_Selected, i++);
            mcn_Administrator = new AWPColName("Administrator", lng.cn_Administrator, i++);
            mcn_myOrganisation_Person_office_Name = new AWPColName("myOrganisation_Person_$_office_$$Name", lng.cn_myOrganisation_Person_office_Name, i++);
            mcn_myOrganisation_Person__office_ShortName = new AWPColName("myOrganisation_Person_$_office_$$ShortName", lng.cn_myOrganisation_Person__office_ShortName, i++);
            mcn_UserName = new AWPColName("UserName", lng.cn_myOrganisation_Person_UserName, i++);
            mcn_myOrganisation_Person__per__cfn_FirstName = new AWPColName("myOrganisation_Person_$_per_$_cfn_$$FirstName", lng.cn_myOrganisation_Person__per__cfn_FirstName, i++);
            mcn_myOrganisation_Person__per__cln_LastName = new AWPColName("myOrganisation_Person_$_per_$_cln_$$LastName", lng.cn_myOrganisation_Person__per__cln_LastName, i++);
            mcn_myOrganisation_Person__per_Tax_ID = new AWPColName("myOrganisation_Person_$_per_$$Tax_ID", lng.cn_myOrganisation_Person__per_Tax_ID, i++);
            mcn_myOrganisation_Person__per_Registration_ID = new AWPColName("myOrganisation_Person_$_per_$$Registration_ID", lng.cn_myOrganisation_Person__per_Registration_ID, i++);
            mcn_Enabled = new AWPColName("Enabled", lng.cn_Enabled, i++);
            mcn_myOrganisation_Person_Active = new AWPColName("myOrganisation_Person_$$Active", lng.cn_myOrganisation_Person_Active, i++);
            mcn_myOrganisation_Person_Job = new AWPColName("myOrganisation_Person_$$Job", lng.cn_myOrganisation_Person_Job, i++);
            mcn_myOrganisation_Person_Description = new AWPColName("myOrganisation_Person_$$Description", lng.cn_myOrganisation_Person_Description, i++);
            mcn_myOrganisation_Person__per_DateOfBirth = new AWPColName("myOrganisation_Person_$_per_$$DateOfBirth", lng.cn_myOrganisation_Person__per_DateOfBirth, i++);
            mcn_myOrganisation_Person__per_Gender = new AWPColName("myOrganisation_Person_$_per_$$Gender", lng.cn_myOrganisation_Person__per_Gender, i++);
            mcn_PersonData__cemailper_Email = new AWPColName("PersonData_$_cemailper_$$Email", lng.cn_PersonData__cemailper_Email, i++);
            mcn_PersonData__cgsmnper_GsmNumber = new AWPColName("PersonData_$_cgsmnper_$$GsmNumber", lng.cn_PersonData__cgsmnper_GsmNumber, i++);
            mcn_PersonData__cphnnper_PhoneNumber = new AWPColName("PersonData_$_cphnnper_$$PhoneNumber", lng.cn_PersonData__cphnnper_PhoneNumber, i++);
            mcn_PersonData__cadrper__cstrnper_StreetName = new AWPColName("PersonData_$_cadrper_$_cstrnper_$$StreetName", lng.cn_PersonData__cadrper__cstrnper_StreetName, i++);
            mcn_PersonData__cadrper__chounper_HouseNumber = new AWPColName("PersonData_$_cadrper_$_chounper_$$HouseNumber", lng.cn_PersonData__cadrper__chounper_HouseNumber, i++);
            mcn_PersonData__cadrper__zipper_ZIP = new AWPColName("PersonData_$_cadrper_$_zipper_$$ZIP", lng.cn_PersonData__cadrper__zipper_ZIP, i++);
            mcn_PersonData__cadrper__ccitper_City = new AWPColName("PersonData_$_cadrper_$_ccitper_$$City", lng.cn_PersonData__cadrper__ccitper_City, i++);
            mcn_PersonData__cadrper__cstper_Country = new AWPColName("PersonData_$_cadrper_$_cstper_$$Country", lng.cn_PersonData__cadrper__cstper_Country, i++);
            mcn_PersonData__cadrper__ccouper_State = new AWPColName("PersonData_$_cadrper_$_ccouper_$$State", lng.cn_PersonData__cadrper__ccouper_State, i++);
            mcn_PersonData_Description = new AWPColName("PersonData_$$Description", lng.cn_PersonData_Description, i++);
            mcn_PersonData__cardtper_CardType = new AWPColName("PersonData_$_cardtper_$$CardType", lng.cn_PersonData__cardtper_CardType, i++);
            mcn_PersonData_CardNumber = new AWPColName("PersonData_$$CardNumber", lng.cn_PersonData_CardNumber, i++);
            mcn_myOrganisation_Person_ID = new AWPColName("myOrganisation_Person_ID", null, i++);
            mcn_PasswordNeverExpires = new AWPColName("PasswordNeverExpires", null, i++);
            mcn_Time_When_AdministratorSetsPassword = new AWPColName("Time_When_AdministratorSetsPassword", null, i++);
            mcn_Time_When_UserSetsItsOwnPassword_FirstTime = new AWPColName("Time_When_UserSetsItsOwnPassword_FirstTime", null, i++);
            mcn_Time_When_UserSetsItsOwnPassword_LastTime = new AWPColName("Time_When_UserSetsItsOwnPassword_LastTime", null, i++);
            mcn_Administrator_LoginUsers_ID = new AWPColName("Administrator_LoginUsers_ID", null, i++);
            mcn_ChangePasswordOnFirstLogin = new AWPColName("ChangePasswordOnFirstLogin", null, i++);
            mcn_Maximum_password_age_in_days = new AWPColName("Maximum_password_age_in_days", null, i++);
            mcn_NotActiveAfterPasswordExpires = new AWPColName("NotActiveAfterPasswordExpires", null, i++);

            mcn_Password = new AWPColName("Password", null, i++);
            mcn_myOrganisation_Person__per_ID = new AWPColName("myOrganisation_Person_$_per_$$ID", null, i++);
            mcn_ID = new AWPColName("ID", lng.cn_Selected, i++);
            mcn_myOrganisation_Person__per__cfn_ID = new AWPColName("myOrganisation_Person_$_per_$_cfn_$$ID", null, i++); 
            mcn_myOrganisation_Person__per__cln_ID = new AWPColName("myOrganisation_Person_$_per_$_cln_$$ID", null, i++); 
            mcn_myOrganisation_Person__office_ID = new AWPColName("myOrganisation_Person_$_office_$$ID", null, i++);
            mcn_myOrganisation_Person__office_Name = new AWPColName("myOrganisation_Person_$_office_$$Name", null, i++);
            mcn_PersonData_ID = new AWPColName("PersonData_$$ID", null, i++);
            mcn_PersonData__cphnnper_ID = new AWPColName("PersonData_$_cphnnper_$$ID", null, i++);
            mcn_PersonData__cemailper_ID = new AWPColName("PersonData_$_cemailper_$$ID", null, i++);
            mcn_PersonData__cadrper_ID = new AWPColName("PersonData_$_cadrper_$$ID", null, i++);
            mcn_PersonData__cadrper__cstrnper_ID = new AWPColName("PersonData_$_cadrper_$_cstrnper_$$ID", null, i++);
            mcn_PersonData__cadrper__chounper_ID = new AWPColName("PersonData_$_cadrper_$_chounper_$$ID", null, i++);
            mcn_PersonData__cadrper__ccitper_ID = new AWPColName("PersonData_$_cadrper_$_ccitper_$$ID", null, i++);
            mcn_PersonData__cadrper__zipper_ID = new AWPColName("PersonData_$_cadrper_$_zipper_$$ID", null, i++);
            mcn_PersonData__cadrper__cstper_ID = new AWPColName("PersonData_$_cadrper_$_cstper_$$ID", null, i++);
            mcn_PersonData__cadrper__cstper_Country_ISO_3166_a2 = new AWPColName("PersonData_$_cadrper_$_cstper_$$Country_ISO_3166_a2", null, i++);
            mcn_PersonData__cadrper__cstper_Country_ISO_3166_a3 = new AWPColName("PersonData_$_cadrper_$_cstper_$$Country_ISO_3166_a3", null, i++);
            mcn_PersonData__cadrper__ccouper_ID = new AWPColName("PersonData_$_cadrper_$_ccouper_$$ID", null, i++);
            mcn_PersonData__cardtper_ID = new AWPColName("PersonData_$_cardtper_$$ID", null, i++);
            mcn_PersonData__perimg_ID = new AWPColName("PersonData_$_perimg_$$ID", null, i++);
            mcn_PersonData__perimg_Image_Hash = new AWPColName("PersonData_$_perimg_$$Image_Hash", null, i++);
            mcn_PersonData__perimg_Image_Data = new AWPColName("PersonData_$_perimg_$$Image_Data", null, i++);

            AWP_col_Names.Add(mcn_Selected);
            AWP_col_Names.Add(mcn_Administrator);
            AWP_col_Names.Add(mcn_myOrganisation_Person_office_Name);
            AWP_col_Names.Add(mcn_myOrganisation_Person__office_ShortName);
            AWP_col_Names.Add(mcn_UserName);
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

            if (AllRoles==null)
            {
                AllRoles = new List<AWPRole>();
            }

            AllRoles.Add(new AWPRole(null, AWP.ROLE_Administrator));
            AllRoles.Add(new AWPRole(null, AWP.ROLE_UserManagement));
            AllRoles.Add(new AWPRole(null, AWP.ROLE_StockTakeManagement));
            AllRoles.Add(new AWPRole(null, AWP.ROLE_PriceListManagement));
            AllRoles.Add(new AWPRole(null, AWP.ROLE_WriteInvoiceAndProformaInvoice));
            //AllRoles.Add(new AWPRole(-1, AWP.ROLE_WriteInvoice));
            //AllRoles.Add(new AWPRole(-1, AWP.ROLE_WriteProformainvoice));
            //AllRoles.Add(new AWPRole(-1, AWP.ROLE_ViewAndExport));
            //AllRoles.Add(new AWPRole(-1, AWP.ROLE_WorkInShopA));
            //AllRoles.Add(new AWPRole(-1, AWP.ROLE_WorkInShopB));
            //AllRoles.Add(new AWPRole(-1, AWP.ROLE_WorkInShopC));


        }

        internal void BindingControls(AWP_UserManager xfrm)
        {
            frm = xfrm;
            mcn_Selected.Bind(null, null);
            mcn_Administrator.Bind(null, null);
            mcn_UserName.Bind(frm.lbl_UserName, frm.txtUserName);
            mcn_Enabled.Bind(frm.chk_Enabled, frm.chk_Enabled);
            mcn_PersonData_Description.Bind( null, null);
            mcn_PersonData__cardtper_CardType.Bind( null, null);
            mcn_PersonData_CardNumber.Bind(null, null);
            mcn_myOrganisation_Person_ID.Bind( null, null);
            mcn_PasswordNeverExpires.Bind( frm.rdb_PaswordExpires_Never, frm.rdb_PaswordExpires_Never);
            mcn_Time_When_AdministratorSetsPassword.Bind( null, null);
            mcn_Time_When_UserSetsItsOwnPassword_FirstTime.Bind( null, null);
            mcn_Time_When_UserSetsItsOwnPassword_LastTime.Bind( null, null);
            mcn_Administrator_LoginUsers_ID.Bind( null, null);
            mcn_ChangePasswordOnFirstLogin.Bind( frm.chk_ChangePasswordOnFirstLogIn, frm.chk_ChangePasswordOnFirstLogIn);
            mcn_Maximum_password_age_in_days.Bind( frm.lbl_Max_Password_Age, frm.nmUpDn_MaxPasswordAge);
            mcn_NotActiveAfterPasswordExpires.Bind( frm.rdb_DeactivateAfterNumberOfDays, frm.rdb_DeactivateAfterNumberOfDays);
        }

        internal void SetControls(DataGridView2xls dgv_LoginUsers, DataRow dataRow, string TableName)
        {
            if (dgv_LoginUsers != null)
            {
                foreach (DataGridViewColumn dgvc in dgv_LoginUsers.Columns)
                {
                    dgvc.Visible = false;
                }
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
                        if (dgv_LoginUsers != null)
                        {
                            if (TableName != null)
                            {
                                dgv_LoginUsers.Columns[awpcn.ColumnName].Visible = true;
                                if (awpcn.NameInLanguage != null)
                                {
                                    dgv_LoginUsers.Columns[awpcn.ColumnName].HeaderText = awpcn.NameInLanguage.s;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogFile.Error.Show("ERROR:LoginControl:AWPData:SetControls: awpcn.ColumnName = " + awpcn.ColumnName + " not in dgv_LoginUsers!\r\nException =" + ex.Message);
                    }

                    try
                    {
                        if (awpcn.lbl_ctrl != null)
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
