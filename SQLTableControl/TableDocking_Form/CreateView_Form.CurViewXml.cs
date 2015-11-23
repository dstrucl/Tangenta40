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
using SQLTableControl.TableDocking_Form;

namespace SQLTableControl
{
    public class CurViewXml
    {
        public enum ViewXmlState { DEFAULT_VIEW,EXISTING_VIEW, NEW_VIEW };
        public ViewXml m_ViewXml;
        public ViewXmlState State;

        public CurViewXml(ViewXml CurViewXml, SQLTable tbl, FlowLayoutPanel flowLayoutPanel1, FlowLayoutPanel flowLayoutPanel2, List<DefineView_InputControl> _items, DBTableControl m_DBTables, List<ViewXml> ViewXmlList)
        {
            if (CurViewXml != null)
            {
                // DefaultView Found;
                m_ViewXml = new ViewXml(CurViewXml);


                // Put in flowLayoutPanel1 all those which are  in ViewXml!
                ViewXml refViewXml=null;

                if (UniqueNames.AlreadyExistInUniqueConstraintNameList(ViewXmlList, CurViewXml.Name, ref refViewXml))
                {
                    State = ViewXmlState.EXISTING_VIEW;
                    TableDockingFormXml xTableDockingFormXml = m_DBTables.m_xml.GetTableDockingFormXml(tbl.TableName);
                    if (xTableDockingFormXml.m_CreateViewFormXml.sDefaultView != null)
                    {
                        if (xTableDockingFormXml.m_CreateViewFormXml.sDefaultView.Equals(m_ViewXml.Name))
                        {
                            State = ViewXmlState.DEFAULT_VIEW;
                        }
                    }
                }

                foreach (ColumnXml xColumnXml in CurViewXml.m_ColumnXml)
                {
                    DefineView_InputControl dvinpctrl = tbl.GetDefineView_InputControl(xColumnXml.Name);
                    if (dvinpctrl != null)
                    {
                        xColumnXml.m_col = dvinpctrl.m_col;
                        Size s;
                        dvinpctrl.Padding = new Padding(0);

                        //dvinpctrl.MainText = "47x100x5400 - 20/100";
                        dvinpctrl.FillDegree = 20;
                        dvinpctrl.StatusText = "";
                        dvinpctrl.StatusBarColor = 0;

                        dvinpctrl.bUseSqlFilter = xColumnXml.bUseSqlFilter;
                        if (dvinpctrl.m_chkUseFiler != null)
                        {
                            dvinpctrl.m_chkUseFiler.Checked = dvinpctrl.bUseSqlFilter;
                        }

                        if (xColumnXml.SqlFilter != null)
                        {
                            if (xColumnXml.SqlFilter.Length > 0)
                            {
                                dvinpctrl.SQLFilter = xColumnXml.SqlFilter;
                                if (dvinpctrl.m_txtSQLFilter != null)
                                {
                                    dvinpctrl.m_txtSQLFilter.Text = dvinpctrl.SQLFilter;
                                }
                            }
                        }

                        //dvinpctrl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
                        //GetCurrentView
                        s = new Size(300, flowLayoutPanel1.Height);
                        flowLayoutPanel1.Controls.Add(dvinpctrl);
                        dvinpctrl.Size = s;
                        _items.Add(dvinpctrl);
                    }
                }

                // Put in flowLayoutPanel2 all those which are not in ViewXml

                foreach (DefineView_InputControl dvinpctrl in tbl.DefineView_inpCtrlList)
                {
                    ColumnXml xColumnXml = null;
                    if (State == ViewXmlState.DEFAULT_VIEW)
                    {
                        xColumnXml = m_DBTables.m_xml.GetCreateViewDefaultViewColumnXml(tbl.TableName, dvinpctrl.FullName);
                    }
                    else
                    {
                        xColumnXml = m_ViewXml.GetColumnXml(dvinpctrl.FullName);
                    }

                    if (xColumnXml == null)
                    {
                        Size s;
                        dvinpctrl.Padding = new Padding(0);

                        //dvinpctrl.MainText = "47x100x5400 - 20/100";
                        dvinpctrl.FillDegree = 20;
                        dvinpctrl.StatusText = "";
                        dvinpctrl.StatusBarColor = 0;

                        //dvinpctrl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
                        //GetCurrentView
                        s = new Size(flowLayoutPanel2.Width + 100, 40);
                        flowLayoutPanel2.Controls.Add(dvinpctrl);
                        dvinpctrl.Size = s;
                        _items.Add(dvinpctrl);
                    }

                }

            }
            else
            {

                State = ViewXmlState.NEW_VIEW;
                m_ViewXml = new ViewXml();
                m_ViewXml.Name = UniqueNames.GetName(ViewXmlList, tbl.GetFirstViewName());
                foreach (DefineView_InputControl dvinpctrl in tbl.DefineView_inpCtrlList)
                {
                    Size s;
                    dvinpctrl.Padding = new Padding(0);

                    //dvinpctrl.MainText = "47x100x5400 - 20/100";
                    dvinpctrl.FillDegree = 20;
                    dvinpctrl.StatusText = "";
                    dvinpctrl.StatusBarColor = 0;

                    //dvinpctrl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
                    //GetCurrentView
                    s = new Size(flowLayoutPanel2.Width + 100, 40);
                    flowLayoutPanel2.Controls.Add(dvinpctrl);
                    dvinpctrl.Size = s;

                    _items.Add(dvinpctrl);

                }

            }
        }
    }
}
