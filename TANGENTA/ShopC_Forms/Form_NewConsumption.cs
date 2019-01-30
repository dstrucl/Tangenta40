using HUDCMS;
using LanguageControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TangentaDB;
using TangentaProperties;

namespace ShopC_Forms
{
    public partial class Form_NewConsumption : Form
    {
        private HUDCMS.HelpWizzardTagDC tagDCTop = null;
        private HUDCMS.HelpWizzardTagDC tagDC_DocType_Invoice = null;
        private HUDCMS.HelpWizzardTagDC tagDC_DocType_ProformaInvoice = null;
        private HUDCMS.HelpWizzardTagDC tagDC_EmptyDB_true = null;
        private HUDCMS.HelpWizzardTagDC tagDC_EmptyDB_false = null;
        private HUDCMS.HelpWizzardTagDC tagDCBottom = null;

        internal HUDCMS.HelpWizzardTagDC[] TagDCs = null;



        private Control parentControl = null;

        private ConsumptionMan consM = null;

        public f_Consumption.eConsumptionType eNewConsumptionResult = f_Consumption.eConsumptionType.UNKNOWN;

        public int FinancialYear = -1;

        //private Form_NewConsumption_WizzardForHelp frm_NewConsumption_WizzardForHelp = null;

        private bool IsWriteOff
        {
            get
            {
                if (consM != null)
                {
                    return consM.IsWriteOff;
                }
                else
                {
                    return false;
                }              
            }
        }

        private bool IsOwnUse
        {
            get
            {
                if (consM != null)
                {
                    return consM.IsOwnUse;
                }
                else
                {
                    return false;
                }
            }
        }

        private bool IsAll
        {
            get
            {
                if (consM != null)
                {
                    return consM.IsAll;
                }
                else
                {
                    return false;
                }
            }
        }

        public Form_NewConsumption(Control xparent,ConsumptionMan xconsM, string xsumtext)
        {
            InitializeComponent();
            parentControl = xparent;
            consM = xconsM;
            Init(xsumtext);
            lng.s_New_Consumption.Text(this);
            lng.s_btn_New_Empty_OwnUse.Text(this.btn_New_Empty_OwnUse);
            lng.s_btn_New_Empty_WriteOff.Text(this.btn_New_Empty_WriteOff);
        }

