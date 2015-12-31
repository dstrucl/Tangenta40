using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Diagnostics;

namespace ComboBox_Recent
{

    [ToolboxItem(true)]
    [System.Drawing.ToolboxBitmapAttribute(@"G:\Plates\ComboBox_Recent\Resources\ComboBoxR.bmp")]
    public class ComboBox_RecentList : ComboBox
    {

        public delegate void delagate_EnterPressed(object sender);
        public event delagate_EnterPressed EnterPressed = null;


        public Font myFont;
        private bool bDisplayTime = true;
        private ContextMenu mnuContextMenu = null;
        private bool Insert_on_KeyPress = true;
        private char KeyToInsert = '\r';
        DataTable dt;
        private int max_count = 10;
        //public string[] my_items = new string[max_count];
        private string m_Identifier;

        private string FileName;
        private string FolderName = "";
        private string m_Key;
        private string m_KeyTime;
        private bool m_ReadOnly = false;

        DataTable dtRecentFiles = null;
        private const string DefaultComboBoxRecentXmlFile = "ComboBoxRecentXmlFile.xml";

        //public char EnterKey
        //{

        //    get { return KeyToInsert; }
        //    set { KeyToInsert = value; }
        //}

        public bool ReadOnly
        {
            get { return m_ReadOnly; }
            set { m_ReadOnly = value;
                if (m_ReadOnly)
                {
                    base.Enabled = false;
                }
                else
                {
                    base.Enabled = true;
                }

                }
        }

        public int MaxRecentCount
        {
            get { return max_count; }
            set { max_count = value; }
        }

        public bool InsertOnKeyPress
        {
            get { return Insert_on_KeyPress; }
            set { Insert_on_KeyPress = value; }
        }

        [EditorAttribute(typeof(System.Windows.Forms.Design.FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string RecentItemsFolder
        {
            get { return FolderName; }
            set
            {
                FolderName = value;
                Init();
            }
        }

        public string RecentItemsFile
        {
            get { return FolderName + "\\" + FileName; }
        }

        public string RecentItemsFileName
        {
            get { return FileName; }
            set
            {
                FileName = value;
            }
        }

        public bool DisplayTime
        {
            get { return bDisplayTime; }
            set
            {
                bDisplayTime = value;
            }
        }

        public string Key
        {
            get { return m_Key; }
            set
            {
                m_Key = value;
                m_KeyTime = m_Key + "_Time";
            }
        }

        public void clear()
        {
            try
            {
                if (File.Exists(FileName))
                {
                    File.Delete(FileName);
                    base.Items.Clear();
                    dtRecentFiles.Clear();
                }
                Init();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error: Can not delete or create recent list file :\"" + FileName + "\"!\r\n Exception = " + ex);
            }
        }


        private void ComboBox_RecentList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Insert_on_KeyPress)
            {
                ComboBox CmbBox = (ComboBox)sender;
                if (e.KeyChar == KeyToInsert)
                {
                    // Enter new item
                    Set(CmbBox.Text);
                    if (EnterPressed != null)
                    {
                        EnterPressed(this);
                    }
                }
            }
        }

        public bool Set(string sNew)
        {
            bool bRet = false;
            if (sNew.Length > 0)
            {
                SetLast(sNew);
                bRet = Save();
                this.SelectedIndex = 0;
            }
            return bRet;
        }

        private void ComboBox_RecentList_ParentChanged(object sender, EventArgs e)
        {
            //Init();
        }

        private void ClearRecentList(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to clear Recent List of " + Key + "?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                clear();
            }
        }

        private void ShowRecentListTable(object sender, EventArgs e)
        {
            ShowRecentListTable_Form srlt = new ShowRecentListTable_Form(dtRecentFiles, FileName);
            srlt.ShowDialog();
        }

        private void ComboBox_RecentList_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Let's highlight the currently selected item like any well 
            myIteM mitm = (myIteM)this.Items[e.Index];
            string str = mitm.item;
            string TimeStr = mitm.time.ToString();
            // behaved combo box should
           
            Rectangle rect = new Rectangle();
            int leftp = 0;

