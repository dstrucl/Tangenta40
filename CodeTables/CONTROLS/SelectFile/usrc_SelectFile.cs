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

namespace SelectFile
{
    public partial class usrc_SelectFile : UserControl
    {
        public delegate bool delegate_SaveFile(string FileName, ref string Err);
        public event delegate_SaveFile SaveFile = null;

        public delegate bool delegate_EditFile(string FileName);
        public event delegate_EditFile EditFile = null;

        private string m_InitialDirectory = @"C:\";
        public string InitialDirectory
        {
            get { return m_InitialDirectory; }
            set { m_InitialDirectory = value; }

        }

        private string m_FileName = "";
        public string FileName
        {
            get { return m_FileName; }
            set { m_FileName = value;
                txt_File.Text = m_FileName;
            }
        }

        private string m_Title = "Save File";
        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        private string m_Text = "Save File";
        public override string Text
        {
            get { return m_Text; }
            set { m_Text = value;
                label1.Text = m_Text;
            }
        }

        private string m_DefaultExtension = "txt";
        public string DefaultExtension
        {
            get { return m_DefaultExtension; }
            set { m_DefaultExtension = value; }
        }

        private string m_Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
        public string Filter
        {
            get { return m_Filter; }
            set { m_Filter = value; }
        }

        public usrc_SelectFile()
        {
            InitializeComponent();
        }

        private void showfiledialog(string path)
        {
            InitialDirectory = path;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = this.InitialDirectory;
            saveFileDialog1.Title = this.Title;
            saveFileDialog1.FileName = this.FileName;
            saveFileDialog1.CheckFileExists = false;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = this.DefaultExtension;
            saveFileDialog1.Filter = this.Filter;
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txt_File.Text = saveFileDialog1.FileName;
                FileName = this.txt_File.Text;
                if (SaveFile != null)
                {
                    string Err = null;
                    if (SaveFile(FileName, ref Err))
                    {
                        MessageBox.Show("File:\"" + FileName + "\" saved OK!");
                    }
                    else
                    {
                        if (Err == null)
                        {
                            Err = "";
                        }
                        MessageBox.Show("Save file:\"" + FileName + "\" failed!" + Err);
                    }
                }
            }
        }

        public static bool CreateFolder(Control parentcontrol,string path)
        {
            if (MessageBox.Show(parentcontrol, "Folder does not exist:\"" + path + "\" CreateFolder", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes) 
            {
                string[] folders = path.Split('\\');
                int iCount = folders.Length;
                string sfolder = "";
                for (int i = 0; i<iCount; i++)
                {
                    sfolder += folders[i];
                    if (Directory.Exists(sfolder))
                    {
                        sfolder += "\\";
                        continue;
                    }
                    else
                    {
                        try
                        {
                            Directory.CreateDirectory(sfolder);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Create directory\"" + sfolder + "\" failed! Exception=" + ex.Message);
                            return false;
                        }
                    }
                    sfolder += "\\";
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool CreateFolderIfNotExist(Control parentcontrol, string filename)
        {
            string path = Path.GetDirectoryName(filename);
            if (Directory.Exists(path))
            {
                return true;
            }
            else
            {
                return CreateFolder(parentcontrol, path);
            }
        }
            private void btn_Save_Click(object sender, EventArgs e)
            {
              FileName = txt_File.Text;
              string path = Path.GetDirectoryName(FileName);
              if (Directory.Exists(path))
              {
                showfiledialog(path);
              }
              else
                {
                CreateFolder(this, path);
                showfiledialog(path);
                }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (EditFile!=null)
            {
                FileName = txt_File.Text;
                EditFile(FileName);
            }
        }
    }
}
