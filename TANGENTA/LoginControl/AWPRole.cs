using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoginControl
{
    public class AWPRole
    {
        private long id = -1;
        internal long ID
        {
            get { return id; }
            set { id = value; }
        }

        private string role = null;
        internal string Role
        {
            get { return role; }
            set { role = value; }
        }

        private string name = null;
        internal string Name
        {
            get { return name; }
        }

        internal AWPRole(long xid, string xrole)
        {
            id = xid;
            role = xrole;
            if (role.Equals(LoginControl.ROLE_Administrator))
            {
                name = lng.cn_Role_Administrator.s;
            }
            else if (role.Equals(LoginControl.ROLE_PriceListManagement))
            {
                name = lng.cn_Role_PriceListManagement.s;
            }
            else if (role.Equals(LoginControl.ROLE_StockTakeManagement))
            {
                name = lng.cn_Role_StockTakeManagemenent.s;
            }
            else if (role.Equals(LoginControl.ROLE_UserManagement))
            {
                name = lng.cn_Role_UserManagement.s;
            }
            else if (role.Equals(LoginControl.ROLE_WriteInvoice))
            {
                name = lng.cn_Role_WriteInvoice.s;
            }
            else if (role.Equals(LoginControl.ROLE_WriteProformainvoice))
            {
                name = lng.cn_Role_WriteProformaInvoice.s;
            }
            else if (role.Equals(LoginControl.ROLE_WorkInShopA))
            {
                name = lng.cn_Role_WorkInShopA.s;
            }
            else if (xrole.Equals(LoginControl.ROLE_WorkInShopB))
            {
                name = lng.cn_Role_WorkInShopB.s;
            }
            else if (xrole.Equals(LoginControl.ROLE_WorkInShopC))
            {
                name = lng.cn_Role_WorkInShopC.s;
            }
            else if (xrole.Equals(LoginControl.ROLE_ViewAndExport))
            {
                name = lng.cn_Role_WorkInShopC.s;
            }
            else
            {
                LogFile.Error.Show("ERROR:LoginControl:AWPRole:Role=" + role + " not implemented!");
                name = role;

            }
        }
    }
}