#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangentaTableClass;
using DBTypes;
using DBConnectionControl40;

namespace ShopA_dbfunc
{
    public static class dbfunc
    {
        public static bool Read_ShopA_Price_Item_Table(string DocInvoice,ID DocInvoice_ID,ref DataTable dt)
        {
            string Err = null;
            string sql = null;
            if (DocInvoice.Equals("DocInvoice"))
            {
                sql = @"SELECT 
                            DocInvoice_ShopA_Item.ID,
                            DocInvoice_ShopA_Item_$_pinv.ID AS DocInvoice_ShopA_Item_$_dinv_$$ID,
                            DocInvoice_ShopA_Item_$_pinv.Draft AS DocInvoice_ShopA_Item_$_dinv_$$Draft,
                            DocInvoice_ShopA_Item_$_aisha.ID AS DocInvoice_ShopA_Item_$_aisha_$$ID,
                            DocInvoice_ShopA_Item_$_aisha.Name AS DocInvoice_ShopA_Item_$_aisha_$$Name,
                            DocInvoice_ShopA_Item_$_aisha.Description AS DocInvoice_ShopA_Item_$_aisha_$$Description,
                            DocInvoice_ShopA_Item_$_aisha_$_tax.ID AS DocInvoice_ShopA_Item_$_aisha_$_tax_$$ID,
                            DocInvoice_ShopA_Item_$_aisha_$_tax.Name AS DocInvoice_ShopA_Item_$_aisha_$_tax_$$Name,
                            DocInvoice_ShopA_Item_$_aisha_$_tax.Rate AS DocInvoice_ShopA_Item_$_aisha_$_tax_$$Rate,
                            DocInvoice_ShopA_Item_$_aisha_$_u.ID AS DocInvoice_ShopA_Item_$_aisha_$_u_$$ID,
                            DocInvoice_ShopA_Item_$_aisha_$_u.Name AS DocInvoice_ShopA_Item_$_aisha_$_u_$$Name,
                            DocInvoice_ShopA_Item_$_aisha_$_u.Symbol AS DocInvoice_ShopA_Item_$_aisha_$_u_$$Symbol,
                            DocInvoice_ShopA_Item_$_aisha_$_u.DecimalPlaces AS DocInvoice_ShopA_Item_$_aisha_$_u_$$DecimalPlaces,
                            DocInvoice_ShopA_Item.Discount AS DocInvoice_ShopA_Item_$$Discount,
                            DocInvoice_ShopA_Item.dQuantity AS DocInvoice_ShopA_Item_$$dQuantity,
                            DocInvoice_ShopA_Item.PricePerUnit AS DocInvoice_ShopA_Item_$$PricePerUnit,
                            DocInvoice_ShopA_Item.EndPriceWithDiscountAndTax AS DocInvoice_ShopA_Item_$$EndPriceWithDiscountAndTax,
                            DocInvoice_ShopA_Item.TAX AS DocInvoice_ShopA_Item_$$TAX
                            FROM DocInvoice_ShopA_Item 
                            INNER JOIN DocInvoice DocInvoice_ShopA_Item_$_pinv ON DocInvoice_ShopA_Item.DocInvoice_ID = DocInvoice_ShopA_Item_$_pinv.ID
                            INNER JOIN Atom_ItemShopA DocInvoice_ShopA_Item_$_aisha ON DocInvoice_ShopA_Item.Atom_ItemShopA_ID = DocInvoice_ShopA_Item_$_aisha.ID
                            INNER JOIN Taxation DocInvoice_ShopA_Item_$_aisha_$_tax ON DocInvoice_ShopA_Item_$_aisha.Taxation_ID = DocInvoice_ShopA_Item_$_aisha_$_tax.ID
                            LEFT JOIN Unit DocInvoice_ShopA_Item_$_aisha_$_u ON DocInvoice_ShopA_Item_$_aisha.Unit_ID = DocInvoice_ShopA_Item_$_aisha_$_u.ID
                            where DocInvoice_ShopA_Item_$_pinv.ID = " + DocInvoice_ID.ToString();
            }
            else if (DocInvoice.Equals("DocProformaInvoice"))
            {
                sql = @"SELECT 
                            DocProformaInvoice_ShopA_Item.ID,
                            DocProformaInvoice_ShopA_Item_$_pinv.ID AS DocProformaInvoice_ShopA_Item_$_dpinv_$$ID,
                            DocProformaInvoice_ShopA_Item_$_pinv.Draft AS DocProformaInvoice_ShopA_Item_$_dpinv_$$Draft,
                            DocProformaInvoice_ShopA_Item_$_aisha.ID AS DocProformaInvoice_ShopA_Item_$_aisha_$$ID,
                            DocProformaInvoice_ShopA_Item_$_aisha.Name AS DocProformaInvoice_ShopA_Item_$_aisha_$$Name,
                            DocProformaInvoice_ShopA_Item_$_aisha.Description AS DocProformaInvoice_ShopA_Item_$_aisha_$$Description,
                            DocProformaInvoice_ShopA_Item_$_aisha_$_tax.ID AS DocProformaInvoice_ShopA_Item_$_aisha_$_tax_$$ID,
                            DocProformaInvoice_ShopA_Item_$_aisha_$_tax.Name AS DocProformaInvoice_ShopA_Item_$_aisha_$_tax_$$Name,
                            DocProformaInvoice_ShopA_Item_$_aisha_$_tax.Rate AS DocProformaInvoice_ShopA_Item_$_aisha_$_tax_$$Rate,
                            DocProformaInvoice_ShopA_Item_$_aisha_$_u.ID AS DocProformaInvoice_ShopA_Item_$_aisha_$_u_$$ID,
                            DocProformaInvoice_ShopA_Item_$_aisha_$_u.Name AS DocProformaInvoice_ShopA_Item_$_aisha_$_u_$$Name,
                            DocProformaInvoice_ShopA_Item_$_aisha_$_u.Symbol AS DocProformaInvoice_ShopA_Item_$_aisha_$_u_$$Symbol,
                            DocProformaInvoice_ShopA_Item_$_aisha_$_u.DecimalPlaces AS DocProformaInvoice_ShopA_Item_$_aisha_$_u_$$DecimalPlaces,
                            DocProformaInvoice_ShopA_Item.Discount AS DocProformaInvoice_ShopA_Item_$$Discount,
                            DocProformaInvoice_ShopA_Item.dQuantity AS DocProformaInvoice_ShopA_Item_$$dQuantity,
                            DocProformaInvoice_ShopA_Item.PricePerUnit AS DocProformaInvoice_ShopA_Item_$$PricePerUnit,
                            DocProformaInvoice_ShopA_Item.EndPriceWithDiscountAndTax AS DocProformaInvoice_ShopA_Item_$$EndPriceWithDiscountAndTax,
                            DocProformaInvoice_ShopA_Item.TAX AS DocProformaInvoice_ShopA_Item_$$TAX
                            FROM DocProformaInvoice_ShopA_Item 
                            INNER JOIN DocProformaInvoice DocProformaInvoice_ShopA_Item_$_pinv ON DocProformaInvoice_ShopA_Item.DocProformaInvoice_ID = DocProformaInvoice_ShopA_Item_$_pinv.ID
                            INNER JOIN Atom_ItemShopA DocProformaInvoice_ShopA_Item_$_aisha ON DocProformaInvoice_ShopA_Item.Atom_ItemShopA_ID = DocProformaInvoice_ShopA_Item_$_aisha.ID
                            INNER JOIN Taxation DocProformaInvoice_ShopA_Item_$_aisha_$_tax ON DocProformaInvoice_ShopA_Item_$_aisha.Taxation_ID = DocProformaInvoice_ShopA_Item_$_aisha_$_tax.ID
                            LEFT JOIN Unit DocProformaInvoice_ShopA_Item_$_aisha_$_u ON DocProformaInvoice_ShopA_Item_$_aisha.Unit_ID = DocProformaInvoice_ShopA_Item_$_aisha_$_u.ID
                            where DocProformaInvoice_ShopA_Item_$_pinv.ID = " + DocInvoice_ID.ToString();
            }
            else
            {
                Err = "ERROR:dbfunc.cs:Read_Atom_SimpleItem_Table:DocInvoice="+DocInvoice + " not implemented.";
                LogFile.Error.Show(Err);
                return false;
            }

            dt.Clear();
            dt.Columns.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:dbfunc.cs:Read_Atom_SimpleItem_Table:sql="+sql+"\r\n Err=" + Err);
                return false;
            }
        }

