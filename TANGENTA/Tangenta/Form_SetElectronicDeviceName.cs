using CodeTables;
using DBConnectionControl40;
using DBTypes;
using NavigationButtons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TangentaDB;
using UniqueControlNames;

namespace Tangenta
{
    public partial class Form_SetElectronicDeviceName : Form
    {
        private UniqueControlName uctrln = new UniqueControlName();
        private bool bclose = false;
        private ID m_Office_ID = null;
        private myOrg_Office m_myOrg_Office = null;

        private DataTable tElectronicDevice = null;
        private DataTable tOffice = null;

        private NavigationButtons.Navigation nav = null;


        public Form_SetElectronicDeviceName( NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;
            usrc_NavigationButtons1.Init(nav);
            lng.s_ElectronicDevice_ID.Text(lbl_ElectronicDevice_Name);
            lng.s_ElectronicDevice_Description.Text(lbl_ElectronicDevice_Description);
            lng.s_ComputerName.Text(lbl_ComputerName);
            lng.s_ComputerUserName.Text(lbl_ComputerUsername);
            lng.s_ComputerMAC_address.Text(lbl_MAC_address);
            lng.s_ComputerIP_address.Text(lbl_IP_address);
            txt_ComputerName.Text = TangentaDB.f_Atom_ComputerName.Get();
            txt_ComputerUserName.Text = TangentaDB.f_Atom_ComputerUsername.Get();
            txt_MAC_address.Text = TangentaDB.f_Atom_MAC_address.Get();
            txt_IP_address.Text = TangentaDB.f_Atom_IP_address.Get();
        }

        private bool do_OK()
        {
            if (tElectronicDevice!=null)
            {
                if (tElectronicDevice.Rows.Count > 0)
                {
                    this.Close();
                    DialogResult = DialogResult.OK;
                    return true;
                }
                else
                {
                    XMessage.Box.Show(this, lng.s_You_Must_Write_This_ElectronicDevice_into_DataBase, MessageBoxIcon.Warning);
                }
            }
            return false;
        }

        private void do_Cancel()
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }


        private void Form_SetElectronicDeviceName_Load(object sender, EventArgs e)
        {
            if (bclose)
            {
                DialogResult = DialogResult.Abort;
                this.Close();
            }
            if (tElectronicDevice!=null)
            {
                tElectronicDevice.Dispose();
                tElectronicDevice = null;
            }
            tElectronicDevice = new DataTable();
            if (!Init())
            {
                this.Close();
                DialogResult = DialogResult.Abort;
            }
        }


