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
using DBConnectionControl40;

namespace DBSync
{
    public partial class Form_GetDBType : Form
    {
        public DBConnection.eDBType m_DBType = DBConnection.eDBType.SQLITE;
        public Form_GetDBType(string sdbtype)
        {
            InitializeComponent();
            lngRPM.s_SelectDatabase.Text(lbl_SelectDataBase);
            if (sdbtype != null)
            {
                if (sdbtype.Equals("SQLITE"))
                {
                    rdb_SQLite.Checked = true;
                    rdb_MSSQL.Checked = false;
                    m_DBType = DBConnection.eDBType.SQLITE;
                }
                else if (sdbtype.Equals("MSSQL"))
                {
                    rdb_SQLite.Checked = false;
                    rdb_MSSQL.Checked = true;
                    m_DBType = DBConnection.eDBType.MSSQL;
                }
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (rdb_SQLite.Checked)
            {
                m_DBType = DBConnection.eDBType.SQLITE;
            }
            else
            {
                m_DBType = DBConnection.eDBType.MSSQL;
            }
            this.Close();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
