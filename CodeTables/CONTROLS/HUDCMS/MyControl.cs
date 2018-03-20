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

namespace HUDCMS
{
    public partial class MyControl : IEquatable<MyControl>
    {
        internal Form_HUDCMS xfrm_HUDCMS = null;

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

        bool bImageIncluded = true;

        Image ImageOfControl = null;
        internal MyControl Parent = null;



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
            get { return this.helperImageRenderer.ImageList.Images.IndexOfKey(ControlUniqueName); }
        }


        public string HelpTitle
        {
            get { return m_HelpTitle; }
            set { m_HelpTitle = value; }
        }

        private int m_Right = 0;
        public int Right
        {
            get { return m_Right; }
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

        internal List<MyControl> children = new List<MyControl>();

        internal List<MyControl> AvailableLink = null;
        internal List<MyControl> Link = null;

        internal hctrl hc = null;
        internal usrc_Help uH = null;

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

        //public int ImageWidth
        //{
        //    get
        //    {

        //        string Err = null;
        //        try
        //        {
        //            return this.pic_Control.Image.Width;
        //        }
        //        catch (Exception ex)
        //        {
        //            Err = ex.Message;
        //            return 0;
        //        }
        //    }
        //}

        //public int ImageHeight
        //{
        //    get
        //    {

        //        string Err = null;
        //        try
        //        {
        //            return this.pic_Control.Image.Height;
        //        }
        //        catch (Exception ex)
        //        {
        //            Err = ex.Message;
        //            return 0;
        //        }
        //    }
        //}

        public string GetControlUniqueName()
        {
            return uH.Prefix+hc.GetName();
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

        internal void CreateNode(XDocument xh,ref XElement xn)
        {

            xel = new XElement("TControl");
            XAttribute attribute_name = new XAttribute("name", GetControlUniqueName());
            string simage_included = "0";
            //if (chk_ImageIncluded.Checked)
            //{
                simage_included = "1";
            //}
            XAttribute attribute_imageincluded = new XAttribute("imageincluded", simage_included);
            string sLink = "";
            if (Link!=null)
            {
                if (Link.Count > 0)
                {
                    foreach (MyControl c in Link)
                    {
                        if (sLink.Length == 0)
                        {
                            sLink = c.ControlUniqueName;
                        }
                        else
                        {
                            sLink += "," + c.ControlUniqueName;
                        }
                    }
                }
            }
            XAttribute attribute_link = new XAttribute("link", sLink);

            //string smargin = SnapShotMargin.ToString();
            //XAttribute attribute_margin = new XAttribute("margin", smargin);

            XAttribute attribute_heading = new XAttribute("heading", HeadingTag);

            xel.Add(attribute_name);
            xel.Add(attribute_imageincluded);
            xel.Add(attribute_link);
            //xel.Add(attribute_margin);
            xel.Add(attribute_heading);



            if (HelpTitle.Length > 0)
            {
                xdiv_Title = new XElement("div");
                XAttribute xdiv_Title_class = new XAttribute("class", "Title");
                xdiv_Title.Add(xdiv_Title_class);
                xTitle_Heading = new XElement(HeadingTag);
                XAttribute xdiv_Title_Heading_class = new XAttribute("class", "Title");
                if (ID.Length==0)
                {
                    Guid id = Guid.NewGuid();
                    ID = id.ToString();
                }
                XAttribute xdiv_Title_Heading_id = new XAttribute("id", ID);

                xTitle_Heading.Add(xdiv_Title_Heading_class);
                xTitle_Heading.Add(xdiv_Title_Heading_id);


                usrc_Control.ReplaceInnerXml(xTitle_Heading, "Title", HelpTitle);


                
                xdiv_Title.Add(xTitle_Heading);

                if (About.Length > 0)
                {
                    xdiv_About = new XElement("div");
                    XAttribute xdiv_About_class = new XAttribute("class", "About");
                    xdiv_About.Add(xdiv_About_class);
                    usrc_Control.ReplaceInnerXml(xdiv_About,"About",About);
                    xdiv_Title.Add(xdiv_About);
                }

                string imagesourcename = ImageSource;
                if (ImageSource.Length > HUDCMS_static.MAX_FILENAME_LENGTH)
                {
                    imagesourcename = "hashname_" + ImageSource.GetHashCode()+".png";
                }
                if (bImageIncluded)
                {
                    ximg = new XElement("img");
                    XAttribute img_src = new XAttribute("src", imagesourcename);
                    //                    XAttribute img_width = new XAttribute("width", ImageWidth.ToString());
                    //                    XAttribute img_height = new XAttribute("height", ImageHeight.ToString());
                    ximg.Add(img_src);
                    //                    ximg.Add(img_width);
                    //                    ximg.Add(img_height);
                    xdiv_Title.Add(ximg);
                }

                if (Description.Length > 0)
                {
                    xdiv_Description = new XElement("div");
                    XAttribute xdiv_Description_class = new XAttribute("class", "Description");
                    xdiv_Description.Add(xdiv_Description_class);
                    usrc_Control.ReplaceInnerXml(xdiv_Description, "Description", Description);
                    //xdiv_Description.Value = Description;
                    xdiv_Title.Add(xdiv_Description);
                }

                xel.Add(xdiv_Title);
                string Err = null;

                if ((this.hc.ctrlbmp != null)&& (bImageIncluded))
                {
                    try
                    {
                        string ximage_path = Path.GetDirectoryName(uH.LocalHtmlFile);
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

                      

                        string ximage_file = ximage_path + imagesourcename;
                        this.ImageOfControl.Save(ximage_file, ImageFormat.Png);
                    }
                    catch (Exception ex)
                    {
                        Err = ex.Message;
                        MessageBox.Show("ERROR:Can not save:\"" + ImageSource + "\"" + Err);
                    }
                }
            }
            foreach (MyControl c in this.children)
            {
                    c.CreateNode(xh,ref xel);
            }
            xn.Add(xel);

        }

        public static void ReplaceInnerXml(XElement xdiv_About,string classname, string about)
        {
            //Here is an example in C# that uses ReplaceNodes and XElement.Parse:

//            xdiv_About.

            xdiv_About.ReplaceNodes(XElement.Parse("<div class=\""+ classname + "\">" + about + "</div>").Nodes());



        }

        public MyControl()
        {
        }

        //private void Usrc_Control_MouseClick(object sender, MouseEventArgs e)
        //{
        //    switch (e.Button)
        //    {
        //        case MouseButtons.Right:
        //            {
        //                string msg = null;
        //                if (sender is usrc_Control)
        //                {
        //                    msg = "Control:" + ((usrc_Control)sender).txt_Control.Text + "\r\nName=" + ((usrc_Control)sender).txt_ControlName.Text;
        //                }
        //                if (sender is Panel)
        //                {
        //                    if (((Panel)sender).Parent != null)
        //                    {
        //                        if (((Panel)sender).Parent is usrc_Control)
        //                        {
        //                            msg = "Control:" + ((usrc_Control)((Panel)sender).Parent).txt_Control.Text + "\r\nName=" + ((usrc_Control)((Panel)sender).Parent).txt_ControlName.Text;
        //                        }
        //                    }
        //                }
        //                if (msg != null)
        //                {
        //                    MessageBox.Show(Global.f.GetParentForm(this), msg);
        //                }
        //            }
        //            break;
        //    }
        //}

        //private void Set_pic_Control()
        //{
        //    this.pic_Control.Image = hc.ctrlbmp;
        //    this.pic_Control.SizeMode = PictureBoxSizeMode.Zoom;
        //    this.pic_Control.Width = hc.ctrlbmp.Width;
        //    if (this.pic_Control.Width > MaxPanelWidth)
        //    {
        //        this.pic_Control.Width = MaxPanelWidth - 60;
        //        this.pic_Control.Height = hc.ctrlbmp.Height * this.pic_Control.Width / hc.ctrlbmp.Width + 4;
        //    }
        //    else
        //    {
        //        this.pic_Control.Height = hc.ctrlbmp.Height;
        //    }
        //    this.pic_Control.Top = this.chk_ImageIncluded.Bottom + 4;
        //    this.lbl_LinkedControls.Left = this.pic_Control.Right + 4;
        //    this.list_Link.Left = this.pic_Control.Right + 4;
        //}

        internal void Init(usrc_Help xuH, hctrl xhc, int iLevel,  ref SysImageListHelper helperControlType, ref ImageRenderer xhelperImageRenderer)
        {
            uH = xuH;
            hc = xhc;
            helperImageRenderer = xhelperImageRenderer;
            if (hc.ctrl != null)
            {
                this.ControlName =hc.ctrl.Name;
            }
            else if (hc.dgvc != null)
            {
                this.ControlName = "dgvc__" + hc.dgvc.Name;
            }
            string sText = "";
            string sControl = HUDCMS_static.slng_UserControlName;
            helperControlType.AddImageToCollection(GetControlType(), helperControlType.SmallImageList, GetControlTypeImage());

            if (hc.ctrlbmp != null)
            {
                if (helperImageRenderer.ImageList==null)
                {
                    helperImageRenderer.ImageList = new ImageList();
                    helperImageRenderer.ImageList.ImageSize = new Size(48, 48);
                }
                helperImageRenderer.ImageList.Images.Add(GetControlUniqueName(),hc.ctrlbmp);
                //helperControlName.AddImageToCollection(GetControlName(), helperControlName.LargeImageList, hc.ctrlbmp);
            }
            if (hc.pForm !=null)
            {
                sControl = "Form";
                this.ControlName = hc.pForm.Name;
                //                this.txt_Control.ForeColor = Color.DarkGreen;
                //                this.txt_Control.BackColor = Color.White;
                //                helper.AddImageToCollection(xhc.pForm.GetType().ToString(), helper.LargeImageList, Prop)
            }
            else if (hc.ctrl is Form)
            {
                sControl = "Form";
                this.ControlName = hc.ctrl.Name;
                //                this.txt_Control.ForeColor = Color.DarkGreen;
            }
            else if (xhc.ctrl is UserControl)
            {
                //                this.txt_Control.ForeColor = Color.DarkBlue;
                //                this.txt_Control.BackColor = Color.White;
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
                        //                        this.txt_Control.ForeColor = Color.DarkViolet;
                        //                        this.txt_Control.BackColor = Color.LightCoral;
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
                    //                    this.txt_Control.Text = sControl + "=" + xhc.dgvc.Name + "  Type:" + xhc.dgvc.GetType().ToString() + sText;
                }
                else 
                {
                    MessageBox.Show("ERROR:HUDCMS:usrc_Control:(xhc.ctrl == null)&&(xhc.pForm != null)!");
                }
            }
            else
            {
                //                this.txt_Control.Text = sControl + "=" + xhc.ctrl.Name + "  Type:" + xhc.ctrl.GetType().ToString() + sText;
            }

            //            this.txt_Control.Text += " Level="+ iLevel.ToString();
            //            txt_ControlName.Text = uH.Prefix+hc.GetName();

            if (hc.ctrlbmp != null)
            {
                //                Set_pic_Control();


                string path = Path.GetDirectoryName(uH.LocalHtmlFile);

                //                this.panel1.Height = this.pic_Control.Bottom + 4;
                //                if (this.panel1.Height>MaxPanelHeight)
                //                {
                //                this.panel1.Height = MaxPanelHeight;
                //            }
                //if (this.panel1.Height < MinPanelHeight)
                //{
                //    this.panel1.Height = MinPanelHeight;
                //}
                //this.Height = this.panel1.Bottom + 4;
             
            }
            else
            {
                if (this.hc.dgvc != null)
                {
                    //this.chk_ImageIncluded.Visible = false;
                    //this.pic_Control.Visible = false;
                    //Title = this.hc.dgvc.HeaderText;
                    //this.panel1.Height = this.radioButtonGlobal1.Bottom + 6;
                    //if (this.panel1.Height < MinPanelHeight)
                    //{
                    //    this.panel1.Height = MinPanelHeight;
                    //}
                    //this.Height = this.panel1.Bottom + 4;
                    //this.btn_Link.Visible = false;
                }
            }

            xfrm_HUDCMS = null;
             if (uH.hlp_dlg!=null)
            {
                xfrm_HUDCMS = uH.hlp_dlg.usrc_web_Help1.frm_HUDCMS;
            }
            else
            {
             //   xfrm_HUDCMS =(Form_HUDCMS) Global.f.GetParentForm(this);
            }

            if (xfrm_HUDCMS.xhtml_Loaded != null)
            {
                XDocument doc = xfrm_HUDCMS.xhtml_Loaded;
                XElement xel = null;
                if (FindXElement(doc, ref xel, "TControl", "name",ControlUniqueName))
                {
                    string simageincluded = xel.Attribute("imageincluded").Value;
//                    chk_ImageIncluded.Checked = true;
                    if (simageincluded.Equals("0"))
                    {
                        //                        chk_ImageIncluded.Checked = false;
                    }

                    this.sLink = null;
                    string sLinks = xel.Attribute("link").Value;
                    if (sLinks != null)
                    {
                        if (sLinks.Length > 0)
                        {
                            sLink = sLinks.Split(',');
                        }
                    }

                    string smargin = xel.Attribute("margin").Value;
                    if (smargin != null)
                    {
                        if (smargin.Length > 0)
                        {
                            SnapShotMargin = Convert.ToInt32(smargin);
                        }
                    }

                    HeadingTag = xel.Attribute("heading").Value;

                    XElement xel_Title = null;
                    if (FindXElement(xel, ref xel_Title, "div", "class", "Title"))
                    {
                        XElement xel_Title_Header = null;
                        if (FindXElement(xel_Title, ref xel_Title_Header, "h1", "class", "Title"))
                        {
                            //Title = xel_Title_Header.Value;
                            HelpTitle = usrc_Control.InnerXml(xel_Title_Header);
                            Set_ID(xel_Title_Header.Attribute("id"));
                        }
                        else if (FindXElement(xel_Title, ref xel_Title_Header, "h2", "class", "Title"))
                        {
                            //Title = xel_Title_Header.Value;
                            HelpTitle = usrc_Control.InnerXml(xel_Title_Header);
                            Set_ID(xel_Title_Header.Attribute("id"));
                        }
                        else if (FindXElement(xel_Title, ref xel_Title_Header, "h3", "class", "Title"))
                        {
                            //Title = xel_Title_Header.Value;
                            HelpTitle = usrc_Control.InnerXml(xel_Title_Header);
                            Set_ID(xel_Title_Header.Attribute("id"));
                        }
                        else if (FindXElement(xel_Title, ref xel_Title_Header, "h4", "class", "Title"))
                        {
                            //Title = xel_Title_Header.Value;
                            HelpTitle = usrc_Control.InnerXml(xel_Title_Header);
                            Set_ID(xel_Title_Header.Attribute("id"));
                        }
                        else if (FindXElement(xel_Title, ref xel_Title_Header, "h5", "class", "Title"))
                        {
                            //Title = xel_Title_Header.Value;
                            HelpTitle = usrc_Control.InnerXml(xel_Title_Header);
                            Set_ID(xel_Title_Header.Attribute("id"));
                        }
                        else if (FindXElement(xel_Title, ref xel_Title_Header, "h6", "class", "Title"))
                        {
                            //Title = xel_Title_Header.Value;
                            HelpTitle = usrc_Control.InnerXml(xel_Title_Header);
                            Set_ID(xel_Title_Header.Attribute("id"));
                        }

                        XElement xel_About = null;
                        if (FindXElement(xel_Title, ref xel_About, "div", "class", "About"))
                        {
                            //About = xel_About.Value;
                            About = usrc_Control.InnerXml(xel_About);
                        }
                        XElement xel_Description = null;
                        if (FindXElement(xel_Title, ref xel_Description, "div", "class", "Description"))
                        {
                            //Description = xel_Description.Value;
                            Description = usrc_Control.InnerXml(xel_Description);
                        }
                    }

                }
            }
            else
            {
                if (hc.pForm != null)
                {
                    HelpTitle = hc.pForm.Text;
                    HeadingTag = "h1";
                }
                else if (hc.ctrl != null)
                {
                    HeadingTag = "h2";
                }
                else if (hc.dgvc != null)
                {
                    HeadingTag = "h3";
                }
                else
                {
                    HeadingTag = "h4";
                }

                if (hc.ctrl != null)
                {
                    if (hc.ctrl is GroupBox)
                    {
                        HelpTitle = ((GroupBox)hc.ctrl).Text;
                    }
                }
            }


            //            this.list_Link.Visible = false;

            //            this.list_Link.DataSource = null;
            if (this.Link != null)
            {
                if (this.Link.Count > 0)
                {
                    //this.list_Link.Visible = true;
                    //this.list_Link.DataSource = Link;
                    //this.list_Link.DisplayMember = "ControlName";
                    //this.list_Link.ValueMember = "ControlName";
                }
            }
            //            this.lbl_LinkedControls.Visible = this.list_Link.Visible;

            if (ID.Length == 0)
            {
                Guid id = Guid.NewGuid();
                ID = id.ToString();
            }
            //            txt_ID.Text = ID;
            //            SetDefault_BackColor();
            //            this.Refresh();
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
            }
            else
            {
                ID = Guid.NewGuid().ToString();
            }
        }

