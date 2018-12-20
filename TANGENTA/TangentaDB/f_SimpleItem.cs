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
        public static bool Get(string Name, string Abbreviation, bool bToOffer, Image SimpleItem_Image, int_v Code_v, string SimpleItem_ParentGroup1, string SimpleItem_ParentGroup2, string SimpleItem_ParentGroup3, ref ID SimpleItem_ID, Transaction transaction)
        {
            string Err = null;
            DataTable dt = new DataTable();
            string sql = null;
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
                ID SimpleItem_ParentGroup1_ID = null;
                ID SimpleItem_Image_ID = null;
                if (f_SimpleItem_ParentGroup1.Get(SimpleItem_ParentGroup1, SimpleItem_ParentGroup2, SimpleItem_ParentGroup3, ref SimpleItem_ParentGroup1_ID, transaction))
                {
                    scond_SimpleItem_ParentGroup1_ID = " SimpleItem_ParentGroup1_ID = " + SimpleItem_ParentGroup1_ID.ToString() + " ";
                    sval_SimpleItem_ParentGroup1_ID = " " + SimpleItem_ParentGroup1_ID.ToString() + " ";

                    if (SimpleItem_Image != null)
                    {
                        if (f_SimpleItem_Image.Get(SimpleItem_Image, ref SimpleItem_Image_ID, transaction))
                        {
                            scond_SimpleItem_Image_ID = " SimpleItem_Image_ID = " + SimpleItem_Image_ID.ToString() + " ";
                            sval_SimpleItem_Image_ID = " " + SimpleItem_Image_ID.ToString() + " ";
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
                    if (SimpleItem_ID==null)
                    {
                        SimpleItem_ID = new ID();
                    }
                    SimpleItem_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = "insert into SimpleItem (Name,Abbreviation,ToOffer,Code,SimpleItem_ParentGroup1_ID,SimpleItem_Image_ID)values(" + spar_Name + "," + spar_Abbreviation + ",1," + sval_Code + "," + sval_SimpleItem_ParentGroup1_ID + "," + sval_SimpleItem_Image_ID + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref SimpleItem_ID, ref Err, "SimpleItem"))
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

        public static bool Get(string Name,
                            string Abbreviation,
                            ref bool_v bToOffer_v,
                            ref ID SimpleItem_Image_ID,
                            ref Image SimpleItem_Image,
                            ref string_v SimpleItem_Image_Hash_v,
                            ref int_v Code_v,
                            ref string_v SimpleItem_ParentGroup1_v,
                            ref string_v SimpleItem_ParentGroup2_v,
                            ref string_v SimpleItem_ParentGroup3_v,
                            ref ID SimpleItem_ID)
        {


            string Err = null;
            bToOffer_v = null;
            SimpleItem_Image_ID = null;
            SimpleItem_Image = null;
            SimpleItem_Image_Hash_v = null;
            Code_v = null;
            SimpleItem_ParentGroup1_v = null;
            SimpleItem_ParentGroup2_v = null;
            SimpleItem_ParentGroup3_v = null;
            SimpleItem_ID = null;
            DataTable dt = new DataTable();
            string sql = null;

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_Name = "@par_Name";
            SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Name);
            lpar.Add(par_Name);
            string spar_Abbreviation = "@par_Abbreviation";
            SQL_Parameter par_Abbreviation = new SQL_Parameter(spar_Abbreviation, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Abbreviation);
            lpar.Add(par_Abbreviation);

            sql = "select ID,ToOffer,SimpleItem_Image_ID,Code,SimpleItem_ParentGroup1_ID from SimpleItem where Name = " + spar_Name + " and Abbreviation = " + spar_Abbreviation;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (SimpleItem_ID==null)
                    {
                        SimpleItem_ID = new ID();
                    }
                    SimpleItem_ID.Set(dt.Rows[0]["ID"]);
                    bToOffer_v = tf.set_bool(dt.Rows[0]["ToOffer"]);
                    if (SimpleItem_Image_ID==null)
                    {
                        SimpleItem_Image_ID = new ID();
                    }
                    SimpleItem_Image_ID.Set(dt.Rows[0]["SimpleItem_Image_ID"]);
                    SimpleItem_Image = null;
                    SimpleItem_Image_Hash_v = null;
                    if (SimpleItem_Image_ID != null)
                    {
                        string simpleItem_Image_Hash = null;
                        f_SimpleItem_Image.Get(SimpleItem_Image_ID, ref SimpleItem_Image, ref simpleItem_Image_Hash);
                        if (simpleItem_Image_Hash != null)
                        {
                            SimpleItem_Image_Hash_v = new string_v(simpleItem_Image_Hash);
                        }
                    }
                    ID SimpleItem_ParentGroup1_ID = new ID(dt.Rows[0]["SimpleItem_ParentGroup1_ID"]);
                    if (ID.Validate(SimpleItem_ParentGroup1_ID))
                    {
                        if (!f_SimpleItem_ParentGroup1.Get(SimpleItem_ParentGroup1_ID, ref SimpleItem_ParentGroup1_v, ref SimpleItem_ParentGroup2_v, ref SimpleItem_ParentGroup3_v))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_SimpleItem:Find:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}