        private void Init(string xsumText)
        {
            string sdraft = "";
            string sNumber = null;


            sNumber = consM.ConsE.CurrentCons.FinancialYear.ToString() + "-" + consM.ConsE.CurrentCons.NumberInFinancialYear.ToString();

            string sInvoiceNumber = null;
            int ItemsCount = 0;
            string sumText = xsumText;
            ItemsCount = consM.ConsE.CurrentCons.ItemsCount(consM.ConsumptionTyp);
            if (consM.ConsE.CurrentCons.bDraft)
            {
                sdraft = lng.s_Draft.s;
                sInvoiceNumber = "(" + sdraft + " št.:" + consM.ConsE.CurrentCons.FinancialYear.ToString() + "-" + consM.ConsE.CurrentCons.DraftNumber.ToString()
                                    + " " + lng.s_Total.s + " = " + sumText + ")";
            }
            else
            {
                sInvoiceNumber = "(" + sdraft + " št.:" + consM.ConsE.CurrentCons.FinancialYear.ToString() + "-" + consM.ConsE.CurrentCons.NumberInFinancialYear.ToString()
                + " " + lng.s_Total.s + " = " + sumText + ")";
            }

            
            lng.s_New_Consumption.Text(this.btn_New_Empty_OwnUse);
            

            if (ItemsCount == 0)
            {
                this.btn_Cancel.Top = this.btn_New_Empty_OwnUse.Bottom + 20;
                this.Height = this.btn_Cancel.Bottom + 50;
            }
            else
            {
            }
            SetNewFormTag();
        }
        private void btn_New_Empty_OwnUse_Click(object sender, EventArgs e)
        {
            eNewConsumptionResult = f_Consumption.eConsumptionType.OwnUse;
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void btn_New_Empty_WriteOff_Click(object sender, EventArgs e)
        {
            eNewConsumptionResult = f_Consumption.eConsumptionType.WriteOff;
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }


        private void SetNewFormTag()
        {

            tagDCTop = new HelpWizzardTagDC( "Top", "", null, null);

            tagDC_DocType_Invoice = new HelpWizzardTagDC( "DocType", "", "enum", "Invoice");
            tagDC_DocType_ProformaInvoice = new HelpWizzardTagDC( "DocType", "", "enum", "ProformaInvoice");

            tagDC_EmptyDB_true = new HelpWizzardTagDC( "DBEmpty", "", "bool", "true");
            tagDC_EmptyDB_false = new HelpWizzardTagDC( "DBEmpty", "", "bool", "false");


            tagDCBottom = new HelpWizzardTagDC( "Bottom", "", null, null);


            TagDCs = new HUDCMS.HelpWizzardTagDC[] {
            tagDCTop,
            tagDC_DocType_Invoice,
            tagDC_DocType_ProformaInvoice,
            tagDC_EmptyDB_true,
            tagDC_EmptyDB_false,
            tagDCBottom
            };

            HUDCMS.HelpWizzardTag hlpwizTag = new HelpWizzardTag(TagDCs, null,null);
            hlpwizTag.DefaultControlWidth = this.Width;
            hlpwizTag.DefaultControlHeight = this.Height;



            long numberOfAll = -1;
            string[] sTagConditions = null;

            string sxmlfilesuffix = "";
            string sNewTag = GetStringTag(ref numberOfAll, ref sTagConditions, ref sxmlfilesuffix);

            hlpwizTag.FileSuffix = sNewTag;
            hlpwizTag.XmlFileSuffix = sxmlfilesuffix;
            hlpwizTag.ShowWizzard = HelpWizzardShow;

            this.Tag = hlpwizTag;
        }

        internal string GetStringTag(ref long numberOfAll, ref string[] sTagConditions, ref string sXMLFiletag)
        {
            string sNewTag = "_";
            sXMLFiletag = "_";
            //List<string> tag_conditions = new List<string>();
            //if (consM.IsDocInvoice)
            //{
            //    numberOfAll = fs.NumberOInvoicesInDatabase();
            //    sNewTag += "i";
            //    sXMLFiletag += "i";
            //    tag_conditions.Add(tagDC_DocType_Invoice.NamedCondition);
            //}
            //else if (consM.IsDocProformaInvoice)
            //{
            //    numberOfAll = fs.NumberOfProformaInvoicesInDatabase();
            //    sNewTag += "p";
            //    sXMLFiletag += "p";
            //    tag_conditions.Add(tagDC_DocType_ProformaInvoice.NamedCondition);
            //}
            //if (numberOfAll < 0)
            //{
            //    LogFile.Error.Show("ERROR:Tangenta:Form:SetNewFormTag:  numberOfAll invoices or proforma invoices < 0 !");
            //}
            //else if (numberOfAll == 0)
            //{
            //    sNewTag += "Z";
            //    sXMLFiletag += "Z";
            //    tag_conditions.Add(tagDC_EmptyDB_true.NamedCondition);
            //}
            //else if (numberOfAll > 0)
            //{
            //    sNewTag += "N";
            //    sXMLFiletag += "N";
            //    tag_conditions.Add(tagDC_EmptyDB_false.NamedCondition);
            //}

            //int iconditions_count = tag_conditions.Count;
            //sTagConditions = new string[iconditions_count];
            //for (int i = 0; i < iconditions_count; i++)
            //{
            //    sTagConditions[i] = tag_conditions[i];
            //}
            return sNewTag;
        }

        public void HelpWizzardShow(Control ctrl, MyControl root_ctrl,string xheader, string xstyleFile)
        {
            //if (frm_NewConsumption_WizzardForHelp != null)
            //{
            //    if (frm_NewConsumption_WizzardForHelp.IsDisposed)
            //    {
            //        frm_NewConsumption_WizzardForHelp = null;
            //    }

            //}
            //if (frm_NewConsumption_WizzardForHelp == null)
            //{
            //    frm_NewConsumption_WizzardForHelp = new Form_NewConsumption_WizzardForHelp(ctrl, root_ctrl, xheader, xstyleFile);
            //    frm_NewConsumption_WizzardForHelp.Owner = this;
            //}
            //frm_NewConsumption_WizzardForHelp.Show();
        }

       
    }
}
