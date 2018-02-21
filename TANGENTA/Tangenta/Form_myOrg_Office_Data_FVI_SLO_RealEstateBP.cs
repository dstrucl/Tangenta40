// Copyright (c) 2011 rubicon IT GmbH
using TangentaTableClass;
using DBTypes;
using TangentaDB;
using LanguageControl;
using CodeTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NavigationButtons;
using UniqueControlNames;

namespace Tangenta
{
    public partial class Form_myOrg_Office_Data_FVI_SLO_RealEstateBP : Form
    {
        UniqueControlName uctrln = new UniqueControlName();
        private bool bclose = false;
        string ColumnToOrderBy = "FVI_SLO_RealEstateBP_$$Community asc";
        long m_Office_Data_ID = -1;
        SQLTable tbl_FVI_SLO_RealEstateBP = null;
        NavigationButtons.Navigation nav = null;


        public Form_myOrg_Office_Data_FVI_SLO_RealEstateBP(long xOffice_Data_ID,NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;
            usrc_NavigationButtons1.Init(nav);
            m_Office_Data_ID = xOffice_Data_ID;
            tbl_FVI_SLO_RealEstateBP = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(FVI_SLO_RealEstateBP)));
            this.Text = lng.s_Edit_Office_Data_FVI_SLO_RealEstateBP.s;
            this.usrc_EditTable1.Title = lng.s_Edit_Office_Data_FVI_SLO_RealEstateBP.s;
            string selection =    @"FVI_SLO_RealEstateBP_$_officed_$_office_$$Name,
                                    FVI_SLO_RealEstateBP_$_officed_$_office_$$ShortName,
                                    FVI_SLO_RealEstateBP_$$BuildingNumber,
                                    FVI_SLO_RealEstateBP_$$BuildingSectionNumber,
                                    FVI_SLO_RealEstateBP_$$Community,
                                    FVI_SLO_RealEstateBP_$$CadastralNumber,
                                    FVI_SLO_RealEstateBP_$$ValidityDate,
                                    FVI_SLO_RealEstateBP_$$ClosingTag,
                                    FVI_SLO_RealEstateBP_$$SoftwareSupplier_TaxNumber,
                                    FVI_SLO_RealEstateBP_$$PremiseType,
                                    ID";
            if (usrc_EditTable1.Init(DBSync.DBSync.DB_for_Tangenta.m_DBTables, tbl_FVI_SLO_RealEstateBP, selection, ColumnToOrderBy, false, " where FVI_SLO_RealEstateBP_$_officed_$$ID = " + m_Office_Data_ID.ToString() + " ", null, false,nav))
            {
                if (usrc_EditTable1.RowsCount > 0)
                {
                    usrc_EditTable1.AllowUserToAddNew = false;
                }
                else
                {
                    usrc_EditTable1.FillInitialDataAndSetInputControls(null);
                    usrc_EditTable1.AllowUserToAddNew = true;
                }
            }
            else
            {
                bclose = true;
            }

        }

        private bool do_OK()
        {
            if (usrc_EditTable1.Changed)
            {
                usrc_EditTable1.Save();
            }
            this.Close();
            DialogResult = DialogResult.OK;
            return true;
        }
        private void do_Cancel()
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        #region Fill ReadOnlyDaTa

        private void usrc_EditTable1_FillTable(SQLTable m_tbl)
        {
            if (m_tbl.TableName.ToLower().Equals("office_data"))
            {
                string Err = null;
                m_tbl.FillDataInputControl(DBSync.DBSync.DB_for_Tangenta.m_DBTables.m_con, uctrln, m_Office_Data_ID, true, ref Err);
            }
        }

        private void usrc_EditTable1_after_New(SQLTable m_tbl, bool bRes)
        {
            usrc_EditTable1.FillInitialData();
        }

        #endregion


        private void Form_myOrg_Offices_Edit_Load(object sender, EventArgs e)
        {
            if (bclose)
            {
                DialogResult = DialogResult.Abort;
                this.Close();
            }
        }

        private void usrc_EditTable1_after_InsertInDataBase(SQLTable m_tbl, long ID, bool bRes)
        {
            if (bRes)
            { 
                usrc_EditTable1.AllowUserToAddNew = false;
            }
        }

        private void usrc_NavigationButtons1_ButtonPressed(NavigationButtons.Navigation.eEvent evt)
        {
            switch (nav.m_eButtons)
            {
                case NavigationButtons.Navigation.eButtons.OkCancel:
                    switch (evt)
                    {
                        case NavigationButtons.Navigation.eEvent.OK:
                            if (do_OK())
                            {
                                nav.eExitResult = evt;
                            }
                            break;
                        case NavigationButtons.Navigation.eEvent.CANCEL:
                            do_Cancel();
                            nav.eExitResult = evt;
                            break;
                    }
                    break;
                case NavigationButtons.Navigation.eButtons.PrevNextExit:
                    switch (evt)
                    {
                        case NavigationButtons.Navigation.eEvent.NEXT:
                            if (do_OK())
                            {
                                nav.eExitResult = evt;
                            }
                            break;
                        case NavigationButtons.Navigation.eEvent.PREV:
                            do_Cancel();
                            nav.eExitResult = evt;
                            break;
                        case NavigationButtons.Navigation.eEvent.EXIT:
                            do_Cancel();
                            nav.eExitResult = evt;
                            break;
                    }
                    break;
            }

        }

        private void usrc_EditTable1_SetInputControlProperties(Column col, object obj)
        {
            if (nav.m_eButtons == Navigation.eButtons.PrevNextExit)
            {
                if (col.ownerTable.TableName.Equals("FVI_SLO_RealEstateBP"))
                {
                    if (col.Name.Equals("BuildingNumber"))
                    {
                        col.InputControl.SetValue(1);
                    }
                    else if (col.Name.Equals("BuildingSectionNumber"))
                    {
                        col.InputControl.SetValue(1);
                    }
                    else if (col.Name.Equals("Community"))
                    {
                        col.InputControl.SetValue(lng.s_Community1.s);
                    }
                    else if (col.Name.Equals("CadastralNumber"))
                    {
                        col.InputControl.SetValue(1738);
                    }
                    else if (col.Name.Equals("ValidityDate"))
                    {
                        col.InputControl.SetValue(new DateTime(2200,1,1));
                    }
                    else if (col.Name.Equals("ClosingTag"))
                    {
                        col.InputControl.SetValue("Z");
                    }
                    else if (col.Name.Equals("SoftwareSupplier_TaxNumber"))
                    {
                        col.InputControl.SetValue("89304489");
                    }
                    else if (col.Name.Equals("PremiseType"))
                    {
                        col.InputControl.SetValue("C");
                    }
                }
            }
        }
    }
}
