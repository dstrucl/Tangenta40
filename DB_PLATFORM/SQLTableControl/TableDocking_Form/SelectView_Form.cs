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


namespace SQLTableControl.TableDocking_Form
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
            this.Icon = SQLTableControl.Properties.Resources.SelectViewIcon;
            m_xml = myXml;
            m_CurrentViewXml = CurrentViewXml;
            m_tbl = xTbl;
            m_TableDockingFormXml = xTableDockingFormXml;
            InitializeComponent();
           
            if (m_mode == FormMode.SELECT)
            {
                this.Text = lngRPM.s_SelectViewForTable.s + m_tbl.lngTableName.s;
                chkBoxSetAsDefault.Visible = true;
                this.btn_Select.Text = lngRPM.s_Select.s;
                this.btn_Cancel.Text = lngRPM.s_Cancel.s;
            }
            else
            {
                this.Text = lngRPM.s_DeleteViewForTable.s + m_tbl.lngTableName.s;
                chkBoxSetAsDefault.Visible = false;
                this.btn_Select.Text = lngRPM.s_Delete.s;
                this.btn_Cancel.Text = lngRPM.s_Close.s;
            }
            this.chkBoxSetAsDefault.Text = lngRPM.s_SelectAsDefaultView.s;
            lnlViewName.Text = lngRPM.s_SelectedView.s;
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
                        //Error.Show(lngRPM.s_ViewWithName.s + txtViewName.Text + lngRPM.s_AllreadyExistForTable.s + m_tbl.TableName);
                        MessageBox.Show(lngRPM.s_TableView.s + " " + txtViewName.Text + " " + lngRPM.s_DoesNotExist.s, lngRPM.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    Error.Show(lngRPM.s_YouMustDefineViewNameOrCancel.s);
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
                        string sQuest = lngRPM.s_AreYouSureToDeleteView.s + ":" + xViewXml.Name + " ?";
                        if (MessageBox.Show(this, sQuest, lngRPM.s_DeleteViewTitle.s, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
