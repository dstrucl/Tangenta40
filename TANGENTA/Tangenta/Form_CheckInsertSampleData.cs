using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Startup;
using LanguageControl;

namespace Tangenta
{
    public partial class Form_CheckInsertSampleData : Form
    {
        private startup myStartup;


        public Form_CheckInsertSampleData(startup xmyStartup)
        {
            InitializeComponent();
            lngRPM.s_DataBaseIsEmpty_InsertInitialData.Text(this.lbl_Message1);
            lngRPM.s_DataBaseIsEmpty_EnterData.Text(this.lbl_Message2);
            lngRPM.s_Write_predefined_data_into_a_new_database.Text(this.rdb_WritePredefinedDefaultDataInDataBase);
            lngRPM.s_Enter_your_data_manually.Text(this.rdb_Enter_data_into_a_new_database_table);
            this.rdb_Enter_data_into_a_new_database_table.Checked = false;
            this.rdb_WritePredefinedDefaultDataInDataBase.Checked = true;
            this.myStartup = xmyStartup;
            this.Text = "";
            lngRPM.s_OK.Text(this.btn_OK);
            if (myStartup.m_FormIconQuestion != null)
            {
                this.Icon = myStartup.m_FormIconQuestion;
            }
            if (xmyStartup.m_ImageCancel != null)
            {
                btn_Cancel.Text = "";
                btn_Cancel.Image = xmyStartup.m_ImageCancel;
            }
            else
            {
                lngRPM.s_Cancel.Text(this.btn_Cancel);
            }
            this.btn_OK.Focus();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            myStartup.bCanceled = true;
            myStartup.bInsertSampleData = false;
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            myStartup.bCanceled = false;
            myStartup.bInsertSampleData = true;
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void lbl_Message2_Click(object sender, EventArgs e)
        {

        }

        private void rdb_Enter_data_into_a_new_database_table_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
