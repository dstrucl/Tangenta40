#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SQLTableControl
{
    public class Margin
    {
        public int left = 5;
        public int right = 5;
        public int top = 5;
        public int bottom = 5;
    }

    public class MyTabControl:TabControl
    {
        public Margin margin;

    //    public MySize size = null;
    //    public MyPos pos = null;
        private int HeightOfEditControls(List<EditControl> edtCtrlList)
        {
            int iCount = edtCtrlList.Count;
            if (iCount > 0)
            {
                int iLastIndex = iCount - 1;
                return edtCtrlList[iLastIndex].y + edtCtrlList[iLastIndex].height;
            }
            else
            {
                return 0;
            }
        }

        public MyTabControl(Form parentForm, List<EditControl> edtCtrlList)
        {
            margin = new Margin();
            base.Width = parentForm.Width - margin.left - margin.right-20;
            base.Height = parentForm.Height - margin.top - margin.bottom-30;
            base.Top = HeightOfEditControls(edtCtrlList) + margin.top;
            base.Left = margin.left;
            base.Parent = parentForm;
            base.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            base.Multiline = true;
            base.Alignment = TabAlignment.Left;
            base.SizeMode = TabSizeMode.Fixed;
            base.DrawMode = TabDrawMode.OwnerDrawFixed;
            base.DrawItem += new DrawItemEventHandler(tabControl_DrawItem);
            base.ItemSize = new System.Drawing.Size(48, 96);
            Visible = true;


        }

        public MyTabControl(TabPage parentTabPageControl, List<EditControl> edtCtrlList)
        {
            margin = new Margin();
            base.Width = parentTabPageControl.Width - margin.left - margin.right;
            base.Height = parentTabPageControl.Height - margin.top - margin.bottom;
            base.Top = HeightOfEditControls(edtCtrlList) + margin.top;
            base.Left = margin.left;
            base.Parent = parentTabPageControl;
            base.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            base.Multiline = true;
            base.Alignment = TabAlignment.Top;
            //base.SizeMode = TabSizeMode.Fixed;
            //base.DrawMode = TabDrawMode.OwnerDrawFixed;
            //base.DrawItem += new DrawItemEventHandler(tabControl_DrawItem);
            //base.ItemSize = new System.Drawing.Size(48, 96);
            Visible = true;
        }

        private void tabControl_DrawItem(Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = base.TabPages[e.Index];
            _tabPage.BorderStyle = BorderStyle.Fixed3D;
            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = base.GetTabRect(e.Index);

            if (e.State== DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Red);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Arial", (float)12.0, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

    }
}
