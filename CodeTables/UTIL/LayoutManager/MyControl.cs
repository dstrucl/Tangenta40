using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Collections;
using BrightIdeasSoftware;
using UniqueControlNames;

namespace LayoutManager
{
    public partial class MyControl : IEquatable<MyControl>
    {
        internal List<MyControl> children = new List<MyControl>();

        internal List<MyControl> Link = null;

        //internal Form_HUDCMS xfrm_HUDCMS = null;
        internal Form_Layout xfrm_Layout = null;

        //internal HelpWizzardTag HlpWizTag = null;

        internal XElement xel = null;
        internal XElement xdiv_Title = null;
        internal XElement xdiv_About = null;
        internal XElement xdiv_Description = null;
        internal XElement ximg = null;
        internal XElement xTitle_Heading = null;
        internal XElement xAbout = null;
        internal XElement xDescription = null;
        internal ImageRenderer helperImageRenderer = null;

        internal string[] sLink = null;

        private bool m_ImageIncluded = true;

        public bool ImageIncluded
        {
            get { return m_ImageIncluded; }
            set { m_ImageIncluded = value; }
        }

        internal Image ImageOfControl = null;
        internal MyControl Parent = null;

        internal int GetOfsX()
        {
            int ofsx = 0;
            MyControl prev = this.Parent;
            while (prev !=null)
            {
                ofsx += prev.Left;
                prev = prev.Parent;
            }
            return ofsx;
        }

        internal int GetOfsY()
        {
            int ofsy = 0;
            MyControl prev = this.Parent;
            while (prev != null)
            {
                ofsy += prev.Top;
                prev = prev.Parent;
            }
            return ofsy;
        }

        private string m_HelpTitle = "";

        string m_ControlName = null;

        public string ControlName
        {
            get { return m_ControlName; }
            set { m_ControlName = value; }
        }

        public bool HasChildren
        {
            get
            {
                return children.Count > 0;
            }

        }

        //string m_ControlName = null;
        public string ControlUniqueName
        {
            get { return GetControlUniqueName(); }
        }

        public string ControlType
        {
            get { return GetControlType(); }
        }

      

        public int ControlImage
        {
            get
            {
                if (this.helperImageRenderer != null)
                {
                    return this.helperImageRenderer.ImageList.Images.IndexOfKey(ControlUniqueName);
                }
                else
                {
                    return -1;
                }
            }
        }

        public string ControlLink
        {
            get {
                if (HasLink)
                {
                    return "Yes";
                }
                else
                {
                    return "No";
                }
            }
        }


        public string HelpTitle
        {
            get { return m_HelpTitle; }
            set { m_HelpTitle = value; }
        }

        private int left = 0;
        public int Left
        {
            get { return left; }
            set { left = value; }
        }

        private int right = 0;
        public int Right
        {
            get { return right; }
            set { right = value; }
        }

        private int top = 0;
        public int Top
        {
            get { return top; }
            set { top = value; }
        }

        private int width = 0;
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        private int height = 0;
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        private bool anchorleft = false;
        public bool AnchorLeft
        {
            get { return anchorleft; }
            set { anchorleft = value; }
        }

        private bool anchorright = false;
        public bool AnchorRight
        {
            get { return anchorright; }
            set { anchorright = value; }
        }

        private bool anchortop = false;
        public bool AnchorTop
        {
            get { return anchortop; }
            set { anchortop = value; }
        }

        private bool anchorbottom = false;
        public bool AnchorBottom
        {
            get { return anchorbottom; }
            set { anchorbottom = value; }
        }

        private Color forecolor = Color.White;
        public Color ForeColor
        {
            get { return forecolor; }
            set { forecolor = value; }
        }

        private Color backcolor = Color.Gray;
        public Color BackColor
        {
            get { return backcolor; }
            set { backcolor = value; }
        }


        private string m_ID = "";

        internal string ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }

        private string m_HeadingTag = "h1";

        internal string HeadingTag
        {
            get { return m_HeadingTag; }
            set { m_HeadingTag = value; }
        }

        private string m_About = "";

        internal string About
        {
            get { return m_About; }
            set { m_About = value; }
        }

        private string m_ImageCaption = "";

        internal string ImageCaption
        {
            get { return m_ImageCaption; }
            set { m_ImageCaption = value; }
        }

        private string m_Description = "";

        internal string Description
        {
            get { return m_Description; }
            set { m_Description = value; }
        }


        internal hctrl hc = null;
        //internal usrc_Help uH = null;

