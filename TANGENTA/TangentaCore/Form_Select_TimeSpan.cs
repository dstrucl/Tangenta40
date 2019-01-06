#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using DBConnectionControl40;
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

namespace DocumentManager
{
    public partial class Form_Select_TimeSpan : Form
    {
        private usrc_TableOfDocuments m_usrc_InvoiceTable;
        private usrc_TableOfDocuments.eMode Org_Mode;
        private DateTime Org_dtStartTime;
        private DateTime Org_dtEndTime;


        public Form_Select_TimeSpan(usrc_TableOfDocuments xusrc_InvoiceTable)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.m_usrc_InvoiceTable = xusrc_InvoiceTable;


            this.Text = lng.s_SelectTimeSpan.s;
            this.rdb_All.Text = lng.s_all.s;
            this.rdb_CurrentDay.Text = lng.s_Today.s;
            this.rdb_TimeSpan.Text = lng.s_TimeSpan.s;
            this.rdb_LastYear.Text = lng.s_LastYear.s;
            this.rdb_ThisYear.Text= lng.s_ThisYear.s;  
            this.rdb_LastMonth.Text = lng.s_LastMonth.s;
            this.rdb_ThisMonth.Text = lng.s_ThisMonth.s;
            this.rdb_LastWeek.Text= lng.s_LastWeek.s; 
            this.rdb_ThisWeek.Text= lng.s_ThisWeek.s;
            this.rdb_ForDay.Text = lng.s_ForDay.s;
            lbl_From.Text = lng.ss_From.s;
            lbl_To.Text = lng.ss_To.s;
            btn_OK.Text = lng.ss_OK.s;
            Org_Mode = m_usrc_InvoiceTable.Mode;
            Org_dtStartTime = m_usrc_InvoiceTable.dtStartTime;
            Org_dtEndTime = m_usrc_InvoiceTable.dtEndTime;

            switch (m_usrc_InvoiceTable.Mode)
            {
                case usrc_TableOfDocuments.eMode.All:
                    rdb_All.Checked = true;
                    break;
                case usrc_TableOfDocuments.eMode.Today:
                    this.rdb_CurrentDay.Checked = true;
                    break;

                case usrc_TableOfDocuments.eMode.ThisWeek:
                    this.rdb_ThisWeek.Checked = true;
                    break;
                case usrc_TableOfDocuments.eMode.LastWeek:
                    this.rdb_LastWeek.Checked = true;
                    break;
                case usrc_TableOfDocuments.eMode.ThisMonth:
                    this.rdb_ThisMonth.Checked = true;
                    break;
                case usrc_TableOfDocuments.eMode.LastMonth:
                    this.rdb_LastMonth.Checked = true;
                    break;
                case usrc_TableOfDocuments.eMode.ThisYear:
                    this.rdb_ThisYear.Checked = true;
                    break;
                case usrc_TableOfDocuments.eMode.LastYear:
                    this.rdb_LastYear.Text = lng.s_LastYear.s;
                    break;
                case usrc_TableOfDocuments.eMode.TimeSpan:
                    this.rdb_TimeSpan.Checked = true;
                    break;
            }
            this.rdb_All.CheckedChanged += new System.EventHandler(this.rdb_All_CheckedChanged);
            this.rdb_CurrentDay.CheckedChanged += new System.EventHandler(this.rdb_CurrentDay_CheckedChanged);
            this.rdb_ThisWeek.CheckedChanged += new System.EventHandler(this.rdb_ThisWeek_CheckedChanged);
            this.rdb_LastMonth.CheckedChanged += new System.EventHandler(this.rdb_LastMonth_CheckedChanged);
            this.rdb_ThisYear.CheckedChanged += new System.EventHandler(this.rdb_ThisYear_CheckedChanged);
            this.rdb_TimeSpan.CheckedChanged += new System.EventHandler(this.rdb_TimeSpan_CheckedChanged);
            this.rdb_ThisMonth.CheckedChanged += new System.EventHandler(this.rdb_ThisMonth_CheckedChanged);
            this.rdb_LastYear.CheckedChanged += new System.EventHandler(this.rdb_LastYear_CheckedChanged);
            this.rdb_LastWeek.CheckedChanged += new System.EventHandler(this.rdb_LastWeek_CheckedChanged);

            this.dateTimePicker_From.Value = m_usrc_InvoiceTable.dtStartTime;
            this.dateTimePicker_To.Value = m_usrc_InvoiceTable.dtEndTime;

