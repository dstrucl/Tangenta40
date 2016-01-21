using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB
{
    public static class f_Atom_Customer_Person
    {
        public static bool Get(long Customer_Person_ID, ref long_v Atom_Customer_Person_ID_v)
        {
            DataTable dt = new DataTable();
            string sql = "select Person_ID from Customer_Person where ID = " + Customer_Person_ID.ToString();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count == 1)
                {
                    long Person_ID = (long)dt.Rows[0]["Person_ID"];
                    dt.Clear();
                    sql = "select  Person_$$Gender, Person_$_cfn_$$FirstName,Person_$_cln_$$LastName,Person_$$DateOfBirth,Person_$$Tax_ID, Person_$$Registration_ID from Person_VIEW where ID = " + Person_ID.ToString();
                    if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                    {
                        if (dt.Rows.Count == 1)
                        {
                            bool_v Gender_v = func.set_bool(dt.Rows[0]["Person_$$Gender"]);
                            string_v FirstName_v = func.set_string(dt.Rows[0]["Person_$_cfn_$$FirstName"]);
                            string_v LastName_v = func.set_string(dt.Rows[0]["Person_$_cln_$$LastName"]);
                            DateTime_v DateOfBirth_v = func.set_DateTime(dt.Rows[0]["Person_$$DateOfBirth"]);
                            int_v Tax_ID_v = func.set_int(dt.Rows[0]["Person_$$Tax_ID"]);
                            string_v Registration_ID_v = func.set_string(dt.Rows[0]["Person_$$Registration_ID"]);
                            string_v GsmNumber_v = null;
                            string_v PhoneNumber_v = null;
                            string_v Email_v = null;

                            string_v StreetName_v = null;
                            string_v HouseNumber_v = null;
                            string_v City_v = null;
                            string_v ZIP_v = null;
                            string_v State_v = null;
                            string_v Country_v = null;
                            string_v CardNumber_v = null;
                            string_v CardType_v = null;
                            string_v Image_Hash_v = null;
                            byte_array_v Image_Data_v = null;
                            string_v Description_v = null;
                            sql = @"select  PersonData_$_cgsmnper_$$GsmNumber,
                                            PersonData_$_cphnnper_$$PhoneNumber,
                                            PersonData_$_cemailper_$$Email,
                                            PersonData_$_cadrper_$_cstrnper_$$StreetName,
                                            PersonData_$_cadrper_$_chounper_$$HouseNumber,
                                            PersonData_$_cadrper_$_ccitper_$$City,
                                            PersonData_$_cadrper_$_zipper_$$ZIP,
                                            PersonData_$_cadrper_$_cstper_$$State,
                                            PersonData_$_cadrper_$_ccouper_$$Country,
                                            PersonData_$$CardNumber,
                                            PersonData_$_cardtper_$$CardType,
                                            PersonData_$_perimg_$$Image_Hash,
                                            PersonData_$_perimg_$$Image_Data,
                                            PersonData_$$Description
                                            from PersonData_VIEW where PersonData_$_per_$$ID = " + Person_ID.ToString() + " order by ID desc";
                            dt.Clear();
                            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                            {
                                if (dt.Rows.Count > 0)
                                {
                                    GsmNumber_v = func.set_string(dt.Rows[0]["PersonData_$_cgsmnper_$$GsmNumber"]);
                                    PhoneNumber_v = func.set_string(dt.Rows[0]["PersonData_$_cphnnper_$$PhoneNumber"]);
                                    Email_v = func.set_string(dt.Rows[0]["PersonData_$_cemailper_$$Email"]);
                                    StreetName_v = func.set_string(dt.Rows[0]["PersonData_$_cadrper_$_cstrnper_$$StreetName"]);
                                    HouseNumber_v = func.set_string(dt.Rows[0]["PersonData_$_cadrper_$_chounper_$$HouseNumber"]);
                                    City_v = func.set_string(dt.Rows[0]["PersonData_$_cadrper_$_ccitper_$$City"]);
                                    ZIP_v = func.set_string(dt.Rows[0]["PersonData_$_cadrper_$_zipper_$$ZIP"]);
                                    State_v = func.set_string(dt.Rows[0]["PersonData_$_cadrper_$_cstper_$$State"]);
                                    Country_v = func.set_string(dt.Rows[0]["PersonData_$_cadrper_$_ccouper_$$Country"]);
                                    CardNumber_v = func.set_string(dt.Rows[0]["PersonData_$$CardNumber"]);
                                    CardType_v = func.set_string(dt.Rows[0]["PersonData_$_cardtper_$$CardType"]);
                                    Image_Hash_v = func.set_string(dt.Rows[0]["PersonData_$_perimg_$$Image_Hash"]);
                                    Image_Data_v = func.set_byte_array(dt.Rows[0]["PersonData_$_perimg_$$Image_Data"]);
                                    Description_v = func.set_string(dt.Rows[0]["PersonData_$$Description"]);
                                }
                                long_v Atom_Person_ID_v = null;
                                if (!f_Atom_Person.Get(
                                                        Gender_v,
                                                        FirstName_v,
                                                        LastName_v,
                                                        DateOfBirth_v,
                                                        Tax_ID_v,
                                                        Registration_ID_v,
                                                        GsmNumber_v,
                                                        PhoneNumber_v,
                                                        Email_v,
                                                        StreetName_v,
                                                        HouseNumber_v,
                                                        City_v,
                                                        ZIP_v,
                                                        State_v,
                                                        Country_v,
                                                        CardNumber_v,
                                                        CardType_v,
                                                        Image_Hash_v,
                                                        Image_Data_v,
                                                        ref Atom_Person_ID_v))
                                {
                                    return false;
                                }
                                if (Atom_Person_ID_v != null)
                                {

                                    sql = "select ID from Atom_Customer_Person where Atom_Person_ID = " + Atom_Person_ID_v.v.ToString();
                                    dt.Clear();
                                    if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                                    {
                                        if (dt.Rows.Count == 1)
                                        {
                                            if (Atom_Customer_Person_ID_v == null)
                                            {
                                                Atom_Customer_Person_ID_v = new long_v();
                                            }
                                            Atom_Customer_Person_ID_v.v = (long)dt.Rows[0]["ID"];
                                            return true;
                                        }
                                        else
                                        {
                                            sql = "insert into Atom_Customer_Person (Atom_Person_ID) values (" + Atom_Person_ID_v.v.ToString() + ")";
                                            object ores = null;
                                            long id = -1;
                                            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, null, ref id, ref ores, ref Err, "Atom_Customer_Person"))
                                            {
                                                if (Atom_Customer_Person_ID_v == null)
                                                {
                                                    Atom_Customer_Person_ID_v = new long_v();
                                                }
                                                Atom_Customer_Person_ID_v.v = id;
                                                return true;
                                            }
                                            else
                                            {
                                                LogFile.Error.Show("ERROR:f_Atom_Customer_Person:Get:\r\nsql=" + sql + "\r\nErr=" + Err);
                                                return false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:f_Atom_Customer_Person:Get:Atom_Person_ID==null");
                                    return false;
                                }

                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:f_Atom_Customer_Person:Get:sql=" + sql + "\nErr=" + Err);
                                return false;
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_Atom_Customer_Person:Get:sql=" + sql + "\ndt.Rows.Count!=1");
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_Customer_Person:Get:sql=" + sql + "\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_Customer_Person:Get:sql=" + sql + "\ndt.Rows.Count!=1");
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_Customer_Person:Get:sql=" + sql + "\ndt.Rows.Count!=1");
                return false;
            }
        }






        private static bool Find_Customer(long Customer_Person_ID, ref long Person_ID, ref long Customer_ID)
        {
            string Err = null;
            DataTable dt = new DataTable();
            string sCustomer_Person_ID = Customer_Person_ID.ToString();
            string sql = "select Customer_ID,Person_ID from Customer_Person where ID = " + sCustomer_Person_ID;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Customer_ID = (long)dt.Rows[0]["Customer_ID"];
                    Person_ID = (long)dt.Rows[0]["Person_ID"];
                    return true;
                }
                else
                {
                    Customer_ID = -1;
                    Person_ID = -1;
                    LogFile.Error.Show("ERROR:f_Atom_Customer_Person:Find_Customer:No Data row in table Customer_Person for Customer_Person.ID = " + sCustomer_Person_ID);
                    return false;
                }

            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_Customer_Person:Find_Customer:" + sql + "\r\n:Err=" + Err);
                return false;
            }
        }
    }
}
