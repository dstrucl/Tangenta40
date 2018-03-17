using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using BrightIdeasSoftware;
using FastColoredTextBoxNS;
using UniqueControlNames;

namespace HUDCMS
{
    public partial class Form_HUDCMS : Form
    {
        ArrayList roots = new ArrayList();
        SysImageListHelper helperControlType = null;
        ImageRenderer helperImageRenderer = null;

        public const string HTML_index = "index";
        public const string HTML_download = "download";
        public const string HTML_Tangenta = "Tangenta";
        public const string HTML_News = "News";
        public const string HTML_About = "About";
        public const string HTML_Invoice= "Invoice";
        public const string HTML_ProformaInvoice = "ProformaInvoice";
        public const string HTML_InstallationFinished = "InstallationFinished";
        public const string HTML_Stock = "Stock";
        public const string HTML_PriceList = "PriceList";
        public const string HTML_InvoicingOverview = "InvoicingOverview";
        public const string HTML_Support = "Support";

        public const string CSS_GeneralHelp = "GeneralHelp";
        public const string CSS_TIndex = "TIndex";
        public const string CSS_style = "style";
        public const string CSS_reset = "reset";

        private List<GeneralHelpFile> generalHelpFile_List = null;
        private List<GeneralHelpFile> generalStyleFile_List = null;
        private Form_FCTB_Editor frm_FCTB_Editor = null;
        private hctrl hc = null;
        private usrc_Help mH = null;
        internal usrc_Control usrc_Control_Selected = null;
        XDocument xhtml = null;
        internal XDocument xhtml_Loaded = null;

        private string m_Header = "";

        internal string Header
        {
            get { return m_Header; }
            set { m_Header = value;
                fctb_Header.Text = m_Header;
                }
        }

        XElement html_html = null;
        XElement html_head = null;
        XElement html_title = null;
        XElement html_body = null;
        XElement THeader = null;


        public Form_HUDCMS(usrc_Help xH)
        {
            UniqueControlName uctrln = new UniqueControlName();
            InitializeComponent();
            mH = xH;
            hc = new hctrl(mH.pForm, uctrln);
            usrc_SelectHtmlFile.InitialDirectory = Path.GetDirectoryName(mH.LocalHtmlFile);
            usrc_SelectHtmlFile.FileName = mH.LocalHtmlFile;
            usrc_SelectHtmlFile.Title = "Save HTML file";
            usrc_SelectHtmlFile.Text = "HTML file:";
            this.usrc_SelectHtmlFile.DefaultExtension = "html";
            this.usrc_SelectHtmlFile.Filter = "HTML files (*.html)|*.html|All files (*.*)|*.*";

            string sStylePath = Path.GetDirectoryName(mH.LocalHtmlFile);
            int index_of_last_map = sStylePath.LastIndexOf('\\');
            if (index_of_last_map > 0)
            {
                sStylePath = sStylePath.Substring(0, index_of_last_map);
            }
            usrc_SelectStyleFile.InitialDirectory = sStylePath;

            usrc_SelectStyleFile.FileName = sStylePath + "\\style.css";
            usrc_SelectStyleFile.Title = "Save style file";
            usrc_SelectStyleFile.Text = "Style file:";

       
        }

        private void Form_HUDCMS_Load(object sender, EventArgs e)
        {

            if (Properties.Settings.Default.Header == null)
            {
                Properties.Settings.Default.Header = Properties.Resources.Header;
                Properties.Settings.Default.Save();
            }
            else if (Properties.Settings.Default.Header.Length == 0)
            {
                Properties.Settings.Default.Header = Properties.Resources.Header;
                Properties.Settings.Default.Save();
            }

            Header = Properties.Settings.Default.Header;

            SetGeneralHelpFiles();

            string sHtmFileName = usrc_SelectHtmlFile.FileName;
            try
            {
                xhtml_Loaded = XDocument.Load(sHtmFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: XDocument.Load file=\"" + sHtmFileName + "\" failed :Exception = " + ex.Message);
            }

            int y = 2;
            int iAllCount = 0;

            InitializeMyTreeListView(ref iAllCount);
            //UserControl root = CreateControls(ref y, 0,0,ref iAllCount, hc, null);
            //this.panel1.Controls.Add(root);

            this.Text = sHtmFileName + "  Number of controls=" + iAllCount.ToString();
            HideLinks();
            SetLinks(this.panel1);
        }

