using DBTypes;
using LanguageControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB
{
    public class SampleDB
    {
        string_v Organisation_Name_v =null;
        string_v Tax_ID_v = null;
        string_v Registration_ID_v = null;
        string_v OrganisationTYPE_v=  null;
        PostAddress_v Address_v=  null;
        string_v PhoneNumber_v=  null;
        string_v FaxNumber_v=  null;
        string_v Email_v=  null;
        string_v HomePage_v=  null;
        string_v BankName_v=  null;
        string_v TRR_v=  null;

        string_v Image_Hash_v = null;
        byte_array_v Image_Data_v = null;
        string_v Image_Description_v = null;
        long_v Atom_Organisation_ID_v = null;
        long_v Atom_OrganisationData_ID_v = null;

        public SampleDB()
        {

            Organisation_Name_v = new DBTypes.string_v(lngRPMS.s_Organisation_Name_v.s);
            Tax_ID_v = new DBTypes.string_v(lngRPMS.s_Tax_ID_v.s);
            Registration_ID_v = new DBTypes.string_v(lngRPMS.s_Registration_ID_v.s);
            OrganisationTYPE_v = new DBTypes.string_v(lngRPMS.s_OrganisationTYPE_v.s);
     
            PhoneNumber_v = new DBTypes.string_v(lngRPMS.s_PhoneNumber_v.s);
            FaxNumber_v = new DBTypes.string_v(lngRPMS.s_FaxNumber_v.s);
            Email_v = new DBTypes.string_v(lngRPMS.s_Email_v.s);
            HomePage_v = new DBTypes.string_v(lngRPMS.s_HomePage_v.s);
            BankName_v = new DBTypes.string_v(lngRPMS.s_BankName_v.s);
            TRR_v = new DBTypes.string_v(lngRPMS.s_TRR_v.s);
       }
        public bool Write()
        {
            if (f_Atom_Organisation.Get(Organisation_Name_v,
                                 Tax_ID_v,
                                 Registration_ID_v,
                                 OrganisationTYPE_v,
                                 Address_v,
                                 PhoneNumber_v,
                                 FaxNumber_v,
                                 Email_v,
                                  HomePage_v,
                                  BankName_v,
                                  TRR_v,
                                  Image_Hash_v,
                                  Image_Data_v,
                                  Image_Description_v,
                                 ref  Atom_Organisation_ID_v,
                                 ref  Atom_OrganisationData_ID_v))
            {
                return true;
            }
            return false;
        }

        public bool Insert_MyOrgData()
        {

            return false;
        }
    }
}
