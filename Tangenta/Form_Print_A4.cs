using BlagajnaTableClass;
using LanguageControl;
using SQLTableControl;
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
    public partial class Form_Print_A4 : Form
    {
        public Form_Print_A4()
        {
            InitializeComponent();
            lngRPM.s_Template.Text(lbl_Template, ":");
        }

        private void btn_EditTemplates_Click(object sender, EventArgs e)
        {
            SQLTable tbl_doc = new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(doc)));
            Form_Templates edt_doc_dlg = new Form_Templates(DBSync.DBSync.DB_for_Blagajna.m_DBTables,
                                                            tbl_doc,
                                                            "doc_$$Name");
            edt_doc_dlg.ShowDialog();

        
        }
    }
}
