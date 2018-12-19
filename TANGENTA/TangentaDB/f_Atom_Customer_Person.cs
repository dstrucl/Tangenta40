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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_Atom_Customer_Person
    {
        public static bool Get(ID Customer_Person_ID, ref ID Atom_Customer_Person_ID, Transaction transaction)
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
                            bool_v Gender_v = tf.set_bool(dt.Rows[0]["Person_$$Gender"]);
                            string_v FirstName_v = tf.set_string(dt.Rows[0]["Person_$_cfn_$$FirstName"]);
                            string_v LastName_v = tf.set_string(dt.Rows[0]["Person_$_cln_$$LastName"]);
                            DateTime_v DateOfBirth_v = tf.set_DateTime(dt.Rows[0]["Person_$$DateOfBirth"]);
                            string_v Tax_ID_v = tf.set_string(dt.Rows[0]["Person_$$Tax_ID"]);
                            string_v Registration_ID_v = tf.set_string(dt.Rows[0]["Person_$$Registration_ID"]);
                            string_v GsmNumber_v = null;
                            string_v PhoneNumber_v = null;
                            string_v Email_v = null;

                            string_v StreetName_v = null;
                            string_v HouseNumber_v = null;
                            string_v City_v = null;
                            string_v ZIP_v = null;
                            string_v Country_v = null;
                            string_v Country_ISO_3166_a2_v = null;
                            string_v Country_ISO_3166_a3_v = null;
                            short_v  Country_ISO_3166_num_v = null;
                            string_v State_v = null;
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
                                            PersonData_$_cadrper_$_cstper_$$Country,
                                            PersonData_$_cadrper_$_cstper_$$Country_ISO_3166_a2,
                                            PersonData_$_cadrper_$_cstper_$$Country_ISO_3166_a3,
                                            PersonData_$_cadrper_$_cstper_$$Country_ISO_3166_num,
                                            PersonData_$_cadrper_$_ccouper_$$State,
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
                                    GsmNumber_v = tf.set_string(dt.Rows[0]["PersonData_$_cgsmnper_$$GsmNumber"]);
                                    PhoneNumber_v = tf.set_string(dt.Rows[0]["PersonData_$_cphnnper_$$PhoneNumber"]);
                                    Email_v = tf.set_string(dt.Rows[0]["PersonData_$_cemailper_$$Email"]);
                                    StreetName_v = tf.set_string(dt.Rows[0]["PersonData_$_cadrper_$_cstrnper_$$StreetName"]);
                                    HouseNumber_v = tf.set_string(dt.Rows[0]["PersonData_$_cadrper_$_chounper_$$HouseNumber"]);
                                    City_v = tf.set_string(dt.Rows[0]["PersonData_$_cadrper_$_ccitper_$$City"]);
                                    ZIP_v = tf.set_string(dt.Rows[0]["PersonData_$_cadrper_$_zipper_$$ZIP"]);
                                    Country_v = tf.set_string(dt.Rows[0]["PersonData_$_cadrper_$_cstper_$$Country"]);
                                    Country_ISO_3166_a2_v = tf.set_string(dt.Rows[0]["PersonData_$_cadrper_$_cstper_$$Country_ISO_3166_a2"]);
                                    Country_ISO_3166_a3_v = tf.set_string(dt.Rows[0]["PersonData_$_cadrper_$_cstper_$$Country_ISO_3166_a3"]);
                                    Country_ISO_3166_num_v = tf.set_short(dt.Rows[0]["PersonData_$_cadrper_$_cstper_$$Country_ISO_3166_num"]);
                                    State_v = tf.set_string(dt.Rows[0]["PersonData_$_cadrper_$_ccouper_$$State"]);
                                    CardNumber_v = tf.set_string(dt.Rows[0]["PersonData_$$CardNumber"]);
                                    CardType_v = tf.set_string(dt.Rows[0]["PersonData_$_cardtper_$$CardType"]);
                                    Image_Hash_v = tf.set_string(dt.Rows[0]["PersonData_$_perimg_$$Image_Hash"]);
                                    Image_Data_v = tf.set_byte_array(dt.Rows[0]["PersonData_$_perimg_$$Image_Data"]);
                                    Description_v = tf.set_string(dt.Rows[0]["PersonData_$$Description"]);
                                }
                                ID Atom_Person_ID = null;
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
                                                        Country_v,
                                                        Country_ISO_3166_a2_v,
                                                        Country_ISO_3166_a3_v,
                                                        Country_ISO_3166_num_v,
                                                        State_v,
                                                        CardNumber_v,
                                                        CardType_v,
                                                        Image_Hash_v,
                                                        Image_Data_v,
                                                        ref Atom_Person_ID,
                                                        transaction))
                                {
                                    return false;
                                }
                                if (Atom_Person_ID != null)
                                {

                                    sql = "select ID from Atom_Customer_Person where Atom_Person_ID = " + Atom_Person_ID.ToString();
                                    dt.Clear();
                                    if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                                    {
                                        if (dt.Rows.Count == 1)
                                        {
                                            Atom_Customer_Person_ID = tf.set_ID(dt.Rows[0]["ID"]);
                                            return true;
                                        }
                                        else
                                        {
                                            if (!transaction.Get(DBSync.DBSync.Con))
                                            {
                                                return false;
                                            }
                                            sql = "insert into Atom_Customer_Person (Atom_Person_ID) values (" + Atom_Person_ID.ToString() + ")";
                                            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, null, ref Atom_Customer_Person_ID, ref Err, "Atom_Customer_Person"))
                                            {
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



        public static UniversalInvoice.Person GetData(ltext token_prefix, ID Atom_Customer_Person_ID)
        {
            string Err = null;
            UniversalInvoice.Person univ_per = null;
            string sql = @"select 
                            Atom_Customer_Person_$_aper_$$Gender,
                            Atom_Customer_Person_$_aper_$_acfn_$$FirstName,
                            Atom_Customer_Person_$_aper_$_acln_$$LastName,
                            Atom_Customer_Person_$_aper_$$DateOfBirth,
                            Atom_Customer_Person_$_aper_$$Tax_ID,
                            Atom_Customer_Person_$_aper_$$Registration_ID,
                            Atom_Customer_Person_$_aper_$_agsmnper_$$GsmNumber,
                            Atom_Customer_Person_$_aper_$_aphnnper_$$PhoneNumber,
                            Atom_Customer_Person_$_aper_$_aemailper_$$Email,
                            Atom_Customer_Person_$_aper_$_acadrper_$_astrnper_$$StreetName,
                            Atom_Customer_Person_$_aper_$_acadrper_$_ahounper_$$HouseNumber,
                            Atom_Customer_Person_$_aper_$_acadrper_$_acitper_$$City,
                            Atom_Customer_Person_$_aper_$_acadrper_$_azipper_$$ZIP,
                            Atom_Customer_Person_$_aper_$_acadrper_$_astper_$$Country,
                            Atom_Customer_Person_$_aper_$_acadrper_$_acouper_$$State,
                            Atom_Customer_Person_$_aper_$$CardNumber,
                            Atom_Customer_Person_$_aper_$_acardtper_$$CardType,
                            Atom_Customer_Person_$_aper_$_aperimg_$$Image_Data
                                from Atom_Customer_Person_VIEW where ID = " + Atom_Customer_Person_ID.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, null, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    univ_per = new UniversalInvoice.Person(token_prefix, DBTypes.tf._set_bool(dt.Rows[0]["Atom_Customer_Person_$_aper_$$Gender"]),
                                                         DBTypes.tf._set_string(dt.Rows[0]["Atom_Customer_Person_$_aper_$_acfn_$$FirstName"]),
                                                         DBTypes.tf._set_string(dt.Rows[0]["Atom_Customer_Person_$_aper_$_acln_$$LastName"]),
                                                         DBTypes.tf._set_DateTime(dt.Rows[0]["Atom_Customer_Person_$_aper_$$DateOfBirth"]),
                                                         DBTypes.tf._set_string(dt.Rows[0]["Atom_Customer_Person_$_aper_$$Tax_ID"]),
                                                         DBTypes.tf._set_string(dt.Rows[0]["Atom_Customer_Person_$_aper_$$Registration_ID"]),
                                                         DBTypes.tf._set_string(dt.Rows[0]["Atom_Customer_Person_$_aper_$_agsmnper_$$GsmNumber"]),
                                                         DBTypes.tf._set_string(dt.Rows[0]["Atom_Customer_Person_$_aper_$_aphnnper_$$PhoneNumber"]),
                                                         DBTypes.tf._set_string(dt.Rows[0]["Atom_Customer_Person_$_aper_$_aemailper_$$Email"]),
                                                         DBTypes.tf._set_string(dt.Rows[0]["Atom_Customer_Person_$_aper_$$CardNumber"]),
                                                         DBTypes.tf._set_string(dt.Rows[0]["Atom_Customer_Person_$_aper_$_acardtper_$$CardType"]),
                                                         DBTypes.tf._set_byte_array(dt.Rows[0]["Atom_Customer_Person_$_aper_$_aperimg_$$Image_Data"]),
                                                         DBTypes.tf._set_string(dt.Rows[0]["Atom_Customer_Person_$_aper_$_acadrper_$_astrnper_$$StreetName"]),
                                                         DBTypes.tf._set_string(dt.Rows[0]["Atom_Customer_Person_$_aper_$_acadrper_$_ahounper_$$HouseNumber"]),
                                                         DBTypes.tf._set_string(dt.Rows[0]["Atom_Customer_Person_$_aper_$_acadrper_$_azipper_$$ZIP"]),
                                                         DBTypes.tf._set_string(dt.Rows[0]["Atom_Customer_Person_$_aper_$_acadrper_$_acitper_$$City"]),
                                                         DBTypes.tf._set_string(dt.Rows[0]["Atom_Customer_Person_$_aper_$_acadrper_$_astper_$$Country"]),
                                                         DBTypes.tf._set_string(dt.Rows[0]["Atom_Customer_Person_$_aper_$_acadrper_$_acouper_$$State"]));
                    return univ_per;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_Person:GetData:sql=" + sql + "\r\nErr=" + Err);
            }
            return null;
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
