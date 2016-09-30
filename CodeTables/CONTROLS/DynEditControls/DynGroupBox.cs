using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LanguageControl;
using System.Drawing;

namespace DynEditControls
{
    public class DynGroupBox : GroupBox
    {
        public ToolTip tooltip = null;
        public Control ParentControl = null;
        public List<EditControl> EditControlsList = null;

        public delegate bool delegate_EnumControlCallback_Check(EditControl myEditControl);
        public delegate void delegate_EnumControlCallback_Fill(EditControl myEditControl);

        private bool m_ReadOnly = false;

        public DynGroupBox():base()
        {
            tooltip = new ToolTip();
            tooltip.AutoPopDelay = 2000;
            tooltip.InitialDelay = 1000;
            tooltip.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            tooltip.ShowAlways = true;
        }

        public bool ReadOnly
        {
            get { return m_ReadOnly; }
            set { m_ReadOnly = value;
                    foreach (EditControl edtctrl in EditControlsList)
                    {
                        edtctrl.ReadOnly = m_ReadOnly;
                    }
                    if (m_ReadOnly)
                    {
                        this.Cursor = Cursors.No;
                    }
                    else
                    {
                        this.Cursor = Cursors.Arrow;
                    }
                }
        }

        private Color  m_ColorChanged = Color.DarkRed;
        public Color ColorChanged
        {
            get { return m_ColorChanged; }
            set { m_ColorChanged = value; }
        }

        private Color m_ColorNotChanged = Color.DarkBlue;
        public Color ColorNotChanged
        {
            get { return m_ColorNotChanged; }
            set { m_ColorNotChanged = value; }
        }


        private int m_LeftMargin = 10;
        public int LeftMargin
        {
            get { return m_LeftMargin; }
            set { m_LeftMargin = value; }
        }

        private int m_MinEditBoxWidth = 36;
        public int MinEditBoxWidth
        {
            get { return m_MinEditBoxWidth; }
            set { m_MinEditBoxWidth = value; }
        }
        private int m_RightMargin = 10;
        public int RightMargin
        {
            get { return m_RightMargin; }
            set { m_RightMargin = value; }
        }

        private int m_TopMargin = 30;
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

        private int m_lblVerticalOffset = 4;
        public int lblVerticalOffset
        {
            get { return m_lblVerticalOffset; }
            set { m_lblVerticalOffset = value; }
        }

        private int m_VerticalOffsetToLabel = 4;
        public int VerticalOffsetToLabel
        {
            get { return m_VerticalOffsetToLabel; }
            set { m_VerticalOffsetToLabel = value; }
        }

        private int m_HorisontallOffsetToLabel = 4;
        public int HorisontallOffsetToLabel
        {
            get { return m_HorisontallOffsetToLabel; }
            set { m_HorisontallOffsetToLabel = value; }
        }

        public void DoReposition(int yPos)
        {
            this.Top = yPos;
            this.Width = ParentControl.Width - 2 * LeftMargin;
            int this_group_ypos = TopMargin;
            int i = 0;
            int MaxHeightInRow = 0;
            int iCount = 0;
            int y = 0;
            if (EditControlsList != null)
            {
                iCount = EditControlsList.Count;
                for (i = 0; i < iCount; i++)
                {
                    EditControlsList[i].DoReposition(ref MaxHeightInRow);
                    //if (y < EditControlsList[i].Top)
                    //{
                        y = EditControlsList[i].Top;
                    //}
                }
            }
            this_group_ypos += y + MaxHeightInRow;

            iCount = Controls.Count;
            for (i = 0; i < iCount; i++)
            {
                object octrl = Controls[i];
                if (octrl is DynGroupBox)
                {
                    ((DynGroupBox)octrl).DoReposition(this_group_ypos);
                    this_group_ypos += ((DynGroupBox)octrl).Height + VerticalDistance;
                }
            }
            this.Height = this_group_ypos;
            this.Left = LeftMargin;

        }


        public DynGroupBox AddGroupBox(string Name, ltext lt_Label)
        {
            DynGroupBox newGroupBox = new DynGroupBox();
            newGroupBox.Name = "grp_" + Name;
            newGroupBox.ParentControl = this;
            lt_Label.Text(newGroupBox);
            newGroupBox.BackColor = Color.FromArgb(this.BackColor.R - 5, this.BackColor.G - 5, this.BackColor.B - 5);
            newGroupBox.MinEditBoxWidth = this.m_MinEditBoxWidth;
            newGroupBox.RightMargin = this.RightMargin;
            newGroupBox.TopMargin = this.TopMargin;
            newGroupBox.VerticalDistance = this.VerticalDistance;
            newGroupBox.HorisontalDistance = this.HorisontalDistance;
            newGroupBox.lblVerticalOffset = this.lblVerticalOffset;
            newGroupBox.VerticalOffsetToLabel = this.VerticalOffsetToLabel;
            newGroupBox.HorisontallOffsetToLabel = this.HorisontallOffsetToLabel;

            this.Controls.Add(newGroupBox);
            return newGroupBox;

        }

        public bool EnumEditControl_Check(delegate_EnumControlCallback_Check enum_control_callback_check)
        {
            int i;
            int iCount = Controls.Count;
            bool bRes = true;
            for (i = 0; i < iCount; i++)
            {
                object octrl = Controls[i];
                if (octrl is DynGroupBox)
                {
                    if (!((DynGroupBox)octrl).EnumEditControl_Check(enum_control_callback_check))
                    {
                        bRes = false;
                    }
                }
            }
            iCount = EditControlsList.Count;
            for (i = 0; i < iCount; i++)
            {
                if (!enum_control_callback_check(EditControlsList[i]))
                {
                    bRes = false;
                }
            }
            return bRes;
        }

        public void EnumEditControl_Fill(delegate_EnumControlCallback_Fill enum_control_callback_fill)
        {
            int i;
            int iCount = Controls.Count;
            bool bRes = true;
            for (i = 0; i < iCount; i++)
            {
                object octrl = Controls[i];
                if (octrl is DynGroupBox)
                {
                    ((DynGroupBox)octrl).EnumEditControl_Fill(enum_control_callback_fill);
                }
            }
            iCount = EditControlsList.Count;
            for (i = 0; i < iCount; i++)
            {
                enum_control_callback_fill(EditControlsList[i]);
            }
        }
    }
}