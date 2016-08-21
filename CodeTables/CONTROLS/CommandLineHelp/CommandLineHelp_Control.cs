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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;

namespace CommandLineHelp
{
    public partial class CommandLineHelp_Control : UserControl
    {
        Image m_Image_Button_Cancel = null;
        Icon m_FormIcon = null;
        public Image Image_Button_Cancel
        {
            get { return m_Image_Button_Cancel; }
            set { m_Image_Button_Cancel = value; }
        }

        public Icon FormIcon
        {
            get { return m_FormIcon; }
            set { m_FormIcon = value; }
        }

        private List<CommandLineHelp> m_CommandLineHelpList = null;
        public CommandLineHelp_Control()
        {
            InitializeComponent();
            btn_CommandLineHelp.Text = lngRPM.s_CommandLineHelp.s;
        }

        public void Attach(List<CommandLineHelp> xCommandLineHelpList)
        {
            m_CommandLineHelpList = xCommandLineHelpList;
        }

        private void btn_CommandLineHelp_Click(object sender, EventArgs e)
        {

            NavigationButtons.Navigation CommandLineHelpNav = new NavigationButtons.Navigation();
            CommandLineHelpNav.bDoModal = true;
            CommandLineHelpNav.m_eButtons = NavigationButtons.Navigation.eButtons.OkCancel;
            CommandLineHelpNav.btn1_Visible = false;
            CommandLineHelpNav.btn2_Image = null;
            CommandLineHelpNav.btn2_Text = lngRPM.s_OK.s;
            CommandLineHelpNav.btn2_Visible = true;
            CommandLineHelpNav.btn3_Image = null;
            CommandLineHelpNav.btn3_Text = lngRPM.s_Cancel.s;
            CommandLineHelpNav.btn3_Visible = false;
            CommandLineHelpNav.btn2_ToolTip_Text = "";
            CommandLineHelpNav.btn3_ToolTip_Text = "";
            CommandLineHelp_Form hlpfrm = new CommandLineHelp_Form(m_CommandLineHelpList, CommandLineHelpNav, m_FormIcon);
            hlpfrm.ShowDialog();
        }
    }
}
