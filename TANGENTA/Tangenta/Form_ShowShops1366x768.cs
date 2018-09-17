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
    public partial class Form_ShowShops1366x768 : Form
    {
        private usrc_DocumentEditor1366x768 m_usrc_Invoice1366x768 = null;

        private SettingsUserValues mSettingsUserValues = null;
     

        public Form_ShowShops1366x768(usrc_DocumentEditor1366x768 x_usrc_Invoice1366x768, SettingsUserValues xSettingsUserValues)
        {
            InitializeComponent();
            mSettingsUserValues = xSettingsUserValues;
            m_usrc_Invoice1366x768 = x_usrc_Invoice1366x768;
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

            if (mSettingsUserValues.eShopsMode.Equals("A"))
            {
                rdb_A.Checked = true;
            }
            else if (mSettingsUserValues.eShopsMode.Equals("B"))
            {
                rdb_B.Checked = true;
            }
            else if (mSettingsUserValues.eShopsMode.Equals("C"))
            {
                rdb_C.Checked = true;
            }
            else if (mSettingsUserValues.eShopsMode.Equals("AB"))
            {
                rdb_AB.Checked = true;
            }
            else if (mSettingsUserValues.eShopsMode.Equals("BC"))
            {
                rdb_BC.Checked = true;
            }
            else if (mSettingsUserValues.eShopsMode.Equals("AC"))
            {
                rdb_AC.Checked = true;
            }
            else if (mSettingsUserValues.eShopsMode.Equals("ABC"))
            {
                rdb_ABC.Checked = true;
            }
            else
            {
                LogFile.Error.Show("ERROR:Form_SelectPanels:m_usrc_Invoice.m_eShopsMode illegal Mode! Properties.Settings.Default.eShopsMode = " + mSettingsUserValues.eShopsMode);
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
                mSettingsUserValues.eShopsMode = "A";
            }
            Close();
            DialogResult = DialogResult.OK;

        }

        private void Rdb_B_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_B.Checked)
            {
                mSettingsUserValues.eShopsMode = "B";
            }
            Close();
            DialogResult = DialogResult.OK;
        }

        private void Rdb_C_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_C.Checked)
            {
                mSettingsUserValues.eShopsMode = "C";
            }
            Close();
            DialogResult = DialogResult.OK;
        }

        private void Rdb_AB_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_AB.Checked)
            {
                mSettingsUserValues.eShopsMode = "AB";
            }
            Close();
            DialogResult = DialogResult.OK;
        }

        private void Rdb_BC_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_BC.Checked)
            {
                mSettingsUserValues.eShopsMode = "BC";
            }
            Close();
            DialogResult = DialogResult.OK;
        }

        private void Rdb_AC_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_AC.Checked)
            {
                mSettingsUserValues.eShopsMode = "AC";
            }
            Close();
            DialogResult = DialogResult.OK;
        }
        private void Rdb_ABC_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_ABC.Checked)
            {
                mSettingsUserValues.eShopsMode = "ABC";
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
            this.Top = m_usrc_Invoice1366x768.btn_Show_Shops.Top + m_usrc_Invoice1366x768.btn_Show_Shops.Height;
            this.Left = m_usrc_Invoice1366x768.btn_Show_Shops.Left;
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


            if (mSettingsUserValues.eShopsMode.Equals("A"))
            {
                rdb_A.Checked = true;
            }
            else if (mSettingsUserValues.eShopsMode.Equals("B"))
            {
                rdb_B.Checked = true;
            }
            else if (mSettingsUserValues.eShopsMode.Equals("C"))
            {
                rdb_C.Checked = true;
            }
            else if (mSettingsUserValues.eShopsMode.Equals("AB"))
            {
                rdb_AB.Checked = true;
            }
            else if (mSettingsUserValues.eShopsMode.Equals("BC"))
            {
                rdb_BC.Checked = true;
            }
            else if (mSettingsUserValues.eShopsMode.Equals("AC"))
            {
                rdb_AC.Checked = true;
            }
            else if (mSettingsUserValues.eShopsMode.Equals("ABC"))
            {
                rdb_ABC.Checked = true;
            }
            else
            { 
                   LogFile.Error.Show("ERROR:Form_SelectPanels:m_usrc_Invoice.m_eShopsMode illegal Mode! Properties.Settings.Default.eShopsMode =" + mSettingsUserValues.eShopsMode);
            }
        }
    }
}
