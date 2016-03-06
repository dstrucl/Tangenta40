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
using DBTypes;
using LanguageControl;
using CodeTables.TableDocking_Form;

namespace CodeTables
{
    partial class SQLTable
    {
        public void DeleteInputControls()
        {
            int iCol = 0;
            int iCount = Column.Count();

            for (iCol = 0; iCol < iCount; iCol++)
            {
                Column col = Column[iCol];
                if (col.obj is ValSet)
                {
                    ValSet vs = (ValSet)col.obj;
                    vs.defined = false;
                }
                if (!col.IsIdentity)
                {
                    if (col.fKey != null)
                    {
                        col.fKey.fTable.DeleteInputControls();
                    }
                    else
                    {
                        if (col.InputControl != null)
                        {
                            col.InputControl.Dispose();
                            col.InputControl = null;
                        }
                    }
                }
            }
            this.inpCtrlList.Clear();
            if (this.myGroupBox != null)
            {
                this.myGroupBox.DeleteControls();
                this.myGroupBox.Dispose();
                this.myGroupBox = null;
            }
        }

        public void CreateInputControls(SQLTable pPrevTable,
                                        Column fcol, 
                                        string sParentKeys, 
                                        ref List<usrc_InputControl> 
                                        inpCtrlList, 
                                        Object pParentWindow, 
                                        Control pControl,
                                        DBTableControl xDBTables,
                                        bool bReadOnly)
        {
            int iCol = 0;
            int iCount = Column.Count();
            this.pParentTable = pPrevTable;
            this.myGroupBox = new usrc_myGroupBox();
            this.myGroupBox.SelectionButtonVisible = m_SelectionButtonVisible;
            this.myGroupBox.Init(this, fcol, sParentKeys, pParentWindow, pControl, xDBTables, bReadOnly);

            if (pParentWindow.GetType() == typeof(myPanel))
            {
                this.myGroupBox.Left = 5;
                this.myGroupBox.Top = 5;
                Panel pnl = (Panel)pParentWindow;
                pnl.Controls.Add(myGroupBox);
            }
            else if (pParentWindow.GetType() == typeof(usrc_myGroupBox))
            {
                usrc_myGroupBox pParentMyGroupBox = (usrc_myGroupBox)pParentWindow;
                MyControl mctrl = new MyControl(this.myGroupBox);
                pParentMyGroupBox.controls.Add(mctrl);
            }

            for (iCol = 0; iCol < iCount; iCol++)
            {
                Column col = Column[iCol];
                if (!col.IsIdentity)
                {
                    if (col.fKey != null)
                    {
                        string sKey;
                        bool xbReadOnly = bReadOnly;

                        if (col.Style == CodeTables.Column.eStyle.ReadOnlyTable)
                        {
                            xbReadOnly = true;
                        }

                        sKey = sParentKeys + "*" + col.fKey.refInListOfTables.TableName + ">";
                        col.fKey.fTable.CreateInputControls(this, col, sKey, ref inpCtrlList, this.myGroupBox, pControl, xDBTables, xbReadOnly);
                    }
                    else
                    {
                        string sImportExportLine;
                        usrc_InputControl inpCtrl;
                        if (col.IsNumber())
                        {
                            sImportExportLine = sParentKeys + col.Name + ",";
                            inpCtrl = new usrc_InputControl();
                            inpCtrl.Init(this, col, inpCtrlList, sImportExportLine, true,bReadOnly);
                            if (!bReadOnly)
                            {
                                inpCtrl.ObjectChanged += new usrc_InputControl.delegate_ObjectChanged(inpCtrl_ObjectChanged);
                            }
                            col.InputControl = inpCtrl;
                        }
                        else
                        {
                            sImportExportLine = sParentKeys + col.Name + ",";
                            inpCtrl = new usrc_InputControl();
                            inpCtrl.Init(this, col, inpCtrlList, sImportExportLine, false,bReadOnly);
                            if (!bReadOnly)
                            { 
                                inpCtrl.ObjectChanged += new usrc_InputControl.delegate_ObjectChanged(inpCtrl_ObjectChanged);
                            }
                            col.InputControl = inpCtrl;
                        }
                        MyControl mctrl = new MyControl(inpCtrl);
                        this.myGroupBox.controls.Add(mctrl);
                    }
                }
            }

            if (pPrevTable!=null)
            { 
                if (pParentWindow is usrc_myGroupBox)
                {
                    if (!bReadOnly)
                    {
                        this.myGroupBox.Unique_parameter_exist += myGroupBox_Unique_parameter_exist;
                        this.myGroupBox.bUnique_parameter_exist = true;
                        this.myGroupBox.RowReferenceFromTable_Check_NoChangeToOther += myGroupBox_RowReferenceFromTable_Check_NoChangeToOther; 
                        this.myGroupBox.usrc_myGroupBox_IndexChanged += new usrc_myGroupBox.delegate_IndexChanged(myGroupBox_usrc_myGroupBox_IndexChanged);
                        this.myGroupBox.usrc_InputControl_ObjectChanged += new usrc_myGroupBox.delegate_ObjectChanged(myGroupBox_usrc_InputControl_ObjectChanged);
                    }
                }
                //if (pParentWindow is Panel)
                //{
                //    if (!bReadOnly)
                //    {
                //        this.myGroupBox.Unique_parameter_exist += myGroupBox_Unique_parameter_exist;
                //        this.myGroupBox.bUnique_parameter_exist = true;
                //        this.myGroupBox.RowReferenceFromTable_Check_NoChangeToOther += myGroupBox_RowReferenceFromTable_Check_NoChangeToOther; 
                //        //this.myGroupBox.usrc_myGroupBox_IndexChanged += new usrc_myGroupBox.delegate_IndexChanged(myGroupBox_usrc_myGroupBox_IndexChanged);
                //        //this.myGroupBox.usrc_InputControl_ObjectChanged += new usrc_myGroupBox.delegate_ObjectChanged(myGroupBox_usrc_InputControl_ObjectChanged);
                //    }
                //}
            }
        }

