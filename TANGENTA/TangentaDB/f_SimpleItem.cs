using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_SimpleItem
    {
        public static bool Get(string Name, string Abbreviation, bool bToOffer, Image SimpleItem_Image, int_v Code_v, string SimpleItem_ParentGroup1, string SimpleItem_ParentGroup2, string SimpleItem_ParentGroup3, ref long SimpleItem_ID)
        {
            string Err = null;
            DataTable dt = new DataTable();
            string sql = null;
            object oret = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_Name = "@par_Name";
            SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Name);
            lpar.Add(par_Name);
            string spar_Abbreviation = "@par_Abbreviation";
            SQL_Parameter par_Abbreviation = new SQL_Parameter(spar_Abbreviation, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Abbreviation);
            lpar.Add(par_Abbreviation);
            string spar_ToOffer = "@par_ToOffer";
            SQL_Parameter par_ToOffer = new SQL_Parameter(spar_ToOffer, SQL_Parameter.eSQL_Parameter.Bit, false, bToOffer);
            lpar.Add(par_ToOffer);

            string scond_Code = " Code is null ";
            string sval_Code = "null";
            if (Code_v != null)
            {
                scond_Code = " Code = " + Code_v.v.ToString() + " ";
                sval_Code = " " + Code_v.v.ToString() + " ";
            }

            string scond_SimpleItem_ParentGroup1_ID = " SimpleItem_ParentGroup1_ID is null ";
            string sval_SimpleItem_ParentGroup1_ID = " null ";

            string scond_SimpleItem_Image_ID = " SimpleItem_Image_ID is null ";
            string sval_SimpleItem_Image_ID = " null ";

            if (SimpleItem_ParentGroup1 != null)
            {
                long SimpleItem_ParentGroup1_ID = -1;
                long SimpleItem_Image_ID = -1;
                if (f_SimpleItem_ParentGroup1.Get(SimpleItem_ParentGroup1, SimpleItem_ParentGroup2, SimpleItem_ParentGroup3, ref SimpleItem_ParentGroup1_ID))
                {
                    scond_SimpleItem_ParentGroup1_ID = " SimpleItem_ParentGroup1_ID = " + SimpleItem_ParentGroup1_ID.ToString() + " ";
                    sval_SimpleItem_ParentGroup1_ID = " " + SimpleItem_ParentGroup1_ID.ToString() + " ";

                    if (SimpleItem_Image!=null)
                    {
                        if (f_SimpleItem_Image.Get(SimpleItem_Image, ref SimpleItem_Image_ID))
                        {
                            scond_SimpleItem_Image_ID = " SimpleItem_Image_ID = " + SimpleItem_Image_ID.ToString() + " ";
                            sval_SimpleItem_Image_ID = " " + SimpleItem_Image.ToString() + " ";
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            sql = "select ID from SimpleItem where Name = " + spar_Name + " and Abbreviation = " + spar_Abbreviation + " and ToOffer = " + spar_ToOffer + " and " + scond_Code + " and " + scond_SimpleItem_ParentGroup1_ID + " and " + scond_SimpleItem_Image_ID;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    SimpleItem_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = "insert into SimpleItem (Name,Abbreviation,ToOffer,Code,SimpleItem_ParentGroup1_ID,SimpleItem_Image_ID)values(" + spar_Name + "," + spar_Abbreviation + "," + sval_Code + "," + sval_SimpleItem_ParentGroup1_ID + "," + sval_SimpleItem_Image_ID + ")";
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref SimpleItem_ID, ref oret, ref Err, "SimpleItem"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_SimpleItem:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_SimpleItem:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
