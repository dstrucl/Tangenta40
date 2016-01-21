﻿using BlagajnaTableClass;
using LanguageControl;
using SQLTableControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace uwpf_GUI
{
    /// <summary>
    /// Interaction logic for Price_Item_Undefined.xaml
    /// </summary>
    public partial class Price_Undefined_Window : Window
    {
        DataTable dt_price_Item_view = null;
        SQLTableControl.DBTableControl dbTables = null;
        SQLTableControl.SQLTable tbl = null;
        public Price_Undefined_Window(string sTitle,DataTable xdt_price_Item_view,SQLTableControl.DBTableControl xdbTables)
        {
            InitializeComponent();
            this.Title = sTitle;
            this.btn_Edit.Content = lngRPM.s_EditPriceList.s;
            this.btn_Cancel.Content = lngRPM.s_Cancel.s;
            dt_price_Item_view = xdt_price_Item_view;
            dbTables = xdbTables;
            this.dgvx_PriceUndefinedItem.ItemsSource = dt_price_Item_view.AsDataView();
            tbl = new SQLTable(dbTables.GetTable(typeof(Atom_cAddress_Org)));
            tbl.CreateTableTree(dbTables.items);
            this.dgvx_PriceUndefinedItem.AutoGeneratedColumns +=dgvx_PriceUndefinedItem_AutoGeneratedColumns;
            //this.dgvx_PriceUndefinedItem.Columns[0].Header = 
        }

        public SQLTableControl.SQLTable ew { get; set; }

        private void dgvx_PriceUndefinedItem_AutoGeneratedColumns(object sender, EventArgs e)
        {
            DataGridView_Headers.SetVIEW_DataGridViewImageColumns_Headers(this.dgvx_PriceUndefinedItem, dbTables, tbl);
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

    }
}