using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;

namespace DBSync
{
    public partial class Form_StartupWindow : Form
    {
        public Form_StartupWindow()
        {
            InitializeComponent();
            this.Text = lngRPM.s_Startup_title.s;
            this.lbl_CopyRight.Text = lngRPM.s_Copyright_KIG.s;
            this.lbl_CopyRight.BackColor = Color.Transparent;
        }
    }
}
