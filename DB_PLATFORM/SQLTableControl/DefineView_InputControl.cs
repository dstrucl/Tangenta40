using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using System.Drawing;
using DBTypes;
using System.Drawing.Imaging;
using GraphicsExtensions;
using System.Drawing.Drawing2D;

namespace SQLTableControl
{
    public class DefineView_InputControl: Panel
    {

        public int RoundedCornerAngle { get; set; }
        public int LeftBarSize { get; set; }
        public int RightBarSize { get; set; }
        public int StatusBarSize { get; set; }
        //public Padding Padding { get; set; }

        public new Font Font { get; set; }
        public string MainText { get; set; }
        public string LeftText { get; set; }
        public string RightText { get; set; }
        public string StatusText { get; set; }
        //public string Name { get; set; }
        public string FullName{ get; set; }

        private string ColTitleLong;

        public bool bUseSqlFilter = false;
        public string SQLFilter="";

        public Column m_col{ get; set; }

        private Color StatusColor1;
        private Color StatusColor2;

        public CheckBox m_chkUseFiler = null;
        public TextBox m_txtSQLFilter = null;

        /// <summary>
        /// ColorIndex. [0 - Raw active] [1 - Raw inactive] [2 - Dry active] [3 - Dry inactive].
        /// </summary>
        public int StatusBarColor
        {
            get { return _StatusBarColorIndex; }
            set
            {
                switch (value)
                {
                    case 0:
                        //Raw active
                        StatusColor1 = Color.FromArgb(161, 182, 155);
                        StatusColor2 = Color.FromArgb(108, 136, 100);
                        break;
                    case 1:
                        //Raw inactive
                        StatusColor1 = Color.FromArgb(161, 182, 155);
                        StatusColor2 = Color.FromArgb(154, 160, 182);
                        break;
                    case 2:
                        // Dry active
                        StatusColor1 = Color.Goldenrod;
                        StatusColor2 = Color.DarkGoldenrod;
                        break;
                    case 3:
                        // Dry inactive
                        StatusColor1 = Color.Goldenrod;
                        StatusColor2 = Color.FromArgb(99, 106, 134);
                        break;
                    default:
                        StatusColor1 = Color.FromArgb(99, 106, 134);
                        StatusColor2 = Color.FromArgb(99, 106, 134);
                        break;
                }
            }
        }

        private Color FirstColor;
        private Color SecondColor;
        private int _FillDegree = 50;
        public int FillDegree
        {
            get { return _FillDegree; }
            set 
            {
                if (value >= 100)
                {
                    FirstColor = Color.Red;
                    SecondColor = Color.DarkRed;
                }
                else if (value > 90)
                {
                    FirstColor = Color.Yellow;
                    SecondColor = Color.Gold;
                }
                else if (value > 80)
                {
                    FirstColor = Color.Gold;
                    SecondColor = Color.DarkGoldenrod;
                }               
                else
                {
                    FirstColor = Color.FromArgb(161, 182, 155);
                    SecondColor = Color.FromArgb(60, 76, 56);
                }
                _FillDegree = value;
            }
        }

        //Check radius for begin drag n drop
        public bool AllowDrag { get; set; }
        private bool _isDragging = false;
        private int _DDradius = 40;
        private int _mX=0;
        private int _mY=0;
        private int _StatusBarColorIndex=0;

        //public DefineView_InputControl()
        //{
        //    Font = new Font("Arial", 10);
        //    FillDegree = 10;
        //    RoundedCornerAngle = 10;
        //    Margin = new Padding(0);
        //    LeftText = "LT";
        //    StatusText = "Not set";
        //    MainText = "Hec";
        //    RightText = "RT";
        //    LeftBarSize = 5;
        //    StatusBarSize = 5;
            
        //    RightBarSize = 5;
        //    StatusBarColor = 99;
        //    AllowDrag = true;
        //}

        public DefineView_InputControl(Column col, List<DefineView_InputControl> inpCtrlList, string sImportExportLine, bool bNumber,ref int iCtrl)
        {
            Font = new Font("Arial", 10);
            FillDegree = 10;
            RoundedCornerAngle = 10;
            Margin = new Padding(0);
            LeftText = iCtrl.ToString();
            m_col = col;
            StatusText = "Not set";
            Name = col.Name;
            FullName = sImportExportLine;
            MainText = col.Name_in_language.s;

            ColTitleLong = this.MainText + " (" + m_col.Name + ")";
            RightText = iCtrl.ToString(); 
            LeftBarSize = 30;
            StatusBarSize = 5;
            RightBarSize = 30;
            StatusBarColor = 99;
            AllowDrag = true;
            iCtrl++;
        }

