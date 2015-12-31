using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excell_Export;
using LanguageControl;
namespace DataGridView_2xls
{
    public partial class DataGridView2xls : DataGridView
    {
        private bool m_DataGridViewWithRowNumber = false;

        public bool DataGridViewWithRowNumber
        {
         get {return m_DataGridViewWithRowNumber;}
         set {m_DataGridViewWithRowNumber= value;
              if (m_DataGridViewWithRowNumber)
              {
                  this.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dgGrid_RowPostPaint);
              }
              else
              {
                  this.RowPostPaint -= dgGrid_RowPostPaint;
              }
              this.Refresh();
             }
        }

        public DataGridView2xls()
        {
            //InitializeComponent();
            this.CellMouseClick += new DataGridViewCellMouseEventHandler(DataGridView_2xls_CellMouseClick);
            this.CellPainting += new DataGridViewCellPaintingEventHandler(DataGridView_2xls_CellPainting);
            
        }

        void DataGridView_2xls_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1) && (e.ColumnIndex == -1))
            {
                Rectangle newRect = new Rectangle(e.CellBounds.X + 1,
                  e.CellBounds.Y + 1, e.CellBounds.Width - 4,
                  e.CellBounds.Height - 4);

                using (
                    Brush gridBrush = new SolidBrush(this.GridColor),
                    backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                {
                    using (Pen gridLinePen = new Pen(gridBrush))
                    {
                        // Erase the cell.
                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

                        // Draw the grid lines (only the right and bottom lines; 
                        // DataGridView takes care of the others).
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
                            e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
                            e.CellBounds.Bottom - 1);
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
                            e.CellBounds.Top, e.CellBounds.Right - 1,
                            e.CellBounds.Bottom);

                        // Draw the inset highlight box.
                        e.Graphics.DrawRectangle(Pens.Blue, newRect);

                        // Draw the text content of the cell, ignoring alignment. 
                        e.Graphics.DrawString("Excel", e.CellStyle.Font,
                            Brushes.Blue, e.CellBounds.X + 2,
                            e.CellBounds.Y + 2, StringFormat.GenericDefault);
                    }
                }
                e.Handled = true;
            }
        }

        void DataGridView_2xls_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if ((e.RowIndex == -1) && (e.ColumnIndex == -1))
                {
                    if (MessageBox.Show(lngRPM.s_SaveSelectedRowsToExcelFile.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        Excell excell = new Excell();
                        string FileName = "Table";
                        excell.Export(ref FileName, this);
                    }
                }
                else
                {
                    if (e.ColumnIndex == -1)
                    {
                        if (MessageBox.Show(lngRPM.s_ShowRowNumbers.s + "?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            if (!DataGridViewWithRowNumber)
                            {
                                DataGridViewWithRowNumber = true;
                            }
                        }
                        else
                        {
                            if (DataGridViewWithRowNumber)
                            {
                                DataGridViewWithRowNumber = false;
                            }
                        }
                    }
                }
            }
        }


        private void dgGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //var grid = sender as DataGridView;
            //var rowIdx = (e.RowIndex + 1).ToString();

            //var centerFormat = new StringFormat()
            //{
            //    // right alignment might actually make more sense for numbers
            //    Alignment = StringAlignment.Center,
            //    LineAlignment = StringAlignment.Center
            //};

            //var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            //e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
            DataGridView grid   = (DataGridView)sender;
            string rowIdx  = (e.RowIndex + 1).ToString();
            System.Drawing.Font rowFont = new System.Drawing.Font("Tahoma", 10.0F, 
                                                                System.Drawing.FontStyle.Regular, 
                                                                System.Drawing.GraphicsUnit.Point,(Byte)0);

            StringFormat centerFormat = new StringFormat();
            centerFormat.Alignment = StringAlignment.Far;
            centerFormat.LineAlignment = StringAlignment.Near;

            Rectangle headerBounds  = new Rectangle(
                                                    e.RowBounds.Left-2, e.RowBounds.Top,
                                                    grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, rowFont, SystemBrushes.ControlText,
            headerBounds, centerFormat);

        }
    }
}
