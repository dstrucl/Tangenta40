using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErrorCreateWindowHandle
{
    public partial class Form1 : Form
    {
        int ypos = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_DeleteAndCreateNew_Click(object sender, EventArgs e)
        {
            ypos = 0;
            m_usrc_ItemList.DeleteAndCreateNew(ref ypos);
            SetGDICounts();
        }

        private void SetGDICounts()
        {
            int diff_after_delete = Program.iGDIcUser100 - Program.iGDIcUser101;
            int diff_after_insert = Program.iGDIcUser102 - Program.iGDIcUser101;
            lbl_GDI_counts.Text = "GDI handels count: start = " + Program.iGDIcUser100.ToString() + ", after delete = " + Program.iGDIcUser101.ToString() + ", Diff after delete =" + diff_after_delete.ToString() + " after create = " + Program.iGDIcUser102.ToString() + ", Diff After Insert = " + diff_after_insert.ToString();
        }
    }
}
