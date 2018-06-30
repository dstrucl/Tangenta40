#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeTables
{
    public class ID_v
    {
        public long v = -1;

        public ID_v()
        {
        }

        public ID_v(long xv)
        {
            v = xv;
        }
    }

    public class ForeignKey
    {
        public ID_v reference_ID = null;
        public string ID_ForeignKey = "";
        public string ReferenceTable = "";
        public SQLTable refInListOfTables = null; // this are linked list references acrosss List<SQLTable> 
        public SQLTable fTable = null;   // this are linked list references of standalone tree of SQLTable !
        public bool brefTableID = false;
        public string ReferenceTable_Column = "";
        public TabPage TabPage = null;

        public ForeignKey()
        {
        }

        public ForeignKey(ForeignKey srcfKey)
        {
            ID_ForeignKey = srcfKey.ID_ForeignKey;
            ReferenceTable = srcfKey.ReferenceTable;
            brefTableID = srcfKey.brefTableID;
            refInListOfTables = srcfKey.refInListOfTables;
            if (srcfKey.refInListOfTables != null)
            {
                fTable = new SQLTable(srcfKey.refInListOfTables);
            }
            ReferenceTable_Column = srcfKey.ReferenceTable_Column;
        }

        public ForeignKey(ForeignKey srcfKey, SQLTable DBm_owner_Tabel,List<SQLTable> lTable)
        {
            ID_ForeignKey = srcfKey.ID_ForeignKey;
            ReferenceTable = srcfKey.ReferenceTable;
            brefTableID = srcfKey.brefTableID;
            refInListOfTables = srcfKey.refInListOfTables;
            if (srcfKey.refInListOfTables != null)
            {
                fTable = new SQLTable(srcfKey.refInListOfTables, DBm_owner_Tabel, lTable);
                lTable.Add(fTable);
            }
            ReferenceTable_Column = srcfKey.ReferenceTable_Column;
        }


        internal bool IsNull
        {
            get
            {
                if (this.fTable != null)
                {
                    if (this.fTable.myGroupBox != null)
                    {
                        if (this.fTable.myGroupBox.usrc_lbl != null)
                        {
                            return this.fTable.myGroupBox.usrc_lbl.Null_Selected;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:ForeignKey:IsNull:this.fTable.myGroupBox.usrc_lbl == null!");
                            return true;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:ForeignKey:IsNull:this.fTable.myGroupBox == null!");
                        return true;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:ForeignKey:IsNull:this.fTable == null!");
                    return true;
                }
             }
        }
    }
}
