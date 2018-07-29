using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangentaDB;

namespace Tangenta
{
    public class SettingsUser
    {
        public bool Load(LoginControl.LoginOfMyOrgUser luser)
        {
            DataTable dt = new DataTable();
            string sql = @"Select  from PropertiesSettings ps
                          inner 
                         ";
            foreach (SettingsProperty currentProperty in Properties.SettingsUser.Default.Properties)
            {
               
            }
            return false;
        }
    }
}
