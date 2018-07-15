using CodeTables;
using DBConnectionControl40;
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
            this.Close();
            DialogResult = DialogResult.OK;
            return true;
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

                if (f_Office_Data.Get(null, ref tOffice))
                {
                    dgvx_Office.DataSource = tOffice;
                    DBSync.DBSync.DB_for_Tangenta.t_Office_Data.Set_DataGridViewImageColumns_Headers(dgvx_Office);
                    return true;
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
    }
}
