using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace DataGridViewWithRowNumber
{
    public class DataGridViewWithRowNumber:DataGridView
    {
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

        public DataGridViewWithRowNumber()
        {
            this.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dgGrid_RowPostPaint);
        }
    }
}
