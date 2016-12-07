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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DBTypes;
using LanguageControl;
using FiscalVerificationOfInvoices_SLO;
using TangentaDB;
using UniversalInvoice;

namespace Tangenta
{
    public partial class usrc_Printer : UserControl
    {
        public Printer Printer = new Printer();

        Form_PrinterSettings m_frm_prn_settings = null;

        public NavigationButtons.Navigation nav = null;




        public usrc_Printer()
        {
            InitializeComponent();
        }

        private void btn_Printer_Click(object sender, EventArgs e)
        {
            m_frm_prn_settings = new Form_PrinterSettings(this);
            m_frm_prn_settings.ShowDialog();
            m_frm_prn_settings = null;

        }
    }
}
