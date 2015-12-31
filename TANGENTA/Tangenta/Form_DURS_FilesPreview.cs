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
    public partial class Form_DURS_FilesPreview : Form
    {
        private Form_DURS_output form_DURS_output;


        public Form_DURS_FilesPreview()
        {
            InitializeComponent();
        }

        public Form_DURS_FilesPreview(Form_DURS_output form_DURS_output)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.form_DURS_output = form_DURS_output;
            try
            {
                lbl_file_GLAVA.Text = form_DURS_output.cmbR_FilePath.Text + form_DURS_output.filename_DURS_IZPIS_RACUNI_GLAVE_TXT;
                lbl_file_POSTAVKE.Text =form_DURS_output.cmbR_FilePath.Text + form_DURS_output.filename_DURS_IZPIS_RACUNI_POSTAVKE_TXT;
                txt_GLAVA.Text = File.ReadAllText(lbl_file_GLAVA.Text);
                txt_POSTAVKE.Text = File.ReadAllText(lbl_file_POSTAVKE.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, lngRPM.s_Error.s + ":" + ex.Message);
            }
        }
    }
}
