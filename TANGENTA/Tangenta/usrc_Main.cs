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

namespace Tangenta
{
    public partial class usrc_Main : UserControl
    {
        Form Main_Form = null;
        public delegate void delegate_Exit_Click();
        public event delegate_Exit_Click Exit_Click;
        public UpgradeDB_inThread m_UpgradeDB = null;


        public usrc_Main()
        {
            InitializeComponent();
            Program.usrc_Printer1 = this.usrc_Printer1;
            m_UpgradeDB = new UpgradeDB_inThread(this);
        }

        public bool Get_shops_in_use(object oData, ref string Err, ref Startup.startup_step.eStep eNextStep)
        {
            if (Get_shops_in_use(false))
            {
                eNextStep++;
            }
            else
            {
                eNextStep = Startup.startup_step.eStep.End;
            }
            return true;
        }


        public bool Get_shops_in_use(bool bResetShopsInUse)
        {
            Form_ShopsInUse frm_shops_in_use = new Form_ShopsInUse(bResetShopsInUse,this);
            DialogResult dlgres = frm_shops_in_use.ShowDialog(this);
            return (dlgres == DialogResult.OK);
        }


        internal bool Init(Form main_Form)
        {
            Main_Form = main_Form;
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

            

            if (this.m_usrc_InvoiceMan.Init(main_Form))
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

    public bool GetWorkPeriod(object oData, ref string Err, ref Startup.startup_step.eStep eNextStep)
    {
        if (GlobalData.GetWorkPeriod(f_Atom_WorkPeriod.sWorkPeriod, "Šiht", DateTime.Now, null, ref Err))
        {
            eNextStep++;
            return true;
        }
        else
        {
            LogFile.Error.Show("ERROR:usrc_Main:GlobalData.GetWorkPeriod:Err=" + Err);
            eNextStep = Startup.startup_step.eStep.End;
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
            DBSync.DBSync.DBMan(Main_Form, Program.bReset2FactorySettings, ((Form_Main)Main_Form).m_XmlFileName, IniFileFolder, ref sDBType, ref BackupFolder);
            Properties.Settings.Default.BackupFolder = BackupFolder;
            Properties.Settings.Default.DBType = sDBType;
            Properties.Settings.Default.Save();
        }
    }
}
