using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBTypes;

namespace TangentaTableClass
{
    public class Width : DB_decimal2
    {
    }

    public class Height : DB_decimal2
    {
    }


    public class Gender : DB_bit
    {
    }
    public class Storno : DB_bit
    {
    }
    public class Paid : DB_bit
    {
    }
    public class FirstName : DB_varchar_264
    {
    }

    public class LastName : DB_varchar_264
    {
    }

    public class PersonalLicenceNum : DB_Int32
    {
    }

    public class MAC_address : DB_varchar_32
    {
    }
    
    public class IP_address : DB_varchar_32
    {
    }
    
    public class ExpectedShelfLifeInDays: DB_Int32
    {
    }

    public class SaleBeforeExpiryDateInDays : DB_Int32
    {
    }


    public class DiscardBeforeExpiryDateInDays : DB_Int32
    {
    }

    public class DateOfBirth : DB_DateTime
    {
    }

    public class SOrganisation :DB_varchar_2000
    {
    }

    public class Symbol : DB_varchar_5
    {
    }

    public class RateToCurrency1 : DB_Money
    {
    }


    public class Address : DB_varchar_264
    {
    }

    public class StreetName : DB_varchar_264
    {
    }


    public class HouseNumber : DB_varchar_32
    {
    }


    public class PhoneNumber : DB_varchar_50
    {
    }

    public class GsmNumber : DB_varchar_50
    {
    }

    public class FaxNumber : DB_varchar_50
    {
    }

    public class Email : DB_varchar_264
    {
    }

    public class HomePage : DB_varchar_264
    {
    }
    

    public class OrganisationTYPE : DB_varchar_32
    {
    }

    public class OrgName : DB_varchar_264
    {
    }

    public class WarrantyExist : DB_bit
    {
    }



    public class LocationTYPE : DB_varchar_264
    {
    }



    public class Organisation_id:DB_Int64
    {
    }

    public class Tax_ID: DB_varchar_32
    {
    }

    public class TRR:DB_varchar_264
    {

    }

    public class Registration_ID:DB_varchar_50
    {
    }

    public class BankName:DB_varchar_264
    {

    }

    public class UniqueName : DB_varchar_264
    {
    }

    public class Community:DB_varchar_250
    {

    }

    public class CadastralNumber:DB_Int32
    {

    }

    public class BuildingNumber : DB_Int32
    {

    }

    public class BuildingSectionNumber:DB_Int32
    {

    }

    public class PremiseType:DB_varchar_5
    {

    }

    public class ValidityDate:DB_DateTime
    {

    }

    public class PurchasePriceDate : DB_DateTime
    {

    }

    public class ClosingTag : DB_varchar_5
    {

    }

    public class SoftwareSupplier_TaxNumber: DB_varchar_10
    {

    }

    public class SpecialNotes:DB_varchar_2000
    {

    }

    public class Name:DB_varchar_264
    {
    }

    public class TextValue : DB_varchar_2000
    {
    }

    public class iQuantity:DB_Int32
    {
    }

    public class dQuantity : DB_decimal2
    {
    }

    public class PurchasePricePerUnit:DB_Money
    {
    }

    public class Customs : DB_Money
    {
    }

    public class StockTakePriceTotal : DB_Money
    {
    }

    public class ImportTime:DB_DateTime
    {
    }

    public class Rate:DB_Percent
    {
    }

    public class TaxSum:DB_Money
    {
    }

    public class GrossSum:DB_Money
    {
    }

    public class RetailPricePerUnit:DB_Money
    {
        
    }

     public class RetailPricePerUnitWithDiscount:DB_Money
    {
        
    }


    public class ExpiryDate:DB_DateTime
    {
    }

    public class DocInvoiceTime:DB_DateTime
    {
    }

    public class InvoiceTime : DB_DateTime
    {
    }

    public class FirstPrintTime : DB_DateTime
    {
    }

    public class NetSum:DB_Money
    {
    }


    public class EndSum:DB_Money
    {
    }
        
    public class PaymentType:DB_varchar_264
    {
    }


    public class TaxPrice:DB_Money
    {
    }


    public class Discount:DB_Percent
    {
    }

    public class ExtraDiscount : DB_Percent
    {
    }

    public class RetailPriceWithDiscount:DB_Money
    {

    }

    public class Abbreviation:DB_varchar_50
    {
    }

    public class CardNumber : DB_varchar_50
    {
    }
    public class CardType : DB_varchar_50
    {
    }

    public class MinimumSimpleItemPrice:DB_Money
    {
    }

    public class RetailSimpleItemPrice:DB_Money
    {
    }

    public class RetailSimpleItemPriceWithDiscount : DB_Money
    {
    }

    public class ZIP : DB_varchar_32
    {

    }
    public class City : DB_varchar_264
    {
    }

    public class Country: DB_varchar_264
    {
    }

    public class State : DB_varchar_264
    {
    }

    public class ContactPerson:DB_varchar_264
    {
    }

    public class ContactPhone:DB_varchar_264
    {
    }

    public class ContactEmail:DB_varchar_264
    {
    }

    public class RecievedInvoiceNumber:DB_varchar_50
    {
    }

    public class Code:DB_Int64
    {
    }

    public class barcode : DB_varchar_32
    {
    }

    public class ReferenceNote : DB_varchar_264
    {
    }

    public class EventTime:DB_DateTime
    {

    }

    public class DeliveryTime:DB_DateTime
    {

    }

    public class xDocument : DB_Document
    {

    }

    public class Country_ISO_3166_a2:DB_varchar_5
    {

    }

    public class Country_ISO_3166_a3 : DB_varchar_5
    {

    }

    public class Country_ISO_3166_num : DB_smallInt
    {

    }

    public class cFirstName
    {
        public ID ID = new ID();
        public FirstName FirstName = new FirstName();
    }


    public class cLastName
    {
        public ID ID = new ID();
        public LastName LastName = new LastName();
    }


    public class cCardType_Person
    {
        public ID ID = new ID();
        public CardType CardType = new CardType();
    }

    public class cPhoneNumber_Person
    {
        public ID ID = new ID();
        public PhoneNumber PhoneNumber = new PhoneNumber();
    }

    public class cGsmNumber_Person
    {
        public ID ID = new ID();
        public GsmNumber GsmNumber = new GsmNumber();
    }

    public class cEmail_Person
    {
        public ID ID = new ID();
        public Email Email = new Email();
    }



    public class Atom_cFirstName
    {
        public ID ID = new ID();
        public FirstName FirstName = new FirstName();
    }


    public class Atom_cLastName
    {
        public ID ID = new ID();
        public LastName LastName = new LastName();
    }


    public class Atom_cCardType_Person
    {
        public ID ID = new ID();
        public CardType CardType = new CardType();
    }

    public class Atom_cPhoneNumber_Person
    {
        public ID ID = new ID();
        public PhoneNumber PhoneNumber = new PhoneNumber();
    }

    public class Atom_cGsmNumber_Person
    {
        public ID ID = new ID();
        public GsmNumber GsmNumber = new GsmNumber();
    }

    public class Atom_cEmail_Person
    {
        public ID ID = new ID();
        public Email Email = new Email();
    }


    public class cStreetName_Person
    {
        public ID ID = new ID();
        public StreetName StreetName = new StreetName();
    }

    public class cHouseNumber_Person
    {
        public ID ID = new ID();
        public HouseNumber HouseNumber = new HouseNumber();
    }

    public class cCity_Person
    {
        public ID ID = new ID();
        public City City = new City();
    }

    public class cZIP_Person
    {
        public ID ID = new ID();
        public ZIP ZIP = new ZIP();
    }

    public class cCountry_Person
    {
        public ID ID = new ID();
        public Country Country= new Country();
        public Country_ISO_3166_a2 Country_ISO_3166_a2 = new Country_ISO_3166_a2();
        public Country_ISO_3166_a3 Country_ISO_3166_a3 = new Country_ISO_3166_a3();
        public Country_ISO_3166_num Country_ISO_3166_num = new Country_ISO_3166_num();
    }

    public class cState_Person
    {
        public ID ID = new ID();
        public State State = new State();
    }

    public class Atom_cStreetName_Person
    {
        public ID ID = new ID();
        public StreetName StreetName = new StreetName();
    }

    public class Atom_cHouseNumber_Person
    {
        public ID ID = new ID();
        public HouseNumber HouseNumber = new HouseNumber();
    }
    
    public class Atom_cCity_Person
    {
        public ID ID = new ID();
        public City City = new City();
    }

    public class Atom_cZIP_Person
    {
        public ID ID = new ID();
        public ZIP ZIP = new ZIP();
    }


    public class Atom_cCountry_Person
    {
        public ID ID = new ID();
        public Country Country= new Country();
        public Country_ISO_3166_a2 Country_ISO_3166_a2 = new Country_ISO_3166_a2();
        public Country_ISO_3166_a3 Country_ISO_3166_a3 = new Country_ISO_3166_a3();
        public Country_ISO_3166_num Country_ISO_3166_num = new Country_ISO_3166_num();
    }

    public class Atom_cState_Person
    {
        public ID ID = new ID();
        public State State = new State();
    }

    public class cAddress_Person
    {
        public ID ID = new ID();
        public cStreetName_Person m_cStreetName_Person = new cStreetName_Person();
        public cHouseNumber_Person m_cHouseNumber_Person = new cHouseNumber_Person();
        public cCity_Person m_cCity_Person = new cCity_Person();
        public cZIP_Person m_cZIP_Person = new cZIP_Person();
        public cCountry_Person m_cCountry_Person = new cCountry_Person();
        public cState_Person m_cState_Person = new cState_Person();

    }

    public class Bank
    {
        public ID ID = new ID();
        public Organisation m_Organisation = new Organisation();
    }

    public class BankAccount
    {
        public ID ID = new ID();
        public Bank m_Bank = new Bank();
        public TRR TRR = new TRR();
        public Active Active = new Active();
        public Description Description = new Description();
    }

    public class Person
    {
        public ID ID = new ID();
        public Gender Gender = new Gender();
        public cFirstName m_cFirstName = new cFirstName();
        public cLastName m_cLastName = new cLastName();
        public Tax_ID Tax_ID = new Tax_ID();
        public Registration_ID Registration_ID = new Registration_ID();
        public DateOfBirth DateOfBirth = new DateOfBirth();
    }

    public class PersonAccount
    {
        public ID ID = new ID();
        public Person m_Person = new Person();
        public BankAccount m_BankAccount = new BankAccount();
        public Description Description = new Description();
    }

    public class OrganisationAccount
    {
        public ID ID = new ID();
        public Organisation m_Organisation = new Organisation();
        public BankAccount m_BankAccount = new BankAccount();
        public Description Description = new Description();
    }

