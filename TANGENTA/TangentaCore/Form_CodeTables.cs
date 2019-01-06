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
using TangentaDB;

namespace TangentaCore
{
    public partial class Form_CodeTables : Form
    {
        

        public Form_CodeTables()
        {
            InitializeComponent();
        }

        public Form_CodeTables(object x_usrc_DocumentManX)
        {
            InitializeComponent();
            lng.s_CodeTables.Text(this);
            lng.s_Issuer.Text(lbl_MyOrganisation);
            lng.s_MyOrganisation.Text(lbl_MyOrganisation);

            this.usrc_CodeTables1.M_usrc_DocumentManX = x_usrc_DocumentManX;
        

            string suser = "??";
            if (myOrg.m_myOrg_Office != null)
            {
                if (myOrg.m_myOrg_Office.m_myOrg_Person != null)
                {
                    if (myOrg.m_myOrg_Office.m_myOrg_Person.FirstName_v != null)
                    {
                        suser = myOrg.m_myOrg_Office.m_myOrg_Person.FirstName_v.v;
                    }
                    if (myOrg.m_myOrg_Office.m_myOrg_Person.LastName_v != null)
                    {
                        suser += " " + myOrg.m_myOrg_Office.m_myOrg_Person.LastName_v.v;
                    }

                }
            }
            //this.txt_Issuer.Text = suser;

        }

        private void usrc_CodeTables1_OK_Click()
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void usrc_CodeTables1_EndDialog()
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void usrc_CodeTables1_Load(object sender, EventArgs e)
        {

        }
    }
}
