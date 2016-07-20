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

namespace Tangenta
{
    public partial class usrc_Document : UserControl
    {
        Form Main_Form = null;
        public delegate void delegate_Exit_Click();
        public event delegate_Exit_Click Exit_Click;
        public UpgradeDB_inThread m_UpgradeDB = null;


        public usrc_Document()
        {
            InitializeComponent();
            Program.usrc_Printer1 = this.usrc_Printer1;
            m_UpgradeDB = new UpgradeDB_inThread(this);
        }

        public bool Get_shops_in_use(startup myStartup,object oData, ref string Err)
        {
            if (Get_shops_in_use(false))
            {
                myStartup.eNextStep++;
            }
            else
            {
                myStartup.eNextStep = Startup.startup_step.eStep.Cancel;
            }
            return true;
        }


        public bool Get_shops_in_use(bool bResetShopsInUse)
        {
            if (Program.Shops_in_use.Length>0)
            {
                return true;
            }
            else
            { 
                Form_ShopsInUse frm_shops_in_use = new Form_ShopsInUse(bResetShopsInUse,this);
                DialogResult dlgres = frm_shops_in_use.ShowDialog(this);
                return (dlgres == DialogResult.OK);
            }
        }

        internal bool Initialise(Form main_Form)
        {
            Main_Form = main_Form;
            return  this.m_usrc_InvoiceMan.Initialise(Main_Form);
        }


