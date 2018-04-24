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

namespace HUDCMS
{
    public partial class MyControl : IEquatable<MyControl>
    {
        internal List<MyControl> children = new List<MyControl>();

        internal List<MyControl> Link = null;

        internal Form_HUDCMS xfrm_HUDCMS = null;
        internal Form_Wizzard xfrm_Wizzard = null;

        internal HelpWizzardTag HlpWizTag = null;

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

        public static bool MakeHtml(Control ctrl_for_help, string sNewTag, string[] sTagConditions,string styleFile, MyControl source_root_ctrl, ref string sResult)
        {
            if (ctrl_for_help !=null)
            {
                if (ctrl_for_help is Form)
                {
                    UniqueControlName uctrln = new UniqueControlName();
                    hctrl xhc = new hctrl((Form)ctrl_for_help, uctrln);
                    int level = 0;
                    int icount = 0;
                    int iAllCount = 0;
                    MyControl destination_root_ctrl = Form_HUDCMS.CreateMyControlsFromWizzardSource(source_root_ctrl, sNewTag, sTagConditions,level, icount, ref iAllCount, xhc,null);
                    XDocument xh = null;
                    string header = "";
                    XElement html_html = null;
                    XElement html_head = null;
                    XElement html_title = null;
                    XElement html_body = null;
                    XElement THeader = null;
                    string Err = null;
                    Form_HUDCMS.SaveXHTML((Form)ctrl_for_help, ref xh, destination_root_ctrl.ControlUniqueName + sNewTag, styleFile, header, ref header, destination_root_ctrl,
                        ref html_html,
                        ref html_head,
                        ref html_title,
                        ref html_body,
                        ref THeader,
                        ref Err
                        );
                }
            }
            return false;
        }

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
            if (ImageIncluded)
            {
                simage_included = "1";
            }
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

            string smargin = SnapShotMargin.ToString();
            XAttribute attribute_margin = new XAttribute("margin", smargin);

            XAttribute attribute_heading = new XAttribute("heading", HeadingTag);

            xel.Add(attribute_name);
            xel.Add(attribute_imageincluded);
            xel.Add(attribute_link);
            xel.Add(attribute_margin);
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


                MyControl.ReplaceInnerXml(xTitle_Heading, "Title", HelpTitle);


                
                xdiv_Title.Add(xTitle_Heading);

                xdiv_About = null;

                if (this.HlpWizTag != null)
                {
                    if (this.HlpWizTag.HasAbout())
                    {
                        xdiv_About = new XElement("div");
                        XAttribute xdiv_About_class = new XAttribute("class", "About");
                        xdiv_About.Add(xdiv_About_class);
                        MyControl.ReplaceInnerXml(xdiv_About, this.HlpWizTag.About.tagDCs);
                        xdiv_Title.Add(xdiv_About);
                    }
                }

                if (xdiv_About == null)
                {
                    if (About.Length > 0)
                    {
                        xdiv_About = new XElement("div");
                        XAttribute xdiv_About_class = new XAttribute("class", "About");
                        xdiv_About.Add(xdiv_About_class);
                        MyControl.ReplaceInnerXml(xdiv_About, "About", About);
                        xdiv_Title.Add(xdiv_About);
                    }
                }


                string Err = null;

