﻿using LanguageControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TangentaDB;

namespace Tangenta
{
    public partial class Form_FVI_check : Form
    {
        private NavigationButtons.Navigation nav = null;
        public Form_FVI_check(NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;
            chk_FVI.Checked = true;
            usrc_NavigationButtons1.Init(nav);
            lng.s_FVI_instruction.Text(label1);
            lng.s_FVI_Check.Text(chk_FVI);
        }

        private void usrc_NavigationButtons1_ButtonPressed(NavigationButtons.Navigation.eEvent evt)
        {
            switch (nav.m_eButtons)
            {

                case NavigationButtons.Navigation.eButtons.OkCancel:
                    switch (evt)
                    {
                        case NavigationButtons.Navigation.eEvent.OK:
                            nav.eExitResult = evt;
                            if (!do_OK())
                            {
                                nav.eExitResult = NavigationButtons.Navigation.eEvent.NOTHING;
                            }
                            break;

                        case NavigationButtons.Navigation.eEvent.CANCEL:
                            nav.eExitResult = evt;
                            do_Cancel();
                            break;
                    }
                    break;

                case NavigationButtons.Navigation.eButtons.PrevNextExit:
                    switch (evt)
                    {
                        case NavigationButtons.Navigation.eEvent.NEXT:
                            nav.eExitResult = evt;
                            if (!do_OK())
                            {
                                nav.eExitResult = NavigationButtons.Navigation.eEvent.NOTHING;
                            }
                            break;

                        case NavigationButtons.Navigation.eEvent.PREV:
                            nav.eExitResult = evt;
                            do_Cancel();
                            break;

                        case NavigationButtons.Navigation.eEvent.EXIT:
                            nav.eExitResult = evt;
                            do_Cancel();
                            break;
                    }
                    break;
            }
        }

        private bool do_OK()
        {
            Program.b_FVI_SLO = false;
            long DBSettings_ID = -1;
            if (chk_FVI.Checked)
            {
                string sFiscalVerificationOfInvoices = "1";
                if (fs.WriteDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.FiscalVerificationOfInvoices.Name, sFiscalVerificationOfInvoices, "0", ref DBSettings_ID))
                {
                    Program.b_FVI_SLO = sFiscalVerificationOfInvoices.Equals("1");
                }
            }
            else
            {
                string sFiscalVerificationOfInvoices = "0";
                if (fs.WriteDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.FiscalVerificationOfInvoices.Name, sFiscalVerificationOfInvoices, "0", ref DBSettings_ID))
                {
                    Program.b_FVI_SLO = sFiscalVerificationOfInvoices.Equals("1");
                }
            }
            Close();
            DialogResult = DialogResult.OK;
            return true;
        }
        private void do_Cancel()
        {
            Close();
            DialogResult = DialogResult.Cancel;
        }
    }
}
