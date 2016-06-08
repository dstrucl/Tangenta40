// Copyright (c) 2011 rubicon IT GmbH
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public class myOrg_Office_FVI_SLO_RealEstate
    {
        public long_v ID_v = null;
        public long_v Office_Data_ID_v = null;
        public int_v BuildingNumber_v = null;
        public int_v BuildingSectionNumber_v = null;
        public string_v Community_v = null;
        public int_v CadastralNumber_v = null;
        public DateTime_v ValidityDate_v = null;
        public string_v ClosingTag_v = null;
        public string_v SoftwareSupplier_TaxNumber_v = null;
        public string_v PremiseType_v = null;

        public bool Get(long_v xOffice_Data_ID_v)
        {
            string Err = null;
            ID_v = null;
            Office_Data_ID_v = null;
            BuildingNumber_v = null;
            BuildingSectionNumber_v = null;
            Community_v = null;
            CadastralNumber_v = null;
            ValidityDate_v = null;
            ClosingTag_v = null;
            SoftwareSupplier_TaxNumber_v = null;
            PremiseType_v = null;

            if (xOffice_Data_ID_v != null)
            {
                string sql = @"SELECT 
                                    ID,
                                    Office_Data_ID,
                                    BuildingNumber,
                                    BuildingSectionNumber,
                                    Community,
                                    CadastralNumber,
                                    ValidityDate,
                                    ClosingTag,
                                    SoftwareSupplier_TaxNumber,
                                    PremiseType
                              FROM FVI_SLO_RealEstateBP
                              where Office_Data_ID = " + xOffice_Data_ID_v.v.ToString();
                DataTable dt = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        ID_v = tf.set_long(dt.Rows[0]["ID"]);
                        Office_Data_ID_v = tf.set_long(dt.Rows[0]["Office_Data_ID"]);
                        BuildingNumber_v = tf.set_int(dt.Rows[0]["BuildingNumber"]);
                        BuildingSectionNumber_v = tf.set_int(dt.Rows[0]["BuildingSectionNumber"]);
                        Community_v = tf.set_string(dt.Rows[0]["Community"]);
                        CadastralNumber_v = tf.set_int(dt.Rows[0]["CadastralNumber"]);
                        ValidityDate_v = tf.set_DateTime(dt.Rows[0]["ValidityDate"]);
                        ClosingTag_v = tf.set_string(dt.Rows[0]["ClosingTag"]);
                        SoftwareSupplier_TaxNumber_v = tf.set_string(dt.Rows[0]["SoftwareSupplier_TaxNumber"]);
                        PremiseType_v = tf.set_string(dt.Rows[0]["PremiseType"]);
                    }
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:myOrg_Office:Get:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:myOrg_Office:Get:(Office_ID_v == null)");
                return false;
            }
        }

    }
}
