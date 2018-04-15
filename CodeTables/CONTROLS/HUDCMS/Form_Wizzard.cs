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
    public partial class Form_Wizzard : Form
    {
        public delegate bool delegate_WizControlInfo(Control ctrl, ref string title, ref List<HelpWizzardTag> TagForHelp_About, ref List<HelpWizzardTag> TagForHelp_Description);
        public static delegate_WizControlInfo WizControlInfo = null;


        internal Form_AddLinks frm_AddLinks = null;
        internal MyControl myroot = null;
        ArrayList roots = new ArrayList();
        internal SysImageListHelper helperControlType = null;
        internal ImageRenderer helperImageRenderer = null;

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
        internal hctrl hc = null;
        internal usrc_Help mH = null;
        internal MyControl MyControl_Selected = null;
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


        public Form_Wizzard(usrc_Help xH)
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

            SetHeader();

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

            this.Text = sHtmFileName + "  Number of controls=" + iAllCount.ToString();

            if (Properties.Settings.Default.GitExeFile.Length==0)
            {
                Properties.Settings.Default.UseGit = false;
                Properties.Settings.Default.Save();
            }
            chk_UseGit.Checked = Properties.Settings.Default.UseGit;

            this.chk_UseGit.CheckedChanged += new System.EventHandler(this.chk_UseGit_CheckedChanged);
            btn_SetGitExeFile.Enabled = Properties.Settings.Default.UseGit; 

        }

        private void SetHeader()
        {
            Header = Properties.Settings.Default.eng_Header;
            switch (HUDCMS_static.LanguageID)
            {
                case 0:
                    if (Properties.Settings.Default.eng_Header.Length == 0)
                    {
                        Properties.Settings.Default.eng_Header = Properties.Resources.eng_Header;
                        Properties.Settings.Default.Save();
                    }
                    Header = Properties.Settings.Default.eng_Header;
                    break;
                case 1:
                    if (Properties.Settings.Default.slo_Header.Length == 0)
                    {
                        Properties.Settings.Default.slo_Header = Properties.Resources.slo_Header;
                        Properties.Settings.Default.Save();
                    }
                    Header = Properties.Settings.Default.slo_Header;
                    break;
            }
        }

        void InitializeMyTreeListView(ref int iAllCount)
        {

            this.MyTreeListView.HierarchicalCheckboxes = false;
            this.MyTreeListView.HideSelection = false;
            this.MyTreeListView.UseCellFormatEvents = true;
            this.MyTreeListView.FormatRow += MyTreeListView_FormatRow;
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


            // You can change the way the connection lines are drawn by changing the pen
            TreeListView.TreeRenderer renderer = this.MyTreeListView.TreeColumnRenderer;
            renderer.LinePen = new Pen(Color.Firebrick, 0.5f);
            renderer.LinePen.DashStyle = DashStyle.Dot;

            //-------------------------------------------------------------------
            // Eveything after this is the same as the Explorer example tab --
            // nothing specific to the TreeListView. It doesn't have the grouping
            // delegates, since TreeListViews can't show groups.

            // Draw the system icon next to the name
            helperControlType = new SysImageListHelper(this.MyTreeListView);
            this.olvc_ControlType.ImageGetter = delegate (object x)
            {
                return helperControlType.GetControlTypeImageIndex(((MyControl)x).ControlType);
            };


            this.olvc_ControlImage.ImageGetter = delegate (object x)
            {
                int idx = helperImageRenderer.ImageList.Images.IndexOfKey(((MyControl)x).ControlUniqueName);
                return idx;
            };

            helperImageRenderer = new ImageRenderer();
            this.olvc_ControlImage.Renderer = helperImageRenderer;

            // List all drives as the roots of the tree
            myroot = CreateMyControls(0, 0, ref iAllCount, hc, null, ref helperControlType,  ref mH);
            SetLinks(myroot,ref helperImageRenderer);

            this.helperImageRenderer.Aspect = (System.Int32)0;

            roots.Add(myroot);
            this.MyTreeListView.Roots = roots;
        }

        private void MyTreeListView_FormatRow(object sender, FormatRowEventArgs e)
        {
            if (sender is TreeListView)
            {
                if (e.Item.RowObject is MyControl)
                {
                    MyControl myctrl = (MyControl)e.Item.RowObject;
                    if (myctrl.HasTitle)
                    {
                        e.Item.ForeColor = Color.Blue;
                    }
                    else
                    {
                        e.Item.ForeColor = Color.Black;
                    }
                }
            }
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

    

        internal static void SetLinks(MyControl ctrl, ref ImageRenderer helperImageRenderer)
        {
            if (ctrl !=null)
            {
                string[] xslink = ctrl.sLink;
                string ctrl_name = ctrl.ControlName;
                if (ctrl.HasLink)
                {
                    if (ctrl.Link == null)
                    {
                        ctrl.Link = new List<MyControl>();
                    }
                    else
                    {
                        ctrl.Link.Clear();
                    }
                    foreach (string sctrl_name in ctrl.sLink)
                    {
                        MyControl my_Control_Linked = null;
                        MyControl myparent = ctrl.Parent;


                        while (myparent != null)
                        {
                            if (MyControl.Find_my_Control(myparent, sctrl_name, ref my_Control_Linked))
                            {
                                ctrl.Link.Add(my_Control_Linked);
                                my_Control_Linked.bLinked = true;
                            }
                            myparent = myparent.Parent;
                        }
                    }
                    if (ctrl.Link.Count > 0)
                    {
                        ctrl.CreateImageOfLinkedControls();
                    }
                }
                foreach (MyControl c in ctrl.children)
                {
                    SetLinks(c,ref helperImageRenderer);
                }
                if (ctrl.hc.ctrlbmp != null)
                {
                    if (helperImageRenderer.ImageList == null)
                    {
                        helperImageRenderer.ImageList = new ImageList();
                        helperImageRenderer.ImageList.ImageSize = new Size(48, 48);
                    }
                    helperImageRenderer.ImageList.Images.Add(ctrl.GetControlUniqueName(), ctrl.hc.ctrlbmp);
                    //helperControlName.AddImageToCollection(GetControlName(), helperControlName.LargeImageList, hc.ctrlbmp);
                    ctrl.helperImageRenderer = helperImageRenderer;
                }
            }
        }

        internal bool SaveXHTML(string html_file,ref XDocument xh, ref string Err)
        {

            if (this.MyControl_Selected != null)
            {
                this.usrc_EditControl1.my_Control.ImageIncluded = this.usrc_EditControl1.usrc_EditControl_Image1.chk_ImageIncluded.Checked;
                if (this.usrc_EditControl1.usrc_EditControl_Image1.pic_Control.Image != null)
                {
                    this.usrc_EditControl1.my_Control.ImageOfControl = (Image)this.usrc_EditControl1.usrc_EditControl_Image1.pic_Control.Image.Clone();
                }
                else
                {
                    this.usrc_EditControl1.my_Control.ImageOfControl = null;
                }
                this.usrc_EditControl1.my_Control.HelpTitle = this.usrc_EditControl1.usrc_EditControl_Title1.fctb_CtrlTitle.Text;
                this.usrc_EditControl1.my_Control.HeadingTag = this.usrc_EditControl1.usrc_EditControl_Title1.cmb_HtmlTag.Text;
                this.usrc_EditControl1.my_Control.About = this.usrc_EditControl1.usrc_EditControl_About1.fctb_CtrlAbout.Text;
                this.usrc_EditControl1.my_Control.Description = this.usrc_EditControl1.usrc_EditControl_Description1.fctb_CtrlDescription.Text;
                this.usrc_EditControl1.my_Control.ImageCaption = this.usrc_EditControl1.usrc_EditControl_Image1.fctb_CtrlImageCaption.Text;
            }

            if (xh != null)
            {
                xh = null;
            }

            xh = new XDocument();

            html_html = new XElement("html");


            xh.AddFirst(html_html);

                if (myroot != null)
                {
                    if (myroot.hc.pForm != null)
                    {
                        html_head = new XElement("head");

                        AddStylesheet(ref html_head);

                        html_title = new XElement("title");

                        string sTitle = myroot.hc.pForm.Text;
                        if (sTitle.Length == 0)
                        {
                            sTitle = myroot.hc.pForm.GetType().ToString();
                        }
                        html_title.Value = sTitle;
                        html_body = new XElement("body");
                        //< iframe src = "../Header.html" style = "border:none; width="714" height="150"></iframe>

                        THeader = new XElement("THeader");
                        Header = fctb_Header.Text;
                        MyControl.ReplaceInnerXml(THeader, "THeader", Header);
                        html_body.Add(THeader);
                        html_head.Add(html_title);
                        html_html.Add(html_head);
                        html_html.Add(html_body);

                    }
                    else if (myroot.hc.ctrl != null)
                    {
                        html_head = new XElement("head");

                        AddStylesheet(ref html_head);

                        html_title = new XElement("title");

                        string sTitle = myroot.hc.ctrl.Text;
                        if (sTitle.Length == 0)
                        {
                            sTitle = myroot.hc.ctrl.GetType().ToString();
                        }
                        html_title.Value = sTitle;

                        html_body = new XElement("body");

                        THeader = new XElement("THeader");
                        Header = fctb_Header.Text;
                        MyControl.ReplaceInnerXml(THeader, "THeader", Header);
                        html_body.Add(THeader);

                        html_head.Add(html_title);
                        html_html.Add(html_head);
                        html_html.Add(html_body);

                    }
                    myroot.CreateNode(xh, ref html_body);
                }
                else
                {
                    MessageBox.Show("ERROR:myroot == null in Form_HUDCMS!");
                    return false;
                }

            //save xhtml
            if (SelectFile.usrc_SelectFile.CreateFolderIfNotExist(this, html_file,ref Err))
            {
                try
                {
                    xh.Save(html_file);
                    if (Properties.Settings.Default.UseGit)
                    {
                        string std_err = "";
                        string std_out = "";
                        switch (Git.CheckIfFileInRepository(html_file, ref std_out, ref std_err))
                        {
                            case Git.eCheckIfFileInRepository.FileIsNotInRepository:
                                if (!Git.Add(html_file, ref std_out, ref std_err))
                                {
                                    MessageBox.Show(std_err);
                                }
                                break;
                            case Git.eCheckIfFileInRepository.ERROR:
                                MessageBox.Show(std_err);
                                break;
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR:xh.Save(html_file) in Form_HUDCMS!\r\nException=" + ex.Message);
                    return false;

                }
            }
            else
            {
                MessageBox.Show("ERROR:SelectFile.usrc_SelectFile.CreateFolderIfNotExist(..) in Form_HUDCMS!");
                return false;

            }
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


        internal static MyControl  CreateMyControls( int level, int iCount, ref int iAllCount, hctrl xhc, MyControl xctrl, ref SysImageListHelper helperControlType,  ref usrc_Help mH)
        {


            MyControl myctrl = new MyControl();
            iAllCount++;
            iCount = 0;
            myctrl.ControlName = "uctrl_" + level.ToString() + "_" + iCount.ToString();
            myctrl.Init(mH, xhc, level, xctrl, ref helperControlType);
            if (xhc.subctrl != null)
            {
                MyControl child = null;
                foreach (hctrl hc in xhc.subctrl)
                {
                    if (hc.ctrl != null)
                    {
                        if (hc.ctrl.Visible)
                        {
                            child = CreateMyControls( level + 1, iCount++, ref iAllCount, hc, myctrl, ref helperControlType,  ref mH);
                            myctrl.children.Add(child);
                        }
                    }
                    else if (hc.dgvc != null)
                    {
                        child = CreateMyControls( level + 1, iCount++, ref iAllCount, hc, myctrl,ref helperControlType,  ref mH);
                        myctrl.children.Add(child);
                    }
                }
            }
            return myctrl;
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
                            mH.hlp_dlg.usrc_web_Help1.ShowSaved(null);
                            mH.hlp_dlg.usrc_web_Help1.ReloadHtml();
                        }
                    }
                    else if (mH.uwebHelp!=null)
                    {
                        mH.uwebHelp.ShowSaved(null);
                        mH.uwebHelp.ReloadHtml();
                    }

                }
                return true;

            }
            else
            {
                if (mH != null)
                {
                    if (mH.hlp_dlg != null)
                    {
                        if (mH.hlp_dlg.usrc_web_Help1 != null)
                        {
                            mH.hlp_dlg.usrc_web_Help1.ShowSaved(Err);
                        }
                    }
                    else if (mH.uwebHelp != null)
                    {
                        mH.uwebHelp.ShowSaved(Err);
                    }
                }
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
                    if (olvi.RowObject is MyControl)
                    {
                        MyControl myctrl = (MyControl)olvi.RowObject;
                        myctrl.xfrm_HUDCMS.MyControl_Selected = myctrl;
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

        private void MyTreeListView_SubItemChecking(object sender, SubItemCheckingEventArgs e)
        {

        }

        private void MyTreeListView_CellRightClick(object sender, CellRightClickEventArgs e)
        {
            if (sender is TreeListView)
            {
                if (e.Item.RowObject is MyControl)
                {
                    MyControl myctrl = (MyControl)e.Item.RowObject;
                }
            }
        }

        private void usrc_SelectHtmlFile_Load(object sender, EventArgs e)
        {

        }

        private void btn_SetGitExeFile_Click(object sender, EventArgs e)
        {
            if (GetGitSettings())
            {
                chk_UseGit.Checked = true;
            }
            else
            {
                chk_UseGit.Checked = false;
            }
        }

        private bool GetGitSettings()
        {
            Form_SetGitExeFile frm_SetGitExeFile = new Form_SetGitExeFile();
            frm_SetGitExeFile.ShowDialog();
            return Properties.Settings.Default.GitExeFile.Length > 0;
        }

        private void chk_UseGit_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_UseGit.Checked)
            {
                string sGitExeFile = Properties.Settings.Default.GitExeFile;
                if (sGitExeFile.Length == 0)
                {
                    if (!GetGitSettings())
                    {
                        chk_UseGit.Checked = false;
                    }
                }
            }
            Properties.Settings.Default.UseGit = chk_UseGit.Checked;
            Properties.Settings.Default.Save();
            btn_SetGitExeFile.Enabled = Properties.Settings.Default.UseGit;
        }

        private void btn_ZIP_Click(object sender, EventArgs e)
        {
            Form_ZIP frm_zip = new Form_ZIP();
            frm_zip.ShowDialog(this);
        }

        private void btn_Wizzard_Click(object sender, EventArgs e)
        {
            if (myroot != null)
            {
                if (myroot.hc != null)
                {
                    Control xctrl = null;
                    if (myroot.hc.pForm != null)
                    {
                        xctrl = myroot.hc.pForm;
                    }
                    else if (myroot.hc.ctrl != null)
                    {
                        xctrl = myroot.hc.ctrl;
                    }
                    if (xctrl != null)
                    {
                        if (xctrl.Tag!=null)
                        {
                            if (xctrl.Tag is HelpWizzardTag)
                            {
                                HelpWizzardTag hlpwt = (HelpWizzardTag)xctrl.Tag;
                                if (hlpwt.ShowWizzard!=null)
                                {
                                    hlpwt.ShowWizzard(xctrl);
                                }
                            }

                        }
                    }
                }
            }
        }
    }
}

