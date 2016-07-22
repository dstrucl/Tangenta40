using DBTypes;
using LanguageControl;
using SelectGender;
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
        public ltext m_lt_help = null;
        public Label lbl = null;

        public Control edit_control = null;

        private usrc_SampleDataEdit m_usrc_SampleDataEdit = null;
        private object m_refobj = null;
        private string m_Name = null;
        public int Height = -1;
        public int Width = -1;
        public int Top = -1;
        public int Left = -1;
        public int ypos = -1;
        public int xpos = -1;
        public EditControl pNext = null;
        public EditControl pPrev = null;

        private int m_MinEditBoxWidth = 30;
        public int MinEditBoxWidth
        {
            get { return m_MinEditBoxWidth; }
            set { m_MinEditBoxWidth = value; }
        }

        private int m_LeftMargin = 10;
        public int LeftMargin
        {
            get { return m_LeftMargin; }
            set { m_LeftMargin = value; }
        }

        private int m_RightMargin = 10;
        public int RightMargin
        {
            get { return m_RightMargin; }
            set { m_RightMargin = value; }
        }

        private int m_TopMargin = 5;
        public int TopMargin
        {
            get { return m_TopMargin; }
            set { m_TopMargin = value; }
        }

        private int m_VerticalDistance = 5;
        public int VerticalDistance
        {
            get { return m_VerticalDistance; }
            set { m_VerticalDistance = value; }
        }

        private int m_HorisontalDistance = 3;
        public int HorisontalDistance
        {
            get { return m_HorisontalDistance; }
            set { m_HorisontalDistance = value; }
        }

        private int m_txtVerticalOffsetToLabel = 0;
        public int TxtVerticalOffsetToLabel
        {
            get { return m_txtVerticalOffsetToLabel; }
            set { m_txtVerticalOffsetToLabel = value; }
        }

        private int m_lblVerticalOffset = 4;
        public int lblVerticalOffset
        {
            get { return m_lblVerticalOffset; }
            set { m_lblVerticalOffset = value; }
        }

        private int m_HorisontallOffsetToLabel = 4;
        public int HorisontallOffsetToLabel
        {
            get { return m_HorisontallOffsetToLabel; }
            set { m_HorisontallOffsetToLabel = value; }
        }



        public EditControl(usrc_SampleDataEdit usrc_parent,object refobj, string xName,ltext lt_label, ltext lt_val, ltext lt_help)
        {
            m_usrc_SampleDataEdit = usrc_parent;
            m_lt_help = lt_help;
            this.MinEditBoxWidth = m_usrc_SampleDataEdit.MinEditBoxWidth;
            this.LeftMargin = m_usrc_SampleDataEdit.LeftMargin;
            this.RightMargin = m_usrc_SampleDataEdit.RightMargin;
            this.TopMargin = m_usrc_SampleDataEdit.TopMargin;
            this.VerticalDistance = m_usrc_SampleDataEdit.VerticalDistance;
            this.HorisontalDistance = m_usrc_SampleDataEdit.HorisontalDistance;
            this.lblVerticalOffset = m_usrc_SampleDataEdit.lblVerticalOffset;
            this.TxtVerticalOffsetToLabel = m_usrc_SampleDataEdit.VerticalOffsetToLabel;
            this.HorisontallOffsetToLabel = m_usrc_SampleDataEdit.HorisontallOffsetToLabel;
            m_refobj = refobj;
            m_Name = xName;
            lbl = new Label();
            if (m_refobj is dstring_v)
            {
                edit_control = new TextBox();
                edit_control.Text = lt_val.s;
            }
            else if (m_refobj is dbool_v)
            {
                if (xName.Equals("MyOrg_Person_Gender"))
                {
                    edit_control = new usrc_SelectGender();
                    ((usrc_SelectGender)edit_control).RadioButton1IsTrue = true;
                    ((usrc_SelectGender)edit_control).RadioButton1_Text = lngRPM.s_Male.s;
                    ((usrc_SelectGender)edit_control).RadioButton2_Text = lngRPM.s_Female.s;
                }
                else
                {
                    edit_control = new CheckBox();
                    ((CheckBox)edit_control).Text = "";
                }
            }
            else if (m_refobj is dDateTime_v)
            {
                edit_control = new DateTimePicker();
                edit_control.Text = "";
                ((DateTimePicker)edit_control).Value = DateTime.Now;
            }
            else
            {
                LogFile.Error.Show("ERROR:EditControl:unsuported type: m_refobj type =" + m_refobj.GetType().ToString());
                return;
            }

                lbl.Name = "lbl_" + m_Name;
            lbl.Font = usrc_parent.Font;
            edit_control.Name = "txt_" + m_Name;
            edit_control.Font = usrc_parent.Font;
            lbl.AutoSize = false;
            lbl.Text = lt_label.s + ":";
            SizeF size_lbl = lbl.CreateGraphics().MeasureString(lbl.Text, lbl.Font);
            SizeF size_txt = lbl.CreateGraphics().MeasureString(edit_control.Text, edit_control.Font);
            lbl.Width = (int)Math.Ceiling(size_lbl.Width);
            lbl.Height = (int)Math.Ceiling(size_lbl.Height);
            if ((m_refobj is dstring_v))
            {
                edit_control.Width = MinEditBoxWidth;
                int txt_calculated_width = (int)Math.Ceiling(size_txt.Width) + 4;
                if (edit_control.Width < txt_calculated_width)
                {
                    edit_control.Width = txt_calculated_width;
                }
            }

            this.Width = lbl.Width + m_HorisontallOffsetToLabel + edit_control.Width;
            if (m_usrc_SampleDataEdit.EditControlsList == null)
            {
                m_usrc_SampleDataEdit.EditControlsList = new List<EditControl>();
            }
            m_usrc_SampleDataEdit.EditControlsList.Add(this);
            int EditControlsList_Count = m_usrc_SampleDataEdit.EditControlsList.Count;
            if (EditControlsList_Count == 1)
            {
                this.pPrev = null;
                this.pNext = null;
            }
            else if (EditControlsList_Count > 1)
            {
                this.pPrev = m_usrc_SampleDataEdit.EditControlsList[EditControlsList_Count-2];
                m_usrc_SampleDataEdit.EditControlsList[EditControlsList_Count - 2].pNext = this;
                this.pNext = null;
            }
            m_usrc_SampleDataEdit.Controls.Add(lbl);
            m_usrc_SampleDataEdit.Controls.Add(edit_control);
        }

        public void DoReposition()
        {

            ypos = m_TopMargin;
            xpos = m_LeftMargin;
            if (pPrev != null)
            {
                if (pPrev.xpos + pPrev.Width + m_HorisontalDistance + this.Width + m_RightMargin < m_usrc_SampleDataEdit.Width)
                {
                    xpos = pPrev.xpos + pPrev.Width + m_HorisontalDistance;
                    ypos = pPrev.ypos;
                }
                else
                {
                    ypos = pPrev.ypos + edit_control.Height + m_VerticalDistance;
                    xpos = m_LeftMargin;
                }
            }

            lbl.Top = ypos+ m_lblVerticalOffset;
            lbl.Left = xpos;
            edit_control.Top = ypos;
            edit_control.Left = lbl.Left + lbl.Width + m_HorisontalDistance;
        }
    }
}
