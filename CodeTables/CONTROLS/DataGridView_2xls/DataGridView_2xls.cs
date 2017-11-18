#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excell_Export_base;
using LanguageControl;
using DataGridView_2xls_base;

namespace DataGridView_2xls
{
    public partial class DataGridView2xls : DataGridView2xls_base
    {
        public DataGridView2xls()
        {
            DataGridView_2xls_base.static_lng_text.lng_s_ShowRowNumbers_s = lng.s_ShowRowNumbers.s;
            DataGridView_2xls_base.static_lng_text.lng_s_SaveSelectedRowsToExcelFile_s = lng.s_SaveSelectedRowsToExcelFile.s;
            Excell_Export.Excell exel = new Excell_Export.Excell(); // make local instance to init static lng variables in Excell_Export_base !
        }
    }
}
