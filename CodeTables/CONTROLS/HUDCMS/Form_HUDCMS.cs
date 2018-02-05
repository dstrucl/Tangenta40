﻿using System;
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

        public Form_HUDCMS(usrc_Help xH)
        {
            InitializeComponent();
            mH = xH;
            hc = new hctrl(mH.pForm);
            usrc_SelectHtmlFile.InitialDirectory = Path.GetDirectoryName(mH.sLocalHtmlFile);
            usrc_SelectHtmlFile.FileName = mH.sLocalHtmlFile;
            usrc_SelectStyleFile.Title = "Save HTML file";
            usrc_SelectHtmlFile.Text = "HTML file:";
            this.usrc_SelectHtmlFile.DefaultExtension = "html";
            this.usrc_SelectHtmlFile.Filter = "HTML files (*.html)|*.html|All files (*.*)|*.*";

            string[] folders = mH.RelativeURL.Split('/');
            string sStylePath = "";
            if (folders.Length>0)
            {
                sStylePath = HUDCMS_static.ApplicationPath+"\\"+folders[0];
            }
            usrc_SelectStyleFile.InitialDirectory = sStylePath;
            usrc_SelectStyleFile.FileName = sStylePath + "\\TangentaHelp.css";
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

        }
        internal bool SaveXHTML(ref XDocument xh)
        {
            if (xh == null)
            {
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
                                html_title = new XElement("title");
                                string sTitle = ((usrc_Control)c).hc.pForm.Text;
                                if (sTitle.Length == 0)
                                {
                                    sTitle = ((usrc_Control)c).hc.pForm.GetType().ToString();
                                }
                                html_title.Value = sTitle;
                                html_body = new XElement("body");

                                html_head.Add(html_title);
                                html_html.Add(html_head);
                                html_html.Add(html_body);

                            }
                            else if (((usrc_Control)c).hc.ctrl != null)
                            {
                                html_head = new XElement("head");
                                html_title = new XElement("title");
                                string sTitle = ((usrc_Control)c).hc.ctrl.Text;
                                if (sTitle.Length == 0)
                                {
                                    sTitle = ((usrc_Control)c).hc.ctrl.GetType().ToString();
                                }
                                html_title.Value = sTitle;
                                html_body = new XElement("body");

                                html_head.Add(html_title);
                                html_html.Add(html_head);
                                html_html.Add(html_body);

                            }
                        }
                        ((usrc_Control)c).CreateNode(xh, ref html_body);
                    }
                }

                //save xhtml
                string sHtmFileName = usrc_SelectHtmlFile.FileName;
                if (SelectFile.usrc_SelectFile.CreateFolderIfNotExist(this, sHtmFileName))
                {
                    xh.Save(sHtmFileName);
                }

            }

            return false;
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
                        if (hc.ctrl.Visible)
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

        private void btn_Create_Click(object sender, EventArgs e)
        {
            SaveXHTML(ref this.xhtml);
        }

       
    }
}
