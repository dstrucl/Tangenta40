﻿using DBConnectionControl40;
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

namespace Tangenta
{
    public partial class Form_NewDocument_WorkArea : Form
    {
        public xCurrency Currency = null;
        public ID Atom_Currency_ID = null;
        public int FinancialYear = -1;
        public WArea Warea = null;

        public Form_NewDocument.e_NewDocument eNewDocumentResult = Form_NewDocument.e_NewDocument.UNKNOWN;

        DataTable m_dtWorkAreaAll = null;

        public Form_NewDocument_WorkArea(DataTable x_dtWorkAreaAll)
        {
            InitializeComponent();
            Currency = GlobalData.BaseCurrency;
            f_Atom_Currency.Get(Currency.ID, ref Atom_Currency_ID);
            m_dtWorkAreaAll = x_dtWorkAreaAll;


        }
    

        private void Form_NewDocument_WorkArea_Load(object sender, EventArgs e)
        {
                this.usrc_WorkAreaAll1.dtWorkAreaAll = m_dtWorkAreaAll;
                this.usrc_WorkAreaAll1.Init();
        }

        private void usrc_WorkAreaAll1_Selected(WArea warea)
        {
            Warea = warea;
            eNewDocumentResult = Form_NewDocument.e_NewDocument.New_Empty;
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void usrc_WorkAreaAll1_Exit()
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }
    }
}
