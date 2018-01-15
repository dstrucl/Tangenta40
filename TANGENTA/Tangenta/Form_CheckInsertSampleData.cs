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
        private NavigationButtons.Navigation nav = null;
        private bool m_WritePredefinedDefaultDataInDataBase = false;
        public bool WritePredefinedDefaultDataInDataBase
        {
            get {return  m_WritePredefinedDefaultDataInDataBase; }
        }
        public Form_CheckInsertSampleData(startup xmyStartup, NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;
            usrc_NavigationButtons1.Init(nav);
            lng.s_DataBaseIsEmpty_InsertInitialData.Text(this.lbl_Message1);
            lng.s_DataBaseIsEmpty_EnterData.Text(this.lbl_Message2);
            lng.s_Write_predefined_data_into_a_new_database.Text(this.rdb_WritePredefinedDefaultDataInDataBase);
            lng.s_Enter_your_data_manually.Text(this.rdb_Enter_data_into_a_new_database_table);
            this.rdb_Enter_data_into_a_new_database_table.Checked = false;
            this.rdb_WritePredefinedDefaultDataInDataBase.Checked = true;
            this.myStartup = xmyStartup;
            this.Text = "";
            if (myStartup.m_FormIconQuestion != null)
            {
                this.Icon = myStartup.m_FormIconQuestion;
            }
        }

        private void Do_Cancel()
        {
            myStartup.bCanceled = true;
            myStartup.bInsertSampleData = false;
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void do_OK()
        {
            myStartup.bCanceled = false;
            myStartup.bInsertSampleData = rdb_WritePredefinedDefaultDataInDataBase.Checked;
            m_WritePredefinedDefaultDataInDataBase = rdb_WritePredefinedDefaultDataInDataBase.Checked;
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void rdb_Enter_data_into_a_new_database_table_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void usrc_NavigationButtons1_ButtonPressed(NavigationButtons.Navigation.eEvent evt)
        {
            nav.eExitResult = evt;
            switch (evt)
            {
                case NavigationButtons.Navigation.eEvent.NEXT:
                    do_OK();
                    break;
                case NavigationButtons.Navigation.eEvent.PREV:
                    Do_Cancel();
                    break;
                case NavigationButtons.Navigation.eEvent.EXIT:
                    Do_Cancel();
                    break;
            }
        }
    }
}
