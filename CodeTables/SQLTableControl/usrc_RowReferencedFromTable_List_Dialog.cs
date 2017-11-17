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
using LanguageControl;

namespace CodeTables
{
    public partial class usrc_RowReferencedFromTable_List_Dialog : Form
    {

        List<usrc_RowReferencedFromTable> m_usrc_RowReferencedFromTable_List = null;
        private ltext Instruction = null;
        SQLTable m_tbl = null;
        long id = -1;
        public usrc_RowReferencedFromTable_List_Dialog(List<usrc_RowReferencedFromTable> x_usrc_RowReferencedFromTable_List,SQLTable x_tbl,long x_id, ltext xInstruction)
        {
            InitializeComponent();
            Instruction = xInstruction;
            m_usrc_RowReferencedFromTable_List = x_usrc_RowReferencedFromTable_List;
            m_tbl = x_tbl;
            id = x_id;
            if (m_usrc_RowReferencedFromTable_List!=null)
            {
                int y = 0;
                foreach (usrc_RowReferencedFromTable x_usrc_RowReferencedFromTable in m_usrc_RowReferencedFromTable_List)
                {
                    x_usrc_RowReferencedFromTable.Top = y;
                    x_usrc_RowReferencedFromTable.Left = 2;
                    x_usrc_RowReferencedFromTable.BorderStyle = BorderStyle.Fixed3D;
                    x_usrc_RowReferencedFromTable.Width = pnl_usrc_RowReferencedTable_List.Width - 4;
                    x_usrc_RowReferencedFromTable.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    x_usrc_RowReferencedFromTable.Visible = true;
                    pnl_usrc_RowReferencedTable_List.Controls.Add(x_usrc_RowReferencedFromTable);
                    y += x_usrc_RowReferencedFromTable.Height + 2;
                }
            }
            this.btn_Yes.Text = lng.s_Yes.s;
            this.btn_No.Text = lng.s_No.s;
        }

        private void btn_No_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.No;
        }

        private void btn_Yes_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Yes;
        }

        private void usrc_RowReferencedFromTable_List_Dialog_Load(object sender, EventArgs e)
        {
            this.Text = lng.s_Warning.s;
            if (Instruction!=null)
            {
                Instruction.Text(this.lbl_Message);
            }
            else
            { 
                List<object> ltext_obj_list = new List<object>();
                ltext_obj_list.Add(lng.s_RowWithID);
                ltext_obj_list.Add(id.ToString());
                ltext_obj_list.Add(lng.s_InTable);
                ltext_obj_list.Add(m_tbl.lngTableName.s);
                ltext_obj_list.Add(lng.s_IsReferencedSeveralTimes);
                ltext_obj_list.Add("!\r\n");
                ltext_obj_list.Add(lng.s_IfYouChangeThisRowThisWillAffectAllRowsThatAreReferencingIt);
                ltext_obj_list.Add("\r\n");
                ltext_obj_list.Add(lng.s_BellowIsTheListOfTableReferences);
                ltext_obj_list.Add("\r\n");
                ltext_obj_list.Add(lng.s_ChangeThisRowQuestion);
                ltext xInstruction = new ltext(ltext_obj_list);
                xInstruction.Text(lbl_Message);
            }
            this.btn_No.Focus();
        }
    }
}