    public class PersonData
    {
        public ID ID = new ID();
        public Person m_Person = new Person();
        public cAddress_Person m_cAddress_Person = new cAddress_Person();
        public cPhoneNumber_Person m_cPhoneNumber_Person = new cPhoneNumber_Person();
        public cGsmNumber_Person m_cGsmNumber_Person = new cGsmNumber_Person();
        public cEmail_Person m_cEmail_Person = new cEmail_Person();
        public CardNumber CardNumber = new CardNumber();
        public cCardType_Person m_cCardType_Person = new cCardType_Person();
        public Description Description = new Description();
        public PersonImage m_PersonImage = new PersonImage();
    }


    public class Atom_cAddress_Person
    {
        public ID ID = new ID();
        public Atom_cStreetName_Person m_Atom_cStreetName_Person = new Atom_cStreetName_Person();
        public Atom_cHouseNumber_Person m_Atom_cHouseNumber_Person = new Atom_cHouseNumber_Person();
        public Atom_cCity_Person m_Atom_cCity_Person = new Atom_cCity_Person();
        public Atom_cZIP_Person m_Atom_cZIP_Person = new Atom_cZIP_Person();
        public Atom_cCountry_Person m_Atom_cCountry_Person = new Atom_cCountry_Person();
        public Atom_cState_Person m_Atom_cState_Person = new Atom_cState_Person();
    }

    public class Atom_Person
    {
        public ID ID = new ID();
        public Gender Gender = new Gender();
        public Atom_cFirstName m_Atom_cFirstName = new Atom_cFirstName();
        public Atom_cLastName m_Atom_cLastName = new Atom_cLastName();
        public Atom_cAddress_Person m_Atom_cAddress_Person = new Atom_cAddress_Person();
        public Atom_cPhoneNumber_Person m_Atom_cPhoneNumber_Person = new Atom_cPhoneNumber_Person();
        public Atom_cGsmNumber_Person m_Atom_cGsmNumber_Person = new Atom_cGsmNumber_Person();
        public Atom_cEmail_Person m_Atom_cEmail_Person = new Atom_cEmail_Person();
        public DateOfBirth DateOfBirth = new DateOfBirth();
        public Tax_ID Tax_ID = new Tax_ID();
        public Registration_ID Registration_ID = new Registration_ID();
        public CardNumber CardNumber = new CardNumber();
        public Atom_cCardType_Person m_Atom_cCardType_Person = new Atom_cCardType_Person();
        public Atom_PersonImage m_Atom_PersonImage = new Atom_PersonImage();
        public Description Description = new Description();
    }



    public class cOrgTYPE
    {
        public ID ID = new ID();
        public OrganisationTYPE OrganisationTYPE = new OrganisationTYPE();
    }


    public class cStreetName_Org
    {
        public ID ID = new ID();
        public StreetName StreetName = new StreetName();
    }

    public class cHouseNumber_Org
    {
        public ID ID = new ID();
        public HouseNumber HouseNumber = new HouseNumber();
    }


    public class cCity_Org
    {
        public ID ID = new ID();
        public City City = new City();
    }

    public class cZIP_Org
    {
        public ID ID = new ID();
        public ZIP ZIP = new ZIP();
    }

    public class cCountry_Org
    {
        public ID ID = new ID();
        public Country Country= new Country();
        public Country_ISO_3166_a2 Country_ISO_3166_a2 = new Country_ISO_3166_a2();
        public Country_ISO_3166_a3 Country_ISO_3166_a3 = new Country_ISO_3166_a3();
        public Country_ISO_3166_num Country_ISO_3166_num = new Country_ISO_3166_num();
    }

    public class cState_Org
    {
        public ID ID = new ID();
        public State State = new State();
    }


    public class Atom_cStreetName_Org
    {
        public ID ID = new ID();
        public StreetName StreetName = new StreetName();
    }

    public class Atom_cHouseNumber_Org
    {
        public ID ID = new ID();
        public HouseNumber HouseNumber = new HouseNumber();
    }

    public class Atom_cCity_Org
    {
        public ID ID = new ID();
        public City City = new City();
    }

    public class Atom_cZIP_Org
    {
        public ID ID = new ID();
        public ZIP ZIP = new ZIP();
    }

    public class Atom_cCountry_Org
    {
        public ID ID = new ID();
        public Country Country= new Country();
        public Country_ISO_3166_a2 Country_ISO_3166_a2 = new Country_ISO_3166_a2();
        public Country_ISO_3166_a3 Country_ISO_3166_a3 = new Country_ISO_3166_a3();
        public Country_ISO_3166_num Country_ISO_3166_num = new Country_ISO_3166_num();
    }

    public class Atom_cState_Org
    {
        public ID ID = new ID();
        public State State = new State();
    }


    public class cPhoneNumber_Org
    {
        public ID ID = new ID();
        public PhoneNumber PhoneNumber = new PhoneNumber();
    }

    public class cFaxNumber_Org
    {
        public ID ID = new ID();
        public FaxNumber FaxNumber = new FaxNumber();
    }

    public class cEmail_Org
    {
        public ID ID = new ID();
        public Email Email = new Email();
    }

    public class cHomePage_Org
    {
        public ID ID = new ID();
        public HomePage HomePage = new HomePage();
    }

    public class Description : DB_varchar_2000
    {
    }

    public class NoticeText : DB_varchar_max
    {
    }

    public class ExpiryDescription: DB_varchar_2000
    {
    }





    public class ReadOnly: DB_bit
    {
    }
    public class ToOffer : DB_bit
    {
    }

    public class WarrantyDurationType: DB_smallInt
    {
    }
    public class WarrantyDuration : DB_Int32
    {
    }
    public class WarrantyConditions : DB_varchar_2000
    {
    }

    public class DocDuration:DB_Int64
    {
    }

    public class DocDurationType: DB_smallInt
    {
    }

    public class Job:DB_varchar_264
    {
    }

    public class UserName:DB_varchar_32
    {
    }

    public class Password:DB_varchar_32
    {
    }

    public class Active:DB_bit
    {
    }

    public class bDefault : DB_bit
    {
    }

    public class Compressed : DB_bit
    {
    }

    public class  LoginTime:DB_DateTime
    {

    }

    public class  LogoutTime:DB_DateTime
    {

    }

    public class DocInvoice_Top_Description:DB_varchar_max
    {
    }

    public class DocInvoice_Bottom_description:DB_varchar_max
    {
    }


    public class PaymentDeadline:DB_DateTime
    {
    }

    public class ProFormaImage:DB_Image
    {
    }

    public class Image_Hash : DB_varchar_32
    {

    }

    public class xDocument_Hash : DB_varchar_32
    {

    }


    public class Draft : DB_bit
    {
    }
    public class DraftNumber : DB_Int32
    {
    }

    public class FinancialYear:DB_Int32
    {
    }

    public class NumberInFinancialYear:DB_Int32
    {
    }

    public class StorageOption : DB_bit
    {
    }

    public class PersonImage
    {
        public ID ID = new ID();
        public Image_Hash Image_Hash = new Image_Hash();
        public Image_Data Image_Data = new Image_Data();
    }

    public class Atom_PersonImage
    {
        public ID ID = new ID();
        public Image_Hash Image_Hash = new Image_Hash();
        public Image_Data Image_Data = new Image_Data();
    }

