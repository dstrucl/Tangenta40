using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Crom.Controls.Docking;
using System.IO;
using System.Xml;
using SQLTableControl;
using LanguageControl;
using DBConnectionControl40;
using SQLTableControl.TableDocking_Form;

namespace SQLTableControl
{
    public partial class TableDockingForm : Form
    {
        Form m_pParentForm;

        DBTableControl m_DBTables;

        SQLTable m_tbl;
        internal static Globals.delegate_SetControls SetControls = null;

        TableDockingFormXml m_pTableDockingFormXml;


        public DataTable_Form m_DataTable_Form = null;
        DockableFormInfo info_DataTable_Form = null;

        public EditTable_Form m_EditTable_Form = null;
        DockableFormInfo info_EditTable_Form = null;

        public CreateView_Form m_CreateView_Form = null;
        public DockableFormInfo info_CreateView_Form = null;


        public TableView_Form[] m_TableView_Form = new TableView_Form[guid.MaxTableViews] { null, null, null, null };
        DockableFormInfo[] info_TableView_Form = new DockableFormInfo[guid.MaxTableViews] { null, null, null, null };

        #region XML parameters

        //private const string const_atrShow = "Show";
        //private const string const_true = "true";
        //private const string const_false = "false";

        //private const string const_ON = "ON";
        //private const string const_OFF = "OFF";


        private const string const_TableName_EditTableForm = "EditTableForm";
        private const string const_TableName_CreateViewForm = "CreateViewForm";

        #endregion

        public TableDockingForm(Form pParentForm, DBTableControl dbTables, SQLTable tbl)
        {
            m_pParentForm = pParentForm;
            InitializeComponent();
            m_DBTables = dbTables;
            m_tbl = tbl;
            m_pTableDockingFormXml = m_DBTables.m_xml.GetTableDockingFormXml(m_tbl.TableName);
            if (m_pTableDockingFormXml == null)
            {
                m_pTableDockingFormXml = new TableDockingFormXml(m_tbl.TableName);
                m_DBTables.m_xml.m_xmldata.Add(m_pTableDockingFormXml);
            }

            m_pTableDockingFormXml.wrect.SetFormPlacement(this);


            this.Icon = Properties.Resources.TableDockingForm_icon;
            this.Text = m_tbl.lngTableName.s;
            SetViews();


        }

        #region Create_Forms

        private void Create_CreateView_Form()
        {
            if (m_CreateView_Form == null)
            {
                if (m_pTableDockingFormXml.m_CreateViewFormXml == null)
                {
                    m_pTableDockingFormXml.m_CreateViewFormXml = new CreateViewFormXml();
                }
                m_CreateView_Form = (CreateView_Form)CreateDockForm(new Guid(guid.gDocking_CreateView_Form.ToByteArray()), m_DBTables, m_tbl, this, m_pTableDockingFormXml.m_CreateViewFormXml.wrect, null);
                info_CreateView_Form = _docker.Add(m_CreateView_Form, zAllowedDock.All, new Guid(guid.gDocking_CreateView_Form.ToByteArray()));
                _docker.DockForm(info_CreateView_Form, DockStyle.Top, zDockMode.None);
            }
            else
            {
                m_CreateView_Form.Activate();

            }

        }

        public void Create_TableView_Form(int index)
        {
            if (m_TableView_Form[index] == null)
            {
                if (m_pTableDockingFormXml.m_TableViewFormXml[index] == null)
                {
                    m_pTableDockingFormXml.m_TableViewFormXml[index] = new TableViewFormXml();
                }
                m_TableView_Form[index] = (TableView_Form)CreateDockForm(new Guid(guid.gDocking_TableView_Form[index].ToByteArray()), m_DBTables, m_tbl, this, m_pTableDockingFormXml.m_TableViewFormXml[index].wrect, m_pTableDockingFormXml.m_TableViewFormXml[index].m_DefaultViewXml);
                info_TableView_Form[index] = _docker.Add(m_TableView_Form[index], zAllowedDock.Sides, new Guid(guid.gDocking_TableView_Form[index].ToByteArray()));
                _docker.DockForm(info_TableView_Form[index], DockStyle.Top, zDockMode.Inner);
            }
            else
            {
                m_TableView_Form[index].Activate();

            }
        }

