#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TangentaTableClass;
using CodeTables;
using System.Windows.Forms.VisualStyles;
using LanguageControl;
using DBTypes;
using DBConnectionControl40;
using System.Windows.Forms;

namespace TangentaDB
{
    public static class f_Atom_myOrganisation_Person
    {
        public static bool Get(ID myOrganisation_Person_ID, ref ID Atom_myOrganisation_Person_ID, ref string_v office_name, Transaction transaction)
        {
            string Err = null;
            DataTable dt = new DataTable();
            ID myOrganisation_ID = null;
            ID Office_ID = null;
            ID Person_ID = null;
            if (Find_myOrganisation_Office(myOrganisation_Person_ID, ref Person_ID, ref myOrganisation_ID, ref Office_ID, ref Err))
            {
                ID Atom_myOrganisation_ID = null;
                if (f_Atom_myOrganisation.Get(myOrganisation_ID, ref Atom_myOrganisation_ID, transaction))
                {
                    ID Atom_Office_ID = null;
                    if (f_Atom_Office.Get(Office_ID,ref Atom_Office_ID, transaction))
                    {
                        DataTable dtOfficeData_of_Office_ID = new DataTable();
                        if (f_Office_Data.Read(Office_ID, ref dtOfficeData_of_Office_ID))
                        {
                            if (dtOfficeData_of_Office_ID!=null)
                            {
                                int iCount = dtOfficeData_of_Office_ID.Rows.Count;
                                int i = 0;
                                if (iCount>0)
                                {
                                    for (i=0;i< iCount;i++)
                                    {
                                        ID OfficeData_ID = new ID(dtOfficeData_of_Office_ID.Rows[i]["ID"]);
                                        ID Atom_Office_Data_ID = null;
                                        if (!f_Atom_Office_Data.Get(OfficeData_ID, ref Atom_Office_Data_ID,transaction))
                                        {
                                            return false;
                                        }
                                    }
                                    string_v Job_v = null;
                                    string_v Description_v = null;
                                    bool_v Gender_v = null;
                                    string_v FirstName_v = null;
                                    string_v LastName_v = null;
                                    DateTime_v DateOfBirth_v = null;
                                    string_v Tax_ID_v = null;
                                    string_v Registration_ID_v = null;
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
                                    short_v Country_ISO_3166_num_v = null;
                                    string_v State_v = null;
                                    string_v CardNumber_v = null;
                                    string_v CardType_v = null;
                                    string_v Image_Hash_v = null;
                                    byte_array_v Image_Data_v = null;

                                    string sql = @"select
                                            myOrganisation_Person_$_per_$$ID,
                                            myOrganisation_Person_$$Job,
                                            myOrganisation_Person_$$Description,
                                            myOrganisation_Person_$_per_$$Gender,
                                            myOrganisation_Person_$_per_$_cfn_$$FirstName,
                                            myOrganisation_Person_$_per_$_cln_$$LastName,
                                            myOrganisation_Person_$_per_$$DateOfBirth,
                                            myOrganisation_Person_$_per_$$Tax_ID,
                                            myOrganisation_Person_$_per_$$Registration_ID,
                                            myOrganisation_Person_$_office_$$Name
                                            from myOrganisation_Person_VIEW where ID = " + myOrganisation_Person_ID.ToString();
                                    if (DBSync.DBSync.ReadDataTable(ref dt, sql, null, ref Err))
                                    {
                                        if (dt.Rows.Count > 0)
                                        {
                                            Person_ID = new ID(dt.Rows[0]["myOrganisation_Person_$_per_$$ID"]);
                                            Job_v = tf.set_string(dt.Rows[0]["myOrganisation_Person_$$Job"]);
                                            Description_v = tf.set_string(dt.Rows[0]["myOrganisation_Person_$$Description"]);
                                            Gender_v = tf.set_bool(dt.Rows[0]["myOrganisation_Person_$_per_$$Gender"]);
                                            FirstName_v = tf.set_string(dt.Rows[0]["myOrganisation_Person_$_per_$_cfn_$$FirstName"]);
                                            LastName_v = tf.set_string(dt.Rows[0]["myOrganisation_Person_$_per_$_cln_$$LastName"]);
                                            DateOfBirth_v = tf.set_DateTime(dt.Rows[0]["myOrganisation_Person_$_per_$$DateOfBirth"]);
                                            Tax_ID_v = tf.set_string(dt.Rows[0]["myOrganisation_Person_$_per_$$Tax_ID"]);
                                            Registration_ID_v = tf.set_string(dt.Rows[0]["myOrganisation_Person_$_per_$$Registration_ID"]);
                                            office_name = tf.set_string(dt.Rows[0]["myOrganisation_Person_$_office_$$Name"]);
                                            DataTable dt_PersonData = new DataTable();
                                            sql = @"select
                                            PersonData_$_cgsmnper_$$GsmNumber,
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
                                            PersonData_$_perimg_$$Image_Data
                                            from PersonData_VIEW where PersonData_$_per_$$ID = " + Person_ID.ToString();

                                            if (DBSync.DBSync.ReadDataTable(ref dt_PersonData, sql, null, ref Err))
                                            {
                                                if (dt_PersonData.Rows.Count > 0)
                                                {
                                                    GsmNumber_v = tf.set_string(dt_PersonData.Rows[0]["PersonData_$_cgsmnper_$$GsmNumber"]);
                                                    PhoneNumber_v = tf.set_string(dt_PersonData.Rows[0]["PersonData_$_cphnnper_$$PhoneNumber"]);
                                                    Email_v = tf.set_string(dt_PersonData.Rows[0]["PersonData_$_cemailper_$$Email"]);
                                                    StreetName_v = tf.set_string(dt_PersonData.Rows[0]["PersonData_$_cadrper_$_cstrnper_$$StreetName"]);
                                                    HouseNumber_v = tf.set_string(dt_PersonData.Rows[0]["PersonData_$_cadrper_$_chounper_$$HouseNumber"]);
                                                    City_v = tf.set_string(dt_PersonData.Rows[0]["PersonData_$_cadrper_$_ccitper_$$City"]);
                                                    ZIP_v = tf.set_string(dt_PersonData.Rows[0]["PersonData_$_cadrper_$_zipper_$$ZIP"]);
                                                    Country_v = tf.set_string(dt_PersonData.Rows[0]["PersonData_$_cadrper_$_cstper_$$Country"]);
                                                    Country_ISO_3166_a2_v = tf.set_string(dt_PersonData.Rows[0]["PersonData_$_cadrper_$_cstper_$$Country_ISO_3166_a2"]);
                                                    Country_ISO_3166_a3_v = tf.set_string(dt_PersonData.Rows[0]["PersonData_$_cadrper_$_cstper_$$Country_ISO_3166_a3"]);
                                                    Country_ISO_3166_num_v = tf.set_short(dt_PersonData.Rows[0]["PersonData_$_cadrper_$_cstper_$$Country_ISO_3166_num"]);
                                                    State_v = tf.set_string(dt_PersonData.Rows[0]["PersonData_$_cadrper_$_ccouper_$$State"]);
                                                    CardNumber_v = tf.set_string(dt_PersonData.Rows[0]["PersonData_$$CardNumber"]);
                                                    CardType_v = tf.set_string(dt_PersonData.Rows[0]["PersonData_$_cardtper_$$CardType"]);
                                                    Image_Hash_v = tf.set_string(dt_PersonData.Rows[0]["PersonData_$_perimg_$$Image_Hash"]);
                                                    Image_Data_v = tf.set_byte_array(dt_PersonData.Rows[0]["PersonData_$_perimg_$$Image_Data"]);
                                                }
                                            }
                                            else
                                            {
                                                LogFile.Error.Show("ERROR:f_Atom_myOrganisation_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                                                return false;
                                            }

                                            ID Atom_Person_ID = null;
                                            if (f_Atom_Person.Get(Gender_v,
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

                                                List<SQL_Parameter> lpar = new List<SQL_Parameter>();


                                                string scond_Atom_Office_ID = null;
                                                string sval_Atom_Office_ID = "null";
                                                if (ID.Validate(Atom_Office_ID))
                                                {
                                                    string spar_Atom_Office_ID = "@par_Atom_Office_ID";
                                                    SQL_Parameter par_Atom_Office_ID = new SQL_Parameter(spar_Atom_Office_ID, false, Atom_Office_ID);
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
                                                if (ID.Validate(Atom_Person_ID))
                                                {
                                                    string spar_Atom_Person_ID = "@par_Atom_Person_ID";
                                                    SQL_Parameter par_Atom_Person_ID = new SQL_Parameter(spar_Atom_Person_ID, false, Atom_Person_ID);
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

                                                sql = @"select ID from atom_myorganisation_person where (" + scond_Atom_Office_ID + ") and (" + scond_Atom_Person_ID + ")and(" + scond_Job + ")and(" + scond_Description + ")";
                                                dt.Clear();
                                                dt.Columns.Clear();
                                                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                                                {
                                                    if (dt.Rows.Count > 0)
                                                    {
                                                        if (Atom_myOrganisation_Person_ID==null)
                                                        {
                                                            Atom_myOrganisation_Person_ID = new ID();
                                                        }
                                                        Atom_myOrganisation_Person_ID.Set(dt.Rows[0]["ID"]);
                                                        return true;
                                                    }
                                                    else
                                                    {
                                                        sql = @"insert into  atom_myorganisation_person (Atom_Office_ID,Atom_Person_ID,Job,Description)values(" + sval_Atom_Office_ID + "," + sval_Atom_Person_ID + "," + sval_Job + "," + sval_Description + ")";
                                                        dt.Clear();
                                                        dt.Columns.Clear();
                                                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_myOrganisation_Person_ID, ref Err, "atom_myorganisation_person"))
                                                        {
                                                            return true;
                                                        }
                                                        else
                                                        {
                                                            LogFile.Error.Show("ERROR:f_Atom_myOrganisation_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                                                            return false;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    LogFile.Error.Show("ERROR:f_Atom_myOrganisation_Person:Get:sql=" + sql + "\r\nErr=" + Err);
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
                                            LogFile.Error.Show("ERROR:f_Atom_myOrganisation_Person:Get:myOrganisation_Person for myOrganisation_Person_ID = " + myOrganisation_Person_ID.ToString() + " not found !");
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        LogFile.Error.Show("ERROR:f_Atom_myOrganisation_Person:Get:slq=" + sql + "\r\nErr=" + Err);
                                        return false;
                                    }
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:f_Atom_myOrganisation_Person:Get:error no Office_Data table for Office_ID = " + Office_ID.ToString());
                                    return false;
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:f_Atom_myOrganisation_Person:Get:error no Office_Data table for Office_ID = "+ Office_ID.ToString());
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
                if (Err == null)
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool Get(ID xAtom_myOrganisation_Person_ID, ref string xAtomOfficeShortName, ref string xAtom_Person_Tax_ID)
        {
            xAtomOfficeShortName = null;
            xAtom_Person_Tax_ID = null;
            string sql = @"select ap.Tax_ID as Atom_Person_Tax_ID,
                            ao.ShortName as Atom_Office_ShortName from 
                            Atom_myOrganisation_Person amop
                            inner join Atom_Person ap on amop.Atom_Person_ID = ap.ID
                            inner join Atom_Office ao on amop.Atom_Office_ID = ao.ID where amop.ID = " + xAtom_myOrganisation_Person_ID.ToString();
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                int iCount = dt.Rows.Count;
                if (iCount > 0)
                {
                    xAtomOfficeShortName = tf._set_string(dt.Rows[0]["Atom_Office_ShortName"]);
                    xAtom_Person_Tax_ID = tf._set_string(dt.Rows[0]["Atom_Person_Tax_ID"]);
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_myOrganisation_Person:Get:" + sql + "\r\n:Err=" + Err);
                return false;
            }
        }

        public static bool Get(ID myOrganisation_Person_ID, ref List<ID> atom_myOrganisation_Person_ID_List)
        {
            string sql = @"select amop.ID as Atom_myOrganisation_Person_ID
	                      from myOrganisation_Person mop 
	                      inner join Person p on mop.Person_ID = p.ID
	                      inner join cFirstName fn on p.cFirstName_ID = fn.iD
	                      left join cLastName ln on p.cLastName_ID = ln.iD
	                      inner join Atom_cFirstName afn on fn.FirstName = afn.FirstName
	                      left join Atom_cLastName aln on aln.LastName = ln.LastName
	                      left join Atom_Person ap on ap.Atom_cFirstName_ID = afn.ID
	                      left join Atom_myOrganisation_Person amop on amop.Atom_Person_ID = ap.ID and ap.Tax_ID = p.Tax_ID and ap.Registration_ID = p.Registration_ID
                          where mop.ID = " + myOrganisation_Person_ID.ToString();
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                int iCount = dt.Rows.Count;
                if (iCount > 0)
                {
                    if (atom_myOrganisation_Person_ID_List==null)
                    {
                        atom_myOrganisation_Person_ID_List = new List<ID>();
                    }
                    else
                    {
                        atom_myOrganisation_Person_ID_List.Clear();
                    }
                    for (int i = 0; i < iCount; i++)
                    {
                        ID xid = tf.set_ID(dt.Rows[i]["Atom_myOrganisation_Person_ID"]);
                        if (ID.Validate(xid))
                        {
                            atom_myOrganisation_Person_ID_List.Add(xid);
                        }
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_myOrganisation_Person:Get:" + sql + "\r\n:Err=" + Err);
                return false;
            }
        }

        private static bool Find_myOrganisation_Office(ID myOrganisation_Person_ID, ref ID Person_ID, ref ID myOrganisation_ID, ref ID Office_ID, ref string Err)
        {
            DataTable dt = new DataTable();
            string smyOrganisation_Person_ID = myOrganisation_Person_ID.ToString();
            string sql = @"select mcp.Office_ID,
                                  o.myOrganisation_ID,
                                  mcp.Person_ID 
                                  from myOrganisation_Person mcp
                                  inner join Office o on mcp.Office_ID = o.ID
                                  where mcp.ID = " + smyOrganisation_Person_ID;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (myOrganisation_ID==null)
                    {
                        myOrganisation_ID = new ID();
                    }
                    myOrganisation_ID.Set(dt.Rows[0]["myOrganisation_ID"]);

                    if (Person_ID==null)
                    {
                        Person_ID = new ID();
                    }
                    Person_ID.Set(dt.Rows[0]["Person_ID"]);
                    if (Office_ID==null)
                    {
                        Office_ID = new ID();
                    }
                    Office_ID.Set(dt.Rows[0]["Office_ID"]);
                    return true;
                }
                else
                {
                    myOrganisation_ID = null;
                    Person_ID = null;
                    Err = null;
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_myOrganisation_Person:Find_myOrganisation:" + sql + "\r\n:Err=" + Err);
                return false;
            }

        }
    }
}
