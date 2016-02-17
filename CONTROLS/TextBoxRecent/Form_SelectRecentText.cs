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

namespace TextBoxRecent
{
    public partial class Form_SelectRecentText : Form
    {
        public string SelectedString = null;
        DataTable dt = new DataTable();
        private TextList m_TextList = null;
        public Form_SelectRecentText(TextList xTextList, int xpos, int ypos)
        {
            InitializeComponent();
            this.Left = xpos;
            this.Top = ypos;
            string stext = lngRPM.s_RecentText.s;
            lngRPM.s_RecentText.Text(this);
            m_TextList = xTextList;
            DataColumn dcol = new DataColumn("Text", typeof(string));
            dt.Columns.Add(dcol);
            int iCount = m_TextList.items.Count;
            int i;
            for (i= iCount-1;i>=0;i--)
            {
                DataRow dr = dt.NewRow();
                dr[0] = m_TextList.items[i];
                dt.Rows.Add(dr);
            }
            dgv.DataSource = dt;
            dgv.Columns[0].HeaderText = "";
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                SelectedString = (string)dt.Rows[e.RowIndex][0];
                this.Close();
                DialogResult = DialogResult.OK;
            }
        }
    }
}
