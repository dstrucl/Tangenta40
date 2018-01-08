using LanguageControl;
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
    public partial class Form_Navigate : Form
    {
        NavigationButtons.Navigation nav = null;
        public Form_Navigate(NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;
            this.Owner = nav.OwnerForm;
            usrc_NavigationButtons1.Init(nav);
            lng.s_Select.Text(this);
        }

        private void do_OK()
        {
            Owner = null;
            Close();
            DialogResult = DialogResult.OK;
        }

        private void do_Cancel()
        {
            Owner = null;
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
    }
}