        void InitializeMyTreeListView(ref int iAllCount)
        {

            this.MyTreeListView.HierarchicalCheckboxes = true;
            this.MyTreeListView.HideSelection = false;
            //this.MyTreeListView.RowHeight = 32;
            this.MyTreeListView.CanExpandGetter = delegate (object x) {
                return ((MyControl)x).HasChildren;
            };
            this.MyTreeListView.ChildrenGetter = delegate (object x) {
                MyControl myControl = (MyControl)x;
                try
                {
                    return myControl.GetChildren();
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show(this, ex.Message, "ObjectListViewDemo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return new ArrayList();
                }
            };

            checkBox11.Checked = this.MyTreeListView.HierarchicalCheckboxes;

            //this.treeListView.CheckBoxes = false;

            // You can change the way the connection lines are drawn by changing the pen
            TreeListView.TreeRenderer renderer = this.MyTreeListView.TreeColumnRenderer;
            renderer.LinePen = new Pen(Color.Firebrick, 0.5f);
            renderer.LinePen.DashStyle = DashStyle.Dot;

            //-------------------------------------------------------------------
            // Eveything after this is the same as the Explorer example tab --
            // nothing specific to the TreeListView. It doesn't have the grouping
            // delegates, since TreeListViews can't show groups.

            // Draw the system icon next to the name
            //this.olvc_ControlName.ImageGetter = null;
            helperControlType = new SysImageListHelper(this.MyTreeListView);
            //helper.AddImageToCollection("root1", helper.LargeImageList, Properties.Resources.nav_CommandLineHelp_Form);
            //helper.AddImageToCollection("root2", helper.LargeImageList, Properties.Resources.nav_CommandLineHelp_Form_grp_CommandLineParameters);
            //helper.AddImageToCollection("r1_ch1", helper.LargeImageList, Properties.Resources.limeleaf);
            //helper.AddImageToCollection("r1_ch2", helper.LargeImageList, Properties.Resources.coffee);
            this.olvc_ControlType.ImageGetter = delegate (object x)
            {
                return helperControlType.GetControlTypeImageIndex(((MyControl)x).ControlType);
            };

            //this.olvc_ControlName.ImageGetter = delegate (object x)
            //{
            //    return helperControlName.GetControlImageIndex(((MyControl)x).ControlName);
            //};

            this.olvc_ControlImage.ImageGetter = delegate (object x)
            {
                int idx = helperImageRenderer.ImageList.Images.IndexOfKey(((MyControl)x).ControlName);
                return idx;
            };

            // Show the size of files as GB, MB and KBs. Also, group them by
            // some meaningless divisions
            //this.treeColumnSize.AspectGetter = delegate (object x) {
            //    MyControl myControl = (MyControl)x;

            //    if (!myControl.HasChildren)
            //        return (long)-1;

            //    try
            //    {
            //        return 27061962;
            //    }
            //    catch (System.IO.FileNotFoundException)
            //    {
            //        // Mono 1.2.6 throws this for hidden files
            //        return (long)-2;
            //    }
            //};
            //this.treeColumnSize.AspectToStringConverter = delegate (object x) {
            //    if ((long)x == -1) // folder
            //        return "";

            //    return this.FormatFileSize((long)x);
            //};

            //// Show the system description for this object
            //this.treeColumnFileType.AspectGetter = delegate (object x) {
            //    return ShellUtilities.GetFileType(((MyFileSystemInfo)x).FullName);
            //};

            //// Show the file attributes for this object
            //this.treeColumnAttributes.AspectGetter = delegate (object x) {
            //    return ((MyFileSystemInfo)x).Attributes;
            //};
            helperImageRenderer = new ImageRenderer();
            this.olvc_ControlImage.Renderer = helperImageRenderer;

            // List all drives as the roots of the tree
            MyControl myroot = CreateMyControls(0, 0, ref iAllCount, hc, null, ref helperControlType, ref helperImageRenderer);
            this.helperImageRenderer.Aspect = (System.Int32)0;

            roots.Add(myroot);
            this.MyTreeListView.Roots = roots;
        }



        private void SetGeneralHelpFiles()
        {
            if (generalHelpFile_List==null)
            {
                generalHelpFile_List = new List<GeneralHelpFile>();
            }
            else
            {
                generalHelpFile_List.Clear();
            }

            string fext = ".html";
            generalHelpFile_List.Add(new GeneralHelpFile(HUDCMS_static.Local_ApplicationVersionAndLangugagePath, HTML_News, fext));
            generalHelpFile_List.Add(new GeneralHelpFile(HUDCMS_static.Local_ApplicationVersionAndLangugagePath, HTML_index, fext));
            generalHelpFile_List.Add(new GeneralHelpFile(HUDCMS_static.Local_ApplicationVersionAndLangugagePath, HTML_download, fext));
            generalHelpFile_List.Add(new GeneralHelpFile(HUDCMS_static.Local_ApplicationVersionAndLangugagePath, HTML_Tangenta, fext));
            generalHelpFile_List.Add(new GeneralHelpFile(HUDCMS_static.Local_ApplicationVersionAndLangugagePath, HTML_About, fext));
            generalHelpFile_List.Add(new GeneralHelpFile(HUDCMS_static.Local_ApplicationVersionAndLangugagePath, HTML_InstallationFinished, fext));
            generalHelpFile_List.Add(new GeneralHelpFile(HUDCMS_static.Local_ApplicationVersionAndLangugagePath, HTML_Invoice, fext));
            generalHelpFile_List.Add(new GeneralHelpFile(HUDCMS_static.Local_ApplicationVersionAndLangugagePath, HTML_ProformaInvoice, fext));
            generalHelpFile_List.Add(new GeneralHelpFile(HUDCMS_static.Local_ApplicationVersionAndLangugagePath, HTML_Stock, fext));
            generalHelpFile_List.Add(new GeneralHelpFile(HUDCMS_static.Local_ApplicationVersionAndLangugagePath, HTML_PriceList, fext));
            generalHelpFile_List.Add(new GeneralHelpFile(HUDCMS_static.Local_ApplicationVersionAndLangugagePath, HTML_InvoicingOverview, fext));
            generalHelpFile_List.Add(new GeneralHelpFile(HUDCMS_static.Local_ApplicationVersionAndLangugagePath, HTML_Tangenta, fext));
            generalHelpFile_List.Add(new GeneralHelpFile(HUDCMS_static.Local_ApplicationVersionAndLangugagePath, HTML_Support, fext));
            foreach (GeneralHelpFile ghp in generalHelpFile_List)
            {
                ComboBox_Recent.myIteM mitm = new ComboBox_Recent.myIteM();
                mitm.item = ghp.FileName;
                mitm.Value = ghp.Name;
                cmbr_GeneralHelpFiles.Items.Add(mitm);
            }
            cmbr_GeneralHelpFiles.SelectedIndex = 0;

            if (generalStyleFile_List == null)
            {
                generalStyleFile_List = new List<GeneralHelpFile>();
            }
            else
            {
                generalStyleFile_List.Clear();
            }
            fext = ".css"; 
            generalStyleFile_List.Add(new GeneralHelpFile(HUDCMS_static.Local_ApplicationVersionAndLangugagePath, CSS_GeneralHelp,fext));
            generalStyleFile_List.Add(new GeneralHelpFile(HUDCMS_static.Local_ApplicationVersionAndLangugagePath, CSS_TIndex, fext));
            generalStyleFile_List.Add(new GeneralHelpFile(HUDCMS_static.Local_ApplicationVersionAndLangugagePath, CSS_style, fext));
            generalStyleFile_List.Add(new GeneralHelpFile(HUDCMS_static.Local_ApplicationVersionAndLangugagePath, CSS_reset, fext));
            foreach (GeneralHelpFile ghs in generalStyleFile_List)
            {
                ComboBox_Recent.myIteM mitm = new ComboBox_Recent.myIteM();
                mitm.item = ghs.FileName;
                mitm.Value = ghs.Name;
                cmbr_GeneralStyleFiles.Items.Add(mitm);
            }
            cmbr_GeneralStyleFiles.SelectedIndex = 0;
        }

        private void SetLinks(Control ctrl)
        {
            if (ctrl is usrc_Control)
            {
                string[] xslink = ((usrc_Control)ctrl).sLink;
                string ctrl_name = ((usrc_Control) ctrl).ControlName;
                if (((usrc_Control)ctrl).HasLink)
                {
                    if (((usrc_Control)ctrl).Link ==null)
                    {
                        ((usrc_Control)ctrl).Link = new List<usrc_Control>();
                    }
                    else
                    {
                        ((usrc_Control)ctrl).Link.Clear();
                    }
                    foreach (string sctrl_name in ((usrc_Control)ctrl).sLink)
                    {
                        usrc_Control xusrc_Control_Linked = null; 
                        if (usrc_Control.Find_usrc_Control(this.panel1, sctrl_name,ref xusrc_Control_Linked))
                        {
                            ((usrc_Control)ctrl).Link.Add(xusrc_Control_Linked);
                            xusrc_Control_Linked.bLinked = true;
                        }
                    }
                    ((usrc_Control)ctrl).CreateImageOfLinkedControls();
                }
            }
            foreach (Control c in ctrl.Controls)
            {
                if (c is usrc_Control)
                {
                    SetLinks(c);
                }
            }
        }

        internal bool SaveXHTML(string html_file,ref XDocument xh, ref string Err)
        {
            if (this.usrc_Control_Selected!=null)
            {

                this.usrc_EditControl1.m_usrc_Control.Title = this.usrc_EditControl1.usrc_EditControl_Title1.fctb_CtrlTitle.Text;
                this.usrc_EditControl1.m_usrc_Control.HeadingTag = this.usrc_EditControl1.usrc_EditControl_Title1.cmb_HtmlTag.Text;
                this.usrc_EditControl1.m_usrc_Control.About = this.usrc_EditControl1.usrc_EditControl_About1.fctb_CtrlAbout.Text;
                this.usrc_EditControl1.m_usrc_Control.Description = this.usrc_EditControl1.usrc_EditControl_Description1.fctb_CtrlDescription.Text;
                this.usrc_EditControl1.m_usrc_Control.ImageCaption = this.usrc_EditControl1.usrc_EditControl_Image1.fctb_CtrlImageCaption.Text;
            }
            if (xh != null)
            {
                xh = null;
            }

            xh = new XDocument();

            html_html = new XElement("html");




            xh.AddFirst(html_html);

            foreach (Control c in this.panel1.Controls)
            {
                if (c is usrc_Control)
                {
                    if (html_head == null)
                    {
                        if (((usrc_Control)c).hc.pForm != null)
                        {
                            html_head = new XElement("head");

                            AddStylesheet(ref html_head);

                            html_title = new XElement("title");

                            string sTitle = ((usrc_Control)c).hc.pForm.Text;
                            if (sTitle.Length == 0)
                            {
                                sTitle = ((usrc_Control)c).hc.pForm.GetType().ToString();
                            }
                            html_title.Value = sTitle;
                            html_body = new XElement("body");
                            //< iframe src = "../Header.html" style = "border:none; width="714" height="150"></iframe>

                            THeader = new XElement("THeader");
                            Header = fctb_Header.Text;
                            usrc_Control.ReplaceInnerXml(THeader, "THeader", Header);
                            html_body.Add(THeader);
                            html_head.Add(html_title);
                            html_html.Add(html_head);
                            html_html.Add(html_body);

                        }
                        else if (((usrc_Control)c).hc.ctrl != null)
                        {
                            html_head = new XElement("head");

                            AddStylesheet(ref html_head);

                            html_title = new XElement("title");

                            string sTitle = ((usrc_Control)c).hc.ctrl.Text;
                            if (sTitle.Length == 0)
                            {
                                sTitle = ((usrc_Control)c).hc.ctrl.GetType().ToString();
                            }
                            html_title.Value = sTitle;

                            html_body = new XElement("body");

                            THeader = new XElement("THeader");
                            Header = fctb_Header.Text;
                            usrc_Control.ReplaceInnerXml(THeader, "THeader", Header);
                            html_body.Add(THeader);

                            html_head.Add(html_title);
                            html_html.Add(html_head);
                            html_html.Add(html_body);

                        }
                    }
                    ((usrc_Control)c).CreateNode(xh, ref html_body);
                }
            }

            //save xhtml
            if (SelectFile.usrc_SelectFile.CreateFolderIfNotExist(this, html_file,ref Err))
            {
                try
                {
                    xh.Save(html_file);
                    return true;
                }
                catch (Exception ex)
                {

                }
            }


            return false;
        }

        private void AddStylesheet(ref XElement html_head)
        {
            if (html_head==null)
            {
                html_head = new XElement("head");
            }
            XElement html_link_stylesheet = new XElement("link");
            XAttribute attribute_html_link_stylesheet_rel = new XAttribute("rel", "stylesheet");
            XAttribute attribute_html_link_stylesheet_type = new XAttribute("type", "text/css");
            string styleFile = this.usrc_SelectStyleFile.FileName;
            if (styleFile.Length==0)
            {
                this.usrc_SelectStyleFile.FileName =HUDCMS_static.LocalHelpPath+ "style.css";
                styleFile = this.usrc_SelectStyleFile.FileName;
            }

            if (!File.Exists(styleFile))
            {
                if (MessageBox.Show(this, "Style file :\"" + styleFile + "\" does not exist!\r\nCreate it from default stylesheet?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        File.WriteAllText(styleFile, Properties.Resources.DefaultStyle);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, "Style file :\"" + styleFile + "\" noit created. Exception=" + ex.Message);
                    }
                }
            }

            string shtml_file = this.usrc_SelectHtmlFile.FileName;

            System.Uri uri1 = new Uri(styleFile);

            System.Uri uri2 = new Uri(shtml_file);

            Uri relativeUri = uri2.MakeRelativeUri(uri1);
            string styleFile_Relative = relativeUri.ToString();


            XAttribute attribute_html_link_stylesheet_href = new XAttribute("href", styleFile_Relative);
            html_link_stylesheet.Add(attribute_html_link_stylesheet_rel);
            html_link_stylesheet.Add(attribute_html_link_stylesheet_type);
            html_link_stylesheet.Add(attribute_html_link_stylesheet_href);
            html_head.Add(html_link_stylesheet);
        }


