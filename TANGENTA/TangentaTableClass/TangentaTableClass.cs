using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBConnectionControl40;
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

    public class PIN:DB_Int32
    {

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
        public PIN PIN = new PIN();
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

    public class NoticeText : DB_varchar_2000
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

    public class Password:DB_varbinary_max
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

    public class TaxPayer:DB_bit
    {

    }

    public class Comment : DB_varchar_2000
    {

    }

    public class Comment1
    {
        public ID ID = new ID();
        public Comment Comment = new Comment();
    }

    public class Atom_Comment1
    {
        public ID ID = new ID();
        public Comment Comment = new Comment();
    }

    public class Organisation
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Tax_ID Tax_ID = new Tax_ID();
        public Registration_ID Registration_ID = new Registration_ID();
        public TaxPayer TaxPayer = new TaxPayer();
        public Comment1 m_Comment1 = new Comment1();
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
        public TaxPayer TaxPayer = new TaxPayer();
        public Atom_Comment1 m_Atom_Comment1 = new Atom_Comment1();
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
        public Person m_Person = new Person();
        public Active Active = new Active();
        public Job Job = new Job();
        public Description Description = new Description();
        public Office m_Office = new Office();
    }

    public class myOrganisation_Person_SingleUser
    {
        public ID ID = new ID();
        public myOrganisation_Person m_myOrganisation_Person = new myOrganisation_Person();
        public ElectronicDevice m_ElectronicDevice = new ElectronicDevice();
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

    public class Atom_ComputerName
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
    }

    public class Atom_ComputerUserName
    {
        public ID ID = new ID();
        public UserName UserName = new UserName();
        public Description Description = new Description();
    }

    public class Atom_MAC_address
    {
        public ID ID = new ID();
        public MAC_address MAC_address = new MAC_address();
        public Description Description = new Description();
    }

    public class Atom_IP_address
    {
        public ID ID = new ID();
        public IP_address IP_address = new IP_address();
        public Description Description = new Description();
    }

    public class Atom_Computer
    {
        public ID ID = new ID();
        public Atom_ComputerName m_Atom_ComputerName = new Atom_ComputerName();
        public Atom_ComputerUserName m_Atom_ComputerUserName = new Atom_ComputerUserName();
        public Atom_MAC_address m_Atom_MAC_address = new Atom_MAC_address();
        public Atom_IP_address m_Atom_IP_address = new Atom_IP_address();
        public Description Description = new Description();
    }

    public class ElectronicDevice
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Atom_Computer m_Atom_Computer = new Atom_Computer();
        public Office m_Office = new Office();
        public Description Description = new Description();
    }

    public class Atom_ElectronicDevice
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Atom_Computer m_Atom_Computer = new Atom_Computer();
        public Atom_Office m_Atom_Office = new Atom_Office();
        public Description Description = new Description();
    }

    public class SettingsType
    {
        public ID ID = new ID();
        public Typ Typ = new Typ();
        public Description Description = new Description();
    }

    public class SettingsVal:DB_varchar_264
    {

    }

    public class SettingsValue
    {
        public ID ID = new ID();
        public SettingsVal SettingsVal = new SettingsVal();
    }

    public class ProgramModule
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
    }

    public class PropertiesSettings
    {
        public ID ID = new ID();
        public ElectronicDevice m_ElectronicDevice = new ElectronicDevice();
        public ProgramModule m_ProgramModule = new ProgramModule();
        public myOrganisation_Person m_myOrganisation_Person = new myOrganisation_Person();
        public Name Name = new Name();
        public SettingsType m_SettingsType = new SettingsType();
        public SettingsValue m_SettingsValue = new SettingsValue();
        public Description Description = new Description();
        public TestEnvironment TestEnvironment = new TestEnvironment();
    }


    public class Atom_WorkArea
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
        public WorkAreaImage m_WorkAreaImage = new WorkAreaImage();
        public Active Active = new Active();
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
        public Job Job = new Job();
        public Description Description = new Description();
    }

    public class Atom_WorkAreaImage
    {
        public ID ID = new ID();
        public Image_Hash Image_Hash = new Image_Hash();
        public Image_Data Image_Data = new Image_Data();
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

    public class Atom_PriceList_Name
    {
        public ID ID = new ID();
        public Name Name = new Name();
    }


    public class Atom_PriceList
    {
        public ID ID = new ID();
        public Atom_Currency m_Atom_Currency = new Atom_Currency();
        public Atom_PriceList_Name m_Atom_PriceList_Name = new Atom_PriceList_Name();
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

    public class PriceList_Name
    {
        public ID ID = new ID();
        public Name Name = new Name();
    }

    public class PriceList
    {
        public ID ID = new ID();
        public PriceList_Name m_PriceList_Name = new PriceList_Name();
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
        public Code Code = new Code();
    }

    public class Identification:DB_varchar_64
    {

    }
    public class PaymentType
    {
        public ID ID = new ID();
        public Identification Identification = new Identification();
        public Name Name = new Name();
    }

    public class MethodOfPayment_DI
    {
        public ID ID = new ID();
        public PaymentType m_PaymentType  = new PaymentType();
        public Atom_BankAccount m_Atom_BankAccount = new Atom_BankAccount();
    }

 

    public class MethodOfPayment_DPI
    {
        public ID ID = new ID();
        public PaymentType m_PaymentType = new PaymentType();
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

    public class TermsOfPayment_Default
    {
        public ID ID = new ID();
        public TermsOfPayment m_TermsOfPayment = new TermsOfPayment();
        public Atom_ElectronicDevice m_Atom_ElectronicDevice = new Atom_ElectronicDevice();
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
        public FinancialYear FinancialYear = new FinancialYear();
        public NumberInFinancialYear NumberInFinancialYear = new NumberInFinancialYear();
        public Draft Draft = new Draft();
        public DraftNumber DraftNumber = new DraftNumber();
        public NetSum NetSum = new NetSum();
        public Discount Discount = new Discount();
        public EndSum EndSum = new EndSum();
        public TaxSum TaxSum = new TaxSum();
        public GrossSum GrossSum = new GrossSum();
        public Atom_Currency m_Atom_Currency = new Atom_Currency();
        public Atom_Customer_Person m_Atom_Customer_Person = new Atom_Customer_Person();
        public Atom_Customer_Org m_Atom_Customer_Org = new Atom_Customer_Org();
        public Paid Paid = new Paid();
        public Storno Storno = new Storno();
        public Invoice_Reference_ID Invoice_Reference_ID = new Invoice_Reference_ID();
        public Invoice_Reference_Type Invoice_Reference_Type = new Invoice_Reference_Type();
    }

    public class DocInvoiceAddOn
    {
        public ID ID = new ID();
        public DocInvoice m_DocInvoice = new DocInvoice();
        public IssueDate IssueDate = new IssueDate();
        public TermsOfPayment m_TermsOfPayment = new TermsOfPayment();
        public PaymentDeadline PaymentDeadline = new PaymentDeadline();
        public MethodOfPayment_DI m_MethodOfPayment_DI = new MethodOfPayment_DI();
        public Atom_Warranty m_Atom_Warranty = new Atom_Warranty();
        public Atom_Notice m_Atom_Notice = new Atom_Notice();
        public Doc_ImageLib m_Doc_ImageLib = new Doc_ImageLib();
    }

    public class DocProformaInvoice
    {
        public ID ID = new ID();
        public FinancialYear FinancialYear = new FinancialYear();
        public NumberInFinancialYear NumberInFinancialYear = new NumberInFinancialYear();
        public Draft Draft = new Draft();
        public DraftNumber DraftNumber = new DraftNumber();
        public NetSum NetSum = new NetSum();
        public Discount Discount = new Discount();
        public EndSum EndSum = new EndSum();
        public TaxSum TaxSum = new TaxSum();
        public GrossSum GrossSum = new GrossSum();
        public Atom_Currency m_Atom_Currency = new Atom_Currency();
        public Atom_Customer_Person m_Atom_Customer_Person = new Atom_Customer_Person();
        public Atom_Customer_Org m_Atom_Customer_Org = new Atom_Customer_Org();
    }

    public class DocProformaInvoiceAddOn
    {
        public ID ID = new ID();
        public DocProformaInvoice m_DocProformaInvoice = new DocProformaInvoice();
        public IssueDate IssueDate = new IssueDate();
        public DocDuration DocDuration = new DocDuration();
        public DocDurationType DocDurationType = new DocDurationType(); // 0 = DocDuration is in months after IssueDate; 1,2 DocDuration is in days after IssueDate
        public TermsOfPayment m_TermsOfPayment = new TermsOfPayment();
        public MethodOfPayment_DPI m_MethodOfPayment_DPI = new MethodOfPayment_DPI();
        public Atom_Warranty m_Atom_Warranty = new Atom_Warranty();
        public Atom_Notice m_Atom_Notice = new Atom_Notice();
        public Doc_ImageLib m_Doc_ImageLib = new Doc_ImageLib();
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
        public NoticeText NoticeText = new NoticeText();
    }

    public class Atom_Notice
    {
        public ID ID = new ID();
        public NoticeText NoticeText = new NoticeText();
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

    public class JOURNAL_Atom_WorkPeriod_TYPE
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
    }

    public class JOURNAL_Atom_WorkPeriod
    {
        public ID ID = new ID();
        public Atom_WorkPeriod m_Atom_WorkPeriod = new Atom_WorkPeriod();
        public EventTime EventTime = new EventTime();
        public JOURNAL_Atom_WorkPeriod_TYPE m_JOURNAL_Atom_WorkPeriod_TYPE = new JOURNAL_Atom_WorkPeriod_TYPE();
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

    public class ChangePasswordOnFirstLogin:DB_bit {    }
    public class Time_When_AdministratorSetsPassword : DB_DateTime { }
    public class Administrator_LoginUsers_ID : DB_Int64 { } // reference to administrator who added the user
    public class Time_When_UserSetsItsOwnPassword_FirstTime: DB_DateTime { }
    public class Time_When_UserSetsItsOwnPassword_LastTime : DB_DateTime { }
    public class PasswordNeverExpires : DB_bit { }
    public class Maximum_password_age_in_days : DB_Int32 { }
    public class NotActiveAfterPasswordExpires : DB_bit { }
    public class PrivilegesLevel : DB_Int32 { }
    public class AttemptTime : DB_DateTime { }
    public class Username_does_not_exist : DB_bit { }
    public class Password_wrong : DB_bit { }
    public class Enabled : DB_bit { }
    public class Role : DB_varchar_64 { }

    public class LoginUsers
    {
        public ID ID = new ID();
        public myOrganisation_Person m_myOrganisation_Person = new myOrganisation_Person();
        public Enabled Enabled = new Enabled();
        public UserName UserName = new UserName();
        public Password Password = new Password();
        public ChangePasswordOnFirstLogin ChangePasswordOnFirstLogin = new ChangePasswordOnFirstLogin();
        public Time_When_AdministratorSetsPassword Time_When_AdministratorSetsPassword = new Time_When_AdministratorSetsPassword();
        public Administrator_LoginUsers_ID Administrator_LoginUsers_ID = new Administrator_LoginUsers_ID();
        public Time_When_UserSetsItsOwnPassword_FirstTime Time_When_UserSetsItsOwnPassword_FirstTime = new Time_When_UserSetsItsOwnPassword_FirstTime();
        public Time_When_UserSetsItsOwnPassword_LastTime Time_When_UserSetsItsOwnPassword_LastTime = new Time_When_UserSetsItsOwnPassword_LastTime();
        public PasswordNeverExpires PasswordNeverExpires = new PasswordNeverExpires();
        public Maximum_password_age_in_days Maximum_password_age_in_days = new Maximum_password_age_in_days();
        public NotActiveAfterPasswordExpires NotActiveAfterPasswordExpires = new NotActiveAfterPasswordExpires();
        public LoginUsers_ParentGroup1 m_LoginUsers_ParentGroup1 = new LoginUsers_ParentGroup1();
    }

    public class LoginTag_TYPE
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();

    }

    public class LoginKeyValue:DB_varchar_264
    {

    }

    public class LoginTag
    {
        public ID ID = new ID();
        public LoginUsers m_LoginUsers = new LoginUsers();
        public LoginTag_TYPE m_LoginTag_TYPE = new LoginTag_TYPE();
        public LoginKeyValue LoginKeyValue = new LoginKeyValue();
        public Enabled Enabled = new Enabled();
    }

    public class LoginRoles
    {
        public ID ID = new ID();
        public Role Role = new Role();
    }

    public class LoginUsersAndLoginRoles
    {
        public ID ID = new ID();
        public LoginUsers m_LoginUsers = new LoginUsers();
        public LoginRoles m_LoginRoles = new LoginRoles();
    }


    public class LoginSession
    {
        public ID ID = new ID();
        public LoginUsers m_LoginUsers = new LoginUsers();
        public Atom_WorkPeriod m_Atom_WorkPeriod = new Atom_WorkPeriod();
    }

    public class LoginFailed
    {
        public ID ID = new ID();
        public UserName UserName = new UserName();
        public AttemptTime AttemptTime = new AttemptTime();
        public Username_does_not_exist Username_does_not_exist = new Username_does_not_exist();
        public Password_wrong Password_wrong = new Password_wrong();
        public Atom_Computer m_Atom_Computer = new Atom_Computer();
    }

    public class LoginManagerEvent
    {
        public ID ID = new ID();
        public Name Name = new Name();
    }

    public class LoginManagerJournal
    {
        public ID ID = new ID();
        public LoginUsers m_LoginUsers = new LoginUsers();
        public LoginManagerEvent m_LoginManagerEvent = new LoginManagerEvent();
        public EventTime EventTime = new EventTime();
    }

    public class StartDate : DB_DateTime
    {

    }

    public class EndDate : DB_DateTime
    {

    }

    public class ParameterValue :DB_varchar_64
    {

    }

    public class CaseParameter
    {
        public ID ID = new ID();
        public ParameterValue ParameterValue  = new ParameterValue();
        public Description Description = new Description();
    }

    public class CaseItem
    {
        public ID ID = new ID();
        public Name Name  = new Name();
        public CaseParameter CaseParameter = new CaseParameter();
        public Description Description = new Description();
        public StartDate StartDate = new StartDate();
        public EndDate EndDate = new EndDate();
        public Active Active = new Active();
    }



    public class EntryTime:DB_DateTime
    {

    }

    public class CustomerCase
    {
        public ID ID = new ID();
        public Person m_Person = new Person();
        public Organisation m_Organisation = new Organisation();
        public EntryTime EntryTime = new EntryTime();
        public CaseItem m_CaseItem = new CaseItem();
        public Description Description = new Description();
    }


    public class CaseImage
    {
        public ID ID = new ID();
        public CustomerCase m_CustomerCase = new CustomerCase();
        public Image_Hash Image_Hash = new Image_Hash();
        public Image_Data Image_Data = new Image_Data();
        public Description Description = new Description();
    }

    public class WorkAreaImage
    {
        public ID ID = new ID();
        public Image_Hash Image_Hash = new Image_Hash();
        public Image_Data Image_Data = new Image_Data();
        public Description Description = new Description();
    }

    public class WorkArea
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
        public WorkAreaImage m_WorkAreaImage = new WorkAreaImage();
        public Active Active = new Active();
        public WorkArea_ParentGroup1 m_WorkArea_ParentGroup1 = new WorkArea_ParentGroup1();
    }

    public class DocInvoice_Atom_WorkArea
    {
        public ID ID = new ID();
        public DocInvoice m_DocInvoice = new DocInvoice();
        public Atom_WorkArea m_Atom_WorkArea = new Atom_WorkArea();
    }

    public class WorkArea_ParentGroup3
    {
        public ID ID = new ID();
        public Name Name = new Name();
    }

    public class WorkArea_ParentGroup2
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public WorkArea_ParentGroup3 m_WorkArea_ParentGroup3 = new WorkArea_ParentGroup3();
    }

    public class WorkArea_ParentGroup1
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public WorkArea_ParentGroup2 m_WorkArea_ParentGroup2 = new WorkArea_ParentGroup2();
    }

    public class LoginUsers_ParentGroup3
    {
        public ID ID = new ID();
        public Name Name = new Name();
    }

    public class LoginUsers_ParentGroup2
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public LoginUsers_ParentGroup3 m_LoginUsers_ParentGroup3 = new LoginUsers_ParentGroup3();
    }

    public class LoginUsers_ParentGroup1
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public LoginUsers_ParentGroup2 m_LoginUsers_ParentGroup2 = new LoginUsers_ParentGroup2();
    }

    public class DBSource:DB_varchar_264
    {

    }

    public class Current_DocInvoice_ID
    {
        public ID ID = new ID();
        public DocInvoice m_DocInvoice = new DocInvoice();
        public DBSource DBSource = new DBSource();
        public myOrganisation_Person m_myOrganisation_Person = new myOrganisation_Person();
        public ElectronicDevice m_ElectronicDevice = new ElectronicDevice();
    }

    public class Current_DocProformaInvoice_ID
    {
        public ID ID = new ID();
        public DocProformaInvoice m_DocProformaInvoice = new DocProformaInvoice();
        public DBSource DBSource = new DBSource();
        public myOrganisation_Person m_myOrganisation_Person = new myOrganisation_Person();
        public ElectronicDevice m_ElectronicDevice = new ElectronicDevice();
    }

    public class DocInvoice_ShopC_Item_AdditionalData_TYPE
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public Description Description = new Description();
    }

    public class DocInvoice_ShopC_Item_AdditionalData
    {
        public ID ID = new ID();
        public DocInvoice_ShopC_Item_AdditionalData_TYPE m_DocInvoice_ShopC_Item_AdditionalData_TYPE = new DocInvoice_ShopC_Item_AdditionalData_TYPE();
        public DocInvoice_ShopC_Item m_DocInvoice_Shopc_Item = new DocInvoice_ShopC_Item();
        public Name Name = new Name();
        public Description Description = new Description();
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
        public MethodOfPayment_DI m_MethodOfPayment_DI = new MethodOfPayment_DI();

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
        public Doc_ImageLib m_Doc_ImageLib = new Doc_ImageLib();

        /* 47 */
        public DocInvoiceAddOn m_DocInvoiceAddOn = new DocInvoiceAddOn();

        /* 48 */
        public TermsOfPayment m_TermsOfPayment = new TermsOfPayment();

        /* 49 */
        public myOrganisation_Person m_myOrganisation_Person = new myOrganisation_Person();

        /* 50 */
        public DocInvoice_ShopC_Item m_DocInvoice_ShopC_Item = new DocInvoice_ShopC_Item();

        /* 51 */
        public Atom_myOrganisation_Person m_Atom_myOrganisation_Person = new Atom_myOrganisation_Person();

        /* 52 */
        public Atom_myOrganisation m_Atom_myOrganisation = new Atom_myOrganisation();

        /* 53 */
        public Atom_Person m_BuyerAtom_Person = new Atom_Person();

        /* 54 */
        public Atom_Organisation m_Atom_Organisation = new Atom_Organisation();

        /* 55 */
        public SimpleItem_Image m_SimpleItem_Image = new SimpleItem_Image();

        /* 56 */
        public Item_Image m_Item_Image = new Item_Image();

        /* 57 */
        public Expiry m_Expiry = new Expiry();

        /* 58 */
        public Warranty m_Warranty = new Warranty();

        /* 59 */
        public Atom_Expiry m_Atom_Expiry = new Atom_Expiry();

        /* 60 */
        public Atom_Warranty m_Atom_Warranty = new Atom_Warranty();

        /* 61 */
        public Item_ParentGroup3 m_Item_ParentGroup3 = new Item_ParentGroup3();

        /* 62 */
        public Item_ParentGroup2 m_Item_ParentGroup2 = new Item_ParentGroup2();

        /* 63 */
        public Item_ParentGroup1 m_Item_ParentGroup1 = new Item_ParentGroup1();

        /* 64 */
        public Stock_AddressLevel3 m_Stock_AddressLevel3 = new Stock_AddressLevel3();

        /* 65 */
        public Stock_AddressLevel2 m_Stock_AddressLevel2 = new Stock_AddressLevel2();

        /* 66 */
        public Stock_AddressLevel1 m_Stock_AddressLevel1 = new Stock_AddressLevel1();

        /* 67 */
        public Atom_cStreetName_Person m_Atom_cStreetName_Person = new Atom_cStreetName_Person();

        /* 68 */
        public Atom_cHouseNumber_Person m_Atom_cHouseNumber_Person = new Atom_cHouseNumber_Person();

        /* 69 */
        public Atom_cCity_Person m_Atom_cCity_Person = new Atom_cCity_Person();

        /* 70 */
        public Atom_cZIP_Person m_Atom_cZIP_Person = new Atom_cZIP_Person();

        /* 71 */
        public Atom_cCountry_Person m_Atom_cCountry_Person = new Atom_cCountry_Person();

        /* 72 */
        public Atom_cState_Person m_Atom_cState_Person = new Atom_cState_Person();

        /* 73 */
        public Atom_cStreetName_Org m_Atom_cStreetName_Org = new Atom_cStreetName_Org();

        /* 74 */
        public Atom_cHouseNumber_Org m_Atom_cHouseNumber_Org = new Atom_cHouseNumber_Org();

        /* 75 */
        public Atom_cCity_Org m_Atom_cCity_Org = new Atom_cCity_Org();

        /* 76 */
        public Atom_cZIP_Org m_Atom_cZIP_Org = new Atom_cZIP_Org();

        /* 77 */
        public Atom_cCountry_Org m_Atom_cCountry_Org = new Atom_cCountry_Org();

        /* 78 */
        public Atom_cState_Org m_Atom_cState_Org = new Atom_cState_Org();

        /* 79 */
        public cAddress_Person m_cAddress_Person = new cAddress_Person();

        /* 80 */
        public cAddress_Org m_cAddress_Org = new cAddress_Org();

        /* 81 */
        public Atom_cAddress_Person m_Atom_cAddress_Person = new Atom_cAddress_Person();

        /* 82 */
        public Atom_cAddress_Org m_Atom_cAddress_Org = new Atom_cAddress_Org();

        /* 83 */
        public Price_Item m_Price_Item = new Price_Item();

        /* 84 */
        public Price_SimpleItem m_Price_SimpleItem = new Price_SimpleItem();

        /* 85 */
        public PriceList m_PriceList = new PriceList();

        /* 86 */
        public Currency m_Currency = new Currency();

        /* 87 */
        public BaseCurrency m_BaseCurrency = new BaseCurrency();

        /* 88 */
        public RateToBaseCurrency m_RateToBaseCurrency = new RateToBaseCurrency();

        /* 89 */
        public ExchangeRateSource m_ExchangeRateSource = new ExchangeRateSource();

        /* 90 */
        public Atom_PriceList m_Atom_PriceList = new Atom_PriceList();

        /* 91 */
        public PurchasePrice_Item m_PurchasePrice_Item = new PurchasePrice_Item();

        /* 92 */
        public Atom_Currency m_Atom_Currency = new Atom_Currency();

        /* 93 */
        public Atom_Price_Item m_Atom_Price_Item = new Atom_Price_Item();

        /* 94 */
        public DocInvoice_ShopB_Item m_DocInvoice_ShopB_Item = new DocInvoice_ShopB_Item();

        /* 95 */
        public PersonImage m_PersonImage = new PersonImage();

        /* 96 */
        public Unit m_Unit = new Unit();

        /* 97 */
        public Atom_Unit m_Atom_Unit = new Atom_Unit();

        /* 98 */
        public OrganisationData m_OrganisationData = new OrganisationData();

        /* 99 */
        public PurchasePrice m_PurchasePrice = new PurchasePrice();

        /* 100 */
        public Reference_Image m_Reference_Image = new Reference_Image();

        /* 101 */
        public Atom_OrganisationData m_Atom_OrganisationData = new Atom_OrganisationData();

        /* 102 */
        public Supplier m_Supplier = new Supplier();

        /* 103 */
        public Customer_Org m_Customer_Org = new Customer_Org();

        /* 104 */
        public Customer_Person m_Customer_Person = new Customer_Person();

        /* 105 */
        public Atom_Customer_Org m_Atom_Customer_Org = new Atom_Customer_Org();

        /* 106 */
        public Atom_Customer_Person m_Atom_Customer_Person = new Atom_Customer_Person();

        /* 107 */
        public PersonData m_PersonData = new PersonData();

        /* 108 */
        public PersonAccount m_PersonAccount = new PersonAccount();

        /* 109 */
        public Bank m_Bank = new Bank();

        /* 110 */
        public BankAccount m_BankAccount = new BankAccount();

        /* 111 */
        public OrganisationAccount m_OrganisationAccount = new OrganisationAccount();

        /* 112 */
        public JOURNAL_PriceList_Type m_JOURNAL_PriceList_Type = new JOURNAL_PriceList_Type();

        /* 113 */
        public JOURNAL_DocInvoice_Type m_JOURNAL_DocInvoice_Type = new JOURNAL_DocInvoice_Type();

        /* 114 */
        public JOURNAL_Item_Type m_JOURNAL_Item_Type = new JOURNAL_Item_Type();

        /* 115 */
        public JOURNAL_SimpleItem_Type m_JOURNAL_SimpleItem_Type = new JOURNAL_SimpleItem_Type();

        /* 116 */
        public JOURNAL_myOrganisation_Type m_JOURNAL_myOrganisation_Type = new JOURNAL_myOrganisation_Type();

        /* 117 */
        public JOURNAL_Person_Type m_JOURNAL_Person_Type = new JOURNAL_Person_Type();

        /* 118 */
        public JOURNAL_Customer_Person_Type m_JOURNAL_Customer_Person_Type = new JOURNAL_Customer_Person_Type();

        /* 119 */
        public JOURNAL_Customer_Org_Type m_JOURNAL_Customer_Org_Type = new JOURNAL_Customer_Org_Type();

        /* 120 */
        public JOURNAL_StockTake_Type m_JOURNAL_StockTake_Type = new JOURNAL_StockTake_Type();

        /* 121 */
        public JOURNAL_Taxation_Type m_JOURNAL_Taxation_Type = new JOURNAL_Taxation_Type();

        /* 122 */
        public JOURNAL_Stock_Type m_JOURNAL_Stock_Type = new JOURNAL_Stock_Type();

        /* 123 */
        public JOURNAL_DocInvoice m_JOURNAL_DocInvoice = new JOURNAL_DocInvoice();

        /* 124 */
        public JOURNAL_DocProformaInvoice m_JOURNAL_DocProformaInvoice = new JOURNAL_DocProformaInvoice();

        /* 125 */
        public JOURNAL_Item m_JOURNAL_Item = new JOURNAL_Item();

        /* 126 */
        public JOURNAL_SimpleItem m_JOURNAL_SimpleItem = new JOURNAL_SimpleItem();

        /* 127 */
        public JOURNAL_PriceList m_JOURNAL_PriceList = new JOURNAL_PriceList();

        /* 128 */
        public JOURNAL_myOrganisation m_JOURNAL_myOrganisation = new JOURNAL_myOrganisation();

        /* 129 */
        public JOURNAL_Person m_JOURNAL_Person = new JOURNAL_Person();

        /* 130 */
        public JOURNAL_Customer_Person m_JOURNAL_Customer_Person = new JOURNAL_Customer_Person();

        /* 131 */
        public JOURNAL_Customer_Person_Data m_JOURNAL_Customer_Person_Data = new JOURNAL_Customer_Person_Data();

        /* 132 */
        public JOURNAL_Customer_Person_Data_Image m_JOURNAL_Customer_Person_Data_Image = new JOURNAL_Customer_Person_Data_Image();

        /* 133 */
        public JOURNAL_Customer_Org m_JOURNAL_Customer_Org = new JOURNAL_Customer_Org();

        /* 134 */
        public JOURNAL_StockTake m_JOURNAL_StockTake = new JOURNAL_StockTake();

        /* 135 */
        public JOURNAL_Taxation m_JOURNAL_Taxation = new JOURNAL_Taxation();

        /* 136 */
        public JOURNAL_Stock m_JOURNAL_Stock = new JOURNAL_Stock();

        /* 137 */
        public SimpleItem_ParentGroup3 m_SimpleItem_ParentGroup3 = new SimpleItem_ParentGroup3();

        /* 138 */
        public SimpleItem_ParentGroup2 m_SimpleItem_ParentGroup2 = new SimpleItem_ParentGroup2();

        /* 139 */
        public SimpleItem_ParentGroup1 m_SimpleItem_ParentGroup1 = new SimpleItem_ParentGroup1();

        /* 140 */
        public Logo m_Logo = new Logo();

        /* 141 */
        public Atom_Logo m_Atom_Logo = new Atom_Logo();

        /* 142 */
        public Atom_cFirstName m_Atom_cFirstName = new Atom_cFirstName();

        /* 143 */
        public Atom_cLastName m_Atom_cLastName = new Atom_cLastName();

        /* 144 */
        public Atom_cCardType_Person m_Atom_cCardType_Person = new Atom_cCardType_Person();

        /* 145 */
        public Atom_cPhoneNumber_Person m_Atom_cPhoneNumber_Person = new Atom_cPhoneNumber_Person();

        /* 146 */
        public Atom_cGsmNumber_Person m_Atom_cGsmNumber_Person = new Atom_cGsmNumber_Person();

        /* 147 */
        public Atom_cEmail_Person m_Atom_cEmail_Person = new Atom_cEmail_Person();

        /* 148 */
        public Atom_PersonImage m_Atom_PersonImage = new Atom_PersonImage();

        /* 149 */
        public Office m_Office = new Office();

        /* 150 */
        public Atom_Computer m_Atom_Computer = new Atom_Computer();

        /* 151 */
        public Atom_WorkArea m_Atom_WorkArea = new Atom_WorkArea();

        /* 152 */
        public Atom_Office m_Atom_Office = new Atom_Office();

        /* 153 */
        public Atom_WorkAreaImage m_Atom_WorkAreaImage = new Atom_WorkAreaImage();

        /* 154 */
        public Atom_WorkPeriod m_Atom_WorkPeriod = new Atom_WorkPeriod();

        /* 155 */
        public DeliveryType m_DeliveryType = new DeliveryType();

        /* 156 */
        public Delivery m_Delivery = new Delivery();

        /* 157 */
        public JOURNAL_Delivery_Type m_JOURNAL_Delivery_Type = new JOURNAL_Delivery_Type();

        /* 158 */
        public JOURNAL_Delivery m_JOURNAL_Delivery = new JOURNAL_Delivery();

        /* 159 */
        public Office_Data m_Office_Data = new Office_Data();

        /* 160 */
        public Atom_Office_Data m_Atom_Office_Data = new Atom_Office_Data();

        /* 161 */
        public Atom_WorkPeriod_TYPE m_Atom_WorkPeriod_TYPE = new Atom_WorkPeriod_TYPE();

        /* 162 */
        public Atom_WorkPeriod_Description m_Atom_WorkPeriod_Description = new Atom_WorkPeriod_Description();

        /* 163 */
        public doc_type m_doc_type = new doc_type();

        /* 164 */
        public doc m_doc = new doc();

        /* 165 */
        public JOURNAL_doc_Type m_JOURNAL_doc_Type = new JOURNAL_doc_Type();

        /* 166 */
        public JOURNAL_doc m_JOURNAL_doc = new JOURNAL_doc();

        /* 167 */
        public Language m_Language = new Language();

        /* 168 */
        public doc_page_type m_doc_page_type = new doc_page_type();

        /* 169 */
        public FVI_SLO_RealEstateBP m_FVI_SLO_RealEstateBP = new FVI_SLO_RealEstateBP();

        /* 170 */
        public FVI_SLO_Response m_FVI_SLO_Response = new FVI_SLO_Response();

        /* 171 */
        public Atom_FVI_SLO_RealEstateBP m_Atom_FVI_SLO_RealEstateBP = new Atom_FVI_SLO_RealEstateBP();

        /* 172 */
        public Notice m_Notice = new Notice();

        /* 173 */
        public Atom_ItemShopA_Image m_Atom_ItemShopA_Image = new Atom_ItemShopA_Image();

        /* 174 */
        public Atom_ItemShopA m_Atom_ItemShopA = new Atom_ItemShopA();

        /* 175 */
        public DocInvoice_ShopA_Item m_DocInvoice_ShopA_Item = new DocInvoice_ShopA_Item();

        /* 176 */
        public FVI_SLO_SalesBookInvoice m_FVI_SLO_SalesBookInvoice = new FVI_SLO_SalesBookInvoice();

        /* 177 */
        public DocProformaInvoice m_DocProformaInvoice = new DocProformaInvoice();

        /* 178 */
        public DocProformaInvoice_ShopC_Item m_DocProformaInvoice_ShopC_Item = new DocProformaInvoice_ShopC_Item();

        /* 179 */
        public DocProformaInvoice_ShopB_Item m_DocProformaInvoice_ShopB_Item = new DocProformaInvoice_ShopB_Item();

        /* 180 */
        public DocProformaInvoiceAddOn m_DocProformaInvoiceAddOn = new DocProformaInvoiceAddOn();

        /* 181 */
        public DocProformaInvoice_ShopA_Item m_DocProformaInvoice_ShopA_Item = new DocProformaInvoice_ShopA_Item();

        /* 182 */
        public JOURNAL_myOrganisation_Person_TYPE m_JOURNAL_myOrganisation_Person_TYPE = new JOURNAL_myOrganisation_Person_TYPE();

        /* 183 */
        public JOURNAL_myOrganisation_Person m_JOURNAL_myOrganisation_Person = new JOURNAL_myOrganisation_Person();

        /* 184 */
        public Atom_Bank m_Atom_Bank = new Atom_Bank();

        /* 185 */
        public Atom_BankAccount m_Atom_BankAccount = new Atom_BankAccount();

        /* 186 */
        public Atom_OrganisationAccount m_Atom_OrganisationAccount = new Atom_OrganisationAccount();

        /* 187 */
        public Atom_PersonData m_Atom_PersonData = new Atom_PersonData();

        /* 188 */
        public Atom_PersonAccount m_Atom_PersonAccount = new Atom_PersonAccount();

        /* 189 */
        public JOURNAL_Name m_JOURNAL_Name = new JOURNAL_Name();

        /* 190 */
        public JOURNAL_TableName m_JOURNAL_TableName = new JOURNAL_TableName();

        /* 191 */
        public JOURNAL_TYPE m_JOURNAL_TYPE = new JOURNAL_TYPE();

        /* 192 */
        public JOURNAL m_JOURNAL = new JOURNAL();

        /* 193 */
        public ElectronicDevice m_ElectronicDevice = new ElectronicDevice();

        /* 194 */
        public Trucking m_Trucking = new Trucking();

        /* 195 */
        public Purchase_Order m_Purchase_Order = new Purchase_Order();

        /* 196 */
        public StockTake m_StockTake = new StockTake();

        /* 197 */
        public Contact m_Contact = new Contact();

        /* 198 */
        public StockTake_AdditionalCost m_StockTake_AdditionalCost = new StockTake_AdditionalCost();

        /* 199 */
        public StockTakeCostName m_StockTakeCostName = new StockTakeCostName();

        /* 200 */
        public StockTakeCostDescription m_StockTakeCostDescription = new StockTakeCostDescription();

        /* 201 */
        public PaymentType m_PaymentType = new PaymentType();

        /* 202 */
        public MethodOfPayment_DPI m_MethodOfPayment_DPI = new MethodOfPayment_DPI();

        /* 203 */
        public Atom_Notice m_Atom_Notice = new Atom_Notice();

        /* 204 */
        public Comment1 m_Comment1 = new Comment1();

        /* 205 */
        public Atom_Comment1 m_Atom_Comment1 = new Atom_Comment1();

        /* 206 */
        public LoginUsers m_LoginUsers = new LoginUsers();

        /* 207 */
        public LoginRoles m_LoginRoles = new LoginRoles();

        /* 208 */
        public LoginUsersAndLoginRoles m_LoginUsersAndLoginRoles = new LoginUsersAndLoginRoles();

        /* 209 */
        public LoginSession m_LoginSession = new LoginSession();

        /* 210 */
        public LoginFailed m_LoginFailed = new LoginFailed();

        /* 211 */
        public LoginManagerEvent m_LoginManagerEvent = new LoginManagerEvent();

        /* 212 */
        public LoginManagerJournal m_LoginManagerJournal = new LoginManagerJournal();

        /* 213 */
        public Atom_PriceList_Name m_Atom_PriceList_Name = new Atom_PriceList_Name();

        /* 214 */
        public PriceList_Name m_PriceList_Name = new PriceList_Name();

        /* 215 */
        public Atom_ComputerName m_Atom_ComputerName = new Atom_ComputerName();

        /* 216 */
        public Atom_ComputerUserName m_Atom_ComputerUserName = new Atom_ComputerUserName();

        /* 217 */
        public Atom_MAC_address m_Atom_MAC_address = new Atom_MAC_address();

        /* 218 */
        public CaseItem m_CaseItem = new CaseItem();

        /* 219 */
        public CaseImage m_CaseImage = new CaseImage();

        /* 220 */
        public CustomerCase m_CustomerCase = new CustomerCase();

        /* 221 */
        public CaseParameter m_CaseParameter = new CaseParameter();

        /* 222 */
        public SettingsType m_SettingsType = new SettingsType();

        /* 223 */
        public SettingsValue m_SettingsValue = new SettingsValue();

        /* 224 */
        public ProgramModule m_ProgramModule = new ProgramModule();

        /* 225 */
        public PropertiesSettings m_PropertiesSettings = new PropertiesSettings();

        /* 226 */
        public LoginTag_TYPE m_LoginTag_TYPE = new LoginTag_TYPE();

        /* 227 */
        public LoginTag m_LoginTag = new LoginTag();

        /* 228 */
        public WorkAreaImage m_WorkAreaImage = new WorkAreaImage();

        /* 229 */
        public WorkArea m_WorkArea = new WorkArea();

        /* 230 */
        public DocInvoice_Atom_WorkArea m_DocInvoice_Atom_WorkArea = new DocInvoice_Atom_WorkArea();

        /* 231 */
        public Atom_IP_address m_Atom_IP_address = new Atom_IP_address();

        /* 232 */
        public myOrganisation_Person_SingleUser m_myOrganisation_Person_SingleUser = new myOrganisation_Person_SingleUser();

        /* 233 */
        public TermsOfPayment_Default m_TermsOfPayment_Default = new TermsOfPayment_Default();

        /* 234 */
        public Atom_ElectronicDevice m_Atom_ElectronicDevice = new Atom_ElectronicDevice();

        /* 235 */
        public LoginUsers_ParentGroup3 m_LoginUsers_ParentGroup3 = new LoginUsers_ParentGroup3();

        /* 236 */
        public LoginUsers_ParentGroup2 m_LoginUsers_ParentGroup2 = new LoginUsers_ParentGroup2();

        /* 237 */
        public LoginUsers_ParentGroup1 m_LoginUsers_ParentGroup1 = new LoginUsers_ParentGroup1();

        /* 238 */
        public JOURNAL_Atom_WorkPeriod_TYPE m_JOURNAL_Atom_WorkPeriod_TYPE = new JOURNAL_Atom_WorkPeriod_TYPE();

        /* 239 */
        public JOURNAL_Atom_WorkPeriod m_JOURNAL_Atom_WorkPeriod = new JOURNAL_Atom_WorkPeriod();

        /* 240 */
        public DocInvoice_ShopC_Item_AdditionalData m_DocInvoice_ShopC_Item_AdditionalData = new DocInvoice_ShopC_Item_AdditionalData();

        /* 241 */
        public WorkArea_ParentGroup3 m_WorkArea_ParentGroup3 = new WorkArea_ParentGroup3();

        /* 242 */
        public WorkArea_ParentGroup2 m_WorkArea_ParentGroup2 = new WorkArea_ParentGroup2();

        /* 243 */
        public WorkArea_ParentGroup1 m_WorkArea_ParentGroup1 = new WorkArea_ParentGroup1();

        /* 244 */
        public Current_DocInvoice_ID m_Current_DocInvoice_ID = new Current_DocInvoice_ID();

        /* 245 */
        public Current_DocProformaInvoice_ID m_Current_DocProformaInvoice_ID = new Current_DocProformaInvoice_ID();

        /* 246 */
        public DocInvoice_ShopC_Item_AdditionalData_TYPE m_DocInvoice_ShopC_Item_AdditionalData_TYPE = new DocInvoice_ShopC_Item_AdditionalData_TYPE();

    }
}