    public class Organisation
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Tax_ID Tax_ID = new Tax_ID();
        public Registration_ID Registration_ID = new Registration_ID();
    }

    public class OrganisationData
    {
        public ID ID = new ID();
        public Organisation m_Organisation = new Organisation();
        public cAddress_Org m_cAddress_Org = new cAddress_Org();
        public cPhoneNumber_Org m_cPhoneNumber_Org = new cPhoneNumber_Org();
        public cFaxNumber_Org m_cFaxNumber_Org = new cFaxNumber_Org();
        public cEmail_Org m_cEmail_Org = new cEmail_Org();
        public cHomePage_Org m_cHomePage_Org = new cHomePage_Org();
        public cOrgTYPE m_cOrgTYPE = new cOrgTYPE();
        public Logo m_Logo = new Logo();
    }

    public class Logo
    {
        public ID ID = new ID();
        public Image_Hash Image_Hash = new Image_Hash();
        public Image_Data Image_Data = new Image_Data();
        public Description Description = new Description();
    }

    public class Atom_Organisation
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Tax_ID Tax_ID = new Tax_ID();
        public Registration_ID Registration_ID = new Registration_ID();
    }

    public class Atom_OrganisationData
    {
        public ID ID = new ID();
        public Atom_Organisation m_Atom_Organisation = new Atom_Organisation();
        public Atom_cAddress_Org m_Atom_cAddress_Org = new Atom_cAddress_Org();
        public cPhoneNumber_Org m_cPhoneNumber_Org = new cPhoneNumber_Org();
        public cFaxNumber_Org m_cFaxNumber_Org = new cFaxNumber_Org();
        public cEmail_Org m_cEmail_Org = new cEmail_Org();
        public cHomePage_Org m_cHomePage_Org = new cHomePage_Org();
        public cOrgTYPE m_cOrgTYPE = new cOrgTYPE();
        public BankName BankName = new BankName();
        public TRR TRR = new TRR();
        public Atom_Logo m_Atom_Logo = new Atom_Logo();
    }

    public class Atom_Bank
    {
        public ID ID = new ID();
        public Atom_Organisation m_Atom_Organisation = new Atom_Organisation();
    }
    public class Atom_BankAccount
    {
        public ID ID = new ID();
        public Atom_Bank m_Atom_Bank = new Atom_Bank();
        public TRR TRR = new TRR();
        public Active Active = new Active();
        public Description Description = new Description();
    }

    public class Atom_OrganisationAccount
    {
        public ID ID = new ID();
        public Atom_Organisation m_Atom_Organisation = new Atom_Organisation();
        public Atom_BankAccount m_Atom_BankAccount = new Atom_BankAccount();
        public Description Description = new Description();
    }

    public class Atom_PersonData
    {
        public ID ID = new ID();
        public Atom_Person m_Atom_Person = new Atom_Person();
        public Atom_cAddress_Person m_Atom_cAddress_Person = new Atom_cAddress_Person();
        public Atom_cPhoneNumber_Person m_Atom_cPhoneNumber_Person = new Atom_cPhoneNumber_Person();
        public Atom_cGsmNumber_Person m_Atom_cGsmNumber_Person = new Atom_cGsmNumber_Person();
        public Atom_cEmail_Person m_Atom_cEmail_Person = new Atom_cEmail_Person();
        public CardNumber CardNumber = new CardNumber();
        public Atom_cCardType_Person m_Atom_cCardType_Person = new Atom_cCardType_Person();
        public Description Description = new Description();
        public Atom_PersonImage m_Atom_PersonImage = new Atom_PersonImage();
    }

    public class Atom_PersonAccount
    {
        public ID ID = new ID();
        public Atom_Person m_Atom_Person = new Atom_Person();
        public Atom_BankAccount m_Atom_BankAccount = new Atom_BankAccount();
        public Description Description = new Description();
    }

    public class Atom_Logo
    {
        public ID ID = new ID();
        public Image_Hash Image_Hash = new Image_Hash();
        public Image_Data Image_Data = new Image_Data();
        public Description Description = new Description();
    }


    public class Contact
    {
        public ID ID = new ID();
        public OrganisationData m_OrganisationData = new OrganisationData();
        public Person m_Person = new Person();
    }

    public class myOrganisation
    {
        public ID ID = new ID();
//        public Organisation m_Organisation = new Organisation();
        public OrganisationData m_OrganisationData = new OrganisationData();
    }



    public class cAddress_Org
    {
        public ID ID = new ID();
        public cStreetName_Org m_cStreetName_Org = new cStreetName_Org();
        public cHouseNumber_Org m_cHouseNumber_Org = new cHouseNumber_Org();
        public cCity_Org m_cCity_Org = new cCity_Org();
        public cCountry_Org m_cCountry_Org = new cCountry_Org();
        public cState_Org m_cState_Org = new cState_Org();
        public cZIP_Org m_cZIP_Org = new cZIP_Org();
    }

    public class Atom_cAddress_Org
    {
        public ID ID = new ID();
        public Atom_cStreetName_Org m_Atom_cStreetName_Org = new Atom_cStreetName_Org();
        public Atom_cHouseNumber_Org m_Atom_cHouseNumber_Org = new Atom_cHouseNumber_Org();
        public Atom_cCity_Org m_Atom_cCity_Org = new Atom_cCity_Org();
        public Atom_cZIP_Org m_Atom_cZIP_Org = new Atom_cZIP_Org();
        public Atom_cCountry_Org m_Atom_cCountry_Org = new Atom_cCountry_Org();
        public Atom_cState_Org m_Atom_cState_Org = new Atom_cState_Org();
    }


    public class AccessR
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
    }

    public class myOrganisation_Person_AccessR
    {
        public ID ID = new ID();
        public myOrganisation_Person m_myOrganisation_Person = new myOrganisation_Person();
        public AccessR m_AccessR = new AccessR();
    }

    public class JOURNAL_myOrganisation_Person_AccessR_TYPE
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
    }

    public class JOURNAL_myOrganisation_Person_AccessR
    {
        public ID ID = new ID();
        public myOrganisation_Person_AccessR m_myOrganisation_Person_AccessR = new myOrganisation_Person_AccessR();
        public JOURNAL_myOrganisation_Person_AccessR_TYPE m_JOURNAL_myOrganisation_Person_AccessR_TYPE = new JOURNAL_myOrganisation_Person_AccessR_TYPE();
        public EventTime EventTime = new EventTime();
        public Atom_WorkPeriod m_Atom_WorkPeriod = new Atom_WorkPeriod();
    }


    public class ShortName:DB_varchar_10
    {

    }
    public class Office
    {
        public ID ID = new ID();
        public myOrganisation m_myOrganisation = new myOrganisation();
        public Name Name = new Name();
        public ShortName ShortName = new ShortName();
    }

    public class Office_Data
    {
        public ID ID = new ID();
        public Office m_Office = new Office();
        public cAddress_Org m_cAddress_Org = new cAddress_Org();
        public Description Description = new Description();
    }


    public class myOrganisation_Person
    {
        public ID ID = new ID();
        public Office m_Office = new Office();
        public Person m_Person = new Person();
        public Active Active = new Active();
        public UserName UserName = new UserName();
        public Password Password = new Password();
        public Job Job = new Job();
        public Description Description = new Description();
    }

    public class JOURNAL_myOrganisation_Person_TYPE
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
    }

    public class JOURNAL_myOrganisation_Person
    {
        public ID ID = new ID();
        public myOrganisation_Person m_myOrganisation_Person = new myOrganisation_Person();
        public JOURNAL_myOrganisation_Person_TYPE m_JOURNAL_myOrganisation_Person_TYPE = new JOURNAL_myOrganisation_Person_TYPE();
        public EventTime EventTime = new EventTime();
        public Atom_WorkPeriod m_Atom_WorkPeriod = new Atom_WorkPeriod();
    }

    public class Atom_Computer
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public UserName UserName = new UserName();
        public MAC_address MAC_address = new MAC_address();
        public IP_address IP_address = new IP_address();
        public Description Description = new Description();
    }

    public class Atom_ElectronicDevice
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
    }


    public class WorkingPlace
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
    }


    public class Atom_myOrganisation
    {
        public ID ID = new ID();
        public Atom_OrganisationData m_Atom_OrganisationData = new Atom_OrganisationData();
    }


    public class Atom_Office
    {
        public ID ID = new ID();
        public Atom_myOrganisation m_Atom_myOrganisation = new Atom_myOrganisation();
        public Name Name = new Name();
        public ShortName ShortName = new ShortName();
    }

    public class Atom_Office_Data
    {
        public ID ID = new ID();
        public Atom_Office m_Atom_Office = new Atom_Office();
        public Atom_cAddress_Org m_Atom_cAddress_Org = new Atom_cAddress_Org();
        public Description Description = new Description();
    }

    public class Atom_myOrganisation_Person
    {
        public ID ID = new ID();
        public Atom_Office m_Atom_Office = new Atom_Office();
        public Atom_Person m_Atom_Person = new Atom_Person();
        public UserName UserName = new UserName();
        public Job Job = new Job();
        public Description Description = new Description();
    }


    public class Atom_WorkingPlace
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
    }

    public class Atom_WorkPeriod_TYPE
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
    }

    public class Atom_WorkPeriod_Description
    {
        public ID ID = new ID();
        public Atom_WorkPeriod m_Atom_WorkPeriod = new Atom_WorkPeriod();
        public Description Description = new Description();
    }


    public class Atom_WorkPeriod
    {
        public ID ID = new ID();
        public Atom_myOrganisation_Person m_Atom_myOrganisation_Person = new Atom_myOrganisation_Person();
        public Atom_WorkingPlace m_Atom_WorkingPlace  = new Atom_WorkingPlace();
        public Atom_Computer m_Atom_Computer = new Atom_Computer();
        public Atom_ElectronicDevice m_Atom_ElectronicDevice = new Atom_ElectronicDevice();
        public LoginTime LoginTime = new LoginTime();
        public LogoutTime LogoutTime = new LogoutTime();
        public Atom_WorkPeriod_TYPE m_Atom_WorkPeriod_TYPE = new Atom_WorkPeriod_TYPE();
    }

    public class Expiry
    {
        public ID ID = new ID();
        public ExpectedShelfLifeInDays ExpectedShelfLifeInDays = new ExpectedShelfLifeInDays();
        public SaleBeforeExpiryDateInDays SaleBeforeExpiryDateInDays = new SaleBeforeExpiryDateInDays();
        public DiscardBeforeExpiryDateInDays DiscardBeforeExpiryDateInDays = new DiscardBeforeExpiryDateInDays();
        public ExpiryDescription ExpiryDescription = new ExpiryDescription();
    }

    public class Atom_Expiry
    {
        public ID ID = new ID();
        public ExpectedShelfLifeInDays ExpectedShelfLifeInDays = new ExpectedShelfLifeInDays();
        public SaleBeforeExpiryDateInDays SaleBeforeExpiryDateInDays = new SaleBeforeExpiryDateInDays();
        public DiscardBeforeExpiryDateInDays DiscardBeforeExpiryDateInDays = new DiscardBeforeExpiryDateInDays();
        public ExpiryDescription ExpiryDescription = new ExpiryDescription();
    }


    public class Warranty
    {
        public ID ID = new ID();
        public WarrantyDurationType WarrantyDurationType = new WarrantyDurationType();
        public WarrantyDuration WarrantyDuration = new WarrantyDuration();
        public WarrantyConditions WarrantyConditions = new WarrantyConditions();

    }

    public class Atom_Warranty
    {
        public ID ID = new ID();
        public WarrantyDurationType WarrantyDurationType = new WarrantyDurationType();
        public WarrantyDuration WarrantyDuration = new WarrantyDuration();
        public WarrantyConditions WarrantyConditions = new WarrantyConditions();
    }

    public class Item_ParentGroup3
    {
        public ID ID = new ID();
        public Name Name = new Name();
    }

    public class Item_ParentGroup2
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Item_ParentGroup3 m_Item_ParentGroup3 = new Item_ParentGroup3();
    }

    public class Item_ParentGroup1
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Item_ParentGroup2 m_Item_ParentGroup2 = new Item_ParentGroup2();
    }

    public class EndPriceWithDiscountAndTax : DB_Money
    {

    }

    public class TAX : DB_Money
    {

    }

    public class PricePerUnit:DB_Money
    {

    }

    public class ShopAUnit:DB_varchar_32
    {
        
    }


    public class Unit
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Symbol Symbol = new Symbol();
        public DecimalPlaces DecimalPlaces = new DecimalPlaces();
        public StorageOption StorageOption = new StorageOption();
        public Description Description = new Description();
    }

    public class Atom_Unit
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Symbol Symbol = new Symbol();
        public DecimalPlaces DecimalPlaces = new DecimalPlaces();
        public StorageOption StorageOption = new StorageOption();
        public Description Description = new Description();
    }

    public class Item
    {
            public ID ID = new ID();
            public Code Code  = new Code();
            public UniqueName UniqueName = new UniqueName();
            public Name Name = new Name();
            public Item_ParentGroup1 m_Item_ParentGroup1 = new Item_ParentGroup1();
            public barcode barcode = new barcode();
            public Description Description = new Description();
            public Expiry m_Expiry = new Expiry();
            public Warranty m_Warranty = new Warranty();
            public ToOffer ToOffer = new ToOffer();
            public Item_Image m_Item_Image = new Item_Image();
            public Unit m_Unit = new Unit();
    }

    public class Atom_Item_ImageLib
    {
         public ID ID = new ID();
         public Image_Hash Image_Hash = new Image_Hash();
         public Image_Data Image_Data = new Image_Data();
         public Description Description = new Description();
    }

    public class Atom_Item_Name
    {
         public ID ID = new ID();
         public Name Name = new Name();
    }

    public class Atom_Item_barcode
    {
         public ID ID = new ID();
         public barcode barcode = new barcode();
    }

    public class Taxation
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Rate Rate = new Rate();
    }

    public class Atom_Item_Description
    {
         public ID ID = new ID();
         public Description Description = new Description();
    }

    public class Atom_Currency
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Abbreviation Abbreviation = new Abbreviation();
        public Symbol Symbol = new Symbol();
        public CurrencyCode CurrencyCode = new CurrencyCode();
        public DecimalPlaces DecimalPlaces = new DecimalPlaces();
    }


    public class Atom_PriceList
    {
        public ID ID = new ID();
        public Atom_Currency m_Atom_Currency = new Atom_Currency();
        public Name Name = new Name();
        public Valid Valid = new Valid();
        public ValidFrom ValidFrom = new ValidFrom();
        public ValidTo ValidTo = new ValidTo();
        public Description Description = new Description();
        public CreationDate CreationDate = new CreationDate();
    }

    public class Atom_Price_Item
    {
        public ID ID = new ID();
        public Atom_PriceList m_Atom_PriceList = new Atom_PriceList();
        public Atom_Item m_Atom_Item = new Atom_Item();
        public RetailPricePerUnit RetailPricePerUnit = new RetailPricePerUnit();
        public Discount Discount = new Discount();
        public Atom_Taxation m_Atom_Taxation = new Atom_Taxation();
    }

    public class Atom_Item
    {
            public ID ID = new ID();
            public UniqueName UniqueName = new UniqueName();
            public Atom_Item_Name m_Atom_Item_Name = new Atom_Item_Name();
            public Atom_Item_barcode m_Atom_Item_barcode = new Atom_Item_barcode();
            public Atom_Item_Description m_Atom_Item_Description = new Atom_Item_Description();
            public Atom_Expiry m_Atom_Expiry = new Atom_Expiry();
            public Atom_Warranty m_Atom_Warranty = new Atom_Warranty();
            public Atom_Unit m_Atom_Unit = new Atom_Unit();
    }

    public class DocInvoice_ShopC_Item
    {
        public ID ID = new ID();
        public DocInvoice m_DocInvoice = new DocInvoice();
        public Atom_Price_Item m_Atom_Price_Item = new Atom_Price_Item();
        public Stock m_Stock = new Stock();
        public dQuantity dQuantity = new dQuantity();
        public ExtraDiscount ExtraDiscount = new ExtraDiscount();
        public RetailPriceWithDiscount RetailPriceWithDiscount = new RetailPriceWithDiscount();
        public TaxPrice TaxPrice = new TaxPrice();
        public ExpiryDate ExpiryDate = new ExpiryDate(); 
    }

    public class DocProformaInvoice_ShopC_Item
    {
        public ID ID = new ID();
        public DocProformaInvoice m_DocProformaInvoice = new DocProformaInvoice();
        public Atom_Price_Item m_Atom_Price_Item = new Atom_Price_Item();
        public Stock m_Stock = new Stock();
        public dQuantity dQuantity = new dQuantity();
        public ExtraDiscount ExtraDiscount = new ExtraDiscount();
        public RetailPriceWithDiscount RetailPriceWithDiscount = new RetailPriceWithDiscount();
        public TaxPrice TaxPrice = new TaxPrice();
        public ExpiryDate ExpiryDate = new ExpiryDate();
    }


    public class Atom_Item_Image
    {
         public ID ID = new ID();
         public Atom_Item m_Atom_Item = new Atom_Item();
         public Atom_Item_ImageLib m_Atom_Item_ImageLib = new Atom_Item_ImageLib();
    }


    public class Atom_Taxation 
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Rate Rate = new Rate();
    }

    public class Stock_AddressLevel3
    {
        public ID ID = new ID();
        public Address Address = new Address();
    }

    public class Stock_AddressLevel2
    {
        public ID ID = new ID();
        public Address Address = new Address();
        public Stock_AddressLevel3 m_Stock_AddressLevel3 = new Stock_AddressLevel3();
    }

    public class Stock_AddressLevel1
    {
        public ID ID = new ID();
        public Address Address = new Address();
        public Stock_AddressLevel2 m_Stock_AddressLevel2 = new Stock_AddressLevel2();
    }

    public class ValidFrom:DB_DateTime
    {
    }

    public class ValidTo : DB_DateTime
    {
    }

    public class Valid : DB_bit
    {
    }

    public class CreationDate : DB_DateTime
    {
    }

    public class StockTake_Date : DB_DateTime
    {
    }

    public class Purchase_Order_Date : DB_DateTime
    {
    }

    public class Purchase_Order_Number : DB_varchar_32
    {
    }


    public class PriceList
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Currency m_Currency = new Currency();
        public Valid Valid = new Valid();
        public ValidFrom ValidFrom = new ValidFrom();
        public ValidTo ValidTo = new ValidTo();
        public Description Description = new Description();
        public CreationDate CreationDate = new CreationDate();
    }

    public class Price_Item
    {
        public ID ID = new ID();
        public RetailPricePerUnit RetailPricePerUnit = new RetailPricePerUnit();
        public Item m_Item = new Item();
        public Discount Discount = new Discount();
        public PriceList m_PriceList = new PriceList();
        public Taxation m_Taxation = new Taxation();
    }

    public class Reference_Image
    {
        public ID ID = new ID();
        public Image_Hash Image_Hash = new Image_Hash();
        public Image_Data Image_Data = new Image_Data();

    }

    public class Reference
    {
        public ID ID = new ID();
        public ReferenceNote ReferenceNote = new ReferenceNote();
        public Reference_Image m_Reference_Image = new Reference_Image();
    }

    public class Supplier
    {
        public ID ID = new ID();
        public Contact m_Contact = new Contact();
    }

    public class TruckingNumber:DB_varchar_64
    {

    }

    public class TruckingCost:DB_Money
    {

    }

    public class Trucking
    {
        public ID ID = new ID();
        public Contact m_Contact = new Contact();
        public TruckingCost TruckingCost = new TruckingCost();
        public TruckingNumber TruckingNumber = new TruckingNumber();
        public Customs Customs = new Customs();
        public Description Description = new Description();
    }


    public class Locked:DB_bit
    {

    }

    public class StockTake
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public StockTake_Date StockTake_Date = new StockTake_Date();
        public Supplier m_Supplier = new Supplier();
        public StockTakePriceTotal StockTakePriceTotal = new StockTakePriceTotal();
        public Trucking m_Trucking = new Trucking();
        public Reference m_Reference = new Reference();
        public Description Description = new Description();
        public Draft Draft = new Draft();
    }

    public class PurchasePrice

    {

        public ID ID = new ID();

        public PurchasePricePerUnit PurchasePricePerUnit = new PurchasePricePerUnit();

        public Currency m_Currency = new Currency();

        public Taxation m_Taxation = new Taxation();

        public PurchasePriceDate PurchasePriceDate = new PurchasePriceDate();

    }



    public class PurchasePrice_Item

    {

        public ID ID = new ID();

        public PurchasePrice m_PurchasePrice = new PurchasePrice();

        public Item m_Item = new Item();

        public StockTake m_StockTake = new StockTake();

    }



    public class Stock
    {

        public ID ID = new ID();

        public PurchasePrice_Item m_PurchasePrice_Item = new PurchasePrice_Item();

        public dQuantity dQuantity = new dQuantity();

        public ImportTime ImportTime = new ImportTime();

        public ExpiryDate ExpiryDate = new ExpiryDate();

        public Stock_AddressLevel1 m_Stock_AddressLevel1 = new Stock_AddressLevel1();

        public Description Description = new Description();

    }




    public class Purchase_Order
    {
        public ID ID = new ID();
        public Purchase_Order_Number Purchase_Order_Number = new Purchase_Order_Number();
        public Purchase_Order_Date Purchase_Order_Date = new Purchase_Order_Date();
        public DeliveryTime DeliveryTime = new DeliveryTime();
        public Supplier m_Supplier = new Supplier();
        public Reference m_Reference = new Reference();
        public Description Description = new Description();
    }

    public class Purchase_Order_Item
    {
        public ID ID = new ID();
        public Purchase_Order m_Purchase_Order = new Purchase_Order();
        public Item m_Item = new Item();
        public dQuantity dQuantity = new dQuantity();
        public Description Description = new Description();
    }


    public class SimpleItem_Image
    {
        public ID ID = new ID();
        public Image_Hash Image_Hash = new Image_Hash();
        public Image_Data Image_Data = new Image_Data();
    }

    public class Item_Image
    {
        public ID ID = new ID();
        public Image_Hash Image_Hash = new Image_Hash();
        public Image_Data Image_Data = new Image_Data();
    }

    public class Typ : DB_varchar_264
    {
    }


    public class RateDate:DB_DateTime
    {
    }

    public class CurrencyCode:DB_smallInt
    {
    }

    public class DecimalPlaces :DB_smallInt
    {
    }

    public class Currency
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Abbreviation Abbreviation = new Abbreviation();
        public Symbol Symbol = new Symbol();
        public CurrencyCode CurrencyCode = new CurrencyCode();
        public DecimalPlaces DecimalPlaces = new DecimalPlaces();
    }

    public class BaseCurrency
    {
        public ID ID = new ID();
        public Currency m_Currency = new Currency();
    }

    public class URL : DB_varchar_264
    {
    }

    public class ExchangeRateSource
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public URL URL = new URL();
        public Description Description = new Description();
    }

    public class RateToBaseCurrency
    {
        public ID ID = new ID();
        public BaseCurrency m_BaseCurrency = new BaseCurrency();
        public Currency m_Currency = new Currency();
        public Rate Rate = new Rate();
        public RateDate RateDate = new RateDate();
        public ExchangeRateSource m_ExchangeRateSource = new ExchangeRateSource();
    }

    public class DocInvoice_ShopB_Item
    {
        public ID ID = new ID();
        public Atom_PriceList m_Atom_PriceList = new Atom_PriceList();
        public Atom_SimpleItem m_Atom_SimpleItem = new Atom_SimpleItem();
        public RetailSimpleItemPrice RetailSimpleItemPrice = new RetailSimpleItemPrice();
        public Discount Discount = new Discount();
        public iQuantity iQuantity = new iQuantity();
        public RetailSimpleItemPriceWithDiscount RetailSimpleItemPriceWithDiscount = new RetailSimpleItemPriceWithDiscount();
        public ExtraDiscount ExtraDiscount = new ExtraDiscount();
        public TaxPrice TaxPrice = new TaxPrice();
        public Atom_Taxation m_Atom_Taxation = new Atom_Taxation();
        public DocInvoice m_DocInvoice = new DocInvoice();
    }

    public class DocProformaInvoice_ShopB_Item
    {
        public ID ID = new ID();
        public Atom_PriceList m_Atom_PriceList = new Atom_PriceList();
        public Atom_SimpleItem m_Atom_SimpleItem = new Atom_SimpleItem();
        public RetailSimpleItemPrice RetailSimpleItemPrice = new RetailSimpleItemPrice();
        public Discount Discount = new Discount();
        public iQuantity iQuantity = new iQuantity();
        public RetailSimpleItemPriceWithDiscount RetailSimpleItemPriceWithDiscount = new RetailSimpleItemPriceWithDiscount();
        public ExtraDiscount ExtraDiscount = new ExtraDiscount();
        public TaxPrice TaxPrice = new TaxPrice();
        public Atom_Taxation m_Atom_Taxation = new Atom_Taxation();
        public DocProformaInvoice m_DocProformaInvoice = new DocProformaInvoice();
    }


    public class Price_SimpleItem
    {
        public ID ID = new ID();
        public RetailSimpleItemPrice RetailSimpleItemPrice = new RetailSimpleItemPrice();
        public Discount Discount = new Discount();
        public SimpleItem m_SimpleItem = new SimpleItem();
        public PriceList m_PriceList = new PriceList();
        public Taxation m_Taxation = new Taxation();
    }

    public class SimpleItem
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public SimpleItem_Image m_SimpleItem_Image = new SimpleItem_Image();
        public Abbreviation Abbreviation = new Abbreviation();
        public Code Code = new Code();
        public ToOffer ToOffer = new ToOffer();
        public SimpleItem_ParentGroup1 m_SimpleItem_ParentGroup1 = new SimpleItem_ParentGroup1();
    }

    public class SimpleItem_ParentGroup3
    {
        public ID ID = new ID();
        public Name Name = new Name();
    }

    public class SimpleItem_ParentGroup2
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public SimpleItem_ParentGroup3 m_SimpleItem_ParentGroup3 = new SimpleItem_ParentGroup3();
    }

    public class SimpleItem_ParentGroup1
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public SimpleItem_ParentGroup2 m_SimpleItem_ParentGroup2 = new SimpleItem_ParentGroup2();
    }


    public class Atom_SimpleItem_Name
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Abbreviation Abbreviation = new Abbreviation();
    }

    public class Atom_SimpleItem_Image
    {
        public ID ID = new ID();
        public Image_Hash Image_Hash = new Image_Hash();
        public Image_Data Image_Data = new Image_Data();

    }
    public class Atom_SimpleItem
    {
        public ID ID = new ID();
        public SimpleItem m_SimpleItem = new SimpleItem();
        public Atom_SimpleItem_Name m_Atom_SimpleItem_Name = new Atom_SimpleItem_Name();
        public Atom_SimpleItem_Image m_Atom_SimpleItem_Image = new Atom_SimpleItem_Image();
    }

    public class MethodOfPayment
    {
        public ID ID = new ID();
        public PaymentType PaymentType  = new PaymentType();
        public Atom_BankAccount m_Atom_BankAccount = new Atom_BankAccount();
    }

    public class Invoice_Reference_ID:DB_Int64
    {

    }

    public class Invoice_Reference_Type:DB_varchar_25
    {

    }


    public class  TermsOfPayment 
    {
        public ID ID = new ID();
        public Description Description = new Description();
    }

    public class Customer_Org
    {
        public ID ID = new ID();
        public OrganisationData m_OrganisationData = new OrganisationData();
    }

    public class Customer_Person
    {
        public ID ID = new ID();
        public Person m_Person = new Person();
    }

    public class Atom_Customer_Org
    {
        public ID ID = new ID();
        public Atom_Organisation m_Atom_Organisation = new Atom_Organisation();
    }

    public class Atom_Customer_Person
    {
        public ID ID = new ID();
        public Atom_Person m_Atom_Person = new Atom_Person();
    }

    public class IssueDate:DB_DateTime
    {

    }
    public class DocInvoice 
    {
        public ID ID = new ID();
        public IssueDate IssueDate = new IssueDate();
        public FinancialYear FinancialYear = new FinancialYear();
        public NumberInFinancialYear NumberInFinancialYear = new NumberInFinancialYear();
        public Draft Draft = new Draft();
        public DraftNumber DraftNumber = new DraftNumber();
        public NetSum NetSum = new NetSum();
        public Discount Discount = new Discount();
        public EndSum EndSum = new EndSum();
        public TaxSum TaxSum = new TaxSum();
        public GrossSum GrossSum = new GrossSum();
        public Atom_Customer_Person m_Atom_Customer_Person = new Atom_Customer_Person();
        public Atom_Customer_Org m_Atom_Customer_Org = new Atom_Customer_Org();
        public WarrantyExist WarrantyExist = new WarrantyExist();
        public WarrantyDurationType WarrantyDurationType = new WarrantyDurationType();
        public WarrantyDuration WarrantyDuration = new WarrantyDuration();
        public WarrantyConditions WarrantyConditions = new WarrantyConditions();
        public TermsOfPayment m_TermsOfPayment = new TermsOfPayment();
        public PaymentDeadline PaymentDeadline = new PaymentDeadline();
        public MethodOfPayment m_MethodOfPayment = new MethodOfPayment();
        public Paid Paid = new Paid();
        public Storno Storno = new Storno();
        public Invoice_Reference_ID Invoice_Reference_ID = new Invoice_Reference_ID();
        public Invoice_Reference_Type Invoice_Reference_Type = new Invoice_Reference_Type();
    }

    public class DocProformaInvoice
    {
        public ID ID = new ID();
        public IssueDate IssueDate = new IssueDate();
        public FinancialYear FinancialYear = new FinancialYear();
        public NumberInFinancialYear NumberInFinancialYear = new NumberInFinancialYear();
        public Draft Draft = new Draft();
        public DraftNumber DraftNumber = new DraftNumber();
        public NetSum NetSum = new NetSum();
        public Discount Discount = new Discount();
        public EndSum EndSum = new EndSum();
        public TaxSum TaxSum = new TaxSum();
        public GrossSum GrossSum = new GrossSum();
        public Atom_Customer_Person m_Atom_Customer_Person = new Atom_Customer_Person();
        public Atom_Customer_Org m_Atom_Customer_Org = new Atom_Customer_Org();
        public WarrantyExist WarrantyExist = new WarrantyExist();
        public WarrantyDurationType WarrantyDurationType = new WarrantyDurationType();
        public WarrantyDuration WarrantyDuration = new WarrantyDuration();
        public WarrantyConditions WarrantyConditions = new WarrantyConditions();
        public DocDuration DocDuration = new DocDuration();
        public DocDurationType DocDurationType = new DocDurationType();
        public TermsOfPayment m_TermsOfPayment = new TermsOfPayment();
        public MethodOfPayment m_MethodOfPayment = new MethodOfPayment();
    }

    public class Doc_ImageLib
    {
        public ID ID = new ID();
        public Image_Hash Image_Hash = new Image_Hash();
        public Image_Data Image_Data = new Image_Data();
        public Description Description = new Description();
    }

    public class Notice
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public NoticeText NoticeText = new NoticeText();
        public Description Description = new Description();
    }

    public class DocInvoice_Notice
    {
        public ID ID = new ID();
        public DocInvoice m_DocInvoice = new DocInvoice();
        public Notice m_Notice = new Notice();
        public Doc_ImageLib m_Doc_ImageLib = new Doc_ImageLib();
    }

    public class DocProformaInvoice_Notice
    {
        public ID ID = new ID();
        public DocProformaInvoice m_DocProformaInvoice = new DocProformaInvoice();
        public Notice m_Notice = new Notice();
        public Doc_ImageLib m_Doc_ImageLib = new Doc_ImageLib();
    }

    public class DocInvoice_Image
    {
        public ID ID = new ID();
        public Doc_ImageLib m_Doc_ImageLib = new Doc_ImageLib();
        public DocInvoice m_DocInvoice = new DocInvoice();
    }

    public class DocProformaInvoice_Image
    {
        public ID ID = new ID();
        public Doc_ImageLib m_Doc_ImageLib = new Doc_ImageLib();
        public DocProformaInvoice m_DocProformaInvoice = new DocProformaInvoice();
    }

    public class DBSettings
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public TextValue TextValue = new TextValue();
        public ReadOnly ReadOnly = new ReadOnly();
    }


    public class JOURNAL_PriceList_Type
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
    }

    public class JOURNAL_DocInvoice_Type
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
    }

    public class JOURNAL_DocProformaInvoice_Type
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
    }

    public class JOURNAL_Item_Type
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
    }

    public class JOURNAL_SimpleItem_Type
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
    }
    
    public class JOURNAL_myOrganisation_Type
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
    }

    public class JOURNAL_Person_Type
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
    }

    public class JOURNAL_Customer_Person_Type
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
    }

    public class JOURNAL_Customer_Org_Type
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
    }

    public class JOURNAL_StockTake_Type
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
    }

    public class JOURNAL_Taxation_Type
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
    }

    public class JOURNAL_Stock_Type
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
    }


    public class JOURNAL_DocProformaInvoice
    {
        public ID ID = new ID();
        public JOURNAL_DocProformaInvoice_Type m_JOURNAL_DocProformaInvoice_Type = new JOURNAL_DocProformaInvoice_Type();
        public DocProformaInvoice m_DocProformaInvoice = new DocProformaInvoice();
        public EventTime EventTime = new EventTime();
        public Atom_WorkPeriod m_Atom_WorkPeriod = new Atom_WorkPeriod();
    }

    public class JOURNAL_DocInvoice
    {
        public ID ID = new ID();
        public JOURNAL_DocInvoice_Type m_JOURNAL_DocInvoice_Type = new JOURNAL_DocInvoice_Type();
        public DocInvoice m_DocInvoice = new DocInvoice();
        public EventTime EventTime = new EventTime();
        public Atom_WorkPeriod m_Atom_WorkPeriod = new Atom_WorkPeriod();
    }


    public class JOURNAL_Item
    {
        public ID ID = new ID();
        public JOURNAL_Item_Type m_JOURNAL_Item_Type = new JOURNAL_Item_Type();
        public Item m_Item = new Item();
        public EventTime EventTime = new EventTime();
        public Atom_WorkPeriod m_Atom_WorkPeriod = new Atom_WorkPeriod();
    }


    public class JOURNAL_SimpleItem
    {
        public ID ID = new ID();
        public JOURNAL_SimpleItem_Type m_JOURNAL_SimpleItem_Type = new JOURNAL_SimpleItem_Type();
        public SimpleItem m_SimpleItem = new SimpleItem();
        public EventTime EventTime = new EventTime();
        public Atom_WorkPeriod m_Atom_WorkPeriod = new Atom_WorkPeriod();
    }

    public class JOURNAL_PriceList
    {
        public ID ID = new ID();
        public JOURNAL_PriceList_Type m_JOURNAL_PriceList_Type = new JOURNAL_PriceList_Type();
        public PriceList m_PriceList = new PriceList();
        public EventTime EventTime = new EventTime();
        public Atom_WorkPeriod m_Atom_WorkPeriod = new Atom_WorkPeriod();
    }

    public class JOURNAL_myOrganisation
    {
        public ID ID = new ID();
        public JOURNAL_myOrganisation_Type m_JOURNAL_myOrganisation_Type = new JOURNAL_myOrganisation_Type();
        public myOrganisation m_myOrganisation = new myOrganisation();
        public EventTime EventTime = new EventTime();
        public Atom_WorkPeriod m_Atom_WorkPeriod = new Atom_WorkPeriod();
    }

    public class JOURNAL_Person
    {
        public ID ID = new ID();
        public JOURNAL_Person_Type m_JOURNAL_Person_Type = new JOURNAL_Person_Type();
        public Person m_Person = new Person();
        public EventTime EventTime = new EventTime();
        public Atom_WorkPeriod m_Atom_WorkPeriod = new Atom_WorkPeriod();
    }

    public class JOURNAL_Customer_Person
    {
        public ID ID = new ID();
        public JOURNAL_Customer_Person_Type m_JOURNAL_Customer_Person_Type = new JOURNAL_Customer_Person_Type();
        public Customer_Person m_Customer_Person = new Customer_Person();
        public EventTime EventTime = new EventTime();
        public Atom_WorkPeriod m_Atom_WorkPeriod = new Atom_WorkPeriod();
    }

    public class JOURNAL_Customer_Person_Data
    {
        public ID ID = new ID();
        public JOURNAL_Customer_Person m_JOURNAL_Customer_Person = new JOURNAL_Customer_Person();
        public Description m_Description = new Description();
    }

    public class JOURNAL_Customer_Person_Data_Image
    {
        public ID ID = new ID();
        public Image_Hash Image_Hash = new Image_Hash();
        public Image_Data Image_Data = new Image_Data();
        public Description Description = new Description();
    }


    public class JOURNAL_Customer_Org
    {
        public ID ID = new ID();
        public JOURNAL_Customer_Org_Type m_JOURNAL_Customer_Org_Type = new JOURNAL_Customer_Org_Type();
        public Customer_Org m_Customer_Org = new Customer_Org();
        public EventTime EventTime = new EventTime();
        public Atom_WorkPeriod m_Atom_WorkPeriod = new Atom_WorkPeriod();
    }

    public class JOURNAL_StockTake
    {
        public ID ID = new ID();
        public JOURNAL_StockTake_Type m_JOURNAL_StockTake_Type = new JOURNAL_StockTake_Type();
        public StockTake m_StockTake = new StockTake();
        public EventTime EventTime = new EventTime();
        public Atom_WorkPeriod m_Atom_WorkPeriod = new Atom_WorkPeriod();
    }

    public class JOURNAL_Taxation
    {
        public ID ID = new ID();
        public JOURNAL_Taxation_Type m_JOURNAL_Taxation_Type = new JOURNAL_Taxation_Type();
        public Taxation m_Taxation = new Taxation();
        public EventTime EventTime = new EventTime();
        public Atom_WorkPeriod m_Atom_WorkPeriod = new Atom_WorkPeriod();
    }

    public class JOURNAL_Stock
    {
        public ID ID = new ID();
        public JOURNAL_Stock_Type m_JOURNAL_Stock_Type = new JOURNAL_Stock_Type();
        public Stock m_Stock = new Stock();
        public EventTime EventTime = new EventTime();
        public Atom_WorkPeriod m_Atom_WorkPeriod = new Atom_WorkPeriod();
        public dQuantity dQuantity = new dQuantity();
    }

    public class DeliveryType
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
    }

    public class Delivery
    {
        public ID ID = new ID();
        public Stock m_Stock = new Stock();
        public DeliveryType m_DeliveryType = new DeliveryType();
        public DocInvoice m_DocInvoice = new DocInvoice();
        public dQuantity dQuantity = new dQuantity();
        public Description Description = new Description();
    }

    public class JOURNAL_Delivery_Type
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
    }

    public class JOURNAL_Delivery
    {
        public ID ID = new ID();
        public JOURNAL_Delivery_Type m_JOURNAL_Delivery_Type = new JOURNAL_Delivery_Type();
        public Delivery m_Delivery = new Delivery();
        public EventTime EventTime = new EventTime();
        public Atom_WorkPeriod m_Atom_WorkPeriod = new Atom_WorkPeriod();
    }



    public class doc_type
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
    }

    public class doc_page_type
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
        public Width Width = new Width();
        public Height Height = new Height();
    }

    public class doc
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
        public xDocument xDocument = new xDocument();
        public xDocument_Hash xDocument_Hash = new xDocument_Hash();
        public Active Active = new Active();
        public bDefault bDefault = new bDefault();
        public Compressed Compressed = new Compressed();
        public Language m_Language = new Language();
        public doc_type m_doc_type = new doc_type();
        public doc_page_type m_doc_page_type = new doc_page_type();
    }

    public class JOURNAL_doc_Type
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
    }

    public class JOURNAL_doc
    {
        public ID ID = new ID();
        public JOURNAL_doc_Type m_JOURNAL_doc_Type = new JOURNAL_doc_Type();
        public doc m_doc = new doc();
        public DocInvoice m_DocInvoice = new DocInvoice();
        public EventTime EventTime = new EventTime();
        public Atom_WorkPeriod m_Atom_WorkPeriod = new Atom_WorkPeriod();
    }

    public class LanguageIndex : DB_Int32
    {

    }

    public class Language
    {
        public ID ID = new ID();
        public LanguageIndex LanguageIndex = new LanguageIndex();
        public Name Name = new Name();
        public Description Description = new Description();
        public bDefault bDefault = new bDefault();
    }

    public class FVI_SLO_RealEstateBP
    {
        public ID ID = new ID();
        public Office_Data m_Office_Data = new Office_Data();
        public Community Community = new Community();
        public CadastralNumber CadastralNumber = new CadastralNumber();
        public BuildingNumber BuildingNumber = new BuildingNumber();
        public BuildingSectionNumber BuildingSectionNumber = new BuildingSectionNumber();
        public PremiseType PremiseType = new PremiseType();
        public ValidityDate ValidityDate = new ValidityDate();
        public ClosingTag ClosingTag = new ClosingTag();
        public SoftwareSupplier_TaxNumber SoftwareSupplier_TaxNumber = new SoftwareSupplier_TaxNumber();
        public SpecialNotes SpecialNotes = new SpecialNotes();
    }

    public class Atom_FVI_SLO_RealEstateBP
    {
        public ID ID = new ID();
        public Atom_Office_Data m_Atom_Office_Data = new Atom_Office_Data();
        public Community Community = new Community();
        public CadastralNumber CadastralNumber = new CadastralNumber();
        public BuildingNumber BuildingNumber = new BuildingNumber();
        public BuildingSectionNumber BuildingSectionNumber = new BuildingSectionNumber();
        public PremiseType PremiseType = new PremiseType();
        public ValidityDate ValidityDate = new ValidityDate();
        public ClosingTag ClosingTag = new ClosingTag();
        public SoftwareSupplier_TaxNumber SoftwareSupplier_TaxNumber = new SoftwareSupplier_TaxNumber();
        public SpecialNotes SpecialNotes = new SpecialNotes();
    }

    public class Response_DateTime : DB_DateTime
    {

    }

    public class MessageID:DB_varchar_45
    {

    }

    public class UniqueInvoiceID:DB_varchar_45
    {

    }

    public class BarCodeValue:DB_varchar_64
    {

    }

    public class TestEnvironment:DB_bit
    {

    }

    public class FVI_SLO_Response
    {
        public ID ID = new ID();
        public DocInvoice m_DocInvoice = new DocInvoice();
        public Response_DateTime Response_DateTime = new Response_DateTime();
        public MessageID MessageID = new MessageID();
        public UniqueInvoiceID UniqueInvoiceID = new UniqueInvoiceID();
        public BarCodeValue BarCodeValue = new BarCodeValue();
        public TestEnvironment TestEnvironment = new TestEnvironment();
    }

    public class InvoiceNumber:DB_varchar_25
    {

    }

    public class SetNumber:DB_varchar_5
    {

    }

    public class SerialNumber : DB_varchar_25
    {

    }

    public class FVI_SLO_SalesBookInvoice
    {
        public ID ID = new ID();
        public DocInvoice m_DocInvoice = new DocInvoice();
        public InvoiceNumber InvoiceNumber = new InvoiceNumber();
        public SetNumber SetNumber = new SetNumber();
        public SerialNumber SerialNumber = new SerialNumber();
    }

    public class Atom_ItemShopA_Image
    {
        public ID ID = new ID();
        public Atom_ItemShopA m_Atom_ItemShopA = new Atom_ItemShopA();
        public Image_Hash Image_Hash = new Image_Hash();
        public Image_Data Image_Data = new Image_Data();
        public Description Description = new Description();
    }

    public class VisibleForSelection:DB_bit
    {

    }

    public class Atom_ItemShopA
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
        public Taxation m_Taxation= new Taxation();
        public Unit m_Unit = new Unit();
        public Supplier m_Supplier = new Supplier();
        public VisibleForSelection VisibleForSelection = new VisibleForSelection();
    }


    public class DocInvoice_ShopA_Item
    {
        public ID ID = new ID();
        public DocInvoice m_DocInvoice = new DocInvoice();
        public Atom_ItemShopA m_Atom_ItemShopA = new Atom_ItemShopA();
        public dQuantity dQuantity = new dQuantity();
        public Discount Discount = new Discount();
        public PricePerUnit PricePerUnit = new PricePerUnit();
        public EndPriceWithDiscountAndTax EndPriceWithDiscountAndTax = new EndPriceWithDiscountAndTax();
        public TAX TAX = new TAX();
    }

    public class DocProformaInvoice_ShopA_Item
    {
        public ID ID = new ID();
        public DocProformaInvoice m_DocProformaInvoice = new DocProformaInvoice();
        public Atom_ItemShopA m_Atom_ItemShopA = new Atom_ItemShopA();
        public dQuantity dQuantity = new dQuantity();
        public Discount Discount = new Discount();
        public PricePerUnit PricePerUnit = new PricePerUnit();
        public EndPriceWithDiscountAndTax EndPriceWithDiscountAndTax = new EndPriceWithDiscountAndTax();
        public TAX TAX = new TAX();
    }

    public class TableName : DB_varchar_264
    {

    }
    public class Table_RowID : DB_Int64
    {

    }

    public class JOURNAL_Name
    {
        public ID ID = new ID();
        public Name Name = new Name();
    }

    public class JOURNAL_TableName
    {
        public ID ID = new ID();
        public TableName TableName = new TableName();
    }

    public class JOURNAL_TYPE
    {
        public ID ID = new ID();
        public JOURNAL_TableName m_JOURNAL_TableName = new JOURNAL_TableName();
        public JOURNAL_Name m_JOURNAL_Name = new JOURNAL_Name();
        public Description Description = new Description();
    }

    public class JOURNAL
    {
        public ID ID = new ID();
        public JOURNAL_TYPE m_JOURNAL_TYPE = new JOURNAL_TYPE();
        public Table_RowID Table_RowID = new Table_RowID();
        public EventTime EventTime = new EventTime();
        public Atom_WorkPeriod m_Atom_WorkPeriod = new Atom_WorkPeriod();
    }

    public class Cost:DB_Money
    {

    }

    public class StockTakeCostName
    {
        public ID ID = new ID();
        public Name Name = new Name();
    }

    public class StockTakeCostDescription
    {
        public ID ID = new ID();
        public Description Description = new Description();
    }

    public class StockTake_AdditionalCost
    {
        public ID ID = new ID();
        public StockTakeCostName m_StockTakeCostName = new StockTakeCostName();
        public Cost Cost = new Cost();
        public StockTakeCostDescription m_StockTakeCostDescription = new StockTakeCostDescription();
        public StockTake m_StockTake = new StockTake();
    }

    public class SQL_Database_Tables_Definition
    {

        /* 1 */
        public cFirstName m_cFirstName = new cFirstName();
        /* 2 */
        public cLastName m_cLastName = new cLastName();
        /* 3 */
        public cPhoneNumber_Person m_cPhoneNumber_Person = new cPhoneNumber_Person();
        /* 4 */
        public cGsmNumber_Person m_cGsmNumber_Person = new cGsmNumber_Person();
        /* 5 */
        public cEmail_Person m_cEmail_Person = new cEmail_Person();
        /* 6 */
        public cZIP_Person m_cZIP_Person = new cZIP_Person();
        /* 7 */
        public cStreetName_Person m_cStreetName_Person = new cStreetName_Person();
        /* 8 */
        public cHouseNumber_Person m_cHouseNumber_Person = new cHouseNumber_Person();
        /* 9 */
        public cCity_Person m_cCity_Person = new cCity_Person();
        /* 10 */
        public cCountry_Person m_cCountry_Person = new cCountry_Person();
        /* 11 */
        public cState_Person m_cState_Person = new cState_Person();

        /* 12 */
        public Person m_Person = new Person();

        /* 13 */
        public cOrgTYPE m_cOrgTYPE = new cOrgTYPE();

        /* 14 */
        public cStreetName_Org m_cStreetName_Org = new cStreetName_Org();
        /* 15 */
        public cHouseNumber_Org m_cHouseNumber_Org = new cHouseNumber_Org();
        /* 16 */
        public cCity_Org m_cCity_Org = new cCity_Org();
        /* 17 */
        public cCountry_Org m_cCountry_Org = new cCountry_Org();
        /* 18 */
        public cState_Org m_cState_Org = new cState_Org();
        /* 19 */
        public cZIP_Org m_cZIP_Org = new cZIP_Org();
        /* 20 */
        public cPhoneNumber_Org m_cPhoneNumber_Org = new cPhoneNumber_Org();
        /* 21 */
        public cFaxNumber_Org m_cFaxNumber_Org = new cFaxNumber_Org();
        /* 22 */
        public cEmail_Org m_cEmail_Org = new cEmail_Org();
        /* 23 */
        public cHomePage_Org m_cHomePage_Org = new cHomePage_Org();

        /* 24 */
        public Organisation m_Organisation = new Organisation();

        /* 25 */
        public myOrganisation m_myOrganisation = new myOrganisation();

        /* 26 */
        public Reference m_Reference = new Reference();

        /* 27 */
        public Item m_Item = new Item();

        /* 28 */
        public Taxation m_Taxation = new Taxation();
        
        /* 29 */
        public Stock m_Stock = new Stock();
        
        /* 30 */
        public SimpleItem m_SimpleItem = new SimpleItem();

        /* 31 */
        public MethodOfPayment m_MethodOfPayment = new MethodOfPayment();

        /* 32 */
        public JOURNAL_DocProformaInvoice_Type m_JOURNAL_DocProformaInvoice_Type = new JOURNAL_DocProformaInvoice_Type();
        
        /* 33 */
        public Atom_Item m_Atom_Item = new Atom_Item();
        
        /* 34 */
        public Atom_SimpleItem m_Atom_SimpleItem = new Atom_SimpleItem();
        
        /* 35 */
        public cCardType_Person m_cCardType_Person = new cCardType_Person();
        
        /* 36 */
        public DBSettings m_DBSettings = new DBSettings();
        
        /* 37 */
        public Atom_Item_Image m_Atom_Item_Image = new Atom_Item_Image();

        /* 38 */
        public Atom_Item_ImageLib m_Atom_Item_ImageLib = new Atom_Item_ImageLib();

        /* 39 */
        public Atom_Item_Name m_Atom_Item_Name = new Atom_Item_Name();

        /* 40 */
        public Atom_Item_barcode m_Atom_Item_barcode = new Atom_Item_barcode();

        /* 41 */
        public Atom_Item_Description m_Atom_Item_Description = new Atom_Item_Description();

        /* 42 */
        public Atom_SimpleItem_Name m_Atom_SimpleItem_Name = new Atom_SimpleItem_Name();

        /* 43 */
        public Atom_Taxation m_Atom_Taxation = new Atom_Taxation();

        /* 44 */
        public Atom_SimpleItem_Image m_Atom_SimpleItem_Image = new Atom_SimpleItem_Image();

        /* 45 */
        public DocInvoice m_DocInvoice = new DocInvoice();

        /* 46 */
        public DocInvoice_Notice m_DocInvoice_Notice = new DocInvoice_Notice();

        /* 47 */
        public Doc_ImageLib m_Doc_ImageLib = new Doc_ImageLib();

        /* 48 */
        public DocInvoice_Image m_DocInvoice_Image = new DocInvoice_Image();

        /* 49 */
        public TermsOfPayment m_TermsOfPayment = new TermsOfPayment();

        /* 50 */
        public myOrganisation_Person m_myOrganisation_Person = new myOrganisation_Person();

        /* 51 */
        public DocInvoice_ShopC_Item m_DocInvoice_ShopC_Item = new DocInvoice_ShopC_Item();

        /* 52 */
        public Atom_myOrganisation_Person m_Atom_myOrganisation_Person = new Atom_myOrganisation_Person();

        /* 53 */
        public Atom_myOrganisation m_Atom_myOrganisation = new Atom_myOrganisation();

        /* 54 */
        public Atom_Person m_BuyerAtom_Person = new Atom_Person();

        /* 55 */
        public Atom_Organisation m_Atom_Organisation = new Atom_Organisation();

        /* 56 */
        public SimpleItem_Image m_SimpleItem_Image = new SimpleItem_Image();

        /* 57 */
        public Item_Image m_Item_Image = new Item_Image();

        /* 58 */
        public Expiry m_Expiry = new Expiry();

        /* 59 */
        public Warranty m_Warranty = new Warranty();

        /* 60 */
        public Atom_Expiry m_Atom_Expiry = new Atom_Expiry();

        /* 61 */
        public Atom_Warranty m_Atom_Warranty = new Atom_Warranty();

        /* 62 */
        public Item_ParentGroup3 m_Item_ParentGroup3 = new Item_ParentGroup3();

        /* 63 */
        public Item_ParentGroup2 m_Item_ParentGroup2 = new Item_ParentGroup2();

        /* 64 */
        public Item_ParentGroup1 m_Item_ParentGroup1 = new Item_ParentGroup1();

        /* 65 */
        public Stock_AddressLevel3 m_Stock_AddressLevel3 = new Stock_AddressLevel3();

        /* 66 */
        public Stock_AddressLevel2 m_Stock_AddressLevel2 = new Stock_AddressLevel2();

        /* 67 */
        public Stock_AddressLevel1 m_Stock_AddressLevel1 = new Stock_AddressLevel1();

        /* 68 */
        public Atom_cStreetName_Person m_Atom_cStreetName_Person = new Atom_cStreetName_Person();

        /* 69 */
        public Atom_cHouseNumber_Person m_Atom_cHouseNumber_Person = new Atom_cHouseNumber_Person();

        /* 70 */
        public Atom_cCity_Person m_Atom_cCity_Person = new Atom_cCity_Person();

        /* 71 */
        public Atom_cZIP_Person m_Atom_cZIP_Person = new Atom_cZIP_Person();

        /* 72 */
        public Atom_cCountry_Person m_Atom_cCountry_Person = new Atom_cCountry_Person();

        /* 73 */
        public Atom_cState_Person m_Atom_cState_Person = new Atom_cState_Person();

        /* 74 */
        public Atom_cStreetName_Org m_Atom_cStreetName_Org = new Atom_cStreetName_Org();

        /* 75 */
        public Atom_cHouseNumber_Org m_Atom_cHouseNumber_Org = new Atom_cHouseNumber_Org();

        /* 76 */
        public Atom_cCity_Org m_Atom_cCity_Org  = new Atom_cCity_Org();

        /* 77 */
        public Atom_cZIP_Org m_Atom_cZIP_Org  = new Atom_cZIP_Org();

        /* 78 */
        public Atom_cCountry_Org m_Atom_cCountry_Org = new Atom_cCountry_Org();

        /* 79 */
        public Atom_cState_Org m_Atom_cState_Org = new Atom_cState_Org();

        /* 80 */
        public cAddress_Person m_cAddress_Person = new cAddress_Person();

        /* 81 */
        public cAddress_Org m_cAddress_Org = new cAddress_Org();

        /* 82 */
        public Atom_cAddress_Person m_Atom_cAddress_Person = new Atom_cAddress_Person();

        /* 83 */
        public Atom_cAddress_Org m_Atom_cAddress_Org = new Atom_cAddress_Org();

        /* 84 */
        public Price_Item m_Price_Item = new Price_Item();

        /* 85 */
        public Price_SimpleItem m_Price_SimpleItem = new Price_SimpleItem();

        /* 86 */
        public PriceList m_PriceList = new PriceList();

        /* 87 */
        public Currency m_Currency = new Currency();

        /* 88 */
        public BaseCurrency m_BaseCurrency = new BaseCurrency();

        /* 89 */
        public RateToBaseCurrency m_RateToBaseCurrency = new RateToBaseCurrency();

        /* 90 */
        public ExchangeRateSource m_ExchangeRateSource = new ExchangeRateSource();

        /* 91 */
        public Atom_PriceList m_Atom_PriceList = new Atom_PriceList();

        /* 92 */
        public PurchasePrice_Item m_PurchasePrice_Item = new PurchasePrice_Item();

        /* 93 */
        public Atom_Currency m_Atom_Currency = new Atom_Currency();

        /* 94 */
        public Atom_Price_Item m_Atom_Price_Item = new Atom_Price_Item();

        /* 95 */
        public DocInvoice_ShopB_Item m_DocInvoice_ShopB_Item = new DocInvoice_ShopB_Item();

        /* 96 */
        public PersonImage m_PersonImage = new PersonImage();

        /* 97 */
        public Unit m_Unit = new Unit();

        /* 98 */
        public Atom_Unit m_Atom_Unit = new Atom_Unit();

        /* 99 */
        public AccessR m_AccessR = new AccessR();

        /* 100 */
        public myOrganisation_Person_AccessR m_myOrganisation_Person_AccessR = new myOrganisation_Person_AccessR();

        /* 101 */
        public OrganisationData m_OrganisationData = new OrganisationData();

        /* 102 */
        public PurchasePrice m_PurchasePrice = new PurchasePrice();

        /* 103 */
        public Reference_Image m_Reference_Image = new Reference_Image();

        /* 104 */
        public Atom_OrganisationData m_Atom_OrganisationData = new Atom_OrganisationData();

        /* 105 */
        public Supplier m_Supplier = new Supplier();

        /* 106 */
        public Customer_Org m_Customer_Org = new Customer_Org();

        /* 107 */
        public Customer_Person m_Customer_Person = new Customer_Person();

        /* 108 */
        public Atom_Customer_Org m_Atom_Customer_Org = new Atom_Customer_Org();

        /* 109 */
        public Atom_Customer_Person m_Atom_Customer_Person = new Atom_Customer_Person();

        /* 110 */
        public PersonData m_PersonData = new PersonData();

        /* 111 */
        public PersonAccount m_PersonAccount = new PersonAccount();

        /* 112 */
        public Bank m_Bank = new Bank();

        /* 113 */
        public BankAccount m_BankAccount = new BankAccount();

        /* 114 */
        public OrganisationAccount m_OrganisationAccount = new OrganisationAccount();

        /* 115 */
        public JOURNAL_PriceList_Type m_JOURNAL_PriceList_Type = new JOURNAL_PriceList_Type();

        /* 116 */
        public JOURNAL_DocInvoice_Type m_JOURNAL_DocInvoice_Type = new JOURNAL_DocInvoice_Type();

        /* 117 */
        public JOURNAL_Item_Type m_JOURNAL_Item_Type = new JOURNAL_Item_Type();

        /* 118 */
        public JOURNAL_SimpleItem_Type m_JOURNAL_SimpleItem_Type = new JOURNAL_SimpleItem_Type();

        /* 119 */
        public JOURNAL_myOrganisation_Type m_JOURNAL_myOrganisation_Type = new JOURNAL_myOrganisation_Type();

        /* 120 */
        public JOURNAL_Person_Type m_JOURNAL_Person_Type = new JOURNAL_Person_Type();

        /* 121 */
        public JOURNAL_Customer_Person_Type m_JOURNAL_Customer_Person_Type = new JOURNAL_Customer_Person_Type();

        /* 122 */
        public JOURNAL_Customer_Org_Type m_JOURNAL_Customer_Org_Type = new JOURNAL_Customer_Org_Type();

        /* 123 */
        public JOURNAL_StockTake_Type m_JOURNAL_StockTake_Type = new JOURNAL_StockTake_Type();

        /* 124 */
        public JOURNAL_Taxation_Type m_JOURNAL_Taxation_Type = new JOURNAL_Taxation_Type();

        /* 125 */
        public JOURNAL_Stock_Type m_JOURNAL_Stock_Type = new JOURNAL_Stock_Type();

        /* 126 */
        public JOURNAL_DocInvoice m_JOURNAL_DocInvoice = new JOURNAL_DocInvoice();

        /* 127 */
        public JOURNAL_DocProformaInvoice m_JOURNAL_DocProformaInvoice = new JOURNAL_DocProformaInvoice();

        /* 128 */
        public JOURNAL_Item m_JOURNAL_Item = new JOURNAL_Item();

        /* 129 */
        public JOURNAL_SimpleItem m_JOURNAL_SimpleItem = new JOURNAL_SimpleItem();

        /* 130 */
        public JOURNAL_PriceList m_JOURNAL_PriceList = new JOURNAL_PriceList();

        /* 131 */
        public JOURNAL_myOrganisation m_JOURNAL_myOrganisation = new JOURNAL_myOrganisation();

        /* 132 */
        public JOURNAL_Person m_JOURNAL_Person = new JOURNAL_Person();

        /* 133 */
        public JOURNAL_Customer_Person m_JOURNAL_Customer_Person = new JOURNAL_Customer_Person();

        /* 134 */
        public JOURNAL_Customer_Person_Data m_JOURNAL_Customer_Person_Data = new JOURNAL_Customer_Person_Data();

        /* 135 */
        public JOURNAL_Customer_Person_Data_Image m_JOURNAL_Customer_Person_Data_Image = new JOURNAL_Customer_Person_Data_Image();

        /* 136 */
        public JOURNAL_Customer_Org m_JOURNAL_Customer_Org = new JOURNAL_Customer_Org();

        /* 137 */
        public JOURNAL_StockTake m_JOURNAL_StockTake = new JOURNAL_StockTake();

        /* 138 */
        public JOURNAL_Taxation m_JOURNAL_Taxation = new JOURNAL_Taxation();

        /* 139 */
        public JOURNAL_Stock m_JOURNAL_Stock = new JOURNAL_Stock();

        /* 140 */
        public SimpleItem_ParentGroup3 m_SimpleItem_ParentGroup3 = new SimpleItem_ParentGroup3();

        /* 141 */
        public SimpleItem_ParentGroup2 m_SimpleItem_ParentGroup2 = new SimpleItem_ParentGroup2();

        /* 142 */
        public SimpleItem_ParentGroup1 m_SimpleItem_ParentGroup1 = new SimpleItem_ParentGroup1();

        /* 143 */
        public Logo m_Logo = new Logo();

        /* 144 */
        public Atom_Logo m_Atom_Logo = new Atom_Logo();

        /* 145 */
        public Atom_cFirstName m_Atom_cFirstName = new Atom_cFirstName();

        /* 146 */
        public Atom_cLastName m_Atom_cLastName = new Atom_cLastName();

        /* 147 */
        public Atom_cCardType_Person m_Atom_cCardType_Person = new Atom_cCardType_Person();

        /* 148 */
        public Atom_cPhoneNumber_Person m_Atom_cPhoneNumber_Person = new Atom_cPhoneNumber_Person();

        /* 149 */
        public Atom_cGsmNumber_Person m_Atom_cGsmNumber_Person = new Atom_cGsmNumber_Person();

        /* 150 */
        public Atom_cEmail_Person m_Atom_cEmail_Person = new Atom_cEmail_Person();

        /* 151 */
        public Atom_PersonImage m_Atom_PersonImage = new Atom_PersonImage();

        /* 152 */
        public Office m_Office = new Office();

        /* 153 */
        public Atom_Computer m_Atom_Computer = new Atom_Computer();

        /* 154 */
        public WorkingPlace m_WorkingPlace = new WorkingPlace();

        /* 155 */
        public Atom_Office m_Atom_Office = new Atom_Office();

        /* 156 */
        public Atom_WorkingPlace m_Atom_WorkingPlace = new Atom_WorkingPlace();

        /* 157 */
        public Atom_WorkPeriod m_Atom_WorkPeriod = new Atom_WorkPeriod();

        /* 158 */
        public DeliveryType m_DeliveryType = new DeliveryType();

        /* 159 */
        public Delivery m_Delivery = new Delivery();

        /* 160 */
        public JOURNAL_Delivery_Type m_JOURNAL_Delivery_Type = new JOURNAL_Delivery_Type();

        /* 161 */
        public JOURNAL_Delivery m_JOURNAL_Delivery = new JOURNAL_Delivery();

        /* 162 */
        public Office_Data m_Office_Data = new Office_Data();

        /* 163 */
        public Atom_Office_Data m_Atom_Office_Data = new Atom_Office_Data();

        /* 164 */
        public Atom_WorkPeriod_TYPE m_Atom_WorkPeriod_TYPE = new Atom_WorkPeriod_TYPE();

        /* 165 */
        public Atom_WorkPeriod_Description m_Atom_WorkPeriod_Description = new Atom_WorkPeriod_Description();

        /* 166 */
        public doc_type m_doc_type = new doc_type();

        /* 167 */
        public doc m_doc = new doc();

        /* 168 */
        public JOURNAL_doc_Type m_JOURNAL_doc_Type = new JOURNAL_doc_Type();

        /* 169 */
        public JOURNAL_doc m_JOURNAL_doc = new JOURNAL_doc();

        /* 170 */
        public Language m_Language = new Language();

        /* 171 */
        public doc_page_type m_doc_page_type = new doc_page_type();

        /* 172 */
        public FVI_SLO_RealEstateBP m_FVI_SLO_RealEstateBP = new FVI_SLO_RealEstateBP();

        /* 173 */
        public FVI_SLO_Response m_FVI_SLO_Response = new FVI_SLO_Response();

        /* 174 */
        public Atom_FVI_SLO_RealEstateBP m_Atom_FVI_SLO_RealEstateBP = new Atom_FVI_SLO_RealEstateBP();

        /* 175 */
        public Notice m_Notice = new Notice();

        /* 176 */
        public Atom_ItemShopA_Image m_Atom_ItemShopA_Image = new Atom_ItemShopA_Image();

        /* 177 */
        public Atom_ItemShopA m_Atom_ItemShopA = new Atom_ItemShopA();

        /* 178 */
        public DocInvoice_ShopA_Item m_DocInvoice_ShopA_Item = new DocInvoice_ShopA_Item();

        /* 179 */
        public FVI_SLO_SalesBookInvoice m_FVI_SLO_SalesBookInvoice = new FVI_SLO_SalesBookInvoice();

        /* 180 */
        public DocProformaInvoice m_DocProformaInvoice = new DocProformaInvoice();

        /* 181 */
        public DocProformaInvoice_ShopC_Item m_DocProformaInvoice_ShopC_Item = new DocProformaInvoice_ShopC_Item();

        /* 182 */
        public DocProformaInvoice_ShopB_Item m_DocProformaInvoice_ShopB_Item = new DocProformaInvoice_ShopB_Item();

        /* 183 */
        public DocProformaInvoice_Notice m_DocProformaInvoice_Notice = new DocProformaInvoice_Notice();

        /* 184 */
        public DocProformaInvoice_Image m_DocProformaInvoice_Image = new DocProformaInvoice_Image();

        /* 185 */
        public DocProformaInvoice_ShopA_Item m_DocProformaInvoice_ShopA_Item = new DocProformaInvoice_ShopA_Item();

        /* 186 */
        public JOURNAL_myOrganisation_Person_AccessR_TYPE m_JOURNAL_myOrganisation_Person_AccessR_TYPE = new JOURNAL_myOrganisation_Person_AccessR_TYPE();

        /* 187 */
        public JOURNAL_myOrganisation_Person_AccessR m_JOURNAL_myOrganisation_Person_AccessR = new JOURNAL_myOrganisation_Person_AccessR();

        /* 188 */
        public JOURNAL_myOrganisation_Person_TYPE m_JOURNAL_myOrganisation_Person_TYPE = new JOURNAL_myOrganisation_Person_TYPE();

        /* 189 */
        public JOURNAL_myOrganisation_Person m_JOURNAL_myOrganisation_Person = new JOURNAL_myOrganisation_Person();

        /* 190 */
        public Atom_Bank m_Atom_Bank = new Atom_Bank();

        /* 191 */
        public Atom_BankAccount m_Atom_BankAccount = new Atom_BankAccount();

        /* 192 */
        public Atom_OrganisationAccount m_Atom_OrganisationAccount = new Atom_OrganisationAccount();

        /* 193 */
        public Atom_PersonData m_Atom_PersonData = new Atom_PersonData();

        /* 194 */
        public Atom_PersonAccount m_Atom_PersonAccount = new Atom_PersonAccount();

        /* 195 */
        public JOURNAL_Name m_JOURNAL_Name = new JOURNAL_Name();

        /* 196 */
        public JOURNAL_TableName m_JOURNAL_TableName = new JOURNAL_TableName();

        /* 197 */
        public JOURNAL_TYPE m_JOURNAL_TYPE = new JOURNAL_TYPE();

        /* 198 */
        public JOURNAL m_JOURNAL = new JOURNAL();

        /* 199 */
        public Atom_ElectronicDevice m_Atom_ElectronicDevice = new Atom_ElectronicDevice();

        /* 200 */
        public Trucking m_Trucking = new Trucking();

        /* 201 */
        public Purchase_Order m_Purchase_Order = new Purchase_Order();

        /* 202 */
        public StockTake m_StockTake = new StockTake();

        /* 203 */
        public Contact m_Contact = new Contact();

        /* 204 */
        public StockTake_AdditionalCost m_StockTake_AdditionalCost = new StockTake_AdditionalCost();

        /* 205 */
        public StockTakeCostName m_StockTakeCostName = new StockTakeCostName();

        /* 206 */
        public StockTakeCostDescription m_StockTakeCostDescription = new StockTakeCostDescription();
    }
}