                if ((this.hc.ctrlbmp != null) && m_ImageIncluded)
                {
                    string imagesourcename = ImageSource;
                    if (ImageSource.Length > HUDCMS_static.MAX_FILENAME_LENGTH)
                    {
                        imagesourcename = "hashname_" + ImageSource.GetHashCode() + ".png";
                    }
                    ximg = new XElement("img");
                    XAttribute img_src = new XAttribute("src", imagesourcename);
                    //                    XAttribute img_width = new XAttribute("width", ImageWidth.ToString());
                    //                    XAttribute img_height = new XAttribute("height", ImageHeight.ToString());
                    ximg.Add(img_src);
                    //                    ximg.Add(img_width);
                    //                    ximg.Add(img_height);
                    xdiv_Title.Add(ximg);

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
                        if (this.ImageOfControl == null)
                        {
                            this.ImageOfControl = this.hc.ctrlbmp;
                        }
                        this.ImageOfControl.Save(ximage_file, ImageFormat.Png);
                        if (Properties.Settings.Default.UseGit)
                        {
                            string std_err = null;
                            string std_out = null;
                            switch (Git.CheckIfFileInRepository(ximage_file, ref std_out, ref std_err))
                            {
                                case Git.eCheckIfFileInRepository.FileIsNotInRepository:
                                    if (!Git.Add(ximage_file, ref std_out, ref std_err))
                                    {
                                        MessageBox.Show(std_err);
                                    }
                                    break;
                                case Git.eCheckIfFileInRepository.ERROR:
                                    MessageBox.Show(std_err);
                                    break;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Err = ex.Message;
                        MessageBox.Show("ERROR:Can not save:\"" + ImageSource + "\"" + Err);
                    }
                }

                if (Description.Length > 0)
                {
                    xdiv_Description = new XElement("div");
                    XAttribute xdiv_Description_class = new XAttribute("class", "Description");
                    xdiv_Description.Add(xdiv_Description_class);
                    MyControl.ReplaceInnerXml(xdiv_Description, "Description", Description);
                    //xdiv_Description.Value = Description;
                    xdiv_Title.Add(xdiv_Description);
                }

                xel.Add(xdiv_Title);

                if ((this.hc.ctrlbmp != null)&& (m_ImageIncluded))
                {
                  
                }
            }
            foreach (MyControl c in this.children)
            {
                    c.CreateNode(xh,ref xel);
            }
            xn.Add(xel);

        }

        private static void ReplaceInnerXml(XElement xdiv_About, HelpWizzardTagDC[] tagDCs)
        {
            foreach(HelpWizzardTagDC tdc in tagDCs)
            {
                if (tdc.Text != null)
                {
                    if (tdc.Text.Length > 0)
                    {
                        XElement xdiv_tdc = new XElement("HelpWizzardTagDC");
                        string classname = tdc.Name + "$" + tdc.Condition;
                        XAttribute xdiv_tdc_Name = new XAttribute("class", classname);
                        xdiv_tdc.Add(xdiv_tdc_Name);
                        MyControl.ReplaceInnerXml(xdiv_tdc, classname, tdc.Text);
                        xdiv_About.Add(xdiv_tdc);
                    }
                }
            }
        }

        public static void ReplaceInnerXml(XElement xdiv_About,string classname, string about)
        {
            //Here is an example in C# that uses ReplaceNodes and XElement.Parse:

            //            xdiv_About.

            try
            {
                xdiv_About.ReplaceNodes(XElement.Parse("<div class=\"" + classname + "\">" + about + "</div>").Nodes());
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR:HUDCMS:MyControl:ReplaceInnerXml(...):Exception=" + ex.Message);
            }



        }

