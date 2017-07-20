using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public class MethodOfPayment_definitions
    {
        public long Avans100Percent_ID = -1;
        public DataTable dt_MethodOfPayment = null;

        public bool Read(ref string Err)
        {
            string sql = @"select ID,
                                  MethodOfPayment_$$PaymentType,
                                  MethodOfPayment_$_abc_$$TRR,
                                  MethodOfPayment_$_abc_$$Description,
                                  MethodOfPayment_$_abc_$_ab_$_aorg_$$Name,
                                  MethodOfPayment_$_abc_$_ab_$_aorg_$$Tax_ID,
                                  MethodOfPayment_$_abc_$_ab_$_aorg_$$Name from MethodOfPayment_VIEW";
            if (dt_MethodOfPayment==null)
            {
                dt_MethodOfPayment = new DataTable();
            }
            dt_MethodOfPayment.Clear();
            dt_MethodOfPayment.Columns.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dt_MethodOfPayment,sql,ref Err))
            {
                return true;
            }
            else
            {
                Err = "ERROR:";
                return false;
            }

        }
        /*
        CREATE VIEW MethodOfPayment_VIEW AS SELECT 
            MethodOfPayment.ID, 
            MethodOfPayment.PaymentType AS MethodOfPayment_$$PaymentType,
            MethodOfPayment_$_abc.ID AS MethodOfPayment_$_abc_$$ID,
            MethodOfPayment_$_abc_$_ab.ID AS MethodOfPayment_$_abc_$_ab_$$ID,
            MethodOfPayment_$_abc_$_ab_$_aorg.ID AS MethodOfPayment_$_abc_$_ab_$_aorg_$$ID,
            MethodOfPayment_$_abc_$_ab_$_aorg.Name AS MethodOfPayment_$_abc_$_ab_$_aorg_$$Name,
            MethodOfPayment_$_abc_$_ab_$_aorg.Tax_ID AS MethodOfPayment_$_abc_$_ab_$_aorg_$$Tax_ID,
            MethodOfPayment_$_abc_$_ab_$_aorg.Registration_ID AS MethodOfPayment_$_abc_$_ab_$_aorg_$$Registration_ID,
            MethodOfPayment_$_abc.Active AS MethodOfPayment_$_abc_$$Active,
            MethodOfPayment_$_abc.TRR AS MethodOfPayment_$_abc_$$TRR,
            MethodOfPayment_$_abc.Description AS MethodOfPayment_$_abc_$$Description 
            FROM MethodOfPayment 
            LEFT JOIN Atom_BankAccount MethodOfPayment_$_abc ON MethodOfPayment.Atom_BankAccount_ID = MethodOfPayment_$_abc.ID 
            LEFT JOIN Atom_Bank MethodOfPayment_$_abc_$_ab ON MethodOfPayment_$_abc.Atom_Bank_ID = MethodOfPayment_$_abc_$_ab.ID
            LEFT JOIN Atom_Organisation MethodOfPayment_$_abc_$_ab_$_aorg ON MethodOfPayment_$_abc_$_ab.Atom_Organisation_ID = MethodOfPayment_$_abc_$_ab_$_aorg.ID
        */
        public bool InsertDefault(ref string err)
        {
            return false;
        }
        
    }
}