        internal static bool Find_usrc_Control(Control ctrl, string slnk, ref usrc_Control usrc_Control_found)
        {
            if (ctrl != null)
            {
                if (ctrl is usrc_Control)
                {
                    string sControlName = ((usrc_Control)ctrl).ControlName;
                    if (sControlName.Equals(slnk))
                    {
                        usrc_Control_found = (usrc_Control)ctrl;
                        return true;
                    }
                    foreach (Control c in ctrl.Controls)
                    {
                        if (c is usrc_Control)
                        {
                            if (Find_usrc_Control(c, slnk, ref usrc_Control_found))
                            {
                                return true;
                            }
                        }
                    }
                }
                else
                {
                    foreach (Control c in ctrl.Controls)
                    {
                        if (c is usrc_Control)
                        {
                            if (Find_usrc_Control(c, slnk, ref usrc_Control_found))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        //private Color SetDefault_BackColor()
        //{
        //    if (this.Title.Length > 0)
        //    {
        //        //                this.BackColor = Color.LightYellow;
        //    }
        //    else
        //    {
        //        //                this.BackColor = xfrm_HUDCMS.BackColor;
        //    }
        //    return this.BackColor;
        //}
        public static string InnerXml(XElement element)
        {

            XmlReader oReader = element.CreateReader();
            oReader.MoveToContent();
            return oReader.ReadInnerXml();
         
        }

        internal bool FindXElement(XDocument doc,ref XElement element, string element_name, string AttributeName, string AttributeValue)
        {
            element = null;

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
                        MessageBox.Show("WARNING multiple TControl elements found where name = \"" + ControlUniqueName + "\"");
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
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return false;
        }

        //private void radioButtonGlobal1_CheckChanged()
        //{
        //    if (radioButtonGlobal1.Checked)
        //    {
        //        this.BackColor = radioButtonGlobal1.HighlightBackColor;
        //        xfrm_HUDCMS.usrc_EditControl1.Enabled = true;
        //        xfrm_HUDCMS.usrc_EditControl1.Init(this);
        //        xfrm_HUDCMS.usrc_Control_Selected = this;
        //        if (hc.dgvc == null)
        //        {
        //            xfrm_HUDCMS.HideLinks();
        //            xfrm_HUDCMS.ShowAvailableLinks();
        //        }
        //    }
        //}

        //private void radioButtonGlobal1_Load(object sender, EventArgs e)
        //{

        //}

        private void btn_Link_Click(object sender, EventArgs e)
        {
            //Link Form_HUDCMS.usrc_Control_Selected with this !
            if (xfrm_HUDCMS.usrc_Control_Selected != null)
            {
                if (bLinked)
                {
                    usrc_Control Control_Selected = xfrm_HUDCMS.usrc_Control_Selected;
                    if (Control_Selected.usrc_Link == null)
                    {
                        Control_Selected.usrc_Link = new List<usrc_Control>();
                    }
//                    RemoveLink(Control_Selected.Link, this, Control_Selected);
                    Control_Selected.CreateImageOfLinkedControls();
                    bLinked = false;
                }
                else
                {
                    usrc_Control Control_Selected = xfrm_HUDCMS.usrc_Control_Selected;
                    if (Control_Selected.usrc_Link == null)
                    {
                        Control_Selected.usrc_Link = new List<usrc_Control>();
                    }
//                    AddLink(Control_Selected.Link, this, Control_Selected);
                    Control_Selected.CreateImageOfLinkedControls();
                    bLinked = true;
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

        internal void CreateImageOfLinkedControls()
        {
            //          this.list_Link.Visible = false;
            //            this.list_Link.DataSource = null;
            //            if (this.Parent != null)
            //            {
            //                if (this.Parent is usrc_Control)
            //                {
            if (LinkExist(this.Link))
                    {
                        //this.list_Link.Visible = true;
                        //this.lbl_LinkedControls.Visible = true;
                        //this.list_Link.DataSource = Link;
                        //this.list_Link.DisplayMember = "ControlName";
                        //this.list_Link.ValueMember = "ControlName";
                    }
                    else
                    {
                    //    this.list_Link.Visible = false;
                    //    this.lbl_LinkedControls.Visible = false;
                    //    this.list_Link.DataSource = null;
                    }
                    Rectangle snap_rect = new Rectangle();
                    GetParentSnapshotArea(ref snap_rect, this, this.Link);

                    //if (((usrc_Control)this.Parent).hc.ctrlbmp != null)
                    //{
                    //    Bitmap myBitmap = new Bitmap(((usrc_Control)this.Parent).hc.ctrlbmp);
                    //    System.Drawing.Imaging.PixelFormat format =
                    //        myBitmap.PixelFormat;
                    //    Bitmap cloneBitmap = myBitmap.Clone(snap_rect, format);


                    //    if (this.hc.ctrlbmp != null)
                    //    {
                    //        this.hc.ctrlbmp.Dispose();
                    //        this.hc.ctrlbmp = null;
                    //    }
                    //    this.hc.ctrlbmp = cloneBitmap;
                    //    this.Set_pic_Control();
                    //    this.pic_Control.Refresh();
                    //    if (xfrm_HUDCMS.usrc_EditControl1.m_usrc_Control == this)
                    //    {
                    //        xfrm_HUDCMS.usrc_EditControl1.Init(this);
                    //    }
                    //}
//                }
//            }
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
                        bottom = c.hc.ctrl.Bottom;
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
                //xusrc_Control_Selected.lbl_LinkedControls.Visible = true;
                //xusrc_Control_Selected.list_Link.Visible = true;

            }
        }

        private void RemoveLink(List<MyControl> link, MyControl xusrc_Control, MyControl usrc_Control_Selected)
        {
            if (LinkExist(link))
            {
                foreach (MyControl c in link)
                {
                    if (c == xusrc_Control)
                    {
                        link.Remove(xusrc_Control);
                        if (!LinkExist(link))
                        {
                            //usrc_Control_Selected.lbl_LinkedControls.Visible = false;
                            //usrc_Control_Selected.list_Link.Visible = false;
                            //usrc_Control_Selected.Refresh();
                        }
                        return;
                    }
                }
            }
            else
            {
                //usrc_Control_Selected.lbl_LinkedControls.Visible = false;
                //usrc_Control_Selected.list_Link.Visible = false;
                //usrc_Control_Selected.Refresh();
            }
        }

        //private void radioButtonGlobal1_SetBackColor(object ctrl)
        //{
        //    if (ctrl is usrc_Control)
        //    {
        //        SetDefault_BackColor();
        //        if (((usrc_Control)ctrl).Parent != null)
        //        {
        //            if (((usrc_Control)ctrl).Parent  is usrc_Control)
        //            {
        //                ((usrc_Control)((usrc_Control)ctrl).Parent).SetDefault_BackColor();
        //            }
        //        }
        //    }
        //    else if (ctrl is Panel)
        //    {
        //        if (((Panel)ctrl).Parent != null)
        //        {
        //            if (((Panel)ctrl).Parent is usrc_Control)
        //            {
        //                Color backcolor = ((usrc_Control)((Panel)ctrl).Parent).SetDefault_BackColor();
        //                ((Panel)ctrl).BackColor = backcolor;
        //            }
        //        }
        //    }
        //}

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
