using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB
{
    public class myOrg_Person
    {
        public long ID = 0;
        public string_v UserName_v = null;
        public string_v FirstName_v = null;
        public string_v LastName_v = null;
        public string_v Job_v = null;
        public string_v Password_v = null;
        public bool_v Active_v = null;
        public bool_v Gender_v = null;
        public DateTime_v DateOfBirth_v = null;
        public string_v Tax_ID_v = null;
        public string_v Registration_ID_v = null;
        public string_v Description_v = null;
        public myOrg_Office myOrg_Office = new myOrg_Office();
    }
}
