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
using System.Diagnostics;

namespace LogFile
{
    public partial class WriteLog2DB_Form : Form
    {
        public int LogFile_id = -1;
        LogFile_DataSet.LogFile_DataSet_Procedures m_LogFile_DataSet_Procedures = null;
        string Log_PathFile = null;
        string[] sLogLines = null;
        string m_UserName = null;
        int iLogfile_Lines = 0;
        int iLog_Line = 0;
        private Log_DBConnection m_LogDB_con = null;
        private string m_Description = null;
        List<Log_SQL_Parameter> ProcParams = new List<Log_SQL_Parameter>();


        public WriteLog2DB_Form(Log_DBConnection xm_LogDB_con, string xUserName, string xDescription)
        {
            InitializeComponent();
            m_LogDB_con = xm_LogDB_con;
            Log_PathFile = LogFile.LogFolder + LogFile.LogFileName;
            m_UserName = xUserName;
            m_Description = xDescription;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WriteLog2DB_Form_Load(object sender, EventArgs e)
        {

            try
            {
                if (!File.Exists(Log_PathFile))
                {
                    // write to Logfile to create it
                    LogFile.Write(LogFile.LOG_LEVEL_RUN_RELEASE, "L1", "START 2 LogFile  that not exists:\"" + Log_PathFile + "\"!");
                }
                string sAllLogs = File.ReadAllText(Log_PathFile);

                sLogLines = sAllLogs.Split(LogFile.LogSplitSeparator, StringSplitOptions.RemoveEmptyEntries);
                //sLogLines = File.ReadAllLines(Log_PathFile);
                iLogfile_Lines = sLogLines.Count();
                this.lbl_LogFile.Text = "LogFile=\"" + Log_PathFile + "\"";
                this.lbl_Progress.Text = "LogFile lines = " + iLogfile_Lines.ToString();
                m_LogFile_DataSet_Procedures = new LogFile_DataSet.LogFile_DataSet_Procedures(m_LogDB_con);
                string ComputerName = Environment.MachineName;
                string ProgramName = Process.GetCurrentProcess().ProcessName;
                string Res = null;
                string Err = null;
                m_LogFile_DataSet_Procedures.LogFile_Import(ComputerName, ProgramName, m_UserName, Log_PathFile, m_Description, ref LogFile_id, ref Res, ref Err);
                if (Res.Equals("OK"))
                {
                    timer_WriteLog.Enabled = true;
                }
                else
                {
                    Error.Show("ERROR:LogFile_Import:Res = " + Res);
                    this.Close();
                    DialogResult = DialogResult.Abort;
                }
            }
            catch (Exception ex)
            {
                Error.Show("ERROR:Can not read log lines : LogFile :\"" + Log_PathFile + "\" " + ex.Message );
                this.Close();
                DialogResult = DialogResult.Abort;
            }

        }

        private void timer_WriteLog_Tick(object sender, EventArgs e)
        {
            
            string Res = null;
            string Err = null;
            timer_WriteLog.Enabled = false;
            string sLine = null;
            DateTime LogTime = DateTime.Now;
            string LogType = null;
            string LogDescription = null;
            int Log_id = -1;
            int iCount = 0;
            string sql = @"DECLARE @Ret_code_CopyRight_Logina_AuthorDamjanStrucl int
                           DECLARE @Par_LogWrite_Log_id int
                           DECLARE @Par_LogWrite_Res nvarchar(265)
                            ";
            string sLogFile_id = LogFile_id.ToString();
            ProcParams.Clear();
            object result = new object();
            while (iLog_Line < iLogfile_Lines)
            {
                iCount++;
                sLine = sLogLines[iLog_Line];
                if (ParseLogLine(sLine, ref LogTime, ref LogType, ref LogDescription))
                {
                    Log_SQL_Parameter Par_LogWrite_LogTime = new Log_SQL_Parameter();
                    Par_LogWrite_LogTime.dbType = System.Data.SqlDbType.DateTime;
                    Par_LogWrite_LogTime.Name = "@Par_LogWrite_LogTime_" + iLog_Line.ToString();
                    Par_LogWrite_LogTime.size = 8;
                    Par_LogWrite_LogTime.Value = LogTime;
                    Par_LogWrite_LogTime.IsOutputParameter = false;
                    ProcParams.Add(Par_LogWrite_LogTime);

                    Log_SQL_Parameter Par_LogWrite_LogDescription = new Log_SQL_Parameter();
                    Par_LogWrite_LogDescription.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LogWrite_LogDescription.Name = "@Par_LogWrite_LogDescription_"+ iLog_Line.ToString();;
                    Par_LogWrite_LogDescription.size = 2000;
                    Par_LogWrite_LogDescription.Value = LogDescription;
                    Par_LogWrite_LogDescription.IsOutputParameter = false;
                    ProcParams.Add(Par_LogWrite_LogDescription);


                    //EXECUTE @Ret_code_CopyRight_Logina_AuthorDamjanStrucl =  dbo.LogWrite @LogFile_id = @Par_LogWrite_LogFile_id,@LogTime = @Par_LogWrite_LogTime,@LogType = @Par_LogWrite_LogType,@LogDescription = @Par_LogWrite_LogDescription,@Log_id = @Par_LogWrite_Log_id OUTPUT ,@Res = @Par_LogWrite_Res OUTPUT 
                    sql += "\r\n EXECUTE @Ret_code_CopyRight_Logina_AuthorDamjanStrucl =  dbo.LogWrite @LogFile_id = "+sLogFile_id+",@LogTime = "+Par_LogWrite_LogTime.Name+",@LogType = '"+LogType+"',@LogDescription = "+Par_LogWrite_LogDescription.Name+",@Log_id = @Par_LogWrite_Log_id OUTPUT ,@Res = @Par_LogWrite_Res OUTPUT ";

                    
                    //m_LogFile_DataSet_Procedures.LogWrite(LogFile_id, LogTime, LogType, LogDescription, ref Log_id, ref Res, ref Err);
                    //if (Res.Equals("OK"))
                    //{
                    //    iLog_Line++;
                    //}
                    //else
                    //{
                    //    Error.Show("ERROR:LogWrite:Res=" + Res);
                    //    return;
                    //}
                }
                //else
                //{
                //    Error.Show("ERROR:ParseLogLine!");
                //    return;
                //}
                iLog_Line++;
                if (iCount >= 1000)
                {
                    if (m_LogDB_con.ExecuteNonQuerySQL(sql, ProcParams, ref result, ref Err))
                    {
                        this.progressBar.Minimum = 0;
                        this.progressBar.Maximum = iLogfile_Lines;
                        this.progressBar.Value = iLog_Line;
                        this.lbl_Progress.Text = "Imported: " + iLog_Line.ToString() + "/" + iLogfile_Lines.ToString();
                        timer_WriteLog.Enabled = true;
                        return;
                    }
                    else
                    {
                        Error.Show("ERROR:WriteLog to DB: Err = " + Err);
                        return;
                    }
                }
            }
            if (m_LogDB_con.ExecuteNonQuerySQL(sql,ProcParams,ref result,ref Err))
            {
                this.progressBar.Minimum = 0;
                this.progressBar.Maximum = iLogfile_Lines;
                this.progressBar.Value = iLog_Line;
                this.lbl_Progress.Text = "Imported: " + iLog_Line.ToString() + "/" + iLogfile_Lines.ToString();
                timer_WriteLog.Enabled = true;
            }
            else
            {
                    Error.Show("ERROR:WriteLog to DB: Err = "+ Err);
            }

            try
            {
                File.Delete(Log_PathFile);
            }
            catch (Exception ex)
            {
                Error.Show("ERROR:WriteLog Can not delete:" + Log_PathFile + " Err = " + Err + " ;" + ex.Message );
            }
            finally
            {
                this.Close();
                DialogResult = DialogResult.OK;
            }
        }

        private bool ParseLogLine(string sLine, ref DateTime LogTime, ref string LogType, ref string LogDescription)
        {
            int iDel1 = sLine.IndexOf('|');
            if (iDel1 > 0)
            {
                string sTime = sLine.Substring(0, iDel1);
                string sType = sLine.Substring(iDel1+1,2);
                string sDescription = sLine.Substring(iDel1 + 4);
                if (GetDateTime(sTime, ref LogTime))
                {
                    LogType = sType;
                    LogDescription = sDescription;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool GetDateTime(string sTime, ref DateTime dateandtime)
        {
            int Day;
            int Month;
            int Year;
            int Hour;
            int Minutes;
            int Seconds;
            int MiliSeconds;

            if (sTime[0] == ':')
            {
                string[] sTimeElement = sTime.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    Day = Convert.ToInt32(sTimeElement[0]);
                    Month = Convert.ToInt32(sTimeElement[1]);
                    Year = Convert.ToInt32(sTimeElement[2]);
                    Hour = Convert.ToInt32(sTimeElement[3]);
                    Minutes = Convert.ToInt32(sTimeElement[4]);
                    Seconds = Convert.ToInt32(sTimeElement[5]);
                    MiliSeconds = Convert.ToInt32(sTimeElement[6]);
                    dateandtime = new DateTime(Year, Month, Day, Hour, Minutes, Seconds, MiliSeconds);
                    return true;
                }
                catch (Exception ex)
                {
                    Error.Show("Error:WriteLog2DB_Form:GetDateTime(string sTime, ref DateTime dateandtime):Execption=" + ex.Message + "\r\nStackTrace=" + ex.StackTrace);
                    return false;
                }
            }
            else
            {
                int iDay = sTime.IndexOf('.');
                if (iDay > 0)
                {
                    string sDay = sTime.Substring(0, iDay);
                    Day = Convert.ToInt32(sDay);
                    sTime = sTime.Substring(iDay + 1);
                    int iMonth = sTime.IndexOf('.');
                    if (iMonth > 0)
                    {
                        string sMonth = sTime.Substring(0, iMonth);
                        Month = Convert.ToInt32(sMonth);
                        sTime = sTime.Substring(iMonth + 1);
                        int iYear = sTime.IndexOf(',');
                        if (iYear > 0)
                        {
                            string sYear = sTime.Substring(0, iYear);
                            Year = Convert.ToInt32(sYear);
                            sTime = sTime.Substring(iYear + 1);

                            int iHour = sTime.IndexOf(':');
                            if (iHour > 0)
                            {
                                string sHour = sTime.Substring(0, iHour);
                                Hour = Convert.ToInt32(sHour);
                                sTime = sTime.Substring(iHour + 1);

                                int iMinutes = sTime.IndexOf(':');
                                if (iMinutes > 0)
                                {
                                    string sMinutes = sTime.Substring(0, iMinutes);
                                    Minutes = Convert.ToInt32(sMinutes);
                                    sTime = sTime.Substring(iMinutes + 1);

                                    int iSeconds = sTime.IndexOf(' ');
                                    if (iSeconds > 0)
                                    {
                                        string sSeconds = sTime.Substring(0, iSeconds);
                                        Seconds = Convert.ToInt32(sSeconds);
                                        sTime = sTime.Substring(iSeconds + 3);
                                        int iMiliSeconds = sTime.IndexOf('m');
                                        if (iMiliSeconds > 0)
                                        {
                                            string sMiliSeconds = sTime.Substring(0, iMiliSeconds);
                                            MiliSeconds = Convert.ToInt32(sMiliSeconds);
                                            dateandtime = new DateTime(Year, Month, Day, Hour, Minutes, Seconds, MiliSeconds);
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}
