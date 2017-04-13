using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TangentaDB;
using DBTypes;

namespace TangentaPrint
{
    public partial class usrc_TangentaPrint : UserControl
    {

        public usrc_TangentaPrint()
        {
            InitializeComponent();
        }



        private void btn_Printers_Click(object sender, EventArgs e)
        {
            SelectPrinters();
        }

        private void SelectPrinters()
        {
            NavigationButtons.Navigation xnav = new NavigationButtons.Navigation();
            xnav.bDoModal = true;
            xnav.m_eButtons = NavigationButtons.Navigation.eButtons.OkCancel;

            Form_DefinePrinters frm_select_printers = new Form_DefinePrinters(ref PrintersList.dt,xnav,this);
            xnav.ChildDialog = frm_select_printers;
            xnav.ShowDialog();
        }

    }
}
