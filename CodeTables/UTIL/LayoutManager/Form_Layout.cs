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

namespace LayoutManager
{
    public partial class Form_Layout : Form
    {
        private Screen screen = null;
        Form pForm = null;
        private string screen_layout_folder = null;
        private string screen_layout_file = null;

        private bool designchanged = false;
        public bool DesignChanged
        {
            get
            {
                return designchanged;
            }
        }

        public enum eSetLayoutResult { OK, SCRREN_LAYOUT_FILE_DOES_NOT_EXIST,CANNOT_SET_SCRREN_LAYOUT_FOLDER,EXCEPTION_ERROR };
        public static DataColumn dcol_ControlName = null;
        public static DataColumn dcol_Left = null;
        public static DataColumn dcol_Top = null;
        public static DataColumn dcol_Width = null;
        public static DataColumn dcol_Height = null;
        public static DataColumn dcol_AnchorLeft = null;
        public static DataColumn dcol_AnchorRight = null;
        public static DataColumn dcol_AnchorTop = null;
        public static DataColumn dcol_AnchorBottom = null;
        public static DataColumn dcol_ForeColor = null;
        public static DataColumn dcol_BackColor = null;

        DataTable dtControlLayout = null;

        private string layoutname = null;
        public string LayoutName
        {
            get
            {
                return layoutname;
            }
            set
            {
                layoutname = value;
            }
        }
        private string localBookmarkDicFile = null;

        //internal HelpWizzardTag hlpwiztag = null;

        internal string LocalXmlFileName = null;

        //internal Form_AddLinks frm_AddLinks = null;
        internal MyControl myroot = null;
        ArrayList roots = new ArrayList();
        internal SysImageListHelper helperControlType = null;
        internal ImageRenderer helperImageRenderer = null;

        //public const string HTML_index = "index";
        //public const string HTML_download = "download";
        //public const string HTML_Tangenta = "Tangenta";
        //public const string HTML_News = "News";
        //public const string HTML_About = "About";
        //public const string HTML_Invoice= "Invoice";
        //public const string HTML_ProformaInvoice = "ProformaInvoice";
        //public const string HTML_InstallationFinished = "InstallationFinished";
        //public const string HTML_Stock = "Stock";
        //public const string HTML_PriceList = "PriceList";
        //public const string HTML_InvoicingOverview = "InvoicingOverview";
        //public const string HTML_Support = "Support";

        //public const string CSS_GeneralHelp = "GeneralHelp";
        //public const string CSS_TIndex = "TIndex";
        //public const string CSS_style = "style";
        //public const string CSS_reset = "reset";

        //private List<GeneralHelpFile> generalHelpFile_List = null;
        //private List<GeneralHelpFile> generalStyleFile_List = null;
        //private Form_FCTB_Editor frm_FCTB_Editor = null;
        internal hctrl hc = null;
        //internal usrc_Help mH = null;
        internal MyControl MyControl_Selected = null;
        //XDocument xhtml = null;
        internal XDocument xhtml_Loaded = null;

        //private string m_Header = "";



        //XElement html_html = null;
        //XElement html_head = null;
        //XElement html_title = null;
        //XElement html_body = null;
        //XElement THeader = null;


