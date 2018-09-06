using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_DocProformaInvoice_ShopB_Item
    {
        public static bool GetView(ref DataTable dt)
        {

            if (dt == null)
            {
                dt = new DataTable();
            }
            else
            {
                dt.Clear();
                dt.Columns.Clear();
            }
            string sql_DocProformaInvoice_ShopB_Item_VIEW = @"
            select
DocProformaInvoice_ShopB_Item.ID,
DocProformaInvoice_ShopB_Item_$_asi_$_asin_$$Name, 
DocProformaInvoice_ShopB_Item_$_asi_$_si_$$Name,
DocProformaInvoice_ShopB_Item_$_asi_$_si_$_sipg1_$$Name,
DocProformaInvoice_ShopB_Item_$_asi_$_si_$_sipg1_$_sipg2_$$Name,
DocProformaInvoice_ShopB_Item_$_asi_$_si_$_sipg1_$_sipg2_$_sipg3_$$Name,
DocProformaInvoice_ShopB_Item_$_dpinv_$$NumberInFinancialYear,
DocProformaInvoice_ShopB_Item_$_dpinv_$$FinancialYear,
DocProformaInvoice_ShopB_Item_$_dpinv_$$GrossSum,
DocProformaInvoice_ShopB_Item_$_asi_$_si_$$ToOffer,
DocProformaInvoice_ShopB_Item_$$RetailSimpleItemPrice,
DocProformaInvoice_ShopB_Item_$$Discount,
DocProformaInvoice_ShopB_Item_$$iQuantity,
DocProformaInvoice_ShopB_Item_$$RetailSimpleItemPriceWithDiscount, 
DocProformaInvoice_ShopB_Item_$$ExtraDiscount,
DocProformaInvoice_ShopB_Item_$$TaxPrice,
DocProformaInvoice_ShopB_Item_$_dpinv_$$NetSum,
DocProformaInvoice_ShopB_Item_$_dpinv_$$Discount,
DocProformaInvoice_ShopB_Item_$_dpinv_$$EndSum,
DocProformaInvoice_ShopB_Item_$_dpinv_$$TaxSum,
DocProformaInvoice_ShopB_Item_$_dpinv_$$Draft,
DocProformaInvoice_ShopB_Item_$_dpinv_$$DraftNumber,
DocProformaInvoice_ShopB_Item_$_asi_$_asin_$$Abbreviation,
DocProformaInvoice_ShopB_Item_$_asi_$_si_$$Abbreviation,
DocProformaInvoice_ShopB_Item_$_asi_$_si_$_sipg1_$_sipg2_$$ID,
DocProformaInvoice_ShopB_Item_$_asi_$_si_$_sipg1_$_sipg2_$_sipg3_$$ID,
DocProformaInvoice_ShopB_Item_$_asi_$$ID,
DocProformaInvoice_ShopB_Item_$_asi_$_si_$$ID,
DocProformaInvoice_ShopB_Item_$_asi_$_si_$_siimg_$$ID,
DocProformaInvoice_ShopB_Item_$_asi_$_si_$_siimg.Image_Hash 
DocProformaInvoice_ShopB_Item_$_asi_$_si_$_siimg_$$Image_Hash,
DocProformaInvoice_ShopB_Item_$_asi_$_si_$_siimg_$$Image_Data,
DocProformaInvoice_ShopB_Item_$_asi_$_si_$$Code,
DocProformaInvoice_ShopB_Item_$_asi_$_si_$_sipg1_$$ID,
DocProformaInvoice_ShopB_Item_$_asi_$_si_$_sipg1_$$Name,
DocProformaInvoice_ShopB_Item_$_asi_$_si_$_sipg1_$_sipg2_$$ID,
DocProformaInvoice_ShopB_Item_$_asi_$_si_$_sipg1_$_sipg2_$$Name,
DocProformaInvoice_ShopB_Item_$_asi_$_si_$_sipg1_$_sipg2_$_sipg3_$$ID,
DocProformaInvoice_ShopB_Item_$_asi_$_si_$_sipg1_$_sipg2_$_sipg3_$$Name,
DocProformaInvoice_ShopB_Item_$_asi_$_asin_$$ID,
DocProformaInvoice_ShopB_Item_$_asi_$_asinimg_$$ID,
DocProformaInvoice_ShopB_Item_$_asi_$_asinimg_$$Image_Hash,
DocProformaInvoice_ShopB_Item_$_asi_$_asinimg_$$Image_Data,
DocProformaInvoice_ShopB_Item_$_asi_$$Code,
DocProformaInvoice_ShopB_Item_$_apl_$$ID,
DocProformaInvoice_ShopB_Item_$_apl_$_apln_$$ID,
DocProformaInvoice_ShopB_Item_$_apl_$_apln_$$Name,
DocProformaInvoice_ShopB_Item_$_apl_$$Valid,
DocProformaInvoice_ShopB_Item_$_apl_$$ValidFrom,
DocProformaInvoice_ShopB_Item_$_apl_$$ValidTo,
DocProformaInvoice_ShopB_Item_$_apl_$$Description,
DocProformaInvoice_ShopB_Item_$_apl_$$CreationDate,
DocProformaInvoice_ShopB_Item_$_apl_$_acur_$$ID,
DocProformaInvoice_ShopB_Item_$_apl_$_acur_$$Name,
DocProformaInvoice_ShopB_Item_$_apl_$_acur_$$Abbreviation,
DocProformaInvoice_ShopB_Item_$_apl_$_acur_$$Symbol,
DocProformaInvoice_ShopB_Item_$_apl_$_acur_$$CurrencyCode,
DocProformaInvoice_ShopB_Item_$_apl_$_acur_$$DecimalPlaces,
DocProformaInvoice_ShopB_Item_$_atax_$$ID,
DocProformaInvoice_ShopB_Item_$_atax_$$Name,
DocProformaInvoice_ShopB_Item_$_atax_$$Rate,
DocProformaInvoice_ShopB_Item_$_dpinv_$$ID,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acur_$$ID,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acur_$$Name,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acur_$$Abbreviation,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acur_$$Symbol,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acur_$$CurrencyCode,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acur_$$DecimalPlaces,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$$ID,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$$ID,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$$Gender,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_acfn_$$ID,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_acfn_$$FirstName,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_acln_$$ID,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_acln_$$LastName,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$$DateOfBirth,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$$Tax_ID,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$$Registration_ID,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_agsmnper_$$ID,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_agsmnper_$$GsmNumber,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_aphnnper_$$ID,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_aphnnper_$$PhoneNumber,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_aemailper_$$ID,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_aemailper_$$Email,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_acadrper_$$ID,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_acadrper_$_astrnper_$$ID,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_acadrper_$_astrnper_$$StreetName,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_acadrper_$_ahounper_$$ID,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_acadrper_$_ahounper_$$HouseNumber,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_acadrper_$_acitper_$$ID,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_acadrper_$_acitper_$$City,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_acadrper_$_azipper_$$ID,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_acadrper_$_azipper_$$ZIP,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_acadrper_$_astper_$$ID,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_acadrper_$_astper_$$Country,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_acadrper_$_astper_$$Country_ISO_3166_a2,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_acadrper_$_astper_$$Country_ISO_3166_a3,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_acadrper_$_astper_$$Country_ISO_3166_num,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_acadrper_$_acouper_$$ID,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_acadrper_$_acouper_$$State,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$$CardNumber,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_acardtper_$$ID,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_acardtper_$$CardType,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_aperimg_$$ID,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_aperimg_$$Image_Hash,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusper_$_aper_$_aperimg_$$Image_Data,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusorg_$$ID,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusorg_$_aorg_$$ID,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusorg_$_aorg_$$Name,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusorg_$_aorg_$$Tax_ID,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusorg_$_aorg.Registration_ID AS DocProformaInvoice_ShopB_Item_$_dpinv_$_acusorg_$_aorg_$$Registration_ID,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusorg_$_aorg.TaxPayer AS DocProformaInvoice_ShopB_Item_$_dpinv_$_acusorg_$_aorg_$$TaxPayer,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusorg_$_aorg_$_acmt1.ID AS DocProformaInvoice_ShopB_Item_$_dpinv_$_acusorg_$_aorg_$_acmt1_$$ID,
DocProformaInvoice_ShopB_Item_$_dpinv_$_acusorg_$_aorg_$_acmt1.Comment AS DocProformaInvoice_ShopB_Item_$_dpinv_$_acusorg_$_aorg_$_acmt1_$$Comment 
from DocProformaInvoice_ShopB_Item_VIEW  
                ";
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_DocProformaInvoice_ShopB_Item_VIEW, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice_ShopB_Item:GetView:\r\nsql=" + sql_DocProformaInvoice_ShopB_Item_VIEW + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
