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
using CodeTables;
using System.Runtime.InteropServices;
using DBConnectionControl40;
using CodeTables.TableDocking_Form;
using LogFile;
using NavigationButtons;

namespace CodeTables
{
    public partial class CreateView_Form : Form
    {
        private List<DefineView_InputControl> _items = new List<DefineView_InputControl>();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool PostMessage(int hhwnd, uint msg, IntPtr wparam, IntPtr lparam);

        public TableDockingForm m_TableDockingForm;

        DBTableControl m_DBTables;
        private SQLTable m_tbl;

        //public MyTabControl m_TabControl;
        private bool bFormCreated = false;

        public CurViewXml m_CurViewXml = null;

        public TableDockingFormXml m_pTableDockingFormXml;
        private NavigationButtons.Navigation nav = null;

        public CreateView_Form(DBTableControl dbTables, SQLTable tbl, TableDockingForm dtF, NavigationButtons.Navigation xnav)
        {
            nav = xnav;
            this.Visible = false; 
            bFormCreated = false;
            m_TableDockingForm = dtF;
            m_DBTables = dbTables;
            m_tbl = tbl;
            this.Icon=Properties.Resources.DataView_FormIcon;
            InitializeComponent();
            nmUpDn_Limit.Minimum = 0;
            nmUpDn_Limit.Maximum = 1000000000;
            chk_Limit.Checked = Properties.Settings.Default.bLimit;
            nmUpDn_Limit.Value = Convert.ToDecimal(Properties.Settings.Default.iLimitNumber);
            chk_Descending.Checked = Properties.Settings.Default.b_order_by_ID_desc;

            this.flowLayoutPanel1.Tag = 1;
            this.flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            this.flowLayoutPanel2.Tag = 2;
            this.flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;

            PictureBox pictureBox_MoveRight = new PictureBox();
            pictureBox_MoveRight.Image = Properties.Resources.MoveRightIcon.ToBitmap();
            pictureBox_MoveRight.Parent = this;
            pictureBox_MoveRight.Left = flowLayoutPanel2.Left + flowLayoutPanel2.Width + 3;
            pictureBox_MoveRight.Top = flowLayoutPanel2.Top + flowLayoutPanel2.Height / 4;
            pictureBox_MoveRight.Width = pictureBox_MoveRight.Image.Size.Width + 6;
            pictureBox_MoveRight.Height = pictureBox_MoveRight.Image.Size.Height + 6;
            pictureBox_MoveRight.Visible = true;
            //pictureBox_MoveRight.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;

            PictureBox pictureBox_MoveLeft = new PictureBox();
            pictureBox_MoveLeft.Image = Properties.Resources.MoveLeftIcon.ToBitmap();
            pictureBox_MoveLeft.Parent = this;
            pictureBox_MoveLeft.Left = flowLayoutPanel2.Left + flowLayoutPanel2.Width + 3;
            pictureBox_MoveLeft.Top = flowLayoutPanel2.Top + flowLayoutPanel2.Height/4 + 30;
            pictureBox_MoveLeft.Width = pictureBox_MoveLeft.Image.Size.Width + 6;
            pictureBox_MoveLeft.Height = pictureBox_MoveLeft.Image.Size.Height + 6;
            pictureBox_MoveLeft.Visible = true;
            //pictureBox_MoveLeft.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            //this.pictureBox2.Image = Properties.Resources.MoveLeftIcon.ToBitmap();

            this.flowLayoutPanel1.DragEnter += new DragEventHandler(flowLayoutPanel1_DragEnter);
            this.flowLayoutPanel1.DragDrop += new DragEventHandler(flowLayoutPanel1_DragDrop);
            this.flowLayoutPanel2.DragEnter += new DragEventHandler(flowLayoutPanel1_DragEnter);
            this.flowLayoutPanel2.DragDrop += new DragEventHandler(flowLayoutPanel1_DragDrop);

            if (!bFormCreated)
            {

                int iCtrl = 1;
                m_pTableDockingFormXml = m_DBTables.m_xml.GetTableDockingFormXml(m_tbl.TableName);
                if (m_pTableDockingFormXml == null)
                {
                    m_pTableDockingFormXml = m_DBTables.m_xml.Create_pTableDockingFormXml(m_tbl.TableName);
                    m_DBTables.m_xml.m_xmldata.Add(m_pTableDockingFormXml);
                }
                if (m_pTableDockingFormXml.m_CreateViewFormXml == null)
                {
                    m_pTableDockingFormXml.Create_pCreateViewFormXml();
                }


                m_pTableDockingFormXml.m_CreateViewFormXml.wrect.SetFormPlacement(this);

                // Create DefineView_InputControls with no binding to xml data !
                m_tbl.Create_DefineView_InputControls(null, "", ref m_tbl.DefineView_inpCtrlList, this, this, ref iCtrl);

                
                //this.DynamicCreateControls(m_DBTables.m_xml.GetCreateViewFormDefaultView(m_tbl.TableName));

                this.DynamicCreateControls(m_pTableDockingFormXml.m_CreateViewFormXml.m_DefaultViewXml);


                bFormCreated = true;
            }
            this.Text = lngRPM.s_DataView_Form.s + m_tbl.lngTableName.s + " (" + m_tbl.TableName + ")";
            tsmi_CreateNew.Text = lngRPM.s_CreateNewView.s;
            tsmi_Select_View.Text = lngRPM.s_SelectView.s;
            tsmi_DeleteView.Text = lngRPM.s_DeleteView.s;
            tsmi_Save.Text =  lngRPM.s_Save.s;
            tsmi_Show.Text = lngRPM.s_Show.s;
            label_PrimaryView.Text = lngRPM.s_PrimaryView.s;
            chk_Limit.Text = lngRPM.s_Limit.s;
            chk_Descending.Text = lngRPM.s_Descending.s;
            grb_ShowLimits.Text = lngRPM.s_View.s;

            
        }

