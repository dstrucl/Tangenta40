// Copyright (c) 2011 rubicon IT GmbH
using DBConnectionControl40;
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
        public ID ID = null;
        public ID Atom_FVI_SLO_RealEstate_ID = null;
        public ID Office_Data_ID = null;
        public int_v BuildingNumber_v = null;
        public int_v BuildingSectionNumber_v = null;
        public string_v Community_v = null;
        public int_v CadastralNumber_v = null;
        public DateTime_v ValidityDate_v = null;
        public string_v ClosingTag_v = null;
        public string_v SoftwareSupplier_TaxNumber_v = null;
        public string_v PremiseType_v = null;

        public bool Get(ID xOffice_Data_ID)
        {
            string Err = null;
            ID = null;
            Office_Data_ID = null;
            BuildingNumber_v = null;
            BuildingSectionNumber_v = null;
            Community_v = null;
            CadastralNumber_v = null;
            ValidityDate_v = null;
            ClosingTag_v = null;
            SoftwareSupplier_TaxNumber_v = null;
            PremiseType_v = null;

            if (ID.Validate(xOffice_Data_ID))
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
                              where Office_Data_ID = " + xOffice_Data_ID.ToString();
                DataTable dt = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        ID = tf.set_ID(dt.Rows[0]["ID"]);
                        Office_Data_ID = tf.set_ID(dt.Rows[0]["Office_Data_ID"]);
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
