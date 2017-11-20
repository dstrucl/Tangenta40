using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeDB
{
    internal static class Upgrade_1_21_to_1_22
    {
        internal static object UpgradeDB_1_21_to_1_22(object obj, ref string Err)
        {
            if (DBSync.DBSync.Drop_VIEWs(ref Err))
            {

                string[] new_tables = new string[] {"LoginUsers",
                                                    "LoginRoles",
                                                    "LoginUsersAndLoginRoles",
                                                    "LoginSession",
                                                    "LoginFailed",
                                                    "LoginManagerEvent",
                                                    "LoginManagerJournal"    };

                if (DBSync.DBSync.CreateTables(new_tables, ref Err))
                {
                    if (DBSync.DBSync.Create_VIEWs())
                    {
                        return UpgradeDB_inThread.Set_DataBase_Version("1.22");
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
