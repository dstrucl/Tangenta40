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
        public string LocalHelpPath = null;
        public string RemoteHelpURL = null;

        public string[] CommandLineArguments = null;

        public CommandLineHelp_Form(List<CommandLineHelp> CommandLineHelpList, NavigationButtons.Navigation xnav, Icon xFormIcon,
                                    string xLocalHelpPath,
                                    string xRemoteHelpURL)
        {
            InitializeComponent();
            LocalHelpPath = xLocalHelpPath;
            RemoteHelpURL = xRemoteHelpURL;
            m_CommandLineHelpList = CommandLineHelpList;
            nav = xnav;
            if (RemoteHelpURL!=null)
            {
                if (RemoteHelpURL.Length>0)
                {
                    this.usrc_HelpSettings1.txt_RemoteHelpURL.Text = RemoteHelpURL;
                }
            }

            if (LocalHelpPath != null)
            {
                if (LocalHelpPath.Length > 0)
                {
                    this.usrc_HelpSettings1.usrc_SelectLocalHelpFolder.InitialDirectory = LocalHelpPath;
                    this.usrc_HelpSettings1.usrc_SelectLocalHelpFolder.SelectedFolder = LocalHelpPath;
                }
            }

            usrc_NavigationButtons1.Init(nav);
            if (xFormIcon!=null)
            {
                this.Icon = xFormIcon;
            }
            lng.s_grp_HelpSettings.Text(this.usrc_HelpSettings1.grp_HelpSettings);
            lng.s_LocalHelpAddress.Text(this.usrc_HelpSettings1.usrc_SelectLocalHelpFolder.label1);
            lng.s_RemoteHelpAddress.Text(this.usrc_HelpSettings1.lbl_RemoteURL);
            lng.s_CommandLineParameters.Text(this.grp_CommandLineParameters);
        }

        private void do_OK()
        {
            LocalHelpPath = this.usrc_HelpSettings1.usrc_SelectLocalHelpFolder.SelectedFolder;
            RemoteHelpURL = this.usrc_HelpSettings1.txt_RemoteHelpURL.Text;
            HUDCMS.HUDCMS_static.LocalHelpPath = this.LocalHelpPath;
            HUDCMS.HUDCMS_static.RemoteHelpURL = this.RemoteHelpURL;
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
            int iName = 0;
            foreach (CommandLineHelp cmdlnhlp in m_CommandLineHelpList)
            {
                helpctrl_last = new CommandLineHelp_ItemControl(cmdlnhlp);
                helpctrl_last.Name = helpctrl_last.Name+"["+iName+"]";
                helpctrl_last.Top = y;
                helpctrl_last.Width = this.panel_Help.Width - 20;
                helpctrl_last.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                this.panel_Help.Controls.Add(helpctrl_last);
                helpctrl_last.Left = 10;
                y = helpctrl_last.Bottom + 10;
                iName++;
            }
            this.Text = lng.s_CommandLineHelp.s;
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

        private void usrc_NavigationButtons1_HelpClicked()
        {
            LocalHelpPath = this.usrc_HelpSettings1.usrc_SelectLocalHelpFolder.SelectedFolder;
            RemoteHelpURL = this.usrc_HelpSettings1.txt_RemoteHelpURL.Text;
            if (RemoteHelpURL!=null)
            {
                if (RemoteHelpURL.Length>0)
                {
                    HUDCMS.HUDCMS_static.RemoteHelpURL = RemoteHelpURL;
                }
            }
            if (LocalHelpPath != null)
            {
                if (LocalHelpPath.Length > 0)
                {
                    HUDCMS.HUDCMS_static.LocalHelpPath = LocalHelpPath;
                }
            }

        }

        private void CommandLineHelp_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            // this code is because of a bug in FolderBrowserDialog
            // see https://www.experts-exchange.com/questions/24413526/Child-Dialog-Closes-Parent-Dialog-in-VB-NET.html
            if (e.CloseReason == CloseReason.None)
            {
                e.Cancel = true;
            }
        }
    }
}
