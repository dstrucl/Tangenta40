using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EWSoftware.ListControls;

namespace TestEWSList
{
    public partial class Form1 : Form
    {
        private DataSet demoData, productData;
        private DataTable dt = null;

        public Form1()
        {
            object dataSource;
            string displayMember, valueMember;

            InitializeComponent();

            demoData = new DataSet();
            productData = new DataSet();
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Description", typeof(string)));
            dt.Columns.Add(new DataColumn("Default", typeof(bool)));
            dt.Columns.Add(new DataColumn("ID", typeof(long)));
            dt.Rows.Add(new object[] { "000_Invoice_A4_ENG", "HTML Invoice Print Template A4", false, 1 });
            dt.Rows.Add(new object[] { "000_Invoice_A4_SLO", "HTML predloga za tiskanje računa A4", false, 1 });
            demoData.Tables.Add(dt);

            multiColumnComboBox1.BindingContext = new BindingContext();

            multiColumnComboBox1.DataSource = null;
            multiColumnComboBox1.DisplayMember = multiColumnComboBox1.ValueMember = String.Empty;
            multiColumnComboBox1.Items.Clear();

            // Clear the column filter as it may not contain columns in the new data set
            multiColumnComboBox1.ColumnFilter.Clear();

            // This will dispose of the drop-down portion and clear out all existing column definitions ready for
            // the new stuff.
            multiColumnComboBox1.RefreshSubControls();


            multiColumnComboBox1.BeginInit();
            dataSource = demoData.Tables[0];
            displayMember = "Name";
            valueMember = "ID";
            multiColumnComboBox1.EndInit();

            // Suspend updates to the combo box to speed it up and prevent flickering
            multiColumnComboBox1.BeginInit();
            dataSource = demoData.Tables[0];
            displayMember = "Name";
            valueMember = "ID";
            multiColumnComboBox1.EndInit();

            if (dataSource != null)
            {
                multiColumnComboBox1.DisplayMember = displayMember;
                multiColumnComboBox1.ValueMember = valueMember;
                multiColumnComboBox1.DataSource = dataSource;
            }


        }


        private void multiColumnComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtValue.Text = String.Format("Index = {0}, Value = {1}, Text = {2}", multiColumnComboBox1.SelectedIndex,
            multiColumnComboBox1.SelectedValue, multiColumnComboBox1.Text);

        }

        private void btnGetValue_Click(object sender, EventArgs e)
        {
            txtValue.Text = String.Format("{0} = {1}", multiColumnComboBox1.Text, multiColumnComboBox1[(int)txtRowNumber.Value,
            multiColumnComboBox1.Text]);

        }

        private void multiColumnComboBox1_DrawItemImage(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
                e.DrawBackground();
            else
            if ((e.State & DrawItemState.Disabled) != 0)
            {
                ControlPaint.DrawImageDisabled(e.Graphics, ilImages.Images[e.Index % ilImages.Images.Count],
                    e.Bounds.X, e.Bounds.Y, e.BackColor);
            }
            else
                e.Graphics.DrawImage(ilImages.Images[e.Index % ilImages.Images.Count], e.Bounds.X, e.Bounds.Y);

        }
    }
}
