#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBConnectionControl40;
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
                    if (m_xCurrency.ID == null)
                    {
                        m_xCurrency.ID = new ID();
                    }
                    m_xCurrency.ID.Set(dt_xPriceList.Rows[index]["Currency_ID"]);

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

        public bool Get_PriceLists_of_Currency(ID Currency_ID, ref int iCount, ref string Err)
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

        public bool Get_PriceList(ID PriceList_ID, ref int iCount, ref string Err)
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
