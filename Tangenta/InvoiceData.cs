using LanguageControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangenta
{
    public class InvoiceData
    {
        public DataTable dt_ProformaInvoice = new DataTable();
        public DataTable dt_Atom_Price_SimpleItem = new DataTable();

        public long ProformaInvoice_ID = -1;
        public long Invoice_ID = -1;

        public int FinancialYear = -1;
        public int NumberInFinancialYear = -1;


        public decimal GrossSum = 0;


        public decimal taxsum = 0;
        public decimal NetSum = 0;

        public UniversalInvoice.Organisation MyOrganisation = null;
        public UniversalInvoice.Organisation CustomerOrganisation = null;
        public UniversalInvoice.Person CustomerPerson = null;

        public InvoiceDB m_InvoiceDB = null;


        public object Customer
        {
            get
            {
                if (CustomerOrganisation != null)
                {
                    return CustomerOrganisation;
                }
                else if (CustomerPerson != null)
                {
                    return CustomerPerson;
                }
                else
                {
                    return null;
                }
            }
        }


        public InvoiceData(InvoiceDB xInvoiceDB, long xProformaInvoice_ID)
        {
            m_InvoiceDB = xInvoiceDB;
            ProformaInvoice_ID = xProformaInvoice_ID;
        }
        public bool Read_ProformaInvoice()
        {
            string sql = @"select
                                 inv.ID as Invoice_ID,
                                 pi.FinancialYear,
                                 pi.NumberInFinancialYear,
                                 mpay.PaymentType,
                                 GrossSum,
                                 TaxSum,
                                 NetSum,
                                 ao.Name,
                                 ao.Tax_ID,
                                 ao.Registration_ID,
                                 Atom_cStreetName_Org.StreetName,
                                 Atom_cHouseNumber_Org.HouseNumber,
                                 Atom_cCity_Org.City,
                                 Atom_cZIP_Org.ZIP,
                                 Atom_cState_Org.State,
                                 Atom_cCountry_Org.Country,
                                 cEmail_Org.Email,
                                 aorgd_hp.HomePage,
                                 cPhoneNumber_Org.PhoneNumber,
                                 cFaxNumber_Org.FaxNumber,
                                 aorgd.BankName,
                                 aorgd.TRR,
                                 aoff.Name as Atom_Office_Name,
                                 amcp.UserName,
                                 amcp.Job,
                                 Atom_Logo.Image_Hash as Logo_Hash,
                                 Atom_Logo.Image_Data as Logo_Data,
                                 Atom_Logo.Description as Logo_Description,
                                 acusorg.ID as Atom_Customer_Org_ID,
                                 acusper.ID as Atom_Customer_Person_ID                                 
                                 from JOURNAL_ProformaInvoice 
                                 inner join JOURNAL_ProformaInvoice_Type on JOURNAL_ProformaInvoice.JOURNAL_ProformaInvoice_Type_ID = JOURNAL_ProformaInvoice_Type.ID and (JOURNAL_ProformaInvoice_Type.ID = " + Program.JOURNAL_ProformaInvoice_Type_definitions.InvoiceDraftTime.ID.ToString() + @")
                                 inner join ProformaInvoice pi on JOURNAL_ProformaInvoice.ProformaInvoice_ID = pi.ID
                                 inner join Atom_WorkPeriod on JOURNAL_ProformaInvoice.Atom_WorkPeriod_ID = Atom_WorkPeriod.ID
                                 inner join Atom_myCompany_Person amcp on Atom_WorkPeriod.Atom_myCompany_Person_ID = amcp.ID
                                 inner join Atom_Person ap on ap.ID = amcp.ID
                                 inner join Atom_Office aoff on amcp.Atom_Office_ID = aoff.ID
                                 inner join Atom_myCompany amc on aoff.Atom_myCompany_ID = amc.ID
                                 inner join Atom_OrganisationData aorgd on  amc.Atom_OrganisationData_ID = aorgd.ID
                                 inner join Atom_Organisation ao on aorgd.Atom_Organisation_ID = ao.ID
                                 left join Invoice inv on pi.Invoice_ID = inv.ID
                                 left join MethodOfPayment mpay on inv.MethodOfPayment_ID = mpay.ID
                                 left join cOrgTYPE aorgd_cOrgTYPE on aorgd.cOrgTYPE_ID = aorgd_cOrgTYPE.ID
                                 left join Atom_cAddress_Org acaorg on aorgd.Atom_cAddress_Org_ID = acaorg.ID
                                 left join Atom_cStreetName_Org on acaorg.Atom_cStreetName_Org_ID = Atom_cStreetName_Org.ID
                                 left join Atom_cHouseNumber_Org on acaorg.Atom_cHouseNumber_Org_ID = Atom_cHouseNumber_Org.ID
                                 left join Atom_cCity_Org on acaorg.Atom_cCity_Org_ID = Atom_cCity_Org.ID
                                 left join Atom_cZIP_Org on acaorg.Atom_cZIP_Org_ID = Atom_cZIP_Org.ID
                                 left join Atom_cState_Org on acaorg.Atom_cState_Org_ID = Atom_cState_Org.ID
                                 left join Atom_cCountry_Org on acaorg.Atom_cCountry_Org_ID = Atom_cCountry_Org.ID
                                 left join cHomePage_Org on aorgd.cHomePage_Org_ID = cHomePage_Org.ID
                                 left join cEmail_Org on aorgd.cEmail_Org_ID = cEmail_Org.ID
                                 left join cHomePage_Org aorgd_hp  on aorgd.cHomePage_Org_ID = cHomePage_Org.ID
                                 left join cFaxNumber_Org on aorgd.cFaxNumber_Org_ID = cFaxNumber_Org.ID
                                 left join cPhoneNumber_Org on aorgd.cPhoneNumber_Org_ID = cPhoneNumber_Org.ID
                                 left join Atom_Logo on aorgd.Atom_Logo_ID = Atom_Logo.ID
                                 left join Atom_Customer_Org acusorg on acusorg.ID = pi.Atom_Customer_Org_ID
                                 left join Atom_Customer_Person acusper on acusper.ID = pi.Atom_Customer_Person_ID
                                 where pi.ID = " + ProformaInvoice_ID.ToString();

            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt_ProformaInvoice, sql, ref Err))
            {
                if (dt_ProformaInvoice.Rows.Count == 1)
                {
                    try
                    {
                        GrossSum = DBTypes.func._set_decimal(dt_ProformaInvoice.Rows[0]["GrossSum"]);
                        taxsum = DBTypes.func._set_decimal(dt_ProformaInvoice.Rows[0]["TaxSum"]);
                        NetSum = DBTypes.func._set_decimal(dt_ProformaInvoice.Rows[0]["NetSum"]);
                        ltext ltMy = new ltext("My", "Moja");
                        MyOrganisation = new UniversalInvoice.Organisation(ltMy, DBTypes.func._set_string(dt_ProformaInvoice.Rows[0]["Name"]),
                                                                   DBTypes.func._set_string(dt_ProformaInvoice.Rows[0]["Tax_ID"]),
                                                                   DBTypes.func._set_string(dt_ProformaInvoice.Rows[0]["Registration_ID"]),
                                                                   DBTypes.func._set_string(dt_ProformaInvoice.Rows[0]["Atom_Office_Name"]),
                                                                   DBTypes.func._set_string(dt_ProformaInvoice.Rows[0]["BankName"]),
                                                                   DBTypes.func._set_string(dt_ProformaInvoice.Rows[0]["TRR"]),
                                                                   DBTypes.func._set_string(dt_ProformaInvoice.Rows[0]["Email"]),
                                                                   DBTypes.func._set_string(dt_ProformaInvoice.Rows[0]["HomePage"]),
                                                                   DBTypes.func._set_string(dt_ProformaInvoice.Rows[0]["PhoneNumber"]),
                                                                   DBTypes.func._set_string(dt_ProformaInvoice.Rows[0]["FaxNumber"]),
                                                                   DBTypes.func._set_byte_array(dt_ProformaInvoice.Rows[0]["Logo_Data"]),
                                                                   DBTypes.func._set_string(dt_ProformaInvoice.Rows[0]["StreetName"]),
                                                                   DBTypes.func._set_string(dt_ProformaInvoice.Rows[0]["HouseNumber"]),
                                                                   DBTypes.func._set_string(dt_ProformaInvoice.Rows[0]["ZIP"]),
                                                                   DBTypes.func._set_string(dt_ProformaInvoice.Rows[0]["City"]),
                                                                   DBTypes.func._set_string(dt_ProformaInvoice.Rows[0]["State"]),
                                                                   DBTypes.func._set_string(dt_ProformaInvoice.Rows[0]["Country"]));


                        Invoice_ID = DBTypes.func._set_long(dt_ProformaInvoice.Rows[0]["Invoice_ID"]);
                        FinancialYear = DBTypes.func._set_int(dt_ProformaInvoice.Rows[0]["FinancialYear"]);
                        NumberInFinancialYear = DBTypes.func._set_int(dt_ProformaInvoice.Rows[0]["NumberInFinancialYear"]);

                        object oAtom_Customer_Org_ID = dt_ProformaInvoice.Rows[0]["Atom_Customer_Org_ID"];
                        ltext lt_Customer = new ltext("Customer", "Stranka");
                        if (oAtom_Customer_Org_ID is long)
                        {
                            long Atom_Customer_Org_ID = (long)oAtom_Customer_Org_ID;
                            CustomerOrganisation = f_Atom_OrganisationData.GetData(lt_Customer, Atom_Customer_Org_ID);
                        }
                        else if (dt_ProformaInvoice.Rows[0]["Atom_Customer_Person_ID"] is long)
                        {
                            long Atom_Customer_Person_ID = (long)dt_ProformaInvoice.Rows[0]["Atom_Customer_Person_ID"];
                            CustomerPerson = f_Atom_Person.GetData(lt_Customer, Atom_Customer_Person_ID);
                        }


                        if (m_InvoiceDB.Read_Atom_Price_SimpleItem_Table(ProformaInvoice_ID, ref dt_Atom_Price_SimpleItem))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                    catch (Exception ex)
                    {
                        LogFile.Error.Show("ERROR:usrc_Invoice_Preview:Read_ProformaInvoice:Exception=" + ex.Message);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Invoice_Preview:Read_ProformaInvoice:dt_ProformaInvoice.Rows.Count != 1! for ProformaInvoice_ID=" + ProformaInvoice_ID.ToString() + "!\r\nsql = " + sql);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Invoice_Preview:Read_ProformaInvoice:Err=" + Err);
                return false;
            }
        }

        public string GetAllTokens()
        {
            string s = "";

            ltext ltMy = new ltext("My", "Moja");
            UniversalInvoice.Organisation xMyOrganisation = new UniversalInvoice.Organisation(ltMy, 
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null);


            foreach (UniversalInvoice.TemplateToken tt in xMyOrganisation.token.list)
            {
                s += "\r\n" + tt.lt.s;
            }

            foreach (UniversalInvoice.TemplateToken tt in xMyOrganisation.Address.token.list)
            {
                s += "\r\n" + tt.lt.s;
            }

            ltext ltCustomer = new ltext("Customer", "Stranka");
            UniversalInvoice.Organisation xCustomerOrganisation = new UniversalInvoice.Organisation(ltCustomer, 
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null);

            foreach (UniversalInvoice.TemplateToken tt in xCustomerOrganisation.token.list)
            {
                s += "\r\n" + tt.lt.s;
            }
            foreach (UniversalInvoice.TemplateToken tt in xCustomerOrganisation.Address.token.list)
            {
                s += "\r\n" + tt.lt.s;
            }

            UniversalInvoice.Person xCustomerPerson = new UniversalInvoice.Person(ltCustomer,false,
                                                       null,
                                                       null,
                                                       DateTime.MinValue,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null);
            foreach (UniversalInvoice.TemplateToken tt in xCustomerPerson.token.list)
            {
                s += "\r\n" + tt.lt.s;
            }
            foreach (UniversalInvoice.TemplateToken tt in xCustomerPerson.Address.token.list)
            {
                s += "\r\n" + tt.lt.s;
            }
            return s;
        }

    }
}