        //public Form_Layout(usrc_Help xH)

        
        public Form_Layout(Screen xscreen, Form xpForm)
        {
            InitializeComponent();
            screen = xscreen;
            pForm = xpForm;
            LayoutName = getLayoutName(screen, pForm);
            this.cmb_ScreenResolution.Text = LayoutName;
            UniqueControlName uctrln = new UniqueControlName();

            hc = new hctrl(pForm, uctrln);

            //hlpwiztag = null;
            //if (hc.pForm != null)
            //{
            //    if (hc.pForm.Tag != null)
            //    {
            //        if (hc.pForm.Tag is HelpWizzardTag)
            //        {
            //            hlpwiztag = (HelpWizzardTag)hc.pForm.Tag;
            //        }
            //    }
            //}

            //usrc_SelectXMLFile.InitialDirectory = Path.GetDirectoryName(mH.LocalHtmlFile);
            //int indexof_filesufix_plus_html_extension = mH.LocalHtmlFile.IndexOf(hlpwiztag.FileSuffix + ".html");
            //if (indexof_filesufix_plus_html_extension>0)
            //{
            //    LocalXmlFileName = mH.LocalHtmlFile.Substring(0, indexof_filesufix_plus_html_extension) + hlpwiztag.XmlFileSuffix+ ".xml";
            //}
            //else
            //{
            //    LocalXmlFileName = null;
            //    return;
            //}
            
         
            //string sStylePath = Path.GetDirectoryName(mH.LocalHtmlFile);
            //int index_of_last_map = sStylePath.LastIndexOf('\\');
            //if (index_of_last_map > 0)
            //{
            //    sStylePath = sStylePath.Substring(0, index_of_last_map);
            //    index_of_last_map = sStylePath.LastIndexOf('\\');
            //    if (index_of_last_map > 0)
            //    {

            //    }
            //}
            dtControlLayout = new DataTable();
            dtControlLayout.TableName = LayoutName;
            dcol_ControlName = new DataColumn("ControlName", typeof(string));
            dcol_Left = new DataColumn("Left", typeof(int));
            dcol_Top = new DataColumn("Top", typeof(int));
            dcol_Width = new DataColumn("Width", typeof(int));
            dcol_Height = new DataColumn("Height", typeof(int));
            dcol_AnchorLeft = new DataColumn("AnchorLeft", typeof(bool));
            dcol_AnchorRight = new DataColumn("AnchorRight", typeof(bool));
            dcol_AnchorTop = new DataColumn("AnchoTop", typeof(bool));
            dcol_AnchorBottom = new DataColumn("AnchorBottom", typeof(bool));
            dcol_ForeColor = new DataColumn("ForeColor", typeof(int));
            dcol_BackColor = new DataColumn("BackColor", typeof(int));


            dtControlLayout.Columns.Add(dcol_ControlName);
            dtControlLayout.Columns.Add(dcol_Left);
            dtControlLayout.Columns.Add(dcol_Top);
            dtControlLayout.Columns.Add(dcol_Width);
            dtControlLayout.Columns.Add(dcol_Height);
            dtControlLayout.Columns.Add(dcol_AnchorLeft);
            dtControlLayout.Columns.Add(dcol_AnchorRight);
            dtControlLayout.Columns.Add(dcol_AnchorTop);
            dtControlLayout.Columns.Add(dcol_AnchorBottom);
            dtControlLayout.Columns.Add(dcol_ForeColor);
            dtControlLayout.Columns.Add(dcol_BackColor);





        }

        public static string getLayoutName(Screen screen,Form pForm)
        {
            return 's' + screen.Bounds.Width.ToString() + "x" + screen.Bounds.Height.ToString() + "_" + pForm.Name;
        }
        private void Form_Layout_Load(object sender, EventArgs e)
        {
            //if (LocalXmlFileName == null)
            //{
            //    MessageBox.Show(this, "ERROR:LocalXmlFileName == null");
            //    this.Close();
            //    DialogResult = DialogResult.Abort;
            //    return;
            //}

            //string localfiledirectory = Path.GetDirectoryName(LocalXmlFileName);
            //localBookmarkDicFile = localfiledirectory + "\\BookmarkDic.xml";

            //if (!HUDCMS_static.GetBookmarkFile(LocalXmlFileName, ref localBookmarkDicFile))
            //{
            //    MessageBox.Show("ERROR:HUDCMS:Form_Wizzard:Form_Wizzard_Load: Cannot get BookmarkFile!");
            //    this.Close();
            //    DialogResult = DialogResult.Abort;
            //}
            //BookmarkDic.Init(localBookmarkDicFile);

            ImageFileResults.Init();

            SetHeader();


            string err = null;
            if (Global.f.SetApplicationDataSubFolder(ref screen_layout_folder, "ScreenLayout", ref err))
            {
                if (screen_layout_folder[screen_layout_folder.Length - 1] != '\\')
                {
                    screen_layout_folder += '\\';
                }
                screen_layout_file = screen_layout_folder + getLayoutName(screen, pForm) + ".xml";


                usrc_SelectXMLFile.FileName = screen_layout_file;
                usrc_SelectXMLFile.Title = "Save XML file";
                usrc_SelectXMLFile.Text = "XML file:";
                this.usrc_SelectXMLFile.DefaultExtension = "xml";
                this.usrc_SelectXMLFile.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

                if (File.Exists(screen_layout_file))
                {
                    try
                    {
                        dtControlLayout.ReadXml(screen_layout_file);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR: XDocument.Load file=\"" + screen_layout_file + "\" failed :Exception = " + ex.Message);
                    }
                }


                int iAllCount = 0;

                InitializeMyTreeListView(ref iAllCount);
                if (iAllCount > 0)
                {
                    this.MyTreeListView.ExpandAll();
                }

                this.Text = /*sXmlFileName +*/ "  Number of controls=" + iAllCount.ToString();
            }
            else
            {
                MessageBox.Show("ERROR:LayoutManager:Form_Layout:" + err);
            }
            //if (Properties.Settings.Default.GitExeFile.Length==0)
            //{
            //    Properties.Settings.Default.UseGit = false;
            //    Properties.Settings.Default.Save();
            //}
            //chk_UseGit.Checked = Properties.Settings.Default.UseGit;

