using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoginControl
{
    public static class STD_MSSQL
    {
        internal static bool Read_Login_VIEW(ref LoginDB_DataSet.Login_VIEW m_Login_VIEW,DBConnection Login_con, ref string Err)
        {
            if (m_Login_VIEW == null)
            {
                m_Login_VIEW = new LoginDB_DataSet.Login_VIEW(Login_con);
            }
            m_Login_VIEW.Clear();
            m_Login_VIEW.select.all(true);
            if (m_Login_VIEW.Read(ref Err))
            {
                if (m_Login_VIEW.dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    Err = "ERROR: Some Login Tables are empty !";
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
