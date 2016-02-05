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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using SQLTableControl;
using System.Runtime.InteropServices;
using DBConnectionControl40;


namespace SQLTableControl
{
    public partial class EditTable_Form : Form
    {


        public TableDockingForm m_TableDockingForm;


        public EditTable_Form(DBTableControl dbTables, SQLTable tbl, TableDockingForm dtF,Globals.delegate_SetControls xSetControls, bool bReadOnly)
        {
            m_TableDockingForm = dtF;
            this.Icon = Properties.Resources.SmallEditIcon;
            InitializeComponent();
            this.Text = lngRPM.s_EditTable.s + tbl.lngTableName.s + " (" + tbl.TableName + ")";
            usrc_EditRow.Init(dbTables, tbl, xSetControls, bReadOnly);
        }

        private void EditTable_Form_Load(object sender, EventArgs e)
        {
        }


        private void SetRandom()
        {
        }



        internal void ShowTableRow(long Identity)
        {
            usrc_EditRow.ShowTableRow(Identity);
        }

        private void usrc_EditTable_Update(bool res, long ID,string Err)
        {
            if (res)
            {
                m_TableDockingForm.UpdateForms(ID);
            }
            else
            {
                LogFile.Error.Show(Err);
            }

        }
    }

}
