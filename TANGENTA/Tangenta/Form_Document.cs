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
using Startup;

namespace Tangenta
{
    public partial class Form_Document : Form
    {
        public const string XML_ROOT_NAME = "Tangenta_Xml";
        public string RecentItemsFolder = null;
        public startup m_startup = null;
        internal string m_XmlFileName = null;
        public startup_step[] StartupStep = null;
        public Form ChildForm = null;

        public Form_Document()
        {
            LogFile.LogFile.Write(LogFile.LogFile.LOG_LEVEL_RUN_RELEASE, "Form_Document()before InitializeComponent()!");
            InitializeComponent();

            Program.nav = new NavigationButtons.Navigation();
            Program.nav.parentForm = this;
            Program.nav.m_eButtons = NavigationButtons.Navigation.eButtons.PrevNextExit;
            Program.nav.btn1_Image = Properties.Resources.Prev;
            Program.nav.btn2_Image = Properties.Resources.Next;
            Program.nav.btn3_Image = Properties.Resources.Exit_Program;
            Program.nav.btn1_Text = lngRPM.s_Previous.s;
            Program.nav.btn1_ToolTip_Text = lngRPMS.s_GoToPreviousStartupStep.s;
            Program.nav.btn2_Text = lngRPM.s_Next.s; ;
            Program.nav.btn2_ToolTip_Text = lngRPMS.s_GoToNextStartupStep.s;
            Program.nav.btn3_Text = "";
            Program.nav.btn3_ToolTip_Text = lngRPMS.s_GoToExitProgram.s;
            Program.nav.btn1_Visible = true;
            Program.nav.btn2_Visible = true;
            Program.nav.btn3_Visible = true;
            Program.nav.ExitProgramQuestionInLanguage = lngRPM.s_RealyWantToExitProgram.s;


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

                LogFile.LogFile.Write(1, "MESSAGE:Main_Form:Form_Document:Recent items folder = " + RecentItemsFolder);

            }
            else
            {
                LogFile.Error.Show("ERROR:Get_RecentItemsFolder(ref rfolder) failed!");
            }

            // Properties.Settings.Default.SplitterPositions =
            this.Text = lngRPM.s_Tangenta.s;
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


            ProgramDiagnostic.Diagnostic.Enabled = false;
            if (Program.ProgramDiagnostic)
            {
                ProgramDiagnostic.Diagnostic.Enabled = true;
                this.KeyUp += new KeyEventHandler(Main_Form_KeyUp);
            }

            m_usrc_Main.Visible = false;

            StartupStep = new startup_step[]
            {
                // CHECK DATABASE
                new startup_step(lngRPM.s_Startup_Check_DataBase.s,Startup_Check_DataBase,startup_step.eStep.Check_DataBase),
                // READ DB SETTINGS
                new startup_step(lngRPM.s_Startup_Read_DBSettings.s,this.m_usrc_Main.m_UpgradeDB.Read_DBSettings_Version,startup_step.eStep.Read_DBSettings_Version),
                // CHECK DB AND INSERT SAMPLE DATA IF DATABASE EMPTY
                new startup_step(lngRPM.s_Startup_CheckDBVersion.s,this.m_usrc_Main.CheckDBVersion,startup_step.eStep.CheckDBVersion),
                // GET ORGANISATION DATA
                new startup_step(lngRPM.s_Startup_GetOrganisationData.s,this.m_usrc_Main.m_usrc_InvoiceMan.m_usrc_Invoice.GetOrganisationData,startup_step.eStep.GetOrganisationData),
                // GET BASE CURRENCY
                new startup_step(lngRPM.s_Startup_GetBaseCurrency.s,this.m_usrc_Main.m_usrc_InvoiceMan.m_usrc_Invoice.Get_BaseCurrency,startup_step.eStep.GetBaseCurrency),
                // GET TAXATION
                new startup_step(lngRPM.s_Startup_GetTaxation.s,this.m_usrc_Main.m_usrc_InvoiceMan.m_usrc_Invoice.GetTaxation,startup_step.eStep.GetTaxation),
                // GET PROGRAM SETTINGS
                new startup_step(lngRPM.s_Startup_Get_shops_in_use.s,this.m_usrc_Main.Get_ProgramSettings,startup_step.eStep.Get_ProgramSettings),
                // GET SHOPB Item Data
                new startup_step(lngRPM.s_Startup_GetSimpleItemData.s,this.m_usrc_Main.m_usrc_InvoiceMan.m_usrc_Invoice.Get_ShopB_ItemData,startup_step.eStep.GetSimpleItemData),
                // GET SHOPC Item Data
                new startup_step(lngRPM.s_Startup_GetItemData.s,this.m_usrc_Main.m_usrc_InvoiceMan.m_usrc_Invoice.Get_ShopC_ItemData,startup_step.eStep.GetItemData),
                // LOGIN
                new startup_step(lngRPM.s_Startup_Login.s,this.m_usrc_Main.GetWorkPeriod,startup_step.eStep.GetWorkPeriod),
             };