        private bool Init()
        {
            if (ID.Validate(myOrg.ID))
            {
                dgvx_Office.DataSource = null;
                if (tOffice==null)
                {
                    tOffice = new DataTable();
                }
                else
                {
                    tOffice.Columns.Clear();
                }

                this.dgvx_Office.SelectionChanged -= new System.EventHandler(this.dgvx_Office_SelectionChanged);

                if (f_Office_Data.Get(null, ref tOffice))
                {
                    dgvx_Office.DataSource = tOffice;
                    DBSync.DBSync.DB_for_Tangenta.t_Office_Data.SetVIEW_DataGridViewImageColumns_Headers(dgvx_Office,DBSync.DBSync.DB_for_Tangenta.m_DBTables);
                    dgvx_Office.ClearSelection();
                    this.dgvx_Office.SelectionChanged += new System.EventHandler(this.dgvx_Office_SelectionChanged);
                    if (myOrg.m_myOrg_Office != null)
                    {
                        if (dgvx_Office.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow dgvr in dgvx_Office.Rows)
                            {
                                ID id = new ID(dgvr.Cells["Office_Data_$_office_$$ID"].Value);
                                if (ID.Validate(id))
                                {
                                    if (ID.Validate(myOrg.m_myOrg_Office.ID))
                                    {
                                        if (id.Equals(myOrg.m_myOrg_Office.ID))
                                        {
                                            dgvr.Selected = true;
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                        dgvx_Office.Rows[0].Selected = true;
                        return true;
                    }
                    else
                    {
                        if (dgvx_Office.Rows.Count > 0)
                        {
                            dgvx_Office.Rows[0].Selected = true;
                        }
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:Tangenta:Form_SetElectronicDeviceName:Init:myOrg.ID is not valid!");
                return false;
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
                            nav.eExitResult = evt;
                            if (!do_OK())
                            {
                                nav.eExitResult = Navigation.eEvent.NOTHING;

                            }
                            break;
                        case NavigationButtons.Navigation.eEvent.CANCEL:
                            nav.eExitResult = evt;
                            do_Cancel();
                            break;
                    }
                    break;
                case NavigationButtons.Navigation.eButtons.PrevNextExit:
                    switch (evt)
                    {
                        case NavigationButtons.Navigation.eEvent.NEXT:
                            nav.eExitResult = evt;
                            if (!do_OK())
                            {
                                nav.eExitResult = Navigation.eEvent.NOTHING;
                            }
                            break;
                        case NavigationButtons.Navigation.eEvent.PREV:
                            nav.eExitResult = evt;
                            do_Cancel();
                            break;
                        case NavigationButtons.Navigation.eEvent.EXIT:
                            nav.eExitResult = evt;
                            do_Cancel();
                            break;
                    }
                    break;
            }

        }

        private void dgvx_Office_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection dgvCellCollection = this.dgvx_Office.SelectedCells;
            if (dgvCellCollection.Count >= 1)
            {
                m_Office_ID = tf.set_ID(dgvCellCollection[0].OwningRow.Cells["Office_Data_$_office_$$ID"].Value);
                Show_Office_Electronic_Devices();
            }
        }

        private void Show_Office_Electronic_Devices()
        {
            if (ID.Validate(m_Office_ID))
            {
                m_myOrg_Office = myOrg.Find_Office(m_Office_ID);
                if (m_myOrg_Office != null)
                {
                    if (m_myOrg_Office.Name_v != null)
                    {
                        this.txt_Office.Text = m_myOrg_Office.Name_v.v;
                    }
                    if (m_myOrg_Office.ShortName_v != null)
                    {
                        this.txt_Office_ShortName.Text = m_myOrg_Office.ShortName_v.v;
                    }
                    if (tElectronicDevice == null)
                    {
                        tElectronicDevice = new DataTable();
                    }
                    else
                    {
                        tElectronicDevice.Columns.Clear();
                    }
                    dgvx_ElectronicDevice.DataSource = null;
                    if (f_ElectronicDevice.Get(m_myOrg_Office.ID,ref tElectronicDevice))
                    {
                        if (tElectronicDevice.Rows.Count>0)
                        {
                            lng.s_btn_UpdateElectronicDevice.Text(btn_Write);
                        }
                        else
                        {
                            lng.s_btn_WriteInDBElectronicDevice.Text(btn_Write);
                        }
                        dgvx_ElectronicDevice.DataSource = tElectronicDevice;
                        DBSync.DBSync.DB_for_Tangenta.t_Atom_ElectronicDevice.SetVIEW_DataGridViewImageColumns_Headers(dgvx_ElectronicDevice, DBSync.DBSync.DB_for_Tangenta.m_DBTables);
                    }
                }
            }
        }

        private void btn_Write_Click(object sender, EventArgs e)
        {
            string xElectronicDevice_Name = txt_ElectronicDevice_Name.Text;
            string xElectronicDevice_Description = txt_ElectronicDevice_Description.Text;
            if (xElectronicDevice_Description.Length==0)
            {
                xElectronicDevice_Description = null;
            }
            if (xElectronicDevice_Name.Length>0)
            {
                ID xAtom_ElectronicDevice_ID = null;
                if (f_ElectronicDevice.Get(m_myOrg_Office.ID, xElectronicDevice_Name, xElectronicDevice_Description,ref xAtom_ElectronicDevice_ID))
                {
                    if (ID.Validate(xAtom_ElectronicDevice_ID))
                    {
                        myOrg.Get();
                        Show_Office_Electronic_Devices();
                    }
                }
            }
        }
    }
}
