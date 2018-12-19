#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_Atom_Computer
    {


        public static bool Get(ref ID Atom_Computer_ID, Transaction transaction)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            ID Atom_ComputerName_ID = null;
            ID Atom_ComputerUsername_ID = null;
            ID Atom_MAC_address_ID = null;

            string Err = null;
            DataTable dt = new DataTable();

            if (f_Atom_ComputerName.Get(ref Atom_ComputerName_ID, transaction))
            {
                string scond_Atom_ComputerName_ID = null;
                string sval_Atom_ComputerName_ID = "null";
                if (ID.Validate(Atom_ComputerName_ID))
                {
                    string spar_Atom_ComputerName_ID = "@par_ComputerName";
                    SQL_Parameter par_Atom_ComputerName_ID = new SQL_Parameter(spar_Atom_ComputerName_ID, false, Atom_ComputerName_ID);
                    lpar.Add(par_Atom_ComputerName_ID);
                    scond_Atom_ComputerName_ID = "Atom_ComputerName_ID = " + spar_Atom_ComputerName_ID;
                    sval_Atom_ComputerName_ID = spar_Atom_ComputerName_ID;
                }
                else
                {
                    scond_Atom_ComputerName_ID = "Atom_ComputerName_ID is null";
                    sval_Atom_ComputerName_ID = "null";
                }

                if (f_Atom_ComputerUsername.Get(ref Atom_ComputerUsername_ID))
                {
                    string scond_Atom_ComputerUsername_ID = null;
                    string sval_Atom_ComputerUsername_ID = "null";
                    if (ID.Validate(Atom_ComputerUsername_ID))
                    {
                        string spar_Atom_ComputerUsername_ID = "@par_Atom_ComputerUsername_ID";
                        SQL_Parameter par_Atom_ComputerUsername_ID = new SQL_Parameter(spar_Atom_ComputerUsername_ID,  false, Atom_ComputerUsername_ID);
                        lpar.Add(par_Atom_ComputerUsername_ID);
                        scond_Atom_ComputerUsername_ID = "Atom_ComputerUsername_ID = " + spar_Atom_ComputerUsername_ID;
                        sval_Atom_ComputerUsername_ID = spar_Atom_ComputerUsername_ID;
                    }
                    else
                    {
                        scond_Atom_ComputerUsername_ID = "Atom_ComputerUsername_ID is null";
                        sval_Atom_ComputerUsername_ID = "null";
                    }

                    if (f_Atom_MAC_address.Get(ref Atom_MAC_address_ID))
                    {
                        string scond_Atom_MAC_address_ID = null;
                        string sval_Atom_MAC_address_ID = "null";
                        if (ID.Validate(Atom_MAC_address_ID))
                        {
                            string spar_Atom_MAC_address_ID = "@par_Atom_MAC_address_ID";
                            SQL_Parameter par_Atom_MAC_address_ID = new SQL_Parameter(spar_Atom_MAC_address_ID, false, Atom_MAC_address_ID);
                            lpar.Add(par_Atom_MAC_address_ID);
                            scond_Atom_MAC_address_ID = "Atom_MAC_address_ID = " + spar_Atom_MAC_address_ID;
                            sval_Atom_MAC_address_ID = spar_Atom_MAC_address_ID;
                        }
                        else
                        {
                            scond_Atom_MAC_address_ID = "Atom_MAC_address_ID is null";
                            sval_Atom_MAC_address_ID = "null";
                        }




                        string sql = @"select ID from Atom_Computer
                                                            where (" + scond_Atom_ComputerName_ID + ") and (" + scond_Atom_ComputerUsername_ID + ") and (" + scond_Atom_MAC_address_ID + ")";

                        if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                        {
                            if (dt.Rows.Count > 0)
                            {
                                if (Atom_Computer_ID==null)
                                {
                                    Atom_Computer_ID = new ID();
                                }
                                Atom_Computer_ID.Set(dt.Rows[0]["ID"]);
                                return true;
                            }
                            else
                            {
                                sql = @"insert into Atom_Computer (Atom_ComputerName_ID,Atom_ComputerUsername_ID,Atom_MAC_address_ID) values (" + sval_Atom_ComputerName_ID + "," + sval_Atom_ComputerUsername_ID + "," + sval_Atom_MAC_address_ID +  ")";
                                if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_Computer_ID, ref Err, "Atom_Computer"))
                                {
                                    return true;
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:f_Atom_Computer:Get:" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_Atom_Computer:Get:" + sql + "\r\nErr=" + Err);
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
            else
            {
                return false;
            }
        }
    }
}
