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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LogFile
{
    public partial class LogFileAnalyzer_Form : Form
    {
        bool bInit = false;
        LogFile_DataSet.Log_Computer m_Log_Computer = null;
        LogFile_DataSet.Log_Program m_Log_Program = null;
        LogFile_DataSet.Log_UserName m_Log_UserName = null;
        LogFile_DataSet.Log_VIEW m_Log_View = null;
        LogFile_DataSet.LogFile_VIEW m_LogFile_VIEW = null;
        LogFile_DataSet.LogFile_Attachment_VIEW m_LogFile_Attachment_VIEW = null;
        DataTable dt_LogFile = new DataTable();


        


        public LogFileAnalyzer_Form()
        {
            InitializeComponent();
        }

        private void LogFileAnalyzer_Form_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            bInit = true;
            string Err = null;
            
            int iLimit = Convert.ToInt32(nmUpDn_Limit.Value);
            if (LogFile.m_LogDB_con != null)
            {
                m_Log_Computer = new LogFile_DataSet.Log_Computer(LogFile.m_LogDB_con);
                m_Log_Program = new LogFile_DataSet.Log_Program(LogFile.m_LogDB_con);
                m_Log_UserName = new LogFile_DataSet.Log_UserName(LogFile.m_LogDB_con);
                m_Log_View = new LogFile_DataSet.Log_VIEW(LogFile.m_LogDB_con);
                m_LogFile_VIEW = new LogFile_DataSet.LogFile_VIEW(LogFile.m_LogDB_con);
                m_LogFile_Attachment_VIEW = new LogFile_DataSet.LogFile_Attachment_VIEW(LogFile.m_LogDB_con);

                m_Log_Computer.Clear();
                m_Log_Computer.select.all(true);
                if (m_Log_Computer.Read(iLimit, ref Err))
                {
                    dgv_Computer.DataSource = m_Log_Computer.m_bs_dt;

                    m_Log_Program.Clear();
                    m_Log_Program.select.all(true);
                    if (m_Log_Program.Read(iLimit, ref Err))
                    {
                        dgv_Program.DataSource = m_Log_Program.m_bs_dt;
                        m_Log_UserName.Clear();
                        m_Log_UserName.select.all(true);
                        if (m_Log_UserName.Read(iLimit, ref Err))
                        {
                            dgv_UserName.DataSource = m_Log_UserName.m_bs_dt;
                            if (Init_LogFile_VIEW(iLimit,
                                            m_Log_Computer.m_bs_dt.Current,
                                            m_Log_Program.m_bs_dt.Current,
                                            m_Log_UserName.m_bs_dt.Current,
                                            ref Err))
                            {
                            }
                            else
                            {
                                Error.Show("ERROR:LogFile:LogFileAnalyzer_Form:Init:Init_LogFile_VIEW:Err=" + Err);
                            }

                        }
                        else
                        {
                            Error.Show("ERROR:LogFile:LogFileAnalyzer_Form:Init:(m_Log_UserName.Read:Err=" + Err);
                        }
                    }
                    else
                    {
                        Error.Show("ERROR:LogFile:LogFileAnalyzer_Form:Init:(m_Log_Program.Read:Err=" + Err);
                    }

                }
                else
                {
                    Error.Show("ERROR:LogFile:LogFileAnalyzer_Form:Init:(m_Log_Computer.Read:Err=" + Err);
                }
                bInit = false;
            }
        }

        private bool Init_LogFile_VIEW(int iLimit, 
                                        object oCurrent_Log_Computer_Row,
                                        object oCurrent_Log_Program_Row,
                                        object oCurrent_Log_UserName_Row,
                                        ref string Err)
        {
            if (oCurrent_Log_Computer_Row.GetType() == typeof(DataRowView))
            {

                int Log_Computer_id = (int)((DataRowView)oCurrent_Log_Computer_Row)["id"];
                if (oCurrent_Log_Program_Row.GetType() == typeof(DataRowView))
                {

                    int Log_Program_id = (int)((DataRowView)oCurrent_Log_Program_Row)["id"];
                    if (oCurrent_Log_UserName_Row.GetType() == typeof(DataRowView))
                    {
                        int Log_UserName_id = (int)((DataRowView)oCurrent_Log_UserName_Row)["id"];
                        m_LogFile_VIEW.Clear();
                        m_LogFile_VIEW.select.all(true);
                        m_LogFile_VIEW.where.all(false);
                        m_LogFile_VIEW.where.Log_Computer_id = true;
                        m_LogFile_VIEW.where.Log_Program_id = true;
                        m_LogFile_VIEW.where.Log_UserName_id = true;
                        m_LogFile_VIEW.where.Log_Computer_id_Expression(" = " + Log_Computer_id.ToString());
                        m_LogFile_VIEW.where.Log_Program_id_Expression(" = " + Log_Program_id.ToString());
                        m_LogFile_VIEW.where.Log_UserName_id_Expression(" = " + Log_UserName_id.ToString());
                        if (m_LogFile_VIEW.Read(iLimit, ref Err))
                        {
                            dgv_LogFile.DataSource = m_LogFile_VIEW.m_bs_dt;
                            dgv_LogFile.SelectAll();
                            Init_LogFile_Attachment_VIEW(iLimit, dgv_LogFile.SelectedRows);
                            Init_Log_VIEW(iLimit,dgv_LogFile.SelectedRows);

                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            Err = "ERROR:LogFile:Init_LogFile_VIEW:object not of DataRow Type!";
            return false;
        }

        private void Init_LogFile_Attachment_VIEW(int iLimit, DataGridViewSelectedRowCollection dataGridViewSelectedRowCollection)
        {
            string Err = null;
            m_LogFile_Attachment_VIEW.Clear();
            if (dataGridViewSelectedRowCollection.Count > 0)
            {
                string sIn = null;
                foreach (DataGridViewRow dgvr in dataGridViewSelectedRowCollection)
                {
                    DataRow myRow = (dgvr.DataBoundItem as DataRowView).Row;
                    int LogFile_id = (int)myRow["id"];
                    if (sIn == null)
                    {
                        sIn = " in (" + LogFile_id.ToString();
                    }
                    else
                    {
                        sIn += "," + LogFile_id.ToString();
                    }
                }
                if (sIn != null)
                {
                    sIn += ")";

                    m_LogFile_Attachment_VIEW.Clear();
                    m_LogFile_Attachment_VIEW.select.all(true);
                    m_LogFile_Attachment_VIEW.where.all(false);
                    m_LogFile_Attachment_VIEW.where.LogFile_id = true;
                    m_LogFile_Attachment_VIEW.where.LogFile_id_Expression(sIn);
                    if (m_LogFile_Attachment_VIEW.Read(iLimit, ref Err))
                    {
                        dgv_LogFile_Attachment.DataSource = m_LogFile_Attachment_VIEW.m_bs_dt;
                    }
                    else
                    {
                        dgv_LogFile_Attachment.DataSource = null;
                        Error.Show("ERROR:LogFile:Init_LogFile_Attachment_VIEW:Err=" + Err);
                    }
                }
                else
                {
                    dgv_LogFile_Attachment.DataSource = null;
                }

            }
            else
            {
                dgv_LogFile_Attachment.DataSource = null;
            }
        }

        private void Init_Log_VIEW(int iLimit,DataGridViewSelectedRowCollection dataGridViewSelectedRowCollection)
        {
            string Err = null;
            if (dataGridViewSelectedRowCollection.Count > 0)
            {
                string sIn = null;
                foreach (DataGridViewRow dgvr in dataGridViewSelectedRowCollection)
                {
                    DataRow myRow = (dgvr.DataBoundItem as DataRowView).Row;
                    int LogFile_id = (int)myRow["id"];
                    if (sIn==null)
                    {
                        sIn = " in (" + LogFile_id.ToString();
                    }
                    else
                    {
                        sIn += "," + LogFile_id.ToString();
                    }
                }
                if (sIn!=null)
                {
                    sIn += ")";
                    string sql = "select top " + iLimit .ToString()+ " * from Log_VIEW where LogFile_id " + sIn;
                    dt_LogFile.Clear();
                    if (LogFile.m_LogDB_con.ReadDataTable(ref dt_LogFile,sql,null,ref Err))
                    {
                        dgv_Log.DataSource = dt_LogFile;
                    }
                    else
                    {
                        Error.Show("ERROR:LogFile:Init_Log_VIEW:Err="+Err);
                    }
                }
                
            }
        }

        private void dgv_LogFile_SelectionChanged(object sender, EventArgs e)
        {
            if (!bInit)
            {
                int iLimit = Convert.ToInt32(nmUpDn_Limit.Value);
                Init_LogFile_Attachment_VIEW(iLimit, dgv_LogFile.SelectedRows);
                Init_Log_VIEW(iLimit, dgv_LogFile.SelectedRows);
            }
        }

        private void dgv_LogFile_Attachment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgv_LogFile_Attachment.Columns[LogFile_DataSet.LogFile_Attachment_VIEW.Attachment.name].Index)
            {
                int iRow = e.RowIndex;
                ContextMenu m = new ContextMenu();
                MenuItem menu_item_copy_picture = new MenuItem("Copy");
                menu_item_copy_picture.Tag = iRow;
                menu_item_copy_picture.Click += new EventHandler(menu_item_copy_picture_Click);

                m.MenuItems.Add(menu_item_copy_picture);

                //int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                //if (currentMouseOverRow >= 0)
                //{
                //    m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
                //}
                m.Show(dgv_LogFile_Attachment, new Point(e.ColumnIndex, e.RowIndex));

            }


        }

        void menu_item_copy_picture_Click(object sender, EventArgs e)
        {
            MenuItem menu_item_copy_picture  = (MenuItem) sender;
            int Row = (int)menu_item_copy_picture.Tag;
            byte[] data = (byte[]) m_LogFile_Attachment_VIEW.dt.Rows[Row][LogFile_DataSet.LogFile_Attachment_VIEW.Attachment.name];
            Image image = Image.FromStream(new MemoryStream(data));
            Clipboard.SetImage(image);
        }

        private void Init_LogFile_VIEW()
        {
            if (!bInit)
            {
                bInit = true;
                string Err = null;
                int iLimit = Convert.ToInt32(nmUpDn_Limit.Value);
                if (Init_LogFile_VIEW(iLimit,
                                                        m_Log_Computer.m_bs_dt.Current,
                                                        m_Log_Program.m_bs_dt.Current,
                                                        m_Log_UserName.m_bs_dt.Current,
                                                        ref Err))
                {
                }
                else
                {
                    Error.Show("ERROR:LogFile:LogFileAnalyzer_Form:Init:Init_LogFile_VIEW:Err=" + Err);
                }
                bInit = false;
            }
        }

        private void dgv_Computer_SelectionChanged(object sender, EventArgs e)
        {
           Init_LogFile_VIEW();
        }

        private void dgv_Program_SelectionChanged(object sender, EventArgs e)
        {
           Init_LogFile_VIEW();
        }

        private void dgv_UserName_SelectionChanged(object sender, EventArgs e)
        {
           Init_LogFile_VIEW();
        }
    }
}