        void myGroupBox_Unique_parameter_exist(SQLTable tbl, Column col, DataTable dt,object value, ref bool bHandled)
        {
            if (pParentTable != null)
            {
                if (pParentTable.myGroupBox!=null)
                {
                    pParentTable.myGroupBox.Unique_parameter_exist_Dialog_EventTrigger(tbl, col, dt, value,ref bHandled);
                }
            }
        }

        bool myGroupBox_RowReferenceFromTable_Check_NoChangeToOther(SQLTable pSQL_Table, List<usrc_RowReferencedFromTable> usrc_RowReferencedFromTable_List, ID_v id_v, ref bool bCancelDialog, ref ltext Instruction)
        {
            if (pParentTable != null)
            {
                return pParentTable.myGroupBox.SetEvent_RowReferenceFromTable_Check_NoChangeToOther(pSQL_Table, usrc_RowReferencedFromTable_List, id_v, ref bCancelDialog, ref Instruction);
            }
            else
            {
                bCancelDialog = false;
                return false;
            }
        }


     
        void myGroupBox_usrc_InputControl_ObjectChanged(SQLTable tbl, usrc_InputControl InputControl)
        {
            if (pParentTable != null)
            {
                pParentTable.myGroupBox.SetEvent_ObjectChanged(tbl, InputControl);
                this.myGroupBox.Changed_up = AtLeastOneInputControlChanged();
            }
            else
            {
                this.myGroupBox.Changed_up = AtLeastOneInputControlChanged();
            }
        }

        public void myGroupBox_usrc_myGroupBox_IndexChanged(SQLTable tbl,usrc_myGroupBox xmyGroupBox)
        {
            if (pParentTable != null)
            {
                pParentTable.myGroupBox.SetEvent_IndexChanged(tbl, xmyGroupBox);
                this.myGroupBox.Changed_up = AtLeastOneInputControlChanged();
            }
            else
            {
                this.myGroupBox.Changed_up = AtLeastOneInputControlChanged();
            }
        }


        public void inpCtrl_ObjectChanged(SQLTable tbl,usrc_InputControl InputControl)
        {
            myGroupBox.SetEvent_ObjectChanged(tbl,InputControl);
            this.myGroupBox.Changed_up = AtLeastOneInputControlChanged();
            if (pParentTable != null)
            {
                pParentTable.myGroupBox.SetEvent_ObjectChanged(tbl, InputControl);
            }

        }

