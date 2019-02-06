using LanguageControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TangentaCore
{
    public partial class Form_Reset_Properties_Settings_Default : Form
    {
        public bool bTangentaProperties = false;
        public bool bDBConnectionControlXX_EXE = false;
        public bool bCodeTables_DLL = false;
        public bool bFiscalVerification_DLL = false;
        public bool bLangugaControl_DLL = false;
        public bool bTangentaPrint_DLL = false;
        public bool bLogFile_DLL = false;
        public bool bColorSettings_DLL = false;
        public bool bLayoutSettings = false;

        public Form_Reset_Properties_Settings_Default()
        {
            InitializeComponent();
            lng.s_AreYouSure_ToResetSettingsToInitialvalues.Text(label1);
            this.chk_TangentaProperties.Checked = true;
            this.chk_DBConnectionControl_DLL.Checked = true;
            this.chk_CodeTables_DLL.Checked = true;
            this.chk_LanguageControl_DLL.Checked = true;
            this.chk_TangentaPrint_DLL.Checked = true;
            this.chk_FiscalVerifiaction.Checked = false;
            this.chk_LogFile_DLL.Checked = true;
            this.chk_ColorSettings_DLL.Checked = true;
            this.chk_LayoutSettings.Checked = true;
            lng.s_Yes.Text(btn_Yes);
            lng.s_No.Text(btn_No);
            lng.s_Form_Reset_Properties_Settings_Default.Text(this);
        }

        private void btn_Yes_Click(object sender, EventArgs e)
        {
            bTangentaProperties = this.chk_TangentaProperties.Checked;
            bDBConnectionControlXX_EXE = this.chk_DBConnectionControl_DLL.Checked;
            bCodeTables_DLL = this.chk_CodeTables_DLL.Checked;
            bLangugaControl_DLL = this.chk_LanguageControl_DLL.Checked;
            bTangentaPrint_DLL = this.chk_TangentaPrint_DLL.Checked;
            bFiscalVerification_DLL = this.chk_FiscalVerifiaction.Checked;
            bLogFile_DLL = this.chk_LogFile_DLL.Checked;
            bColorSettings_DLL = this.chk_ColorSettings_DLL.Checked;
            bLayoutSettings = this.chk_LayoutSettings.Checked;
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
