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
    public static class f_Atom_Person
    {
        public static bool Get(bool_v Gender_v,
                                      string_v FirstName_v,
                                      string_v LastName_v,
                                      DateTime_v DateOfBirth_v,
                                      string_v Tax_ID_v,
                                      string_v Registration_ID_v,
                                      string_v GsmNumber_v,
                                      string_v PhoneNumber_v,
                                      string_v Email_v,
                                      string_v StreetName_v,
                                      string_v HouseNumber_v,
                                      string_v City_v,
                                      string_v ZIP_v,
                                      string_v Country_v,
                                      string_v Country_ISO_3166_a2,
                                      string_v Country_ISO_3166_a3,
                                      short_v   Country_ISO_3166_num,
                                      string_v State_v,
                                      string_v CardNumber_v,
                                      string_v CardType_v,
                                      string_v Image_Hash_v,
                                      byte_array_v Image_Data_v,
                                      ref long_v Atom_Person_ID_v)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string Gender_cond = null;
            string Gender_value = null;
            if (!fs.AddPar("Gender", ref lpar, Gender_v, ref Gender_cond, ref Gender_value))
            {
                return false;
            }

            long_v Atom_cFirstName_ID_v = null;
            if (!fs.Get_string_table_ID("Atom_cFirstName", "FirstName", FirstName_v, ref Atom_cFirstName_ID_v))
            {
                return false;
            }
            string Atom_cFirstName_ID_cond = null;
            string Atom_cFirstName_ID_value = null;
            if (!fs.AddPar("Atom_cFirstName_ID", ref lpar, Atom_cFirstName_ID_v, ref Atom_cFirstName_ID_cond, ref Atom_cFirstName_ID_value))
            {
                return false;
            }

            long_v Atom_cLastName_ID_v = null;
            if (!fs.Get_string_table_ID("Atom_cLastName", "LastName", LastName_v, ref Atom_cLastName_ID_v))
            {
                return false;
            }
            string Atom_cLastName_ID_cond = null;
            string Atom_cLastName_ID_value = null;
            if (!fs.AddPar("Atom_cLastName_ID", ref lpar, Atom_cLastName_ID_v, ref Atom_cLastName_ID_cond, ref Atom_cLastName_ID_value))
            {
                return false;
            }

            string DateOfBirth_cond = null;
            string DateOfBirth_value = null;
            if (!fs.AddPar("DateOfBirth", ref lpar, DateOfBirth_v, ref DateOfBirth_cond, ref DateOfBirth_value))
            {
                return false;
            }

            string Tax_ID_cond = null;
            string Tax_ID_value = null;
            if (!fs.AddPar("Tax_ID", ref lpar, Tax_ID_v, ref Tax_ID_cond, ref Tax_ID_value))
            {
                return false;
            }

            string Registration_ID_cond = null;
            string Registration_ID_value = null;
            if (!fs.AddPar("Registration_ID", ref lpar, Registration_ID_v, ref Registration_ID_cond, ref Registration_ID_value))
            {
                return false;
            }


            long_v Atom_cGsmNumber_Person_ID_v = null;
            if (!fs.Get_string_table_ID("Atom_cGsmNumber_Person", "GsmNumber", GsmNumber_v, ref Atom_cGsmNumber_Person_ID_v))
            {
                return false;

            }
            string Atom_cGsmNumber_Person_ID_cond = null;
            string Atom_cGsmNumber_Person_ID_value = null;
            if (!fs.AddPar("Atom_cGsmNumber_Person_ID", ref lpar, Atom_cGsmNumber_Person_ID_v, ref Atom_cGsmNumber_Person_ID_cond, ref Atom_cGsmNumber_Person_ID_value))
            {
                return false;
            }

            long_v Atom_cPhoneNumber_Person_ID_v = null;
            if (!fs.Get_string_table_ID("Atom_cPhoneNumber_Person", "PhoneNumber", PhoneNumber_v, ref Atom_cPhoneNumber_Person_ID_v))
            {
                return false;

            }
            string Atom_cPhoneNumber_Person_ID_cond = null;
            string Atom_cPhoneNumber_Person_ID_value = null;
            if (!fs.AddPar("Atom_cPhoneNumber_Person_ID", ref lpar, Atom_cPhoneNumber_Person_ID_v, ref Atom_cPhoneNumber_Person_ID_cond, ref Atom_cPhoneNumber_Person_ID_value))
            {
                return false;
            }

            long_v Atom_cEmail_Person_ID_v = null;
            if (!fs.Get_string_table_ID("Atom_cEmail_Person", "Email", Email_v, ref Atom_cEmail_Person_ID_v))
            {
                return false;

            }
            string Atom_cEmail_Person_cond = null;
            string Atom_cEmail_Person_value = null;
            if (!fs.AddPar("Atom_cEmail_Person_ID", ref lpar, Atom_cEmail_Person_ID_v, ref Atom_cEmail_Person_cond, ref Atom_cEmail_Person_value))
            {
                return false;
            }

            long_v Atom_cAddress_Person_ID_v = null;
            if (!fs.Get_Atom_cAddress_Person_ID(StreetName_v,
                                            HouseNumber_v,
                                            ZIP_v,
                                            City_v,
                                            Country_v,
                                            Country_ISO_3166_a2,
                                            Country_ISO_3166_a3,
                                            Country_ISO_3166_num,
                                            State_v,
                                            ref Atom_cAddress_Person_ID_v
                                            ))
            {
                return false;
            }
            string Atom_cAddress_Person_ID_cond = null;
            string Atom_cAddress_Person_ID_value = null;
            if (!fs.AddPar("Atom_cAddress_Person_ID", ref lpar, Atom_cAddress_Person_ID_v, ref Atom_cAddress_Person_ID_cond, ref Atom_cAddress_Person_ID_value))
            {
                return false;
            }

            string CardNumber_cond = null;
            string CardNumber_value = null;
            if (!fs.AddPar("CardNumber", ref lpar, CardNumber_v, ref CardNumber_cond, ref CardNumber_value))
            {
                return false;
            }


            long_v Atom_cCardType_Person_ID_v = null;
            if (!fs.Get_string_table_ID("Atom_cCardType_Person", "CardType", CardType_v, ref Atom_cCardType_Person_ID_v))
            {
                return false;

            }

            string Atom_cCardType_Person_ID_cond = null;
            string Atom_cCardType_Person_ID_value = null;
            if (!fs.AddPar("Atom_cCardType_Person_ID", ref lpar, Atom_cCardType_Person_ID_v, ref Atom_cCardType_Person_ID_cond, ref Atom_cCardType_Person_ID_value))
            {
                return false;
            }

            long_v Atom_PersonImage_ID_v = null;
            if (!fs.Get_Atom_PersonImage_ID(Image_Hash_v, Image_Data_v, ref Atom_PersonImage_ID_v))
            {
                return false;
            }

            string Atom_PersonImage_ID_cond = null;
            string Atom_PersonImage_ID_value = null;
            if (!fs.AddPar("Atom_PersonImage_ID", ref lpar, Atom_PersonImage_ID_v, ref Atom_PersonImage_ID_cond, ref Atom_PersonImage_ID_value))
            {
                return false;
            }


            string sql = "select ID from Atom_Person where " + Gender_cond
                                                                     + " and " + Atom_cFirstName_ID_cond
                                                                     + " and " + Atom_cLastName_ID_cond
                                                                     + " and " + DateOfBirth_cond
                                                                     + " and " + Tax_ID_cond
                                                                     + " and " + Registration_ID_cond

                                                                     + " and " + Atom_cGsmNumber_Person_ID_cond
                                                                     + " and " + Atom_cPhoneNumber_Person_ID_cond
                                                                     + " and " + Atom_cEmail_Person_cond
                                                                     + " and " + Atom_cAddress_Person_ID_cond
                                                                     + " and " + Registration_ID_cond
                                                                     + " and " + CardNumber_cond
                                                                     + " and " + Atom_cCardType_Person_ID_cond
                                                                     + " and " + Atom_PersonImage_ID_cond
                                                                     + " order by ID desc";

            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Atom_Person_ID_v == null)
                    {
                        Atom_Person_ID_v = new long_v();
                    }
                    Atom_Person_ID_v.v = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = @"insert into Atom_Person (Gender,
                                                    Atom_cFirstName_ID,
                                                    Atom_cLastName_ID,
                                                    DateOfBirth,
                                                    Tax_ID,
                                                    Registration_ID,
                                                    Atom_cGsmNumber_Person_ID,
                                                    Atom_cPhoneNumber_Person_ID,
                                                    Atom_cEmail_Person_ID,
                                                    Atom_cAddress_Person_ID,
                                                    CardNumber,
                                                    Atom_cCardType_Person_ID,
                                                    Atom_PersonImage_ID
                                                    )values(" + Gender_value
                                                            + "," + Atom_cFirstName_ID_value
                                                            + "," + Atom_cLastName_ID_value
                                                            + "," + DateOfBirth_value
                                                            + "," + Tax_ID_value
                                                            + "," + Registration_ID_value
                                                            + "," + Atom_cGsmNumber_Person_ID_value
                                                            + "," + Atom_cPhoneNumber_Person_ID_value
                                                            + "," + Atom_cEmail_Person_value
                                                            + "," + Atom_cAddress_Person_ID_value
                                                            + "," + CardNumber_value
                                                            + "," + Atom_cCardType_Person_ID_value
                                                            + "," + Atom_PersonImage_ID_value
                                                            + ")";
                    long id = -1;
                    object ores = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref id, ref ores, ref Err, "Atom_Person"))
                    {
                        if (Atom_Person_ID_v == null)
                        {
                            Atom_Person_ID_v = new long_v();
                        }
                        Atom_Person_ID_v.v = id;
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_Customer_Person:Get_Atom_Person_ID:\r\nsql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_Customer_Person:Get_Atom_Person_ID:\r\nsql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static UniversalInvoice.Person GetData(ltext token_prefix, long Atom_Person_ID)
        {
            string Err = null;
            UniversalInvoice.Person univ_per = null;
            string sql = @"select 
                            Atom_Person_$$Gender,
                            Atom_Person_$_acfn_$$FirstName,
                            Atom_Person_$_acln_$$LastName,
                            Atom_Person_$$DateOfBirth,
                            Atom_Person_$$Tax_ID,
                            Atom_Person_$$Registration_ID,
                            Atom_Person_$_agsmnper_$$GsmNumber,
                            Atom_Person_$_aphnnper_$$PhoneNumber,
                            Atom_Person_$_aemailper_$$Email,
                            Atom_Person_$_acadrper_$_astrnper_$$StreetName,
                            Atom_Person_$_acadrper_$_ahounper_$$HouseNumber,
                            Atom_Person_$_acadrper_$_acitper_$$City,
                            Atom_Person_$_acadrper_$_azipper_$$ZIP,
                            Atom_Person_$_acadrper_$_astper_$$Country,
                            Atom_Person_$_acadrper_$_acouper_$$State,
                            Atom_Person_$$CardNumber,
                            Atom_Person_$_acardtper_$$CardType,
                            Atom_Person_$_aperimg_$$Image_Data
                                from Atom_Person_VIEW where ID = " + Atom_Person_ID.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, null, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    univ_per = new UniversalInvoice.Person(token_prefix, DBTypes.tf._set_bool(dt.Rows[0]["Atom_Person_$$Gender"]),
                                                         DBTypes.tf._set_string(dt.Rows[0]["Atom_Person_$_acfn_$$FirstName"]),
                                                         DBTypes.tf._set_string(dt.Rows[0]["Atom_Person_$_acln_$$LastName"]),
                                                         DBTypes.tf._set_DateTime(dt.Rows[0]["Atom_Person_$$DateOfBirth"]),
                                                         DBTypes.tf._set_string(dt.Rows[0]["Atom_Person_$$Tax_ID"]),
                                                         DBTypes.tf._set_string(dt.Rows[0]["Atom_Person_$$Registration_ID"]),
                                                         DBTypes.tf._set_string(dt.Rows[0]["Atom_Person_$_agsmnper_$$GsmNumber"]),
                                                         DBTypes.tf._set_string(dt.Rows[0]["Atom_Person_$_aphnnper_$$PhoneNumber"]),
                                                         DBTypes.tf._set_string(dt.Rows[0]["Atom_Person_$_aemailper_$$Email"]),
                                                         DBTypes.tf._set_string(dt.Rows[0]["Atom_Person_$$CardNumber"]),
                                                         DBTypes.tf._set_string(dt.Rows[0]["Atom_Person_$_acardtper_$$CardType"]),
                                                         DBTypes.tf._set_byte_array(dt.Rows[0]["Atom_Person_$_aperimg_$$Image_Data"]),
                                                         DBTypes.tf._set_string(dt.Rows[0]["Atom_Person_$_acadrper_$_astrnper_$$StreetName"]),
                                                         DBTypes.tf._set_string(dt.Rows[0]["Atom_Person_$_acadrper_$_ahounper_$$HouseNumber"]),
                                                         DBTypes.tf._set_string(dt.Rows[0]["Atom_Person_$_acadrper_$_azipper_$$ZIP"]),
                                                         DBTypes.tf._set_string(dt.Rows[0]["Atom_Person_$_acadrper_$_acitper_$$City"]),
                                                         DBTypes.tf._set_string(dt.Rows[0]["Atom_Person_$_acadrper_$_astper_$$Country"]),
                                                         DBTypes.tf._set_string(dt.Rows[0]["Atom_Person_$_acadrper_$_acouper_$$State"]));
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
    }
}
