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
using LogFile;

namespace SQLTableControl.TableDocking_Form
{
    public partial class SaveView_Form : Form
    {
        private SQLTable m_tbl;
        private DBTableControl m_DBTables;
        private TableDockingFormXml m_TableDockingFormXml;
        System.Windows.Forms.Control.ControlCollection m_ControlCollection;
        private CurViewXml m_CurrentViewXml;
        xml m_xml;
        private CreateView_Form m_CreateView_Form;
        bool m_bLimit;
        int m_iLimitNumber;
        bool m_bOrder_by_id_desc;

        public SaveView_Form(CreateView_Form xCreateView_Form, SQLTable xTbl, TableDockingFormXml xTableDockingFormXml, CurViewXml CurrentViewXml, System.Windows.Forms.Control.ControlCollection cCol, xml myXml, DBTableControl xDBTables,bool bLimit,int iLimitNumber,bool bOrder_by_id_desc)
        {
            m_DBTables = xDBTables;
            m_CreateView_Form = xCreateView_Form;
            this.Icon = SQLTableControl.Properties.Resources.SelectViewIcon;
            m_xml = myXml;
            m_CurrentViewXml = CurrentViewXml;
            m_tbl = xTbl;
            m_TableDockingFormXml = xTableDockingFormXml;
            m_ControlCollection = cCol;
            InitializeComponent();
            this.Text = lngRPM.s_SaveViewForTable.s + m_tbl.lngTableName.s;
            this.btn_Save.Text = lngRPM.s_Save.s;
            this.btn_Cancel.Text = lngRPM.s_Cancel.s;
            this.chkBoxSetAsDefault.Text = lngRPM.s_SelectAsDefaultView.s;
            lnlViewName.Text = lngRPM.s_ViewToSave.s;
            m_bLimit = bLimit;
            m_iLimitNumber = iLimitNumber;
            m_bOrder_by_id_desc = bOrder_by_id_desc;
        }

        private bool SetView(bool bDefaultView,ViewXml xDefaultViewXml)
        {
            //if (!bDefaultView)
            //{
            //    m_CurrentViewXml.State= CurViewXml.ViewXmlState.NEW_VIEW;
            //}

            if (m_ControlCollection.Count > 0)
            {

                if (!m_CurrentViewXml.m_ViewXml.FillColumnXmlList(m_ControlCollection))
                {
                    return false;
                }

                m_CurrentViewXml.m_ViewXml.SQLView = m_tbl.SQLCreateView(ref m_CurrentViewXml.m_ViewXml, m_DBTables, m_bLimit, m_iLimitNumber, m_bOrder_by_id_desc).ToString() + "\n";


                if (bDefaultView)
                {
                    if (m_TableDockingFormXml != null)
                    {
                        if (m_TableDockingFormXml.m_CreateViewFormXml != null)
                        {
                            if (m_TableDockingFormXml.m_CreateViewFormXml.m_DefaultViewXml != null)
                            {
                                if (xDefaultViewXml != null)
                                {
                                    m_TableDockingFormXml.m_CreateViewFormXml.m_DefaultViewXml = xDefaultViewXml;
                                    m_TableDockingFormXml.m_CreateViewFormXml.sDefaultView = xDefaultViewXml.Name;
                                }
                                else
                                {
                                    m_TableDockingFormXml.m_CreateViewFormXml.m_DefaultViewXml = m_CurrentViewXml.m_ViewXml;
                                    m_TableDockingFormXml.m_CreateViewFormXml.sDefaultView = m_CurrentViewXml.m_ViewXml.Name;
                                }
                            }
                        }
                    }
                }

                if (m_CurrentViewXml.State== CurViewXml.ViewXmlState.NEW_VIEW)
                {
                    m_TableDockingFormXml.m_ViewXml.Add(m_CurrentViewXml.m_ViewXml);
                }
                else if ((m_CurrentViewXml.State== CurViewXml.ViewXmlState.DEFAULT_VIEW)||(m_CurrentViewXml.State== CurViewXml.ViewXmlState.EXISTING_VIEW))
                {
                    if (!xDefaultViewXml.FillColumnXmlList(m_ControlCollection))
                    {
                        return false;
                    }
                    xDefaultViewXml.SQLView = m_tbl.SQLCreateView(ref m_CurrentViewXml.m_ViewXml, m_DBTables, m_bLimit, m_iLimitNumber, m_bOrder_by_id_desc).ToString() + "\n";
                }


                if (bDefaultView)
                {
                    m_TableDockingFormXml.m_CreateViewFormXml.m_DefaultViewXml = m_CurrentViewXml.m_ViewXml;
                }

                return true;
            }
            else
            {
                MessageBox.Show(lngRPM.s_CanNotSaveViewWithNoColumn.s, lngRPM.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }



        private void SaveView_Form_Load(object sender, EventArgs e)
        {
            //this.txtViewName.Text = UniqueNames.GetName(m_TableDockingFormXml.m_ViewXml,lngRPM.s_View.s + m_tbl.TableName[ASet.LanguageID]);

            //ViewXml new_ViewXml = CreateNewView();
            //if (new_ViewXml != null)
            //{
            //    new_ViewXml.Name = txtViewName.Text;
            //}
            // Fill List

            txtViewName.Text = m_CurrentViewXml.m_ViewXml.Name;
            if (m_TableDockingFormXml.m_CreateViewFormXml != null)
            {
                foreach (ViewXml xViewXml in m_TableDockingFormXml.m_ViewXml)
                {
                    this.rdblist_Views.Items.Add(xViewXml);
                }
            }

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (this.txtViewName.Text.Length > 0)
            {
                ViewXml xViewXml_ToFind = null;
                if (UniqueNames.AlreadyExistInUniqueConstraintNameList(m_TableDockingFormXml.m_ViewXml, this.txtViewName.Text, ref xViewXml_ToFind))
                {
                    //Error.Show(lngRPM.s_ViewWithName.s + txtViewName.Text + lngRPM.s_AllreadyExistForTable.s + m_tbl.TableName);
                    if (MessageBox.Show(this, lngRPM.s_OverWriteExistingView.s + ":" + this.txtViewName.Text + "?", lngRPM.s_Warning.s, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        Close();
                        return;
                    }
                }
                else
                {
                    m_CurrentViewXml.State= CurViewXml.ViewXmlState.NEW_VIEW; //It is new view and it will be default View
                }

                m_CurrentViewXml.m_ViewXml.Name = this.txtViewName.Text;


                if (SetView(this.chkBoxSetAsDefault.Checked, xViewXml_ToFind))
                {

                    if (m_xml.Save())
                    {
                        MessageBox.Show(lngRPM.s_CurrentViewIsSuccesfulySavedUnderName.s +  m_CurrentViewXml.m_ViewXml.Name,lngRPM.s_Info.s,MessageBoxButtons.OK,MessageBoxIcon.Information);
                        Close();
                        DialogResult = DialogResult.OK;
                        m_CreateView_Form.DynamicCreateControls(m_CurrentViewXml.m_ViewXml);
                    }
                }
            }
            else
            {
                Error.Show(lngRPM.s_YouMustDefineViewNameOrCancel.s);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rdblist_Views_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i= this.rdblist_Views.SelectedIndex;
            if (i>= 0)
            {

                if (rdblist_Views.Items[i].GetType() == typeof(ViewXml))
                {
                    ViewXml xViewXml = (ViewXml)rdblist_Views.Items[i];
                    this.txtViewName.Text = xViewXml.Name;
                }
            }
        }
    }
}
