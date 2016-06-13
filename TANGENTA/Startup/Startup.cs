using LanguageControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThreadProcessor;

namespace Startup
{
   

    public class startup
        {
        private Control m_parent_ctrl = null;
        internal startup_step[] Step_ResetNew = null;
        private startup_step[] Step_ProgramInstalled;


        public startup(Control xparent_ctrl, startup_step[] xStep_ResetNew, startup_step[] xStep_ProgramInstalled)
        {
            m_parent_ctrl = xparent_ctrl;
            Step_ResetNew = xStep_ResetNew;
            Step_ProgramInstalled = xStep_ProgramInstalled;
        }

        public object Startup_ShowHelp(object o,ref string Err)
        {
            return false;
        }
        //public bool UpgradeDB(string sOldDBVersion, string sNewDBVersion, ref string Err, string xBackupFileName)
        //{
        //    int i = 0;
        //    int iCount = UpgradeArray.Length;
        //    for (i = 0; i < iCount; i++)
        //    {
        //        if (UpgradeArray[i].DBVersion.Equals(sOldDBVersion))
        //        {
        //            int j = i;
        //            Form_Upgrade_inThread frm_upgr = new Form_Upgrade_inThread(this, UpgradeArray, j, xBackupFileName);
        //            frm_upgr.ShowDialog();
        //        }
        //    }
        //    return true;
        //}
    }
}
