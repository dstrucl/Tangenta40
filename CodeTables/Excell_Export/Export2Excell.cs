using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using YExcel;
using LanguageControl;

namespace Excell_Export
{
    public class Excell
    {

        public bool Export(ref String FileName, DataGridView dgv)
        {
            int iNoOfColumns = dgv.ColumnCount;
            int iRowCount = dgv.SelectedRows.Count;

            long lCellCount = Convert.ToInt64(iNoOfColumns) * Convert.ToInt64(iRowCount);
            if (iRowCount > 0) 
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = FileName;
                sfd.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
                sfd.InitialDirectory = Path.GetPathRoot(FileName);
                sfd.FilterIndex = 2;
                sfd.DefaultExt = "xls";
                sfd.RestoreDirectory = true;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    FileName = sfd.FileName;

                    Progress_Thread m_Progress_Thread = new Progress_Thread(iNoOfColumns,iRowCount,FileName);
                    m_Progress_Thread.Start();
                    try
                    {
                        int[] RowIndexArray = new int[iRowCount];
                        int i = 0;
                        foreach (DataGridViewRow Row in dgv.SelectedRows)
                        {
                            RowIndexArray[i] = Row.Index;
                            i++;
                        }
                        Array.Sort(RowIndexArray);
                        

                        Excel m_Excel;
                        YExcel.ExcelWorksheet m_ExcelWorksheet = null;
                        YExcel.XLSFormatManager fmt_mgr = null;
                        YExcel.CellFormat m_CellFormat_Header = null;
                        YExcel.CellFormat m_CellFormat = null;
                        YExcel.CellFormat m_CellFormatLongAsText = null;
                        YExcel.ExcelCell m_ExcelCell = null;

                        m_Excel = new Excel();
                        m_Excel.NewSheet(1);
                        m_ExcelWorksheet = m_Excel.GetWorksheet(0);
                        fmt_mgr = new XLSFormatManager(m_Excel);
                        m_CellFormat = new CellFormat(fmt_mgr);
                        m_CellFormat_Header = new CellFormat(fmt_mgr);
                        m_CellFormat_Header.set_wrapping(true);
                        m_CellFormat_Header.set_format_string_TEXT();
                        m_CellFormat_Header.set_background(0x04000000, 5);

                        m_CellFormatLongAsText = new CellFormat(fmt_mgr);
                        m_CellFormatLongAsText.set_background(0x06000000, 5);

                        for (i = 0; i < iNoOfColumns; i++)
                        {
                            int iw = dgv.Columns[i].HeaderCell.Size.Width * 10;
                            if (iw > 40000)
                            {
                                iw = 40000;
                            }
                            ushort width = Convert.ToUInt16(iw);
                            m_ExcelWorksheet.SetColWidth(i, width); //ID
                        }

                        int iRow;
                        int iOfsetCol = 1;
                        int iOfsetRow = 1;
                        int iCol;
                        iCol = 0;

                        //m_ExcelWorksheet.SetColWidth(1, 1400); //ID
                        //m_ExcelWorksheet.SetColWidth(2, 5400); //Računalnik
                        //m_ExcelWorksheet.SetColWidth(3, 6400); //Uporabnik
                        //m_ExcelWorksheet.SetColWidth(4, 6200); //Čas prijave
                        //m_ExcelWorksheet.SetColWidth(5, 3600); //Čas čakanja na obravnavo
                        //m_ExcelWorksheet.SetColWidth(6, 4000); //Ime
                        //m_ExcelWorksheet.SetColWidth(7, 4000); //Priimek
                        //m_ExcelWorksheet.SetColWidth(8, 4200); //Številka kartice
                        //m_ExcelWorksheet.SetColWidth(9, 2000); //Verzija kartice
                        //m_ExcelWorksheet.SetColWidth(10, 6200); //Začetek ob
                        //m_ExcelWorksheet.SetColWidth(11, 6200); //Konec ob
                        //m_ExcelWorksheet.SetColWidth(12, 3200); //Začeto
                        //m_ExcelWorksheet.SetColWidth(13, 3200); //Konec
                        //m_ExcelWorksheet.SetColWidth(14, 3200); //Konec

                        //m_ExcelWorksheet.SetRowHeight(iOfsetRow, 4000);

                        int iColumn;
                        int iCount;
                        long lProgress = 0;
                        int iCountToSendMessage = 1;
                        iCount = dgv.Columns.Count;
                        for (iColumn = 0; iColumn < iCount; iColumn++)
                        {
                            DataGridViewColumn Column = GetColumnByDisplayIndex(dgv.Columns,iColumn);
                            


                            m_ExcelCell = m_ExcelWorksheet.Cell(iOfsetRow, iOfsetCol + iCol);
                            m_ExcelCell.Set(Column.HeaderText);
                            m_ExcelCell.SetFormat(m_CellFormat_Header);


                            //for (iRow = iRowCount-1; iRow >=0; iRow--)

                            //foreach (DataGridViewRow Row in dgv.SelectedRows)
                            //for (iRow = 0;iRow<iRowCount;iRow++)
                            //for (iRow = iRowCount-1; iRow >=0; iRow--)
                            //for (iRow = 0; iRow < iRowCount; iRow++)
                            //for (iRow = iRowCount - 1; iRow >= 0; iRow--)
                            for (iRow = 0; iRow < iRowCount; iRow++)
                            {
                                long lProgressPerc = (lProgress * 100) / lCellCount;
                                lProgress++;
                                if (iCountToSendMessage == 100)
                                {
                                    iCountToSendMessage = 1;
                                    if (m_Progress_Thread.Message(Convert.ToInt32(lProgressPerc)) == Progress_Thread.eMessage.CANCEL)
                                    {
                                        m_Progress_Thread.End();
                                        return false;
                                    }
                                }
                                else
                                {
                                    iCountToSendMessage++;
                                }




                                DataGridViewRow Row = dgv.SelectedRows[iRow];
                                object oValue = Row.Cells[iCol].Value;
                                if (oValue == null)
                                {
                                    if (Row.Cells[iCol].FormattedValue != null)
                                    {
                                        oValue = Convert.ToString(Row.Cells[iCol].FormattedValue);
                                    }
                                }
                                int Row_Index = Array.IndexOf(RowIndexArray, Row.Index);
                                if (oValue != null)
                                {
                                    if (oValue.GetType() == typeof(string))
                                    {
                                        m_CellFormat.set_format_string_TEXT();
                                        //m_ExcelCell = m_ExcelWorksheet.Cell(iOfsetRow + 1 + iRow, iOfsetCol + iCol);
                                        m_ExcelCell = m_ExcelWorksheet.Cell(iOfsetRow + 1 + Row_Index, iOfsetCol + iCol);
                                        string svalue = (String)oValue;
                                        if (svalue.Length > 1000)
                                        {
                                            svalue = svalue.Substring(0, 1000);
                                        }
                                        m_ExcelCell.Set(svalue);
                                        m_ExcelCell.SetFormat(m_CellFormat);
                                    }
                                    else if ((oValue.GetType() == typeof(long)) || (oValue.GetType() == typeof(ulong)) || (oValue.GetType() == typeof(int)) || (oValue.GetType() == typeof(uint)))
                                    {
                                        int iVal;
                                        try
                                        {
                                            iVal = Convert.ToInt32(oValue);
                                            m_CellFormat.set_format_string_INTEGER();
                                            //m_ExcelCell = m_ExcelWorksheet.Cell(iOfsetRow + 1 + iRow, iOfsetCol + iCol);
                                            m_ExcelCell = m_ExcelWorksheet.Cell(iOfsetRow + 1 + Row_Index, iOfsetCol + iCol);
                                            m_ExcelCell.Set(iVal);
                                            m_ExcelCell.SetFormat(m_CellFormat);
                                        }
                                        catch
                                        {
                                            m_CellFormat.set_format_string_TEXT();
                                            //m_ExcelCell = m_ExcelWorksheet.Cell(iOfsetRow + 1 + iRow, iOfsetCol + iCol);
                                            m_ExcelCell = m_ExcelWorksheet.Cell(iOfsetRow + 1 + Row_Index, iOfsetCol + iCol);
                                            m_ExcelCell.Set((String)Convert.ToString(oValue));
                                            m_ExcelCell.SetFormat(m_CellFormatLongAsText);
                                        }
                                    }
                                    else if (oValue.GetType() == typeof(DateTime))
                                    {
                                        m_CellFormat.set_format_string_DATETIME();
                                        //m_ExcelCell = m_ExcelWorksheet.Cell(iOfsetRow + 1 + iRow, iOfsetCol + iCol);
                                        m_ExcelCell = m_ExcelWorksheet.Cell(iOfsetRow + 1 + Row_Index, iOfsetCol + iCol);
                                        m_ExcelCell.Set((DateTime)Row.Cells[iCol].Value);
                                        m_ExcelCell.SetFormat(m_CellFormat);
                                    }
                                    else if (oValue.GetType() == typeof(TimeSpan))
                                    {
                                        m_CellFormat.set_format_string_TIME_H();
                                        //m_ExcelCell = m_ExcelWorksheet.Cell(iOfsetRow + 1 + iRow, iOfsetCol + iCol);
                                        m_ExcelCell = m_ExcelWorksheet.Cell(iOfsetRow + 1 + Row_Index, iOfsetCol + iCol);
                                        m_ExcelCell.SetTimeSpan((TimeSpan)Row.Cells[iCol].Value);
                                        m_ExcelCell.SetFormat(m_CellFormat);
                                    }
                                    else if (oValue.GetType() == typeof(bool))
                                    {
                                        bool b;
                                        b = (bool)oValue;
                                        if (b)
                                        {
                                            m_CellFormat.set_format_string_TEXT();
                                            //m_ExcelCell = m_ExcelWorksheet.Cell(iOfsetRow + 1 + iRow, iOfsetCol + iCol);
                                            m_ExcelCell = m_ExcelWorksheet.Cell(iOfsetRow + 1 + Row_Index, iOfsetCol + iCol);
                                            m_ExcelCell.Set(Column.HeaderText);
                                            m_ExcelCell.SetFormat(m_CellFormat);
                                        }
                                    }
                                    else if (oValue.GetType() == typeof(decimal))
                                    {
                                        double dVal;
                                        try
                                        {
                                            dVal = Convert.ToDouble(oValue);
                                            m_CellFormat.set_format_string_DECIMAL();
                                            //m_ExcelCell = m_ExcelWorksheet.Cell(iOfsetRow + 1 + iRow, iOfsetCol + iCol);
                                            m_ExcelCell = m_ExcelWorksheet.Cell(iOfsetRow + 1 + Row_Index, iOfsetCol + iCol);
                                            m_ExcelCell.Set(dVal);
                                            m_ExcelCell.SetFormat(m_CellFormat);
                                        }
                                        catch
                                        {
                                            m_CellFormat.set_format_string_TEXT();
                                            //m_ExcelCell = m_ExcelWorksheet.Cell(iOfsetRow + 1 + iRow, iOfsetCol + iCol);
                                            m_ExcelCell = m_ExcelWorksheet.Cell(iOfsetRow + 1 + Row_Index, iOfsetCol + iCol);
                                            m_ExcelCell.Set((String)Convert.ToString(oValue));
                                            m_ExcelCell.SetFormat(m_CellFormatLongAsText);
                                        }
                                    }
                                }
                            }
                            iCol++;
                        }
                        m_Excel.SaveAs(FileName);
                        m_Progress_Thread.End();
                        try
                        {
                            m_Excel.ShellExecute_(FileName);
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(lngRPM.s_ErrorStartExecuteExcel.s + ":" + FileName + "," + lngRPM.s_Error.s + " = " +Ex.Message);
                        }

                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(lngRPM.s_ErrorInExportToExcel.s + ":" + Ex.Message);
                        m_Progress_Thread.End();
                    }
                    
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                MessageBox.Show(lngRPM.s_ThereAreNoSelectedRowsToExport.s);
                return false;
            }
        }


        private DataGridViewColumn GetColumnByDisplayIndex(DataGridViewColumnCollection dataGridViewColumnCollection, int iColumn)
        {
            foreach (DataGridViewColumn col in dataGridViewColumnCollection)
            {
                if (col.DisplayIndex == iColumn)
                {
                    return col;
                }
            }
            MessageBox.Show("ERROR CAN NOT FIND DISPLAY INDEX !");
            return dataGridViewColumnCollection[iColumn];
        }


    }
}