        public MyControl()
        {
        }

   
        internal void Init(HelpWizzardTag xHlpWizTag, usrc_Help xuH, hctrl xhc, int iLevel, MyControl parent, ref SysImageListHelper helperControlType)
        {
            string xControlInfo_title = "";
            string xControlInfo_about = "";
            string xControlInfo_description = "";

            if (xHlpWizTag != null)
            {
               
               this.HlpWizTag = new HelpWizzardTag(xHlpWizTag);
               
            }

            uH = xuH;
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
            helperControlType.AddImageToCollection(GetControlType(), helperControlType.SmallImageList, GetControlTypeImage());

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


            if (hc.ctrlbmp != null)
            {

                string path = Path.GetDirectoryName(uH.LocalHtmlFile);
             
            }
            else
            {
                if (this.hc.dgvc != null)
                {
                }
            }

            xfrm_HUDCMS = null;
             if (uH.hlp_dlg!=null)
            {
                xfrm_HUDCMS = uH.hlp_dlg.usrc_web_Help1.frm_HUDCMS;
                xfrm_Wizzard = uH.hlp_dlg.usrc_web_Help1.frm_Wizzard;
            }
            else if (uH.uwebHelp != null)
            {
                xfrm_HUDCMS = uH.uwebHelp.frm_HUDCMS;
                xfrm_Wizzard = null;
            }

            XDocument doc = null;
            if (Get_xhtml_Loaded(ref doc))
            {
                XElement xel = null;
                if (MyControl.FindXElement(doc, ref xel, "TControl", "name",ControlUniqueName,ControlUniqueName))
                {
                    string simageincluded = xel.Attribute("imageincluded").Value;
                    ImageIncluded = true;
                    if (simageincluded.Equals("0"))
                    {
                        ImageIncluded = false;
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
                    if (MyControl.FindXElement(xel, ref xel_Title, "div", "class", "Title"))
                    {
                        XElement xel_Title_Header = null;
                        if (MyControl.FindXElement(xel_Title, ref xel_Title_Header, "h1", "class", "Title"))
                        {
                            //Title = xel_Title_Header.Value;
                            HelpTitle = MyControl.InnerXml(xel_Title_Header);
                            Set_ID(xel_Title_Header.Attribute("id"));
                        }
                        else if (MyControl.FindXElement(xel_Title, ref xel_Title_Header, "h2", "class", "Title"))
                        {
                            //Title = xel_Title_Header.Value;
                            HelpTitle = MyControl.InnerXml(xel_Title_Header);
                            Set_ID(xel_Title_Header.Attribute("id"));
                        }
                        else if (MyControl.FindXElement(xel_Title, ref xel_Title_Header, "h3", "class", "Title"))
                        {
                            //Title = xel_Title_Header.Value;
                            HelpTitle = MyControl.InnerXml(xel_Title_Header);
                            Set_ID(xel_Title_Header.Attribute("id"));
                        }
                        else if (MyControl.FindXElement(xel_Title, ref xel_Title_Header, "h4", "class", "Title"))
                        {
                            //Title = xel_Title_Header.Value;
                            HelpTitle = MyControl.InnerXml(xel_Title_Header);
                            Set_ID(xel_Title_Header.Attribute("id"));
                        }
                        else if (MyControl.FindXElement(xel_Title, ref xel_Title_Header, "h5", "class", "Title"))
                        {
                            //Title = xel_Title_Header.Value;
                            HelpTitle = MyControl.InnerXml(xel_Title_Header);
                            Set_ID(xel_Title_Header.Attribute("id"));
                        }
                        else if (MyControl.FindXElement(xel_Title, ref xel_Title_Header, "h6", "class", "Title"))
                        {
                            //Title = xel_Title_Header.Value;
                            HelpTitle = MyControl.InnerXml(xel_Title_Header);
                            Set_ID(xel_Title_Header.Attribute("id"));
                        }

                        XElement xel_About = null;
                        if (MyControl.FindXElement(xel_Title, ref xel_About, "div", "class", "About"))
                        {
                            //About = xel_About.Value;
                            About = MyControl.InnerXml(xel_About);
                            if (this.HlpWizTag!=null)
                            {
                                this.HlpWizTag.About.Parse(About,ControlUniqueName);
                            }

                        }
                        XElement xel_Description = null;
                        if (MyControl.FindXElement(xel_Title, ref xel_Description, "div", "class", "Description"))
                        {
                            //Description = xel_Description.Value;
                            Description = MyControl.InnerXml(xel_Description);
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
                    if (GetControlInfo(ref xControlInfo_title,ref xControlInfo_about,ref xControlInfo_description))
                    {
                        HelpTitle = xControlInfo_title;
                        About = xControlInfo_about;
                        Description = xControlInfo_description;
                    }
                    else if (hc.ctrl is GroupBox)
                    {
                        if (!ParentIs_usrc_myGroupBox(hc.ctrl))
                        {
                            HelpTitle = ((GroupBox)hc.ctrl).Text;
                        }
                    }
                }
                else if (hc.dgvc != null)
                {
                    HelpTitle = hc.dgvc.HeaderText;
                }
            }


            if (ID.Length == 0)
            {
                Guid id = Guid.NewGuid();
                ID = id.ToString();
            }

        }

        internal void InitFromWizzardSource(MyControl source_root_control, string sNewTag, string[] sTagConditions, hctrl xhc, int iLevel, MyControl parent)
        {
            string xControlInfo_title = "";
            string xControlInfo_about = "";
            string xControlInfo_description = "";

            uH = null;
            hc = xhc;
            this.Parent = parent;
            if (hc.ctrl != null)
            {
                this.ControlName = hc.ctrl.Name;
            }
            else if (hc.dgvc != null)
            {
                this.ControlName = "dgvc__" + hc.dgvc.Name;
                this.m_ImageIncluded = false;
            }
            string sText = "";
            string sControl = HUDCMS_static.slng_UserControlName;

            if (hc.pForm != null)
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


            if (hc.ctrlbmp != null)
            {

                string path = Path.GetDirectoryName(uH.LocalHtmlFile);

            }
            else
            {
                if (this.hc.dgvc != null)
                {
                }
            }

            xfrm_HUDCMS = null;
            xfrm_Wizzard = null;

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
                if (GetControlInfo(ref xControlInfo_title, ref xControlInfo_about, ref xControlInfo_description))
                {
                    HelpTitle = xControlInfo_title;
                    About = xControlInfo_about;
                    Description = xControlInfo_description;
                }
                else if (hc.ctrl is GroupBox)
                {
                    if (!ParentIs_usrc_myGroupBox(hc.ctrl))
                    {
                        HelpTitle = ((GroupBox)hc.ctrl).Text;
                    }
                }
            }
            else if (hc.dgvc != null)
            {
                HelpTitle = hc.dgvc.HeaderText;
            }

            string sAbout = "";
            source_root_control.GetAboutFromHelpWizzardTag(sTagConditions, ref sAbout);
            About = sAbout;

            if (ID.Length == 0)
            {
                Guid id = Guid.NewGuid();
                ID = id.ToString();
            }
        }

        private void GetAboutFromHelpWizzardTag(string[] sTagConditions, ref string sAbout)
        {
            sAbout = "";
            if (HlpWizTag!=null)
            {
                if (HlpWizTag.About != null)
                {
                    foreach (string tagcond in sTagConditions)
                    {
                        foreach (HelpWizzardTagDC tagdc in HlpWizTag.About.tagDCs)
                        {
                            if (tagdc.Condition==null)
                            {
                                if (tagdc.Text != null)
                                {
                                    sAbout += tagdc.Text;
                                }
                            }
                            else if (tagdc.NamedCondition.Equals(tagcond))
                            {
                                if (tagdc.Text != null)
                                {
                                    sAbout += tagdc.Text;
                                }
                            }
                        }
                    }
                }
            }
        }

        private bool Get_xhtml_Loaded(ref XDocument doc)
        {
            if (xfrm_HUDCMS != null)
            {
                doc = xfrm_HUDCMS.xhtml_Loaded;
                return doc != null;
            }
            else if (xfrm_Wizzard != null)
            {
                doc = xfrm_Wizzard.xhtml_Loaded;
                return doc != null; 
            }
            else
            {
                MessageBox.Show("ERROR:HUDCMS:MyControl:Get_xhtml_Loaded:  (xfrm_HUDCMS == null)&&(xfrm_Wizzard == null)");
                return false;
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

        private bool GetControlInfo(ref string xControlInfo_title, ref string xControlInfo_about, ref string xControlInfo_description)
        {
            if (HUDCMS_static.ControlInfo != null)
            {
                if (HUDCMS_static.ControlInfo(hc.ctrl, ref xControlInfo_title, ref xControlInfo_about, ref xControlInfo_description))
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
            }
            else
            {
                ID = Guid.NewGuid().ToString();
            }
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

        public static string InnerXml(XElement element)
        {

            XmlReader oReader = element.CreateReader();
            oReader.MoveToContent();
            return oReader.ReadInnerXml();
         
        }

        internal static bool FindXElement(XDocument doc,ref XElement element, string element_name, string AttributeName, string AttributeValue, string xControlUniqueName)
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
                        MessageBox.Show("WARNING multiple TControl elements found where name = \"" + xControlUniqueName + "\"");
                    }
                }

            }
            return false;
        }

        internal static bool FindXElement(XElement el, ref XElement element,string element_name,string AttributeName,string AttributeValue)
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

    
        internal void ShowLink()
        {
            //Link Form_HUDCMS.usrc_Control_Selected with this !
            if (Get_MyControl_Selected())
            {
                MyControl Control_Selected = null;
                if (xfrm_HUDCMS != null)
                {
                    Control_Selected = xfrm_HUDCMS.MyControl_Selected;
                }
                else if (xfrm_Wizzard != null)
                {
                    Control_Selected = xfrm_Wizzard.MyControl_Selected;
                }

                if (Control_Selected != null)
                {
                    Control_Selected.CreateImageOfLinkedControls();
                }
                else
                {
                    MessageBox.Show("ERROR:HUDCMS:MyControl:ShowLink: (xfrm_HUDCMS==null)&& (xfrm_Wizzard==null)");
                }
            }
        }

        private bool Get_MyControl_Selected()
        {
            if (xfrm_HUDCMS != null)
            {
                return (xfrm_HUDCMS.MyControl_Selected != null);
            }
            else if (xfrm_Wizzard != null)
            {
                return (xfrm_Wizzard.MyControl_Selected != null);
            }
            else
            {
                MessageBox.Show("ERROR:HUDCMS:MyControl:Get_MyControl_Selected: (xfrm_HUDCMS==null)&& (xfrm_Wizzard==null)");
                return false;
            }
        }

        private void SetLinks()
        {
            string[] xslink = sLink;
            string ctrl_name = ControlName;
            if (HasLink)
            {
                if (Link == null)
                {
                    Link = new List<MyControl>();
                }
                else
                {
                    Link.Clear();
                }
                foreach (string sctrl_name in sLink)
                {
                    MyControl my_Control_Linked = null;
                    MyControl myparent = this.Parent;
                    while (myparent != null)
                    {
                        if (MyControl.Find_my_Control(myparent, sctrl_name, ref my_Control_Linked))
                        {
                            Link.Add(my_Control_Linked);
                            my_Control_Linked.bLinked = true;
                        }
                        myparent = myparent.Parent;
                    }
                }
                if (Link.Count > 0)
                {
                    CreateImageOfLinkedControls();
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
            Rectangle snap_rect = new Rectangle();
            GetParentSnapshotArea(ref snap_rect, this, this.Link);

            if (this.hc.ctrlbmp != null)
            {
                Bitmap myBitmap = new Bitmap(this.Parent.hc.ctrlbmp);
                System.Drawing.Imaging.PixelFormat format =
                    myBitmap.PixelFormat;
                Bitmap cloneBitmap = myBitmap.Clone(snap_rect, format);


                if (this.hc.ctrlbmp != null)
                {
                    this.hc.ctrlbmp.Dispose();
                    this.hc.ctrlbmp = null;
                }
                this.hc.ctrlbmp = cloneBitmap;
                if (xfrm_HUDCMS != null)
                {
                    if (xfrm_HUDCMS.usrc_EditControl1.my_Control == this)
                    {
                        xfrm_HUDCMS.usrc_EditControl1.Set_pic_Control(this.hc);
                    }
                }
                else if (xfrm_Wizzard != null)
                {
                    if (xfrm_Wizzard.usrc_EditControlWizzard1.my_Control == this)
                    {
                        xfrm_Wizzard.usrc_EditControlWizzard1.Set_pic_Control(this.hc);
                    }
                }
                else
                {
                    MessageBox.Show("ERROR:HUDCMS:MyControl:CreateImageOfLinkedControls:(xfrm_Wizzard == null) && (xfrm_HUDCMS == null)");
                }
            }
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
