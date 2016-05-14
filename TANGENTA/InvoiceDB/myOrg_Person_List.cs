#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBTypes;
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
        public static bool Get(long myOrganisation_id, ref List<myOrg_Person> myOrg_Person_list)
        {

            DataTable dt = new DataTable();
            myOrg_Person_list.Clear();
            string sql = null;
            sql = @"select
                        myOrganisation_Person_$$UserName,
                        myOrganisation_Person_$$Password,
                        myOrganisation_Person_$$Job,
                        myOrganisation_Person_$$Active,
                        myOrganisation_Person_$$Description,
                        myOrganisation_Person_$_per_$$ID,
                        myOrganisation_Person_$_per_$$Gender,
                        myOrganisation_Person_$_per_$_cfn_$$FirstName,
                        myOrganisation_Person_$_per_$_cln_$$LastName,
                        myOrganisation_Person_$_per_$$DateOfBirth,
                        myOrganisation_Person_$_per_$$Tax_ID,
                        myOrganisation_Person_$_per_$$Registration_ID,
                        myOrganisation_Person_$_office_$$ID,
                        myOrganisation_Person_$_office_$$Name,
                        myOrganisation_Person_$_office_$_mo_$$ID,
                        myOrganisation_Person_$_office_$_mo_$_orgd_$_org_$$ID
                        FROM myOrganisation_Person_VIEW where myOrganisation_Person_$_office_$_mo_$$ID = " + myOrganisation_id.ToString();

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
                        xmp.UserName_v = tf.set_string(dr["myOrganisation_Person_$$UserName"]);
                        xmp.Password_v = tf.set_string(dr["myOrganisation_Person_$$Password"]);
                        xmp.Job_v = tf.set_string(dr["myOrganisation_Person_$$Job"]);
                        xmp.Active_v = tf.set_bool(dr["myOrganisation_Person_$$Active"]);
                        xmp.Description_v = tf.set_string(dr["myOrganisation_Person_$$Description"]);
                        xmp.Gender_v = tf.set_bool(dr["myOrganisation_Person_$_per_$$Gender"]);
                        xmp.FirstName_v = tf.set_string(dr["myOrganisation_Person_$_per_$_cfn_$$FirstName"]);
                        xmp.LastName_v = tf.set_string(dr["myOrganisation_Person_$_per_$_cln_$$LastName"]);
                        xmp.DateOfBirth_v = tf.set_DateTime(dr["myOrganisation_Person_$_per_$$DateOfBirth"]);
                        xmp.Tax_ID_v = tf.set_string(dr["myOrganisation_Person_$_per_$$Tax_ID"]);
                        xmp.Registration_ID_v = tf.set_string(dr["myOrganisation_Person_$_per_$$Registration_ID"]);
                        xmp.myOrg_Office.ID_v = tf.set_long(dr["myOrganisation_Person_$_office_$$ID"]);
                        xmp.myOrg_Office.Name_v = tf.set_string(dr["myOrganisation_Person_$_office_$$Name"]);
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
