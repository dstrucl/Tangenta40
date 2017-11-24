#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public class myOrg_Person
    {
        public long ID = 0;
        public string_v UserName_v = null;
        public string_v FirstName_v = null;
        public string_v LastName_v = null;
        public string_v Job_v = null;
        public byte_array_v Password_v = null;
        public bool_v Active_v = null;
        public bool_v Gender_v = null;
        public DateTime_v DateOfBirth_v = null;
        public string_v Tax_ID_v = null;
        public string_v Registration_ID_v = null;
        public string_v Description_v = null;
        public myOrg_Office myOrg_Office = new myOrg_Office();
    }
}
