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

namespace Tangenta
{
    public partial class Form_Document : Form
    {
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


        public Form_Document()
        {
            LogFile.LogFile.WriteRELEASE("Form_Document()before InitializeComponent()!");
            InitializeComponent();

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

        private void Exit()
        {
            Properties.Settings.Default.Current_DocInvoice_ID = m_usrc_Main.m_usrc_InvoiceMan.m_usrc_InvoiceTable.Current_Doc_ID;
            Properties.Settings.Default.LastDocInvoiceType = Program.RunAs;
            Properties.Settings.Default.Save();
            if (m_usrc_Main.m_usrc_InvoiceMan.m_usrc_Invoice.m_usrc_ShopA != null)
            {
                if (m_usrc_Main.m_usrc_InvoiceMan.m_usrc_Invoice.m_usrc_ShopA.usrc_Editor1.m_tool_SelectItem != null)
                {
                    m_usrc_Main.m_usrc_InvoiceMan.m_usrc_Invoice.m_usrc_ShopA.usrc_Editor1.m_tool_SelectItem.Close();
                    m_usrc_Main.m_usrc_InvoiceMan.m_usrc_Invoice.m_usrc_ShopA.usrc_Editor1.m_tool_SelectItem = null;
                }
            }
            long atom_work_period_id = TangentaDB.GlobalData.Atom_WorkPeriod_ID;
            if (fs.IDisValid(atom_work_period_id))
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

            m_usrc_Main.Visible = true;
            m_usrc_Main.Activate_dgvx_XInvoice_SelectionChanged();

            LogFile.LogFile.WriteDEBUG("** Form_Document:Form_Document_Shown():after m_usrc_Main.Activate_dgvx_XInvoice_SelectionChanged()!");

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
				<div class = 'OrgName'>"+ token_Orgname + @"</div>
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
    }
}
