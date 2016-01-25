using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLTableControl;
using LanguageControl;
using BlagajnaTableClass;
using InvoiceDB;

namespace Tangenta
{
    public partial class usrc_Main : UserControl
    {
        Form Main_Form = null;
        public delegate void delegate_Exit_Click();
        public event delegate_Exit_Click Exit_Click;

       

        public usrc_Main()
        {
            InitializeComponent();
            Program.usrc_FVI_SLO1 = this.usrc_FVI_SLO1;
            Program.usrc_Printer1 = this.usrc_Printer1;
        }

        internal bool Init(Form main_Form)
        {
            Main_Form = main_Form;
            bool bUpgradeDone = false;
            if (m_usrc_DBSettings.Read_DBSettings(ref bUpgradeDone))
            {
                if (Program.Get_JOURNAL_Types_ID())
                {
                    string Err = null;
                    if (GlobalData.GetWorkPeriod(f_Atom_WorkPeriod.sWorkPeriod, "Šiht", DateTime.Now, null,ref Err))
                    {
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
                                if (!this.usrc_FVI_SLO1.Start(ref Err))
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
                    else
                    {
                        if (Program.bStartup && Err == null)
                        {

                            XMessage.Box.Show(Program.MainForm, lngRPM.s_No_CompanyData, "!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1);
                            DialogResult dres = DialogResult.Ignore;
                            if (Program.b_FVI_SLO)
                            {
                                Form_MyCompany_Person_Data_Edit edt_my_company_person_dlg = new Form_MyCompany_Person_Data_Edit(DBSync.DBSync.DB_for_Blagajna.m_DBTables, new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(FVI_SLO_RealEstateBP))));
                                dres = edt_my_company_person_dlg.ShowDialog();
                            }
                            else
                            {
                                Form_MyCompany_Person_Data_Edit edt_my_company_person_dlg = new Form_MyCompany_Person_Data_Edit(DBSync.DBSync.DB_for_Blagajna.m_DBTables, new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(myCompany_Person))));
                                dres = edt_my_company_person_dlg.ShowDialog();
                            }
                            if (dres == DialogResult.OK)
                            {
                                if (GlobalData.GetWorkPeriod(f_Atom_WorkPeriod.sWorkPeriod, "Šiht", DateTime.Now, null, ref Err))
                                {
                                    if (Program.b_FVI_SLO)
                                    {
                                        if (f_Atom_FVI_SLO_RealEstateBP.Get_Atom_FVI_SLO_RealEstateBP_ID(Main_Form, ref Program.Atom_FVI_SLO_RealEstateBP_ID,1))
                                        {
                                        }
                                    }
                                    if (this.m_usrc_InvoiceMan.Init(main_Form))
                                    {
                                        if (Program.b_FVI_SLO)
                                        {
                                            if (!this.usrc_FVI_SLO1.Start(ref Err))
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
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }

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
                return false;
            }
        }


        private void btn_Edit_Click(object sender, EventArgs e)
        {
           
        }


        private void m_usrc_DBSettings_Backup()
        {
            string BackupFolder = Properties.Settings.Default.BackupFolder;
            string IniFileFolder = Properties.Settings.Default.IniFileFolder;
            string sDBType = Properties.Settings.Default.DBType;
            DBConnectionControl40.DBConnection.eDBType org_eDBType = DBSync.DBSync.m_DBType;
            DBSync.DBSync.DBMan(Main_Form, ((Form_Main)Main_Form).m_XmlFileName, IniFileFolder, ref sDBType, ref BackupFolder);
            Properties.Settings.Default.BackupFolder = BackupFolder;
            Properties.Settings.Default.DBType = sDBType;
            Properties.Settings.Default.Save();
            Init(Main_Form);
        }


        private void m_usrc_DBSettings_Settings_Click()
        {
            Form_Settings edt_Form = new Form_Settings(this);
            edt_Form.ShowDialog();
            edt_Form.Dispose();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            if (Exit_Click!=null)
            {
                Exit_Click();
            }
        }


        public long myCompany_Person_ID {
            get
            {
                if (this.m_usrc_InvoiceMan != null)
                {
                    return this.m_usrc_InvoiceMan.myCompany_Person_ID;
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
    }
}
