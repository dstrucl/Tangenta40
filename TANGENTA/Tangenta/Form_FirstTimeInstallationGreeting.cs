﻿using System;
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
    public partial class Form_FirstTimeInstallationGreeting : Form
    {
        public Form_FirstTimeInstallationGreeting()
        {
            InitializeComponent();
        }

        private void Form_FirstTimeInstallationGreeting_Load(object sender, EventArgs e)
        {
            this.usrc_web_Help1.ShowInstallationFinished();
        }
    }
}
