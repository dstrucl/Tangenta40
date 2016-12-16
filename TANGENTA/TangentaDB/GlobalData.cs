﻿#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBTypes;
using LanguageControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class GlobalData
    {

        public const string const_Storno = "Storno";
        public const string const_Storno_with_description = "Storno*";

        public static long Office_ID = -1;
        public static long WorkingPlace_ID = -1;
        public static long Atom_Office_ID = -1;
        public static long Atom_Computer_ID = -1;
        public static long Atom_ElectronicDevice_ID = -1;
        public static long Atom_WorkingPlace_ID = -1;
        public static long Atom_myOrganisation_Person_ID = -1;
        public static long Atom_WorkPeriod_ID = -1;

        public static JOURNAL_DocInvoice_Type_definitions JOURNAL_DocInvoice_Type_definitions = new JOURNAL_DocInvoice_Type_definitions();
        public static JOURNAL_DocProformaInvoice_Type_definitions JOURNAL_DocProformaInvoice_Type_definitions = new JOURNAL_DocProformaInvoice_Type_definitions();

        public static xCurrency BaseCurrency = null;

        public static Color Color_Factory = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
        public static Color Color_Stock = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));

        public enum ePaymentType : int { NONE, CASH, ALLREADY_PAID, PAYMENT_CARD, BANK_ACCOUNT_TRANSFER, CASH_OR_PAYMENT_CARD };
        public static string[] sPaymentTypes = new string[] { "NONE", "CASH", "ALLREADY_PAID", "PAYMENT_CARD", "BANK_ACCOUNT_TRANSFER", "CASH_OR_PAYMENT_CARD" };

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
            return ePaymentType.NONE;
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
                    return lngRPM.s_PaymentType_CASH;
                case GlobalData.ePaymentType.CASH_OR_PAYMENT_CARD:
                    return lngRPM.s_PaymentType_CASH_OR_PAYMENT_CARD;
                case GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER:
                    return lngRPM.s_PaymentType_BANK_ACCOUNT_TRANSFER;
                case GlobalData.ePaymentType.ALLREADY_PAID:
                    return lngRPM.s_PaymentType_ALLREADY_PAID;
                case GlobalData.ePaymentType.PAYMENT_CARD:
                    return lngRPM.s_PaymentType_PAYMENT_CARD;
                case GlobalData.ePaymentType.NONE:
                    LogFile.Error.Show("ERROR:TangentaDB:f_MethodOfPayment:Get:ePaymentType == GlobalData.ePaymentType.NONE!");
                    return null;
                default:
                    LogFile.Error.Show("ERROR:TangentaDB:f_MethodOfPayment:Get:ePaymentType == " +xePaymentType.ToString() + "!");
                    return null;
            }
        }




        public static bool GetWorkPeriod(string Atom_WorkPeriod_Type_Name, 
                                         string x_Atom_WorkPeriod_Type_Description,
                                         string ElectronicDevice_Name,
                                         string ElectronicDevice_Description,
                                         DateTime dtStart,
                                         DateTime_v dtEnd_v,
                                         ref string Err)
        {
            if (Atom_WorkPeriod_ID < 0)
            {
                if (Atom_myOrganisation_Person_ID < 0)
                {
                    string_v office_name = null;
                    if (f_Atom_myOrganisation_Person.Get(1, ref Atom_myOrganisation_Person_ID, ref office_name))
                    {
                        if (f_WorkingPlace.Get(office_name.v, "Tangenta 1", ref WorkingPlace_ID))
                        {
                            if (f_Atom_WorkingPlace.Get(GlobalData.WorkingPlace_ID, ref Atom_WorkingPlace_ID))
                            {
                                if (f_Atom_Computer.Get(ref GlobalData.Atom_Computer_ID))
                                {
                                    if (f_Atom_ElectronicDevice.Get(ElectronicDevice_Name, ElectronicDevice_Description, ref GlobalData.Atom_ElectronicDevice_ID))
                                    {
                                        string Atom_WorkPeriod_Type_Description = x_Atom_WorkPeriod_Type_Description;
                                        if (Atom_WorkPeriod_Type_Name.Equals(f_Atom_WorkPeriod.sWorkPeriod_DB_ver_1_04))
                                        {
                                            Atom_WorkPeriod_Type_Description = "Stari šiht od 29.4.2015 do " + dtEnd_v.v.Day.ToString() + "." + dtEnd_v.v.Month.ToString() + "." + dtEnd_v.v.Year.ToString();
                                        }
                                        if (f_Atom_WorkPeriod.Get(Atom_WorkPeriod_Type_Name, Atom_WorkPeriod_Type_Description, Atom_myOrganisation_Person_ID, Atom_WorkingPlace_ID, Atom_Computer_ID,Atom_ElectronicDevice_ID, dtStart, dtEnd_v, ref Atom_WorkPeriod_ID))
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
            }
            return true;
        }

        public static bool GetWorkPeriodOld(string Atom_WorkPeriod_Type_Name,
                                         string x_Atom_WorkPeriod_Type_Description,
                                         DateTime dtStart,
                                         DateTime_v dtEnd_v,
                                         ref string Err)
        {
            if (Atom_WorkPeriod_ID < 0)
            {
                if (Atom_myOrganisation_Person_ID < 0)
                {
                    string_v office_name = null;
                    if (f_Atom_myOrganisation_Person.Get(1, ref Atom_myOrganisation_Person_ID, ref office_name))
                    {
                        if (f_WorkingPlace.Get(office_name.v, "Tangenta 1", ref WorkingPlace_ID))
                        {
                            if (f_Atom_WorkingPlace.Get(GlobalData.WorkingPlace_ID, ref Atom_WorkingPlace_ID))
                            {
                                if (f_Atom_Computer.Get(ref GlobalData.Atom_Computer_ID))
                                {
                                    string Atom_WorkPeriod_Type_Description = x_Atom_WorkPeriod_Type_Description;
                                    if (Atom_WorkPeriod_Type_Name.Equals(f_Atom_WorkPeriod.sWorkPeriod_DB_ver_1_04))
                                    {
                                        Atom_WorkPeriod_Type_Description = "Stari šiht od 29.4.2015 do " + dtEnd_v.v.Day.ToString() + "." + dtEnd_v.v.Month.ToString() + "." + dtEnd_v.v.Year.ToString();
                                    }
                                    if (f_Atom_WorkPeriod.GetOld(Atom_WorkPeriod_Type_Name, Atom_WorkPeriod_Type_Description, Atom_myOrganisation_Person_ID, Atom_WorkingPlace_ID, Atom_Computer_ID, dtStart, dtEnd_v, ref Atom_WorkPeriod_ID))
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
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        public static bool Get_BaseCurrency(ref string BaseCurrency_Text,ref string Err)
        {
            string sql_BaseCurrency = "select Currency_ID from BaseCurrency";
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_BaseCurrency, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    long currency_id = (long)dt.Rows[0]["Currency_ID"];

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

        public static bool InsertIntoBaseCurrency(long currency_ID, ref string Err)
        {
            string sql_SetBaseCurrency = "Insert into BaseCurrency (Currency_ID) Values (" + currency_ID.ToString() + ")";
            object oRes = null;
            if (DBSync.DBSync.ExecuteNonQuerySQL(sql_SetBaseCurrency, null, ref oRes, ref Err))
            {
                return true;
            }
            else
            {
                Err = "ERROR:usrc_Invoice:Init_Currency_Table:sql = "+ sql_SetBaseCurrency+"\r\nErr = " + Err;
                LogFile.Error.Show(Err);
                return false;
            }
        }

        public static bool JOURNAL_type_definitions_Read()
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
