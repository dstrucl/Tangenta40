﻿#region LICENSE 
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
        public const string XML_ROOT_NAME = "Tangenta_Xml";

        public string RecentItemsFolder = null;
        public startup m_startup = null;
        internal string m_XmlFileName = null;
        public startup_step[] StartupStep = null;
        public Form ChildForm = null;

     
  

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

            int startup_step_index = 0;

            m_startup = new startup(this,
                        Program.nav,
                        Properties.Resources.Tangenta_Question,
                        Program.bFirstTimeInstallation
                        );


            StartupStep = new startup_step[]
            {

                // TANGENTA_About
                CStartup_00_TangentaAbout(),
                
                // TANGENTA_Licence
                CStartup_01_TangentaLicence(),

                // CHECK DATABASE
                CStartup_02_Check_DBType(),
                
                 // CHECK DBConnection
                CStartup_03_Check_DBConnection(),

                // CHECK DBSettings
                CStartup_04_Check_DBSettings(),

                CStartup_05_Check_myOrganisation_Data()


             
             //   new startup_step(lng.s_Startup_Read_DBSettings.s,m_startup, Program.nav,this.m_usrc_Main.m_UpgradeDB.Read_DBSettings_Version,startup_step.eStep.Read_DBSettings_Version,startup_step_index++),

             //   // CHECK DB AND INSERT SAMPLE DATA IF DATABASE EMPTY
             //   new startup_step(lng.s_Startup_CheckDBVersion.s,m_startup, Program.nav,this.m_usrc_Main.CheckDBVersion,startup_step.eStep.CheckDBVersion,startup_step_index++),
             //   // GET ORGANISATION DATA
             //   new startup_step(lng.s_Startup_GetOrganisationData.s,m_startup, Program.nav,this.m_usrc_Main.m_usrc_InvoiceMan.m_usrc_Invoice.GetOrganisationData,startup_step.eStep.GetOrganisationData,startup_step_index++),
             //   // GET BASE CURRENCY
             //   new startup_step(lng.s_Startup_GetBaseCurrency.s,this.m_usrc_Main.m_usrc_InvoiceMan.m_usrc_Invoice.Get_BaseCurrency,startup_step.eStep.GetBaseCurrency,startup_step_index++),
             //   // GET TAXATION
             //   new startup_step(lng.s_Startup_GetTaxation.s,this.m_usrc_Main.m_usrc_InvoiceMan.m_usrc_Invoice.GetTaxation,startup_step.eStep.GetTaxation,startup_step_index++),
             //   // GET SHOPS IN USE
             //   new startup_step(lng.s_Startup_Get_ProgramSettings.s,this.m_usrc_Main.Get_ProgramSettings,startup_step.eStep.Get_ProgramSettings,startup_step_index++),
             //   // GET PROGRAM SETTINGS
             //   new startup_step(lng.s_SetShopsPricelists.s,this.m_usrc_Main.SetShopsPricelists,startup_step.eStep.SetShopsPricelists,startup_step_index++),
             //   // GET SHOPB Item Data
             //   new startup_step(lng.s_Startup_GetSimpleItemData.s,this.m_usrc_Main.m_usrc_InvoiceMan.m_usrc_Invoice.Get_ShopB_ItemData,startup_step.eStep.GetSimpleItemData,startup_step_index++),
             //   // GET SHOPC Item Data
             //   new startup_step(lng.s_Startup_GetItemData.s,this.m_usrc_Main.m_usrc_InvoiceMan.m_usrc_Invoice.Get_ShopC_ItemData,startup_step.eStep.GetItemData,startup_step_index++),
             //   // GET Printer
             //   new startup_step(lng.s_Startup_GetPrinter.s,this.m_usrc_Main.Get_Printer,startup_step.eStep.GetPrinter,startup_step_index++),
             //   // LOGIN
             //   new startup_step(lng.s_Startup_Login.s,this.m_usrc_Main.GetWorkPeriod,startup_step.eStep.GetWorkPeriod,startup_step_index++),
            };

            m_startup.Steps = StartupStep;
            m_startup.m_usrc_Startup.ExitProgram += M_usrc_Startup_ExitProgram;
            m_startup.m_usrc_Startup.StartupFormClosing += M_usrc_Startup_StartupFormClosing;
            //this.usr
            //int iStep = 0;
            //int iCountStep1 = m_startup.Step.Count();
            //for (iStep = 0; iStep < iCountStep1; iStep++)
            //{
            //    usrc_startup_step xusrc_startup_step = new usrc_startup_step(m_startup.Step[iStep]);
            //    xusrc_startup_step.Left = lbl_StartUp.Left;
            //    xusrc_startup_step.Top = lbl_StartUp.Bottom + Y_DIST + iStep * (xusrc_startup_step.Height + Y_DIST);
            //    if (xusrc_startup_step_Width < xusrc_startup_step.Width) { }
            //    {
            //        xusrc_startup_step_Width = xusrc_startup_step.Width;
            //    }
            //    this.Controls.Add(xusrc_startup_step);
            //}

            Program.nav.oStartup = m_startup;
        }

        private void M_usrc_Startup_StartupFormClosing(object sender)
        {
            startup_step.Startup_check_proc_Result eres = Startup_check_proc_Result.CHECK_NONE;
            if (sender is usrc_startup_step)
            {
                usrc_startup_step xusrc_startup_step = (usrc_startup_step)sender;
                if (xusrc_startup_step.bDoStepAgain)
                {
                    xusrc_startup_step.bDoStepAgain = false;
                    this.m_startup.StartCurrentStepExecution();
                }
                else
                {
                    switch (xusrc_startup_step.startup_step.nav.eExitResult)
                    {
                        case NavigationButtons.Navigation.eEvent.NEXT:
                            xusrc_startup_step.startup_step.DoOnFormClosing();
                            break;
                            //if (xusrc_startup_step.startup_step.nav.ChildDialog is Form_Select_Country_ISO_3166)
                            //{
                            //    Form_Select_Country_ISO_3166 frm_Select_Country_ISO_3166 = (Form_Select_Country_ISO_3166)xusrc_startup_step.startup_step.nav.ChildDialog;
                            //    this.m_startup.sbd.Startup_05_Form_Select_Country_ISO_3116_result(frm_Select_Country_ISO_3166);
                            //    this.m_startup.StartCurrentStepExecution_ShowForm(Startup_check_proc_Result.WAIT_USER_INTERACTION_1);

                            //}
                            //else if (xusrc_startup_step.startup_step.nav.ChildDialog is Form_CheckInsertSampleData)
                            //{
                            //    Form_CheckInsertSampleData frm_CheckInsertSampleData = (Form_CheckInsertSampleData)xusrc_startup_step.startup_step.nav.ChildDialog;
                            //    if (frm_CheckInsertSampleData.WritePredefinedDefaultDataInDataBase)
                            //    {
                            //        this.m_startup.StartCurrentStepExecution_ShowForm(Startup_check_proc_Result.WAIT_USER_INTERACTION_2);
                            //    }
                            //    else
                            //    {
                            //        this.m_startup.StartCurrentStepExecution_ShowForm(Startup_check_proc_Result.WAIT_USER_INTERACTION_3);
                            //    }
                            //}
                            //else if (xusrc_startup_step.startup_step.nav.ChildDialog is Form_EditMyOrgSampleData)
                            //{
                            //    this.m_startup.sbd.WriteMyOrg();
                            //    eres = this.m_startup.StartCurrentStepExecution();
                            //    switch (eres)
                            //    {
                            //        case Startup_check_proc_Result.CHECK_OK:
                            //            this.m_startup.StartNextStepExecution();
                            //            return;
                            //    }
                            //}
                            //else if (xusrc_startup_step.startup_step.nav.ChildDialog is Form_myOrg_Edit)
                            //{
                            //    eres = this.m_startup.StartCurrentStepExecution();
                            //    switch (eres)
                            //    {
                            //        case Startup_check_proc_Result.CHECK_OK:
                            //            this.m_startup.StartNextStepExecution();
                            //            return;
                            //    }
                            //}
                            //else if (xusrc_startup_step.startup_step.nav.ChildDialog is Form_myOrg_Office_Data)
                            //{
                            //    eres = this.m_startup.StartCurrentStepExecution();
                            //    switch (eres)
                            //    {
                            //        case Startup_check_proc_Result.CHECK_OK:
                            //            this.m_startup.StartNextStepExecution();
                            //            return;
                            //    }
                            //}
                            //else if (xusrc_startup_step.startup_step.nav.ChildDialog is Form_myOrg_Office_Data_FVI_SLO_RealEstateBP)
                            //{
                            //     eres = this.m_startup.StartCurrentStepExecution();
                            //     switch (eres)
                            //    {
                            //        case Startup_check_proc_Result.CHECK_OK:
                            //            this.m_startup.StartNextStepExecution();
                            //            return;
                            //    }
                            //}
                            //else
                            //{
                            //    this.m_startup.StartNextStepExecution();
                            //}
                            break;

                        case NavigationButtons.Navigation.eEvent.PREV:
                            this.m_startup.CurrentStepExecutionSetUndefined();
                            if (this.m_startup.StartPrevStepExecution())
                            {
                                return;
                            }
                            else
                            {
                                M_usrc_Startup_ExitProgram();
                            }
                            break;

                        case NavigationButtons.Navigation.eEvent.NOTHING:
                            if (xusrc_startup_step.bNO_FORM_BUT_CHECK_OK)
                            {
                                this.m_startup.StartNextStepExecution();
                            }
                            else
                            {
                                if (xusrc_startup_step.startup_step.nav.ChildDialog is DBConnectionControl40.TestConnectionForm)
                                {
                                    DBConnectionControl40.TestConnectionForm frm_TestConnectionForm = (DBConnectionControl40.TestConnectionForm)xusrc_startup_step.startup_step.nav.ChildDialog;
                                    if (frm_TestConnectionForm.Result)
                                    {
                                        this.m_startup.StartNextStepExecution();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("ERROR:Startup:usrc_Startup:Xusrc_startup_step_StartupFormClosing:  case NavigationButtons.Navigation.eEvent.NOTHING: and (xusrc_startup_step.bNO_FORM_BUT_CHECK_OK == false not implemented!");
                                    M_usrc_Startup_ExitProgram();
                                }
                            }
                            break;

                        case NavigationButtons.Navigation.eEvent.EXIT:

                            this.m_startup.m_usrc_Startup.m_Exit = true;
                            M_usrc_Startup_ExitProgram();
                            break;

                    }
                }
            }
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
            if ((Program.nav.eExitResult == NavigationButtons.Navigation.eEvent.PREV) && (Program.bFirstTimeInstallation))
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
            string Err = null;

            LogFile.LogFile.WriteDEBUG("** Form_Document:Form_Document_Shown():before m_startup.Execute!");

            m_startup.StartExecution();

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