        public void Create_TableView_Form(int index, ViewXml ExistingViewXml)
        {
            if (m_TableView_Form[index] == null)
            {
                if (m_pTableDockingFormXml.m_TableViewFormXml[index] == null)
                {
                    m_pTableDockingFormXml.m_TableViewFormXml[index] = new TableViewFormXml();
                }
                m_TableView_Form[index] = (TableView_Form)CreateDockForm(new Guid(guid.gDocking_TableView_Form[index].ToByteArray()), m_DBTables, m_tbl, this, m_pTableDockingFormXml.m_TableViewFormXml[index].wrect, ExistingViewXml);
                info_TableView_Form[index] = _docker.Add(m_TableView_Form[index], zAllowedDock.All, new Guid(guid.gDocking_TableView_Form[index].ToByteArray()));
                _docker.DockForm(info_TableView_Form[index], DockStyle.Right, zDockMode.Inner);
            }
            else
            {
                m_TableView_Form[index].Activate();

            }
        }

        private void Create_DataTable_Form()
        {
            if (m_DataTable_Form == null)
            {
                if (m_pTableDockingFormXml.m_DataTableFormXml == null)
                {
                    m_pTableDockingFormXml.m_DataTableFormXml = new DataTableFormXml();
                }
                m_DataTable_Form = (DataTable_Form)CreateDockForm(new Guid(guid.gDocking_TableGrid_Form.ToByteArray()), m_DBTables, m_tbl, this, m_pTableDockingFormXml.m_DataTableFormXml.wrect, null);
                info_DataTable_Form = _docker.Add(m_DataTable_Form, zAllowedDock.All, new Guid(guid.gDocking_TableGrid_Form.ToByteArray()));
                _docker.DockForm(info_DataTable_Form, DockStyle.Right, zDockMode.Inner);
            }
            else
            {
                m_DataTable_Form.Activate();
            }

        }

        private void Create_EditTable_Form()
        {
            if (m_EditTable_Form == null)
            {
                if (m_pTableDockingFormXml.m_EditTableFormXml == null)
                {
                    m_pTableDockingFormXml.m_EditTableFormXml = new EditTableFormXml();
                    // m_pTableDockingFormXml.m_EditTableFormXml.wrect = Get_wRect(typeof(EditTable_Form), 0);
                }

                m_EditTable_Form = (EditTable_Form)CreateDockForm(new Guid(guid.gDocking_EditTable_Form.ToByteArray()), m_DBTables, m_tbl, this, m_pTableDockingFormXml.m_EditTableFormXml.wrect, null);
                info_EditTable_Form = _docker.Add(m_EditTable_Form, zAllowedDock.All, new Guid(guid.gDocking_EditTable_Form.ToByteArray()));
                _docker.DockForm(info_EditTable_Form, DockStyle.Left, zDockMode.Inner);
            }
            else
            {
                m_EditTable_Form.Activate();
            }

        }


        #endregion



        private void Initialize()
        {

            #region Comments may be used in future
            ////_docker.TitleBarGradientColor1 = Color.Green;
            ////_docker.TitleBarGradientColor2 = Color.LightBlue;
            ////_docker.TitleBarGradientSelectedColor1 = Color.DarkGreen;
            ////_docker.TitleBarGradientSelectedColor2 = Color.Blue;
            ////_docker.TitleBarTextColor = Color.Yellow;
            //Form EditTable_Form = CreateDockForm(new Guid(guid.gDocking_EditTable_Form.ToByteArray()), m_DB, m_tbl, null);
            //m_EditTable_Form = (EditTable_Form)EditTable_Form;
            //Form CreateView_Form = null;
            //DockableFormInfo info_EditTable_Form = _docker.Add(EditTable_Form, zAllowedDock.All, new Guid(guid.gDocking_EditTable_Form.ToByteArray()));
            //DockableFormInfo info_CreateView_Form=null;
            //info_DataTable_Form.ShowContextMenuButton = false;
            //info_EditTable_Form.ShowCloseButton = false;
            //_docker.DockForm(info_EditTable_Form, DockStyle.Fill, zDockMode.Inner);
            //_docker.DockForm(info_DataTable_Form, DockStyle.Right, zDockMode.Outer);
            //_docker.SetWidth(info_EditTable_Form, 500);
            //_docker.SetWidth(info_DataTable_Form, 500);
            //_docker.SetWidth(info_CreateView_Form, 500);
            #endregion

            this.Width = 1500;
            this.Height = 800;
            //_docker.CanMoveByMouseFilledForms = false;
        }
        private static Form CreateDockForm(int left, int top, int width, int height, Color backColor, string caption)
        {
            Form form = new Form();
            form.Bounds = new Rectangle(left, top, width, height);
            form.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            TextBox text = new TextBox();
            text.Multiline = true;
            text.Parent = form;
            text.Dock = DockStyle.Fill;
            text.BackColor = backColor;
            form.Text = caption;
            form.TopLevel = false;

            return form;
        }

