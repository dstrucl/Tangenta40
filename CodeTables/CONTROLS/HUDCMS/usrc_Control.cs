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

namespace HUDCMS
{
    public partial class usrc_Control : UserControl
    {

        internal XElement xel = null;
        internal XElement xdiv_Title = null;
        internal XElement xdiv_About = null;
        internal XElement xdiv_Description = null;
        internal XElement ximg = null;
        internal XElement xTitle_Heading = null;
        internal XElement xAbout = null;
        internal XElement xDescription = null;

        private string m_Title = "";

        internal string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
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

        internal List<usrc_Control> AvailableLink = null;
        internal List<usrc_Control> Link = null;

        internal hctrl hc = null;
        internal usrc_Help uH = null;

        private bool bLink = false;

        internal int SnapShotMargin
        {
            get
            {
                if (uH.hlp_dlg.usrc_web_Help1.frm_HUDCMS.usrc_EditControl1.m_usrc_Control==this)
                {
                    return uH.hlp_dlg.usrc_web_Help1.frm_HUDCMS.usrc_EditControl1.SnapShotMargin;
                }
                return 0;
            }
        }

        public string ImageSource
        {
            get
            {
                string sPictureFileName = this.txt_ControlName.Text;
                sPictureFileName = sPictureFileName.Replace('.', '_');
                sPictureFileName = sPictureFileName.Replace('[', '_');
                sPictureFileName = sPictureFileName.Replace(']', '_') + ".png"; ;
                return sPictureFileName;
            }
        }

        public int ImageWidth
        {
            get
            {

                string Err = null;
                try
                {
                    return this.pic_Control.Image.Width;
                }
                catch (Exception ex)
                {
                    Err = ex.Message;
                    return 0;
                }
            }
        }

        public int ImageHeight
        {
            get
            {

                string Err = null;
                try
                {
                    return this.pic_Control.Image.Height;
                }
                catch (Exception ex)
                {
                    Err = ex.Message;
                    return 0;
                }
            }
        }

        public string ControlName
        {
            get { return hc.GetName(); }
        }

        private int m_MaxPanelHeight = 400;
        public int MaxPanelHeight
        {
            get { return m_MaxPanelHeight; }
            set { m_MaxPanelHeight = value; }
        }

        private int m_MaxPanelWidth = 400;
        public int MaxPanelWidth
        {
            get { return m_MaxPanelWidth; }
            set { m_MaxPanelWidth = value; }
        }

        internal void CreateNode(XDocument xh,ref XElement xn)
        {

            xel = new XElement("TControl");
            XAttribute attribute = new XAttribute("name", ControlName);
            xel.Add(attribute);
            if (Title.Length > 0)
            {
                xdiv_Title = new XElement("div");
                XAttribute xdiv_Title_class = new XAttribute("class", "Title");
                xdiv_Title.Add(xdiv_Title_class);
                string html_Heading = "h1";
                if (hc.ctrl!=null)
                {
                    html_Heading = "h2";
                }
                xTitle_Heading = new XElement(html_Heading);
                XAttribute xdiv_Title_Heading_class = new XAttribute("class", "Title");
                xTitle_Heading.Add(xdiv_Title_Heading_class);
                xTitle_Heading.Value = Title;

                xdiv_Title.Add(xTitle_Heading);

                if (About.Length > 0)
                {
                    xdiv_About = new XElement("div");
                    XAttribute xdiv_About_class = new XAttribute("class", "About");
                    xdiv_About.Add(xdiv_About_class);
                    xdiv_About.Value = About;
                    xdiv_Title.Add(xdiv_About);
                }

                ximg = new XElement("img");
                XAttribute img_src = new XAttribute("src", ImageSource);
                XAttribute img_width = new XAttribute("width", ImageWidth.ToString());
                XAttribute img_height = new XAttribute("height", ImageHeight.ToString());
                ximg.Add(img_src);
                ximg.Add(img_width);
                ximg.Add(img_height);
                xdiv_Title.Add(ximg);

                if (Description.Length > 0)
                {
                    xdiv_Description = new XElement("div");
                    XAttribute xdiv_Description_class = new XAttribute("class", "Description");
                    xdiv_Description.Add(xdiv_Description_class);
                    xdiv_Description.Value = Description;
                    xdiv_Title.Add(xdiv_Description);
                }

                xel.Add(xdiv_Title);

                string Err = null;
                try
                {
                    string ximage_path = Path.GetDirectoryName(uH.sLocalHtmlFile);
                    if (ximage_path != null)
                    {
                        if (ximage_path.Length > 0)
                        {
                            if (ximage_path[ximage_path.Length - 1] != '\\')
                            {
                                ximage_path += '\\';
                            }
                        }
                    }

                    string ximage_file = ximage_path + ImageSource;
                    this.pic_Control.Image.Save(ximage_file, ImageFormat.Png);
                }
                catch (Exception ex)
                {
                    Err = ex.Message;
                    MessageBox.Show("ERROR:Can not save:\"" + ImageSource + "\"" + Err);
                }
            }
            foreach (Control c in this.Controls)
            {
                if (c is usrc_Control)
                {
                    ((usrc_Control)c).CreateNode(xh,ref xel);
                }
            }
            xn.Add(xel);

        }

