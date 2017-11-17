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
using System.Threading.Tasks;
using System.Windows.Forms;
using LanguageControl;

namespace XMessage
{
    public partial class Form_Box : Form
    {
        private IWin32Window owner;
        private string text;
        private string caption;
        private MessageBoxButtons m_buttons;
        private MessageBoxDefaultButton defaultButton;

        public Form_Box()
        {
            InitializeComponent();
            this.Icon = SystemIcons.Information;
        }

        public Icon SetIcon(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.Error:
                    return System.Drawing.SystemIcons.Error;
                case MessageBoxIcon.Exclamation:
                    return System.Drawing.SystemIcons.Exclamation;

                case MessageBoxIcon.Information:
                    return System.Drawing.SystemIcons.Information;
                case MessageBoxIcon.Question:
                    return System.Drawing.SystemIcons.Question;
            }
            return null;

        }
        public Form_Box(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, object oIcon, MessageBoxDefaultButton defaultButton)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.owner = owner;
            this.text = text;
            this.caption = caption;
            this.m_buttons = buttons;
            if (oIcon is MessageBoxIcon)
            {
                Icon ico = SetIcon((MessageBoxIcon)oIcon);
                if (ico != null)
                {
                    this.Icon = ico;
                }
            }
            else if (oIcon is Icon)
            {
                this.Icon = (Icon) oIcon;
            }

