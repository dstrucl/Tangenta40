using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoginControl
{
    internal static class STAND_ALONE_MSSQL_CreateTables
    {
        public static bool DropConstraints(DBConnection db_con)
        {
            switch (db_con.DBType)
            {
                case DBConnection.eDBType.MSSQL:
                    string sql_DropConstraints = STAND_ALONE_MSSQL_commands.sql_DropConstraints;
                    object Result = null;
                    string Err = null;
                    if (db_con.ExecuteNonQuerySQL(sql_DropConstraints, null, ref Result, ref Err))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("Error:LoginControl:DropConstraints:Err = " + Err);
                        return false;
                    }

                default:
                    LogFile.Error.Show("Error:LoginControl:DropConstraints:Login_con.DBType not of type DBConnection.eDBType.MSSQL!");
                    return false;
            }
        }

        private static bool DropTables(DBConnection db_con)
        {
            switch (db_con.DBType)
            {
                case DBConnection.eDBType.MSSQL:
                    string sql_DropTables = STAND_ALONE_MSSQL_commands.sql_DropTables;
                    object Result = null;
                    string Err = null;
                    if (db_con.ExecuteNonQuerySQL(sql_DropTables, null, ref Result, ref Err))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("Error:LoginControl:DropTables:Err = " + Err);
                        return false;
                    }

                default:
                    LogFile.Error.Show("Error:LoginControl:DropTables:Login_con.DBType not of type DBConnection.eDBType.MSSQL!");
                    return false;
            }
        }
        internal static bool CreateTables(DBConnection Login_con)
        {
            string sCreateLoginTables = null;
            if (DropConstraints(Login_con))
            {
                if (DropTables(Login_con))
                {
                    switch (Login_con.DBType)
                    {
                        case DBConnection.eDBType.MSSQL:
                            sCreateLoginTables = STAND_ALONE_MSSQL_commands.sCreateLoginTables;
                            break;

                        case DBConnection.eDBType.MYSQL:
                            LogFile.Error.Show("ERROR:LoginControl does not support MySQL database yet.");
                            return false;

                        case DBConnection.eDBType.SQLITE:
                            LogFile.Error.Show("ERROR:LoginControl does not support SQLITE database yet.");
                            return false;

                        default:
                            LogFile.Error.Show("ERROR:LoginControl does not support ??? database yet.");
                            return false;
                    }
                    object Result = null;
                    string Err = null;
                    if (Login_con.ExecuteNonQuerySQL(sCreateLoginTables, null, ref Result, ref Err))
                    {
                        string drop_view = STAND_ALONE_MSSQL_commands.drop_view;

                        if (Login_con.ExecuteNonQuerySQL(drop_view, null, ref Result, ref Err))
                        {
                            string create_VIEW = STAND_ALONE_MSSQL_commands.create_VIEW;

                            if (Login_con.ExecuteNonQuerySQL(create_VIEW, null, ref Err))
                            {
                                string drop_view_LoginManagerJournal_VIEW = STAND_ALONE_MSSQL_commands.drop_view_LoginManagerJournal_VIEW;

                                if (Login_con.ExecuteNonQuerySQL(drop_view_LoginManagerJournal_VIEW, null, ref Err))
                                {

                                    string sql_LoginManagerJournal_VIEW = STAND_ALONE_MSSQL_commands.sql_LoginManagerJournal_VIEW;

                                    if (Login_con.ExecuteNonQuerySQL(sql_LoginManagerJournal_VIEW, null, ref Err))
                                    {
                                        string drop_view_LoginSession_VIEW = STAND_ALONE_MSSQL_commands.drop_view_LoginSession_VIEW;

                                        if (Login_con.ExecuteNonQuerySQL(drop_view_LoginSession_VIEW, null, ref Err))
                                        {
                                            string sql_LoginSession_VIEW = STAND_ALONE_MSSQL_commands.sql_LoginSession_VIEW;

                                            if (Login_con.ExecuteNonQuerySQL(sql_LoginSession_VIEW, null, ref Err))
                                            {
                                                string sql_drop_procedures_and_functions = STAND_ALONE_MSSQL_commands.sql_drop_procedures_and_functions;

                                                if (Login_con.ExecuteNonQuerySQL(sql_drop_procedures_and_functions, null, ref Err))
                                                {

                                                    string sql_Login_Server_GetDate = STAND_ALONE_MSSQL_commands.sql_Login_Server_GetDate;

                                                    if (Login_con.ExecuteNonQuerySQL(sql_Login_Server_GetDate, null, ref Err))
                                                    {

                                                        string sql_Login_PasswordExpired = STAND_ALONE_MSSQL_commands.sql_Login_PasswordExpired;

                                                        if (Login_con.ExecuteNonQuerySQL(sql_Login_PasswordExpired, null, ref Err))
                                                        {

                                                            string sql_LoginManager_AddJournal = STAND_ALONE_MSSQL_commands.sql_LoginManager_AddJournal;

                                                            if (Login_con.ExecuteNonQuerySQL(sql_LoginManager_AddJournal, null, ref Err))
                                                            {
                                                                string sql_LoginSession_Start = STAND_ALONE_MSSQL_commands.sql_LoginSession_Start;

                                                                if (Login_con.ExecuteNonQuerySQL(sql_LoginSession_Start, null, ref Err))
                                                                {
                                                                    string sql_LoginSession_End = STAND_ALONE_MSSQL_commands.sql_LoginSession_End;

                                                                    if (Login_con.ExecuteNonQuerySQL(sql_LoginSession_End, null, ref Err))
                                                                    {
                                                                        string sql_LoginUsers_ChangeData = STAND_ALONE_MSSQL_commands.sql_LoginUsers_ChangeData;

                                                                        if (Login_con.ExecuteNonQuerySQL(sql_LoginUsers_ChangeData, null, ref Err))
                                                                        {
                                                                            string sql_LoginUsers_UserChangeItsOwnPassword = STAND_ALONE_MSSQL_commands.sql_LoginUsers_UserChangeItsOwnPassword;

                                                                            if (Login_con.ExecuteNonQuerySQL(sql_LoginUsers_UserChangeItsOwnPassword, null, ref Err))
                                                                            {

                                                                                string sql_LoginUsers_Administrator_ChangePassword = STAND_ALONE_MSSQL_commands.sql_LoginUsers_Administrator_ChangePassword;

                                                                                if (Login_con.ExecuteNonQuerySQL(sql_LoginUsers_Administrator_ChangePassword, null, ref Err))
                                                                                {
                                                                                    string sql_LoginUsers_Administrator_ChangePasswordParameters = STAND_ALONE_MSSQL_commands.sql_LoginUsers_Administrator_ChangePasswordParameters;

                                                                                    if (Login_con.ExecuteNonQuerySQL(sql_LoginUsers_Administrator_ChangePasswordParameters, null, ref Err))
                                                                                    {
                                                                                        string sql_LoginUsers_Administrator_AddUser = STAND_ALONE_MSSQL_commands.sql_LoginUsers_Administrator_AddUser;

                                                                                        if (Login_con.ExecuteNonQuerySQL(sql_LoginUsers_Administrator_AddUser, null, ref Err))
                                                                                        {
                                                                                            string sql_LoginUsers_Administrator_DeleteUser = STAND_ALONE_MSSQL_commands.sql_LoginUsers_Administrator_DeleteUser;

                                                                                            if (Login_con.ExecuteNonQuerySQL(sql_LoginUsers_Administrator_DeleteUser, null, ref Err))
                                                                                            {

                                                                                                string sql_LoginUsers_Administrator_AddRole = STAND_ALONE_MSSQL_commands.sql_LoginUsers_Administrator_AddRole;

                                                                                                if (Login_con.ExecuteNonQuerySQL(sql_LoginUsers_Administrator_AddRole, null, ref Err))
                                                                                                {

                                                                                                    string sql_LoginUsersAndLoginRoles_Add = STAND_ALONE_MSSQL_commands.sql_LoginUsersAndLoginRoles_Add;

                                                                                                    if (Login_con.ExecuteNonQuerySQL(sql_LoginUsersAndLoginRoles_Add, null, ref Err))
                                                                                                    {

                                                                                                        return true;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        LogFile.Error.Show("ERROR:LoginControl sql_LoginUsersAndLoginRoles_Add :" + Err);
                                                                                                        return false;
                                                                                                    }

                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    LogFile.Error.Show("ERROR:LoginControl sql_LoginUsers_Administrator_AddRole :" + Err);
                                                                                                    return false;
                                                                                                }

                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                LogFile.Error.Show("ERROR:LoginControl sql_LoginUsers_Administrator_DeleteUser :" + Err);
                                                                                                return false;
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            LogFile.Error.Show("ERROR:LoginControl sql_LoginUsers_Administrator_AddUser :" + Err);
                                                                                            return false;
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        LogFile.Error.Show("ERROR:LoginControl sql_LoginUsers_Administrator_ChangePasswordParameters :" + Err);
                                                                                        return false;
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    LogFile.Error.Show("ERROR:LoginControl sql_LoginUsers_Administrator_ChangePassword :" + Err);
                                                                                    return false;
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                LogFile.Error.Show("ERROR:LoginControl sql_LoginUsers_ChangePassword :" + Err);
                                                                                return false;
                                                                            }

                                                                        }
                                                                        else
                                                                        {
                                                                            LogFile.Error.Show("ERROR:LoginControl sql_LoginUsers_ChangeData :" + Err);
                                                                            return false;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        LogFile.Error.Show("ERROR:LoginControl sql_LoginSession_End :" + Err);
                                                                        return false;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    LogFile.Error.Show("ERROR:LoginControl sql_LoginSession_Start :" + Err);
                                                                    return false;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                LogFile.Error.Show("ERROR:LoginControl sql_LoginManager_AddJournal :" + Err);
                                                                return false;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            LogFile.Error.Show("ERROR:LoginControl sql_Login_PasswordExpired :" + Err);
                                                            return false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        LogFile.Error.Show("ERROR:LoginControl sql_Login_Server_GetDate :" + Err);
                                                        return false;
                                                    }

                                                }
                                                else
                                                {
                                                    LogFile.Error.Show("ERROR:LoginControl sql_drop_procedures_and_functions :" + Err);
                                                    return false;
                                                }
                                            }
                                            else
                                            {
                                                LogFile.Error.Show("ERROR:LoginControl sql_LoginSession_VIEW :" + Err);
                                                return false;

                                            }
                                        }
                                        else
                                        {
                                            LogFile.Error.Show("ERROR:LoginControl drop_view_LoginSession_VIEW :" + Err);
                                            return false;

                                        }
                                    }
                                    else
                                    {
                                        LogFile.Error.Show("ERROR:LoginControl create_view_LoginManagerJournal_VIEW :" + Err);
                                        return false;

                                    }
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:LoginControl drop_view_LoginManagerJournal_VIEW :" + Err);
                                    return false;

                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:LoginControl create_View :" + Err);
                                return false;
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:LoginControl drop_view :" + Err);
                            return false;

                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:LoginControl:" + Err);
                        return false;
                    }
                }
                else
                {
                    return false; // Drop Tables failed
                }
            }
            else
            {
                return false; // Drop Constraints failed
            }
        }
    }
}
