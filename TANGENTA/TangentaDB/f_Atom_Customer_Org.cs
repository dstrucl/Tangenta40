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
    public static class f_Atom_Customer_Org
    {
        public static bool Get(ID Customer_Org_ID, ref ID Atom_Customer_Org_ID, Transaction transaction)
        {
            DataTable dt = new DataTable();
            string sql = @"select orgd.Organisation_ID 
                           from Customer_Org corg
                           inner join  OrganisationData orgd on orgd.ID = corg.OrganisationData_ID
                           where corg.ID = " + Customer_Org_ID.ToString();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    ID Org_ID = new ID(dt.Rows[0]["Organisation_ID"]);
                    dt.Clear();
                    sql = @"select  OrganisationData_$_org_$$Name,
                                    OrganisationData_$_org_$$Tax_ID, 
                                    OrganisationData_$_org_$$Registration_ID,
                                    OrganisationData_$_org_$$TaxPayer,
                                    OrganisationData_$_org_$_cmt1_$$Comment,
                                    OrganisationData_$_orgt_$$OrganisationTYPE,
                                    OrganisationData_$_cadrorg_$_cstrnorg_$$StreetName,
                                    OrganisationData_$_cadrorg_$_chounorg_$$HouseNumber,
                                    OrganisationData_$_cadrorg_$_cziporg_$$ZIP,
                                    OrganisationData_$_cadrorg_$_ccitorg_$$City,
                                    OrganisationData_$_cadrorg_$_ccouorg_$$Country,
                                    OrganisationData_$_cadrorg_$_ccouorg_$$Country_ISO_3166_a2,
                                    OrganisationData_$_cadrorg_$_ccouorg_$$Country_ISO_3166_a3,
                                    OrganisationData_$_cadrorg_$_ccouorg_$$Country_ISO_3166_num,
                                    OrganisationData_$_cadrorg_$_cstorg_$$State,
                                    OrganisationData_$_cphnnorg_$$PhoneNumber,
                                    OrganisationData_$_cfaxnorg_$$FaxNumber,
                                    OrganisationData_$_cemailorg_$$Email,
                                    OrganisationData_$_chomepgorg_$$HomePage,
                                    OrganisationData_$_logo_$$Image_Hash,
                                    OrganisationData_$_logo_$$Image_Data,
                                    OrganisationData_$_logo_$$Description
                                    from OrganisationData_VIEW where OrganisationData_$_org_$$ID = " + Org_ID.ToString();
                    if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            string_v Name_v = tf.set_string(dt.Rows[0]["OrganisationData_$_org_$$Name"]);
                            string_v Tax_ID_v = tf.set_string(dt.Rows[0]["OrganisationData_$_org_$$Tax_ID"]);
                            string_v Registration_ID_v = tf.set_string(dt.Rows[0]["OrganisationData_$_org_$$Registration_ID"]);
                            bool_v TaxPayer_v = tf.set_bool(dt.Rows[0]["OrganisationData_$_org_$$TaxPayer"]);
                            string_v Comment1_v = tf.set_string(dt.Rows[0]["OrganisationData_$_org_$_cmt1_$$Comment"]);
                            string_v OrganisationTYPE_v = tf.set_string(dt.Rows[0]["OrganisationData_$_orgt_$$OrganisationTYPE"]);
                            PostAddress_v Address_v = new PostAddress_v();
                            Address_v.StreetName_v = tf.set_dstring(dt.Rows[0]["OrganisationData_$_cadrorg_$_cstrnorg_$$StreetName"]);
                            Address_v.HouseNumber_v = tf.set_dstring(dt.Rows[0]["OrganisationData_$_cadrorg_$_chounorg_$$HouseNumber"]);
                            Address_v.ZIP_v = tf.set_dstring(dt.Rows[0]["OrganisationData_$_cadrorg_$_cziporg_$$ZIP"]);
                            Address_v.City_v = tf.set_dstring(dt.Rows[0]["OrganisationData_$_cadrorg_$_ccitorg_$$City"]);
                            Address_v.Country_v = tf.set_dstring(dt.Rows[0]["OrganisationData_$_cadrorg_$_ccouorg_$$Country"]);
                            Address_v.Country_ISO_3166_a2_v= tf.set_dstring(dt.Rows[0]["OrganisationData_$_cadrorg_$_ccouorg_$$Country_ISO_3166_a2"]);
                            Address_v.Country_ISO_3166_a3_v = tf.set_dstring(dt.Rows[0]["OrganisationData_$_cadrorg_$_ccouorg_$$Country_ISO_3166_a3"]);
                            Address_v.Country_ISO_3166_num_v = tf.set_dshort(fs.MyConvertToShort(dt.Rows[0]["OrganisationData_$_cadrorg_$_ccouorg_$$Country_ISO_3166_num"]));
                            Address_v.State_v = tf.set_dstring(dt.Rows[0]["OrganisationData_$_cadrorg_$_cstorg_$$State"]);
                            string_v PhoneNumber_v = tf.set_string(dt.Rows[0]["OrganisationData_$_cphnnorg_$$PhoneNumber"]);
                            string_v FaxNumber_v = tf.set_string(dt.Rows[0]["OrganisationData_$_cfaxnorg_$$FaxNumber"]);
                            string_v Email_v = tf.set_string(dt.Rows[0]["OrganisationData_$_cemailorg_$$Email"]);
                            string_v HomePage_v = tf.set_string(dt.Rows[0]["OrganisationData_$_chomepgorg_$$HomePage"]);
                            string_v Image_Hash_v = tf.set_string(dt.Rows[0]["OrganisationData_$_logo_$$Image_Hash"]);
                            byte_array_v Image_Data_v = tf.set_byte_array(dt.Rows[0]["OrganisationData_$_logo_$$Image_Data"]);
                            string_v Description_v = tf.set_string(dt.Rows[0]["OrganisationData_$_logo_$$Description"]);
                            string_v BankName_v = null;
                            string_v TRR_v = null;
                            sql = @"select oacc.Description as OrganisationAccount_Description
                                           o.Name,
                                           bacc.TRR,
                                           bacc.Active
                                    from OrganisationAccount oacc
                                    inner join BankAccount bacc on oacc.BankAccount_ID = bacc.ID
                                    inner join Bank b on bacc.Bank_ID == b.ID
                                    inner join Organisation o on b.Organisation_ID = o.ID
                                    where oacc.Organisation_ID = " + Org_ID.ToString() + " and bacc.Active = 1";
                            dt.Rows.Clear();
                            dt.Columns.Clear();
                            dt.Clear();
                            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                            {
                                if (dt.Rows.Count > 0)
                                {
                                    BankName_v = tf.set_string(dt.Rows[0]["Name"]);
                                    TRR_v = tf.set_string(dt.Rows[0]["TRR"]);
                                }
                            }
                            ID Atom_Organisation_ID = null;
                            ID Atom_OrganisationData_ID = null;
                            if (f_Atom_Organisation.Get(Name_v,
                                                            Tax_ID_v,
                                                            Registration_ID_v,
                                                            TaxPayer_v,
                                                            Comment1_v,
                                                            OrganisationTYPE_v,
                                                            Address_v,
                                                            PhoneNumber_v,
                                                            FaxNumber_v,
                                                            Email_v,
                                                            HomePage_v,
                                                            BankName_v,
                                                            TRR_v,
                                                            Image_Hash_v,
                                                            Image_Data_v,
                                                            Description_v,
                                                            ref Atom_Organisation_ID,
                                                            ref Atom_OrganisationData_ID,
                                                            transaction))
                            {
                                sql = "select ID from Atom_Customer_Org where Atom_Organisation_ID = " + Atom_Organisation_ID.ToString();
                                dt.Clear();
                                if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                                {
                                    if (dt.Rows.Count == 1)
                                    {
                                        if (Atom_Customer_Org_ID == null)
                                        {
                                            Atom_Customer_Org_ID = new ID();
                                        }
                                        Atom_Customer_Org_ID.Set(dt.Rows[0]["ID"]);
                                        return true;
                                    }
                                    else
                                    {
                                        sql = "insert into Atom_Customer_Org (Atom_Organisation_ID) values (" + Atom_Organisation_ID.ToString() + ")";
                                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, null, ref Atom_Customer_Org_ID, ref Err, "Atom_Customer_Org"))
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            LogFile.Error.Show("ERROR:f_Atom_Customer_Org:Get:\r\nsql=" + sql + "\r\nErr=" + Err);
                                            return false;
                                        }
                                    }
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:f_Atom_Customer_Org:Get:\r\nsql=" + sql + "\r\nErr=" + Err);
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
                            LogFile.Error.Show("ERROR:f_Atom_Customer_Org:Get:sql=" + sql + "\ndt.Rows.Count!=1");
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_Customer_Org:Get:sql=" + sql + "\ndt.Rows.Count!=1");
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_Customer_Org:Customer_Org_ID = " + Customer_Org_ID.ToString() + " not found in table Customer_Org !");
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_Customer_Org:Get:sql=" + sql + "\ndt.Rows.Count!=1");
                return false;
            }
        }

        public static UniversalInvoice.Organisation GetData(ltext token_prefix, ID Atom_Customer_Org_ID)
        {
            string sql = "select Atom_Organisation_ID from Atom_Customer_Org where ID = " + Atom_Customer_Org_ID.ToString();
            string Err = null;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt,sql, ref Err))
            {
                if (dt.Rows.Count>0)
                {
                    ID Atom_Organisation_ID = new ID(dt.Rows[0]["Atom_Organisation_ID"]);
                    return f_Atom_OrganisationData.GetData(token_prefix, Atom_Organisation_ID);
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_Atom_Customer_Org:GetData:sql=" + sql + "Err=!(dt.Rows.Count>0)");
                    return null;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Atom_Customer_Org:GetData:sql=" + sql + "Err="+Err);
                return null;
            }
        }


        private static bool Find_Customer(ID Customer_Org_ID, ref ID Org_ID, ref ID Customer_ID)
        {
            string Err = null;
            DataTable dt = new DataTable();
            string sCustomer_Org_ID = Customer_Org_ID.ToString();
            string sql = "select Customer_ID,Org_ID from Customer_Org where ID = " + sCustomer_Org_ID;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Customer_ID==null)
                    {
                        Customer_ID = new ID();
                    }
                    Customer_ID.Set(dt.Rows[0]["Customer_ID"]);
                    if (Org_ID==null)
                    {
                        Org_ID = new ID();
                    }
                    Org_ID.Set(dt.Rows[0]["Org_ID"]);
                    return true;
                }
                else
                {
                    Customer_ID = null;
                    Org_ID = null;
                    LogFile.Error.Show("ERROR:f_Atom_Customer_Org:Find_Customer:No Data row in table Customer_Org for Customer_Org.ID = " + sCustomer_Org_ID);
                    return false;
                }

            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_Customer_Org:Find_Customer:" + sql + "\r\n:Err=" + Err);
                return false;
            }
        }
    }
}
