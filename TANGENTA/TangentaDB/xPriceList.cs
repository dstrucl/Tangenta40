#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public class xPriceList
    {
        public class RowData
        {
            public long ID;
            public string Name = null;
            public bool Valid = false;
            public DBTypes.DateTime_v ValidFrom = null;
            public DBTypes.DateTime_v ValidTo = null;
            public DBTypes.DateTime_v CreationDate = null;
            public DBTypes.string_v Description = null;
            //public DBTypes.string_v myOrganisation_Person_UserName = null;
            //public DBTypes.string_v myOrganisation_Person_FirstName = null;
            //public DBTypes.string_v myOrganisation_Person_LastName = null;
            //public DBTypes.string_v myOrganisation_Person_Job = null;
            //public DBTypes.string_v myOrganisation_Person_Description = null;
            //public DBTypes.bool_v myOrganisation_Person_Active = null;
            public xCurrency m_xCurrency = new xCurrency();

            public string xPriceList_Name
            {
                get { return Name; }
            }

            public long xPriceList_ID
            {
                get { return ID; }
            }

            public void GetRowData(DataTable dt_xPriceList, int index)
            {
                if (index < dt_xPriceList.Rows.Count)
                {
                    ID = (long)dt_xPriceList.Rows[index]["ID"];
                    Name = (string)dt_xPriceList.Rows[index]["Name"];
                    Valid = (bool)dt_xPriceList.Rows[index]["Valid"];
                    object oValidFrom = dt_xPriceList.Rows[index]["ValidFrom"];
                    if (oValidFrom.GetType() == typeof(DateTime))
                    {
                        if (ValidFrom == null)
                        {
                            ValidFrom = new DBTypes.DateTime_v();
                        }
                        ValidFrom.v = (DateTime)oValidFrom;
                    }
                    else
                    {
                        ValidFrom = null;
                    }

                    object oValidTo = dt_xPriceList.Rows[index]["ValidTo"];

                    if (oValidTo.GetType() == typeof(DateTime))
                    {
                        if (ValidTo == null)
                        {
                            ValidTo = new DBTypes.DateTime_v();
                        }
                        ValidTo.v = (DateTime)oValidTo;
                    }
                    else
                    {
                        ValidTo = null;
                    }
                    object oCreationDate = dt_xPriceList.Rows[index]["CreationDate"];
                    if (oCreationDate.GetType() == typeof(DateTime))
                    {
                        if (CreationDate == null)
                        {
                            CreationDate = new DBTypes.DateTime_v();
                        }
                        CreationDate.v = (DateTime)oCreationDate;
                    }
                    else
                    {
                        CreationDate = null;
                    }
                    object oDescription = dt_xPriceList.Rows[index]["Description"];
                    if (oDescription.GetType() == typeof(string))
                    {
                        if (Description == null)
                        {
                            Description = new DBTypes.string_v();
                        }
                        Description.v = (string)oDescription;
                    }
                    else
                    {
                        Description = null;
                    }
                    //object omyOrganisation_Person_UserName = dt_xPriceList.Rows[index]["UserName"];
                    //if (omyOrganisation_Person_UserName.GetType() == typeof(string))
                    //{
                    //    if (myOrganisation_Person_UserName == null)
                    //    {
                    //        myOrganisation_Person_UserName = new DBTypes.string_v();
                    //    }
                    //    myOrganisation_Person_UserName.v = (string)omyOrganisation_Person_UserName;
                    //}
                    //else
                    //{
                    //    myOrganisation_Person_UserName = null;
                    //}

                    //object omyOrganisation_Person_FirstName = dt_xPriceList.Rows[index]["FirstName"];
                    //if (omyOrganisation_Person_FirstName.GetType() == typeof(string))
                    //{
                    //    if (myOrganisation_Person_FirstName == null)
                    //    {
                    //        myOrganisation_Person_FirstName = new DBTypes.string_v();
                    //    }
                    //    myOrganisation_Person_FirstName.v = (string)omyOrganisation_Person_FirstName;
                    //}
                    //else
                    //{
                    //    myOrganisation_Person_FirstName = null;
                    //}
                    //object omyOrganisation_Person_LastName = dt_xPriceList.Rows[index]["LastName"];
                    //if (omyOrganisation_Person_LastName.GetType() == typeof(string))
                    //{
                    //    if (myOrganisation_Person_LastName == null)
                    //    {
                    //        myOrganisation_Person_LastName = new DBTypes.string_v();
                    //    }
                    //    myOrganisation_Person_LastName.v = (string)omyOrganisation_Person_LastName;
                    //}
                    //else
                    //{
                    //    myOrganisation_Person_LastName = null;
                    //}

                    //object omyOrganisation_Person_Job = dt_xPriceList.Rows[index]["Job"];
                    //if (omyOrganisation_Person_Job.GetType() == typeof(string))
                    //{
                    //    if (myOrganisation_Person_Job == null)
                    //    {
                    //        myOrganisation_Person_Job = new DBTypes.string_v();
                    //    }
                    //    myOrganisation_Person_Job.v = (string)omyOrganisation_Person_Job;
                    //}
                    //else
                    //{
                    //    myOrganisation_Person_Job = null;
                    //}

                    //object omyOrganisation_Person_Description = dt_xPriceList.Rows[index]["myOrganisation_Person_Description"];
                    //if (omyOrganisation_Person_Description.GetType() == typeof(string))
                    //{
                    //    if (myOrganisation_Person_Description == null)
                    //    {
                    //        myOrganisation_Person_Description = new DBTypes.string_v();
                    //    }
                    //    myOrganisation_Person_Description.v = (string)omyOrganisation_Person_Description;
                    //}
                    //else
                    //{
                    //    myOrganisation_Person_Description = null;
                    //}

                    //object omyOrganisation_Person_Active = dt_xPriceList.Rows[index]["Active"];
                    //if (omyOrganisation_Person_Active.GetType() == typeof(bool))
                    //{
                    //    if (myOrganisation_Person_Active == null)
                    //    {
                    //        myOrganisation_Person_Active = new DBTypes.bool_v();
                    //    }
                    //    myOrganisation_Person_Active.v = (bool)omyOrganisation_Person_Active;
                    //}
                    //else
                    //{
                    //    myOrganisation_Person_Active = null;
                    //}


                    object oCurrency_ID = dt_xPriceList.Rows[index]["Currency_ID"];
                    if (oCurrency_ID.GetType() == typeof(long))
                    {
                        m_xCurrency.ID = (long)oCurrency_ID;
                    }
                    else
                    {
                        m_xCurrency.ID = -1;
                    }

                    object oCurrency_Name = dt_xPriceList.Rows[index]["Currency_Name"];
                    if (oCurrency_Name.GetType() == typeof(string))
                    {
                        m_xCurrency.Name = (string)oCurrency_Name;
                    }
                    else
                    {
                        m_xCurrency.Name = null;
                    }

                    object oCurrency_Abbreviation = dt_xPriceList.Rows[index]["Currency_Abbreviation"];
                    if (oCurrency_Abbreviation.GetType() == typeof(string))
                    {
                        m_xCurrency.Abbreviation = (string)oCurrency_Abbreviation;
                    }
                    else
                    {
                        m_xCurrency.Abbreviation = null;
                    }

                    object oCurrency_Symbol = dt_xPriceList.Rows[index]["Currency_Symbol"];
                    if (oCurrency_Symbol.GetType() == typeof(string))
                    {
                        m_xCurrency.Symbol = (string)oCurrency_Symbol;
                    }
                    else
                    {
                        m_xCurrency.Symbol = null;
                    }
                    object oCurrency_CurrencyCode = dt_xPriceList.Rows[index]["Currency_CurrencyCode"];
                    if (oCurrency_CurrencyCode.GetType() == typeof(int))
                    {
                        m_xCurrency.CurrencyCode = (int)oCurrency_CurrencyCode;
                    }
                    else
                    {
                        m_xCurrency.CurrencyCode = -1;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:dt_xPriceList:GetRowData:index our of range! index = " + index.ToString() + ",dt_xPriceList.Rows.Count = " + dt_xPriceList.Rows.Count.ToString());
                }
            }
        }

        public DataTable dt_xPriceList = new DataTable();
        public RowData rowData = null;
        public int Count;
        public List<RowData> List_xPriceList = new List<RowData>();

        public bool Get_PriceLists_of_Currency(long Currency_ID, ref int iCount, ref string Err)
        {
            //            string sql_select_PriceList = @"SELECT 
            //              PriceList.ID,
            //              PriceList.Name,
            //              PriceList.Valid,
            //              PriceList.ValidFrom,
            //              PriceList.ValidTo,
            //              PriceList.CreationDate,
            //              PriceList.Description,
            //              myOrganisation_Person.UserName,
            //              cFirstName.FirstName,
            //              cLastName.LastName,
            //              myOrganisation_Person.Active,
            //              myOrganisation_Person.Job,
            //              PersonData.Description as myOrganisation_Person_Description,
            //              Currency.ID as Currency_ID,
            //              Currency.Name as Currency_Name,
            //              Currency.Abbreviation as Currency_Abbreviation,
            //              Currency.Symbol as Currency_Symbol,
            //              Currency.CurrencyCode as Currency_CurrencyCode
            //            FROM PriceList 
            //            INNER JOIN Currency ON Currency.ID = PriceList.Currency_ID 
            //            LEFT JOIN myOrganisation_Person ON myOrganisation_Person.ID = PriceList.myOrganisation_Person_ID 
            //            LEFT JOIN Person ON myOrganisation_Person.Person_ID = Person.ID 
            //            LEFT JOIN cFirstName ON Person.cFirstName_ID = cFirstName.ID 
            //            LEFT JOIN cLastName ON Person.cLastName_ID = cLastName.ID 
            //            LEFT JOIN PersonData ON PersonData.Person_ID = Person.ID 
            //            where PriceList.Valid = 1  and PriceList.Currency_ID = " + Currency_ID.ToString();
            string sql_select_PriceList = @"SELECT 
              pl.ID,
              pln.Name,
              pl.Valid,
              pl.ValidFrom,
              pl.ValidTo,
              pl.CreationDate,
              pl.Description,
              cur.ID as Currency_ID,
              cur.Name as Currency_Name,
              cur.Abbreviation as Currency_Abbreviation,
              cur.Symbol as Currency_Symbol,
              cur.CurrencyCode as Currency_CurrencyCode
            FROM PriceList pl
            INNER JOIN PriceList_Name pln on pln.ID = pl.PriceList_Name_ID
            INNER JOIN Currency cur ON cur.ID = pl.Currency_ID 
            where pl.Valid = 1  and pl.Currency_ID = " + Currency_ID.ToString();
            dt_xPriceList.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dt_xPriceList, sql_select_PriceList, null, ref Err))
            {
                Count = dt_xPriceList.Rows.Count;
                iCount = Count;
                if (Count > 0)
                {
                    int idx;
                    for (idx = 0; idx < iCount; idx++)
                    {
                        RowData rd = new RowData();
                        rd.GetRowData(dt_xPriceList, idx);
                        List_xPriceList.Add(rd);
                        if (idx == 0)
                        {
                            rowData = rd;
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Get_PriceList(long PriceList_ID, ref int iCount, ref string Err)
        {
            string sql_select_PriceList = @"SELECT 
              pl.ID,
              pln.Name,
              pl.Valid,
              pl.ValidFrom,
              pl.ValidTo,
              pl.CreationDate,
              pl.Description,
              cur.ID as Currency_ID,
              cur.Name as Currency_Name,
              cur.Abbreviation as Currency_Abbreviation,
              cur.Symbol as Currency_Symbol,
              cur.CurrencyCode as Currency_CurrencyCode
            FROM PriceList pl
            INNER JOIN PriceList_Name pln on pln.ID = pl.PriceList_Name_ID
            INNER JOIN Currency cur ON cur.ID = pl.Currency_ID 
            where pl.ID = " + PriceList_ID.ToString();

            dt_xPriceList.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dt_xPriceList, sql_select_PriceList, null, ref Err))
            {
                Count = dt_xPriceList.Rows.Count;
                iCount = Count;
                if (Count > 0)
                {
                    RowData rowData = new RowData();
                    rowData.GetRowData(dt_xPriceList, 0);
                    return true;
                }
                else
                {
                    Err = "ERROR:No PriceList data for PriceList_ID = " + PriceList_ID.ToString();
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
