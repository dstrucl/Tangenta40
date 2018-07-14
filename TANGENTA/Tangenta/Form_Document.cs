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
using System.Diagnostics;
using TangentaDB;
using System.Reflection;
using static Startup.startup_step;
using NavigationButtons;
using TangentaSampleDB;
using Country_ISO_3166;
using HUDCMS;

namespace Tangenta
{
    public partial class Form_Document : Form
    {
        private string default_FormName = null;
        private HUDCMS.HelpWizzardTagDC tagDCTop = null;
        private HUDCMS.HelpWizzardTagDC tagDC_DocType_Invoice = null;
        private HUDCMS.HelpWizzardTagDC tagDC_DocType_ProformeInvoice = null;
        private HUDCMS.HelpWizzardTagDC tagDC_EmptyDB_true = null;
        private HUDCMS.HelpWizzardTagDC tagDC_EmptyDB_false = null;
        private HUDCMS.HelpWizzardTagDC tagDC_MultiUser_true = null;
        private HUDCMS.HelpWizzardTagDC tagDC_MultiUser_false = null;
        private HUDCMS.HelpWizzardTagDC tagDC_usrc_Invoice_Visible_true = null;
        private HUDCMS.HelpWizzardTagDC tagDC_usrc_Invoice_Visible_false = null;
        private HUDCMS.HelpWizzardTagDC tagDC_usrc_InvoiceHead_Visible_true = null;
        private HUDCMS.HelpWizzardTagDC tagDC_usrc_InvoiceHead_Visible_false = null;
        private HUDCMS.HelpWizzardTagDC tagDC_usrc_InvoiceTable_Visible_true = null;
        private HUDCMS.HelpWizzardTagDC tagDC_usrc_InvoiceTable_Visible_false = null;
        private HUDCMS.HelpWizzardTagDC tagDC_usrc_Invoice_Mode_ViewMode = null;
        private HUDCMS.HelpWizzardTagDC tagDC_usrc_Invoice_Mode_EditMode = null;
        private HUDCMS.HelpWizzardTagDC tagDC_ShopA_Visible_true = null;
        private HUDCMS.HelpWizzardTagDC tagDC_ShopA_Visible_false = null;
        private HUDCMS.HelpWizzardTagDC tagDC_ShopB_Visible_true = null;
        private HUDCMS.HelpWizzardTagDC tagDC_ShopB_Visible_false = null;
        private HUDCMS.HelpWizzardTagDC tagDC_ShopB_Groups0 = null;
        private HUDCMS.HelpWizzardTagDC tagDC_ShopB_Groups1 = null;
        private HUDCMS.HelpWizzardTagDC tagDC_ShopB_Groups2 = null;
        private HUDCMS.HelpWizzardTagDC tagDC_ShopB_Groups3 = null;
        private HUDCMS.HelpWizzardTagDC tagDC_ShopC_Visible_true = null;
        private HUDCMS.HelpWizzardTagDC tagDC_ShopC_Visible_false = null;
        private HUDCMS.HelpWizzardTagDC tagDC_ShopC_Groups0 = null;
        private HUDCMS.HelpWizzardTagDC tagDC_ShopC_Groups1 = null;
        private HUDCMS.HelpWizzardTagDC tagDC_ShopC_Groups2 = null;
        private HUDCMS.HelpWizzardTagDC tagDC_ShopC_Groups3 = null;
        private HUDCMS.HelpWizzardTagDC tagDCBottom = null;

        internal HUDCMS.HelpWizzardTagDC[] TagDCs = null;

        private Form_FirstTimeInstallationGreeting frm_Form_FirstTimeInstallationGreeting = null;
        public const string XML_ROOT_NAME = "Tangenta_Xml";

        public startup m_startup = null;
        internal string m_XmlFileName = null;
        public startup_step[] StartupStep = null;
        public Form ChildForm = null;

        public string CodeTables_IniFileFolder = null;
        public string xmlCodeTables = "CodeTables.xml";
        public string DataBaseType = null;
        public bool bNewDatabaseCreated = false;
        public bool bInit_DBType_Canceled = false;


        internal Booting_00_TangentaAbout booting_00_TangentaAbout = null;
        internal Booting_01_TangentaLicence booting_01_TangentaLicence = null;
        internal Booting_02_Check_DBType booting_02_Check_DBType = null;
        internal Booting_03_Check_DBConnection booting_03_Check_DBConnection = null;
        internal Booting_04_Check_DBSettings booting_04_Check_DBSettings = null;
        internal Booting_05_Check_myOrganisation_Data booting_05_Check_MyOrganisation_Data = null;
        internal Booting_06_GetBaseCurrency booting_06_GetBaseCurrency = null;
        internal Booting_07_GetTaxation booting_07_GetTaxation = null;
        internal Booting_08_GetProgramSettings booting_08_GetProgramSettings = null;
        internal Booting_09_GetShopsPriceLists booting_09_GetShopsPriceLists = null;
        internal Booting_10_GetShopB_Items booting_10_GetShopB_Items = null;
        internal Booting_11_GetShopC_Items booting_11_GetShopC_Items = null;
        internal Booting_12_GetPrinters booting_12_GetPrinters = null;
        internal Booting_13_Login booting_13_Login = null;

