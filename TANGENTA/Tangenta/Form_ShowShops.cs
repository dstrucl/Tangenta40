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
        private SettingsUserValues mSettingsUserValues = null;
        public Form_ShowShops(usrc_DocumentEditor x_usrc_Invoice,SettingsUserValues xSettingsUserValues)
        {
            const int TOPM = 10;
            const int YDIST = 10;
            const int BDIST = 60;

            InitializeComponent();
            mSettingsUserValues = xSettingsUserValues;
            m_usrc_Invoice = x_usrc_Invoice;
            lng.s_Show_Shops.Text(this);
            lng.s_Shop_A.Text(rdb_A);
            lng.s_Shop_B.Text(rdb_B);
            lng.s_Shop_C.Text(rdb_C);
            lng.s_Shop_AB.Text(rdb_AB);
            lng.s_Shop_BC.Text(rdb_BC);
            lng.s_Shop_AC.Text(rdb_AC);
            lng.s_Shop_ABC.Text(rdb_ABC);
            PropertiesUser.SetRadioButtons(
          TOPM,
          YDIST,
          BDIST,
          this,
          btn_Cancel,
          m_usrc_Invoice.DocE.mSettingsUserValues,
          rdb_A,
          rdb_B,
          rdb_C,
          rdb_AB,
          rdb_BC,
          rdb_AC,
          rdb_ABC
         );

            rdb_A.Checked = false;
            rdb_B.Checked = false;
            rdb_C.Checked = false;
            rdb_AB.Checked = false;
            rdb_BC.Checked = false;
            rdb_AC.Checked = false;
            rdb_ABC.Checked = false;

            if (mSettingsUserValues.eShowShops.Equals("A"))
            {
                rdb_A.Checked = true;
            }
            else if (mSettingsUserValues.eShowShops.Equals("B"))
            {
                rdb_B.Checked = true;
            }
            else if (mSettingsUserValues.eShowShops.Equals("C"))
            {
                rdb_C.Checked = true;
            }
            else if (mSettingsUserValues.eShowShops.Equals("AB"))
            {
                rdb_AB.Checked = true;
            }
            else if (mSettingsUserValues.eShowShops.Equals("BC"))
            {
                rdb_BC.Checked = true;
            }
            else if (mSettingsUserValues.eShowShops.Equals("AC"))
            {
                rdb_AC.Checked = true;
            }
            else if (mSettingsUserValues.eShowShops.Equals("ABC"))
            {
                rdb_ABC.Checked = true;
            }
            else
            { 
                    LogFile.Error.Show("ERROR:Form_SelectPanels:m_usrc_Invoice.m_eShopsMode illegal Mode! Properties.Settings.Default.eShopsMode = " + mSettingsUserValues.eShowShops);
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
                mSettingsUserValues.eShowShops = "A";
            }
            Close();
            DialogResult = DialogResult.OK;

        }

        private void Rdb_B_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_B.Checked)
            {
                mSettingsUserValues.eShowShops = "B";
            }
            Close();
            DialogResult = DialogResult.OK;
        }

        private void Rdb_C_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_C.Checked)
            {
                mSettingsUserValues.eShowShops = "C";
            }
            Close();
            DialogResult = DialogResult.OK;
        }

        private void Rdb_AB_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_AB.Checked)
            {
                mSettingsUserValues.eShowShops = "AB";
            }
            Close();
            DialogResult = DialogResult.OK;
        }

        private void Rdb_BC_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_BC.Checked)
            {
                mSettingsUserValues.eShowShops = "BC";
            }
            Close();
            DialogResult = DialogResult.OK;
        }

        private void Rdb_AC_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_AC.Checked)
            {
                mSettingsUserValues.eShowShops = "AC";
            }
            Close();
            DialogResult = DialogResult.OK;
        }
        private void Rdb_ABC_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_ABC.Checked)
            {
                mSettingsUserValues.eShowShops = "ABC";
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
            this.Top = m_usrc_Invoice.btn_Show_Shops.Top + m_usrc_Invoice.btn_Show_Shops.Height;
            this.Left = m_usrc_Invoice.btn_Show_Shops.Left;
        }
    }
}
