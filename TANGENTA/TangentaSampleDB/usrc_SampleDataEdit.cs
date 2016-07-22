using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBTypes;
using LanguageControl;

namespace TangentaSampleDB
{
    public partial class usrc_SampleDataEdit : UserControl
    {
        public List<EditControl> EditControlsList = null;

        private int m_LeftMargin = 10;
        public int LeftMargin
        {
            get { return m_LeftMargin; }
            set { m_LeftMargin = value; }
        }

        internal void Init()
        {
            DoResize();
            this.Resize += Usrc_SampleDataEdit_Resize;
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

        private int m_TopMargin = 0;
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


        public usrc_SampleDataEdit()
        {
            InitializeComponent();
        }

        private void DoResize()
        {
            int i = 0;
            if (EditControlsList != null)
            {
                int iCount = EditControlsList.Count;
                for (i = 0; i < iCount; i++)
                {
                    EditControlsList[i].DoReposition();
                }
            }
        }
        private void Usrc_SampleDataEdit_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
    }
}
