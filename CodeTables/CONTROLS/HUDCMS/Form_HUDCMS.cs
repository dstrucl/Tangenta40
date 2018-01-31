using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HUDCMS
{
    public partial class Form_HUDCMS : Form
    {
        private hctrl hc = null;
        private usrc_Help mH = null;

        public Form_HUDCMS(usrc_Help xH)
        {
            InitializeComponent();
            mH = xH;
            hc = new hctrl(mH.pForm);
            int y= grp_Style.Bottom+4;

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

            CreateControls(ref y,0,hc,this.panel1);
        }

        private void CreateControls(ref int y,int level, hctrl xhc,Control xctrl)
        {

            if (xhc.parentctrl==null)
            {
                //this is a Root Control
                usrc_RootControl uRoot = new usrc_RootControl();
                uRoot.Init(mH,xhc);
                uRoot.Top = y;
                uRoot.Left = 3+ level*3;
                uRoot.Width = this.Width - uRoot.Left;
                uRoot.Visible = true;
                uRoot.Parent = xctrl;
                HUDCMS_static.SetControlAnchorTopLeftRight(uRoot);
                xctrl.Controls.Add(uRoot);
                y += uRoot.Height + 4;
                if (xhc.subctrl != null)
                {
                    int ysub = uRoot.Height + 4;
                    foreach (hctrl hc in xhc.subctrl)
                    {
                        if (hc.ctrl.Visible)
                        {
                            CreateControls(ref ysub, level + 1, hc, uRoot);
                        }
                    }
                    uRoot.Height = ysub;
                }
            }
            else
            {
                usrc_Control uctrl = new usrc_Control();
                uctrl.Parent = xctrl;
                uctrl.Init(mH,xhc);
                uctrl.Top = y;
                uctrl.Left = 3;
                uctrl.Width = xctrl.Width - uctrl.Left - 3;
                uctrl.Visible = true;
                xctrl.Controls.Add(uctrl);
                uctrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
//                AddParentsSize(uctrl.Parent, uctrl.Height+4);
                y += uctrl.Height + 8;
            }
        }

        private void AddParentsSize(Control parent, int height)
        {
            parent.Height += height+4;
            if (parent.Parent!=null)
            {
                if (parent.Parent is Form)
                {
                    return;
                }
                else
                {
                    AddParentsSize(parent.Parent, height);
                }
            }
        }

        private void usrc_SelectStyleFile_Load(object sender, EventArgs e)
        {

        }
    }
}
