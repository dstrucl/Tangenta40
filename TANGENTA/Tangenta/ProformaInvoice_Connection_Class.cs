#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using TangentaDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnectionControl40;

namespace Tangenta
{
    public class DocInvoice_Connection_Class
    {
        public long ID = -1;
        public DataTable dt_atom_price_simpleitem = null;
        public DataTable dt_journal_docinvoice = null;

        internal bool WriteNew(long new_DocInvoice_id, Transaction transaction)
        {
            foreach (DataRow dr in dt_atom_price_simpleitem.Rows)
            {
                dr["DocInvoice_ID"] = new_DocInvoice_id;
                ID atom_price_simpleitem_ID = null;
                if (!fs.WriteRow("atom_price_simpleitem", dr, null, false, ref atom_price_simpleitem_ID, transaction))
                {
                    return false;
                }
            }
            foreach (DataRow dr in dt_journal_docinvoice.Rows)
            {
                dr["DocInvoice_ID"] = new_DocInvoice_id;
                ID journal_docinvoice_ID = null;
                if (!fs.WriteRow("journal_docinvoice", dr, null, false, ref journal_docinvoice_ID, transaction))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
