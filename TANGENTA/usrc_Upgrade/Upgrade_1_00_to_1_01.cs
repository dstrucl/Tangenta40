using CodeTables;
using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TangentaTableClass;

namespace UpgradeDB
{
    internal static class Upgrade_1_00_to_1_01
    {
        internal static object UpgradeDB_1_00_to_1_01(object o, ref string Err)
        {
            Transaction transaction_UpgradeDB_1_00_to_1_01 = new Transaction("UpgradeDB_1_00_to_1_01", DBSync.DBSync.MyTransactionLog_delegates);
            SQLTable tbl_Logo = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Logo));
            if (transaction_UpgradeDB_1_00_to_1_01.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,tbl_Logo.sql_CreateTable, null, ref Err))
            {
                SQLTable tbl_Atom_Logo = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Atom_Logo));
                if (transaction_UpgradeDB_1_00_to_1_01.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,tbl_Atom_Logo.sql_CreateTable, null, ref Err))
                {
                    string sql = "alter table OrganisationData add column Logo_ID NULL references Logo(ID)";
                    if (transaction_UpgradeDB_1_00_to_1_01.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                    {
                        sql = "alter table Atom_OrganisationData add column Atom_Logo_ID NULL references Atom_Logo(ID)";
                        if (transaction_UpgradeDB_1_00_to_1_01.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                        {
                            sql = "DROP VIEW OrganisationData_VIEW";
                            if (transaction_UpgradeDB_1_00_to_1_01.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                            {
                                sql = "DROP VIEW Atom_OrganisationData_VIEW";
                                if (transaction_UpgradeDB_1_00_to_1_01.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                {
                                    SQLTable tbl_OrganisationData = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(OrganisationData));
                                    if (transaction_UpgradeDB_1_00_to_1_01.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,tbl_OrganisationData.sql_CreateView, null, ref Err))
                                    {
                                        SQLTable tbl_Atom_OrganisationData = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Atom_OrganisationData));
                                        if (transaction_UpgradeDB_1_00_to_1_01.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,tbl_Atom_OrganisationData.sql_CreateView, null, ref Err))
                                        {

                                            sql = @"PRAGMA foreign_keys = OFF;
                                                    CREATE TABLE Atom_OrganisationData_tmp
                                                    (
                                                    'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                    Atom_Organisation_ID  INTEGER  NOT NULL REFERENCES Atom_Organisation(ID),
                                                    Atom_cAddress_Org_ID  INTEGER  NULL REFERENCES Atom_cAddress_Org(ID),
                                                    cPhoneNumber_Org_ID  INTEGER  NULL REFERENCES cPhoneNumber_Org(ID),
                                                    cFaxNumber_Org_ID  INTEGER  NULL REFERENCES cFaxNumber_Org(ID),
                                                    cEmail_Org_ID  INTEGER  NULL REFERENCES cEmail_Org(ID),
                                                    cHomePage_Org_ID  INTEGER  NULL REFERENCES cHomePage_Org(ID),
                                                    cOrgTYPE_ID  INTEGER  NULL REFERENCES cOrgTYPE(ID),
                                                    'BankName' varchar(264) NULL,
                                                    'TRR' varchar(264) NULL
                                                    , Atom_Logo_ID NULL references Atom_Logo(ID));

                                            INSERT INTO Atom_OrganisationData_tmp (id, Atom_Organisation_ID, Atom_cAddress_Org_ID,cPhoneNumber_Org_ID,cFaxNumber_Org_ID,cEmail_Org_ID,cHomePage_Org_ID,cOrgTYPE_ID,BankName,TRR,Atom_Logo_ID)
                                                SELECT id, Atom_Organisation_ID, Atom_cAddress_Org_ID,cPhoneNumber_Org_ID,cFaxNumber_Org_ID,cEmail_Org_ID,cHomePage_Org_ID,cOrgTYPE_ID,BankName,TRR,Atom_Logo_ID FROM Atom_OrganisationData;
                                            DROP TABLE Atom_OrganisationData;
                                            ALTER TABLE Atom_OrganisationData_tmp RENAME TO Atom_OrganisationData;

                                            CREATE TABLE OrganisationData_tmp
                                                    (
                                                    'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                    Organisation_ID  INTEGER  NOT NULL REFERENCES Organisation(ID),
                                                    cAddress_Org_ID  INTEGER  NULL REFERENCES cAddress_Org(ID),
                                                    cPhoneNumber_Org_ID  INTEGER  NULL REFERENCES cPhoneNumber_Org(ID),
                                                    cFaxNumber_Org_ID  INTEGER  NULL REFERENCES cFaxNumber_Org(ID),
                                                    cEmail_Org_ID  INTEGER  NULL REFERENCES cEmail_Org(ID),
                                                    cHomePage_Org_ID  INTEGER  NULL REFERENCES cHomePage_Org(ID),
                                                    cOrgTYPE_ID  INTEGER  NULL REFERENCES cOrgTYPE(ID),
                                                    Logo_ID NULL references Logo(ID));

                                            INSERT INTO OrganisationData_tmp (id, Organisation_ID, cAddress_Org_ID,cPhoneNumber_Org_ID,cFaxNumber_Org_ID,cEmail_Org_ID,cHomePage_Org_ID,cOrgTYPE_ID,Logo_ID)
                                                SELECT id, Organisation_ID, cAddress_Org_ID,cPhoneNumber_Org_ID,cFaxNumber_Org_ID,cEmail_Org_ID,cHomePage_Org_ID,cOrgTYPE_ID,Logo_ID FROM OrganisationData;
                                            DROP TABLE OrganisationData;
                                            ALTER TABLE OrganisationData_tmp RENAME TO OrganisationData;


                                            CREATE TABLE Atom_PriceList_tmp
                                              (
                                              'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                              'Name' varchar(264) UNIQUE  NOT NULL UNIQUE ,
                                              'Valid' BIT NOT NULL,
                                              'ValidFrom' DATETIME NULL,
                                              'ValidTo' DATETIME NULL,
                                              'Description' varchar(2000) NULL,
                                               Atom_Currency_ID  INTEGER  NOT NULL REFERENCES Atom_Currency(ID),
                                               Atom_myOrganisation_Person_ID  INTEGER  NOT NULL REFERENCES Atom_myOrganisation_Person(ID)
                                              );
                                            INSERT INTO Atom_PriceList_tmp (id, Name, Valid,ValidFrom,ValidTo,Description,Atom_Currency_ID,Atom_myOrganisation_Person_ID)
                                                SELECT id, Name, Valid,ValidFrom,ValidTo,Description,Atom_Currency_ID,Atom_myOrganisation_Person_ID FROM Atom_PriceList;
                                            DROP TABLE Atom_PriceList;
                                            ALTER TABLE Atom_PriceList_tmp RENAME TO Atom_PriceList;

                                            PRAGMA foreign_keys = ON;";

                                            if (transaction_UpgradeDB_1_00_to_1_01.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                            {
                                                DataTable dt = new DataTable();
                                                sql = "select Organisation_ID from myOrganisation order by ID desc";
                                                long Organisation_ID = -1;
                                                if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                                                {
                                                    if (dt.Rows.Count > 0)
                                                    {
                                                        Organisation_ID = (long)dt.Rows[0]["Organisation_ID"];
                                                    }
                                                }
                                                sql = @"PRAGMA foreign_keys = OFF;
                                                DROP TABLE myOrganisation;
                                                CREATE TABLE myOrganisation
                                                    (
                                                    'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                    OrganisationData_ID  INTEGER  NOT NULL REFERENCES OrganisationData(ID) UNIQUE
                                                    );";
                                                if (transaction_UpgradeDB_1_00_to_1_01.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                                {
                                                    if (Organisation_ID >= 0)
                                                    {
                                                        sql = "select ID  from OrganisationData where Organisation_ID = " + Organisation_ID.ToString() + " order by ID desc";
                                                        long OrganisationData_ID = -1;
                                                        dt.Clear();
                                                        if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                                                        {
                                                            if (dt.Rows.Count > 0)
                                                            {
                                                                OrganisationData_ID = (long)dt.Rows[0]["ID"];
                                                                sql = "insert into myOrganisation (OrganisationData_ID)values(" + OrganisationData_ID.ToString() + ");";
                                                                if (!transaction_UpgradeDB_1_00_to_1_01.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                                                {
                                                                    return false;
                                                                }
                                                            }
                                                        }
                                                    }

                                                    dt.Clear();
                                                    sql = "select Atom_Organisation_ID from Atom_myOrganisation order by ID desc";
                                                    long Atom_Organisation_ID = -1;
                                                    if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                                                    {
                                                        if (dt.Rows.Count > 0)
                                                        {
                                                            Atom_Organisation_ID = (long)dt.Rows[0]["Atom_Organisation_ID"];
                                                        }
                                                    }
                                                    sql = @"PRAGMA foreign_keys = OFF;
                                                    DROP TABLE Atom_myOrganisation;
                                                    CREATE TABLE Atom_myOrganisation
                                                        (
                                                        'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                        Atom_OrganisationData_ID  INTEGER  NOT NULL REFERENCES Atom_OrganisationData(ID) UNIQUE
                                                        );";
                                                    if (transaction_UpgradeDB_1_00_to_1_01.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                                    {
                                                        if (Atom_Organisation_ID >= 0)
                                                        {
                                                            sql = "select ID  from Atom_OrganisationData where Atom_Organisation_ID = " + Atom_Organisation_ID.ToString() + " order by ID desc";
                                                            long Atom_OrganisationData_ID = -1;
                                                            dt.Clear();
                                                            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                                                            {
                                                                if (dt.Rows.Count > 0)
                                                                {
                                                                    Atom_OrganisationData_ID = (long)dt.Rows[0]["ID"];
                                                                    sql = "insert into Atom_myOrganisation (Atom_OrganisationData_ID)values(" + Atom_OrganisationData_ID.ToString() + ");";
                                                                    if (!transaction_UpgradeDB_1_00_to_1_01.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                                                    {
                                                                        return false;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        sql = "DROP VIEW myOrganisation_Person_VIEW";
                                                        if (transaction_UpgradeDB_1_00_to_1_01.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                                        {
                                                            SQLTable tbl_myOrganisation_Person = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(myOrganisation_Person));
                                                            if (transaction_UpgradeDB_1_00_to_1_01.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,tbl_myOrganisation_Person.sql_CreateView, null, ref Err))
                                                            {
                                                                sql = "DROP VIEW myOrganisation_VIEW";
                                                                if (transaction_UpgradeDB_1_00_to_1_01.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                                                {
                                                                    SQLTable tbl_myOrganisation = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(myOrganisation));
                                                                    if (transaction_UpgradeDB_1_00_to_1_01.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,tbl_myOrganisation.sql_CreateView, null, ref Err))
                                                                    {
                                                                        sql = "DROP VIEW Atom_myOrganisation_Person_VIEW";
                                                                        if (transaction_UpgradeDB_1_00_to_1_01.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                                                        {
                                                                            SQLTable tbl_Atom_myOrganisation_Person = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Atom_myOrganisation_Person));
                                                                            if (transaction_UpgradeDB_1_00_to_1_01.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,tbl_Atom_myOrganisation_Person.sql_CreateView, null, ref Err))
                                                                            {
                                                                                sql = "DROP VIEW Atom_myOrganisation_VIEW";
                                                                                if (transaction_UpgradeDB_1_00_to_1_01.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                                                                {
                                                                                    SQLTable tbl_Atom_myOrganisation = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Atom_myOrganisation));
                                                                                    if (transaction_UpgradeDB_1_00_to_1_01.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,tbl_Atom_myOrganisation.sql_CreateView, null, ref Err))
                                                                                    {

                                                                                        sql = "DROP VIEW DocInvoice_VIEW";
                                                                                        if (transaction_UpgradeDB_1_00_to_1_01.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                                                                        {
                                                                                            SQLTable tbl_DocInvoice = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(DocInvoice));
                                                                                            if (transaction_UpgradeDB_1_00_to_1_01.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,tbl_DocInvoice.sql_CreateView, null, ref Err))
                                                                                            {
                                                                                                sql = "DROP VIEW JOURNAL_DocInvoice_VIEW";
                                                                                                if (transaction_UpgradeDB_1_00_to_1_01.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                                                                                {
                                                                                                    SQLTable tbl_JOURNAL_DocInvoice = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(JOURNAL_DocInvoice));
                                                                                                    if (transaction_UpgradeDB_1_00_to_1_01.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,tbl_JOURNAL_DocInvoice.sql_CreateView, null, ref Err))
                                                                                                    {
                                                                                                        if (UpgradeDB_inThread.Set_DataBase_Version("1.01", transaction_UpgradeDB_1_00_to_1_01))
                                                                                                        {
                                                                                                            if (transaction_UpgradeDB_1_00_to_1_01.Commit())
                                                                                                            {
                                                                                                                return true;
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                return false;
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            transaction_UpgradeDB_1_00_to_1_01.Rollback();
            LogFile.Error.Show("ERROR:usrc_Invoice:UpgradeDB_1_0_to_1_01:Err=" + Err);
            return false;
        }

    }
}