        void flowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            DefineView_InputControl data = (DefineView_InputControl)e.Data.GetData(typeof(DefineView_InputControl));
            FlowLayoutPanel _destination = (FlowLayoutPanel)sender;
            FlowLayoutPanel _source = (FlowLayoutPanel)data.Parent;

            if (_source != _destination)
            {
                // Add control to panel
                _destination.Controls.Add(data);
                if ((int)_destination.Tag == 1)
                {
                    data.Size = new Size(300,_destination.Height);
                }
                else
                {
                    data.Size = new Size(_destination.Width+100, 40);
                }

                // Reorder
                Point p = _destination.PointToClient(new Point(e.X, e.Y));
                var item = _destination.GetChildAtPoint(p);
                int index = _destination.Controls.GetChildIndex(item, false);
                _destination.Controls.SetChildIndex(data, index);

                // Invalidate to paint!
                _destination.Invalidate();
                _source.Invalidate();
            }
            else
            {
                // Just add the control to the new panel.
                // No need to remove from the other panel, this changes the Control.Parent property.
                Point p = _destination.PointToClient(new Point(e.X, e.Y));
                var item = _destination.GetChildAtPoint(p);
                int index = _destination.Controls.GetChildIndex(item, false);
                _destination.Controls.SetChildIndex(data, index);
                _destination.Invalidate();
            }
        }