            this.defaultButton = defaultButton;
            this.Text = caption;
            textBox1.Text = text;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            switch (buttons)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    button1.Visible = true;
                    button1.Tag = DialogResult.Abort;
                    lng.s_Abort.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.Retry;
                    lng.s_Retry.Text(button2);
                    button3.Visible = true;
                    button3.Tag = DialogResult.Ignore;
                    lng.s_Ignore.Text(button3);
                    break;
                case MessageBoxButtons.OK:
                    button2.Visible = true;
                    button2.Tag = DialogResult.OK;
                    lng.s_OK.Text(button2);
                    break;
                case MessageBoxButtons.OKCancel:
                    button1.Visible = true;
                    button1.Tag = DialogResult.OK;
                    lng.s_OK.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.Cancel;
                    lng.s_Cancel.Text(button2);
                    break;
                case MessageBoxButtons.RetryCancel:
                    button1.Visible = true;
                    button1.Tag = DialogResult.Retry;
                    lng.s_Retry.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.Cancel;
                    lng.s_Cancel.Text(button2);
                    break;
                case MessageBoxButtons.YesNo:
                    button1.Visible = true;
                    button1.Tag = DialogResult.Yes;
                    lng.s_Yes.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.No;
                    lng.s_No.Text(button2);
                    break;
                case MessageBoxButtons.YesNoCancel:
                    button1.Visible = true;
                    button1.Tag = DialogResult.Yes;
                    lng.s_Yes.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.No;
                    lng.s_No.Text(button2);
                    button3.Visible = true;
                    button3.Tag = DialogResult.Cancel;
                    lng.s_Cancel.Text(button3);
                    break;
            }
            switch (defaultButton)
            {
                case MessageBoxDefaultButton.Button1:
                    button1.Focus();
                    break;
                case MessageBoxDefaultButton.Button2:
                    button2.Focus();
                    break;
                case MessageBoxDefaultButton.Button3:
                    button3.Focus();
                    break;
            }

        }

        public Form_Box(IWin32Window owner, ltext xltext)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.owner = owner;
            this.caption = "";
            this.Text = "";
            xltext.Text(textBox1);
            textBox1.TextAlign = HorizontalAlignment.Center;
            button1.Visible = false;
            button2.Visible = true;
            button3.Visible = false;
            button2.Tag = DialogResult.OK;
            lng.s_OK.Text(button2);
            button2.Focus();
        }


        public Form_Box(IWin32Window owner, ltext xltext, string text, string caption, MessageBoxButtons buttons, object oIcon, MessageBoxDefaultButton defaultButton)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.owner = owner;
            this.caption = caption;
            this.m_buttons = buttons;
            if (oIcon is MessageBoxIcon)
            {
                Icon ico = SetIcon((MessageBoxIcon)oIcon);
                if (ico != null)
                {
                    this.Icon = ico;
                }
            }
            else if (oIcon is Icon)
            {
                this.Icon = (Icon)oIcon;
            }

            this.defaultButton = defaultButton;
            this.Text = caption;
            xltext.Text(textBox1);
            textBox1.Text += text;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            switch (buttons)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    button1.Visible = true;
                    button1.Tag = DialogResult.Abort;
                    lng.s_Abort.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.Retry;
                    lng.s_Retry.Text(button2);
                    button3.Visible = true;
                    button3.Tag = DialogResult.Ignore;
                    lng.s_Ignore.Text(button3);
                    break;
                case MessageBoxButtons.OK:
                    button2.Visible = true;
                    button2.Tag = DialogResult.OK;
                    lng.s_OK.Text(button2);
                    break;
                case MessageBoxButtons.OKCancel:
                    button1.Visible = true;
                    button1.Tag = DialogResult.OK;
                    lng.s_OK.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.Cancel;
                    lng.s_Cancel.Text(button2);
                    break;
                case MessageBoxButtons.RetryCancel:
                    button1.Visible = true;
                    button1.Tag = DialogResult.Retry;
                    lng.s_Retry.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.Cancel;
                    lng.s_Cancel.Text(button2);
                    break;
                case MessageBoxButtons.YesNo:
                    button1.Visible = true;
                    button1.Tag = DialogResult.Yes;
                    lng.s_Yes.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.No;
                    lng.s_No.Text(button2);
                    break;
                case MessageBoxButtons.YesNoCancel:
                    button1.Visible = true;
                    button1.Tag = DialogResult.Yes;
                    lng.s_Yes.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.No;
                    lng.s_No.Text(button2);
                    button3.Visible = true;
                    button3.Tag = DialogResult.Cancel;
                    lng.s_Cancel.Text(button3);
                    break;
            }
            switch (defaultButton)
            {
                case MessageBoxDefaultButton.Button1:
                    button1.Focus();
                    break;
                case MessageBoxDefaultButton.Button2:
                    button2.Focus();
                    break;
                case MessageBoxDefaultButton.Button3:
                    button3.Focus();
                    break;
            }
        }

        public Form_Box(IWin32Window owner, ltext xltext, ltext lcaption, MessageBoxButtons buttons, object oIcon, MessageBoxDefaultButton defaultButton)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.owner = owner;
            this.m_buttons = buttons;
            if (oIcon is MessageBoxIcon)
            {
                Icon ico = SetIcon((MessageBoxIcon)oIcon);
                if (ico != null)
                {
                    this.Icon = ico;
                }
            }
            else if (oIcon is Icon)
            {
                this.Icon = (Icon)oIcon;
            }
            this.defaultButton = defaultButton;

            lcaption.Text(this);
            xltext.Text(textBox1);

            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;

            switch (buttons)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    button1.Visible = true;
                    button1.Tag = DialogResult.Abort;
                    lng.s_Abort.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.Retry;
                    lng.s_Retry.Text(button2);
                    button3.Visible = true;
                    button3.Tag = DialogResult.Ignore;
                    lng.s_Ignore.Text(button3);
                    break;
                case MessageBoxButtons.OK:
                    button2.Visible = true;
                    button2.Tag = DialogResult.OK;
                    lng.s_OK.Text(button2);
                    break;
                case MessageBoxButtons.OKCancel:
                    button1.Visible = true;
                    button1.Tag = DialogResult.OK;
                    lng.s_OK.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.Cancel;
                    lng.s_Cancel.Text(button2);
                    break;
                case MessageBoxButtons.RetryCancel:
                    button1.Visible = true;
                    button1.Tag = DialogResult.Retry;
                    lng.s_Retry.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.Cancel;
                    lng.s_Cancel.Text(button2);
                    break;
                case MessageBoxButtons.YesNo:
                    button1.Visible = true;
                    button1.Tag = DialogResult.Yes;
                    lng.s_Yes.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.No;
                    lng.s_No.Text(button2);
                    break;
                case MessageBoxButtons.YesNoCancel:
                    button1.Visible = true;
                    button1.Tag = DialogResult.Yes;
                    lng.s_Yes.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.No;
                    lng.s_No.Text(button2);
                    button3.Visible = true;
                    button3.Tag = DialogResult.Cancel;
                    lng.s_Cancel.Text(button3);
                    break;

            }

            switch (defaultButton)
            {
                case MessageBoxDefaultButton.Button1:
                    button1.Focus();
                    break;
                case MessageBoxDefaultButton.Button2:
                    button2.Focus();
                    break;
                case MessageBoxDefaultButton.Button3:
                    button3.Focus();
                    break;
            }
        }

        public Form_Box(IWin32Window owner, ltext xltext, string caption, MessageBoxButtons buttons, object oIcon, MessageBoxDefaultButton defaultButton)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.owner = owner;
            this.m_buttons = buttons;
            if (oIcon is MessageBoxIcon)
            {
                Icon ico = SetIcon((MessageBoxIcon)oIcon);
                if (ico != null)
                {
                    this.Icon = ico;
                }
            }
            else if (oIcon is Icon)
            {
                this.Icon = (Icon)oIcon;
            }
            this.defaultButton = defaultButton;

            this.Text = caption;
            xltext.Text(textBox1);

            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;

            switch (buttons)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    button1.Visible = true;
                    button1.Tag = DialogResult.Abort;
                    lng.s_Abort.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.Retry;
                    lng.s_Retry.Text(button2);
                    button3.Visible = true;
                    button3.Tag = DialogResult.Ignore;
                    lng.s_Ignore.Text(button3);
                    break;
                case MessageBoxButtons.OK:
                    button2.Visible = true;
                    button2.Tag = DialogResult.OK;
                    lng.s_OK.Text(button2);
                    break;
                case MessageBoxButtons.OKCancel:
                    button1.Visible = true;
                    button1.Tag = DialogResult.OK;
                    lng.s_OK.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.Cancel;
                    lng.s_Cancel.Text(button2);
                    break;
                case MessageBoxButtons.RetryCancel:
                    button1.Visible = true;
                    button1.Tag = DialogResult.Retry;
                    lng.s_Retry.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.Cancel;
                    lng.s_Cancel.Text(button2);
                    break;
                case MessageBoxButtons.YesNo:
                    button1.Visible = true;
                    button1.Tag = DialogResult.Yes;
                    lng.s_Yes.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.No;
                    lng.s_No.Text(button2);
                    break;
                case MessageBoxButtons.YesNoCancel:
                    button1.Visible = true;
                    button1.Tag = DialogResult.Yes;
                    lng.s_Yes.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.No;
                    lng.s_No.Text(button2);
                    button3.Visible = true;
                    button3.Tag = DialogResult.Cancel;
                    lng.s_Cancel.Text(button3);
                    break;

            }
            switch (defaultButton)
            {
                case MessageBoxDefaultButton.Button1:
                    button1.Focus();
                    break;
                case MessageBoxDefaultButton.Button2:
                    button2.Focus();
                    break;
                case MessageBoxDefaultButton.Button3:
                    button3.Focus();
                    break;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            switch (m_buttons)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    DialogResult = DialogResult.Abort;
                    break;
                case MessageBoxButtons.OK:
                    DialogResult = DialogResult.OK;
                    break;
                case MessageBoxButtons.OKCancel:
                    DialogResult = DialogResult.OK;
                    break;
                case MessageBoxButtons.RetryCancel:
                    DialogResult = DialogResult.Retry;
                    break;
                case MessageBoxButtons.YesNo:
                    DialogResult = DialogResult.Yes;
                    break;
                case MessageBoxButtons.YesNoCancel:
                    DialogResult = DialogResult.Yes;
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            switch (m_buttons)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    DialogResult = DialogResult.Retry;
                    break;
                case MessageBoxButtons.OK:
                    DialogResult = DialogResult.OK;
                    break;
                case MessageBoxButtons.OKCancel:
                    DialogResult = DialogResult.Cancel;
                    break;
                case MessageBoxButtons.RetryCancel:
                    DialogResult = DialogResult.Cancel;
                    break;
                case MessageBoxButtons.YesNo:
                    DialogResult = DialogResult.No;
                    break;
                case MessageBoxButtons.YesNoCancel:
                    DialogResult = DialogResult.No;
                    break;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            switch (m_buttons)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    DialogResult = DialogResult.Ignore;
                    break;
                case MessageBoxButtons.OK:
                    DialogResult = DialogResult.OK;
                    break;
                case MessageBoxButtons.OKCancel:
                    DialogResult = DialogResult.Cancel;
                    break;
                case MessageBoxButtons.RetryCancel:
                    DialogResult = DialogResult.Cancel;
                    break;
                case MessageBoxButtons.YesNo:
                    DialogResult = DialogResult.No;
                    break;
                case MessageBoxButtons.YesNoCancel:
                    DialogResult = DialogResult.Cancel;
                    break;
            }
        }
    }
}