        private Form_Document_WizzardForHelp frm_Document_WizzardForHelp = null;

        public Form_Document()
        {
            LogFile.LogFile.WriteRELEASE("Form_Document()before InitializeComponent()!");
            InitializeComponent();
            default_FormName = this.Name;
            this.Icon = Properties.Resources.Tangenta_Icon;
            Program.nav = new NavigationButtons.Navigation();
            if (Program.Auto_NEXT)
            {
                Program.nav.m_Auto_NEXT = new NavigationButtons.Auto_NEXT(Program.Auto_NEXT_in_miliseconds);
            }
            Program.nav.parentForm = this;
            Program.nav.OwnerForm = this;
            Program.nav.m_eButtons = NavigationButtons.Navigation.eButtons.PrevNextExit;
            Program.nav.btn1_Image = Properties.Resources.Prev;
            Program.nav.btn2_Image = Properties.Resources.Next;
            Program.nav.btn3_Image = Properties.Resources.Exit_Program;
            Program.nav.btn1_Text = lng.s_Previous.s;
            Program.nav.btn1_ToolTip_Text = lng.s_GoToPreviousStartupStep.s;
            Program.nav.btn2_Text = lng.s_Next.s; ;
            Program.nav.btn2_ToolTip_Text = lng.s_GoToNextStartupStep.s;
            Program.nav.btn3_Text = "";
            Program.nav.btn3_ToolTip_Text = lng.s_GoToExitProgram.s;
            Program.nav.btn1_Visible = true;
            Program.nav.btn2_Visible = true;
            Program.nav.btn3_Visible = true;
            Program.nav.ExitProgramQuestionInLanguage = lng.s_RealyWantToExitProgram.s;


            if (Properties.Settings.Default.FullScreen)
            {
                this.FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }


            // Properties.Settings.Default.SplitterPositions =
            this.Text = lng.s_Tangenta.s;
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
                LogFile.LogFile.LogLevel = LogFile.LogFile.LOG_LEVEL_DEBUG_RELEASE;
                LogFile.LogFile.LogManager(this,true);
            }


            ProgramDiagnostic.Diagnostic.Enabled = false;
            if (Program.ProgramDiagnostic)
            {
                ProgramDiagnostic.Diagnostic.Enabled = true;
                this.KeyUp += new KeyEventHandler(Main_Form_KeyUp);
            }

            m_usrc_Main.Visible = false;


            m_startup = new startup(this,
                        Program.nav,
                        Properties.Resources.Tangenta_Question,
                        Program.bFirstTimeInstallation
                        );

            booting_00_TangentaAbout = new Booting_00_TangentaAbout(this, m_startup);
            booting_01_TangentaLicence = new Booting_01_TangentaLicence(this, m_startup);
            booting_02_Check_DBType = new Booting_02_Check_DBType(this, m_startup);
            booting_03_Check_DBConnection = new Booting_03_Check_DBConnection(this, m_startup);
            booting_04_Check_DBSettings = new Booting_04_Check_DBSettings(this, m_startup);
            booting_05_Check_MyOrganisation_Data = new Booting_05_Check_myOrganisation_Data(this, m_startup);
            booting_06_GetBaseCurrency = new Booting_06_GetBaseCurrency(this, m_startup);
            booting_07_GetTaxation = new Booting_07_GetTaxation(this, m_startup);
            booting_08_GetProgramSettings = new Booting_08_GetProgramSettings(this, m_startup);
            booting_09_GetShopsPriceLists = new Booting_09_GetShopsPriceLists(this, m_startup);
            booting_10_GetShopB_Items = new Booting_10_GetShopB_Items(this, m_startup);
            booting_11_GetShopC_Items = new Booting_11_GetShopC_Items(this, m_startup);
            booting_12_GetPrinters = new Booting_12_GetPrinters(this, m_startup);
            booting_13_Login = new Booting_13_Login(this, m_startup);

            m_startup.ShowNews();
            m_startup.m_usrc_Startup.WebBrowserControl_DocumentCompleted += M_usrc_Startup_WebBrowserControl_DocumentCompleted;

            StartupStep = new startup_step[]
            {

                // TANGENTA_About
                booting_00_TangentaAbout.CreateStep(),
                
                // TANGENTA_Licence
                booting_01_TangentaLicence.CreateStep(),

                // CHECK DATABASE
                booting_02_Check_DBType.CreateStep(),
                
                 // CHECK DBConnection
                booting_03_Check_DBConnection.CreateStep(),

                // CHECK DBSettings
                booting_04_Check_DBSettings.CreateStep(),

                // CHECK TangentaDB.myOrg
                booting_05_Check_MyOrganisation_Data.CreateStep(),

                // CHECK BaseCurrency
                booting_06_GetBaseCurrency.CreateStep(),

                // GET Taxation
                booting_07_GetTaxation.CreateStep(),

                // GET ProgramSettings
                booting_08_GetProgramSettings.CreateStep(),

                // GET PriceList
                booting_09_GetShopsPriceLists.CreateStep(),

                // GET SHOPB Item Data
                booting_10_GetShopB_Items.CreateStep(),

                // GET SHOPC Item Data
                booting_11_GetShopC_Items.CreateStep(),

                // GET Printer
                booting_12_GetPrinters.CreateStep(),

                // LOGIN
                booting_13_Login.CreateStep()
             
            };

