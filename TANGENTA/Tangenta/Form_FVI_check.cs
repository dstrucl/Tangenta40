using LanguageControl;
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
        NavigationButtons.Navigation nav = null;
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
                            if (do_OK())
                            {
                                nav.eExitResult = evt;
                            }
                            break;

                        case NavigationButtons.Navigation.eEvent.CANCEL:
                            do_Cancel();
                            nav.eExitResult = evt;
                            break;
                    }
                    break;

                case NavigationButtons.Navigation.eButtons.PrevNextExit:
                    switch (evt)
                    {
                        case NavigationButtons.Navigation.eEvent.NEXT:
                            if (do_OK())
                            {
                                nav.eExitResult = evt;
                            }
                            break;

                        case NavigationButtons.Navigation.eEvent.PREV:
                            do_Cancel();
                            nav.eExitResult = evt;
                            break;

                        case NavigationButtons.Navigation.eEvent.EXIT:
                            do_Cancel();
                            nav.eExitResult = evt;
                            break;
                    }
                    break;
            }
        }

        private bool do_OK()
        {
            Program.b_FVI_SLO = chk_FVI.Checked;
            if (Program.b_FVI_SLO)
            {
                Properties.Settings.Default.bFVI_SLO = "1";
            }
            else
            {
                Properties.Settings.Default.bFVI_SLO = "0";
            }
            Properties.Settings.Default.Save();
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
