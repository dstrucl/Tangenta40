﻿#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace uwpfGUI
{
    /// <summary>
    /// Interaction logic for Upgrade_Progress_Window.xaml
    /// </summary>
    public partial class Upgrade_Progress_Window : Window
    {
        public Upgrade_Progress_Window()
        {
            InitializeComponent();
            
        }

        public void Set_lbl_Info(string m_Message)
        {
            if (m_Message.Substring(0,3).Equals("$$$"))
            {
                this.Title = m_Message.Substring(3, m_Message.Length - 3);
            }
            else
            { 
                lbl_Info.Text = m_Message;
            }
        }
    }
}