            m_startup.Steps = StartupStep;

            m_startup.m_usrc_Startup.ExitProgram += M_usrc_Startup_ExitProgram;
            m_startup.m_usrc_Startup.ExitPrev += M_usrc_Startup_ExitPrev;
            m_startup.m_usrc_Startup.Finished += M_usrc_Startup_Finished;

            Program.nav.oStartup = m_startup;
        }

        internal void WizzardShow_ShopsVisible(string xshops_inuse)
        {
            m_usrc_Main.WizzardShow_ShopsVisible(xshops_inuse);
        }

        internal void WizzardShow_usrc_Invoice_Head_Visible(bool bvisible)
        {
            m_usrc_Main.WizzardShow_usrc_Invoice_Head_Visible(bvisible);
        }

        internal void WizzardShow_InvoiceTable_Visible(bool bvisible)
        {
            m_usrc_Main.WizzardShow_InvoiceTable_Visible(bvisible);
        }

        internal void WizzardShow_DocInvoice(string xDocInvoice)
        {
            m_usrc_Main.WizzardShow_DocInvoice(xDocInvoice);
        }

        private void M_usrc_Startup_WebBrowserControl_DocumentCompleted(string url)
        {
            if (url.Contains("News.html"))
            {
                m_startup.StartExecution();//when Startup has finished event M_usrc_Startup_Finished is triggered
            }
        }

        private void M_usrc_Startup_ExitPrev()
        {
            Program.nav.eExitResult = NavigationButtons.Navigation.eEvent.PREV;
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void M_usrc_Startup_ExitProgram()
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }


      


        private void Main_Form_Load(object sender, EventArgs e)
        {

            m_XmlFileName = XML_ROOT_NAME;
            m_usrc_Main.Initialise(this);
        }




        private void Main_Form_KeyUp(object sender, KeyEventArgs e)
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

        private void Exit()
        {
            LayoutSave();

            string sdb = DBSync.DBSync.DataBase;
            if (sdb != null)
            {
                Properties.Settings.Default.Current_DataBase = DBSync.DBSync.DataBase;
            }

            // TRICKY DOCHANGE
            Properties.Settings.Default.Current_DocInvoice_ID = (long) m_usrc_Main.m_usrc_TableOfDocuments.Current_Doc_ID.V;
            Properties.Settings.Default.LastDocInvoiceType = Program.RunAs;
            Properties.Settings.Default.Save();
            if (m_usrc_Main.m_usrc_DocumentEditor.m_usrc_ShopA != null)
            {
                if (m_usrc_Main.m_usrc_DocumentEditor.m_usrc_ShopA.usrc_Editor1.m_tool_SelectItem != null)
                {
                    m_usrc_Main.m_usrc_DocumentEditor.m_usrc_ShopA.usrc_Editor1.m_tool_SelectItem.Close();
                    m_usrc_Main.m_usrc_DocumentEditor.m_usrc_ShopA.usrc_Editor1.m_tool_SelectItem = null;
                }
            }
            ID atom_work_period_id = TangentaDB.GlobalData.Atom_WorkPeriod_ID;
            if (ID.Validate(atom_work_period_id))
            {
                TangentaDB.f_Atom_WorkPeriod.End(TangentaDB.GlobalData.Atom_WorkPeriod_ID);
            }
            if (Program.b_FVI_SLO)
            {
                if (Program.usrc_FVI_SLO1 != null)
                {
                    Program.usrc_FVI_SLO1.End();
                }
            }


            //SaveSplitContainerPositions(ref Program.ListOfAllSplitConatinerControls);
        }

        private void LayoutSet()
        {
            m_usrc_Main.usrc_FVI_SLO1.Visible = Program.b_FVI_SLO;

            if (Properties.Settings.Default.Form_Document_WindowState >= 0)
            {
                switch (Properties.Settings.Default.Form_Document_WindowState)
                {
                    case 0:
                        this.WindowState = FormWindowState.Minimized;
                        break;
                    case 1:
                        this.WindowState = FormWindowState.Normal;

                        if (Properties.Settings.Default.Form_Document_Width >= 0)
                        {
                            this.Width = Properties.Settings.Default.Form_Document_Width;
                        }

                        if (Properties.Settings.Default.Form_Document_Height >= 0)
                        {
                            this.Height = Properties.Settings.Default.Form_Document_Height;
                            this.Left = Properties.Settings.Default.Form_Document_Left;
                            this.Top = Properties.Settings.Default.Form_Document_Top;

                        }
                        break;

                    case 2:
                        this.WindowState = FormWindowState.Maximized;
                        break;
                }
            }
            m_usrc_Main.SetSplitControlsSpliterDistance();
        }

