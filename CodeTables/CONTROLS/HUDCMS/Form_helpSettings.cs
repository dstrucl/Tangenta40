using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HUDCMS
{
    public partial class Form_helpSettings : Form
    {
        usrc_Help uH = null;
        usrc_web_Help wH = null;
        public Form_helpSettings(usrc_Help xuH, usrc_web_Help xwH)
        {
            InitializeComponent();
            uH = xuH;
            wH = xwH;
            this.usrc_HelpSettings1.txt_RemoteHelpURL.Text = HUDCMS_static.RemoteHelpURL;
            this.usrc_HelpSettings1.usrc_SelectLocalHelpFolder.InitialDirectory = HUDCMS_static.LocalHelpPath;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            HUDCMS_static.RemoteHelpURL = this.usrc_HelpSettings1.txt_RemoteHelpURL.Text;
            HUDCMS_static.LocalHelpPath = this.usrc_HelpSettings1.usrc_SelectLocalHelpFolder.SelectedFolder;
            uH.GetLocalURL(uH.Prefix);
            wH.ReloadHtml();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Form_helpSettings_FormClosing(object sender, FormClosingEventArgs e)
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
