﻿using System;
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
        private MessageBoxIcon icon;
        private MessageBoxDefaultButton defaultButton;

        public Form_Box()
        {
            InitializeComponent();
        }

        public Form_Box(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.owner = owner;
            this.text = text;
            this.caption = caption;
            this.m_buttons = buttons;
            this.icon = icon;
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
                    lngRPM.s_Abort.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.Retry;
                    lngRPM.s_Retry.Text(button2);
                    button3.Visible = true;
                    button3.Tag = DialogResult.Ignore;
                    lngRPM.s_Ignore.Text(button3);
                    break;
                case MessageBoxButtons.OK:
                    button2.Visible = true;
                    button2.Tag = DialogResult.OK;
                    lngRPM.s_OK.Text(button2);
                    break;
                case MessageBoxButtons.OKCancel:
                    button1.Visible = true;
                    button1.Tag = DialogResult.OK;
                    lngRPM.s_OK.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.Cancel;
                    lngRPM.s_Cancel.Text(button2);
                    break;
                case MessageBoxButtons.RetryCancel:
                    button1.Visible = true;
                    button1.Tag = DialogResult.Retry;
                    lngRPM.s_Retry.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.Cancel;
                    lngRPM.s_Cancel.Text(button2);
                    break;
                case MessageBoxButtons.YesNo:
                    button1.Visible = true;
                    button1.Tag = DialogResult.Yes;
                    lngRPM.s_Yes.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.No;
                    lngRPM.s_No.Text(button2);
                    break;
                case MessageBoxButtons.YesNoCancel:
                    button1.Visible = true;
                    button1.Tag = DialogResult.Yes;
                    lngRPM.s_Yes.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.No;
                    lngRPM.s_No.Text(button2);
                    button3.Visible = true;
                    button3.Tag = DialogResult.Cancel;
                    lngRPM.s_Cancel.Text(button3);
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

        public Form_Box(IWin32Window owner, ltext xltext, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.owner = owner;
            this.text = text;
            this.caption = caption;
            this.m_buttons = buttons;
            this.icon = icon;
            this.defaultButton = defaultButton;
            this.Text = caption;
            xltext.Text(textBox1);
            textBox1.Text = text;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            switch (buttons)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    button1.Visible = true;
                    button1.Tag = DialogResult.Abort;
                    lngRPM.s_Abort.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.Retry;
                    lngRPM.s_Retry.Text(button2);
                    button3.Visible = true;
                    button3.Tag = DialogResult.Ignore;
                    lngRPM.s_Ignore.Text(button3);
                    break;
                case MessageBoxButtons.OK:
                    button2.Visible = true;
                    button2.Tag = DialogResult.OK;
                    lngRPM.s_OK.Text(button2);
                    break;
                case MessageBoxButtons.OKCancel:
                    button1.Visible = true;
                    button1.Tag = DialogResult.OK;
                    lngRPM.s_OK.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.Cancel;
                    lngRPM.s_Cancel.Text(button2);
                    break;
                case MessageBoxButtons.RetryCancel:
                    button1.Visible = true;
                    button1.Tag = DialogResult.Retry;
                    lngRPM.s_Retry.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.Cancel;
                    lngRPM.s_Cancel.Text(button2);
                    break;
                case MessageBoxButtons.YesNo:
                    button1.Visible = true;
                    button1.Tag = DialogResult.Yes;
                    lngRPM.s_Yes.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.No;
                    lngRPM.s_No.Text(button2);
                    break;
                case MessageBoxButtons.YesNoCancel:
                    button1.Visible = true;
                    button1.Tag = DialogResult.Yes;
                    lngRPM.s_Yes.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.No;
                    lngRPM.s_No.Text(button2);
                    button3.Visible = true;
                    button3.Tag = DialogResult.Cancel;
                    lngRPM.s_Cancel.Text(button3);
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

        public Form_Box(IWin32Window owner, ltext xltext, ltext lcaption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.owner = owner;
            this.m_buttons = buttons;
            this.icon = icon;
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
                    lngRPM.s_Abort.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.Retry;
                    lngRPM.s_Retry.Text(button2);
                    button3.Visible = true;
                    button3.Tag = DialogResult.Ignore;
                    lngRPM.s_Ignore.Text(button3);
                    break;
                case MessageBoxButtons.OK:
                    button2.Visible = true;
                    button2.Tag = DialogResult.OK;
                    lngRPM.s_OK.Text(button2);
                    break;
                case MessageBoxButtons.OKCancel:
                    button1.Visible = true;
                    button1.Tag = DialogResult.OK;
                    lngRPM.s_OK.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.Cancel;
                    lngRPM.s_Cancel.Text(button2);
                    break;
                case MessageBoxButtons.RetryCancel:
                    button1.Visible = true;
                    button1.Tag = DialogResult.Retry;
                    lngRPM.s_Retry.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.Cancel;
                    lngRPM.s_Cancel.Text(button2);
                    break;
                case MessageBoxButtons.YesNo:
                    button1.Visible = true;
                    button1.Tag = DialogResult.Yes;
                    lngRPM.s_Yes.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.No;
                    lngRPM.s_No.Text(button2);
                    break;
                case MessageBoxButtons.YesNoCancel:
                    button1.Visible = true;
                    button1.Tag = DialogResult.Yes;
                    lngRPM.s_Yes.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.No;
                    lngRPM.s_No.Text(button2);
                    button3.Visible = true;
                    button3.Tag = DialogResult.Cancel;
                    lngRPM.s_Cancel.Text(button3);
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

        public Form_Box(IWin32Window owner, ltext xltext, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.owner = owner;
            this.m_buttons = buttons;
            this.icon = icon;
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
                    lngRPM.s_Abort.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.Retry;
                    lngRPM.s_Retry.Text(button2);
                    button3.Visible = true;
                    button3.Tag = DialogResult.Ignore;
                    lngRPM.s_Ignore.Text(button3);
                    break;
                case MessageBoxButtons.OK:
                    button2.Visible = true;
                    button2.Tag = DialogResult.OK;
                    lngRPM.s_OK.Text(button2);
                    break;
                case MessageBoxButtons.OKCancel:
                    button1.Visible = true;
                    button1.Tag = DialogResult.OK;
                    lngRPM.s_OK.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.Cancel;
                    lngRPM.s_Cancel.Text(button2);
                    break;
                case MessageBoxButtons.RetryCancel:
                    button1.Visible = true;
                    button1.Tag = DialogResult.Retry;
                    lngRPM.s_Retry.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.Cancel;
                    lngRPM.s_Cancel.Text(button2);
                    break;
                case MessageBoxButtons.YesNo:
                    button1.Visible = true;
                    button1.Tag = DialogResult.Yes;
                    lngRPM.s_Yes.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.No;
                    lngRPM.s_No.Text(button2);
                    break;
                case MessageBoxButtons.YesNoCancel:
                    button1.Visible = true;
                    button1.Tag = DialogResult.Yes;
                    lngRPM.s_Yes.Text(button1);
                    button2.Visible = true;
                    button2.Tag = DialogResult.No;
                    lngRPM.s_No.Text(button2);
                    button3.Visible = true;
                    button3.Tag = DialogResult.Cancel;
                    lngRPM.s_Cancel.Text(button3);
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
                    DialogResult = DialogResult.OK;
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
