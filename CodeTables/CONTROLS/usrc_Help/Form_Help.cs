#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HUDCMS
{
    public partial class Form_Help : Form
    {
        Form pForm = null;
        internal string RelativeURL = null;
        internal string ModuleName = null;
        internal string HtmlFileName = null;
        internal string sLocalHtmlFile = null;
        internal Form_HUDCMS frm_HUDCMS = null;

        public Form_Help(Form xpForm)
        {
            InitializeComponent();
            pForm = xpForm;
        }

        private void Form_Help_Load(object sender, EventArgs e)
        {

            if (HUDCMS_static.GetLocalHtmlFile(pForm, ref ModuleName, ref HtmlFileName, ref RelativeURL, ref  sLocalHtmlFile))
            {
                if (File.Exists(sLocalHtmlFile))
                {
                    this.m_webBrowser.Url = new Uri("file:///" + sLocalHtmlFile);
                }
                else
                {
                    //Local File does not exist
                    frm_HUDCMS = new Form_HUDCMS(pForm, sLocalHtmlFile);
                    frm_HUDCMS.Owner = this;
                    frm_HUDCMS.Show();
                }
            }
            else
            {
                MessageBox.Show("Can not get relative URL");
            }

        }
    }
}
