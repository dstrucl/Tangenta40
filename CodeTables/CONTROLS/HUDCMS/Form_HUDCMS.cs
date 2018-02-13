using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace HUDCMS
{
    public partial class Form_HUDCMS : Form
    {
        private hctrl hc = null;
        private usrc_Help mH = null;
        internal usrc_Control usrc_Control_Selected = null;
        XDocument xhtml = null;
        internal XDocument xhtml_Loaded = null;

        XElement html_html = null;
        XElement html_head = null;
        XElement html_title = null;
        XElement html_body = null;
        XElement html_iframe = null;

        public Form_HUDCMS(usrc_Help xH)
        {
            InitializeComponent();
            mH = xH;
            hc = new hctrl(mH.pForm);
            usrc_SelectHtmlFile.InitialDirectory = Path.GetDirectoryName(mH.LocalHtmlFile);
            usrc_SelectHtmlFile.FileName = mH.LocalHtmlFile;
            usrc_SelectHtmlFile.Title = "Save HTML file";
            usrc_SelectHtmlFile.Text = "HTML file:";
            this.usrc_SelectHtmlFile.DefaultExtension = "html";
            this.usrc_SelectHtmlFile.Filter = "HTML files (*.html)|*.html|All files (*.*)|*.*";

            string sStylePath = Path.GetDirectoryName(mH.LocalHtmlFile);
            usrc_SelectStyleFile.InitialDirectory = sStylePath;
            usrc_SelectStyleFile.FileName = sStylePath + "\\style.css";
            usrc_SelectStyleFile.Title = "Save style file";
            usrc_SelectStyleFile.Text = "Style file:";

       
        }

        private void Form_HUDCMS_Load(object sender, EventArgs e)
        {

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
            CreateControls(ref y, 0, hc, this.panel1);
            HideLinks();
            SetLinks(this.panel1);
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

                            html_iframe = new XElement("iframe");
                            XAttribute atr_html_iframe_src = new XAttribute("src", "../Header.html");
                            XAttribute atr_html_iframe_style = new XAttribute("style", "border:none");
                            XAttribute atr_html_frame_width = new XAttribute("width", "714");
                            XAttribute atr_html_frame_height = new XAttribute("height", "150");
                            html_iframe.Add(atr_html_iframe_src);
                            html_iframe.Add(atr_html_iframe_style);
                            html_iframe.Add(atr_html_frame_width);
                            html_iframe.Add(atr_html_frame_height);
                            html_iframe.Value = "";

                            html_body.Add(html_iframe);

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

                            html_iframe = new XElement("iframe");
                            XAttribute atr_html_iframe_src = new XAttribute("src", "../Header.html");
                            XAttribute atr_html_iframe_style = new XAttribute("style", "border:none");
                            XAttribute atr_html_frame_width = new XAttribute("width", "714");
                            XAttribute atr_html_frame_height = new XAttribute("height", "150");
                            html_iframe.Add(atr_html_iframe_src);
                            html_iframe.Add(atr_html_iframe_style);
                            html_iframe.Add(atr_html_frame_width);
                            html_iframe.Add(atr_html_frame_height);
                            html_iframe.Value = "";

                            html_body.Add(html_iframe);

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

        private void CreateControls(ref int y,int level, hctrl xhc,Control xctrl)
        {

           
                usrc_Control uctrl = new usrc_Control();
                uctrl.Parent = xctrl;
                uctrl.Init(mH, xhc);
                uctrl.Top = y;
                uctrl.Left = 3;
                uctrl.Width = xctrl.Width - uctrl.Left - 3;
                uctrl.Visible = true;
                uctrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                xctrl.Controls.Add(uctrl);
                if (xhc.subctrl != null)
                {
                    int ysub = uctrl.Height + 4;
                    foreach (hctrl hc in xhc.subctrl)
                    {
                        if (hc.ctrl != null)
                        {
                            if (hc.ctrl.Visible)
                            {
                                CreateControls(ref ysub, level + 1, hc, uctrl);
                            }
                        }
                        else if (hc.dgvc != null)
                        {
                            CreateControls(ref ysub, level + 1, hc, uctrl);
                        }
                    }
                    uctrl.Height = ysub;
                }
                y += uctrl.Height + 8;
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

        private void usrc_SelectStyleFile_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

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
    }
}
