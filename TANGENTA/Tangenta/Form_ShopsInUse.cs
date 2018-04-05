#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using LanguageControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tangenta
{
    public partial class Form_ShopsInUse : Form
    {
        private usrc_Document m_usrc_Main;
        private bool bResetShopsInUse = false;
        NavigationButtons.Navigation nav = null;


        public Form_ShopsInUse(NavigationButtons.Navigation xnav, bool xbResetShopsInUse,usrc_Document xusrc_Main)
        {
            InitializeComponent();
            nav = xnav;
            usrc_NavigationButtons1.Init(nav);
            bResetShopsInUse = xbResetShopsInUse;
            lng.s_Shops_In_Use.Text(this);
           
            wb1.DocumentText = Properties.Resources.SLO_Help_Shops_in_use;
          
            this.m_usrc_Main = xusrc_Main;
        }

        private bool do_OK()
        {
            usrc_ShopsInuse1.do_OK();
            this.Close();
            DialogResult = DialogResult.OK;
            return true;
        }

        private void do_Cancel()
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void usrc_NavigationButtons1_ButtonPressed(NavigationButtons.Navigation.eEvent evt)
        {
            switch (nav.m_eButtons)
            {
                case NavigationButtons.Navigation.eButtons.PrevNextExit:
                    switch (evt)
                    {
                        case NavigationButtons.Navigation.eEvent.NEXT:
                            nav.eExitResult = evt;
                            if (!do_OK())
                            {
                                nav.eExitResult = NavigationButtons.Navigation.eEvent.NOTHING;
                            }
                            return;
                        case NavigationButtons.Navigation.eEvent.PREV:
                            nav.eExitResult = evt;
                            do_Cancel();
                            return;
                        case NavigationButtons.Navigation.eEvent.EXIT:
                            nav.eExitResult = evt;
                            do_Cancel();
                            return;
                    }
                    break;
                case NavigationButtons.Navigation.eButtons.OkCancel:
                    switch (evt)
                    {
                        case NavigationButtons.Navigation.eEvent.OK:
                            nav.eExitResult = evt;
                            if (!do_OK())
                            {
                                nav.eExitResult = NavigationButtons.Navigation.eEvent.NOTHING ;
                            }
                            return;
                        case NavigationButtons.Navigation.eEvent.CANCEL:
                            nav.eExitResult = evt;
                            do_Cancel();
                            return;
                    }
                    break;
            }
        }
    }
}