        private MyControl CreateMyControls( int level, int iCount, ref int iAllCount, hctrl xhc, MyControl xctrl, ref SysImageListHelper helperControlType, ref ImageRenderer helperImageRenderer)
        {


            MyControl uctrl = new MyControl();
            iAllCount++;
            iCount = 0;
            uctrl.Name = "uctrl_" + level.ToString() + "_" + iCount.ToString();
            uctrl.Init(mH, xhc, level, ref helperControlType, ref helperImageRenderer);
            if (xhc.subctrl != null)
            {
                MyControl child = null;
                foreach (hctrl hc in xhc.subctrl)
                {
                    if (hc.ctrl != null)
                    {
                        if (hc.ctrl.Visible)
                        {
                            child = CreateMyControls( level + 1, iCount++, ref iAllCount, hc, uctrl, ref helperControlType, ref helperImageRenderer);
                            uctrl.children.Add(child);
                            child.Parent = uctrl;
                        }
                    }
                    else if (hc.dgvc != null)
                    {
                        child = CreateMyControls( level + 1, iCount++, ref iAllCount, hc, uctrl,ref helperControlType, ref helperImageRenderer);
                        uctrl.children.Add(child);
                        child.Parent = uctrl;
                    }
                }
            }
            return uctrl;
        }



