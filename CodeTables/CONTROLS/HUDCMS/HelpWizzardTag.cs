﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HUDCMS
{
    public class HelpWizzardTag
    {
        public int DefaultControlWidth = 1024;
        public int DefaultControlHeight = 768;


        public delegate void delegate_ShowWizzard(Control ctrl, MyControl root_ctrl,string header, string styleFile);
        public  delegate_ShowWizzard ShowWizzard = null;

        public delegate bool delegate_FillTextContent(HelpWizzardTagDC[] hlpTagDCs,ref string About, ref string Description);
        public delegate_FillTextContent FillTextContent = null;

        private string filessufix = null;
        public string FileSuffix
        {
            get { return filessufix; }
            set { filessufix = value; }
        }

        private string xmlfilessufix = null;
        public string XmlFileSuffix
        {
            get { return xmlfilessufix; }
            set { xmlfilessufix = value; }
        }

        public HelpWizzardTagContent About = null;
        public HelpWizzardTagContent Description = null;

        public HelpWizzardTag(HelpWizzardTagDC[] xtagDCs, delegate_ShowWizzard xdelegate_ShowWizzard,
                                                delegate_FillTextContent xFillTextContent)
        {
            About = HelpWizzardTagContent.Clone(xtagDCs);
            Description = HelpWizzardTagContent.Clone(xtagDCs);
            ShowWizzard = xdelegate_ShowWizzard;
            FillTextContent = xFillTextContent;
        }

        public HelpWizzardTag(HelpWizzardTag xhlpwiztag)
        {
            if (xhlpwiztag.About != null)
            {
                About = HelpWizzardTagContent.Clone(xhlpwiztag.About.tagDCs);
            }
            if (xhlpwiztag.Description != null)
            {
                Description = HelpWizzardTagContent.Clone(xhlpwiztag.Description.tagDCs);
            }
            ShowWizzard = xhlpwiztag.ShowWizzard;
            FillTextContent = xhlpwiztag.FillTextContent;
        }

        internal bool HasAbout()
        {
            if (About!=null)
            {
                foreach(HelpWizzardTagDC tdc in About.tagDCs)
                {
                    if (tdc.Text != null)
                    {
                        if (tdc.Text.Length > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        internal bool HasDescription()
        {
            if (Description != null)
            {
                foreach (HelpWizzardTagDC tdc in Description.tagDCs)
                {
                    if (tdc.Text != null)
                    {
                        if (tdc.Text.Length > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

    }
}