            //is the mouse hovering over a combobox item??            
            if ((e.State & DrawItemState.Selected) != 0)
            {
                //this code keeps the last item drawn from having a Bisque background. 
                e.Graphics.FillRectangle(Brushes.Blue, e.Bounds);
                e.Graphics.DrawString(str, myFont, Brushes.White,
                                      new Point(2, e.Bounds.Y));

                if (bDisplayTime)
                {
                    Size size = e.Graphics.MeasureString(TimeStr, myFont).ToSize();
                    leftp = e.Bounds.Right - size.Width;
                    rect = new Rectangle(leftp, e.Bounds.Top, size.Width, size.Height);
                    e.Graphics.FillRectangle(Brushes.Gray, rect);
                    Debug.WriteLine("selected rect.Height=" + rect.Height.ToString());
                    e.Graphics.DrawString(TimeStr, myFont, Brushes.Yellow,
                                      new Point(leftp, e.Bounds.Y));
                }
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.Bisque, e.Bounds);
                e.Graphics.DrawString(str, myFont, Brushes.Blue,
                                      new Point(2, e.Bounds.Y));
                if (bDisplayTime)
                {
                    Size size = e.Graphics.MeasureString(TimeStr, myFont).ToSize();
                    leftp = e.Bounds.Right - size.Width;
                    rect = new Rectangle(leftp, e.Bounds.Top, size.Width, size.Height);
                    Debug.WriteLine("1 rect.Height=" + rect.Height.ToString());
                    e.Graphics.FillRectangle(Brushes.LightGray, rect);

                    e.Graphics.DrawString(TimeStr, myFont, Brushes.Blue,
                                          new Point(leftp, e.Bounds.Y));
                }
            }

        }

        private bool DisplayMember
        {
            get { return true; }
        }



        public ComboBox_RecentList()
        {
            myFont = this.Font;//new System.Drawing.Font("Comic Sans", 11);
            this.KeyPress += new KeyPressEventHandler(ComboBox_RecentList_KeyPress);
            dtRecentFiles = new DataTable();
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DrawItem += new DrawItemEventHandler(ComboBox_RecentList_DrawItem);
            this.ParentChanged += new EventHandler(ComboBox_RecentList_ParentChanged);
            base.DisplayMember = "text";
            ContextMenu mnuContextMenu = new ContextMenu();
            mnuContextMenu = new ContextMenu();
            mnuContextMenu.MenuItems.Add("Clear Recent List", new EventHandler(ClearRecentList));
            mnuContextMenu.MenuItems.Add("Show Recent List Table", new EventHandler(ShowRecentListTable));
            this.ContextMenu = mnuContextMenu;
            dtRecentFiles.TableName = "RecentItems";
        }

        private bool Save()
        {
            try
            {
                int icount_ComboBox_Items = this.Items.Count;

                int icount_dtRecentFiles_rows_count = dtRecentFiles.Rows.Count;

                while (icount_dtRecentFiles_rows_count < icount_ComboBox_Items)
                {
                    DataRow dr = dtRecentFiles.NewRow();
                    dr[m_Key] = null;
                    dr[m_KeyTime] = DateTime.MinValue;
                    dtRecentFiles.Rows.Add(dr);
                    icount_dtRecentFiles_rows_count = dtRecentFiles.Rows.Count;
                }

                int i;
                for (i = 0; i < icount_dtRecentFiles_rows_count; i++)
                {
                    if (i < icount_ComboBox_Items)
                    {
                        myIteM mitm = (myIteM)this.Items[i];
                        dtRecentFiles.Rows[i][m_Key] = mitm.item;
                        dtRecentFiles.Rows[i][m_KeyTime] = mitm.time;
                    }
                    else
                    {
                        dtRecentFiles.Rows[i][Key] = null;
                        dtRecentFiles.Rows[i][m_KeyTime] = DateTime.MinValue;
                    }
                }

                dtRecentFiles.WriteXml(RecentItemsFile, XmlWriteMode.WriteSchema);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error can not save recentb items in module ComboBox_RecentList! Exception = " + ex.Message);
                return false;
            }
        }

        public void SetLast(string str)
        {
            if (str.Length > 0)
            {
                int iFound = Find(str);
                if (iFound >= 0)
                {
                    ReplaceLast(iFound);
                }
                else
                {
                    // items not found yet throw oldest -first one away !

                    if (this.Items.Count < max_count)
                    {
                        myIteM mitm1 = new myIteM();
                        mitm1.item = str;
                        mitm1.time = DateTime.Now;
                        this.Items.Insert(0, mitm1);
                    }
                    else
                    {
                        int i;
                        for (i = this.Items.Count - 1; i > 0; i--)
                        {
                            this.Items[i] = this.Items[i - 1];
                        }
                        myIteM mitm2 = new myIteM();
                        mitm2.item = str;
                        mitm2.time = DateTime.Now;
                        this.Items[0] = mitm2;
                    }
                }
            }
        }

        private void ReplaceLast(int iFound)
        {
            int i;
            myIteM mitm_found = (myIteM) this.Items[iFound];
            for (i = iFound; i > 0; i--)
            {
                this.Items[i] = this.Items[i - 1];
            }
            mitm_found.time = DateTime.Now;
            Items[0] = mitm_found;
        }

        private int Find(string str)
        {
            int i;
            for (i = 0; i < max_count; i++)
            {
                if (i < this.Items.Count)
                {
                    myIteM mitm = (myIteM)this.Items[i];
                    if (mitm.item.Equals(str))
                    {
                        return i;
                    }
                }
                else
                {
                    return -1;
                }
            }
            return -1;
        }

        private bool Init()
        {
            try
            {
                Items.Clear();
                if (Key == null)
                {
                    return false;
                }
                XmlReadMode xrmode = dtRecentFiles.ReadXml(RecentItemsFile);
                if (dtRecentFiles.Columns.Contains(Key))
                {
                }
                else
                {
                    dtRecentFiles.Columns.Add(Key, typeof(string));
                    dtRecentFiles.WriteXml(RecentItemsFile, XmlWriteMode.WriteSchema);
                }
            }
            catch (Exception ex1)
            {
                if (!this.DesignMode)
                {
                    if (RecentItemsFolder.Length > 0)
                    {
                        if (!File.Exists(RecentItemsFile))
                        {
                            if (MessageBox.Show("Recent Items Xml File: \"" + RecentItemsFile + "\" does not exists.\r\n Create \"" + RecentItemsFile + "\"?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                dtRecentFiles.Clear();
                                dtRecentFiles.Columns.Clear();
                                dtRecentFiles.Columns.Add(m_Key, typeof(string));
                                dtRecentFiles.Columns.Add(m_KeyTime, typeof(DateTime));
                                base.Items.Clear();
                                try
                                {
                                    dtRecentFiles.WriteXml(RecentItemsFile, XmlWriteMode.WriteSchema);
                                }
                                catch (Exception ex2)
                                {
                                    MessageBox.Show("Error can not write " + RecentItemsFile + " !" + " Exception =" + ex2);
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Exception = " + ex1.Message);
                            return false;
                        }
                    }
                    else
                    {
                        //MessageBox.Show("Recent items folder is not defined yet");
                        return false;
                    }
                }
            }

            foreach (DataRow dr in dtRecentFiles.Rows)
            {
                if (dr[Key].GetType() == typeof(string))
                {
                    myIteM mitm = new myIteM();
                    mitm.item = (string)dr[m_Key];
                    if (dr[m_KeyTime].GetType() == typeof(DateTime))
                    {
                        mitm.time = (DateTime)dr[m_KeyTime];
                    }
                    else
                    {
                        mitm.time = DateTime.MinValue;
                    }

                    this.Items.Add(mitm);
                }
            }
            if (this.Items.Count > 0)
            {
                this.SelectedIndex = 0;
            }
            return true;
        }

        //public bool Init(string filename, string sKey)
        //{
        //    if (sKey != null)
        //    {
        //        Key = sKey;
        //    }
        //    if (filename != null)
        //    {
        //        RecentItemsFile = filename;
        //    }
        //    return Init();
        //}
    }
    public class myIteM
    {
       public string item;
       public DateTime time;
       public string text
       {
           get { return item; }
       }
    }
}