            //this.chk_UseGit.CheckedChanged += new System.EventHandler(this.chk_UseGit_CheckedChanged);
            //btn_SetGitExeFile.Enabled = Properties.Settings.Default.UseGit; 

        }

        private void SetHeader()
        {
//            Header = Properties.Settings.Default.eng_Header;
            //switch (HUDCMS_static.LanguageID)
            //{
            //    case 0:
            //        if (Properties.Settings.Default.eng_Header.Length == 0)
            //        {
            //            Properties.Settings.Default.eng_Header = Properties.Resources.eng_Header;
            //            Properties.Settings.Default.Save();
            //        }
            //        Header = Properties.Settings.Default.eng_Header;
            //        break;
            //    case 1:
            //        if (Properties.Settings.Default.slo_Header.Length == 0)
            //        {
            //            Properties.Settings.Default.slo_Header = Properties.Resources.slo_Header;
            //            Properties.Settings.Default.Save();
            //        }
            //        Header = Properties.Settings.Default.slo_Header;
            //        break;
            //}
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
            myroot = CreateMyControls(/*hlpwiztag,*/ 0, 0, ref iAllCount, hc, null, ref helperControlType/*,  mH*/);
            SetLinks(myroot, ref helperImageRenderer);

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
                                break;
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

        internal bool SaveTableInXml(string xml_file, /*ref XDocument xh, */ref string Err)
        {

            //if (this.MyControl_Selected != null)
            //{
            //    this.usrc_EditControlWizzard1.my_Control.ImageIncluded = this.usrc_EditControlWizzard1.usrc_EditControlWizzard_Image1.chk_ImageIncluded.Checked;
            //    if (this.usrc_EditControlWizzard1.usrc_EditControlWizzard_Image1.pic_Control.Image != null)
            //    {
            //        this.usrc_EditControlWizzard1.my_Control.ImageOfControl = (Image)this.usrc_EditControlWizzard1.usrc_EditControlWizzard_Image1.pic_Control.Image.Clone();
            //    }
            //    else
            //    {
            //        this.usrc_EditControlWizzard1.my_Control.ImageOfControl = null;
            //    }
            //    this.usrc_EditControlWizzard1.my_Control.HelpTitle = this.usrc_EditControlWizzard1.usrc_EditControlWizzard_Title1.fctb_CtrlTitle.Text;
            //    this.usrc_EditControlWizzard1.my_Control.HeadingTag = this.usrc_EditControlWizzard1.usrc_EditControlWizzard_Title1.cmb_HtmlTag.Text;

            //    this.usrc_EditControlWizzard1.usrc_EditControlWizzard_About1.GetData();
            //    this.usrc_EditControlWizzard1.usrc_EditControlWizzard_Description1.GetData();
            //    //this.usrc_EditControlWizzard1.my_Control.About = this.usrc_EditControlWizzard1.usrc_EditControlWizzard_About1.fctb_CtrlAbout.Text;


            //    //this.usrc_EditControlWizzard1.my_Control.Description = this.usrc_EditControlWizzard1.usrc_EditControlWizzard_Description1.fctb_CtrlDescription.Text;
            //    this.usrc_EditControlWizzard1.my_Control.ImageCaption = this.usrc_EditControlWizzard1.usrc_EditControlWizzard_Image1.fctb_CtrlImageCaption.Text;
            //}

            //if (xh != null)
            //{
            //    xh = null;
            //}

            //xh = new XDocument();

            //html_html = new XElement("html");


            //xh.AddFirst(html_html);

            if (myroot != null)
            {
                dtControlLayout.Rows.Clear();
                myroot.CreateTable(dtControlLayout);
                try
                {
                    dtControlLayout.WriteXml(xml_file, XmlWriteMode.WriteSchema);
                    designchanged = true;
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR:dtControlLayout.WriteXml in Form_Layout!\r\nException=" + ex.Message);
                    return false;

                }
            }
            else
            {
                MessageBox.Show("ERROR:myroot == null in Form_Layout!");
                return false;
            }

            ////save xhtml
            //if (SelectFile.usrc_SelectFile.CreateFolderIfNotExist(this, xml_file, ref Err))
            //{
            //    try
            //    {
            //        xh.Save(xml_file);                  
            //        return true;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("ERROR:xh.Save(html_file) in Form_Layout!\r\nException=" + ex.Message);
            //        return false;

            //    }
            //}
            //else
            //{
            //    MessageBox.Show("ERROR:SelectFile.usrc_SelectFile.CreateFolderIfNotExist(..) in Form_Layout!");
            //    return false;

            //}
        }




        internal static MyControl  CreateMyControls(/*HelpWizzardTag xHlpWizTag,*/ int level, int iCount, ref int iAllCount, hctrl xhc, MyControl xctrl, ref SysImageListHelper helperControlType/*,  usrc_Help mH*/)
        {


            MyControl myctrl = new MyControl();
            iAllCount++;
            iCount = 0;
            myctrl.ControlName = "uctrl_" + level.ToString() + "_" + iCount.ToString();
            myctrl.Init(/*xHlpWizTag,mH,*/ xhc,level, xctrl, ref helperControlType);
            if (xhc.subctrl != null)
            {
                MyControl child = null;
                foreach (hctrl hcx in xhc.subctrl)
                {
                    if (hcx.ctrl != null)
                    {
                        //if (hcx.ctrl.Visible)
                        //{
                            child = CreateMyControls(/*xHlpWizTag,*/ level + 1, iCount++, ref iAllCount, hcx, myctrl, ref helperControlType/*,  mH*/);
                            myctrl.children.Add(child);
                        //}
                    }
                    else if (hcx.dgvc != null)
                    {
                        child = CreateMyControls(/*xHlpWizTag,*/ level + 1, iCount++, ref iAllCount, hcx, myctrl,ref helperControlType/*,  mH*/);
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
                MessageBox.Show("ERROR:HUDCMS:Form_Layout:GetY:(xhc.ctrl==null)&&(xhc.pForm == null)");
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
                MessageBox.Show("ERROR:HUDCMS:Form_Layout:GetX:(xhc.ctrl==null)&&(xhc.pForm == null)");
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
                MessageBox.Show("ERROR:HUDCMS:Form_Layout:GetHeight:(xhc.ctrl==null)&&(xhc.pForm == null)");
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
                MessageBox.Show("ERROR:HUDCMS:Form_Layout:GetWidth:(xhc.ctrl==null)&&(xhc.pForm == null)");
                return -1;
            }
        }


      
        //private void EditFile(string xFileName)
        //{
        //    if (frm_FCTB_Editor == null)
        //    {
        //        frm_FCTB_Editor = new Form_FCTB_Editor();
        //        frm_FCTB_Editor.Owner = this;
        //    }
        //    if (frm_FCTB_Editor.IsDisposed)
        //    {
        //        frm_FCTB_Editor = new Form_FCTB_Editor();
        //        frm_FCTB_Editor.Owner = this;
        //    }
        //    frm_FCTB_Editor.CreateTab(xFileName);
        //    frm_FCTB_Editor.Show();
        //}

        //private bool usrc_SelectHtmlFile_EditFile(string xFileName)
        //{
        //    EditFile(xFileName);
        //    return true;
        //}

        //private bool usrc_SelectStyleFile_EditFile(string xFileName)
        //{
        //    EditFile(xFileName);
        //    return true;
        //}






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
                        myctrl.xfrm_Layout = this;
                        myctrl.xfrm_Layout.MyControl_Selected = myctrl;
                        myctrl.xfrm_Layout.usrc_EditLayout1.Enabled = true;
                        myctrl.xfrm_Layout.usrc_EditLayout1.Init(myctrl);
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

    

        private bool GetGitSettings()
        {
            //Form_SetGitExeFile frm_SetGitExeFile = new Form_SetGitExeFile();
            //frm_SetGitExeFile.ShowDialog();
            //return Properties.Settings.Default.GitExeFile.Length > 0;
            return false;
        }

        private void chk_UseGit_CheckedChanged(object sender, EventArgs e)
        {
            //if (chk_UseGit.Checked)
            //{
            //    //string sGitExeFile = Properties.Settings.Default.GitExeFile;
            //    if (sGitExeFile.Length == 0)
            //    {
            //        if (!GetGitSettings())
            //        {
            //            chk_UseGit.Checked = false;
            //        }
            //    }
            //}
            //Properties.Settings.Default.UseGit = chk_UseGit.Checked;
            //Properties.Settings.Default.Save();
            //btn_SetGitExeFile.Enabled = Properties.Settings.Default.UseGit;
        }

        private void btn_ZIP_Click(object sender, EventArgs e)
        {
            //Form_ZIP frm_zip = new Form_ZIP();
            //frm_zip.ShowDialog(this);
        }

       

        private void btn_ViewBookmardDic_Click(object sender, EventArgs e)
        {
           // HUDCMS.BookmarkDic.ShowBookmarkDic(this);
        }

        private void Form_Layout_FormClosing(object sender, FormClosingEventArgs e)
        {
            BookmarkDic.CloseBookmarkDic();
            ImageFileResults.CloseImageFileResults();

        }

        private void btn_Images_Click(object sender, EventArgs e)
        {
            ImageFileResults.ShowImageFileResults(this);
        }

        private bool usrc_SelectXMLFile_SaveFile(string FileName, ref string Err)
        {
            if (SaveTableInXml(FileName, ref Err))
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public static eSetLayoutResult SetLayout(Form xpForm, 
                                                 ref int screen_width,
                                                 ref int screen_height,
                                                 ref string screen_layout_folder,
                                                 ref string sXmlFileName,ref string err)
        {
            int iAllCount = 0;
            Screen xscreen = Screen.FromControl(xpForm);
            screen_width = xscreen.Bounds.Width;
            screen_height = xscreen.Bounds.Height;
            DataTable dtCtrlLayout = new DataTable();
            //dtCtrlLayout.TableName = Form_Layout.getLayoutName(screen, pForm);
            dcol_ControlName = new DataColumn("ControlName", typeof(string));
            dcol_Left = new DataColumn("Left", typeof(int));
            dcol_Top = new DataColumn("Top", typeof(int));
            dcol_Width = new DataColumn("Width", typeof(int));
            dcol_Height = new DataColumn("Height", typeof(int));
            dcol_AnchorLeft = new DataColumn("AnchorLeft", typeof(bool));
            dcol_AnchorRight = new DataColumn("AnchorRight", typeof(bool));
            dcol_AnchorTop = new DataColumn("AnchoTop", typeof(bool));
            dcol_AnchorBottom = new DataColumn("AnchorBottom", typeof(bool));
            dcol_ForeColor = new DataColumn("ForeColor", typeof(int));
            dcol_BackColor = new DataColumn("BackColor", typeof(int));


            if (Global.f.SetApplicationDataSubFolder(ref screen_layout_folder, "ScreenLayout", ref err))
            {
                if (screen_layout_folder[screen_layout_folder.Length - 1] != '\\')
                {
                    screen_layout_folder += '\\';
                }
                sXmlFileName = screen_layout_folder + getLayoutName(xscreen, xpForm) + ".xml";
                if (File.Exists(sXmlFileName))
                {
                    try
                    {
                        dtCtrlLayout.ReadXml(sXmlFileName);
                        UniqueControlName xuctrln = new UniqueControlName();
                        hctrl xhc = new hctrl(xpForm, xuctrln);
                        SysImageListHelper xhelperControlType = null;
                        MyControl xmyroot = CreateMyControls(0, 0, ref iAllCount, xhc, null, ref xhelperControlType);
                        xmyroot.SetLayout(dtCtrlLayout);
                        return eSetLayoutResult.OK;

                    }
                    catch (Exception ex)
                    {
                        err = "ERROR:LayoutManager:Form_Layout:SetLayout: Exception=" + ex.Message;
                        return eSetLayoutResult.EXCEPTION_ERROR;
                    }
                }
                else
                {
                    err = "ERROR:LayoutManager:Form_Layout:SetLayout: File:\"" + sXmlFileName+"\" does not exists!";
                    return eSetLayoutResult.SCRREN_LAYOUT_FILE_DOES_NOT_EXIST;
                }
            }
            else
            {
                err = "ERROR:LayoutManager:Form_Layout:SetLayout: canot set \"ScreenLayout\" folder !";
                return eSetLayoutResult.CANNOT_SET_SCRREN_LAYOUT_FOLDER;
            }
        }
    }
}

