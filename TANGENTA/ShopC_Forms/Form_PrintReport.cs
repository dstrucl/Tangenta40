#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using DBTypes;
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
using TangentaPrint;

namespace ShopC_Forms
{
    public partial class Form_PrintReport : Form
    {
        private usrc_TableOfConsumption m_usrc_ConsumptionTable = null;

        public Form_PrintReport(usrc_TableOfConsumption xusrc_ConsumptionTable)
        {
            InitializeComponent();
            m_usrc_ConsumptionTable = xusrc_ConsumptionTable;
            this.lbl_From_To.Text = xusrc_ConsumptionTable.lbl_From_To.Text;
            lng.s_Details.Text(chk_Details);
            lng.s_SaveAsTextFile.Text(btn_SaveAsText);

            this.Text = "";
            this.btn_XML_export.Text = lng.s_XML_export.s;
            this.btn_VOD_xml_OPAL_export.Text = lng.s_VODxml_OPAL_export.s;
        }

        private void Form_PrintReport_Load(object sender, EventArgs e)
        {
           //Program.usrc_TangentaPrint1.Init(null);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            string sfromtomode = null;
            bool bDoPrint = true;
            DateTime_v dtStart_v = new DateTime_v(m_usrc_ConsumptionTable.dtStartTime);
            DateTime_v dtEnd_v = new DateTime_v(m_usrc_ConsumptionTable.dtEndTime);
            switch (m_usrc_ConsumptionTable.Mode)
            {
                case usrc_TableOfConsumption.eMode.ForDay:
                    sfromtomode = lng.s_ForDay.s;
                    dtEnd_v = null;
                    break;
                case usrc_TableOfConsumption.eMode.LastMonth:
                    sfromtomode = lng.s_LastMonth.s;
                    break;
                case usrc_TableOfConsumption.eMode.LastWeek:
                    sfromtomode = lng.s_LastWeek.s;
                    break;
                case usrc_TableOfConsumption.eMode.ThisMonth:
                    sfromtomode = lng.s_ThisMonth.s;
                    break;
                case usrc_TableOfConsumption.eMode.ThisWeek:
                    sfromtomode = lng.s_ThisMonth.s;
                    break;
                case usrc_TableOfConsumption.eMode.ThisYear:
                    sfromtomode = lng.s_ThisYear.s;
                    break;
                case usrc_TableOfConsumption.eMode.TimeSpan:
                    sfromtomode = lng.s_TimeSpan.s;
                    break;
                case usrc_TableOfConsumption.eMode.Today:
                    sfromtomode = lng.s_Today.s;
                    dtEnd_v = null;
                    break;
                default:
                    bDoPrint = false;
                    break;
            }
            if (bDoPrint)
            {
                PrintReport printreport = new PrintReport(m_usrc_ConsumptionTable.dt_XInvoice, 
                                                          sfromtomode, dtStart_v, dtEnd_v,
                                                          chk_Details.Checked);
                printreport.Print();
            }

            //Program.usrc_TangentaPrint1.PrintReport(m_usrc_InvoiceTable);
            // XMessage.Box.Show(this, false, lng.s_Printing_InvoiceListIsNotImplementedYet_YouCanExportDataTableToExcelAndPrintExcelFile,MessageBoxIcon.Information);
            // this.Close();
            // DialogResult = DialogResult.OK;
        }

       

       
        private void btn_XML_export_Click(object sender, EventArgs e)
        {
            Form_XML_output XML_output_dlg = new Form_XML_output(m_usrc_ConsumptionTable);
            XML_output_dlg.ShowDialog();
        }

        private void btn_VOD_xml_OPAL_export_Click(object sender, EventArgs e)
        {
            Form_VODxml_OPAL_output XML_output_dlg = new Form_VODxml_OPAL_output(m_usrc_ConsumptionTable);
            XML_output_dlg.ShowDialog();

        }

        private void btn_SaveAsText_Click(object sender, EventArgs e)
        {
            string sfromtomode = null;
            bool bDoPrint = true;
            DateTime_v dtStart_v = new DateTime_v(m_usrc_ConsumptionTable.dtStartTime);
            DateTime_v dtEnd_v = new DateTime_v(m_usrc_ConsumptionTable.dtEndTime);
            switch (m_usrc_ConsumptionTable.Mode)
            {
                case usrc_TableOfConsumption.eMode.ForDay:
                    sfromtomode = lng.s_ForDay.s;
                    dtEnd_v = null;
                    break;
                case usrc_TableOfConsumption.eMode.LastMonth:
                    sfromtomode = lng.s_LastMonth.s;
                    break;
                case usrc_TableOfConsumption.eMode.LastWeek:
                    sfromtomode = lng.s_LastWeek.s;
                    break;
                case usrc_TableOfConsumption.eMode.ThisMonth:
                    sfromtomode = lng.s_ThisMonth.s;
                    break;
                case usrc_TableOfConsumption.eMode.ThisWeek:
                    sfromtomode = lng.s_ThisMonth.s;
                    break;
                case usrc_TableOfConsumption.eMode.ThisYear:
                    sfromtomode = lng.s_ThisYear.s;
                    break;
                case usrc_TableOfConsumption.eMode.TimeSpan:
                    sfromtomode = lng.s_TimeSpan.s;
                    break;
                case usrc_TableOfConsumption.eMode.Today:
                    sfromtomode = lng.s_Today.s;
                    dtEnd_v = null;
                    break;
                default:
                    bDoPrint = false;
                    break;
            }
            if (bDoPrint)
            {
                PrintReport printreport = new PrintReport(m_usrc_ConsumptionTable.dt_XInvoice,
                                                          sfromtomode, dtStart_v, dtEnd_v,
                                                          chk_Details.Checked);
                printreport.Save(this);
            }
        }
        
    }
}
