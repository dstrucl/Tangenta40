using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Excell_Export_base;

namespace Excell_Export
{
    public class Excell:Excell_base
    {
        public Excell()
        {
          Excell_Export_base.static_lng_text.lng_s_ErrorStartExecuteExcel_s = lng.s_ErrorStartExecuteExcel.s;
          Excell_Export_base.static_lng_text.lng_s_ErrorInExportToExcel_s = lng.s_ErrorInExportToExcel.s;
          Excell_Export_base.static_lng_text.lng_s_ThereAreNoSelectedRowsToExport_s = lng.s_ThereAreNoSelectedRowsToExport.s;
          Excell_Export_base.static_lng_text.lng_s_Columns_s = lng.s_Columns.s;
          Excell_Export_base.static_lng_text.lng_s_Rows_s = lng.s_Rows.s;
          Excell_Export_base.static_lng_text.lng_s_ExportToFile_s = lng.s_ExportToFile.s;
          Excell_Export_base.static_lng_text.lng_s_ExportDoneInXprocent_s = lng.s_ExportDoneInXprocent.s;
          Excell_Export_base.static_lng_text.lng_s_Error_s = lng.s_Error.s;
        }
    }
}
