using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TangentaDB;
using NavigationButtons;
using CodeTables;
using TangentaTableClass;

namespace Tangenta
{
    public partial class usrc_Currency : UserControl
    {
        public delegate void delegate_CurrencyChanged(xCurrency Currency, long Atom_Currency_ID);
        public event delegate_CurrencyChanged CurrencyChanged = null;

        public xCurrency Currency = new xCurrency();
        public long Atom_Currency_ID = -1;
        public usrc_Currency()
        {
            InitializeComponent();
            lng.s_Currency.Text(lbl_Currency);
        }
        public void Init(xCurrency xcurrency)
        {
            if (xcurrency != null)
            {
                txt_Currency.Text = xcurrency.Abbreviation;
                Currency.ID = xcurrency.ID;
                Currency.Name = xcurrency.Name;
                Currency.Abbreviation = xcurrency.Abbreviation;
                Currency.Symbol = xcurrency.Symbol;
                Currency.CurrencyCode = xcurrency.CurrencyCode;
                Currency.DecimalPlaces = xcurrency.DecimalPlaces;
                f_Atom_Currency.Get(Currency.ID, ref Atom_Currency_ID);
            }
            else
            {
                txt_Currency.Text = "";
            }
        }

        private void btn_SelectCurrency_Click(object sender, EventArgs e)
        {
            string Err = null;
            NavigationButtons.Navigation xnav = new NavigationButtons.Navigation(null);
            xnav.m_eButtons = NavigationButtons.Navigation.eButtons.OkCancel;
            xnav.btn1_Text = lng.s_OK.s;
            xnav.btn1_Image = null;
            xnav.btn2_Text = lng.s_Cancel.s; ;
            xnav.btn2_Image = null;
            xnav.btn1_Visible = true;
            xnav.btn2_Visible = true;
            xnav.btn3_Visible = false;
            Select_Currency(xnav, ref Err);
        }

        private void Select_Currency(Navigation xnav, ref string err)
        {
            SQLTable tbl_Currency = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Currency)));
            tbl_Currency.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
            string sql = @"SELECT
            Name,
            Abbreviation,
            Symbol,
            CurrencyCode,
            DecimalPlaces
            FROM Currency
            ";
            string[] sColumnsToView = new string[] { "Name",
                                                     "Abbreviation",
                                                     "Symbol",
                                                     "CurrencyCode",
                                                    "DecimalPlaces"
                                                    };


            CodeTables.SelectID_Table_Assistant_Form selectID_Table_Assistant_Form = new SelectID_Table_Assistant_Form(sql, tbl_Currency, DBSync.DBSync.DB_for_Tangenta.m_DBTables, sColumnsToView);
            if (selectID_Table_Assistant_Form.ShowDialog() == DialogResult.OK)
            {
                Currency.ID = selectID_Table_Assistant_Form.ID;
                int xCurrencyCode = -1;
                if (f_Currency.Get(Currency.ID,ref Currency.Abbreviation, ref Currency.Name,ref Currency.Symbol,ref xCurrencyCode,ref Currency.DecimalPlaces))
                {
                    txt_Currency.Text = Currency.Abbreviation;
                    if (f_Atom_Currency.Get(Currency.ID, ref Atom_Currency_ID))
                    {
                        if (CurrencyChanged!=null)
                        {
                            CurrencyChanged(Currency, Atom_Currency_ID);
                        }
                    }
                }
            }
        }
    }
}
