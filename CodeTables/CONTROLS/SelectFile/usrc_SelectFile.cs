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
        OpenFileDialog openFileDialog1 = null;
        public enum eType { SELECT,SAVE};
        public delegate bool delegate_SaveFile(string FileName, ref string Err);
        public event delegate_SaveFile SaveFile = null;

        public delegate bool delegate_SelectFile(string FileName, ref string Err);
        public event delegate_SelectFile SelectFile = null;

        public delegate bool delegate_EditFile(string FileName);
        public event delegate_EditFile EditFile = null;

        private string m_InitialDirectory = @"C:\";
        public string InitialDirectory
        {
            get { return m_InitialDirectory; }
            set { m_InitialDirectory = value; }

        }

        private eType m_eType = eType.SAVE;
        public eType Type
        {
            get { return m_eType; }
            set
            {
                m_eType = value;
            }
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

        private string m_LableText = "Save File";
        public  string LabelText
        {
            get { return m_LableText; }
            set { m_LableText = value;
                label1.Text = m_LableText;
            }
        }

        private string m_ButtonSelectText = "Save";
        public new string ButtonSelectText
        {
            get { return m_ButtonSelectText; }
            set
            {
                m_ButtonSelectText = value;
                btn_Select.Text = m_ButtonSelectText;
            }
        }

        private bool m_ButtonEditVisible = true;
        public new bool ButtonEditVisible
        {
            get { return m_ButtonEditVisible; }
            set
            {
                m_ButtonEditVisible = value;
                btn_Edit.Visible = m_ButtonEditVisible;
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

        private void showSaveFileDialog(string path)
        {
            InitialDirectory = path;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = this.InitialDirectory;
            saveFileDialog1.Title = this.Title;
            saveFileDialog1.FileName = this.FileName.Replace('/','\\');
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

        public static bool CreateFolder(Control parentcontrol,string path, ref string Err)
        {
            Err = null;
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
                            Err = "Create directory\"" + sfolder + "\" failed! Exception=" + ex.Message;
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

        public static bool CreateFolderIfNotExist(Control parentcontrol, string filename, ref string Err)
        {
            Err = null;
            string path = Path.GetDirectoryName(filename);
            if (Directory.Exists(path))
            {
                return true;
            }
            else
            {
                return CreateFolder(parentcontrol, path, ref Err);
            }
        }
        private void btn_Select_Click(object sender, EventArgs e)
        {
            string Err = null;
            string path = null;
            FileName = txt_File.Text;
            if (FileName.Length > 0)
            {
                path = Path.GetDirectoryName(FileName);
                if (Directory.Exists(path))
                {
                    selectFileDialog(path);
                }
                else
                {
                    if (CreateFolder(this, path, ref Err))
                    {
                        selectFileDialog(path);
                    }
                    else
                    {
                        if (Err != null)
                        {
                            MessageBox.Show(Err);
                        }
                    }
                }
            }
            else
            {
                path = "";
                selectFileDialog(path);
            }
        }

        private void selectFileDialog(string path)
        {
            switch (Type)
            {
                case eType.SAVE:
                    showSaveFileDialog(path);
                    break;
                case eType.SELECT:
                    showSelectFileDialog(path);
                    break;

            }
        }

        private void showSelectFileDialog(string path)
        {
            InitialDirectory = path;
            if (openFileDialog1!=null)
            {
                openFileDialog1.Dispose();
                openFileDialog1 = null;
            }
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = this.InitialDirectory;
            openFileDialog1.Title = this.Title;
            openFileDialog1.FileName = this.FileName.Replace('/', '\\');
            openFileDialog1.CheckFileExists = false;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.DefaultExt = this.DefaultExtension;
            openFileDialog1.Filter = this.Filter;
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txt_File.Text = openFileDialog1.FileName;
                FileName = this.txt_File.Text;
                if (SelectFile!=null)
                {
                    string Err = null;
                    SelectFile(FileName, ref Err);
                }
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
