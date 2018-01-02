using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeDB
{
    internal static class Upgrade_1_21_to_1_22
    {


        internal static object UpgradeDB_1_21_to_1_22(object obj, ref string Err)
        {
            if (DBSync.DBSync.Drop_VIEWs(ref Err))
            {
                //change Atom_myOrganisation_Person
                //change myOrganisation_Person

                string sql = @"
                        PRAGMA foreign_keys = OFF;
                        CREATE TABLE Atom_myOrganisation_Person_temp (
                        'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                        Atom_Person_ID INTEGER NOT NULL REFERENCES Atom_Person(ID),
                        Atom_Office_ID INTEGER NOT NULL REFERENCES Atom_Office(ID),
                        'Job' varchar(264) NULL,
                        'Description' varchar(2000) NULL );

                        insert into Atom_myOrganisation_Person_temp
                        (
                          ID,
                          Atom_Person_ID,
                          Atom_Office_ID,
                          'Job',
                          'Description'
                        )
                        select
                            ID,
                            Atom_Person_ID,
                            Atom_Office_ID,
                            'Job',
                            'Description'
                            from Atom_myOrganisation_Person;
                        DROP TABLE Atom_myOrganisation_Person;
                        ALTER TABLE Atom_myOrganisation_Person_temp RENAME TO Atom_myOrganisation_Person;

                        CREATE TABLE myOrganisation_Person_temp ( 
                        'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                        'Job' varchar(264) NULL,
                        'Active' BIT NOT NULL,
                        'Description' varchar(2000) NULL,
                        Person_ID INTEGER NOT NULL REFERENCES Person(ID),
                        Office_ID INTEGER NOT NULL REFERENCES Office(ID) );

                        insert into myOrganisation_Person_temp
                        (
                          ID,
                          Person_ID,
                          Office_ID,
                          'Job',
                          'Description',
                          Active
                        )
                        select
                            ID,
                            Person_ID,
                            Office_ID,
                            'Job',
                            'Description',
                            Active
                            from myOrganisation_Person;

                        DROP TABLE myOrganisation_Person;
                        ALTER TABLE myOrganisation_Person_temp RENAME TO myOrganisation_Person;

                        CREATE TABLE Item_temp (
                        'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                        'UniqueName' varchar(264) UNIQUE NOT NULL UNIQUE ,
                        'Name' varchar(264) NULL,
                         Unit_ID INTEGER NOT NULL REFERENCES Unit(ID),
                         'Code' INTEGER NOT NULL,
                        Item_ParentGroup1_ID INTEGER NULL REFERENCES Item_ParentGroup1(ID),
                       'barcode' varchar(32) NULL,
                       'Description' varchar(2000) NULL,
                        Item_Image_ID INTEGER NULL REFERENCES Item_Image(ID),
                        Expiry_ID INTEGER NULL REFERENCES Expiry(ID),
                        Warranty_ID INTEGER NULL REFERENCES Warranty(ID),
                        'ToOffer' BIT NOT NULL );

                        insert into Item_temp
                        (
                          ID,
                          UniqueName,
                          Name,
                          Unit_ID,
                          Code,
                          Item_ParentGroup1_ID,
                          barcode,
                          Description,
                          Item_Image_ID,
                          Expiry_ID,
                          Warranty_ID,
                          ToOffer
                        )
                        select
                          ID,
                          UniqueName,
                          Name,
                          Unit_ID,
                          Code,
                          Item_ParentGroup1_ID,
                          barcode,
                          Description,
                          Item_Image_ID,
                          Expiry_ID,
                          Warranty_ID,
                          ToOffer  from Item;

                        DROP TABLE Item;
                        ALTER TABLE Item_temp RENAME TO Item;

                        CREATE TABLE Atom_Item_temp (
                        'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                        'UniqueName' varchar(264) NOT NULL,
                        Atom_Item_Name_ID INTEGER NULL REFERENCES Atom_Item_Name(ID),
                        Atom_Unit_ID INTEGER NOT NULL REFERENCES Atom_Unit(ID),
                        Atom_Item_barcode_ID INTEGER NULL REFERENCES Atom_Item_barcode(ID),
                        Atom_Item_Description_ID INTEGER NULL REFERENCES Atom_Item_Description(ID),
                        Atom_Expiry_ID INTEGER NULL REFERENCES Atom_Expiry(ID),
                        Atom_Warranty_ID INTEGER NULL REFERENCES Atom_Warranty(ID) );


                        insert into Atom_Item_temp
                        (
                          ID,
                          UniqueName,
                          Atom_Item_Name_ID,
                          Atom_Unit_ID,
                          Atom_Item_barcode_ID,
                          Atom_Item_Description_ID,
                          Atom_Expiry_ID,
                          Atom_Warranty_ID
                        )
                        select
                          ID,
                          UniqueName,
                          Atom_Item_Name_ID,
                          Atom_Unit_ID,
                          Atom_Item_barcode_ID,
                          Atom_Item_Description_ID,
                          Atom_Expiry_ID,
                          Atom_Warranty_ID
                          from Atom_Item;

                        DROP TABLE Atom_Item;
                        ALTER TABLE Atom_Item_temp RENAME TO Atom_Item;

                        DROP TABLE JOURNAL_myOrganisation_Person_AccessR_TYPE;
                        DROP TABLE JOURNAL_myOrganisation_Person_AccessR;
                        DROP TABLE myOrganisation_Person_AccessR;
                        DROP TABLE AccessR;

                        delete from JOURNAL_DocInvoice  where ID in (select jdi.ID from JOURNAL_DocInvoice jdi where ID in (select ID from DocInvoice where FinancialYear = 2016 and Draft = 1));
                        delete from  DocInvoiceAddOn where ID in (select ID from DocInvoice where FinancialYear = 2016 and Draft = 1);
                        delete from DocInvoice_ShopA_item where DocInvoice_ID in (select ID from DocInvoice where FinancialYear = 2016 and Draft = 1);
                        delete from DocInvoice_ShopB_item where DocInvoice_ID in (select ID from DocInvoice where FinancialYear = 2016 and Draft = 1);
                        delete from DocInvoice_ShopC_item where DocInvoice_ID in (select ID from DocInvoice where FinancialYear = 2016 and Draft = 1);
                        delete from DocInvoice where FinancialYear = 2016 and Draft = 1;

                        PRAGMA foreign_keys = ON;
                        ";

                if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_21_to_1_22:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }

                string[] new_tables = new string[] {"LoginUsers",
                                                    "LoginRoles",
                                                    "LoginUsersAndLoginRoles",
                                                    "LoginSession",
                                                    "LoginFailed",
                                                    "LoginManagerEvent",
                                                    "LoginManagerJournal"    };

                if (DBSync.DBSync.CreateTables(new_tables, ref Err))
                {

                    if (DBSync.DBSync.Create_VIEWs())
                    {
                        return UpgradeDB_inThread.Set_DataBase_Version("1.22");
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