        private bool m_bLink = false;
        internal bool bLinked
        {
            get
            {
                return m_bLink;
            }
            set
            {
                m_bLink = value;
                //if (m_bLink)
                //{
                //    btn_Link.Image = Properties.Resources.Link;
                //    btn_Link.Text = "Remove Link";
                //    btn_Link.Visible = true;
                //}
                //else
                //{
                //    btn_Link.Image = Properties.Resources.NoLink;
                //    btn_Link.Text = "Add Link";
                //}
            }
        }

        private int m_SnapShotMargin = 4;
        internal int SnapShotMargin
        {
            get
            {
                //if (xfrm_HUDCMS.usrc_EditControl1.m_usrc_Control == this)
                //{
                //    m_SnapShotMargin = xfrm_HUDCMS.usrc_EditControl1.SnapShotMargin;
                //}
                return m_SnapShotMargin;
            }
            set
            {
                m_SnapShotMargin = value;
            }
        }

        public string ImageSource
        {
            get
            {
                string sPictureFileName = this.ControlUniqueName;
                sPictureFileName = sPictureFileName.Replace('.', '_');
                sPictureFileName = sPictureFileName.Replace('[', '_');
                sPictureFileName = sPictureFileName.Replace(']', '_') + ".png"; ;
                return sPictureFileName;
            }
        }

       

        public string GetControlUniqueName()
        {
                return hc.GetName();
        }

        public string GetControlType()
        {
            if (hc.ctrl != null)
            {
                return hc.ctrl.GetType().ToString();
            }
            else if (hc.pForm != null)
            {
                return hc.pForm.GetType().ToString();
            }
            else if (hc.dgvc != null)
            {
                return hc.dgvc.GetType().ToString();
            }
            else
            {
                return "UNKNOWN";
            }
        }

        private int m_MaxPanelHeight = 400;
        public int MaxPanelHeight
        {
            get { return m_MaxPanelHeight; }
            set { m_MaxPanelHeight = value; }
        }

        private int m_MinPanelHeight = 80;
        public int MinPanelHeight
        {
            get { return m_MinPanelHeight; }
            set { m_MinPanelHeight = value; }
        }


        private int m_MaxPanelWidth = 400;
        public int MaxPanelWidth
        {
            get { return m_MaxPanelWidth; }
            set { m_MaxPanelWidth = value; }
        }

        public bool HasLink
        {
            get
            {
                if (sLink != null)
                {
                    return (sLink.Count() > 0);

                }
                else
                {
                    return false;
                }
            }
        }

        public bool HasTitle
        {
            get
            {
                if (m_HelpTitle != null)
                {
                    return (m_HelpTitle.Length > 0);
                }
                else
                {
                    return false;
                }
            }
        }

        internal void CreateTable(DataTable dt)
        {
            DataRow dr = dt.NewRow();
            dr[Form_Layout.dcol_ControlName] = this.ControlUniqueName;
            dr[Form_Layout.dcol_Left] = this.Left;
            dr[Form_Layout.dcol_Top] = this.Top;
            dr[Form_Layout.dcol_Width] = this.Width;
            dr[Form_Layout.dcol_Height] = this.Height;
            dr[Form_Layout.dcol_AnchorLeft] = this.AnchorLeft;
            dr[Form_Layout.dcol_AnchorRight] = this.AnchorRight;
            dr[Form_Layout.dcol_AnchorTop] = this.AnchorTop;
            dr[Form_Layout.dcol_AnchorBottom] = this.AnchorBottom;
            dr[Form_Layout.dcol_ForeColor] = this.ForeColor.ToArgb();
            dr[Form_Layout.dcol_BackColor] = this.BackColor.ToArgb();
            dt.Rows.Add(dr);
            foreach (MyControl c in this.children)
            {
                c.CreateTable(dt);
            }
        }

        

        
        
