﻿#region LICENSE 
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

namespace LogFile
{
    public partial class Connections_Form : Form
    {
        private List<Connection_Control> m_Connections;
        public Connections_Form(List<Log_DBConnection> Connections)
        {
            InitializeComponent();
            int y = 10;
            m_Connections = new List<Connection_Control>();
            foreach (Log_DBConnection con in Connections)
            {
                if (con != null)
                {
                    Connection_Control ctrl = new Connection_Control(con);
                    m_Connections.Add(ctrl);
                    ctrl.Parent = this;
                    ctrl.Top = y;
                    y += ctrl.Height + 10;
                    this.Controls.Add(ctrl);
                }
            }
            btn_OK.Top = y;
        }

        private void Connections_Form_Load(object sender, EventArgs e)
        {
            this.Height = btn_OK.Top + btn_OK.Height + 60;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
