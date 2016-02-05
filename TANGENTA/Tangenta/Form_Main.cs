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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBConnectionControl40;
using LanguageControl;
using System.IO;

namespace Tangenta
{
    public partial class Form_Main : Form
    {
        public const string XML_ROOT_NAME = "Blagajna_Xml";
        public string RecentItemsFolder = null;

        internal string m_XmlFileName = null;


        public Form_Main()
        {
            LogFile.LogFile.Write(LogFile.LogFile.LOG_LEVEL_RUN_RELEASE, "Main()before InitializeComponent()!");
            InitializeComponent();
            if (Properties.Settings.Default.FullScreen)
            {
                this.FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }

            if (Get_RecentItemsFolder(ref RecentItemsFolder))
            {

                LogFile.LogFile.Write(1, "MESSAGE:Main_Form:Main_Form:Recent items folder = " + RecentItemsFolder);

            }
            else
            {
                LogFile.Error.Show("ERROR:Get_RecentItemsFolder(ref rfolder) failed!");
            }
        }


        private bool Get_RecentItemsFolder(ref string xRecentItemsFolder)
        {
            const string sRecentComboBoxItemsFolder = "\\RecentComboBoxItemsFolder";
            string rfolder = Properties.Settings.Default.RecentItemsFolder; 
            if (HasFolderReadWriteDeleteAccess(rfolder))
            {
                xRecentItemsFolder = rfolder;
                return true;
            }
            else
            {
                rfolder = Application.StartupPath + sRecentComboBoxItemsFolder;
                if (CanUseFolder(rfolder))
                {
                    RecentItemsFolder = rfolder;
                    Properties.Settings.Default.RecentItemsFolder = RecentItemsFolder;
                    Properties.Settings.Default.Save(); 
                    return true;
                }
                else
                {
                    for (; ; )
                    {
                        FolderBrowserDialog fbd = new FolderBrowserDialog();
                        fbd.Description = lngRPM.s_select_folder_for_recent_combobox_data.s;
                        if (fbd.ShowDialog() == DialogResult.OK)
                        {
                            rfolder = fbd.SelectedPath;
                            if (CanUseFolder(rfolder))
                            {
                                xRecentItemsFolder = rfolder;
                                Properties.Settings.Default.RecentItemsFolder = RecentItemsFolder;
                                Properties.Settings.Default.Save(); 
                                return true;
                            }
                            else
                            {
                                MessageBox.Show(lngRPM.s_CanNotWriteOrDeleteFileInFolder.s + rfolder + "\r\n" + lngRPM.s_SelectAnotherFolder);
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            //string Err = null;
            this.Text = lngRPM.s_Cashier.s;
            if (Program.bDemo)
            {
                this.Text += " DEMO";
            }
            if (Program.bSymulator)
            {
                this.Text += " (WITH INPUT SYMULATION)";
            }
            if (Program.ProgramDiagnostic)
            {
                this.Text += " DIAGNOSTIC";
            }

            //if (Program.m_SQLite_Support == null)
            //{
            //    Program.m_SQLite_Support = new SQLite_Support(this);
            //}

            ProgramDiagnostic.Diagnostic.Enabled = false;
            if (Program.ProgramDiagnostic)
            {
                ProgramDiagnostic.Diagnostic.Enabled = true;
                this.KeyUp += new KeyEventHandler(Main_Form_KeyUp);
            }

            m_XmlFileName = XML_ROOT_NAME;

            string IniFileFolder = Properties.Settings.Default.IniFileFolder;
            string sDBType = Properties.Settings.Default.DBType;
            bool bResult = DBSync.DBSync.Init(this,Program.bReset2FactorySettings, m_XmlFileName, IniFileFolder, ref sDBType,false,Program.bChangeConnection);

            Properties.Settings.Default.IniFileFolder = IniFileFolder;

            Properties.Settings.Default.DBType = sDBType;
            Properties.Settings.Default.Save();
            if (bResult)
            {
                if (m_usrc_Main.Init(this))
                {
                    return;
                }
            }
            this.Close();
            DialogResult = DialogResult.Abort;
        }

        void Main_Form_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.F10)
            {
                if (Program.ProgramDiagnostic)
                {
                    ProgramDiagnostic.Diagnostic.ShowResults();
                }
            }
        }
        public bool HasFolderReadWriteDeleteAccess(string folder)
        {
            if (folder.Length == 0)
            {
                return false;
            }
            try
            {
                string sTestFile = folder + "\\testfile.txt";
                if (File.Exists(sTestFile))
                {
                    File.Delete(sTestFile);
                }
                File.WriteAllText(sTestFile, "1");
                File.Delete(sTestFile);
                if (!File.Exists(sTestFile))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        private bool CanUseFolder(string rfolder)
        {
            if (Directory.Exists(rfolder))
            {
                if (HasFolderReadWriteDeleteAccess(rfolder))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    DirectoryInfo di = Directory.CreateDirectory(rfolder);
                    if (HasFolderReadWriteDeleteAccess(rfolder))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }

        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            
        }

        private void usrc_Invoice_Load(object sender, EventArgs e)
        {

        }



        private void m_usrc_Main_Load(object sender, EventArgs e)
        {

        }

        private void Exit()
        {
            if (m_usrc_Main.m_usrc_InvoiceMan.m_usrc_Invoice.m_usrc_ShopA != null)
            {
                if (m_usrc_Main.m_usrc_InvoiceMan.m_usrc_Invoice.m_usrc_ShopA.usrc_Editor1.m_tool_SelectItem != null)
                {
                    m_usrc_Main.m_usrc_InvoiceMan.m_usrc_Invoice.m_usrc_ShopA.usrc_Editor1.m_tool_SelectItem.Close();
                    m_usrc_Main.m_usrc_InvoiceMan.m_usrc_Invoice.m_usrc_ShopA.usrc_Editor1.m_tool_SelectItem = null;
                }
            }
            InvoiceDB.f_Atom_WorkPeriod.End(InvoiceDB.GlobalData.Atom_WorkPeriod_ID);
            if (Program.b_FVI_SLO)
            {
                if (Program.usrc_FVI_SLO1 != null)
                {
                    Program.usrc_FVI_SLO1.End();
                }
            }
        }

        private void m_usrc_Main_Exit_Click()
        {
             this.Close();
        }

        private bool AskToExit()
        {
            if (MessageBox.Show(this, lngRPM.s_RealyWantToExitProgram.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public long myCompany_Person_ID 
        { 
            get {
                    if (this.m_usrc_Main!=null)
                    {
                        return this.m_usrc_Main.myCompany_Person_ID;
                    }
                    else
                    {
                        return -1;
                    }
                }
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AskToExit())
            {
                Exit();
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }


    }
}
