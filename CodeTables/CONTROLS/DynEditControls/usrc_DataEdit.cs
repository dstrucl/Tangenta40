using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LanguageControl;

namespace DynEditControls
{
    public partial class usrc_DataEdit : UserControl
    {
        private int m_LeftMargin = 10;
        public int LeftMargin
        {
            get { return m_LeftMargin; }
            set { m_LeftMargin = value; }
        }

        public void Init()
        {
            DoResize();
            this.Resize += Usrc_DataEdit_Resize;
        }

        private Color m_ColorChanged = Color.DarkRed;
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

        public usrc_DataEdit()
        {
            InitializeComponent();
        }

        public DynGroupBox AddGroupBox(string Name,ltext lt_Label)
        {
            DynGroupBox newGroupBox = new DynGroupBox();
            newGroupBox.Name = "grp_" + Name;
            lt_Label.Text(newGroupBox);
            newGroupBox.ParentControl = this;
            newGroupBox.ColorChanged = this.ColorChanged;
            newGroupBox.ColorNotChanged = this.ColorNotChanged;
            newGroupBox.MinEditBoxWidth = this.m_MinEditBoxWidth;
            newGroupBox.RightMargin = this.RightMargin;
            newGroupBox.TopMargin = this.TopMargin;
            newGroupBox.VerticalDistance = this.VerticalDistance;
            newGroupBox.HorisontalDistance = this.HorisontalDistance;
            newGroupBox.lblVerticalOffset = this.lblVerticalOffset;
            newGroupBox.VerticalOffsetToLabel = this.VerticalOffsetToLabel;
            newGroupBox.HorisontallOffsetToLabel = this.HorisontallOffsetToLabel;
            newGroupBox.Top = this.TopMargin;
            newGroupBox.Left= this.RightMargin;
            newGroupBox.Width = this.Width;
            newGroupBox.Height = 40;
            newGroupBox.Visible = true;
            newGroupBox.BackColor = Color.FromArgb(210, 210, 210);
            newGroupBox.Enabled = true;
            this.Controls.Add(newGroupBox);
            //child_DynGroupBoxList.Add(newGroupBox);
            return newGroupBox;

        }


        private void DoResize()
        {
            int i = 0;
            int yPos = 10;
            if (Controls.Count > 0)
            {
                int iCount = Controls.Count;
                for (i = 0; i < iCount; i++)
                {
                        object octrl = Controls[i];
                        if (octrl is DynGroupBox)
                        {
                            ((DynGroupBox)octrl).DoReposition(yPos);
                            yPos += ((DynGroupBox)octrl).Height + VerticalDistance;
                        }
                }
            }
        }


        private void Usrc_DataEdit_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        public bool Check(DynGroupBox.delegate_EnumControlCallback_Check EnumControlCallback_check)
        {

            int i = 0;
            bool bRes = true;
            int iCount = Controls.Count;
            for (i = 0; i < iCount; i++)
            {
                object octrl = Controls[i];
                if (octrl is DynGroupBox)
                {
                    if (!((DynGroupBox)octrl).EnumEditControl_Check(EnumControlCallback_check))
                    {
                        bRes = false;
                    }
                }
            }
            return bRes;
        }

        public void Fill(DynGroupBox.delegate_EnumControlCallback_Fill EnumControlCallback_Fill)
        {

            int i = 0;
            int iCount = Controls.Count;
            for (i = 0; i < iCount; i++)
            {
                object octrl = Controls[i];
                if (octrl is DynGroupBox)
                {
                    ((DynGroupBox)octrl).EnumEditControl_Fill(EnumControlCallback_Fill);
                }
            }
        }

    }
}
