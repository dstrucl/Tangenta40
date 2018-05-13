#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using LanguageControl;
using System;
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
    public partial class Form_ShowShops : Form
    {
        private usrc_DocumentEditor m_usrc_Invoice = null;
        public Form_ShowShops(usrc_DocumentEditor x_usrc_Invoice)
        {
            InitializeComponent();
            m_usrc_Invoice = x_usrc_Invoice;
            lng.s_Show_Shops.Text(this);
            lng.s_Shop_A.Text(rdb_A);
            lng.s_Shop_B.Text(rdb_B);
            lng.s_Shop_C.Text(rdb_C);
            lng.s_Shop_AB.Text(rdb_AB);
            lng.s_Shop_BC.Text(rdb_BC);
            lng.s_Shop_AC.Text(rdb_AC);
            lng.s_Shop_ABC.Text(rdb_ABC);


            rdb_A.Checked = false;
            rdb_B.Checked = false;
            rdb_C.Checked = false;
            rdb_AB.Checked = false;
            rdb_BC.Checked = false;
            rdb_AC.Checked = false;
            rdb_ABC.Checked = false;

            if (Properties.Settings.Default.eShopsMode.Equals("A"))
            {
                rdb_A.Checked = true;
            }
            else if (Properties.Settings.Default.eShopsMode.Equals("B"))
            {
                rdb_B.Checked = true;
            }
            else if (Properties.Settings.Default.eShopsMode.Equals("C"))
            {
                rdb_C.Checked = true;
            }
            else if (Properties.Settings.Default.eShopsMode.Equals("AB"))
            {
                rdb_AB.Checked = true;
            }
            else if (Properties.Settings.Default.eShopsMode.Equals("BC"))
            {
                rdb_BC.Checked = true;
            }
            else if (Properties.Settings.Default.eShopsMode.Equals("AC"))
            {
                rdb_AC.Checked = true;
            }
            else if (Properties.Settings.Default.eShopsMode.Equals("ABC"))
            {
                rdb_ABC.Checked = true;
            }
            else
            { 
                    LogFile.Error.Show("ERROR:Form_SelectPanels:m_usrc_Invoice.m_eShopsMode illegal Mode! Properties.Settings.Default.eShopsMode = " + Properties.Settings.Default.eShopsMode);
            }
            rdb_A.CheckedChanged += Rdb_A_CheckedChanged;
            rdb_B.CheckedChanged += Rdb_B_CheckedChanged;
            rdb_C.CheckedChanged += Rdb_C_CheckedChanged; 
            rdb_AB.CheckedChanged += Rdb_AB_CheckedChanged;
            rdb_BC.CheckedChanged += Rdb_BC_CheckedChanged;
            rdb_AC.CheckedChanged += Rdb_AC_CheckedChanged;
            rdb_ABC.CheckedChanged += Rdb_ABC_CheckedChanged;
        }

        private void Rdb_A_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_A.Checked)
            {
                Properties.Settings.Default.eShopsMode = "A";
                Properties.Settings.Default.Save();
            }
            Close();
            DialogResult = DialogResult.OK;

        }

        private void Rdb_B_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_B.Checked)
            {
                Properties.Settings.Default.eShopsMode = "B";
                Properties.Settings.Default.Save();
            }
            Close();
            DialogResult = DialogResult.OK;
        }

        private void Rdb_C_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_C.Checked)
            {
                Properties.Settings.Default.eShopsMode = "C";
                Properties.Settings.Default.Save();
            }
            Close();
            DialogResult = DialogResult.OK;
        }

        private void Rdb_AB_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_AB.Checked)
            {
                Properties.Settings.Default.eShopsMode = "AB";
                Properties.Settings.Default.Save();
            }
            Close();
            DialogResult = DialogResult.OK;
        }

        private void Rdb_BC_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_BC.Checked)
            {
                Properties.Settings.Default.eShopsMode = "BC";
                Properties.Settings.Default.Save();
            }
            Close();
            DialogResult = DialogResult.OK;
        }

        private void Rdb_AC_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_AC.Checked)
            {
                Properties.Settings.Default.eShopsMode = "AC";
                Properties.Settings.Default.Save();
            }
            Close();
            DialogResult = DialogResult.OK;
        }
        private void Rdb_ABC_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_ABC.Checked)
            {
                Properties.Settings.Default.eShopsMode = "ABC";
                Properties.Settings.Default.Save();
            }
            Close();
            DialogResult = DialogResult.OK;
        }


        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.Cancel;
        }

        private void Form_SelectPanels_Load(object sender, EventArgs e)
        {
            const int TOPM = 10;
            const int YDIST = 10;
            const int BDIST = 60;
            this.Top = m_usrc_Invoice.btn_Show_Shops.Top + m_usrc_Invoice.btn_Show_Shops.Height;
            this.Left = m_usrc_Invoice.btn_Show_Shops.Left;
            string shinuse = Program.Shops_in_use;

            if (shinuse.Equals("A"))
            {
                rdb_A.Checked = true;
                rdb_A.Enabled = false;
                rdb_A.Visible = true;
                rdb_B.Visible = false;
                rdb_C.Visible = false;
                rdb_AB.Visible = false;
                rdb_AC.Visible = false;
                rdb_ABC.Visible = false;
                rdb_A.Top = TOPM;
                btn_Cancel.Top = rdb_A.Bottom + YDIST;
                this.Height = btn_Cancel.Bottom + BDIST;
            }

            if (shinuse.Equals("B"))
            {
                rdb_B.Checked = true;
                rdb_B.Enabled = false;
                rdb_B.Visible = true;
                rdb_A.Visible = false;
                rdb_C.Visible = false;
                rdb_AB.Visible = false;
                rdb_AC.Visible = false;
                rdb_ABC.Visible = false;
                rdb_B.Top = TOPM;
                btn_Cancel.Top = rdb_B.Bottom + YDIST;
                this.Height = btn_Cancel.Bottom + BDIST;
            }

            if (shinuse.Equals("C"))
            {
                rdb_A.Visible = false;
                rdb_C.Checked = true;
                rdb_C.Enabled = false;
                rdb_C.Visible = true;
                rdb_B.Visible = false;
                rdb_AB.Visible = false;
                rdb_AC.Visible = false;
                rdb_ABC.Visible = false;
                rdb_C.Top = TOPM;
                btn_Cancel.Top = rdb_C.Bottom + YDIST;
                this.Height = btn_Cancel.Bottom + BDIST;
            }

            if (shinuse.Equals("AB"))
            {
                rdb_A.Enabled = true;
                rdb_A.Visible = true;
                rdb_B.Visible = true;
                rdb_B.Enabled = true;
                rdb_AB.Visible = true;
                rdb_AB.Enabled = true;

                rdb_C.Visible = false;
                rdb_AC.Visible = false;
                rdb_ABC.Visible = false;

                rdb_A.Top = TOPM;
                rdb_B.Top = rdb_A.Bottom + YDIST;
                rdb_AB.Top = rdb_B.Bottom + YDIST;
                btn_Cancel.Top = rdb_AB.Bottom + YDIST;
                this.Height = btn_Cancel.Bottom + BDIST;
            }

            if (shinuse.Equals("AC"))
            {
                rdb_A.Enabled = true;
                rdb_A.Visible = true;
                rdb_C.Visible = true;
                rdb_C.Enabled = true;
                rdb_AC.Visible = true;
                rdb_AC.Enabled = true;

                rdb_B.Visible = false;
                rdb_AB.Visible = false;
                rdb_ABC.Visible = false;

                rdb_A.Top = TOPM;
                rdb_C.Top = rdb_A.Bottom + YDIST;
                rdb_AC.Top = rdb_C.Bottom + YDIST;
                btn_Cancel.Top = rdb_AC.Bottom + YDIST;
                this.Height = btn_Cancel.Bottom + BDIST;
            }

            if (shinuse.Equals("BC"))
            {
                rdb_B.Enabled = true;
                rdb_B.Visible = true;
                rdb_C.Visible = true;
                rdb_C.Enabled = true;
                rdb_BC.Visible = true;
                rdb_BC.Enabled = true;

                rdb_A.Visible = false;
                rdb_AB.Visible = false;
                rdb_AC.Visible = false;
                rdb_ABC.Visible = false;

                rdb_B.Top = TOPM;
                rdb_C.Top = rdb_B.Bottom + YDIST;
                rdb_BC.Top = rdb_C.Bottom + YDIST;
                btn_Cancel.Top = rdb_BC.Bottom + YDIST;
                this.Height = btn_Cancel.Bottom + BDIST;
            }

            if (shinuse.Equals("ABC"))
            {
                rdb_A.Visible = true;
                rdb_A.Enabled = true;
                rdb_B.Enabled = true;
                rdb_B.Visible = true;
                rdb_C.Visible = true;
                rdb_C.Enabled = true;
                rdb_AB.Visible = true;
                rdb_AB.Enabled = true;
                rdb_AC.Visible = true;
                rdb_AC.Enabled = true;
                rdb_BC.Visible = true;
                rdb_BC.Enabled = true;
                rdb_ABC.Visible = true;
                rdb_ABC.Enabled = true;

                rdb_A.Top = TOPM;
                rdb_B.Top = rdb_A.Bottom + YDIST;
                rdb_C.Top = rdb_B.Bottom + YDIST;
                rdb_AB.Top = rdb_C.Bottom + YDIST;
                rdb_AC.Top = rdb_AB.Bottom + YDIST;
                rdb_BC.Top = rdb_AC.Bottom + YDIST;
                rdb_ABC.Top = rdb_BC.Bottom + YDIST;
                btn_Cancel.Top = rdb_ABC.Bottom + YDIST;
                this.Height = btn_Cancel.Bottom + BDIST;
            }


            if (Properties.Settings.Default.eShopsMode.Equals("A"))
            {
                rdb_A.Checked = true;
            }
            else if (Properties.Settings.Default.eShopsMode.Equals("B"))
            {
                rdb_B.Checked = true;
            }
            else if (Properties.Settings.Default.eShopsMode.Equals("C"))
            {
                rdb_C.Checked = true;
            }
            else if (Properties.Settings.Default.eShopsMode.Equals("AB"))
            {
                rdb_AB.Checked = true;
            }
            else if (Properties.Settings.Default.eShopsMode.Equals("BC"))
            {
                rdb_BC.Checked = true;
            }
            else if (Properties.Settings.Default.eShopsMode.Equals("AC"))
            {
                rdb_AC.Checked = true;
            }
            else if (Properties.Settings.Default.eShopsMode.Equals("ABC"))
            {
                rdb_ABC.Checked = true;
            }
            else
            { 
                   LogFile.Error.Show("ERROR:Form_SelectPanels:m_usrc_Invoice.m_eShopsMode illegal Mode! Properties.Settings.Default.eShopsMode =" + Properties.Settings.Default.eShopsMode);
            }
        }

        private void rdb_A_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
}