        private usrc_Control CreateControls(ref int y, int level, int iCount,ref int iAllCount, hctrl xhc,UserControl xctrl)
        {

           
            usrc_Control uctrl = new usrc_Control();
            iAllCount++;
            iCount = 0;
            uctrl.Name = "uctrl_" + level.ToString() + "_" + iCount.ToString();
            uctrl.Init(mH, xhc, level);
            uctrl.Top = y;
            uctrl.Left = 3;
            if (xctrl != null)
            {
                uctrl.Width = xctrl.Width - uctrl.Left - 3;
            }
            else
            {
                uctrl.Width = this.panel1.Width - uctrl.Left - 3;
            }
            
            uctrl.Visible = true;
            uctrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            if (xhc.subctrl != null)
            {
                int ysub = uctrl.Height + 4;
                usrc_Control child = null;
                foreach (hctrl hc in xhc.subctrl)
                {
                    if (hc.ctrl != null)
                    {
                        if (hc.ctrl.Visible)
                        {
                           child= CreateControls(ref ysub, level + 1, iCount++, ref iAllCount, hc, uctrl);
                           uctrl.Controls.Add(child);
                            child.Parent = uctrl;
                        }
                    }
                    else if (hc.dgvc != null)
                    {
                        child = CreateControls(ref ysub, level + 1, iCount++, ref iAllCount, hc, uctrl);
                        uctrl.Controls.Add(child);
                        child.Parent = uctrl;
                    }
                }
                uctrl.Height = ysub;
            }
            y += uctrl.Height + 4;
            return uctrl;
        }

