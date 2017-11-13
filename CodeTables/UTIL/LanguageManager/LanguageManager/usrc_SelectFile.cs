using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanguageManager
{
    public partial class usrc_SelectFile : UserControl
    {
        public delegate void delegate_ExistingFileChanged(string SolutionFileName);
        public event delegate_ExistingFileChanged ExistingFileChanged = null;

        private string m_Path ="";
        private string m_FileName = "";
        private string m_Extension = "";
        private string m_DefaultExtension = "sln";
        private bool bExecuting_ExistingFileChanged = false;

        public void FireEvent_ExistingFileChanged()
        {
            if (ExistingFileChanged != null)
            {
                if (System.IO.File.Exists(this.txt_SelectedFile.Text))
                {
                    ExistingFileChanged(this.txt_SelectedFile.Text);
                }
            }
        }
        private void ExecuteEvent_ExistingFileChanged()
        {
            if (!bExecuting_ExistingFileChanged)
            {
                bExecuting_ExistingFileChanged = true;
                bExecuting_ExistingFileChanged = false;
            }
        }

        public string Path
        {
            get { return m_Path;
                }
            set
            {
                m_Path = value;
                this.txt_SelectedFile.Text = PathWithFileName;
                ExecuteEvent_ExistingFileChanged();
            }
        }

        public string FileName
        {
            get
            {
                return m_FileName;
            }
            set
            {
                m_FileName = value;
                this.txt_SelectedFile.Text = PathWithFileName;
                ExecuteEvent_ExistingFileChanged();
            }
        }

        public string PathWithFileName
        {
            get
            {
                string path_with_file_name = m_Path + m_FileName;
                return path_with_file_name;
            }
        }

        public string Extension
        {
            get
            {
                return m_Extension;
            }
            set
            {
                m_Extension = value;
            }
        }

        public string DefaultExtension
        {
            get
            {
                return m_DefaultExtension;
            }
            set
            {
                m_DefaultExtension = value;
            }
        }




        public usrc_SelectFile()
        {
            InitializeComponent();
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = m_DefaultExtension;
            ofd.Multiselect = false;
            ofd.InitialDirectory = m_Path;
            if (ofd.ShowDialog()== DialogResult.OK)
            {
                bExecuting_ExistingFileChanged = true;
                FileName = ofd.SafeFileName;
                bExecuting_ExistingFileChanged = false;
                Path = ofd.FileName.Substring(0,ofd.FileName.IndexOf(ofd.SafeFileName));
                Extension = ofd.SafeFileName.Substring(ofd.SafeFileName.IndexOf("."));
                txt_SelectedFile.Text = PathWithFileName;
                if (ExistingFileChanged!=null)
                {
                    ExistingFileChanged(txt_SelectedFile.Text);
                }
            }
        }
    }
}
