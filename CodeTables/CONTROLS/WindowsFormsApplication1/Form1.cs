using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        DataRow dr1 = null;
        DataRow dr2 = null;
        DataColumn dcolName = null;
        DataColumn dcolDescription = null;
        DataColumn dcolDefault = null;
        DataColumn dcolID = null;

        string[] ColumnsToDisplay = new string[] { "Name", "Description", "Default" };

        public Form1()
        {
            InitializeComponent();
            dcolName = new DataColumn("Name", typeof(string));
            dcolDescription = new DataColumn("Description", typeof(string));
            dcolDefault = new DataColumn("Default", typeof(bool));
            dcolID = new DataColumn("ID", typeof(long));
            dt.Columns.Add(dcolName);
            dt.Columns.Add(dcolDescription);
            dt.Columns.Add(dcolDefault);
            dt.Columns.Add(dcolID);

            dr1 = dt.NewRow();
            dr1["Name"] = "000_Invoice_A4_ENG";
            dr1["Description"] = "HTML Predloga za tiskanje slovenska";
            dr1["Default"] = true;
            dr1["ID"] = 1;
            dr2 = dt.NewRow();
            dr2["Name"] = "001_Invoice_A4_ENG";
            dr2["Description"] = "HTML  za tiskanje slovenska";
            dr2["Default"] = false;
            dr2["ID"] = 2;
            dt.Rows.Add(dr1);
            dt.Rows.Add(dr2);
            this.multiColumnComboBox1.Table = dt;
            this.multiColumnComboBox1.ColumnsToDisplay = ColumnsToDisplay;
            this.multiColumnComboBox1.DisplayMember = "Name";
            this.multiColumnComboBox1.ValueMember = "ID";
        }
    }
}
