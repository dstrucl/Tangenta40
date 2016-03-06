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

        public static bool Read_ShopA_Price_Item_Table(long ProformaInvoice_ID,ref DataTable dt)
        {
            string Err = null;
            string sql = @"SELECT 
                            Atom_ItemShopA_Price.ID,
                            Atom_ItemShopA_Price_$_pinv.ID AS Atom_ItemShopA_Price_$_pinv_$$ID,
                            Atom_ItemShopA_Price_$_pinv.Draft AS Atom_ItemShopA_Price_$_pinv_$$Draft,
                            Atom_ItemShopA_Price_$_aisha.ID AS Atom_ItemShopA_Price_$_aisha_$$ID,
                            Atom_ItemShopA_Price_$_aisha.Name AS Atom_ItemShopA_Price_$_aisha_$$Name,
                            Atom_ItemShopA_Price_$_aisha.Description AS Atom_ItemShopA_Price_$_aisha_$$Description,
                            Atom_ItemShopA_Price_$_aisha_$_tax.ID AS Atom_ItemShopA_Price_$_aisha_$_tax_$$ID,
                            Atom_ItemShopA_Price_$_aisha_$_tax.Name AS Atom_ItemShopA_Price_$_aisha_$_tax_$$Name,
                            Atom_ItemShopA_Price_$_aisha_$_tax.Rate AS Atom_ItemShopA_Price_$_aisha_$_tax_$$Rate,
                            Atom_ItemShopA_Price_$_aisha_$_u.ID AS Atom_ItemShopA_Price_$_aisha_$_u_$$ID,
                            Atom_ItemShopA_Price_$_aisha_$_u.Name AS Atom_ItemShopA_Price_$_aisha_$_u_$$Name,
                            Atom_ItemShopA_Price_$_aisha_$_u.Symbol AS Atom_ItemShopA_Price_$_aisha_$_u_$$Symbol,
                            Atom_ItemShopA_Price_$_aisha_$_u.DecimalPlaces AS Atom_ItemShopA_Price_$_aisha_$_u_$$DecimalPlaces,
                            Atom_ItemShopA_Price.Discount AS Atom_ItemShopA_Price_$$Discount,
                            Atom_ItemShopA_Price.dQuantity AS Atom_ItemShopA_Price_$$dQuantity,
                            Atom_ItemShopA_Price.PricePerUnit AS Atom_ItemShopA_Price_$$PricePerUnit,
                            Atom_ItemShopA_Price.EndPriceWithDiscountAndTax AS Atom_ItemShopA_Price_$$EndPriceWithDiscountAndTax,
                            Atom_ItemShopA_Price.TAX AS Atom_ItemShopA_Price_$$TAX
                            FROM Atom_ItemShopA_Price 
                            INNER JOIN ProformaInvoice Atom_ItemShopA_Price_$_pinv ON Atom_ItemShopA_Price.ProformaInvoice_ID = Atom_ItemShopA_Price_$_pinv.ID
                            INNER JOIN Atom_ItemShopA Atom_ItemShopA_Price_$_aisha ON Atom_ItemShopA_Price.Atom_ItemShopA_ID = Atom_ItemShopA_Price_$_aisha.ID
                            INNER JOIN Taxation Atom_ItemShopA_Price_$_aisha_$_tax ON Atom_ItemShopA_Price_$_aisha.Taxation_ID = Atom_ItemShopA_Price_$_aisha_$_tax.ID
                            LEFT JOIN Unit Atom_ItemShopA_Price_$_aisha_$_u ON Atom_ItemShopA_Price_$_aisha.Unit_ID = Atom_ItemShopA_Price_$_aisha_$_u.ID
                            where Atom_ItemShopA_Price_$_pinv.ID = " + ProformaInvoice_ID.ToString();
            dt.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:Read_Atom_SimpleItem_Table:select ... from Atom_SimpleItem:\r\n Err=" + Err);
                return false;
            }
        }


        public static bool insert(Atom_ItemShopA_Price m_Atom_ItemShopA_Price, ref long Atom_ItemShopA_Price_ID)
        {
            long Atom_ItemShopA_ID = -1;
            
            if (get(m_Atom_ItemShopA_Price.m_Atom_ItemShopA, ref Atom_ItemShopA_ID))
            {
                string Err = null;
                string scond = null;
                string sval = null;
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                m_Atom_ItemShopA_Price.m_Atom_ItemShopA.ID.set(Atom_ItemShopA_ID);
                m_Atom_ItemShopA_Price.m_ProformaInvoice.ID.setsqlp(ref lpar, "ProformaInvoice_ID", ref scond, ref sval);
                m_Atom_ItemShopA_Price.m_Atom_ItemShopA.ID.setsqlp(ref lpar, "Atom_ItemShopA_ID", ref scond, ref sval);
                m_Atom_ItemShopA_Price.EndPriceWithDiscountAndTax.setsqlp(ref lpar, "EndPriceWithDiscountAndTax", ref scond, ref sval);
                m_Atom_ItemShopA_Price.PricePerUnit.setsqlp(ref lpar, "PricePerUnit", ref scond, ref sval);
                m_Atom_ItemShopA_Price.dQuantity.setsqlp(ref lpar, "dQuantity", ref scond, ref sval);
                m_Atom_ItemShopA_Price.Discount.setsqlp(ref lpar, "Discount", ref scond, ref sval);
                m_Atom_ItemShopA_Price.TAX.setsqlp(ref lpar, "TAX", ref scond, ref sval);
                string sql = "insert into Atom_ItemShopA_Price (ProformaInvoice_ID,Atom_ItemShopA_ID,Discount,dQuantity,PricePerUnit,EndPriceWithDiscountAndTax,TAX) values ("
                              + m_Atom_ItemShopA_Price.m_ProformaInvoice.ID.value + ","
                              + m_Atom_ItemShopA_Price.m_Atom_ItemShopA.ID.value + ","
                              + m_Atom_ItemShopA_Price.Discount.value + ","
                              + m_Atom_ItemShopA_Price.dQuantity.value + ","
                              + m_Atom_ItemShopA_Price.PricePerUnit.value + ","
                              + m_Atom_ItemShopA_Price.EndPriceWithDiscountAndTax.value + ","
                              + m_Atom_ItemShopA_Price.TAX.value + ")";
                object oret = null;
                if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_ItemShopA_Price_ID, ref oret, ref Err, "Atom_ItemShopA_Price"))
                {
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:ShopA_dbfunc:dbfunc:get(Atom_ItemShopA m_Atom_ItemShopA, ref long atom_ItemShopA_ID) sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            return false;
        }

        public static bool get(Atom_ItemShopA m_Atom_ItemShopA, ref long Atom_ItemShopA_ID)
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
                    Atom_ItemShopA_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = "insert into Atom_ItemShopA (Name,Description,Taxation_ID,Unit_ID,VisibleForSelection) values ("
                            + m_Atom_ItemShopA.Name.value + ","
                            + m_Atom_ItemShopA.Description.value + ","
                            + m_Atom_ItemShopA.m_Taxation.ID.value + ","
                            + m_Atom_ItemShopA.m_Unit.ID.value + ",1)";
                    object oret = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql,lpar,ref Atom_ItemShopA_ID,ref oret, ref Err, "Atom_ItemShopA"))
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

        public static bool delete(long atom_ItemShopA_Price_ID)
        {
            string Err = null;
            string sql = @"delete from Atom_ItemShopA_Price
                                                   where ID = " + atom_ItemShopA_Price_ID.ToString();
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