        internal void ShowAvailableLinks()
        {
            usrc_Control xsel = this.usrc_Control_Selected;
            GetAvailableParentLinks(xsel, xsel.Parent, ref xsel.AvailableLink);
            
        }

        private bool GetAvailableParentLinks(usrc_Control xsel, Control xsel_parent, ref List<usrc_Control> link)
        {
            usrc_Control owner_usrc_Control = null;
            bool bAtLeastOneVisible = false;
            if (xsel_parent != null)
            {
                if (xsel_parent is usrc_Control)
                {
                    owner_usrc_Control = (usrc_Control)xsel_parent;
                }
            }
            if (owner_usrc_Control!=null)
            {
                foreach (Control ctrl in owner_usrc_Control.Controls)
                {
                    if (ctrl is usrc_Control)
                    {
                        if (ctrl != xsel)
                        {
                          if (VisbleOnOwnerControl(owner_usrc_Control, (usrc_Control)ctrl))
                            {
                                if (link==null)
                                {
                                    link = new List<usrc_Control>();
                                }
                                link.Add((usrc_Control)ctrl);
                                bAtLeastOneVisible = true;
                            }
                        }
                    }
                }
                return bAtLeastOneVisible;
            }
            else
            {
                return false;
            }
        }

        private bool VisbleOnOwnerControl(usrc_Control owner_usrc_Control, usrc_Control ctrl)
        {
            hctrl owner_hc = owner_usrc_Control.hc;
            hctrl xhc = ctrl.hc;
            if (InsideOwner(owner_hc, xhc))
            {
                ctrl.btn_Link.Visible = true;
                return true;
            }
            else
            {
                ctrl.btn_Link.Visible = false;
                return false;
            }
        }