        public usrc_Control()
        {
            InitializeComponent();
           
        }

        private void Set_pic_Control()
        {
            this.pic_Control.Image = hc.ctrlbmp;
            this.pic_Control.SizeMode = PictureBoxSizeMode.Zoom;
            this.pic_Control.Width = hc.ctrlbmp.Width;
            if (this.pic_Control.Width > MaxPanelWidth)
            {
                this.pic_Control.Width = MaxPanelWidth - 60;
                this.pic_Control.Height = hc.ctrlbmp.Height * this.pic_Control.Width / hc.ctrlbmp.Width + 4;
            }
            else
            {
                this.pic_Control.Height = hc.ctrlbmp.Height;
            }
            this.lbl_LinkedControls.Left = this.pic_Control.Right + 4;
            this.list_Link.Left = this.pic_Control.Right + 4;
        }

        internal void Init(usrc_Help xuH, hctrl xhc)
        {
            uH = xuH;
            hc = xhc;
            string sText = "";
            string sControl = HUDCMS_static.slng_UserControlName;
            if (xhc.ctrl is Form)
            {
                sControl = "Form";
                this.txt_Control.ForeColor = Color.DarkGreen;
            }
            else if (xhc.ctrl is UserControl)
            {
                this.txt_Control.ForeColor = Color.DarkBlue;
            }
            else
            {
                sControl = "Control";
                this.txt_Control.ForeColor = Color.Black;
                if (xhc.ctrl is Button)
                {
                    sText = "  TEXT:\"" + ((Button)xhc.ctrl).Text + "\"";
                }
                else if (xhc.ctrl is GroupBox)
                {
                    sText = "  TEXT:\"" + ((GroupBox)xhc.ctrl).Text + "\""; ;
                }
                else if (xhc.ctrl is Label)
                {
                    sText = "  TEXT:\"" + ((Label)xhc.ctrl).Text + "\""; ;
                }
            }


            if (xhc.ctrl == null)
            {
                if (xhc.pForm != null)
                {
                    this.txt_Control.Text = sControl + "=" + xhc.pForm.Name + "  Type:" + xhc.pForm.GetType().ToString() + sText;
                }
                else
                {
                    MessageBox.Show("ERROR:HUDCMS:usrc_Control:(xhc.ctrl == null)&&(xhc.pForm != null)!");
                }
            }
            else
            {
                this.txt_Control.Text = sControl + "=" + xhc.ctrl.Name + "  Type:" + xhc.ctrl.GetType().ToString() + sText;
            }

            txt_ControlName.Text = hc.GetName();

            if (hc.ctrlbmp != null)
            {
                Set_pic_Control();


                string path = Path.GetDirectoryName(uH.sLocalHtmlFile);
       
                this.panel1.Height = this.pic_Control.Bottom + 4;
                if (this.panel1.Height>MaxPanelHeight)
                {
                    this.panel1.Height = MaxPanelHeight;
                }
                this.Height = this.panel1.Bottom + 4;
             
            }
            else
            {
               
            }
            this.list_Link.Visible = false;
            
            this.list_Link.DataSource = null;
            if (this.Link!=null)
            {
                if (this.Link.Count>0)
                {
                    this.list_Link.Visible = true;
                    this.list_Link.DataSource = Link;
                    this.list_Link.DisplayMember = "ControlName";
                    this.list_Link.ValueMember = "ControlName";
                }
            }
            this.lbl_LinkedControls.Visible = this.list_Link.Visible;

            if (uH.hlp_dlg.usrc_web_Help1.frm_HUDCMS.xhtml_Loaded != null)
            {
                XDocument doc = uH.hlp_dlg.usrc_web_Help1.frm_HUDCMS.xhtml_Loaded;
                XElement xel = null;
                if (FindXElement(doc, ref xel, "TControl", "name", ControlName))
                {
                    XElement xel_Title = null;
                    if (FindXElement(xel, ref xel_Title, "div", "class", "Title"))
                    {
                        XElement xel_Title_Header = null;
                        if (FindXElement(xel_Title, ref xel_Title_Header, "h1", "class", "Title"))
                        {
                                Title = xel_Title_Header.Value;
                        }
                        else if (FindXElement(xel_Title, ref xel_Title_Header, "h2", "class", "Title"))
                        {
                            Title = xel_Title_Header.Value;
                        }
                        XElement xel_About = null;
                        if (FindXElement(xel_Title, ref xel_About, "div", "class", "About"))
                        {
                            About = xel_About.Value;
                        }
                        XElement xel_Description = null;
                        if (FindXElement(xel_Title, ref xel_Description, "div", "class", "Description"))
                        {
                            About = xel_Description.Value;
                        }
                    }
               
                }
            }

            if (this.Title.Length > 0)
            {
                this.BackColor = Color.LightYellow;
            }
            else
            {
                this.BackColor = uH.hlp_dlg.usrc_web_Help1.frm_HUDCMS.BackColor;
            }
            this.Refresh();
        }