        /// <summary>
        /// Create test form
        /// </summary>
        /// <param name="identifier">form identifier</param>
        /// <returns>test form</returns>
        /// 
        private static Form CreateDockForm(Guid identifier, DBTableControl dbTables, SQLTable x_tbl, TableDockingForm pParentForm, wRect wrect, ViewXml xViewXml)
        {
            if (identifier == new Guid(guid.gDocking_TableGrid_Form.ToByteArray()))
            {
                DataTable_Form result = new DataTable_Form(dbTables, x_tbl, DataTable_Form.DataTable_Form_ENUM.EDIT_OR_DELETE, pParentForm);
                result.Bounds = new Rectangle(wrect.Left, wrect.Top, wrect.Width, wrect.Height);
                return result;
            }
            else if (identifier == new Guid(guid.gDocking_EditTable_Form.ToByteArray()))
            {
                EditTable_Form result = new EditTable_Form(dbTables, x_tbl, pParentForm,SetControls,false);
                result.Bounds = new Rectangle(wrect.Left, wrect.Top, wrect.Width, wrect.Height);
                return result;
            }
            else if (identifier == new Guid(guid.gDocking_CreateView_Form.ToByteArray()))
            {
                CreateView_Form result = new CreateView_Form(dbTables, x_tbl, pParentForm);
                result.Bounds = new Rectangle(wrect.Left, wrect.Top, wrect.Width, wrect.Height);
                return result;
            }
            else
            {
                for (int i = 0; i < guid.MaxTableViews; i++)
                {
                    if (identifier == new Guid(guid.gDocking_TableView_Form[i].ToByteArray()))
                    {
                        TableView_Form result = new TableView_Form(i, dbTables, x_tbl, pParentForm, xViewXml);
                        result.Bounds = new Rectangle(wrect.Left, wrect.Top, wrect.Width, wrect.Height);
                        return result;
                    }
                }
            }

            throw new InvalidOperationException();
        }

        private void TableDockingForm_Load(object sender, EventArgs e)
        {
        }


        private void SetViews()
        {

            if (m_pTableDockingFormXml != null)
            {
                this.WindowState = m_pTableDockingFormXml.wrect.formWindowState;
                if (this.WindowState == FormWindowState.Normal)
                {
                    if (m_pTableDockingFormXml.wrect.Width < 200)
                        m_pTableDockingFormXml.wrect.Width = 200;

                    if (m_pTableDockingFormXml.wrect.Left < 0)
                        m_pTableDockingFormXml.wrect.Left = 0;

                    if (m_pTableDockingFormXml.wrect.Top < 0)
                        m_pTableDockingFormXml.wrect.Top = 0;

                    if (m_pTableDockingFormXml.wrect.Height < 200)
                        m_pTableDockingFormXml.wrect.Height = 200;


                }

                if (m_pTableDockingFormXml.m_CreateViewFormXml != null)
                {
                    Create_CreateView_Form();
                }
                if (m_pTableDockingFormXml.m_EditTableFormXml != null)
                {
                    Create_EditTable_Form();
                }
                if (m_pTableDockingFormXml.m_DataTableFormXml != null)
                {
                    Create_DataTable_Form();
                }
                int i;
                for (i = 0; i < guid.MaxTableViews; i++)
                {
                    if (m_pTableDockingFormXml.m_TableViewFormXml[i] != null)
                    {
                        this.Create_TableView_Form(i);
                    }
                }

                // set all forms visible !
                if (this.m_CreateView_Form != null)
                {
                    this.m_CreateView_Form.Visible = true;
                }
                if (m_EditTable_Form != null)
                {
                    this.m_EditTable_Form.Visible = true;
                }

                if (m_DataTable_Form != null)
                {
                    this.m_DataTable_Form.Visible = true;
                }

                for (i = 0; i < guid.MaxTableViews; i++)
                {
                    if (m_TableView_Form[i] != null)
                    {
                        m_TableView_Form[i].Visible = true;
                    }
                }
                //this.tsmi_View.Text = lngRPM.s_View.s;
                //this.tsmi_Primary_Table.Text = lngRPM.s_PrimaryTable.s;
                //this.tsmi_Table_View_1.Text = lngRPM.s_Table_View_1.s;
                //this.tsmi_Table_View_2.Text = lngRPM.s_Table_View_2.s;
                //this.tsmi_Table_View_3.Text = lngRPM.s_Table_View_3.s;
                //this.tsmi_Table_View_4.Text = lngRPM.s_Table_View_4.s;
                this.tsmi_Data_Editor.Text = lngRPM.s_DataEditor.s;
                this.tsmi_Data_Editor.Visible = true;
                this.tsmi_View_Manager.Text = lngRPM.s_ViewManager.s;
                this.tsmi_SaveWindowConfiguration.Text = lngRPM.s_SaveWindowConfiguration.s;
                this.tsmi_Edit_XML_configuration.Text = lngRPM.s_Edit_XML_Configuration.s;
            }
        }