        void flowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }


        //[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        //protected override void WndProc(ref Message m)
        //{
        //    // Listen for operating system messages.
        //    if (m.Msg == (int)Func.WM_USER_REDRAW_FORM)
        //    {
        //        // The WParam value identifies what is occurring.
        //        // Invalidate to get new text painted.
        //        MySize size = new MySize();
        //        size.cx = 0;
        //        size.cy = 0;
        //        //m_tbl.myGroupBox.Top = 60;
        //        m_tbl.Reposition_DefineView_InputControls(m_tbl.DefineView_GroupBox, ref size, 0);
        //        m_tbl.DefineView_GroupBox.Width = size.cx;
        //        m_tbl.DefineView_GroupBox.Height = size.cy;
        //        m_tbl.DefineView_GroupBox.Visible = true;
        //        this.BackColor = m_tbl.DefineView_GroupBox.BackColor;
        //        this.Invalidate();
        //    }
        //    base.WndProc(ref m);
        //}


        private void CreateView_Form_Load(object sender, EventArgs e)
        {

        }

        private void tsmi_DataBaseView_Create_Click(object sender, EventArgs e)
        {

        }

        // BINDS flowLayoutPanel1, flowLayoutPanel2 and DefineView_InputControls to XML !
        public void DynamicCreateControls(ViewXml xViewXml)
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();

            m_CurViewXml = new CurViewXml(xViewXml, m_tbl, flowLayoutPanel1, flowLayoutPanel2, _items, m_DBTables, this.m_pTableDockingFormXml.m_ViewXml);

            this.label_ViewName.Text = lngRPM.s_View.s + " : ";

            lblViewName.Text = m_CurViewXml.m_ViewXml.Name;

            if (m_pTableDockingFormXml.m_CreateViewFormXml.m_DefaultViewXml != null)
            {
                lblPrimaryView.Text = m_pTableDockingFormXml.m_CreateViewFormXml.m_DefaultViewXml.Name;
            }
            else
            {
                lblPrimaryView.Text = "";
            }

        }

        private bool FillColumnXmlList(List<ColumnXml> ColumnXml_list, Control.ControlCollection m_ControlCollection)
        {
            ColumnXml_list.Clear();

            foreach (Control ctrl in m_ControlCollection)
            {
                if (ctrl.GetType() == typeof(DefineView_InputControl))
                {
                    DefineView_InputControl dvinpctrl = (DefineView_InputControl)ctrl;
                    ColumnXml xColumnXml = new ColumnXml();

                    xColumnXml.Name = dvinpctrl.FullName;
                    xColumnXml.m_col = dvinpctrl.m_col;
                    ColumnXml_list.Add(xColumnXml);
                }
                else
                {
                    Error.Show("ERROR in saveToolStripMenuItem_Click! Wrong Type:" + ctrl.GetType().ToString());
                    return false;
                }
            }
            return true;
        }

        private void flowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate(true);
        }

        private void tsmi_Save_Click(object sender, EventArgs e)
        {
            TableDockingFormXml xTableDockingFormXml = m_DBTables.m_xml.GetTableDockingFormXml(m_tbl.TableName);

            SaveView_Form SaveView_FormDialog = new SaveView_Form(this, m_tbl, xTableDockingFormXml, m_CurViewXml, flowLayoutPanel1.Controls, m_DBTables.m_xml, m_DBTables, chk_Limit.Checked, Convert.ToInt32(nmUpDn_Limit.Value), this.chk_Descending.Checked);
            SaveView_FormDialog.ShowDialog();
        }


        private void tsmi_Select_View_Click(object sender, EventArgs e)
        {
            SelectView_Form SelectView_FormDialog = new SelectView_Form(this, m_tbl, m_pTableDockingFormXml, m_CurViewXml.m_ViewXml, m_DBTables.m_xml, SelectView_Form.FormMode.SELECT);
            if (SelectView_FormDialog.ShowDialog() == DialogResult.OK)
            {
                m_CurViewXml.m_ViewXml = new ViewXml(SelectView_FormDialog.m_ViewXml_Selected);
                if (SelectView_FormDialog.bDefaultView)
                {
                    m_CurViewXml.State= CurViewXml.ViewXmlState.DEFAULT_VIEW;
                    if (m_pTableDockingFormXml != null)
                    {
                        if (m_pTableDockingFormXml.m_CreateViewFormXml != null)
                        {
                            m_pTableDockingFormXml.m_CreateViewFormXml.m_DefaultViewXml = SelectView_FormDialog.m_ViewXml_Selected;
                            m_pTableDockingFormXml.m_CreateViewFormXml.sDefaultView = SelectView_FormDialog.m_ViewXml_Selected.Name;
                        }
                    }
                }
                else
                {
                    m_CurViewXml.State= CurViewXml.ViewXmlState.EXISTING_VIEW;
                }
                m_tbl.ClearFilterDataOf_DefineView_InputControl();
                DynamicCreateControls(m_CurViewXml.m_ViewXml);
            }
        }

        private void tsmi_Show_Click(object sender, EventArgs e)
        {
//            ViewXml xViewXml = SaveCurrentView();

            if (flowLayoutPanel1.Controls.Count > 0)
            {
                m_CurViewXml.m_ViewXml.FillColumnXmlList(flowLayoutPanel1.Controls);
                m_CurViewXml.m_ViewXml.SQLView = m_tbl.SQLCreateView(ref m_CurViewXml.m_ViewXml, m_DBTables, chk_Limit.Checked, Convert.ToInt32(nmUpDn_Limit.Value), this.chk_Descending.Checked).ToString() + "\n";

                int iIndexFree = m_TableDockingForm.GetFreeTableViewIndex();
                if (iIndexFree < 0)
                {
                    iIndexFree = 3; //Overwrite
                }
                m_TableDockingForm.Create_TableView_Form(iIndexFree, m_CurViewXml.m_ViewXml,nav);
            }
            else
            {
                MessageBox.Show(this, lngRPM.s_SelectColumnsBeforeShow.s, lngRPM.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void CreateView_Form_TextChanged(object sender, EventArgs e)
        {
            this.Refresh();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tsmi_CreateNew_Click(object sender, EventArgs e)
        {
            //if (flowLayoutPanel1.Controls.Count > 0)
            //{
                if (MessageBox.Show(this, lngRPM.s_CreateNewViewQuestion.s, lngRPM.s_Question.s, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            //}
            m_CurViewXml.m_ViewXml = null;
            //m_CurViewXml.State= CurViewXml.ViewXmlState.NEW_VIEW;
            //TableDockingFormXml xTableDockingFormXml = m_DBTables.m_xml.GetTableDockingFormXml(m_tbl.TableName);
            //m_CurViewXml.m_ViewXml.Name = UniqueNames.GetName(xTableDockingFormXml.m_ViewXml, lngRPM.s_View.s+"1");
            m_tbl.ClearFilterDataOf_DefineView_InputControl();
            DynamicCreateControls(m_CurViewXml.m_ViewXml);
        }

        public bool bDefaultLimit { get; set; }

        private void deleteViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectView_Form SelectView_FormDialog = new SelectView_Form(this, m_tbl, m_pTableDockingFormXml, m_CurViewXml.m_ViewXml, m_DBTables.m_xml, SelectView_Form.FormMode.DELETE);
            if (SelectView_FormDialog.ShowDialog() == DialogResult.OK)
            {
                m_CurViewXml.m_ViewXml = new ViewXml(SelectView_FormDialog.m_ViewXml_Selected);
                if (SelectView_FormDialog.bDefaultView)
                {
                    m_CurViewXml.State= CurViewXml.ViewXmlState.DEFAULT_VIEW;
                    if (m_pTableDockingFormXml != null)
                    {
                        if (m_pTableDockingFormXml.m_CreateViewFormXml != null)
                        {
                            m_pTableDockingFormXml.m_CreateViewFormXml.m_DefaultViewXml = SelectView_FormDialog.m_ViewXml_Selected;
                            m_pTableDockingFormXml.m_CreateViewFormXml.sDefaultView = SelectView_FormDialog.m_ViewXml_Selected.Name;
                        }
                    }
                }
                else
                {
                    m_CurViewXml.State= CurViewXml.ViewXmlState.EXISTING_VIEW;
                }
                m_tbl.ClearFilterDataOf_DefineView_InputControl();
                DynamicCreateControls(m_CurViewXml.m_ViewXml);
            }
        }
    }
}
