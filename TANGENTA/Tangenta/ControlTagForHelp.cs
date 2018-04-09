using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangenta
{
    public class ControlTagForHelp
    {
        private bool bmultiuser = false;

        private string controlnameextension = null;

        public string ControlNameExtension
        {
            get { return controlnameextension; }
        }
        public bool bMultiUser
        {
            get { return bmultiuser; }
        }

        private bool bm_usrc_invoice_visible = false;
        public bool bm_usrc_Invoice_Visible
        {
                    get { return bm_usrc_invoice_visible; }
        }

        private bool bm_usrc_invoice_viewmode = false;
        public bool bm_usrc_Invoice_ViewMode
        {
            get { return bm_usrc_invoice_viewmode; }
        }

        private bool bshopa_visible = false;
        public bool bShopA_Visible
        {
            get { return bshopa_visible; }
        }

        private bool bshopb_visible = false;
        public bool bShopB_Visible
        {
            get { return bshopb_visible; }
        }

        private bool bshopc_visible = false;
        public bool bShopC_Visible
        {
            get { return bshopc_visible; }
        }

        private bool bm_usrc_invoicetable_visible = false;
        public bool bm_usrc_InvoiceTable_Visible
        {
            get { return bm_usrc_invoicetable_visible; }
        }


        private bool bm_usrc_invoice_headvisible = false;
        public bool bm_usrc_Invoice_HeadVisible
        {
            get { return bm_usrc_invoice_headvisible; }
        }

        private bool bdatabaseempty = false;
        public bool bDataBaseEmpty
        {
            get { return bdatabaseempty; }
        }


        private string docinvoice = null;
        public string DocInvoice
        {
            get { return docinvoice; }
        }



        public ControlTagForHelp(bool xbMultiUser,
                                 bool xm_usrc_Invoice_Visible,
                                 bool xm_usrc_Invoice_ViewMode,
                                 bool xShopA_Visible,
                                 bool xShopB_Visible,
                                 bool xShopC_Visible,
                                 bool xm_usrc_InvoiceTable_Visible,
                                 bool xm_usrc_Invoice_HeadVisible,
                                 bool xbDataBaseEmpty,
                                 string xDocInvoice
                                )
        {
            bmultiuser = xbMultiUser;
            bm_usrc_invoice_visible = xm_usrc_Invoice_Visible;
            bm_usrc_invoice_viewmode = xm_usrc_Invoice_ViewMode;
            bshopa_visible = xShopA_Visible;
            bshopb_visible = xShopB_Visible;
            bshopc_visible = xShopC_Visible;
            bm_usrc_invoicetable_visible = xm_usrc_InvoiceTable_Visible;
            bm_usrc_invoice_headvisible = xm_usrc_Invoice_HeadVisible;
            bdatabaseempty = xbDataBaseEmpty;
            docinvoice = xDocInvoice;

        }

        public void Init(ref List<HUDCMS.TagForHelp> TagForHelpList)
        {
            if (TagForHelpList==null)
            {
                TagForHelpList = new List<HUDCMS.TagForHelp>();

                TagForHelpList.Add(new HUDCMS.TagForHelp("bmultiuser", new string[] { "true", "false" }));

                //TagForHelpList.Add(new HUDCMS.TagForHelp("bm_usrc_invoice_visible", new string[] { "true", "false" })));
                //TagForHelpList.Add(new HUDCMS.TagForHelp("bm_usrc_invoice_visible", "false"));

                //TagForHelpList.Add(new HUDCMS.TagForHelp("Shops", "true"));
                //TagForHelpList.Add(new HUDCMS.TagForHelp("bshopa_visible", "true"));
                //TagForHelpList.Add(new HUDCMS.TagForHelp("bshopa_visible", "false"));

                //TagForHelpList.Add(new HUDCMS.TagForHelp("bshopb_visible", "true"));
                //TagForHelpList.Add(new HUDCMS.TagForHelp("bshopb_visible", "false"));

                //TagForHelpList.Add(new HUDCMS.TagForHelp("bshopc_visible", "true"));
                //TagForHelpList.Add(new HUDCMS.TagForHelp("bshopc_visible", "false"));

                //TagForHelpList.Add(new HUDCMS.TagForHelp("bm_usrc_invoicetable_visible", "true"));
                //TagForHelpList.Add(new HUDCMS.TagForHelp("bm_usrc_invoicetable_visible", "false"));

                //TagForHelpList.Add(new HUDCMS.TagForHelp("bm_usrc_invoice_headvisible", "true"));
                //TagForHelpList.Add(new HUDCMS.TagForHelp("bm_usrc_invoice_headvisible", "false"));

                //TagForHelpList.Add(new HUDCMS.TagForHelp("bdatabaseempty", "true"));
                //TagForHelpList.Add(new HUDCMS.TagForHelp("bdatabaseempty", "false"));

                //TagForHelpList.Add(new HUDCMS.TagForHelp("InvoiceType", "DocInvoice"));
                //TagForHelpList.Add(new HUDCMS.TagForHelp("InvoiceType", "DocProformaInvoice"));

            }

        }
        public void Fill()
        {
            controlnameextension = "_";
            if (bmultiuser)
            {
                controlnameextension += "M";
            }
            else
            {
                controlnameextension += "S";
            }

            if (bm_usrc_invoice_viewmode)
            {
                controlnameextension += "I";
                if (bm_usrc_invoice_viewmode)
                {
                    controlnameextension += "V";
                }
                else
                {
                    controlnameextension += "E";
                }
                if (bshopa_visible)
                {
                    controlnameextension += "A";
                }
                if (bshopb_visible)
                {
                    controlnameextension += "B";
                }
                if (bshopc_visible)
                {
                    controlnameextension += "C";
                }
            }

            if (bm_usrc_invoicetable_visible)
            {
                controlnameextension += "T";
            }

            if (bm_usrc_invoicetable_visible)
            {
                controlnameextension += "H";
            }

            if (bdatabaseempty)
            {
                controlnameextension += "N";
            }

            if (docinvoice.Equals(Program.const_DocInvoice))
            {
                controlnameextension += "R";
            }
            if (docinvoice.Equals(Program.const_DocProformaInvoice))
            {
                controlnameextension += "P";
            }

        }
    }
}