        internal bool AtLeastOneInputControlChanged()
        {
            foreach (Column col in Column)
            {
                if (col.InputControl != null)
                {
                    if (col.InputControl.Changed)
                    {
                        return true;
                    }
                }
                else
                {
                    if (col.fKey != null)
                    {
                        if (col.fKey.fTable != null)
                        {
                            if (col.fKey.fTable.myGroupBox.Changed_up)
                            {
                                return true;
                            }
                            else
                            {
                                if (!col.fKey.fTable.myGroupBox.usrc_lbl.Null_Selected)
                                {
                                    if (col.fKey.fTable.AtLeastOneInputControlChanged())
                                    {
                                        return true;
                                    }
                                }
                                else
                                {
                                    //Null selected
                                    if (col.fKey.fTable.myGroupBox.DifferentToIndexInitialValue())
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (this.myGroupBox != null)
            {
                return this.myGroupBox.DifferentToIndexInitialValue();
            }
            return false;
        }

        public void RepositionInputControls(usrc_myGroupBox pmyGroupBox, ref MySize size, int Level)
        {
            int LeftMarginGroupBox = 7;
            int RightMarginGroupBox = 7;
            int TopMarginGroupBox = 10;
            int StartTopMarginGroupBox = 40;
            int BottomMarginGroupBox = 2;

            int LeftMarginInputBox = 3;
            int RightMarginInputBox = 3;
            int TopMarginInputBox = 40; 
            int BottomMarginInputBox = 4;




            int cxMax = 0;

            int x = 0;
            int y = 0;

            if (Level >= ColorList.Count)
            {
                Level = ColorList.Count - 1;
            }
            pmyGroupBox.BackColor = ColorList[Level];
            if (pmyGroupBox.bExpanded)
            {
                foreach (MyControl ctrl in pmyGroupBox.controls)
                {

                    if (ctrl.Control.GetType() == typeof(usrc_myGroupBox))
                    {
                        usrc_myGroupBox pGrpBox = (usrc_myGroupBox)ctrl.Control;
                        MySize xsize = new MySize();
                        if (y == 0)
                        {
                            y = y + StartTopMarginGroupBox;
                        }
                        else
                        {
                            y = y + TopMarginGroupBox;
                        }
                        pGrpBox.Top = y;
                        pGrpBox.Left = LeftMarginGroupBox;
                        pGrpBox.Visible = true;

                        RepositionInputControls(pGrpBox, ref xsize, Level + 1);

                        y = y + xsize.cy;


                        pGrpBox.Width = xsize.cx;
                        pGrpBox.Height = xsize.cy;

                        if (cxMax < pGrpBox.Width)
                        {
                            cxMax = pGrpBox.Width;
                        }



                    }
                    else if (ctrl.Control.GetType() == typeof(usrc_InputControl))
                    {

                        usrc_InputControl pInputControl = (usrc_InputControl)ctrl.Control;

                        x = LeftMarginInputBox; // ColPosition[iCount % iColumns];

                        pInputControl.Left = x;

                        if (cxMax < (x + pInputControl.Width + RightMarginInputBox))
                        {
                            cxMax = (x + pInputControl.Width + RightMarginInputBox);
                        }

                        y = y + TopMarginInputBox;
                        pInputControl.Top = y;
                        pInputControl.Show();
                        TopMarginInputBox = 8;
                        y = y + pInputControl.Height + BottomMarginInputBox;
                    }
                    else
                    {
                        MessageBox.Show("Program Error in RepositionInputControls(MyGroupBox pmyGroupBox)");
                    }
                    //iCount++;
                }
                size.cx = LeftMarginGroupBox + cxMax + RightMarginGroupBox;
                size.cy = y + BottomMarginGroupBox;
            }
            else
            {
                foreach (MyControl ctrl in pmyGroupBox.controls)
                {

                    if (ctrl.Control.GetType() == typeof(usrc_myGroupBox))
                    {
                        usrc_myGroupBox pGrpBox = (usrc_myGroupBox)ctrl.Control;
                        pGrpBox.Visible = false;
                    }
                    else if (ctrl.Control.GetType() == typeof(usrc_InputControl))
                    {

                        usrc_InputControl pInputControl = (usrc_InputControl)ctrl.Control;
                        pInputControl.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Program Error in RepositionInputControls(MyGroupBox pmyGroupBox)");
                    }
                    //iCount++;
                }
                pmyGroupBox.Height = 38;
                size.cx = pmyGroupBox.Width;
                size.cy = pmyGroupBox.Height;
            }
        }
    }
}

