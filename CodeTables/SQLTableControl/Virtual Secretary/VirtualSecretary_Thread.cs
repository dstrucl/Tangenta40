#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using LanguageControl;
using LogFile;

namespace CodeTables
{
     public class VirtualSecretary_ThreadParam
    {
        public int iHandleToControl; //Form m_pForm;
        public SQLTable m_tbl;

        public VirtualSecretary_ThreadParam(SQLTable m_tbl, Control pControl)
        {
            iHandleToControl = pControl.Handle.ToInt32();
        }
    }

    public class VirtualSecretary_Thread
    {
        public Mutex mutex_VirtualSecretary = new Mutex(false);

        public Thread VirtualSecretaryThread = null;

        public void VirtualSecretaryJob(Object data)
        {
            VirtualSecretary_ThreadParam scp = (VirtualSecretary_ThreadParam) data;
            VirtualSecretary_Form VirtualSecretaryDlg = new VirtualSecretary_Form(scp.m_tbl, scp.iHandleToControl);
            VirtualSecretaryDlg.ShowDialog();
        }

        public bool StartThread(SQLTable tbl,Control pControl)
        {
            VirtualSecretaryThread = new Thread(VirtualSecretaryJob);
            VirtualSecretary_ThreadParam scp = new VirtualSecretary_ThreadParam(tbl, pControl);
            VirtualSecretaryThread.Start(scp);
            return true;
        }

    }
}