        public MyControl()
        {
        }

   
        internal void Init(/*HelpWizzardTag xHlpWizTag, usrc_Help xuH,*/ hctrl xhc, int iLevel, MyControl parent, ref SysImageListHelper helperControlType)
        {
           
            hc = xhc;
            this.Parent = parent;
            if (hc.ctrl != null)
            {
                this.ControlName =hc.ctrl.Name;
            }
            else if (hc.dgvc != null)
            {
                this.ControlName = "dgvc__" + hc.dgvc.Name;
                this.m_ImageIncluded = false;
            }
            string sText = "";
            string sControl = HUDCMS_static.slng_UserControlName;
            if (helperControlType != null)
            {
                helperControlType.AddImageToCollection(GetControlType(), helperControlType.SmallImageList, GetControlTypeImage());
            }

            if (hc.pForm !=null)
            {
                sControl = "Form";
                this.ControlName = hc.pForm.Name;
            }
            else if (hc.ctrl is Form)
            {
                sControl = "Form";
                this.ControlName = hc.ctrl.Name;
            }
            else if (xhc.ctrl is UserControl)
            {
            }
            else
            {
                if (xhc.ctrl != null)
                {
                    sControl = "Control";
                    //                    this.txt_Control.ForeColor = Color.Black;
                    if (xhc.ctrl is Button)
                    {
                        sText = "  TEXT:\"" + ((Button)xhc.ctrl).Text + "\"";
                    }
                    else if (xhc.ctrl is GroupBox)
                    {
                        sText = "  TEXT:\"" + ((GroupBox)xhc.ctrl).Text + "\"";
                    }
                    else if (xhc.ctrl is Label)
                    {
                        sText = "  TEXT:\"" + ((Label)xhc.ctrl).Text + "\""; 
                    }
                }
                else if (xhc.dgvc != null)
                {
                    sControl = "DataGridViewColumn";
                    sText = "  TEXT:\"" + xhc.dgvc.HeaderText + "\""; 
                }

            }


            if (xhc.ctrl == null)
            {
                if (xhc.pForm != null)
                {
                    //                    this.txt_Control.Text = sControl + "=" + xhc.pForm.Name + "  Type:" + xhc.pForm.GetType().ToString() + sText;
                }
                else if (xhc.dgvc != null)
                {
                    this.m_ImageIncluded = false;
                    //                    this.txt_Control.Text = sControl + "=" + xhc.dgvc.Name + "  Type:" + xhc.dgvc.GetType().ToString() + sText;
                }
                else 
                {
                    MessageBox.Show("ERROR:HUDCMS:usrc_Control:(xhc.ctrl == null)&&(xhc.pForm != null)!");
                }
            }
            else
            {
            }


               

                
                if (hc.ctrl != null)
                {

                    SetControlProperties(hc.ctrl);
                }
                else if (hc.dgvc != null)
                {
                    HelpTitle = hc.dgvc.HeaderText;
                }


            //if (ID.Length == 0)
            //{
            //    //Guid id = Guid.NewGuid();
            //    ID = SetID();
            //}

        }

        internal void SetLayout(DataTable dtCtrlLayout)
        {
            if (!(this.ControlUniqueName.ToUpper().Contains("UNKNOWN")) || (this.ControlUniqueName.ToUpper().Contains("NONAME")))
            {
                DataRow dr = findrow(dtCtrlLayout, this.ControlUniqueName);
                if (this.ControlUniqueName.Equals("Form_Document.usrc_DocumentMan1366x768.btn_Exit")) 
                {

                }
                if (dr != null)
                {
                    if (this.hc.ctrl != null)
                    {
                        this.hc.ctrl.Left = (int)dr["Left"];
                        this.hc.ctrl.Top = (int)dr["Top"];
                        this.hc.ctrl.Width = (int)dr["Width"];
                        this.hc.ctrl.Height = (int)dr["Height"];
                        this.hc.ctrl.ForeColor = Color.FromArgb((int)dr["ForeColor"]);
                        this.hc.ctrl.BackColor = Color.FromArgb((int)dr["BackColor"]);
                        this.hc.ctrl.Refresh();
                    }
                }
            }

            foreach (MyControl c in this.children)
            {
                c.SetLayout(dtCtrlLayout);
            }
        }

        private DataRow findrow(DataTable dtCtrlLayout, string controlUniqueName)
        {
            foreach (DataRow dr in dtCtrlLayout.Rows)
            {
                if (((string)dr["ControlName"]).Equals(controlUniqueName))
                {
                    return dr;
                }
            }
            return null;
        }

        public void SetControlProperties(Control ctrlx)
        {
            left = ctrlx.Left;
            top = ctrlx.Top;
            width = ctrlx.Width;
            height = ctrlx.Height;

            anchorleft = false;
            if ((ctrlx.Anchor & AnchorStyles.Left) != 0)
            {
                anchorleft = true;
            }

            anchorright = false;
            if ((ctrlx.Anchor & AnchorStyles.Right) != 0)
            {
                anchorright = true;
            }

            anchortop = false;
            if ((ctrlx.Anchor & AnchorStyles.Top) != 0)
            {
                anchortop = true;
            }

            anchorbottom = false;
            if ((ctrlx.Anchor & AnchorStyles.Bottom) != 0)
            {
                anchorbottom = true;
            }

            forecolor = ctrlx.ForeColor;
            backcolor = ctrlx.BackColor;
        }

       

