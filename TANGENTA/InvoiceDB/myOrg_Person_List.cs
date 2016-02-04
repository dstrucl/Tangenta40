﻿using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB
{
    public static class myOrg_Person_List
    {
        public static bool Get(long myCompany_id, ref List<myOrg_Person> myOrg_Person_list)
        {

            DataTable dt = new DataTable();
            myOrg_Person_list.Clear();
            string sql = null;
            sql = @"select
                        myCompany_Person_$$UserName,
                        myCompany_Person_$$Password,
                        myCompany_Person_$$Job,
                        myCompany_Person_$$Active,
                        myCompany_Person_$$Description,
                        myCompany_Person_$_per_$$ID,
                        myCompany_Person_$_per_$$Gender,
                        myCompany_Person_$_per_$_cfn_$$FirstName,
                        myCompany_Person_$_per_$_cln_$$LastName,
                        myCompany_Person_$_per_$$DateOfBirth,
                        myCompany_Person_$_per_$$Tax_ID,
                        myCompany_Person_$_per_$$Registration_ID,
                        myCompany_Person_$_office_$$ID,
                        myCompany_Person_$_office_$$Name,
                        myCompany_Person_$_office_$_mc_$$ID,
                        myCompany_Person_$_office_$_mc_$_orgd_$_org_$$ID
                        FROM myCompany_Person_VIEW where myCompany_Person_$_office_$_mc_$$ID = " + myCompany_id.ToString();

            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    int i = 0;
                    int iCount = dt.Rows.Count;
                    for (i = 0; i < iCount; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        myOrg_Person xmp = new myOrg_Person();
                        xmp.UserName_v = tf.set_string(dr["myCompany_Person_$$UserName"]);
                        xmp.Password_v = tf.set_string(dr["myCompany_Person_$$Password"]);
                        xmp.Job_v = tf.set_string(dr["myCompany_Person_$$Job"]);
                        xmp.Active_v = tf.set_bool(dr["myCompany_Person_$$Active"]);
                        xmp.Description_v = tf.set_string(dr["myCompany_Person_$$Description"]);
                        xmp.Gender_v = tf.set_bool(dr["myCompany_Person_$_per_$$Gender"]);
                        xmp.FirstName_v = tf.set_string(dr["myCompany_Person_$_per_$_cfn_$$FirstName"]);
                        xmp.LastName_v = tf.set_string(dr["myCompany_Person_$_per_$_cln_$$LastName"]);
                        xmp.DateOfBirth_v = tf.set_DateTime(dr["myCompany_Person_$_per_$$DateOfBirth"]);
                        xmp.Tax_ID_v = tf.set_string(dr["myCompany_Person_$_per_$$Tax_ID"]);
                        xmp.Registration_ID_v = tf.set_string(dr["myCompany_Person_$_per_$$Registration_ID"]);
                        xmp.myOrg_Office.ID_v = tf.set_long(dr["myCompany_Person_$_office_$$ID"]);
                        xmp.myOrg_Office.Name_v = tf.set_string(dr["myCompany_Person_$_office_$$Name"]);
                        xmp.myOrg_Office.Get(xmp.myOrg_Office.ID_v);
                        myOrg_Person_list.Add(xmp);
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:MyOrg:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

    }
}