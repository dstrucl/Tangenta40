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
using System.Runtime.InteropServices;
using CodeTables;


namespace CodeTables.TableDocking_Form
{
    public partial class SelectView_Form : Form
    {
         public  enum FormMode {SELECT,DELETE};

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);
 //       public static extern bool PostMessage(int hhwnd, uint msg, IntPtr wparam, IntPtr lparam);

        private Form m_ParentForm;

        private SQLTable m_tbl;
        private TableDockingFormXml m_TableDockingFormXml;
        private ViewXml m_CurrentViewXml;

        public ViewXml m_ViewXml_Selected = null;
        public bool bDefaultView = false;
        xml m_xml;
        private FormMode m_mode;

        public SelectView_Form(Form xParentForm, SQLTable xTbl, TableDockingFormXml xTableDockingFormXml, ViewXml CurrentViewXml, xml myXml,FormMode mode)
        {
            m_mode = mode;
            m_ParentForm = xParentForm;
            this.Owner = xParentForm;
            this.Icon = CodeTables.Properties.Resources.SelectViewIcon;
            m_xml = myXml;
            m_CurrentViewXml = CurrentViewXml;
            m_tbl = xTbl;
            m_TableDockingFormXml = xTableDockingFormXml;
            InitializeComponent();
           
            if (m_mode == FormMode.SELECT)
            {
                this.Text = lng.s_SelectViewForTable.s + m_tbl.lngTableName.s;
                chkBoxSetAsDefault.Visible = true;
                this.btn_Select.Text = lng.s_Select.s;
                this.btn_Cancel.Text = lng.s_Cancel.s;
            }
            else
            {
                this.Text = lng.s_DeleteViewForTable.s + m_tbl.lngTableName.s;
                chkBoxSetAsDefault.Visible = false;
                this.btn_Select.Text = lng.s_Delete.s;
                this.btn_Cancel.Text = lng.s_Close.s;
            }
            this.chkBoxSetAsDefault.Text = lng.s_SelectAsDefaultView.s;
            lnlViewName.Text = lng.s_SelectedView.s;
            foreach (ViewXml xViewXml in m_TableDockingFormXml.m_ViewXml)
            {
                this.rdblist_Views.Items.Add(xViewXml);
            }
        }



        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.Cancel;
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

        private bool FindView(ref int Index, ViewXml xViewXmlToFind)
        {
            if (m_TableDockingFormXml.m_ViewXml != null)
            {
                int i = 0;
                int iCount = m_TableDockingFormXml.m_ViewXml.Count();
                for (i = 0; i < iCount; i++)
                {

                    if (m_TableDockingFormXml.m_ViewXml[i].Name.Equals(xViewXmlToFind.Name))
                    {
                        Index = i;
                        return true;
                    }
                }
            }
            return false;
        }

        private void FillViewList()
        {
            txtViewName.Text = m_CurrentViewXml.Name;
            if (m_TableDockingFormXml.m_CreateViewFormXml != null)
            {
                rdblist_Views.Items.Clear();
                foreach (ViewXml xViewXml in m_TableDockingFormXml.m_ViewXml)
                {
                    this.rdblist_Views.Items.Add(xViewXml);
                }
            }
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            if (m_mode == FormMode.SELECT)
            {
                if (this.txtViewName.Text.Length > 0)
                {
                    if (UniqueNames.AlreadyExistInUniqueConstraintNameList(m_TableDockingFormXml.m_ViewXml, this.txtViewName.Text, ref m_ViewXml_Selected))
                    {
                        bDefaultView = this.chkBoxSetAsDefault.Checked;
                        Close();
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        //Error.Show(lng.s_ViewWithName.s + txtViewName.Text + lng.s_AllreadyExistForTable.s + m_tbl.TableName);
                        MessageBox.Show(lng.s_TableView.s + " " + txtViewName.Text + " " + lng.s_DoesNotExist.s, lng.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    Error.Show(lng.s_YouMustDefineViewNameOrCancel.s);
                }
            }
            else
            {
                int i = this.rdblist_Views.SelectedIndex;
                if (i >= 0)
                {
                    if (rdblist_Views.Items[i].GetType() == typeof(ViewXml))
                    {
                        ViewXml xViewXml = (ViewXml)rdblist_Views.Items[i];
                        string sQuest = lng.s_AreYouSureToDeleteView.s + ":" + xViewXml.Name + " ?";
                        if (MessageBox.Show(this, sQuest, lng.s_DeleteViewTitle.s, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            int Index = -1;
                            if (FindView(ref Index, xViewXml))
                            {
                                m_TableDockingFormXml.m_ViewXml.RemoveAt(Index);
                                FillViewList();
                            }
                            m_xml.Save();
                        }
                    }
                }
            }
        }
    }
}
