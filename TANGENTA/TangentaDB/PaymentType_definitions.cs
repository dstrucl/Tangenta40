using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public class PaymentType_definitions
    {
        public ID PaymentType_ANY_TYPE_ID = null;
        public ID PaymentType_CASH_ID = null;
        public ID PaymentType_CARD_ID = null;
        public ID PaymentType_BANK_ACCOUNT_TRANSFER_ID = null;
        public ID PaymentType_CASH_OR_CARD_ID = null;
        public ID PaymentType_ALLREADY_PAID_ID = null;

        public string_v PaymentType_Name_ANY_TYPE_v = null;
        public string_v PaymentType_Name_CASH_v = null;
        public string_v PaymentType_Name_CARD_v = null;
        public string_v PaymentType_Name_BANK_ACCOUNT_TRANSFER_v = null;
        public string_v PaymentType_Name_CASH_OR_CARD_v = null;
        public string_v PaymentType_Name_ALLREADY_PAID_v = null;

        public bool Get()
        {
            if (f_PaymentType.Get(GlobalData.Get_sPaymentType(GlobalData.ePaymentType.ANY_TYPE), GlobalData.Get_sPaymentType_ltext(GlobalData.ePaymentType.ANY_TYPE).s,ref PaymentType_Name_ANY_TYPE_v,ref PaymentType_ANY_TYPE_ID))
            {
                if (f_PaymentType.Get(GlobalData.Get_sPaymentType(GlobalData.ePaymentType.CASH), GlobalData.Get_sPaymentType_ltext(GlobalData.ePaymentType.CASH).s,ref PaymentType_Name_CASH_v, ref PaymentType_CASH_ID))
                {
                    if (f_PaymentType.Get(GlobalData.Get_sPaymentType(GlobalData.ePaymentType.CARD), GlobalData.Get_sPaymentType_ltext(GlobalData.ePaymentType.CARD).s,ref PaymentType_Name_CARD_v, ref PaymentType_CARD_ID))
                    {
                        if (f_PaymentType.Get(GlobalData.Get_sPaymentType(GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER), GlobalData.Get_sPaymentType_ltext(GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER).s,ref PaymentType_Name_BANK_ACCOUNT_TRANSFER_v, ref PaymentType_BANK_ACCOUNT_TRANSFER_ID))
                        {
                            if (f_PaymentType.Get(GlobalData.Get_sPaymentType(GlobalData.ePaymentType.CASH_OR_CARD), GlobalData.Get_sPaymentType_ltext(GlobalData.ePaymentType.CASH_OR_CARD).s,ref PaymentType_Name_CASH_OR_CARD_v,ref PaymentType_CASH_OR_CARD_ID))
                            {
                                if (f_PaymentType.Get(GlobalData.Get_sPaymentType(GlobalData.ePaymentType.ALLREADY_PAID), GlobalData.Get_sPaymentType_ltext(GlobalData.ePaymentType.ALLREADY_PAID).s,ref PaymentType_Name_ALLREADY_PAID_v, ref PaymentType_ALLREADY_PAID_ID))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}