            m_startup = new startup(this,
                                    StartupStep,
                                    Program.nav,
                                    Properties.Resources.Tangenta_Question
                                    );
        }

        public bool Startup_Check_DataBase(startup myStartup,object o, NavigationButtons.Navigation xnav, ref string Err)
        {
            string IniFileFolder = Properties.Settings.Default.IniFileFolder;
            string sDBType = null;
            sDBType = Properties.Settings.Default.DBType;
            bool bCanceled = false;
            bool bResult = DBSync.DBSync.Init(Program.bReset2FactorySettings, m_XmlFileName, IniFileFolder, ref sDBType, false, Program.bChangeConnection, xnav, ref myStartup.bNewDatabaseCreated,ref bCanceled);
            if (bCanceled)
            {
                myStartup.eNextStep = startup_step.eStep.Cancel;
                return false;
            }
            if (bResult)
            {
                Properties.Settings.Default.IniFileFolder = IniFileFolder;

                Properties.Settings.Default.DBType = sDBType;
                Properties.Settings.Default.Save();

                myStartup.eNextStep++;
            }
            else
            {
                myStartup.eNextStep = startup_step.eStep.Cancel;
            }
            return bResult;
        }


        private void Main_Form_Load(object sender, EventArgs e)
        {

            m_XmlFileName = XML_ROOT_NAME;
            //GetAllSplitContainerControlsRecusive<Control>(ref Program.ListOfAllSplitConatinerControls, this);
            //SetSplitContainerPositions(true, ref Program.ListOfAllSplitConatinerControls, Properties.Settings.Default.SplitContainerDistanceUserSettings);

            m_usrc_Main.Initialise(this);
        }

        public void GetAllSplitContainerControlsRecusive<T>(ref List<Control> retlist, Control control) where T : Control
        {
            List<Control> tmpList = null;
            foreach (Control item in control.Controls)
            {
                var ctr = item as T;
                if (ctr != null)
                {
                    string a = ctr.Name;
                    Type t = ctr.GetType();
                    if (t.Equals(typeof(SplitContainer)))
                    {
                        retlist.Add(ctr);
                    }
                    if (ctr.HasChildren)
                    {
                        if ( tmpList == null) tmpList = new List<Control>();
                        tmpList.Add(item);
                    }
                }
            }

            if (tmpList != null)
            {
                for (int i = 0; i < tmpList.Count; i++)
                {
                    GetAllSplitContainerControlsRecusive<T>(ref retlist, tmpList.ElementAt(i));
                }
            }

        }