        protected override void OnGotFocus(EventArgs e)
        {
            this.BackColor = Color.Gold;
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            this.BackColor = Color.Transparent;
            base.OnLostFocus(e);
        }

        protected override void OnClick(EventArgs e)
        {
            this.Focus();
            base.OnClick(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.Focus();
            base.OnMouseDown(e);
            _mX = e.X;
            _mY = e.Y;
            this._isDragging = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!_isDragging)
            {
                // This is a check to see if the mouse is moving while pressed.
                // Without this, the DragDrop is fired directly when the control is clicked, now you have to drag a few pixels first.
                if (e.Button == MouseButtons.Left && _DDradius > 0 && this.AllowDrag)
                {
                    int num1 = _mX - e.X;
                    int num2 = _mY - e.Y;
                    if (((num1 * num1) + (num2 * num2)) > _DDradius)
                    {
                        DoDragDrop(this, DragDropEffects.All);
                        _isDragging = true;
                        return;
                    }
                }
                base.OnMouseMove(e);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _isDragging = false;
            base.OnMouseUp(e);
        }

        protected override void OnParentChanged(EventArgs e)
        {
            if (this.Parent != null)
            {
                if (this.Parent.Tag.GetType() == typeof(int))
                {
                    if ((int)this.Parent.Tag == 1)
                    {
                        //  this.Height = this.Parent.Height - 30;
                        if (m_txtSQLFilter == null)
                        {
                            m_chkUseFiler = new CheckBox();
                            m_chkUseFiler.Text = lngRPM.s_UseFilter.s;
                            m_chkUseFiler.Left = 48;
                            m_chkUseFiler.Top = 30;
                            m_chkUseFiler.Visible = true;
                            m_chkUseFiler.Parent = this;
                            m_chkUseFiler.Enabled = true;
                            m_chkUseFiler.BackColor = Color.DimGray;

                            m_txtSQLFilter = new TextBox();
                            m_txtSQLFilter.Left = 48;
                            m_txtSQLFilter.Top = 60;
                            m_txtSQLFilter.Multiline = true;
                            m_txtSQLFilter.Visible = true;
                            m_txtSQLFilter.Parent = this;
                            m_txtSQLFilter.Enabled = true;
                            m_txtSQLFilter.BackColor = Color.Beige;

                            m_chkUseFiler.Checked = this.bUseSqlFilter;

                            if (this.SQLFilter.Length > 0)
                            {
                                m_txtSQLFilter.Text = this.SQLFilter;
                            }
                        }
                    }
                    else
                    {
                        if (m_txtSQLFilter != null)
                        {
                            m_chkUseFiler.Dispose();
                            m_chkUseFiler = null;
                            m_txtSQLFilter.Dispose();
                            m_txtSQLFilter = null;
                        }
                    }
                }
            }
            base.OnParentChanged(e); 
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            paintThisShit(e.Graphics);
        }

        public void paintThisShit(Graphics _graphics)
        {
            // Textformat
            bool bTag1 = false;
            if (this.Parent.Tag.GetType() == typeof(int))
            {
                if ((int)this.Parent.Tag == 1)
                {
                    bTag1 = true;
                    this.Height = this.Parent.Height - 30;
                    m_txtSQLFilter.Width = this.Width - 86;
                    if ((this.Height - 100) > 30)
                    {
                        m_txtSQLFilter.Height = this.Height - 100;
                    }
                }
            }

            StringFormat f = new StringFormat();
            f.Alignment = StringAlignment.Center;
            f.LineAlignment = StringAlignment.Center;

            // Textformat
            StringFormat fl = new StringFormat();
            fl.Alignment = StringAlignment.Near;
            fl.LineAlignment = StringAlignment.Center;
            // Misc
            _graphics = this.CreateGraphics();
            System.Drawing.Drawing2D.LinearGradientBrush _LeftAndRightBrush = new LinearGradientBrush(GetMainArea(), Color.DimGray, Color.Black, LinearGradientMode.Vertical);
            System.Drawing.Drawing2D.LinearGradientBrush _StatusBrush = new LinearGradientBrush(GetMainArea(), StatusColor1, StatusColor2, LinearGradientMode.Vertical);
            System.Drawing.Drawing2D.LinearGradientBrush _MainBrush = new LinearGradientBrush(GetMainArea(), FirstColor, SecondColor, LinearGradientMode.Vertical);
            
            // Draw left
            if (LeftBarSize > 0)
            {
                _graphics.FillRoundedRectangle(_LeftAndRightBrush, this.GetLeftArea(), this.RoundedCornerAngle, RectangleEdgeFilter.TopLeft | RectangleEdgeFilter.BottomLeft);
                _graphics.DrawString(this.LeftText, this.Font, Brushes.White, this.GetLeftArea(), f);
            }
            
            // Draw status
            if (StatusBarSize > 0)
            {
                _graphics.FillRoundedRectangle(_StatusBrush, this.GetStatusArea(), this.RoundedCornerAngle, RectangleEdgeFilter.None);
                _graphics.DrawString(this.StatusText, this.Font, Brushes.White, this.GetStatusArea(), f);
            }

            // Draw main background
            _graphics.FillRoundedRectangle(Brushes.DimGray, GetMainAreaBackground(), this.RoundedCornerAngle, RectangleEdgeFilter.None);

            // Draw main
            //_graphics.FillRoundedRectangle(_MainBrush, this.GetMainArea(), this.RoundedCornerAngle, RectangleEdgeFilter.None);

            //_graphics.DrawString(this.MainText, this.Font, Brushes.White, this.GetMainAreaBackground(), f);
            if (bTag1)
            {
                _graphics.DrawString(ColTitleLong, this.Font, Brushes.White, this.GetMainAreaEx(), fl);
            }
            else
            {
                _graphics.DrawString(this.MainText, this.Font, Brushes.White, this.GetMainAreaEx(), fl);
            }

            // Draw right
            if (RightBarSize > 0)
            {
                _graphics.FillRoundedRectangle(_LeftAndRightBrush, this.GetRightArea(), this.RoundedCornerAngle, RectangleEdgeFilter.TopRight | RectangleEdgeFilter.BottomRight);
                _graphics.DrawString(this.RightText, this.Font, Brushes.White, this.GetRightArea(), f);
            }

            // Clean up
            _LeftAndRightBrush.Dispose();
            _MainBrush.Dispose();
            _StatusBrush.Dispose();
        }

        private Rectangle GetLeftArea()
        {
            return new Rectangle(
                Padding.Left,
                Padding.Top, 
                LeftBarSize,
                this.ClientRectangle.Height - Padding.Bottom - Padding.Top);
        }

        private Rectangle GetStatusArea()
        {
            return new Rectangle(
                Padding.Left + LeftBarSize,
                Padding.Top,
                StatusBarSize,
                this.ClientRectangle.Height - Padding.Bottom - Padding.Top);
        }

        private Rectangle GetMainArea()
        {
            return new Rectangle(
                Padding.Left + LeftBarSize + StatusBarSize,
                Padding.Top,
                Convert.ToInt32(((this.ClientRectangle.Width - (Padding.Left + LeftBarSize + StatusBarSize + RightBarSize + Padding.Right)) * FillDegree) / 100),
                this.ClientRectangle.Height - Padding.Bottom - Padding.Top);
        }

        private Rectangle GetMainAreaEx()
        {
            if (this.Parent.Tag.GetType() ==  typeof (int))
            {
                if ((int)this.Parent.Tag==1)
                {
                    return new Rectangle(
                        Padding.Left + LeftBarSize + StatusBarSize,
                        Padding.Top,
                        Convert.ToInt32(((this.ClientRectangle.Width - (Padding.Left + LeftBarSize + StatusBarSize + RightBarSize + Padding.Right)))),
                        30 /*this.ClientRectangle.Height - Padding.Bottom - Padding.Top*/);
                }
            }
            return new Rectangle(
                Padding.Left + LeftBarSize + StatusBarSize,
                Padding.Top,
                Convert.ToInt32(((this.ClientRectangle.Width - (Padding.Left + LeftBarSize + StatusBarSize + RightBarSize + Padding.Right)))),
                this.ClientRectangle.Height - Padding.Bottom - Padding.Top);

        }

        private Rectangle GetMainAreaBackground()
        {
            return new Rectangle(
                   Padding.Left + LeftBarSize + StatusBarSize,
                   Padding.Top,
                   this.ClientRectangle.Width - (Padding.Left + LeftBarSize + StatusBarSize + RightBarSize + Padding.Right),
                   this.ClientRectangle.Height - Padding.Bottom - Padding.Top);
        }

        private Rectangle GetRightArea()
        {
            return new Rectangle(
                this.ClientRectangle.Width - (RightBarSize + Padding.Right),
                Padding.Top, 
                RightBarSize,
                this.ClientRectangle.Height - Padding.Bottom - Padding.Top);
        }
    }
}