        internal bool FindXElement(XDocument doc,ref XElement element, string element_name, string AttributeName, string AttributeValue)
        {
            element = null;

            //IEnumerable<System.Xml.Linq.XElement> qElements = from e in doc.Elements()
            //                                                  where e.Attribute(AttributeName).Value == AttributeValue
            //                                                  select e;
            IEnumerable<System.Xml.Linq.XElement> qElements = from c in doc.Descendants(element_name)
                                                              where c.Attribute(AttributeName).Value == AttributeValue
                                                              select c;

            if (qElements != null)
            {
                if (qElements.Count() > 0)
                {
                    if (qElements.Count() == 1)
                    {
                        element = qElements.ElementAt(0);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("WARNING multiple TControl elements found where name = \"" + ControlName + "\"");
                    }
                }

            }
            return false;
        }

        internal bool FindXElement(XElement el, ref XElement element,string element_name,string AttributeName,string AttributeValue)
        {
            element = null;
            try
            {
             
                IEnumerable<System.Xml.Linq.XElement> qElements = from c in el.Descendants(element_name)
                                                                  where c.Attribute(AttributeName).Value == AttributeValue
                                                                  select c;


                if (qElements != null)
                {
                    if (qElements.Count() > 0)
                    {
                        XElement xelement = qElements.ElementAt(0);
                        if ( xelement.Parent == el)
                        {
                            element = xelement;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        
                        //if (qElements.Count() == 1)
                        //{
                        //}
                        //else
                        //{
                        //    //MessageBox.Show("WARNING multiple TControl elements found where name = \"" + ControlName + "\"");
                        //}
                    }

                }
            }
            catch (Exception ex)
            {

            }

            return false;
        }

            private void pic_Control_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonGlobal1_CheckChanged()
        {
            if (radioButtonGlobal1.Checked)
            {
                this.BackColor = radioButtonGlobal1.HighlightBackColor;
                uH.hlp_dlg.usrc_web_Help1.frm_HUDCMS.usrc_EditControl1.Init(this);
                uH.hlp_dlg.usrc_web_Help1.frm_HUDCMS.usrc_Control_Selected = this;
                uH.hlp_dlg.usrc_web_Help1.frm_HUDCMS.HideLinks();
                uH.hlp_dlg.usrc_web_Help1.frm_HUDCMS.ShowAvailableLinks();
            }
        }

        private void radioButtonGlobal1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Link_Click(object sender, EventArgs e)
        {
            //Link Form_HUDCMS.usrc_Control_Selected with this !
            if (uH.hlp_dlg.usrc_web_Help1.frm_HUDCMS.usrc_Control_Selected != null)
            {
                if (bLink)
                {
                    usrc_Control Control_Selected = uH.hlp_dlg.usrc_web_Help1.frm_HUDCMS.usrc_Control_Selected;
                    if (Control_Selected.Link == null)
                    {
                        Control_Selected.Link = new List<usrc_Control>();
                    }
                    RemoveLink(Control_Selected.Link, this, Control_Selected);
                    Control_Selected.CreateImageOfLinkedControls();
                    btn_Link.Image = Properties.Resources.NoLink;
                    btn_Link.Text = "Add Link";
                    bLink = false;
                }
                else
                {
                    usrc_Control Control_Selected = uH.hlp_dlg.usrc_web_Help1.frm_HUDCMS.usrc_Control_Selected;
                    if (Control_Selected.Link == null)
                    {
                        Control_Selected.Link = new List<usrc_Control>();
                    }
                    AddLink(Control_Selected.Link, this, Control_Selected);
                    Control_Selected.CreateImageOfLinkedControls();
                    btn_Link.Image = Properties.Resources.Link;
                    btn_Link.Text = "Remove Link";
                    bLink = true;
                }
            }
        }

        private bool HasLinksToOtherControls()
        {
            if (this.Link != null)
            {
                if (this.Link.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }
        private void CreateImageOfLinkedControls()
        {
            this.list_Link.Visible = false;
            this.list_Link.DataSource = null;
            if (this.Parent != null)
            {
                if (this.Parent is usrc_Control)
                {
                    if (LinkExist(this.Link))
                    {
                        this.list_Link.Visible = true;
                        this.lbl_LinkedControls.Visible = true;
                        this.list_Link.DataSource = Link;
                        this.list_Link.DisplayMember = "ControlName";
                        this.list_Link.ValueMember = "ControlName";
                    }
                    else
                    {
                        this.list_Link.Visible = false;
                        this.lbl_LinkedControls.Visible = false;
                        this.list_Link.DataSource = null;
                    }
                    Rectangle snap_rect = new Rectangle();
                    GetParentSnapshotArea(ref snap_rect, this, this.Link);

                    if (((usrc_Control)this.Parent).hc.ctrlbmp != null)
                    {
                        Bitmap myBitmap = new Bitmap(((usrc_Control)this.Parent).hc.ctrlbmp);
                        System.Drawing.Imaging.PixelFormat format =
                            myBitmap.PixelFormat;
                        Bitmap cloneBitmap = myBitmap.Clone(snap_rect, format);


                        if (this.hc.ctrlbmp != null)
                        {
                            this.hc.ctrlbmp.Dispose();
                            this.hc.ctrlbmp = null;
                        }
                        this.hc.ctrlbmp = cloneBitmap;
                        this.Set_pic_Control();
                        this.pic_Control.Refresh();
                        if (uH.hlp_dlg.usrc_web_Help1.frm_HUDCMS.usrc_EditControl1.m_usrc_Control == this)
                        {
                            uH.hlp_dlg.usrc_web_Help1.frm_HUDCMS.usrc_EditControl1.Init(this);
                        }
                    }
                }
            }
        }

        private void GetParentSnapshotArea(ref Rectangle snap_rect, usrc_Control xusrc_Control, List<usrc_Control> link)
        {
            int xLeft = GetLeftMost(xusrc_Control, link)- SnapShotMargin;
            int yTop = GetTopMost(xusrc_Control, link)-SnapShotMargin;
            int xRight = GetRightMost(xusrc_Control, link) + SnapShotMargin; 
            int yBottom = GetBottomMost(xusrc_Control, link) + SnapShotMargin; 
            snap_rect = new Rectangle(xLeft, yTop, xRight - xLeft, yBottom - yTop);
        }

        private int GetBottomMost(List<usrc_Control> link)
        {
            bool bDefined = false;
            int bottom = -1;

            foreach (usrc_Control c in link)
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
                        bottom = c.hc.ctrl.Bottom;
                    }
                }
            }
            return bottom;
        }

