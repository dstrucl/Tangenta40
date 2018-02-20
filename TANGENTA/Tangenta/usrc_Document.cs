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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeTables;
using LanguageControl;
using TangentaTableClass;
using TangentaDB;
using UpgradeDB;
using Startup;
using NavigationButtons;
using static Tangenta.Program;

namespace Tangenta
{
    public partial class usrc_Document : UserControl
    {

        Form Main_Form = null;
        public delegate void delegate_Exit_Click();

        internal usrc_Invoice.eGetOrganisationDataResult Startup_05_Check_myOrganisation_Data()
        {
            usrc_Invoice.eGetOrganisationDataResult eres = this.m_usrc_InvoiceMan.m_usrc_Invoice.GetOrganisationData();
            return eres;

        }

        public event delegate_Exit_Click Exit_Click;
        public UpgradeDB_inThread m_UpgradeDB = null;


        public usrc_Document()
        {
            InitializeComponent();
            Program.usrc_TangentaPrint1 = this.usrc_TangentaPrint1;
            m_UpgradeDB = new UpgradeDB_inThread(this);
        }

        private bool Get_FVI(Navigation xnav)
        {
            Program.b_FVI_SLO = false;
            if (myOrg.Address_v != null)
            {
                if (myOrg.Address_v.Country_ISO_3166_num == TangentaDB.PostAddress_v.SLO_Country_ISO_3166_num)
                {
                    Program.b_FVI_SLO = true;
                    if (Program.bFirstTimeInstallation)
                    {
                        Do_Form_FVI_check:
                        xnav.ChildDialog = new Form_FVI_check(xnav);
                        xnav.ShowDialog();
                        if (Program.b_FVI_SLO)
                        {
                            if (xnav.eExitResult == Navigation.eEvent.NEXT)
                            {
                                long FVI_SLO_RealEstateBP_rows_count = fs.GetTableRowsCount("FVI_SLO_RealEstateBP");
                                if (FVI_SLO_RealEstateBP_rows_count == 0)
                                {

                                    Do_Form_myOrg_Office_Data_FVI_SLO_RealEstateBP:

                                    xnav.ChildDialog = new Form_myOrg_Office_Data_FVI_SLO_RealEstateBP(myOrg.myOrg_Office_list[0].Office_Data_ID_v.v, xnav);
                                    xnav.ShowDialog();
                                    if (xnav.eExitResult == Navigation.eEvent.PREV)
                                    {
                                        goto Do_Form_FVI_check;
                                    }
                                    else if (xnav.eExitResult == Navigation.eEvent.NEXT)
                                    {
                                        bool Reset2FactorySettings_FiscalVerification_DLL = Program.Reset2FactorySettings.FiscalVerification_DLL;
                                        xnav.ChildDialog = new FiscalVerificationOfInvoices_SLO.Form_Settings(usrc_FVI_SLO1, xnav, ref Reset2FactorySettings_FiscalVerification_DLL);
                                        Program.Reset2FactorySettings.FiscalVerification_DLL = Reset2FactorySettings_FiscalVerification_DLL;
                                        xnav.ShowDialog();
                                        if (xnav.eExitResult == Navigation.eEvent.PREV)
                                        {
                                            goto Do_Form_myOrg_Office_Data_FVI_SLO_RealEstateBP;
                                        }
                                    }
                                }
                                else
                                {
                                    bool Reset2FactorySettings_FiscalVerification_DLL = Program.Reset2FactorySettings.FiscalVerification_DLL;
                                    xnav.ChildDialog = new FiscalVerificationOfInvoices_SLO.Form_Settings(usrc_FVI_SLO1, xnav, ref Reset2FactorySettings_FiscalVerification_DLL);
                                    Program.Reset2FactorySettings.FiscalVerification_DLL = Reset2FactorySettings_FiscalVerification_DLL;
                                    xnav.ShowDialog();
                                    if (xnav.eExitResult == Navigation.eEvent.PREV)
                                    {
                                        goto Do_Form_FVI_check;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }

        internal bool Startup_08_CheckPogramSettings(bool bResetShopsInUse)
        {
            if (Program.bFirstTimeInstallation || (Program.Shops_in_use.Length == 0))
            {
                return false;
            }
            else
            {
                if (Program.Shops_in_use.Length > 0)
                {
                    return true;
                }
            }
            return false;
        }

        internal bool Startup_08_Show_Form_ProgramSettings(NavigationButtons.Navigation xnav)
        {
            xnav.ShowForm(new Form_ProgramSettings(this, xnav), typeof(Form_ProgramSettings).ToString());
            return true;
        }


        public bool Get_ProgramSettings(NavigationButtons.Navigation xnav, bool bResetShopsInUse)
        {
            if (Program.bFirstTimeInstallation || (Program.Shops_in_use.Length == 0))
            {
                xnav.ChildDialog = new Form_ProgramSettings(this, xnav);
                xnav.ShowDialog();
                if (xnav.m_eButtons == NavigationButtons.Navigation.eButtons.PrevNextExit)
                {
                    switch (xnav.eExitResult)
                    {
                        case NavigationButtons.Navigation.eEvent.NEXT:
                            return true;
                        case NavigationButtons.Navigation.eEvent.PREV:
                            return true;
                        default:
                            return false;
                    }
                }
                else if (xnav.m_eButtons == NavigationButtons.Navigation.eButtons.OkCancel)
                {
                    switch (xnav.eExitResult)
                    {
                        case NavigationButtons.Navigation.eEvent.OK:

                            if (m_usrc_InvoiceMan.m_usrc_Invoice != null)
                            {
                                if (m_usrc_InvoiceMan.m_usrc_Invoice.DBtcn != null)
                                {
                                    m_usrc_InvoiceMan.m_usrc_Invoice.Set_eShopsMode(Properties.Settings.Default.eShopsInUse, xnav);
                                    return true;
                                }
                            }
                            return true;
                        default:
                            return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Document:Get_shops_in_use:Error " + xnav.m_eButtons.ToString() + "not implemented!");
                    return false;
                }
            }
            else
            {
                if (Program.Shops_in_use.Length > 0)
                {
                    xnav.eExitResult = Navigation.eEvent.NEXT;
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Document:Get_shops_in_use:Error Program.Shops_in_use.Length <= 0!");
                    return false;
                }
            }
        }

        internal bool Startup_12_Get_Printer(startup myStartup, ref string Err)
        {
            //Insert default templates for Proforma Invoice and for 
            if (f_doc.InsertDefault())
            {
                TangentaPrint.PrintersList.Init();

                if (TangentaPrint.PrintersList.Read(Reset2FactorySettings.TangentaPrint_DLL))
                {
                    //myStartup.eNextStep++;
                    return true;
                }
                else
                {
                    return false;

                }
            }
            else
            {
                //myStartup.eNextStep = Startup.startup_step.eStep.Cancel;
                return false;
            }
        }

        internal bool Get_Printer(startup myStartup, object oData, Navigation xnav, ref string Err)
        {
            //Insert default templates for Proforma Invoice and for 
            if (f_doc.InsertDefault())
            {
                TangentaPrint.PrintersList.Init();

                if (TangentaPrint.PrintersList.Read(Reset2FactorySettings.TangentaPrint_DLL))
                {
                    //myStartup.eNextStep++;
                    return true;
                }
                else
                {
                    if (TangentaPrint.PrintersList.Define(xnav))
                    {
                        if (xnav.eExitResult == Navigation.eEvent.NEXT)
                        {
                            //myStartup.eNextStep++;
                            return true;
                        }
                        else if (xnav.eExitResult == Navigation.eEvent.PREV)
                        {
                            //myStartup.eNextStep--;
                            return true;
                        }
                        else if (xnav.eExitResult == Navigation.eEvent.CANCEL)
                        {
                            //myStartup.eNextStep = Startup.startup_step.eStep.Cancel;
                            return false;
                        }
                    }
                    return false;
                }
            }
            else
            {
                //myStartup.eNextStep = Startup.startup_step.eStep.Cancel;
                return false;
            }
        }

        internal bool Initialise(Form main_Form)
        {
            Main_Form = main_Form;
            return this.m_usrc_InvoiceMan.Initialise(Main_Form);
        }


        internal bool SetShopsPricelists(startup myStartup, object oData, Navigation xnav, ref string Err)
        {
            if (m_usrc_InvoiceMan != null)
            {
                if (m_usrc_InvoiceMan.m_usrc_Invoice != null)
                {
                    if (m_usrc_InvoiceMan.m_usrc_Invoice.DBtcn != null)
                    {
                        m_usrc_InvoiceMan.m_usrc_Invoice.Set_eShopsMode(Properties.Settings.Default.eShopsInUse, xnav);
                        if (xnav.eExitResult == Navigation.eEvent.NEXT)
                        {
                            //myStartup.eNextStep++;
                            return true;
                        }
                        else if (xnav.eExitResult == Navigation.eEvent.PREV)
                        {
                            //myStartup.eNextStep--;
                            return true;
                        }
                        else if (xnav.eExitResult == Navigation.eEvent.EXIT)
                        {
                            //myStartup.eNextStep = startup_step.eStep.Cancel;
                            return true;
                        }
                    }
                }
            }

            //myStartup.eNextStep++;
            return true;
        }

        internal bool Init(NavigationButtons.Navigation xnav)
        {
            string Err = null;
            Program.usrc_FVI_SLO1 = this.usrc_FVI_SLO1;
            Program.thread_fvi = this.usrc_FVI_SLO1.thread_fvi;
            Program.message_box = this.usrc_FVI_SLO1.message_box;

            if (Program.b_FVI_SLO)
            {

                Program.usrc_FVI_SLO1.FursD_ElectronicDeviceID = Properties.Settings.Default.ElectronicDevice_ID;
            }

            if (Program.b_FVI_SLO)
            {
                if (f_Atom_FVI_SLO_RealEstateBP.Get_Atom_FVI_SLO_RealEstateBP_ID(Main_Form, ref Program.Atom_FVI_SLO_RealEstateBP_ID, 1))
                {
                }
            }

            LogFile.LogFile.WriteDEBUG("usrc_Document.cs:Init():before this.m_usrc_InvoiceMan.Init(xnav)!");

            if (this.m_usrc_InvoiceMan.Init(xnav))
            {
                if (Program.b_FVI_SLO)
                {
                    if (this.usrc_FVI_SLO1.Start(ref Err))
                    {
                        if (this.m_usrc_InvoiceMan.IsDocInvoice)
                        {
                            if (Program.b_FVI_SLO)
                            {
                                this.m_usrc_InvoiceMan.m_usrc_Invoice.m_InvoiceData.AddOnDI.b_FVI_SLO = Program.b_FVI_SLO;
                                if (Program.usrc_FVI_SLO1.Check_InvoiceNotConfirmedAtFURS(this.m_usrc_InvoiceMan.m_usrc_Invoice.m_ShopABC, this.m_usrc_InvoiceMan.m_usrc_Invoice.m_InvoiceData.AddOnDI, this.m_usrc_InvoiceMan.m_usrc_Invoice.m_InvoiceData.AddOnDPI))
                                {
                                    this.m_usrc_InvoiceMan.SetDocument(xnav);
                                }
                                //Program.usrc_FVI_SLO1.Check_SalesBookInvoice(this.m_usrc_InvoiceMan.m_usrc_Invoice.m_ShopABC, this.m_usrc_InvoiceMan.m_usrc_Invoice.m_InvoiceData.AddOnDI, this.m_usrc_InvoiceMan.m_usrc_Invoice.m_InvoiceData.AddOnDPI);
                            }
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("usrc_Main:Init:this.usrc_FVI_SLO1.Start(ref Err):Err=" + Err);
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckInsertSampleData(startup myStartup, NavigationButtons.Navigation xnav)
        {
            Form_CheckInsertSampleData frmdlg = new Form_CheckInsertSampleData(myStartup, xnav);
            xnav.ChildDialog = frmdlg;
            xnav.ShowDialog();
            return myStartup.bInsertSampleData;
        }

        internal bool Startup_05_Show_Form_CheckInsertSampleData(startup myStartup, NavigationButtons.Navigation xnav)
        {
            xnav.ShowForm(new Form_CheckInsertSampleData(myStartup, xnav), typeof(Form_CheckInsertSampleData).ToString());
            return true;
        }



        internal bool GetDBSettings(ref string Err)
        {
            bool bReadOnly = false;
            Err = null;
            long lRowsCount = fs.GetTableRowsCount("DBSettings");
            if (lRowsCount > 0)
            {
                switch (fs.GetDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.AdminPassword.Name, ref Program.AdministratorLockedPassword, ref bReadOnly, ref Err))
                {
                    case fs.enum_GetDBSettings.DBSettings_OK:
                        string MultiuserOperationWithLogin = null;
                        switch (fs.GetDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.MultiUserOperation.Name, ref MultiuserOperationWithLogin, ref bReadOnly, ref Err))
                        {
                            case fs.enum_GetDBSettings.DBSettings_OK:
                                Program.OperationMode.MultiUser = MultiuserOperationWithLogin.Equals("1");

                                string StockCheckAtStartup = null;
                                switch (fs.GetDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.StockCheckAtStartup.Name, ref StockCheckAtStartup, ref bReadOnly, ref Err))
                                {
                                    case fs.enum_GetDBSettings.DBSettings_OK:
                                        Program.OperationMode.StockCheckAtStartup = StockCheckAtStartup.Equals("1");

                                        string sSingleUserLoginAsAdministrator = null;
                                        switch (fs.GetDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.SingleUserLoginAsAdministrator.Name, ref sSingleUserLoginAsAdministrator, ref bReadOnly, ref Err))
                                        {
                                            case fs.enum_GetDBSettings.DBSettings_OK:
                                                Program.OperationMode.SingleUserLoginAsAdministrator = sSingleUserLoginAsAdministrator.Equals("1");

                                                string sShopC_ExclusivelySellFromStock = null;
                                                switch (fs.GetDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.ShopC_ExclusivelySellFromStock.Name, ref sShopC_ExclusivelySellFromStock, ref bReadOnly, ref Err))
                                                {
                                                    case fs.enum_GetDBSettings.DBSettings_OK:
                                                        Program.OperationMode.ShopC_ExclusivelySellFromStock = sShopC_ExclusivelySellFromStock.Equals("1");

                                                        string sMultiCurrencyOperation = null;
                                                        switch (fs.GetDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.MultiCurrencyOperation.Name, ref sMultiCurrencyOperation, ref bReadOnly, ref Err))
                                                        {
                                                            case fs.enum_GetDBSettings.DBSettings_OK:
                                                                Program.OperationMode.MultiCurrency = sMultiCurrencyOperation.Equals("1");
                                                                return true;

                                                            case fs.enum_GetDBSettings.No_TextValue:
                                                            case fs.enum_GetDBSettings.No_Data_Rows:
                                                                Err = DBSync.DBSync.DB_for_Tangenta.Settings.MultiCurrencyOperation.Name;
                                                                return false;

                                                            case fs.enum_GetDBSettings.Error_Load_DBSettings:

                                                                return false;
                                                        }
                                                        break;

                                                    case fs.enum_GetDBSettings.No_TextValue:
                                                    case fs.enum_GetDBSettings.No_Data_Rows:
                                                        Err = DBSync.DBSync.DB_for_Tangenta.Settings.ShopC_ExclusivelySellFromStock.Name;
                                                        return false;

                                                    case fs.enum_GetDBSettings.Error_Load_DBSettings:
                                                        return false;
                                                }
                                                break;


                                            case fs.enum_GetDBSettings.No_TextValue:
                                            case fs.enum_GetDBSettings.No_Data_Rows:
                                                Err = DBSync.DBSync.DB_for_Tangenta.Settings.StockCheckAtStartup.Name;
                                                return false;

                                            case fs.enum_GetDBSettings.Error_Load_DBSettings:
                                                return false;
                                        }
                                        break;

                                    case fs.enum_GetDBSettings.No_ReadOnly:
                                    case fs.enum_GetDBSettings.No_TextValue:
                                    case fs.enum_GetDBSettings.No_Data_Rows:
                                        Err = DBSync.DBSync.DB_for_Tangenta.Settings.MultiUserOperation.Name;
                                        return false;
                                    case fs.enum_GetDBSettings.Error_Load_DBSettings:
                                        return false;
                                }
                                break;


                            case fs.enum_GetDBSettings.No_ReadOnly:
                            case fs.enum_GetDBSettings.No_TextValue:
                            case fs.enum_GetDBSettings.No_Data_Rows:
                                Err = DBSync.DBSync.DB_for_Tangenta.Settings.StockCheckAtStartup.Name;
                                return false;
                            case fs.enum_GetDBSettings.Error_Load_DBSettings:
                                return false;
                        }
                        break;
                    case fs.enum_GetDBSettings.No_ReadOnly:
                    case fs.enum_GetDBSettings.No_TextValue:
                    case fs.enum_GetDBSettings.No_Data_Rows:
                        Err = DBSync.DBSync.DB_for_Tangenta.Settings.AdminPassword.Name;
                        return false;
                    case fs.enum_GetDBSettings.Error_Load_DBSettings:
                        Err = fs.ERROR;
                        return false;
                }

                return false; // GlobalData.Type_definitions_Read();
            }
            else
            {
                Err = fs.EMPTYTABLE;
                return false; // No DataRows;
            }
        }
    
       
    

        private bool getWorkPeriod(long myOrganisation_Person_ID, ref long xAtom_WorkPeriod_ID)
        {
                string Err = null;
                if(GlobalData.GetWorkPeriod(myOrganisation_Person_ID,f_Atom_WorkPeriod.sWorkPeriod, "Šiht", Properties.Settings.Default.ElectronicDevice_ID, null, DateTime.Now, null, ref Err))
                {
                    xAtom_WorkPeriod_ID = GlobalData.Atom_WorkPeriod_ID;
                    return true;
                }
                else
                {
                    xAtom_WorkPeriod_ID = -1;
                    GlobalData.Atom_WorkPeriod_ID = -1;
                    return false;
                }
        }
    
        public bool call_Edit_myOrganisationPerson(Form parentform,long myOrganisation_Person_ID, ref bool Changed, ref long myOrganisation_Person_ID_new)
        {
            Navigation xnav = new Navigation(null);
            xnav.m_eButtons = Navigation.eButtons.OkCancel;
            Form_myOrg_Person_Edit frm_myOrgPerEdit = new Form_myOrg_Person_Edit(1, xnav);
            frm_myOrgPerEdit.TopMost = parentform.TopMost;
            frm_myOrgPerEdit.Show(parentform);
            return true;
        }

    public bool GetWorkPeriod(startup myStartup,object oData, NavigationButtons.Navigation xnav, ref string Err)
    {
        if (Program.OperationMode.MultiUser)
        {
            bool bCancel = false;
            this.loginControl1.Init(LoginControl.LoginCtrl.eDataTableCreationMode.AWP,
                                            DBSync.DBSync.DB_for_Tangenta.m_DBTables.m_con,
                                            this.getWorkPeriod,
                                            call_Edit_myOrganisationPerson,
                                            null,
                                            LanguageControl.DynSettings.LanguageID,
                                            ref bCancel
                                            );

            if (this.loginControl1.Login(xnav, getWorkPeriod))
            {
                    //myStartup.eNextStep++;
                    return true;
            }
            else
            {
                    //myStartup.eNextStep = Startup.startup_step.eStep.Cancel;
                    return false;
            }
        }
        else // Single user
        {
            this.loginControl1.Visible = false;
            long myOrganisation_Person_first_ID = f_myOrganisation_Person.First_ID();
            if (myOrganisation_Person_first_ID >= 0)
            {
                if (Program.bFirstTimeInstallation)
                {
                    if (GlobalData.GetWorkPeriod(myOrganisation_Person_first_ID, f_Atom_WorkPeriod.sWorkPeriod, "Šiht", Properties.Settings.Default.ElectronicDevice_ID, null, DateTime.Now, null, ref Err))
                    {
                            //myStartup.eNextStep++;
                            return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Main:GlobalData.GetWorkPeriod:Err=" + Err);
                            //myStartup.eNextStep = Startup.startup_step.eStep.Cancel;
                            return false;
                    }
                }
                else
                {
                    if (Program.OperationMode.SingleUserLoginAsAdministrator)
                    {
                        if (Door.DoLoginAsAdministrator((Form)this.Parent))
                        {
                            if (GlobalData.GetWorkPeriod(myOrganisation_Person_first_ID, f_Atom_WorkPeriod.sWorkPeriod, "Šiht", Properties.Settings.Default.ElectronicDevice_ID, null, DateTime.Now, null, ref Err))
                            {
                                    //myStartup.eNextStep++;
                                    return true;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:usrc_Main:GlobalData.GetWorkPeriod:Err=" + Err);
                                    //myStartup.eNextStep = Startup.startup_step.eStep.Cancel;
                                    return false;
                            }
                        }
                        else
                        {
                                //myStartup.eNextStep = Startup.startup_step.eStep.Cancel;
                                return false;
                        }
                    }
                    else
                    {
                        if (GlobalData.GetWorkPeriod(myOrganisation_Person_first_ID,f_Atom_WorkPeriod.sWorkPeriod, "Šiht", Properties.Settings.Default.ElectronicDevice_ID, null, DateTime.Now, null, ref Err))
                        {
                                //myStartup.eNextStep++;
                                return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:usrc_Main:GlobalData.GetWorkPeriod:Err=" + Err);
                                //myStartup.eNextStep = Startup.startup_step.eStep.Cancel;
                                return false;
                        }
                    }
                }
            }
            else
            {
                return false;
            }
          }
        }


        private void btn_Exit_Click(object sender, EventArgs e)
        {
            if (Exit_Click!=null)
            {
                Exit_Click();
            }
        }




        private void btn_Settings_Click(object sender, EventArgs e)
        {
            if (Door.OpenIfUserIsAdministrator(Global.f.GetParentForm(this)))
            {
                NavigationButtons.Navigation nav_Form_ProgramSettings = new NavigationButtons.Navigation(null);
                nav_Form_ProgramSettings.bDoModal = true;
                nav_Form_ProgramSettings.m_eButtons = NavigationButtons.Navigation.eButtons.OkCancel;
                Form_ProgramSettings edt_Form = new Form_ProgramSettings(this, nav_Form_ProgramSettings);
                edt_Form.ShowDialog();
                edt_Form.Dispose();
            }
        }

        private void btn_Backup_Click(object sender, EventArgs e)
        {

            string sDBType = Properties.Settings.Default.DBType;
            DBConnectionControl40.DBConnection.eDBType org_eDBType = DBSync.DBSync.m_DBType;
            NavigationButtons.Navigation nav = new NavigationButtons.Navigation(null);
            nav.btn3_Visible = true;
            nav.btn3_Text = "";
            nav.btn3_Image = Properties.Resources.Exit;
            string xCodeTables_IniFileFolder = null;
            string Err = null;
            if (StaticLib.Func.SetApplicationDataSubFolder(ref xCodeTables_IniFileFolder, Program.TANGENTA_SETTINGS_SUB_FOLDER, ref Err))
            {
                string xSQLitebackupFolder = Properties.Settings.Default.SQLiteBackupFolder;
                if (xSQLitebackupFolder.Length == 0)
                {
                    if (StaticLib.Func.SetApplicationDataSubFolder(ref xSQLitebackupFolder, Program.TANGENTA_SQLITEBACKUP_SUB_FOLDER, ref Err))
                    {
                    }
                }
                DBSync.DBSync.DBMan(Main_Form, Program.Reset2FactorySettings.DBConnectionControlXX_EXE, ((Form_Document)Main_Form).m_XmlFileName, xCodeTables_IniFileFolder, ref sDBType, ref xSQLitebackupFolder, nav);
                Properties.Settings.Default.SQLiteBackupFolder = xSQLitebackupFolder;
                Properties.Settings.Default.DBType = sDBType;
                Properties.Settings.Default.Save();
            }
        }

        internal void Activate_dgvx_XInvoice_SelectionChanged()
        {
            this.m_usrc_InvoiceMan.Activate_dgvx_XInvoice_SelectionChanged();
        }

        private void btn_CodeTables_Click(object sender, EventArgs e)
        {
            if (Door.OpenIfUserIsAdministrator(Global.f.GetParentForm(this)))
            {
                Form_CodeTables fct_dlg = new Form_CodeTables();
                fct_dlg.ShowDialog();
            }
        }

        private void usrc_FVI_SLO1_PasswordCheck(ref bool PasswordOK)
        {
            PasswordOK = false;
            if (Door.OpenIfUserIsAdministrator(Global.f.GetParentForm(this)))
            { 
                    PasswordOK = true;
            }
        }

        private bool usrc_TangentaPrint1_CheckEditPrinterAccess()
        {
            return Door.OpenIfUserIsAdministrator(Global.f.GetParentForm(this));
        }
    }
}
