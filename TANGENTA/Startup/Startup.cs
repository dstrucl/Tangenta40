using LanguageControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThreadProcessor;
using TangentaDB;
using TangentaSampleDB;
using NavigationButtons;
using static Startup.startup_step;

namespace Startup
{
   

    public class startup
        {
        public enum EvaulateStep_RESULT {EXIT,NEXT,PREV,START_GO_PREV, FINISHED_GO_NEXT };

        public SampleDB sbd;
        public NavigationButtons.Navigation nav = null;

        public startup_step.eStep eStep = startup_step.eStep.NoStep;

        public bool bNewDatabaseCreated = false;
        public bool bInsertSampleData = false;
        public bool bUpgradeDone = false;
        public string AdminPassword = null;

        public Form m_parent_form = null;
        public usrc_Startup m_usrc_Startup = null;
        private startup_step[] m_Step = null;

        public startup_step[] Steps
        {
            get {   return m_Step; }

            set {   m_Step = value;
                    if(m_usrc_Startup!=null)
                    {
                        eStep = startup_step.eStep.Check_00_TangentaAbout;
                        m_usrc_Startup.Init();
                    }
                }
        }

 

        public Image m_ImageCancel = null;
        private bool m_bCancel = false;
        public Icon m_FormIconQuestion = null;
        public fs.enum_GetDBSettings eGetDBSettings_Result = fs.enum_GetDBSettings.No_TextValue;
        public string CurrentDataBaseVersionTextValue = null;
        private bool bFirstTimeInstallation = false;

        public bool bCanceled
        {
            get { return m_bCancel; }
            set { m_bCancel = value; }
        }

        public bool Exit { get {
                if ((((int)eStep) < 0))
                {
                    return true;
                }
                if (m_usrc_Startup != null)
                {
                    return (m_usrc_Startup.Exit);
                }
                else
                {
                    return false;
                }
            } }

        public bool CheckUpgrade(ref bool bUpgradeDone, ref string Err)
        {
            bUpgradeDone = false;
            int iversionread = -1;
            int ithisprogramDBversion = -1;
            string dbversionread = CurrentDataBaseVersionTextValue.Replace(".", "");
            string sthisprogramDBversion = TangentaDataBaseDef.MyDataBase_Tangenta.VERSION.Replace(".", "");
            try
            {
                iversionread = Convert.ToInt32(dbversionread);
            }
            catch
            {
                Err= "ERROR:Startup:startup:CheckUpgrade can not convert verison=\""+ dbversionread+"\" to int !";
                return false;
            }
            try
            {
                ithisprogramDBversion = Convert.ToInt32(sthisprogramDBversion);
            }
            catch 
            {
                Err = "ERROR:Startup:startup:CheckUpgrade can not convert verison=\"" + dbversionread + "\" to int !";
                return false;
            }
            if (ithisprogramDBversion < iversionread)
            {
                Err = lng.ThisVersionOfProgramSupportsDBVersion_which_is_less_or_equal.s+":"+ sthisprogramDBversion;
                return false;
            }
            else if (ithisprogramDBversion > iversionread)
            {
                string smsg = lng.s_DataBase.s +" \""+ DBSync.DBSync.DataBase+"\""+  lng.s_DataBase_is_of_version.s + "\"" + CurrentDataBaseVersionTextValue + "\".\r\n" + lng.s_This_program_runs_with_database_version.s + ":\"" + TangentaDataBaseDef.MyDataBase_Tangenta.VERSION + "\".\r\n" +
                lng.s_UpgradeDataBaseToVersion.s + ":\"" + TangentaDataBaseDef.MyDataBase_Tangenta.VERSION + "\" ?\r\n";
                ltext lmsg = new ltext(new string[] { smsg, smsg });
                if (XMessage.Box.Show(true, m_usrc_Startup, lmsg, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    bool bres = m_usrc_Startup.m_UpgradeDB.UpgradeDB(CurrentDataBaseVersionTextValue, TangentaDataBaseDef.MyDataBase_Tangenta.VERSION, ref Err);
                    if (bres)
                    {
                        bUpgradeDone = true;
                    }
                    return bres;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public startup(Form parent_form, NavigationButtons.Navigation xnav, Icon xFormIconQuestion,bool xbFirstTimeInstallation)
        {
            sbd = new SampleDB();
            m_parent_form = parent_form;
            nav = xnav;
            bFirstTimeInstallation = xbFirstTimeInstallation;
            m_usrc_Startup = new usrc_Startup(this);
            nav.web_Help = m_usrc_Startup.usrc_web_Help1;
            m_FormIconQuestion = xFormIconQuestion;
        }


        public bool Startup_01_Do_showform_TangentaLicence(NavigationButtons.Navigation xnav)
        {
            // return  true for step over
            xnav.ShowForm(new Form_LicenseAgreement(xnav), typeof(Form_LicenseAgreement).ToString());
            return true; //
        }


        public bool Startup_00_Do_showform_TangentaAbout( NavigationButtons.Navigation xnav)
        {
            xnav.ShowForm(new Form_Navigate(xnav), typeof(usrc_Startup).ToString());
            return true;
        }

        public void StartExecution()
        {

             m_Step[0].StartExecution();
        }

        
        public bool StartNextStepExecution()
        {
            if (((int)eStep) < m_Step.Length-1)
            {
                if ((int)eStep > 0)
                {
                    nav.btn1_Visible = (m_Step[(int)eStep].undo_procedure != null);
                }
                m_Step[(int)eStep].Remove_DialogClosingNotifier_SomethingReady();
                eStep++;
                m_Step[(int)eStep].StartExecution();
                return true;
            }
            else
            {
                // all steps done
                return false;
            }
        }

        public bool StartPrevStepExecution(ref string Err)
        {
            Err = null;
            m_Step[(int)eStep].Remove_DialogClosingNotifier_SomethingReady();
            for (;;)
            {
                if (((int)eStep) > 0)
                {
                    eStep--;
                    startup_step.Startup_eUndoProcedureResult eres = m_Step[(int)eStep].UndoProcedure(ref Err);
                    switch (eres)
                    {
                        case Startup_eUndoProcedureResult.OK:
                            m_Step[(int)eStep].SetWait();
                            m_Step[(int)eStep].StartExecution();
                            return true;
                        case Startup_eUndoProcedureResult.NO_UNDO:
                            m_Step[(int)eStep].SetUndefined();
                            continue;

                        case Startup_eUndoProcedureResult.ERROR:
                            m_Step[(int)eStep].SetError();
                            return false;

                    }
                }
                else
                {
                    // all steps in PREV direction done
                    return false;
                }
            }
        }

        public void RemoveControl()
        {
            m_parent_form.Controls.Remove(m_usrc_Startup);
            m_usrc_Startup.Dispose();
            m_usrc_Startup = null;
        }

        internal bool CanGoToPrevious(eStep step)
        {
            if (((int)eStep) > 0)
            {
                return m_Step[(int)eStep - 1].undo_procedure != null;
            }
            else
            {
                return true;
            }
        }

        public void ShowNews()
        {
            m_usrc_Startup.ShowNews();
        }
    }
}
