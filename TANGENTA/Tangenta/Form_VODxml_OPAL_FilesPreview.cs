#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using LanguageControl;
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

namespace Tangenta
{
    public partial class Form_VODxml_OPAL_FilesPreview : Form
    {
        private Form_VODxml_OPAL_output m_form_VODxml_OPAL_output;

        public Form_VODxml_OPAL_FilesPreview()
        {
            InitializeComponent();
        }

        public Form_VODxml_OPAL_FilesPreview(Form_VODxml_OPAL_output form_VODxml_OPAL_output)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.m_form_VODxml_OPAL_output = form_VODxml_OPAL_output;
        }

        private void Form_XML_FilesPreview_Load(object sender, EventArgs e)
        {
            try
            {
                lbl_file_GLAVA.Text = m_form_VODxml_OPAL_output.cmbR_FilePath.Text + m_form_VODxml_OPAL_output.filename_XML_IZPIS_RACUNI_GLAVE_TXT;
                txt_GLAVA.Text = File.ReadAllText(lbl_file_GLAVA.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, lngRPM.s_Error.s + ":" + ex.Message);
            }
        }

    }
}
