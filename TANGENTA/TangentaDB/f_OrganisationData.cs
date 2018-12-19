#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using TangentaTableClass;
using DBConnectionControl40;
using DBTypes;
using LanguageControl;
using CodeTables;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_OrganisationData
    {
        public static bool Get(ID Organisation_ID,
                                string_v OrganisationTYPE_v,
                                PostAddress_v Address_v,
                                string_v PhoneNumber_v,
                                string_v FaxNumber_v,
                                string_v Email_v,
                                string_v HomePage_v,
                                string_v Logo_Hash_v,
                                byte_array_v Image_Data_v,
                                string_v Logo_Description_v,
                                ref ID cAdressAtom_Org_iD,
                                ref ID OrganisationData_ID,
                                Transaction transaction)
        {
            string Err = null;
         

            //  long_v Atom_Organisation_ID_v = null;
            ID OrganisationTYPE_ID = null;
            if (f_cOrgTYPE.Get(OrganisationTYPE_v, ref OrganisationTYPE_ID, transaction))
            {
                if (f_cAddress_Org.Get(Address_v, ref cAdressAtom_Org_iD))
                {
                    ID xcHomePage_Org_ID = null;
                    string cHomePage_Org_ID_v_cond = "cHomePage_Org_ID is null";
                    string cHomePage_Org_ID_v_Value = "null";

                    if (fs.Get_ID("cHomePage_Org", "HomePage", HomePage_v, ref xcHomePage_Org_ID, ref Err, transaction))
                    {
                        if (ID.Validate(xcHomePage_Org_ID))
                        {
                            cHomePage_Org_ID_v_Value = xcHomePage_Org_ID.ToString();
                            cHomePage_Org_ID_v_cond = "cHomePage_Org_ID = " + cHomePage_Org_ID_v_Value;
                        }
                    }

                    ID cEmail_Org_ID = null;
                    string cEmail_Org_ID_v_cond = "cEmail_Org_ID is null";
                    string cEmail_Org_ID_v_Value = "null";

                    if (fs.Get_ID("cEmail_Org", "Email", Email_v, ref cEmail_Org_ID, ref Err, transaction))
                    {
                        if (ID.Validate(cEmail_Org_ID))
                        {
                            cEmail_Org_ID_v_Value = cEmail_Org_ID.ToString();
                            cEmail_Org_ID_v_cond = "cEmail_Org_ID = " + cEmail_Org_ID_v_Value;
                        }
                    }

                    ID cPhoneNumber_Org_ID = null;
                    string cPhoneNumber_Org_ID_v_cond = "cPhoneNumber_Org_ID is null";
                    string cPhoneNumber_Org_ID_v_Value = "null";

                    if (fs.Get_ID("cPhoneNumber_Org", "PhoneNumber", PhoneNumber_v, ref cPhoneNumber_Org_ID, ref Err, transaction))
                    {
                        if (ID.Validate(cPhoneNumber_Org_ID))
                        {
                            cPhoneNumber_Org_ID_v_Value = cPhoneNumber_Org_ID.ToString();
                            cPhoneNumber_Org_ID_v_cond = "cPhoneNumber_Org_ID = " + cPhoneNumber_Org_ID_v_Value;
                        }
                    }

                    ID cFaxNumber_Org_ID = null;
                    string cFaxNumber_Org_ID_v_cond = "cFaxNumber_Org_ID is null";
                    string cFaxNumber_Org_ID_v_Value = "null";

                    if (fs.Get_ID("cFaxNumber_Org", "FaxNumber", FaxNumber_v, ref cFaxNumber_Org_ID, ref Err, transaction))
                    {
                        if (ID.Validate(cFaxNumber_Org_ID))
                        {
                            cFaxNumber_Org_ID_v_Value = cFaxNumber_Org_ID.ToString();
                            cFaxNumber_Org_ID_v_cond = "cFaxNumber_Org_ID = " + cFaxNumber_Org_ID_v_Value;
                        }
                    }



                    ID Logo_ID = null;
                    string Logo_ID_cond = "Logo_ID is null";
                    string Logo_ID_Value = "null";
                    // = null;
                    //if (Logo != null)
                    //{
                    //    Image_Data_v = new byte_array_v();
                    //    Image_Data_v.v = DBtypesFunc.imageToByteArray(Logo, Logo.RawFormat);
                    //}
                    if (f_Logo.Get(Logo_Hash_v, Image_Data_v, Logo_Description_v, ref Logo_ID, transaction))
                    {
                        if (ID.Validate(Logo_ID))
                        {
                            Logo_ID_Value = Logo_ID.ToString();
                            Logo_ID_cond = "Logo_ID = " + Logo_ID_Value;
                        }
                    }


                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                    //if (BankName_v != null)
                    //{
                    //    BankName_Value = "@par_BankName";
                    //    SQL_Parameter par_BankName = new SQL_Parameter(BankName_Value, SQL_Parameter.eSQL_Parameter.Nvarchar, false, BankName_v.v);
                    //    lpar.Add(par_BankName);
                    //    BankName_condition = " BankName = " + par_BankName.Name + " ";
                    //}
                    //else
                    //{
                    //    BankName_condition = " BankName is null ";
                    //    BankName_Value = "null";
                    //}

                    //if (TRR_v != null)
                    //{
                    //    TRR_Value = "@par_TRR";
                    //    SQL_Parameter par_TRR = new SQL_Parameter(TRR_Value, SQL_Parameter.eSQL_Parameter.Nvarchar, false, TRR_v.v);
                    //    lpar.Add(par_TRR);
                    //    TRR_condition = " TRR = " + par_TRR.Name + " ";
                    //}
                    //else
                    //{
                    //    TRR_condition = " TRR is null ";
                    //    TRR_Value = "null";
                    //}

                    string cOrgTYPE_ID_condition = null;
                    string cOrgTYPE_ID_value = null;
                    if (OrganisationTYPE_ID != null)
                    {
                        cOrgTYPE_ID_condition = " cOrgTYPE_ID = " + OrganisationTYPE_ID.ToString();
                        cOrgTYPE_ID_value = OrganisationTYPE_ID.ToString();
                    }
                    else
                    {
                        cOrgTYPE_ID_condition = " cOrgTYPE_ID is null ";
                        cOrgTYPE_ID_value = "null";
                    }
                    string cAddress_Org_ID_condition = null;
                    if (cAdressAtom_Org_iD != null)
                    {
                        cAddress_Org_ID_condition = " cAddress_Org_ID = " + cAdressAtom_Org_iD.ToString();
                    }
                    else
                    {
                        cAddress_Org_ID_condition = " cAddress_Org_ID is null ";
                    }


                    string sql_select = "select ID from OrganisationData where Organisation_ID =" + Organisation_ID.ToString() + @" and 
                                                                                    " + cOrgTYPE_ID_condition + @" and  
                                                                                    " + cAddress_Org_ID_condition + @" and  
                                                                                    " + cHomePage_Org_ID_v_cond + @" and  
                                                                                    " + cEmail_Org_ID_v_cond + @" and  
                                                                                    " + cPhoneNumber_Org_ID_v_cond + @" and  
                                                                                    " + cFaxNumber_Org_ID_v_cond + @" and  
                                                                                    " + Logo_ID_cond;
                    DataTable dt = new DataTable();
                    if (DBSync.DBSync.ReadDataTable(ref dt, sql_select, lpar, ref Err))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            if (OrganisationData_ID == null)
                            {
                                OrganisationData_ID = new ID();
                            }
                            OrganisationData_ID.Set(dt.Rows[0]["ID"]);
                            return true;
                        }
                        else
                        {
                            string sql_insert = @"insert into OrganisationData (Organisation_ID,cOrgTYPE_ID,cAddress_Org_ID,cHomePage_Org_ID,cEmail_Org_ID,cPhoneNumber_Org_ID,cFaxNumber_Org_ID,Logo_ID) values (
                                                                                    " + Organisation_ID.ToString() + @",
                                                                                    " + cOrgTYPE_ID_value + @",
                                                                                    " + cAdressAtom_Org_iD.ToString() + @",
                                                                                    " + cHomePage_Org_ID_v_Value + @",
                                                                                    " + cEmail_Org_ID_v_Value + @",
                                                                                    " + cPhoneNumber_Org_ID_v_Value + @",
                                                                                    " + cFaxNumber_Org_ID_v_Value + @",
                                                                                    " + Logo_ID_Value + ")";
                            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_insert, lpar, ref OrganisationData_ID, ref Err, "OrganisationData"))
                            {
                                return true;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:f_OrganisationData:Get:sql=" + sql_insert + "\r\nErr=" + Err);
                            }
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_OrganisationData:Get:sql=" + sql_select + "\r\nErr=" + Err);
                    }
                }
            }
            return false;
        }


        public static bool GetData(long Organisation_ID,
                                ref string Name,
                                ref string Tax_ID,
                                ref string Registration_ID,
                                ref UniversalInvoice.Address Address,
                                ref string PhoneNumber,
                                ref string FaxNumber,
                                ref string Email,
                                ref string HomePage,
                                ref string OrganisationType,
                                ref string Logo_Hash,
                                ref Image LogoImage,
                                ref string Logo_Description
                                )
        {
            string Err = null;
            string sql = @"select 
                            OrganisationData_$_org_$$Name,
                                OrganisationData_$_org_$$Tax_ID,
                                OrganisationData_$_org_$$Registration_ID,
                                OrganisationData_$_cadrorg_$_strnorg_$$StreetName,
                                OrganisationData_$_cadrorg_$_hounorg_$$HouseNumber,
                                OrganisationData_$_cadrorg_$_citorg_$$City,
                                OrganisationData_$_cadrorg_$_ziporg_$$ZIP,
                                OrganisationData_$_cadrorg_$_couorg_$$Country,
                                OrganisationData_$_cadrorg_$_storg_$$State,
                                OrganisationData_$_cphnnorg_$$PhoneNumber,
                                OrganisationData_$_cfaxnorg_$$FaxNumber,
                                OrganisationData_$_cemailorg_$$Email,
                                OrganisationData_$_chomepgorg_$$HomePage,
                                OrganisationData_$_orgt_$$OrganisationTYPE,
                                OrganisationData_$_logo.Image_Hash AS OrganisationData_$_logo_$$Image_Hash,
                                OrganisationData_$_logo.Image_Data AS OrganisationData_$_logo_$$Image_Data,
                                OrganisationData_$_logo.Description AS OrganisationData_$_logo_$$Description
                                from OrganisationData_VIEW where OrganisationData_$_org_$$ID = " + Organisation_ID.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, null, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Name = DBTypes.tf._set_string(dt.Rows[0]["OrganisationData_$_org_$$Name"]);
                    Tax_ID = DBTypes.tf._set_string(dt.Rows[0]["OrganisationData_$_org_$$Tax_ID"]);
                    Registration_ID = DBTypes.tf._set_string(dt.Rows[0]["OrganisationData_$_org_$$Registration_ID"]);
                    Address.StreetName = DBTypes.tf._set_string(dt.Rows[0]["OrganisationData_$_cadrorg_$_strnorg_$$StreetName"]);
                    Address.HouseNumber = DBTypes.tf._set_string(dt.Rows[0]["OrganisationData_$_cadrorg_$_ahounorg_$$HouseNumber"]);
                    Address.City = DBTypes.tf._set_string(dt.Rows[0]["OrganisationData_$_cadrorg_$_acitorg_$$City"]);
                    Address.ZIP = DBTypes.tf._set_string(dt.Rows[0]["OrganisationData_$_cadrorg_$_aziporg_$$ZIP"]);
                    Address.State = DBTypes.tf._set_string(dt.Rows[0]["OrganisationData_$_cadrorg_$_couorg_$$Country"]);
                    Address.State = DBTypes.tf._set_string(dt.Rows[0]["OrganisationData_$_cadrorg_$_storg_$$State"]);
                    PhoneNumber = DBTypes.tf._set_string(dt.Rows[0]["OrganisationData_$_cphnnorg_$$PhoneNumber"]);
                    FaxNumber = DBTypes.tf._set_string(dt.Rows[0]["OrganisationData_$_cfaxnorg_$$FaxNumber"]);
                    Email = DBTypes.tf._set_string(dt.Rows[0]["OrganisationData_$_cemailorg_$$Email"]);
                    HomePage = DBTypes.tf._set_string(dt.Rows[0]["OrganisationData_$_chomepgorg_$$HomePage"]);
                    OrganisationType = DBTypes.tf._set_string(dt.Rows[0]["OrganisationData_$_orgt_$$OrganisationTYPE"]);
                    Logo_Hash = DBTypes.tf._set_string(dt.Rows[0]["OrganisationData_$_logo_$$Image_Hash"]);
                    LogoImage = DBTypes.tf._set_Image(dt.Rows[0]["OrganisationData_$_logo_$$Image_Data"]);
                    Logo_Description = DBTypes.tf._set_string(dt.Rows[0]["OrganisationData_$_logo_$$Description"]);
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

        public static bool DeleteAll()
        {

            return fs.DeleteAll("OrganisationData");
        }
    }
}
