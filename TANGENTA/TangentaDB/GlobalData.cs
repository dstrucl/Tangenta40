#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBConnectionControl40;
using DBTypes;
using LanguageControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TangentaDB
{
    public static class GlobalData
    {
        public const string const_DocInvoice = "DocInvoice";
        public const string const_DocProformaInvoice = "DocProformaInvoice";

        public const string const_Storno = "Storno";
        public const string const_Storno_with_description = "Storno*";

        public static ID Office_ID = null;
        public static ID Atom_Office_ID = null;
        public static ID Atom_Computer_ID = null;
        public static ID Atom_ElectronicDevice_ID = null;

        public static string ElectronicDevice_Name
        {
            get
            {
                if (myOrg.m_myOrg_Office!=null)
                {
                    if (myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice != null)
                    {
                        return myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice.ElectronicDevice_Name;
                    }
                }
                return null;
            }
        }
        public static string ElectronicDevice_Description
        {
            get
            {
                if (myOrg.m_myOrg_Office != null)
                {
                    if (myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice != null)
                    {
                        return myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice.ElectronicDevice_Name;
                    }
                }
                return null;
            }
        }


        public static JOURNAL_DocInvoice_Type_definitions JOURNAL_DocInvoice_Type_definitions = null;
        public static JOURNAL_DocProformaInvoice_Type_definitions JOURNAL_DocProformaInvoice_Type_definitions = null;
        public static doc_page_type_definitions doc_page_type_definitions = null;
        public static doc_type_definitions doc_type_definitions = null;
        public static Language_definitions language_definitions = null;
        public static TermsOfPayment_definitions termsOfPayment_definitions = null;
        public static PaymentType_definitions paymentType_definitions = null;


        public static xCurrency BaseCurrency = null;

        //public static Color Color_Factory = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
        //public static Color Color_Stock = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));

        public enum ePaymentType : int { ANY_TYPE,
                                         CASH,
                                         CARD,
                                         BANK_ACCOUNT_TRANSFER,
                                         CASH_OR_CARD,
                                         ALLREADY_PAID,
                                         NOT_DEFINED
                                        };

        public const string const_PaymentType_ANY_TYPE = "ANY_TYPE";
        public const string const_PaymentType_CASH = "CASH";
        public const string const_PaymentType_CARD = "CARD";
        public const string const_PaymentType_BANK_ACCOUNT_TRANSFER = "BANK_ACCOUNT_TRANSFER";
        public const string const_PaymentType_CASH_OR_CARD = "CASH_OR_CARD";
        public const string const_PaymentType_ALLREADY_PAID = "ALLREADY_PAID";
        public static string[] sPaymentTypes = new string[] { const_PaymentType_ANY_TYPE,
                                                              const_PaymentType_CASH,
                                                              const_PaymentType_CARD,
                                                              const_PaymentType_BANK_ACCOUNT_TRANSFER,
                                                              const_PaymentType_CASH_OR_CARD,
                                                              const_PaymentType_ALLREADY_PAID
                                                              };

        public static void Init()
        {
            JOURNAL_DocInvoice_Type_definitions = new JOURNAL_DocInvoice_Type_definitions();
            JOURNAL_DocProformaInvoice_Type_definitions = new JOURNAL_DocProformaInvoice_Type_definitions();
            doc_page_type_definitions = new doc_page_type_definitions();
            doc_type_definitions = new doc_type_definitions();
            language_definitions = new Language_definitions();
            termsOfPayment_definitions = new TermsOfPayment_definitions();
            paymentType_definitions = new PaymentType_definitions();
        }


        //Function to get random number
        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return getrandom.Next(min, max);
            }
        }

        public static decimal GetRandomPrice(decimal dmin, decimal dmax, int DecimalPlaces )
        {
            lock (syncLock)
            { // synchronize
                int min = Convert.ToInt32(dmin);
                int iMultiply = 10 ^ DecimalPlaces;
                int max = Convert.ToInt32(dmax)* iMultiply;
                int irand = getrandom.Next(min, max);
                decimal drand = Convert.ToDecimal(irand) / iMultiply;
                drand = Decimal.Round(drand, DecimalPlaces);
                return drand;
            }
        }

        public static bool SetFinancialYears(ComboBox cmb_FinancialYear,ref DataTable dt_FinancialYears,bool IsDocInvoice,bool IsDocProformaInvoice,ref int Default_FinancialYear)
        {
            //            XMessage.Box.Show(cmb_FinancialYear, "Default_FinancialYear=" + Default_FinancialYear.ToString(), "GlobalData:SetFinancialYears(..)");
            if (IsDocInvoice)
            {
                if (!f_DocInvoice.GetExistingFinancialYears(ref dt_FinancialYears))
                {
                    return false;
                }

            }
            else if (IsDocProformaInvoice)
            {
                if (!f_DocProformaInvoice.GetExistingFinancialYears(ref dt_FinancialYears))
                {
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:GlobalData:SetFinancialYears:Unsupported DocTyp");
                return false;
            }

            cmb_FinancialYear.DataSource = null;
            int CurrentYear = DateTime.Now.Year;
            bool bNewFinancialYear = false;
            bool bNoFinancialYearsatAll = false;
            if (!FinancialYearExist(dt_FinancialYears, CurrentYear))
            {
                if (dt_FinancialYears.Rows.Count == 0)
                {
                    //No data rows for financial year at all
                    //                    XMessage.Box.Show(cmb_FinancialYear, "dt_FinancialYears.Rows.Count == 0" , "GlobalData:SetFinancialYears(..)");

                    bNewFinancialYear = true;
                    bNoFinancialYearsatAll = true;
                    DataRow dr = dt_FinancialYears.NewRow();
                    dr["FinancialYear"] = CurrentYear;
                    dt_FinancialYears.Rows.Add(dr);
                }
                else
                {
                    //No data rows for financial year for Current Year
                    if (Default_FinancialYear != CurrentYear)
                    {
                        if (XMessage.Box.Show(Global.f.GetParentForm(cmb_FinancialYear), lng.s_CurrentComputerTimeIsInNewYear, ":" + CurrentYear.ToString() + "\r\n" + lng.s_OpenNewFiscalYearYesNo.s + ":" + CurrentYear.ToString() + " ?", lng.s_HappyNewYear.s, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            bNewFinancialYear = true;
                            DataRow dr = dt_FinancialYears.NewRow();
                            dr["FinancialYear"] = CurrentYear;
                            dt_FinancialYears.Rows.Add(dr);
                        }
                    }
                    else
                    {
                        //                        XMessage.Box.Show(cmb_FinancialYear, "Default_FinancialYear == CurrentYear", "GlobalData:SetFinancialYears(..)");
                        DataRow dr = dt_FinancialYears.NewRow();
                        dr["FinancialYear"] = CurrentYear;
                        dt_FinancialYears.Rows.Add(dr);
                    }
                }
            }
            cmb_FinancialYear.DataSource = dt_FinancialYears;
            cmb_FinancialYear.DisplayMember = "FinancialYear";
            cmb_FinancialYear.ValueMember = "FinancialYear";

            if (Default_FinancialYear == 0)
            {
                //                XMessage.Box.Show(cmb_FinancialYear, "Default_FinancialYear == 0", "GlobalData:SetFinancialYears(..)");
                Default_FinancialYear = CurrentYear;
            }
            else
            {
                if (bNewFinancialYear)
                {
                    //XMessage.Box.Show(cmb_FinancialYear, "bNewFinancialYear == true", "GlobalData:SetFinancialYears(..)");
                    if (bNoFinancialYearsatAll)
                    {
                        Default_FinancialYear = CurrentYear;
                    }
                    else
                    {
                        if (XMessage.Box.Show(Global.f.GetParentForm(cmb_FinancialYear), lng.s_SetNewFinancial, ":" + CurrentYear.ToString() + lng.s_AsDefaultFinancialYear.s, lng.s_HappyNewYear.s, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            Default_FinancialYear = CurrentYear;
                        }
                    }
                }
                else
                {
                    if (!FinancialYearExist(dt_FinancialYears, Default_FinancialYear))
                    {
                        Default_FinancialYear = CurrentYear;
                    }
                }
            }
            SelectFinancialYear(cmb_FinancialYear, Default_FinancialYear);
//            XMessage.Box.Show(cmb_FinancialYear, "after SelectFinancialYear=" + Default_FinancialYear.ToString(), "GlobalData:SetFinancialYears(..)");
            return true;
        }


        public static void SelectFinancialYear(ComboBox cmb_FinancialYear,int financialYear)
        {

            foreach (object oItem in cmb_FinancialYear.Items)
            {
                if (oItem is System.Data.DataRowView)
                {
                    System.Data.DataRowView drv = (System.Data.DataRowView)oItem;
                    if (drv["FinancialYear"] is int)
                    {
                        if (((int)drv["FinancialYear"]) == financialYear)
                        {
                            cmb_FinancialYear.SelectedItem = oItem;
                        }
                    }
                }
            }
        }

        public static bool FinancialYearExist(DataTable dt, int Year)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if ((int)dr["FinancialYear"] == Year)
                {
                    return true;
                }
            }
            return false;
        }


        public static ePaymentType Get_ePaymentType(string sPaymentType, ref string Err)
        {
            Err = null;
            string spt = sPaymentType.ToUpper();
            int i = 0;
            int iCount = sPaymentTypes.Length;
            for (i=0;i< iCount;i++)
            {
                if (spt.Equals(sPaymentTypes[i]))
                {
                    return (ePaymentType)i;
                }
            }
            Err = "ERROR:TangentaDB:GlobalData:Get_ePaymentType:sPaymentType =" + sPaymentType + " not implemented!";
            return ePaymentType.ANY_TYPE;
        }

        public static string Get_sPaymentType(ePaymentType xePaymentType)
        {
            return sPaymentTypes[(int)xePaymentType];
        }

        public static ltext Get_sPaymentType_ltext(ePaymentType xePaymentType)
        {
            switch (xePaymentType)
            {
                case GlobalData.ePaymentType.CASH:
                    return lng.s_PaymentType_CASH;
                case GlobalData.ePaymentType.CASH_OR_CARD:
                    return lng.s_PaymentType_CASH_OR_PAYMENT_CARD;
                case GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER:
                    return lng.s_PaymentType_BANK_ACCOUNT_TRANSFER;
                case GlobalData.ePaymentType.ALLREADY_PAID:
                    return lng.s_PaymentType_ALLREADY_PAID;
                case GlobalData.ePaymentType.CARD:
                    return lng.s_PaymentType_PAYMENT_CARD;
                case GlobalData.ePaymentType.ANY_TYPE:
                    return lng.s_PaymentType_ANY_TYPE;
                default:
                    LogFile.Error.Show("ERROR:TangentaDB:f_MethodOfPayment:Get:ePaymentType == " +xePaymentType.ToString() + "!");
                    return null;
            }
        }

        public static GlobalData.ePaymentType Get_ePaymentType(string s)
        {
            if (s!=null)
            {
                if (s.ToLower().Equals(lng.s_PaymentType_CASH.s.ToLower()))
                {
                    return GlobalData.ePaymentType.CASH;
                }
                else if (s.ToLower().Equals(lng.s_PaymentType_CASH_OR_PAYMENT_CARD.s.ToLower()))
                {
                    return GlobalData.ePaymentType.CASH_OR_CARD;
                }
                else if (s.ToLower().Equals(lng.s_PaymentType_PAYMENT_CARD.s.ToLower()))
                {
                    return GlobalData.ePaymentType.CARD;
                }
                else if (s.ToLower().Equals(lng.s_PaymentType_BANK_ACCOUNT_TRANSFER.s.ToLower()))
                {
                    return GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER;
                }
                else if (s.ToLower().Equals(lng.s_PaymentType_ALLREADY_PAID.s.ToLower()))
                {
                    return GlobalData.ePaymentType.ALLREADY_PAID;
                }
                else
                {
                    return GlobalData.ePaymentType.ANY_TYPE;
                }
            }
            else
            {
                return GlobalData.ePaymentType.ANY_TYPE;
            }
        }




        public static bool GetWorkPeriod(ID myOrganisation_Person_ID,
                                         string Atom_WorkPeriod_Type_Name, 
                                         string x_Atom_WorkPeriod_Type_Description,
                                         DateTime dtStart,
                                         DateTime_v dtEnd_v,
                                         ref ID xAtom_myOrganisation_Person_ID,
                                         ref ID xAtom_WorkPeriod_ID,
                                         ref string Err)
        {
            string_v office_name = null;
            if (f_Atom_myOrganisation_Person.Get(myOrganisation_Person_ID, ref xAtom_myOrganisation_Person_ID, ref office_name))
            {
                if (f_Atom_ElectronicDevice.Get(myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice.ElectronicDevice_Name, myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice.ElectronicDevice_Description, ref GlobalData.Atom_ElectronicDevice_ID))
                {
                    string Atom_WorkPeriod_Type_Description = x_Atom_WorkPeriod_Type_Description;
                    if (Atom_WorkPeriod_Type_Name.Equals(f_Atom_WorkPeriod.sWorkPeriod_DB_ver_1_04))
                    {
                        Atom_WorkPeriod_Type_Description = "Stari šiht od 29.4.2015 do " + dtEnd_v.v.Day.ToString() + "." + dtEnd_v.v.Month.ToString() + "." + dtEnd_v.v.Year.ToString();
                    }
                    ID Atom_IP_address_ID = null;
                    if (f_Atom_IP_address.Get(ref Atom_IP_address_ID))
                    {
                        if (f_Atom_WorkPeriod.Get(Atom_WorkPeriod_Type_Name,
                                                  Atom_WorkPeriod_Type_Description,
                                                  xAtom_myOrganisation_Person_ID,
                                                  Atom_ElectronicDevice_ID,
                                                  Atom_IP_address_ID,
                                                  dtStart,
                                                  dtEnd_v,
                                                  ref xAtom_WorkPeriod_ID))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        public static bool Get_BaseCurrency(ref string BaseCurrency_Text,ref string Err)
        {
            string sql_BaseCurrency = "select Currency_ID from BaseCurrency";
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_BaseCurrency, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    ID currency_id = tf.set_ID(dt.Rows[0]["Currency_ID"]);

                    if (GlobalData.BaseCurrency == null)
                    {
                        GlobalData.BaseCurrency = new xCurrency();
                    }
                    if (GlobalData.BaseCurrency.SetCurrency(currency_id, ref Err))
                    {
                        BaseCurrency_Text = GlobalData.BaseCurrency.Abbreviation + " " + GlobalData.BaseCurrency.Symbol;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    BaseCurrency_Text = null;
                    return true;
                }
            }
            else
            {
                Err = "ERROR:usrc_Invoice:Init_Currency_Table:Err=" + Err;
                return false;
            }
        }


        public static int Get_BaseCurrency_DecimalPlaces()
        {
            if (GlobalData.BaseCurrency != null)
            {
                return GlobalData.BaseCurrency.DecimalPlaces;
            }
            else
            {
                LogFile.Error.Show("ERROR:Program:Get_DecimalPlaces:BaseCurrency is not defined!");
                return 0;
            }
        }

        public static bool InsertIntoBaseCurrency(ID currency_ID, ref string Err)
        {
            string sql_SetBaseCurrency = "Insert into BaseCurrency (Currency_ID) Values (" + currency_ID.ToString() + ")";
            object oRes = null;
            if (DBSync.DBSync.ExecuteNonQuerySQL(sql_SetBaseCurrency, null, ref oRes, ref Err))
            {
                return true;
            }
            else
            {
                Err = "ERROR:TangentaDB:GlobalData:InsertIntoBaseCurrency:sql = " + sql_SetBaseCurrency+"\r\nErr = " + Err;
                LogFile.Error.Show(Err);
                return false;
            }
        }

        public static bool Type_definitions_Read()
        {
            if (language_definitions==null)
            {
                GlobalData.Init();
            }
            if (language_definitions.Get())
            {
                if (JOURNAL_type_definitions_Read())
                {
                    if (Doc_type_definitions_Read())
                    {
                        if (TermsOfPayment_definitions_Read())
                        {
                            if (Payment_definitions_Read())
                            {
                                if (fs.Get_JOURNAL_TYPE_ID())
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

        private static bool Payment_definitions_Read()
        {
            return paymentType_definitions.Get();
        }

        private static bool TermsOfPayment_definitions_Read()
        {
            if (termsOfPayment_definitions.Read())
            {
                return true;
            }
            return false;
        }

        public static bool Get_ElectronicDevice_depended_definitions()
        {
            if (ID.Validate(termsOfPayment_definitions.Advanced_100PercentPayment_ID))
            {
                return true;
            }
            else
            {
                return termsOfPayment_definitions.InsertDefault();
            }
        }


    private static bool Doc_type_definitions_Read()
        {
            if (GlobalData.doc_type_definitions.Read())
            {
                if (GlobalData.doc_page_type_definitions.Read())
                {
                    return true;
                }
            }
            return false;
        }

        private static bool JOURNAL_type_definitions_Read()
        {
            if (GlobalData.JOURNAL_DocInvoice_Type_definitions.Read())
            {
                if (GlobalData.JOURNAL_DocProformaInvoice_Type_definitions.Read())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
