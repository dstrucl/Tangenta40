﻿using InvoiceDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangenta
{
    public class ProformaInvoice_Connection_Class
    {
        public long ID = -1;
        public DataTable dt_atom_price_simpleitem = null;
        public DataTable dt_journal_proformainvoice = null;

        internal bool WriteNew(long new_ProformaInvoice_id)
        {
            foreach (DataRow dr in dt_atom_price_simpleitem.Rows)
            {
                dr["ProformaInvoice_ID"] = new_ProformaInvoice_id;
                long atom_price_simpleitem_ID = -1;
                if (!fs.WriteRow("atom_price_simpleitem", dr, null, false, ref atom_price_simpleitem_ID))
                {
                    return false;
                }
            }
            foreach (DataRow dr in dt_journal_proformainvoice.Rows)
            {
                dr["ProformaInvoice_ID"] = new_ProformaInvoice_id;
                long journal_proformainvoice_ID = -1;
                if (!fs.WriteRow("journal_proformainvoice", dr, null, false, ref journal_proformainvoice_ID))
                {
                    return false;
                }
            }
            return true;
        }
    }
}