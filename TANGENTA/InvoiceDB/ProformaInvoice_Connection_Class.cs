// Copyright (c) 2011 rubicon IT GmbH
#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using InvoiceDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB
{
    public class ProformaInvoice_Connection_Class
    {
        public long ID = -1;
        public DataTable dt_atom_price_simpleitem = null;
        public DataTable dt_journal_proformainvoice = null;

        public bool WriteNew(long new_ProformaInvoice_id)
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
