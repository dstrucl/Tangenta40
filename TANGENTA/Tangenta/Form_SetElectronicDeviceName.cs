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
using UniqueControlNames;

namespace Tangenta
{
    public partial class Form_SetElectronicDeviceName : Form
    {
        private UniqueControlName uctrln = new UniqueControlName();
        private bool bclose = false;
        private ID m_RealEstateBP_ID = null;
        private DataTable tElectronicDevice = null;
        private NavigationButtons.Navigation nav = null;


        public Form_SetElectronicDeviceName(ID xRealEstateBP_ID, NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;
            usrc_NavigationButtons1.Init(nav);
            m_RealEstateBP_ID = xRealEstateBP_ID;
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