        private void TableDockingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void tsmi_View_Edit_Click(object sender, EventArgs e)
        {

        }

        private void tsmi_View_Create_Click(object sender, EventArgs e)
        {

        }

        private void tsmi_View_Table_Default_Click(object sender, EventArgs e)
        {

        }

        private void _docker_FormClosed(object sender, FormEventArgs e)
        {
            if (e.Form.GetType() == typeof(DataTable_Form))
            {
                m_DataTable_Form.Dispose();
                m_DataTable_Form = null;
            }
            else if (e.Form.GetType() == typeof(EditTable_Form))
            {
                m_EditTable_Form.Dispose();
                m_EditTable_Form = null;
                m_tbl.inpCtrlList.Clear();
            }
            else if (e.Form.GetType() == typeof(CreateView_Form))
            {
                m_CreateView_Form.Dispose();
                m_CreateView_Form = null;
                m_tbl.DefineView_inpCtrlList.Clear();
            }
            else if (e.Form.GetType() == typeof(TableView_Form))
            {
                int i;
                for (i = 0; i < guid.MaxTableViews; i++)
                {
                    if (e.Form == m_TableView_Form[i])
                    {
                        m_TableView_Form[i].Dispose();
                        m_TableView_Form[i] = null;
                    }
                }
            }

        }

