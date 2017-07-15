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
    public static class f_Item
    {
        public static bool Get(string Name,
                               string UniqueName,
                               bool bToOffer,
                               Image Item_Image,
                               int_v Code_v,
                               string Unit_Name,
                               string Unit_Symbol,
                               int Unit_DecimalPlaces,
                               bool Unit_StorageOption,
                               string Unit_Description,
                               string barcode,
                               string Description,
                               f_Expiry.Expiry_v Expiry_v,
                               f_Warranty.Warranty_v Warranty_v,
                               string Item_ParentGroup1,
                               string Item_ParentGroup2,
                               string Item_ParentGroup3,
                               ref long Unit_ID,
                               ref long Item_ID)
        {
            string Err = null;
            DataTable dt = new DataTable();
            string sql = null;
            object oret = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_Name = "@par_Name";
            SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Name);
            lpar.Add(par_Name);
            string spar_UniqueName = "@par_UniqueName";
            SQL_Parameter par_UniqueName = new SQL_Parameter(spar_UniqueName, SQL_Parameter.eSQL_Parameter.Nvarchar, false, UniqueName);
            lpar.Add(par_UniqueName);
            string spar_ToOffer = "@par_ToOffer";
            SQL_Parameter par_ToOffer = new SQL_Parameter(spar_ToOffer, SQL_Parameter.eSQL_Parameter.Bit, false, bToOffer);
            lpar.Add(par_ToOffer);

            string scond_barcode = " barcode is null ";
            string sval_barcode = "null";
            if (barcode != null)
            {
                string spar_Barcode = "@par_Barcode";
                SQL_Parameter par_Barcode = new SQL_Parameter(spar_Barcode, SQL_Parameter.eSQL_Parameter.Nvarchar, false, barcode);
                lpar.Add(par_Barcode);
                scond_barcode = " barcode = " + spar_Barcode + " ";
                sval_barcode = " " + spar_Barcode + " ";
            }

            string scond_Description = " Description is null ";
            string sval_Description = "null";
            if (Description != null)
            {
                string spar_Description = "@par_Description";
                SQL_Parameter par_Barcode = new SQL_Parameter(spar_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Description);
                lpar.Add(par_Barcode);
                scond_Description = " Description = " + spar_Description + " ";
                sval_Description = " " + spar_Description + " ";
            }

            string scond_Code = " Code is null ";
            string sval_Code = "null";
            if (Code_v != null)
            {
                scond_Code = " Code = " + Code_v.v.ToString() + " ";
                sval_Code = " " + Code_v.v.ToString() + " ";
            }


            long_v Expiry_ID_v = null;
            if (!f_Expiry.Get(Expiry_v, ref Expiry_ID_v))
            {
                return false;
            }
            string scond_Expiry_ID = " Expiry_ID is null ";
            string sval_Expiry_ID = "null";



            if (Expiry_ID_v != null)
            {
                scond_Expiry_ID = " Expiry_ID = " + Expiry_ID_v.v.ToString() + " ";
                sval_Expiry_ID = " " + Expiry_ID_v.v.ToString() + " ";
            }

            long_v Warranty_ID_v = null;
            if (!f_Warranty.Get(Warranty_v, ref Warranty_ID_v))
            {
                return false;
            }

            string scond_Warranty_ID = " Warranty_ID is null ";
            string sval_Warranty_ID = "null";
            if (Warranty_ID_v != null)
            {
                scond_Warranty_ID = " Warranty_ID = " + Warranty_ID_v.v.ToString() + " ";
                sval_Warranty_ID = " " + Warranty_ID_v.v.ToString() + " ";
            }

            string scond_Item_ParentGroup1_ID = " Item_ParentGroup1_ID is null ";
            string sval_Item_ParentGroup1_ID = " null ";

            string scond_Item_Image_ID = " Item_Image_ID is null ";
            string sval_Item_Image_ID = " null ";

            if (!f_Unit.Get(Unit_Name, Unit_Symbol, Unit_DecimalPlaces, Unit_StorageOption, Unit_Description, ref Unit_ID))
            {
                return false;
            }

            if (Item_ParentGroup1 != null)
            {
                long Item_ParentGroup1_ID = -1;
                long Item_Image_ID = -1;
                if (f_Item_ParentGroup1.Get(Item_ParentGroup1, Item_ParentGroup2, Item_ParentGroup3, ref Item_ParentGroup1_ID))
                {
                    scond_Item_ParentGroup1_ID = " Item_ParentGroup1_ID = " + Item_ParentGroup1_ID.ToString() + " ";
                    sval_Item_ParentGroup1_ID = " " + Item_ParentGroup1_ID.ToString() + " ";

                    if (Item_Image != null)
                    {
                        if (f_Item_Image.Get(Item_Image, ref Item_Image_ID))
                        {
                            scond_Item_Image_ID = " Item_Image_ID = " + Item_Image_ID.ToString() + " ";
                            sval_Item_Image_ID = " " + Item_Image.ToString() + " ";
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            //sql = "select ID from Item where Name = " + spar_Name + " and UniqueName = " + spar_UniqueName + " and ToOffer = " + spar_ToOffer + " and " + scond_Code + " and " + scond_Item_ParentGroup1_ID + " and " + scond_Item_Image_ID;
            sql = "select ID from Item where UniqueName = " + spar_UniqueName;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Item_ID = (long)dt.Rows[0]["ID"];
                    sql = "select ID from Item where Name = " + spar_Name +
                                            " and UniqueName = " + spar_UniqueName +
                                            " and ToOffer = " + spar_ToOffer +
                                            " and " + scond_Code +
                                            " and " + scond_Item_ParentGroup1_ID +
                                            " and " + scond_Item_Image_ID +
                                            " and Unit_ID = " + Unit_ID.ToString() +
                                            " and " + scond_barcode +
                                            " and " + scond_Description +
                                            " and " + scond_Expiry_ID +
                                            " and " + scond_Warranty_ID;
                    dt.Clear();
                    dt.Rows.Clear();
                    dt.Columns.Clear();
                    if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            return true;
                        }
                        else
                        {
                            sql = @"update Item set Name = " + spar_Name + @",
                                                    ToOffer = " + spar_ToOffer + @",
                                                    Code = " + sval_Code + @",
                                                    Item_ParentGroup1_ID = " + sval_Item_ParentGroup1_ID + @",
                                                    Item_Image_ID = " + sval_Item_Image_ID + @",
                                                    Unit_ID = " + Unit_ID.ToString() + @",
                                                    barcode = " + sval_barcode + @",
                                                    Description = " + sval_Description + @",
                                                    Expiry_ID = " + sval_Expiry_ID + @",
                                                    Warranty_ID = " + sval_Warranty_ID + " where ID = " + Item_ID.ToString();
                            if (DBSync.DBSync.ExecuteNonQuerySQL(sql, lpar, ref oret, ref Err))
                            {
                                return true;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:f_Item:Get:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Item:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    sql = @"insert into Item (Name,
                                              UniqueName,
                                              ToOffer,
                                              Code,
                                              Item_ParentGroup1_ID,
                                              Item_Image_ID,
                                              Unit_ID,
                                              barcode,
                                              Description,
                                              Expiry_ID,
                                              Warranty_ID
                                              )values("
                                            + spar_Name + ","
                                            + spar_UniqueName + ","
                                            + spar_ToOffer + ","
                                            + sval_Code + ","
                                            + sval_Item_ParentGroup1_ID + ","
                                            + sval_Item_Image_ID + ","
                                            + Unit_ID.ToString() + ","
                                            + sval_barcode + ","
                                            + sval_Description + ","
                                            + sval_Expiry_ID + ","
                                            + sval_Warranty_ID +
                                            ")";
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Item_ID, ref oret, ref Err, "Item"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Item:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Item:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Get(string UniqueName,
                                   ref string_v UniqueName_v,
                                   ref string_v Name_v,
                                   ref bool_v bToOffer_v,
                                   ref Image Item_Image,
                                   ref long_v Item_Image_ID_v,
                                   ref string_v Item_Image_Hash_v,
                                   ref long_v Code_v,
                                   ref string_v Unit_Name_v,
                                   ref string_v Unit_Symbol_v,
                                   ref int_v Unit_DecimalPlaces_v,
                                   ref bool_v Unit_StorageOption_v,
                                   ref string_v Unit_Description_v,
                                   ref string_v barcode_v,
                                   ref string_v Description_v,
                                   ref long_v Expiry_ID_v,
                                   ref long_v Warranty_ID_v,
                                   ref f_Expiry.Expiry_v Expiry_v,
                                   ref f_Warranty.Warranty_v Warranty_v,
                                   ref long_v Item_ParentGroup1_ID_v,
                                   ref string_v Item_ParentGroup1_v,
                                   ref long_v Item_ParentGroup2_ID_v,
                                   ref string_v Item_ParentGroup2_v,
                                   ref long_v Item_ParentGroup3_ID_v,
                                   ref string_v Item_ParentGroup3_v,
                                   ref long_v Unit_ID_v,
                                   ref long_v Item_ID_v)
        {
            UniqueName_v = null;
            Name_v = null;
            bToOffer_v = null;
            Item_Image = null;
            Item_Image_ID_v = null;
            Item_Image_Hash_v = null;
            Code_v = null;
            Unit_Name_v = null;
            Unit_Symbol_v = null;
            Unit_DecimalPlaces_v = null;
            Unit_StorageOption_v = null;
            Unit_Description_v = null;
            barcode_v = null;
            Description_v = null;
            Expiry_ID_v = null;
            Warranty_ID_v = null;
            Expiry_v = null;
            Warranty_v = null;
            Item_ParentGroup1_ID_v = null;
            Item_ParentGroup1_v = null;
            Item_ParentGroup2_v = null;
            Item_ParentGroup3_v = null;
            Unit_ID_v = null;
            Item_ID_v = null;

            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_UniqueName = "@par_UniqueName";
            SQL_Parameter par_UniqueName = new SQL_Parameter(spar_UniqueName, SQL_Parameter.eSQL_Parameter.Nvarchar, false, UniqueName);
            lpar.Add(par_UniqueName);
            string sql = @"select ID,Code,UniqueName,Name,Unit_ID,ToOffer,barcode,Description,Item_Image_ID,Expiry_ID,Warranty_ID,Item_ParentGroup1_ID from Item where UniqueName =" + spar_UniqueName;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    UniqueName_v = tf.set_string(dt.Rows[0]["UniqueName"]);
                    Name_v = tf.set_string(dt.Rows[0]["Name"]);
                    bToOffer_v = tf.set_bool(dt.Rows[0]["ToOffer"]);
                    Item_Image_ID_v = tf.set_long(dt.Rows[0]["Item_Image_ID"]);

                    if (Item_Image_ID_v != null)
                    {
                        if (!f_Item_Image.Get(Item_Image_ID_v.v, ref Item_Image, ref Item_Image_Hash_v))
                        {
                            return false;
                        }
                    }


                    Unit_ID_v = tf.set_long(dt.Rows[0]["Unit_ID"]);

                    if (Unit_ID_v != null)
                    {
                        if (!f_Unit.Get(Unit_ID_v.v, ref Unit_Name_v, ref Unit_Symbol_v, ref Unit_DecimalPlaces_v, ref Unit_StorageOption_v, ref Unit_Description_v))
                        {
                            return false;
                        }
                    }


                    Code_v = tf.set_long(dt.Rows[0]["Code"]);

                    //Unit_Name_v = tf.set_string(dt.Rows[0][""]);
                    //Unit_Symbol_v = tf.set_string(dt.Rows[0][""]);
                    //Unit_DecimalPlaces_v = tf.set_string(dt.Rows[0][""]);
                    //Unit_StorageOption_v = tf.set_string(dt.Rows[0][""]);
                    //Unit_Description_v = tf.set_string(dt.Rows[0][""]); 

                    barcode_v = tf.set_string(dt.Rows[0]["barcode"]);
                    Description_v = tf.set_string(dt.Rows[0]["Description"]);

                    Expiry_ID_v = tf.set_long(dt.Rows[0]["Expiry_ID"]);

                    if (Expiry_ID_v != null)
                    {
                        if (!f_Expiry.Get(Expiry_ID_v.v, ref Expiry_v))
                        {
                            return false;
                        }
                    }

                    Warranty_ID_v = tf.set_long(dt.Rows[0]["Warranty_ID"]);

                    if (Warranty_ID_v != null)
                    {
                        if (!f_Warranty.Get(Warranty_ID_v.v, ref Warranty_v))
                        {
                            return false;
                        }
                    }

                    Item_ParentGroup1_ID_v = tf.set_long(dt.Rows[0]["Item_ParentGroup1_ID"]);

                    if (Item_ParentGroup1_ID_v != null)
                    {
                        if (!f_Item_ParentGroup1.Get(Item_ParentGroup1_ID_v.v, ref Item_ParentGroup1_v, ref Item_ParentGroup2_ID_v, ref Item_ParentGroup2_v, ref Item_ParentGroup3_ID_v, ref Item_ParentGroup2_v))
                        {
                            return false;
                        }
                    }

                    Item_ID_v = tf.set_long(dt.Rows[0]["ID"]);
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Item:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
