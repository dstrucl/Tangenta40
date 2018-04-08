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
    public partial class Form_ZIP : Form
    {
        public Form_ZIP()
        {
            InitializeComponent();
        }

        private void Form_ZIP_Load(object sender, EventArgs e)
        {
            string helpfolder = HUDCMS_static.GetApplicationHelpFolder();
            if (helpfolder != null)
            {
                this.usrc_SelectFolder_DestinationFolder.SelectedFolder = HUDCMS_static.ApplicationPath;
                this.usrc_SelectFolder_OfHelp.SelectedFolder = HUDCMS_static.LocalHelpPath + HUDCMS_static.ApplicationVersion;
            }
            else
            {
                MessageBox.Show("ERROR:HUDCMS:Form_ZIP:Load:Can not GetApplicationHelpFolder");
                this.Close();
                DialogResult = DialogResult.Abort;
            }
        }

        private void btn_Compress_Click(object sender, EventArgs e)
        {
            string start_path = this.usrc_SelectFolder_OfHelp.SelectedFolder;
            string zipFile = this.usrc_SelectFolder_DestinationFolder.SelectedFolder + "Help"+HUDCMS_static.ApplicationVersion+".zip";
            if (File.Exists(zipFile))
            {
                if (MessageBox.Show(this, "File:" + zipFile + "\r\nAllready Exist!\r\n\r\nDelete existing file and write new one?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try
                    {
                        File.Delete(zipFile);
                        if (HUDCMS_static.Zip(start_path, zipFile))
                        {
                            lbl_Result.Text = "Zip file:\"" + zipFile + "\" Created ok!";
                        }
                        else
                        {
                            lbl_Result.Text = "ERROR: file:\"" + zipFile + "\" not created!";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR:HUDCMS:Form_ZIP:Can not delete file:" + zipFile + "\r\nException = " + ex.Message);
                    }
                }
            }
            else
            {
                if (HUDCMS_static.Zip(start_path, zipFile))
                {
                    lbl_Result.Text = "Zip file:\"" + zipFile + "\" Created ok!";
                }
                else
                {
                    lbl_Result.Text = "ERROR: file:\"" + zipFile + "\" not created!";
                }
            }
        }
    }
}
