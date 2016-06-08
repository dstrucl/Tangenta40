#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBConnectionControl40;
using LanguageControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TangentaDB
{
    public static class f_Atom_FVI_SLO_RealEstateBP
    {
        public static bool Get(
                         long FVI_SLO_RealEstateBP_ID,
                         ref long Atom_FVI_SLO_RealEstateBP_ID)
        {

            long Office_Data_ID = -1;

            string sql = @"select 
                            fres.Office_Data_ID,
                            fres.BuildingNumber,
                            fres.BuildingSectionNumber,
                            fres.Community,
                            fres.CadastralNumber,
                            fres.ValidityDate,
                            fres.ClosingTag,
                            fres.SoftwareSupplier_TaxNumber,
                            fres.PremiseType
                            from FVI_SLO_RealEstateBP fres
                            where fres.ID = " + FVI_SLO_RealEstateBP_ID.ToString();
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, null, ref Err))
            {
                if (dt.Rows.Count > 0)
                {


                    Office_Data_ID = (long)dt.Rows[0]["Office_Data_ID"];
                    long Atom_Office_Data_ID = -1;
                    if (f_Atom_Office_Data.Get(Office_Data_ID, ref Atom_Office_Data_ID))
                    {
                        List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                        string spar_Atom_Office_Data_ID = "@par_Atom_Office_Data_ID";
                        SQL_Parameter par_Atom_Office_Data_ID = new SQL_Parameter(spar_Atom_Office_Data_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_Office_Data_ID);
                        lpar.Add(par_Atom_Office_Data_ID);

                        int BuildingNumber = (int)dt.Rows[0]["BuildingNumber"];
                        string spar_BuildingNumber = "@par_BuildingNumber";
                        SQL_Parameter par_BuildingNumber = new SQL_Parameter(spar_BuildingNumber, SQL_Parameter.eSQL_Parameter.Int, false, BuildingNumber);
                        lpar.Add(par_BuildingNumber);

                        int BuildingSectionNumber = (int)dt.Rows[0]["BuildingSectionNumber"];
                        string spar_BuildingSectionNumber = "@par_BuildingSectionNumber";
                        SQL_Parameter par_BuildingSectionNumber = new SQL_Parameter(spar_BuildingSectionNumber, SQL_Parameter.eSQL_Parameter.Int, false, BuildingSectionNumber);
                        lpar.Add(par_BuildingSectionNumber);

                        string Community = (string)dt.Rows[0]["Community"];
                        string spar_Community = "@par_Community";
                        SQL_Parameter par_Community = new SQL_Parameter(spar_Community, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Community);
                        lpar.Add(par_Community);

                        int CadastralNumber = (int)dt.Rows[0]["CadastralNumber"];
                        string spar_CadastralNumber = "@par_CadastralNumber";
                        SQL_Parameter par_CadastralNumber = new SQL_Parameter(spar_CadastralNumber, SQL_Parameter.eSQL_Parameter.Int, false, CadastralNumber);
                        lpar.Add(par_CadastralNumber);

                        DateTime ValidityDate = (DateTime)dt.Rows[0]["ValidityDate"];
                        string spar_ValidityDate = "@par_ValidityDate";
                        SQL_Parameter par_ValidityDate = new SQL_Parameter(spar_ValidityDate, SQL_Parameter.eSQL_Parameter.Datetime, false, ValidityDate);
                        lpar.Add(par_ValidityDate);


                        string ClosingTag = (string)dt.Rows[0]["ClosingTag"];
                        string spar_ClosingTag = "@par_ClosingTag";
                        SQL_Parameter par_ClosingTag = new SQL_Parameter(spar_ClosingTag, SQL_Parameter.eSQL_Parameter.Nvarchar, false, ClosingTag);
                        lpar.Add(par_ClosingTag);

                        string SoftwareSupplier_TaxNumber = (string)dt.Rows[0]["SoftwareSupplier_TaxNumber"];
                        string spar_SoftwareSupplier_TaxNumber = "@par_SoftwareSupplier_TaxNumber";
                        SQL_Parameter par_SoftwareSupplier_TaxNumber = new SQL_Parameter(spar_SoftwareSupplier_TaxNumber, SQL_Parameter.eSQL_Parameter.Nvarchar, false, SoftwareSupplier_TaxNumber);
                        lpar.Add(par_SoftwareSupplier_TaxNumber);


                        string PremiseType = (string)dt.Rows[0]["PremiseType"];
                        string spar_PremiseType = "@par_PremiseType";
                        SQL_Parameter par_PremiseType = new SQL_Parameter(spar_PremiseType, SQL_Parameter.eSQL_Parameter.Nvarchar, false, PremiseType);
                        lpar.Add(par_PremiseType);
                        dt.Clear();
                        dt.Columns.Clear();
                        sql = @"select
                                    ID
                                    from Atom_FVI_SLO_RealEstateBP where
                                    Atom_Office_Data_ID = " + spar_Atom_Office_Data_ID + @"
                                    and Community  = " + spar_Community + @"
                                    and BuildingNumber  = " + spar_BuildingNumber + @"
                                    and BuildingSectionNumber  = " + spar_BuildingSectionNumber + @"
                                    and CadastralNumber  = " + spar_CadastralNumber + @"
                                    and ValidityDate  = " + spar_ValidityDate + @"
                                    and ClosingTag  = " + spar_ClosingTag + @"
                                    and SoftwareSupplier_TaxNumber  = " + spar_SoftwareSupplier_TaxNumber + @"
                                    and PremiseType  = " + spar_PremiseType;
                        if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                        {
                            if (dt.Rows.Count > 0)
                            {
                                Atom_FVI_SLO_RealEstateBP_ID = (long)dt.Rows[0]["ID"];
                                return true;
                            }
                            else
                            {
                                sql = @"insert into Atom_FVI_SLO_RealEstateBP (
                                                        Atom_Office_Data_ID
                                                        ,Community
                                                        ,BuildingNumber
                                                        ,BuildingSectionNumber
                                                        ,CadastralNumber
                                                        ,ValidityDate
                                                        ,ClosingTag
                                                        ,SoftwareSupplier_TaxNumber
                                                        ,PremiseType)
                                                        values (" + spar_Atom_Office_Data_ID + ","
                                                                 + spar_Community + ","
                                                                 + spar_BuildingNumber + ","
                                                                 + spar_BuildingSectionNumber + ","
                                                                 + spar_CadastralNumber + ","
                                                                 + spar_ValidityDate + ","
                                                                 + spar_ClosingTag + ","
                                                                 + spar_SoftwareSupplier_TaxNumber + ","
                                                                 + spar_PremiseType + ")";
                                object objretx = null;
                                if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_FVI_SLO_RealEstateBP_ID, ref objretx, ref Err, "Atom_FVI_SLO_RealEstateBP"))
                                {
                                    return true;
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:f_Atom_FVI_SLO_RealEstateBP:Get:sql=" + sql + "\r\nErr=" + Err);
                                }
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_Atom_FVI_SLO_RealEstateBP:Get:" + sql + "\r\nErr=" + Err);
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_FVI_SLO_RealEstateBP:Get:No FVI_SLO_RealEstateBP data for FVI_SLO_RealEstateBP_ID = " + FVI_SLO_RealEstateBP_ID.ToString());
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_FVI_SLO_RealEstateBP:Get:" + sql + "\r\nErr=" + Err);
            }
            return false;
        }


        public static bool Get_Atom_FVI_SLO_RealEstateBP_ID(Form main_Form, ref long Atom_FVI_SLO_RealEstateBP_ID, int limit)
        {
            string Err = null;
            string sTop = "";
            string sLimit = "";
            switch (DBSync.DBSync.m_DBType)
            {
                case DBConnection.eDBType.SQLITE:
                    sLimit = " Limit " + limit.ToString()+" ";
                    break;
                case DBConnection.eDBType.MYSQL:
                    sLimit = " Limit " + limit.ToString()+" ";
                    break;

                case DBConnection.eDBType.MSSQL:
                    sTop = " Top "+ limit.ToString() + " ";
                    break;

            }
            string sql = @"select "+sTop+ " ID from FVI_SLO_RealEstateBP order by ID desc" + sLimit;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt,sql, ref Err))
            {
                if (dt.Rows.Count>0)
                {
                    long FVI_SLO_RealEstateBP_ID = (long) dt.Rows[0]["ID"];
                    return f_Atom_FVI_SLO_RealEstateBP.Get(FVI_SLO_RealEstateBP_ID, ref Atom_FVI_SLO_RealEstateBP_ID);
                }
                else
                {
                    XMessage.Box.Show(main_Form, lngRPM.s_FVI_SLO_RealEstateBP_has_no_Data, "!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_FVI_SLO_RealEstateBP:Get_Atom_FVI_SLO_RealEstateBP_ID:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}