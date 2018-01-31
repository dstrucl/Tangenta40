using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SelectFolder
{
    public partial class usrc_SelectFolder : UserControl
    {
        public usrc_SelectFolder()
        {
            InitializeComponent();
        }

        private string m_InitialDirectory = @"C:\";
        public string InitialDirectory
        {
            get { return m_InitialDirectory; }
            set { m_InitialDirectory = value; }

        }

        private string m_Folder = "";
        public string SelectedFolder
        {
            get {
                m_Folder = txt_Folder.Text;
                return m_Folder; }
            set
            {
                m_Folder = value;
                txt_Folder.Text = m_Folder;
            }
        }

        private string m_LabelText = "Select folder";
        public string LabelText
        {
            get
            {
                if (label1.Text.Length > 0)
                {
                    m_LabelText = label1.Text;
                    return m_LabelText;
                }
                else
                {
                    label1.Text = m_LabelText;
                    return m_LabelText;
                }
            }
            set
            {
                m_LabelText = value;
                label1.Text = m_LabelText;
            }
        }

        private string m_Title = "Select Folder";
        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

      

        private void showFolderBrowserDialog()
        {
            FolderBrowserDialog selectFolderDialog  = new FolderBrowserDialog();
            selectFolderDialog.SelectedPath = this.InitialDirectory;
            selectFolderDialog.Description = this.Title;
            selectFolderDialog.ShowNewFolderButton = true;
            if (selectFolderDialog.ShowDialog() == DialogResult.OK)
            {
                this.txt_Folder.Text = selectFolderDialog.SelectedPath;
                SelectedFolder = this.txt_Folder.Text;
            }
        }

        private void btn_SelectFolder_Click(object sender, EventArgs e)
        {
            showFolderBrowserDialog();
        }
    }
}