        private bool InsideOwner(hctrl owner_hc, hctrl xhc)
        {
            int owner_cx = GetWidth(owner_hc);
            if (owner_cx > 0)
            {
                int owner_cy = GetHeight(owner_hc);
                if (owner_cy > 0)
                {
                    int ctrl_cx = GetWidth(xhc);
                    if (ctrl_cx > 0)
                    {
                        int ctrl_cy = GetHeight(xhc);
                        if (ctrl_cy > 0)
                        {
                            int ctrl_x = GetX(xhc);
                            if (ctrl_x > 0)
                            {
                                int ctrl_y = GetY(xhc);
                                if (ctrl_y > 0)
                                {
                                    if (XPercentInside(ctrl_x + ctrl_cx, owner_cx, 80) && (XPercentInside(ctrl_y + ctrl_cy, owner_cy, 80)))
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        private bool XPercentInside(int plength, int xwidth, int ipercent)
        {
            if (plength<xwidth)
            {
                // totaly inside
                return true;
            }
            else
            {
                int reduced_length = (plength * ipercent) / 100;
                if (reduced_length < xwidth)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private int GetY(hctrl xhc)
        {
            if (xhc.ctrl != null)
            {
                return xhc.ctrl.Top;
            }
            else if (xhc.pForm != null)
            {
                return xhc.pForm.Top;
            }
            else
            {
                MessageBox.Show("ERROR:HUDCMS:Form_HUDCMS:GetY:(xhc.ctrl==null)&&(xhc.pForm == null)");
                return -1;
            }
        }

        private int GetX(hctrl xhc)
        {
            if (xhc.ctrl != null)
            {
                return xhc.ctrl.Left;
            }
            else if (xhc.pForm != null)
            {
                return xhc.pForm.Left;
            }
            else
            {
                MessageBox.Show("ERROR:HUDCMS:Form_HUDCMS:GetX:(xhc.ctrl==null)&&(xhc.pForm == null)");
                return -1;
            }
        }

        private int GetHeight(hctrl xhc)
        {
            if (xhc.ctrl!=null)
            {
                return xhc.ctrl.Height;
            }
            else if (xhc.pForm != null)
            {
                return xhc.pForm.Height;
            }
            else
            {
                MessageBox.Show("ERROR:HUDCMS:Form_HUDCMS:GetHeight:(xhc.ctrl==null)&&(xhc.pForm == null)");
                return -1;
            }
        }

        private int GetWidth(hctrl xhc)
        {
            if (xhc.ctrl != null)
            {
                return xhc.ctrl.Width;
            }
            else if (xhc.pForm != null)
            {
                return xhc.pForm.Width;
            }
            else
            {
                MessageBox.Show("ERROR:HUDCMS:Form_HUDCMS:GetWidth:(xhc.ctrl==null)&&(xhc.pForm == null)");
                return -1;
            }
        }

        internal void HideLinks(Control xctrl)
        {
            foreach (Control ctrl in xctrl.Controls)
            {
                if (ctrl is usrc_Control)
                {
                    ((usrc_Control)ctrl).btn_Link.Visible = false;
                    HideLinks(ctrl);
                }
            }
        }

        internal void HideLinks()
        {
            foreach (Control ctrl in this.panel1.Controls)
            {
                if (ctrl is usrc_Control)
                {
                    ((usrc_Control)ctrl).btn_Link.Visible = false;
                    HideLinks(ctrl);
                }
            }
        }


        private bool usrc_SelectHtmlFile_SaveFile(string FileName, ref string Err)
        {
            if (SaveXHTML(FileName,ref this.xhtml, ref Err))
            {
                if (mH!=null)
                {
                    if (mH.hlp_dlg != null)
                    {
                        if (mH.hlp_dlg.usrc_web_Help1 != null)
                        {
                            mH.hlp_dlg.usrc_web_Help1.ReloadHtml();
                        }
                    }
                }
                return true;

            }
            else
            {
                return false;
            }
        }

        private void EditFile(string xFileName)
        {
            if (frm_FCTB_Editor == null)
            {
                frm_FCTB_Editor = new Form_FCTB_Editor();
                frm_FCTB_Editor.Owner = this;
            }
            if (frm_FCTB_Editor.IsDisposed)
            {
                frm_FCTB_Editor = new Form_FCTB_Editor();
                frm_FCTB_Editor.Owner = this;
            }
            frm_FCTB_Editor.CreateTab(xFileName);
            frm_FCTB_Editor.Show();
        }

        private bool usrc_SelectHtmlFile_EditFile(string xFileName)
        {
            EditFile(xFileName);
            return true;
        }

        private bool usrc_SelectStyleFile_EditFile(string xFileName)
        {
            EditFile(xFileName);
            return true;
        }


        private void btn_EditGeneralHelpFile_Click(object sender, EventArgs e)
        {
            string sFileName = this.cmbr_GeneralHelpFiles.Text;
            if (sFileName.Length > 0)
            {
                if (File.Exists(sFileName))
                {
                    EditFile(sFileName);
                }
                else
                {
                    string s = null;
                    //check if GeneralHelp.css
                    string sGeneralHelpStyleFile = GeneralHelpFile.SetFile(HUDCMS_static.Local_ApplicationVersionAndLangugagePath, "GeneralHelp", ".css");
                    if (!File.Exists(sGeneralHelpStyleFile))
                    {
                        s = Properties.Resources.GeneralHelpStyle;
                        try
                        {
                            File.WriteAllText(sGeneralHelpStyleFile, s);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("ERROR: Can not write \"" + sGeneralHelpStyleFile + "\"\r\nException = " + ex.Message);
                        }
                    }
                    try
                    {
                        string sfile = null;
                        s = Properties.Resources.GeneralHelpTemplate;
                        int iLastIndexOfFolder = sFileName.LastIndexOf('/');
                        if (iLastIndexOfFolder > 0)
                        {
                            string sf = sFileName.Substring(iLastIndexOfFolder);
                            int iIndexOfExtension = sf.IndexOf('.');
                            if (iIndexOfExtension > 0)
                            {
                                sfile = sf.Substring(0, iIndexOfExtension);
                            }
                        }
                        if (sfile != null)
                        {
                            s = s.Replace("(@@Title@@)", sfile);
                            s = s.Replace("(@@About@@)", HUDCMS_static.slng_WriteSomethingAbout + sfile);
                        }
                        File.WriteAllText(sFileName, s);
                        EditFile(sFileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR: Can not write \"" + sFileName + "\"\r\nException = " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Help file name is not defined !");
            }
        }

        private void btn_EditGeneralStyles_Click(object sender, EventArgs e)
        {
            string sFileName = this.cmbr_GeneralStyleFiles.Text;
            if (sFileName.Length > 0)
            {
                if (File.Exists(sFileName))
                {
                    EditFile(sFileName);
                }
                else
                {
                    string s = null;
                    s = Properties.Resources.GeneralHelpStyle;
                    try
                    {
                        File.WriteAllText(sFileName, s);
                        EditFile(sFileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR: Can not write \"" + sFileName + "\"\r\nException = " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Style File name is not defined !");
            }
        }

        private void MyTreeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is TreeListView)
            {
                TreeListView treeListView = (TreeListView)sender;
                int selectedindex = treeListView.SelectedIndex;
                OLVListItem olvi = treeListView.SelectedItem;
                if (olvi != null)
                {
                    MyControl myctrl = (MyControl)olvi.RowObject;

                    myctrl.xfrm_HUDCMS.usrc_EditControl1.Enabled = true;
                    myctrl.xfrm_HUDCMS.usrc_EditControl1.Init(myctrl);
                    if (hc.dgvc == null)
                    {
                        //xfrm_HUDCMS.HideLinks();
                        //xfrm_HUDCMS.ShowAvailableLinks();
                    }
                }
            }
        }
    }
}

