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
    public static class f_DocInvoice_Atom_WorkArea
    {
        public static bool Get(ID docInvoice_ID, ID xAtom_WorkArea_ID, ref ID docInvoice_Atom_WorkArea_ID, Transaction transaction )
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string Err = null;
            string scond_docInvoice_ID = null;
            string sval_docInvoice_ID = "null";
            if (ID.Validate(docInvoice_ID))
            {
                string spar_docInvoice_ID = "@par_docInvoice_ID";
                SQL_Parameter par_docInvoice_ID = new SQL_Parameter(spar_docInvoice_ID, false, docInvoice_ID);
                lpar.Add(par_docInvoice_ID);
                scond_docInvoice_ID = " DocInvoice_ID = " + spar_docInvoice_ID;
                sval_docInvoice_ID = spar_docInvoice_ID;
            }
            else
            {
                scond_docInvoice_ID = " DocInvoice_ID is null";
                sval_docInvoice_ID = "null";
            }

            string scond_Atom_WorkArea_ID = null;
            string sval_Atom_WorkArea_ID = "null";
            if (ID.Validate(xAtom_WorkArea_ID))
            {
                string spar_Atom_WorkArea_ID = "@par_Atom_WorkArea_ID";
                SQL_Parameter par_Atom_WorkArea_ID = new SQL_Parameter(spar_Atom_WorkArea_ID, false,xAtom_WorkArea_ID);
                lpar.Add(par_Atom_WorkArea_ID);
                scond_Atom_WorkArea_ID = "Atom_WorkArea_ID = " + spar_Atom_WorkArea_ID;
                sval_Atom_WorkArea_ID = spar_Atom_WorkArea_ID;
            }
            else
            {
                scond_Atom_WorkArea_ID = "Atom_WorkArea_ID is null";
                sval_Atom_WorkArea_ID = "null";
            }

            string sql = @"select ID
                                     from DocInvoice_Atom_WorkArea
                                      where " + scond_docInvoice_ID + " and " + scond_Atom_WorkArea_ID;

            DataTable dt = new DataTable();

            if (DBSync.DBSync.ReadDataTable(ref dt, sql,lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    docInvoice_Atom_WorkArea_ID = tf.set_ID(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @" insert into DocInvoice_Atom_WorkArea (DocInvoice_ID,Atom_WorkArea_ID)values(" + sval_docInvoice_ID + "," + sval_Atom_WorkArea_ID + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql,lpar, ref docInvoice_Atom_WorkArea_ID,ref Err, "DocInvoice_Atom_WorkArea"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice_AtomWorkArea:Get:sql=" + sql + "\r\nErr" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice_AtomWorkArea:Get:sql=" + sql + "\r\nErr" + Err);
                return false;
            }
        }
    }
}
