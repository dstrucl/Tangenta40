#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;

namespace CommandLineHelp
{
    public partial class CommandLineHelp_Form : Form
    {
        List<CommandLineHelp> m_CommandLineHelpList = null;
        CommandLineHelp_ItemControl helpctrl_last;
        NavigationButtons.Navigation nav = null;

        public string[] CommandLineArguments = null;

        public CommandLineHelp_Form(List<CommandLineHelp> CommandLineHelpList, NavigationButtons.Navigation xnav, Icon xFormIcon)
        {
            InitializeComponent();
            m_CommandLineHelpList = CommandLineHelpList;
            nav = xnav;
            usrc_NavigationButtons1.Init(nav);
            if (xFormIcon!=null)
            {
                this.Icon = xFormIcon;
            }
        }

        private void do_OK()
        {
            List<string> cmds = new List<string>();
            foreach (Control ctrl in this.panel_Help.Controls)
            {
                if (ctrl is CommandLineHelp_ItemControl)
                {
                    if (((CommandLineHelp_ItemControl)ctrl).Selected)
                    {
                        cmds.Add(((CommandLineHelp_ItemControl)ctrl).Command);
                    }
                }
            }
            int iCount = cmds.Count;
            if (iCount > 0)
            {
                CommandLineArguments = new string[cmds.Count];
                int i = 0;
                for (i=0;i< iCount;i++)
                {
                    CommandLineArguments[i] = cmds[i];
                }
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void do_Cancel()
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CommandLineHelp_Form_Load(object sender, EventArgs e)
        {
            
            int y = 10;
            foreach (CommandLineHelp cmdlnhlp in m_CommandLineHelpList)
            {
                helpctrl_last = new CommandLineHelp_ItemControl(cmdlnhlp);
                helpctrl_last.Top = y;
                this.panel_Help.Controls.Add(helpctrl_last);
                helpctrl_last.Left = 10;
                y = helpctrl_last.Bottom + 10;
            }
            this.Text = lngRPM.s_CommandLineHelp.s;
        }

        private void usrc_NavigationButtons1_ButtonPressed(NavigationButtons.Navigation.eEvent evt)
        {
            nav.eExitResult = evt;
            switch (nav.m_eButtons)
            {
                case NavigationButtons.Navigation.eButtons.OkCancel:
                    switch (evt)
                    {
                        case NavigationButtons.Navigation.eEvent.OK:
                            do_OK();
                            break;
                        case NavigationButtons.Navigation.eEvent.CANCEL:
                            do_Cancel();
                            break;
                    }
                    break;
                case NavigationButtons.Navigation.eButtons.PrevNextExit:
                    switch (evt)
                    {
                        case NavigationButtons.Navigation.eEvent.PREV:
                            DialogResult = DialogResult.Abort;
                            Close();
                            break;
                        case NavigationButtons.Navigation.eEvent.NEXT:
                            do_OK();
                            break;
                        case NavigationButtons.Navigation.eEvent.EXIT:
                            do_Cancel();
                            break;
                    }
                    break;
            }

        }
    }
}