        public static bool Write_ShopA_Price_Item_Table(string docInvoice, ID doc_ID, DataTable xdt_ShopA_Items)
        {
            DocInvoice_ShopA_Item x_DocInvoice_ShopA_Item = new DocInvoice_ShopA_Item();
            foreach (DataRow dr in xdt_ShopA_Items.Rows)
            {
                x_DocInvoice_ShopA_Item.Discount.type_v = tf.set_decimal(dr[docInvoice + "_ShopA_Item_$$Discount"]);

                x_DocInvoice_ShopA_Item.dQuantity.type_v = tf.set_decimal(dr[docInvoice + "_ShopA_Item_$$dQuantity"]);

                x_DocInvoice_ShopA_Item.EndPriceWithDiscountAndTax.type_v = tf.set_decimal(dr[docInvoice + "_ShopA_Item_$$EndPriceWithDiscountAndTax"]);

                x_DocInvoice_ShopA_Item.m_Atom_ItemShopA.ID = tf.set_ID(dr[docInvoice + "_ShopA_Item_$_aisha_$$ID"]);

                x_DocInvoice_ShopA_Item.m_DocInvoice.ID = new ID(doc_ID);

                x_DocInvoice_ShopA_Item.PricePerUnit.type_v = tf.set_decimal(dr[docInvoice + "_ShopA_Item_$$PricePerUnit"]);

                x_DocInvoice_ShopA_Item.TAX.type_v = tf.set_decimal(dr[docInvoice + "_ShopA_Item_$$TAX"]);
                ID DocInvoice_ShopA_Item_ID = null;
                if (insert(docInvoice, x_DocInvoice_ShopA_Item,ref DocInvoice_ShopA_Item_ID))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }


        public static bool insert(string DocInvoice,DocInvoice_ShopA_Item m_DocInvoice_ShopA_Item, ref ID DocInvoice_ShopA_Item_ID)
        {
            if (m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.ID != null)
            {
                return insert_ex(DocInvoice, m_DocInvoice_ShopA_Item, ref  DocInvoice_ShopA_Item_ID);
            }
            else
            {
                ID Atom_ItemShopA_ID = null;
                if (get(m_DocInvoice_ShopA_Item.m_Atom_ItemShopA, ref Atom_ItemShopA_ID))
                {
                    m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.ID.Set(Atom_ItemShopA_ID);
                    return insert_ex(DocInvoice, m_DocInvoice_ShopA_Item, ref DocInvoice_ShopA_Item_ID);
                }
            }
            return false;
        }

        private static bool insert_ex(string docInvoice, DocInvoice_ShopA_Item m_DocInvoice_ShopA_Item, ref ID DocInvoice_ShopA_Item_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string Err = null;
            string scond = null;
            string sval = null;
            string sql = null;
            if (docInvoice.Equals("DocInvoice"))
            {
                m_DocInvoice_ShopA_Item.m_DocInvoice.ID.setsqlp(ref lpar, docInvoice +"_ID", ref scond, ref sval);
                m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.ID.setsqlp(ref lpar, "Atom_ItemShopA_ID", ref scond, ref sval);
                m_DocInvoice_ShopA_Item.EndPriceWithDiscountAndTax.setsqlp(ref lpar, "EndPriceWithDiscountAndTax", ref scond, ref sval);
                m_DocInvoice_ShopA_Item.PricePerUnit.setsqlp(ref lpar, "PricePerUnit", ref scond, ref sval);
                m_DocInvoice_ShopA_Item.dQuantity.setsqlp(ref lpar, "dQuantity", ref scond, ref sval);
                m_DocInvoice_ShopA_Item.Discount.setsqlp(ref lpar, "Discount", ref scond, ref sval);
                m_DocInvoice_ShopA_Item.TAX.setsqlp(ref lpar, "TAX", ref scond, ref sval);
                sql = "insert into DocInvoice_ShopA_Item ("+ docInvoice+"_ID,Atom_ItemShopA_ID,Discount,dQuantity,PricePerUnit,EndPriceWithDiscountAndTax,TAX) values ("
                              + m_DocInvoice_ShopA_Item.m_DocInvoice.ID.value + ","
                              + m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.ID.value + ","
                              + m_DocInvoice_ShopA_Item.Discount.value + ","
                              + m_DocInvoice_ShopA_Item.dQuantity.value + ","
                              + m_DocInvoice_ShopA_Item.PricePerUnit.value + ","
                              + m_DocInvoice_ShopA_Item.EndPriceWithDiscountAndTax.value + ","
                              + m_DocInvoice_ShopA_Item.TAX.value + ")";
            }
            else if (docInvoice.Equals("DocProformaInvoice"))
            {
                m_DocInvoice_ShopA_Item.m_DocInvoice.ID.setsqlp(ref lpar, "DocProformaInvoice_ID", ref scond, ref sval);
                m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.ID.setsqlp(ref lpar, "Atom_ItemShopA_ID", ref scond, ref sval);
                m_DocInvoice_ShopA_Item.EndPriceWithDiscountAndTax.setsqlp(ref lpar, "EndPriceWithDiscountAndTax", ref scond, ref sval);
                m_DocInvoice_ShopA_Item.PricePerUnit.setsqlp(ref lpar, "PricePerUnit", ref scond, ref sval);
                m_DocInvoice_ShopA_Item.dQuantity.setsqlp(ref lpar, "dQuantity", ref scond, ref sval);
                m_DocInvoice_ShopA_Item.Discount.setsqlp(ref lpar, "Discount", ref scond, ref sval);
                m_DocInvoice_ShopA_Item.TAX.setsqlp(ref lpar, "TAX", ref scond, ref sval);
                sql = "insert into DocProformaInvoice_ShopA_Item (DocProformaInvoice_ID,Atom_ItemShopA_ID,Discount,dQuantity,PricePerUnit,EndPriceWithDiscountAndTax,TAX) values ("
                              + m_DocInvoice_ShopA_Item.m_DocInvoice.ID.value + ","
                              + m_DocInvoice_ShopA_Item.m_Atom_ItemShopA.ID.value + ","
                              + m_DocInvoice_ShopA_Item.Discount.value + ","
                              + m_DocInvoice_ShopA_Item.dQuantity.value + ","
                              + m_DocInvoice_ShopA_Item.PricePerUnit.value + ","
                              + m_DocInvoice_ShopA_Item.EndPriceWithDiscountAndTax.value + ","
                              + m_DocInvoice_ShopA_Item.TAX.value + ")";
            }
            else
            {
                LogFile.Error.Show("ERROR:ShopA_dbfunc:dbfunc:insert_ex(Atom_ItemShopA m_Atom_ItemShopA, ref long atom_ItemShopA_ID) DocInvoice=" + docInvoice + " not implemented.");
                return false;
            }
            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref DocInvoice_ShopA_Item_ID,  ref Err, docInvoice+"_ShopA_Item"))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:ShopA_dbfunc:dbfunc:insert_ex(Atom_ItemShopA m_Atom_ItemShopA, ref long atom_ItemShopA_ID) sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }


        public static bool get(Atom_ItemShopA m_Atom_ItemShopA, ref ID Atom_ItemShopA_ID)
        {
            string Err = null;
            string scond = null;
            string sval = null;
            m_Atom_ItemShopA.VisibleForSelection.set(true);
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            m_Atom_ItemShopA.Name.setsqlp(ref lpar, "Name", ref scond, ref sval);
            m_Atom_ItemShopA.Description.setsqlp(ref lpar, "Description", ref scond, ref sval);
            m_Atom_ItemShopA.m_Taxation.ID.setsqlp(ref lpar, "Taxation_ID", ref scond, ref sval);
            m_Atom_ItemShopA.m_Unit.ID.setsqlp(ref lpar, "Unit_ID", ref scond, ref sval);
            string sql = " select ID from Atom_ItemShopA where "
                            + m_Atom_ItemShopA.Name.cond + " and "
                            + m_Atom_ItemShopA.Description.cond + " and "
                            + m_Atom_ItemShopA.m_Taxation.ID.cond + " and "
                            + m_Atom_ItemShopA.m_Unit.ID.cond;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt,sql,lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Atom_ItemShopA_ID==null)
                    {
                        Atom_ItemShopA_ID = new ID();
                    }
                    Atom_ItemShopA_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = "insert into Atom_ItemShopA (Name,Description,Taxation_ID,Unit_ID,VisibleForSelection) values ("
                            + m_Atom_ItemShopA.Name.value + ","
                            + m_Atom_ItemShopA.Description.value + ","
                            + m_Atom_ItemShopA.m_Taxation.ID.value + ","
                            + m_Atom_ItemShopA.m_Unit.ID.value + ",1)";
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql,lpar,ref Atom_ItemShopA_ID, ref Err, "Atom_ItemShopA"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:ShopA_dbfunc:dbfunc:get(Atom_ItemShopA m_Atom_ItemShopA, ref long atom_ItemShopA_ID) sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:ShopA_dbfunc:dbfunc:get(Atom_ItemShopA m_Atom_ItemShopA, ref long atom_ItemShopA_ID) sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool delete(string DocInvoice,ID atom_ItemShopA_Price_ID)
        {
            string Err = null;
            string sql = null;
            if (DocInvoice.Equals("DocInvoice"))
            {
                sql =    @"delete from DocInvoice_ShopA_Item
                                                   where ID = " + atom_ItemShopA_Price_ID.ToString();
            }
            else if (DocInvoice.Equals("DocProformaInvoice"))
            {
                sql = @"delete from DocProformaInvoice_ShopA_Item
                                                   where ID = " + atom_ItemShopA_Price_ID.ToString();
            }
            else
            {
                LogFile.Error.Show("ERROR:ShopA_dbfunc:dbfunc:DocInvoice=" + DocInvoice+" not implememted.");
                return false;
            }


            object ores = null;
            if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref ores, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:ShopA_dbfunc:dbfunc:delete sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

    }
}
