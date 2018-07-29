#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using TangentaDB;
using LanguageControl;
using System;
using System.Collections.Generic;
using System.Drawing;
//using System.Collections.Generic;
//using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using DBConnectionControl40;

namespace FiscalVerificationOfInvoices_SLO
{
    public partial class usrc_FVI_SLO : UserControl
    {
        internal Form_MainFiscal frm_main = null;

        public FVI_SLO m_FVI_SLO = null;

        private Image m_Image_ButtonExit = null;
        public Image Image_ButtonExit
        {
            get { return m_Image_ButtonExit; }
            set { m_Image_ButtonExit = value; }
        }

        public delegate void deleagteRequestPasswordCheck(ref bool PasswordOK);
        public event deleagteRequestPasswordCheck PasswordCheck = null;

        public new bool Enabled
        {
            get
            {
                return base.Enabled;
            }
            set
            {
                bool benabled = value;
                base.Enabled = benabled;
                if (benabled)
                {
                    if (m_FVI_SLO.IsRunning)
                    {
                        btn_FVI.Enabled = true;
                    }
                    else
                    {
                        btn_FVI.Enabled = false;
                    }
                }
                
            }
        }
        #region Metods

        public usrc_FVI_SLO()
        {
            InitializeComponent();
            btn_FVI.Enabled = false;
        }

        public void Bind(FVI_SLO xfvislo)
        {
            m_FVI_SLO = xfvislo;
        }
        private void usrc_FVI_SLO_Load(object sender, EventArgs e)
        {
        }

        private void btn_FVI_Click(object sender, EventArgs e)
        {

            if (PasswordCheck!=null)
            {
                bool bPasswordOK = false;
                PasswordCheck(ref bPasswordOK);
                {
                    if (!bPasswordOK)
                    {
                        return;
                    }
                }
            }
            frm_main = new Form_MainFiscal(m_FVI_SLO);
            frm_main.PasswordCheck = this.PasswordCheck;
            frm_main.ShowDialog(this);
            frm_main = null;
        }
        #endregion
    }
}
