﻿using BlagajnaTableClass;
using DBConnectionControl40;
using DBTypes;
using LanguageControl;
using SQLTableControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangenta
{
    public static class f_Atom_OrganisationData
    {
        public static bool Get(long Atom_Organisation_ID,
                                string_v OrganisationTYPE_v,
                                PostAddress_v Address_v,
                                string_v PhoneNumber_v,
                                string_v FaxNumber_v,
                                string_v Email_v,
                                string_v HomePage_v,
                                string_v Logo_Hash_v,
                                byte_array_v Image_Data_v,
                                string_v Logo_Description_v,
                                string_v BankName_v,
                                string_v TRR_v,
                                ref long_v Atom_OrganisationData_ID_v)
        {
            string Err = null;
            string BankName_condition = null;
            string BankName_Value = null;
            string TRR_Value = null;
            string TRR_condition = null;

            long_v Atom_Organisation_ID_v = null;

            ID_v cAdressAtom_Org_iD_v = null;
            SQLTable t_cAdressAtom_Org = new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Atom_cAddress_Org)));
            t_cAdressAtom_Org.CreateTableTree(DBSync.DBSync.DB_for_Blagajna.m_DBTables.items);
            if (myOrg.Address_v.Get_Address_Tabel_ID(t_cAdressAtom_Org, ref cAdressAtom_Org_iD_v))
            {
                ID_v cHomePage_Org_ID_v = null;
                string cHomePage_Org_ID_v_cond = "cHomePage_Org_ID is null";
                string cHomePage_Org_ID_v_Value = "null";

                if (fs.Get_ID("cHomePage_Org", "HomePage", HomePage_v, ref cHomePage_Org_ID_v, ref Err))
                {
                    if (cHomePage_Org_ID_v != null)
                    {
                        cHomePage_Org_ID_v_Value = cHomePage_Org_ID_v.v.ToString();
                        cHomePage_Org_ID_v_cond = "cHomePage_Org_ID = " + cHomePage_Org_ID_v_Value;
                    }
                }

                ID_v cEmail_Org_ID_v = null;
                string cEmail_Org_ID_v_cond = "cEmail_Org_ID is null";
                string cEmail_Org_ID_v_Value = "null";

                if (fs.Get_ID("cEmail_Org", "Email", Email_v, ref cEmail_Org_ID_v, ref Err))
                {
                    if (cEmail_Org_ID_v != null)
                    {
                        cEmail_Org_ID_v_Value = cEmail_Org_ID_v.v.ToString();
                        cEmail_Org_ID_v_cond = "cEmail_Org_ID = " + cEmail_Org_ID_v_Value;
                    }
                }

                ID_v cPhoneNumber_Org_ID_v = null;
                string cPhoneNumber_Org_ID_v_cond = "cPhoneNumber_Org_ID is null";
                string cPhoneNumber_Org_ID_v_Value = "null";

                if (fs.Get_ID("cPhoneNumber_Org", "PhoneNumber", PhoneNumber_v, ref cPhoneNumber_Org_ID_v, ref Err))
                {
                    if (cPhoneNumber_Org_ID_v != null)
                    {
                        cPhoneNumber_Org_ID_v_Value = cPhoneNumber_Org_ID_v.v.ToString();
                        cPhoneNumber_Org_ID_v_cond = "cPhoneNumber_Org_ID = " + cPhoneNumber_Org_ID_v_Value;
                    }
                }

                ID_v cFaxNumber_Org_ID_v = null;
                string cFaxNumber_Org_ID_v_cond = "cFaxNumber_Org_ID is null";
                string cFaxNumber_Org_ID_v_Value = "null";

                if (fs.Get_ID("cFaxNumber_Org", "FaxNumber", FaxNumber_v, ref cFaxNumber_Org_ID_v, ref Err))
                {
                    if (cFaxNumber_Org_ID_v != null)
                    {
                        cFaxNumber_Org_ID_v_Value = cFaxNumber_Org_ID_v.v.ToString();
                        cFaxNumber_Org_ID_v_cond = "cFaxNumber_Org_ID = " + cFaxNumber_Org_ID_v_Value;
                    }
                }



                long_v Logo_ID_v = null;
                string Atom_Logo_ID_cond = "Atom_Logo_ID is null";
                string Atom_Logo_ID_Value = "null";
                // = null;
                //if (Logo != null)
                //{
                //    Image_Data_v = new byte_array_v();
                //    Image_Data_v.v = DBtypesFunc.imageToByteArray(Logo, Logo.RawFormat);
                //}
                if (f_Atom_Logo.Get(Logo_Hash_v, Image_Data_v, Logo_Description_v, ref Logo_ID_v))
                {
                    if (Logo_ID_v != null)
                    {
                        Atom_Logo_ID_Value = Logo_ID_v.v.ToString();
                        Atom_Logo_ID_cond = "Atom_Logo_ID = " + Atom_Logo_ID_Value;
                    }
                }


                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                if (BankName_v != null)
                {
                    BankName_Value = "@par_BankName";
                    SQL_Parameter par_BankName = new SQL_Parameter(BankName_Value, SQL_Parameter.eSQL_Parameter.Nvarchar, false, BankName_v.v);
                    lpar.Add(par_BankName);
                    BankName_condition = " BankName = " + par_BankName.Name + " ";
                }
                else
                {
                    BankName_condition = " BankName is null ";
                    BankName_Value = "null";
                }

                if (TRR_v != null)
                {
                    TRR_Value = "@par_TRR";
                    SQL_Parameter par_TRR = new SQL_Parameter(TRR_Value, SQL_Parameter.eSQL_Parameter.Nvarchar, false, TRR_v.v);
                    lpar.Add(par_TRR);
                    TRR_condition = " TRR = " + par_TRR.Name + " ";
                }
                else
                {
                    TRR_condition = " TRR is null ";
                    TRR_Value = "null";
                }

                string Atom_cAddress_Org_ID_condition = null;
                if (cAdressAtom_Org_iD_v != null)
                {
                    Atom_cAddress_Org_ID_condition = " Atom_cAddress_Org_ID = " + cAdressAtom_Org_iD_v.v.ToString();
                }
                else
                {
                    Atom_cAddress_Org_ID_condition = " Atom_cAddress_Org_ID is null ";
                }


                string sql_select = "select ID from Atom_OrganisationData where Atom_Organisation_ID =" + Atom_Organisation_ID.ToString() + @" and 
                                                                                    " + Atom_cAddress_Org_ID_condition + @" and  
                                                                                    " + cHomePage_Org_ID_v_cond + @" and  
                                                                                    " + cEmail_Org_ID_v_cond + @" and  
                                                                                    " + cPhoneNumber_Org_ID_v_cond + @" and  
                                                                                    " + cFaxNumber_Org_ID_v_cond + @" and  
                                                                                    " + BankName_condition + @" and  
                                                                                    " + TRR_condition + @" and
                                                                                    " + Atom_Logo_ID_cond;
                DataTable dt = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt, sql_select, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (Atom_OrganisationData_ID_v == null)
                        {
                            Atom_OrganisationData_ID_v = new long_v();
                        }
                        Atom_OrganisationData_ID_v.v = (long)dt.Rows[0]["ID"];
                        return true;
                    }
                    else
                    {
                        string sql_insert = @"insert into Atom_OrganisationData (Atom_Organisation_ID,Atom_cAddress_Org_ID,cHomePage_Org_ID,cEmail_Org_ID,cPhoneNumber_Org_ID,cFaxNumber_Org_ID,BankName,TRR,Atom_Logo_ID) values (
                                                                                    " + Atom_Organisation_ID.ToString() + @",
                                                                                    " + cAdressAtom_Org_iD_v.v.ToString() + @",
                                                                                    " + cHomePage_Org_ID_v_Value + @",
                                                                                    " + cEmail_Org_ID_v_Value + @",
                                                                                    " + cPhoneNumber_Org_ID_v_Value + @",
                                                                                    " + cFaxNumber_Org_ID_v_Value + @",
                                                                                    " + BankName_Value + @",
                                                                                    " + TRR_Value + @",
                                                                                    " + Atom_Logo_ID_Value + ")";
                        object oret = null;
                        long Atom_OrganisationData_ID = -1;
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_insert, lpar, ref Atom_OrganisationData_ID, ref oret, ref Err, "Atom_OrganisationData"))
                        {
                            if (Atom_OrganisationData_ID_v == null)
                            {
                                Atom_OrganisationData_ID_v = new long_v();
                            }
                            Atom_OrganisationData_ID_v.v = Atom_OrganisationData_ID;
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_Atom_OrganisationData:Get:sql=" + sql_insert + "\r\nErr=" + Err);
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_OrganisationData:Get:sql=" + sql_select + "\r\nErr=" + Err);
                }
            }
            return false;
        }

        public static bool GetData(long Atom_Organisation_ID,
                                ref string Name,
                                ref string Tax_ID,
                                ref string Registration_ID,
                                ref UniversalInvoice.Address Address,
                                ref string PhoneNumber,
                                ref string FaxNumber,
                                ref string Email,
                                ref string HomePage,
                                ref string OrganisationType,
                                ref string BankName,
                                ref string BankAccount,
                                ref string Logo_Hash,
                                ref Image  LogoImage,
                                ref string Logo_Description
                                )
        {
            string Err = null;
            string sql = @"select 
                            Atom_OrganisationData_$_aorg_$$Name,
                                Atom_OrganisationData_$_aorg_$$Tax_ID,
                                Atom_OrganisationData_$_aorg_$$Registration_ID,
                                Atom_OrganisationData_$_acadrorg_$_astrnorg_$$StreetName,
                                Atom_OrganisationData_$_acadrorg_$_ahounorg_$$HouseNumber,
                                Atom_OrganisationData_$_acadrorg_$_acitorg_$$City,
                                Atom_OrganisationData_$_acadrorg_$_aziporg_$$ZIP,
                                Atom_OrganisationData_$_acadrorg_$_astorg_$$State,
                                Atom_OrganisationData_$_acadrorg_$_acouorg_$$Country,
                                Atom_OrganisationData_$_cphnnorg_$$PhoneNumber,
                                Atom_OrganisationData_$_cfaxnorg_$$FaxNumber,
                                Atom_OrganisationData_$_cemailorg_$$Email,
                                Atom_OrganisationData_$_chomepgorg_$$HomePage,
                                Atom_OrganisationData_$_orgt_$$OrganisationTYPE,
                                Atom_OrganisationData_$$BankName,
                                Atom_OrganisationData_$$TRR,
                                Atom_OrganisationData_$_alogo.Image_Hash AS Atom_OrganisationData_$_alogo_$$Image_Hash,
                                Atom_OrganisationData_$_alogo.Image_Data AS Atom_OrganisationData_$_alogo_$$Image_Data,
                                Atom_OrganisationData_$_alogo.Description AS Atom_OrganisationData_$_alogo_$$Description
                                from Atom_OrganisationData_VIEW where Atom_OrganisationData_$_aorg_$$ID = " + Atom_Organisation_ID.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql,null , ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Name = DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$_aorg_$$Name"]);
                    Tax_ID = DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$_aorg_$$Tax_ID"]);
                    Registration_ID = DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$_aorg_$$Registration_ID"]);
                    Address.StreetName = DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$_acadrorg_$_astrnorg_$$StreetName"]);
                    Address.HouseNumber = DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$_acadrorg_$_ahounorg_$$HouseNumber"]);
                    Address.City = DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$_acadrorg_$_acitorg_$$City"]);
                    Address.ZIP = DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$_acadrorg_$_aziporg_$$ZIP"]);
                    Address.State = DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$_acadrorg_$_astorg_$$State"]);
                    Address.Country = DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$_acadrorg_$_acouorg_$$Country"]);
                    PhoneNumber = DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$_cphnnorg_$$PhoneNumber"]);
                    FaxNumber = DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$_cfaxnorg_$$FaxNumber"]);
                    Email = DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$_cemailorg_$$Email"]);
                    HomePage = DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$_chomepgorg_$$HomePage"]);
                    OrganisationType = DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$_orgt_$$OrganisationTYPE"]);
                    BankName = DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$$BankName"]);
                    BankAccount = DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$$TRR"]);
                    Logo_Hash = DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$_alogo.Image_Hash AS Atom_OrganisationData_$_alogo_$$Image_Hash"]);
                    LogoImage = DBTypes.func._set_Image(dt.Rows[0]["Atom_OrganisationData_$_alogo.Image_Data AS Atom_OrganisationData_$_alogo_$$Image_Data"]);
                    Logo_Description = DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$_alogo.Description AS Atom_OrganisationData_$_alogo_$$Description"]);
                    return true;
                }
                else
                {
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_OrganisationData:GetData:sql=" + sql + "\r\nErr=" + Err);
            }
            return false;
        }

        public static UniversalInvoice.Organisation GetData(ltext token_prefix,long Atom_Organisation_ID)
        {
            string Err = null;
            UniversalInvoice.Organisation univ_org = null;
            string sql = @"select 
                            Atom_OrganisationData_$_aorg_$$Name,
                                Atom_OrganisationData_$_aorg_$$Tax_ID,
                                Atom_OrganisationData_$_aorg_$$Registration_ID,
                                Atom_OrganisationData_$_acadrorg_$_astrnorg_$$StreetName,
                                Atom_OrganisationData_$_acadrorg_$_ahounorg_$$HouseNumber,
                                Atom_OrganisationData_$_acadrorg_$_acitorg_$$City,
                                Atom_OrganisationData_$_acadrorg_$_aziporg_$$ZIP,
                                Atom_OrganisationData_$_acadrorg_$_astorg_$$State,
                                Atom_OrganisationData_$_acadrorg_$_acouorg_$$Country,
                                Atom_OrganisationData_$_cphnnorg_$$PhoneNumber,
                                Atom_OrganisationData_$_cfaxnorg_$$FaxNumber,
                                Atom_OrganisationData_$_cemailorg_$$Email,
                                Atom_OrganisationData_$_chomepgorg_$$HomePage,
                                Atom_OrganisationData_$_orgt_$$OrganisationTYPE,
                                Atom_OrganisationData_$$BankName,
                                Atom_OrganisationData_$$TRR,
                                Atom_OrganisationData_$_alogo.Image_Hash AS Atom_OrganisationData_$_alogo_$$Image_Hash,
                                Atom_OrganisationData_$_alogo.Image_Data AS Atom_OrganisationData_$_alogo_$$Image_Data,
                                Atom_OrganisationData_$_alogo.Description AS Atom_OrganisationData_$_alogo_$$Description
                                from Atom_OrganisationData_VIEW where Atom_OrganisationData_$_aorg_$$ID = " + Atom_Organisation_ID.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, null, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    univ_org = new UniversalInvoice.Organisation(token_prefix,DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$_aorg_$$Name"]),
                                                         DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$_aorg_$$Tax_ID"]),
                                                         DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$_aorg_$$Registration_ID"]),
                                                         null,
                                                         DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$$BankName"]),
                                                         DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$$TRR"]),
                                                         DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$_cemailorg_$$Email"]),
                                                         DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$_chomepgorg_$$HomePage"]),
                                                         DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$_cphnnorg_$$PhoneNumber"]),
                                                         DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$_cfaxnorg_$$FaxNumber"]),
                                                         DBTypes.func._set_byte_array(dt.Rows[0]["Atom_OrganisationData_$_alogo.Image_Data AS Atom_OrganisationData_$_alogo_$$Image_Data"]),

                                                        DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$_acadrorg_$_astrnorg_$$StreetName"]),
                                                        DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$_acadrorg_$_ahounorg_$$HouseNumber"]),
                                                        DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$_acadrorg_$_aziporg_$$ZIP"]),
                                                        DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$_acadrorg_$_acitorg_$$City"]),
                                                        DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$_acadrorg_$_astorg_$$State"]),
                                                        DBTypes.func._set_string(dt.Rows[0]["Atom_OrganisationData_$_acadrorg_$_acouorg_$$Country"]));
                    return univ_org;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_OrganisationData:GetData:sql=" + sql + "\r\nErr=" + Err);
            }
            return null;
        }

    }
}