        private MyControl GetMatchingControl(MyControl xmyControl)
        {
            string thisControlUniqueName = this.GetControlUniqueName();
            string xmyControlUniqueName = xmyControl.GetControlUniqueName();
            if (thisControlUniqueName.Equals(xmyControlUniqueName))
            {
                return this;
            }
            else
            {
                foreach (MyControl mc in this.children)
                {
                    MyControl mctrl = mc.GetMatchingControl(xmyControl);
                    if (mctrl!=null)
                    {
                        return mctrl;
                    }
                }
                return null;
            }
        }

        private bool ParentIs_usrc_myGroupBox(Control ctrl)
        {
            if (ctrl.Parent!=null)
            {
                if (ctrl.Parent.GetType().ToString().Contains("usrc_myGroupBox"))
                {
                    return true;
                }
            }
            return false;
        }

      

        private Image GetControlTypeImage()
        {
            if (hc.ctrl != null)
            {
                if (hc.ctrl is Label)
                {
                    return Properties.Resources.ctrl_Label;
                }
                else if (hc.ctrl is Button)
                {
                    return Properties.Resources.ctrl_Button;
                }
                else if (hc.ctrl is RadioButton)
                {
                    return Properties.Resources.ctrl_RadioButton;
                }
                else if (hc.ctrl is CheckBox)
                {
                    return Properties.Resources.ctrl_CheckBox;
                }
                else if (hc.ctrl is ComboBox)
                {
                    return Properties.Resources.ctrl_ComboBox;
                }
                else if (hc.ctrl is CheckedListBox)
                {
                    return Properties.Resources.ctrl_CheckedListBox;
                }
                else if (hc.ctrl is DataGridView)
                {
                    return Properties.Resources.ctrl_DataGridView;
                }
                else if (hc.ctrl is NumericUpDown)
                {
                    return Properties.Resources.ctrl_NumericUpDown;
                }
                else if (hc.ctrl is TextBox)
                {
                    return Properties.Resources.ctrl_Text;
                }
                else if (hc.ctrl is RichTextBox)
                {
                    return Properties.Resources.ctrl_RichTextBox;
                }
                else if (hc.ctrl is SplitContainer)
                {
                    return Properties.Resources.ctrl_SplitContainer;
                }
                else if (hc.ctrl is Panel)
                {
                    return Properties.Resources.ctrl_Panel;
                }
                else if (hc.ctrl is GroupBox)
                {
                    return Properties.Resources.ctrl_GroupBox;
                }
                else
                {
                    return Properties.Resources.ctrl_UserControl;
                }
            }
            else if (hc.pForm != null)
            {
                return Properties.Resources.ctrl_Form;
            }
            else if (hc.dgvc != null)
            {
                return Properties.Resources.ctrl_DataGridViewColumn;
            }
            else
            {
                return Properties.Resources.ctrl_UserControl; 
            }
        }

        private void Set_ID(XAttribute xAttribute)
        {
            if (xAttribute != null)
            {
                ID = xAttribute.Value;
                if (ID.Length >= 32)
                {
                    ID = SetID();
                }
            }
            else
            {
                //ID = Guid.NewGuid().ToString();
                ID = SetID();
            }
        }

        private string SetID()
        {
            string sid = BookmarkDic.GetBookmark(GetControlUniqueName());
            sid = sid.Replace("#", "");
            return sid;
        }

