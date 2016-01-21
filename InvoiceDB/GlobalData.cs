﻿using DBTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB
{
    public static class GlobalData
    {
        public enum ePaymentType { NONE, CASH, ALLREADY_PAID, PAYMENT_CARD, TRR };
        public const string const_Storno = "Storno";
        public const string const_Storno_with_description = "Storno*";

        public static long Office_ID = -1;
        public static long WorkingPlace_ID = -1;
        public static long Atom_Office_ID = -1;
        public static long Atom_Computer_ID = -1;
        public static long Atom_WorkingPlace_ID = -1;
        public static long Atom_myCompany_Person_ID = -1;
        public static long Atom_WorkPeriod_ID = -1;

        public static JOURNAL_ProformaInvoice_Type_definitions JOURNAL_ProformaInvoice_Type_definitions = new JOURNAL_ProformaInvoice_Type_definitions();
        public static xCurrency BaseCurrency = null;

        public static bool GetWorkPeriod(string Atom_WorkPeriod_Type_Name, string x_Atom_WorkPeriod_Type_Description, DateTime dtStart, DateTime_v dtEnd_v, ref string Err)
        {
            if (Atom_WorkPeriod_ID < 0)
            {
                if (Atom_myCompany_Person_ID < 0)
                {
                    string_v office_name = null;
                    if (f_Atom_myCompany_Person.Get(1, ref Atom_myCompany_Person_ID, ref office_name) == myOrg.enum_GetCompany_Person_Data.MyCompany_Data_OK)
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
                                    if (f_Atom_WorkPeriod.Get(Atom_WorkPeriod_Type_Name, Atom_WorkPeriod_Type_Description, Atom_myCompany_Person_ID, Atom_WorkingPlace_ID, Atom_Computer_ID, dtStart, dtEnd_v, ref Atom_WorkPeriod_ID))
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

    }
}