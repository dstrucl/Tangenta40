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
using LanguageControl;

namespace SQLTableControl
{
    public class EditControl
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public TextBox txtBox;
        public Label lbl;

        public EditControl(SQLTable tblOf2Coulumns,List<EditControl> edtCtrlList)
        {

        }

        public void SetPositionAndSize(List<EditControl> edtCtrlList)
        {
            int iCount = edtCtrlList.Count;
            if (iCount > 0)
            {
                lbl.Width = 100;
                lbl.Height = 21;
                txtBox.Width = 100;
                txtBox.Height = 21;
                int iLastIndex = iCount - 1;
                if (iCount % 2 == 0)
                {
                    x = 5;
                    y = edtCtrlList[iLastIndex].y + edtCtrlList[iLastIndex].height;
                    width = lbl.Width + txtBox.Width;
                    height = lbl.Height;
                }
                else
                {
                    x = edtCtrlList[iLastIndex].x + edtCtrlList[iLastIndex].width;
                    y = edtCtrlList[iLastIndex].y;
                    width = lbl.Width + txtBox.Width;
                    height = lbl.Height;
                }
            }
            else
            {
                x = 5;
                y = 5;
                lbl.Width = 100;
                lbl.Height = 21;
                txtBox.Width = 100;
                txtBox.Height = 21;
                width = lbl.Width + txtBox.Width;
                height = lbl.Height;
            }
        }

        public EditControl(Form pParentForm, Column col, List<EditControl> edtCtrlList)
        {
            lbl = new Label();
            txtBox = new TextBox();
            col.Name_in_language.Text(lbl);
            lbl.AutoSize = false;
            lbl.Parent = pParentForm;
            lbl.Visible = true;
            SetPositionAndSize(edtCtrlList);
            edtCtrlList.Add(this);
        }

        public EditControl(TabPage pParentTabPage, Column col, List<EditControl> edtCtrlList)
        {
            lbl = new Label();
            txtBox = new TextBox();
            col.Name_in_language.Text(lbl);
            lbl.AutoSize = false;
            lbl.Parent = pParentTabPage;
            lbl.Visible = true;
            SetPositionAndSize(edtCtrlList);
            edtCtrlList.Add(this);
        }
    }
}
