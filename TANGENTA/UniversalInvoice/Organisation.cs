using LanguageControl;

namespace UniversalInvoice
{
    public class Organisation
    {
        public string Name = null;
        public string Tax_ID = null;
        public string Registration_ID = null;
        public string Atom_Office_Name = null;
        public string BankName = null;
        public string TRR = null;
        public string Email = null;
        public string HomePage = null;
        public string PhoneNumber = null;
        public string FaxNumber = null;
        public byte[] Logo_Data = null;
        public string StreetName = null;
        public string HouseNumber = null;
        public string ZIP = null;
        public string City = null;
        public string State = null;
        public string Country = null;

        public Address Address = null;
        public OrganisationToken token = null;


        public Organisation(ltext token_prefix,
                            string _Name,
                            string _Tax_ID,
                            string _Registration_ID,
                            string _Atom_Office_Name,
                            string _BankName,
                            string _TRR,
                            string _Email,
                            string _HomePage,
                            string _PhoneNumber,
                            string _FaxNumber,
                            byte[] _Logo_Data,
                            string _StreetName,
                            string _HouseNumber,
                            string _ZIP,
                            string _City,
                            string _State,
                            string _Country)
        {

            Name = _Name;
            Tax_ID =                _Tax_ID;
            Registration_ID =       _Registration_ID;
            Atom_Office_Name =      _Atom_Office_Name;
            BankName =              _BankName;
            TRR =                   _TRR;
            Email =                 _Email;
            HomePage =              _HomePage;
            PhoneNumber =           _PhoneNumber;
            FaxNumber =             _FaxNumber;
            Logo_Data =             _Logo_Data;

            ltext token_prefix_Organisation = token_prefix.AddAtTheEnd(lngToken.st_Organisation);
            Address = new Address(token_prefix_Organisation, StreetName,
                                    HouseNumber,
                                    ZIP,
                                    City,
                                    State,
                                    Country);

            token = new OrganisationToken(token_prefix_Organisation,
                                            Name,
                                            Tax_ID,
                                            Registration_ID,
                                            Atom_Office_Name,
                                            BankName,
                                            TRR,
                                            Email,
                                            HomePage,
                                            PhoneNumber,
                                            FaxNumber,
                                            Logo_Data);
        }
    }
}