        internal static bool Find_my_Control(MyControl ctrl, string slnk, ref MyControl my_Control_found)
        {
            if (ctrl != null)
            {
                string sControlName = ctrl.ControlUniqueName;
                if (sControlName.Equals(slnk))
                {
                    my_Control_found = ctrl;
                    return true;
                }
                foreach (MyControl c in ctrl.children)
                {
                    if (Find_my_Control(c, slnk, ref my_Control_found))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

       

      
       



        

        private void GetParentSnapshotArea(ref Rectangle snap_rect, MyControl myControl, List<MyControl> link)
        {
            int xLeft = GetLeftMost(myControl, link)- SnapShotMargin;
            if (xLeft<0)
            {
                xLeft = 0;
            }
            int yTop = GetTopMost(myControl, link)-SnapShotMargin;
            if (yTop<0)
            {
                yTop = 0;
            }
            int xRight = GetRightMost(myControl, link) + SnapShotMargin; 
            int yBottom = GetBottomMost(myControl, link) + SnapShotMargin; 
            snap_rect = new Rectangle(xLeft, yTop, xRight - xLeft, yBottom - yTop);
        }

        private int GetBottomMost(List<MyControl> link)
        {
            bool bDefined = false;
            int bottom = -1;

            foreach (MyControl c in link)
            {
                if (!bDefined)
                {
                    bottom = c.hc.Bottom;
                    bDefined = true;
                }
                else
                {
                    if (c.hc.Bottom > bottom)
                    {
                        bottom = c.hc.Bottom;
                    }
                }
            }
            return bottom;
        }

        private bool LinkExist(List<MyControl> link)
        {
            if (link!=null)
            {
                return link.Count > 0;
            }
            return  false;
        }

        private int GetBottomMost(MyControl xusrc_Control, List<MyControl> link)
        {
            if (LinkExist(link))
            {
                int bottom_most_in_Link = GetBottomMost(link);
                if (xusrc_Control.hc.Bottom > bottom_most_in_Link)
                {
                    return xusrc_Control.hc.Bottom;
                }
                else
                {
                    return bottom_most_in_Link;
                }
            }
            else
            {
                return xusrc_Control.hc.Bottom;
            }
        }

        private int GetRightMost(List<MyControl> link)
        {
            bool bDefined = false;
            int right = -1;
            foreach (MyControl c in link)
            {
                if (!bDefined)
                {
                    right = c.hc.Right;
                    bDefined = true;
                }
                else
                {
                    if (c.hc.Right > Right)
                    {
                        right = c.hc.Right;
                    }
                }
            }
            return right;
        }

        private int GetRightMost(MyControl xusrc_Control, List<MyControl> link)
        {
            if (LinkExist(link))
            {
                int right_most_in_Link = GetRightMost(link);
                if (xusrc_Control.hc.Right > right_most_in_Link)
                {
                    return xusrc_Control.hc.Right;
                }
                else
                {
                    return right_most_in_Link;
                }
            }
            else
            {
                return xusrc_Control.hc.Right;
            }
        }

        private int GetTopMost(List<MyControl> link)
        {
            bool bDefined = false;
            int top = -1;
            foreach (MyControl c in link)
            {
                if (!bDefined)
                {
                    top = c.hc.Top;
                    bDefined = true;
                }
                else
                {
                    if (c.hc.Top < top)
                    {
                        top = c.hc.Top;
                    }
                }
            }
            return top;
        }

        private int GetTopMost(MyControl xusrc_Control, List<MyControl> link)
        {
            if (LinkExist(link))
            {
                int top_most_in_Link = GetRightMost(link);
                if (xusrc_Control.hc.Top < top_most_in_Link)
                {
                    return xusrc_Control.hc.Top;
                }
                else
                {
                    return top_most_in_Link;
                }
            }
            else
            {
                return xusrc_Control.hc.Top;
            }
        }

        private int GetLeftMost(List<MyControl> link)
        {
            bool bDefined = false;
            int left = -1;
            foreach (MyControl c in link)
            {
                if (!bDefined)
                {
                    left = c.hc.Left;
                    bDefined = true;
                }
                else
                {
                    if (c.hc.Left < left)
                    {
                        left = c.hc.Left;
                    }
                }
            }
            return left;
        }

        private int GetLeftMost(MyControl xusrc_Control, List<MyControl> link)
        {
            if (LinkExist(link))
            {
                int left_most_in_Link = GetLeftMost(link);
                if (xusrc_Control.hc.Left < left_most_in_Link)
                {
                    return xusrc_Control.hc.Left;
                }
                else
                {
                    return left_most_in_Link;
                }
            }
            else
            {
                return xusrc_Control.hc.Left;
            }
        }

        private void AddLink(List<MyControl> link, MyControl xusrc_Control, MyControl xusrc_Control_Selected)
        {
            if (link!=null)
            {
                foreach (MyControl c in link)
                {
                    if (c== xusrc_Control)
                    {
                        //allready added
                        MessageBox.Show("Link allready added!");
                        return;
                    }
                }
                link.Add(xusrc_Control);
            }
        }



        public IEnumerable GetChildren()
        {
            return children;
        }
        // Two file system objects are equal if they point to the same file system path

        public bool Equals(MyControl other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.ControlUniqueName, this.ControlUniqueName);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(MyControl)) return false;
            return Equals((MyControl)obj);
        }
        public override int GetHashCode()
        {
            return (this.ControlUniqueName != null ? this.ControlUniqueName.GetHashCode() : 0);
        }
        public static bool operator ==(MyControl left, MyControl right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(MyControl left, MyControl right)
        {
            return !Equals(left, right);
        }
    }
}
