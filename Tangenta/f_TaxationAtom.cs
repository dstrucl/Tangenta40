﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LogFile;

namespace Tangenta
{
    public static class f_Atom_Taxation
    {
        internal static bool Get(long Taxation_ID, ref long Atom_Taxation_ID)
        {
            string Err = null;
            DataTable dt = new DataTable();
            string sql = @"select Atom_Taxation.ID
                                                    from Atom_Taxation
                                                    inner join Taxation on Taxation.Name = Atom_Taxation.Name
                                                                           and Taxation.Rate = Atom_Taxation.Rate
                                                    where Taxation.ID = " + Taxation_ID.ToString();

            if (DBSync.DBSync.ReadDataTable(ref dt, sql, null, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Atom_Taxation_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = @"insert into Atom_Taxation (Name,Rate) select Name,Rate from Taxation where ID = " + Taxation_ID.ToString();
                    object objretx = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, null, ref Atom_Taxation_ID, ref objretx, ref Err, "Atom_Taxation"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_Taxation:Get:" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_Taxation:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

    }
}
