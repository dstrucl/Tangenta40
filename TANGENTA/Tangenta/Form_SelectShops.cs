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
    public partial class Form_SelectShops : Form
    {
        usrc_Invoice m_usrc_Invoice = null;
        public Form_SelectShops(usrc_Invoice x_usrc_Invoice)
        {
            InitializeComponent();
            m_usrc_Invoice = x_usrc_Invoice;
            lngRPM.s_Shop_A.Text(rdb_A);
            lngRPM.s_Shop_B.Text(rdb_B);
            lngRPM.s_Shop_C.Text(rdb_C);
            lngRPM.s_Shop_AB.Text(rdb_AB);
            lngRPM.s_Shop_BC.Text(rdb_BC);
            lngRPM.s_Shop_AC.Text(rdb_AC);
            lngRPM.s_Shop_ABC.Text(rdb_ABC);


            rdb_A.Checked = false;
            rdb_B.Checked = false;
            rdb_C.Checked = false;
            rdb_AB.Checked = false;
            rdb_BC.Checked = false;
            rdb_AC.Checked = false;
            rdb_ABC.Checked = false;

            switch (x_usrc_Invoice.m_eShopsMode)
            {
                case usrc_Invoice.eShopsMode.A:
                    rdb_A.Checked = true;
                    break;
                case usrc_Invoice.eShopsMode.B:
                    rdb_B.Checked = true;
                    break;
                case usrc_Invoice.eShopsMode.C:
                    rdb_C.Checked = true;
                    break;
                case usrc_Invoice.eShopsMode.AB:
                    rdb_AB.Checked = true;
                    break;
                case usrc_Invoice.eShopsMode.BC:
                    rdb_BC.Checked = true;
                    break;
                case usrc_Invoice.eShopsMode.AC:
                    rdb_AC.Checked = true;
                    break;
                case usrc_Invoice.eShopsMode.ABC:
                    rdb_ABC.Checked = true;
                    break;
                default:
                    LogFile.Error.Show("ERROR:Form_SelectPanels:m_usrc_Invoice.m_eShopsMode illegal Mode!");
                    break;
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
                m_usrc_Invoice.Set_eShopsMode(usrc_Invoice.eShopsMode.A);
            }
            Close();
            DialogResult = DialogResult.OK;

        }

        private void Rdb_B_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_B.Checked)
            {
                m_usrc_Invoice.Set_eShopsMode(usrc_Invoice.eShopsMode.B);
            }
            Close();
            DialogResult = DialogResult.OK;
        }

        private void Rdb_C_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_C.Checked)
            {
                m_usrc_Invoice.Set_eShopsMode(usrc_Invoice.eShopsMode.C);
            }
            Close();
            DialogResult = DialogResult.OK;
        }

        private void Rdb_AB_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_AB.Checked)
            {
                m_usrc_Invoice.Set_eShopsMode(usrc_Invoice.eShopsMode.AB);
            }
            Close();
            DialogResult = DialogResult.OK;
        }

        private void Rdb_BC_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_BC.Checked)
            {
                m_usrc_Invoice.Set_eShopsMode(usrc_Invoice.eShopsMode.BC);
            }
            Close();
            DialogResult = DialogResult.OK;
        }

        private void Rdb_AC_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_AC.Checked)
            {
                m_usrc_Invoice.Set_eShopsMode(usrc_Invoice.eShopsMode.AC);
            }
            Close();
            DialogResult = DialogResult.OK;
        }
        private void Rdb_ABC_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_ABC.Checked)
            {
                m_usrc_Invoice.Set_eShopsMode(usrc_Invoice.eShopsMode.ABC);
            }
            Close();
            DialogResult = DialogResult.OK;
        }


        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.OK;
        }

        private void Form_SelectPanels_Load(object sender, EventArgs e)
        {
            this.Top = m_usrc_Invoice.btn_Select_Shops.Top + m_usrc_Invoice.btn_Select_Shops.Height;
            this.Left = m_usrc_Invoice.btn_Select_Shops.Left;
        }
    }
}
