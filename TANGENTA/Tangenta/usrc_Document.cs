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
        private string LockedPassword = null;

        Form Main_Form = null;
        public delegate void delegate_Exit_Click();
        public event delegate_Exit_Click Exit_Click;
        public UpgradeDB_inThread m_UpgradeDB = null;


        public usrc_Document()
        {
            InitializeComponent();
            Program.usrc_TangentaPrint1 = this.usrc_TangentaPrint1;
            m_UpgradeDB = new UpgradeDB_inThread(this);
        }

        public bool Get_ProgramSettings(startup myStartup,object oData, NavigationButtons.Navigation xnav,ref string Err)
        {
            if (fs.Get_JOURNAL_TYPE_ID())
            {
do_Get_ProgramSettings:
                if (Get_ProgramSettings(xnav, true))
                {
                    switch (xnav.eExitResult)
                    {
                        case NavigationButtons.Navigation.eEvent.NEXT:
                            if (Get_FVI(xnav))
                            {
                                switch (xnav.eExitResult)
                                {
                                    case NavigationButtons.Navigation.eEvent.NEXT:
                                        myStartup.eNextStep++;
                                        return true;
                                    case NavigationButtons.Navigation.eEvent.PREV:
                                        goto do_Get_ProgramSettings;

                                    case NavigationButtons.Navigation.eEvent.EXIT:
                                        myStartup.eNextStep = Startup.startup_step.eStep.Cancel;
                                        return true;


                                }
                            }
                            break;

                        case NavigationButtons.Navigation.eEvent.PREV:
                            myStartup.eNextStep--;
                            return true;
                        case NavigationButtons.Navigation.eEvent.EXIT:
                            myStartup.eNextStep = Startup.startup_step.eStep.Cancel;
                            return true;
                    }
                }
                else
                {
                    myStartup.eNextStep = Startup.startup_step.eStep.Cancel;
                }
                return true;
            }
            return false;
        }

        private bool Get_FVI(Navigation xnav)
        {
            Program.b_FVI_SLO = false;
            if (myOrg.Address_v!=null)
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
Do_Form_myOrg_Office_Data_FVI_SLO_RealEstateBP:

                                xnav.ChildDialog = new Form_myOrg_Office_Data_FVI_SLO_RealEstateBP(myOrg.myOrg_Office_list[0].Office_Data_ID_v.v, xnav);
                                xnav.ShowDialog();
                                if (xnav.eExitResult == Navigation.eEvent.PREV)
                                {
                                    goto Do_Form_FVI_check;
                                }
                                else if (xnav.eExitResult == Navigation.eEvent.NEXT)
                                {
                                    xnav.ChildDialog = new FiscalVerificationOfInvoices_SLO.Form_Settings(usrc_FVI_SLO1,xnav);
                                    xnav.ShowDialog();
                                    if (xnav.eExitResult == Navigation.eEvent.PREV)
                                    {
                                        goto Do_Form_myOrg_Office_Data_FVI_SLO_RealEstateBP;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }

        public bool Get_ProgramSettings(NavigationButtons.Navigation xnav,bool bResetShopsInUse)
        {
            if (Program.bFirstTimeInstallation||(Program.Shops_in_use.Length == 0))
            {
                xnav.ChildDialog = new Form_ProgramSettings(this,xnav);
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

        internal bool Get_Printer(startup myStartup, object oData, Navigation xnav, ref string Err)
        {
            //Insert default templates for Proforma Invoice and for 
            if (f_doc.InsertDefault())
            {
                TangentaPrint.PrintersList.Init();

                if (TangentaPrint.PrintersList.Read(Reset2FactorySettings.TangentaPrint_DLL)) 
                {
                    myStartup.eNextStep++;
                    return true;
                }
                else
                {
                    if (TangentaPrint.PrintersList.Define(xnav))
                    {
                        if (xnav.eExitResult == Navigation.eEvent.NEXT)
                        {
                            myStartup.eNextStep++;
                            return true;
                        }
                        else if (xnav.eExitResult == Navigation.eEvent.PREV)
                        {
                            myStartup.eNextStep--;
                            return true;
                        }
                        else if (xnav.eExitResult == Navigation.eEvent.CANCEL)
                        {
                            myStartup.eNextStep = Startup.startup_step.eStep.Cancel;
                            return false;
                        }
                    }
                    return false;
                }
            }
            else
            {
               myStartup.eNextStep = Startup.startup_step.eStep.Cancel;
                return false;
            }
        }

        internal bool Initialise(Form main_Form)
        {
            Main_Form = main_Form;
            return  this.m_usrc_InvoiceMan.Initialise(Main_Form);
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
                        if (xnav.eExitResult== Navigation.eEvent.NEXT)
                        {
                            myStartup.eNextStep++;
                            return true;
                        }
                        else if (xnav.eExitResult == Navigation.eEvent.PREV)
                        {
                            myStartup.eNextStep--;
                            return true;
                        }
                        else if (xnav.eExitResult == Navigation.eEvent.EXIT)
                        {
                            myStartup.eNextStep = startup_step.eStep.Cancel;
                            return true;
                        }
                    }
                }
            }

            myStartup.eNextStep++;
            return true;
        }

        internal bool Init(NavigationButtons.Navigation xnav)
        {
            string Err = null;

            if (Program.b_FVI_SLO)
            {
                Program.usrc_FVI_SLO1 = this.usrc_FVI_SLO1;
                Program.usrc_FVI_SLO1.FursD_ElectronicDeviceID = Properties.Settings.Default.ElectronicDevice_ID;
                if (Program.Reset2FactorySettings.FiscalVerification_DLL)
                {
                    Program.usrc_FVI_SLO1.Settings_Reset(this);
                }
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
                                Program.usrc_FVI_SLO1.Check_SalesBookInvoice(this.m_usrc_InvoiceMan.m_usrc_Invoice.m_ShopABC);
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
            Form_CheckInsertSampleData frmdlg = new Form_CheckInsertSampleData(myStartup,xnav);
            xnav.ChildDialog = frmdlg;
            xnav.ShowDialog();
            return myStartup.bInsertSampleData;
        }

        internal bool GetDBSettings_And_JOURNAL_DocInvoice_Type(startup myStartup, ref string Err)
        {
            bool bReadOnly = false;
            switch (fs.GetDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.AdminPassword.Name, ref Program.AdministratorLockedPassword, ref bReadOnly, ref Err))
            {
                case fs.enum_GetDBSettings.DBSettings_OK:
                    string MultiuserOperationWithLogin = null;
                    switch (fs.GetDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.AdminPassword.Name, ref MultiuserOperationWithLogin, ref bReadOnly, ref Err))
                    {
                        case fs.enum_GetDBSettings.DBSettings_OK:
                            Program.MultiuserOperationWithLogin = MultiuserOperationWithLogin.Equals("1");
                            string StockCheckAtStartup = null;
                            switch (fs.GetDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.AdminPassword.Name, ref StockCheckAtStartup, ref bReadOnly, ref Err))
                            {
                                case fs.enum_GetDBSettings.DBSettings_OK:
                                    Program.StockCheckAtStartup = StockCheckAtStartup.Equals("1");
                                    break;

                                case fs.enum_GetDBSettings.No_ReadOnly:
                                case fs.enum_GetDBSettings.No_TextValue:
                                case fs.enum_GetDBSettings.No_Data_Rows:
                                    if (!GetMissingDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.StockCheckAtStartup.Name))
                                    {
                                        myStartup.eNextStep = startup_step.eStep.Cancel;
                                        return false;
                                    }
                                    break;
                                case fs.enum_GetDBSettings.Error_Load_DBSettings:
                                    myStartup.eNextStep = startup_step.eStep.Cancel;
                                    return false;
                            }
                            break;


                        case fs.enum_GetDBSettings.No_ReadOnly:
                        case fs.enum_GetDBSettings.No_TextValue:
                        case fs.enum_GetDBSettings.No_Data_Rows:
                            if (!GetMissingDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.StockCheckAtStartup.Name))
                            {
                                myStartup.eNextStep = startup_step.eStep.Cancel;
                                return false;
                            }
                            break;
                        case fs.enum_GetDBSettings.Error_Load_DBSettings:
                            myStartup.eNextStep = startup_step.eStep.Cancel;
                            return false;
                    }
                    break;
                case fs.enum_GetDBSettings.No_ReadOnly:
                case fs.enum_GetDBSettings.No_TextValue:
                case fs.enum_GetDBSettings.No_Data_Rows:
                    if (!GetMissingDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.StockCheckAtStartup.Name))
                    {
                        myStartup.eNextStep = startup_step.eStep.Cancel;
                        return false;
                    }
                    break;
                case fs.enum_GetDBSettings.Error_Load_DBSettings:
                    myStartup.eNextStep = startup_step.eStep.Cancel;
                    return false;
            }
            myStartup.eNextStep++;
            return GlobalData.Type_definitions_Read();

        }

        internal bool CheckDataBaseVersion(startup myStartup, ref string Err)
        {
            if (myStartup.CurrentDataBaseVersionTextValue.Equals(DBSync.DBSync.DB_for_Tangenta.Settings.Version.TextValue))
            {
                return GetDBSettings_And_JOURNAL_DocInvoice_Type(myStartup, ref Err);
            }
            else
            {
                if (MessageBox.Show(this.Main_Form, lngRPM.s_Database_Version_is.s + myStartup.CurrentDataBaseVersionTextValue + lngRPM.s_ThisProgramWorksOnlyWithDatabase_Version.s + DBSync.DBSync.DB_for_Tangenta.Settings.Version.TextValue + "\r\n"+lngRPM.s_DoYouWantToUpgradeDBToLatestVersion.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    myStartup.bUpgradeDone = m_UpgradeDB.UpgradeDB(myStartup.CurrentDataBaseVersionTextValue, DBSync.DBSync.DB_for_Tangenta.Settings.Version.TextValue, ref Err);
                    return GetDBSettings_And_JOURNAL_DocInvoice_Type(myStartup, ref Err);
                }
                else
                {
                    Err = lngRPM.s_Database_Version_is.s + myStartup.CurrentDataBaseVersionTextValue + "\r\n"+ lngRPM.s_ThisProgramWorksOnlyWithDatabase_Version.s + ":" + DBSync.DBSync.DB_for_Tangenta.Settings.Version.TextValue;
                    myStartup.eNextStep = startup_step.eStep.Cancel;
                    return false;
                }
            }
        }

        private bool GetMissingDBSettings(string name)
        {
            MessageBox.Show(this, lngRPM.s_No_DB_Settings_for.s + " " + name);
            NavigationButtons.Navigation nav_FormDBSettings = new Navigation();
            nav_FormDBSettings.bDoModal = true;
            nav_FormDBSettings.m_eButtons = Navigation.eButtons.OkCancel;
            nav_FormDBSettings.eExitResult = Navigation.eEvent.NOTHING;
            repeat_Form_DBSettings:
            nav_FormDBSettings.ChildDialog = new Form_DBSettings(nav_FormDBSettings, Program.AdministratorLockedPassword, Program.MultiuserOperationWithLogin, Program.StockCheckAtStartup);
            nav_FormDBSettings.ShowDialog();
            if (nav_FormDBSettings.eExitResult == Navigation.eEvent.OK)
            {
                Program.AdministratorLockedPassword = ((Form_DBSettings)nav_FormDBSettings.ChildDialog).AdministratorLockedPassword;
                Program.MultiuserOperationWithLogin = ((Form_DBSettings)nav_FormDBSettings.ChildDialog).MultiuserOperationWithLogin;
                Program.StockCheckAtStartup = ((Form_DBSettings)nav_FormDBSettings.ChildDialog).StockCheckAtStartup;
                return true;
            }
            else
            {
                if (MessageBox.Show(this, lngRPM.s_WithoutDatabaseSettingsProgramCanNotRun_ExitOKOrCancel.s, "?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    goto repeat_Form_DBSettings;
                }
                else
                {
                    return false;
                }
            }
        }

        internal bool InsertSampleData(startup myStartup, NavigationButtons.Navigation xnav, ref string Err)
        {
        do_CheckInsertSampleData:
            if (!xnav.LastStartupDialog_TYPE.Equals("Tangenta.Form_Select_DefaultCurrency"))
            {
                myStartup.bInsertSampleData = CheckInsertSampleData(myStartup, xnav);
                if (xnav.eExitResult == NavigationButtons.Navigation.eEvent.PREV)
                {
                    myStartup.eNextStep = startup_step.eStep.Check_DataBase; //go back
                    return true;
                }
                else if (xnav.eExitResult == NavigationButtons.Navigation.eEvent.EXIT)
                {
                    myStartup.bCanceled = true;
                    myStartup.eNextStep = startup_step.eStep.Cancel;
                    return false;
                }
            }

            if (myStartup.bInsertSampleData)
            {
                bool bCanceled = false;
                if (TangentaSampleDB.TangentaSampleDB.Init_Sample_DB(ref bCanceled, myStartup.sbd, xnav, Properties.Resources.Tangenta_Icon, ref Err))
                {
                    if (xnav.eExitResult == NavigationButtons.Navigation.eEvent.PREV)
                    {
                        if (xnav.LastStartupDialog_TYPE.Equals("Country_ISO_3166.Form_Select_Country_ISO_3166"))
                        {
                            goto do_CheckInsertSampleData;
                        }
                        myStartup.sbd.DeleteAll();
                        myStartup.eNextStep--; //go back 
                        return true;
                    }
                    if (xnav.eExitResult == NavigationButtons.Navigation.eEvent.PREV)
                    {
                        bCanceled = true;
                        myStartup.bCanceled = bCanceled;
                    }
                    if (bCanceled)
                    {
                        myStartup.eNextStep = startup_step.eStep.Cancel;
                    }
                    else
                    {
                        myStartup.eNextStep = startup_step.eStep.GetOrganisationData;
                        return GlobalData.Type_definitions_Read();
                    }
                    return true;
                }
                else
                {
                    myStartup.bCanceled = bCanceled;
                    if (bCanceled)
                    {
                        myStartup.eNextStep = startup_step.eStep.Cancel;
                        return false;
                    }
                    else
                    {
                        LogFile.Error.Show(Err);
                        myStartup.eNextStep = startup_step.eStep.Cancel;
                        return false;
                    }
                }
            }
            else
            {
                if (fs.Init_Default_DB(ref Err))
                {
                    if (GlobalData.Type_definitions_Read())
                    {
                        myStartup.eNextStep++;
                        return true;
                    }
                    else
                    {
                        myStartup.eNextStep = startup_step.eStep.Cancel;
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show(Err);
                    myStartup.eNextStep = startup_step.eStep.Cancel;
                    return false;
                }
            }
        }

        internal bool CheckDBVersion(startup myStartup, object oData,NavigationButtons.Navigation xnav, ref string Err)
        {
            bool bResult = false;
            switch (myStartup.eGetDBSettings_Result)
            {

                case fs.enum_GetDBSettings.DBSettings_OK:
                    bResult = CheckDataBaseVersion(myStartup, ref Err);
                    if (bResult)
                    {
                        if (Program.bFirstTimeInstallation)
                        {
                            bResult = InsertSampleData(myStartup, xnav, ref Err);
                            if (xnav.eExitResult == Navigation.eEvent.PREV)
                            {
                                goto do_Form_DBSettings;
                            }
                        }
                    }
                    return bResult;

                case fs.enum_GetDBSettings.No_Data_Rows:
                    //No CheckDataBaseVersion is needed because Database was allready created and its version has not been written to DBSettings table
 do_Form_DBSettings:

                    xnav.ChildDialog = new Form_DBSettings(xnav, Program.AdministratorLockedPassword, Program.MultiuserOperationWithLogin, Program.StockCheckAtStartup);
                    xnav.ShowDialog();
                    Program.AdministratorLockedPassword = ((Form_DBSettings)xnav.ChildDialog).AdministratorLockedPassword;
                    Program.MultiuserOperationWithLogin = ((Form_DBSettings)xnav.ChildDialog).MultiuserOperationWithLogin;
                    Program.StockCheckAtStartup = ((Form_DBSettings)xnav.ChildDialog).StockCheckAtStartup;
                    switch (xnav.eExitResult)
                    {
                        case Navigation.eEvent.NEXT:
                            bResult = InsertSampleData(myStartup, xnav, ref Err);
                            if (xnav.eExitResult == Navigation.eEvent.PREV)
                            {
                                if (xnav.LastStartupDialog_TYPE.Equals("Tangenta.Form_CheckInsertSampleData"))
                                {
                                    goto do_Form_DBSettings;
                                }
                            }
                            return bResult;

                        case Navigation.eEvent.PREV:
                            myStartup.eNextStep = startup_step.eStep.Check_DataBase;
                            return true;

                        case Navigation.eEvent.EXIT:
                            myStartup.eNextStep = startup_step.eStep.Cancel;
                            return false;
                    }


                    bResult = InsertSampleData(myStartup, xnav, ref Err);
                    return bResult;

                case fs.enum_GetDBSettings.Error_Load_DBSettings:
                    LogFile.Error.Show(Err);
                    myStartup.eNextStep = startup_step.eStep.Cancel;
                    return false;

                case fs.enum_GetDBSettings.No_TextValue:
                    myStartup.eNextStep = startup_step.eStep.Cancel;
                    return false;

                case fs.enum_GetDBSettings.No_ReadOnly:
                    Err = "ERROR enum_GetDBSettings return No_ReadOnly!";
                    LogFile.Error.Show(Err);
                    myStartup.eNextStep = startup_step.eStep.Cancel;
                    return false;

                default:
                    Err = "ERROR enum_GetDBSettings not handled!";
                    LogFile.Error.Show(Err);
                    myStartup.eNextStep = startup_step.eStep.Cancel;
                    return false;

            }

            myStartup.eNextStep = startup_step.eStep.Cancel;
            return false;
        }

    public bool GetWorkPeriod(startup myStartup,object oData, NavigationButtons.Navigation xnav, ref string Err)
    {
        if (GlobalData.GetWorkPeriod(f_Atom_WorkPeriod.sWorkPeriod, "Šiht",Properties.Settings.Default.ElectronicDevice_ID,null, DateTime.Now, null, ref Err))
        {
                myStartup.eNextStep++;
            return true;
        }
        else
        {
            LogFile.Error.Show("ERROR:usrc_Main:GlobalData.GetWorkPeriod:Err=" + Err);
                myStartup.eNextStep = Startup.startup_step.eStep.Cancel;
            return false;
        }
    }


    private void btn_Exit_Click(object sender, EventArgs e)
        {
            if (Exit_Click!=null)
            {
                Exit_Click();
            }
        }


        public long myOrganisation_Person_ID {
            get
            {
                if (this.m_usrc_InvoiceMan != null)
                {
                    return this.m_usrc_InvoiceMan.myOrganisation_Person_ID;
                }
                else
                {
                    return -1;
                }
            }
        }


        private void btn_Settings_Click(object sender, EventArgs e)
        {
            NavigationButtons.Navigation nav_Form_ProgramSettings = new NavigationButtons.Navigation();
            nav_Form_ProgramSettings.bDoModal = true;
            nav_Form_ProgramSettings.m_eButtons = NavigationButtons.Navigation.eButtons.OkCancel;
            Form_ProgramSettings edt_Form = new Form_ProgramSettings(this, nav_Form_ProgramSettings);
            edt_Form.ShowDialog();
            edt_Form.Dispose();
        }

        private void btn_Backup_Click(object sender, EventArgs e)
        {
            string BackupFolder = Properties.Settings.Default.BackupFolder;
            string IniFileFolder = Properties.Settings.Default.IniFileFolder;
            string sDBType = Properties.Settings.Default.DBType;
            DBConnectionControl40.DBConnection.eDBType org_eDBType = DBSync.DBSync.m_DBType;
            NavigationButtons.Navigation nav = new NavigationButtons.Navigation();
            nav.btn3_Visible = true;
            nav.btn3_Text = "";
            nav.btn3_Image = Properties.Resources.Exit;

            DBSync.DBSync.DBMan(Main_Form, Program.Reset2FactorySettings.DBConnectionControlXX_EXE, ((Form_Document)Main_Form).m_XmlFileName, IniFileFolder, ref sDBType, ref BackupFolder, nav);
            Properties.Settings.Default.BackupFolder = BackupFolder;
            Properties.Settings.Default.DBType = sDBType;
            Properties.Settings.Default.Save();
        }

        internal void Activate_dgvx_XInvoice_SelectionChanged()
        {
            this.m_usrc_InvoiceMan.Activate_dgvx_XInvoice_SelectionChanged();
        }

        private void btn_CodeTables_Click(object sender, EventArgs e)
        {
            Form_CodeTables fct_dlg = new Form_CodeTables();
            fct_dlg.ShowDialog();
        }

    }
}
