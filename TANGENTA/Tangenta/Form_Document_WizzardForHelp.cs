using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tangenta
{
    public partial class Form_Document_WizzardForHelp : Form
    {
        int istep_DocInvoice = 0;
        int istep_m_usrc_InvoiceTable_Visible = 0;
        int istep_Head = 0;
        int istep_Shop = 0;

        private bool bRun = false;
        private Control control_ForWizzard = null;
        private Form_Document form_document = null;



        public Form_Document_WizzardForHelp(Control ctrl)
        {
            InitializeComponent();
            control_ForWizzard = ctrl;
        }

        private void bn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.Cancel;
        }

        private void InitStep()
        {
            istep_DocInvoice = 0;
            istep_m_usrc_InvoiceTable_Visible = 0;
            istep_Head = 0;
            istep_Shop = 0;
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (!bRun)
            {
                this.timer1.Interval = Convert.ToInt32(this.numericUpDown1.Value);
                this.timer1.Enabled = true;
                btn_Start.Text = "Stop";
                bRun = true;
            }
            else
            {
                InitStep();
                this.timer1.Enabled = false;
                btn_Start.Text = "Start";
                bRun = false;
            }
        }

        private bool SetStep()
        {
            if (istep_DocInvoice < 2)
            {
                if (istep_m_usrc_InvoiceTable_Visible < 2)
                {
                    if (istep_Head < 2)
                    {
                        if (istep_Shop < 7)
                        {
                            istep_Shop++;
                            return true;
                        }
                        else
                        {
                            istep_Shop = 0;
                        }
                        istep_Head++;
                        return true;
                    }
                    else
                    {
                        istep_Head=0;
                    }
                    istep_m_usrc_InvoiceTable_Visible++;
                    return true;
                }
                else
                {
                    istep_m_usrc_InvoiceTable_Visible = 0;
                }
                istep_DocInvoice++;
                return true;
            }
            else
            {
                istep_DocInvoice = 0;
                return false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            WriteStep();
            this.Refresh();
            ExecuteStep();
            timer1.Enabled = true;
            if (SetStep())
            {
                return;
            }
            else
            {
                bRun = false;
                timer1.Enabled = false;
                btn_Start.Text = "Start";
                InitStep();
            }
        }

        private void WriteStep()
        {
            switch (istep_DocInvoice)
            {
                case 0:
                    txt_DocumentType.Text = "0:ProformaInvoice";
                    break;
                case 1:
                    txt_DocumentType.Text = "1:Invoice";
                    break;
            }
            switch (istep_m_usrc_InvoiceTable_Visible)
            {
                case 0:
                    txt_InvoiceTableVisible.Text = "0:Visible";
                    break;
                case 1:
                    txt_InvoiceTableVisible.Text = "1:Hidden";
                    break;
            }

            switch (istep_Head)
            {
                case 0:
                    txt_InvoiceHeadVisible.Text = "0:Visible";
                    break;
                case 1:
                    txt_InvoiceHeadVisible.Text = "1:Hidden";
                    break;
            }
            switch (istep_Shop)
            {
                case 0:
                    txt_ShopsVisible.Text = "0: A";
                    break;
                case 1:
                    txt_ShopsVisible.Text = "1: B";
                    break;
                case 2:
                    txt_ShopsVisible.Text = "2: C";
                    break;
                case 3:
                    txt_ShopsVisible.Text = "3: A,B";
                    break;
                case 4:
                    txt_ShopsVisible.Text = "4: A,C";
                    break;
                case 5:
                    txt_ShopsVisible.Text = "5: B,C";
                    break;
                case 6:
                    txt_ShopsVisible.Text = "6: A,B,C";
                    break;
            }
        }

        private void ExecuteStep()
        {
            if (form_document != null)
            {
                switch (istep_DocInvoice)
                {
                    case 0:
                        form_document.WizzardShow_DocInvoice(Program.const_DocProformaInvoice);
                        break;
                    case 1:
                        form_document.WizzardShow_DocInvoice(Program.const_DocInvoice);
                        break;
                }
                switch (istep_m_usrc_InvoiceTable_Visible)
                {
                    case 0:
                        form_document.WizzardShow_InvoiceTable_Visible(true);
                        break;
                    case 1:
                        form_document.WizzardShow_InvoiceTable_Visible(false);
                        break;
                }

                switch (istep_Head)
                {
                    case 0:
                        form_document.WizzardShow_usrc_Invoice_Head_Visible(true);
                        break;
                    case 1:
                        form_document.WizzardShow_usrc_Invoice_Head_Visible(false);
                        break;
                }
                switch (istep_Shop)
                {
                    case 0:
                        form_document.WizzardShow_ShopsVisible("A");
                        break;
                    case 1:
                        form_document.WizzardShow_ShopsVisible("B");
                        break;
                    case 2:
                        form_document.WizzardShow_ShopsVisible("C");
                        break;
                    case 3:
                        form_document.WizzardShow_ShopsVisible("AB");
                        break;
                    case 4:
                        form_document.WizzardShow_ShopsVisible("AC");
                        break;
                    case 5:
                        form_document.WizzardShow_ShopsVisible("BC");
                        break;
                    case 6:
                        form_document.WizzardShow_ShopsVisible("ABC");
                        break;
                }
            }
        }

        private void Form_Document_WizzardForHelp_Load(object sender, EventArgs e)
        {
            if (control_ForWizzard is Form_Document)
            {
                form_document = (Form_Document)control_ForWizzard;
            }
            else
            {
                MessageBox.Show("WARNING:Control of type " + control_ForWizzard.GetType().ToString() + " not implemented in Wizzard");
                this.Close();
                DialogResult = DialogResult.Abort;
            }
        }
    }
}

