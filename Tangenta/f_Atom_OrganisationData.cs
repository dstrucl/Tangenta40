using BlagajnaTableClass;
using DBConnectionControl40;
using DBTypes;
using SQLTableControl;
using System;
using System.Collections.Generic;
using System.Data;
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
                        if (Atom_OrganisationData_ID_v== null)
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
                    }
                }
            }
            return false;
        }

    }
}
