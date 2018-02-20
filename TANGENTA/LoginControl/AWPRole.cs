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

        public static bool RoleInLanguage(string xrole, ref string role_in_language)
        {
            if (xrole.Equals(AWP.ROLE_Administrator))
            {
                role_in_language = lng.cn_Role_Administrator.s;
            }
            else if (xrole.Equals(AWP.ROLE_PriceListManagement))
            {
                role_in_language = lng.cn_Role_PriceListManagement.s;
            }
            else if (xrole.Equals(AWP.ROLE_StockTakeManagement))
            {
                role_in_language = lng.cn_Role_StockTakeManagemenent.s;
            }
            else if (xrole.Equals(AWP.ROLE_UserManagement))
            {
                role_in_language = lng.cn_Role_UserManagement.s;
            }
            //else if (xrole.Equals(AWP.ROLE_WriteInvoice))
            //{
            //    role_in_language = lng.cn_Role_WriteInvoice.s;
            //}
            //else if (xrole.Equals(AWP.ROLE_WriteProformainvoice))
            //{
            //    role_in_language = lng.cn_Role_WriteProformaInvoice.s;
            //}
            //else if (xrole.Equals(AWP.ROLE_WorkInShopA))
            //{
            //    role_in_language = lng.cn_Role_WorkInShopA.s;
            //}
            //else if (xrole.Equals(AWP.ROLE_WorkInShopB))
            //{
            //    role_in_language = lng.cn_Role_WorkInShopB.s;
            //}
            //else if (xrole.Equals(AWP.ROLE_WorkInShopC))
            //{
            //    role_in_language = lng.cn_Role_WorkInShopC.s;
            //}
            //else if (xrole.Equals(AWP.ROLE_ViewAndExport))
            //{
            //    role_in_language = lng.cn_Role_WorkInShopC.s;
            //}
            else
            {
                LogFile.Error.Show("ERROR:LoginControl:AWPRole:Role=" + xrole + " not implemented!");
                role_in_language = xrole;
                return false;

            }
            return true;
        }

        internal AWPRole(long xid, string xrole)
        {
            id = xid;
            role = xrole;
            RoleInLanguage(xrole, ref name);
        }

        public static string RolesInLanguages(string[] roles)
        {
            string roles_in_language = null;
            foreach (string srole in roles)
            {
                string role_in_lang = null;
                LoginControl.AWPRole.RoleInLanguage(srole, ref role_in_lang);
                if (roles_in_language == null)
                {
                    roles_in_language = "\"" + role_in_lang + "\"";
                }
                else
                {
                    roles_in_language += ",\"" + role_in_lang + "\"";
                }
            }
            return roles_in_language;
        }

    }
}