            this.dateTimePicker_ForDay.ValueChanged += new System.EventHandler(this.dateTimePicker_ForDay_ValueChanged);
            this.dateTimePicker_From.ValueChanged += new System.EventHandler(this.dateTimePicker_From_ValueChanged);
            this.dateTimePicker_To.ValueChanged += new System.EventHandler(this.dateTimePicker_To_ValueChanged);
            this.rdb_TimeSpan.CheckedChanged += new System.EventHandler(this.rdb_TimeSpan_CheckedChanged);
            this.rdb_ForDay.CheckedChanged += new System.EventHandler(this.rdb_ForDay_CheckedChanged);
        }


        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            m_usrc_InvoiceTable.SetTimeSpanParam(Org_Mode, Org_dtStartTime, Org_dtEndTime);
            this.Close();
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void rdb_TimeSpan_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_TimeSpan.Checked)
            {
                dateTimePicker_From.Enabled = true;
                dateTimePicker_To.Enabled = true;
                m_usrc_InvoiceTable.SetTimeSpanParam(usrc_TableOfDocuments.eMode.TimeSpan, dateTimePicker_From.Value, dateTimePicker_To.Value);
            }
            else
            {
                dateTimePicker_From.Enabled = false;
                dateTimePicker_To.Enabled = false;
            }
        }

        private void rdb_ThisYear_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_ThisYear.Checked)
            {
                DateTime dtNow = DateTime.Now;
                DateTime dtStartTime = new DateTime(dtNow.Year, 1, 1);
                DateTime dtEndTime = new DateTime(dtNow.Year+1, 1, 1);
                m_usrc_InvoiceTable.SetTimeSpanParam(usrc_TableOfDocuments.eMode.ThisYear, dtStartTime, dtEndTime);
            }

        }

        private void rdb_All_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_All.Checked)
            {
                m_usrc_InvoiceTable.lpar_ExtraCondition = null;
                m_usrc_InvoiceTable.ExtraCondition = null;
                m_usrc_InvoiceTable.SetMode(usrc_TableOfDocuments.eMode.All, lng.s_AllData.s);
            }
        }

        private void rdb_CurrentDay_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_CurrentDay.Checked)
            { 
                DateTime dtNow = DateTime.Now;
                DateTime dtStartTime = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day);
                DateTime dtEndTime = dtStartTime.AddDays(1);
                m_usrc_InvoiceTable.SetTimeSpanParam(usrc_TableOfDocuments.eMode.Today,dtStartTime, dtEndTime);
            }
        }

        private void rdb_LastWeek_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_LastWeek.Checked)
            { 
                DateTime dtNow = DateTime.Now;
                DayOfWeek dwk = dtNow.DayOfWeek;
            
                DateTime dtStartTime = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day);
                switch (dwk)
                {
                    case DayOfWeek.Sunday:
                        dtStartTime = dtStartTime.AddDays(-13);
                        break;
                    case DayOfWeek.Monday:
                        dtStartTime = dtStartTime.AddDays(-7);
                        break;
                    case DayOfWeek.Tuesday:
                        dtStartTime = dtStartTime.AddDays(-8);
                        break;
                    case DayOfWeek.Wednesday:
                        dtStartTime = dtStartTime.AddDays(-9);
                        break;
                    case DayOfWeek.Thursday:
                        dtStartTime = dtStartTime.AddDays(-10);
                        break;
                    case DayOfWeek.Friday:
                        dtStartTime = dtStartTime.AddDays(-11);
                        break;
                    case DayOfWeek.Saturday:
                        dtStartTime = dtStartTime.AddDays(-12);
                        break;

                }
                DateTime dtEndTime = dtStartTime.AddDays(7);
                m_usrc_InvoiceTable.SetTimeSpanParam(usrc_TableOfDocuments.eMode.LastWeek,dtStartTime, dtEndTime);
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (rdb_TimeSpan.Checked)
            {
                DateTime dtTo = dateTimePicker_To.Value;
                DateTime dtToNextDay = dtTo;//.AddDays(1);
                dtToNextDay = new DateTime(dtToNextDay.Year, dtToNextDay.Month, dtToNextDay.Day, 0, 0, 0);
                m_usrc_InvoiceTable.SetTimeSpanParam(usrc_TableOfDocuments.eMode.TimeSpan, dateTimePicker_From.Value, dtToNextDay);
            }
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void rdb_ThisWeek_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_ThisWeek.Checked)
            {
                DateTime dtNow = DateTime.Now;
                DayOfWeek dwk = dtNow.DayOfWeek;

                DateTime dtStartTime = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day);
                switch (dwk)
                {
                    case DayOfWeek.Sunday:
                        dtStartTime = dtStartTime.AddDays(-6);
                        break;
                    case DayOfWeek.Monday:
                        break;
                    case DayOfWeek.Tuesday:
                        dtStartTime = dtStartTime.AddDays(-1);
                        break;
                    case DayOfWeek.Wednesday:
                        dtStartTime = dtStartTime.AddDays(-2);
                        break;
                    case DayOfWeek.Thursday:
                        dtStartTime = dtStartTime.AddDays(-3);
                        break;
                    case DayOfWeek.Friday:
                        dtStartTime = dtStartTime.AddDays(-4);
                        break;
                    case DayOfWeek.Saturday:
                        dtStartTime = dtStartTime.AddDays(-5);
                        break;

                }
                DateTime dtEndTime = dtStartTime.AddDays(7);
                m_usrc_InvoiceTable.SetTimeSpanParam(usrc_TableOfDocuments.eMode.ThisWeek, dtStartTime, dtEndTime);
            }

        }

        private void rdb_ThisMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_ThisMonth.Checked)
            {
                DateTime dtNow = DateTime.Now;
                int m = dtNow.Month;
                int y = dtNow.Year;
                if (m==12)
                {
                    m = 1;
                    y = y + 1;

                }
                else
                {
                    m = m + 1;
                }

                DateTime dtStartTime = new DateTime(dtNow.Year, dtNow.Month, 1);
                DateTime dtEndTime = new DateTime(y, m, 1);
                m_usrc_InvoiceTable.SetTimeSpanParam(usrc_TableOfDocuments.eMode.ThisMonth, dtStartTime, dtEndTime);
            }
        }

        private void rdb_LastMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_LastMonth.Checked)
            {
                DateTime dtNow = DateTime.Now;
                int m = dtNow.Month;
                int y = dtNow.Year;
                if (m > 1)
                {
                    m = m - 1;
                }
                else
                {
                    m = 12;
                    y = y - 1;
                }

                DateTime dtStartTime = new DateTime(y, m, 1);
                DateTime dtEndTime = new DateTime(dtNow.Year, dtNow.Month, 1);
                m_usrc_InvoiceTable.SetTimeSpanParam(usrc_TableOfDocuments.eMode.LastMonth, dtStartTime, dtEndTime);
            }
        }

        private void rdb_LastYear_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_LastYear.Checked)
            {
                DateTime dtNow = DateTime.Now;
                DateTime dtStartTime = new DateTime(dtNow.Year-1, 1, 1);
                DateTime dtEndTime = new DateTime(dtNow.Year, 1, 1);
                m_usrc_InvoiceTable.SetTimeSpanParam(usrc_TableOfDocuments.eMode.LastYear, dtStartTime, dtEndTime);
            }

        }

        private void dateTimePicker_From_ValueChanged(object sender, EventArgs e)
        {
            this.rdb_TimeSpan.CheckedChanged -= new System.EventHandler(this.rdb_TimeSpan_CheckedChanged);
            rdb_TimeSpan.Checked = true;
//            m_usrc_InvoiceTable.SetTimeSpanParam(usrc_TableOfDocuments.eMode.TimeSpan, dateTimePicker_From.Value, dateTimePicker_To.Value);
            this.rdb_TimeSpan.CheckedChanged += new System.EventHandler(this.rdb_TimeSpan_CheckedChanged);
        }

        private void dateTimePicker_To_ValueChanged(object sender, EventArgs e)
        {
            this.rdb_TimeSpan.CheckedChanged -= new System.EventHandler(this.rdb_TimeSpan_CheckedChanged);
            rdb_TimeSpan.Checked = true;
//            m_usrc_InvoiceTable.SetTimeSpanParam(usrc_TableOfDocuments.eMode.TimeSpan, dateTimePicker_From.Value, dateTimePicker_To.Value);
            this.rdb_TimeSpan.CheckedChanged += new System.EventHandler(this.rdb_TimeSpan_CheckedChanged);
        }

        private void rdb_ForDay_CheckedChanged(object sender, EventArgs e)
        {

            DateTime xdtStart = dateTimePicker_ForDay.Value;
            DateTime xdtEnd = xdtStart;
            m_usrc_InvoiceTable.SetTimeSpanParam(usrc_TableOfDocuments.eMode.ForDay, xdtStart, xdtEnd);
        }

        private void dateTimePicker_ForDay_ValueChanged(object sender, EventArgs e)
        {

            this.rdb_ForDay.CheckedChanged -= new System.EventHandler(this.rdb_ForDay_CheckedChanged);
            rdb_ForDay.Checked = true;
            DateTime xdtStart = dateTimePicker_ForDay.Value;
            DateTime xdtEnd = xdtStart;
            m_usrc_InvoiceTable.SetTimeSpanParam(usrc_TableOfDocuments.eMode.ForDay, xdtStart, xdtEnd);
            this.rdb_ForDay.CheckedChanged += new System.EventHandler(this.rdb_ForDay_CheckedChanged);
        }

    }
}
