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

namespace LanguageControl
{
    public partial class Form_complex_text_edit : Form
    {
        ltext m_ltext = null;

        const int ITEM_HEIGHT = 24;
        const int BTN_HEIGHT = ITEM_HEIGHT;
        const int BTN_WIDTH = 48;
        const int LBL_WIDTH = 300;
        const int LBL_HEIGHT = ITEM_HEIGHT;
        const int CTRL_DISTANCE = 2;
        const int MAX_LBL_STRING_LENGTH = 60;
        public Form_complex_text_edit(ltext xltext)
        {
            InitializeComponent();
            m_ltext = xltext;
            if (m_ltext.complex_text_list!=null)
            {
                int y = 2;
                int x = 10;
                foreach (object o in m_ltext.complex_text_list)
                {   
                   if  (o is ltext)
                   {
                        Button btn = new Button();
                        btn.Text = "Edit";
                        btn.Width = BTN_WIDTH;
                        btn.Height = BTN_HEIGHT;
                        btn.Left = x;
                        btn.Top = y;
                        btn.Tag = o;
                        btn.Click += btn_Click;
                        Label lbl = new Label();
                        string s = ((ltext)o).GetText(0);
                        if (s.Length < MAX_LBL_STRING_LENGTH)
                        {
                            lbl.Text = s;
                        }
                        else
                        {
                            lbl.Text = s.Substring(0, MAX_LBL_STRING_LENGTH) + " ...";
                        }
                        lbl.Width = LBL_WIDTH;
                        lbl.Left = btn.Left + btn.Width + CTRL_DISTANCE;
                        lbl.Top = btn.Top;
                        lbl.Height = btn.Height;
                        this.Controls.Add(btn);
                        this.Controls.Add(lbl);
                   }
                   else if (o is string)
                   {
                       Label lbl = new Label();
                           lbl.Text = (string)o;
                           lbl.Width = LBL_WIDTH;
                           lbl.Left = x + BTN_WIDTH + CTRL_DISTANCE;
                           lbl.Top = y;
                           lbl.Height = LBL_HEIGHT;
                           this.Controls.Add(lbl);
                   }
                   y += ITEM_HEIGHT + CTRL_DISTANCE;
                }
            }
        }

        void btn_Click(object sender, EventArgs e)
        {
            ltext xltext = (ltext)((Button)sender).Tag;
            xltext.Edit(ref xltext);
        }
    }
}