        private void tsmi_SaveWindowConfiguration_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, lngRPM.s_SaveWindowsConfiguration.s, lngRPM.s_Warning.s, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SaveWindowConfigruarion();
            }
        }

        public void SaveWindowConfigruarion()
        {
            TableDockingFormXml xTableDockingFormXml = m_DBTables.m_xml.GetTableDockingFormXml(m_tbl.TableName);
            if (xTableDockingFormXml == null)
            {
                xTableDockingFormXml = new TableDockingFormXml();
                xTableDockingFormXml.TableName = m_tbl.TableName;

            }

            m_DBTables.m_xml.Set_wRect(xTableDockingFormXml.wrect, this);


            if (m_EditTable_Form != null)
            {
                if (xTableDockingFormXml.m_EditTableFormXml == null)
                {
                    xTableDockingFormXml.m_EditTableFormXml = new EditTableFormXml();
                }

                m_DBTables.m_xml.Set_wRect(xTableDockingFormXml.m_EditTableFormXml.wrect, m_EditTable_Form);

            }
            else
            {
                if (xTableDockingFormXml.m_EditTableFormXml != null)
                {
                    xTableDockingFormXml.m_EditTableFormXml = null;
                }
            }

            if (m_CreateView_Form != null)
            {
                if (xTableDockingFormXml.m_CreateViewFormXml == null)
                {
                    xTableDockingFormXml.m_CreateViewFormXml = new CreateViewFormXml();
                }

                m_DBTables.m_xml.Set_wRect(xTableDockingFormXml.m_CreateViewFormXml.wrect, m_CreateView_Form);
            }
            else
            {
                if (xTableDockingFormXml.m_CreateViewFormXml != null)
                {
                    xTableDockingFormXml.m_CreateViewFormXml = null;
                }
            }

            if (this.m_DataTable_Form != null)
            {
                if (xTableDockingFormXml.m_DataTableFormXml == null)
                {
                    xTableDockingFormXml.m_DataTableFormXml = new DataTableFormXml();
                }

                m_DBTables.m_xml.Set_wRect(xTableDockingFormXml.m_DataTableFormXml.wrect, m_DataTable_Form);

            }
            else
            {
                if (xTableDockingFormXml.m_DataTableFormXml != null)
                {
                    xTableDockingFormXml.m_DataTableFormXml = null;
                }
            }

            int i;
            for (i = 0; i < guid.MaxTableViews; i++)
            {
                if (this.m_TableView_Form[i] != null)
                {
                    if (xTableDockingFormXml.m_TableViewFormXml[i] == null)
                    {
                        xTableDockingFormXml.m_TableViewFormXml[i] = new TableViewFormXml();
                    }
                    m_DBTables.m_xml.Set_wRect(xTableDockingFormXml.m_TableViewFormXml[i].wrect, m_TableView_Form[i]);
                }
                else
                {
                    if (xTableDockingFormXml.m_TableViewFormXml[i] != null)
                    {
                        xTableDockingFormXml.m_TableViewFormXml[i] = null;
                    }
                }
            }

            m_DBTables.m_xml.Set_wRect(m_DBTables.m_xml.wrect, m_pParentForm);

            m_DBTables.m_xml.Save();
        }


        private void tsmi_Data_Editor_Click(object sender, EventArgs e)
        {
            Create_EditTable_Form();
        }



        private void tsmi_Primary_Table_Click(object sender, EventArgs e)
        {
            Create_DataTable_Form();
        }

        private void tsmi_Edit_XML_configuration_Click(object sender, EventArgs e)
        {
            try
            {
                string sXml = File.ReadAllText(StaticXml.m_XMLFile);
                TextEditorDialog txtEditor = new TextEditorDialog(sXml, StaticXml.m_XMLFile, this);
                txtEditor.Show();
            }
            catch (Exception ex)
            {
                LogFile.Warning.Show("Warning: Xml file :" + StaticXml.m_XMLFile + " not loaded ! " + ex.Message );
            }
        }

        private void tsmi_View_Manager_Click(object sender, EventArgs e)
        {
            Create_CreateView_Form();
        }

        private void tsmi_Table_View_1_Click(object sender, EventArgs e)
        {
            Create_TableView_Form(0);
        }

        private void tsmi_Table_View_2_Click(object sender, EventArgs e)
        {
            Create_TableView_Form(1);
        }

        private void tsmi_Table_View_3_Click(object sender, EventArgs e)
        {
            Create_TableView_Form(2);
        }

        private void tsmi_Table_View_4_Click(object sender, EventArgs e)
        {
            Create_TableView_Form(3);
        }






        internal int GetFreeTableViewIndex()
        {
            int i;
            for (i = 0; i < guid.MaxTableViews; i++)
            {
                if (m_TableView_Form[i] == null)
                {
                    return i;
                }
            }
            return -1;
        }

        internal void UpdateForms(long ID)
        {
            int i;
            for (i = 0; i < guid.MaxTableViews; i++)
            {
                if (m_TableView_Form[i] != null)
                {
                    m_TableView_Form[i].UpdateForm();
                }
            }
            if (m_DataTable_Form != null)
            {
                m_DataTable_Form.UpdateForm();
            }
        }

    }



    public static class guid
    {
        public const int MaxTableViews = 4;
        public static Guid gDocking_TableGrid_Form = Guid.NewGuid();
        public static Guid gDocking_EditTable_Form = Guid.NewGuid();
        public static Guid gDocking_CreateView_Form = Guid.NewGuid();
        public static Guid[] gDocking_TableView_Form = new Guid[MaxTableViews] { Guid.NewGuid(), //
                                                                                 Guid.NewGuid(),
                                                                                 Guid.NewGuid(),
                                                                                 Guid.NewGuid()};
        public static Guid neki = Guid.NewGuid();
    }
}