        internal bool Init()
        {
            string Err = null;
            if (Program.b_FVI_SLO)
            {
                Program.usrc_FVI_SLO1 = this.usrc_FVI_SLO1;
                Program.usrc_FVI_SLO1.FursD_ElectronicDeviceID = Properties.Settings.Default.ElectronicDevice_ID;
                if (Program.bReset2FactorySettings)
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

            

            if (this.m_usrc_InvoiceMan.Init())
            {
                if (Program.b_FVI_SLO)
                {
                    if (this.usrc_FVI_SLO1.Start(ref Err))
                    {
                        if (Program.b_FVI_SLO)
                        {
                            Program.usrc_FVI_SLO1.Check_SalesBookInvoice(this.m_usrc_InvoiceMan.m_usrc_Invoice.m_ShopABC);
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

        private bool CheckInsertSampleData(startup myStartup)
        {
            //if (MessageBox.Show(m_parent_ctrl, lngRPM.s_DataBaseIsEmpty_InsertInitialData.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            Form_CheckInsertSampleData frmdlg = new Form_CheckInsertSampleData(myStartup);
            frmdlg.ShowDialog();
            return myStartup.bInsertSampleData;
        }

        internal bool CheckDBVersion_2(startup myStartup, object oData, ref string Err)
        {
            if (GlobalData.JOURNAL_DocInvoice_Type_definitions.Read())
            {
                //if (Read_DBSettings_LastInvoiceType(bUpgradeDone, ref Err))
                //{
                //    if (fs.Read_DBSettings_StockCheckAtStartup(bUpgradeDone, ref Err))
                //    {
                //        if (f_JOURNAL_Stock.Get_JOURNAL_Stock_Type_ID())
                //        {
                //            switch (myStartup.eGetDBSettings_Result)
                //            {
                //                case fs.enum_GetDBSettings.No_Data_Rows:
                //                    myStartup.eNextStep++;
                //                    return true;
                //            }
                //            myStartup.eNextStep++;
                //            return true;
                //        }
                //    }
                //}
            }
            myStartup.eNextStep = startup_step.eStep.Cancel;
            return false;
        }


        internal bool CheckDBVersion(startup myStartup, object oData, ref string Err)
        {
            switch (myStartup.eGetDBSettings_Result)
            {

                case fs.enum_GetDBSettings.DBSettings_OK:
                    if (myStartup.CurrentDataBaseVersionTextValue.Equals(DBSync.DBSync.DB_for_Tangenta.Settings.Version.TextValue))
                    {
                        myStartup.eNextStep++;
                        return true;
                    }
                    else
                    {
                        if (MessageBox.Show(this.Main_Form, lngRPM.s_Database_Version_is.s + myStartup.CurrentDataBaseVersionTextValue + lngRPM.s_ThisProgramWorksOnlyWithDatabase_Version.s + DBSync.DBSync.DB_for_Tangenta.Settings.Version.TextValue + "\r\nNadgradim podatkovno bazo na novo verzijo?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            myStartup.bUpgradeDone = m_UpgradeDB.UpgradeDB(myStartup.CurrentDataBaseVersionTextValue, DBSync.DBSync.DB_for_Tangenta.Settings.Version.TextValue, ref Err);
                            myStartup.eNextStep++;
                            return true;
                        }
                        else
                        {
                            Err = "Podatkovna baza je verzije:" + myStartup.CurrentDataBaseVersionTextValue + "\r\nTa program dela lahko dela le z verzijo podatkovne baze:" + DBSync.DBSync.DB_for_Tangenta.Settings.Version.TextValue;
                            myStartup.eNextStep = startup_step.eStep.Cancel;
                            return false;
                        }
                    }


                case fs.enum_GetDBSettings.Error_Load_DBSettings:
                    LogFile.Error.Show(Err);
                    myStartup.eNextStep = startup_step.eStep.Cancel;
                    return false;



                case fs.enum_GetDBSettings.No_Data_Rows:
                    myStartup.bInsertSampleData = CheckInsertSampleData(myStartup);
                    if (myStartup.bInsertSampleData)
                    {
                        myStartup.SetSampleData();
                        bool bCanceled = false;
                        if (TangentaSampleDB.TangentaSampleDB.Init_Sample_DB(ref bCanceled, myStartup.m_ImageCancel, ref Err))
                        {
                            myStartup.bCanceled = bCanceled;
                            if (bCanceled)
                            {
                                myStartup.eNextStep = startup_step.eStep.Cancel;
                            }
                            else
                            {
                                myStartup.eNextStep++;
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
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show(Err);
                            myStartup.eNextStep = startup_step.eStep.Cancel;
                            return false;
                        }
                    }

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

            //{
            //    if (bCanceled)
            //    {
            //        myStartup.eNextStep = startup_step.eStep.Cancel;
            //        return false;
            //    }
            //    if (GlobalData.JOURNAL_DocInvoice_Type_definitions.Read())
            //    {
            //        if (Read_DBSettings_LastInvoiceType(bUpgradeDone, ref bCanceled, myStartup.m_ImageCancel, ref Err))
            //        {
            //            if (bCanceled)
            //            {
            //                myStartup.eNextStep = startup_step.eStep.Cancel;
            //                return false;
            //            }
            //            if (fs.Read_DBSettings_StockCheckAtStartup(bUpgradeDone, ref Err))
            //            {
            //                if (f_JOURNAL_Stock.Get_JOURNAL_Stock_Type_ID())
            //                {
            //                    switch (eGetDBSettings_Result)
            //                    {
            //                        case fs.enum_GetDBSettings.No_Data_Rows:
            //                            myStartup.eNextStep++;
            //                            return true;
            //                    }
            //                    myStartup.eNextStep++;
            //                    return true;
            //                }
            //            }
            //        }
            //    }
            //}
            myStartup.eNextStep = startup_step.eStep.Cancel;
            return false;
        }

    public bool GetWorkPeriod(startup myStartup,object oData, ref string Err)
    {
        if (GlobalData.GetWorkPeriod(f_Atom_WorkPeriod.sWorkPeriod, "Šiht", DateTime.Now, null, ref Err))
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

        private void usrc_Printer1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
            Form_Settings edt_Form = new Form_Settings(this);
            edt_Form.ShowDialog();
            edt_Form.Dispose();
        }

        private void btn_Backup_Click(object sender, EventArgs e)
        {
            string BackupFolder = Properties.Settings.Default.BackupFolder;
            string IniFileFolder = Properties.Settings.Default.IniFileFolder;
            string sDBType = Properties.Settings.Default.DBType;
            DBConnectionControl40.DBConnection.eDBType org_eDBType = DBSync.DBSync.m_DBType;
            DBSync.DBSync.DBMan(Main_Form, Program.bReset2FactorySettings, ((Form_Document)Main_Form).m_XmlFileName, IniFileFolder, ref sDBType, ref BackupFolder,Properties.Resources.Exit);
            Properties.Settings.Default.BackupFolder = BackupFolder;
            Properties.Settings.Default.DBType = sDBType;
            Properties.Settings.Default.Save();
        }
    }
}
