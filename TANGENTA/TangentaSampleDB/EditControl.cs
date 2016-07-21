using LanguageControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TangentaSampleDB
{
    public class EditControl
    {
        public Label lbl = null;
        public TextBox txt = null;
        private UserControl m_usrc_parent = null;
        private object m_refobj = null;
        private string m_Name = null;
        

        public EditControl(UserControl usrc_parent, object refobj, string xName,ltext lt_label, ltext lt_val)
        {
            List<EditControl> EditControlsList = null;
            m_usrc_parent = usrc_parent;
            m_refobj = refobj;
            m_Name = xName;
            lbl = new Label();
            txt = new TextBox();
            lbl.Name = "lbl_" + m_Name;
            lbl.Font = usrc_parent.Font;
            txt.Name = "txt_" + m_Name;
            txt.Font = usrc_parent.Font;
            if (usrc_parent.Tag is List<EditControl>)
            {
                EditControlsList = (List<EditControl>)usrc_parent.Tag;
            }
            else
            {
                EditControlsList = new List<EditControl>();
                usrc_parent.Tag = EditControlsList;
            }
            int EditControlsList_Count = EditControlsList.Count;
            int LastEditControlList_item = EditControlsList_Count - 1;
            EditControlsList.Add(this);
            int ypos = 0;
            int xpos = 10;
            lbl.AutoSize = false;
            lbl.Text = lt_label.s;
            SizeF size = lbl.CreateGraphics().MeasureString(lbl.Text, lbl.Font);
            lbl.Width = (int)Math.Ceiling(size.Width);
            lbl.Height = (int)Math.Ceiling(size.Height);
            if (LastEditControlList_item>=0)
            {
                ypos = EditControlsList[LastEditControlList_item].lbl.Top + lbl.Height + 5;
            }
            lbl.Top = ypos;
            lbl.Left = xpos;
            txt.Left = lbl.Left + lbl.Width + 5;
            txt.Top = lbl.Top;
            txt.Text = lt_val.s;
            usrc_parent.Controls.Add(lbl);
            usrc_parent.Controls.Add(txt);
        }
    }
}