        public  void SetSplitContainerPositions(bool firstime, ref List<Control> ctllist,string settingValues)
        {
            int i = 0;
            string[] distances = settingValues.Split(';');

            foreach (Control item in ctllist)
            {
                var ctr = item as SplitContainer;
                if (ctr != null)
                {
                    if (firstime)// at first time save design values for 
                    {
                        if (Program.SplitConatinerControlsDefaulValues.Length > 0) Program.SplitConatinerControlsDefaulValues += ";";
                        Program.SplitConatinerControlsDefaulValues += ctr.SplitterDistance;
                  }

                    int size = 0;
                    if (i < distances.Length) int.TryParse(distances[i].Trim(), out size);

                    int mesaurewith = ctr.Height;
                    if (ctr.Orientation == Orientation.Vertical) mesaurewith = ctr.Width;
                    if (size >= ctr.Panel1MinSize && size< mesaurewith - ctr.Panel2MinSize) //=SplitterDistance must be between Panel1MinSize and Width - Panel2MinSize.
                       {
                            ctr.SplitterDistance = size;
                    }
                    i++;
                }
            }
        }

        public  void SaveSplitContainerPositions(ref List<Control> ctllist)
        {
            string distances ="";
            foreach (Control item in ctllist)
            {
                var ctr = item as SplitContainer;
                if (ctr != null)
                {
                    if (distances.Length !=0) distances += ";";
                    distances += ctr.SplitterDistance;
                }
            }

            Properties.Settings.Default.SplitContainerDistanceUserSettings= distances;
            Properties.Settings.Default.Save();
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
            Properties.Settings.Default.Current_DocInvoice_ID = m_usrc_Main.m_usrc_InvoiceMan.m_usrc_InvoiceTable.Current_Doc_ID;
            Properties.Settings.Default.Save();
            if (m_usrc_Main.m_usrc_InvoiceMan.m_usrc_Invoice.m_usrc_ShopA != null)
            {
                if (m_usrc_Main.m_usrc_InvoiceMan.m_usrc_Invoice.m_usrc_ShopA.usrc_Editor1.m_tool_SelectItem != null)
                {
                    m_usrc_Main.m_usrc_InvoiceMan.m_usrc_Invoice.m_usrc_ShopA.usrc_Editor1.m_tool_SelectItem.Close();
                    m_usrc_Main.m_usrc_InvoiceMan.m_usrc_Invoice.m_usrc_ShopA.usrc_Editor1.m_tool_SelectItem = null;
                }
            }
            TangentaDB.f_Atom_WorkPeriod.End(TangentaDB.GlobalData.Atom_WorkPeriod_ID);
            if (Program.b_FVI_SLO)
            {
                if (Program.usrc_FVI_SLO1 != null)
                {
                    Program.usrc_FVI_SLO1.End();
                }
            }

            //SaveSplitContainerPositions(ref Program.ListOfAllSplitConatinerControls);
        }

        private void m_usrc_Main_Exit_Click()
        {
             this.Close();
        }

        private bool AskToExit()
        {
            if ((Program.nav.eExitResult == NavigationButtons.Navigation.eEvent.PREV) && (Program.bFirstTimeInstallation))
            {
                return true;
            }
            else
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
        }

        public long myOrganisation_Person_ID 
        { 
            get {
                    if (this.m_usrc_Main!=null)
                    {
                        return this.m_usrc_Main.myOrganisation_Person_ID;
                    }
                    else
                    {
                        return -1;
                    }
                }
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.m_startup.eNextStep == startup_step.eStep.Cancel)
            {
                return;
            }
            else
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

        private void Form_Document_Shown(object sender, EventArgs e)
        {
            string Err = null;
            if (m_startup.Execute(Program.bFirstTimeInstallation, ref Err))
            {
                m_usrc_Main.Init(Program.nav);
                m_startup.RemoveControl();
                m_usrc_Main.Visible = true;
                m_usrc_Main.Activate_dgvx_XInvoice_SelectionChanged();
            }
            else
            {
                this.Close();
                DialogResult = DialogResult.Abort;
            }
        }

    }
}
