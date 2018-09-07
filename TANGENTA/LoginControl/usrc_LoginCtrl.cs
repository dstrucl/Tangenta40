using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBConnectionControl40;
using LanguageControl;
using LogFile;
using System.Security.Cryptography;
using NavigationButtons;
using System.Runtime.InteropServices;

namespace LoginControl
{
    public partial class usrc_LoginCtrl : UserControl
    {
        public LoginCtrl m_LoginCtrl = null;
        public LMOUser m_LMOUser = null;

        public usrc_LoginCtrl()
        {
            InitializeComponent();
        }

        public void Bind(LoginCtrl xlctrl,LMOUser loginOfMyOrgUser)
        {
            m_LoginCtrl = xlctrl;
            m_LMOUser = loginOfMyOrgUser;
            this.lbl_username.Text = m_LMOUser.UserName;
            if (loginOfMyOrgUser.IsAdministrator|| loginOfMyOrgUser.IsUserManager)
            {
                btn_UserManager.Visible = true;
            }
            else
            {
                btn_UserManager.Visible = false;
            }
        }

        private void btn_UserManager_Click(object sender, EventArgs e)
        {
            switch (m_LoginCtrl.m_eDataTableCreationMode)
            {
                case LoginCtrl.eDataTableCreationMode.AWP:
                    Navigation xnav = new Navigation(null);
                    xnav.m_eButtons = Navigation.eButtons.OkCancel;
                    AWP_UserManager AWP_usr_mangaer = new AWP_UserManager(m_LoginCtrl, xnav,this.ParentForm, m_LoginCtrl.awp.LMO1User);
                    AWP_usr_mangaer.ShowDialog(Global.f.GetParentForm(this));
                    break;

                case LoginCtrl.eDataTableCreationMode.STD:
                    STD_UserManager STD_usr_mangaer = new STD_UserManager(this.ParentForm, m_LoginCtrl.std);
                    STD_usr_mangaer.ShowDialog(Global.f.GetParentForm(this));
                    break;
            }
        }

        private void btn_UserInfo_Click(object sender, EventArgs e)
        {
            switch (m_LoginCtrl.m_eDataTableCreationMode)
            {
                case LoginCtrl.eDataTableCreationMode.AWP:
                    Form pForm = Global.f.GetParentForm(this);
                    AWP_UserInfo_Form awp_usr_info = new AWP_UserInfo_Form(pForm, m_LoginCtrl.awp.LMO1User.UserName, m_LoginCtrl.awp.LMO1User);
                    awp_usr_info.ShowDialog(pForm);
                    break;
                case LoginCtrl.eDataTableCreationMode.STD:
                    STDUserInfoForm usrinfo = new STDUserInfoForm(m_LoginCtrl.std);
                    usrinfo.ShowDialog();
                    break;
            }
        }
    }
}