        private bool LinkExist(List<usrc_Control> link)
        {
            if (link!=null)
            {
                return link.Count > 0;
            }
            return  false;
        }

        private int GetBottomMost(usrc_Control xusrc_Control, List<usrc_Control> link)
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

        private int GetRightMost(List<usrc_Control> link)
        {
            bool bDefined = false;
            int right = -1;
            foreach (usrc_Control c in link)
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

        private int GetRightMost(usrc_Control xusrc_Control, List<usrc_Control> link)
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

        private int GetTopMost(List<usrc_Control> link)
        {
            bool bDefined = false;
            int top = -1;
            foreach (usrc_Control c in link)
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

        private int GetTopMost(usrc_Control xusrc_Control, List<usrc_Control> link)
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

        private int GetLeftMost(List<usrc_Control> link)
        {
            bool bDefined = false;
            int left = -1;
            foreach (usrc_Control c in link)
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

        private int GetLeftMost(usrc_Control xusrc_Control, List<usrc_Control> link)
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

        private void AddLink(List<usrc_Control> link, usrc_Control xusrc_Control, usrc_Control xusrc_Control_Selected)
        {
            if (link!=null)
            {
                foreach (usrc_Control c in link)
                {
                    if (c== xusrc_Control)
                    {
                        //allready added
                        MessageBox.Show("Link allready added!");
                        return;
                    }
                }
                link.Add(xusrc_Control);
                xusrc_Control_Selected.lbl_LinkedControls.Visible = true;
                xusrc_Control_Selected.list_Link.Visible = true;

            }
        }

        private void RemoveLink(List<usrc_Control> link, usrc_Control xusrc_Control, usrc_Control usrc_Control_Selected)
        {
            if (LinkExist(link))
            {
                foreach (usrc_Control c in link)
                {
                    if (c == xusrc_Control)
                    {
                        link.Remove(xusrc_Control);
                        if (!LinkExist(link))
                        {
                            usrc_Control_Selected.lbl_LinkedControls.Visible = false;
                            usrc_Control_Selected.list_Link.Visible = false;
                            usrc_Control_Selected.Refresh();
                        }
                        return;
                    }
                }
            }
            else
            {
                usrc_Control_Selected.lbl_LinkedControls.Visible = false;
                usrc_Control_Selected.list_Link.Visible = false;
                usrc_Control_Selected.Refresh();
            }
        }
    }
}