        private void LayoutSave()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Minimized:
                    Properties.Settings.Default.Form_Document_WindowState = 0;
                    break;
                case FormWindowState.Normal:
                    Properties.Settings.Default.Form_Document_WindowState = 1;
                    Properties.Settings.Default.Form_Document_Width = this.Width;
                    Properties.Settings.Default.Form_Document_Height = this.Height;
                    Properties.Settings.Default.Form_Document_Left = this.Left;
                    Properties.Settings.Default.Form_Document_Top = this.Top;
                    break;
                case FormWindowState.Maximized:
                    Properties.Settings.Default.Form_Document_WindowState = 2;
                    break;
            }

            if (this.m_usrc_Main != null)
            {
                this.m_usrc_Main.SaveSplitControlsSpliterDistance();
            }

        }

        private void m_usrc_Main_Exit_Click()
        {
             this.Close();
        }

        private bool AskToExit()
        {
            if (((Program.nav.eExitResult == NavigationButtons.Navigation.eEvent.PREV) && (Program.bFirstTimeInstallation)) ||
                ((Program.nav.eExitResult == NavigationButtons.Navigation.eEvent.EXIT)&&(Program.nav.m_eButtons== Navigation.eButtons.PrevNextExit)))
            {
                return true;
            }
            else
            {
                if (XMessage.Box.Show(Program.bStartup,this, lng.s_RealyWantToExitProgram, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.m_startup.Exit )
            {
                Exit();
                e.Cancel = false;
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
            LogFile.LogFile.WriteDEBUG("** Form_Document:Form_Document_Shown():before m_startup.Execute!");

        }

        private void M_usrc_Startup_Finished()
        {
            //Startup finished

            LogFile.LogFile.WriteDEBUG("** Form_Document:Form_Document_Shown():after m_startup.Execute!");

            //if (Program.bFirstTimeInstallation)
            long iCountNumberOfAllInvoices = fs.NumberOInvoicesInDatabase();
            long iCountNumberOfAllProformaInvoices = fs.NumberOfProformaInvoicesInDatabase();

            if (iCountNumberOfAllInvoices + iCountNumberOfAllProformaInvoices == 0)
            {
                if (frm_Form_FirstTimeInstallationGreeting==null)
                {
                    frm_Form_FirstTimeInstallationGreeting = new Form_FirstTimeInstallationGreeting();
                    frm_Form_FirstTimeInstallationGreeting.Owner = this;
                }
                else if (frm_Form_FirstTimeInstallationGreeting.IsDisposed)
                {
                    frm_Form_FirstTimeInstallationGreeting = new Form_FirstTimeInstallationGreeting();
                    frm_Form_FirstTimeInstallationGreeting.Owner = this;
                }
                frm_Form_FirstTimeInstallationGreeting.Show();
            }
            Program.bFirstTimeInstallation = false;
            m_usrc_Main.Init(null);

            LogFile.LogFile.WriteDEBUG("** Form_Document:Form_Document_Shown():after m_usrc_Main.Init(null)!");

            CheckOrganisationDataChange();

            m_startup.RemoveControl();

            LogFile.LogFile.WriteDEBUG("** Form_Document:Form_Document_Shown():after m_startup.RemoveControl()!");

            LayoutSet();

            m_usrc_Main.Visible = true;

            m_usrc_Main.Activate_dgvx_XInvoice_SelectionChanged();

            LogFile.LogFile.WriteDEBUG("** Form_Document:Form_Document_Shown():after m_usrc_Main.Activate_dgvx_XInvoice_SelectionChanged()!");

            SetNewFormTag();
            m_usrc_Main.LayoutChanged += M_usrc_Main_LayoutChanged;
        }


        private void M_usrc_Main_LayoutChanged()
        {
            SetNewFormTag();
            m_usrc_Main.HelpReload();
        }


        internal string GetStringTag(ref long numberOfAll, ref string[] sTagConditions, ref string sXMLFiletag)
        {
            string sNewTag = "_";
            sXMLFiletag = "_";
            List<string> tag_conditions = new List<string>();
            if (this.m_usrc_Main.IsDocInvoice)
            {
                numberOfAll = fs.NumberOInvoicesInDatabase();
                sNewTag += "i";
                tag_conditions.Add(tagDC_DocType_Invoice.NamedCondition);
            }
            else if (this.m_usrc_Main.IsDocProformaInvoice)
            {
                numberOfAll = fs.NumberOfProformaInvoicesInDatabase();
                sNewTag += "p";
                tag_conditions.Add(tagDC_DocType_ProformeInvoice.NamedCondition);
            }

            if (numberOfAll < 0)
            {
                LogFile.Error.Show("ERROR:Tangenta:Form_Document:SetNewFormTag:  numberOfAll invoices or proforma invoices < 0 !");
            }
            else if (numberOfAll == 0)
            {
                sNewTag += "Z";
                sXMLFiletag += "Z";
                tag_conditions.Add(tagDC_EmptyDB_true.NamedCondition);
            }
            else if (numberOfAll > 0)
            {
                sNewTag += "N";
                sXMLFiletag += "N";
                tag_conditions.Add(tagDC_EmptyDB_false.NamedCondition);
            }


            if (Program.OperationMode.MultiUser)
            {
                sNewTag += "m";
                sXMLFiletag += "m";
                tag_conditions.Add(tagDC_MultiUser_true.NamedCondition);
            }
            else
            {
                sNewTag += "s";
                sXMLFiletag += "s";
                tag_conditions.Add(tagDC_MultiUser_false.NamedCondition);
            }

            if (m_usrc_Main.m_usrc_Invoice_Visible)
            {
                sNewTag += "I";
                tag_conditions.Add(tagDC_usrc_Invoice_Visible_true.NamedCondition);

                if (m_usrc_Main.m_usrc_InvoiceHead_Visible)
                {
                    sNewTag += "h1";
                    tag_conditions.Add(tagDC_usrc_InvoiceHead_Visible_true.NamedCondition);
                }
                else
                {
                    sNewTag += "h0";
                    tag_conditions.Add(tagDC_usrc_InvoiceHead_Visible_false.NamedCondition);
                }

                if (m_usrc_Main.m_usrc_Invoice_ViewMode)
                {
                    if (sNewTag.Contains("N"))
                    {
                        sNewTag += "v";
                        tag_conditions.Add(tagDC_usrc_Invoice_Mode_ViewMode.NamedCondition);
                    }
                }
                else
                {
                    if (sNewTag.Contains("N"))
                    {
                        sNewTag += "e";
                        sXMLFiletag += "e";
                        tag_conditions.Add(tagDC_usrc_Invoice_Mode_EditMode.NamedCondition);
                    }
                }
                if (m_usrc_Main.ShopA_Visible)
                {
                    sNewTag += "A";
                    tag_conditions.Add(tagDC_ShopA_Visible_true.NamedCondition);
                }
                else
                {
                    tag_conditions.Add(tagDC_ShopA_Visible_false.NamedCondition);
                }

                if (m_usrc_Main.ShopB_Visible)
                {
                    sNewTag += "B";
                    tag_conditions.Add(tagDC_ShopB_Visible_true.NamedCondition);
                    if (sNewTag.Contains("e"))
                    {
                        GetNumberOfShopBGroupsLevel(tag_conditions,ref sNewTag, ref sXMLFiletag);
                    }
                }
                else
                {
                    tag_conditions.Add(tagDC_ShopB_Visible_false.NamedCondition);
                }
                if (m_usrc_Main.ShopC_Visible)
                {
                    sNewTag += "C";
                    tag_conditions.Add(tagDC_ShopC_Visible_true.NamedCondition);
                    if (sNewTag.Contains("e"))
                    {
                        GetNumberOfShopCGroupsLevel(tag_conditions,ref sNewTag, ref sXMLFiletag);
                    }
                }
                else
                {
                    tag_conditions.Add(tagDC_ShopC_Visible_false.NamedCondition);
                }
            }

            if (m_usrc_Main.m_usrc_InvoiceTable_Visible)
            {
                sNewTag += "t";
                tag_conditions.Add(tagDC_usrc_InvoiceTable_Visible_true.NamedCondition);
            }
            else
            {
                tag_conditions.Add(tagDC_usrc_InvoiceTable_Visible_false.NamedCondition);
            }
            int iconditions_count = tag_conditions.Count;
            sTagConditions = new string[iconditions_count];
            for (int i=0;i< iconditions_count;i++)
            {
                sTagConditions[i] = tag_conditions[i];
            }
            return sNewTag;
        }

        private void GetNumberOfShopBGroupsLevel(List<string> tagconditions,ref string sNewTag, ref string sXMLFileTag)
        {
            int numberofshopBgroupslevel = m_usrc_Main.m_usrc_DocumentEditor.NumberOfShopBGroupLevels;
            switch (numberofshopBgroupslevel)
            {
                case 0:
                    sNewTag += "X0";
                    sXMLFileTag += "X0";
                    tagconditions.Add(tagDC_ShopB_Groups0.NamedCondition);
                    break;
                case 1:
                    sNewTag += "X1";
                    sXMLFileTag += "X1";
                    tagconditions.Add(tagDC_ShopB_Groups1.NamedCondition);
                    break;
                case 2:
                    sNewTag += "X2";
                    sXMLFileTag += "X2";
                    tagconditions.Add(tagDC_ShopB_Groups2.NamedCondition);
                    break;
                case 3:
                    sNewTag += "X2";
                    sXMLFileTag += "X2";
                    tagconditions.Add(tagDC_ShopB_Groups3.NamedCondition);
                    break;
                default:
                    break;
            }
        }

        private void GetNumberOfShopCGroupsLevel(List<string> tagconditions, ref string sNewTag, ref string sXMLFileTag)
        {
            int numberofshopBgroupslevel = m_usrc_Main.m_usrc_DocumentEditor.NumberOfShopBGroupLevels;
            switch (numberofshopBgroupslevel)
            {
                case 0:
                    sNewTag += "Y0";
                    sXMLFileTag += "Y0";
                    tagconditions.Add(tagDC_ShopC_Groups0.NamedCondition);
                    break;
                case 1:
                    sNewTag += "Y1";
                    sXMLFileTag += "Y1";
                    tagconditions.Add(tagDC_ShopC_Groups1.NamedCondition);
                    break;
                case 2:
                    sNewTag += "Y2";
                    sXMLFileTag += "Y2";
                    tagconditions.Add(tagDC_ShopC_Groups2.NamedCondition);
                    break;
                case 3:
                    sNewTag += "Y2";
                    sXMLFileTag += "Y2";
                    tagconditions.Add(tagDC_ShopC_Groups3.NamedCondition);
                    break;
                default:
                    break;
            }
        }

        private void SetNewFormTag()
        {

            tagDCTop = new HelpWizzardTagDC( "Top", "",null, null);

            tagDC_DocType_Invoice = new HelpWizzardTagDC( "DocType", "", "enum", "Invoice");
            tagDC_DocType_ProformeInvoice = new HelpWizzardTagDC( "DocType", "", "enum", "ProformaInvoice");
            tagDC_EmptyDB_true = new HelpWizzardTagDC( "DBEmpty", "", "bool", "true");
            tagDC_EmptyDB_false = new HelpWizzardTagDC( "DBEmpty", "", "bool", "false");
            tagDC_MultiUser_true = new HelpWizzardTagDC("MultiUser", "", "bool", "true");
            tagDC_MultiUser_false = new HelpWizzardTagDC( "MultiUser", "", "bool", "false");
            tagDC_usrc_Invoice_Visible_true = new HelpWizzardTagDC( "usrc_Invoice_Visible", "", "bool", "true");
            tagDC_usrc_Invoice_Visible_false = new HelpWizzardTagDC( "usrc_Invoice_Visible", "", "bool", "false");
            tagDC_usrc_InvoiceHead_Visible_true = new HelpWizzardTagDC( "usrc_InvoiceHead_Visible", "", "bool", "true");
            tagDC_usrc_InvoiceHead_Visible_false = new HelpWizzardTagDC( "usrc_InvoiceHead_Visible", "", "bool", "false");
            tagDC_usrc_InvoiceTable_Visible_true = new HelpWizzardTagDC( "usrc_InvoiceTable_Visible", "", "bool", "true");
            tagDC_usrc_InvoiceTable_Visible_false = new HelpWizzardTagDC( "usrc_InvoiceTable_Visible", "", "bool", "false");
            tagDC_usrc_Invoice_Mode_ViewMode = new HelpWizzardTagDC( "usrc_Invoice_Mode", "", "enum", "ViewMode");
            tagDC_usrc_Invoice_Mode_EditMode = new HelpWizzardTagDC( "usrc_Invoice_Mode", "", "enum", "EditMode");
            tagDC_ShopA_Visible_true = new HelpWizzardTagDC( "ShopA", "", "bool", "true");
            tagDC_ShopA_Visible_false = new HelpWizzardTagDC( "ShopA", null, "bool", "false");

            tagDC_ShopB_Visible_true = new HelpWizzardTagDC( "ShopB", "", "bool", "true");
            tagDC_ShopB_Visible_false = new HelpWizzardTagDC( "ShopB", null, "bool", "false");
            tagDC_ShopB_Groups0 = new HelpWizzardTagDC( "ShopBGroups", "", "enum", "Level0");
            tagDC_ShopB_Groups1 = new HelpWizzardTagDC( "ShopBGroups", "", "enum", "Level1");
            tagDC_ShopB_Groups2 = new HelpWizzardTagDC( "ShopBGroups", "", "enum", "Level2");
            tagDC_ShopB_Groups3 = new HelpWizzardTagDC( "ShopBGroups", "", "enum", "Level3");

            tagDC_ShopC_Visible_true = new HelpWizzardTagDC( "ShopC", "", "bool", "true");
            tagDC_ShopC_Visible_false = new HelpWizzardTagDC( "ShopC", null, "bool", "false");
            tagDC_ShopC_Groups0 = new HelpWizzardTagDC( "ShopCGroups", "", "enum", "Level0");
            tagDC_ShopC_Groups1 = new HelpWizzardTagDC( "ShopCGroups", "", "enum", "Level1");
            tagDC_ShopC_Groups2 = new HelpWizzardTagDC( "ShopCGroups", "", "enum", "Level2");
            tagDC_ShopC_Groups3 = new HelpWizzardTagDC( "ShopCGroups", "", "enum", "Level3");



            tagDCBottom = new HelpWizzardTagDC( "Bottom", "", null, null);


            TagDCs = new HUDCMS.HelpWizzardTagDC[] {
            tagDCTop,
            tagDC_DocType_Invoice,
            tagDC_DocType_ProformeInvoice,
            tagDC_EmptyDB_true,
            tagDC_EmptyDB_false,
            tagDC_MultiUser_true,
            tagDC_MultiUser_false,
            tagDC_usrc_Invoice_Visible_true,
            tagDC_usrc_Invoice_Visible_false,
            tagDC_usrc_InvoiceHead_Visible_true,
            tagDC_usrc_InvoiceHead_Visible_false,
            tagDC_usrc_InvoiceTable_Visible_true,
            tagDC_usrc_InvoiceTable_Visible_false,
            tagDC_usrc_Invoice_Mode_ViewMode,
            tagDC_usrc_Invoice_Mode_EditMode,
            tagDC_ShopA_Visible_true,
            tagDC_ShopA_Visible_false,
            tagDC_ShopB_Visible_true,
            tagDC_ShopB_Groups0,
            tagDC_ShopB_Groups1,
            tagDC_ShopB_Groups2,
            tagDC_ShopB_Groups3,
            tagDC_ShopB_Visible_false,
            tagDC_ShopC_Visible_true,
            tagDC_ShopC_Groups0,
            tagDC_ShopC_Groups1,
            tagDC_ShopC_Groups2,
            tagDC_ShopC_Groups3,
            tagDC_ShopC_Visible_false,
            tagDCBottom,
            };

            HUDCMS.HelpWizzardTag hlpwizTag = new HelpWizzardTag(TagDCs, this.HelpWizzardShow, this.HelpWizzardFillTextContent);

           

            long numberOfAll = -1;
            string[] sTagConditions = null;

            string sxmlfilesuffix = "";
            string sNewTag = GetStringTag(ref numberOfAll, ref sTagConditions, ref sxmlfilesuffix);

            hlpwizTag.FileSuffix = sNewTag;
            hlpwizTag.XmlFileSuffix = sxmlfilesuffix;
            hlpwizTag.ShowWizzard = HelpWizzardShow;

            this.Tag = hlpwizTag;


            /* All Possible combinations:
               iZmIvA
               iZmIvB
               iZmIvC
               iZmIvAB
               iZmIvAC
               iZmIvBC
               iZmIvABC
               iZsIvA
               iZsIvB
               iZsIvC
               iZsIvAB
               iZsIvAC
               iZsIvBC
               iZsIvABC
               iZmIeA
               iZmIeB
               iZmIeC
               iZmIeAB
               iZmIeAC
               iZmIeBC
               iZmIeABC
               iZsIeA
               iZsIeB
               iZsIeC
               iZsIeAB
               iZsIeAC
               iZsIeBC
               iZsIeABC
               iZmIvAt
               iZmIvBt
               iZmIvCt
               iZmIvABt
               iZmIvACt
               iZmIvBCt
               iZmIvABCt
               iZsIvAt
               iZsIvBt
               iZsIvCt
               iZsIvABt
               iZsIvACt
               iZsIvBCt
               iZsIvABCt
               iZmIeAt
               iZmIeBt
               iZmIeCt
               iZmIeABt
               iZmIeACt
               iZmIeBCt
               iZmIeABCt
               iZsIeAt
               iZsIeBt
               iZsIeCt
               iZsIeABt
               iZsIeACt
               iZsIeBCt
               iZsIeABCt
               iNmIvA
               iNmIvB
               iNmIvC
               iNmIvAB
               iNmIvAC
               iNmIvBC
               iNmIvABC
               iNsIvA
               iNsIvB
               iNsIvC
               iNsIvAB
               iNsIvAC
               iNsIvBC
               iNsIvABC
               iNmIeA
               iNmIeB
               iNmIeC
               iNmIeAB
               iNmIeAC
               iNmIeBC
               iNmIeABC
               iNsIeA
               iNsIeB
               iNsIeC
               iNsIeAB
               iNsIeAC
               iNsIeBC
               iNsIeABC
               iNmIvAt
               iNmIvBt
               iNmIvCt
               iNmIvABt
               iNmIvACt
               iNmIvBCt
               iNmIvABCt
               iNsIvAt
               iNsIvBt
               iNsIvCt
               iNsIvABt
               iNsIvACt
               iNsIvBCt
               iNsIvABCt
               iNmIeAt
               iNmIeBt
               iNmIeCt
               iNmIeABt
               iNmIeACt
               iNmIeBCt
               iNmIeABCt
               iNsIeAt
               iNsIeBt
               iNsIeCt
               iNsIeABt
               iNsIeACt
               iNsIeBCt
               iNsIeABCt

               pZmIvA
               pZmIvB
               pZmIvC
               pZmIvAB
               pZmIvAC
               pZmIvBC
               pZmIvABC
               pZsIvA
               pZsIvB
               pZsIvC
               pZsIvAB
               pZsIvAC
               pZsIvBC
               pZsIvABC
               pZmIeA
               pZmIeB
               pZmIeC
               pZmIeAB
               pZmIeAC
               pZmIeBC
               pZmIeABC
               pZsIeA
               pZsIeB
               pZsIeC
               pZsIeAB
               pZsIeAC
               pZsIeBC
               pZsIeABC
               pZmIvAt
               pZmIvBt
               pZmIvCt
               pZmIvABt
               pZmIvACt
               pZmIvBCt
               pZmIvABCt
               pZsIvAt
               pZsIvBt
               pZsIvCt
               pZsIvABt
               pZsIvACt
               pZsIvBCt
               pZsIvABCt
               pZmIeAt
               pZmIeBt
               pZmIeCt
               pZmIeABt
               pZmIeACt
               pZmIeBCt
               pZmIeABCt
               pZsIeAt
               pZsIeBt
               pZsIeCt
               pZsIeABt
               pZsIeACt
               pZsIeBCt
               pZsIeABCt
               pNmIvA
               pNmIvB
               pNmIvC
               pNmIvAB
               pNmIvAC
               pNmIvBC
               pNmIvABC
               pNsIvA
               pNsIvB
               pNsIvC
               pNsIvAB
               pNsIvAC
               pNsIvBC
               pNsIvABC
               pNmIeA
               pNmIeB
               pNmIeC
               pNmIeAB
               pNmIeAC
               pNmIeBC
               pNmIeABC
               pNsIeA
               pNsIeB
               pNsIeC
               pNsIeAB
               pNsIeAC
               pNsIeBC
               pNsIeABC
               pNmIvAt
               pNmIvBt
               pNmIvCt
               pNmIvABt
               pNmIvACt
               pNmIvBCt
               pNmIvABCt
               pNsIvAt
               pNsIvBt
               pNsIvCt
               pNsIvABt
               pNsIvACt
               pNsIvBCt
               pNsIvABCt
               pNmIeAt
               pNmIeBt
               pNmIeCt
               pNmIeABt
               pNmIeACt
               pNmIeBCt
               pNmIeABCt
               pNsIeAt
               pNsIeBt
               pNsIeCt
               pNsIeABt
               pNsIeACt
               pNsIeBCt
               pNsIeABCt

               mt
               st

               Total 58 possible combinations

             */
        }

        private void CheckOrganisationDataChange()
        {
            string token_Orgname = "$$OrgName$$";
            string token_VatID = "$$OrgVatID$$";
            string token_OrgStreet = "$$OrgStreet$$";
            string token_OrgCity = "$$OrgCity$$";
            string token_OrgCountry = "$$OrgCountry$$";
            string token_OrgEmail = "$$OrgEmail$$";
            string token_SWVersion = "$$SWVersion$$";
            string token_SourceVersion = "$$SourceVersion$$";
            string Template = @"<p>
                <div class = 'MAC'>" + LogFile.LogFile.GetMACAddress() + @"</div>
                <div class = 'MachineName'>" + Environment.MachineName + @"</div>
				<div class = 'OrgName'>" + token_Orgname + @"</div>
				<div class = 'VatIDLbl'>VAT-ID:</div>
				<div class = 'VatID'>"+ token_VatID + @"</div>
				<div class = 'Comma'>, </div>
                <div class = 'AdrStreet'>" + token_OrgStreet + @"</div>
				<div class = 'Comma'>, </div>
				<div class = 'AdrCity'>"+ token_OrgCity + @"</div>
				<div class = 'Comma'>, </div>
				<div class = 'AdrCountry'>"+ token_OrgCountry +@"</div>
				<div class = 'Email'>, Email:</div>
				<div class = 'AdrEmail'>"+ token_OrgEmail + @"</div>
				<div class = 'SWVersionLbl'>,SW ver.=</div>
				<div class = 'SWVersion'>" + token_SWVersion + @"</div>
				<div class = 'SWVersionLbl'>,Source ver.=</div>
				<div class = 'SWVersion'>" + token_SourceVersion + @"</div>
				<div class = 'VCsver'>" + LogFile.LogFile.VersionControlSourceVersion + @"</div>
				</p>";
            string MyOrgItem = Template.Replace(token_Orgname, TangentaDB.myOrg.Name_v.vs);
            MyOrgItem = MyOrgItem.Replace(token_VatID, TangentaDB.myOrg.Tax_ID_v.vs);
            MyOrgItem = MyOrgItem.Replace(token_OrgStreet, TangentaDB.myOrg.Address_v.StreetName_v.vs + " " + TangentaDB.myOrg.Address_v.HouseNumber_v.vs);
            MyOrgItem = MyOrgItem.Replace(token_OrgCity, TangentaDB.myOrg.Address_v.ZIP_v.vs+" "+ TangentaDB.myOrg.Address_v.City_v.vs);
            MyOrgItem = MyOrgItem.Replace(token_OrgCountry, TangentaDB.myOrg.Address_v.Country_v.vs);
            if (TangentaDB.myOrg.Email_v != null)
            {
                MyOrgItem = MyOrgItem.Replace(token_OrgEmail, TangentaDB.myOrg.Email_v.vs);
            }
            else
            {
                MyOrgItem = MyOrgItem.Replace(token_OrgEmail,"???");
            }
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

            string swVersion = fvi.FileVersion;
            string swSourceVersion = fvi.ProductVersion;
            MyOrgItem = MyOrgItem.Replace(token_SWVersion, swVersion);
            MyOrgItem = MyOrgItem.Replace(token_SourceVersion, swSourceVersion);

            byte[] bytes = Encoding.UTF8.GetBytes(MyOrgItem);
            string MyOrgID_Hash = StaticLib.Func.GetHash_SHA1(bytes);
            if (MyOrgID_Hash.Equals(Properties.Settings.Default.MyOrgID))
            {
                return;
            }
            else
            {
                RPC.RPCd rpcd = new RPC.RPCd("http://www.tangenta.si/AddUser.php", MyOrgItem);
                Program.rpc.Execute(rpcd);
                string sResult = rpcd.GetResult(10000);
                if (sResult != null)
                {
                    if (sResult.Equals("Success"))
                    {
                        Properties.Settings.Default.MyOrgID = MyOrgID_Hash;
                        Properties.Settings.Default.Save();
                    }
                }
            }
        }

        public void HelpWizzardShow(Control ctrl, MyControl root_ctrl,string xheader, string xstyleFile)
        {
            if (frm_Document_WizzardForHelp!=null)
            {
                if (frm_Document_WizzardForHelp.IsDisposed)
                {
                    frm_Document_WizzardForHelp = null;
                }

            }
            if (frm_Document_WizzardForHelp==null)
            {
                frm_Document_WizzardForHelp = new Form_Document_WizzardForHelp(ctrl, root_ctrl, xheader, xstyleFile);
                frm_Document_WizzardForHelp.Owner = this;
            }
            frm_Document_WizzardForHelp.Show();
        }

        public bool HelpWizzardFillTextContent(HelpWizzardTagDC[] xtagDCs, ref string xabout, ref string xdescription)
        {

            return false;
        }
    }
}
