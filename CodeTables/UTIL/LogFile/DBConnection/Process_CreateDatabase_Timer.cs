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
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Data;


namespace LogFile
{
    public class Process_CreateDatabase_Timer
    {
        private CreateDataBase_Form m_CreateDataBase_Form;
    
        public enum Process_CreateDatabase_ENUM {  START,
                                                    CHECK_PERMISSIONS, 
                                                    SHOW_NOT_ENOUGH_PERMISSIONS,
                                                    CREATE_DATABASE,
                                                    STOP_CREATE,
                                                    STOP} ;
        Process_CreateDatabase_ENUM m_step;


    
        public Process_CreateDatabase_Timer(CreateDataBase_Form pForm)
        {
            m_CreateDataBase_Form = pForm;
            m_step  = Process_CreateDatabase_ENUM.START;
        }





        private void ProcessStep()
        {
            switch (m_step)
            {
                case Process_CreateDatabase_ENUM.START:
                    m_CreateDataBase_Form.lbl_Message.Text = " Process : Check permissions... ";
                    m_CreateDataBase_Form.lbl_Message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    m_CreateDataBase_Form.lbl_Message.Visible = true;
                    m_CreateDataBase_Form.Cursor = Cursors.AppStarting;
                    m_step = Process_CreateDatabase_ENUM.CHECK_PERMISSIONS;
                    break;

                case Process_CreateDatabase_ENUM.CHECK_PERMISSIONS:

                    if (m_CreateDataBase_Form.m_con.CheckPermission_ALTER_ANY_DATABASE())
                    {
                        m_step = Process_CreateDatabase_ENUM.CREATE_DATABASE;
                        m_CreateDataBase_Form.m_bPermissionsOK = true;
                    }
                    else
                    {
                        m_step = Process_CreateDatabase_ENUM.SHOW_NOT_ENOUGH_PERMISSIONS;
                        m_CreateDataBase_Form.m_bPermissionsOK = false;
                    }
                    break;

                case Process_CreateDatabase_ENUM.SHOW_NOT_ENOUGH_PERMISSIONS:
                    DataSet ds = new DataSet();
                    m_CreateDataBase_Form.lbl_Message.Text = " User " + m_CreateDataBase_Form.m_con.UserName + " does not have  permission:'ALTER ANY DATABASE'\n All permissions granted to this\n user are listed in nearby table:";
                    m_CreateDataBase_Form.lbl_Message.Left = 10;
                    m_CreateDataBase_Form.lbl_Message.Top = 10;
                    m_CreateDataBase_Form.lbl_Message.Width = (m_CreateDataBase_Form.Size.Width - 20) / 2;
                    m_CreateDataBase_Form.lbl_Message.Height = (m_CreateDataBase_Form.Size.Height - 100);
                    m_CreateDataBase_Form.lbl_Message.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    m_CreateDataBase_Form.lbl_Message.Visible = true;
                    string sql_cmd = @"SELECT permission_name
                                       FROM fn_my_permissions(NULL, 'SERVER');";
                    string csError = "";

                    string saved_DataBaseName = m_CreateDataBase_Form.m_con.DataBase;
                    m_CreateDataBase_Form.m_con.DataBase = "";
                    //m_CreateDataBase_Form.m_con.conData.SetConnectionString();

                    if (m_CreateDataBase_Form.m_con.ReadDataSet(ref ds, sql_cmd, ref csError))
                    {
                        m_CreateDataBase_Form.m_con.DataBase = saved_DataBaseName;
                        //m_CreateDataBase_Form.m_con.conData.SetConnectionString();

                        if (ds.Tables.Count > 0)
                        {
                            m_CreateDataBase_Form.dataGridView_Permissions.DataSource = ds.Tables[0];
                            m_CreateDataBase_Form.dataGridView_Permissions.Update();
                            m_CreateDataBase_Form.dataGridView_Permissions.Visible = true;
                            m_CreateDataBase_Form.dataGridView_Permissions.Left = m_CreateDataBase_Form.lbl_Message.Left + 10 + m_CreateDataBase_Form.lbl_Message.Width;
                            m_CreateDataBase_Form.dataGridView_Permissions.Top = 10;
                            m_CreateDataBase_Form.dataGridView_Permissions.Width = (m_CreateDataBase_Form.Size.Width - 40) / 2 - 30;
                            m_CreateDataBase_Form.dataGridView_Permissions.Height = (m_CreateDataBase_Form.Size.Height - 120);
                            m_CreateDataBase_Form.dataGridView_Permissions.AutoResizeColumns();
                        }
                    }
                    else
                    {
                        m_CreateDataBase_Form.m_con.DataBase = saved_DataBaseName;
                        //m_CreateDataBase_Form.m_con.conData.SetConnectionString();
                    }

                    m_CreateDataBase_Form.btn_CreateDatabase.Visible = false;

                    m_step = Process_CreateDatabase_ENUM.STOP;
                    break;

                case Process_CreateDatabase_ENUM.CREATE_DATABASE:
                    m_CreateDataBase_Form.lbl_Message.Visible = false;
                    m_CreateDataBase_Form.dataGridView_Permissions.Visible = false;
                    m_CreateDataBase_Form.tabControl_CreateDialog.Visible = true;
                    m_CreateDataBase_Form.btn_CreateDatabase.Visible = true;
                    m_step = Process_CreateDatabase_ENUM.STOP_CREATE;
                    break;

                case Process_CreateDatabase_ENUM.STOP_CREATE:
                    break;

                case Process_CreateDatabase_ENUM.STOP:
                    break;
            }
        }

        public Process_CreateDatabase_ENUM Process_CreateDatabase_Timer_Tick()
        {
            ProcessStep();
            return m_step;
        }

    }
}
