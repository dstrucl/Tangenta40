#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace InvoiceDB
{
    public class xUnitList
    {
        public List<xUnit> m_DefaltUnitList = new List<xUnit>();

        public int Count = 0;
        public xUnit[] items = null;

        public xUnitList()
        {
            m_DefaltUnitList.Add(new xUnit(1,1,"komad", "kom.", 0,true, "Artikli kot komadi."));
            m_DefaltUnitList.Add(new xUnit(2,2, "ura", "h", 2,false, "Za vse, kar se meri v urah"));
            m_DefaltUnitList.Add(new xUnit(3,3, "dan", "dan", 2, false, "Za vse, kar se meri v dnevih"));
            m_DefaltUnitList.Add(new xUnit(4,4,"mesec", "mes", 2, false, "Za vse, kar se meri v mesecih"));
            m_DefaltUnitList.Add(new xUnit(5,5,"leto", "mes", 2,false, "Za vse, kar se meri v mesecih"));
            m_DefaltUnitList.Add(new xUnit(6,6,"meter", "m", 2, true, "Za kar se, prodaja na dolžinsko enoto"));
            m_DefaltUnitList.Add(new xUnit(7,7,"kvadratni meter", "m2", 2, true, "Za vse kar se prodaja glede na površino"));
            m_DefaltUnitList.Add(new xUnit(8,8,"kubični meter", "m3", 2, true, "Za vse kar se prodaja glede na prostornino"));
            m_DefaltUnitList.Add(new xUnit(9,9,"kilowatna ura", "kWh", 2, false, "Prodaja energije"));
            m_DefaltUnitList.Add(new xUnit(10,10,"kilometrina", "km", 0, false, "Obračun kilometrine"));
            m_DefaltUnitList.Add(new xUnit(11,11,"kilogram", "kg", 2, true, "Masa artikla"));
            m_DefaltUnitList.Add(new xUnit(12,12,"liter", "l", 2, true, "Za snovi, ki se prodajajo glede na prostornino"));
        }

        public bool Get(ref DataTable dt, ref string Err)
        {
            string sql_Unit = "select * from Unit";
            dt.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_Unit, ref Err))
            {
                Count = dt.Rows.Count;
                items = new xUnit[Count];
                if (Count > 0)
                {
                    int i = 0;
                    for (i = 0; i < Count; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        string desc = null;
                        if (dr["Description"] is string)
                        {
                            desc = (string)dr["Description"];
                        }
                        items[i] = new xUnit(i,(long)dr["ID"], (string)dr["Name"],(string)dr["Symbol"], (int)dr["DecimalPlaces"], (bool)dr["StorageOption"], desc);
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    public class xUnit
    {
        private int m_Index = -1;
        private long m_ID = -1;
        private string m_Name = null;
        private string m_Symbol = null;
        private int m_DecimalPlaces = -1;
        private bool m_StorageOption = false;
        private string m_Description = null;

        public int Index
        {
            get { return m_Index; }
        }

        public long ID
        {
            get { return m_ID; }
        }

        public string Name
        {
            get { return m_Name; }
        }

        public string Symbol
        {
            get { return m_Symbol; }
        }


        public int DecimalPlaces
        {
            get { return m_DecimalPlaces; }
        }
        public bool StorageOption
        {
            get { return m_StorageOption; }
        }

        public string Description
        {
            get { return m_Description; }
        }



        public xUnit()
        {
        }

        public xUnit(int xIndex,long xID,string xName, string xSymbol, int xDecimalPlaces,bool xStorageOption, string xDescription)
        {
            m_Index = xIndex;
            m_ID = xID;
            m_Name = xName;
            m_Symbol = xSymbol;
            m_DecimalPlaces = xDecimalPlaces;
            m_StorageOption = xStorageOption;
            m_Description = xDescription;
        }

        internal bool SetUnit(long unit_id, ref string Err)
        {
            string sql_BaseUnit = "select Name,Symbol,DecimalPlaces,StorageOption,Description from Unit where ID = " + unit_id.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_BaseUnit, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    m_ID = unit_id;
                    m_Name = (string)dt.Rows[0]["Name"];
                    m_Symbol = (string)dt.Rows[0]["Symbol"];
                    m_DecimalPlaces = (int)dt.Rows[0]["DecimalPlaces"];
                    m_StorageOption = (bool)dt.Rows[0]["StorageOption"];
                    object oDescription = dt.Rows[0]["Description"];
                    if (oDescription.GetType() == typeof(string))
                    {
                        m_Description = (string)oDescription;
                    }
                    else
                    {
                        m_Description = null;
                    }

                    return true;
                }
                else
                {
                    Err = "ERROR:Unit id = " + unit_id.ToString() + " not found in table Unit";
                    return false;
                }
            }
            else
            {
                Err = "ERROR:xUnit:SetUnit:Err=" + Err;
                return false;
            }
        }
    }
}
