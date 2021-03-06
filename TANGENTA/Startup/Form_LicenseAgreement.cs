﻿using LanguageControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Startup
{
    public partial class Form_LicenseAgreement : Form
    {
        NavigationButtons.Navigation nav = null;

        public Form_LicenseAgreement(NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;
            this.Owner = nav.OwnerForm;
            lng.s_License_agreement.Text(this);
            this.usrc_NavigationButtons1.Init(nav);
            lng.s_I_accept_the_terms_in_the_license_agreement.Text(rdb_AcceptLicenseAgreement);
            lng.s_I_do_not_accept_the_terms_in_the_license_agreement.Text(rdb_NotAcceptLicenseAgreement);
            lng.s_Print.Text(btn_Print);
            rdb_AcceptLicenseAgreement.Checked = false;
            rdb_NotAcceptLicenseAgreement.Checked = true;
            usrc_NavigationButtons1.Visible_NEXT = false;
            usrc_NavigationButtons1.Visible_PREV = true;
            usrc_NavigationButtons1.Visible_EXIT = true;
            this.rdb_AcceptLicenseAgreement.CheckedChanged += new System.EventHandler(this.rdb_AcceptLicenseAgreement_CheckedChanged);
            this.usrc_NavigationButtons1.ButtonPressed += new NavigationButtons.usrc_NavigationButtons.delegate_button_pressed(this.usrc_NavigationButtons1_ButtonPressed);
            this.usrc_web_Help1.ShowLicenceAgreement();
        }

        private void do_OK()
        {
            Close();
            DialogResult = DialogResult.OK;
        }

        private void do_Cancel()
        {
            Close();
            DialogResult = DialogResult.Cancel;
        }

        private void usrc_NavigationButtons1_ButtonPressed(NavigationButtons.Navigation.eEvent evt)
        {
            nav.eExitResult = evt;
            switch (evt)
            {
                case NavigationButtons.Navigation.eEvent.NEXT:
                    do_OK();
                    return;
                case NavigationButtons.Navigation.eEvent.PREV:
                    do_Cancel();
                    return;
                case NavigationButtons.Navigation.eEvent.EXIT:
                    do_Cancel();
                    return;
            }
        }

        private void rdb_AcceptLicenseAgreement_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_AcceptLicenseAgreement.Checked)
            {
                nav.LicenseAgreementAccaptedTime = new NavigationButtons.Navigation.LicenseAgreementAcceptedTime(DateTime.Now);
                usrc_NavigationButtons1.Visible_NEXT = true;
                usrc_NavigationButtons1.Visible_PREV = true;
            }
            else
            {
                nav.LicenseAgreementAccaptedTime = null;
                usrc_NavigationButtons1.Visible_NEXT = false;
                usrc_NavigationButtons1.Visible_PREV = false;
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {

        }
    }
}
