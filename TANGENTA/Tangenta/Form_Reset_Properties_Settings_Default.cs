using LanguageControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tangenta
{
    public partial class Form_Reset_Properties_Settings_Default : Form
    {
        internal bool bTangenta_EXE = false;
        internal bool bDBConnectionControlXX_EXE = false;
        internal bool bFiscalVerification_DLL = false;
        internal bool bLangugaControl_DLL = false;
        internal bool bLogFile_DLL = false;

        public Form_Reset_Properties_Settings_Default()
        {
            InitializeComponent();
            lngRPM.s_AreYouSure_ToResetSettingsToInitialvalues.Text(label1);
            this.chk_Tangenta_EXE.Checked = true;
            this.chk_DBConnectionControl_DLL.Checked = true;
            this.chk_LanguageControl_DLL.Checked = true;
            this.chk_FiscalVerifiaction.Checked = false;
            this.chk_LogFile_DLL.Checked = true; 
            lngRPM.s_Yes.Text(btn_Yes);
            lngRPM.s_No.Text(btn_No);
        }

        private void btn_Yes_Click(object sender, EventArgs e)
        {
            bTangenta_EXE = this.chk_Tangenta_EXE.Checked;
            bDBConnectionControlXX_EXE = this.chk_DBConnectionControl_DLL.Checked;
            bLangugaControl_DLL = this.chk_LanguageControl_DLL.Checked;
            bFiscalVerification_DLL = this.chk_FiscalVerifiaction.Checked;
            bLogFile_DLL = this.chk_LogFile_DLL.Checked;
            Close();
            this.DialogResult = DialogResult.Yes;
        }

        private void btn_No_Click(object sender, EventArgs e)
        {
            Close();
            this.DialogResult = DialogResult.No;
        }

        private void Form_Reset_Properties_Settings_Default_Load(object sender, EventArgs e)
        {

        }
    }
}
