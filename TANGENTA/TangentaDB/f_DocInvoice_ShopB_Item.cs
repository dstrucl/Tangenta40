using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_DocInvoice_ShopB_Item
    {
        public static bool GetView(ref DataTable dt)
        {

            if (dt==null)
            {
                dt = new DataTable();
            }
            else
            {
                dt.Clear();
                dt.Columns.Clear();
            }
            string sql_DocInvoice_ShopB_Item_VIEW = @"SELECT 
ID,
DocInvoice_ShopB_Item_$_asi_$_asin_$$Name,
DocInvoice_ShopB_Item_$_asi_$_si_$$Name,
DocInvoice_ShopB_Item_$_asi_$_si_$_sipg1_$$Name,
DocInvoice_ShopB_Item_$_asi_$_si_$_sipg1_$_sipg2_$$Name,
DocInvoice_ShopB_Item_$_asi_$_si_$_sipg1_$_sipg2_$_sipg3_$$Name,
DocInvoice_ShopB_Item_$_dinv_$$NumberInFinancialYear,
DocInvoice_ShopB_Item_$_dinv_$$FinancialYear,
DocInvoice_ShopB_Item_$$RetailSimpleItemPrice,
DocInvoice_ShopB_Item_$$Discount,
DocInvoice_ShopB_Item_$$iQuantity,
DocInvoice_ShopB_Item_$$RetailSimpleItemPriceWithDiscount,
DocInvoice_ShopB_Item_$$ExtraDiscount,
DocInvoice_ShopB_Item_$$TaxPrice,
DocInvoice_ShopB_Item_$_asi_$_asin_$$Abbreviation,
DocInvoice_ShopB_Item_$_asi_$_si_$$Abbreviation,
DocInvoice_ShopB_Item_$_asi_$_si_$$ToOffer,
DocInvoice_ShopB_Item_$_dinv_$$Draft,
DocInvoice_ShopB_Item_$_dinv_$$DraftNumber,
DocInvoice_ShopB_Item_$_asi_$_si_$_sipg1_$$ID,
DocInvoice_ShopB_Item_$_asi_$_si_$_sipg1_$_sipg2_$$ID,
DocInvoice_ShopB_Item_$_asi_$_si_$_sipg1_$_sipg2_$_sipg3_$$ID,
DocInvoice_ShopB_Item_$_dinv_$$ID,
DocInvoice_ShopB_Item_$_asi_$_si_$$ID,
DocInvoice_ShopB_Item_$_asi_$_asin_$$ID,
DocInvoice_ShopB_Item_$_asi_$$ID,
DocInvoice_ShopB_Item_$_asi_$_si_$_siimg_$$ID,
DocInvoice_ShopB_Item_$_asi_$_si_$_siimg_$$Image_Hash,
DocInvoice_ShopB_Item_$_asi_$_si_$_siimg_$$Image_Data,
DocInvoice_ShopB_Item_$_asi_$_si_$$Code,
DocInvoice_ShopB_Item_$_asi_$_asinimg_$$ID,
DocInvoice_ShopB_Item_$_asi_$_asinimg_$$Image_Hash,
DocInvoice_ShopB_Item_$_asi_$_asinimg_$$Image_Data,
DocInvoice_ShopB_Item_$_asi_$$Code,
DocInvoice_ShopB_Item_$_apl_$$ID,
DocInvoice_ShopB_Item_$_apl_$_apln_$$ID,
DocInvoice_ShopB_Item_$_apl_$_apln_$$Name,
DocInvoice_ShopB_Item_$_apl_$$Valid,
DocInvoice_ShopB_Item_$_apl_$$ValidFrom,
DocInvoice_ShopB_Item_$_apl_$$ValidTo,
DocInvoice_ShopB_Item_$_apl_$$Description,
DocInvoice_ShopB_Item_$_apl_$$CreationDate,
DocInvoice_ShopB_Item_$_apl_$_acur_$$ID,
DocInvoice_ShopB_Item_$_apl_$_acur_$$Name,
DocInvoice_ShopB_Item_$_apl_$_acur_$$Abbreviation,
DocInvoice_ShopB_Item_$_apl_$_acur_$$Symbol,
DocInvoice_ShopB_Item_$_apl_$_acur_$$CurrencyCode,
DocInvoice_ShopB_Item_$_apl_$_acur_$$DecimalPlaces,
DocInvoice_ShopB_Item_$_atax_$$ID,
DocInvoice_ShopB_Item_$_atax_$$Name,
DocInvoice_ShopB_Item_$_atax_$$Rate,
DocInvoice_ShopB_Item_$_dinv_$$NetSum,
DocInvoice_ShopB_Item_$_dinv_$$Discount,
DocInvoice_ShopB_Item_$_dinv_$$EndSum,
DocInvoice_ShopB_Item_$_dinv_$$TaxSum,
DocInvoice_ShopB_Item_$_dinv_$$GrossSum,
DocInvoice_ShopB_Item_$_dinv_$_acur_$$ID,
DocInvoice_ShopB_Item_$_dinv_$_acur_$$Name,
DocInvoice_ShopB_Item_$_dinv_$_acur_$$Abbreviation,
DocInvoice_ShopB_Item_$_dinv_$_acur_$$Symbol,
DocInvoice_ShopB_Item_$_dinv_$_acur_$$CurrencyCode,
DocInvoice_ShopB_Item_$_dinv_$_acur_$$DecimalPlaces,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$$ID,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$$ID,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$$Gender,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_acfn_$$ID,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_acfn_$$FirstName,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_acln_$$ID,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_acln_$$LastName,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$$DateOfBirth,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$$Tax_ID,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$$Registration_ID,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_agsmnper_$$ID,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_agsmnper_$$GsmNumber,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_aphnnper_$$ID,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_aphnnper_$$PhoneNumber,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_aemailper_$$ID,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_aemailper_$$Email,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_acadrper_$$ID,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_acadrper_$_astrnper_$$ID,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_acadrper_$_astrnper_$$StreetName,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_acadrper_$_ahounper_$$ID,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_acadrper_$_ahounper_$$HouseNumber,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_acadrper_$_acitper_$$ID,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_acadrper_$_acitper_$$City,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_acadrper_$_azipper_$$ID,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_acadrper_$_azipper_$$ZIP,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_acadrper_$_astper_$$ID,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_acadrper_$_astper_$$Country,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_acadrper_$_astper_$$Country_ISO_3166_a2,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_acadrper_$_astper_$$Country_ISO_3166_a3,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_acadrper_$_astper_$$Country_ISO_3166_num,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_acadrper_$_acouper_$$ID,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_acadrper_$_acouper_$$State,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$$CardNumber,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_acardtper_$$ID,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_acardtper_$$CardType,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_aperimg_$$ID,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_aperimg_$$Image_Hash,
DocInvoice_ShopB_Item_$_dinv_$_acusper_$_aper_$_aperimg_$$Image_Data,
DocInvoice_ShopB_Item_$_dinv_$_acusorg_$$ID,
DocInvoice_ShopB_Item_$_dinv_$_acusorg_$_aorg_$$ID,
DocInvoice_ShopB_Item_$_dinv_$_acusorg_$_aorg_$$Name,
DocInvoice_ShopB_Item_$_dinv_$_acusorg_$_aorg_$$Tax_ID,
DocInvoice_ShopB_Item_$_dinv_$_acusorg_$_aorg_$$Registration_ID,
DocInvoice_ShopB_Item_$_dinv_$_acusorg_$_aorg_$$TaxPayer,
DocInvoice_ShopB_Item_$_dinv_$_acusorg_$_aorg_$_acmt1_$$ID,
DocInvoice_ShopB_Item_$_dinv_$_acusorg_$_aorg_$_acmt1_$$Comment,
DocInvoice_ShopB_Item_$_dinv_$$Paid,
DocInvoice_ShopB_Item_$_dinv_$$Storno,
DocInvoice_ShopB_Item_$_dinv_$$Invoice_Reference_ID,
DocInvoice_ShopB_Item_$_dinv_$$Invoice_Reference_Type
from DocInvoice_ShopB_Item_VIEW";
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt,sql_DocInvoice_ShopB_Item_VIEW,ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice_ShopB_Item:GetView:\r\nsql=" + sql_DocInvoice_ShopB_Item_VIEW + "\r\nErr=" + Err);
                return false;
            }
            
        }
    }
}
