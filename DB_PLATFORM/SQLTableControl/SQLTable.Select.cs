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
using DBConnectionControl40;
using System.Data;
using System.Windows.Forms;

namespace SQLTableControl
{
    partial class SQLTable
    {
        public bool Select(ref StringBuilder SQL_Select, ref StringBuilder SQL_From, ref StringBuilder SQL_Where)
        {
            bool bRet = false;
        //    if (this.DefineView_GroupBox != null)
        //    {
        //        foreach (MyControl control in DefineView_GroupBox.controls)
        //        {
        //            if (control.Control.GetType() == typeof(DefineView_InputControl))
        //            {
        //                if (dvinpctrl.chkBox.Checked)
        //                {


        //                }
        //            }
        //            else
        //            {
        //               MessageBox.Show("ERROR in SQL_Table.Select : wrong MyControl.Control type");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("ERRORn SQL_Table.Select  DefineView_GroupBox-es not created");
        //    }
        //    foreach (Column col in this.Column)
        //    {
        //        if (!col.IsIdentity)
        //        {
        //            if (col.fKey != null)
        //            {
        //                string sKey;

        //                sKey = sParentKeys + "*" + col.fKey.refTable.TableName + ">";
        //                col.fKey.fTable.Create_DefineView_InputControls(this, sKey, ref inpCtrlList, this.DefineView_GroupBox, pForm);
        //            }
        //            else
        //            {
        //                string sImportExportLine;
        //                DefineView_InputControl inpCtrl;
        //                if (col.IsNumber())
        //                {
        //                    sImportExportLine = sParentKeys + col.Name + ",";
        //                    inpCtrl = new DefineView_InputControl(this, col, inpCtrlList, sImportExportLine, true);
        //                    col.DefineView_InputControl = inpCtrl;
        //                }
        //                else
        //                {
        //                    sImportExportLine = sParentKeys + col.Name + ",";
        //                    inpCtrl = new DefineView_InputControl(this, col, inpCtrlList, sImportExportLine, false);
        //                    col.DefineView_InputControl = inpCtrl;
        //                }
        //                MyControl mctrl = new MyControl(inpCtrl);
        //                this.DefineView_GroupBox.controls.Add(mctrl);
        //            }
        //        }
        //    }

            return bRet;
        }
    }
}