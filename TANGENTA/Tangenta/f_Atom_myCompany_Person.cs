using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BlagajnaTableClass;
using SQLTableControl;
using System.Windows.Forms.VisualStyles;
using LanguageControl;
using DBTypes;
using DBConnectionControl40;
using System.Windows.Forms;

namespace Tangenta
{
    public static class f_Atom_myCompany_Person
    {
        internal static myOrg.enum_GetCompany_Person_Data Get(long myCompany_Person_ID, ref long Atom_myCompany_Person_ID, ref string_v office_name)
        {
            string Err = null;
            DataTable dt = new DataTable();
            long myCompany_ID = -1;
            long Office_ID = -1;
            long Person_ID = -1;
            if (Find_myCompany_Office(myCompany_Person_ID, ref Person_ID, ref myCompany_ID, ref Office_ID, ref Err))
            {
                long Atom_myCompany_ID = -1;
                myOrg.enum_GetCompany_Person_Data Result_enum_GetCompany_Person_Data = f_Atom_myCompany.Get(myCompany_ID, ref Atom_myCompany_ID);
                if (Result_enum_GetCompany_Person_Data == myOrg.enum_GetCompany_Person_Data.MyCompany_Data_OK)
                {
                    long Atom_Office_ID = -1;
                    if (f_Atom_Office.Get(Office_ID,ref Atom_Office_ID))
                    { 
                        string_v UserName_v = null; 
                        string_v Job_v = null; 
                        string_v Description_v = null; 
                        bool_v   Gender_v = null;
                        string_v FirstName_v = null;
                        string_v LastName_v = null;
                        DateTime_v DateOfBirth_v = null;
                        int_v    Tax_ID_v = null;
                        string_v Registration_ID_v = null;
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
                        
                        string sql = @"select
                                        myCompany_Person_$_per_$$ID,
                                        myCompany_Person_$$UserName,
                                        myCompany_Person_$$Job,
                                        myCompany_Person_$$Description,
                                        myCompany_Person_$_per_$$Gender,
                                        myCompany_Person_$_per_$_cfn_$$FirstName,
                                        myCompany_Person_$_per_$_cln_$$LastName,
                                        myCompany_Person_$_per_$$DateOfBirth,
                                        myCompany_Person_$_per_$$Tax_ID,
                                        myCompany_Person_$_per_$$Registration_ID,
                                        myCompany_Person_$_office_$$Name
                                        from myCompany_Person_VIEW where ID = " + myCompany_Person_ID.ToString();
                        if (DBSync.DBSync.ReadDataTable(ref dt, sql, null, ref Err))
                        {
                            if (dt.Rows.Count>0)
                            {
                                long_v Person_ID_v = null;
                                Person_ID_v =  func.set_long(dt.Rows[0]["myCompany_Person_$_per_$$ID"]);
                                UserName_v = func.set_string(dt.Rows[0]["myCompany_Person_$$UserName"]);
                                Job_v = func.set_string(dt.Rows[0]["myCompany_Person_$$Job"]);
                                Description_v= func.set_string(dt.Rows[0]["myCompany_Person_$$Description"]);
                                Gender_v  =  func.set_bool(dt.Rows[0]["myCompany_Person_$_per_$$Gender"]);
                                FirstName_v = func.set_string(dt.Rows[0]["myCompany_Person_$_per_$_cfn_$$FirstName"]);
                                LastName_v = func.set_string(dt.Rows[0]["myCompany_Person_$_per_$_cln_$$LastName"]);
                                DateOfBirth_v = func.set_DateTime(dt.Rows[0]["myCompany_Person_$_per_$$DateOfBirth"]);
                                Tax_ID_v = func.set_int(dt.Rows[0]["myCompany_Person_$_per_$$Tax_ID"]);
                                Registration_ID_v = func.set_string(dt.Rows[0]["myCompany_Person_$_per_$$Registration_ID"]);
                                office_name = func.set_string(dt.Rows[0]["myCompany_Person_$_office_$$Name"]);
                                DataTable dt_PersonData = new DataTable();
                                sql = @"select
                                        PersonData_$_cgsmnper_$$GsmNumber,
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
                                        PersonData_$_perimg_$$Image_Data
                                        from PersonData_VIEW where PersonData_$_per_$$ID = "+ Person_ID.ToString();

                                if (DBSync.DBSync.ReadDataTable(ref dt_PersonData, sql, null, ref Err))
                                {
                                    if (dt_PersonData.Rows.Count>0)
                                    {
                                        GsmNumber_v = func.set_string(dt_PersonData.Rows[0]["PersonData_$_cgsmnper_$$GsmNumber"]);
                                        PhoneNumber_v = func.set_string(dt_PersonData.Rows[0]["PersonData_$_cphnnper_$$PhoneNumber"]);
                                        Email_v = func.set_string(dt_PersonData.Rows[0]["PersonData_$_cemailper_$$Email"]);
                                        StreetName_v = func.set_string(dt_PersonData.Rows[0]["PersonData_$_cadrper_$_cstrnper_$$StreetName"]);
                                        HouseNumber_v = func.set_string(dt_PersonData.Rows[0]["PersonData_$_cadrper_$_chounper_$$HouseNumber"]);
                                        City_v = func.set_string(dt_PersonData.Rows[0]["PersonData_$_cadrper_$_ccitper_$$City"]);
                                        ZIP_v = func.set_string(dt_PersonData.Rows[0]["PersonData_$_cadrper_$_zipper_$$ZIP"]);
                                        State_v = func.set_string(dt_PersonData.Rows[0]["PersonData_$_cadrper_$_cstper_$$State"]);
                                        Country_v = func.set_string(dt_PersonData.Rows[0]["PersonData_$_cadrper_$_ccouper_$$Country"]);
                                        CardNumber_v = func.set_string(dt_PersonData.Rows[0]["PersonData_$$CardNumber"]);
                                        CardType_v = func.set_string(dt_PersonData.Rows[0]["PersonData_$_cardtper_$$CardType"]);
                                        Image_Hash_v = func.set_string(dt_PersonData.Rows[0]["PersonData_$_perimg_$$Image_Hash"]);
                                        Image_Data_v = func.set_byte_array(dt_PersonData.Rows[0]["PersonData_$_perimg_$$Image_Data"]);
                                    }
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:f_Atom_myCompany_Person:Get:sql="+sql+"\r\nErr="+Err);
                                    return myOrg.enum_GetCompany_Person_Data.Error_Load_MyCompany_data;
                                }

                                long_v Atom_Person_ID = null;
                                if (f_Atom_Person.Get( Gender_v,
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
                                                        ref Atom_Person_ID))
                                {

                                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                                    string scond_UserName = null;
                                    string sval_UserName = "null";
                                    if (UserName_v != null)
                                    {
                                        string spar_UserName = "@par_UserName";
                                        SQL_Parameter par_UserName = new SQL_Parameter(spar_UserName, SQL_Parameter.eSQL_Parameter.Nvarchar, false, UserName_v.v);
                                        lpar.Add(par_UserName);
                                        scond_UserName = "UserName = " + spar_UserName;
                                        sval_UserName = spar_UserName;
                                    }
                                    else
                                    {
                                        scond_UserName = "UserName is null";
                                        sval_UserName = "null";
                                    }

                                    string scond_Atom_Office_ID = null;
                                    string sval_Atom_Office_ID = "null";
                                    if (Atom_Office_ID >= 0)
                                    {
                                        string spar_Atom_Office_ID = "@par_Atom_Office_ID";
                                        SQL_Parameter par_Atom_Office_ID = new SQL_Parameter(spar_Atom_Office_ID, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Atom_Office_ID);
                                        lpar.Add(par_Atom_Office_ID);
                                        scond_Atom_Office_ID = "Atom_Office_ID = " + spar_Atom_Office_ID;
                                        sval_Atom_Office_ID = spar_Atom_Office_ID;
                                    }
                                    else
                                    {
                                        scond_Atom_Office_ID = "Atom_Office_ID is null";
                                        sval_Atom_Office_ID = "null";
                                    }

                                    string scond_Atom_Person_ID = null;
                                    string sval_Atom_Person_ID = "null";
                                    if (Atom_Person_ID !=null)
                                    {
                                        string spar_Atom_Person_ID = "@par_Atom_Person_ID";
                                        SQL_Parameter par_Atom_Person_ID = new SQL_Parameter(spar_Atom_Person_ID, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Atom_Person_ID.v);
                                        lpar.Add(par_Atom_Person_ID);
                                        scond_Atom_Person_ID = "Atom_Person_ID = " + spar_Atom_Person_ID;
                                        sval_Atom_Person_ID = spar_Atom_Person_ID;
                                    }
                                    else
                                    {
                                        scond_Atom_Person_ID = "Atom_Person_ID is null";
                                        sval_Atom_Person_ID = "null";
                                    }


                                    string scond_Job = null;
                                    string sval_Job = "null";
                                    if (Job_v != null)
                                    {
                                        string spar_Job = "@par_Job";
                                        SQL_Parameter par_Job = new SQL_Parameter(spar_Job, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Job_v.v);
                                        lpar.Add(par_Job);
                                        scond_Job = "Job = " + spar_Job;
                                        sval_Job = spar_Job;
                                    }
                                    else
                                    {
                                        scond_Job = "Job is null";
                                        sval_Job = "null";
                                    }
                                    string scond_Description = null;
                                    string sval_Description = "null";
                                    if (Description_v != null)
                                    {
                                        string spar_Description = "@par_Description";
                                        SQL_Parameter par_Description = new SQL_Parameter(spar_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Description_v.v);
                                        lpar.Add(par_Description);
                                        scond_Description = "Description = " + spar_Description;
                                        sval_Description = spar_Description;
                                    }
                                    else
                                    {
                                        scond_Description = "Description is null";
                                        sval_Description = "null";
                                    }

                                    sql = @"select ID from atom_mycompany_person where ("+scond_UserName+") and ("+scond_Atom_Office_ID+ ") and (" + scond_Atom_Person_ID + ")and(" + scond_Job+")and("+scond_Description+")";
                                    dt.Clear();
                                    dt.Columns.Clear();
                                    if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                                    {
                                        if (dt.Rows.Count>0)
                                        {
                                            Atom_myCompany_Person_ID = (long)dt.Rows[0]["ID"];
                                            return myOrg.enum_GetCompany_Person_Data.MyCompany_Data_OK;;
                                        }
                                        else
                                        {
                                            sql = @"insert into  atom_mycompany_person (UserName,Atom_Office_ID,Atom_Person_ID,Job,Description)values(" + sval_UserName+","+sval_Atom_Office_ID+"," + sval_Atom_Person_ID + "," + sval_Job+","+sval_Description+")";
                                            dt.Clear();
                                            dt.Columns.Clear();
                                            object oret = null;
                                            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar,ref Atom_myCompany_Person_ID,ref oret, ref Err,"atom_mycompany_person"))
                                            {
                                                return myOrg.enum_GetCompany_Person_Data.MyCompany_Data_OK;
                                            }
                                            else
                                            {
                                                LogFile.Error.Show("ERROR:f_Atom_myCompany_Person:Get:sql="+sql+"\r\nErr="+Err);
                                                return myOrg.enum_GetCompany_Person_Data.Error_Load_MyCompany_data;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        LogFile.Error.Show("ERROR:f_Atom_myCompany_Person:Get:sql="+sql+"\r\nErr="+Err);
                                        return myOrg.enum_GetCompany_Person_Data.Error_Load_MyCompany_data;
                                    }
                                }
                                else
                                {
                                    return myOrg.enum_GetCompany_Person_Data.Error_Load_MyCompany_data;
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:f_Atom_myCompany_Person:Get:myCompany_Person for myCompany_Person_ID = " +myCompany_Person_ID.ToString()+ " not found !");
                                return myOrg.enum_GetCompany_Person_Data.Error_Load_MyCompany_data;
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_Atom_myCompany_Person:Get:slq="+sql+"\r\nErr="+Err);
                            return myOrg.enum_GetCompany_Person_Data.Error_Load_MyCompany_data;
                        }
                    }
                    else
                    {
                        return myOrg.enum_GetCompany_Person_Data.Error_Load_MyCompany_data;
                    }
                }
                else
                {
                    return Result_enum_GetCompany_Person_Data;
                }
            }
            else
            {
                if (Err == null)
                {
                    return myOrg.enum_GetCompany_Person_Data.No_MyCompanyData;
                }
                else
                {
                    return myOrg.enum_GetCompany_Person_Data.Error_Load_MyCompany_data;
                }
            }
        }


        private static bool Find_myCompany_Office(long myCompany_Person_ID, ref long Person_ID, ref long myCompany_ID, ref long Office_ID, ref string Err)
        {
            DataTable dt = new DataTable();
            string smyCompany_Person_ID = myCompany_Person_ID.ToString();
            string sql = @"select mcp.Office_ID,
                                  o.myCompany_ID,
                                  mcp.Person_ID 
                                  from myCompany_Person mcp
                                  inner join Office o on mcp.Office_ID = o.ID
                                  where mcp.ID = " + smyCompany_Person_ID;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    myCompany_ID = (long)dt.Rows[0]["myCompany_ID"];
                    Person_ID = (long)dt.Rows[0]["Person_ID"];
                    Office_ID = (long)dt.Rows[0]["Office_ID"];
                    return true;
                }
                else
                {
                    myCompany_ID = -1;
                    Person_ID = -1;
                    Err = null;
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_myCompany_Person:Find_myCompany:" + sql + "\r\n:Err=" + Err);
                return false;
            }

        }
    }
}
