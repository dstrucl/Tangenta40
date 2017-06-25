using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProgramDiagnostic
{
    public partial class Results_Form : Form
    {
        private DataTable m_dt = null;
        public Results_Form(DataTable dt)
        {
            InitializeComponent();
            m_dt = dt;
            int i = 0;
            int iCount = dt.Rows.Count;
            
            for (i=0;i<iCount;i++)
            {
                if (dt.Rows[i][2].GetType()==typeof(System.DBNull))
                {
                    string sToken = (string)dt.Rows[i][0];
                    int IndexOfSpace = sToken.IndexOf(' ');
                    if (IndexOfSpace > 0)
                    {
                        string sParam = sToken.Substring(0, IndexOfSpace);
                        int Len = sToken.Length;
                        string sType = sToken.Substring(IndexOfSpace+1,Len-IndexOfSpace-1);
                        sType = sType.Replace(" ", "");
                        if (sType.ToUpper().Equals("START"))
                        {
                            DateTime timeStart = (DateTime)dt.Rows[i][1];
                            int idx_of_end = FindEnd(sParam,dt, i);
                            if (idx_of_end>0)
                            {
                                DateTime timeEnd = (DateTime)dt.Rows[idx_of_end][1];
                                decimal TickElapsed = (decimal)((timeEnd.Ticks - timeStart.Ticks))/10000M;
                                dt.Rows[i][2] = TickElapsed;
                                dt.Rows[idx_of_end][2] = TickElapsed;
                            }
                        }
                    }
                }
            }
            dgvx_Results.DataSource = dt;
            dgvx_Results.Columns["Time"].DefaultCellStyle.Format = "HH:mm:ss:ms";

        }

        private int FindEnd(string xsParam, DataTable dt, int iStart)
        {
            int i = 0;
            int iCount = dt.Rows.Count;
            for (i=iStart + 1;i<iCount;i++)
            {
                if (dt.Rows[i][2].GetType() == typeof(System.DBNull))
                {
                    string sToken = (string)dt.Rows[i][0];
                    int IndexOfSpace = sToken.IndexOf(' ');
                    if (IndexOfSpace > 0)
                    {
                        string sParam = sToken.Substring(0, IndexOfSpace);
                        int Len = sToken.Length;
                        string sType = sToken.Substring(IndexOfSpace + 1, Len - IndexOfSpace - 1);
                        if (sParam.Equals(xsParam))
                        {
                            sType = sType.Replace(" ","");
                            if (sType.ToUpper().Equals("END"))
                            {
                                return i;
                            }
                            else
                            {
                                if (sType.ToUpper().Equals("START"))
                                {
                                    DateTime timeStart = (DateTime)dt.Rows[i][1];
                                    int idx_of_end = FindEnd(sParam, dt, i);
                                    if (idx_of_end >= 0)
                                    {
                                        DateTime timeEnd = (DateTime)dt.Rows[idx_of_end][1];
                                        decimal TickElapsed = (decimal)((timeEnd.Ticks - timeStart.Ticks)) / 10000M;
                                        dt.Rows[i][2] = TickElapsed;
                                        dt.Rows[idx_of_end][2] = TickElapsed;
                                        i = idx_of_end;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (sType.ToUpper().Equals("START"))
                            {
                                DateTime timeStart = (DateTime)dt.Rows[i][1];
                                int idx_of_end = FindEnd(sParam, dt, i);
                                if (idx_of_end >= 0)
                                {
                                    DateTime timeEnd = (DateTime)dt.Rows[idx_of_end][1];
                                    decimal TickElapsed = (decimal)((timeEnd.Ticks - timeStart.Ticks)) / 10000M;
                                    dt.Rows[i][2] = TickElapsed;
                                    dt.Rows[idx_of_end][2] = TickElapsed;
                                    i = idx_of_end;
                                }
                            }
                        }
                    }
                }
            }
            return -1;
        }


        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            m_dt.Rows.Clear();
            dgvx_Results.Refresh();
        }
    }
}
