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
using LoginControl;
using static TangentaDB.CashierActivity;
using DBTypes;
using System.Net.NetworkInformation;
using TangentaBooting;
using TangentaCore;
using TangentaProperties;

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

        private LoginControl.LoginCtrl.eExitReason eExitReason = LoginControl.LoginCtrl.eExitReason.NORMAL;

        private Form_FirstTimeInstallationGreeting frm_Form_FirstTimeInstallationGreeting = null;
        public const string XML_ROOT_NAME = "Tangenta_Xml";

        

        public Form ChildForm = null;

        public string DataBaseType = null;
        public bool bNewDatabaseCreated = false;
        public bool bInit_DBType_Canceled = false;





        private Form_Document_WizzardForHelp frm_Document_WizzardForHelp = null;

        private usrc_DocumentMan m_DocumentMan = null;

        public usrc_DocumentMan documentMan 
        {
            get
            {
                return m_DocumentMan;
            }
            set
            {
                m_DocumentMan = value;
            }
        }

        private usrc_DocumentMan1366x768 m_DocumentMan1366x768 = null;

        public usrc_DocumentMan1366x768 DocumentMan1366x768
        {
            get
            {
                return m_DocumentMan1366x768;
            }
            set
            {
                m_DocumentMan1366x768 = value;
            }
        }

        public bool HasDocumentMan1366x768
        {
            get
            {
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is usrc_DocumentMan1366x768)
                    {
                        return true;
                    }
                }
                return false;
            }
        }


        
        public CashierActivity CashierActivity
        {
            get
            {
                if (loginControl1 != null)
                {
                    return loginControl1.CashierActivity;
                }
                else
                {
                    return null;
                }
            }
        }
        public bool RecordCashierActivity
        {
            get
            {
                if (loginControl1!=null)
                {
                    return loginControl1.RecordCashierActivity;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                if (loginControl1 != null)
                {
                    loginControl1.RecordCashierActivity = value;
                }
            }
        }

        public Form_Document()
        {
            LogFile.LogFile.WriteRELEASE("Form_Document()before InitializeComponent()!");
            InitializeComponent();

            TSettings.LoginControl1 = this.loginControl1;

            TSettings.FVI_SLO1 = this.fvI_SLO1;
            TSettings.thread_fvi = this.fvI_SLO1.thread_fvi;
            TSettings.message_box = this.fvI_SLO1.message_box;

            this.loginControl1.RecordCashierActivity = TangentaProperties.Properties.Settings.Default.RecordCashierActivity;

            default_FormName = this.Name;
            this.Icon = TangentaResources.Properties.Resources.Tangenta_Icon;

            Booting.Define(this, M_usrc_Startup_WebBrowserControl_DocumentCompleted);


            if (TangentaProperties.Properties.Settings.Default.FullScreen || TangentaProperties.Properties.Settings.Default.ControlLayout_TouchScreen)
            {
                this.FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }


            DBConnectionControl40.TestConnectionForm.WaitToChangeDatabase = TangentaProperties.Properties.Settings.Default.WaitToChangeDataBaseAtStartup;


            this.loginControl1.IdleControlFileImageUrl1 = TangentaProperties.Properties.Settings.Default.IdleControl_FileImageUrl1;
            if (this.loginControl1.IdleControlFileImageUrl1 != null)
            {
                if (this.loginControl1.IdleControlFileImageUrl1.Length > 0)
                {
                    if (File.Exists(this.loginControl1.IdleControlFileImageUrl1))
                    {
                        try
                        {
                            this.loginControl1.IdleControlImageUrl1 = Image.FromFile(this.loginControl1.IdleControlFileImageUrl1);
                        }
                        catch (Exception Ex)
                        {
                            LogFile.Error.Show("ERROR:Tangenta:Forum_Document:constructor Form_Document():can not load URL1 image file:" + this.loginControl1.IdleControlFileImageUrl1);
                        }
                    }
                }
            }


            this.loginControl1.IdleControlFileImageUrl2 = TangentaProperties.Properties.Settings.Default.IdleControl_FileImageUrl2;
            if (this.loginControl1.IdleControlFileImageUrl2 != null)
            {
                if (this.loginControl1.IdleControlFileImageUrl2.Length > 0)
                {
                    if (File.Exists(this.loginControl1.IdleControlFileImageUrl2))
                    {
                        try
                        {
                            this.loginControl1.IdleControlImageUrl2 = Image.FromFile(this.loginControl1.IdleControlFileImageUrl2);
                        }
                        catch (Exception Ex)
                        {
                            LogFile.Error.Show("ERROR:Tangenta:Forum_Document:constructor Form_Document():can not load URL2 image file:" + this.loginControl1.IdleControlFileImageUrl2+ "\r\nException="+Ex.Message);
                        }
                    }
                }
            }

            this.loginControl1.IdleControlActive = TangentaProperties.Properties.Settings.Default.IdleControl_Active;
            this.loginControl1.IdleControlUseExitButton = TangentaProperties.Properties.Settings.Default.IdleControl_UseExitButton;
            this.loginControl1.IdleControlShowURL2 = TangentaProperties.Properties.Settings.Default.IdleControl_ShowURL2;
            this.loginControl1.IdleControlTimeInSecondsToActivate = TangentaProperties.Properties.Settings.Default.IdleControl_TimeInSecondsToActivate;
            this.loginControl1.IdleControlURL1 = TangentaProperties.Properties.Settings.Default.IdleControl_URL1;
            this.loginControl1.IdleControlURL2 = TangentaProperties.Properties.Settings.Default.IdleControl_URL2;


            // Properties.Settings.Default.SplitterPositions =
            this.Text = lng.s_Tangenta.s;
            if (Startup.CommandLineParam.bDemo)
            {
                this.Text += " DEMO";
            }
            if (Startup.CommandLineParam.bSymulator)
            {
                this.Text += " (WITH INPUT SYMULATION)";
            }
            if (Startup.CommandLineParam.m_bProgramDiagnostic)
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

            //m_usrc_Main.Visible = false;



            Booting.m_startup.m_usrc_Startup.ExitProgram += M_usrc_Startup_ExitProgram;
            Booting.m_startup.m_usrc_Startup.ExitPrev += M_usrc_Startup_ExitPrev;
            Booting.m_startup.m_usrc_Startup.Finished += M_usrc_Startup_Finished;

            Booting.nav.oStartup = Booting.m_startup;
        }



        internal void WizzardShow_ShopsVisible(string xshops_inuse)
        {
            if (HasDocumentMan1366x768)
            {
                DocumentMan1366x768.WizzardShow_ShopsVisible(xshops_inuse);
            }
            else
            {
                documentMan.WizzardShow_ShopsVisible(xshops_inuse);
            }
        }

        internal void WizzardShow_usrc_Invoice_Head_Visible(bool bvisible)
        {
            if (HasDocumentMan1366x768)
            {
                DocumentMan1366x768.WizzardShow_usrc_Invoice_Head_Visible(bvisible);
            }
            else
            {
                documentMan.WizzardShow_usrc_Invoice_Head_Visible(bvisible);
            }
        }

        internal void WizzardShow_InvoiceTable_Visible(bool bvisible)
        {
            if (HasDocumentMan1366x768)
            {
                DocumentMan1366x768.WizzardShow_InvoiceTable_Visible(bvisible);
            }
            else
            {
                documentMan.WizzardShow_InvoiceTable_Visible(bvisible);
            }

        }

        internal void WizzardShow_DocInvoice(string xDocInvoice)
        {
            if (HasDocumentMan1366x768)
            {
                DocumentMan1366x768.WizzardShow_DocInvoice(xDocInvoice);
            }
            else
            {
                documentMan.WizzardShow_DocInvoice(xDocInvoice);
            }

        }

        private void M_usrc_Startup_WebBrowserControl_DocumentCompleted(string url)
        {
            if (url.Contains("News.html"))
            {
               Booting.m_startup.StartExecution();//when Startup has finished event M_usrc_Startup_Finished is triggered
            }
            else
            {
                // no document not completed there is error to locql or remote connection
                if (!NetworkInterface.GetIsNetworkAvailable())
                {
                    if (!Booting.m_startup.Started)
                    {
                        Booting.m_startup.StartExecution();
                    }
                }
            }
        }

        private void M_usrc_Startup_ExitPrev()
        {
            Booting.nav.eExitResult = NavigationButtons.Navigation.eEvent.PREV;
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

            TSettings.m_XmlFileName = XML_ROOT_NAME;
            //m_usrc_Main.Initialise(this);
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

            string sdb = DBSync.DBSync.DataBase;
            if (sdb != null)
            {
                TangentaProperties.Properties.Settings.Default.Current_DataBase = DBSync.DBSync.DataBase;
            }

            if (loginControl1.IdleControlFileImageUrl1 != null)
            {
                if (!loginControl1.IdleControlFileImageUrl1.Equals(TangentaProperties.Properties.Settings.Default.IdleControl_FileImageUrl1))
                {
                    TangentaProperties.Properties.Settings.Default.IdleControl_FileImageUrl1 = loginControl1.IdleControlFileImageUrl1;
                    TangentaProperties.Properties.Settings.Default.Save();
                }
            }

            if (loginControl1.IdleControlFileImageUrl2 != null)
            {
                if (!loginControl1.IdleControlFileImageUrl2.Equals(TangentaProperties.Properties.Settings.Default.IdleControl_FileImageUrl2))
                {
                    TangentaProperties.Properties.Settings.Default.IdleControl_FileImageUrl2 = loginControl1.IdleControlFileImageUrl2;
                    TangentaProperties.Properties.Settings.Default.Save();
                }
            }

            if (HasDocumentMan1366x768)
            {
                if (DocumentMan1366x768 != null)
                {
                    if (ID.Validate(DocumentMan1366x768.m_usrc_TableOfDocuments.Current_Doc_ID))
                    {
                        // Properties.Settings.Default.Current_DocInvoice_ID = DocumentMan.m_usrc_TableOfDocuments.Current_Doc_ID.V.ToString();
                    }
                    if (DocumentMan1366x768.m_usrc_DocumentEditor1366x768.m_usrc_ShopA1366x768 != null)
                    {
                        if (DocumentMan1366x768.m_usrc_DocumentEditor1366x768.m_usrc_ShopA1366x768.usrc_Editor1366x768_1.m_tool_SelectItem != null)
                        {
                            DocumentMan1366x768.m_usrc_DocumentEditor1366x768.m_usrc_ShopA1366x768.usrc_Editor1366x768_1.m_tool_SelectItem.Close();
                            DocumentMan1366x768.m_usrc_DocumentEditor1366x768.m_usrc_ShopA1366x768.usrc_Editor1366x768_1.m_tool_SelectItem = null;
                        }
                    }
                }
            }
            else
            {
                if (documentMan != null)
                {
                    if (ID.Validate(documentMan.m_usrc_TableOfDocuments.Current_Doc_ID))
                    {
                        // Properties.Settings.Default.Current_DocInvoice_ID = DocumentMan.m_usrc_TableOfDocuments.Current_Doc_ID.V.ToString();
                    }
                    if (documentMan.m_usrc_DocumentEditor.m_usrc_ShopA != null)
                    {
                        if (documentMan.m_usrc_DocumentEditor.m_usrc_ShopA.usrc_Editor1.m_tool_SelectItem != null)
                        {
                            documentMan.m_usrc_DocumentEditor.m_usrc_ShopA.usrc_Editor1.m_tool_SelectItem.Close();
                            documentMan.m_usrc_DocumentEditor.m_usrc_ShopA.usrc_Editor1.m_tool_SelectItem = null;
                        }
                    }
                }
            }

            if (TSettings.Login_MultipleUsers)
            {

            }
            else
            {
                if (loginControl1.awp != null)
                {
                    if (loginControl1.awp.LMO1User != null)
                    {
                        ID atom_work_period_id = loginControl1.awp.LMO1User.Atom_WorkPeriod_ID;
                        if (ID.Validate(atom_work_period_id))
                        {
                            Transaction transaction_loginControl1_awp_LMO1User = DBSync.DBSync.NewTransaction("loginControl1_awp_LMO1User");
                            if (TangentaDB.f_Atom_WorkPeriod.End(loginControl1.awp.LMO1User.Atom_WorkPeriod_ID, transaction_loginControl1_awp_LMO1User))
                            {
                                transaction_loginControl1_awp_LMO1User.Commit();
                            }
                            else
                            {
                                transaction_loginControl1_awp_LMO1User.Rollback();
                            }
                        }
                    }
                }
            }
            if (TSettings.b_FVI_SLO)
            {
                if (TSettings.FVI_SLO1 != null)
                {
                    TSettings.FVI_SLO1.End();
                }
            }


            //SaveSplitContainerPositions(ref Program.ListOfAllSplitConatinerControls);
        }

        private void LayoutSet(SettingsUserValues xSettingsUserValues)
        {
            documentMan.usrc_FVI_SLO1.Visible = TSettings.b_FVI_SLO;

            if (xSettingsUserValues.Form_WindowState >= 0)
            {
                switch (xSettingsUserValues.Form_WindowState)
                {
                    case 0:
                        this.WindowState = FormWindowState.Minimized;
                        break;
                    case 1:
                        this.WindowState = FormWindowState.Normal;

                        if (xSettingsUserValues.Form_Width >= 0)
                        {
                            this.Width = xSettingsUserValues.Form_Width;
                        }

                        if (xSettingsUserValues.Form_Height >= 0)
                        {
                            this.Height = xSettingsUserValues.Form_Height;
                            this.Left = xSettingsUserValues.Form_Left;
                            this.Top = xSettingsUserValues.Form_Top;

                        }
                        break;

                    case 2:
                        this.WindowState = FormWindowState.Maximized;
                        break;
                }
            }
            documentMan.SetSplitControlsSpliterDistance();
        }

       

        private void m_usrc_Main_Exit_Click(string sDocInvoice, ID doc_ID, LoginControl.LMOUser xLMOUser, LoginControl.LoginCtrl.eExitReason eReason)
        {
            if (xLMOUser!=null)
            {
                if (ID.Validate(xLMOUser.myOrganisation_Person_ID))
                {
                    string sDataSource = DBSync.DBSync.DataSource;
                    ID xCurrent_Doc_ID = null;
                    if (ID.Validate(doc_ID))
                    {
                        Transaction transaction_Form_Document_m_usrc_Main_Exit_Click_SetLast = DBSync.DBSync.NewTransaction("Form_Document.m_usrc_Main_Exit_Click.SetLast");

                        if (f_Current_Doc_ID.SetLast(sDocInvoice, doc_ID, sDataSource, xLMOUser.myOrganisation_Person_ID, myOrg.m_myOrg_Office.ElectronicDevice_ID, ref xCurrent_Doc_ID, transaction_Form_Document_m_usrc_Main_Exit_Click_SetLast))
                        {
                            transaction_Form_Document_m_usrc_Main_Exit_Click_SetLast.Commit();
                        }
                        else
                        {
                            transaction_Form_Document_m_usrc_Main_Exit_Click_SetLast.Rollback();
                        }
                    }
                }
            }
            do_exit(eReason);
        }

        private void do_exit(LoginControl.LoginCtrl.eExitReason eReason)
        {
            eExitReason = eReason;
            this.Close();
        }


        internal void EndProgram(LoginControl.LoginCtrl.eExitReason eres)
        {
            TangentaProperties.Properties.Settings.Default.ShowAdministratorsInMultiuserLogin = loginControl1.ShowAdministrators;
            TangentaProperties.Properties.Settings.Default.Save();
            do_exit(eres);
        }

        private bool call_Edit_myOrganisationPerson(Form parentform, ID myOrganisation_Person_ID, ref bool Changed, ref ID myOrganisation_Person_ID_new)
        {
            Navigation xnav = new Navigation(null);
            xnav.m_eButtons = Navigation.eButtons.OkCancel;
            if (myOrg.m_myOrg_Office != null)
            {
                if (ID.Validate(myOrg.m_myOrg_Office.ID))
                {
                    Form_myOrg_Person_Edit frm_myOrgPerEdit = new Form_myOrg_Person_Edit(myOrg.m_myOrg_Office.ID, myOrganisation_Person_ID, xnav);
                    frm_myOrgPerEdit.TopMost = parentform.TopMost;
                    frm_myOrgPerEdit.Show(parentform);
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:Tangenta:Form_Document:call_Edit_myOrganisationPerson:myOrg.m_myOrg_Office.m_myOrg_Person.ID is not valid!");
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:Tangenta:Form_Document:call_Edit_myOrganisationPerson:(myOrg.m_myOrg_Office == null!");
                return false;
            }
        }


        private bool AskToExit()
        {
            if (((Booting.nav.eExitResult == NavigationButtons.Navigation.eEvent.PREV) && (Startup.Startup.bFirstTimeInstallation)) ||
                ((Booting.nav.eExitResult == NavigationButtons.Navigation.eEvent.EXIT)&&(Booting.nav.m_eButtons== Navigation.eButtons.PrevNextExit)))
            {
                return true;
            }
            else
            {
                if (XMessage.Box.Show(TSettings.bStartup,this, lng.s_RealyWantToExitProgram, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
            if (Booting.m_startup.Exit )
            {
                Exit();
                e.Cancel = false;
                return;
            }
            else
            {
                if (TSettings.Login_MultipleUsers)
                {
                    if (this.eExitReason != LoginControl.LoginCtrl.eExitReason.LOGIN_CONTROL)
                    {
                        if (HasDocumentMan1366x768)
                        {
                            if (this.DocumentMan1366x768 != null)
                            {
                                TSettings.LayoutSave(this,((SettingsUser)this.DocumentMan1366x768.DocM.m_LMOUser.oSettings).mSettingsUserValues);
                                this.DocumentMan1366x768.Active = false;
                            }
                        }
                        else
                        {
                            if (this.documentMan != null)
                            {
                                TSettings.LayoutSave(this,((SettingsUser)this.documentMan.DocM.m_LMOUser.oSettings).mSettingsUserValues);
                                this.documentMan.Active = false;
                            }
                        }
                        this.loginControl1.Login_MultipleUsers_ShowControl();
                        e.Cancel = true;
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
                else
                {
                    if (AskToExit())
                    {
                        TSettings.SaveSettings(this, TSettings.LMO1User);
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

        private void Form_Document_Shown(object sender, EventArgs e)
        {
            LogFile.LogFile.WriteDEBUG("** Form_Document:Form_Document_Shown():before m_startup.Execute!");

        }

        /// <summary>
        /// 
        /// </summary>
        private void M_usrc_Startup_Finished()
        {
            //Startup finished

            LogFile.LogFile.WriteDEBUG("** Form_Document:Form_Document_Shown():after m_startup.Execute!");

            //if (DocumentMan.bFirstTimeInstallation)
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
            Startup.Startup.bFirstTimeInstallation = false;

            //m_usrc_Main.Init(null);

            LogFile.LogFile.WriteDEBUG("** Form_Document:Form_Document_Shown():after m_usrc_Main.Init(null)!");

            CheckOrganisationDataChange();

            Booting.m_startup.RemoveControl();

            if (TSettings.Login_MultipleUsers)
            {
                //stay in Login_MulitpleUsersMode !
            }
            else
            {
                Activate_usrc_DocumentMan_for_LMO1User(null);
            }
        }

        internal void Activate_usrc_DocumentMan_for_LMO1User(LoginControl.usrc_MultipleUsers xm_usrc_MultipleUsers)
        {
            SettingsUser user_settings = new SettingsUser();
            Transaction transaction_Form_Document_Activate_usrc_DocumentMan_for_LMO1User_user_settings_Load = DBSync.DBSync.NewTransaction("Form_Document.Activate_usrc_DocumentMan_for_LMO1User.user_settings.Load");
            if (user_settings.Load(TSettings.LMO1User,
                                   transaction_Form_Document_Activate_usrc_DocumentMan_for_LMO1User_user_settings_Load))
            {
                if (transaction_Form_Document_Activate_usrc_DocumentMan_for_LMO1User_user_settings_Load.Commit())
                {
                    TSettings.LMO1User.oSettings = user_settings;

                    //xLMOUser.Form_settingsuser = new Form_SettingsUsers(xLMOUser);
                    //((Form_SettingsUsers)xLMOUser.Form_settingsuser).InitAfterLoad();
                    //xLMOUser.Form_settingsuser.Owner = this;
                    //xLMOUser.Form_settingsuser.Show();

                    if (TangentaProperties.Properties.Settings.Default.ControlLayout_TouchScreen)
                    {
                        usrc_DocumentMan1366x768 xusrc_DocumentMan1366x768 = new usrc_DocumentMan1366x768();
                        xusrc_DocumentMan1366x768.LayoutChanged += M_usrc_Main_LayoutChanged;
                        xusrc_DocumentMan1366x768.DocM.DocTyp = PropertiesUser.LastDocType_Get(user_settings.mSettingsUserValues);
                        xusrc_DocumentMan1366x768.Active = true;
                        xusrc_DocumentMan1366x768.Dock = DockStyle.Fill;
                        this.Controls.Add(xusrc_DocumentMan1366x768);

                        xusrc_DocumentMan1366x768.Initialise(this, TSettings.LMO1User);
                        xusrc_DocumentMan1366x768.Init();


                        TSettings.LMO1User.m_usrc_DocumentMan = xusrc_DocumentMan1366x768;
                        xusrc_DocumentMan1366x768.Exit_Click += m_usrc_Main_Exit_Click;
                        xusrc_DocumentMan1366x768.Activate_dgvx_XInvoice_SelectionChanged();

                    }
                    else
                    {
                        usrc_DocumentMan xusrc_DocumentMan = new usrc_DocumentMan();
                        xusrc_DocumentMan.Active = true;
                        xusrc_DocumentMan.Dock = DockStyle.Fill;
                        xusrc_DocumentMan.LayoutChanged += M_usrc_Main_LayoutChanged;
                        this.Controls.Add(xusrc_DocumentMan);

                        xusrc_DocumentMan.Initialise(this, TSettings.LMO1User);
                        xusrc_DocumentMan.Init();
                        this.documentMan = xusrc_DocumentMan;
                        TSettings.LMO1User.m_usrc_DocumentMan = xusrc_DocumentMan;
                        xusrc_DocumentMan.Exit_Click += m_usrc_Main_Exit_Click;
                        xusrc_DocumentMan.Activate_dgvx_XInvoice_SelectionChanged();
                    }
                }
            }
            else
            {
                transaction_Form_Document_Activate_usrc_DocumentMan_for_LMO1User_user_settings_Load.Rollback();
            }
        }


        private void M_usrc_Main_LayoutChanged()
        {
            //SetNewFormTag();
            //if (HasDocumentMan1366x768)
            //{
            //    DocumentMan1366x768.HelpReload();
            //}
            //else
            //{
            //    DocumentMan.HelpReload();
            //}
        }



        //    if (numberOfAll < 0)
        //    {
        //        LogFile.Error.Show("ERROR:Tangenta:Form_Document:SetNewFormTag:  numberOfAll invoices or proforma invoices < 0 !");
        //    }
        //    else if (numberOfAll == 0)
        //    {
        //        sNewTag += "Z";
        //        sXMLFiletag += "Z";
        //        tag_conditions.Add(tagDC_EmptyDB_true.NamedCondition);
        //    }
        //    else if (numberOfAll > 0)
        //    {
        //        sNewTag += "N";
        //        sXMLFiletag += "N";
        //        tag_conditions.Add(tagDC_EmptyDB_false.NamedCondition);
        //    }


        //    if (OperationMode.MultiUser)
        //    {
        //        sNewTag += "m";
        //        sXMLFiletag += "m";
        //        tag_conditions.Add(tagDC_MultiUser_true.NamedCondition);
        //    }
        //    else
        //    {
        //        sNewTag += "s";
        //        sXMLFiletag += "s";
        //        tag_conditions.Add(tagDC_MultiUser_false.NamedCondition);
        //    }

        //    if (HasDocumentMan1366x768)
        //    {
        //        if (DocumentMan1366x768.m_usrc_Invoice_Visible)
        //        {
        //            sNewTag += "I";
        //            tag_conditions.Add(tagDC_usrc_Invoice_Visible_true.NamedCondition);

        //            //if (DocumentMan1366x768.m_usrc_InvoiceHead_Visible)
        //            //{
        //            //    sNewTag += "h1";
        //            //    tag_conditions.Add(tagDC_usrc_InvoiceHead_Visible_true.NamedCondition);
        //            //}
        //            //else
        //            //{
        //            //    sNewTag += "h0";
        //            //    tag_conditions.Add(tagDC_usrc_InvoiceHead_Visible_false.NamedCondition);
        //            //}

        //            if (DocumentMan1366x768.m_usrc_Invoice_ViewMode)
        //            {
        //                if (sNewTag.Contains("N"))
        //                {
        //                    sNewTag += "v";
        //                    tag_conditions.Add(tagDC_usrc_Invoice_Mode_ViewMode.NamedCondition);
        //                }
        //            }
        //            else
        //            {
        //                if (sNewTag.Contains("N"))
        //                {
        //                    sNewTag += "e";
        //                    sXMLFiletag += "e";
        //                    tag_conditions.Add(tagDC_usrc_Invoice_Mode_EditMode.NamedCondition);
        //                }
        //            }
        //            if (DocumentMan1366x768.ShopA_Visible)
        //            {
        //                sNewTag += "A";
        //                tag_conditions.Add(tagDC_ShopA_Visible_true.NamedCondition);
        //            }
        //            else
        //            {
        //                tag_conditions.Add(tagDC_ShopA_Visible_false.NamedCondition);
        //            }

        //            if (DocumentMan1366x768.ShopB_Visible)
        //            {
        //                sNewTag += "B";
        //                tag_conditions.Add(tagDC_ShopB_Visible_true.NamedCondition);
        //                if (sNewTag.Contains("e"))
        //                {
        //                    GetNumberOfShopBGroupsLevel(tag_conditions, ref sNewTag, ref sXMLFiletag);
        //                }
        //            }
        //            else
        //            {
        //                tag_conditions.Add(tagDC_ShopB_Visible_false.NamedCondition);
        //            }
        //            if (DocumentMan1366x768.ShopC_Visible)
        //            {
        //                sNewTag += "C";
        //                tag_conditions.Add(tagDC_ShopC_Visible_true.NamedCondition);
        //                if (sNewTag.Contains("e"))
        //                {
        //                    GetNumberOfShopCGroupsLevel(tag_conditions, ref sNewTag, ref sXMLFiletag);
        //                }
        //            }
        //            else
        //            {
        //                tag_conditions.Add(tagDC_ShopC_Visible_false.NamedCondition);
        //            }
        //        }
        //        if (DocumentMan1366x768.m_usrc_InvoiceTable_Visible)
        //        {
        //            sNewTag += "t";
        //            tag_conditions.Add(tagDC_usrc_InvoiceTable_Visible_true.NamedCondition);
        //        }
        //        else
        //        {
        //            tag_conditions.Add(tagDC_usrc_InvoiceTable_Visible_false.NamedCondition);
        //        }

        //    }
        //    else
        //    {
        //        if (DocumentMan.m_usrc_Invoice_Visible)
        //        {
        //            sNewTag += "I";
        //            tag_conditions.Add(tagDC_usrc_Invoice_Visible_true.NamedCondition);

        //            if (DocumentMan.m_usrc_InvoiceHead_Visible)
        //            {
        //                sNewTag += "h1";
        //                tag_conditions.Add(tagDC_usrc_InvoiceHead_Visible_true.NamedCondition);
        //            }
        //            else
        //            {
        //                sNewTag += "h0";
        //                tag_conditions.Add(tagDC_usrc_InvoiceHead_Visible_false.NamedCondition);
        //            }

        //            if (DocumentMan.m_usrc_Invoice_ViewMode)
        //            {
        //                if (sNewTag.Contains("N"))
        //                {
        //                    sNewTag += "v";
        //                    tag_conditions.Add(tagDC_usrc_Invoice_Mode_ViewMode.NamedCondition);
        //                }
        //            }
        //            else
        //            {
        //                if (sNewTag.Contains("N"))
        //                {
        //                    sNewTag += "e";
        //                    sXMLFiletag += "e";
        //                    tag_conditions.Add(tagDC_usrc_Invoice_Mode_EditMode.NamedCondition);
        //                }
        //            }
        //            if (DocumentMan.ShopA_Visible)
        //            {
        //                sNewTag += "A";
        //                tag_conditions.Add(tagDC_ShopA_Visible_true.NamedCondition);
        //            }
        //            else
        //            {
        //                tag_conditions.Add(tagDC_ShopA_Visible_false.NamedCondition);
        //            }

        //            if (DocumentMan.ShopB_Visible)
        //            {
        //                sNewTag += "B";
        //                tag_conditions.Add(tagDC_ShopB_Visible_true.NamedCondition);
        //                if (sNewTag.Contains("e"))
        //                {
        //                    GetNumberOfShopBGroupsLevel(tag_conditions, ref sNewTag, ref sXMLFiletag);
        //                }
        //            }
        //            else
        //            {
        //                tag_conditions.Add(tagDC_ShopB_Visible_false.NamedCondition);
        //            }
        //            if (DocumentMan.ShopC_Visible)
        //            {
        //                sNewTag += "C";
        //                tag_conditions.Add(tagDC_ShopC_Visible_true.NamedCondition);
        //                if (sNewTag.Contains("e"))
        //                {
        //                    GetNumberOfShopCGroupsLevel(tag_conditions, ref sNewTag, ref sXMLFiletag);
        //                }
        //            }
        //            else
        //            {
        //                tag_conditions.Add(tagDC_ShopC_Visible_false.NamedCondition);
        //            }
        //        }
        //        if (DocumentMan.m_usrc_InvoiceTable_Visible)
        //        {
        //            sNewTag += "t";
        //            tag_conditions.Add(tagDC_usrc_InvoiceTable_Visible_true.NamedCondition);
        //        }
        //        else
        //        {
        //            tag_conditions.Add(tagDC_usrc_InvoiceTable_Visible_false.NamedCondition);
        //        }
        //    }


        //    int iconditions_count = tag_conditions.Count;
        //    sTagConditions = new string[iconditions_count];
        //    for (int i=0;i< iconditions_count;i++)
        //    {
        //        sTagConditions[i] = tag_conditions[i];
        //    }
        //    return sNewTag;
        //}

        private void GetNumberOfShopBGroupsLevel(List<string> tagconditions,ref string sNewTag, ref string sXMLFileTag)
        {
            int numberofshopBgroupslevel = documentMan.m_usrc_DocumentEditor.NumberOfShopBGroupLevels;
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
            int numberofshopBgroupslevel = 0;
            if (HasDocumentMan1366x768)
            {
                numberofshopBgroupslevel = DocumentMan1366x768.m_usrc_DocumentEditor1366x768.NumberOfShopBGroupLevels;
            }
            else
            {
                numberofshopBgroupslevel = documentMan.m_usrc_DocumentEditor.NumberOfShopBGroupLevels;
            }

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
            if (MyOrgID_Hash.Equals(TangentaProperties.Properties.Settings.Default.MyOrgID))
            {
                return;
            }
            else
            {
                RPC.RPCd rpcd = new RPC.RPCd("http://www.tangenta.si/AddUser.php", MyOrgItem);
                TSettings.RPC.Execute(rpcd);
                string sResult = rpcd.GetResult(10000);
                if (sResult != null)
                {
                    if (sResult.Equals("Success"))
                    {
                        TangentaProperties.Properties.Settings.Default.MyOrgID = MyOrgID_Hash;
                        TangentaProperties.Properties.Settings.Default.Save();
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

        internal string GetStringTag(ref long numberOfAll, ref string[] sTagConditions, ref string sXMLFiletag)
        {
            string sNewTag = "_";
            sXMLFiletag = "_";
            List<string> tag_conditions = new List<string>();

            if (HasDocumentMan1366x768)
            {
                if (this.DocumentMan1366x768.DocM.IsDocInvoice)
                {
                    numberOfAll = fs.NumberOInvoicesInDatabase();
                    sNewTag += "i";
                    tag_conditions.Add(tagDC_DocType_Invoice.NamedCondition);
                }
                else if (this.DocumentMan1366x768.DocM.IsDocProformaInvoice)
                {
                    numberOfAll = fs.NumberOfProformaInvoicesInDatabase();
                    sNewTag += "p";
                    tag_conditions.Add(tagDC_DocType_ProformeInvoice.NamedCondition);
                }
            }
            else
            {
                if (this.documentMan.IsDocInvoice)
                {
                    numberOfAll = fs.NumberOInvoicesInDatabase();
                    sNewTag += "i";
                    tag_conditions.Add(tagDC_DocType_Invoice.NamedCondition);
                }
                else if (this.documentMan.IsDocProformaInvoice)
                {
                    numberOfAll = fs.NumberOfProformaInvoicesInDatabase();
                    sNewTag += "p";
                    tag_conditions.Add(tagDC_DocType_ProformeInvoice.NamedCondition);
                }
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


            if (OperationMode.MultiUser)
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

            if (HasDocumentMan1366x768)
            {
                if (DocumentMan1366x768.m_usrc_Invoice_Visible)
                {
                    sNewTag += "I";
                    tag_conditions.Add(tagDC_usrc_Invoice_Visible_true.NamedCondition);

                    //if (DocumentMan1366x768.m_usrc_InvoiceHead_Visible)
                    //{
                    //    sNewTag += "h1";
                    //    tag_conditions.Add(tagDC_usrc_InvoiceHead_Visible_true.NamedCondition);
                    //}
                    //else
                    //{
                    //    sNewTag += "h0";
                    //    tag_conditions.Add(tagDC_usrc_InvoiceHead_Visible_false.NamedCondition);
                    //}

                    if (DocumentMan1366x768.m_usrc_Invoice_ViewMode)
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
                    if (DocumentMan1366x768.ShopA_Visible)
                    {
                        sNewTag += "A";
                        tag_conditions.Add(tagDC_ShopA_Visible_true.NamedCondition);
                    }
                    else
                    {
                        tag_conditions.Add(tagDC_ShopA_Visible_false.NamedCondition);
                    }

                    if (DocumentMan1366x768.ShopB_Visible)
                    {
                        sNewTag += "B";
                        tag_conditions.Add(tagDC_ShopB_Visible_true.NamedCondition);
                        if (sNewTag.Contains("e"))
                        {
                            GetNumberOfShopBGroupsLevel(tag_conditions, ref sNewTag, ref sXMLFiletag);
                        }
                    }
                    else
                    {
                        tag_conditions.Add(tagDC_ShopB_Visible_false.NamedCondition);
                    }
                    if (DocumentMan1366x768.ShopC_Visible)
                    {
                        sNewTag += "C";
                        tag_conditions.Add(tagDC_ShopC_Visible_true.NamedCondition);
                        if (sNewTag.Contains("e"))
                        {
                            GetNumberOfShopCGroupsLevel(tag_conditions, ref sNewTag, ref sXMLFiletag);
                        }
                    }
                    else
                    {
                        tag_conditions.Add(tagDC_ShopC_Visible_false.NamedCondition);
                    }
                }
                if (DocumentMan1366x768.m_usrc_InvoiceTable_Visible)
                {
                    sNewTag += "t";
                    tag_conditions.Add(tagDC_usrc_InvoiceTable_Visible_true.NamedCondition);
                }
                else
                {
                    tag_conditions.Add(tagDC_usrc_InvoiceTable_Visible_false.NamedCondition);
                }

            }
            else
            {
                if (documentMan.m_usrc_Invoice_Visible)
                {
                    sNewTag += "I";
                    tag_conditions.Add(tagDC_usrc_Invoice_Visible_true.NamedCondition);

                    if (documentMan.m_usrc_InvoiceHead_Visible)
                    {
                        sNewTag += "h1";
                        tag_conditions.Add(tagDC_usrc_InvoiceHead_Visible_true.NamedCondition);
                    }
                    else
                    {
                        sNewTag += "h0";
                        tag_conditions.Add(tagDC_usrc_InvoiceHead_Visible_false.NamedCondition);
                    }

                    if (documentMan.m_usrc_Invoice_ViewMode)
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
                    if (documentMan.ShopA_Visible)
                    {
                        sNewTag += "A";
                        tag_conditions.Add(tagDC_ShopA_Visible_true.NamedCondition);
                    }
                    else
                    {
                        tag_conditions.Add(tagDC_ShopA_Visible_false.NamedCondition);
                    }

                    if (documentMan.ShopB_Visible)
                    {
                        sNewTag += "B";
                        tag_conditions.Add(tagDC_ShopB_Visible_true.NamedCondition);
                        if (sNewTag.Contains("e"))
                        {
                            GetNumberOfShopBGroupsLevel(tag_conditions, ref sNewTag, ref sXMLFiletag);
                        }
                    }
                    else
                    {
                        tag_conditions.Add(tagDC_ShopB_Visible_false.NamedCondition);
                    }
                    if (documentMan.ShopC_Visible)
                    {
                        sNewTag += "C";
                        tag_conditions.Add(tagDC_ShopC_Visible_true.NamedCondition);
                        if (sNewTag.Contains("e"))
                        {
                            GetNumberOfShopCGroupsLevel(tag_conditions, ref sNewTag, ref sXMLFiletag);
                        }
                    }
                    else
                    {
                        tag_conditions.Add(tagDC_ShopC_Visible_false.NamedCondition);
                    }
                }
                if (documentMan.m_usrc_InvoiceTable_Visible)
                {
                    sNewTag += "t";
                    tag_conditions.Add(tagDC_usrc_InvoiceTable_Visible_true.NamedCondition);
                }
                else
                {
                    tag_conditions.Add(tagDC_usrc_InvoiceTable_Visible_false.NamedCondition);
                }
            }


            int iconditions_count = tag_conditions.Count;
            sTagConditions = new string[iconditions_count];
            for (int i = 0; i < iconditions_count; i++)
            {
                sTagConditions[i] = tag_conditions[i];
            }
            return sNewTag;
        }

        private void loginControl1_UserLoggedIn(LoginControl.LMOUser xLMOUser)
        {
            SettingsUser user_settings = new SettingsUser();
            Transaction transaction_Form_Document_loginControl1_UserLoggedIn_user_settings_Load = DBSync.DBSync.NewTransaction("Form_Document.loginControl1_UserLoggedIn.user_settings.Load");
            if (user_settings.Load(xLMOUser,
                                    transaction_Form_Document_loginControl1_UserLoggedIn_user_settings_Load))
            {
                if (transaction_Form_Document_loginControl1_UserLoggedIn_user_settings_Load.Commit())
                {
                    xLMOUser.oSettings = user_settings;

                    //xLMOUser.Form_settingsuser = new Form_SettingsUsers(xLMOUser);
                    //((Form_SettingsUsers)xLMOUser.Form_settingsuser).InitAfterLoad();
                    //xLMOUser.Form_settingsuser.Owner = this;
                    //xLMOUser.Form_settingsuser.Show();

                    if (TangentaProperties.Properties.Settings.Default.ControlLayout_TouchScreen)
                    {
                        usrc_DocumentMan1366x768 xusrc_DocumentMan1366x768 = new usrc_DocumentMan1366x768();
                        xusrc_DocumentMan1366x768.Visible = false;
                        xusrc_DocumentMan1366x768.Dock = DockStyle.Fill;
                        this.Controls.Add(xusrc_DocumentMan1366x768);

                        xusrc_DocumentMan1366x768.Initialise(this, xLMOUser);
                        xusrc_DocumentMan1366x768.Init();


                        xLMOUser.m_usrc_DocumentMan = xusrc_DocumentMan1366x768;
                        xusrc_DocumentMan1366x768.Exit_Click += m_usrc_Main_Exit_Click;

                    }
                    else
                    {
                        usrc_DocumentMan xusrc_DocumentMan = new usrc_DocumentMan();
                        xusrc_DocumentMan.Visible = false;
                        xusrc_DocumentMan.Dock = DockStyle.Fill;
                        this.Controls.Add(xusrc_DocumentMan);

                        xusrc_DocumentMan.Initialise(this, xLMOUser);
                        xusrc_DocumentMan.Init();


                        xLMOUser.m_usrc_DocumentMan = xusrc_DocumentMan;
                        xusrc_DocumentMan.Exit_Click += m_usrc_Main_Exit_Click;
                    }
                }
            }
            else
            {
                transaction_Form_Document_loginControl1_UserLoggedIn_user_settings_Load.Rollback();
            }
        }



        private void loginControl1_UserLoggedOut(LoginControl.LMOUser xLMOUser)
        {
            TSettings.SaveSettings(this,xLMOUser);
        }

        private void loginControl1_ActivateDocumentMan(LoginControl.LMOUser xLMOUser)
        {

            if (xLMOUser.m_usrc_DocumentMan is usrc_DocumentMan)
            {
                documentMan = (usrc_DocumentMan)xLMOUser.m_usrc_DocumentMan;
                LogFile.LogFile.WriteDEBUG("** Form_Document:Form_Document_Shown():after m_startup.RemoveControl()!");

                SettingsUser user_settings = (SettingsUser)xLMOUser.oSettings;
                LayoutSet(user_settings.mSettingsUserValues);

                if (xLMOUser.ReloadRequest)
                {
                    documentMan.Reload();
                    xLMOUser.ReloadRequest = false;
                }

                documentMan.Active = true;

                documentMan.Activate_dgvx_XInvoice_SelectionChanged();

                LogFile.LogFile.WriteDEBUG("** Form_Document:Form_Document_Shown():after m_usrc_Main.Activate_dgvx_XInvoice_SelectionChanged()!");

                SetNewFormTag();
                documentMan.LayoutChanged += M_usrc_Main_LayoutChanged;
            }
            else if (xLMOUser.m_usrc_DocumentMan is usrc_DocumentMan1366x768)
            {
                DocumentMan1366x768 = (usrc_DocumentMan1366x768)xLMOUser.m_usrc_DocumentMan;
                LogFile.LogFile.WriteDEBUG("** Form_Document:Form_Document_Shown():after m_startup.RemoveControl()!");

                SettingsUser user_settings = (SettingsUser)xLMOUser.oSettings;
                //LayoutSet(user_settings.mSettingsUserValues);

                if (xLMOUser.ReloadRequest)
                {
                    DocumentMan1366x768.Reload();
                    xLMOUser.ReloadRequest = false;
                }

                DocumentMan1366x768.Active = true;

                DocumentMan1366x768.Activate_dgvx_XInvoice_SelectionChanged();

                LogFile.LogFile.WriteDEBUG("** Form_Document:Form_Document_Shown():after m_usrc_Main.Activate_dgvx_XInvoice_SelectionChanged()!");

                SetNewFormTag();
                DocumentMan1366x768.LayoutChanged += M_usrc_Main_LayoutChanged;
            }

        }

        private bool loginControl1_Edit_myOrganisationPerson(Form parentform, ID myOrganisation_Person_ID, ref bool Changed, ref ID myOrganisation_Person_ID_new)
        {
            return call_Edit_myOrganisationPerson(parentform, myOrganisation_Person_ID, ref Changed, ref myOrganisation_Person_ID_new);
        }

        private void loginControl1_Reload(LoginControl.LMOUser xLMOUser)
        {
            if (xLMOUser.m_usrc_DocumentMan is usrc_DocumentMan)
            {
                usrc_DocumentMan xusrc_DocumentMan = (usrc_DocumentMan)xLMOUser.m_usrc_DocumentMan;
                if (xusrc_DocumentMan != null)
                {
                    xusrc_DocumentMan.Reload();
                }
            }
            else if (xLMOUser.m_usrc_DocumentMan is usrc_DocumentMan1366x768)
            {
                usrc_DocumentMan1366x768 xusrc_DocumentMan1366x768 = (usrc_DocumentMan1366x768)xLMOUser.m_usrc_DocumentMan;
                if (xusrc_DocumentMan1366x768 != null)
                {
                    xusrc_DocumentMan1366x768.Reload();
                }
            }

        }
    }
}
